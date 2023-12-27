using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class TipoEntradaLegajoService
    {
        #region EstaActivo



        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="tipo_entrada_id">The tipo_entrada_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal tipo_entrada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_ENTRADA_LEGAJORow row = sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.GetByPrimaryKey(tipo_entrada_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo


        #region UsaFechaInicio
        public bool UsaFechaInicio(decimal tipo_entrada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_ENTRADA_LEGAJORow row = sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.GetByPrimaryKey(tipo_entrada_id);
                if (row.REQUEIRE_FECHA_INICIO.Equals(Definiciones.SiNo.Si)) return true;
                else return false;
            }
        }
        #endregion UsaFechaInicio

        #region UsaFechaFin
        public bool UsaFechaFin(decimal tipo_entrada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_ENTRADA_LEGAJORow row = sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.GetByPrimaryKey(tipo_entrada_id);
                if (row.REQUIERE_FECHA_FIN.Equals(Definiciones.SiNo.Si)) return true;
                else return false;
            }
        }
        #endregion UsaFechaFin

        #region GetTiposDeEntradaDataTable



        /// <summary>
        /// Gets the tipos de entrada data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetTiposDeEntradaDataTable()
        {
            return GetTiposDeEntradaDataTable(string.Empty, Orden_NombreCol, false);
        }


        /// <summary>
        /// Gets the tipos de entrada data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetTiposDeEntradaDataTable(String clausulas, String orden)
        {
            return GetTiposDeEntradaDataTable(clausulas, orden, false);
        }


        /// <summary>
        /// Gets the tipos de entrada data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetTiposDeEntradaDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = EntidadId_NombreCol+" = "+ sesion.Entidad.ID;
                if (soloActivos) estado +=" and "+ Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.GetAsDataTable(estado, orden);
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

                    TIPOS_ENTRADA_LEGAJORow row = new TIPOS_ENTRADA_LEGAJORow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("tipos_entrada_legajo_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                        row.EDITABLE = Definiciones.SiNo.Si;
                        //El nombre es el ID principal, por lo que no puede
                        //modificarse si el registro ya estaba creado
                        
                    }
                    else
                    {
                        row = sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    if (campos.Contains(Descripcion_NombreCol)) row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                    else row.DESCRIPCION = string.Empty;

                    row.REQUEIRE_FECHA_INICIO = campos[RequiereFechaInicio_NombreCol].ToString();
                    row.REQUIERE_FECHA_FIN = campos[RequiereFechaFin_NombreCol].ToString();

                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.ORDEN = decimal.Parse(campos[Orden_NombreCol].ToString());


                    if (insertarNuevo) sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.Insert(row);
                    else sesion.Db.TIPOS_ENTRADA_LEGAJOCollection.Update(row);

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
        public static string Nombre_Tabla
        {
            get { return "TIPOS_ENTRADA_LEGAJO"; }
        }
        public static string Descripcion_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.DESCRIPCIONColumnName; } }

        public static string EntidadId_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.ENTIDAD_IDColumnName; } }

        public static string Estado_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.ESTADOColumnName; } }

        public static string Id_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.IDColumnName; } }

        public static string Nombre_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.NOMBREColumnName; } }

        public static string Orden_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.ORDENColumnName; } }

        public static string Editable_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.EDITABLEColumnName; } }

        public static string RequiereFechaInicio_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.REQUEIRE_FECHA_INICIOColumnName; } }
        
        public static string RequiereFechaFin_NombreCol
        { get { return TIPOS_ENTRADA_LEGAJOCollection.REQUIERE_FECHA_FINColumnName; } }
        
        

      

        #endregion Accessors
    }
}
