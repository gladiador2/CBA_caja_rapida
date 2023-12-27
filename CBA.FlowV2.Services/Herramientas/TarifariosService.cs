#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TarifariosService   
    {
        #region GetDataTable
        public static DataTable GetTarifariosDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosDataTable(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosDataTable(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOSCollection.GetAsDataTable(where, orden);
        }

        public static DataTable GetTarifariosInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosInfoCompleta(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosInfoCompleta(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
        }
        #endregion GetDataTable

        

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService()) 
            {
                try {
                    sesion.Db.BeginTransaction();
                    decimal tarifarioId = Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    return tarifarioId;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            } 
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                TARIFARIOSRow row = new TARIFARIOSRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("tarifarios_sqc");
                }
                else
                {
                    row = sesion.Db.TARIFARIOSCollection.GetByPrimaryKey(decimal.Parse(campos[TarifariosService.Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                
                row.NOMBRE = (campos[TarifariosService.Nombre_NombreCol].ToString());
                row.ESTADO = Definiciones.Estado.Activo;
                row.FECHA_MODIFICACION = DateTime.Now;
                row.USUARIO_MODIFICACION_ID = sesion.Usuario_Id;
                


                if (insertarNuevo) sesion.Db.TARIFARIOSCollection.Insert(row);
                else sesion.Db.TARIFARIOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal tarifario_id, SessionService sesion)
        {
            try
            {
                TARIFARIOSRow row = sesion.Db.TARIFARIOSCollection.GetByPrimaryKey(tarifario_id);
                String valorAnterior = row.ToString();
                
                row.ESTADO = Definiciones.Estado.Inactivo;
                row.FECHA_MODIFICACION = DateTime.Now;
                row.USUARIO_MODIFICACION_ID = sesion.Usuario_Id;

                sesion.Db.TARIFARIOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(TarifariosService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }

        public static void Borrar(decimal tarifario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Borrar(tarifario_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TARIFARIOS"; }
        }
        public static string Id_NombreCol
        {
            get { return TARIFARIOSCollection.IDColumnName; }
        }
        public static string FechaModificacion_NombreCol
        {
            get { return TARIFARIOSCollection.FECHA_MODIFICACIONColumnName; }
        }
        public static string UsuarioModificacionId_NombreCol
        {
            get { return TARIFARIOSCollection.USUARIO_MODIFICACION_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TARIFARIOSCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TARIFARIOSCollection.ESTADOColumnName; }
        }
        
        public static string VistaUsuarioModificacionNombre_NombreCol
        {
            get { return TARIFARIOS_INFO_COMPLETACollection.USUARIO_MODIFICACION_NOMBREColumnName; }
        }
       

        #endregion Accessors
    }
}

