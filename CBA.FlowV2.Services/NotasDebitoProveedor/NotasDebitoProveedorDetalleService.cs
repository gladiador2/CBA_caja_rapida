using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;

namespace CBA.FlowV2.Services.NotasDebitoProveedor
{
    public class NotasDebitoProveedorDetalleService
    {
        #region GetNotaDebitoProveedorDetalleDataTable
        public static DataTable GetNotaDebitoProveedorDetalleDataTable(decimal nota_debito_proveedor_id)
        {
            return GetNotaDebitoProveedorDetalleDataTable(NotaDebitoId_NombreCol + " = " + nota_debito_proveedor_id, string.Empty);
        }

        public static DataTable GetNotaDebitoProveedorDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoProveedorDetalleDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoProveedorDetalleDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.NOTA_DEBITO_PROVEEDOR_DETALLECollection.GetAsDataTable(clausulas, orden);
        }
        
        
        public static DataTable GetNotaDebitoProveedorDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNotaDebitoProveedorDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetNotaDebitoProveedorDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.ND_PROVEEDOR_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetNotaDebitoProveedorDetalleDataTable

        #region Guardar

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    NOTA_DEBITO_PROVEEDOR_DETALLERow row = new NOTA_DEBITO_PROVEEDOR_DETALLERow();
                    
                    string valorAnterior;
                    
                    valorAnterior = Definiciones.Log.RegistroNuevo;

                    row.ID = sesion.Db.GetSiguienteSecuencia("NOTA_DEBITO_PROVEEDOR_DET_SQC");
                    row.NOTA_DEBITO_PROVEEDOR_ID = decimal.Parse(campos[NotaDebitoId_NombreCol].ToString());
                    row.FACTURA_RELACIONADA_ID = decimal.Parse(campos[FacturaRelacionadaId_NombreCol].ToString());


                    row.MONTO = decimal.Parse(campos[Monto_NombreCol].ToString());
                    row.PORCENTAJE_IMPUESTO = decimal.Parse(campos[ImpuestoPorcentje_NombreCol].ToString());
                    if (row.PORCENTAJE_IMPUESTO != 0) row.MONTO_IMPUESTO = row.MONTO/ ((100 / row.PORCENTAJE_IMPUESTO) + 1);
                    else row.MONTO_IMPUESTO= 0;
                    row.DESCRIPCION =campos[Descripcion_NombreCol].ToString();
                    
                    if (campos.Contains(ActivoId_NombreCol))
                    {
                        row.ACTIVO_ID = decimal.Parse(campos[ActivoId_NombreCol].ToString());
                    }
                    else
                    {
                        row.IsACTIVO_IDNull = true;
                    }

                    sesion.Db.NOTA_DEBITO_PROVEEDOR_DETALLECollection.Insert(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    NotasDebitoProveedorService.RecalcularTotal(row.NOTA_DEBITO_PROVEEDOR_ID, sesion);
                    sesion.Db.CommitTransaction();
                   


                }
                catch (Exception )
                {
                    sesion.Db.RollbackTransaction();
                    throw ;
                }
            }
        }
        #endregion Guardar

        #region Borrar

        /// <summary>
        /// Borrars the specified nota_debito_proveedor_detalle_id.
        /// </summary>
        /// <param name="nota_debito_proveedor_detalle_id">The nota_debito_proveedor_detalle_id.</param>
        public static void Borrar(decimal nota_debito_proveedor_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    NOTA_DEBITO_PROVEEDOR_DETALLERow row;
              
                    //se obtiene l el detalle de la nota de credito
                    row = sesion.Db.NOTA_DEBITO_PROVEEDOR_DETALLECollection.GetByPrimaryKey(nota_debito_proveedor_detalle_id);
                
                    sesion.Db.NOTA_DEBITO_PERSONA_DETALLECollection.DeleteByPrimaryKey(nota_debito_proveedor_detalle_id);
                   
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    NotasDebitoProveedorService.RecalcularTotal(row.NOTA_DEBITO_PROVEEDOR_ID, sesion);

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

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "NOTA_DEBITO_PROVEEDOR_DETALLE"; }
        }      
        public static string Id_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.IDColumnName; }
        }
        public static string ActivoId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.ACTIVO_IDColumnName; }
        }  
        public static string NotaDebitoId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.NOTA_DEBITO_PROVEEDOR_IDColumnName; }
        }   
       
        public static string FacturaRelacionadaId_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.FACTURA_RELACIONADA_IDColumnName; }
        }

        public static string ImpuestoMonto_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.MONTO_IMPUESTOColumnName; }
        }

        public static string ImpuestoPorcentje_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.PORCENTAJE_IMPUESTOColumnName; }
        }   

        public static string Monto_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.MONTOColumnName; }
        }

        public static string Descripcion_NombreCol
        {
            get { return NOTA_DEBITO_PROVEEDOR_DETALLECollection.DESCRIPCIONColumnName; }
        }
        #endregion Tabla

        #region Vistas
        public static string VistaActivoCodigo_NombreCol
        {
            get { return ND_PROVEEDOR_DET_INFO_COMPLETACollection.ACTIVO_CODIGOColumnName; }
        }      
        public static string VistaFacturaNumeroComprobante_NombreCol
        {
            get { return ND_PROVEEDOR_DET_INFO_COMPLETACollection.FACTURA_NROCOMPROBANTEColumnName; }
        }      
        #endregion Vistas

        #endregion Accessors
    }
}
