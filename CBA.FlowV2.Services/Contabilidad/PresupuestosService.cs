#region Using
using System;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.TextosPredefinidos;
using CBA.FlowV2.Services.Common;
using System.ComponentModel;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class PresupuestosService : ClaseCBA<PresupuestosService>
    {
        #region clase Filtros
        public partial class Filtros
        {
            #region clases
            public class Valor
            {
                public int Id { get; set; }
                public int[] Ids { get; set; }
                public string Texto { get; set; }
                public bool ValorLogico { get; set; }
                public bool ValorExacto { get; set; }
            }

            public enum Tipo : int
            {
                Estado = 0,
                Nombre = 1,
                Region = 2,
                Sucursal = 3,
            }
            #endregion clases

            #region propiedades
            public Dictionary<Tipo, Valor> FiltrosDefinidos { get; private set; }
            public int Cantidad { get { return this.FiltrosDefinidos.Count; } }
            public static string DataTable_ColumnaNombre = "__NOMBRE__";
            public static string DataTable_ColumnaValor = "__VALOR__";
            #endregion propiedades

            #region constructor
            public Filtros()
            {
                this.FiltrosDefinidos = new Dictionary<Tipo, Valor>();
            }
            #endregion constructor

            #region GetDataTable()
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(DataTable_ColumnaNombre, typeof(string));
                dt.Columns.Add(DataTable_ColumnaValor, typeof(int));

                dt.Rows.Add("Estado", Tipo.Estado);
                dt.Rows.Add("Nombre", Tipo.Nombre);
                dt.Rows.Add("Región", Tipo.Region);
                dt.Rows.Add("Sucursal", Tipo.Sucursal);

                return dt;
            }
            #endregion GetDataTable()

            #region Agregar
            public void Agregar(Tipo tipo, Valor valor)
            {
                if (this.FiltrosDefinidos.ContainsKey(tipo))
                    throw new Exception("Ya existe un filtro del mismo tipo");
                this.FiltrosDefinidos.Add(tipo, valor);
            }
            #endregion Agregar

            #region Quitar
            public void Quitar(Tipo tipo)
            {
                this.FiltrosDefinidos.Remove(tipo);
            }
            #endregion Quitar

            #region GetSQL
            public string GetSQL()
            {
                string clausulas = " 1=1 ";

                foreach (KeyValuePair<Tipo, Valor> f in this.FiltrosDefinidos)
                {
                    clausulas += " and ";
                    switch (f.Key)
                    {
                        case Tipo.Estado:
                            clausulas += CTB_PRESUPUESTOSCollection.ESTADOColumnName + " = '" + f.Value.Texto + "' ";
                            break;
                        case Tipo.Nombre:
                            if(f.Value.ValorExacto)
                                clausulas += " upper(" + CTB_PRESUPUESTOSCollection.NOMBREColumnName + ") = '" + f.Value.Texto.ToUpper() + "' ";
                            else
                                clausulas += " upper(" + CTB_PRESUPUESTOSCollection.NOMBREColumnName + ") like '%" + f.Value.Texto.ToUpper() + "%' ";
                            break;
                        case Tipo.Region:
                            if (f.Value.Id > 0)
                                clausulas += CTB_PRESUPUESTOSCollection.REGION_IDColumnName + " = " + f.Value.Id + " ";
                            else
                                clausulas += CTB_PRESUPUESTOSCollection.REGION_IDColumnName + " in (" + string.Join("", new List<int>(f.Value.Ids).ConvertAll(i => i.ToString()).ToArray()) + " ";
                            break;
                        case Tipo.Sucursal:
                            if (f.Value.Id > 0)
                                clausulas += CTB_PRESUPUESTOSCollection.SUCURSAL_IDColumnName + " = " + f.Value.Id + " ";
                            else
                                clausulas += CTB_PRESUPUESTOSCollection.SUCURSAL_IDColumnName + " in (" + string.Join("", new List<int>(f.Value.Ids).ConvertAll(i => i.ToString()).ToArray()) + " ";
                            break;
                        default: throw new Exception("Tipo de filtro no definido.");
                    }
                }

                return clausulas;
            }
            #endregion GetSQL

            #region ToString
            public string ToString(Tipo tipo)
            {
                string s = "";
                Valor v = this.FiltrosDefinidos[tipo];

                switch (tipo)
                {
                    case Tipo.Estado:
                        s = "Estado " + (v.Texto == Definiciones.Estado.Activo ? "activo" : "inactivo") + ".";
                        break;
                    case Tipo.Nombre:
                        s = "Nombre " + (v.ValorExacto ? "es" : "contiene") + " " + v.Texto + ".";
                        break;
                    case Tipo.Region:
                        s = "Región " + (new RegionesService(v.Id)).Nombre + ".";
                        break;
                    case Tipo.Sucursal:
                        s = "Región " + (new SucursalesService(v.Id)).Nombre + ".";
                        break;
                    default: throw new Exception("Tipo de filtro no definido.");
                }

                return s;
            }
            #endregion ToString
        }
        #endregion clase Filtros

        #region clase Rango
        public class Rango
        {
            [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
            public string Nombre;
            [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
            public int MesInicio;
            [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
            public int MesFin;
        }
        #endregion clase Rango

        #region Propiedades
        protected CTB_PRESUPUESTOSRow row;
        protected CTB_PRESUPUESTOSRow rowSinModificar;
        public class Modelo : CTB_PRESUPUESTOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal CtbPlanCuentaId { get { return row.CTB_PLAN_CUENTA_ID; } set { row.CTB_PLAN_CUENTA_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public string Nombre { get { return GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal? RegionId { get { if (row.IsREGION_IDNull) return null; else return row.REGION_ID; } set { if (value.HasValue) row.REGION_ID = value.Value; else row.IsREGION_IDNull = true; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        private Rango[] _rangos;
        public Rango[] Rangos
        {
            get
            {
                if (this._rangos == null)
                {
                    if (Interprete.EsNullODBNull(row.RANGOS))
                    {
                        this._rangos = new Rango[1];
                        this._rangos[0].Nombre = "Año";
                        this._rangos[0].MesInicio = 1;
                        this._rangos[0].MesFin = 12;
                    }
                    else
                    {
                        this._rangos = JsonUtil.Deserializar<Rango[]>(row.RANGOS);
                    }
                }
                return this._rangos;
            }
            set
            {
                this._rangos = value;

                if (this.ExisteEnDB)
                    CrearDetalles();
            }
        }
        #endregion Propiedades

        #region Propiedades Extendidas
        private PlanesDeCuentaService _ctb_plan_cuenta;
        public PlanesDeCuentaService CTBPlanCuenta
        {
            get
            {
                if (this._ctb_plan_cuenta == null)
                    this._ctb_plan_cuenta = new PlanesDeCuentaService(this.CtbPlanCuentaId);
                return this._ctb_plan_cuenta;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }

        private RegionesService _region;
        public RegionesService Region
        {
            get
            {
                if (this._region == null)
                    this._region = new RegionesService(this.RegionId.Value);
                return this._region;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId.Value);
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_PRESUPUESTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_PRESUPUESTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTB_PRESUPUESTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PresupuestosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PresupuestosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PresupuestosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private PresupuestosService(CTB_PRESUPUESTOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!RolesService.Tiene("ctb presupuestos editar"))
                throw new Exception("No tiene permisos para guardar"); 
            
            this.Validar();

            this.row.RANGOS = JsonUtil.Serializar(this.Rangos);

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.CTB_PRESUPUESTOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);

                CrearDetalles(sesion);
            }
            else
            {
                sesion.db.CTB_PRESUPUESTOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);

                if (rowSinModificar.CTB_PLAN_CUENTA_ID != row.CTB_PLAN_CUENTA_ID)
                    CrearDetalles(sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.Nombre.Length <= 0)
                excepciones.Agregar("Debe indicar el nombre.", null);
            if (this.MonedaId <= 0)
                excepciones.Agregar("Debe seleccionar la moneda.", null);
            if (this.Estado.Length <= 0)
                excepciones.Agregar("Debe seleccionar el estado.", null);
            if (this.RegionId <= 0)
                excepciones.Agregar("Debe seleccionar la región o desmarcar su uso.", null);
            if (this.SucursalId <= 0)
                excepciones.Agregar("Debe seleccionar la sucursal o desmarcar su uso.", null);

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._ctb_plan_cuenta = null;
            this._moneda = null;
            this._region = null;
            this._sucursal = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override PresupuestosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CTB_PLAN_CUENTA_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.REGION_IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.NOMBREColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CTB_PRESUPUESTOSRow[] rows = sesion.db.CTB_PRESUPUESTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            PresupuestosService[] p = new PresupuestosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                p[i] = new PresupuestosService(rows[i]);
            return p;
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

        #region CrearDetalles
        private void CrearDetalles()
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                CrearDetalles(sesion);
                this.FinalizarUsingSesion();
            }
        }

        private void CrearDetalles(SessionService sesion)
        {
            DataTable dtCuentas = CuentasService.GetCuentasInfoCompleta(CuentasService.CtbPlanCuentaId_NombreCol + " = " + this.CtbPlanCuentaId + " and " + CuentasService.Asentable_NombreCol + " = '" + Definiciones.SiNo.Si + "'", CuentasService.VistaCodigoCompleto_NombreCol);
            for (int i = 0; i < dtCuentas.Rows.Count; i++)
            {
                PresupuestosDetallesService[] pd = this.GetFiltrado<PresupuestosDetallesService>(new Filtro[]
                    {
                        new Filtro { Columna = PresupuestosDetallesService.Modelo.CTB_PRESUPUESTO_IDColumnName, Valor = this.Id.Value },
                        new Filtro { Columna = PresupuestosDetallesService.Modelo.CTB_CUENTA_IDColumnName, Valor = dtCuentas.Rows[i][CuentasService.Id_NombreCol] }
                    }
                );

                for (int j = 0; j < pd.Length; j++)
                    pd[j].Borrar(sesion);

                for (int j = 0; j < this.Rangos.Length; j++)
                {
                    PresupuestosDetallesService nuevo = new PresupuestosDetallesService();
                    nuevo.IniciarUsingSesion(sesion);
                    nuevo.CtbPresupuestoId = this.Id.Value;
                    nuevo.CtbCuentaId = (decimal)dtCuentas.Rows[i][CuentasService.Id_NombreCol];
                    nuevo.MesDesde = this.Rangos[j].MesInicio;
                    nuevo.MesHasta = this.Rangos[j].MesFin;
                    nuevo.Monto = 0;
                    nuevo.Nombre = this.Rangos[j].Nombre;
                    nuevo.Guardar();
                    nuevo.FinalizarUsingSesion();
                }
            }
        }
        #endregion CrearDetalles

        #region toString
        public override string ToString()
        {
            return this.Nombre;
        }
        #endregion toString

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTB_PRESUPUESTOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "CTB_PRESUPUESTOS_SQC"; }
        }
        #endregion Accessors
    }
}
