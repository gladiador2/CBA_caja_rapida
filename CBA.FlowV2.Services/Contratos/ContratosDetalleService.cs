#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Contratos
{
    public class ContratosDetalleService
    {
        #region GetContratosDetalleDataTable


        /// <summary>
        /// Gets the contratos detalle data table.
        /// </summary>
        /// <param name="contrato_id">The contrato_id.</param>
        /// <returns></returns>
        public DataTable GetContratosDetalleDataTable(decimal contrato_id)
        {
            return GetContratosDetalleDataTable(ContratosDetalleService.ContratoId_NombreCol + " = " + contrato_id, string.Empty);
        }

        /// <summary>
        /// Gets the contratos detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetContratosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CONTRATOS_DETALLESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetContratosDetalleDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CONTRATOS_DETALLESRow row = new CONTRATOS_DETALLESRow();
                    SucursalesService sucursal = new SucursalesService();
                    string valorAnterior = string.Empty;
                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        row.ID = sesion.Db.GetSiguienteSecuencia("CONTRATOS_DETALLES_SQC");

                    }
                    else
                    {
                        valorAnterior = row.ToString();
                        row= sesion.Db.CONTRATOS_DETALLESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    }              
                    
                    row.CONTRATO_ID = decimal.Parse(campos[ContratoId_NombreCol].ToString());

                    if (campos.Contains(ContratosDetalleService.TituloEtapa_NombreCol))row.TITULO_ETAPA = campos[ContratosDetalleService.TituloEtapa_NombreCol].ToString();
                    if (campos.Contains(ContratosDetalleService.DescripcionEtapa_NombreCol)) row.DESCRIPCIO_ETAPA = campos[ContratosDetalleService.DescripcionEtapa_NombreCol].ToString();
                    if (campos.Contains(ContratosDetalleService.FechaInicio_NombreCol)) row.FECHA_INICIO= DateTime.Parse(campos[ContratosDetalleService.FechaInicio_NombreCol].ToString());
                    if (campos.Contains(ContratosDetalleService.FechaFin_NombreCol)) row.FECHA_FIN = DateTime.Parse(campos[ContratosDetalleService.FechaFin_NombreCol].ToString());
                    if (campos.Contains(ContratosDetalleService.EstadoEtapa_NombreCol)) row.ESTADO_ETAPA= campos[ContratosDetalleService.EstadoEtapa_NombreCol].ToString();
                    if (campos.Contains(ContratosDetalleService.RequerimientoCobro_NombreCol)) row.REQUERIMIENTO_COBRAR = campos[ContratosDetalleService.RequerimientoCobro_NombreCol].ToString();
                    if (campos.Contains(ContratosDetalleService.Cobrado_NombreCol)) row.COBRADO = campos[ContratosDetalleService.Cobrado_NombreCol].ToString();
                    if (campos.Contains(ContratosDetalleService.MontoEtapa_NombreCol)) row.MONTO_ETAPA = decimal.Parse(campos[ContratosDetalleService.MontoEtapa_NombreCol].ToString());

                    
                    
                    if(insertarNuevo)sesion.Db.CONTRATOS_DETALLESCollection.Insert(row);
                    else sesion.Db.CONTRATOS_DETALLESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

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


        /// <summary>
        /// Borrars the specified contrato_detalle_id.
        /// </summary>
        /// <param name="contrato_detalle_id">The contrato_detalle_id.</param>
        public void Borrar(decimal contrato_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CONTRATOS_DETALLESRow row;

                    row = sesion.Db.CONTRATOS_DETALLESCollection.GetByPrimaryKey(contrato_detalle_id);

                    sesion.Db.CONTRATOS_DETALLESCollection.DeleteByPrimaryKey(contrato_detalle_id);

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
            get { return "CONTRATOS_DETALLES"; }
        }

              
        public static string Id_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.IDColumnName; }
        }
        public static string ContratoId_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.CONTRATO_IDColumnName; }
        }
        public static string TituloEtapa_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.TITULO_ETAPAColumnName; }
        }
        public static string DescripcionEtapa_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.DESCRIPCIO_ETAPAColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.FECHA_INICIOColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.FECHA_FINColumnName; }
        }
        public static string EstadoEtapa_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.ESTADO_ETAPAColumnName; }
        }
        public static string MontoEtapa_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.MONTO_ETAPAColumnName; }
        }
        public static string RequerimientoCobro_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.REQUERIMIENTO_COBRARColumnName; }
        }
        public static string Cobrado_NombreCol
        {
            get { return CONTRATOS_DETALLESCollection.COBRADOColumnName; }
        }
        
        
        #endregion Accessors
    }
}
