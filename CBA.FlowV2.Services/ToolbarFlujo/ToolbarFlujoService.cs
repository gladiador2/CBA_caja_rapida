using System;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.ToolbarFlujo
{
    public class ToolbarFlujoService
    {
        public class ComentarioTransicion
        {
            public string texto = string.Empty;
            public decimal TextoPredefinidoId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal AsignacionCasoUsuarioId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal AsignacionCasoTextoPredefinidoId = Definiciones.Error.Valor.EnteroPositivo;
        }

        #region ProcesarCambioEstado
        /// <summary>
        /// Procesars the cambio estado.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="comentario">The comentario.</param>
        /// <returns></returns>
        public bool ProcesarCambioEstado(decimal caso_id, string estado_destino, ComentarioTransicion comentario, SessionService sesion)
        {
            bool exito = false;
            try
            {
                CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                CASOSRow casoAntes = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);

                exito = cambioEstado.CambiarEstado(caso_id,
                                                   estado_destino,
                                                   sesion.Usuario.ID,
                                                   sesion.Usuario.SESION,
                                                   comentario.texto,
                                                   comentario.TextoPredefinidoId,
                                                   SessionService.GetClienteIP(),
                                                   sesion);

                CASOSRow casoDespues = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);

                //Se guarda el cambio en la bitacora
                LogCambiosService.LogDeRegistro(CasosService.Nombre_Tabla, caso_id, casoAntes.ToString(), casoDespues.ToString(), sesion);

                //Si esta definido el usuario al que se asigna el caso, se guarda la asignacion
                if(!comentario.AsignacionCasoUsuarioId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    CasosAsignacionesService.Asignar(caso_id, comentario.AsignacionCasoUsuarioId, comentario.AsignacionCasoTextoPredefinidoId, string.Empty, sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return exito;
        }
        public bool ProcesarCambioEstado(decimal caso_id, string estado_destino, string comentario, SessionService sesion)
        {
            return ProcesarCambioEstado(caso_id, estado_destino, new ComentarioTransicion { texto = comentario }, sesion);
        }
        #endregion ProcesarCambioEstado
    }
}
