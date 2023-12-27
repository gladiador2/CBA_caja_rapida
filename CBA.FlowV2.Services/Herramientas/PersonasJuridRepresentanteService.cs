using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasJuridRepresentanteService
    {
        #region GetPersonasJuridRepresentanteDataTable
        /// <summary>
        /// Gets the personas jurid representante data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetPersonasJuridRepresentanteDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_JURID_REPRESENTANTECollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasJuridRepresentanteDataTable

        #region GetPersonasJuridRepresentanteInfoCompleta
        /// <summary>
        /// Gets the personas jurid representante info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetPersonasJuridRepresentanteInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERS_JURID_REPRESENT_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasJuridRepresentanteInfoCompleta

        #region Guardar
        public virtual void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERSONAS_JURID_REPRESENTANTERow row = new PERSONAS_JURID_REPRESENTANTERow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.Db.GetSiguienteSecuencia("personas_jurid_represent_sqc");
                        row.PERSONA_ID = decimal.Parse(campos[PersonaId_NombreCol].ToString());
                        row.PERSONA_ID_REPRESENTANTE = decimal.Parse(campos[PersonaIdRepresentante_NombreCol].ToString());

                        if (insertarNuevo)
                            sesion.Db.PERSONAS_JURID_REPRESENTANTECollection.Insert(row);

                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                        sesion.Db.CommitTransaction();
                    }
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe otra persona con el mismo tipo y número de documento.");
                        default:
                            throw exp;
                    }
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
        public void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    
                    // Se borra el detalle
                    PERSONAS_JURID_REPRESENTANTERow row = sesion.Db.PERSONAS_JURID_REPRESENTANTECollection.GetByPrimaryKey(id);
                    sesion.Db.PERSONAS_JURID_REPRESENTANTECollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "PERSONAS_JURID_REPRESENTANTE"; }
        }
        public static string Id_NombreCol
        {
            get { return PERSONAS_JURID_REPRESENTANTECollection.IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PERSONAS_JURID_REPRESENTANTECollection.PERSONA_IDColumnName; }
        }
        public static string PersonaIdRepresentante_NombreCol
        {
            get { return PERSONAS_JURID_REPRESENTANTECollection.PERSONA_ID_REPRESENTANTEColumnName; }
        }
        public static string VistaPersonaApellido_NombreCol
        {
            get { return PERS_JURID_REPRESENT_INFO_COMPCollection.PERSONA_APELLIDOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return PERS_JURID_REPRESENT_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaRepresentanteApellido_NombreCol
        {
            get { return PERS_JURID_REPRESENT_INFO_COMPCollection.REPRESENTANTE_APELLIDOColumnName; }
        }
        public static string VistaRepresentanteNombre_NombreCol
        {
            get { return PERS_JURID_REPRESENT_INFO_COMPCollection.REPRESENTANTE_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
