using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CentrosCostoService
    {
        #region clase Participacion
        private class Participacion
        {
            #region sub clases
            private class Elemento
            {
                public decimal centroCostoId;
                public decimal centroCostoPorcentaje;
                public decimal monto;
            }

            private class Detalle
            {
                private decimal id;
                public decimal monto { get; private set; }
                public List<Elemento> centrosCosto { get; private set; }

                public Detalle(decimal id, decimal monto)
                {
                    this.id = id;
                    this.monto = monto;
                    this.centrosCosto = new List<Elemento>();
                }

                public void Agregar(AsientosDetalleService.Detalle asiento_detalle, Dictionary<decimal, decimal> centros_costo)
                {
                    foreach (KeyValuePair<decimal, decimal> item in centros_costo)
                    {
                        this.centrosCosto.Add(new Elemento()
                        {
                            centroCostoId = item.Key,
                            centroCostoPorcentaje = item.Value,
                            monto = this.monto * item.Value / 100
                        });
                    }
                }
            }

            private class Cuenta
            {
                private Dictionary<decimal, Detalle> detalles; //Diccionario de detalles por su id
                private decimal suma;

                public Cuenta()
                {
                    this.detalles = new Dictionary<decimal, Detalle>();
                    this.suma = 0;
                }

                public void Agregar(decimal detalle_id, AsientosDetalleService.Detalle asiento_detalle, Dictionary<decimal, decimal> centros_costo, decimal monto)
                {
                    if (centros_costo.Count == 0)
                        centros_costo.Add(Definiciones.Error.Valor.EnteroPositivo, 100);

                    if (!this.detalles.ContainsKey(detalle_id))
                        this.detalles.Add(detalle_id, new Detalle(detalle_id, monto));
                    this.detalles[detalle_id].Agregar(asiento_detalle, centros_costo);

                    this.suma += monto;
                }

                public Hashtable GetCentrosCosto()
                {
                    var ht = new Hashtable();

                    //Tomando en cuenta: cuenta_contable - detalle_id - centro_costo
                    //Hay que normalizar el porcentaje dentro de cada cuenta contable
                    foreach (KeyValuePair<decimal, Detalle> d in this.detalles)
                    {
                        foreach (Elemento e in d.Value.centrosCosto)
                        {
                            if (!ht.Contains(e.centroCostoId))
                                ht.Add(e.centroCostoId, (decimal)0);

                            ht[e.centroCostoId] = (decimal)ht[e.centroCostoId] + (e.centroCostoPorcentaje * d.Value.monto / this.suma );
                        }
                    }

                    //Se quita el centro de costo artificial que 
                    //permite asiganciones menores al 100%
                    ht.Remove(Definiciones.Error.Valor.EnteroPositivo);

                    return ht;
                }
            }
            #endregion sub clases

            private Dictionary<decimal, Cuenta> cuentas; //Diccionario de cuentas por su id

            public Participacion()
            {
                this.cuentas = new Dictionary<decimal, Cuenta>();
            }

            public void Agregar(decimal? detalle_id, AsientosDetalleService.Detalle asiento_detalle, Dictionary<decimal, decimal> centros_costo, decimal porcentaje)
            {
                decimal monto = (asiento_detalle.Debe + asiento_detalle.Haber) * porcentaje;
                
                if (!this.cuentas.ContainsKey(asiento_detalle.CuentaId))
                    this.cuentas.Add(asiento_detalle.CuentaId, new Cuenta());
                this.cuentas[asiento_detalle.CuentaId].Agregar(detalle_id ?? Definiciones.Error.Valor.EnteroPositivo, asiento_detalle, centros_costo, monto);
            }

            public Hashtable GetCentrosCosto(decimal cuenta_id)
            {
                //Si no existe la cuenta entonces no tiene distribucion por centro de costo
                if (!this.cuentas.ContainsKey(cuenta_id))
                    return new Hashtable();

                return this.cuentas[cuenta_id].GetCentrosCosto();
            }
        }
        #endregion clase Participacion

        #region Clase que debe ser implementada por cada asiento automatico de ser necesario
        public abstract class CentrosCostoAplicacionWorkaround : CentrosCostoAplicacion<FlujosServiceBaseWorkaround>
        {
            protected CentrosCostoAplicacionWorkaround(FlujosServiceBaseWorkaround flujo_service) : base(flujo_service) { }
        }

        public abstract class CentrosCostoAplicacion<T> where T : new()
        {
            protected FlujosServiceBase<T> flujoService;
            private Participacion participacion;
            protected Hashtable porcentajeDetalleSobreTotal;
            protected Hashtable detalles; //Utilizado si el flujo permite definir al usuario el desglose por detalle

            protected CentrosCostoAplicacion(FlujosServiceBase<T> flujo_service)
            {
                this.detalles = new Hashtable();
                this.porcentajeDetalleSobreTotal = new Hashtable();
                this.participacion = new Participacion();
                this.flujoService = flujo_service;
            }

            #region AgregarCuentaContable
            public void AgregarCuentaContable(decimal? detalle_id, AsientosDetalleService.Detalle asiento_detalle, Dictionary<decimal, decimal> centros_costo, decimal porcentaje)
            {
                this.participacion.Agregar(detalle_id, asiento_detalle, centros_costo, porcentaje);
            }
            #endregion AgregarCuentaContable

            #region Seleccionar
            public Dictionary<decimal, decimal> Seleccionar(decimal? detalle_id, object prioridad_1, object prioridad_2, object prioridad_3, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
            {
                Dictionary<decimal, decimal> resultado = new Dictionary<decimal, decimal>();
                decimal p1 = Interprete.EsNullODBNull(prioridad_1) ? Definiciones.Error.Valor.EnteroPositivo : (decimal)prioridad_1;
                decimal p2 = Interprete.EsNullODBNull(prioridad_2) ? Definiciones.Error.Valor.EnteroPositivo : (decimal)prioridad_2;
                decimal p3 = Interprete.EsNullODBNull(prioridad_3) ? Definiciones.Error.Valor.EnteroPositivo : (decimal)prioridad_3;

                if (!detalle_id.HasValue)
                    detalle_id = Definiciones.Error.Valor.EnteroPositivo;

                if (p1 == Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.DefinidoPorUsuario && detalles.Contains(detalle_id))
                    resultado = (Dictionary<decimal, decimal>)detalles[detalle_id];
                else
                    resultado = ((IFlujo)this.flujoService).SeleccionarCentrosCosto(p1, caso, caso_cabecera, caso_detalle, sesion);

                if (resultado.Count > 0)
                    return resultado;

                if (p2 == Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.DefinidoPorUsuario && detalles.Contains(detalle_id))
                    resultado = (Dictionary<decimal, decimal>)detalles[detalle_id];
                else
                    resultado = ((IFlujo)this.flujoService).SeleccionarCentrosCosto(p2, caso, caso_cabecera, caso_detalle, sesion);

                if (resultado.Count > 0)
                    return resultado;

                if (p3 == Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.DefinidoPorUsuario && detalles.Contains(detalle_id))
                    resultado = (Dictionary<decimal, decimal>)detalles[detalle_id];
                else
                    resultado = ((IFlujo)this.flujoService).SeleccionarCentrosCosto(p3, caso, caso_cabecera, caso_detalle, sesion);

                return resultado;
            }
            #endregion

            #region GetCentrosCosto
            public Hashtable GetCentrosCosto(AsientosDetalleService.Detalle asiento_detalle)
            {
                return this.participacion.GetCentrosCosto(asiento_detalle.CuentaId);
            }
            #endregion GetCentrosCosto
        }
        #endregion Clase que debe ser implementada por cada asiento automatico de ser necesario

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="centro_costo_id">The centro_costo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal centro_costo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CENTROS_COSTORow row = sesion.Db.CENTROS_COSTOCollection.GetByPrimaryKey(centro_costo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EsGrupo
        public static bool EsGrupo(decimal centro_costo_id, SessionService sesion)
        {
            CENTROS_COSTORow row = sesion.Db.CENTROS_COSTOCollection.GetByPrimaryKey(centro_costo_id);
            return !row.IsCENTRO_COSTO_GRUPO_IDNull;
        }
        #endregion EsGrupo

        #region GetCentrosCostoDataTable
        /// <summary>
        /// Gets the centros costo data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCentrosCostoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCentrosCostoDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCentrosCostoDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CENTROS_COSTOCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetBarriosDataTable

        #region GetOrdenMaximo
        public static decimal GetOrdenMaximo()
        {
            using (SessionService sesion = new SessionService())
            {
                string sql = "select nvl(max(orden),0) from " + CentrosCostoService.Nombre_Tabla;
                DataTable dt = sesion.db.EjecutarQuery(sql);
                return decimal.Parse(dt.Rows[0][0].ToString());
            }
        }
        #endregion GetOrdenMaximo

        #region SeleccionarCentrosCosto
        public static Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, Dictionary<decimal, object> campos, SessionService sesion)
        {
            Dictionary<decimal, decimal> resultado = new Dictionary<decimal, decimal>();
            decimal centroCostoId = Definiciones.Error.Valor.EnteroPositivo;

            #region prioridad
            if (campos.ContainsKey(prioridad) && !Interprete.EsNullODBNull(campos[prioridad]) && (decimal)campos[prioridad] > 0)
            {
                switch ((int)prioridad)
                {
                    case Definiciones.Error.Valor.IntPositivo:
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal:
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.SucursalRelacionada:
                        centroCostoId = SucursalesService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region:
                        centroCostoId = RegionesService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona:
                        centroCostoId = PersonasService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario:
                        centroCostoId = FuncionariosService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor:
                        centroCostoId = ProveedoresService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito:
                        centroCostoId = Stock.StockDepositosService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo:
                        centroCostoId = Articulos.ArticulosService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido:
                        centroCostoId = TextosPredefinidos.TextosPredefinidosService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    case Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo:
                        centroCostoId = Activos.ActivosService.GetCentroCosto((decimal)campos[prioridad], sesion);
                        break;
                    default: throw new Exception("CentrosCostoService.SeleccionarCentrosCosto(). TiposAsientosAutomaticosRelacionesCentroCostoPrioridad no implementado");
                }
            }
            #endregion prioridad

            if (centroCostoId != Definiciones.Error.Valor.EnteroPositivo)
                resultado.Add(centroCostoId, 100);
            return resultado;
        }
        #endregion SeleccionarCentrosCosto

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, sesion);
                    sesion.CommitTransaction();

                    return id;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                CENTROS_COSTORow row = new CENTROS_COSTORow();
                string valorAnterior = string.Empty;

                #region Validaciones
                if (((string)campos[CentrosCostoService.Nombre_NombreCol]).Length <= 0)
                    throw new Exception("Debe indicar el nombre");
                if (((string)campos[CentrosCostoService.Abreviatura_NombreCol]).Length <= 0)
                    throw new Exception("Debe indicar la abreviatura");

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.CentrosCostoControlarUnicidadNombre) == Definiciones.SiNo.Si)
                {
                    string clausulas = "upper(" + CentrosCostoService.Nombre_NombreCol + ") = '" + ((string)campos[Nombre_NombreCol]).ToUpper() + "'";
                    if (campos.Contains(CentrosCostoService.Id_NombreCol))
                        clausulas += " and " + CentrosCostoService.Id_NombreCol + " <> " + campos[CentrosCostoService.Id_NombreCol];
                    DataTable dtAux = CentrosCostoService.GetCentrosCostoDataTable(clausulas, string.Empty);
                    if (dtAux.Rows.Count > 0)
                        throw new Exception("Ya existe un centro de costo con el mismo nombre.");
                }
                #endregion Validaciones

                if (!campos.Contains(CentrosCostoService.Id_NombreCol))
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("centros_costo_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    row = sesion.Db.CENTROS_COSTOCollection.GetByPrimaryKey((decimal)campos[CentrosCostoService.Id_NombreCol]);
                    valorAnterior = row.ToString();
                }

                row.ABREVIATURA = (string)campos[CentrosCostoService.Abreviatura_NombreCol];
                row.ESTADO = (string)campos[CentrosCostoService.Estado_NombreCol];
                row.NOMBRE = (string)campos[CentrosCostoService.Nombre_NombreCol];
                row.ORDEN = (decimal)campos[CentrosCostoService.Orden_NombreCol];
                row.ES_UNIDAD_NEGOCIO = Definiciones.SiNo.No;

                //Una vez asociado no puede desvincularse
                if (campos.Contains(CentrosCostoService.CentroCostoGrupoId_NombreCol))
                    row.CENTRO_COSTO_GRUPO_ID = (decimal)campos[CentrosCostoService.CentroCostoGrupoId_NombreCol];

                if (!campos.Contains(CentrosCostoService.Id_NombreCol)) sesion.Db.CENTROS_COSTOCollection.Insert(row);
                else sesion.Db.CENTROS_COSTOCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                return row.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CENTROS_COSTO"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return CENTROS_COSTOCollection.ABREVIATURAColumnName; }
        }
        public static string CentroCostoGrupoId_NombreCol
        {
            get { return CENTROS_COSTOCollection.CENTRO_COSTO_GRUPO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CENTROS_COSTOCollection.ESTADOColumnName; }
        }
        public static string EsUnidadDeNegocio_NombreCol
        {
            get { return CENTROS_COSTOCollection.ES_UNIDAD_NEGOCIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CENTROS_COSTOCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CENTROS_COSTOCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return CENTROS_COSTOCollection.ORDENColumnName; }
        }
        #endregion Accessors
    }
}
