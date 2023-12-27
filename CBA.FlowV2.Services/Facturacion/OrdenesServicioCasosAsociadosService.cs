#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class OrdenesServicioCasosAsociadosService
    {
        #region GetOrdenesServicioCasosAsocDataTable
        /// <summary>
        /// Gets the ordenes servicio detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioCasosAsocDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERVICIO_CASOS_ASOCCollection.GetAsDataTable(clausula, orden);
            }
        }
        
        #endregion GetUsoDeInsumosCasosAsocDataTable

        #region GetOrdenesServicioCasosAsocInfoCompleta
        /// <summary>
        /// Gets the ordenes servicio detalle info completa static.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetOrdenesServicioCasosAsocInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ORDENES_SERV_CAS_ASOC_INF_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetOrdenesServicioCasosAsocInfoCompleta

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {

            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                } 
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
            
        }
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <param name="sesion">The sesion.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            ORDENES_SERVICIO_CASOS_ASOCRow row = new ORDENES_SERVICIO_CASOS_ASOCRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ordenes_servicio_cas_asoc_sqc");
                row.ORDEN_SERVICIO_ID = (decimal)campos[OrdenesServicioCasosAsociadosService.OrdenServicioId_NombreCol];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.ORDENES_SERVICIO_CASOS_ASOCCollection.GetRow(OrdenesServicioCasosAsociadosService.Id_NombreCol + " = " + campos[OrdenesServicioCasosAsociadosService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }

            DataTable casos = CasosService.GetCasosInfoCompleta(CasosService.Id_NombreCol + " = " + (decimal)campos[OrdenesServicioCasosAsociadosService.CasoId_NombreCol], string.Empty, sesion);
            if (casos.Rows.Count > 0)
                row.CASO_ID = (decimal)campos[OrdenesServicioCasosAsociadosService.CasoId_NombreCol];
            else
                throw new Exception("No existe un caso con ese número.");

            row.FECHA_AGREGADO = (DateTime)campos[OrdenesServicioCasosAsociadosService.FechaAgregado_NombreCol];
            row.USUARIO_ID = sesion.Usuario_Id;

            if (campos.Contains(OrdenesServicioCasosAsociadosService.Observacion_NombreCol))
                row.OBSERVACION = (string)campos[OrdenesServicioCasosAsociadosService.Observacion_NombreCol];
            else
                row.OBSERVACION = string.Empty;

            if (campos.Contains(OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol))
                row.CONSIDERAR_COMO_PAGO = (string)campos[OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol];
            else
                row.CONSIDERAR_COMO_PAGO = string.Empty;

            if (campos.Contains(OrdenesServicioCasosAsociadosService.Editable_NombreCol))
                row.EDITABLE = (string)campos[OrdenesServicioCasosAsociadosService.Editable_NombreCol];
            else
                row.EDITABLE = Definiciones.SiNo.Si;

            if (insertarNuevo) sesion.Db.ORDENES_SERVICIO_CASOS_ASOCCollection.Insert(row);
            else sesion.Db.ORDENES_SERVICIO_CASOS_ASOCCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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
                    ORDENES_SERVICIO_CASOS_ASOCRow row = new ORDENES_SERVICIO_CASOS_ASOCRow();
                    row = sesion.Db.ORDENES_SERVICIO_CASOS_ASOCCollection.GetByPrimaryKey(detalles_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.ORDENES_SERVICIO_CASOS_ASOCCollection.DeleteByPrimaryKey(detalles_id);
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

        #region SetCasoConsideradoPago
        public static void SetCasoConsideradoPago(decimal orden_servicio_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Hashtable campos = new Hashtable();
                campos.Add(OrdenesServicioCasosAsociadosService.OrdenServicioId_NombreCol, orden_servicio_id);
                campos.Add(OrdenesServicioCasosAsociadosService.CasoId_NombreCol, caso_id);
                campos.Add(OrdenesServicioCasosAsociadosService.FechaAgregado_NombreCol, DateTime.Now);
                campos.Add(OrdenesServicioCasosAsociadosService.UsuarioId_NombreCol, sesion.Usuario_Id);
                campos.Add(OrdenesServicioCasosAsociadosService.Observacion_NombreCol, "Factura generada por plan de facturación");
                campos.Add(OrdenesServicioCasosAsociadosService.ConsiderarComoPago_NombreCol, Definiciones.SiNo.Si);
                OrdenesServicioCasosAsociadosService.Guardar(campos, true);
            }
        }
        #endregion SetCasoConsideradoPago

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ORDENES_SERVICIO_CASOS_ASOC"; }
        }
        public static string Nombre_Vista
        {
            get { return "ORDENES_SERV_CAS_ASOC_INF_COMP"; }
        }
        public static string CasoId_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.CASO_IDColumnName; }
        }
        public static string ConsiderarComoPago_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.CONSIDERAR_COMO_PAGOColumnName; }
        }
        public static string FechaAgregado_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.FECHA_AGREGADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.OBSERVACIONColumnName; }
        }
        public static string OrdenServicioId_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.ORDEN_SERVICIO_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.USUARIO_IDColumnName; }
        }
        public static string Editable_NombreCol
        {
            get { return ORDENES_SERVICIO_CASOS_ASOCCollection.EDITABLEColumnName; }
        }
        public static string VistaFlujoAsociadoId_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.FLUJO_ASOCIADO_IDColumnName; }
        }
        public static string VistaFlujoAsociadoDesc_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.FLUJO_ASOCIADO_DESCColumnName; }
        }
        public static string VistaOrdenServicioCasoId_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.ORDEN_SERVICIO_CASOColumnName; }
        }
        public static string VistaOrdenServicioTipo_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.ORDEN_SERVICIO_TIPOColumnName; }
        }
        public static string VistaOrdenServicioTitulo_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.ORDEN_SERVICIO_TITULOColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaCasoAsociadoEstadoId_NombreCol
        {
            get { return ORDENES_SERV_CAS_ASOC_INF_COMPCollection.CASO_ASOCIADO_ESTADO_IDColumnName; }
        }
        #endregion Accessors
    }
}




