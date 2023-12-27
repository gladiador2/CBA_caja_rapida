#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
using System.Collections;
#endregion using

namespace CBA.FlowV2.Services.Herramientas
{
    public class UnidadesMedidaService
    {
        #region GetUnidadesMedidaDataTable
        /// <summary>
        /// Gets the unidades de medida.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        /// 
        public static DataTable GetUnidadesMedidaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = GetUnidadesMedidaDataTable(clausulas, orden, sesion);
                return dt;
            }
        }

        public static DataTable GetUnidadesMedidaDataTable(string clausulas, string orden, SessionService sesion)
        {   
            return   sesion.Db.UNIDADES_MEDIDACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetUnidadesMedidaDataTable        

        #region GetUnidadMedidaPorId
        public static DataTable GetUnidadMedidaPorId(decimal unidadMedida_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = UnidadesMedidaService.Id_NombreCol + " = " + unidadMedida_id;
                return sesion.Db.UNIDADES_MEDIDACollection.GetAsDataTable(where, UnidadesMedidaService.Orden_NombreCol);
            }
        }
        #endregion GetUnidadMedidaPorId

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// 
        public static string Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string id = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        public static string Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                UNIDADES_MEDIDARow row = new UNIDADES_MEDIDARow();
                if (insertarNuevo)
                {
                    row.ID = campos[Id_NombreCol].ToString();
                }
                else
                {
                    row = sesion.Db.UNIDADES_MEDIDACollection.GetByPrimaryKey(campos[Id_NombreCol].ToString());
                }

                row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                if (campos.Contains(UnidadesMedidaService.FactorKilo_NombreCol))
                    row.FACTOR_KILO = (decimal)campos[FactorKilo_NombreCol];
                else
                    row.IsFACTOR_KILONull = true;
                if (campos.Contains(UnidadesMedidaService.FactorMetro_NombreCol))
                    row.FACTOR_METRO = (decimal)campos[FactorKilo_NombreCol];
                else
                    row.IsFACTOR_METRONull = true;
                row.CANTIDAD_DECIMALES = (decimal)campos[CantidadDecimales_NombreCol];
                row.ORDEN = (decimal)campos[Orden_NombreCol];

                if (insertarNuevo)
                    sesion.Db.UNIDADES_MEDIDACollection.Insert(row);
                else
                    sesion.Db.UNIDADES_MEDIDACollection.Update(row);

                return row.ID;
            }
            catch (OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe esta Unidad de Medida. Verifique el ID.", exp);
                    default:
                        throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar 

        #region Nombre de Columnas
        public static string Nombre_Tabla
        {
            get { return "UNIDADES_MEDIDA"; }
        }
        
        public static string Descripcion_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.DESCRIPCIONColumnName; }
        }
        public static string FactorKilo_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.FACTOR_KILOColumnName; }
        }
        
        public static string FactorMetro_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.FACTOR_METROColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.ORDENColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.IDColumnName; }
        }
        
        public static string CantidadDecimales_NombreCol
        {
            get { return UNIDADES_MEDIDACollection.CANTIDAD_DECIMALESColumnName; }
        }
       
        #endregion Nombre de Columnas
    }
}
