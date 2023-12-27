using System;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Contabilidad;

namespace CBA.FlowV2.Services.Casos
{
    public class CambioEstadoCasoService
    {
        #region CambiarEstado
        /// <summary>
        /// Cambiars the estado.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="sesion_id">The sesion_id.</param>
        /// <param name="comentario">The comentario.</param>
        /// <param name="direccion_ip">The direccion_ip.</param>
        /// <returns>
        /// True o false segun haya tenido exito el cambio
        /// </returns>

        public bool CambiarEstado(decimal caso_id, string estado_destino, decimal usuario_id, decimal sesion_id, string comentario, string direccion_ip, SessionService sesion)
        {
            return ProcesarCambioEstado(estado_destino, caso_id, comentario, Definiciones.Error.Valor.EnteroPositivo, sesion_id, usuario_id, direccion_ip,sesion);
        }
        public bool CambiarEstado(decimal caso_id, string estado_destino, decimal usuario_id, decimal sesion_id, string comentario, decimal comentario_texto_id, string direccion_ip, SessionService sesion)
        {
            return ProcesarCambioEstado(estado_destino, caso_id, comentario, comentario_texto_id, sesion_id, usuario_id, direccion_ip, sesion);
        }

        public bool ProcesarCambioEstado(string estado_destino, Decimal caso_id, string comentario, decimal comentario_texto_id, Decimal sesion_id, Decimal usuario_id, string direccion_ip, SessionService sesion)
        {
            try
            {
                if (VerificarSesionUsuario(sesion_id.ToString(), sesion) != null)
                {

                    CASOSRow caso = sesion.db.CASOSCollection.GetByPrimaryKey(caso_id);
                    string where = TransicionesService.FlujoId_NombreCol + "=" + caso.FLUJO_ID;
                    where += " and " + TransicionesService.EstadoOrigenId_NombreCol + "='" + caso.ESTADO_ID+"'";
                    where += " and " + TransicionesService.EstadoDestinoId_NombreCol + "='" + estado_destino+"'";
                    TRANSICIONESRow[] transciones = sesion.db.TRANSICIONESCollection.GetAsArray(where, string.Empty);
                    FLUJOSRow flujo = sesion.db.FLUJOSCollection.GetByPrimaryKey(caso.FLUJO_ID);

                    if (transciones.Length > 0)
                    {
                        decimal operacion = OperacionesService.InsertarOperacion(caso_id, transciones[0].ID, estado_destino, caso.ESTADO_ID, Definiciones.TipoOperacion.PasoEstado, sesion.Usuario_Id, direccion_ip, DateTime.Now.ToString(), comentario,comentario_texto_id, sesion);

                       
                        caso.ESTADO_ANTERIOR_ID = caso.ESTADO_ID;
                        caso.ESTADO_ID = estado_destino;
                        caso.ULTIMO_USUARIO_ID = sesion.Usuario_Id;
                        caso.ULTIMA_MODIFICACION = DateTime.Now;
                        sesion.db.CASOSCollection.Update(caso);

                        AsientosAutomaticosService.GenerarAsientosPorTransicion(transciones[0].ID, caso_id, caso.FLUJO_ID, true, DateTime.Now, sesion);

                    }
                    else
                    {
                        throw new Exception("Transición no encontrada para el caso: " + caso_id + ". Flujo: " + flujo.DESCRIPCION_IMPRESION + "\n del Estado: " + caso.ESTADO_ID + " al Estado: " + estado_destino);
                    }

                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
 
        }

        #endregion CambiarEstado

        #region BorrarCambioEstado
        public static string BorrarCambioEstado(decimal caso_id, string estado_origen, string estado_destino, SessionService sesion)
        {
            string clausulas, estadoAux;
            DataTable dtOperaciones;

            //Validar que el caso se encuentra en el estado destino
            if (CasosService.GetEstadoCaso(caso_id, sesion) != estado_destino)
                throw new Exception("El caso " + caso_id + " no se encontraba en el estado " + estado_destino);

            //Obtener la transicion que se desea borrar
            clausulas = OperacionesService.CasoId_NombreCol + " = " + caso_id + " and " +
                        OperacionesService.EstadoOriginalId_NombreCol + " = '" + estado_origen + "' and " +
                        OperacionesService.EstadoResultanteId_NombreCol + " = '" + estado_destino + "' ";
            
            dtOperaciones = OperacionesService.GetOperacionesDataTable(clausulas, OperacionesService.Id_NombreCol + " desc", sesion);

            if (dtOperaciones.Rows.Count <= 0)
                throw new Exception("CambioEstadoCasoService.BorrarCambioEstado(). No se encontró el cambio de estado.");

            //Borrar la transicion y el comentario
            OperacionesService.Borrar((decimal)dtOperaciones.Rows[0][OperacionesService.Id_NombreCol], sesion);

            //Obtener las transiciones ya realizadas en orden descendente
            dtOperaciones = OperacionesService.GetOperacionesDataTable(caso_id, OperacionesService.Id_NombreCol + " desc", sesion);

            if (dtOperaciones.Rows.Count <= 0)
                throw new Exception("CambioEstadoCasoService.BorrarCambioEstado(). No se encontraron transiciones.");

            if (Interprete.EsNullODBNull(dtOperaciones.Rows[0][OperacionesService.EstadoOriginalId_NombreCol]))
                estadoAux = string.Empty;
            else
                estadoAux = (string)dtOperaciones.Rows[0][OperacionesService.EstadoOriginalId_NombreCol];
            
            CasosService.ActualizarEstado(caso_id, (string)dtOperaciones.Rows[0][OperacionesService.EstadoResultanteId_NombreCol], estadoAux, sesion);

            return (string)dtOperaciones.Rows[0][OperacionesService.EstadoResultanteId_NombreCol];
        }
        #endregion BorrarCambioEstado

        #region Verificar Sesion de Usuario
        /// <summary>
        /// Verifíca que la sesión del usuario exista dentro de la tabla usuario
        /// </summary>
        /// <param name="pSesion">The p sesion.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public USUARIOSRow VerificarSesionUsuario(string pSesion, SessionService sesion)
        {
            string clausuas = USUARIOSCollection.SESIONColumnName + " = '" + pSesion + "'";
            return sesion.db.USUARIOSCollection.GetRow(clausuas);
        }
        #endregion Verificar Sesion de Usuario
    }
}
