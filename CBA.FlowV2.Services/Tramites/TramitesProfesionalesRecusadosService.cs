#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
using System.Data;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesProfesionalesRecusadosService
    {
        #region GetTramitesProfesionalesRecusadosDataTable
        /// <summary>
        /// Gets the tramites profesionales recusados data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesProfesionalesRecusadosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_PROF_RECUSADOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesProfesionalesRecusadosDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_PROF_RECUSADOSRow row = new TRAMITES_PROF_RECUSADOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramit_prof_recusados_sqc");
                        row.TRAMITE_ID = (decimal)campos[TramitesProfesionalesRecusadosService.TramiteId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_PROF_RECUSADOSCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesProfesionalesRecusadosService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.CARGO = (string)campos[TramitesProfesionalesRecusadosService.Cargo_NombreCol];
                    row.MOTIVO = (string)campos[TramitesProfesionalesRecusadosService.Motivo_NombreCol];
                    row.NOMBRE = (string)campos[TramitesProfesionalesRecusadosService.Nombre_NombreCol];

                    if (campos.Contains(TramitesProfesionalesRecusadosService.Observaciones_NombreCol))
                        row.OBSERVACIONES= (string)campos[TramitesProfesionalesRecusadosService.Observaciones_NombreCol];

                    if (insertarNuevo) sesion.Db.TRAMITES_PROF_RECUSADOSCollection.Insert(row);
                    else sesion.Db.TRAMITES_PROF_RECUSADOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified prof recusado id.
        /// </summary>
        /// <param name="profRecusadoId">The prof recusado id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal profRecusadoId, SessionService sesion)
        {
            try
            {
                TRAMITES_PROF_RECUSADOSRow fila = sesion.Db.TRAMITES_PROF_RECUSADOSCollection.GetByPrimaryKey(profRecusadoId);

                sesion.Db.TRAMITES_PROF_RECUSADOSCollection.DeleteByPrimaryKey(profRecusadoId);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, profRecusadoId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void Borrar(decimal profRecusadoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(profRecusadoId, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_PROF_RECUSADOS"; }
        }
        public static string Cargo_NombreCol
        {
            get { return TRAMITES_PROF_RECUSADOSCollection.CARGOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_PROF_RECUSADOSCollection.IDColumnName; }
        }
        public static string Motivo_NombreCol
        {
            get { return TRAMITES_PROF_RECUSADOSCollection.MOTIVOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TRAMITES_PROF_RECUSADOSCollection.NOMBREColumnName; }
        }
        public static string Observaciones_NombreCol
        {
            get { return TRAMITES_PROF_RECUSADOSCollection.OBSERVACIONESColumnName; }
        }
        public static string TramiteId_NombreCol
        {
            get { return TRAMITES_PROF_RECUSADOSCollection.TRAMITE_IDColumnName; }
        }
        #endregion Accessors
    }
}
