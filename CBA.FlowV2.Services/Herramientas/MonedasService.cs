#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class MonedasService : ClaseCBA<MonedasService>
    {
        #region EstaActivo
        public static bool EstaActivo(decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MONEDASRow moneda = sesion.Db.MONEDASCollection.GetRow(Modelo.IDColumnName + " = " + moneda_id);
                return moneda.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region RefrescarCombobox
        public static void RefrescarCombobox(ref ComboBox cbo)
        {
            cbo.DataSource = GetMonedasActivasPorEntidadPais();
            cbo.DisplayMember = MONEDASCollection.NOMBREColumnName;
            cbo.ValueMember = MONEDASCollection.IDColumnName;
            cbo.SelectedItem = null;
        }
        #endregion

        #region GetNombreMoneda
        /// <summary>
        /// Gets the nombre moneda.
        /// </summary>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public static string GetNombreMoneda(decimal moneda_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                MONEDASRow moneda = sesion.Db.MONEDASCollection.GetByPrimaryKey(moneda_id);
                return moneda.NOMBRE;
            }
        }
        #endregion GetNombreMoneda

        #region GetMontoEnLetras
        /// <summary>
        /// Gets the monto en letras.
        /// </summary>
        /// <param name="monto">The monto.</param>
        /// <returns></returns>
        public static string GetMontoEnLetras(decimal monto)
        {
            using (SessionService sesion = new SessionService())
            {
                if (monto == 0) return string.Empty;

                //Como la separacion decimal es con coma, debe cambiarse a punto
                String valor = monto.ToString();
                valor = valor.Replace(',', '.');

                DataTable dt = sesion.Db.EjecutarQuery("select importeenletras(" + valor + ") from dual");
                string letras = string.Empty;
                if (dt.Rows.Count > 0)
                    letras = dt.Rows[0].Field<String>(0);

                return CBA.FlowV2.Services.Base.StringUtil.MayusculaPrimero(letras);
            }
        }

        public static string GetMontoEnLetrasMayuscula(decimal monto)
        {
            return CBA.FlowV2.Services.Base.StringUtil.MayusculaPrimero(GetMontoEnLetras(monto));
        }
        #endregion GetMontoEnLetras

        #region GetMonedasDataTable
        /// <summary>
        /// Gets the monedas data table.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetMonedasDataTable()
        {
            return GetMonedasDataTable("", Modelo.ORDENColumnName, false);
        }
        public static DataTable GetMonedasDataTable2()
        {
            return GetMonedasDataTable2("", Modelo.ORDENColumnName, false);
        }

        /// <summary>
        /// Gets the monedas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetMonedasDataTable(String clausulas, String orden) 
        {
            return GetMonedasDataTable(clausulas, orden, false);
        }
        public static DataTable GetMonedasDataTable2(String clausulas, String orden)
        {
            return GetMonedasDataTable2(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the monedas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetMonedasDataTable(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Modelo.ESTADOColumnName + "  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.MONEDASCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.MONEDASCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        public static DataTable GetMonedasDataTable2(String clausulas, String orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = Modelo.ESTADOColumnName + "  = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.MONEDASCollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.MONEDASCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }

        #endregion GetMonedasDataTable

        #region GetMonedasActivasPorEntidadPais
        public static DataTable GetMonedasActivasPorEntidadPais()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMonedasActivasPorEntidadPais(sesion.SucursalActiva_Id);
            }
        }

        public static DataTable GetMonedasActivasPorEntidadPais(decimal sucursal_id)
        {
            decimal paisId = SucursalesService.GetPais(sucursal_id);
            DataTable dtMonedasConCotizaciones = (new CotizacionesService()).GetMonedasConCotizacionesPorPaisEntidad(paisId);

            DataTable dtMonedas = new DataTable();
            dtMonedas.Columns.Add(MonedasService.Modelo.IDColumnName, typeof(decimal));
            dtMonedas.Columns.Add(MonedasService.Modelo.NOMBREColumnName, typeof(string));
            dtMonedas.Columns.Add(MonedasService.Modelo.SIMBOLOColumnName, typeof(string));

            foreach (DataRow c in dtMonedasConCotizaciones.Rows)
            {
                dtMonedas.Rows.Add(decimal.Parse(c[CotizacionesService.Modelo.MONEDA_IDColumnName].ToString()), c[CotizacionesService.VistaModelo.MONEDAColumnName].ToString(),c[CotizacionesService.VistaModelo.SIMBOLOColumnName].ToString());
            }
            return dtMonedas;
        }
        #endregion GetMonedasActivasPorEntidadPais

        #region GetMonedasActivas
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetMonedasActivas()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.MONEDASCollection.GetAsDataTable(Modelo.ESTADOColumnName + " ='" + Definiciones.Estado.Activo + "' ", MONEDASCollection.ORDENColumnName);
                return table;
            }
        }
        public static DataTable GetMonedasActivas2()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.MONEDASCollection.GetAsDataTable(Modelo.ESTADOColumnName + " ='" + Definiciones.Estado.Activo + "' ", MONEDASCollection.ORDENColumnName);
                return table;
            }
        }
        #endregion GetMonedasActivas

        #region GetSimbolo
        /// <summary>
        /// Gets the simbolo.
        /// </summary>
        /// <param name="moneda_id">The moneda_id.</param>
        /// <returns></returns>
        public static string GetSimbolo(Decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MONEDASRow moneda = sesion.Db.MONEDASCollection.GetRow(Modelo.IDColumnName + "= " + moneda_id);
                return moneda.SIMBOLO;
            }
        }
        #endregion GetSimbolo

        #region CadenaDecimales
        public static string CadenaDecimales2(decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                MONEDASRow moneda = sesion.Db.MONEDASCollection.GetRow(MonedasService.Modelo.IDColumnName + " = " + moneda_id);
                return moneda.CADENA_DECIMALES;
            }
        }
        public static string CadenaDecimales2(string moneda_nombre)
        {
            using (SessionService sesion = new SessionService())
            {
                MONEDASRow moneda = sesion.Db.MONEDASCollection.GetRow(MonedasService.Modelo.NOMBREColumnName + " = '" + moneda_nombre + "'");
                return moneda.CADENA_DECIMALES;
            }
        }

        public static string MontoFormateadoString(decimal monto, decimal monedaId) 
        {
            return monto.ToString(CadenaDecimales2(monedaId));
        }
        #endregion CadenaDecimales

        #region CantidadDecimales
        public static int CantidadDecimalesStatic(decimal moneda_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return CantidadDecimalesStatic(moneda_id, sesion);
            }
        }
        public static int CantidadDecimalesStatic(decimal moneda_id, SessionService sesion)
        {
            MonedasService moneda = new MonedasService(moneda_id, sesion);
            return moneda.CantidadDecimales;
        }
        #endregion CantidadDecimales

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    MONEDASRow monedas = new MONEDASRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        monedas.ID = sesion.Db.GetSiguienteSecuencia("monedas_sqc");                        
                        valorAnterior = CBA.FlowV2.Services.Base.Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        monedas = sesion.Db.MONEDASCollection.GetRow(Modelo.IDColumnName + " = " + decimal.Parse(campos[Modelo.IDColumnName].ToString()));
                        valorAnterior = monedas.ToString();
                    }

                    monedas.NOMBRE = campos[Modelo.NOMBREColumnName].ToString();
                    monedas.OBSERVACION = campos[Modelo.OBSERVACIONColumnName].ToString();
                    monedas.CANTIDADES_DECIMALES = decimal.Parse(campos[Modelo.CANTIDADES_DECIMALESColumnName].ToString());
                    if (monedas.CANTIDADES_DECIMALES > 0)
                    {
                        monedas.CADENA_DECIMALES = "###,###,##0.00";
                        monedas.MASCARA = "9G999G999D99";
                    }
                    else
                    {
                        monedas.CADENA_DECIMALES = "###,###,###,##0";
                        monedas.MASCARA = "9G999G999G999";
                    }

                    monedas.SIMBOLO = campos[Modelo.SIMBOLOColumnName].ToString();
                    monedas.ISO_4217 = campos[Modelo.ISO_4217ColumnName].ToString();
                    monedas.ORDEN = decimal.Parse(campos[Modelo.ORDENColumnName].ToString());
                    monedas.ESTADO = campos[Modelo.ESTADOColumnName].ToString();

                    if (insertarNuevo) sesion.Db.MONEDASCollection.Insert(monedas);
                    else sesion.Db.MONEDASCollection.Update(monedas);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, monedas.ID, valorAnterior, monedas.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar       

        #region Redondear
        public static decimal Redondear(decimal valor)
        {
            using (SessionService sesion = new SessionService())
            {
                if (sesion.tipoRedondeo == Definiciones.TipoRedondeo.RedondeoParaAbajo)
                    return decimal.Floor(valor);
                else if (sesion.tipoRedondeo == Definiciones.TipoRedondeo.RedondeoParaArriba)
                    return decimal.Ceiling(valor);
                else
                    return Math.Round(valor, 0, MidpointRounding.AwayFromZero);
            }
        }

        public static double Redondear(double valor)
        {
            using (SessionService sesion = new SessionService())
            {
                if (sesion.tipoRedondeo == Definiciones.TipoRedondeo.RedondeoParaAbajo)
                    return Math.Floor(valor);
                else if (sesion.tipoRedondeo == Definiciones.TipoRedondeo.RedondeoParaArriba)
                    return Math.Ceiling(valor);
                else
                    return Math.Round(valor, 0, MidpointRounding.AwayFromZero);
            }
        }
        #endregion Redondear

        #region Accessors
        public static string Nombre_Tabla = "MONEDAS";
        public static string Nombre_Secuencia = "MONEDAS_SQC";
        #endregion Accessors

        #region CODIGO NUEVO orientacion a objetos
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static MonedasService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new MonedasService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected MONEDASRow row;
        protected MONEDASRow rowSinModificar;
        public class Modelo : MONEDASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string CadenaDecimales { get { return row.CADENA_DECIMALES; } private set { row.CADENA_DECIMALES = value; } }
        public int CantidadDecimales
        { 
            get 
            { 
                return int.Parse(row.CANTIDADES_DECIMALES.ToString()); 
            } 
            set 
            { 
                row.CANTIDADES_DECIMALES = value;

                string cadena = "###,###,###,##0";
                if (row.CANTIDADES_DECIMALES > 0)
                {
                    cadena += ".";
                    for (int i = 0; i < row.CANTIDADES_DECIMALES; i++)
                        cadena += "0";
                }
                this.CadenaDecimales = cadena;
            } 
        }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string ISO4217 { get { return row.ISO_4217; } set { row.ISO_4217 = value; } }
        public string Mascara { get { return row.MASCARA; } set { row.MASCARA = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Observacion { get { return row.OBSERVACION; } set { row.OBSERVACION = value; } }
        public decimal? Orden { get { if (row.IsORDENNull) return null; else return row.ORDEN; } set { if (value.HasValue) row.ORDEN = value.Value; else row.IsORDENNull = true; } }
        public string Simbolo { get { return row.SIMBOLO; } set { row.SIMBOLO = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.MONEDASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new MONEDASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            
            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(MONEDASRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            
            this.rowSinModificar = this.row.Clonar();
        }

        public MonedasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public MonedasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public MonedasService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
   
        private MonedasService(MONEDASRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.MONEDASCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
            }
            else
            {
                sesion.db.MONEDASCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, this.rowSinModificar, sesion);
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (!RolesService.Tiene("monedas editar"))
                excepciones.Agregar("No tiene permisos para guardar.", null);

            if (this.row.NOMBRE.Length <= 0)
                excepciones.Agregar("Debe indicar el nombre.", null);

            if (this.row.SIMBOLO.Length <= 0)
                excepciones.Agregar("Debe indicar el sìmbolo.", null);

            if (this.row.ISO_4217.Length <= 0)
                excepciones.Agregar("Debe indicar el código ISO-4217 (3 caracteres).", null);

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override MonedasService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

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
                        case Modelo.CANTIDADES_DECIMALESColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.ORDENColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.ESTADOColumnName:
                        case Modelo.ISO_4217ColumnName:
                        case Modelo.NOMBREColumnName:
                        case Modelo.OBSERVACIONColumnName:
                        case Modelo.SIMBOLOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.ORDENColumnName);
            MONEDASRow[] rows = sesion.db.MONEDASCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            MonedasService[] m = new MonedasService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                m[i] = new MonedasService(rows[i]);

            return m;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            var e = new CBA.FlowV2.Services.Base.EdiCBA.Moneda()
            {
                cadena_decimales = this.CadenaDecimales,
                cantidad_decimales = this.CantidadDecimales,
                iso_4217 = this.ISO4217,
                nombre = this.Nombre,
                simbolo = this.Simbolo
            };
            
            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = this.GetOrCreateUUID(sesion);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO orientacion a objetos
    }
}
