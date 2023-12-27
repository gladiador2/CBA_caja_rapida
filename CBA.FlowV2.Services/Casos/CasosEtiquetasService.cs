#region Using
using System;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Casos
{
    public class CasosEtiquetasService
    {
        #region GetCasosEtiquetasDataTable
        public static DataTable GetCasosEtiquetasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0)
                    where += " and (" + clausulas + ")";
                return sesion.Db.CASOS_ETIQUETASCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCasosEtiquetasDataTable

        #region GetCasosEtiquetasInfoCompleta
        public static DataTable GetCasosEtiquetasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0)
                    where += " and (" + clausulas + ")";
                return sesion.Db.CASOS_ETIQUETAS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCasosEtiquetasInfoCompleta

        #region Verificar duplicación
        private static bool ExisteCombinacionCasoIdTextoPredefinidoId(decimal caso_id, decimal texto_predefinido_id, SessionService sesion)
        {
            bool existe = false;
            string clausulas = CasosEtiquetasService.CasoId_NombreCol + " = " + caso_id +
                               " and " + CasosEtiquetasService.TextoPredefinidoId_NombreCol + " = " + texto_predefinido_id;

            CASOS_ETIQUETASRow[] rows = sesion.Db.CASOS_ETIQUETASCollection.GetAsArray(clausulas, string.Empty);

            existe = rows.Length > 0;

            return existe;
        }
        #endregion Verificar duplicación

        #region Guardar
        public static void Guardar(Hashtable campos, bool insertarNuevo)
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

        public static void Guardar(Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            CASOS_ETIQUETASRow row = new CASOS_ETIQUETASRow();
            string valorAnterior = Definiciones.Log.RegistroNuevo;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("casos_etiquetas_sqc");
                row.FECHA_CREACION = DateTime.Now;
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.CASOS_ETIQUETASCollection.GetByPrimaryKey(decimal.Parse(campos[CasosEtiquetasService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }

            row.TEXTO_PREDEFINIDO_ID = (decimal)campos[CasosEtiquetasService.TextoPredefinidoId_NombreCol];
            row.ESTADO = Definiciones.Estado.Activo;
            row.TABLA_ID = (string)campos[CasosEtiquetasService.TablaId_NombreCol];

            if (!Interprete.EsNullODBNull(campos[CasosEtiquetasService.CasoId_NombreCol]))
            {
                row.CASO_ID = (decimal)campos[CasosEtiquetasService.CasoId_NombreCol];
                if (CasosEtiquetasService.ExisteCombinacionCasoIdTextoPredefinidoId(row.CASO_ID, row.TEXTO_PREDEFINIDO_ID, sesion))
                    throw new Exception("Ya existe ese valor asociado al caso.");
            }
            else
            {
                row.IsCASO_IDNull = true;
            }

            if (!Interprete.EsNullODBNull(campos[CasosEtiquetasService.RegistroId_NombreCol]))
                row.REGISTRO_ID = (decimal)campos[CasosEtiquetasService.RegistroId_NombreCol];
            else
                row.IsREGISTRO_IDNull = true;

            if (insertarNuevo)
                sesion.Db.CASOS_ETIQUETASCollection.Insert(row);
            else
                sesion.Db.CASOS_ETIQUETASCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(id, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static void Borrar(decimal id, SessionService sesion)
        {
            CASOS_ETIQUETASRow row = sesion.Db.CASOS_ETIQUETASCollection.GetByPrimaryKey(id);

            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.Db.CASOS_ETIQUETASCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CASOS_ETIQUETAS"; }
        }

        public static string Nombre_Vista
        {
            get { return "CASOS_ETIQUETAS_INFO_COMPLETA"; }
        }

        public static string Id_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.IDColumnName; }
        }

        public static string CasoId_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.CASO_IDColumnName; }
        }

        public static string FechaCreacion_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.FECHA_CREACIONColumnName; }
        }

        public static string TextoPredefinidoId_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }

        public static string TablaId_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.TABLA_IDColumnName; }
        }

        public static string RegistroId_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.REGISTRO_IDColumnName; }
        }

        public static string Estado_NombreCol
        {
            get { return CASOS_ETIQUETASCollection.ESTADOColumnName; }
        }

        public static string VistaCasoFlujoDescripcion_NombreCol
        {
            get { return CASOS_ETIQUETAS_INFO_COMPLETACollection.FLUJO_DESCRIPCIONColumnName; }
        }

        public static string VistaCasoFlujoId_NombreCol
        {
            get { return CASOS_ETIQUETAS_INFO_COMPLETACollection.FLUJO_IDColumnName; }
        }

        public static string VistaTextoPredefinidoTipoId_NombreCol
        {
            get { return CASOS_ETIQUETAS_INFO_COMPLETACollection.TIPO_TEXTO_PREDEFINIDO_IDColumnName; }
        }

        public static string VistaTextoPredefinidoTipoNombre_NombreCol
        {
            get { return CASOS_ETIQUETAS_INFO_COMPLETACollection.TIPO_TEXTO_PREDEFINIDO_NOMBREColumnName; }
        }

        public static string VistaTextoPredefinido_NombreCol
        {
            get { return CASOS_ETIQUETAS_INFO_COMPLETACollection.TEXTOColumnName; }
        }

        public static string VistaTablaNombre_NombreCol
        {
            get { return CASOS_ETIQUETAS_INFO_COMPLETACollection.TABLA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
