using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCajaComposicionService
    {
        #region GetCtacteCajaComposDataTable
        public static DataTable GetCtacteCajaComposDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteCajaComposDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCtacteCajaComposDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_CAJA_COMPOSICIONCollection.GetAsDataTable(clausulas, orden);
        }

        public static decimal GetCtacteCajaComposicionId(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CAJA_COMPOSICIONRow idCajaComposicion = sesion.Db.CTACTE_CAJA_COMPOSICIONCollection.GetRow(clausulas);
                return idCajaComposicion.ID;
            }
        }
              
        #endregion GetCtacteCajaDataTable

        #region GetCtacteCajaComposInfoCompleta
        /// <summary>
        /// Gets the ctacte caja composicion info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCtacteCajaComposInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_CAJA_COMPOS_INF_COMPLCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetCtacteCajaComposInfoCompleta(decimal idCajaComposicion)
        {
            string clausulas = CuentaCorrienteCajaComposicionService.Id_NombreCol + " = " + idCajaComposicion;
            using (SessionService sesion = new SessionService())
            {
                return GetCtacteCajaComposInfoCompleta(clausulas, string.Empty, sesion);
            }
        }
        #endregion GetCtacteCajaComposInfoCompleta

        #region ExisteArqueo
        public static bool ExisteArqueo(string clausula, SessionService sesion)
        {
            bool existe = false;
            
            DataTable dtArqueo = sesion.Db.CTACTE_CAJA_COMPOSICIONCollection.GetAsDataTable(clausula, string.Empty);

            if (dtArqueo.Rows.Count > 0)
                existe = true;
            
            return existe;
        }
        #endregion ExisteArqueo

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns>El id del recibo</returns>
        public static void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CTACTE_CAJA_COMPOSICIONRow row = new CTACTE_CAJA_COMPOSICIONRow();

                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_caja_composicion_sqc");
                row.FECHA = DateTime.Now;
                row.SUCURSAL_ID = (decimal)campos[SucursalId_NombreCol];
                
                if (campos.Contains(CtaCteCajaSucursalId_NombreCol))
                    row.CTACTE_CAJA_SUCURSAL_ID = (decimal)campos[CtaCteCajaSucursalId_NombreCol];
                else
                    row.IsCTACTE_CAJA_SUCURSAL_IDNull = true;

                if (campos.Contains(CtaCteFondoFijoId_NombreCol))
                    row.CTACTE_FONDO_FIJO_ID = (decimal)campos[CtaCteFondoFijoId_NombreCol];
                else
                    row.IsCTACTE_FONDO_FIJO_IDNull = true;

                sesion.Db.CTACTE_CAJA_COMPOSICIONCollection.Insert(row);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ctacte_caja_composicion"; }
        }
        public static string Nombre_Vista
        {
            get { return "ctacte_caja_compos_inf_compl"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICIONCollection.IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICIONCollection.SUCURSAL_IDColumnName; }
        }
        public static string CtaCteCajaSucursalId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICIONCollection.CTACTE_CAJA_SUCURSAL_IDColumnName; }
        }
        public static string CtaCteFondoFijoId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICIONCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return CTACTE_CAJA_COMPOSICIONCollection.FECHAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_INF_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_INF_COMPLCollection.SUCURSAL_ABREVColumnName; }
        }
        public static string VistaFuncionarioCajaSucId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_INF_COMPLCollection.FUNCIONARIO_CAJA_SUCColumnName; }
        }
        public static string VistaFuncionarioFondoFijoId_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_INF_COMPLCollection.FUNCIONARIO_FONDO_FIJOColumnName; }
        }
        public static string VistaFondoFijoNombre_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_INF_COMPLCollection.FONDO_FIJO_NOMBREColumnName; }
        }
        public static string VistaFondoFijoLimiteSuperior_NombreCol
        {
            get { return CTACTE_CAJA_COMPOS_INF_COMPLCollection.LIMITE_SUPERIOR_FFColumnName; }
        }
        #endregion Accessors
    }
}
