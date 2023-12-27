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
#endregion Using

/// <summary>
/// Summary description for Tesaka
/// </summary>
public class Tesaka
{
    #region Variables Privadas
    private string fechaInicial = string.Empty;
    private string fechaFinal = string.Empty;
    private bool porFechaFactura = false;

    string archivo;

    protected abstract class Columnas
    {
        public abstract class IDs
        {
            public const string RETENCION_ID = "RETENCION_ID";
            public const string FACTURA_PROVEEDOR_ID = "FACTURA_PROVEEDOR_ID";
            public const string FACTURA_PROVEEDOR_DETALLE_ID = "FACTURA_PROVEEDOR_DETALLE_ID";
        }

        public abstract class Atributos
        {
            public const string FECHA_CREACION = "FECHA_CREACION";
            public const string FECHA_HORA_CREACION = "FECHA_HORA_CREACION";
        }

        public abstract class Informado
        {
            public const string SITUACION = "SITUACION";
            public const string RUC = "RUC";
            public const string DV = "DV";
            public const string TIPO_IDENTIFICACION = "TIPO_IDENTIFICACION";
            public const string IDENTIFICACION = "IDENTIFICACION";
            public const string DOMICILIO = "DOMICILIO";
            public const string DIRECCION = "DIRECCION";
            public const string TELEFONO = "TELEFONO";
            public const string PAIS = "PAIS";
            public const string NOMBRE = "NOMBRE";
            public const string CORREO_ELECTRONICO = "CORREO_ELECTRONICO";
        }

        public abstract class Transaccion
        {
            public const string CONDICION_COMPRA = "CONDICION_COMPRA";
            public const string TIPO_COMPROBANTE = "TIPO_COMPROBANTE";
            public const string NUMERO_COMPROBANTE_VENTA = "NUMERO_COMPROBANTE_VENTA";
            public const string FECHA = "FECHA";
            public const string CUOTAS = "CUOTAS";
            public const string NUMERO_TIMBRADO = "NUMERO_TIMBRADO";
        }

        public abstract class Detalle
        {
            public const string CANTIDAD = "CANTIDAD";
            public const string TASA_APLICA = "TASA_APLICA";
            public const string PRECIO_UNITARIO = "PRECIO_UNITARIO";
            public const string DESCRIPCION = "DESCRIPCION";
        }

        public abstract class Retencion
        {
            public const string FECHA_RETENCION = "FECHA_RETENCION";
            public const string MONEDA_RETENCION = "MONEDA_RETENCION";
            public const string TIPO_CAMBIO = "TIPO_CAMBIO";
            public const string RETENCION_RENTA = "RETENCION_RENTA";
            public const string CONCEPTO_RENTA = "CONCEPTO_RENTA";
            public const string RETENCION_IVA = "RETENCION_IVA";
            public const string CONCEPTO_IVA = "CONCEPTO_IVA";
            public const string RENTA_CABEZAS_BASE = "RENTA_CABEZAS_BASE";
            public const string RENTA_CABEZAS_CANTIDAD = "RENTA_CABEZAS_CANTIDAD";
            public const string RENTA_TONELADAS_BASE = "RENTA_TONELADAS_BASE";
            public const string RENTA_TONELADAS_CANTIDAD = "RENTA_TONELADAS_CANTIDAD";
            public const string IVA_PORCENTAJE_5 = "IVA_PORCENTAJE_5";
            public const string IVA_PORCENTAJE_10 = "IVA_PORCENTAJE_10";
        }
    }

    #endregion

    #region Constantes
    private const string pathServidor = @"~/" + "/Resources/Tesaka/";
    private const string pathTemporal = "tmp\\";
    #endregion Constantes

    #region Constructor
    public Tesaka(string fechaInicial, string fechaFinal, bool porFechaFactura)
    {
        this.fechaInicial = fechaInicial;
        this.fechaFinal = fechaFinal;
        this.porFechaFactura = porFechaFactura;
    }
    #endregion Constructor

