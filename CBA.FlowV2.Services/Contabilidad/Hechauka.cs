#region Using
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Data;
using System.Collections;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

using System.Text;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

/// <summary>
/// Summary description for Hechauka
/// </summary>
public class Hechauka
{
    #region Variables Privadas
    private int decimales = 10;
    private decimal sucursalId = -1;
    private string rucRepresentante = "-1";
    private string dvRepresentante = "-1";
    private string representante = "";
    private string rucAgente = "-1";
    private string dvAgente = "-1";
    private string agente = "";
    private string fechaInicial = string.Empty;
    private string fechaFinal = string.Empty;
    private string tipoLibro = string.Empty;
    private string version = "3";
    List<string> archivos;
    private decimal tipoDatos;

   
    #endregion

    #region Constantes
    private const string pathServidor = @"~/" + "/Resources/Hechauka/";
    private const string pathTemporal = "tmp\\";
    #endregion Constantes

    #region Constructor
    public Hechauka(string rucRepresentante, string dvRepresentante, string representante, string rucAgente, string dvAgente, string agente, string fechaInicial, string fechaFinal, string tipoLibro, decimal tipoDatos)
    {
        this.rucRepresentante = rucRepresentante;
        this.dvRepresentante = dvRepresentante;
        if (dvRepresentante.Trim().Equals(string.Empty))
            this.dvRepresentante = "0";
        this.representante = representante;
        this.rucAgente = rucAgente;
        this.dvAgente = dvAgente;
        this.agente = agente;
        this.fechaInicial = fechaInicial;
        this.fechaFinal = fechaFinal;
        this.tipoLibro = tipoLibro;
        this.tipoDatos = tipoDatos;

        this.archivos = new List<string>();
    }
    #endregion Constructor

