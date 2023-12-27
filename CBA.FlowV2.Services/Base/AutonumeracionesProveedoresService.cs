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

namespace CBA.FlowV2.Services.Base
{
    public class AutonumeracionesProveedoresService
    {
       
        #region GetPrefijo
        public static String GetPrefijo(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPrefijo(autonumeracion_id, sesion);
            }
        }
        public static String GetPrefijo(decimal autonumeracion_id, SessionService sesion)
        {

            AUTONUMERACIONES_PROVEEDORRow row = sesion.db.AUTONUMERACIONES_PROVEEDORCollection.GetByPrimaryKey(autonumeracion_id);

            if (row != null)
            { 
                return row.PREFIJO;
            }
            return string.Empty;
        }
        #endregion GetPrefijo

        #region GetAutonumeracionesDataTable
        /// <summary>
        /// Gets the autonumeraciones.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        /// 
        public static DataTable GetAutonumeracionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = GetAutonumeracionesDataTable(clausulas, orden, sesion);
                return dt;
            }
        }

        public static DataTable GetAutonumeracionesDataTable(string clausulas, string orden, SessionService sesion)
        {   
            return   sesion.Db.AUTONUMERACIONES_PROV_INF_COMCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAutonumeracionesDataTable        

        #region GetAutonumeracionPorId
        public static DataTable GetAutonumeracionPorId(decimal autonumeracion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = AutonumeracionesProveedoresService.Id_NombreCol + " = " + autonumeracion_id;
                return sesion.Db.AUTONUMERACIONES_PROVEEDORCollection.GetAsDataTable(where, AutonumeracionesProveedoresService.FechaVencimiento_NombreCol);
            }
        }
        #endregion GetAutonumeracionPorId

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// 
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, insertarNuevo, sesion);
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
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                AUTONUMERACIONES_PROVEEDORRow row = new AUTONUMERACIONES_PROVEEDORRow();
                string valorAnterior = string.Empty;
             
                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("AUTONUMERACIONES_PROVEE_SQC");
                   
                    row.FECHA_CREACION = DateTime.Now;

                    //Una vez creada la autonumeracion no pueden modificarse los limites y el proveedor
                    row.LIMITE_INFERIOR = (decimal)campos[LimiteInferior_NombreCol];
                    row.LIMITE_SUPERIOR = (decimal)campos[LimiteSuperior_NombreCol];

                    row.PROVEEDORES_ID = (decimal)campos[ProveedorId_NombreCol];
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.AUTONUMERACIONES_PROVEEDORCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
              
                if (!ValidarDuplicado(row.ID, campos, sesion))
                    return Definiciones.Error.Valor.EnteroPositivo;

              
                if (campos.Contains(LimiteInferior_NombreCol))
                    row.LIMITE_INFERIOR = (decimal)campos[LimiteInferior_NombreCol];
                if (campos.Contains(LimiteSuperior_NombreCol))
                    row.LIMITE_SUPERIOR = (decimal)campos[LimiteSuperior_NombreCol];
                if (!campos[NumeroTimbrado_NombreCol].Equals(string.Empty)) row.NUMERO_TIMBRADO = (string)campos[NumeroTimbrado_NombreCol];
                else row.NUMERO_TIMBRADO = string.Empty;
               
                if (!campos[Prefijo_NombreCol].Equals(string.Empty)) row.PREFIJO = (string)campos[Prefijo_NombreCol];
                else row.PREFIJO = string.Empty;

                if (campos.Contains(FechaVencimiento_NombreCol))
                    row.FECHA_VENCIMIENTO = (DateTime)campos[FechaVencimiento_NombreCol];
                else
                    row.IsFECHA_VENCIMIENTONull = true;

				if (campos.Contains(FechaInicio_NombreCol))
                    row.FECHA_INICIO = (DateTime)campos[FechaInicio_NombreCol];
                else
                    row.IsFECHA_INICIONull = true;

                if (campos.Contains(FlujoId_NombreCol))
                    row.FLUJO_ID = (decimal) campos[FlujoId_NombreCol];
                else
                    row.IsFLUJO_IDNull = true;  
                
                row.ESTADO = (string)campos[Estado_NombreCol];
                

                row.USUARIO_CREACION_ID = sesion.Usuario_Id;
              
                if (insertarNuevo)
                    sesion.Db.AUTONUMERACIONES_PROVEEDORCollection.Insert(row);
                else
                    sesion.Db.AUTONUMERACIONES_PROVEEDORCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe esta autonumeración", exp);
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

        #region ValidarDuplicado
        public static bool ValidarDuplicado(decimal autonumeracion_id, Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                return ValidarDuplicado(autonumeracion_id, campos, sesion);
            }
        }
        public static bool ValidarDuplicado(decimal autonumeracion_id, Hashtable campos, SessionService sesion)
        {
            string clausulasValidacion =
                                   AutonumeracionesProveedoresService.NumeroTimbrado_NombreCol + " = '" + campos[AutonumeracionesProveedoresService.NumeroTimbrado_NombreCol] + "' and ";
            clausulasValidacion += AutonumeracionesProveedoresService.ProveedorId_NombreCol + " = " + campos[AutonumeracionesProveedoresService.ProveedorId_NombreCol] + " and ";
            clausulasValidacion += AutonumeracionesProveedoresService.Id_NombreCol + " <> " + autonumeracion_id;

            DataTable dtValidacion = GetAutonumeracionesDataTable(clausulasValidacion, string.Empty);
            if (dtValidacion.Rows.Count > 0)
                throw new Exception("Ya existe el mismo número de timbrado registrado para el proveedor.");

            return true;
        }
        #endregion ValidarDuplicado

        #region Nombre de Columnas
        public static string Nombre_Tabla
        {
            get { return "AUTONUMERACIONES_PROVEEDOR"; }
        }
        
        public static string Estado_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.ESTADOColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.PROVEEDORES_IDColumnName; }
        }
        
        public static string FechaCreacion_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.FECHA_INICIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.IDColumnName; }
        }
        
        public static string LimiteInferior_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.LIMITE_INFERIORColumnName; }
        }
        public static string LimiteSuperior_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.LIMITE_SUPERIORColumnName; }
        }
       
        public static string Prefijo_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.PREFIJOColumnName; }
        }
        
        public static string UsuarioCreacionId_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string NumeroTimbrado_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.NUMERO_TIMBRADOColumnName; }
        }
        
        public static string ProveedorNombre_NombreCol
        {
            get { return ProveedoresService.RazonSocial_NombreCol; }
        }

        public static string FlujoId_NombreCol
        {
            get { return AUTONUMERACIONES_PROVEEDORCollection.FLUJO_IDColumnName; }
        }

        public static string FlujoDescripcion_NombreCol
        {
            get { return AUTONUMERACIONES_PROV_INF_COMCollection.FLUJO_DESCRIPCIONColumnName; }
        }

        public static string ProveedorRuc_NombreCol
        {
            get { return ProveedoresService.Ruc_NombreCol; }
        }
     
        #endregion Nombre de Columnas
    }
}
