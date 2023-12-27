#region Using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
using CBA.FlowV2.Services.Tramites;
using CBA.FlowV2.Services.Common;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Service.Tramites
{
    public class TramitesActividadesDetallesService
    {
        #region GetDatatable
        public static DataTable GetTramitesActividadesDetallesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TRAMITES_ACTIVIDADES_DETALLESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetDatatable

        #region Guardar
        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal detalle_id = Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    return detalle_id;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static decimal Guardar(Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                TRAMITES_ACTIVIDADES_DETALLESRow row = new TRAMITES_ACTIVIDADES_DETALLESRow();
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("tramites_actividades_det_sqc");
                    row.TRAMITE_ACTIVIDAD_ID = (decimal)campos[TramitesActividadesDetallesService.TramiteActividadId_NombreCol];
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.TRAMITES_ACTIVIDADES_DETALLESCollection.GetByPrimaryKey((decimal)campos[TramitesActividadesService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                if (!Interprete.EsNullODBNull(campos[TramitesActividadesDetallesService.FuncionarioId_NombreCol]))
                    row.FUNCIONARIO_ID = (decimal)campos[TramitesActividadesDetallesService.FuncionarioId_NombreCol];
                else
                    row.IsFUNCIONARIO_IDNull = true;

                if (campos.Contains(TramitesActividadesDetallesService.FechaInicio_NombreCol))
                    row.FECHA_INICIO = (DateTime)campos[TramitesActividadesDetallesService.FechaInicio_NombreCol];
                else
                    row.IsFECHA_INICIONull = true;

                if (campos.Contains(TramitesActividadesDetallesService.FechaFin_NombreCol))
                    row.FECHA_FIN = (DateTime)campos[TramitesActividadesDetallesService.FechaFin_NombreCol];
                else
                    row.IsFECHA_FINNull = true;

                if (campos.Contains(TramitesActividadesDetallesService.CantidadHoras_NombreCol))
                    row.CANTIDAD_HORAS = (decimal)campos[TramitesActividadesDetallesService.CantidadHoras_NombreCol];
                else
                    row.IsCANTIDAD_HORASNull = true;

                row.OBSERVACION = (string)campos[TramitesActividadesDetallesService.Observacion_NombreCol];

                if (campos.Contains(TramitesActividadesDetallesService.MonedaId_NombreCol) && campos.Contains(TramitesActividadesDetallesService.Monto_NombreCol))
                {
                    row.MONEDA_ID = (decimal)campos[TramitesActividadesDetallesService.MonedaId_NombreCol];
                    row.MONTO = (decimal)campos[TramitesActividadesDetallesService.Monto_NombreCol];
                }
                else
                {
                    row.IsMONEDA_IDNull = true;
                    row.IsMONTONull = true;
                }

                if (insertarNuevo)
                    sesion.Db.TRAMITES_ACTIVIDADES_DETALLESCollection.Insert(row);
                else
                    sesion.Db.TRAMITES_ACTIVIDADES_DETALLESCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    Borrar(detalle_id, sesion);
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Borrar(decimal detalle_id, SessionService sesion)
        {
            try
            {
                sesion.Db.BeginTransaction();
                TRAMITES_ACTIVIDADES_DETALLESRow row = new TRAMITES_ACTIVIDADES_DETALLESRow();

                row = sesion.Db.TRAMITES_ACTIVIDADES_DETALLESCollection.GetByPrimaryKey(detalle_id);
                string valorAnterior = row.ToString();
                string valorNuevo = Definiciones.Log.RegistroBorrado;

                sesion.Db.TRAMITES_ACTIVIDADES_DETALLESCollection.DeleteByPrimaryKey(detalle_id);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                sesion.Db.CommitTransaction();
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRAMITES_ACTIVIDADES_DETALLES"; }
        }

        public static string Id_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.IDColumnName; }
        }

        public static string FuncionarioId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.FUNCIONARIO_IDColumnName; }
        }

        public static string FechaInicio_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.FECHA_INICIOColumnName; }
        }

        public static string FechaFin_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.FECHA_FINColumnName; }
        }

        public static string CantidadHoras_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.CANTIDAD_HORASColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.MONTOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.OBSERVACIONColumnName; }
        }

        public static string TramiteActividadId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.TRAMITE_ACTIVIDAD_IDColumnName; }
        }

        public static string TextoPredifinidoId_NombreCol
        {
            get { return TRAMITES_ACTIVIDADES_DETALLESCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        #endregion Accessors
    }
}