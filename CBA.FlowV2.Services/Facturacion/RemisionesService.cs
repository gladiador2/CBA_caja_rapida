#region Using
using System;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.TextosPredefinidos;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public partial class RemisionesService : FlujosServiceBase<RemisionesService>
    {
        #region Implementacion de metodos abstract
        #region GetFlujoId
        public override int GetFlujoId()
        {
            return Definiciones.FlujosIDs.REMISIONES;
        }
        #endregion GetFlujoId

        #region SeleccionarCentrosCosto
        public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            var cabecera = (RemisionesService)caso_cabecera;
            var detalle = (RemisionesDetallesService)caso_detalle;

            Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
            if (cabecera.PersonaId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
            if (cabecera.FuncionarioId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
            else if(cabecera.FuncionarioChoferId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, cabecera.FuncionarioChoferId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, cabecera.DepositoId);
            campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, detalle.ArticuloId);
            if (cabecera.TextoPredefinidoId.HasValue)
                campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, cabecera.TextoPredefinidoId);
            //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
            return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
        }
        #endregion SeleccionarCentrosCosto

        #region EjecutarAccionesCambioEstado
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        protected override CasosService EjecutarAccionesCambioEstado(string estado_destino, bool cambio_pedido_por_usuario, SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            //Verificar si se cumplen los requisitos
            base.VerificarRequisitosDelFlujo(this.CasoId.Value, sesion);

            //Borrador a Pendiente
            if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
            {
                //Acciones

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                if (this.Detalles.Length <= 0)
                    throw new Exception("El caso no tiene detalles.");
            }
            //Pendiente a Borrador
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
            {
                //Ninguna acción
            }
            //Borrador a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Borrador) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                //poner en preparado el pedido de cliente
                decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId((decimal)this.Detalles[0].PedidoClienteDetalleId, sesion);
                if (auxNotaPedido != Definiciones.Error.Valor.EnteroPositivo)
                {
                    var estadoCaso = CasosService.GetEstadoCaso(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido, sesion), sesion);

                    if (!estadoCaso.Equals(Definiciones.EstadosFlujos.Preparado))
                    {
                        NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                        NotasDePedido.CambiarAPreparado(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido, sesion), sesion);
                    }
                }
            }
            //Pendiente a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                    estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId((decimal)this.Detalles[0].PedidoClienteDetalleId, sesion);
                if (auxNotaPedido != Definiciones.Error.Valor.EnteroPositivo)
                {
                    var estadoCaso = CasosService.GetEstadoCaso(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido, sesion), sesion);

                    if (!estadoCaso.Equals(Definiciones.EstadosFlujos.Preparado))
                    {
                        NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                        NotasDePedido.CambiarAPreparado(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido, sesion), sesion);
                    }
                }
            }
            //Pendiente a Aprobado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Pendiente) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
            {
                //Acciones
                //Se genera la numeracion si no existia un numero de comprobante definido
                //Afectar stock

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                if (this.Detalles.Length <= 0)
                    throw new Exception("El caso no tiene detalles.");

                if (this.PersonaId.HasValue && new PersonasBloqueosService().PersonaBloqueada(this.PersonaId.Value))
                    throw new Exception("La pesona se encuentra bloqueada.");
                
                //Se genera la numeracion si no existia un numero de comprobante definido
                if (this.NroComprobante.Length <= 0)
                {
                    if (this.FuncionarioId.HasValue && !AutonumeracionesService.FuncionarioPuedeUsar(this.AutonumeracionId, this.FuncionarioId.Value, sesion))
                        throw new Exception("El talonario no puede ser utilizado por el funcionario seleccionado.");

                    if (AutonumeracionesService.EsGeneracionManual(this.AutonumeracionId, sesion))
                        throw new Exception("Debe indicar el número de comprobante o utilizar un talonario automático.");

                    decimal nroComprobanteSecuencia = Definiciones.Error.Valor.EnteroPositivo;
                    this.NroComprobante = AutonumeracionesService.GetSiguienteNumero2(this.AutonumeracionId, out nroComprobanteSecuencia, sesion);
                    if (NroComprobanteSecuencia != Definiciones.Error.Valor.EnteroPositivo)
                        this.NroComprobanteSecuencia = nroComprobanteSecuencia;

                    //Controlar que se logro asignar una numeracion
                    if (this.NroComprobante.Length <= 0)
                        throw new Exception("No se pudo asignar una numeración válida");
                }

                //Afectar stock
                for (int i = 0; i < this.Detalles.Length; i++)
                {
                    StockService.modificarStock(this.DepositoId, this.Detalles[i].ArticuloId, this.Detalles[i].Cantidad,
                           Definiciones.Stock.TipoMovimiento.Remision, this.CasoId.Value, this.Detalles[i].LoteId, estado_destino,
                           sesion, null, null, this.Detalles[i].Id.Value);
                }
            }
            //Aprobado a Pendiente
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
            {
                //Acciones
                //Afectar stock
                //Borrar el asiento que se creó cuando se aprobó el caso

                //Afectar stock
                for (int i = 0; i < this.Detalles.Length; i++)
                {
                    StockService.modificarStock(this.DepositoId, this.Detalles[i].ArticuloId, -this.Detalles[i].Cantidad,
                           Definiciones.Stock.TipoMovimiento.Remision, this.CasoId.Value, this.Detalles[i].LoteId, estado_destino,
                           sesion, null, null, this.Detalles[i].Id.Value);
                }               

                //Borrar el asiento que se creo cuando se aprobo el pago
                CBA.FlowV2.Services.Contabilidad.AsientosService.BorrarPorCasoYTransicion(
                this.CasoId.Value,
                TransicionesService.GetTransicionSegunFlujoYEstados(Definiciones.FlujosIDs.REMISIONES, Definiciones.EstadosFlujos.Pendiente, Definiciones.EstadosFlujos.Aprobado, sesion),
                sesion);
            }
            //Aprobado a Anulado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
            {
                //Acciones               

                //Afectar stock
                for (int i = 0; i < this.Detalles.Length; i++)
                {
                    StockService.modificarStock(this.DepositoId, this.Detalles[i].ArticuloId, -this.Detalles[i].Cantidad,
                           Definiciones.Stock.TipoMovimiento.Remision, this.CasoId.Value, this.Detalles[i].LoteId, estado_destino,
                           sesion, null, null, this.Detalles[i].Id.Value);
                }

                decimal auxNotaPedido = NotasDePedidoDetalleService.GetNotaDePedidoIdPorId((decimal)this.Detalles[0].PedidoClienteDetalleId, sesion);
                if (auxNotaPedido != Definiciones.Error.Valor.EnteroPositivo)
                {
                    var estadoCaso = CasosService.GetEstadoCaso(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido, sesion), sesion);
                    
                    if (!estadoCaso.Equals(Definiciones.EstadosFlujos.Preparado))
                    {
                        NotasDePedidosService NotasDePedido = new NotasDePedidosService();
                        NotasDePedido.CambiarAPreparado(NotasDePedidosService.GetCasoIdPorId(auxNotaPedido, sesion), sesion);
                    }
                }
            }
            //Aprobado a Viajando
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Aprobado) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
            {
                //Acciones
                //Establecer la fecha de inicio de viaje

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                this.FechaInicioTraslado = DateTime.Now.Date;
            }
            //Viajando a Aprobado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Viajando) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
            {
                //Ninguna acción
            }
            //Viajando a Cerrado
            else if (this.Caso.EstadoId.Equals(Definiciones.EstadosFlujos.Viajando) &&
               estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
            {
                //Acciones
                //Establecer la fecha de fin de viaje

                #region Verificar Puede Avanzar Estado
                string mensaje = string.Empty;
                if (!VerificarPuedeAvanzarEstado(this.CasoId.Value, out mensaje, sesion))
                {
                    throw new Exception(mensaje);
                }
                #endregion Verificar Puede Avanzar Estado

                this.FechaFinTraslado = DateTime.Now.Date;
            }

            this.Caso.Guardar(sesion);
            this.Guardar();

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());

            return this.Caso;
        }
        #endregion EjecutarAccionesCambioEstado

        #region EjecutarAccionesLuegoDeCambioEstado
        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        protected override void EjecutarAccionesLuegoDeCambioEstado(string estado_destino_id, SessionService sesion)
        {
            //Se fuerza un refrescado de informacion
            this.ResetearPropiedadesExtendidas();
        }
        #endregion EjecutarAccionesLuegoDeCambioEstado
        #endregion Implementacion de metodos abstract

        #region VerificarPuedeAvanzarEstado
        public bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, SessionService sesion)
        {
            return FlujosService.VerificarPuedeAvanzarEstado(caso_id, out mensaje, this.Permisos.remisionesNoControlarMargenDiasPuedeAvanzarNombre, Definiciones.VariablesDeSistema.RemisionesMargenDiasPuedeAvanzar, sesion);
        }
        #endregion VerificarPuedeAvanzarEstado

        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string CasoEstadoId = "ESTADO_ID";
        }
        #endregion FiltrosExtension

        #region Permisos
        public Permiso Permisos = new Permiso();
        public class Permiso
        {
            private bool? _remisionesCrear;
            public bool RemisionesCrear { get { if (this._remisionesCrear == null) this._remisionesCrear = RolesService.Tiene("REMISIONES CREAR"); return this._remisionesCrear.Value; } }

            private bool? _remisionesNoControlarMargenDiasPuedeAvanzar;
            public string remisionesNoControlarMargenDiasPuedeAvanzarNombre = "REMISIONES NO CONTROLAR MARGEN DIAS PUEDE AVANZAR";
            public bool RemisionesNoControlarMargenDiasPuedeAvanzar { get { if (this._remisionesNoControlarMargenDiasPuedeAvanzar == null) this._remisionesNoControlarMargenDiasPuedeAvanzar = RolesService.Tiene(this.remisionesNoControlarMargenDiasPuedeAvanzarNombre); return this._remisionesNoControlarMargenDiasPuedeAvanzar.Value; } }
        }
        #endregion Permisos

        #region Propiedades
        protected REMISIONESRow row;
        protected REMISIONESRow rowSinModificar;
        public class Modelo : REMISIONESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal AutonumeracionId { get { return row.AUTONUMERACION_ID; } set { row.AUTONUMERACION_ID = value; } }
        public decimal? BarrioDestinoId { get { if (row.IsBARRIO_DESTINO_IDNull) return null; else return row.BARRIO_DESTINO_ID; } set { if (value.HasValue) row.BARRIO_DESTINO_ID = value.Value; else row.IsBARRIO_DESTINO_IDNull = true; } }
        public decimal? BarrioOrigenId { get { if (row.IsBARRIO_ORIGEN_IDNull) return null; else return row.BARRIO_ORIGEN_ID; } set { if (value.HasValue) row.BARRIO_ORIGEN_ID = value.Value; else row.IsBARRIO_ORIGEN_IDNull = true; } }
        public decimal? CasoId { get { if (row.CASO_ID <= 0) return null; else return row.CASO_ID; } set { if (this.CasoId != value) this._caso = null; row.CASO_ID = value.Value; } }
        public string ChoferNombre { get { return GetStringHelper(row.CHOFER_NOMBRE); } set { row.CHOFER_NOMBRE= value; } }
        public string ChoferNroDocumento { get { return GetStringHelper(row.CHOFER_NRO_DOCUMENTO); } set { row.CHOFER_NRO_DOCUMENTO = value; } }
        public decimal? CiudadDestinoId { get { if (row.IsCIUDAD_DESTINO_IDNull) return null; else return row.CIUDAD_DESTINO_ID; } set { if (value.HasValue) row.CIUDAD_DESTINO_ID = value.Value; else row.IsCIUDAD_DESTINO_IDNull = true; } }
        public decimal? CiudadOrigenId { get { if (row.IsCIUDAD_ORIGEN_IDNull) return null; else return row.CIUDAD_ORIGEN_ID; } set { if (value.HasValue) row.CIUDAD_ORIGEN_ID = value.Value; else row.IsCIUDAD_ORIGEN_IDNull = true; } }
        public decimal? DepartamentoDestinoId { get { if (row.IsDEPARTAMENTO_DESTINO_IDNull) return null; else return row.DEPARTAMENTO_DESTINO_ID; } set { if (value.HasValue) row.DEPARTAMENTO_DESTINO_ID = value.Value; else row.IsDEPARTAMENTO_DESTINO_IDNull = true; } }
        public decimal? DepartamentoOrigenId { get { if (row.IsDEPARTAMENTO_ORIGEN_IDNull) return null; else return row.DEPARTAMENTO_ORIGEN_ID; } set { if (value.HasValue) row.DEPARTAMENTO_ORIGEN_ID = value.Value; else row.IsDEPARTAMENTO_ORIGEN_IDNull = true; } }
        public decimal DepositoId { get { return row.DEPOSITO_ID; } set { if (this.DepositoId != value) this._deposito = null; row.DEPOSITO_ID = value; } }
        public string DireccionDestino { get { return GetStringHelper(row.DIRECCION_DESTINO); } set { row.DIRECCION_DESTINO = value; } }
        public string DireccionOrigen { get { return GetStringHelper(row.DIRECCION_ORIGEN); } set { row.DIRECCION_ORIGEN = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime? FechaFinTraslado { get { if (row.IsFECHA_FIN_TRASLADONull) return null; else return row.FECHA_FIN_TRASLADO; } set { if (value.HasValue) row.FECHA_FIN_TRASLADO = value.Value; else row.IsFECHA_FIN_TRASLADONull = true; } }
        public DateTime? FechaInicioTraslado { get { if (row.IsFECHA_INICIO_TRASLADONull) return null; else return row.FECHA_INICIO_TRASLADO; } set { if (value.HasValue) row.FECHA_INICIO_TRASLADO = value.Value; else row.IsFECHA_INICIO_TRASLADONull = true; } }
        public decimal? FuncionarioAcompanhante1Id { get { if (row.IsFUNCIONARIO_ACOMPANHANTE1_IDNull) return null; else return row.FUNCIONARIO_ACOMPANHANTE1_ID; } set { if (value.HasValue) row.FUNCIONARIO_ACOMPANHANTE1_ID = value.Value; else row.IsFUNCIONARIO_ACOMPANHANTE1_IDNull = true; } }
        public decimal? FuncionarioAcompanhante2Id { get { if (row.IsFUNCIONARIO_ACOMPANHANTE2_IDNull) return null; else return row.FUNCIONARIO_ACOMPANHANTE2_ID; } set { if (value.HasValue) row.FUNCIONARIO_ACOMPANHANTE2_ID = value.Value; else row.IsFUNCIONARIO_ACOMPANHANTE2_IDNull = true; } }
        public decimal? FuncionarioChoferId { get { if (row.IsFUNCIONARIO_CHOFER_IDNull) return null; else return row.FUNCIONARIO_CHOFER_ID; } set { if (value.HasValue) row.FUNCIONARIO_CHOFER_ID = value.Value; else row.IsFUNCIONARIO_CHOFER_IDNull = true; } }
        public decimal? FuncionarioId { get { if (row.IsFUNCIONARIO_IDNull) return null; else return row.FUNCIONARIO_ID; } set { if (value.HasValue) row.FUNCIONARIO_ID = value.Value; else row.IsFUNCIONARIO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Impreso { get { return GetStringHelper(row.IMPRESO); } set { row.IMPRESO = value; } }
        public decimal? LatitudDestino { get { if (row.IsLATITUD_DESTINONull) return null; else return row.LATITUD_DESTINO; } set { if (value.HasValue) row.LATITUD_DESTINO = value.Value; else row.IsLATITUD_DESTINONull = true; } }
        public decimal? LatitudOrigen { get { if (row.IsLATITUD_ORIGENNull) return null; else return row.LATITUD_ORIGEN; } set { if (value.HasValue) row.LATITUD_ORIGEN = value.Value; else row.IsLATITUD_ORIGENNull = true; } }
        public decimal? LongitudDestino { get { if (row.IsLONGITUD_DESTINONull) return null; else return row.LONGITUD_DESTINO; } set { if (value.HasValue) row.LONGITUD_DESTINO = value.Value; else row.IsLONGITUD_DESTINONull = true; } }
        public decimal? LongitudOrigen { get { if (row.IsLONGITUD_ORIGENNull) return null; else return row.LONGITUD_ORIGEN; } set { if (value.HasValue) row.LONGITUD_ORIGEN = value.Value; else row.IsLONGITUD_ORIGENNull = true; } }
        public string NroComprobante { get { return GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NroComprobanteExterno { get { return GetStringHelper(row.NRO_COMPROBANTE_EXTERNO); } set { row.NRO_COMPROBANTE_EXTERNO = value; } }
        public decimal? NroComprobanteSecuencia { get { if (row.IsNRO_COMPROBANTE_SECUENCIANull) return null; else return row.NRO_COMPROBANTE_SECUENCIA; } set { if (value.HasValue) row.NRO_COMPROBANTE_SECUENCIA = value.Value; else row.IsNRO_COMPROBANTE_SECUENCIANull = true; } }
        public string Observacion { get { return GetStringHelper(row.OBSERACION); } set { row.OBSERACION = value; } }
        public string ObservacionEntrega { get { return GetStringHelper(row.OBSERACION_ENTREGA); } set { row.OBSERACION_ENTREGA = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? ProveedorEntregaId { get { if (row.IsPROVEEDOR_ENTREGA_IDNull) return null; else return row.PROVEEDOR_ENTREGA_ID; } set { if (value.HasValue) row.PROVEEDOR_ENTREGA_ID = value.Value; else row.IsPROVEEDOR_ENTREGA_IDNull = true; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { if (this.SucursalId != value) this._sucursal = null; row.SUCURSAL_ID = value; } }
        public decimal? TextoPredefinidoId { get { if (row.IsTEXTO_PREDEFINIDO_IDNull) return null; else return row.TEXTO_PREDEFINIDO_ID; } set { if (value.HasValue) row.TEXTO_PREDEFINIDO_ID = value.Value; else row.IsTEXTO_PREDEFINIDO_IDNull = true; } }
        public decimal? VehiculoId { get { if (row.IsVEHICULO_IDNull) return null; else return row.VEHICULO_ID; } set { if (value.HasValue) row.VEHICULO_ID = value.Value; else row.IsVEHICULO_IDNull = true; } }
        public string VehiculoMarca { get { return GetStringHelper(row.VEHICULO_MARCA); } set { row.VEHICULO_MARCA = value; } }
        public string VehiculoMatricula { get { return GetStringHelper(row.VEHICULO_MATRICULA); } set { row.VEHICULO_MATRICULA = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private BarriosService _barrio_destino;
        public BarriosService BarrioDestino
        {
            get
            {
                if (this._barrio_destino == null)
                {
                    if (this.sesion != null)
                        this._barrio_destino = new BarriosService(this.BarrioDestinoId.Value, this.sesion);
                    else
                        this._barrio_destino = new BarriosService(this.BarrioDestinoId.Value);
                }
                return this._barrio_destino;
            }
        }

        private BarriosService _barrio_origen;
        public BarriosService BarrioOrigen
        {
            get
            {
                if (this._barrio_origen == null)
                {
                    if (this.sesion != null)
                        this._barrio_origen = new BarriosService(this.BarrioOrigenId.Value, this.sesion);
                    else
                        this._barrio_origen = new BarriosService(this.BarrioOrigenId.Value);
                }
                return this._barrio_origen;
            }
        }

        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                {
                    if(this.sesion != null)
                        this._caso = new CasosService(this.CasoId.Value, this.sesion);
                    else
                        this._caso = new CasosService(this.CasoId.Value);
                }
                return this._caso;
            }
        }

        private CiudadesService _ciudad_destino;
        public CiudadesService CiudadDestino
        {
            get
            {
                if (this._ciudad_destino == null)
                {
                    if (this.sesion != null)
                        this._ciudad_destino = new CiudadesService(this.CiudadDestinoId.Value, this.sesion);
                    else
                        this._ciudad_destino = new CiudadesService(this.CiudadDestinoId.Value);
                }
                return this._ciudad_destino;
            }
        }

        private CiudadesService _ciudad_origen;
        public CiudadesService CiudadOrigen
        {
            get
            {
                if (this._ciudad_origen == null)
                {
                    if (this.sesion != null)
                        this._ciudad_origen = new CiudadesService(this.CiudadOrigenId.Value, this.sesion);
                    else
                        this._ciudad_origen = new CiudadesService(this.CiudadOrigenId.Value);
                }
                return this._ciudad_origen;
            }
        }

        private DepartamentosService _departamento_destino;
        public DepartamentosService DepartamentoDestino
        {
            get
            {
                if (this._departamento_destino == null)
                {
                    if (this.sesion != null)
                        this._departamento_destino = new DepartamentosService(this.DepartamentoDestinoId.Value, this.sesion);
                    else
                        this._departamento_destino = new DepartamentosService(this.DepartamentoDestinoId.Value);
                }
                return this._departamento_destino;
            }
        }

        private DepartamentosService _departamento_origen;
        public DepartamentosService DepartamentoOrigen
        {
            get
            {
                if (this._departamento_origen == null)
                {
                    if (this.sesion != null)
                        this._departamento_origen = new DepartamentosService(this.DepartamentoOrigenId.Value, this.sesion);
                    else
                        this._departamento_origen = new DepartamentosService(this.DepartamentoOrigenId.Value);
                }
                return this._departamento_origen;
            }
        }

        private StockDepositosService _deposito;
        public StockDepositosService Deposito
        {
            get
            {
                if (this._deposito == null)
                {
                    if (this.sesion != null)
                        this._deposito = new StockDepositosService(this.DepositoId, this.sesion);
                    else
                        this._deposito = new StockDepositosService(this.DepositoId);
                }
                return this._deposito;
            }
        }

        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                {
                    if (this.sesion != null)
                        this._funcionario = new FuncionariosService(this.FuncionarioId.Value, this.sesion);
                    else
                        this._funcionario = new FuncionariosService(this.FuncionarioId.Value);
                }
                return this._funcionario;
            }
        }

        private FuncionariosService _funcionario_acompanhante1;
        public FuncionariosService FuncionarioAcompanhante1
        {
            get
            {
                if (this._funcionario_acompanhante1 == null)
                {
                    if (this.sesion != null)
                        this._funcionario_acompanhante1 = new FuncionariosService(this.FuncionarioAcompanhante1Id.Value, this.sesion);
                    else
                        this._funcionario_acompanhante1 = new FuncionariosService(this.FuncionarioAcompanhante1Id.Value);
                }
                return this._funcionario_acompanhante1;
            }
        }

        private FuncionariosService _funcionario_acompanhante2;
        public FuncionariosService FuncionarioAcompanhante2
        {
            get
            {
                if (this._funcionario_acompanhante2 == null)
                {
                    if (this.sesion != null)
                        this._funcionario_acompanhante2 = new FuncionariosService(this.FuncionarioAcompanhante2Id.Value, this.sesion);
                    else
                        this._funcionario_acompanhante2 = new FuncionariosService(this.FuncionarioAcompanhante2Id.Value);
                }
                return this._funcionario_acompanhante2;
            }
        }

        private FuncionariosService _funcionario_chofer;
        public FuncionariosService FuncionarioChofer
        {
            get
            {
                if (this._funcionario_chofer == null)
                {
                    if (this.sesion != null)
                        this._funcionario_chofer = new FuncionariosService(this.FuncionarioChoferId.Value, this.sesion);
                    else
                        this._funcionario_chofer = new FuncionariosService(this.FuncionarioChoferId.Value);
                }
                return this._funcionario_chofer;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                {
                    if (this.sesion != null)
                        this._persona = new PersonasService(this.PersonaId.Value, this.sesion);
                    else
                        this._persona = new PersonasService(this.PersonaId.Value);
                }
                return this._persona;
            }
        }

        private ProveedoresService _proveedor_entrega;
        public ProveedoresService ProveedorEntrega
        {
            get
            {
                if (this._proveedor_entrega == null)
                {
                    if (this.sesion != null)
                        this._proveedor_entrega = new ProveedoresService(this.ProveedorEntregaId.Value, this.sesion);
                    else
                        this._proveedor_entrega = new ProveedoresService(this.ProveedorEntregaId.Value);
                }
                return this._proveedor_entrega;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                        this._sucursal = new SucursalesService(this.SucursalId, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalId);
                }
                return this._sucursal;
            }
        }

        private TextosPredefinidosService _texto_predefinido;
        public TextosPredefinidosService TextoPredefinido
        {
            get
            {
                if (this._texto_predefinido == null)
                {
                    if (this._texto_predefinido != null)
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value, this.sesion);
                    else
                        this._texto_predefinido = new TextosPredefinidosService(this.TextoPredefinidoId.Value);
                }
                return this._texto_predefinido;
            }
        }

        private VehiculosService _vehiculo;
        public VehiculosService Vehiculo
        {
            get
            {
                if (this._vehiculo == null)
                {
                    if (this._vehiculo != null)
                        this._vehiculo = new VehiculosService(this.VehiculoId.Value, this.sesion);
                    else
                        this._vehiculo = new VehiculosService(this.VehiculoId.Value);
                }
                return this._vehiculo;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private RemisionesDetallesService[] _detalles;
        public RemisionesDetallesService[] Detalles
        {
            get
            {
                if (!this.ExisteEnDB)
                    return new RemisionesDetallesService[0];
                if (this._detalles == null)
                    this._detalles = this.GetFiltrado<RemisionesDetallesService>(new Filtro { Columna = RemisionesDetallesService.Modelo.REMISION_IDColumnName, Valor = this.Id.Value });
                return this._detalles;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.REMISIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new REMISIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(REMISIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public RemisionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public RemisionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public RemisionesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private RemisionesService(REMISIONESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorCaso
        public static RemisionesService GetPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPorCaso(caso_id, sesion);
            }
        }

        public static RemisionesService GetPorCaso(decimal caso_id, SessionService sesion)
        {
            var remisionesService = RemisionesService.Instancia;
            remisionesService.IniciarUsingSesion(sesion);
            var remision = RemisionesService.Instancia.GetPrimero<RemisionesService>(new Filtro
            {
                Columna = Modelo.CASO_IDColumnName,
                Valor = caso_id
            });
            remisionesService.FinalizarUsingSesion();
            return remision;
        }
        #endregion GetPorCaso

        #region GetRemision
        /// <summary>
        /// Gets the remision.
        /// </summary>
        /// <param name="remision_id">The remision_id.</param>
        /// <returns></returns>
        public static REMISIONESRow GetRemision(decimal remision_id, SessionService sesion)
        {
            string clausulas = RemisionesService.Modelo.IDColumnName + " = " + remision_id;
            REMISIONESRow[] rows = sesion.Db.REMISIONESCollection.GetAsArray(clausulas, RemisionesService.Modelo.IDColumnName);
            if (rows.Length > 0)
                return rows[0];
            else
                throw new Exception("Remisión no encontrada.");
        }
        #endregion GetRemision

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            bool casoNuevo = false;

            try
            {
                if (!Permisos.RemisionesCrear)
                    throw new Exception("No tiene permisos para guardar");

                this.Validar();

                if (!this.ExisteEnDB)
                {
                    casoNuevo = true;
                    CrearCasos CrearCaso = new CrearCasos((int)this.SucursalId, Definiciones.FlujosIDs.REMISIONES, (int)sesion.Usuario_Id, SessionService.GetClienteIP());
                    this.CasoId = int.Parse(CrearCaso.Ejecutar(sesion));
                    this.Estado = Definiciones.Estado.Activo;
                    this.Impreso = Definiciones.SiNo.No;
                    this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);

                    sesion.db.REMISIONESCollection.Insert(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
                }
                else
                {
                    sesion.db.REMISIONESCollection.Update(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
                }

                #region Actualizar datos en tabla casos
                this.Caso.FechaFormulario = this.Fecha;
                this.Caso.NroComprobante = this.NroComprobante;
                this.Caso.NroComprobante2 = this.NroComprobanteExterno;
                this.Caso.PersonaId = this.PersonaId;
                this.Caso.FuncionarioId = this.FuncionarioId;
                this.Caso.ProveedorId = this.ProveedorEntregaId;
                this.Caso.SucursalId = this.SucursalId;
                this.Caso.Guardar(this.sesion);
                #endregion Actualizar datos en tabla casos

                this.rowSinModificar = this.row.Clonar();
                return this.Id.Value;
            }
            catch
            {
                //Si el caso fue creado el mismo debe borrarse
                if (casoNuevo && this.CasoId > 0)
                    (new CasosService()).Eliminar(row.CASO_ID, sesion);

                throw;
            }
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.PersonaId.HasValue)
            {
                if (this.rowSinModificar.IsPERSONA_IDNull || this.PersonaId != this.rowSinModificar.PERSONA_ID)
                { 
                    if(this.Persona.Estado == Definiciones.Estado.Inactivo)
                        excepciones.Agregar(Traducciones.La_persona_esta_inactiva, null);
                    if (PersonasService.EstaBloqueado(this.PersonaId.Value))
                        excepciones.Agregar(Traducciones.La_persona_esta_bloqueada, null);

                    if (this.Detalles.Length > 0)
                        excepciones.Agregar("No se puede modificar la persona mientas el caso tiene detalles.");
                }

                //Si no tiene separacion de bienes, y tiene una persona asociada como conyuge
                //se controla que el conyuge no este en judicial ni informconf
                if (this.Persona.EnInformconf == Definiciones.SiNo.Si)
                    excepciones.Agregar(Traducciones.La_persona_esta_en_informconf, null);
                if (this.Persona.EnJudicial == Definiciones.SiNo.Si)
                    excepciones.Agregar(Traducciones.La_persona_esta_en_judicial, null);
                if (this.Persona.PersonaIdConyuge.HasValue)
                {
                    if (this.Persona.PersonaConyuge.Estado == Definiciones.Estado.Inactivo)
                        excepciones.Agregar("El cónyuge está inactivo.", null);
                    if (PersonasService.EstaBloqueado(this.Persona.PersonaConyuge.Id.Value))
                        excepciones.Agregar("El cónyuge está bloqueado", null);
                    if (this.Persona.PersonaConyuge.EnInformconf == Definiciones.SiNo.Si)
                        excepciones.Agregar("El cónyuge está en Informconf.", null);
                    if (this.Persona.PersonaConyuge.EnJudicial == Definiciones.SiNo.Si)
                        excepciones.Agregar("El cónyuge está en judicial.", null);
                }
            }

            if (this.ProveedorEntregaId.HasValue && (this.rowSinModificar.IsPROVEEDOR_ENTREGA_IDNull || this.ProveedorEntregaId.Value != this.rowSinModificar.PROVEEDOR_ENTREGA_ID))
            {
                if (this.ProveedorEntrega.Estado == Definiciones.Estado.Inactivo)
                    excepciones.Agregar("El proveedor está inactivo", null);
            }

            if(this.DepositoId != this.rowSinModificar.DEPOSITO_ID && this.Detalles.Length > 0)
                excepciones.Agregar("No se puede modificar el depósito mientas el caso tiene detalles.");

            if (this.NroComprobante.Length > 0 && this.NroComprobante != GetStringHelper(this.rowSinModificar.NRO_COMPROBANTE))
            {
                decimal casoCoincideId;
                if (RemisionesService.GetExisteNroComprobanteRemision(this.Id ?? Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, this.AutonumeracionId, this.NroComprobante, out casoCoincideId, sesion))
                    excepciones.Agregar("El número de remisión " + this.NroComprobante + " ya está siendo utilizado en el " + Traducciones.Caso + " " + casoCoincideId + ".");
            }

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._barrio_destino = null;
            this._barrio_destino = null;
            this._caso = null;
            this._ciudad_destino = null;
            this._ciudad_origen = null;
            this._departamento_destino = null;
            this._departamento_origen = null;
            this._deposito = null;
            this._detalles = null;
            this._funcionario = null;
            this._funcionario_acompanhante1 = null;
            this._funcionario_acompanhante2 = null;
            this._funcionario_chofer = null;
            this._persona = null;
            this._proveedor_entrega = null;
            this._sucursal = null;
            this._texto_predefinido = null;
            this._vehiculo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region AgregarDetalles
        public void AgregarDetalles(RemisionesDetallesService.DetallePosible[] detalles)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    AgregarDetalles(detalles, sesion);
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public void AgregarDetalles(RemisionesDetallesService.DetallePosible[] detalles, SessionService sesion)
        {
            for (int i = 0; i < detalles.Length; i++)
            {
                var d = new RemisionesDetallesService()
                {
                    RemisionId = this.Id.Value,
                    CasoOrigenId = detalles[i].caso.Id.Value,
                    ArticuloId = detalles[i].lote.ArticuloId,
                    LoteId = detalles[i].lote.Id.Value,
                    UnidadMedidaId = detalles[i].unidadMedida.Id,
                    Cantidad = detalles[i].cantidadSaldo,
                };
                switch ((int)detalles[i].caso.FlujoId)
                { 
                    case Definiciones.FlujosIDs.PEDIDO_DE_CLIENTE:
                        d.PedidoClienteDetalleId = detalles[i].detalleId;
                        break;
                    case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                        d.FacturaClienteDetalleId = detalles[i].detalleId;
                        break;
                    default:
                        throw new Exception("RemisionesService.AgregarDetalles() Flujo no implementado.");
                }
                d.IniciarUsingSesion(sesion);
                d.Guardar();
                d.FinalizarUsingSesion();
            }
            this._detalles = null;
        }
        #endregion AgregarDetalles

        #region Borrar
        public void Borrar()
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Borrar(sesion);
                this.FinalizarUsingSesion();
            }
        }

        public void Borrar(SessionService sesion)
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();

            this.Caso.Estado = Definiciones.Estado.Inactivo;
            this.Caso.Guardar(sesion);
        }
        #endregion Borrar

        #region Buscar
        protected override RemisionesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.AUTONUMERACION_IDColumnName:
                        case Modelo.BARRIO_DESTINO_IDColumnName:
                        case Modelo.BARRIO_ORIGEN_IDColumnName:
                        case Modelo.CASO_IDColumnName:
                        case Modelo.CIUDAD_DESTINO_IDColumnName:
                        case Modelo.CIUDAD_ORIGEN_IDColumnName:
                        case Modelo.DEPARTAMENTO_DESTINO_IDColumnName:
                        case Modelo.DEPARTAMENTO_ORIGEN_IDColumnName:
                        case Modelo.DEPOSITO_IDColumnName:
                        case Modelo.FUNCIONARIO_ACOMPANHANTE1_IDColumnName:
                        case Modelo.FUNCIONARIO_ACOMPANHANTE2_IDColumnName:
                        case Modelo.FUNCIONARIO_CHOFER_IDColumnName:
                        case Modelo.FUNCIONARIO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.LATITUD_DESTINOColumnName:
                        case Modelo.LATITUD_ORIGENColumnName:
                        case Modelo.LONGITUD_DESTINOColumnName:
                        case Modelo.LONGITUD_ORIGENColumnName:
                        case Modelo.NRO_COMPROBANTE_SECUENCIAColumnName:
                        case Modelo.PERSONA_IDColumnName:
                        case Modelo.PROVEEDOR_ENTREGA_IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                        case Modelo.TEXTO_PREDEFINIDO_IDColumnName:
                        case Modelo.VEHICULO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.CHOFER_NOMBREColumnName:
                        case Modelo.CHOFER_NRO_DOCUMENTOColumnName:
                        case Modelo.DIRECCION_DESTINOColumnName:
                        case Modelo.DIRECCION_ORIGENColumnName:
                        case Modelo.IMPRESOColumnName:
                        case Modelo.NRO_COMPROBANTE_EXTERNOColumnName:
                        case Modelo.NRO_COMPROBANTEColumnName:
                        case Modelo.OBSERACION_ENTREGAColumnName:
                        case Modelo.OBSERACIONColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHA_FIN_TRASLADOColumnName:
                        case Modelo.FECHA_INICIO_TRASLADOColumnName:
                        case Modelo.FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.CasoEstadoId:
                            if (f.Exacto)
                            {
                                sb.Append(" exists(select * from " + CasosService.Nombre_Tabla + " a " +
                                             "         where a." + CasosService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CASO_IDColumnName +
                                             "           and a." + f.Columna + " = '" + f.Valor + "') ");
                            }
                            else
                            {
                                string valores = string.Empty;
                                foreach (var v in (string[])f.Valor)
                                    valores += "'" + v + "', ";
                                valores += "'" + Definiciones.Error.Valor.EnteroPositivo.ToString() + "'";

	                             sb.Append(" exists(select * from " + CasosService.Nombre_Tabla + " a " +
                                             "         where a." + CasosService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.CASO_IDColumnName +
                                             "           and a." + f.Columna + " in (" + valores + ")) ");
                            }
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            REMISIONESRow[] rows = sesion.db.REMISIONESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            RemisionesService[] r = new RemisionesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                r[i] = new RemisionesService(rows[i]);

            return r;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region GetExisteNroComprobanteRemision
        public static bool GetExisteNroComprobanteRemision(decimal remision_id, decimal transferencia_caso_id, decimal autonumeracion_id, string nro_comprobante, out decimal caso_coincide_id, SessionService sesion)
        {
            caso_coincide_id = Definiciones.Error.Valor.EnteroPositivo;
            if (nro_comprobante.Length <= 0)
                return true;

            string sql = "select " + CasosService.Id_NombreCol + " from (" +
                "select c. " + CasosService.Id_NombreCol +
                " from " + StockTransferenciasService.Nombre_Tabla + " st, " + CasosService.Nombre_Tabla + " c " +
                "where st." + StockTransferenciasService.CasoId_NombreCol + " <> " + transferencia_caso_id +
                "  and nvl(st." + StockTransferenciasService.CasoAsociadoId_NombreCol + ", 0) <> " + transferencia_caso_id +
                "  and st." + StockTransferenciasService.CasoId_NombreCol + " = c." + CasosService.Id_NombreCol +
                "  and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                "  and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                "  and st." + StockTransferenciasService.EsCasoOriginal_NombreCol + " = '" + Definiciones.SiNo.Si + "' " +
                "  and st." + StockTransferenciasService.RemisionAutonumeracionId_NombreCol + " = " + autonumeracion_id +
                "  and upper(st." + StockTransferenciasService.RemisionExterna_NombreCol + ") = '" + nro_comprobante.ToUpper() + "' " +
                " union " +
                "select c. " + CasosService.Id_NombreCol +
                " from " + RemisionesService.Nombre_Tabla + " r, " + CasosService.Nombre_Tabla + " c " +
                "where r." + RemisionesService.Modelo.CASO_IDColumnName + " = c." + CasosService.Id_NombreCol +
                "  and r." + RemisionesService.Modelo.IDColumnName + " <> " + remision_id +
                "  and c." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                "  and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                "  and r." + RemisionesService.Modelo.AUTONUMERACION_IDColumnName + " = " + autonumeracion_id +
                "  and upper(r." + RemisionesService.Modelo.NRO_COMPROBANTEColumnName + ") = '" + nro_comprobante.ToUpper() + "' " +
                " )";
            
            var dt = sesion.db.EjecutarQuery(sql);
            if(dt.Rows.Count > 0)
                caso_coincide_id = (decimal)dt.Rows[0][0];

            return dt.Rows.Count > 0;
        }
        #endregion GetExisteNroComprobanteRemision

        #region Accessors
        public static string Nombre_Tabla = "REMISIONES";
        public static string Nombre_Secuencia = "REMISIONES_SQC";
        #endregion Accessors

        #region FueImpreso
        public static bool FueImpreso(decimal caso_id)
        {
            if (caso_id == Definiciones.Error.Valor.EnteroPositivo) return false;
            using (SessionService sesion = new SessionService())
            {
                RemisionesService remision = RemisionesService.GetPorCaso(caso_id);
                return remision.Impreso.Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion FueImpreso

        #region DesmarcarImpreso
        public static void DesmarcarImpreso(decimal caso_id)
        {
            try
            {
                RemisionesService remision = RemisionesService.GetPorCaso(caso_id);
                remision.Impreso = Definiciones.SiNo.No;
                remision.Guardar();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion DesmarcarImpreso
    }
}
