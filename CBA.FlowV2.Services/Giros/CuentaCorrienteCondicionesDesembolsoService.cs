using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;

namespace CBA.FlowV2.Services.Giros
{
    public class CuentaCorrienteCondicionesDesembolsoService
    {
        public const string Desembolso_NombreCol = "DESEMBOLSO";

        #region EstaActivo
        public static bool EstaActivo(decimal red_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_DESEMBOLSORow condicion = sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.GetRow(Id_NombreCol + " = " + red_id);
                return condicion.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                sesion.Db.BeginTransaction();

                CTACTE_CONDICIONES_DESEMBOLSORow row = new CTACTE_CONDICIONES_DESEMBOLSORow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_COND_DESEMBOLSO_SQC");
                }
                else
                {
                    row = sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                row.NOMBRE = campos[Nombre_NombreCol].ToString();
                row.ESTADO = campos[Estado_NombreCol].ToString();
                row.CANTIDAD_CUOTAS = decimal.Parse(campos[CantidadCuotas_NombreCol].ToString());
                row.DESCRIPCION = campos[Descripcion_NombreCol].ToString();
                row.TIPO_CALCULO = campos[TipoCalculo_NombreCol].ToString();

                if (campos.Contains(FechaDesembolso1_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_1 = (decimal)campos[FechaDesembolso1_NombreCol];
                }
                if (campos.Contains(FechaDesembolso2_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_2 = (decimal)campos[FechaDesembolso2_NombreCol];
                }
                if (campos.Contains(FechaDesembolso3_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_3 = (decimal)campos[FechaDesembolso3_NombreCol];
                }
                if (campos.Contains(FechaDesembolso4_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_4 = (decimal)campos[FechaDesembolso4_NombreCol];
                }
                if (campos.Contains(FechaDesembolso4_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_5 = (decimal)campos[FechaDesembolso5_NombreCol];
                }
                if (campos.Contains(FechaDesembolso6_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_6 = (decimal)campos[FechaDesembolso6_NombreCol];
                }
                if (campos.Contains(FechaDesembolso7_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_7 = (decimal)campos[FechaDesembolso7_NombreCol];
                }
                if (campos.Contains(FechaDesembolso7_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_8 = (decimal)campos[FechaDesembolso8_NombreCol];
                }
                if (campos.Contains(FechaDesembolso9_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_9 = (decimal)campos[FechaDesembolso9_NombreCol];
                }
                if (campos.Contains(FechaDesembolso10_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_10 = (decimal)campos[FechaDesembolso10_NombreCol];
                }
                if (campos.Contains(FechaDesembolso11_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_11 =(decimal)campos[FechaDesembolso11_NombreCol];
                }
                if (campos.Contains(FechaDesembolso12_NombreCol))
                {
                    row.FECHA_DESEMBOLSO_12 = (decimal)campos[FechaDesembolso12_NombreCol];
                }

                if (insertarNuevo) sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.Insert(row);
                else sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                sesion.Db.CommitTransaction();
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }
        #endregion Guardar

        #region GetCondicionesDesembolso
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetCondicionesDesembolso(string orden, bool soloActivos)
        {
            string where = string.Empty;
            if (soloActivos) where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            return GetCondicionesDesembolso(where, orden);
        }

        public static DataTable GetCondicionesDesembolso(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetCondicionesDesembolso

        #region GetPlazosDesembolsos
        public static DataTable GetPlazosDesembolsos(decimal idCondicion)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(Desembolso_NombreCol, typeof(string));

            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_DESEMBOLSORow condicion = sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.GetByPrimaryKey(idCondicion);

                for (int i = 0; i < condicion.CANTIDAD_CUOTAS; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_1);
                            break;

                        case 1:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_2);
                            break;
                        case 2:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_3);
                            break;
                        case 3:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_4);
                            break;
                        case 4:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_5);
                            break;
                        case 5:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_6);
                            break;
                        case 6:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_7);
                            break;
                        case 7:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_8);
                            break;
                        case 8:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_9);
                            break;
                        case 9:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_10);
                            break;
                        case 10:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_11);
                            break;
                        case 11:
                            dt.Rows.Add(condicion.FECHA_DESEMBOLSO_12);
                            break;
                    }

                }
            }
            return dt;
        }
        #endregion GetPlazosDesembolsos

        #region GetCantidadPagos
        public static decimal GetCantidadCuotas(decimal idCondicion)
        {

            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_DESEMBOLSORow condicion = sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.GetByPrimaryKey(idCondicion);
                return condicion.CANTIDAD_CUOTAS;
            }

        }
        #endregion GetCantidadPagos

        #region GetTipoCalculo
        public static string GetTipoCalculo(decimal idCondicion)
        {

            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_DESEMBOLSORow condicion = sesion.Db.CTACTE_CONDICIONES_DESEMBOLSOCollection.GetByPrimaryKey(idCondicion);
                return condicion.TIPO_CALCULO;
            }

        }
        #endregion GetTipoCalculo

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CONDICIONES_DESEMBOLSO"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.IDColumnName; }
        }
        public static string CantidadCuotas_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.CANTIDAD_CUOTASColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.ESTADOColumnName; }
        }
        public static string FechaDesembolso1_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_1ColumnName; }
        }
        public static string FechaDesembolso2_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_2ColumnName; }
        }
        public static string FechaDesembolso3_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_3ColumnName; }
        }
        public static string FechaDesembolso4_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_4ColumnName; }
        }
        public static string FechaDesembolso5_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_5ColumnName; }
        }
        public static string FechaDesembolso6_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_6ColumnName; }
        }
        public static string FechaDesembolso7_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_7ColumnName; }
        }
        public static string FechaDesembolso8_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_8ColumnName; }
        }
        public static string FechaDesembolso9_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_9ColumnName; }
        }
        public static string FechaDesembolso10_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_10ColumnName; }
        }
        public static string FechaDesembolso11_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_11ColumnName; }
        }
        public static string FechaDesembolso12_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.FECHA_DESEMBOLSO_12ColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.NOMBREColumnName; }
        }
        public static string TipoCalculo_NombreCol
        {
            get { return CTACTE_CONDICIONES_DESEMBOLSOCollection.TIPO_CALCULOColumnName; }
        }
        #endregion Tabla

        #endregion Accessors
    }
}