    #region Comprobantes Retencion Tesaka
    public DataTable ObtenerDatosRetencionTesaka()
    {
        try
        {
            DataTable dtDatos = new DataTable();

            using (SessionService sesion = new SessionService())
            {
                StringBuilder queryRetenciones = new StringBuilder();
                queryRetenciones.Append("select \n");
                queryRetenciones.Append("       cre.id retencion_id, \n");
                queryRetenciones.Append("       cred.caso_id caso_factura_proveedor, \n");
                queryRetenciones.Append("       fp.id factura_proveedor_id, \n");
                queryRetenciones.Append("       fpd.id factura_proveedor_detalle_id, \n");
                queryRetenciones.Append("      /*ATRIBUTOS*/ \n");
                queryRetenciones.Append("      to_char(sysdate,'YYYY-MM-DD') fecha_creacion, \n");
                queryRetenciones.Append("      to_char(sysdate,'YYYY-MM-DD HH:mm:SS') fecha_hora_creacion, \n");
                queryRetenciones.Append("       \n");
                queryRetenciones.Append("      /*INFORMADO*/ \n");
                queryRetenciones.Append("      'contribuyente' situacion, \n");
                queryRetenciones.Append("      p.ruc ruc, \n");
                queryRetenciones.Append("      pa_calcular_dv_11_a(p.ruc, 11)  dv, \n");
                queryRetenciones.Append("      '' tipo_identificacion, \n");
                queryRetenciones.Append("      '' identificacion, \n");
                queryRetenciones.Append("      '' domicilio, \n");
                queryRetenciones.Append("      p.calle1 || ' ' || p.barrio1_nombre || ' ' || p.ciudad1_nombre direccion, \n");
                queryRetenciones.Append("      '' telefono, \n");
                queryRetenciones.Append("      '' pais, \n");
                queryRetenciones.Append("      p.razon_social nombre, \n");
                queryRetenciones.Append("      '' correo_electronico, \n");
                queryRetenciones.Append("       \n");
                queryRetenciones.Append("      /*TRANSACCION*/ \n");
                queryRetenciones.Append("      ccp.tipo_condicion_pago condicion_compra, \n");
                queryRetenciones.Append("      case when fp.tipo_factura_proveedor_id in (1,2,3,4) \n");
                queryRetenciones.Append("      then 1 /*Factura*/ \n");
                queryRetenciones.Append("      when fp.tipo_factura_proveedor_id = 5 \n");
                queryRetenciones.Append("      then 12 /*Autofactura*/ \n");
                queryRetenciones.Append("      end tipo_comprobante, \n");
                queryRetenciones.Append("      fp.nro_comprobante  numero_comprobante_venta, \n");
                queryRetenciones.Append("      to_char(fp.fecha_factura,'YYYY-MM-DD')  fecha, \n");
                queryRetenciones.Append("      ccp.cantidad_pagos cuotas, \n");
                queryRetenciones.Append("      fp.nro_timbrado numero_timbrado, \n");
                queryRetenciones.Append("       \n");
                queryRetenciones.Append("      /*DETALLE*/ \n");
                queryRetenciones.Append("      fpd.cantidad_unitaria_total_dest cantidad, \n");
                queryRetenciones.Append("      round(fpd.porcentaje_impuesto,0) tasa_aplica, \n");
                queryRetenciones.Append("      round(fpd.precio_bruto_unitario_dest,2) precio_unitario, \n");
                queryRetenciones.Append("      fpd.articulo_descripcion_completa descripcion, \n");
                queryRetenciones.Append("       \n");
                queryRetenciones.Append("      /*RETENCION*/ \n");
                queryRetenciones.Append("      to_char(cre.fecha,'YYYY-MM-DD')  fecha_retencion, \n");
                queryRetenciones.Append("      m.iso_4217 moneda_retencion, \n");
                queryRetenciones.Append("      round(cre.cotizacion_moneda_pais) tipo_cambio, \n");
                queryRetenciones.Append("      'false' retencion_renta, \n");
                queryRetenciones.Append("      '' concepto_renta, \n");
                queryRetenciones.Append("      'true' retencion_iva, \n");
                queryRetenciones.Append("      'IVA.1' concepto_iva, \n");
                queryRetenciones.Append("      '0' renta_cabezas_base, \n");
                queryRetenciones.Append("      '0' renta_cabezas_cantidad, \n");
                queryRetenciones.Append("      '0' renta_toneladas_base, \n");
                queryRetenciones.Append("      '0' renta_toneladas_cantidad, \n");
                queryRetenciones.Append("      '30' iva_porcentaje_5, \n");
                queryRetenciones.Append("      '30' iva_porcentaje_10 \n");
                queryRetenciones.Append("       \n");
                queryRetenciones.Append("  from ctacte_retenc_emit_info_comp  cre, \n");
                queryRetenciones.Append("       ctacte_retenc_emit_det_info_c cred, \n");
                queryRetenciones.Append("       proveedores_info_completa     p, \n");
                queryRetenciones.Append("       facturas_proveedor            fp, \n");
                queryRetenciones.Append("       ctacte_condiciones_pago       ccp, \n");
                queryRetenciones.Append("       facturas_proveedor_det_info_c fpd, \n");
                queryRetenciones.Append("       monedas                       m \n");
                queryRetenciones.Append("        \n");
                queryRetenciones.Append(" where cred.ctacte_retencion_emitida_id = cre.id \n");
                queryRetenciones.Append("   and cre.proveedor_id = p.id \n");
                queryRetenciones.Append("   and cre.estado = 'A' \n");
                queryRetenciones.Append("   and fpd.facturas_proveedor_id = fp.id \n");
                queryRetenciones.Append("   and fp.ctacte_condicion_pago_id = ccp.id \n");
                queryRetenciones.Append("   and cred.caso_id = fp.caso_id \n");
                queryRetenciones.Append("   and cre.moneda_id = m.id and cre.declarado_tesaka = 'N' \n");

                if (this.porFechaFactura)
                {
                    queryRetenciones.Append("   and trunc(fp.fecha_factura) between to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') and \n");
                    queryRetenciones.Append("       to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy') ");
                }
                else
                {
                    queryRetenciones.Append("   and trunc(cre.fecha) between to_date('" + DateTime.Parse(fechaInicial).ToShortDateString() + "', 'dd/mm/yyyy') and \n");
                    queryRetenciones.Append("       to_date('" + DateTime.Parse(fechaFinal).ToShortDateString() + "', 'dd/mm/yyyy') ");
                }

                queryRetenciones.Append("       order by cred.id asc");

                string sql = queryRetenciones.ToString();
                dtDatos = sesion.db.EjecutarQuery(sql);
                dtDatos.TableName = "reporte_retencion_tesaka";
            }
            return dtDatos;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Error en ObtenerDatos: " + exp.Message);
        }
    }
    #endregion

