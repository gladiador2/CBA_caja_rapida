using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Collections;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public abstract class DescuentosLlegadasTardiasService
    {
        public abstract decimal CalcularDescuentosPorFuncionarios(Hashtable camposDescuento);

        #region Getters
        public static decimal GetTipoPolitica(decimal politica_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DESCUENTOS_LLEGADAS_TARDIASRow row = new DESCUENTOS_LLEGADAS_TARDIASRow();
                row = sesion.db.DESCUENTOS_LLEGADAS_TARDIASCollection.GetByPrimaryKey(politica_id);
                return row.TIPO_REGLA;
            }
        }
        public static DataTable GetTipoReglaPorHorario(decimal horario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.DESCUENTOS_LLEGADAS_TARDIASCollection.GetByHORARIO_IDAsDataTable(horario_id);
            }
        }
        public static DataTable GetDataTable(string where)
        {
            return GetDataTable(where, string.Empty);
        }
        public static DataTable GetDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.DESCUENTOS_LLEGADAS_TARDIASCollection.GetAsDataTable(where,orderBy);
            }
        }
        public static DataTable GetDataTable()
        {
            return GetDataTable(string.Empty);
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
                    DESCUENTOS_LLEGADAS_TARDIASRow row = new DESCUENTOS_LLEGADAS_TARDIASRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.db.GetSiguienteSecuencia("descuentos_llegadas_tard_sqc");
                    }
                    else
                    {
                        row = sesion.db.DESCUENTOS_LLEGADAS_TARDIASCollection.GetByPrimaryKey((decimal)campos[DescuentosLlegadasTardiasService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.TIPO_REGLA = (decimal)campos[DescuentosLlegadasTardiasService.Tipo_Regla];
                    row.HORARIO_ID = (decimal)campos[DescuentosLlegadasTardiasService.Horario_Id_NombreCol];
                    row.ESTADO = campos[DescuentosLlegadasTardiasService.Estado_NombreCol].ToString();
                    row.APLICAR_TOLERANCIA = campos[DescuentosLlegadasTardiasService.Aplicar_Tolerancia_NombreCol].ToString();
                    row.APLICAR_DESC_MONTO_FIJO = campos[DescuentosLlegadasTardiasService.Aplicar_Desc_Monto_Fijo_NombreCol].ToString();
                    row.DESCRIPCION = campos[DescuentosLlegadasTardiasService.Descripcion_NombreCol].ToString();
                    row.ORDEN = (decimal)campos[DescuentosLlegadasTardiasService.Orden_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.DESCUENTOS_LLEGADAS_TARDIASCollection.Insert(row);
                    else
                        sesion.Db.DESCUENTOS_LLEGADAS_TARDIASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

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
        public static void Borrar(decimal IdPolitica)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    DESCUENTOS_LLEGADAS_TARDIASRow row = new DESCUENTOS_LLEGADAS_TARDIASRow();
                    row = sesion.db.DESCUENTOS_LLEGADAS_TARDIASCollection.GetByPrimaryKey(IdPolitica);
                    String valorAnterior = row.ToString();
                    sesion.Db.DESCUENTOS_LLEGADAS_TARDIASCollection.DeleteByPrimaryKey(IdPolitica);
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
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DESCUENTOS_LLEGADAS_TARDIAS"; }
        }
        public static string Id_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.IDColumnName; } }
        }
        public static string Tipo_Regla
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.TIPO_REGLAColumnName; } }
        }
        public static string Horario_Id_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.HORARIO_IDColumnName; } }
        }
        public static string Descripcion_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.DESCRIPCIONColumnName; } }
        }
        public static string Estado_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.ESTADOColumnName; } }
        }
        public static string Aplicar_Tolerancia_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.APLICAR_TOLERANCIAColumnName; } }
        }
        public static string Aplicar_Desc_Monto_Fijo_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.APLICAR_DESC_MONTO_FIJOColumnName; } }
        }
        public static string Orden_NombreCol
        {
            get { { return DESCUENTOS_LLEGADAS_TARDIASCollection.ORDENColumnName; } }
        }
        #endregion Accessors
    }
}