    #region Compra Consolidado Hechauka
    public DataTable ObtenerDatosCompraHechauka()
    {
        try
        {
            DataTable dtDatos = new DataTable();

            using (SessionService sesion = new SessionService())
            {
                StringBuilder queryCompra = new StringBuilder();
                queryCompra.Append("SELECT 2                                                 tipo_registro, \n");
                queryCompra.Append("       tipo_documento, \n");
                queryCompra.Append("       plazo, \n");
                queryCompra.Append("       decode(condicion_compra, 'CONTADO', 0, \n");
                queryCompra.Append("                              'CREDITO', cantidad_pagos) cantidad_pagos, \n");
                queryCompra.Append("       caso_id                                           nro_caso, \n");
                queryCompra.Append("       proveedor_nombre                                  nombre_proveedor, \n");
                queryCompra.Append("       0                                                 tipo_operacion, \n");
                queryCompra.Append("       decode(condicion_compra, 'CONTADO', 1, \n");
                queryCompra.Append("                                'CREDITO', 2)            condicion_compra, \n");
                queryCompra.Append("       sucursal_nombre, \n");
                queryCompra.Append("       fecha_factura                                     fecha, \n");
                queryCompra.Append("       TO_char(fecha_factura, 'DD/MM/YYYY')              fecha_documento, \n");
                queryCompra.Append("       TO_char(fecha_factura, 'YYYYMM')                  periodo, \n");
                queryCompra.Append("       nro_comprobante nro_documento, \n");
                queryCompra.Append("       nro_timbrado, \n");
                queryCompra.Append("       ruc                                               ruc_proveedor, \n");
                queryCompra.Append("       dv, \n");
                queryCompra.Append("       round(nvl(SUM(total_pago),0),9)                                   total_pago, \n");
                queryCompra.Append("       round(nvl(SUM(total_gravado_10),0),9)                             monto_compra_10, \n");
                queryCompra.Append("       round(nvl(SUM(total_iva_10),0),9)                                 iva_credito_10, \n");
                queryCompra.Append("       round(nvl(SUM(total_gravado_5),0),9)                              monto_compra_5, \n");
                queryCompra.Append("       round(nvl(SUM(total_iva_5),0),9)                                  iva_credito_5, \n");
                queryCompra.Append("       round(nvl(SUM(total_exento),0),9)                                 monto_compra_exenta \n");
                queryCompra.Append("FROM   (SELECT tipo_documento, \n");
                queryCompra.Append("               plazo, \n");
                queryCompra.Append("               cantidad_pagos, \n");
                queryCompra.Append("               caso_id, \n");
                queryCompra.Append("               proveedor_nombre, \n");
                queryCompra.Append("               sucursal_nombre, \n");
                queryCompra.Append("               fecha_factura, \n");
                queryCompra.Append("               nro_comprobante, \n");
                queryCompra.Append("               nro_timbrado, \n");
                queryCompra.Append("               ruc, \n");
                queryCompra.Append("               dv, \n");
                queryCompra.Append("               condicion_compra, \n");
                queryCompra.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryCompra.Append("                                           ELSE total_pago \n");
                queryCompra.Append("                                           END) \n");
                queryCompra.Append("               ELSE SUM(total_pago) \n");
                queryCompra.Append("               END      total_pago, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN (total_pago - total_impuesto_descontado) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_gravado_10, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN total_impuesto_descontado \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_iva_10, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN (total_pago - total_impuesto_descontado) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_gravado_5, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN total_impuesto_descontado \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_iva_5, \n");
                queryCompra.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryCompra.Append("                                           ELSE (total_pago - total_impuesto_descontado) * (1 - porcentaje_impuesto / porcentaje_comparacion) \n");
                queryCompra.Append("                                           END) \n");
                queryCompra.Append("               ELSE SUM(CASE porcentaje_comparacion WHEN 0 THEN total_pago \n");
                queryCompra.Append("                        ELSE 0 \n");
                queryCompra.Append("                        END) \n");
                queryCompra.Append("               END      total_exento \n");
                queryCompra.Append("        FROM   (SELECT ccp.nombre                                       plazo, \n");
                queryCompra.Append("                       1                                                tipo_documento, \n");
                queryCompra.Append("                       ccp.cantidad_pagos, \n");
                queryCompra.Append("                       (SELECT ccp.tipo_condicion_pago \n");
                queryCompra.Append("                        FROM   ctacte_condiciones_pago ccp \n");
                queryCompra.Append("                        WHERE  ccp.id = fc.ctacte_condicion_pago_id)    condicion_compra, \n");
                queryCompra.Append("                       fd.id, \n");
                queryCompra.Append("                       fc.caso_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then fc.proveedor_nombre else 'Proveedores del Exterior' end proveedor_nombre, \n");
                queryCompra.Append("                       fc.sucursal_nombre, \n");
                queryCompra.Append("                       trunc(fc.fecha_factura)                          fecha_factura, \n");
                queryCompra.Append("                       fc.nro_comprobante, \n");
                queryCompra.Append("                       fc.nro_timbrado, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_pago \n");
                queryCompra.Append("                       ELSE fd.total_pago / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_pago, \n");
                queryCompra.Append("                       imp.porcentaje_hijo                              porcentaje_impuesto, \n");
                queryCompra.Append("                       imp.porcentaje_padre                             porcentaje_comparacion, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_impuesto_descontado \n");
                queryCompra.Append("                       ELSE fd.total_impuesto_descontado / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_impuesto_descontado, \n");
                queryCompra.Append("                       imp.id_padre                                     impuesto_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then p.ruc else '99999901' end ruc, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then pa_calcular_dv_11_a(p.ruc, 11) else 0 end dv \n");
                queryCompra.Append("                FROM   facturas_proveedor_info_comp fc, \n");
                queryCompra.Append("                       facturas_proveedor_det_info_c fd, \n");
                queryCompra.Append("                       casos c, \n");
                queryCompra.Append("                       proveedores p, \n");
                queryCompra.Append("                       ctacte_condiciones_pago ccp, \n");
                queryCompra.Append("                       (SELECT id_padre, \n");
                queryCompra.Append("                               porcentaje_padre, \n");
                queryCompra.Append("                               porcentaje_hijo \n");
                queryCompra.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryCompra.Append("                                FROM   impuestos i1, \n");
                queryCompra.Append("                                       impuestos i2, \n");
                queryCompra.Append("                                       impuestos_compuestos ic \n");
                queryCompra.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryCompra.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryCompra.Append("                WHERE  fd.facturas_proveedor_id = fc.id AND \n");
                queryCompra.Append("                       fc.proveedor_id = p.id AND \n");
                queryCompra.Append("                       fc.caso_id = c.id AND \n");
                queryCompra.Append("                       c.estado like 'A' AND \n");
                queryCompra.Append("                       fc.caso_estado_id IN ('APROBADO', 'CERRADO') AND \n");
                queryCompra.Append("                       fc.tipo_factura_proveedor_id <> " + Definiciones.TipoFacturaProveedor.Autofactura + " AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       NOT fc.es_ticket = 'S' AND \n");
                queryCompra.Append("                       fc.ctacte_condicion_pago_id = ccp.id AND \n");
                queryCompra.Append("                       fd.impuesto_id = imp.id_padre \n");
                queryCompra.Append(" \n");
                queryCompra.Append("                UNION ALL \n");
                queryCompra.Append("SELECT                 ccp.nombre                                       plazo, \n");
                queryCompra.Append("                       5                                                tipo_documento, \n");
                queryCompra.Append("                       ccp.cantidad_pagos, \n");
                queryCompra.Append("                       (SELECT ccp.tipo_condicion_pago \n");
                queryCompra.Append("                        FROM   ctacte_condiciones_pago ccp \n");
                queryCompra.Append("                        WHERE  ccp.id = fc.ctacte_condicion_pago_id)    condicion_compra, \n");
                queryCompra.Append("                       fd.id, \n");
                queryCompra.Append("                       fc.caso_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then fc.proveedor_nombre else 'Proveedores del Exterior' end proveedor_nombre, \n");
                queryCompra.Append("                       fc.sucursal_nombre, \n");
                queryCompra.Append("                       trunc(fc.fecha_factura)                          fecha_factura, \n");
                queryCompra.Append("                       fc.nro_comprobante, \n");
                queryCompra.Append("                       fc.nro_timbrado, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_pago \n");
                queryCompra.Append("                       ELSE fd.total_pago / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_pago, \n");
                queryCompra.Append("                       imp.porcentaje_hijo                              porcentaje_impuesto, \n");
                queryCompra.Append("                       imp.porcentaje_padre                             porcentaje_comparacion, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_impuesto_descontado \n");
                queryCompra.Append("                       ELSE fd.total_impuesto_descontado / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_impuesto_descontado, \n");
                queryCompra.Append("                       imp.id_padre                                     impuesto_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then p.ruc else '99999901' end ruc, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then pa_calcular_dv_11_a(p.ruc, 11) else 0 end dv \n");
                queryCompra.Append("                FROM   facturas_proveedor_info_comp fc, \n");
                queryCompra.Append("                       facturas_proveedor_det_info_c fd, \n");
                queryCompra.Append("                       casos c, \n");
                queryCompra.Append("                       proveedores p, \n");
                queryCompra.Append("                       ctacte_condiciones_pago ccp, \n");
                queryCompra.Append("                       (SELECT id_padre, \n");
                queryCompra.Append("                               porcentaje_padre, \n");
                queryCompra.Append("                               porcentaje_hijo \n");
                queryCompra.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryCompra.Append("                                FROM   impuestos i1, \n");
                queryCompra.Append("                                       impuestos i2, \n");
                queryCompra.Append("                                       impuestos_compuestos ic \n");
                queryCompra.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryCompra.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryCompra.Append("                WHERE  fd.facturas_proveedor_id = fc.id AND \n");
                queryCompra.Append("                       fc.proveedor_id = p.id AND \n");
                queryCompra.Append("                       fc.caso_id = c.id AND \n");
                queryCompra.Append("                       c.estado like 'A' AND \n");
                queryCompra.Append("                       fc.tipo_factura_proveedor_id = " + Definiciones.TipoFacturaProveedor.Autofactura + " AND \n");
                queryCompra.Append("                       fc.caso_estado_id IN ('APROBADO', 'CERRADO') AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       NOT fc.es_ticket = 'S' AND \n");
                queryCompra.Append("                       fc.ctacte_condicion_pago_id = ccp.id AND \n");
                queryCompra.Append("                       fd.impuesto_id = imp.id_padre \n");
                queryCompra.Append(" \n");
                queryCompra.Append("                UNION ALL \n");
                queryCompra.Append("SELECT \n");
                queryCompra.Append("                       NULL                           plazo, \n");
                queryCompra.Append("                       3                              tipo_documento, \n");
                queryCompra.Append("                       NULL                           cantidad_pagos, \n");
                queryCompra.Append("                       NULL                           condicion_compra, \n");
                queryCompra.Append("                       ncd.id, \n");
                queryCompra.Append("                       nc.caso_id, \n");
                queryCompra.Append("                       nc.persona_nombre              proveedor_nombre, \n");
                queryCompra.Append("                       nc.sucursal_nombre, \n");
                queryCompra.Append("                       trunc(nc.fecha)                fecha, \n");
                queryCompra.Append("                       nc.nro_comprobante, \n");
                queryCompra.Append("                       nvl(a.numero_timbrado,'1')     numero_timbrado, \n");
                queryCompra.Append("                       CASE WHEN nc.moneda_id = 1 THEN ncd.total \n");
                queryCompra.Append("                       ELSE ncd.total / nc.cotizacion_moneda  * herramientas.Obtener_Cotizacion_Venta(nc.sucursal_id, 1, nc.fecha) \n");
                queryCompra.Append("                       END                            total_pago, \n");
                queryCompra.Append("                       imp.porcentaje_hijo            porcentaje_impuesto, \n");
                queryCompra.Append("                       imp.porcentaje_padre           porcentaje_comparacion, \n");
                queryCompra.Append("                       CASE WHEN nc.moneda_id = 1 THEN ncd.impuesto_monto \n");
                queryCompra.Append("                       ELSE ncd.impuesto_monto / nc.cotizacion_moneda * herramientas.Obtener_Cotizacion_Venta(nc.sucursal_id, 1, nc.fecha) \n");
                queryCompra.Append("                       END                            total_impuesto_descontado, \n");
                queryCompra.Append("                       imp.id_padre                   impuesto_id, \n");
                queryCompra.Append("                       p.ruc, \n");
                queryCompra.Append("                       pa_calcular_dv_11_a(p.ruc, 11) dv \n");
                queryCompra.Append("                FROM   notas_credito_persona_inf_comp nc, \n");
                queryCompra.Append("                       notas_cred_per_det_inf_comp ncd, \n");
                queryCompra.Append("                       autonumeraciones a, \n");
                queryCompra.Append("                       personas p, \n");
                queryCompra.Append("                       casos c, \n");
                queryCompra.Append("                       flujos f, \n");
                queryCompra.Append("                       (SELECT id_padre, \n");
                queryCompra.Append("                               porcentaje_padre, \n");
                queryCompra.Append("                               porcentaje_hijo \n");
                queryCompra.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryCompra.Append("                                FROM   impuestos i1, \n");
                queryCompra.Append("                                       impuestos i2, \n");
                queryCompra.Append("                                       impuestos_compuestos ic \n");
                queryCompra.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryCompra.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryCompra.Append("                WHERE  ncd.nota_credito_persona_id = nc.id AND \n");
                queryCompra.Append("                       nc.persona_id = p.id AND \n");
                queryCompra.Append("                       nc.caso_id = c.id AND \n");
                queryCompra.Append("                       nc.autonumeracion_id = a.id(+) AND \n");
                queryCompra.Append("                       c.flujo_id = f.id AND \n");
                queryCompra.Append("       trunc(nc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("       trunc(nc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       nc.caso_estado_id IN ('CERRADO', 'APROBADO') AND \n");
                queryCompra.Append("                       ncd.impuesto_id = imp.id_padre )");
                queryCompra.Append("        GROUP  BY id,plazo,cantidad_pagos,caso_id,proveedor_nombre,sucursal_nombre,fecha_factura,nro_comprobante,nro_timbrado,ruc,dv,condicion_compra,tipo_documento)  \n");
                queryCompra.Append("GROUP  BY plazo,cantidad_pagos,caso_id,proveedor_nombre,sucursal_nombre,fecha_factura,nro_comprobante,nro_timbrado,ruc,dv,condicion_compra,tipo_documento \n");
                queryCompra.Append("ORDER  BY fecha_factura,proveedor_nombre ASC ");

                dtDatos = sesion.db.EjecutarQuery(queryCompra.ToString());
                dtDatos.TableName = "reporte_compra_hechauka";
            }

            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }

    public DataTable ObtenerDatosCompraHechaukaV2()
    {
        try
        {
            DataTable dtDatos = new DataTable();

            using (SessionService sesion = new SessionService())
            {
                StringBuilder queryCompra = new StringBuilder();
                queryCompra.Append("SELECT 2                                                 tipo_registro, \n");
                queryCompra.Append("       tipo_documento, \n");
                queryCompra.Append("       plazo, \n");
                queryCompra.Append("       decode(condicion_compra, 'CONTADO', 0, \n");
                queryCompra.Append("                              'CREDITO', cantidad_pagos) cantidad_pagos, \n");
                queryCompra.Append("       caso_id                                           nro_caso, \n");
                queryCompra.Append("       proveedor_nombre                                  nombre_proveedor, \n");
                queryCompra.Append("       0                                                 tipo_operacion, \n");
                queryCompra.Append("       decode(condicion_compra, 'CONTADO', 1, \n");
                queryCompra.Append("                                'CREDITO', 2)            condicion_compra, \n");
                queryCompra.Append("       sucursal_nombre, \n");
                queryCompra.Append("       fecha_factura                                     fecha, \n");
                queryCompra.Append("       TO_char(fecha_factura, 'DD/MM/YYYY')              fecha_documento, \n");
                queryCompra.Append("       TO_char(fecha_factura, 'YYYYMM')                  periodo, \n");
                queryCompra.Append("       nro_comprobante nro_documento, \n");
                queryCompra.Append("       nro_timbrado, \n");
                queryCompra.Append("       ruc                                               ruc_proveedor, \n");
                queryCompra.Append("       dv, \n");
                queryCompra.Append("       round(nvl(SUM(total_pago),0),9)                                   total_pago, \n");
                queryCompra.Append("       round(nvl(SUM(total_gravado_10),0),9)                             monto_compra_10, \n");
                queryCompra.Append("       round(nvl(SUM(total_iva_10),0),9)                                 iva_credito_10, \n");
                queryCompra.Append("       round(nvl(SUM(total_gravado_5),0),9)                              monto_compra_5, \n");
                queryCompra.Append("       round(nvl(SUM(total_iva_5),0),9)                                  iva_credito_5, \n");
                queryCompra.Append("       round(nvl(SUM(total_exento),0),9)                                 monto_compra_exenta \n");
                queryCompra.Append("FROM   (SELECT tipo_documento, \n");
                queryCompra.Append("               plazo, \n");
                queryCompra.Append("               cantidad_pagos, \n");
                queryCompra.Append("               caso_id, \n");
                queryCompra.Append("               proveedor_nombre, \n");
                queryCompra.Append("               sucursal_nombre, \n");
                queryCompra.Append("               fecha_factura, \n");
                queryCompra.Append("               nro_comprobante, \n");
                queryCompra.Append("               nro_timbrado, \n");
                queryCompra.Append("               ruc, \n");
                queryCompra.Append("               dv, \n");
                queryCompra.Append("               condicion_compra, \n");
                queryCompra.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryCompra.Append("                                           ELSE total_pago \n");
                queryCompra.Append("                                           END) \n");
                queryCompra.Append("               ELSE SUM(total_pago) \n");
                queryCompra.Append("               END      total_pago, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN (total_pago - total_impuesto_descontado) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_gravado_10, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN total_impuesto_descontado \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_iva_10, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN (total_pago - total_impuesto_descontado) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_gravado_5, \n");
                queryCompra.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN total_impuesto_descontado \n");
                queryCompra.Append("                   ELSE 0 \n");
                queryCompra.Append("                   END) total_iva_5, \n");
                queryCompra.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryCompra.Append("                                           ELSE (total_pago - total_impuesto_descontado) * (1 - porcentaje_impuesto / porcentaje_comparacion) \n");
                queryCompra.Append("                                           END) \n");
                queryCompra.Append("               ELSE SUM(CASE porcentaje_comparacion WHEN 0 THEN total_pago \n");
                queryCompra.Append("                        ELSE 0 \n");
                queryCompra.Append("                        END) \n");
                queryCompra.Append("               END      total_exento \n");
                queryCompra.Append("        FROM   (SELECT ccp.nombre                                       plazo, \n");
                queryCompra.Append("                       1                                                tipo_documento, \n");
                queryCompra.Append("                       ccp.cantidad_pagos, \n");
                queryCompra.Append("                       (SELECT ccp.tipo_condicion_pago \n");
                queryCompra.Append("                        FROM   ctacte_condiciones_pago ccp \n");
                queryCompra.Append("                        WHERE  ccp.id = fc.ctacte_condicion_pago_id)    condicion_compra, \n");
                queryCompra.Append("                       fd.id, \n");
                queryCompra.Append("                       fc.caso_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then fc.proveedor_nombre else 'Proveedores del Exterior' end proveedor_nombre, \n");
                queryCompra.Append("                       fc.sucursal_nombre, \n");
                queryCompra.Append("                       trunc(fc.fecha_factura)                          fecha_factura, \n");
                queryCompra.Append("                       fc.nro_comprobante, \n");
                queryCompra.Append("                       fc.nro_timbrado, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_pago \n");
                queryCompra.Append("                       ELSE fd.total_pago / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_pago, \n");
                queryCompra.Append("                       imp.porcentaje_hijo                              porcentaje_impuesto, \n");
                queryCompra.Append("                       imp.porcentaje_padre                             porcentaje_comparacion, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_impuesto_descontado \n");
                queryCompra.Append("                       ELSE fd.total_impuesto_descontado / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_impuesto_descontado, \n");
                queryCompra.Append("                       imp.id_padre                                     impuesto_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then p.ruc else '99999901' end ruc, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then pa_calcular_dv_11_a(p.ruc, 11) else 0 end dv \n");
                queryCompra.Append("                FROM   facturas_proveedor_info_comp fc, \n");
                queryCompra.Append("                       facturas_proveedor_det_info_c fd, \n");
                queryCompra.Append("                       casos c, \n");
                queryCompra.Append("                       proveedores p, \n");
                queryCompra.Append("                       ctacte_condiciones_pago ccp, \n");
                queryCompra.Append("                       (SELECT id_padre, \n");
                queryCompra.Append("                               porcentaje_padre, \n");
                queryCompra.Append("                               porcentaje_hijo \n");
                queryCompra.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryCompra.Append("                                FROM   impuestos i1, \n");
                queryCompra.Append("                                       impuestos i2, \n");
                queryCompra.Append("                                       impuestos_compuestos ic \n");
                queryCompra.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryCompra.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryCompra.Append("                WHERE  fd.facturas_proveedor_id = fc.id AND \n");
                queryCompra.Append("                       fc.proveedor_id = p.id AND \n");
                queryCompra.Append("                       fc.caso_id = c.id AND \n");
                queryCompra.Append("                       c.estado like 'A' AND \n");
                queryCompra.Append("                       fc.caso_estado_id IN ('APROBADO', 'CERRADO') AND \n");
                queryCompra.Append("                       fc.tipo_factura_proveedor_id <> " + Definiciones.TipoFacturaProveedor.Autofactura + " AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       NOT fc.es_ticket = 'S' AND \n");
                queryCompra.Append("                       fc.ctacte_condicion_pago_id = ccp.id AND \n");
                queryCompra.Append("                       fd.impuesto_id = imp.id_padre \n");
                queryCompra.Append(" \n");
                queryCompra.Append("                UNION ALL \n");
                queryCompra.Append("SELECT                 ccp.nombre                                       plazo, \n");
                queryCompra.Append("                       5                                                tipo_documento, \n");
                queryCompra.Append("                       ccp.cantidad_pagos, \n");
                queryCompra.Append("                       (SELECT ccp.tipo_condicion_pago \n");
                queryCompra.Append("                        FROM   ctacte_condiciones_pago ccp \n");
                queryCompra.Append("                        WHERE  ccp.id = fc.ctacte_condicion_pago_id)    condicion_compra, \n");
                queryCompra.Append("                       fd.id, \n");
                queryCompra.Append("                       fc.caso_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then fc.proveedor_nombre else 'Proveedores del Exterior' end proveedor_nombre, \n");
                queryCompra.Append("                       fc.sucursal_nombre, \n");
                queryCompra.Append("                       trunc(fc.fecha_factura)                          fecha_factura, \n");
                queryCompra.Append("                       fc.nro_comprobante, \n");
                queryCompra.Append("                       fc.nro_timbrado, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_pago \n");
                queryCompra.Append("                       ELSE fd.total_pago / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_pago, \n");
                queryCompra.Append("                       imp.porcentaje_hijo                              porcentaje_impuesto, \n");
                queryCompra.Append("                       imp.porcentaje_padre                             porcentaje_comparacion, \n");
                queryCompra.Append("                       CASE WHEN fc.moneda_id = 1 THEN fd.total_impuesto_descontado \n");
                queryCompra.Append("                       ELSE fd.total_impuesto_descontado / fc.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(fc.sucursal_id, 1, fc.fecha) \n");
                queryCompra.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_impuesto_descontado, \n");
                queryCompra.Append("                       imp.id_padre                                     impuesto_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then p.ruc else '99999901' end ruc, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then pa_calcular_dv_11_a(p.ruc, 11) else 0 end dv \n");
                queryCompra.Append("                FROM   facturas_proveedor_info_comp fc, \n");
                queryCompra.Append("                       facturas_proveedor_det_info_c fd, \n");
                queryCompra.Append("                       casos c, \n");
                queryCompra.Append("                       proveedores p, \n");
                queryCompra.Append("                       ctacte_condiciones_pago ccp, \n");
                queryCompra.Append("                       (SELECT id_padre, \n");
                queryCompra.Append("                               porcentaje_padre, \n");
                queryCompra.Append("                               porcentaje_hijo \n");
                queryCompra.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryCompra.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryCompra.Append("                                FROM   impuestos i1, \n");
                queryCompra.Append("                                       impuestos i2, \n");
                queryCompra.Append("                                       impuestos_compuestos ic \n");
                queryCompra.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryCompra.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryCompra.Append("                WHERE  fd.facturas_proveedor_id = fc.id AND \n");
                queryCompra.Append("                       fc.proveedor_id = p.id AND \n");
                queryCompra.Append("                       fc.caso_id = c.id AND \n");
                queryCompra.Append("                       c.estado like 'A' AND \n");
                queryCompra.Append("                       fc.tipo_factura_proveedor_id = " + Definiciones.TipoFacturaProveedor.Autofactura + " AND \n");
                queryCompra.Append("                       fc.caso_estado_id IN ('APROBADO', 'CERRADO') AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       trunc(fc.fecha_factura, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("                       NOT fc.es_ticket = 'S' AND \n");
                queryCompra.Append("                       fc.ctacte_condicion_pago_id = ccp.id AND \n");
                queryCompra.Append("                       fd.impuesto_id = imp.id_padre \n");
                queryCompra.Append(" \n");
                queryCompra.Append("                UNION ALL \n");
                queryCompra.Append("SELECT \n");
                queryCompra.Append("                       NULL                           plazo, \n");
                queryCompra.Append("                       3                              tipo_documento, \n");
                queryCompra.Append("                       NULL                           cantidad_pagos, \n");
                queryCompra.Append("                       NULL                           condicion_compra, \n");
                queryCompra.Append("                       ncpd.id, \n");
                queryCompra.Append("                       ncpic.caso_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then ncpic.proveedor_nombre else 'Proveedores del Exterior' end proveedor_nombre, \n");
                queryCompra.Append("                       ncpic.sucursal_nombre, \n");
                queryCompra.Append("                       trunc(ncpic.fecha)                fecha, \n");
                queryCompra.Append("                       ncpic.NRO_COMPROBANTE, \n");
                queryCompra.Append("                       '1'                              numero_timbrado, \n");
                queryCompra.Append("                       CASE WHEN ncpd.moneda_id = 1 THEN ncpd.monto_concepto \n");
                queryCompra.Append("                       ELSE ncpd.monto_concepto / ncpd.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(ncpic.sucursal_id, 1, ncpic.fecha) \n");
                queryCompra.Append("                       END                            total_pago, \n");
                queryCompra.Append("                       imp.porcentaje_hijo            porcentaje_impuesto, \n");
                queryCompra.Append("                       imp.porcentaje_padre           porcentaje_comparacion, \n");
                queryCompra.Append("                       CASE WHEN ncpd.moneda_id = 1 THEN ncpd.impuesto_monto \n");
                queryCompra.Append("                        ELSE ncpd.impuesto_monto / ncpd.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(ncpic.sucursal_id, 1, ncpic.fecha) \n");
                queryCompra.Append("                        END                            total_impuesto_descontado, \n");
                queryCompra.Append("                       imp.id_padre                   impuesto_id, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then p.ruc else '99999901' end ruc, \n");
                queryCompra.Append("                       case p.es_nacional when 'S' then pa_calcular_dv_11_a(p.ruc, 11) else 0 end dv \n");
                queryCompra.Append("FROM   notas_credito_proveed_inf_comp ncpic, \n");
                queryCompra.Append("       notas_cred_pro_det_inf_comp ncpd, \n");
                queryCompra.Append("       proveedores p, \n");
                queryCompra.Append("       casos c, \n");
                queryCompra.Append("       flujos f, \n");
                queryCompra.Append("       (SELECT id_padre, \n");
                queryCompra.Append("               porcentaje_padre, \n");
                queryCompra.Append("               porcentaje_hijo \n");
                queryCompra.Append("        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryCompra.Append("                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryCompra.Append("                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryCompra.Append("                FROM   impuestos i1, \n");
                queryCompra.Append("                       impuestos i2, \n");
                queryCompra.Append("                       impuestos_compuestos ic \n");
                queryCompra.Append("                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryCompra.Append("                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryCompra.Append("WHERE  ncpic.id = ncpd.nota_credito_proveedor_id AND \n");
                queryCompra.Append("       ncpic.proveedor_id = p.id AND \n");
                queryCompra.Append("       ncpic.caso_estado IN ('APROBADO', 'CERRADO') AND \n");
                queryCompra.Append("       trunc(ncpic.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("       trunc(ncpic.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryCompra.Append("       ncpd.impuesto_id = imp.id_padre AND \n");
                queryCompra.Append("       ncpic.CASO_ID = c.id AND \n");
                queryCompra.Append("       c.flujo_id = f.id )         GROUP  BY id,plazo,cantidad_pagos,caso_id,proveedor_nombre,sucursal_nombre,fecha_factura,nro_comprobante,nro_timbrado,ruc,dv,condicion_compra,tipo_documento)");
                queryCompra.Append("GROUP  BY plazo,cantidad_pagos,caso_id,proveedor_nombre,sucursal_nombre,fecha_factura,nro_comprobante,nro_timbrado,ruc,dv,condicion_compra,tipo_documento \n");
                queryCompra.Append("ORDER  BY fecha_factura,proveedor_nombre ASC ");

                dtDatos = sesion.db.EjecutarQuery(queryCompra.ToString());
                dtDatos.TableName = "reporte_compra_hechauka";
            }

            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Venta Consolidado Hechauka
    public DataTable ObtenerDatosVentaHechauka(bool incluirAnuladas)
    {
        try
        {
            DataTable dtDatos = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                DateTime fecha = DateTime.Parse(fechaFinal);

                int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime ultimoDia = new DateTime(fecha.Year, fecha.Month, diasEnMes);

                decimal paisId;
                if (sesion.SucursalActiva.ES_CASA_MATRIZ == Definiciones.SiNo.Si)
                    paisId = sesion.SucursalActiva.PAIS_ID;
                else
                    paisId = new SucursalesService(sesion.SucursalActiva.SUC_CASA_MATRIZ_ID, sesion).PaisId;

                StringBuilder queryVenta = new StringBuilder();
                queryVenta.Append("SELECT 2                                                  tipo_registro, \n");
                queryVenta.Append("       condicion_pago, \n");
                queryVenta.Append("       decode(tipo_factura_id, 'CONTADO', 0, \n");
                queryVenta.Append("                               'CREDITO', cantidad_pagos) cantidad_pagos, \n");
                queryVenta.Append("       caso_id                                            nro_caso, \n");
                queryVenta.Append("       TO_char(fecha, 'DD/MM/YYYY')                       fecha_documento, \n");
                queryVenta.Append("       persona_nombre_completo                            nombre_proveedor, \n");
                queryVenta.Append("       autonumeracion_timbrado, \n");
                queryVenta.Append("       1                                                  numero_timbrado, \n");
                queryVenta.Append("       tipo_documento, \n");
                queryVenta.Append("       nro_comprobante                                    nro_documento, \n");
                queryVenta.Append("       ruc                                                ruc_proveedor, \n");
                queryVenta.Append("       dv, \n");
                queryVenta.Append("       flujo_id, \n");
                queryVenta.Append("       sucursal_nombre, \n");
                queryVenta.Append("       round(nvl(SUM(total_neto),0),9)                    total_neto, \n");
                queryVenta.Append("       round(nvl(SUM(total_gravado_10),0),9)              monto_compra_10, \n");
                queryVenta.Append("       round(nvl(SUM(total_iva_10),0),9)                  iva_credito_10, \n");
                queryVenta.Append("       round(nvl(SUM(total_gravado_5),0),9)               monto_compra_5, \n");
                queryVenta.Append("       round(nvl(SUM(total_iva_5),0),9)                   iva_credito_5, \n");
                queryVenta.Append("       round(nvl(SUM(total_exento),0),9)                  monto_compra_exenta, \n");
                queryVenta.Append("       TO_char(fecha, 'YYYYMM')                           Periodo, \n");
                queryVenta.Append("       tipo_factura_id, \n");
                queryVenta.Append("       decode(tipo_factura_id, 'CONTADO', 1, \n");
                queryVenta.Append("                               'CREDITO', 2)              condicion_venta \n");
                queryVenta.Append("FROM   (SELECT condicion_pago, \n");
                queryVenta.Append("               cantidad_pagos, \n");
                queryVenta.Append("               caso_id, \n");
                queryVenta.Append("               tipo_factura_id, \n");
                queryVenta.Append("               fecha, \n");
                queryVenta.Append("               persona_nombre_completo, \n");
                queryVenta.Append("               autonumeracion_timbrado, \n");
                queryVenta.Append("               1        numero_timbrado, \n");
                queryVenta.Append("               tipo_documento, \n");
                queryVenta.Append("               nro_comprobante, \n");
                queryVenta.Append("               ruc, \n");
                queryVenta.Append("               flujo_id, \n");
                queryVenta.Append("               sucursal_nombre, \n");
                queryVenta.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryVenta.Append("                                           ELSE total_neto \n");
                queryVenta.Append("                                           END) \n");
                queryVenta.Append("               ELSE SUM(total_neto) \n");
                queryVenta.Append("               END      total_neto, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN (total_neto - total_monto_impuesto) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_gravado_10, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN total_monto_impuesto \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_iva_10, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN (total_neto - total_monto_impuesto) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_gravado_5, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN total_monto_impuesto \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_iva_5, \n");
                queryVenta.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryVenta.Append("                                           ELSE (total_neto - total_monto_impuesto) * (1 - porcentaje_impuesto / porcentaje_comparacion) \n");
                queryVenta.Append("                                           END) \n");
                queryVenta.Append("               ELSE SUM(CASE porcentaje_comparacion WHEN 0 THEN total_neto \n");
                queryVenta.Append("                        ELSE 0 \n");
                queryVenta.Append("                        END) \n");
                queryVenta.Append("               END      total_exento, dv \n");
                queryVenta.Append("        FROM   (SELECT 2                                                tipo_registro, \n");
                queryVenta.Append("                       ccp.nombre                                       condicion_pago, \n");
                queryVenta.Append("                       ccp.cantidad_pagos, \n");
                queryVenta.Append("                       fc.sucursal_nombre, \n");
                queryVenta.Append("                       fc.caso_id, \n");
                queryVenta.Append("                       trunc(fc.fecha)                                  fecha, \n");
                queryVenta.Append("                       fc.persona_nombre_completo, \n");
                queryVenta.Append("                       fc.autonumeracion_timbrado, \n");
                queryVenta.Append("                       1                                                numero_timbrado, \n");
                queryVenta.Append("                       1                                                tipo_documento, \n");
                queryVenta.Append("                       fc.nro_comprobante, \n");
                queryVenta.Append("                       fd.id, \n");
                queryVenta.Append("                       CASE WHEN fc.moneda_destino_id = 1 THEN fd.total_neto \n");
                queryVenta.Append("                       ELSE fd.total_neto / fc.cotizacion_destino * herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, 1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_neto, \n");
                queryVenta.Append("                       imp.porcentaje_hijo                              porcentaje_impuesto, \n");
                queryVenta.Append("                       imp.porcentaje_padre                             porcentaje_comparacion, \n");
                queryVenta.Append("                       CASE WHEN fc.moneda_destino_id = 1 THEN fd.total_monto_impuesto \n");
                queryVenta.Append("                       ELSE fd.total_monto_impuesto / fc.cotizacion_destino * herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, 1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_monto_impuesto, \n");
                queryVenta.Append("                       imp.id_padre                                     impuesto_id, \n");
                queryVenta.Append("                       p.ruc, \n");
                queryVenta.Append("                       pa_calcular_dv_11_a(p.ruc, 11)                   dv, \n");
                queryVenta.Append("                       p.codigo, \n");
                queryVenta.Append("                       c.flujo_id, \n");
                queryVenta.Append("                       TO_char(fc.fecha, 'YYYYMM')                      Periodo, \n");
                queryVenta.Append("                       fc.tipo_factura_id \n");
                queryVenta.Append("                FROM   facturas_cliente_info_completa fc, \n");
                queryVenta.Append("                       facturas_cliente_det_inf_co fd, \n");
                queryVenta.Append("                       articulos_info_completa a, \n");
                queryVenta.Append("                       personas p, \n");
                queryVenta.Append("                       casos c, \n");
                queryVenta.Append("                       flujos f, \n");
                queryVenta.Append("                       ctacte_condiciones_pago ccp, \n");
                queryVenta.Append("                       (SELECT id_padre, \n");
                queryVenta.Append("                               porcentaje_padre, \n");
                queryVenta.Append("                               porcentaje_hijo \n");
                queryVenta.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryVenta.Append("                                FROM   impuestos i1, \n");
                queryVenta.Append("                                       impuestos i2, \n");
                queryVenta.Append("                                       impuestos_compuestos ic \n");
                queryVenta.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryVenta.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryVenta.Append("                WHERE  fd.facturas_cliente_id = fc.id AND \n");
                queryVenta.Append("                       fc.estado = 'A' AND \n");
                queryVenta.Append("                       fd.articulo_id = a.id AND \n");
                queryVenta.Append("                       fc.condicion_pago_id = ccp.id AND \n");
                queryVenta.Append("                       fc.persona_id = p.id AND \n");
                queryVenta.Append("                       fc.caso_id = c.id AND \n");
                queryVenta.Append("                       c.flujo_id = f.id AND \n");
                queryVenta.Append("                       trunc(fc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                queryVenta.Append("                       trunc(fc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                queryVenta.Append("                       fc.caso_estado_id IN ('CERRADO', 'CAJA') AND \n");
                queryVenta.Append("                       p.es_contribuyente = 'S' AND \n");
                queryVenta.Append("                       fd.impuesto_id = imp.id_padre \n");
                queryVenta.Append(" \n");
                if (incluirAnuladas == true)
                {
                    queryVenta.Append("                UNION ALL \n");
                    queryVenta.Append("                SELECT 2                              tipo_registro, \n");
                    queryVenta.Append("                       ccp.nombre                     condicion_pago, \n");
                    queryVenta.Append("                       ccp.cantidad_pagos, \n");
                    queryVenta.Append("                       fc.sucursal_nombre, \n");
                    queryVenta.Append("                       fc.caso_id, \n");
                    queryVenta.Append("                       trunc(fc.fecha)                fecha, \n");
                    queryVenta.Append("                       fc.persona_nombre_completo, \n");
                    queryVenta.Append("                       fc.autonumeracion_timbrado, \n");
                    queryVenta.Append("                       1                              numero_timbrado, \n");
                    queryVenta.Append("                       1                              tipo_documento, \n");
                    queryVenta.Append("                       fc.nro_comprobante, \n");
                    queryVenta.Append("                       fd.id, \n");
                    queryVenta.Append("                       0                              total_neto, \n");
                    queryVenta.Append("                       imp.porcentaje_hijo            porcentaje_impuesto, \n");
                    queryVenta.Append("                       imp.porcentaje_padre           porcentaje_comparacion, \n");
                    queryVenta.Append("                       0                              total_monto_impuesto, \n");
                    queryVenta.Append("                       imp.id_padre                   impuesto_id, \n");
                    queryVenta.Append("                       p.ruc, \n");
                    queryVenta.Append("                       pa_calcular_dv_11_a(p.ruc, 11) dv, \n");
                    queryVenta.Append("                       p.codigo, \n");
                    queryVenta.Append("                       c.flujo_id, \n");
                    queryVenta.Append("                       TO_char(fc.fecha, 'YYYYMM')    Periodo, \n");
                    queryVenta.Append("                       fc.tipo_factura_id \n");
                    queryVenta.Append("                FROM   facturas_cliente_info_completa fc, \n");
                    queryVenta.Append("                       facturas_cliente_det_inf_co fd, \n");
                    queryVenta.Append("                       articulos_info_completa a, \n");
                    queryVenta.Append("                       personas p, \n");
                    queryVenta.Append("                       casos c, \n");
                    queryVenta.Append("                       flujos f, \n");
                    queryVenta.Append("                       ctacte_condiciones_pago ccp, \n");
                    queryVenta.Append("                       (SELECT id_padre, \n");
                    queryVenta.Append("                               porcentaje_padre, \n");
                    queryVenta.Append("                               porcentaje_hijo \n");
                    queryVenta.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                    queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                    queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                    queryVenta.Append("                                FROM   impuestos i1, \n");
                    queryVenta.Append("                                       impuestos i2, \n");
                    queryVenta.Append("                                       impuestos_compuestos ic \n");
                    queryVenta.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                    queryVenta.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                    queryVenta.Append("                WHERE  fd.facturas_cliente_id = fc.id AND \n");
                    queryVenta.Append("                       fc.estado = 'A' AND \n");
                    queryVenta.Append("                       fd.articulo_id = a.id AND \n");
                    queryVenta.Append("                       fc.condicion_pago_id = ccp.id AND \n");
                    queryVenta.Append("                       fc.persona_id = p.id AND \n");
                    queryVenta.Append("                       fc.caso_id = c.id AND \n");
                    queryVenta.Append("                       c.flujo_id = f.id AND \n");
                    queryVenta.Append("                       trunc(fc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                    queryVenta.Append("                       trunc(fc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                    queryVenta.Append("                       fc.caso_estado_id = 'ANULADO' AND \n");
                    queryVenta.Append("                       fd.impuesto_id = imp.id_padre AND \n");
                    queryVenta.Append("                       p.es_contribuyente = 'S' \n");
                    queryVenta.Append(" \n");
                }            
                queryVenta.Append("UNION ALL \n");
                queryVenta.Append("                SELECT 2 tipo_registro, \n");
                queryVenta.Append("                       'CONTADO' condicion_pago, \n");
                queryVenta.Append("                       0 cantidad_pagos, \n");
                queryVenta.Append("                       '' sucursal_nombre, \n");
                queryVenta.Append("                       -1 caso_id, \n");
                queryVenta.Append("                       to_date('" + ultimoDia.ToShortDateString() + "','dd/mm/yyyy') fecha, \n");
                queryVenta.Append("                       case p." + PersonasService.PaisResidenciaId_NombreCol + " \n");
                queryVenta.Append("                       when " + paisId + " then 'Importes Consolidados' else 'Clientes del Exterior' end persona_nombre_completo, \n");
                queryVenta.Append("                       '0' autonumeracion_timbrado, \n");
                queryVenta.Append("                       0 numero_timbrado, \n");
                queryVenta.Append("                       1 tipo_documento, \n");
                queryVenta.Append("                       '0' nro_comprobante, \n");
                queryVenta.Append("                       fd.id, \n");
                queryVenta.Append("                       CASE \n");
                queryVenta.Append("                         WHEN fc.moneda_destino_id = 1 THEN \n");
                queryVenta.Append("                          fd.total_neto \n");
                queryVenta.Append("                         ELSE \n");
                queryVenta.Append("                          fd.total_neto / fc.cotizacion_destino * \n");
                queryVenta.Append("                          herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, \n");
                queryVenta.Append("                                                                1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_neto, \n");
                queryVenta.Append("                       imp.porcentaje_hijo porcentaje_impuesto, \n");
                queryVenta.Append("                       imp.porcentaje_padre porcentaje_comparacion, \n");
                queryVenta.Append("                       CASE \n");
                queryVenta.Append("                         WHEN fc.moneda_destino_id = 1 THEN \n");
                queryVenta.Append("                          fd.total_monto_impuesto \n");
                queryVenta.Append("                         ELSE \n");
                queryVenta.Append("                          fd.total_monto_impuesto / fc.cotizacion_destino * \n");
                queryVenta.Append("                          herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, \n");
                queryVenta.Append("                                                                1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_monto_impuesto, \n");
                queryVenta.Append("                       imp.id_padre impuesto_id, \n");
                queryVenta.Append("                       case p." + PersonasService.PaisResidenciaId_NombreCol + " \n");
                queryVenta.Append("                       when " + paisId + " then '44444401' else '88888801' end ruc, \n");
                queryVenta.Append("                       case p." + PersonasService.PaisResidenciaId_NombreCol + " \n");
                queryVenta.Append("                       when " + paisId + " then 7 else 5 end dv, \n");
                queryVenta.Append("                       -1 codigo, \n");
                queryVenta.Append("                       c.flujo_id, \n");
                queryVenta.Append("                       TO_char('" + ultimoDia.ToShortDateString() + "' , 'YYYYMM')                            Periodo, \n");
                queryVenta.Append("                       'CONTADO' tipo_factura_id \n");
                queryVenta.Append("                  FROM facturas_cliente_info_completa fc, \n");
                queryVenta.Append("                       facturas_cliente_det_inf_co fd, \n");
                queryVenta.Append("                       articulos_info_completa a, \n");
                queryVenta.Append("                       personas p, \n");
                queryVenta.Append("                       casos c, \n");
                queryVenta.Append("                       flujos f, \n");
                queryVenta.Append("                       ctacte_condiciones_pago ccp, \n");
                queryVenta.Append("                       (SELECT id_padre, porcentaje_padre, porcentaje_hijo \n");
                queryVenta.Append("                          FROM (SELECT i1.id id_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje) porcentaje_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, \n");
                queryVenta.Append("                                           i1.porcentaje) porcentaje_hijo \n");
                queryVenta.Append("                                  FROM impuestos            i1, \n");
                queryVenta.Append("                                       impuestos            i2, \n");
                queryVenta.Append("                                       impuestos_compuestos ic \n");
                queryVenta.Append("                                 WHERE i1.id = ic.impuesto_padre_id(+) \n");
                queryVenta.Append("                                   AND ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryVenta.Append("                 WHERE fd.facturas_cliente_id = fc.id \n");
                queryVenta.Append("                   AND fc.estado = 'A' \n");
                queryVenta.Append("                   AND fd.articulo_id = a.id \n");
                queryVenta.Append("                   AND fc.condicion_pago_id = ccp.id \n");
                queryVenta.Append("                   AND fc.persona_id = p.id \n");
                queryVenta.Append("                   AND fc.caso_id = c.id \n");
                queryVenta.Append("                   AND c.flujo_id = f.id \n");
                queryVenta.Append("                   AND    trunc(fc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy')  \n");
                queryVenta.Append("                   AND    trunc(fc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy')  \n");
                queryVenta.Append("                   AND fc.caso_estado_id IN ('CERRADO', 'CAJA') \n");
                queryVenta.Append("                   AND p.es_contribuyente = 'N' \n");
                queryVenta.Append("                   AND fd.impuesto_id = imp.id_padre");
                queryVenta.Append(" \n");
                queryVenta.Append("                UNION ALL \n");
                queryVenta.Append("SELECT 2                              tipo_registro, \n");
                queryVenta.Append("       NULL                           condicion_pago, \n");
                queryVenta.Append("       NULL                           cantidad_pagos, \n");
                queryVenta.Append("       ncpic.sucursal_nombre, \n");
                queryVenta.Append("       ncpic.caso_id, \n");
                queryVenta.Append("       trunc(ncpic.fecha), \n");
                queryVenta.Append("       ncpic.proveedor_nombre, \n");
                queryVenta.Append("       ncpic.nro_timbrado, \n");
                queryVenta.Append("       1                              numero_timbrado, \n");
                queryVenta.Append("       3                              tipo_documento, \n");
                queryVenta.Append("       ncpic.nro_comprobante, \n");
                queryVenta.Append("       ncpd.id, \n");
                queryVenta.Append("       CASE WHEN ncpd.moneda_id = 1 THEN ncpd.monto_concepto  \n");
                queryVenta.Append("       ELSE ncpd.monto_concepto / ncpd.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(ncpic.sucursal_id, 1, ncpic.fecha)  \n");
                queryVenta.Append("       END                            total_pago, \n");
                queryVenta.Append("       imp.porcentaje_hijo            porcentaje_impuesto, \n");
                queryVenta.Append("       imp.porcentaje_padre           porcentaje_comparacion, \n");
                queryVenta.Append("       CASE WHEN ncpd.moneda_id = 1 THEN ncpd.impuesto_monto  \n");
                queryVenta.Append("       ELSE ncpd.impuesto_monto / ncpd.moneda_cotizacion * herramientas.Obtener_Cotizacion_Venta(ncpic.sucursal_id, 1, ncpic.fecha)  \n");
                queryVenta.Append("       END                            total_impuesto_descontado, \n");
                queryVenta.Append("       imp.id_padre                   impuesto_id, \n");
                queryVenta.Append("       p.ruc, \n");
                queryVenta.Append("       pa_calcular_dv_11_a(p.ruc, 11) dv, \n");
                queryVenta.Append("       p.codigo, \n");
                queryVenta.Append("       c.flujo_id, \n");
                queryVenta.Append("       TO_char(ncpic.fecha, 'YYYYMM') Periodo, \n");
                queryVenta.Append("       'CONTADO'                      tipo_factura_id \n");
                queryVenta.Append("FROM   notas_credito_proveed_inf_comp ncpic, \n");
                queryVenta.Append("       notas_cred_pro_det_inf_comp ncpd, \n");
                queryVenta.Append("       proveedores p, \n");
                queryVenta.Append("       casos c, \n");
                queryVenta.Append("       flujos f, \n");
                queryVenta.Append("       (SELECT id_padre, \n");
                queryVenta.Append("               porcentaje_padre, \n");
                queryVenta.Append("               porcentaje_hijo \n");
                queryVenta.Append("        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryVenta.Append("                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryVenta.Append("                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryVenta.Append("                FROM   impuestos i1, \n");
                queryVenta.Append("                       impuestos i2, \n");
                queryVenta.Append("                       impuestos_compuestos ic \n");
                queryVenta.Append("                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryVenta.Append("                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryVenta.Append("WHERE  ncpic.id = ncpd.nota_credito_proveedor_id AND \n");
                queryVenta.Append("       ncpic.proveedor_id = p.id AND \n");
                queryVenta.Append("       ncpic.caso_estado IN ('APROBADO', 'CERRADO') AND \n");
                queryVenta.Append("       trunc(ncpic.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryVenta.Append("       trunc(ncpic.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryVenta.Append("       ncpd.impuesto_id = imp.id_padre AND \n");
                queryVenta.Append("       ncpic.CASO_ID = c.id AND \n");
                queryVenta.Append("       c.flujo_id = f.id ) ");
                queryVenta.Append("        GROUP  BY tipo_documento,id,condicion_pago,cantidad_pagos,caso_id,fecha,tipo_factura_id,persona_nombre_completo,autonumeracion_timbrado,nro_comprobante,ruc,flujo_id,sucursal_nombre, dv) \n");
                queryVenta.Append("GROUP  BY tipo_documento,condicion_pago,cantidad_pagos,caso_id,fecha,tipo_factura_id,persona_nombre_completo,autonumeracion_timbrado,nro_comprobante,ruc,flujo_id,sucursal_nombre, dv \n");
                queryVenta.Append("ORDER  BY fecha,persona_nombre_completo ");


                string sql = queryVenta.ToString();
                
                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_venta_hechauka";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    
    public DataTable ObtenerDatosVentaHechaukaV2(bool incluirAnuladas)
    {
        try
        {
            DataTable dtDatos = new DataTable();
            using (SessionService sesion = new SessionService())
            {

                DateTime fecha = DateTime.Parse(fechaFinal);

                int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime ultimoDia = new DateTime(fecha.Year, fecha.Month, diasEnMes);

                decimal paisId;
                if (sesion.SucursalActiva.ES_CASA_MATRIZ == Definiciones.SiNo.Si)
                    paisId = sesion.SucursalActiva.PAIS_ID;
                else
                    paisId = new SucursalesService(sesion.SucursalActiva.SUC_CASA_MATRIZ_ID, sesion).PaisId;

                StringBuilder queryVenta = new StringBuilder();
                queryVenta.Append("SELECT 2                                                  tipo_registro, \n");
                queryVenta.Append("       condicion_pago, \n");
                queryVenta.Append("       decode(tipo_factura_id, 'CONTADO', 0, \n");
                queryVenta.Append("                               'CREDITO', cantidad_pagos) cantidad_pagos, \n");
                queryVenta.Append("       caso_id                                            nro_caso, \n");
                queryVenta.Append("       TO_char(fecha, 'DD/MM/YYYY')                       fecha_documento, \n");
                queryVenta.Append("       persona_nombre_completo                            nombre_proveedor, \n");
                queryVenta.Append("       autonumeracion_timbrado, \n");
                queryVenta.Append("       1                                                  numero_timbrado, \n");
                queryVenta.Append("       tipo_documento, \n");
                queryVenta.Append("       nro_comprobante                                    nro_documento, \n");
                queryVenta.Append("       ruc                                                ruc_proveedor, \n");
                queryVenta.Append("       dv, \n");
                queryVenta.Append("       flujo_id, \n");
                queryVenta.Append("       sucursal_nombre, \n");
                queryVenta.Append("       round(nvl(SUM(total_neto),0),9)                    total_neto, \n");
                queryVenta.Append("       round(nvl(SUM(total_gravado_10),0),9)              monto_compra_10, \n");
                queryVenta.Append("       round(nvl(SUM(total_iva_10),0),9)                  iva_credito_10, \n");
                queryVenta.Append("       round(nvl(SUM(total_gravado_5),0),9)               monto_compra_5, \n");
                queryVenta.Append("       round(nvl(SUM(total_iva_5),0),9)                   iva_credito_5, \n");
                queryVenta.Append("       round(nvl(SUM(total_exento),0),9)                  monto_compra_exenta, \n");
                queryVenta.Append("       TO_char(fecha, 'YYYYMM')                           Periodo, \n");
                queryVenta.Append("       tipo_factura_id, \n");
                queryVenta.Append("       decode(tipo_factura_id, 'CONTADO', 1, \n");
                queryVenta.Append("                               'CREDITO', 2)              condicion_venta \n");
                queryVenta.Append("FROM   (SELECT condicion_pago, \n");
                queryVenta.Append("               cantidad_pagos, \n");
                queryVenta.Append("               caso_id, \n");
                queryVenta.Append("               tipo_factura_id, \n");
                queryVenta.Append("               fecha, \n");
                queryVenta.Append("               persona_nombre_completo, \n");
                queryVenta.Append("               autonumeracion_timbrado, \n");
                queryVenta.Append("               1        numero_timbrado, \n");
                queryVenta.Append("               tipo_documento, \n");
                queryVenta.Append("               nro_comprobante, \n");
                queryVenta.Append("               ruc, \n");
                queryVenta.Append("               flujo_id, \n");
                queryVenta.Append("               sucursal_nombre, \n");
                queryVenta.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryVenta.Append("                                           ELSE total_neto \n");
                queryVenta.Append("                                           END) \n");
                queryVenta.Append("               ELSE SUM(total_neto) \n");
                queryVenta.Append("               END      total_neto, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN (total_neto - total_monto_impuesto) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_gravado_10, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 10 THEN total_monto_impuesto \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_iva_10, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN (total_neto - total_monto_impuesto) * porcentaje_impuesto / porcentaje_comparacion \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_gravado_5, \n");
                queryVenta.Append("               SUM(CASE porcentaje_comparacion WHEN 5 THEN total_monto_impuesto \n");
                queryVenta.Append("                   ELSE 0 \n");
                queryVenta.Append("                   END) total_iva_5, \n");
                queryVenta.Append("               CASE WHEN count(id) > 1 THEN SUM(CASE porcentaje_comparacion WHEN 0 THEN 0 \n");
                queryVenta.Append("                                           ELSE (total_neto - total_monto_impuesto) * (1 - porcentaje_impuesto / porcentaje_comparacion) \n");
                queryVenta.Append("                                           END) \n");
                queryVenta.Append("               ELSE SUM(CASE porcentaje_comparacion WHEN 0 THEN total_neto \n");
                queryVenta.Append("                        ELSE 0 \n");
                queryVenta.Append("                        END) \n");
                queryVenta.Append("               END      total_exento, dv \n");
                queryVenta.Append("        FROM   (SELECT 2                                                tipo_registro, \n");
                queryVenta.Append("                       ccp.nombre                                       condicion_pago, \n");
                queryVenta.Append("                       ccp.cantidad_pagos, \n");
                queryVenta.Append("                       fc.sucursal_nombre, \n");
                queryVenta.Append("                       fc.caso_id, \n");
                queryVenta.Append("                       trunc(fc.fecha)                                  fecha, \n");
                queryVenta.Append("                       fc.persona_nombre_completo, \n");
                queryVenta.Append("                       fc.autonumeracion_timbrado, \n");
                queryVenta.Append("                       1                                                numero_timbrado, \n");
                queryVenta.Append("                       1                                                tipo_documento, \n");
                queryVenta.Append("                       fc.nro_comprobante, \n");
                queryVenta.Append("                       fd.id, \n");
                queryVenta.Append("                       CASE WHEN fc.moneda_destino_id = 1 THEN fd.total_neto \n");
                queryVenta.Append("                       ELSE fd.total_neto / fc.cotizacion_destino * herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, 1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_neto, \n");
                queryVenta.Append("                       imp.porcentaje_hijo                              porcentaje_impuesto, \n");
                queryVenta.Append("                       imp.porcentaje_padre                             porcentaje_comparacion, \n");
                queryVenta.Append("                       CASE WHEN fc.moneda_destino_id = 1 THEN fd.total_monto_impuesto \n");
                queryVenta.Append("                       ELSE fd.total_monto_impuesto / fc.cotizacion_destino * herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, 1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_monto_impuesto, \n");
                queryVenta.Append("                       imp.id_padre                                     impuesto_id, \n");
                queryVenta.Append("                       p.ruc, \n");
                queryVenta.Append("                       pa_calcular_dv_11_a(p.ruc, 11)                   dv, \n");
                queryVenta.Append("                       p.codigo, \n");
                queryVenta.Append("                       c.flujo_id, \n");
                queryVenta.Append("                       TO_char(fc.fecha, 'YYYYMM')                      Periodo, \n");
                queryVenta.Append("                       fc.tipo_factura_id \n");
                queryVenta.Append("                FROM   facturas_cliente_info_completa fc, \n");
                queryVenta.Append("                       facturas_cliente_det_inf_co fd, \n");
                queryVenta.Append("                       articulos_info_completa a, \n");
                queryVenta.Append("                       personas p, \n");
                queryVenta.Append("                       casos c, \n");
                queryVenta.Append("                       flujos f, \n");
                queryVenta.Append("                       ctacte_condiciones_pago ccp, \n");
                queryVenta.Append("                       (SELECT id_padre, \n");
                queryVenta.Append("                               porcentaje_padre, \n");
                queryVenta.Append("                               porcentaje_hijo \n");
                queryVenta.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryVenta.Append("                                FROM   impuestos i1, \n");
                queryVenta.Append("                                       impuestos i2, \n");
                queryVenta.Append("                                       impuestos_compuestos ic \n");
                queryVenta.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryVenta.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryVenta.Append("                WHERE  fd.facturas_cliente_id = fc.id AND \n");
                queryVenta.Append("                       fc.estado = 'A' AND \n");
                queryVenta.Append("                       fd.articulo_id = a.id AND \n");
                queryVenta.Append("                       fc.condicion_pago_id = ccp.id AND \n");
                queryVenta.Append("                       fc.persona_id = p.id AND \n");
                queryVenta.Append("                       fc.caso_id = c.id AND \n");
                queryVenta.Append("                       c.flujo_id = f.id AND \n");
                queryVenta.Append("                       trunc(fc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                queryVenta.Append("                       trunc(fc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                queryVenta.Append("                       fc.caso_estado_id IN ('CERRADO', 'CAJA') AND \n");
                queryVenta.Append("                       p.es_contribuyente = 'S' AND \n");
                queryVenta.Append("                       fd.impuesto_id = imp.id_padre \n");
                queryVenta.Append(" \n");
                if (incluirAnuladas == true)
                {
                    queryVenta.Append("                UNION ALL \n");
                    queryVenta.Append("                SELECT 2                              tipo_registro, \n");
                    queryVenta.Append("                       ccp.nombre                     condicion_pago, \n");
                    queryVenta.Append("                       ccp.cantidad_pagos, \n");
                    queryVenta.Append("                       fc.sucursal_nombre, \n");
                    queryVenta.Append("                       fc.caso_id, \n");
                    queryVenta.Append("                       trunc(fc.fecha)                fecha, \n");
                    queryVenta.Append("                       fc.persona_nombre_completo, \n");
                    queryVenta.Append("                       fc.autonumeracion_timbrado, \n");
                    queryVenta.Append("                       1                              numero_timbrado, \n");
                    queryVenta.Append("                       1                              tipo_documento, \n");
                    queryVenta.Append("                       fc.nro_comprobante, \n");
                    queryVenta.Append("                       fd.id, \n");
                    queryVenta.Append("                       0                              total_neto, \n");
                    queryVenta.Append("                       imp.porcentaje_hijo            porcentaje_impuesto, \n");
                    queryVenta.Append("                       imp.porcentaje_padre           porcentaje_comparacion, \n");
                    queryVenta.Append("                       0                              total_monto_impuesto, \n");
                    queryVenta.Append("                       imp.id_padre                   impuesto_id, \n");
                    queryVenta.Append("                       p.ruc, \n");
                    queryVenta.Append("                       pa_calcular_dv_11_a(p.ruc, 11) dv, \n");
                    queryVenta.Append("                       p.codigo, \n");
                    queryVenta.Append("                       c.flujo_id, \n");
                    queryVenta.Append("                       TO_char(fc.fecha, 'YYYYMM')    Periodo, \n");
                    queryVenta.Append("                       fc.tipo_factura_id \n");
                    queryVenta.Append("                FROM   facturas_cliente_info_completa fc, \n");
                    queryVenta.Append("                       facturas_cliente_det_inf_co fd, \n");
                    queryVenta.Append("                       articulos_info_completa a, \n");
                    queryVenta.Append("                       personas p, \n");
                    queryVenta.Append("                       casos c, \n");
                    queryVenta.Append("                       flujos f, \n");
                    queryVenta.Append("                       ctacte_condiciones_pago ccp, \n");
                    queryVenta.Append("                       (SELECT id_padre, \n");
                    queryVenta.Append("                               porcentaje_padre, \n");
                    queryVenta.Append("                               porcentaje_hijo \n");
                    queryVenta.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                    queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                    queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                    queryVenta.Append("                                FROM   impuestos i1, \n");
                    queryVenta.Append("                                       impuestos i2, \n");
                    queryVenta.Append("                                       impuestos_compuestos ic \n");
                    queryVenta.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                    queryVenta.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                    queryVenta.Append("                WHERE  fd.facturas_cliente_id = fc.id AND \n");
                    queryVenta.Append("                       fc.estado = 'A' AND \n");
                    queryVenta.Append("                       fd.articulo_id = a.id AND \n");
                    queryVenta.Append("                       fc.condicion_pago_id = ccp.id AND \n");
                    queryVenta.Append("                       fc.persona_id = p.id AND \n");
                    queryVenta.Append("                       fc.caso_id = c.id AND \n");
                    queryVenta.Append("                       c.flujo_id = f.id AND \n");
                    queryVenta.Append("                       trunc(fc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                    queryVenta.Append("                       trunc(fc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy') AND \n");
                    queryVenta.Append("                       fc.caso_estado_id = 'ANULADO' AND \n");
                    queryVenta.Append("                       fd.impuesto_id = imp.id_padre AND \n");
                    queryVenta.Append("                       p.es_contribuyente = 'S' \n");
                    queryVenta.Append(" \n");
                }
                queryVenta.Append("UNION ALL \n");
                queryVenta.Append("                SELECT 2 tipo_registro, \n");
                queryVenta.Append("                       'CONTADO' condicion_pago, \n");
                queryVenta.Append("                       0 cantidad_pagos, \n");
                queryVenta.Append("                       '' sucursal_nombre, \n");
                queryVenta.Append("                       -1 caso_id, \n");
                queryVenta.Append("                       to_date('" + ultimoDia.ToShortDateString() + "','dd/mm/yyyy') fecha, \n");
                queryVenta.Append("                       case p." + PersonasService.PaisResidenciaId_NombreCol + " \n");
                queryVenta.Append("                       when " + paisId + " then 'Importes Consolidados' else 'Clientes del Exterior' end persona_nombre_completo, \n");
                queryVenta.Append("                       '0' autonumeracion_timbrado, \n");
                queryVenta.Append("                       0 numero_timbrado, \n");
                queryVenta.Append("                       1 tipo_documento, \n");
                queryVenta.Append("                       '0' nro_comprobante, \n");
                queryVenta.Append("                       fd.id, \n");
                queryVenta.Append("                       CASE \n");
                queryVenta.Append("                         WHEN fc.moneda_destino_id = 1 THEN \n");
                queryVenta.Append("                          fd.total_neto \n");
                queryVenta.Append("                         ELSE \n");
                queryVenta.Append("                          fd.total_neto / fc.cotizacion_destino * \n");
                queryVenta.Append("                          herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, \n");
                queryVenta.Append("                                                                1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_neto, \n");
                queryVenta.Append("                       imp.porcentaje_hijo porcentaje_impuesto, \n");
                queryVenta.Append("                       imp.porcentaje_padre porcentaje_comparacion, \n");
                queryVenta.Append("                       CASE \n");
                queryVenta.Append("                         WHEN fc.moneda_destino_id = 1 THEN \n");
                queryVenta.Append("                          fd.total_monto_impuesto \n");
                queryVenta.Append("                         ELSE \n");
                queryVenta.Append("                          fd.total_monto_impuesto / fc.cotizacion_destino * \n");
                queryVenta.Append("                          herramientas.Obtener_Cotizacion_Compra(fc.sucursal_id, \n");
                queryVenta.Append("                                                                1, fc.fecha) \n");
                queryVenta.Append("                       END * (1 - fc.porcentaje_desc_sobre_total / 100) total_monto_impuesto, \n");
                queryVenta.Append("                       imp.id_padre impuesto_id, \n");
                queryVenta.Append("                       case p." + PersonasService.PaisResidenciaId_NombreCol + " \n");
                queryVenta.Append("                       when " + paisId + " then '44444401' else '88888801' end ruc, \n");
                queryVenta.Append("                       case p." + PersonasService.PaisResidenciaId_NombreCol + " \n");
                queryVenta.Append("                       when " + paisId + " then 7 else 5 end dv, \n");
                queryVenta.Append("                       -1 codigo, \n");
                queryVenta.Append("                       c.flujo_id, \n");
                queryVenta.Append("                       TO_char('" + ultimoDia.ToShortDateString() + "' , 'YYYYMM')                            Periodo, \n");
                queryVenta.Append("                       'CONTADO' tipo_factura_id \n");
                queryVenta.Append("                  FROM facturas_cliente_info_completa fc, \n");
                queryVenta.Append("                       facturas_cliente_det_inf_co fd, \n");
                queryVenta.Append("                       articulos_info_completa a, \n");
                queryVenta.Append("                       personas p, \n");
                queryVenta.Append("                       casos c, \n");
                queryVenta.Append("                       flujos f, \n");
                queryVenta.Append("                       ctacte_condiciones_pago ccp, \n");
                queryVenta.Append("                       (SELECT id_padre, porcentaje_padre, porcentaje_hijo \n");
                queryVenta.Append("                          FROM (SELECT i1.id id_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje) porcentaje_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, \n");
                queryVenta.Append("                                           i1.porcentaje) porcentaje_hijo \n");
                queryVenta.Append("                                  FROM impuestos            i1, \n");
                queryVenta.Append("                                       impuestos            i2, \n");
                queryVenta.Append("                                       impuestos_compuestos ic \n");
                queryVenta.Append("                                 WHERE i1.id = ic.impuesto_padre_id(+) \n");
                queryVenta.Append("                                   AND ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryVenta.Append("                 WHERE fd.facturas_cliente_id = fc.id \n");
                queryVenta.Append("                   AND fc.estado = 'A' \n");
                queryVenta.Append("                   AND fd.articulo_id = a.id \n");
                queryVenta.Append("                   AND fc.condicion_pago_id = ccp.id \n");
                queryVenta.Append("                   AND fc.persona_id = p.id \n");
                queryVenta.Append("                   AND fc.caso_id = c.id \n");
                queryVenta.Append("                   AND c.flujo_id = f.id \n");
                queryVenta.Append("                   AND    trunc(fc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy')  \n");
                queryVenta.Append("                   AND    trunc(fc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy')  \n");
                queryVenta.Append("                   AND fc.caso_estado_id IN ('CERRADO', 'CAJA') \n");
                queryVenta.Append("                   AND p.es_contribuyente = 'N' \n");
                queryVenta.Append("                   AND fd.impuesto_id = imp.id_padre");
                queryVenta.Append(" \n");
                queryVenta.Append("                UNION ALL \n");
                queryVenta.Append("SELECT 2                              tipo_registro, \n");
                queryVenta.Append("       NULL                           condicion_pago, \n");
                queryVenta.Append("       NULL                           cantidad_pagos, \n");
                queryVenta.Append("       nc.sucursal_nombre, \n");
                queryVenta.Append("       nc.caso_id, \n");
                queryVenta.Append("       trunc(nc.fecha), \n");
                queryVenta.Append("       nc.persona_nombre, \n");
                queryVenta.Append("       nvl(a.numero_timbrado,'1')     nro_timbrado, \n");
                queryVenta.Append("       to_number(nvl(a.numero_timbrado,'1'))     numero_timbrado, \n");
                queryVenta.Append("       3                              tipo_documento, \n");
                queryVenta.Append("       nc.nro_comprobante, \n");
                queryVenta.Append("       nc.id, \n");
                queryVenta.Append("       CASE WHEN nc.moneda_id = 1 THEN ncd.total \n");
                queryVenta.Append("       ELSE ncd.total / nc.cotizacion_moneda  * herramientas.Obtener_Cotizacion_Compra(nc.sucursal_id, 1, nc.fecha) \n");
                queryVenta.Append("       END                            total_pago, \n");
                queryVenta.Append("       imp.porcentaje_hijo            porcentaje_impuesto, \n");
                queryVenta.Append("       imp.porcentaje_padre           porcentaje_comparacion, \n");
                queryVenta.Append("       CASE WHEN nc.moneda_id = 1 THEN ncd.impuesto_monto \n");
                queryVenta.Append("       ELSE ncd.impuesto_monto / nc.cotizacion_moneda * herramientas.Obtener_Cotizacion_Compra(nc.sucursal_id, 1, nc.fecha) \n");
                queryVenta.Append("       END                            total_impuesto_descontado, \n");
                queryVenta.Append("       imp.id_padre                   impuesto_id, \n");
                queryVenta.Append("       p.ruc, \n");
                queryVenta.Append("       pa_calcular_dv_11_a(p.ruc, 11) dv, \n");
                queryVenta.Append("       p.codigo, \n");
                queryVenta.Append("       c.flujo_id, \n");
                queryVenta.Append("       TO_char(nc.fecha, 'YYYYMM') Periodo, \n");
                queryVenta.Append("       'CONTADO'                      tipo_factura_id \n");
                queryVenta.Append("                FROM   notas_credito_persona_inf_comp nc, \n");
                queryVenta.Append("                       notas_cred_per_det_inf_comp ncd, \n");
                queryVenta.Append("                       autonumeraciones a, \n");
                queryVenta.Append("                       personas p, \n");
                queryVenta.Append("                       casos c, \n");
                queryVenta.Append("                       flujos f, \n");
                queryVenta.Append("                       (SELECT id_padre, \n");
                queryVenta.Append("                               porcentaje_padre, \n");
                queryVenta.Append("                               porcentaje_hijo \n");
                queryVenta.Append("                        FROM   (SELECT i1.id                                                   id_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje, i1.porcentaje)                       porcentaje_padre, \n");
                queryVenta.Append("                                       nvl(i2.porcentaje * ic.porcentaje / 100, i1.porcentaje) porcentaje_hijo \n");
                queryVenta.Append("                                FROM   impuestos i1, \n");
                queryVenta.Append("                                       impuestos i2, \n");
                queryVenta.Append("                                       impuestos_compuestos ic \n");
                queryVenta.Append("                                WHERE  i1.id = ic.impuesto_padre_id(+) AND \n");
                queryVenta.Append("                                       ic.impuesto_hijo_id = i2.id(+))) imp \n");
                queryVenta.Append("                WHERE  ncd.nota_credito_persona_id = nc.id AND \n");
                queryVenta.Append("                       nc.autonumeracion_id = a.id(+) AND \n");
                queryVenta.Append("                       nc.persona_id = p.id AND \n");
                queryVenta.Append("                       nc.caso_id = c.id AND \n");
                queryVenta.Append("                       c.flujo_id = f.id AND \n");
                queryVenta.Append("       trunc(nc.fecha, 'DD') >= to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryVenta.Append("       trunc(nc.fecha, 'DD') <= to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'DD/MM/yyyy') AND \n");
                queryVenta.Append("                       nc.caso_estado_id IN ('CERRADO', 'APROBADO') AND \n");
                queryVenta.Append("                       ncd.impuesto_id = imp.id_padre)   GROUP  BY tipo_documento,id,condicion_pago,cantidad_pagos,caso_id,fecha,tipo_factura_id,persona_nombre_completo,autonumeracion_timbrado,nro_comprobante,ruc,flujo_id,sucursal_nombre, dv)");
                queryVenta.Append("GROUP  BY tipo_documento,condicion_pago,cantidad_pagos,caso_id,fecha,tipo_factura_id,persona_nombre_completo,autonumeracion_timbrado,nro_comprobante,ruc,flujo_id,sucursal_nombre, dv \n");
                queryVenta.Append("ORDER  BY fecha,persona_nombre_completo ");


                string sql = queryVenta.ToString();

                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_venta_hechauka";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Comprobantes Retencion Hechauka
    public DataTable ObtenerDatosRetencionHechauka()
    {
        try
        {
            DataTable dtDatos = new DataTable();

            using (SessionService sesion = new SessionService())
            {
                StringBuilder queryRetenciones = new StringBuilder();
                queryRetenciones.Append("select 2 tipo_registro, \n");
                queryRetenciones.Append("       p.ruc ruc_proveedor, \n");
                queryRetenciones.Append("       pa_calcular_dv_11_a(p.ruc, 11) dv_proveedor, \n");
                queryRetenciones.Append("       p.razon_social nombre_proveedor, \n");
                queryRetenciones.Append("       1 tipo_operacion, \n");
                queryRetenciones.Append("       to_char(fp.fecha_factura,'dd/mm/yyyy') fecha_comprobante, \n");
                queryRetenciones.Append("       fp.nro_comprobante nro_factura_venta, \n");
                queryRetenciones.Append("       cre.nro_comprobante comprobante_retencion, \n");
                queryRetenciones.Append("       to_char(cre.fecha,'dd/mm/yyyy') fecha_retencion, \n");
                queryRetenciones.Append("       0 base_renta, \n");
                queryRetenciones.Append("       cred.total_impuesto monto_impuesto, \n");
                queryRetenciones.Append("       cred.monto total_retencion, \n");
                queryRetenciones.Append("       0 monto_retencion_renta, \n");
                queryRetenciones.Append("       fp.nro_timbrado nro_timbrado, TO_char(fp.fecha_factura, 'YYYYMM') periodo \n");
                queryRetenciones.Append("  from ctacte_retenc_emit_info_comp  cre, \n");
                queryRetenciones.Append("       ctacte_retenc_emit_det_info_c cred, \n");
                queryRetenciones.Append("       proveedores                   p, \n");
                queryRetenciones.Append("       facturas_proveedor            fp \n");
                queryRetenciones.Append(" where cred.ctacte_retencion_emitida_id = cre.id \n");
                queryRetenciones.Append("   and cre.proveedor_id = p.id \n");
                queryRetenciones.Append("   and cred.caso_id = fp.caso_id \n");
                queryRetenciones.Append("   and trunc(cre.fecha) between to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') and \n");
                queryRetenciones.Append("       to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy')");

                string sql = queryRetenciones.ToString();
                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_retencion_hechauka";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Crear Archivo Hechauka
    private Hashtable CabeceraArchivoHechauka(string tipoLibro)
    {
        try
        {
            Hashtable cabecera = new Hashtable();

            if (Definiciones.ReporteHechauka.COMPRA.Equals(tipoLibro))
            {
                cabecera.Add("tipoRegistro", "1\t");
                cabecera.Add("tipoReporte", "1\t");
                cabecera.Add("tipoInformacion", "911\t");
                cabecera.Add("codigoFormulario", "211\t");
                 
                cabecera.Add("RUCRepresentante", this.rucRepresentante + "\t");
                cabecera.Add("DVRepresentante", this.dvRepresentante + "\t");
                cabecera.Add("nombreRepresentante", this.representante + "\t");
            }
            else if (Definiciones.ReporteHechauka.RETENCION.Equals(tipoLibro))
            {
                cabecera.Add("tipoRegistro", "1\t");
                cabecera.Add("tipoReporte", "1\t");
                cabecera.Add("tipoInformacion", "931\t");
                cabecera.Add("codigoFormulario", "231\t");

                cabecera.Add("RUCRepresentante", this.rucRepresentante + "\t");
                cabecera.Add("DVRepresentante", this.dvRepresentante + "\t");
                cabecera.Add("nombreRepresentante", this.representante + "\t");
            }
            else
            {
                cabecera.Add("tipoRegistro", "1\t");
                cabecera.Add("tipoReporte", "1\t");
                cabecera.Add("tipoInformacion", "921\t");
                cabecera.Add("codigoFormulario", "221\t");

                cabecera.Add("RUCRepresentante", this.rucRepresentante + "\t");
                cabecera.Add("DVRepresentante", this.dvRepresentante + "\t");
                cabecera.Add("nombreRepresentante", this.representante + "\t");
            }

            return cabecera;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error al generar la cabecera del archivo para el Hechauka (CabeceraArchivoHechauka):" + exp.Message);
        }
    }

    public List<string> ExportarArchivoHechauka(bool incluirAnuladas)
    {
        string tipoLibro = this.tipoLibro;

        Hashtable cabecera = CabeceraArchivoHechauka(tipoLibro);
        DataTable dtDatos;

        if (Definiciones.ReporteHechauka.VENTA.Equals(tipoLibro))
        {
            if (this.tipoDatos == 1)
                dtDatos = this.ObtenerDatosVentaHechauka(incluirAnuladas);
            else
                dtDatos = this.ObtenerDatosVentaHechaukaV2(incluirAnuladas);
        }
        else if (Definiciones.ReporteHechauka.RETENCION.Equals(tipoLibro))
        {
            dtDatos = this.ObtenerDatosRetencionHechauka();
        }
        else
            if (this.tipoDatos == 1)
                dtDatos = this.ObtenerDatosCompraHechauka();
            else
                dtDatos = this.ObtenerDatosCompraHechaukaV2();

        if (dtDatos.Rows.Count <= 0)
            throw new Exception("No hay datos");

        System.Web.UI.Page pagina = new System.Web.UI.Page();
        string strCurrentDir = "";
        decimal totalCabecera = 0;
        decimal montoVenta = 0;
        string strline = "";
        string header;
        string nombreArchivo;
        StreamWriter outputFile;

        try
        {
            nombreArchivo = "hechauka_" + DateTime.Now.Ticks.ToString() + ".txt";
            CrearDirectiorio(nombreArchivo);
            strCurrentDir = pagina.Server.MapPath(pathServidor + pathTemporal);
            outputFile = new StreamWriter(strCurrentDir + nombreArchivo);

            this.archivos.Add(strCurrentDir + nombreArchivo);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + strCurrentDir);
        }

        if (Definiciones.ReporteHechauka.RETENCION.Equals(tipoLibro))
        {
            foreach (DataRow dbRow in dtDatos.Rows)
            {
                totalCabecera += decimal.Parse(dbRow["total_retencion"].ToString());
            }

            totalCabecera = Math.Round(totalCabecera, 0);

            header = cabecera["tipoRegistro"] + dtDatos.Rows[0]["PERIODO"].ToString() + "\t" + cabecera["tipoReporte"] + cabecera["tipoInformacion"] + cabecera["codigoFormulario"] + this.rucAgente + "\t" + this.dvAgente + "\t" + this.agente + "\t" + cabecera["RUCRepresentante"] + cabecera["DVRepresentante"] + cabecera["nombreRepresentante"] + dtDatos.Rows.Count + "\t" + totalCabecera + "\t" + version + "\t";
            outputFile.WriteLine(header);
            foreach (DataRow dbRow in dtDatos.Rows)
            {
                strline += dbRow["tipo_registro"].ToString() + '\t';
                strline += dbRow["ruc_proveedor"].ToString() + '\t';
                strline += dbRow["dv_proveedor"].ToString() + '\t';
                strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nombre_proveedor"]) + '\t';
                strline += dbRow["tipo_operacion"].ToString() + '\t';
                strline += dbRow["fecha_comprobante"].ToString() + '\t';
                strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_factura_venta"]) + '\t';
                strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["comprobante_retencion"]) + '\t';
                strline += dbRow["fecha_retencion"].ToString() + '\t';
                strline += dbRow["base_renta"].ToString() + '\t';
                strline += dbRow["monto_impuesto"].ToString() + '\t';
                strline += dbRow["total_retencion"].ToString() + '\t';
                strline += dbRow["monto_retencion_renta"].ToString() + '\t';

                outputFile.WriteLine(strline);
                strline = "";
            }
        }
        else
        {
            foreach (DataRow dbRow in dtDatos.Rows)
            {
                totalCabecera += Math.Round(decimal.Parse(dbRow["monto_compra_10"].ToString()), 0) +

                    Math.Round(decimal.Parse(dbRow["monto_compra_5"].ToString()), 0) +
                    Math.Round(decimal.Parse(dbRow["monto_compra_exenta"].ToString()), 0);
                if (Definiciones.ReporteHechauka.VENTA.Equals(tipoLibro))
                {
                    totalCabecera += Math.Round(decimal.Parse(dbRow["iva_credito_10"].ToString()), 0) +
                     Math.Round(decimal.Parse(dbRow["iva_credito_5"].ToString()), 0);
                }
            }
            totalCabecera = Math.Round(totalCabecera, 0);

            
            header = cabecera["tipoRegistro"] + dtDatos.Rows[0]["PERIODO"].ToString() + "\t" + cabecera["tipoReporte"] + cabecera["tipoInformacion"] + cabecera["codigoFormulario"] + this.rucAgente + "\t" + this.dvAgente + "\t" + this.agente + "\t" + cabecera["RUCRepresentante"] + cabecera["DVRepresentante"] + cabecera["nombreRepresentante"] + dtDatos.Rows.Count + "\t" + totalCabecera + "\t";

            if (Definiciones.ReporteHechauka.VENTA.Equals(tipoLibro))
            {
                header = header + version + "\t";
            }

            if (Definiciones.ReporteHechauka.COMPRA.Equals(tipoLibro))
            {
                header = header + "NO" + "\t" + version + "\t";
            }

            outputFile.WriteLine(header);

            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if ((i + 1) % 15000 == 0)
                {
                    try
                    {
                        outputFile.Close();

                        nombreArchivo = "hechauka_" + DateTime.Now.Ticks.ToString() + ".txt";
                        CrearDirectiorio(nombreArchivo);
                        strCurrentDir = pagina.Server.MapPath(pathServidor + pathTemporal);
                        outputFile = new StreamWriter(strCurrentDir + nombreArchivo);

                        this.archivos.Add(strCurrentDir + nombreArchivo);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + strCurrentDir);
                    }
                }

                strline += dtDatos.Rows[i]["tipo_registro"].ToString() + '\t';
                strline += dtDatos.Rows[i]["ruc_proveedor"].ToString() + '\t';
                strline += dtDatos.Rows[i]["dv"].ToString() + '\t';
                strline += StringUtil.QuitarCaracteresNoImprimibles(dtDatos.Rows[i]["nombre_proveedor"]) + '\t';
               
                if (Definiciones.ReporteHechauka.COMPRA.Equals(tipoLibro))
                {
                    strline += dtDatos.Rows[i]["nro_timbrado"].ToString() + '\t';
                }

                strline += dtDatos.Rows[i]["tipo_documento"].ToString() + '\t';
                strline += StringUtil.QuitarCaracteresNoImprimibles(dtDatos.Rows[i]["nro_documento"]) + '\t';
                strline += dtDatos.Rows[i]["fecha_documento"].ToString() + '\t';
                strline += Math.Round(decimal.Parse(dtDatos.Rows[i]["monto_compra_10"].ToString()), 0).ToString() + '\t';
                strline += Math.Round(decimal.Parse(dtDatos.Rows[i]["iva_credito_10"].ToString()), 0).ToString() + '\t';
                strline += Math.Round(decimal.Parse(dtDatos.Rows[i]["monto_compra_5"].ToString()), 0).ToString() + '\t';
                strline += Math.Round(decimal.Parse(dtDatos.Rows[i]["iva_credito_5"].ToString()), 0).ToString() + '\t';
                strline += Math.Round(decimal.Parse(dtDatos.Rows[i]["monto_compra_exenta"].ToString()), 0).ToString() + '\t';
                
                if (Definiciones.ReporteHechauka.COMPRA.Equals(tipoLibro))
                {
                    strline += dtDatos.Rows[i]["tipo_operacion"].ToString() + '\t';
                    strline += dtDatos.Rows[i]["condicion_compra"].ToString() + '\t';
                    strline += dtDatos.Rows[i]["cantidad_pagos"].ToString() + '\t';
                }

                if (Definiciones.ReporteHechauka.VENTA.Equals(tipoLibro))
                {
                    montoVenta = Math.Round(decimal.Parse(dtDatos.Rows[i]["monto_compra_10"].ToString()), 0) +
                        Math.Round(decimal.Parse(dtDatos.Rows[i]["monto_compra_5"].ToString()), 0) +
                        Math.Round(decimal.Parse(dtDatos.Rows[i]["monto_compra_exenta"].ToString()), 0) +
                        Math.Round(decimal.Parse(dtDatos.Rows[i]["iva_credito_10"].ToString()), 0) +
                        Math.Round(decimal.Parse(dtDatos.Rows[i]["iva_credito_5"].ToString()), 0);
                    montoVenta = Math.Round(montoVenta, 0);
                    strline += montoVenta.ToString() + '\t';

                    strline += dtDatos.Rows[i]["condicion_venta"].ToString() + '\t';
                    strline += dtDatos.Rows[i]["cantidad_pagos"].ToString() + '\t';
                    strline += dtDatos.Rows[i]["autonumeracion_timbrado"].ToString() + '\t';
                }

                outputFile.WriteLine(strline);
                strline = "";
            }
        }

        outputFile.Close();
        pagina.Dispose();

        return archivos;
    }
    #endregion

    #region CrearDirectorio
    public void CrearDirectiorio(string nombreArchivo)
    {
        System.Web.UI.Page page = new System.Web.UI.Page();
        string pathCompleto = page.Server.MapPath(pathServidor) + pathTemporal;

        if (!Directory.Exists(pathCompleto)) Directory.CreateDirectory(pathCompleto);
        if (File.Exists(pathCompleto + nombreArchivo))
        {
            File.Delete(pathCompleto + nombreArchivo);
        }
    }
    #endregion CrearDirectorio
}
