using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;
using System.Data;
using System.Collections;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class DescuentosLlegadasTardiasDetallesService
    {
        #region Getters
        public static DataTable GetDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(string.Empty); 
            }
        }
        public static DataTable GetDataTable(string where)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetDataTable(where, string.Empty);
            }
        }
        public static DataTable GetDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.DESCUENTOS_LLEGADAS_TAR_DETCollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion Getters

        #region Guardar
        public static void Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    DESCUENTOS_LLEGADAS_TAR_DETRow row = new DESCUENTOS_LLEGADAS_TAR_DETRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.db.GetSiguienteSecuencia("DESCUENTOS_LLEG_TAR_DET_SQC");
                    }
                    else
                    {
                        row = sesion.db.DESCUENTOS_LLEGADAS_TAR_DETCollection.GetByPrimaryKey((decimal)campos[DescuentosLlegadasTardiasDetallesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.DESCUENTO_LLEGADA_TARDIA_ID = (decimal)campos[DescuentosLlegadasTardiasDetallesService.DescuentoLlegadaTardiaId_NombreCol];
                    row.ESTADO = (string)campos[DescuentosLlegadasTardiasDetallesService.Estado_NombreCol];

                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Monto_Descuento_NombreCol))
                        row.MONTO_DESCUENTO = (decimal)campos[DescuentosLlegadasTardiasDetallesService.Monto_Descuento_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Horas_Penalizadas_NombreCol))
                        row.HORAS_PENALIZADAS = (DateTime)campos[DescuentosLlegadasTardiasDetallesService.Horas_Penalizadas_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Punto_Inicio_NombreCol))
                        row.PUNTO_INICIO = (decimal)campos[DescuentosLlegadasTardiasDetallesService.Punto_Inicio_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Punto_Fin_NombreCol))
                        row.PUNTO_FIN = (decimal)campos[DescuentosLlegadasTardiasDetallesService.Punto_Fin_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Tiempo_Inicio_NombreCol))
                        row.TIEMPO_INICIO = (DateTime)campos[DescuentosLlegadasTardiasDetallesService.Tiempo_Inicio_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Tiempo_Fin_NombreCol))
                        row.TIEMPO_FIN = (DateTime)campos[DescuentosLlegadasTardiasDetallesService.Tiempo_Fin_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Mensaje_NombreCol))
                        row.MENSAJE = (string)campos[DescuentosLlegadasTardiasDetallesService.Mensaje_NombreCol];
                    if (campos.Contains(DescuentosLlegadasTardiasDetallesService.Observacion_NombreCol))
                        row.OBSERVACION = (string)campos[DescuentosLlegadasTardiasDetallesService.Observacion_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.DESCUENTOS_LLEGADAS_TAR_DETCollection.Insert(row);
                    else
                        sesion.Db.DESCUENTOS_LLEGADAS_TAR_DETCollection.Update(row);

                    LogCambiosService.LogDeRegistro(DescuentosLlegadasTardiasDetallesService.Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
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

        #region Borrar
        public static void Borrar(decimal IdDetalle)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    DESCUENTOS_LLEGADAS_TAR_DETRow row = new DESCUENTOS_LLEGADAS_TAR_DETRow();
                    row = sesion.db.DESCUENTOS_LLEGADAS_TAR_DETCollection.GetByPrimaryKey(IdDetalle);
                    String valorAnterior = row.ToString();
                    sesion.Db.DESCUENTOS_LLEGADAS_TAR_DETCollection.DeleteByPrimaryKey(IdDetalle);
                    LogCambiosService.LogDeRegistro(DescuentosLlegadasTardiasService.Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion

        #region Accesors
        public static string Nombre_Tabla
        {
            get { { return "descuentos_llegadas_tar_det"; } }
        }
        public static string Id_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.IDColumnName; } }
        }
        public static string DescuentoLlegadaTardiaId_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.DESCUENTO_LLEGADA_TARDIA_IDColumnName; } }
        }
        public static string Monto_Descuento_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.MONTO_DESCUENTOColumnName; } }
        }
        public static string Horas_Penalizadas_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.HORAS_PENALIZADASColumnName; } }
        }
        public static string Punto_Inicio_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.PUNTO_INICIOColumnName; } }
        }
        public static string Punto_Fin_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.PUNTO_FINColumnName; } }
        }
        public static string Tiempo_Inicio_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.TIEMPO_INICIOColumnName; } }
        }
        public static string Tiempo_Fin_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.TIEMPO_FINColumnName; } }
        }
        public static string Mensaje_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.MENSAJEColumnName; } }
        }
        public static string Estado_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.ESTADOColumnName; } }
        }
        public static string Observacion_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TAR_DETCollection.OBSERVACIONColumnName; } }
        }
        #endregion Accesors
    }
}
