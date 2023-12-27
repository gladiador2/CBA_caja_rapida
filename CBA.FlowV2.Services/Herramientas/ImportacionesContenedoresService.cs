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
    public class ImportacionesContenedoresService
    {
        #region GetImportacionesContenedoresDataTable
        public DataTable GetImportacionesContenedoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_CONTENEDORESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesContenedoresDataTable

        #region GetImportacionesContenedoresInfoCompleta
        public DataTable GetImportacionesContenedoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.IMPORTACIONES_CONTEN_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetImportacionesContenedoresInfoCompleta

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
                IMPORTACIONES_CONTENEDORESRow row = new IMPORTACIONES_CONTENEDORESRow();
                bool exito = false;
                try
                {
                    sesion.Db.BeginTransaction();

                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("importaciones_contenedores_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.IMPORTACIONES_CONTENEDORESCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.CANTIDAD_CAJAS = (decimal)campos[CantidadCajas_NombreCol];
                    row.CANTIDAD = (decimal)campos[Cantidad_NombreCol];
                    row.IMPORTACION_ID = (decimal)campos[ImportacionId_NombreCol];
                    row.NOMBRE_INTERNO = (string)campos[NombreInterno_NombreCol];
                    row.SALDO = (decimal)campos[Saldo_NombreCol];
                    row.TIPO_CONTENEDOR_ID = (decimal)campos[TipoContenedorId_NombreCol];

                    if (insertarNuevo) sesion.Db.IMPORTACIONES_CONTENEDORESCollection.Insert(row);
                    else sesion.Db.IMPORTACIONES_CONTENEDORESCollection.Update(row);

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

        #region Borrar
        public void Borrar(decimal importacion_contenedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    IMPORTACIONES_CONTENEDORESRow row;

                    row = sesion.Db.IMPORTACIONES_CONTENEDORESCollection.GetByPrimaryKey(importacion_contenedor_id);

                    sesion.Db.IMPORTACIONES_CONTENEDORESCollection.DeleteByPrimaryKey(importacion_contenedor_id);
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
            get { return "IMPORTACIONES_CONTENEDORES"; }
        }
        public static string Id_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.IDColumnName; }
        }
        public static string CantidadCajas_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.CANTIDAD_CAJASColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.CANTIDADColumnName; }
        }
        public static string ImportacionId_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.IMPORTACION_IDColumnName; }
        }
        public static string NombreInterno_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.NOMBRE_INTERNOColumnName; }
        }
        public static string Saldo_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.SALDOColumnName; }
        }
        public static string TipoContenedorId_NombreCol
        {
            get { return IMPORTACIONES_CONTENEDORESCollection.TIPO_CONTENEDOR_IDColumnName; }
        }
        public static string VistaTipoContenedor_NombreCol
        {
            get { return IMPORTACIONES_CONTEN_INFO_COMPCollection.TIPO_CONTENEDOR_CLASIFICACIONColumnName; }
        }
        #endregion Accessors
    }
}
