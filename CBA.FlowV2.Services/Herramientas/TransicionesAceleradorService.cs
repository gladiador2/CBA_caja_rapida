using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

namespace CBA.FlowV2.Services.Herramientas
{
    public static class TransicionesAceleradorService
    {
        #region GetSiguienteTransicion
        /// <summary>
        /// En caso de que exista una regla de aceleracion para el estado origen y destino, y se cuente con los permisos, se retorna el estado_id. 
        /// Sino, se retorna string.Empty
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="estado_origen">The estado_origen.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <returns></returns>
        public static string GetEstadoDestinoDeSiguienteTransicion(decimal flujo_id, string estado_origen, string estado_destino, SessionService sesion)
        {
            string estadoSiguienteTransicion = string.Empty;
            TransicionesService transicion = new TransicionesService();
            DataTable dtTransicionActual, dtTransicionSiguiente;
            DataTable dtTransicionesAceleradorPermitidas;
            string clausula;

            clausula = TransicionesService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " +
                       TransicionesService.FlujoId_NombreCol + " = " + flujo_id + " and " +
                       TransicionesService.EstadoOrigenId_NombreCol + " = '" + estado_origen + "' and " +
                       TransicionesService.EstadoDestinoId_NombreCol + " = '" + estado_destino + "' and " +
                       TransicionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            //Obtener en el DataTable la transicion utilizada por (estado_origen;estado_destino)
            dtTransicionActual = transicion.GetTransicionesDataTable(clausula, TransicionesService.Orden_NombreCol);

            if (dtTransicionActual.Rows.Count > 0)
            {
                clausula = PermisosAceleradorService.VistaEntidadId_NombreCol + " = " + sesion.Entidad.ID + " and " +
                           PermisosAceleradorService.VistaFlujoId_NombreCol + " = " + flujo_id + " and " +
                           PermisosAceleradorService.VistaTransicionOcurridaId_NombreCol + " = " + dtTransicionActual.Rows[0][TransicionesService.Id_NombreCol] + " and " +
                           PermisosAceleradorService.VistaEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                           PermisosAceleradorService.VistaUsuarioId_NombreCol + " = " + sesion.Usuario.ID + " ";

                dtTransicionesAceleradorPermitidas = PermisosAceleradorService.GetPermisosVisualizacionFlujosDataTable(clausula);

                if (dtTransicionesAceleradorPermitidas.Rows.Count > 0)
                {
                    //Obtener la siguiente transicion
                    dtTransicionSiguiente = transicion.GetTransicionesDataTable(TransicionesService.Id_NombreCol + " = " + dtTransicionesAceleradorPermitidas.Rows[0][PermisosAceleradorService.VistaTransicionSiguienteId_NombreCol], string.Empty);

                    if (dtTransicionSiguiente.Rows.Count > 0)
                        estadoSiguienteTransicion = dtTransicionSiguiente.Rows[0][TransicionesService.EstadoDestinoId_NombreCol].ToString();
                }
            }
            
            return estadoSiguienteTransicion;
        }
        #endregion GetSiguienteTransicion

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TRANSICIONES_ACELERADOR"; }
        }
        public static string EntidadId_NombreCol
        {
            get { return TRANSICIONES_ACELERADORCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TRANSICIONES_ACELERADORCollection.ESTADOColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return TRANSICIONES_ACELERADORCollection.FLUJO_IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return TRANSICIONES_ACELERADORCollection.ROL_IDColumnName; }
        }
        public static string TransicionOcurridaId_NombreCol
        {
            get { return TRANSICIONES_ACELERADORCollection.TRANSICION_OCURRIDA_IDColumnName; }
        }
        public static string TransicionSiguienteId_NombreCol
        {
            get { return TRANSICIONES_ACELERADORCollection.TRANSICION_SIGUIENTE_IDColumnName; }
        }
        #endregion Accessors
    }
}
