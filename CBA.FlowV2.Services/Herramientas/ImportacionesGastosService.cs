using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ImportacionesGastosService
    {
        #region GetImportacionesGastosDataTable
        public DataTable GetImportacionesGastosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_GASTOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesGastosDataTable

        #region GetImportacionesGastosInfoCompleta
        public DataTable GetImportacionesGastosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_GASTOS_INFO_COMCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesGastosInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPORTACIONES_GASTOSRow row = new IMPORTACIONES_GASTOSRow();
                bool exito = false;
                try
                {
                    sesion.Db.BeginTransaction();

                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("importaciones_gastos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.IMPORTACIONES_GASTOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.COTIZACION = (decimal)campos[Cotizacion_NombreCol];
                    row.IMPORTACION_ID = (decimal)campos[ImportacionId_NombreCol];
                    row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                    row.MONTO = (decimal)campos[Monto_NombreCol];

                    if (campos.Contains(Observacion_NombreCol))
                        row.OBSERVACION = (string)campos[Observacion_NombreCol];
                    row.IMPUESTO_MONTO = (decimal)campos[ImpuestoMonto_NombreCol];
                    row.MONTO_APLICABLE = row.MONTO - row.IMPUESTO_MONTO;
                    if (campos.Contains(CasoId_NombreCol))
                    {
                        row.CASO_ID = (decimal)campos[CasoId_NombreCol];
                    }
                    else
                    {
                        row.IsCASO_IDNull = true;
                    }

                    if (insertarNuevo) sesion.Db.IMPORTACIONES_GASTOSCollection.Insert(row);
                    else sesion.Db.IMPORTACIONES_GASTOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    exito = true;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }

                return exito ? row.ID : Definiciones.Error.Valor.EnteroPositivo;
            }
        }
        #endregion Guardar

        #region Actualizar MontoGastoAplicable
        public static void ActualizarMontoGastoAplicable(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    IMPORTACIONES_GASTOSRow row = sesion.db.IMPORTACIONES_GASTOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                    row.MONTO_APLICABLE = (decimal)campos[MontoAplicable_NombreCol];
                    sesion.db.IMPORTACIONES_GASTOSCollection.Update(row);
                }
                catch 
                {
                    throw new Exception("Error al actualizar el monto Monto Aplicable");
                }
            }
        }
        #endregion Actualizar MontoGastoAplicable

        #region Borrar
        public void Borrar(decimal importacion_gasto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    IMPORTACIONES_GASTOSRow row;

                    row = sesion.Db.IMPORTACIONES_GASTOSCollection.GetByPrimaryKey(importacion_gasto_id);

                    sesion.Db.IMPORTACIONES_GASTOSCollection.DeleteByPrimaryKey(importacion_gasto_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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
            get { return "IMPORTACIONES_GASTOS"; }
        }
        public static string Id_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.COTIZACIONColumnName; }
        }
        public static string ImportacionId_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.IMPORTACION_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.MONTOColumnName; }
        }
        public static string ImpuestoMonto_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.IMPUESTO_MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.OBSERVACIONColumnName; }
        }
        public static string MontoAplicable_NombreCol
        {
            get { return IMPORTACIONES_GASTOSCollection.MONTO_APLICABLEColumnName; }
        }
        public static string VistaMoneda_NombreCol
        {
            get { return IMPORTACIONES_GASTOS_INFO_COMCollection.MONEDAColumnName; }
        }
        #endregion Accessors
    }
}
