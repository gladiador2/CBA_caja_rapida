using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PagoContratistasDetallesServices
    {
        #region Obtener Datatble
        
        public static DataTable GetPagoContratistasDetallesDatatable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPagoContratistasDetallesDatatable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetPagoContratistasDetallesDatatable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PAGO_CONTRATISTAS_DETALLESCollection.GetAsDataTable(clausulas, orden);
        }
        
        #endregion Obtener Datatable
        
        #region Guardar

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            PAGO_CONTRATISTAS_DETALLESRow pagoContratistasDetalles = new PAGO_CONTRATISTAS_DETALLESRow();
            String valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                pagoContratistasDetalles.ID = sesion.Db.GetSiguienteSecuencia("pago_contratistas_det_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                if (!campos.Contains(Id_NombreCol))
                    throw new Exception("Falta el Id");
                pagoContratistasDetalles = sesion.Db.PAGO_CONTRATISTAS_DETALLESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                valorAnterior = pagoContratistasDetalles.ToString();
            }
            if (campos.Contains(PagoContratistasDetallesServices.CertificadoNro_NombreCol))
                pagoContratistasDetalles.CERTIFICADO_NRO= decimal.Parse(campos[PagoContratistasDetallesServices.CertificadoNro_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.Certificado_NombreCol))
                pagoContratistasDetalles.CERTIFICADO = campos[PagoContratistasDetallesServices.Certificado_NombreCol].ToString();

            if (campos.Contains(PagoContratistasDetallesServices.FechaDesde_NombreCol))
                pagoContratistasDetalles.FECHA_DESDE = DateTime.Parse(campos[PagoContratistasDetallesServices.FechaDesde_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.FechaHasta_NombreCol))
                pagoContratistasDetalles.FECHA_HASTA = DateTime.Parse(campos[PagoContratistasDetallesServices.FechaHasta_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.CertificadoMonto_NombreCol))
                pagoContratistasDetalles.CERTIFICADO_MONTO = decimal.Parse(campos[PagoContratistasDetallesServices.CertificadoMonto_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.FondoFijo_NombreCol))
                pagoContratistasDetalles.FONDO_FIJO = decimal.Parse(campos[PagoContratistasDetallesServices.FondoFijo_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.FondoFijoPagado_NombreCol))
                pagoContratistasDetalles.FONDO_FIJO_PAGADO = decimal.Parse(campos[PagoContratistasDetallesServices.FondoFijoPagado_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.FacturasProveedor_NombreCol))
                pagoContratistasDetalles.FACTURAS_PROVEEDOR = decimal.Parse(campos[PagoContratistasDetallesServices.FacturasProveedor_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.FacturasProveedorPagado_NombreCol))
                pagoContratistasDetalles.FACTURAS_PROVEEDOR_PAGADO = decimal.Parse(campos[PagoContratistasDetallesServices.FacturasProveedorPagado_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.Adelantos_NombreCol))
                pagoContratistasDetalles.ADELANTOS = decimal.Parse(campos[PagoContratistasDetallesServices.Adelantos_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.AdelantosPagados_NombreCol))
                pagoContratistasDetalles.ADELANTOS_PAGADOS = decimal.Parse(campos[PagoContratistasDetallesServices.AdelantosPagados_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.AdelantoInicial_NombreCol))
                pagoContratistasDetalles.ADELANTO_INICIAL = decimal.Parse(campos[PagoContratistasDetallesServices.AdelantoInicial_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.FondoReparo_NombreCol))
                pagoContratistasDetalles.FONDO_REPARO = decimal.Parse(campos[PagoContratistasDetallesServices.FondoReparo_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.Total_NombreCol))
                pagoContratistasDetalles.TOTAL = decimal.Parse(campos[PagoContratistasDetallesServices.Total_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.TotalIva_NombreCol))
                pagoContratistasDetalles.TOTAL_IVA = decimal.Parse(campos[PagoContratistasDetallesServices.TotalIva_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.Retencion_NombreCol))
                pagoContratistasDetalles.RETENCION = decimal.Parse(campos[PagoContratistasDetallesServices.Retencion_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.TotalPagar_NombreCol))
                pagoContratistasDetalles.TOTAL_PAGAR = decimal.Parse(campos[PagoContratistasDetallesServices.TotalPagar_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.PagoContratistasId_NombreCol))
                pagoContratistasDetalles.PAGO_CONTRATISTA_ID = decimal.Parse(campos[PagoContratistasDetallesServices.PagoContratistasId_NombreCol].ToString());

            if (campos.Contains(PagoContratistasDetallesServices.PorcentajeFondoReparo_NombreCol))
                pagoContratistasDetalles.PORCENTAJE_FONDO_REPARO = decimal.Parse(campos[PagoContratistasDetallesServices.PorcentajeFondoReparo_NombreCol].ToString());

           if (insertarNuevo)
                sesion.db.PAGO_CONTRATISTAS_DETALLESCollection.Insert(pagoContratistasDetalles);
            else
                sesion.db.PAGO_CONTRATISTAS_DETALLESCollection.Update(pagoContratistasDetalles);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, pagoContratistasDetalles.ID, valorAnterior, pagoContratistasDetalles.ToString(), sesion);
        }
       
        #endregion Guardar

        #region Accessors
        
        public static string Nombre_Tabla
        {
            get { return "PAGO_CONTRATISTAS_DETALLES"; }
        }
        public static string AdelantoInicial_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.ADELANTO_INICIALColumnName; }
        }
        public static string AdelantosPagados_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.ADELANTOS_PAGADOSColumnName; }
        }
        public static string Adelantos_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.ADELANTOSColumnName; }
        }
        public static string CasoRelacionadoId_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.CASO_RELACIONADO_IDColumnName; }
        }
        public static string CertificadoMonto_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.CERTIFICADO_MONTOColumnName; }
        }
        public static string CertificadoNro_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.CERTIFICADO_NROColumnName; }
        }
        public static string Certificado_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.CERTIFICADOColumnName; }
        }
        public static string FacturasProveedorPagado_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FACTURAS_PROVEEDOR_PAGADOColumnName; }
        }
        public static string FacturasProveedor_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FACTURAS_PROVEEDORColumnName; }
        }
        public static string FechaDesde_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FECHA_DESDEColumnName; }
        }
        public static string FechaHasta_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FECHA_HASTAColumnName; }
        }
        public static string FondoFijoPagado_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FONDO_FIJO_PAGADOColumnName; }
        }
        public static string FondoFijo_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FONDO_FIJOColumnName; }
        }
        public static string FondoReparo_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.FONDO_REPAROColumnName; }
        }
        public static string PagoContratistasId_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.PAGO_CONTRATISTA_IDColumnName; }
        }
        public static string Retencion_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.RETENCIONColumnName; }
        }
        public static string TotalIva_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.TOTAL_IVAColumnName; }
        }
        public static string TotalPagar_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.TOTAL_PAGARColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.TOTALColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.IDColumnName; }
        }
        public static string PorcentajeFondoReparo_NombreCol
        {
            get { return PAGO_CONTRATISTAS_DETALLESCollection.PORCENTAJE_FONDO_REPAROColumnName; }
        }

        #endregion Accessors

        #region Actualizar Caso Relacionado
        public static void ActualizarCasoRelacionado(decimal IdDetalle, decimal casoRelacionado)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarCasoRelacionado(IdDetalle, casoRelacionado, sesion);
            }
        }

        public static void ActualizarCasoRelacionado(decimal IdDetalle, decimal casoRelacionado, SessionService sesion)
        {
                sesion.Db.BeginTransaction();
                PAGO_CONTRATISTAS_DETALLESRow row = new PAGO_CONTRATISTAS_DETALLESRow();
                row = sesion.Db.PAGO_CONTRATISTAS_DETALLESCollection.GetByPrimaryKey(IdDetalle);
                row.CASO_RELACIONADO_ID = casoRelacionado;
                String valorAnterior = row.ToString();
                sesion.Db.PAGO_CONTRATISTAS_DETALLESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                sesion.Db.CommitTransaction();
            
        }
        #endregion Actualizar Caso Relacionado

        #region Borrar detalle
        public static void Borrar(decimal IdDetalle)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                PAGO_CONTRATISTAS_DETALLESRow row = new PAGO_CONTRATISTAS_DETALLESRow();
                row = sesion.Db.PAGO_CONTRATISTAS_DETALLESCollection.GetByPrimaryKey(IdDetalle);
                String valorAnterior = row.ToString();
                sesion.Db.PAGO_CONTRATISTAS_DETALLESCollection.DeleteByPrimaryKey(IdDetalle);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                sesion.Db.CommitTransaction();
            }
        }
        #endregion
    }
}
