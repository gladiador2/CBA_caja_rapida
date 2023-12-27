#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.TextosPredefinidos;
using System.Collections;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Facturacion
{
    public class RemisionesDetallesService : ClaseCBA<RemisionesDetallesService>
    {
        #region sub clases
        public class DetallePosible
        {
            public decimal detalleId;
            public CasosService caso;
            public ArticulosLotesService lote;
            public UnidadesService unidadMedida;
            public decimal cantidadInicial;
            public decimal cantidadSaldo;
        }
        #endregion sub clases

        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string CasoEstadoId = "ESTADO_ID";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected REMISIONES_DETALLESRow row;
        protected REMISIONES_DETALLESRow rowSinModificar;
        public class Modelo : REMISIONES_DETALLESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public decimal Cantidad { get { return row.CANTIDAD; } set { row.CANTIDAD = value; } }
        public decimal CasoOrigenId { get { return row.CASO_ORIGEN_ID; } set { row.CASO_ORIGEN_ID = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? FacturaClienteDetalleId { get { if (row.IsFACTURA_CLIENTE_DETALLE_IDNull) return null; else return row.FACTURA_CLIENTE_DETALLE_ID; } set { if (value.HasValue) row.FACTURA_CLIENTE_DETALLE_ID = value.Value; else row.IsFACTURA_CLIENTE_DETALLE_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal LoteId { get { return row.LOTE_ID; } set { row.LOTE_ID = value; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal? PedidoClienteDetalleId { get { if (row.IsPEDIDO_CLIENTE_DETALLE_IDNull) return null; else return row.PEDIDO_CLIENTE_DETALLE_ID; } set { if (value.HasValue) row.PEDIDO_CLIENTE_DETALLE_ID = value.Value; else row.IsPEDIDO_CLIENTE_DETALLE_IDNull = true; } }
        public decimal RemisionId { get { return row.REMISION_ID; } set { row.REMISION_ID = value; } }
        public string UnidadMedidaId { get { return GetStringHelper(row.UNIDAD_MEDIDA_ID); } set { row.UNIDAD_MEDIDA_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                {
                    if (this.sesion != null)
                        this._articulo = new ArticulosService(this.ArticuloId, this.sesion);
                    else
                        this._articulo = new ArticulosService(this.ArticuloId);
                }
                return this._articulo;
            }
        }

        private CasosService _caso_origen;
        public CasosService CasoOrigen
        {
            get
            {
                if (this._caso_origen == null)
                {
                    if (this.sesion != null)
                        this._caso_origen = new CasosService(this.CasoOrigenId, this.sesion);
                    else
                        this._caso_origen = new CasosService(this.CasoOrigenId);
                }
                return this._caso_origen;
            }
        }
        
        private ArticulosLotesService _lote;
        public ArticulosLotesService Lote
        {
            get
            {
                if (this._lote == null)
                {
                    if (this.sesion != null)
                        this._lote = new ArticulosLotesService(this.LoteId, this.sesion);
                    else
                        this._lote = new ArticulosLotesService(this.LoteId);
                }
                return this._lote;
            }
        }

        private RemisionesService _remision;
        public RemisionesService Remision
        {
            get
            {
                if (this._remision == null)
                {
                    if (this.sesion != null)
                        this._remision = new RemisionesService(this.RemisionId, this.sesion);
                    else
                        this._remision = new RemisionesService(this.RemisionId);
                }
                return this._remision;
            }
        }

        private UnidadesService _unidad_medida;
        public UnidadesService UnidadMedida
        {
            get
            {
                if (this._unidad_medida == null)
                {
                    if (this.sesion != null)
                        this._unidad_medida = new UnidadesService(this.UnidadMedidaId, this.sesion);
                    else
                        this._unidad_medida = new UnidadesService(this.UnidadMedidaId);
                }
                return this._unidad_medida;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.REMISIONES_DETALLESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new REMISIONES_DETALLESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(REMISIONES_DETALLESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public RemisionesDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public RemisionesDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public RemisionesDetallesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private RemisionesDetallesService(REMISIONES_DETALLESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            decimal cantidadTotal = 0, cantidadRemitida = 0;
            var fDetalle = new Filtro();

            if (this.Cantidad <= 0)
                excepciones.Agregar("La cantidad debe ser mayor a cero.");
            
            if (this.CasoOrigen.PersonaId != this.Remision.PersonaId)
                excepciones.Agregar("La remisión y el detalle que se está guardando deben pertenecer a la misma persona.");

            #region Validar que la cantidad que se está agregando no supera el total posible de remitir
            if (this.PedidoClienteDetalleId.HasValue)
            {
                cantidadTotal = NotasDePedidoDetalleService.GetCantidadTotalPorDetalleId(this.PedidoClienteDetalleId.Value, sesion);
                
                fDetalle.Columna = Modelo.PEDIDO_CLIENTE_DETALLE_IDColumnName;
                fDetalle.Valor = this.PedidoClienteDetalleId.Value;
            }
            else if (this.FacturaClienteDetalleId.HasValue)
            {
                var dtFacturaClienteDetalle = FacturasClienteDetalleService.GetFacturaClienteDetalleDataTable(FacturasClienteDetalleService.Id_NombreCol + " = " + this.FacturaClienteDetalleId, string.Empty, sesion);
                if (dtFacturaClienteDetalle.Rows.Count <= 0)
                    excepciones.Agregar("Detalle de factura no encontrado");
                cantidadTotal = (decimal)dtFacturaClienteDetalle.Rows[0][FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol];

                fDetalle.Columna = Modelo.FACTURA_CLIENTE_DETALLE_IDColumnName;
                fDetalle.Valor = this.FacturaClienteDetalleId.Value;
            }
            else
            {
                excepciones.Agregar("RemisionesDetallesRelaciones.Validar() Tipo de detalle no implementado.");
            }

            var lFiltros = new List<Filtro>();
            lFiltros.Add(fDetalle);
            lFiltros.Add(new Filtro() { Columna = FiltroExtension.CasoEstadoId, Valor = new string[] { Definiciones.EstadosFlujos.Anulado }, Comparacion = "not in", Exacto = false });
            if (this.Id.HasValue)
                lFiltros.Add(new Filtro() { Columna = Modelo.IDColumnName, Comparacion = "<>", Valor = this.Id.Value });
            var rd = this.GetFiltrado<RemisionesDetallesService>(lFiltros);
            for (int i = 0; i < rd.Length; i++)
                cantidadRemitida += rd[i].Cantidad;

            if (cantidadRemitida + this.Cantidad > cantidadTotal)
            {
                excepciones.Agregar("Del lote " + this.Articulo.CodigoEmpresa + " - " + this.Lote.Lote +
                                    " ya fueron remitidos " + this.UnidadMedida.Descripcion + " " + Math.Round(cantidadRemitida, (int)this.UnidadMedida.CantidadDecimales).ToString("###.###,######") +
                                    " de " + Math.Round(cantidadTotal, (int)this.UnidadMedida.CantidadDecimales).ToString("###.###,######") + ".");
            }
            #endregion Validar que la cantidad que se está agregando no supera el total posible de remitir

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
            this._caso_origen = null;
            this._lote = null;
            this._remision = null;
            this._unidad_medida = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                REMISIONESRow remisionRow;
                remisionRow = RemisionesService.GetRemision(this.RemisionId, sesion);

                #region verificar cantidad de detalles segun autonumeracion                
                var dt = AutonumeracionesService.GetAutonumeracionesDataTable(AutonumeracionesService.Id_NombreCol + " = " + remisionRow.AUTONUMERACION_ID, string.Empty, sesion);
                if (!Interprete.EsNullODBNull(dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol]))
                {
                    var dtDetalles = sesion.Db.REMISIONES_DETALLESCollection.GetAsDataTable(RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = " + this.RemisionId + " and " + RemisionesDetallesService.Modelo.ESTADOColumnName + " = '"+ Definiciones.Estado.Activo + "'" , string.Empty);                    
                    if (dtDetalles.Rows.Count >= (decimal)dt.Rows[0][AutonumeracionesService.DetallesCantidadMaxima_NombreCol])
                        throw new Exception("Cantidad máxima de artículos superada.");
                }                
                #endregion verificar cantidad de detalles segun autonumeracion

                this.Estado = Definiciones.Estado.Activo;
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.REMISIONES_DETALLESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.REMISIONES_DETALLESCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Borrar
        public void Borrar()
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    this.IniciarUsingSesion(sesion);
                    Borrar(sesion);
                    this.FinalizarUsingSesion();
                    sesion.CommitTransaction();
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public void Borrar(SessionService sesion)
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region Buscar
        protected override RemisionesDetallesService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.CANTIDADColumnName:
                        case Modelo.CASO_ORIGEN_IDColumnName:
                        case Modelo.FACTURA_CLIENTE_DETALLE_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.LOTE_IDColumnName:
                        case Modelo.PEDIDO_CLIENTE_DETALLE_IDColumnName:
                        case Modelo.REMISION_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.OBSERVACIONColumnName:
                        case Modelo.UNIDAD_MEDIDA_IDColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case FiltroExtension.CasoEstadoId:
                            if (f.Exacto)
                            {
                                sb.Append(" exists(select * from " + CasosService.Nombre_Tabla + " c, " + RemisionesService.Nombre_Tabla + " r " +
                                             "         where c." + CasosService.Id_NombreCol + " = r." + RemisionesService.Modelo.CASO_IDColumnName +
                                             "           and r." + RemisionesService.Modelo.IDColumnName + " = " + Nombre_Tabla + "." + Modelo.REMISION_IDColumnName +
                                             "           and c." + f.Columna + " " + f.Comparacion + " '" + f.Valor + "') ");
                            }
                            else
                            {
                                string valores = string.Empty;
                                string comparacion = f.Comparacion == "=" ? "in" : f.Comparacion;
                                foreach (var v in (string[])f.Valor)
                                    valores += "'" + v + "', ";
                                valores += "'" + Definiciones.Error.Valor.EnteroPositivo.ToString() + "'";
                                

                                sb.Append(" exists(select * from " + CasosService.Nombre_Tabla + " c, " + RemisionesService.Nombre_Tabla + " r " +
                                             "         where c." + CasosService.Id_NombreCol + " = r." + RemisionesService.Modelo.CASO_IDColumnName +
                                             "           and r." + RemisionesService.Modelo.IDColumnName + " = " + Nombre_Tabla + "." + Modelo.REMISION_IDColumnName +
                                             "           and c." + f.Columna + " " + f.Comparacion + " (" + valores + ")) ");
                            }
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            REMISIONES_DETALLESRow[] rows = sesion.db.REMISIONES_DETALLESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            RemisionesDetallesService[] rd = new RemisionesDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                rd[i] = new RemisionesDetallesService(rows[i]);

            return rd;
        }
        #endregion Buscar

        #region GetDetallesPosibles
        public static DetallePosible[] GetDetallesPosibles(Hashtable filtrado)
        {
            using(SessionService sesion = new SessionService())
            {
                string detalleId = "id";
                string fecha = "fecha";
                string casoId = "caso_id";
                string loteId = "lote_id";
                string unidadMedidaId = "unidad_medida_id";
                string cantidadInicial = "cantidad_inicial";
                string cantidadSaldo = "cantidad_saldo";

                //Todos los casos que sean de facturas cliente o pedido de cliente para:
                //  Persona y rango de fechas indicados.
                //  En cualquier sucursal de la región, si la variable de sistema indica que las regiones son empresas.
                //Los pedidos deben estar en pre-aprobado, preparado o aprobado y no estar marcado para usar remisiones, mirando solo lo ya preparado.
                //Las facturas deben estar en Caja o Cerrado y sus detalles no provienen de pedido de cliente, o bien el pedido no está marcado para usar remisiones.
                //La suma de lo ya remitido debe ser menor a la cantidad del detalle.
                string sql =
                    "select " + fecha + ", " + casoId + ", " + detalleId + ", " + loteId + ", " + unidadMedidaId + ", " + cantidadInicial + ", " + cantidadSaldo +
                    "  from ( " +
                    "select trunc(c." + CasosService.FechaFormulario_NombreCol + ") " + fecha + ", " +
                    "       c." + CasosService.Id_NombreCol + " " + casoId + ", " +
                    "       pcd." + NotasDePedidoDetalleService.Id_NombreCol + " " + detalleId + ", " +
                    "       pcd." + NotasDePedidoDetalleService.LoteId_NombreCol + " " + loteId + ", " +
                    "       pcd." + NotasDePedidoDetalleService.UnidadIdDestino_NombreCol + " " + unidadMedidaId + ", " +
                    "       sum(dpe." + DepositoPreparacionEstadoService.Cantidad_NombreCol + ") " + cantidadInicial + ", " +
                    "       sum(dpe." + DepositoPreparacionEstadoService.Cantidad_NombreCol + ") - " +
                    "       nvl((" +
                    "        select sum(rd." + RemisionesDetallesService.Modelo.CANTIDADColumnName + ") " +
                    "          from " + RemisionesDetallesService.Nombre_Tabla + " rd, " + RemisionesService.Nombre_Tabla + " r, " + CasosService.Nombre_Tabla + " c2 " +
                    "         where r." + RemisionesService.Modelo.CASO_IDColumnName + " = c2." + CasosService.Id_NombreCol +
                    "           and rd." + RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = r." + RemisionesService.Modelo.IDColumnName +
                    "           and c2." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                    "           and rd." + RemisionesDetallesService.Modelo.PEDIDO_CLIENTE_DETALLE_IDColumnName + " = pcd." + NotasDePedidoDetalleService.Id_NombreCol +
                    "           and c2." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "           and r." + RemisionesService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " +
                    "           and rd." + RemisionesDetallesService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " +
                    "        ), 0) " + cantidadSaldo +
                    "  from " + CasosService.Nombre_Tabla + " c," +
                    "       " + NotasDePedidosService.Nombre_Tabla + " pc," +
                    "       " + NotasDePedidoDetalleService.Nombre_Tabla + " pcd, " +
                    "       " + DepositoPreparacionEstadoService.Nombre_Tabla + " dpe " +
                    " where c." + CasosService.Id_NombreCol + " = pc." + NotasDePedidosService.CASO_ID_NombreCol +
                    "   and pc." + NotasDePedidosService.ID_NombreCol + " = pcd." + NotasDePedidoDetalleService.PedidosClienteId_NombreCol +
                    "   and pc." + NotasDePedidosService.ID_NombreCol + " = dpe." + DepositoPreparacionEstadoService.PedidoClienteId_NombreCol +
                    "   and pcd." + NotasDePedidoDetalleService.ArticuloId_NombreCol + " = dpe." + DepositoPreparacionEstadoService.ArticuloId_NombreCol +
                    "   and c." + CasosService.PersonaId_NombreCol + " = " + filtrado[RemisionesService.Modelo.PERSONA_IDColumnName];
                if (filtrado.ContainsKey(RemisionesService.Modelo.CASO_IDColumnName))
                    sql += " and c." + CasosService.Id_NombreCol + " = " + filtrado[RemisionesService.Modelo.CASO_IDColumnName];
                if (filtrado.ContainsKey(RemisionesService.Modelo.NRO_COMPROBANTEColumnName))
                    sql += " and upper(c." + CasosService.NroComprobante_NombreCol + ") like '%" + ((string)filtrado[RemisionesService.Modelo.NRO_COMPROBANTEColumnName]).ToUpper() + "%' ";
                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionRepresentaEmpresa) == Definiciones.SiNo.Si)
                    sql += " and c." + CasosService.SucursalId_NombreCol + " in (select s." + SucursalesService.Id_NombreCol + " from " + SucursalesService.Nombre_Tabla + " s where s." + SucursalesService.RegionId_NombreCol + " = " + SucursalesService.GetRegionID((decimal)filtrado[RemisionesService.Modelo.SUCURSAL_IDColumnName], sesion) + ") ";
                if (filtrado.ContainsKey(RemisionesService.Modelo.FECHA_INICIO_TRASLADOColumnName))
                    sql += " and trunc(c." + CasosService.FechaFormulario_NombreCol + ") >= to_date('" + ((DateTime)filtrado[RemisionesService.Modelo.FECHA_INICIO_TRASLADOColumnName]).ToShortDateString() + "', 'dd/mm/yyyy') ";
                if (filtrado.ContainsKey(RemisionesService.Modelo.FECHA_FIN_TRASLADOColumnName))
                    sql += " and trunc(c." + CasosService.FechaFormulario_NombreCol + ") <= to_date('" + ((DateTime)filtrado[RemisionesService.Modelo.FECHA_FIN_TRASLADOColumnName]).ToShortDateString() + "', 'dd/mm/yyyy') ";
                sql += "and c." + CasosService.EstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.PreAprobado + "', '" + Definiciones.EstadosFlujos.Preparado + "', '" + Definiciones.EstadosFlujos.Aprobado + "') " +
                    "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "   and dpe." + DepositoPreparacionEstadoService.DepositoEstado_NombreCol + " = '" + Definiciones.EstadosDeposito.Preparado + "' " +
                    "   and dpe." + DepositoPreparacionEstadoService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "   and pc." + NotasDePedidosService.UsarRemisiones_NombreCol + " = '" + Definiciones.SiNo.Si + "' " +
                    " group by trunc(c." + CasosService.FechaFormulario_NombreCol + "), c." + CasosService.Id_NombreCol + ", pcd." + NotasDePedidoDetalleService.Id_NombreCol + ", pcd." + NotasDePedidoDetalleService.LoteId_NombreCol + ", pcd." + NotasDePedidoDetalleService.UnidadIdDestino_NombreCol + " " +
                    "union " +
                    "select trunc(c." + CasosService.FechaFormulario_NombreCol + ") " + fecha + ", " +
                    "       c." + CasosService.Id_NombreCol + " " + casoId + ", " +
                    "       fcd." + FacturasClienteDetalleService.Id_NombreCol + " " + detalleId + ", " +
                    "       fcd." + FacturasClienteDetalleService.LoteId_NombreCol + " " + loteId + ", " +
                    "       fcd." + FacturasClienteDetalleService.UnidadDestinoId_NombreCol + " " + unidadMedidaId + ", " +
                    "       fcd." + FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol + " " + cantidadInicial + ", " +
                    "       fcd." + FacturasClienteDetalleService.CantidadUnitariaTotalDest_NombreCol + " - " +
                    "       nvl((" +
                    "        select sum(rd." + RemisionesDetallesService.Modelo.CANTIDADColumnName + ") " +
                    "          from " + RemisionesDetallesService.Nombre_Tabla + " rd, " + RemisionesService.Nombre_Tabla + " r, " + CasosService.Nombre_Tabla + " c2 " +
                    "         where r." + RemisionesService.Modelo.CASO_IDColumnName + " = c2." + CasosService.Id_NombreCol +
                    "           and rd." + RemisionesDetallesService.Modelo.REMISION_IDColumnName + " = r." + RemisionesService.Modelo.IDColumnName +
                    "           and c2." + CasosService.EstadoId_NombreCol + " <> '" + Definiciones.EstadosFlujos.Anulado + "' " +
                    "           and rd." + RemisionesDetallesService.Modelo.FACTURA_CLIENTE_DETALLE_IDColumnName + " = fcd." + FacturasClienteDetalleService.Id_NombreCol +
                    "           and c2." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "           and r." + RemisionesService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " +
                    "           and rd." + RemisionesDetallesService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " +
                    "           and not exists(select pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.Id_NombreCol + 
                    "                            from " + NotasDePedidoDetalleFacturaClienteRelacionesService.Nombre_Tabla + " pcfr, " +
                    "                                 " + NotasDePedidoDetalleService.Nombre_Tabla + " pcd, " +
                    "                                 " + NotasDePedidosService.Nombre_Tabla + " pc, " +
                    "                                 " + CasosService.Nombre_Tabla + " c3 " +
                    "                           where fcd." + FacturasClienteDetalleService.Id_NombreCol + " = pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.FacturaClienteDetalleId_NombreCol +
                    "                             and pcd." + NotasDePedidoDetalleService.Id_NombreCol + " = pcfr." + NotasDePedidoDetalleFacturaClienteRelacionesService.PedidoClienteDetalleId_NombreCol +
                    "                             and pc." + NotasDePedidosService.ID_NombreCol + " = pcd." + NotasDePedidoDetalleService.PedidosClienteId_NombreCol +
                    "                             and pc." + NotasDePedidosService.UsarRemisiones_NombreCol + " = '" + Definiciones.SiNo.No + "' " +
                    "                             and pc." + NotasDePedidosService.CASO_ID_NombreCol + " = c3." + CasosService.Id_NombreCol +
                    "                             and c3." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "                         ) " +
                    "        ), 0) " + cantidadSaldo +
                    "  from " + CasosService.Nombre_Tabla + " c," +
                    "       " + FacturasClienteService.Nombre_Tabla + " fc," +
                    "       " + FacturasClienteDetalleService.Nombre_Tabla + " fcd " +
                    " where c." + CasosService.Id_NombreCol + " = fc." + FacturasClienteService.CasoId_NombreCol +
                    "   and fc." + FacturasClienteService.Id_NombreCol + " = fcd." + FacturasClienteDetalleService.FacturaClienteId_NombreCol +
                    "   and c." + CasosService.PersonaId_NombreCol + " = " + filtrado[RemisionesService.Modelo.PERSONA_IDColumnName];
                if (filtrado.ContainsKey(RemisionesService.Modelo.CASO_IDColumnName))
                    sql += " and c." + CasosService.Id_NombreCol + " = " + filtrado[RemisionesService.Modelo.CASO_IDColumnName];
                if (filtrado.ContainsKey(RemisionesService.Modelo.NRO_COMPROBANTEColumnName))
                    sql += " and upper(c." + CasosService.NroComprobante_NombreCol + ") like '%" + ((string)filtrado[RemisionesService.Modelo.NRO_COMPROBANTEColumnName]).ToUpper() + "%' ";
                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionRepresentaEmpresa) == Definiciones.SiNo.Si)
                    sql += " and c." + CasosService.SucursalId_NombreCol + " in (select s." + SucursalesService.Id_NombreCol + " from " + SucursalesService.Nombre_Tabla + " s where s." + SucursalesService.RegionId_NombreCol + " = " + SucursalesService.GetRegionID((decimal)filtrado[RemisionesService.Modelo.SUCURSAL_IDColumnName], sesion) + ") ";
                if (filtrado.ContainsKey(RemisionesService.Modelo.FECHA_INICIO_TRASLADOColumnName))
                    sql += " and trunc(c." + CasosService.FechaFormulario_NombreCol + ") >= to_date('" + ((DateTime)filtrado[RemisionesService.Modelo.FECHA_INICIO_TRASLADOColumnName]).ToShortDateString() + "', 'dd/mm/yyyy') ";
                if (filtrado.ContainsKey(RemisionesService.Modelo.FECHA_INICIO_TRASLADOColumnName))
                    sql += " and trunc(c." + CasosService.FechaFormulario_NombreCol + ") <= to_date('" + ((DateTime)filtrado[RemisionesService.Modelo.FECHA_FIN_TRASLADOColumnName]).ToShortDateString() + "', 'dd/mm/yyyy') ";
                sql += "and c." + CasosService.EstadoId_NombreCol + " in ('" + Definiciones.EstadosFlujos.Caja + "', '" + Definiciones.EstadosFlujos.Cerrado + "') " +
                    "   and c." + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "   and fc." + FacturasClienteService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' " +
                    "   and fc." + FacturasClienteService.AfectaStock_NombreCol + " = '" + Definiciones.SiNo.No + "' " +
                    ") " +
                    " where " + cantidadSaldo + " > 0 " +
                    " order by " + fecha + ", " + casoId;

                var dUnidades = new Dictionary<string, UnidadesService>();
                List<DetallePosible> ldetallePosible = new List<DetallePosible>();
                var dt = sesion.db.EjecutarQuery(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!dUnidades.ContainsKey((string)dt.Rows[i][unidadMedidaId]))
                        dUnidades.Add((string)dt.Rows[i][unidadMedidaId], new UnidadesService((string)dt.Rows[i][unidadMedidaId], sesion));

                    ldetallePosible.Add(new DetallePosible() 
                    {
                        caso = new CasosService((decimal)dt.Rows[i][casoId], sesion),
                        detalleId = (decimal)dt.Rows[i][detalleId],
                        lote = new ArticulosLotesService((decimal)dt.Rows[i][loteId], sesion),
                        unidadMedida = dUnidades[(string)dt.Rows[i][unidadMedidaId]],
                        cantidadInicial = (decimal)dt.Rows[i][cantidadInicial],
                        cantidadSaldo = (decimal)dt.Rows[i][cantidadSaldo]
                    });
                }

                return ldetallePosible.ToArray();
            }
        }
        #endregion GetDetallesPosibles       

        #region GetStockMovimiento
        public StockMovimientoService GetStockMovimiento(SessionService sesion)
        {
            return GetStockMovimiento(this.Remision.CasoId.Value, sesion);
        }

        public StockMovimientoService GetStockMovimiento(decimal caso_id, SessionService sesion)
        {
            var sm = new StockMovimientoService();
            sm.IniciarUsingSesion(sesion);

            var movimiento = StockMovimientoService.Instancia.GetPrimero<StockMovimientoService>(new ClaseCBABase.Filtro[] {
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = caso_id },
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = this.Id.Value },
                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.IDColumnName, OrderBy = true, Valor = "desc" }
            });

            sm.FinalizarUsingSesion();

            return movimiento;
        }
        #endregion GetStockMovimiento

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

        #region Accessors
        public static string Nombre_Tabla = "REMISIONES_DETALLES";
        public static string Nombre_Secuencia = "REMISIONES_DETALLES_SQC";
        #endregion Accessors
    }
}
