using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Stock
{
    public class IngresoInsumosDetallesService 
    {
        #region GetIngresoInsumosDetalleDataTable
        public static DataTable GetIngresoInsumosDetalleDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.INGRESO_INSUMOS_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetIngresoInsumosDetalleDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    if (!campos.Contains(IngresoInsumosDetallesService.IngresoId_NombreCol))
                        throw new Exception("Debe indicar la cabecera.");
                    if (!campos.Contains(IngresoInsumosDetallesService.ArticuloId_NombreCol))
                        throw new Exception("Debe indicar el artículo.");                  
                    if (!campos.Contains(IngresoInsumosDetallesService.UnidadId_NombreCol))
                        throw new Exception("Debe indicar la unidad de medida.");                  

                    INGRESO_INSUMOS_DETALLESRow row = new INGRESO_INSUMOS_DETALLESRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("INGRESO_INSUMOS_DETALLES_SQC");
                        row.INGRESO_ID = (decimal)campos[IngresoInsumosDetallesService.IngresoId_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.INGRESO_INSUMOS_DETALLESCollection.GetRow(IngresoInsumosDetallesService.Id_NombreCol + " = " + campos[IngresoInsumosDetallesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.ARTICULO_ID = (decimal)campos[IngresoInsumosDetallesService.ArticuloId_NombreCol];
                    row.LOTE_ID = (decimal)campos[IngresoInsumosDetallesService.LoteId_NombreCol];
                    row.UNIDAD_ID = campos[IngresoInsumosDetallesService.UnidadId_NombreCol].ToString();

                    if (campos.Contains(IngresoInsumosDetallesService.PersonaId_NombreCol))
                        row.PERSONA_ID = (decimal)campos[IngresoInsumosDetallesService.PersonaId_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.BoxId_NombreCol))
                        row.BOX_ID = (decimal)campos[IngresoInsumosDetallesService.BoxId_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.Merma_NombreCol))
                        row.MERMA = (decimal)campos[IngresoInsumosDetallesService.Merma_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.CantidadBascula_NombreCol))
                        row.CANTIDAD_BASCULA = (decimal)campos[IngresoInsumosDetallesService.CantidadBascula_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.UsarCantidadBascula_NombreCol))
                        row.USAR_CANTIDAD_BASCULA = campos[IngresoInsumosDetallesService.UsarCantidadBascula_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.CantidadBl_NombreCol))
                        row.CANTIDAD_BL = (decimal)campos[IngresoInsumosDetallesService.CantidadBl_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.UsarCantidadBl_NombreCol))
                        row.USAR_CANTIDAD_BL = campos[IngresoInsumosDetallesService.UsarCantidadBl_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.CantidadDraft_NombreCol))
                        row.CANTIDAD_DRAFT = (decimal)campos[IngresoInsumosDetallesService.CantidadDraft_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.UsarCantidadDraft_NombreCol))
                        row.USAR_CANTIDAD_DRAFT = campos[IngresoInsumosDetallesService.UsarCantidadDraft_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.CantidadRemision_NombreCol))
                        row.CANTIDAD_REMISION = (decimal)campos[IngresoInsumosDetallesService.CantidadRemision_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.UsarCantidadRemision_NombreCol))
                        row.USAR_CANTIDAD_REMISION = campos[IngresoInsumosDetallesService.UsarCantidadRemision_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.ChapaCamion_NombreCol))
                        row.CHAPA_CAMION = campos[IngresoInsumosDetallesService.ChapaCamion_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.ChapaCarreta_NombreCol))
                        row.CHAPA_CARRETA = campos[IngresoInsumosDetallesService.ChapaCarreta_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.ChoferNombre_NombreCol))
                        row.CHOFER_NOMBRE = campos[IngresoInsumosDetallesService.ChoferNombre_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.ChoferDocumento_NombreCol))
                        row.CHOFER_DOCUMENTO = campos[IngresoInsumosDetallesService.ChoferDocumento_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.NroTicketBascula_NombreCol))
                        row.NRO_TICKET_BASCULA = campos[IngresoInsumosDetallesService.NroTicketBascula_NombreCol].ToString();
                    if (campos.Contains(IngresoInsumosDetallesService.PresentacionId_NombreCol))
                        row.PRESENTACION_ID = (decimal)campos[IngresoInsumosDetallesService.PresentacionId_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.CantidadPresentacion_NombreCol))
                        row.CANTIDAD_PRESENTACION = (decimal)campos[IngresoInsumosDetallesService.CantidadPresentacion_NombreCol];
                    if (campos.Contains(IngresoInsumosDetallesService.CantidadDePresentacion_NombreCol))
                        row.CANTIDAD_DE_PRESENTACION = (decimal)campos[IngresoInsumosDetallesService.CantidadDePresentacion_NombreCol];
                    
                    if (insertarNuevo) sesion.Db.INGRESO_INSUMOS_DETALLESCollection.Insert(row);
                    else sesion.Db.INGRESO_INSUMOS_DETALLESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    INGRESO_INSUMOS_DETALLESRow row = new INGRESO_INSUMOS_DETALLESRow();

                    row = sesion.Db.INGRESO_INSUMOS_DETALLESCollection.GetByPrimaryKey(detalles_id);
                    //Se borra las relaciones si existen

                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.INGRESO_INSUMOS_DETALLESCollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "INGRESO_INSUMOS_DETALLES"; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.ARTICULO_IDColumnName; }
        }
        public static string BoxId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.BOX_IDColumnName; }
        }
        public static string CantidadBascula_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CANTIDAD_BASCULAColumnName; }
        }
        public static string CantidadBl_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CANTIDAD_BLColumnName; }
        }
        public static string CantidadDraft_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CANTIDAD_DRAFTColumnName; }
        }
        public static string CantidadRemision_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CANTIDAD_REMISIONColumnName; }
        }
        public static string ChapaCamion_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CHAPA_CAMIONColumnName; }
        }
        public static string ChapaCarreta_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CHAPA_CARRETAColumnName; }
        }
        public static string ChoferDocumento_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CHOFER_DOCUMENTOColumnName; }
        }
        public static string ChoferNombre_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CHOFER_NOMBREColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.IDColumnName; }
        }
        public static string IngresoId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.INGRESO_IDColumnName; }
        }
        public static string LoteId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.LOTE_IDColumnName; }
        }
        public static string Merma_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.MERMAColumnName; }
        }
        public static string NroTicketBascula_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.NRO_TICKET_BASCULAColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.PERSONA_IDColumnName; }
        }
        public static string UnidadId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.UNIDAD_IDColumnName; }
        }
        public static string UsarCantidadBascula_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.USAR_CANTIDAD_BASCULAColumnName; }
        }
        public static string UsarCantidadBl_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.USAR_CANTIDAD_BLColumnName; }
        }
        public static string UsarCantidadDraft_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.USAR_CANTIDAD_DRAFTColumnName; }
        }
        public static string UsarCantidadRemision_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.USAR_CANTIDAD_REMISIONColumnName; }
        }
        public static string PresentacionId_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.PRESENTACION_IDColumnName; }
        }
        public static string CantidadPresentacion_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CANTIDAD_PRESENTACIONColumnName; }
        }
        public static string CantidadDePresentacion_NombreCol
        {
            get { return INGRESO_INSUMOS_DETALLESCollection.CANTIDAD_DE_PRESENTACIONColumnName; }
        }

        #endregion Accessors
    }
}
