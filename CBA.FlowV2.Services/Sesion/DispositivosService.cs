using System;
using System.Collections.Generic;
using CBA.FlowV2.Db;
using System.Collections;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;

namespace CBA.FlowV2.Services.Sesion
{
    public class DispositivosService
    {
        #region GetDataTable
        public static DataTable GetDataTable(decimal usuario_id, string caracteristicas)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string clausulas = DispositivosService.UsuarioId_NombreCol + " = " + usuario_id + " and " + DispositivosService.Caracteristica_NombreCol + " = '" + caracteristicas + "' ";
                    return GetDataTable(clausulas, string.Empty, sesion);
                }
                catch
                {
                    throw;
                }
            }
        }

        public static DataTable GetDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.DISPOSITIVOSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetDataTable

        #region Guardar
        public static decimal Guardar(Hashtable campos, SessionService sesion)
        {
            try
            {
                DISPOSITIVOSRow row;
                string valorAnterior;

                if (campos.Contains(DispositivosService.Id_NombreCol))
                {
                    row = sesion.db.DISPOSITIVOSCollection.GetByPrimaryKey((decimal)campos[DispositivosService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }
                else
                {
                    row = new DISPOSITIVOSRow();
                    row.ID = sesion.db.GetSiguienteSecuencia(DispositivosService.Nombre_Secuencia);
                    row.ESTADO = Definiciones.Estado.Activo;
                    row.USUARIO_ID = sesion.Usuario_Id;
                    row.TOKEN = row.ID.ToString();
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }

                if (!campos.Contains(DispositivosService.Caracteristica_NombreCol))
                    throw new Exception("El campo característica es obligatorio");
                row.CARACTERISTICA = (string)campos[DispositivosService.Caracteristica_NombreCol];

                if (campos.Contains(DispositivosService.Nombre_NombreCol))
                    row.NOMBRE = (string)campos[DispositivosService.Nombre_NombreCol];
                else
                    row.NOMBRE = row.CARACTERISTICA;

                if (campos.Contains(DispositivosService.Estado_NombreCol))
                    row.ESTADO = (string)campos[DispositivosService.Estado_NombreCol];

                if (campos.Contains(DispositivosService.UsuarioId_NombreCol))
                    row.USUARIO_ID = (decimal)campos[DispositivosService.UsuarioId_NombreCol];

                if (campos.Contains(DispositivosService.Id_NombreCol))
                    sesion.db.DISPOSITIVOSCollection.Update(row);
                else
                    sesion.db.DISPOSITIVOSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                
                return row.ID;
            }
            catch
            {
                throw;
            }
        }
        #endregion Guardar

        

        #region GetToken
        public static string GetToken(decimal dispositivo_id, SessionService sesion)
        {
            try
            {
                DISPOSITIVOSRow row = sesion.db.DISPOSITIVOSCollection.GetByPrimaryKey(dispositivo_id);
                return row.TOKEN;
            }
            catch
            {
                throw;
            }
        }
        #endregion GetToken

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DISPOSITIVOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "DISPOSITIVOS_SQC"; }
        }
        public static string Caracteristica_NombreCol
        {
            get { return DISPOSITIVOSCollection.CARACTERISTICAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return DISPOSITIVOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DISPOSITIVOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return DISPOSITIVOSCollection.NOMBREColumnName; }
        }
        public static string Token_NombreCol
        {
            get { return DISPOSITIVOSCollection.TOKENColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return DISPOSITIVOSCollection.USUARIO_IDColumnName; }
        }
        #endregion Accessors
    }
}
