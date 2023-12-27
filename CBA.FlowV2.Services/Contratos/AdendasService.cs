using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Contratos
{
    public class AdendasService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="legajo_id">The legajo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal adendas_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ADENDASRow row = sesion.Db.ADENDASCollection.GetByPrimaryKey(adendas_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region GetAdendasDataTable

        /// <summary>
        /// Gets the adendas data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAdendasDataTable()
        {
            return GetAdendasDataTable(string.Empty, Id_NombreCol, false);
        }

        /// <summary>
        /// Gets the adendas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetAdendasDataTable(String clausulas, String orden)
        {
            return GetAdendasDataTable(clausulas, orden, false);
        }


        /// <summary>
        /// Gets the adendas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetAdendasDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = "1=1";
                if (soloActivos) estado +=" and "+ Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.ADENDASCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.ADENDASCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        public DataTable GetAdendasInfoCompleta(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = "1=1";
                if (soloActivos) estado += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.ADENDAS_INFO_COMPLETACollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.ADENDAS_INFO_COMPLETACollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        #endregion GetTiposDeEntradaDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ADENDASRow row = new ADENDASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("adendas_sqc");
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                        row.FECHA = DateTime.Now;
                                               
                    }
                    else
                    {
                        row = sesion.Db.ADENDASCollection.GetByPrimaryKey(decimal.Parse(campos[AdendasService.Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    //campos obligatorios
                    row.CONTRATO_ID = decimal.Parse(campos[AdendasService.ContratoId_NombreCol].ToString());
                    row.TEXTO = campos[Texto_NombreCol].ToString();
                    row.APROBADO = campos[Aprobado_NombreCol].ToString();
                   
                    
                    //campos no obligatorios.
                    string nuevoEstado =  campos[Estado_NombreCol].ToString();
                    if (row.ESTADO.Equals(Definiciones.Estado.Inactivo) && nuevoEstado.Equals(Definiciones.Estado.Activo)) 
                    {
                        throw new System.ArgumentException("No reactivar la adenda una adenda anulada");
                        
                    }
                    row.ESTADO = campos[Estado_NombreCol].ToString();


                   

                    if (row.APROBADO.Equals(Definiciones.SiNo.Si))
                    {
                        row.USUARIO_APROBACION_ID = sesion.Usuario_Id;
                        row.FECHA_APROBACION = DateTime.Now;
                    }

                    if (row.ESTADO.Equals(Definiciones.Estado.Inactivo)) 
                    {
                        row.USUARIO_ANULACION_ID = sesion.Usuario_Id;
                        row.FECHA_ANULACION = DateTime.Now;
                    }

                   

                   


                    if (insertarNuevo) sesion.Db.ADENDASCollection.Insert(row);
                    else sesion.Db.ADENDASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe un registro con ese nombre.");
                        default: throw exp;
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

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "ADENDAS"; }
        }
        public static string Id_NombreCol
        { 
            get { return ADENDASCollection.IDColumnName; } 
        }
        public static string ContratoId_NombreCol
        {
            get { return ADENDASCollection.CONTRATO_IDColumnName; }
        }
        public static string Aprobado_NombreCol
        {
            get { return ADENDASCollection.APROBADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ADENDASCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ADENDASCollection.FECHAColumnName; }
        }
        public static string Texto_NombreCol
        {
            get { return ADENDASCollection.TEXTOColumnName; }
        }
        public static string UsuarioCreacionID_NombreCol
        {
            get { return ADENDASCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string UsuarioAprobacionID_NombreCol
        {
            get { return ADENDASCollection.USUARIO_APROBACION_IDColumnName; }
        }
        public static string UsuarioAnulacionId_NombreCol
        {
            get { return ADENDASCollection.USUARIO_ANULACION_IDColumnName; }
        }
        public static string FechaAprobacion_NombreCol
        {
            get { return ADENDASCollection.FECHA_APROBACIONColumnName; }
        }
        public static string FechaAnulacion_NombreCol
        {
            get { return ADENDASCollection.FECHA_ANULACIONColumnName; }
        }      

        #endregion Tabla
        #region Vista
        public static string VistaUsuarioCreacion_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.USUARIO_CREACIONColumnName; }
        }
        public static string VistaUsuarioAprobacion_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.USUARIO_APROBACIONColumnName; }
        }
        public static string VistaUsuarioAnulacion_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.USUARIO_ANULACIONColumnName; }
        }
        public static string VistaFechaCreacion_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.FECHA_CREACIONColumnName; }
        }
        public static string VistaFechaAprobacion_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.FECHA_APROBACIONColumnName; }
        }
        public static string VistaFechaAnulacion_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.FECHA_ANULACIONColumnName; }
        }
        public static string VistaEstado_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.ESTADOColumnName; }
        }
        public static string VistaTexto_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.TEXTOColumnName; }
        }
        public static string VistaAprobado_NombreCol
        {
            get { return ADENDAS_INFO_COMPLETACollection.APROBADOColumnName; }
        }
        #endregion Vista
        #endregion Accessors
    }
}
