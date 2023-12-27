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
    public class TarifariosGruposService   
    {
        #region GetDataTable
        public static DataTable GetTarifariosGruposDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosGruposDataTable(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosGruposDataTable(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOS_GRUPOSCollection.GetAsDataTable(where, orden);
        }

        
        #endregion GetDataTable

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService()) 
            {
                try {
                    sesion.Db.BeginTransaction();
                    decimal tarifarioGrupoId = Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    return tarifarioGrupoId;
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
                TARIFARIOS_GRUPOSRow row = new TARIFARIOS_GRUPOSRow();
               
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("TARIFARIOS_GRUPOS_SQC");
                }
                else
                {
                    if(!campos.Contains(TarifariosGruposService.Id_NombreCol))
                        throw new Exception("Error, no se cargo el identificador del grupo.");
                    row = sesion.db.TARIFARIOS_GRUPOSCollection.GetByPrimaryKey(decimal.Parse(campos[TarifariosGruposService.Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                if (!campos.Contains(TarifariosGruposService.Nombre_NombreCol))
                    throw new Exception("Error,no  se cargo el nombre del grupo.");
                if (!campos.Contains(TarifariosGruposService.Nombre_NombreCol))
                    throw new Exception("Error,no  se cargo la operacion del grupo.");

                row.NOMBRE = campos[TarifariosGruposService.Nombre_NombreCol].ToString();
                row.OPERACION = campos[TarifariosGruposService.Operacion_NombreCol].ToString();

                if(insertarNuevo)
                     sesion.Db.TARIFARIOS_GRUPOSCollection.Insert(row);
                else
                    sesion.Db.TARIFARIOS_GRUPOSCollection.Update(row);
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
        public static void Borrar(decimal tarifario_grupo_id, SessionService sesion)
        {
            try
            {
                TARIFARIOS_GRUPOSRow row = sesion.Db.TARIFARIOS_GRUPOSCollection.GetByPrimaryKey(tarifario_grupo_id);
                String valorAnterior = string.Empty;

                TarifariosColumnasService.BorrarGrupos(tarifario_grupo_id,sesion);

                sesion.Db.TARIFARIOS_GRUPOSCollection.Delete(row);
                LogCambiosService.LogDeRegistro(TarifariosGruposService.Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }

        public static void Borrar(decimal tarifario_grupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(tarifario_grupo_id, sesion);
               
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TARIFARIOS_GRUPOS"; }
        }
        public static string Id_NombreCol
        {
            get { return TARIFARIOS_GRUPOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TARIFARIOS_GRUPOSCollection.NOMBREColumnName; }
        }
        public static string Operacion_NombreCol
        {
            get { return TARIFARIOS_GRUPOSCollection.OPERACIONColumnName; }
        }
        #endregion Accessors

        public static DataTable GetOperaciones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(TarifariosGruposService.Operacion_NombreCol);
            dt.Rows.Add(Operacion.Mayor);
            dt.Rows.Add(Operacion.Menor);
            dt.Rows.Add(Operacion.Suma);
            dt.Rows.Add(Operacion.Escala);
             return dt;

        }
        public static DataTable GetGruposPorTarifarioId(decimal tarfario_id, SessionService sesion)
        {
            string query = "select distinct t.tarifario_grupo_nombre as " + TarifariosColumnasService.VistaTarifarioGrupoNombre_NombreCol;
            query += " from tarifarios_columnas_inf_comp t ";
            query += " where t.tarifarios_grupo_id is not null and t.tarifario_id =" + tarfario_id;
           return sesion.db.EjecutarQuery(query);

        }

        public static DataTable GetGruposPorTarifarioId(decimal tarfario_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return GetGruposPorTarifarioId(tarfario_id, sesion);
                }
            }
            catch (Exception exp)
            {
                throw  exp;
            }

        }

        public class Operacion
        {
            public static string Mayor = "Mayor";
            public static string Menor = "Menor";
            public static string Suma = "Suma";
            public static string Escala = "Escala";
           
        }
    }
}

