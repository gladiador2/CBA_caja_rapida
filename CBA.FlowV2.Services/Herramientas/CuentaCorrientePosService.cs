using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;

namespace CBA.FlowV2.Services.Tesoreria
{
    
    public class CuentaCorrientePosService
    {
        public static string red_infonet = "INFONET";
        public static string red_dinelco = "DINELCO";

        #region GetPOSDataTable
        public static DataTable GetPosDataTable(string clausulas, string order, SessionService sesion)
        {

            DataTable dt = new DataTable();   
           
            dt = sesion.Db.CTACTE_POSCollection.GetAsDataTable(clausulas, order);
          
            return dt;
        }

        public static DataTable GetPosDataTable(string clausulas, string order, bool soloactivos)
        {
            using (SessionService sesion = new SessionService())
            {
                if(soloactivos && !clausulas.Equals(string.Empty))
                clausulas += "\n and "+ Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                else if(soloactivos)
                    clausulas = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                return GetPosDataTable(clausulas, order, sesion);
            }
        }
        #endregion GetPOSDataTable

        #region getPOSNombre
        public static string getPOSNombrePorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_POSRow row = sesion.Db.CTACTE_POSCollection.GetByPrimaryKey(id);
                return row.NOMBRE;
            }
        }
        #endregion getPOSNombre

        #region Guardar
        public static decimal Guardar(Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            CTACTE_POSRow row = new CTACTE_POSRow();           
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_POS_SQC");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.CTACTE_POSCollection.GetByPrimaryKey(decimal.Parse(campos[CuentaCorrientePosService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }
            if (campos.Contains(CuentaCorrientePosService.Codigo_NombreCol))
                row.CODIGO = campos[CuentaCorrientePosService.Codigo_NombreCol].ToString();// decimal.Parse(campos[CuentaCorrientePosService.Codigo_NombreCol].ToString());
            else
                throw new Exception("Es necesario cargar el código del POS para continuar.");
            if (campos.Contains(CuentaCorrientePosService.Nombre_NombreCol))
                row.NOMBRE = campos[CuentaCorrientePosService.Nombre_NombreCol].ToString();
            else
                throw new Exception("Es necesario cargar el nombre del POS para continuar.");
            if (campos.Contains(CuentaCorrientePosService.SucursalId_NombreCol))
                row.SUCURSAL_ID = decimal.Parse(campos[CuentaCorrientePosService.SucursalId_NombreCol].ToString());
            else
                throw new Exception("Es necesario seleccionar una sucursal para continuar.");
            if (campos.Contains(CuentaCorrientePosService.Red_NombreCol))
                row.RED = campos[CuentaCorrientePosService.Red_NombreCol].ToString();
            else
                throw new Exception("Es necesario seleccionar una red para continuar.");
            if (campos.Contains(CuentaCorrientePosService.Estado_NombreCol))
                row.ESTADO = campos[CuentaCorrientePosService.Estado_NombreCol].ToString();
          
            if(existeCodigo(row.CODIGO,insertarNuevo, row.ID))
                 throw new Exception("No se puede guardar porque el código "+row.CODIGO+" ya existe.");

            if (insertarNuevo)
            {
                sesion.db.CTACTE_POSCollection.Insert(row);
            }
            else
                sesion.db.CTACTE_POSCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }

        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal pos_id = Guardar(campos, sesion, insertarNuevo);
                    sesion.db.CommitTransaction();
                    return pos_id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region verificarCodigoExistente
        public static bool existeCodigo(string codigo, bool nuevo, decimal pos_id)
        {
            string clausulas = CuentaCorrientePosService.Codigo_NombreCol + " = " + codigo;
            if(!nuevo)
                clausulas += " and " + CuentaCorrientePosService.Id_NombreCol + " != " + pos_id;
            DataTable dt = GetPosDataTable(clausulas, string.Empty, false);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion verificarCodigoExistente

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_POS"; }
        }
        public static string Nombre_Vista
        {
            get { return ""; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_POSCollection.IDColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return CTACTE_POSCollection.CODIGOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_POSCollection.NOMBREColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTACTE_POSCollection.SUCURSAL_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_POSCollection.ESTADOColumnName; }
        }
        public static string Red_NombreCol
        {
            get { return CTACTE_POSCollection.REDColumnName; }
        }
        #endregion Accesors
    }
}
