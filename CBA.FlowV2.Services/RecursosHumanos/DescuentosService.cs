#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class DescuentosService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="descuento_id">The descuento_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal descuento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DESCUENTOSRow row = sesion.Db.DESCUENTOSCollection.GetByPrimaryKey(descuento_id);
                return row.ESTADO.Equals(Definiciones.Estado.Activo);
            }
        }
        #endregion EstaActivo

        #region EsUnica
        /// <summary>
        /// Eses the unica.
        /// </summary>
        /// <param name="descuento_id">The descuento_id.</param>
        /// <returns></returns>
        public static bool EsUnica(decimal descuento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DESCUENTOSRow row = sesion.Db.DESCUENTOSCollection.GetByPrimaryKey(descuento_id);
                return row.UNICA.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion EsUnica

        #region GetPorcentaje

        /// <summary>
        /// Gets the porcentaje.
        /// </summary>
        /// <param name="descuento_id">The descuento_id.</param>
        /// <returns></returns>
        public static decimal GetPorcentaje(decimal descuento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DESCUENTOSRow row = sesion.Db.DESCUENTOSCollection.GetByPrimaryKey(descuento_id);
                return row.PORCENTAJE_SUGERIDO;
            }
        }
        #endregion GetPorcentaje

        #region GetDescuentosDataTable



        /// <summary>
        /// Gets the descuentos data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDescuentosDataTable()
        {
            return GetDescuentosDataTable(string.Empty, Orden_NombreCol, false);
        }


        /// <summary>
        /// Gets the descuentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetDescuentosDataTable(String clausulas, String orden)
        {
            return GetDescuentosDataTable(clausulas, orden, false);
        }


        /// <summary>
        /// Gets the descuentos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetDescuentosDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = EntidadId_NombreCol+" = "+ sesion.Entidad.ID;
                if (soloActivos) estado +=" and "+ Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.DESCUENTOSCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.DESCUENTOSCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetDescuentosDataTable

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

                    DESCUENTOSRow row = new DESCUENTOSRow();
                    String valorAnterior = string.Empty;
                    bool modificable= true;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("descuentos_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                        //El nombre es el ID principal, por lo que no puede
                        //modificarse si el registro ya estaba creado
                        
                    }
                    else
                    {
                        row = sesion.Db.DESCUENTOSCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                        modificable= row.MODIFICABLE.Equals(Definiciones.SiNo.Si);
                    }

                    if (modificable) //Validar que el registro sea modificable
                    {
                        row.NOMBRE = campos[Nombre_NombreCol].ToString();
                        if (campos.Contains(Descripcion_NombreCol)) row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                        else row.DESCRIPCION = string.Empty;

                        row.UNICA = campos[Unica_NombreCol].ToString();
                        row.PORCENTAJE_SUGERIDO = decimal.Parse(campos[PorcentajeSugerido_NombreCol].ToString());
                        row.ESTADO = campos[Estado_NombreCol].ToString();
                        row.ORDEN = decimal.Parse(campos[Orden_NombreCol].ToString());
                        row.CONSUMO = campos[Consumo_NombreCol].ToString();
                        row.INCLUIR_A_AGUINALDO = campos[IncluirAAguinaldo_NombreCol].ToString();
                        if (campos.Contains(MonedaId_NombreCol))
                        {
                            row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                        }
                        if (campos.Contains(Monto_NombreCol))
                        {
                            row.MONTO = (decimal)campos[Monto_NombreCol];
                        }

                        if (campos.Contains(Modificable_NombreCol)) row.MODIFICABLE = campos[Modificable_NombreCol].ToString();

                        if (insertarNuevo) sesion.Db.DESCUENTOSCollection.Insert(row);
                        else sesion.Db.DESCUENTOSCollection.Update(row);

                        LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                        sesion.Db.CommitTransaction();
                    }
                    else
                        throw new Exception("Este registro no es modificable.");
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
            get { return "DESCUENTOS"; }
        }
        public static string Descripcion_NombreCol
        { get { return DESCUENTOSCollection.DESCRIPCIONColumnName; } }

        public static string EntidadId_NombreCol
        { get { return DESCUENTOSCollection.ENTIDAD_IDColumnName; } }

        public static string Estado_NombreCol
        { get { return DESCUENTOSCollection.ESTADOColumnName; } }

        public static string Nombre_NombreCol
        { get { return DESCUENTOSCollection.NOMBREColumnName; } }

        public static string Orden_NombreCol
        { get { return DESCUENTOSCollection.ORDENColumnName; } }

        public static string PorcentajeSugerido_NombreCol
        { get { return DESCUENTOSCollection.PORCENTAJE_SUGERIDOColumnName; } }

        public static string Id_NombreCol
        { get { return DESCUENTOSCollection.IDColumnName; } }

        public static string Unica_NombreCol
        { get { return DESCUENTOSCollection.UNICAColumnName; } }

        public static string Consumo_NombreCol
        { get { return DESCUENTOSCollection.CONSUMOColumnName; } }

        public static string Monto_NombreCol
        { get { return DESCUENTOSCollection.MONTOColumnName; } }

        public static string MonedaId_NombreCol
        { get { return DESCUENTOSCollection.MONEDA_IDColumnName; } }
        
        public static string Modificable_NombreCol
        { get { return DESCUENTOSCollection.MODIFICABLEColumnName; } }

        public static string IncluirAAguinaldo_NombreCol
        { get { return DESCUENTOSCollection.INCLUIR_A_AGUINALDOColumnName; } }

        #endregion Accessors
    }
}
