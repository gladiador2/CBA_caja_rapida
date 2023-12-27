using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using Oracle.ManagedDataAccess.Client;


using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;


namespace CBA.FlowV2.Services.Casos
{
    public class CrearCasos
    {
        #region Variables privadas
        private int vSucursalID;
        private int vFlujoID;
        private int vUsuarioID;
        private string vDireccionIP;
        private CBAV2 db;
        #endregion Variables privadas

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="CrearCasos"/> class.
        /// </summary>
        /// <param name="pSucursalID">The p sucursal ID.</param>
        /// <param name="pFlujoID">The p flujo ID.</param>
        /// <param name="pUsuarioID">The p usuario ID.</param>
        /// <param name="pDireccionIP">The p direccion IP.</param>
        public CrearCasos(int pSucursalID, int pFlujoID, int pUsuarioID, string pDireccionIP)
        {
            this.vSucursalID = pSucursalID;
            this.vFlujoID = pFlujoID;
            this.vUsuarioID = pUsuarioID;
            this.vDireccionIP = pDireccionIP;
        }
        #endregion Constructores

        #region Ejecutar
        /// <summary>
        /// Se llama al metodo para crear el caso.
        /// </summary>
        /// <param name="sesion_id">The sesion_id.</param>
        /// <returns></returns>
        public string Ejecutar(SessionService sesion)
        {
            decimal casoId = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo;
            
            OPERACIONES_TIPORow tipoOperacionRow = new OPERACIONES_TIPORow();
            string clausulasOperaciones = string.Empty;

            if (VerificarSesionUsuario(sesion.Usuario.SESION.ToString(), sesion) != null)
                casoId = CrearCaso(CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Borrador, sesion);

            OperacionesService.InsertarOperacion(casoId, 
                                                 CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo, 
                                                 CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Borrador, 
                                                 string.Empty,
                                                 CBA.FlowV2.Services.Base.Definiciones.TipoOperacion.CasoCreado, 
                                                 vUsuarioID, 
                                                 vDireccionIP, 
                                                 string.Empty,
                                                 string.Empty, 
                                                 CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo, 
                                                 sesion);

            if (casoId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
            {
                return "Error. No se ha podido crear el Caso. Favor verifique su sesión.";
            }
            else
            {
                //Se evalua el envio de notificaciones
                CasosService caso = new CasosService(casoId, sesion);
                NotificacionesService.EvaluarPorFlujo(null, caso, sesion);

                return casoId.ToString();
            }
        }

        public string Ejecutar(SessionService sesion, string estadoInicial)
        {
            decimal casoId = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo;

            OPERACIONES_TIPORow tipoOperacionRow = new OPERACIONES_TIPORow();
            string clausulasOperaciones = string.Empty;

            if (VerificarSesionUsuario(sesion.Usuario.SESION.ToString(), sesion) != null)
                casoId = CrearCaso(estadoInicial, sesion);

            OperacionesService.InsertarOperacion(casoId,
                                                 CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo,
                                                 estadoInicial,
                                                 string.Empty,
                                                 CBA.FlowV2.Services.Base.Definiciones.TipoOperacion.CasoCreado,
                                                 vUsuarioID,
                                                 vDireccionIP,
                                                 string.Empty,
                                                 string.Empty,
                                                 CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo,
                                                 sesion);

            if (casoId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
            {
                return "Error. No se ha podido crear el Caso. Favor verifique su sesión.";
            }
            else
            {
                //Se evalua el envio de notificaciones
                CasosService caso = new CasosService(casoId, sesion);
                NotificacionesService.EvaluarPorFlujo(null, caso, sesion);

                return casoId.ToString();
            }
        }

        public string Ejecutar(Decimal sesion_id)
        {
            decimal casoId = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo;
            
            using (SessionService sesion = new SessionService())
            {
                OPERACIONES_TIPORow tipoOperacionRow = new OPERACIONES_TIPORow();
                string clausulasOperaciones = string.Empty;

                if (VerificarSesionUsuario(sesion_id.ToString(), sesion) != null)
                {
                    casoId = CrearCaso(CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Borrador, sesion);
                }

                
                OperacionesService.InsertarOperacion(casoId, CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo, CBA.FlowV2.Services.Base.Definiciones.EstadosFlujos.Borrador, string.Empty, CBA.FlowV2.Services.Base.Definiciones.TipoOperacion.CasoCreado, vUsuarioID, vDireccionIP, string.Empty,
                    string.Empty, CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo, sesion);

                if (casoId.Equals(CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo))
                    return "Error. No se ha podido crear el Caso. Favor verifique su sesión.";
                else
                    return casoId.ToString();
            }
        }
        #endregion Ejecutar

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

        #region Crear Caso
        /// <summary>
        /// Se inserta un registro en la tabla casos
        /// </summary>
        /// <param name="pEstadoInicial">The p estado inicial.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Error al crear el caso</exception>
        private decimal CrearCaso(string pEstadoInicial, SessionService sesion)
        {
            decimal CasoId = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo; 

            try
            {
                CASOSRow nuevoCaso = new CASOSRow();

                CasoId = sesion.db.GetSiguienteSecuencia("casos_sqc");
                nuevoCaso.ID = CasoId;
                nuevoCaso.FLUJO_ID = vFlujoID;
                nuevoCaso.SUCURSAL_ID = vSucursalID;
                nuevoCaso.USUARIO_ID = vUsuarioID;
                nuevoCaso.ESTADO_ID = pEstadoInicial;
                nuevoCaso.USUARIO_CREACION_ID = vUsuarioID;
                nuevoCaso.FECHA_CREACION = DateTime.Now;
                nuevoCaso.ESTADO = CBA.FlowV2.Services.Base.Definiciones.Estado.Activo;

                sesion.db.CASOSCollection.Insert(nuevoCaso);
            }
            catch (Exception)
            {
                throw new Exception("Error al crear el caso");
            }

            return CasoId;

        }
        #endregion CrearCaso
    }
}



