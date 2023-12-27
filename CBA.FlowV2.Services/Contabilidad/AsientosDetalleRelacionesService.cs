#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosDetalleRelacionesService
    {
        #region GetAsientosDetalleRelacionesDataTable
        public static DataTable GetAsientosDetalleRelacionesDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_ASIENTOS_DETALLE_RELCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAsientosDetalleRelacionesDataTable

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_ASIENTOS_DETALLE_RELRow row = new CTB_ASIENTOS_DETALLE_RELRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_asientos_detalle_rel_sqc");
                    }
                    else
                    {
                        row = sesion.Db.CTB_ASIENTOS_DETALLE_RELCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (campos.Contains(AsientosDetalleRelacionesService.CtbAsientosDetalle_NombreCol))
                        row.CTB_ASIENTOS_DETALLE = (decimal)campos[AsientosDetalleRelacionesService.CtbAsientosDetalle_NombreCol];

                    if (campos.Contains(AsientosDetalleRelacionesService.RegistroRelacionadoId_NombreCol))
                        row.REGISTRO_RELACIONADO_ID = (decimal)campos[AsientosDetalleRelacionesService.RegistroRelacionadoId_NombreCol];

                    if (campos.Contains(AsientosDetalleRelacionesService.TablaRelacionadaId_NombreCol))
                        row.TABLA_RELACIONADA_ID = campos[AsientosDetalleRelacionesService.TablaRelacionadaId_NombreCol].ToString();

                    if (campos.Contains(AsientosDetalleRelacionesService.Monto_NombreCol))
                        row.MONTO = (decimal)campos[AsientosDetalleRelacionesService.Monto_NombreCol];

                    if (insertarNuevo)
                        sesion.Db.CTB_ASIENTOS_DETALLE_RELCollection.Insert(row);
                    else
                        sesion.Db.CTB_ASIENTOS_DETALLE_RELCollection.Update(row);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        #endregion Guardar

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_DETALLE_REL"; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_RELCollection.IDColumnName; }
        }
        public static string CtbAsientosDetalle_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_RELCollection.CTB_ASIENTOS_DETALLEColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_RELCollection.MONTOColumnName; }
        }
        public static string RegistroRelacionadoId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_RELCollection.REGISTRO_RELACIONADO_IDColumnName; }
        }
        public static string TablaRelacionadaId_NombreCol
        {
            get { return CTB_ASIENTOS_DETALLE_RELCollection.TABLA_RELACIONADA_IDColumnName; }
        }
        #endregion Accesors
    }
}
