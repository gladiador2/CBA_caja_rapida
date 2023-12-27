using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteRecargosService
    {
        #region GetFechaMinimaSinFacturar
        /// <summary>
        /// Gets the fecha minima sin facturar.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetFechaMinimaSinFacturar()
        {
            string clausula = CuentaCorrienteRecargosService.CasoFacturaId_NombreCol + " is null";
            DataTable dt = GetCtacteRecargosDataTable(clausula, CuentaCorrienteRecargosService.Fecha_NombreCol);

            if (dt.Rows.Count > 0)
                return (DateTime)dt.Rows[0][CuentaCorrienteRecargosService.Fecha_NombreCol];
            else
                return DateTime.Now;
        }
        #endregion GetFechaMinimaSinFacturar

        #region GetCtacteRecargosDataTable
        /// <summary>
        /// Gets the ctacte recargos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCtacteRecargosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteRecargosDataTable(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the ctacte recargos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetCtacteRecargosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_RECARGOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCtacteRecargosDataTable

        #region GetCtacteRecargosInfoCompleta
        /// <summary>
        /// Gets the ctacte recargos information completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetCtacteRecargosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_RECARGOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCtacteRecargosInfoCompleta

        #region GetFacturasGeneradas
        /// <summary>
        /// Gets the facturas generadas.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFacturasGeneradas()
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.db.GetDistintos(Nombre_Tabla, CuentaCorrienteRecargosService.CasoFacturaId_NombreCol, CuentaCorrienteRecargosService.CasoFacturaId_NombreCol + " is not null");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion GetFacturasGeneradas

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_RECARGOSRow row = new CTACTE_RECARGOSRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                row.CASO_ORIGEN_ID = (decimal)campos[CuentaCorrienteRecargosService.CasoOrigenId_NombreCol];
                row.COTIZACION = (decimal)campos[CuentaCorrienteRecargosService.Cotizacion_NombreCol];
                row.FECHA = (DateTime)campos[CuentaCorrienteRecargosService.Fecha_NombreCol];
                row.FUNCIONARIO_ID = (decimal)campos[CuentaCorrienteRecargosService.FuncionarioId_NombreCol];
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_recargos_sqc");
                row.IMPUESTO_ID = (decimal)campos[CuentaCorrienteRecargosService.ImpuestoId_NombreCol];
                row.MONEDA_ID = (decimal)campos[CuentaCorrienteRecargosService.MonedaId_NombreCol];
                row.MONTO = (decimal)campos[CuentaCorrienteRecargosService.Monto_NombreCol];
                row.PERSONA_ID = (decimal)campos[CuentaCorrienteRecargosService.PersonaId_NombreCol];
                row.SUCURSAL_ID = (decimal)campos[CuentaCorrienteRecargosService.SucursalId_NombreCol];
                row.TIPO_RECARGO = (decimal)campos[CuentaCorrienteRecargosService.TipoRecargo_NombreCol];

                if (campos.Contains(CuentaCorrienteRecargosService.CtacteCajaSucursalId_NombreCol))
                    row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[CuentaCorrienteRecargosService.CtacteCajaSucursalId_NombreCol];

                if (campos.Contains(CuentaCorrienteRecargosService.CasoFacturaId_NombreCol))
                    row.CASO_FACTURA_ID = (decimal)campos[CuentaCorrienteRecargosService.CasoFacturaId_NombreCol];

                if(campos.Contains(CuentaCorrienteRecargosService.CtactePagoPersonaDocId_NombreCol))
                    row.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)campos[CuentaCorrienteRecargosService.CtactePagoPersonaDocId_NombreCol];
                if(campos.Contains(CuentaCorrienteRecargosService.CtactePagoPersonaRecargoId_NombreCol))
                    row.CTACTE_PAGO_PERSONA_RECARGO_ID = (decimal)campos[CuentaCorrienteRecargosService.CtactePagoPersonaRecargoId_NombreCol];

                if (campos.Contains(CuentaCorrienteRecargosService.AplicacionDcoumentoDocId_NombreCol))
                    row.APLICACION_DOCUMENTO_DOC_ID = (decimal)campos[CuentaCorrienteRecargosService.AplicacionDcoumentoDocId_NombreCol];
                if (campos.Contains(CuentaCorrienteRecargosService.AplicacionDcoumentoDocReId_NombreCol))
                    row.APLICACION_DOCUMENTO_DOC_RE_ID = (decimal)campos[CuentaCorrienteRecargosService.AplicacionDcoumentoDocReId_NombreCol];

                sesion.Db.CTACTE_RECARGOSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Vincular
        /// <summary>
        /// Vinculars the specified ctacte_recargo_id.
        /// </summary>
        /// <param name="ctacte_recargo_id">The ctacte_recargo_id.</param>
        /// <param name="caso_factura_id">The caso_factura_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Vincular(decimal ctacte_recargo_id, decimal caso_factura_id, SessionService sesion)
        {
            CTACTE_RECARGOSRow row = sesion.db.CTACTE_RECARGOSCollection.GetByPrimaryKey(ctacte_recargo_id);
            row.CASO_FACTURA_ID = caso_factura_id;
            sesion.db.CTACTE_RECARGOSCollection.Update(row);
        }
        #endregion Vincular

        #region Desvincular
        /// <summary>
        /// Desvinculars the specified ctacte_recargo_id.
        /// </summary>
        /// <param name="ctacte_recargo_id">The ctacte_recargo_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Desvincular(decimal ctacte_recargo_id, SessionService sesion)
        {
            CTACTE_RECARGOSRow row = sesion.db.CTACTE_RECARGOSCollection.GetByPrimaryKey(ctacte_recargo_id);
            row.IsCASO_FACTURA_IDNull = true;
            sesion.db.CTACTE_RECARGOSCollection.Update(row);
        }
        #endregion Desvincular

        #region BorrarDesdePago
        /// <summary>
        /// Borrars the desde pago.
        /// </summary>
        /// <param name="ctacte_pago_persona_documento_id">The ctacte_pago_persona_documento_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void BorrarDesdePago(decimal ctacte_pago_persona_documento_id, SessionService sesion)
        {
            try
            {
                CTACTE_RECARGOSRow[] rows = sesion.db.CTACTE_RECARGOSCollection.GetByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_documento_id);
                if (rows.Length <= 0) 
                    return;

                if (!rows[0].IsCASO_FACTURA_IDNull)
                    throw new Exception("El recargo no puede ser borrado porque pertenece a la factura con caso " + rows[0].CASO_FACTURA_ID + ".");

                sesion.db.CTACTE_RECARGOSCollection.DeleteByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_documento_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion BorrarDesdePago

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_RECARGOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "CTACTE_RECARGOS_INFO_COMP"; }
        }
        public static string AplicacionDcoumentoDocReId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.APLICACION_DOCUMENTO_DOC_RE_IDColumnName; }
        }
        public static string AplicacionDcoumentoDocId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.APLICACION_DOCUMENTO_DOC_IDColumnName; }
        }
        public static string CasoFacturaId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.CASO_FACTURA_IDColumnName; }
        }
        public static string CasoOrigenId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.CASO_ORIGEN_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.COTIZACIONColumnName; }
        }
        public static string CtacteCajaSucursalId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtactePagoPersonaDocId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.CTACTE_PAGO_PERSONA_DOC_IDColumnName; }
        }
        public static string CtactePagoPersonaRecargoId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.CTACTE_PAGO_PERSONA_RECARGO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.FECHAColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.IMPUESTO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.MONTOColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoRecargo_NombreCol
        {
            get { return CTACTE_RECARGOSCollection.TIPO_RECARGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaImpuestoPorcentaje_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.IMPUESTO_PORCENTAJEColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.IMPUESTO_NOMBREColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_RECARGOS_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
