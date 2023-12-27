using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Activos
{
    public class InmueblesService
    {
        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
                try
                {
                    sesion.Db.BeginTransaction();

                    INMUEBLESRow row = new INMUEBLESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("inmuebles_sqc");
                    }
                    else
                    {
                        row = sesion.Db.INMUEBLESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }
                    
                    //Campos obligatorios
                    if (campos.Contains(TipoInmuebleId_NombreCol))
                        row.TEXTO_PRED_TIPO_INMUEBLE_ID = Decimal.Parse(campos[TipoInmuebleId_NombreCol].ToString());

                    if (campos.Contains(PaisId_NombreCol))
                        row.PAIS_ID = Decimal.Parse(campos[PaisId_NombreCol].ToString());

                    if (campos.Contains(DepartamentoId_NombreCol))
                        row.DEPARTAMENTO_ID = Decimal.Parse(campos[DepartamentoId_NombreCol].ToString());

                    if (campos.Contains(CiudadId_NombreCol))
                        row.CIUDAD_ID = Decimal.Parse(campos[CiudadId_NombreCol].ToString());

                    if (campos.Contains(BarrioId_NombreCol))
                        row.BARRIO_ID = Decimal.Parse(campos[BarrioId_NombreCol].ToString());
                    
                    row.LOTE_NUMERO = campos[LoteNumero_NombreCol].ToString();
                    row.SUPERFICIE = Decimal.Parse(campos[Superficie_NombreCol].ToString());
                    row.FINCA_NUMERO = campos[FincaNumero_NombreCol].ToString();
                    row.CUENTA_CATASTRAL = campos[CuentaCatastral_NombreCol].ToString();
                    row.PADRON_NUMERO = campos[PadronNumero_NombreCol].ToString();

                    if (!campos[Latitud_NombreCol].ToString().Equals(string.Empty))
                        row.LATITUD = Decimal.Parse(campos[Latitud_NombreCol].ToString());

                    if (!campos[Longitud_NombreCol].ToString().Equals(string.Empty))
                        row.LONGITUD = Decimal.Parse(campos[Longitud_NombreCol].ToString());

                    row.ESCRITURADO = campos[Escriturado_NombreCol].ToString();
                    row.PISO = campos[Piso_NombreCol].ToString();
                    row.TELEFONO = campos[Telefono_NombreCol].ToString();
                    row.NUMERO = campos[Numero_NombreCol].ToString();
                    row.MEDIDOR_AGUA_NUMERO = campos[MedidorAguaNumero_NombreCol].ToString();
                    row.MEDIDOR_ELECTRICIDAD_NUMERO = campos[MedidorElectricidadNumero_NombreCol].ToString();
                    row.NIS_ELECTRICIDAD = campos[NisElectricidad_NombreCol].ToString();
                    row.CUENTA_CATASTRAL_AGUA = campos[CuentaCatastralAgua_NombreCol].ToString();
                    row.ES_ESPACIO_COMUN = campos[EsEspacioComun_NombreCol].ToString();
                    row.MATRICULA_NRO = campos[MatriculaNumero_NombreCol].ToString();
                    row.TEXTO_PRED_DISPONIBILIDAD_ID = Decimal.Parse(campos[DisponibilidadId_NombreCol].ToString());
                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.CALLE = campos[Calle_NombreCol].ToString();

                    //Campos opcionales
                    if (campos.Contains(PersonaPropietarioId_NombreCol))
                    {
                        row.PERSONA_PROPIETARIO_ID = Decimal.Parse(campos[PersonaPropietarioId_NombreCol].ToString());
                        row.PROPIETARIO_APELLIDO = string.Empty;
                        row.PROPIETARIO_NOMBRE = string.Empty;
                    }
                    else if (campos.Contains(ProveedorPropietarioId_NombreCol))
                    {
                        row.PROVEEDOR_PROPIETARIO_ID = Decimal.Parse(campos[ProveedorPropietarioId_NombreCol].ToString());
                        row.PROPIETARIO_APELLIDO = string.Empty;
                        row.PROPIETARIO_NOMBRE = string.Empty;
                    }
                    else
                    {
                        row.PROPIETARIO_APELLIDO = campos[PropietarioApellido_NombreCol].ToString();
                        row.PROPIETARIO_NOMBRE = campos[PropietarioNombre_NombreCol].ToString();
                        row.IsPERSONA_PROPIETARIO_IDNull = true;
                        row.IsPROVEEDOR_PROPIETARIO_IDNull = true;
                    }

                    if (campos.Contains(InmueblePadreId_NombreCol))
                        row.INMUEBLE_PADRE_ID = Decimal.Parse(campos[InmueblePadreId_NombreCol].ToString());

                    if (insertarNuevo) sesion.Db.INMUEBLESCollection.Insert(row);
                    else sesion.Db.INMUEBLESCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
        }
        #endregion Guardar

        #region GetInmueblesInfoCompleta
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        /// 
        public static DataTable GetInmueblesInfoCompletaFiltrado(string valor_a_buscar) 
        {
            string txt = valor_a_buscar.Replace(' ', '%').ToUpper();

            string clausulas = "(" +
                               "     upper(" + Id_NombreCol + ") = '" + txt + "'" + " or"+
                               "     upper(" + Nombre_NombreCol + ") = '" + txt + "'" + " or" +
                               "     upper(" + PropietarioNombre_NombreCol + ") = '" + txt + "'" + " or" +
                               "     upper(" + PropietarioApellido_NombreCol + ") = '" + txt + "'" + " or" +
                               "     upper(" + FincaNumero_NombreCol + ") = '" + txt + "'" +
                               ")";

            return GetInmueblesInfoCompleta(clausulas, Nombre_NombreCol);
        }

        public static DataTable GetInmueblesInfoCompleta(string orden)
        {
            return GetInmueblesInfoCompleta(string.Empty, orden);
        }

        public static DataTable GetInmueblesInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.INMUEBLES_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }

        #endregion GetInmueblesInfoCompleta

        public static DataTable GetInmuebleInfoCompletaPorId(string id) 
        {
            string txt = id.Replace(' ', '%').ToUpper();

            string clausulas = "(" +
                               "     upper(" + Id_NombreCol + ") = '" + txt + "'" +
                               ")";

            return GetInmueblesInfoCompleta(clausulas, Nombre_NombreCol);

        
        } 

        public static string GetDatoPadreInmueblePadre(string nombre_col, decimal id_padre)
        {
            string clausulas= Id_NombreCol + " = " + id_padre.ToString();
            DataTable dt = GetInmueblesInfoCompleta(clausulas, string.Empty);
            return dt.Rows[0][nombre_col].ToString();
        }

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "INMUEBLES"; }
        }
        public static string Id_NombreCol
        {
            get { return INMUEBLESCollection.IDColumnName; }
        }
        public static string TextoPredTipoInmuebleId_NombreCol
        {
            get { return INMUEBLESCollection.TEXTO_PRED_TIPO_INMUEBLE_IDColumnName; }
        }
        public static string PropietarioNombre_NombreCol
        {
            get { return INMUEBLESCollection.PROPIETARIO_NOMBREColumnName; }
        }
        public static string PropietarioApellido_NombreCol
        {
            get { return INMUEBLESCollection.PROPIETARIO_APELLIDOColumnName; }
        }
        public static string PersonaPropietarioId_NombreCol
        {
            get { return INMUEBLESCollection.PERSONA_PROPIETARIO_IDColumnName; }
        }
        public static string ProveedorPropietarioId_NombreCol
        {
            get { return INMUEBLESCollection.PROVEEDOR_PROPIETARIO_IDColumnName; }
        }
        public static string InmueblePadreId_NombreCol
        {
            get { return INMUEBLESCollection.INMUEBLE_PADRE_IDColumnName; }
        }
        public static string PaisId_NombreCol
        {
            get { return INMUEBLESCollection.PAIS_IDColumnName; }
        }
        public static string CiudadId_NombreCol
        {
            get { return INMUEBLESCollection.CIUDAD_IDColumnName; }
        }    
        public static string BarrioId_NombreCol
        {
            get { return INMUEBLESCollection.BARRIO_IDColumnName; }
        }
        public static string DepartamentoId_NombreCol
        {
            get { return INMUEBLESCollection.DEPARTAMENTO_IDColumnName; }
        }
        public static string LoteNumero_NombreCol
        {
            get { return INMUEBLESCollection.LOTE_NUMEROColumnName; }
        }
        public static string Superficie_NombreCol
        {
            get { return INMUEBLESCollection.SUPERFICIEColumnName; }
        }
        public static string FincaNumero_NombreCol
        {
            get { return INMUEBLESCollection.FINCA_NUMEROColumnName; }
        }
        public static string CuentaCatastral_NombreCol
        {
            get { return INMUEBLESCollection.CUENTA_CATASTRALColumnName; }
        }
        public static string PadronNumero_NombreCol
        {
            get { return INMUEBLESCollection.PADRON_NUMEROColumnName; }
        }
        public static string Latitud_NombreCol
        {
            get { return INMUEBLESCollection.LATITUDColumnName; }
        }
        public static string Longitud_NombreCol
        {
            get { return INMUEBLESCollection.LONGITUDColumnName; }
        }
        public static string Escriturado_NombreCol
        {
            get { return INMUEBLESCollection.ESCRITURADOColumnName; }
        }
        public static string Piso_NombreCol
        {
            get { return INMUEBLESCollection.PISOColumnName; }
        }
        public static string Telefono_NombreCol
        {
            get { return INMUEBLESCollection.TELEFONOColumnName; }
        }
        public static string Numero_NombreCol
        {
            get { return INMUEBLESCollection.NUMEROColumnName; }
        }
        public static string MedidorAguaNumero_NombreCol
        {
            get { return INMUEBLESCollection.MEDIDOR_AGUA_NUMEROColumnName; }
        }
        public static string MedidorElectricidadNumero_NombreCol
        {
            get { return INMUEBLESCollection.MEDIDOR_ELECTRICIDAD_NUMEROColumnName; }
        }
        public static string NisElectricidad_NombreCol
        {
            get { return INMUEBLESCollection.NIS_ELECTRICIDADColumnName; }
        }
        public static string CuentaCatastralAgua_NombreCol
        {
            get { return INMUEBLESCollection.CUENTA_CATASTRAL_AGUAColumnName; }
        }
        public static string EsEspacioComun_NombreCol
        {
            get { return INMUEBLESCollection.ES_ESPACIO_COMUNColumnName; }
        }
        public static string MatriculaNumero_NombreCol
        {
            get { return INMUEBLESCollection.MATRICULA_NROColumnName; }
        }
        public static string TextoPredDisponibilidadId_NombreCol
        {
            get { return INMUEBLESCollection.TEXTO_PRED_DISPONIBILIDAD_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return INMUEBLESCollection.NOMBREColumnName; }
        }
        public static string Calle_NombreCol
        {
            get { return INMUEBLESCollection.CALLEColumnName; }
        }
             
        public static string DisponibilidadId_NombreCol
        {
            get { return INMUEBLESCollection.TEXTO_PRED_DISPONIBILIDAD_IDColumnName; }
        }
        public static string TipoInmuebleId_NombreCol
        {
            get { return INMUEBLESCollection.TEXTO_PRED_TIPO_INMUEBLE_IDColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaDisponibilidadTexto_NombreCol
        {
            get { return INMUEBLES_INFO_COMPLETACollection.DISPONIBILIDAD_TEXTOColumnName; }
        }
        public static string VistaPropietarioApellido_NombreCol
        {
            get { return INMUEBLES_INFO_COMPLETACollection.PERSONA_APELLIDOColumnName; }
        }
        public static string VistaPropietarioNombre_NombreCol
        {
            get { return INMUEBLES_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaTipoInmuebleTexto_NombreCol
        {
            get { return INMUEBLES_INFO_COMPLETACollection.TIPO_INMUEBLE_TEXTOColumnName; }
        }
        #endregion Vista

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS

        #region Propiedades
        protected INMUEBLESRow row;
        protected INMUEBLESRow rowSinModificar;
        public class Modelo : INMUEBLESCollection_Base { public Modelo() : base(null) { } }

        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

            public decimal Id { get { return row.ID; } set { row.ID = value; } }
            public decimal Texto_Pred_Tipo_Inmueble_Id { get {return this.row.TEXTO_PRED_TIPO_INMUEBLE_ID;} set {row.TEXTO_PRED_TIPO_INMUEBLE_ID= value;}}
            public string Propietario_Nombre { get { return ClaseCBABase.GetStringHelper(row.PROPIETARIO_NOMBRE); } set { row.PROPIETARIO_NOMBRE = value; } }
            public string Propietario_Apellido { get { return ClaseCBABase.GetStringHelper(row.PROPIETARIO_APELLIDO); } set { row.PROPIETARIO_APELLIDO = value; } }
            public decimal? Persona_Propietario_Id { get { if (row.IsPERSONA_PROPIETARIO_IDNull) return null; else return row.PERSONA_PROPIETARIO_ID; } set { if (value.HasValue) row.PERSONA_PROPIETARIO_ID = value.Value; else row.IsPERSONA_PROPIETARIO_IDNull = true; } }
            public decimal? Inmueble_Padre_Id { get { if (row.IsINMUEBLE_PADRE_IDNull) return null; else return row.INMUEBLE_PADRE_ID; } set { if (value.HasValue) row.INMUEBLE_PADRE_ID = value.Value; else row.IsINMUEBLE_PADRE_IDNull = true; } }
            public decimal? Pais_Id { get { if (row.IsPAIS_IDNull) return null; else return row.PAIS_ID; } set { if (value.HasValue) row.PAIS_ID = value.Value; else row.IsPAIS_IDNull = true; } }
            public decimal? Ciudad_Id { get { if (row.IsCIUDAD_IDNull) return null; else return row.CIUDAD_ID; } set { if (value.HasValue) row.CIUDAD_ID = value.Value; else row.IsCIUDAD_IDNull = true; } }
            public decimal? Barrio_Id { get { if (row.IsBARRIO_IDNull) return null; else return row.BARRIO_ID; } set { if (value.HasValue) row.BARRIO_ID = value.Value; else row.IsBARRIO_IDNull = true; } }
            public decimal? Departamento_Id { get { if (row.IsDEPARTAMENTO_IDNull) return null; else return row.DEPARTAMENTO_ID; } set { if (value.HasValue) row.DEPARTAMENTO_ID = value.Value; else row.IsDEPARTAMENTO_IDNull = true; } }
            public string Lote_Numero { get { return ClaseCBABase.GetStringHelper(row.LOTE_NUMERO); } set { row.LOTE_NUMERO = value; } }
            public decimal? Superficie { get { if (row.IsSUPERFICIENull) return null; else return row.SUPERFICIE; } set { if (value.HasValue) row.SUPERFICIE = value.Value; else row.IsSUPERFICIENull = true; } }
            public string Finca_Numero { get { return ClaseCBABase.GetStringHelper(row.FINCA_NUMERO); } set { row.FINCA_NUMERO = value; } }
            public string Cuenta_Catastral { get { return ClaseCBABase.GetStringHelper(row.CUENTA_CATASTRAL); } set { row.CUENTA_CATASTRAL = value; } }
            public string Padron_Numero { get { return ClaseCBABase.GetStringHelper(row.PADRON_NUMERO); } set { row.PADRON_NUMERO = value; } }
            public decimal? Latitud { get { if (row.IsLATITUDNull) return null; else return row.LATITUD; } set { if (value.HasValue) row.LATITUD = value.Value; else row.IsLATITUDNull = true; } }
            public decimal? Longitud { get { if (row.IsLONGITUDNull) return null; else return row.LONGITUD; } set { if (value.HasValue) row.LONGITUD = value.Value; else row.IsLONGITUDNull = true; } }
            public string Escriturado { get { return ClaseCBABase.GetStringHelper(row.ESCRITURADO); } set { row.ESCRITURADO = value; } }
            public string Piso { get { return ClaseCBABase.GetStringHelper(row.PISO); } set { row.PISO = value; } }
            public string Telefono { get { return ClaseCBABase.GetStringHelper(row.TELEFONO); } set { row.TELEFONO = value; } }
            public string Numero { get { return ClaseCBABase.GetStringHelper(row.NUMERO); } set { row.NUMERO = value; } }
            public string Medidor_Agua_Numero { get { return ClaseCBABase.GetStringHelper(row.MEDIDOR_AGUA_NUMERO); } set { row.MEDIDOR_AGUA_NUMERO = value; } }
            public string Medidor_Electricidad_Numero{ get { return ClaseCBABase.GetStringHelper(row.MEDIDOR_ELECTRICIDAD_NUMERO); } set { row.MEDIDOR_ELECTRICIDAD_NUMERO = value; } }
            public string NIS_Electricidad { get { return ClaseCBABase.GetStringHelper(row.NIS_ELECTRICIDAD); } set { row.NIS_ELECTRICIDAD = value; } }
            public string Cuenta_Catastral_Agua { get { return ClaseCBABase.GetStringHelper(row.CUENTA_CATASTRAL_AGUA); } set { row.CUENTA_CATASTRAL_AGUA = value; } }
            public string Es_Espacio_Comun { get { return ClaseCBABase.GetStringHelper(row.ES_ESPACIO_COMUN); } set { row.ES_ESPACIO_COMUN = value; } }
            public string Matricula_Nro { get { return ClaseCBABase.GetStringHelper(row.MATRICULA_NRO); } set { row.MATRICULA_NRO = value; } }
            public decimal Texto_Pred_Disponibilidad_Id { get { return row.TEXTO_PRED_DISPONIBILIDAD_ID; } set { row.TEXTO_PRED_DISPONIBILIDAD_ID = value; } }
            public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
            public string Calle { get { return ClaseCBABase.GetStringHelper(row.CALLE); } set { row.CALLE = value; } }
         #endregion Propiedades
 
        #region Propiedades Extendidas

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.Persona_Propietario_Id.Value);
                return this._persona;
            }
        }
        
        private InmueblesService _inmueble_padre;
        public InmueblesService Inmueble_Padre
        {
            get
            {
                if (this._inmueble_padre == null)
                    this._inmueble_padre = new InmueblesService(this.Inmueble_Padre_Id.Value);
                return this._inmueble_padre;
            }
        }

        private PaisesService _pais;
        public PaisesService Pais
        {
            get
            {
                if (this._pais == null)
                    this._pais = new PaisesService(this.Pais_Id.Value);
                return this._pais;
            }
        }

        private CiudadesService _ciudad;
        public CiudadesService Ciudad
        {
            get
            {
                if (this._ciudad == null)
                    this._ciudad = new CiudadesService(this.Ciudad_Id.Value);
                return this._ciudad;
            }
        }

        private BarriosService _barrio;
        public BarriosService Barrio
        {
            get
            {
                if (this._barrio == null)
                    this._barrio = new BarriosService(this.Barrio_Id.Value);
                return this._barrio;
            }
        }

        private DepartamentosService _departamento;
        public DepartamentosService Departamento
        {
            get
            {
                if (this._departamento == null)
                    this._departamento = new DepartamentosService(this.Departamento_Id.Value);
                return this._departamento;
            }
        }

        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.INMUEBLESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new INMUEBLESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public InmueblesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public InmueblesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public InmueblesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #endregion CODIGO NUEVO ORIENTACION A OBJETOS

    }
}

