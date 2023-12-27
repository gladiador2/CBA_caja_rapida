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
public class MarangatuService
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
    private string nombreArchivo = "";
    List<string> archivos;
    private decimal tipoDatos;

   
    #endregion

    #region Constantes
    private const string pathServidor = @"~/" + "/Resources/Hechauka/";
    private const string pathTemporal = "tmp\\";
    #endregion Constantes

    #region Constructor
    public MarangatuService(string fechaInicial, string fechaFinal, string tipoLibro, decimal tipoDatos, string archivo)
    {
        this.fechaInicial = fechaInicial;
        this.fechaFinal = fechaFinal;
        this.tipoLibro = tipoLibro;
        this.tipoDatos = tipoDatos;
        this.nombreArchivo = archivo;

        this.archivos = new List<string>();
    }
    #endregion Constructor

    #region Accesors
    public static string Nombre_Tabla
    {
        get { return "CTB_ARCHIVOS_MARANGATU"; }
    }
    public static string Nombre_Secuencia
    {
        get { return "ctb_archi_marangatu_sqc"; }
    }
    public static string Periodo_NombreCol
    {
        get { return CTB_ARCHIVOS_MARANGATUCollection.PERIODOColumnName; }
    }
    public static string FechaCreacion_NombreCol
    {
        get { return CTB_ARCHIVOS_MARANGATUCollection.FECHA_CREACIONColumnName; }
    }
    public static string UsuarioId_NombreCol
    {
        get { return CTB_ARCHIVOS_MARANGATUCollection.USUARIO_IDColumnName; }
    }
    public static string TipoRegistro_NombreCol
    {
        get { return CTB_ARCHIVOS_MARANGATUCollection.TIPO_REGISTROColumnName; }
    }
    public static string Version_NombreCol
    {
        get { return CTB_ARCHIVOS_MARANGATUCollection.VERSIONColumnName; }
    }
    #endregion Accesors

    #region Venta
    public DataTable ObtenerDatosVenta()
    {
        try
        {
            DataTable dtDatos = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                //DateTime fechaDesde = DateTime.Parse(fechaInicial);
                //DateTime fechaHasta = DateTime.Parse(fechaFinal);

                DateTime fecha = DateTime.Parse(fechaFinal);

                int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime ultimoDia = new DateTime(fecha.Year, fecha.Month, diasEnMes);

                decimal paisId;
                if (sesion.SucursalActiva.ES_CASA_MATRIZ == Definiciones.SiNo.Si)
                    paisId = sesion.SucursalActiva.PAIS_ID;
                else
                    paisId = new SucursalesService(sesion.SucursalActiva.SUC_CASA_MATRIZ_ID, sesion).PaisId;

                StringBuilder queryVenta = new StringBuilder();
                queryVenta.Append("SELECT 1 tipo_registro, \n");
                queryVenta.Append("       decode(p.tipo_documento_identidad_id, 'CI', 12, 'DNI', 14, 'PAS', 13, 11) as tp_identificacion_comprador, \n");
                queryVenta.Append("       replace(p.numero_documento,'.','') as numero_documento, \n");
                queryVenta.Append("       p.nombre_completo, \n");
                queryVenta.Append("       109 as tipo_comprobante, \n");
                queryVenta.Append("       to_char(fc.fecha, 'dd/mm/yyyy') as fecha, \n");
                queryVenta.Append("       au.numero_timbrado, \n");
                queryVenta.Append("       fc.nro_comprobante, \n");
                // gravadas 10
                queryVenta.Append("       CASE \n");
                queryVenta.Append("       WHEN (fc.moneda_destino_id <> 1) then \n");
                queryVenta.Append("           (select nvl(sum(det.total_neto),0)* Herramientas.Obtener_Cotizacion_compra(fc.sucursal_id, 1, fc.fecha) from facturas_cliente_detalle det where  det.facturas_cliente_id = fc.id and det.impuesto_id = 1) \n");
                queryVenta.Append("       ELSE \n");
                queryVenta.Append("            (select nvl(sum(round(det.total_neto)),0) from facturas_cliente_detalle det where det.facturas_cliente_id = fc.id and det.impuesto_id = 1) \n");
                queryVenta.Append("       END as gravadas_10, \n");
                // gravadas 5
                queryVenta.Append("       CASE \n");
                queryVenta.Append("       WHEN (fc.moneda_destino_id <> 1) then \n");
                queryVenta.Append("           (select nvl(sum(det.total_neto),0)* Herramientas.Obtener_Cotizacion_compra(fc.sucursal_id, 1, fc.fecha) from facturas_cliente_detalle det where  det.facturas_cliente_id = fc.id and det.impuesto_id = 2) \n");
                queryVenta.Append("       ELSE \n");
                queryVenta.Append("            (select nvl(sum(round(det.total_neto)),0) from facturas_cliente_detalle det where det.facturas_cliente_id = fc.id and det.impuesto_id = 2) \n");
                queryVenta.Append("       END as gravadas_5, \n");
                // exenta
                queryVenta.Append("        CASE \n");
                queryVenta.Append("       WHEN (fc.moneda_destino_id <> 1) then \n");
                queryVenta.Append("           (select nvl(sum(det.total_neto),0)* Herramientas.Obtener_Cotizacion_compra(fc.sucursal_id, 1, fc.fecha) from facturas_cliente_detalle det where  det.facturas_cliente_id = fc.id and det.impuesto_id = 3) \n");
                queryVenta.Append("       ELSE \n");
                queryVenta.Append("            (select nvl(sum(round(det.total_neto)),0) from facturas_cliente_detalle det where det.facturas_cliente_id = fc.id and det.impuesto_id = 3) \n");
                queryVenta.Append("       END as exentas, \n");
                // total factura
                queryVenta.Append("        CASE \n");
                queryVenta.Append("       WHEN (fc.moneda_destino_id <> 1) then \n");
                queryVenta.Append("            fc.total_neto * Herramientas.Obtener_Cotizacion_compra(fc.sucursal_id, 1, fc.fecha) \n");
                queryVenta.Append("           ELSE \n");
                queryVenta.Append("            round(fc.total_neto, 0) \n");
                queryVenta.Append("       END as total_factura,");
                //                
                queryVenta.Append("       decode(tipo_factura_id, 'CREDITO', 2, 1) as cond_venta, \n");
                queryVenta.Append("       'N' as operacion_moneda_extr, \n");
                queryVenta.Append("       'S' as imputa_iva, \n");
                queryVenta.Append("       'N' as imputa_ire, \n");
                queryVenta.Append("       'N' as imputa_irp \n");                
                queryVenta.Append("FROM   facturas_cliente fc, \n");
                queryVenta.Append("       personas_info_completa p, \n");
                queryVenta.Append("       autonumeraciones au, \n");
                queryVenta.Append("       casos c \n");
                queryVenta.Append("WHERE  fc.persona_id = p.id  \n");
                queryVenta.Append("  AND  fc.caso_id = c.id  \n");
                queryVenta.Append("  AND  fc.autonumeracion_id = au.id(+)  \n");
                queryVenta.Append("  AND  trunc(fc.fecha) between to_date('" + fechaInicial + "', 'dd/mm/yyyy') and to_date('" + fechaFinal + "', 'dd/mm/yyyy') \n");
                queryVenta.Append("  AND  c.estado_id in ('CERRADO', 'CAJA') ");

                string sql = queryVenta.ToString();
                
                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_venta";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }    
    #endregion

    #region Notas creditos cliente
    public DataTable ObtenerDatosNCCliente()
    {
        try
        {
            DataTable dtDatos = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                //DateTime fechaDesde = DateTime.Parse(fechaInicial);
                //DateTime fechaHasta = DateTime.Parse(fechaFinal);

                DateTime fecha = DateTime.Parse(fechaFinal);

                int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime ultimoDia = new DateTime(fecha.Year, fecha.Month, diasEnMes);

                decimal paisId;
                if (sesion.SucursalActiva.ES_CASA_MATRIZ == Definiciones.SiNo.Si)
                    paisId = sesion.SucursalActiva.PAIS_ID;
                else
                    paisId = new SucursalesService(sesion.SucursalActiva.SUC_CASA_MATRIZ_ID, sesion).PaisId;

                StringBuilder query = new StringBuilder();

                query.Append(" SELECT 1 tipo_registro, \n");
                query.Append("        decode(p.tipo_documento_identidad_id, 'CI', 12, 'DNI', 14, 'PAS', 13, 11) as tp_identificacion_comprador,  \n");
                query.Append("        p.numero_documento,  \n");
                query.Append("        p.nombre_completo,  \n");
                query.Append("        110 as tipo_comprobante, \n");                 
                query.Append("        to_char(nc.fecha, 'dd/mm/yyyy') fecha, \n");
                query.Append("        au.numero_timbrado,  \n");
                query.Append("        nc.nro_comprobante,  \n");
                query.Append("         DevuelveImporteGuaranies(nc.fecha, (select nvl(sum(det.total),0) from notas_credito_personas_det det where det.nota_credito_persona_id = nc.id and det.impuesto_id = 1), nc.moneda_id) as gravadas_10,  \n");
                query.Append("         DevuelveImporteGuaranies(nc.fecha, (select nvl(sum(det.total),0) from notas_credito_personas_det det where det.nota_credito_persona_id = nc.id and det.impuesto_id = 2), nc.moneda_id) as gravadas_5,  \n");
                query.Append("         DevuelveImporteGuaranies(nc.fecha, (select nvl(sum(det.total),0) from notas_credito_personas_det det where det.nota_credito_persona_id = nc.id and det.impuesto_id = 3), nc.moneda_id) as exentas,  \n");
                query.Append("         DevuelveImporteGuaranies(nc.fecha, nc.monto_total, nc.moneda_id) as total_factura,  \n");
                query.Append("        'N' as operacion_moneda_extr,  \n");
                query.Append("        'S' as imputa_iva,  \n");
                query.Append("        'N' as imputa_ire,  \n");
                query.Append("        'N' as imputa_irp,  \n");
                query.Append("        doc.nro_comprobante comprobante_venta,  \n");
                query.Append("        doc.numero_timbrado timbrado_venta \n");
                query.Append(" FROM   notas_credito_persona_inf_comp nc,  \n");
                query.Append("        personas_info_completa p,  \n");
                query.Append("        autonumeraciones au,  \n");
                query.Append("        casos c, \n");
                query.Append("        (SELECT distinct(ncd.factura_cliente_id) factura_cliente_id, fc.nro_comprobante, au.numero_timbrado, ncd.nota_credito_persona_id  \n");
                query.Append("          FROM notas_credito_personas_det ncd, facturas_cliente fc, autonumeraciones au  \n");
                query.Append("         WHERE ncd.factura_cliente_id = fc.id  \n");
                query.Append("           AND fc.autonumeracion_id = au.id) doc    \n");
                query.Append(" WHERE  nc.persona_id = p.id   \n");
                query.Append("   AND  nc.caso_id = c.id   \n");
                query.Append("   AND  nc.autonumeracion_id = au.id(+)   \n");
                query.Append("   AND  nc.id = doc.nota_credito_persona_id (+)  \n");
                query.Append("   AND  c.estado_id in ('APROBADO','CERRADO')  \n");
                query.Append("   AND  trunc(nc.fecha) between  to_date('" + fechaInicial + "', 'dd/mm/yyyy') and to_date('" + fechaFinal + "', 'dd/mm/yyyy')  \n");
   
                string sql = query.ToString();

                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_nc_cliente";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Compras
    public DataTable ObtenerDatosCompras()
    {
        try
        {
            DataTable dtDatos = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                //DateTime fechaDesde = DateTime.Parse(fechaInicial);
                //DateTime fechaHasta = DateTime.Parse(fechaFinal);

                DateTime fecha = DateTime.Parse(fechaFinal);

                int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime ultimoDia = new DateTime(fecha.Year, fecha.Month, diasEnMes);

                decimal paisId;
                if (sesion.SucursalActiva.ES_CASA_MATRIZ == Definiciones.SiNo.Si)
                    paisId = sesion.SucursalActiva.PAIS_ID;
                else
                    paisId = new SucursalesService(sesion.SucursalActiva.SUC_CASA_MATRIZ_ID, sesion).PaisId;

                StringBuilder query = new StringBuilder();
                query.Append(" SELECT 2 tipo_registro, \n");
                query.Append("        11 tp_identificacion_proveedor, \n");
                query.Append("        p.ruc, \n");
                query.Append("        p.razon_social, \n");
                query.Append("        coalesce(fp.ctb_tipo_comprobante_set_id, 109) as tipo_comprobante, \n");
                query.Append("        to_char(fp.fecha, 'dd/mm/yyyy') fecha, \n");
                query.Append("        fp.nro_timbrado,  \n");
                query.Append("        fp.nro_comprobante,  \n");
                query.Append("        fp.moneda_id,   \n");
                query.Append("        case fp.moneda_id when 1 then (select nvl(sum(det.total_bruto - det.total_descuento),0) from facturas_proveedor_detalle det where det.facturas_proveedor_id = fp.id and det.impuesto_id = 1)  \n");
                query.Append("           when 2 then (select nvl(sum(det.total_bruto - det.total_descuento),0) * fp.moneda_pais_cotizacion from facturas_proveedor_detalle det where det.facturas_proveedor_id = fp.id and det.impuesto_id = 1) end as gravadas_10,   \n");
                query.Append("        case fp.moneda_id when 1 then (select nvl(sum(det.total_bruto - det.total_descuento),0) from facturas_proveedor_detalle det where det.facturas_proveedor_id = fp.id and det.impuesto_id = 2)    \n");
                query.Append("           when 2 then (select nvl(sum(det.total_bruto - det.total_descuento),0) * fp.moneda_pais_cotizacion from facturas_proveedor_detalle det where det.facturas_proveedor_id = fp.id and det.impuesto_id = 2) end as gravadas_5,  \n");     
                query.Append("        case fp.moneda_id when 1 then (select nvl(sum(det.total_bruto - det.total_descuento),0) from facturas_proveedor_detalle det where det.facturas_proveedor_id = fp.id and det.impuesto_id = 3)    \n");
                query.Append("           when 2 then (select nvl(sum(det.total_bruto - det.total_descuento),0) * fp.moneda_pais_cotizacion from facturas_proveedor_detalle det where det.facturas_proveedor_id = fp.id and det.impuesto_id = 3) end as exentas,   \n");
                query.Append("        case fp.moneda_id when 1 then (fp.total_bruto - fp.total_descuento) when 2 then (fp.total_bruto - fp.total_descuento) * fp.moneda_pais_cotizacion end as total_factura, \n");
                query.Append("        decode(fp.ctacte_condicion_pago_id, 1, 1, 2) codigo_condicion_compra,  \n");
                query.Append("        case fp.moneda_id when 1 then 'N' when 2 then 'S' end as operacion_moneda_extr, \n");
                query.Append("        coalesce(fp.imputa_iva, 'S') as imputa_iva, \n");
                query.Append("        coalesce(fp.imputa_ire, 'N') as imputa_ire \n");
                query.Append(" FROM   facturas_proveedor fp,  \n");
                query.Append("        proveedores_info_completa p,  \n");
                query.Append("        casos c \n");
                query.Append(" WHERE  fp.proveedor_id = p.id  \n");
                query.Append("   AND  fp.caso_id = c.id    \n");
                query.Append("   AND  trunc(fp.fecha_factura) between to_date('" + fechaInicial + "', 'dd/mm/yyyy') and to_date('" + fechaFinal + "', 'dd/mm/yyyy')  \n");
                query.Append("   AND  c.estado_id in ('CERRADO', 'APROBADO') \n");
                query.Append("   AND  fp.es_fact_electronica = 'N'  \n");
                query.Append("   AND  (fp.es_ticket = 'N' AND fp.tipo_movimiento_set = 'C') ");
                query.Append("   AND (fp.imputa_iva = 'S' OR fp.imputa_ire = 'S')");
  
                string sql = query.ToString();

                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_compra";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Notas creditos proveedor
    public DataTable ObtenerDatosNCProveedor()
    {
        try
        {
            DataTable dtDatos = new DataTable();
            using (SessionService sesion = new SessionService())
            {
                //DateTime fechaDesde = DateTime.Parse(fechaInicial);
                //DateTime fechaHasta = DateTime.Parse(fechaFinal);

                DateTime fecha = DateTime.Parse(fechaFinal);

                int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime ultimoDia = new DateTime(fecha.Year, fecha.Month, diasEnMes);

                decimal paisId;
                if (sesion.SucursalActiva.ES_CASA_MATRIZ == Definiciones.SiNo.Si)
                    paisId = sesion.SucursalActiva.PAIS_ID;
                else
                    paisId = new SucursalesService(sesion.SucursalActiva.SUC_CASA_MATRIZ_ID, sesion).PaisId;

                StringBuilder query = new StringBuilder();

                query.Append(" SELECT 1 tipo_registro, \n");
                query.Append("      11 tp_identificacion_proveedor,  \n");
                query.Append("      p.ruc as numero_documento,  \n");
                query.Append("      p.razon_social as nombre_completo,  \n");
                query.Append("      110 as tipo_comprobante, \n");
                query.Append("      to_char(nc.fecha, 'dd-mm-yyyy') fecha, \n");
                query.Append("      nc.nro_timbrado,  \n");
                query.Append("      nc.nro_comprobante,  \n");
                query.Append("      nc.moneda_id, \n");
                query.Append("      DevuelveImporteGuaranies(nc.fecha, (select nvl(sum(det.total),0) from notas_credito_proveedores_det det where det.nota_credito_proveedor_id = nc.id and det.impuesto_id = 1), nc.moneda_id) as gravadas_10,  \n");
                query.Append("      DevuelveImporteGuaranies(nc.fecha, (select nvl(sum(det.total),0) from notas_credito_proveedores_det det where det.nota_credito_proveedor_id = nc.id and det.impuesto_id = 2), nc.moneda_id) as gravadas_5,  \n");
                query.Append("      DevuelveImporteGuaranies(nc.fecha, (select nvl(sum(det.total),0) from notas_credito_proveedores_det det where det.nota_credito_proveedor_id = nc.id and det.impuesto_id = 3), nc.moneda_id) as exentas,  \n");
                query.Append("      DevuelveImporteGuaranies(nc.fecha, nc.monto_total, nc.moneda_id) as total_factura,  \n");
                query.Append("      case nc.moneda_id when 1 then 'N' when 2 then 'S' end as operacion_moneda_extr,  \n");
                query.Append("      'S' as imputa_iva,  \n");
                query.Append("      'N' as imputa_ire,  \n");
                query.Append("      'N' as imputa_irp,  \n");
                query.Append("      'S' as imputa, \n");
                query.Append("       fp.nro_comprobante as nro_comprobante_asociado,  \n");
                query.Append("       fp.nro_timbrado as nro_timbrado_asociado \n");
                query.Append(" FROM  notas_credito_proveed_inf_comp nc,  \n");
                query.Append("       proveedores_info_completa p,   \n");                
                query.Append("       casos c, \n");
                query.Append("       facturas_proveedor fp, \n");
                query.Append("       notas_credito_proveedores_det ncd  \n");               
                query.Append(" WHERE nc.proveedor_id = p.id   \n");
                query.Append("   AND nc.caso_id = c.id   \n");
                query.Append("   AND c.estado_id in ('APROBADO','CERRADO')  \n");
                query.Append("   AND nc.fecha between to_date('" + fechaInicial + "', 'dd/mm/yyyy') and to_date('" + fechaFinal + "', 'dd/mm/yyyy')  \n");
                query.Append("   AND nc.id = ncd.nota_credito_proveedor_id  \n");
                query.Append("   AND ncd.factura_proveedor_id = fp.id  ");                
                string sql = query.ToString();
                
                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_nc_proveedor";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Egresos
    public DataTable ObtenerDatosEgresos()
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

                StringBuilder query = new StringBuilder();
                query.Append(" SELECT 4 tipo_registro, \n");
                query.Append("        coalesce(fp.ctb_tipo_comprobante_set_id, 109) as tipo_comprobante, \n");
                query.Append("        to_char(fp.fecha, 'dd/mm/yyyy') fecha, \n");
                query.Append("        fp.nro_comprobante,  \n");
                query.Append("        11 tp_identificacion_proveedor, \n");
                query.Append("        p.ruc as ruc_proveedor, \n");
                query.Append("        p.razon_social as nombre_proveedor, \n");
                query.Append("        fp.total_bruto as total_factura, \n");
                query.Append("        case fp.ctb_tipo_comprobante_set_id \n");
                query.Append("           when 207 then 'S' \n");
                query.Append("           else 'N'   \n");
                query.Append("        end imputa_iva, \n");
                query.Append("        coalesce(fp.imputa_ire, 'S') as imputa_ire \n");
                query.Append(" FROM   facturas_proveedor fp,  \n");
                query.Append("        proveedores_info_completa p,  \n");
                query.Append("        casos c \n");
                query.Append(" WHERE  fp.proveedor_id = p.id  \n");
                query.Append("   AND  fp.caso_id = c.id    \n");
                query.Append("   AND  fp.fecha between to_date('" + fechaInicial + "', 'dd/mm/yyyy') and to_date('" + fechaFinal + "', 'dd/mm/yyyy')  \n");
                query.Append("   AND  c.estado_id in ('CERRADO','APROBADO') \n");
                query.Append("   AND  fp.es_fact_electronica = 'N'  \n");
                query.Append("   AND  (fp.es_ticket = 'S' OR fp.tipo_movimiento_set = 'E')  ");

                string sql = query.ToString();

                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_egresos";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Ingresos
    public DataTable ObtenerDatosIngresos()
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

                StringBuilder query = new StringBuilder();
                query.Append(" SELECT 3 tipo_registro, \n");
                query.Append("      203 as tipo_comprobante, \n");
                query.Append("      cp.fecha,  \n");
                query.Append("      cp.ctacte_recibo_numero as nro_comprobante,  \n");
                query.Append("      decode(p.tipo_documento_identidad_id, 'CI', 12, 'DNI', 14, 'PAS', 13, 11) as tp_identificacion_pagador,  \n");
                query.Append("      p.numero_documento,  \n");
                query.Append("      p.nombre_completo,  \n");
                query.Append("      0 as monto_gravado,  \n");
                query.Append("      0 as monto_exento,  \n");
                query.Append("      (SELECT sum(monto) from ctacte_pagos_persona_det d where d.ctacte_pago_persona_id = cp.id) as monto_total,  \n");
                query.Append("      'N' as imputa_ire, \n");
                query.Append("      'N' as imputa_irp,  \n");
                query.Append("      doc.nro_comprobante as nro_comprobante_asociado,  \n");
                query.Append("      doc.numero_timbrado as timbrado_asociado  \n");
                query.Append(" FROM ctacte_pagos_persona cp, \n");
                query.Append("      personas_info_completa p,  \n");
                query.Append("      casos c,  \n");                
                query.Append("      (SELECT distinct(do.caso_id) caso_factura, fc.nro_comprobante, au.numero_timbrado, do.ctacte_pagos_persona_id  \n");
                query.Append("      FROM ctacte_pagos_pers_doc_inf_comp do, facturas_cliente fc, autonumeraciones au  \n");
                query.Append("      WHERE do.caso_id = fc.caso_id  \n");
                query.Append("      AND fc.autonumeracion_id = au.id  \n");
                query.Append("      AND fc.tipo_factura_id = 'CREDITO') doc  \n");
                query.Append(" WHERE cp.persona_id = p.id  \n");
                query.Append("  AND cp.caso_id = c.id  \n");
                query.Append("  AND cp.id = doc.ctacte_pagos_persona_id  \n");
                query.Append("  AND trunc(cp.fecha) between to_date('" + fechaInicial + "', 'dd/mm/yyyy') and to_date('" + fechaFinal + "', 'dd/mm/yyyy')  \n");
                query.Append("  AND c.estado_id = 'APROBADO'  \n");
                string sql = query.ToString();

                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_ingresos";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion


    #region Exportar Archivo
    public List<string> ExportarArchivo()
    {
        string tipoLibro = this.tipoLibro;

        //Hashtable cabecera = CabeceraArchivoHechauka(tipoLibro);
        DataTable dtDatosVentas = new DataTable();
        DataTable dtDatosNCProveedor = new DataTable();
        DataTable dtDatosCompras = new DataTable();
        DataTable dtDatosNCCliente = new DataTable();
        DataTable dtDatosIngresos = new DataTable();
        DataTable dtDatosEgresos = new DataTable();

        if (Definiciones.ReportesMarangatu.VENTA.Equals(tipoLibro))
        {
            dtDatosVentas = this.ObtenerDatosVenta();
            dtDatosNCProveedor = this.ObtenerDatosNCProveedor();
        }
        else if (Definiciones.ReportesMarangatu.COMPRA.Equals(tipoLibro))
        {
            dtDatosCompras = this.ObtenerDatosCompras();
            dtDatosNCCliente = this.ObtenerDatosNCCliente();
        }
        else if (Definiciones.ReportesMarangatu.INGRESO.Equals(tipoLibro))
        {
            dtDatosIngresos = this.ObtenerDatosIngresos();
        }
        else if (Definiciones.ReportesMarangatu.EGRESO.Equals(tipoLibro))
        {
            dtDatosEgresos = this.ObtenerDatosEgresos();
        }

        //if (dtDatosVentas.Rows.Count <= 0)
        //    throw new Exception("No hay datos");

        System.Web.UI.Page pagina = new System.Web.UI.Page();
        string strCurrentDir = "";
        decimal totalCabecera = 0;
        decimal montoVenta = 0;
        string strline = "";
        string header;
        string nombreArchivo;
        StreamWriter outputFile;
		string l_no_imputa;
        string l_imputa_iva;
        string l_imputa_ire;

        try
        {
            CrearDirectiorio(this.nombreArchivo);
            strCurrentDir = pagina.Server.MapPath(pathServidor + pathTemporal);
            outputFile = new StreamWriter(strCurrentDir + this.nombreArchivo);

            this.archivos.Add(strCurrentDir + this.nombreArchivo);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + strCurrentDir);
        }

		#region escribeArchivoVentas
        // Datos de la Venta
        foreach (DataRow dbRow in dtDatosVentas.Rows)
        {
            strline += dbRow["tipo_registro"].ToString() + '\t';
            strline += dbRow["tp_identificacion_comprador"].ToString() + '\t';
            strline += dbRow["numero_documento"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nombre_completo"]) + '\t';
            strline += dbRow["tipo_comprobante"].ToString() + '\t';
            strline += dbRow["fecha"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["numero_timbrado"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_comprobante"]) + '\t';
            strline += dbRow["gravadas_10"].ToString() + '\t';
            strline += dbRow["gravadas_5"].ToString() + '\t';
            strline += dbRow["exentas"].ToString() + '\t';
            strline += dbRow["total_factura"].ToString() + '\t';
            strline += dbRow["cond_venta"].ToString() + '\t';
            strline += dbRow["operacion_moneda_extr"].ToString() + '\t';
            strline += dbRow["imputa_iva"].ToString() + '\t';
            strline += dbRow["imputa_ire"].ToString() + '\t';
            strline += dbRow["imputa_irp"].ToString() + '\t';

            outputFile.WriteLine(strline);
            strline = "";
        }

        // Datos de NC Proveedor
        foreach (DataRow dbRow in dtDatosNCProveedor.Rows)
        {
            if ((decimal.Parse(dbRow["exentas"].ToString())) > 0)
            {
                l_imputa_iva = "N";
                l_imputa_ire = "N";
            }
            else
            {
                l_imputa_iva = "S";
                l_imputa_ire = "N";
            }
            strline += dbRow["tipo_registro"].ToString() + '\t';
            strline += dbRow["tp_identificacion_proveedor"].ToString() + '\t';
            strline += dbRow["numero_documento"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nombre_completo"]) + '\t';
            strline += dbRow["tipo_comprobante"].ToString() + '\t';
            strline += dbRow["fecha"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_timbrado"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_comprobante"]) + '\t';
            strline += dbRow["gravadas_10"].ToString() + '\t';
            strline += dbRow["gravadas_5"].ToString() + '\t';
            strline += dbRow["exentas"].ToString() + '\t';
            strline += dbRow["total_factura"].ToString() + '\t';
			strline += "" + '\t';       // condicion venta
            strline += dbRow["operacion_moneda_extr"].ToString() + '\t';
            strline += l_imputa_iva + '\t';
            strline += l_imputa_ire + '\t';
            strline += dbRow["imputa_irp"].ToString() + '\t';            
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_comprobante_asociado"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_timbrado_asociado"]) + '\t';

            outputFile.WriteLine(strline);
            strline = "";
        }
		#endregion

		#region escribeArchivoCompras
		// Compras
        foreach (DataRow dtRow in dtDatosCompras.Rows)
        {
            l_no_imputa = "N";
            if (dtRow["imputa_iva"].ToString() == "N" && dtRow["imputa_ire"].ToString() == "N")
                l_no_imputa = "S";
            
            strline += dtRow["tipo_registro"].ToString() + '\t';
            strline += dtRow["tp_identificacion_proveedor"].ToString() + '\t';
            strline += dtRow["ruc"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["razon_social"]) + '\t';
            strline += dtRow["tipo_comprobante"].ToString() + '\t';
            strline += dtRow["fecha"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nro_timbrado"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nro_comprobante"]) + '\t';
            strline += dtRow["gravadas_10"].ToString() + '\t';
            strline += dtRow["gravadas_5"].ToString() + '\t';
            strline += dtRow["exentas"].ToString() + '\t';
            strline += dtRow["total_factura"].ToString() + '\t';
            strline += dtRow["codigo_condicion_compra"].ToString() + '\t';
            strline += dtRow["operacion_moneda_extr"].ToString() + '\t';
            strline += dtRow["imputa_iva"].ToString() + '\t';
            strline += dtRow["imputa_ire"].ToString() + '\t';
            strline += "N" + '\t';      // imputa irp/rsp
            strline += l_no_imputa + '\t';
            strline += "" + '\t';       // nro venta comprobante asociado
            strline += "" + '\t';       // timbrado comprobante asociado

            outputFile.WriteLine(strline);
            strline = "";
        }

        // Datos de NC Cliente
        foreach (DataRow dbRow in dtDatosNCCliente.Rows)
        {
            l_no_imputa = "N";
            if ((decimal.Parse(dbRow["exentas"].ToString())) > 0)
            {
                l_imputa_iva = "N";
                l_imputa_ire = "S";
            }
            else
            {
                l_imputa_iva = "S";
                l_imputa_ire = "N";
            }
            strline += dbRow["tipo_registro"].ToString() + '\t';
            strline += dbRow["tp_identificacion_comprador"].ToString() + '\t';
            strline += dbRow["numero_documento"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nombre_completo"]) + '\t';
            strline += dbRow["tipo_comprobante"].ToString() + '\t';
            strline += dbRow["fecha"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["numero_timbrado"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["nro_comprobante"]) + '\t';
            strline += dbRow["gravadas_10"].ToString() + '\t';
            strline += dbRow["gravadas_5"].ToString() + '\t';
            strline += dbRow["exentas"].ToString() + '\t';
            strline += dbRow["total_factura"].ToString() + '\t';
            strline += "" + '\t';       // condicion venta
            strline += dbRow["operacion_moneda_extr"].ToString() + '\t';
            strline += l_imputa_iva + '\t';
            strline += l_imputa_ire + '\t';
            strline += dbRow["imputa_irp"].ToString() + '\t';
			strline += l_no_imputa + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["comprobante_venta"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dbRow["timbrado_venta"]) + '\t';

            outputFile.WriteLine(strline);
            strline = "";
        }
		#endregion

		#region escribeArchivoEgresos
        // Datos de Egresos
        foreach (DataRow dtRow in dtDatosEgresos.Rows)
        {
            l_no_imputa = "N";
            if (dtRow["imputa_iva"].ToString() == "N" && dtRow["imputa_ire"].ToString() == "N")
                l_no_imputa = "S";

            string l_banco = "";
            if (dtRow["tipo_comprobante"].ToString() == "207" || dtRow["tipo_comprobante"].ToString() == "211")
                l_banco = StringUtil.QuitarCaracteresNoImprimibles(dtRow["nombre_proveedor"]);

            strline += dtRow["tipo_registro"].ToString() + '\t';
            strline += dtRow["tipo_comprobante"].ToString() + '\t';
            strline += dtRow["fecha"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nro_comprobante"]) + '\t';
            strline += dtRow["tp_identificacion_proveedor"].ToString() + '\t';
            strline += dtRow["ruc_proveedor"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nombre_proveedor"]) + '\t';
            strline += dtRow["total_factura"].ToString() + '\t';
            strline += dtRow["imputa_iva"].ToString() + '\t';
            strline += dtRow["imputa_ire"].ToString() + '\t';
            strline += "N" + '\t';      // imputa irp/rsp
            strline += l_no_imputa + '\t';
            strline += "" + '\t';           // nro cuenta o tarjeta
            strline += l_banco + '\t';       // banco financiera cooperativa
            strline += "" + '\t';           // identificacion del empleador
            strline += "" + '\t';           // tipo documento
            strline += "" + '\t';           // nro comprobante asociado
            strline += "" + '\t';           // nro timbrado asociado

            outputFile.WriteLine(strline);
            strline = "";
        }
		#endregion

        #region escribeArchivoIngresos
        // Datos de Ingresos
        foreach (DataRow dtRow in dtDatosIngresos.Rows)
        {
            strline += dtRow["tipo_registro"].ToString() + '\t';
            strline += dtRow["tipo_comprobante"].ToString() + '\t';
            strline += dtRow["fecha"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nro_comprobante"]) + '\t';
            strline += dtRow["tp_identificacion_pagador"].ToString() + '\t';
            strline += dtRow["numero_documento"].ToString() + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nombre_completo"]) + '\t';
            strline += dtRow["monto_gravado"].ToString() + '\t';
            strline += dtRow["monto_exento"].ToString() + '\t';
            strline += dtRow["monto_total"].ToString() + '\t';
            strline += dtRow["imputa_ire"].ToString() + '\t';
            strline += dtRow["imputa_irp"].ToString() + '\t';
            strline += "" + '\t';           // tipo documento
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["nro_comprobante_asociado"]) + '\t';
            strline += StringUtil.QuitarCaracteresNoImprimibles(dtRow["timbrado_asociado"]) + '\t';

            outputFile.WriteLine(strline);
            strline = "";
        }
        #endregion

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

    #region GetDatosSucursales
    public static void GetDatosSucursal(ref string nomSucursal, ref string ruc)
    {
        using (SessionService sesion = new SessionService())
        {
            nomSucursal = SucursalesService.GetNombreSucursal(sesion.SucursalActiva_Id);
            ruc = SucursalesService.GetRUC(sesion.SucursalActiva_Id);
        }
    }
    #endregion GetDatosSucursales

    #region GetUltVersionArchivo
    public static decimal GetUltVersionArchivo(string periodo, string tipo)
    {
        using (SessionService sesion = new SessionService())
        {
            decimal version = 0;
            string where;
            where = Periodo_NombreCol + " = '" + periodo + "' ";
            where += " and " + TipoRegistro_NombreCol + " = '" + tipo + "' ";
            string orden = Version_NombreCol;

            DataTable dt = sesion.Db.CTB_ARCHIVOS_MARANGATUCollection.GetAsDataTable(where, orden);

            if (dt.Rows.Count > 0)
                version = decimal.Parse(dt.Rows[dt.Rows.Count - 1][Version_NombreCol].ToString());

            return version;
        }
    }
    #endregion GetUltVersionArchivo

    #region Guardar
    public static void Guardar(Hashtable campos)
    {
        using (SessionService sesion = new SessionService())
        {
            CTB_ARCHIVOS_MARANGATURow row;

            row = new CTB_ARCHIVOS_MARANGATURow();
            row.ID = sesion.Db.GetSiguienteSecuencia("ctb_archi_marangatu_sqc");
            row.FECHA_CREACION = DateTime.Now;
            row.USUARIO_ID = sesion.Usuario_Id;

            row.PERIODO = (string)campos[MarangatuService.Periodo_NombreCol];
            row.TIPO_REGISTRO = (string)campos[MarangatuService.TipoRegistro_NombreCol];
            row.VERSION = (decimal)campos[MarangatuService.Version_NombreCol];

            sesion.Db.CTB_ARCHIVOS_MARANGATUCollection.Insert(row);
        }
    }
    #endregion Guardar

}
