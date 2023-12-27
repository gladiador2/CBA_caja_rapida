#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteBancosService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ctacte_banco_id">The ctacte_banco_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ctacte_banco_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_BANCOSRow row = sesion.Db.CTACTE_BANCOSCollection.GetRow(CuentaCorrienteBancosService.Id_NombreCol + " = " + ctacte_banco_id);

                return row.ESTADO == Definiciones.Estado.Activo;

            }
        }
        #endregion EstaActivo

        #region GetBancosDataTable
        public static DataTable GetBancosDataTable(string clausulas, string orden, bool soloActivos, SessionService sesion)
        {
            string where = CuentaCorrienteBancosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            DataTable dt;

            if (soloActivos) where += " and " + CuentaCorrienteBancosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length > 0) where += " and " + clausulas;

            sesion.Db.IniciarBusquedaFlexible();
            dt = sesion.Db.CTACTE_BANCOSCollection.GetAsDataTable(where, orden);
            sesion.Db.FinalizarBusquedaFlexible();

            return dt;
        }

        public static DataTable GetBancosDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetBancosDataTable(clausulas, orden, soloActivos, sesion);
            }
        }

        public static DataTable GetBancosDataTable(string clausulas, string orden)
        {
            return GetBancosDataTable(clausulas, orden, false);
        }
        #endregion GetBancosDataTable

        #region GetBancoFromProveedor
        
        public static decimal GetBancoFromProveedor(decimal proveedorId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_BANCOSRow[] row = sesion.Db.CTACTE_BANCOSCollection.GetByPROVEEDOR_ID(proveedorId);
                    if (row.Length > 1)
                        throw new Exception("Existe más de un banco asociado a ese proveedor.");                        
                    else
                        return row[0].ID;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        #endregion GetBancoFromProveedor

        #region GetAbreviaturaBanco

        public static string GetAbreviaturaBanco(decimal bancoId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CTACTE_BANCOSRow row = sesion.Db.CTACTE_BANCOSCollection.GetByPrimaryKey(bancoId);
                    if (row.Equals(DBNull.Value))
                        throw new Exception("Error.");
                    else
                        return row.ABREVIATURA;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        #endregion GetBancoFromProveedor

        #region GetPais
        public static decimal GetPais(decimal ctacte_banco_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_BANCOSRow row = sesion.Db.CTACTE_BANCOSCollection.GetByPrimaryKey(ctacte_banco_id);
                return row.PAIS_ID;
            }
        }
        #endregion GetBancosDataTable

        #region GetProveedor
        public static decimal GetProveedor(decimal ctacte_banco_id, SessionService sesion)
        {
            CTACTE_BANCOSRow row = sesion.Db.CTACTE_BANCOSCollection.GetByPrimaryKey(ctacte_banco_id);
            return row.IsPROVEEDOR_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.PROVEEDOR_ID;
        }
        #endregion GetBancosDataTable

        #region GetReportePlanillaCheques
        /// <summary>
        /// Gets the reporte planilla cheques.
        /// </summary>
        /// <param name="ctacte_banco_id">The ctacte_banco_id.</param>
        /// <returns></returns>
        public static decimal GetReportePlanillaCheques(decimal ctacte_banco_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_BANCOSRow row = sesion.Db.CTACTE_BANCOSCollection.GetByPrimaryKey(ctacte_banco_id);
                if (row.IsREPORTE_PLANILLA_CHEQUES_IDNull)
                    return Definiciones.Error.Valor.EnteroPositivo;
                else
                    return row.REPORTE_PLANILLA_CHEQUES_ID;
            }
        }
        #endregion GetReportePlanillaCheques

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTACTE_BANCOSRow banco = new CTACTE_BANCOSRow();
                    string valorAnterior = string.Empty;
                    decimal aux;

                    if (insertarNuevo)
                    {
                        banco.ID = sesion.Db.GetSiguienteSecuencia("ctacte_bancos_sqc");
                        banco.ENTIDAD_ID = sesion.Entidad.ID;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        banco = sesion.Db.CTACTE_BANCOSCollection.GetRow(Id_NombreCol + " = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = banco.ToString();
                    }

                    if (campos.Contains(CuentaCorrienteBancosService.ReportePlanillaChequesIdId_NombreCol))
                        banco.REPORTE_PLANILLA_CHEQUES_ID = (decimal)campos[CuentaCorrienteBancosService.ReportePlanillaChequesIdId_NombreCol];
                    else
                        banco.IsREPORTE_PLANILLA_CHEQUES_IDNull = true;


                    banco.ABREVIATURA = (string)campos[CuentaCorrienteBancosService.Abreviatura_NombreCol];
                    banco.AGENTE_CUENTA_NOMBRE = (string)campos[CuentaCorrienteBancosService.AgenteCuentaNombre_NombreCol];
                    banco.AGENTE_CUENTA_TELEFONO1 = (string)campos[CuentaCorrienteBancosService.AgenteCuentaTelefono1_NombreCol];
                    banco.AGENTE_CUENTA_TELEFONO2 = (string)campos[CuentaCorrienteBancosService.AgenteCuentaTelefono2_NombreCol];
                    banco.AGENTE_CUENTA_TELEFONO3 = (string)campos[CuentaCorrienteBancosService.AgenteCuentaTelefono3_NombreCol];
                    banco.CODIGO = (string)campos[CuentaCorrienteBancosService.Codigo_NombreCol];
                    banco.DIRECCION = (string)campos[CuentaCorrienteBancosService.Direccion_NombreCol];
                    banco.EMAIL1 = (string)campos[CuentaCorrienteBancosService.Email1_NombreCol];
                    banco.EMAIL2 = (string)campos[CuentaCorrienteBancosService.Email2_NombreCol];
                    banco.ESTADO = (string)campos[CuentaCorrienteBancosService.Estado_NombreCol];

                    aux = decimal.Parse((string)campos[CuentaCorrienteBancosService.PaisId_NombreCol]);
                    if (banco.PAIS_ID != aux)
                    {
                        if (PaisesService.EstaActivo(aux)) banco.PAIS_ID = aux;
                        else throw new System.ArgumentException("El país seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    banco.RAZON_SOCIAL = (string)campos[CuentaCorrienteBancosService.RazonSocial_NombreCol];
                    banco.TELEFONO1 = (string)campos[CuentaCorrienteBancosService.Telefono1_NombreCol];
                    banco.TELEFONO2 = (string)campos[CuentaCorrienteBancosService.Telefono2_NombreCol];
                    banco.TELEFONO3 = (string)campos[CuentaCorrienteBancosService.Telefono3_NombreCol];

                    if (campos.Contains(CuentaCorrienteBancosService.ProveedorId_NombreCol))
                    {
                        aux = (decimal)campos[CuentaCorrienteBancosService.ProveedorId_NombreCol];
                        if(banco.IsPROVEEDOR_IDNull || !banco.PROVEEDOR_ID.Equals(aux))
                        {
                            if (ProveedoresService.EstaActivo(aux))
                                banco.PROVEEDOR_ID = aux;
                            else
                                throw new Exception("El proveedor está inactivo.");
                        }
                    }
                    else
                    {
                        banco.IsPROVEEDOR_IDNull = true;
                    }

                    if (campos.Contains(EsNacional_NombreCol)) banco.ES_NACIONAL = campos[EsNacional_NombreCol].ToString();
                    if (campos.Contains(EsExtranjero_NombreCol)) banco.ES_EXTRANJERO = campos[EsExtranjero_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.CTACTE_BANCOSCollection.Insert(banco);
                    else sesion.Db.CTACTE_BANCOSCollection.Update(banco);

                    LogCambiosService.LogDeRegistro(CuentaCorrienteBancosService.Nombre_Tabla, banco.ID, valorAnterior, banco.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_BANCOS"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_BANCOSCollection.IDColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return CTACTE_BANCOSCollection.ENTIDAD_IDColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return CTACTE_BANCOSCollection.CODIGOColumnName; }
        }
        public static string RazonSocial_NombreCol
        {
            get { return CTACTE_BANCOSCollection.RAZON_SOCIALColumnName; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return CTACTE_BANCOSCollection.ABREVIATURAColumnName; }
        }
        public static string PaisId_NombreCol
        {
            get { return CTACTE_BANCOSCollection.PAIS_IDColumnName; }
        }
        public static string Direccion_NombreCol
        {
            get { return CTACTE_BANCOSCollection.DIRECCIONColumnName; }
        }
        public static string Telefono1_NombreCol
        {
            get { return CTACTE_BANCOSCollection.TELEFONO1ColumnName; }
        }
        public static string Telefono2_NombreCol
        {
            get { return CTACTE_BANCOSCollection.TELEFONO2ColumnName; }
        }
        public static string Telefono3_NombreCol
        {
            get { return CTACTE_BANCOSCollection.TELEFONO3ColumnName; }
        }
        public static string Email1_NombreCol
        {
            get { return CTACTE_BANCOSCollection.EMAIL1ColumnName; }
        }
        public static string Email2_NombreCol
        {
            get { return CTACTE_BANCOSCollection.EMAIL2ColumnName; }
        }
        public static string AgenteCuentaNombre_NombreCol
        {
            get { return CTACTE_BANCOSCollection.AGENTE_CUENTA_NOMBREColumnName; }
        }
        public static string AgenteCuentaTelefono1_NombreCol
        {
            get { return CTACTE_BANCOSCollection.AGENTE_CUENTA_TELEFONO1ColumnName; }
        }
        public static string AgenteCuentaTelefono2_NombreCol
        {
            get { return CTACTE_BANCOSCollection.AGENTE_CUENTA_TELEFONO2ColumnName; }
        }
        public static string AgenteCuentaTelefono3_NombreCol
        {
            get { return CTACTE_BANCOSCollection.AGENTE_CUENTA_TELEFONO3ColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_BANCOSCollection.ESTADOColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CTACTE_BANCOSCollection.PROVEEDOR_IDColumnName; }
        }
        public static string ReportePlanillaChequesIdId_NombreCol
        {
            get { return CTACTE_BANCOSCollection.REPORTE_PLANILLA_CHEQUES_IDColumnName; }
        }
        public static string EsNacional_NombreCol
        {
            get { return CTACTE_BANCOSCollection.ES_NACIONALColumnName; }
        }
        public static string EsExtranjero_NombreCol
        {
            get { return CTACTE_BANCOSCollection.ES_EXTRANJEROColumnName; }
        }
        public static string ReporteTXTModeloId_NombreCol
        {
            get { return CTACTE_BANCOSCollection.REPORTE_TXT_MODELO_IDColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteBancosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteBancosService(e.RegistroId, sesion);
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
        protected CTACTE_BANCOSRow row;
        protected CTACTE_BANCOSRow rowSinModificar;
        public class Modelo : CTACTE_BANCARIASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public string AgenteCuentaNombre { get { return ClaseCBABase.GetStringHelper(row.AGENTE_CUENTA_NOMBRE); } set { row.AGENTE_CUENTA_NOMBRE = value; } }
        public string AgenteCuentaTelefono1 { get { return ClaseCBABase.GetStringHelper(row.AGENTE_CUENTA_TELEFONO1); } set { row.AGENTE_CUENTA_TELEFONO1 = value; } }
        public string AgenteCuentaTelefono2 { get { return ClaseCBABase.GetStringHelper(row.AGENTE_CUENTA_TELEFONO2); } set { row.AGENTE_CUENTA_TELEFONO2 = value; } }
        public string AgenteCuentaTelefono3 { get { return ClaseCBABase.GetStringHelper(row.AGENTE_CUENTA_TELEFONO3); } set { row.AGENTE_CUENTA_TELEFONO3 = value; } }
        public string Codigo { get { return ClaseCBABase.GetStringHelper(row.CODIGO); } set { row.CODIGO = value; } }
        public string Direccion { get { return ClaseCBABase.GetStringHelper(row.DIRECCION); } set { row.DIRECCION = value; } }
        public string Email1 { get { return ClaseCBABase.GetStringHelper(row.EMAIL1); } set { row.EMAIL1 = value; } }
        public string Email2 { get { return ClaseCBABase.GetStringHelper(row.EMAIL2); } set { row.EMAIL2 = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string EsExtranjero { get { return ClaseCBABase.GetStringHelper(row.ES_EXTRANJERO); } set { row.ES_EXTRANJERO = value; } }
        public string EsNacional { get { return ClaseCBABase.GetStringHelper(row.ES_NACIONAL); } set { row.ES_NACIONAL = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal PaisId { get { return row.PAIS_ID; } set { row.PAIS_ID = value; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public string RazonSocial { get { return ClaseCBABase.GetStringHelper(row.RAZON_SOCIAL); } set { row.RAZON_SOCIAL = value; } }
        public decimal? ReportePlanillaChequeId { get { if (row.IsREPORTE_PLANILLA_CHEQUES_IDNull) return null; else return row.REPORTE_PLANILLA_CHEQUES_ID; } set { if (value.HasValue) row.REPORTE_PLANILLA_CHEQUES_ID = value.Value; else row.IsREPORTE_PLANILLA_CHEQUES_IDNull = true; } }
        public decimal? ReporteTxtModeloId { get { if (row.IsREPORTE_TXT_MODELO_IDNull) return null; else return row.REPORTE_TXT_MODELO_ID; } set { if (value.HasValue) row.REPORTE_TXT_MODELO_ID = value.Value; else row.IsREPORTE_TXT_MODELO_IDNull = true; } }
        public string Telefono1 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO1); } set { row.TELEFONO1 = value; } }
        public string Telefono2 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO2); } set { row.TELEFONO2 = value; } }
        public string Telefono3 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO3); } set { row.TELEFONO3 = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private PaisesService _pais;
        public PaisesService Pais
        {
            get
            {
                if (this._pais == null)
                    this._pais = new PaisesService(this.PaisId);
                return this._pais;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_BANCOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_BANCOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_BANCOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteBancosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteBancosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteBancosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrienteBancosService(EdiCBA.Banco edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = DepositosBancariosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);
            
            this.Abreviatura = edi.abreviatura;
            this.Codigo = edi.codigo;
            this.EsExtranjero = edi.es_extranjero ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.EsNacional = edi.es_nacional ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.Estado = Definiciones.Estado.Activo;
            
            #region pais
            if (!string.IsNullOrEmpty(edi.pais_uuid))
                this._pais = PaisesService.GetPorUUID(edi.pais_uuid, sesion);
            if (this._pais == null && edi.pais != null)
                this._pais = new PaisesService(edi.pais, almacenar_localmente, sesion);
            if (this._pais == null)
                throw new Exception("No se encontró el UUID " + edi.pais_uuid + " ni se definieron los datos del objeto.");
            
            if(!this.Pais.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Pais.Id.HasValue)
                this.PaisId = this.Pais.Id.Value;
            #endregion pais

            this.RazonSocial = edi.razon_social;
        }
        private CuentaCorrienteBancosService(CTACTE_BANCOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._pais = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Banco()
            {
                abreviatura = this.Abreviatura,
                codigo = this.Codigo,
                es_extranjero = this.EsExtranjero == Definiciones.SiNo.Si,
                es_nacional = this.EsNacional == Definiciones.SiNo.Si,
                pais_uuid = this.Pais.GetOrCreateUUID(sesion),
                razon_social = this.RazonSocial,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.pais = (EdiCBA.Pais)this.Pais.ToEDI(nueva_profundidad, sesion);
            }

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
