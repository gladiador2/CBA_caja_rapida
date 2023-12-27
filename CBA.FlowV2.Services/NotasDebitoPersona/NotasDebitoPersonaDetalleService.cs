using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.NotasCreditoPersona;

namespace CBA.FlowV2.Services.NotasDebitoPersona
{
    public class NotasDebitoPersonaDetalleService
    {
        #region GetNotaDebitoPersonaDetalleDataTable

        /// <summary>
        /// Gets the nota debito persona detalle data table.
        /// </summary>
        /// <param name="nota_debito_persona_id">The nota_debito_persona_id.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaDetalleDataTable(decimal nota_debito_persona_id)
        {
            return GetNotaDebitoPersonaDetalleDataTable(NotaDebitoId_NombreCol + " = " + nota_debito_persona_id, string.Empty);
        }

        /// <summary>
        /// Gets the nota debito persona detalle data tablee.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetNotaDebitoPersonaDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoPersonaDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoPersonaDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        

        public static DataTable GetNotaDebitoPersonaDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoPersonaDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoPersonaDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ND_PERSONA_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
        }
        #endregion GetNotaDebitoPersonaDetalleDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    NOTA_DEBITO_PERSONA_DETALLERow row = new NOTA_DEBITO_PERSONA_DETALLERow();
                    SucursalesService sucursal = new SucursalesService();
                    
                    string valorAnterior;
                    
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("NOTA_DEBITO_PERSONA_DET_SQC");
                    row.NOTA_DEBITO_PERSONA_ID = (decimal)campos[NotasDebitoPersonaDetalleService.NotaDebitoId_NombreCol];
                    row.FACTURA_RELACIONADA_ID = (decimal)campos[NotasDebitoPersonaDetalleService.FacturaRelacionadaId_NombreCol];


                    row.MONTO = (decimal)campos[NotasDebitoPersonaDetalleService.Monto_NombreCol];
                    row.PORCENTAJE_IMPUESTO = (decimal)campos[NotasDebitoPersonaDetalleService.ImpuestoPorcentje_NombreCol];
                    
                    if (row.PORCENTAJE_IMPUESTO != 0) 
                        row.MONTO_IMPUESTO = row.MONTO/ ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                    else 
                        row.MONTO_IMPUESTO= 0;
                    
                    row.DESCRIPCION = (string)campos[NotasDebitoPersonaDetalleService.Descripcion_NombreCol];

                    if (campos.Contains(NotasDebitoPersonaDetalleService.ActivoId_NombreCol))
                    {
                        row.ACTIVO_ID = decimal.Parse(campos[NotasDebitoPersonaDetalleService.ActivoId_NombreCol].ToString());
                    }
                    else 
                    {
                        row.IsACTIVO_IDNull = true;
                    }
                    
                    sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    NotasDebitoPersonaService.RecalcularTotal(row.NOTA_DEBITO_PERSONA_ID, sesion);
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
        /// Borrars the specified ctacte_pago_persona_detalle_id.
        /// </summary>
        /// <param name="nota_credito_persona_detalle_id">The nota_credito_persona_detalle_id.</param>
        public static void Borrar(decimal nota_debito_persona_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    NOTA_DEBITO_PERSONA_DETALLERow row;
              
                    //se obtiene l el detalle de la nota de credito
                    row = sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.GetByPrimaryKey(nota_debito_persona_detalle_id);
                
                    sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.DeleteByPrimaryKey(nota_debito_persona_detalle_id);
                   
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    NotasDebitoPersonaService.RecalcularTotal(row.NOTA_DEBITO_PERSONA_ID, sesion);

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
            get { return "NOTA_DEBITO_PERSONA_DETALLE"; }
        }
        public static string ActivoId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.ACTIVO_IDColumnName; }
        }       
        public static string Id_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.IDColumnName; }
        }
        
        public static string NotaDebitoId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.NOTA_DEBITO_PERSONA_IDColumnName; }
        }   
       
        public static string FacturaRelacionadaId_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.FACTURA_RELACIONADA_IDColumnName; }
        }

        public static string ImpuestoMonto_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.MONTO_IMPUESTOColumnName; }
        }

        public static string ImpuestoPorcentje_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }   

        public static string Monto_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.MONTOColumnName; }
        }

        public static string Descripcion_NombreCol
        {
            get { return NOTA_DEBITO_PERSONA_DETALLECollection.DESCRIPCIONColumnName; }
        }


        #region Vistas
        public static string VistaFacturaNumeroComprobante_NombreCol
        {
            get { return ND_PERSONA_DET_INFO_COMPLETACollection.FACTURA_NROCOMPROBANTEColumnName; }
        }
        public static string VistaActivoCodigo_NombreCol
        {
            get { return ND_PERSONA_DET_INFO_COMPLETACollection.ACTIVO_CODIGOColumnName; }
        }
        
       
        #endregion Vistas
        #endregion Accessors
    }
}
