#region Using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
#endregion Using

namespace CBA.FlowV2.Services.Tramites
{
    public class TramitesTiposService
    {
        #region GetTramitesTiposDataTable
        /// <summary>
        /// Gets the tramites tipos data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTramitesTiposDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_TIPOSCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetTramitesTiposDataTable
        
        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo) 
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    TRAMITES_TIPOSRow row = new TRAMITES_TIPOSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("tramites_tipos_sqc");
                    }
                    else
                    {
                        row = sesion.Db.TRAMITES_TIPOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //campos obligatorios
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.PRESUPUESTO_TOMA_ETAPAS = campos[PresupuestoTomaEtapas_NombreCol].ToString();

                    if (campos.Contains(MostrarAlcance_NombreCol))
                        row.MOSTRAR_ALCANCE = campos[MostrarAlcance_NombreCol].ToString();
                    if (campos.Contains(MostrarMedidas_NombreCol))
                        row.MOSTRAR_MEDIDAS = campos[MostrarMedidas_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.TRAMITES_TIPOSCollection.Insert(row);
                    else sesion.Db.TRAMITES_TIPOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
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
        public static void Borrar(decimal tramiteTipoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    TRAMITES_TIPOSRow fila = sesion.Db.TRAMITES_TIPOSCollection.GetByPrimaryKey(tramiteTipoId);

                    sesion.Db.TRAMITES_TIPOSCollection.DeleteByPrimaryKey(tramiteTipoId);
                    LogCambiosService.LogDeRegistro(TramitesTiposService.Nombre_Tabla, tramiteTipoId, fila.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    
                    //TODO borrar detalles asociados
                    string clausulasCascada = TramitesTiposCamposEtapasService.TramiteTipoId_NombreCol + " = " + tramiteTipoId.ToString();
                    DataTable camposABorrar = TramitesTiposCamposEtapasService.GetTramitesTiposCamposEtapasDataTable(clausulasCascada, TramitesTiposCamposEtapasService.Id_NombreCol);
                    foreach (DataRow dr in camposABorrar.Rows){
                        TramitesTiposCamposEtapasService.Borrar(decimal.Parse(dr[TramitesTiposCamposEtapasService.Id_NombreCol].ToString()), sesion);
                    }

                    sesion.CommitTransaction();

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
            get { return "TRAMITES_TIPOS"; }
        }
        public static string Id_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.ESTADOColumnName; }
        }
        public static string MostrarAlcance_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.MOSTRAR_ALCANCEColumnName; }
        }
        public static string MostrarMedidas_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.MOSTRAR_MEDIDASColumnName; }
        }
        public static string MostrasProfesionalesRecusados_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.MOSTRAR_PROF_RECUSADOSColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.NOMBREColumnName; }
        }
        public static string PresupuestoTomaEtapas_NombreCol
        {
            get { return TRAMITES_TIPOSCollection.PRESUPUESTO_TOMA_ETAPASColumnName; }
        }
        #endregion Accessors
    }
}
