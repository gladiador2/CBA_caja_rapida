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
    public class TramitesFuncionariosAsignadosService
    {
        #region GetTramitesFuncionariosAsignadosDataTable
        /// <summary>
        /// Gets the tramites funcionarios asignados data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesFuncionariosAsignadosDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_FUNCIONARIOS_ASIGNADCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesFuncionariosAsignadosDataTable

        #region GetTramitesFuncionariosAsignadosInfoCompleta
        /// <summary>
        /// Gets the tramites tipos etapas info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesFuncionariosAsignadosInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMIT_FUNCION_ASIG_INF_COMPCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesFuncionariosAsignadosInfoCompleta
        
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
                    TRAMITES_FUNCIONARIOS_ASIGNADRow row = new TRAMITES_FUNCIONARIOS_ASIGNADRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("TRAMIT_FUNCION_ASIG_SQC");
                        row.TRAMITE_ID = (decimal)campos[TramitesFuncionariosAsignadosService.TramiteId_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_FUNCIONARIOS_ASIGNADCollection.GetByPrimaryKey(decimal.Parse(campos[TramitesFuncionariosAsignadosService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.FUNCIONARIO_ID = (decimal)campos[TramitesFuncionariosAsignadosService.FuncionarioId_NombreCol];
                    row.OBSERVACION = (string)campos[TramitesFuncionariosAsignadosService.Observacion_NombreCol];                    
                    
                    if (insertarNuevo) sesion.Db.TRAMITES_FUNCIONARIOS_ASIGNADCollection.Insert(row);
                    else sesion.Db.TRAMITES_FUNCIONARIOS_ASIGNADCollection.Update(row);

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
        /// Borrars the specified tramite funcionario asignado id.
        /// </summary>
        /// <param name="tramiteFuncionarioAsignadoId">The tramite funcionario asignado id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal tramiteFuncionarioAsignadoId, SessionService sesion)
        {
            try
            {
                TRAMITES_FUNCIONARIOS_ASIGNADRow fila = sesion.Db.TRAMITES_FUNCIONARIOS_ASIGNADCollection.GetByPrimaryKey(tramiteFuncionarioAsignadoId);

                sesion.Db.TRAMITES_FUNCIONARIOS_ASIGNADCollection.DeleteByPrimaryKey(tramiteFuncionarioAsignadoId);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, tramiteFuncionarioAsignadoId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void Borrar(decimal tramiteFuncionarioAsignadoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Borrar(tramiteFuncionarioAsignadoId, sesion);
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
            get { return "TRAMITES_FUNCIONARIOS_ASIGNAD"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_FUNCIONARIOS_ASIGNADCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRAMITES_FUNCIONARIOS_ASIGNADCollection.OBSERVACIONColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return TRAMITES_FUNCIONARIOS_ASIGNADCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string TramiteId_NombreCol
        {
            get { return TRAMITES_FUNCIONARIOS_ASIGNADCollection.TRAMITE_IDColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return TRAMIT_FUNCION_ASIG_INF_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaTramiteTipoId_NombreCol
        {
            get { return TRAMIT_FUNCION_ASIG_INF_COMPCollection.TRAMITE_TIPO_IDColumnName; }
        }
        public static string VistaTramiteTipoNombre_NombreCol
        {
            get { return TRAMIT_FUNCION_ASIG_INF_COMPCollection.TRAMITE_TIPO_NOMBREColumnName; }
        }
        public static string VistaTramiteTitulo_NombreCol
        {
            get { return TRAMIT_FUNCION_ASIG_INF_COMPCollection.TRAMITE_TITULOColumnName; }
        }
        #endregion Accessors
    }
}
