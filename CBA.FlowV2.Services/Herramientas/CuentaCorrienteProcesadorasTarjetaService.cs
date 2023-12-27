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
    public class CuentaCorrienteProcesadorasTarjetaService
    {
        #region EstaActivo

        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="ctacte_procesadora_tarjeta_id">The ctacte_procesadora_tarjeta_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal ctacte_procesadora_tarjeta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PROCESADORAS_TARJETARow row = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetRow(CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol + " = " + ctacte_procesadora_tarjeta_id);

                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }

        #endregion EstaActivo

        #region TieneCuentaBancariaAsociada

        /// <summary>
        /// Gets the cuenta bancaria asociada.
        /// </summary>
        /// <param name="ctacte_procesadora_id">The ctacte_procesadora_id.</param>
        /// <returns></returns>
        public bool TieneCuentaBancariaAsociada(decimal ctacte_procesadora_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PROCESADORAS_TARJETARow row = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetByPrimaryKey(ctacte_procesadora_id);
                if (row.IsCUENTA_CORRIENTE_BANCARIA_IDNull)
                    return false;
                else
                    return true;
            }
        }

        #endregion TieneCuentaBancariaAsociada

        #region GetCuentaBancariaAsociada

        /// <summary>
        /// Gets the cuenta bancaria asociada.
        /// </summary>
        /// <param name="ctacte_procesadora_id">The ctacte_procesadora_id.</param>
        /// <returns></returns>
        public decimal GetCuentaBancariaAsociada(decimal ctacte_procesadora_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PROCESADORAS_TARJETARow row = sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetByPrimaryKey(ctacte_procesadora_id);
                return row.CUENTA_CORRIENTE_BANCARIA_ID;
            }
        }

        #endregion GetCuentaBancariaAsociada

        #region GetProcesadorasTarjetaDataTable

        /// <summary>
        /// Gets the procesadoras tarjeta data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetProcesadorasTarjetaDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = string.Empty;

                if (soloActivos) where = CuentaCorrienteProcesadorasTarjetaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                if (clausulas.Length > 0)
                {
                    if (!where.Equals(string.Empty))
                        where += " and " + clausulas;
                    else
                        where = clausulas;
                }

                return sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetAsDataTable(where, orden);
            }
        }


        /// <summary>
        /// Gets the procesadoras tarjeta data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetProcesadorasTarjetaDataTable(string clausulas, string orden)
        {
            return GetProcesadorasTarjetaDataTable(clausulas, orden, false);
        }

        #endregion GetProcesadorasTarjetaDataTable

        #region Accessors

        public static string Nombre_Tabla
        {
            get { return "CTACTE_PROCESADORAS_TARJETA"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.ABREVIATURAColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.NOMBREColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.CUENTA_CORRIENTE_BANCARIA_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.IDColumnName; }
        }
        public static string EsTarjetaCredito_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.ES_TARJETA_CREDITOColumnName; }
        }
        public static string ProcesadoraId_NombreCol
        {
            get { return CTACTE_PROCESADORAS_TARJETACollection.PROCESADORA_IDColumnName; }
        }
       
        #endregion Accessors

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            CTACTE_PROCESADORAS_TARJETARow row = new CTACTE_PROCESADORAS_TARJETARow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_PROCESAR_TARJ");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.CTACTE_PROCESADORAS_TARJETACollection.GetByPrimaryKey(decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaService.Nombre_NombreCol))
                row.NOMBRE = campos[CuentaCorrienteProcesadorasTarjetaService.Nombre_NombreCol].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaService.Abreviatura_NombreCol))
                row.ABREVIATURA = campos[CuentaCorrienteProcesadorasTarjetaService.Abreviatura_NombreCol].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaService.CtacteBancariaId_NombreCol))
                row.CUENTA_CORRIENTE_BANCARIA_ID = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaService.CtacteBancariaId_NombreCol].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaService.EsTarjetaCredito_NombreCol))
                row.ES_TARJETA_CREDITO = campos[CuentaCorrienteProcesadorasTarjetaService.EsTarjetaCredito_NombreCol].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaService.ProcesadoraId_NombreCol ))
                row.PROCESADORA_ID = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaService.ProcesadoraId_NombreCol].ToString());
            
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaService.Estado_NombreCol))
                row.ESTADO = campos[CuentaCorrienteProcesadorasTarjetaService.Estado_NombreCol].ToString();

            if (insertarNuevo)
            {
                sesion.db.CTACTE_PROCESADORAS_TARJETACollection.Insert(row);
            }
            else
                sesion.db.CTACTE_PROCESADORAS_TARJETACollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal pos_id = Guardar(campos, sesion, insertarNuevo);
                    sesion.db.CommitTransaction();
                    return pos_id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CuentaCorrienteProcesadorasTarjetaService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CuentaCorrienteProcesadorasTarjetaService(e.RegistroId, sesion);
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
        protected CTACTE_PROCESADORAS_TARJETARow row;
        protected CTACTE_PROCESADORAS_TARJETARow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public decimal? CuentaCorrienteBancariaId { get { if (row.IsCUENTA_CORRIENTE_BANCARIA_IDNull) return null; else return row.CUENTA_CORRIENTE_BANCARIA_ID; } set { if (value.HasValue) row.CUENTA_CORRIENTE_BANCARIA_ID = value.Value; else row.IsCUENTA_CORRIENTE_BANCARIA_IDNull = true; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public string EsTarjetaCredito { get { return ClaseCBABase.GetStringHelper(row.ES_TARJETA_CREDITO); } set { row.ES_TARJETA_CREDITO = value; } }
        public decimal? ProcesadoraId { get { if (row.IsPROCESADORA_IDNull) return null; else return row.CUENTA_CORRIENTE_BANCARIA_ID; } set { if (value.HasValue) row.PROCESADORA_ID = value.Value; else row.IsPROCESADORA_IDNull = true; } }
       
        #endregion Propiedades

        #region Propiedades Extendidas
        private CuentaCorrienteCuentasBancariasService _cuenta_corriente_bancaria;
        public CuentaCorrienteCuentasBancariasService CuentaCorrienteBancaria
        {
            get
            {
                if (this._cuenta_corriente_bancaria == null)
                    this._cuenta_corriente_bancaria = new CuentaCorrienteCuentasBancariasService(this.CuentaCorrienteBancariaId.Value);
                return this._cuenta_corriente_bancaria;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_PROCESADORAS_TARJETACollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_PROCESADORAS_TARJETARow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true; 
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(CTACTE_PROCESADORAS_TARJETARow row)
        {
            this.AlmacenarLocalmente = true; 
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CuentaCorrienteProcesadorasTarjetaService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteProcesadorasTarjetaService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteProcesadorasTarjetaService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CuentaCorrienteProcesadorasTarjetaService(EdiCBA.ProcesadoraTarjeta edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CuentaCorrienteProcesadorasTarjetaService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            this.Abreviatura = edi.abreviatura;
            this.Nombre = edi.nombre;

            this.Estado = Definiciones.Estado.Activo;
        }
        private CuentaCorrienteProcesadorasTarjetaService(CTACTE_PROCESADORAS_TARJETARow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._cuenta_corriente_bancaria = null;
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

            var e = new EdiCBA.ProcesadoraTarjeta()
            {
                abreviatura = this.Abreviatura,
                nombre = this.Nombre,
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
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

        #region GetProcesadorasIdporTarjetaId
        public static decimal GetProcesadorasIdporTarjetaId(decimal tarjeta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CuentaCorrienteProcesadorasTarjetaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                return sesion.Db.CTACTE_PROCESADORAS_TARJETACollection.GetByPrimaryKey(tarjeta_id).PROCESADORA_ID;
            }
        }
        #endregion GetProcesadorasIdporTarjetaId

    }
}