    #region Crear Archivo Tesaka
    public string ExportarArchivoTesaka(ref List<decimal> retenciones)
    {
        try
        {
            DataTable dtDatos;

            dtDatos = this.ObtenerDatosRetencionTesaka();

            if (dtDatos.Rows.Count <= 0)
                throw new Exception("No hay datos que exportar");

            DataView viewDatos = new DataView(dtDatos);

            #region Inicializar archivo de salida
            System.Web.UI.Page pagina = new System.Web.UI.Page();
            string strCurrentDir = "";
            string nombreArchivo;
            StreamWriter outputFile;

            try
            {
                nombreArchivo = "tesaka_" + DateTime.Now.Ticks.ToString() + ".json";
                CrearDirectiorio(nombreArchivo);
                strCurrentDir = pagina.Server.MapPath(pathServidor + pathTemporal);
                outputFile = new StreamWriter(strCurrentDir + nombreArchivo);

                archivo = strCurrentDir + nombreArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + strCurrentDir);
            }

            #endregion Inicializar archivo de salida

            #region Operaciones en el archivo
            #region Recorrer retenciones
            DataTable distinctRetenciones = viewDatos.ToTable(true, Columnas.IDs.RETENCION_ID);
            decimal ultimaRetencion = 0;
            decimal ultimoDetalle = 0;

            outputFile.WriteLine("[ ");
            foreach (DataRow drRetenciones in distinctRetenciones.Rows)
            {
                DataTable dtFacturas = dtDatos.Select(Columnas.IDs.RETENCION_ID + " = " + drRetenciones[Columnas.IDs.RETENCION_ID].ToString()).CopyToDataTable();
                DataView viewFacturas = new DataView(dtFacturas);
                DataTable distinctFacturas = viewFacturas.ToTable(true, Columnas.IDs.FACTURA_PROVEEDOR_ID);

                outputFile.WriteLine("{ ");

                //atributos
                outputFile.WriteLine("\"atributos\":{ ");
                outputFile.WriteLine("\"fechaCreacion\":\"" + dtFacturas.Rows[0][Columnas.Atributos.FECHA_CREACION] + "\",");
                outputFile.WriteLine("\"fechaHoraCreacion\":\"" + dtFacturas.Rows[0][Columnas.Atributos.FECHA_HORA_CREACION] + "\"");
                outputFile.WriteLine("}, ");

                #region Recorrrer facturas
                foreach (DataRow drFacturas in distinctFacturas.Rows)
                {
                    DataTable dtDetallesFacturas = dtFacturas.Select(Columnas.IDs.FACTURA_PROVEEDOR_ID + " = " + drFacturas[Columnas.IDs.FACTURA_PROVEEDOR_ID].ToString()).CopyToDataTable();
                    DataView viewDetallesFacturas = new DataView(dtFacturas);
                    DataTable distinctDetallesFacturas = viewDetallesFacturas.ToTable(true, Columnas.IDs.FACTURA_PROVEEDOR_DETALLE_ID);
                    ultimoDetalle = 0;

                    #region Porcentaje en base a lo pagado
                    // porcentaje pago
                    decimal porcentajePago = 1;
                    DataTable dtCasoFactura = dtDatos.Select(Columnas.IDs.FACTURA_PROVEEDOR_ID + " = " + drFacturas[Columnas.IDs.FACTURA_PROVEEDOR_ID].ToString()).CopyToDataTable();

                    StringBuilder queryPorcentaje = new StringBuilder();
                    queryPorcentaje.Append("select round(opd.monto_origen / cp.credito,14) porcentaje \n");
                    queryPorcentaje.Append("  from ordenes_pago_det     opd, \n");
                    queryPorcentaje.Append("       ctacte_proveedores   cp, \n");
                    queryPorcentaje.Append("       ordenes_pago_valores opv \n");
                    queryPorcentaje.Append(" where cp.id = opd.ctacte_proveedor_id \n");
                    queryPorcentaje.Append("   and opd.orden_pago_id = opv.orden_pago_id \n");
                    queryPorcentaje.Append("   and opd.caso_referido_id = " + dtCasoFactura.Rows[0]["caso_factura_proveedor"] + " \n");
                    queryPorcentaje.Append("   and opv.retencion_emitida_id = " + drRetenciones["retencion_id"] + " \n");
                    queryPorcentaje.Append(" order by opd.id desc");

                    string sql = queryPorcentaje.ToString();
                    DataTable dtPorcentaje = (new SessionService()).db.EjecutarQuery(sql);

                    if (dtPorcentaje.Rows.Count > 0)
                        porcentajePago = (decimal)dtPorcentaje.Rows[0]["porcentaje"];

                    #endregion Porcentaje en base a lo pagado

                    //informado
                    outputFile.WriteLine("\"informado\":{ ");
                    outputFile.WriteLine("\"situacion\":\"" + dtDetallesFacturas.Rows[0][Columnas.Informado.SITUACION] + "\",");
                    outputFile.WriteLine("\"ruc\":\"" + dtDetallesFacturas.Rows[0][Columnas.Informado.RUC] + "\",");
                    outputFile.WriteLine("\"dv\":\"" + dtDetallesFacturas.Rows[0][Columnas.Informado.DV] + "\",");
                    outputFile.WriteLine("\"tipoIdentificacion\":\"" + dtDetallesFacturas.Rows[0][Columnas.Informado.TIPO_IDENTIFICACION] + "\",");
                    outputFile.WriteLine("\"identificacion\":\"" + dtDetallesFacturas.Rows[0][Columnas.Informado.IDENTIFICACION] + "\",");
                    outputFile.WriteLine("\"domicilio\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Informado.DOMICILIO]) + "\",");
                    outputFile.WriteLine("\"direccion\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Informado.DIRECCION]) + "\",");
                    outputFile.WriteLine("\"telefono\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Informado.TELEFONO]) + "\",");
                    outputFile.WriteLine("\"pais\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Informado.PAIS]) + "\",");
                    outputFile.WriteLine("\"nombre\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Informado.NOMBRE]) + "\",");
                    outputFile.WriteLine("\"correoElectronico\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Informado.CORREO_ELECTRONICO]) + "\"");
                    outputFile.WriteLine("}, ");

                    //transacción
                    outputFile.WriteLine("\"transaccion\":{ ");
                    outputFile.WriteLine("\"condicionCompra\":\"" + dtDetallesFacturas.Rows[0][Columnas.Transaccion.CONDICION_COMPRA] + "\",");
                    outputFile.WriteLine("\"tipoComprobante\":" + dtDetallesFacturas.Rows[0][Columnas.Transaccion.TIPO_COMPROBANTE] + ",");
                    outputFile.WriteLine("\"numeroComprobanteVenta\":\"" + StringUtil.QuitarCaracteresNoImprimibles(dtDetallesFacturas.Rows[0][Columnas.Transaccion.NUMERO_COMPROBANTE_VENTA]) + "\",");
                    outputFile.WriteLine("\"fecha\":\"" + dtDetallesFacturas.Rows[0][Columnas.Transaccion.FECHA] + "\",");
                    outputFile.WriteLine("\"cuotas\":" + dtDetallesFacturas.Rows[0][Columnas.Transaccion.CUOTAS] + ",");
                    outputFile.WriteLine("\"numeroTimbrado\":\"" + dtDetallesFacturas.Rows[0][Columnas.Transaccion.NUMERO_TIMBRADO] + "\"");
                    outputFile.WriteLine("}, ");

                    #region Recorrer detalles
                    outputFile.WriteLine("\"detalle\":[ ");
                    foreach (DataRow drDetallesFacturas in dtDetallesFacturas.Rows)
                    {
                        //detalle
                        outputFile.WriteLine("{ ");
                        outputFile.WriteLine("\"cantidad\":" + drDetallesFacturas[Columnas.Detalle.CANTIDAD] + ",");
                        outputFile.WriteLine("\"tasaAplica\":\"" + drDetallesFacturas[Columnas.Detalle.TASA_APLICA] + "\",");
                        outputFile.WriteLine("\"precioUnitario\":" + (Math.Round((decimal.Parse(drDetallesFacturas[Columnas.Detalle.PRECIO_UNITARIO].ToString()) * porcentajePago), 2).ToString().Replace(",", ".") + ","));
                        outputFile.WriteLine("\"descripcion\":\"" + StringUtil.QuitarCaracteresNoImprimibles(drDetallesFacturas[Columnas.Detalle.DESCRIPCION]) + "\"");

                        if (ultimoDetalle == (dtDetallesFacturas.Rows.Count - 1))
                            outputFile.WriteLine("} ");
                        else
                            outputFile.WriteLine("}, ");

                        ultimoDetalle++;
                    }
                    outputFile.WriteLine("], ");
                    #endregion recorrer detalles
                }

                //retención
                outputFile.WriteLine("\"retencion\":{ ");

                outputFile.WriteLine("\"fecha\":\"" + dtFacturas.Rows[0][Columnas.Retencion.FECHA_RETENCION] + "\",");
                outputFile.WriteLine("\"moneda\":\"" + dtFacturas.Rows[0][Columnas.Retencion.MONEDA_RETENCION] + "\",");
                if (!dtFacturas.Rows[0][Columnas.Retencion.MONEDA_RETENCION].ToString().Equals("PYG"))
                    outputFile.WriteLine("\"tipoCambio\":" + dtFacturas.Rows[0][Columnas.Retencion.TIPO_CAMBIO] + ",");
                outputFile.WriteLine("\"retencionRenta\":" + dtFacturas.Rows[0][Columnas.Retencion.RETENCION_RENTA] + ",");
                outputFile.WriteLine("\"conceptoRenta\":\"" + dtFacturas.Rows[0][Columnas.Retencion.CONCEPTO_RENTA] + "\",");
                outputFile.WriteLine("\"retencionIva\":" + dtFacturas.Rows[0][Columnas.Retencion.RETENCION_IVA] + ",");
                outputFile.WriteLine("\"conceptoIva\":\"" + dtFacturas.Rows[0][Columnas.Retencion.CONCEPTO_IVA] + "\",");
                outputFile.WriteLine("\"rentaPorcentaje\":" + 0 + ",");
                outputFile.WriteLine("\"rentaCabezasBase\":" + dtFacturas.Rows[0][Columnas.Retencion.RENTA_CABEZAS_BASE] + ",");
                outputFile.WriteLine("\"rentaCabezasCantidad\":" + dtFacturas.Rows[0][Columnas.Retencion.RENTA_CABEZAS_CANTIDAD] + ",");
                outputFile.WriteLine("\"rentaToneladasBase\":" + dtFacturas.Rows[0][Columnas.Retencion.RENTA_TONELADAS_BASE] + ",");
                outputFile.WriteLine("\"rentaToneladasCantidad\":" + dtFacturas.Rows[0][Columnas.Retencion.RENTA_TONELADAS_CANTIDAD] + ",");
                outputFile.WriteLine("\"ivaPorcentaje5\":" + dtFacturas.Rows[0][Columnas.Retencion.IVA_PORCENTAJE_5] + ",");
                outputFile.WriteLine("\"ivaPorcentaje10\":" + dtFacturas.Rows[0][Columnas.Retencion.IVA_PORCENTAJE_10] + "");

                outputFile.WriteLine("} ");

                if (ultimaRetencion == (distinctRetenciones.Rows.Count - 1))
                    outputFile.WriteLine("} ");
                else
                    outputFile.WriteLine("}, ");

                retenciones.Add((decimal)dtFacturas.Rows[0]["RETENCION_ID"]);
                ultimaRetencion++;

                #endregion Recorrer facturas
            }

            outputFile.WriteLine("] ");
            #endregion Recorrer retenciones

            #endregion Operaciones en el archivo

            outputFile.Close();
            pagina.Dispose();

            return archivo;
        }
        catch (System.Exception exp)
        {
            throw new Exception("Adevertencia: " + exp.Message);
        }
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
