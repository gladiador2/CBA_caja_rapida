using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Herramientas
{
    public class SucursalesSectoresService
    {
        #region Constructor
        public SucursalesSectoresService()
        {
        }
        #endregion Constructor

        #region GetSucursalesSectoresDataTable

        /// <summary>
        /// Gets the SucursalesSectores data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DataTable GetSucursalesSectoresDataTable(string where, SessionService sesion)
        {
            DataTable table = sesion.Db.SUCURSALES_SECTORESCollection.GetAsDataTable(where, SucursalesSectoresService.Id_NombreCol);
            return table;

        }

        /// <summary>
        /// Gets the SucursalesSectores data table.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public static DataTable GetSucursalesSectoresDataTable(string where)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSucursalesSectoresDataTable(where, sesion);
            }
        }

        public static DataTable GetSucursalesSectoresDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                string where = SucursalesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" ;
                return GetSucursalesSectoresDataTable(where, sesion);
            }
        }

        #endregion GetSucursalesSectoresDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            SUCURSALES_SECTORESRow row = new SUCURSALES_SECTORESRow();
            string valorAnterior = string.Empty;

            #region Validaciones
            //Control de campos obligatorios

            if (!campos.Contains(SucursalesSectoresService.Nombre_NombreCol))
                throw new Exception("Debe Indicar el nombre de la sucursal correspondiente.");
            if (!campos.Contains(SucursalesSectoresService.Abreviatura_NombreCol))
                throw new Exception("Debe Indicar la abreviatura de la sucursal");
            if (!campos.Contains(SucursalesSectoresService.Orden_NombreCol))
                throw new Exception("Debe Indicar el numero de orden.");

            #endregion Validaciones

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("SUCURSALES_SECTORES_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.SUCURSALES_SECTORESCollection.GetByPrimaryKey(decimal.Parse(campos[SucursalesSectoresService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }
            row.SUCURSAL_ID = decimal.Parse(campos[SucursalesSectoresService.Id_Sucursal].ToString());
            row.NOMBRE = campos[SucursalesSectoresService.Nombre_NombreCol].ToString();
            row.ABREVIATURA = campos[SucursalesSectoresService.Abreviatura_NombreCol].ToString();
            row.ORDEN = decimal.Parse(campos[SucursalesSectoresService.Orden_NombreCol].ToString());
            row.ESTADO = campos[SucursalesSectoresService.Estado_NombreCol].ToString();

            if (insertarNuevo)
                sesion.db.SUCURSALES_SECTORESCollection.Insert(row);
            else
                sesion.db.SUCURSALES_SECTORESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;

        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal surcursalSectores_id = Guardar(campos, sesion, insertarNuevo);
                    sesion.db.CommitTransaction();
                    return surcursalSectores_id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }


        }
        #endregion Guardar

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "SucursalesSectores"; }
        }
        public static string Id_NombreCol
        {
            get { return SUCURSALES_SECTORESCollection.IDColumnName; }
        }
        public static string Id_Sucursal
        {
            get { return SUCURSALES_SECTORESCollection.SUCURSAL_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return SUCURSALES_SECTORESCollection.NOMBREColumnName; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return SUCURSALES_SECTORESCollection.ABREVIATURAColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return SUCURSALES_SECTORESCollection.ORDENColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return SUCURSALES_SECTORESCollection.ESTADOColumnName; }
        }
        #endregion Accesors

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal sector_id)
        {
            using (SessionService sesion = new SessionService())
            {
                SUCURSALES_SECTORESRow sucursal = sesion.Db.SUCURSALES_SECTORESCollection.GetByPrimaryKey(sector_id);
                return sucursal.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo
    }
}
