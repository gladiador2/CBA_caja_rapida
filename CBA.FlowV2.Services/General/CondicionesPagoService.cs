#region Using
using System;
using System.Data;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class CondicionesPagoService
    {
        #region Variables globales estaticas
        public static string Pagos_NombreCol = "pagos";
        #endregion Variables globales estaticas

        #region EstaActivo
        public static bool EstaActivo(decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_PAGORow condicion = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetRow(" id = " + condicion_pago_id);
                return condicion.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EsContado
        public static bool EsContado(decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EsContado(condicion_pago_id, sesion);
            }
        }

        public static bool EsContado(decimal condicion_pago_id, SessionService sesion)
        {
            CTACTE_CONDICIONES_PAGORow condicion = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(condicion_pago_id);
            return condicion.TIPO_CONDICION_PAGO.Equals(Definiciones.TipoFactura.Contado);
        }
        #endregion EstaActivo

        #region GetCondicionesDataTable
        public DataTable GetCondicionesDataTable(int uso)
        {
            string clausulas = string.Empty;
            if (Definiciones.CondicionPagoUso.Venta == uso)
            {
                clausulas += CondicionesPagoService.EsVenta_NombreCol + "='" + Definiciones.SiNo.Si + "'";
            }
            if (Definiciones.CondicionPagoUso.Compra == uso)
            {
                if (!clausulas.Equals(string.Empty))
                    clausulas += " and ";
                clausulas += CondicionesPagoService.EsCompra_NombreCol + "='" + Definiciones.SiNo.Si + "'";

            }
            return GetCondicionesDataTable(clausulas, false);
        }
        public static DataTable GetCondicionesPorTipoDataTable(int uso)
        {
            string clausulas = string.Empty;
            if (Definiciones.CondicionPagoUso.Venta == uso)
            {
                clausulas += CondicionesPagoService.EsVenta_NombreCol + "='" + Definiciones.SiNo.Si + "'";
            }
            if (Definiciones.CondicionPagoUso.Compra == uso)
            {
                if (!clausulas.Equals(string.Empty))
                    clausulas += " and ";
                clausulas += CondicionesPagoService.EsCompra_NombreCol + "='" + Definiciones.SiNo.Si + "'";

            }
            return GetCondicionesDataTable(clausulas, false);
        }

        public static DataTable GetCondicionesDataTable(string clausulas, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCondicionesDataTable(clausulas, soloActivos, sesion);
            }
        }

        public static DataTable GetCondicionesDataTable(string clausulas, bool soloActivos, SessionService sesion)
        {

            StringBuilder where = new StringBuilder(50);
            if (soloActivos)
                where.AppendFormat("{0} = '{1}'", Estado_NombreCol, Definiciones.Estado.Activo);

           

            return sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetAsDataTable(where.ToString(), Nombre_NombreCol);

        }
        #endregion GetCondicionesDataTable

        #region GetPlazosVencimientos
        public DataTable GetPlazosVencimientos(decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPlazosVencimientos(condicion_pago_id, sesion);
            }
        }
        public DataTable GetPlazosVencimientos(decimal condicion_pago_id, SessionService sesion)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(Pagos_NombreCol, typeof(string));

            var cuotas = CondicionesPagoDetService.Instancia.GetFiltrado<CondicionesPagoDetService>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.CTACTE_CONDICION_PAGO_IDColumnName , Valor = condicion_pago_id },
                new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.NUMERO_CUOTAColumnName, OrderBy = true }
            });
            
            for (int i = 0; i < cuotas.Length; i++)
                dt.Rows.Add(cuotas[i].VencimientoPago.ToString());
            
            return dt;
        }
        #endregion GetVencimientos

        #region GetPrimerVencimientoPago
        public static decimal GetPrimerVencimientoPago(decimal condicion_pago_id, SessionService sesion)
        {
            var cuotas = CondicionesPagoDetService.Instancia.GetFiltrado<CondicionesPagoDetService>(new ClaseCBABase.Filtro[] 
                {
                    new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.CTACTE_CONDICION_PAGO_IDColumnName , Valor = condicion_pago_id },
                    new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.NUMERO_CUOTAColumnName, OrderBy = true }
                });
            return cuotas[0].VencimientoPago;
        }
        #endregion GetPrimerVencimientoPago

        #region GetCantidadPagos
        public static decimal GetCantidadPagos(decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                
                return GetCantidadPagos(condicion_pago_id, sesion);
            }
        }
        public static decimal GetCantidadPagos(decimal condicion_pago_id,SessionService sesion)
        {
            
                CTACTE_CONDICIONES_PAGORow condicion = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(condicion_pago_id);
                return condicion.CANTIDAD_PAGOS;
           
        }
        #endregion GetCantidadPagos

        #region GetNombre
        public static string GetNombre(decimal condicion_pago_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_PAGORow condicion = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(condicion_pago_id);
                return condicion.NOMBRE;
            }
        }
        #endregion GetNombre

        #region GetTipoCalculo
        public string GetTipoCalculo(decimal idCondicion)
        {
            using (SessionService sesion = new SessionService())
            {

                return GetTipoCalculo(idCondicion, sesion);
            }
        }
        public string GetTipoCalculo(decimal idCondicion,SessionService sesion)
        {
            
                CTACTE_CONDICIONES_PAGORow condicion = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(idCondicion);
                return condicion.TIPO_CALCULO;
            
        }
        #endregion GetTipoCalculo

        #region GetVencimiento
        /// <summary>
        /// Gets the vencimiento.
        /// </summary>
        /// <param name="condicion_pago_id">The condicion_pago_id.</param>
        /// <param name="numero_cuota">The numero_cuota.</param>
        /// <param name="fecha_base">The fecha_base.</param>
        /// <returns></returns>
        public static DateTime GetVencimiento(decimal condicion_pago_id, int numero_cuota, DateTime fecha_base)
        {
            using (SessionService sesion = new SessionService())
            {
                var row = sesion.db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(condicion_pago_id);
                DateTime vencimiento = fecha_base;

                var cuotas = CondicionesPagoDetService.Instancia.GetFiltrado<CondicionesPagoDetService>(new ClaseCBABase.Filtro[] 
                {
                    new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.CTACTE_CONDICION_PAGO_IDColumnName , Valor = condicion_pago_id },
                    new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.NUMERO_CUOTAColumnName, OrderBy = true }
                });

                if (cuotas.Length < numero_cuota)
                    throw new Exception("La condición de pago tiene " + cuotas.Length + " cuotas definidas.");

                switch (row.TIPO_CALCULO)
                {
                    case Definiciones.CondicionPagoTipoCalculo.Dias:
                        vencimiento = vencimiento.AddDays((int)cuotas[numero_cuota - 1].VencimientoPago);
                        break;
                    case Definiciones.CondicionPagoTipoCalculo.Meses:
                        vencimiento = vencimiento.AddMonths((int)cuotas[numero_cuota - 1].VencimientoPago);
                        break;
                    default:
                        throw new NotImplementedException("CondicionesPagoService.GetPrimerVencimiento(). Tipo de calculo no implementado.");
                }

                return vencimiento;
            }
        }
        #endregion GetVencimiento

        #region GetUltimoVencimiento
        /// <summary>
        /// Gets the ultimo vencimiento.
        /// </summary>
        /// <param name="ctacte_condicion_pago_id">The ctacte_condicion_pago_id.</param>
        /// <param name="fecha_base">The fecha_base.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static DateTime GetUltimoVencimiento(decimal ctacte_condicion_pago_id, DateTime fecha_base, SessionService sesion)
        {
            CTACTE_CONDICIONES_PAGORow row = sesion.db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(ctacte_condicion_pago_id);
            return CondicionesPagoService.GetVencimiento(ctacte_condicion_pago_id, int.Parse(row.CANTIDAD_PAGOS.ToString()), fecha_base);
        }
        #endregion GetUltimoVencimiento

        #region GetFechaBaseAPartirDeFechaCuota
        public static DateTime GetFechaBaseAPartirDeFechaCuota(decimal condicion_pago_id, int numero_cuota, DateTime vencimiento)
        {
            using (SessionService sesion = new SessionService())
            {
                var row = sesion.db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(condicion_pago_id);
                DateTime fechaBase = vencimiento;

                var cuotas = CondicionesPagoDetService.Instancia.GetFiltrado<CondicionesPagoDetService>(new ClaseCBABase.Filtro[] 
                {
                    new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.CTACTE_CONDICION_PAGO_IDColumnName , Valor = condicion_pago_id },
                    new ClaseCBABase.Filtro() { Columna = CondicionesPagoDetService.Modelo.NUMERO_CUOTAColumnName, OrderBy = true }
                });

                if (cuotas.Length < numero_cuota)
                    throw new Exception("La condición de pago tiene " + cuotas.Length + " cuotas definidas.");

                switch (row.TIPO_CALCULO)
                {
                    case Definiciones.CondicionPagoTipoCalculo.Dias:
                        fechaBase = vencimiento.AddDays(-(int)cuotas[numero_cuota - 1].VencimientoPago);
                        break;
                    case Definiciones.CondicionPagoTipoCalculo.Meses:
                        fechaBase = vencimiento.AddMonths(-(int)cuotas[numero_cuota - 1].VencimientoPago);
                        break;
                    default:
                        throw new NotImplementedException("CondicionesPagoService.GetPrimerVencimiento(). Tipo de calculo no implementado.");
                }
                

                return fechaBase;
            }
        }
        #endregion GetFechaBaseAPartirDeFechaCuota

        #region GetTipoCondicionPago
        public static string GetTipoCondicionPago(decimal condicion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_CONDICIONES_PAGORow condicion = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetRow(" id = " + condicion_id);
                return condicion.TIPO_CONDICION_PAGO;
            }
        }
        #endregion GetTipoCondicionPago

        #region Obtener condiciones de pago
        /// <summary>
        /// Gets the condicion pago.
        /// </summary>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns> 
        public static DataTable GetCondicionPago(bool soloActivos)
        {
            CBA.FlowV2.Services.Sesion.SessionService sesion = null;
            try
            {
                DataTable dtDatos = new DataTable();
                using (sesion = new CBA.FlowV2.Services.Sesion.SessionService())
                {
                    if (soloActivos)
                    {
                        dtDatos = sesion.Db.CTACTE_CONDICIONES_PAGOCollection.GetAsDataTable("estado = '" + Definiciones.Estado.Activo + "'", "nombre");
                    }

                }
                return dtDatos;
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTACTE_CONDICIONES_PAGO"; }
        }
        public static string CantidadPagos_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.CANTIDAD_PAGOSColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.NOMBREColumnName; }
        }
        public static string TipoCalculo_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.TIPO_CALCULOColumnName; }
        }
        public static string TipoCondicionPago_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.TIPO_CONDICION_PAGOColumnName; }
        }
        public static string EsCompra_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.ES_COMPRAColumnName; }

        }
        public static string EsVenta_NombreCol
        {
            get { return CTACTE_CONDICIONES_PAGOCollection.ES_VENTAColumnName; }

        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CondicionesPagoService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CondicionesPagoService(e.RegistroId, sesion);
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
        protected CTACTE_CONDICIONES_PAGORow row;
        protected CTACTE_CONDICIONES_PAGORow rowSinModificar;
        public class Modelo : CTACTE_CONDICIONES_PAGOCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CantidadPagos { get { return row.CANTIDAD_PAGOS; } set { row.CANTIDAD_PAGOS = value; } }
        public decimal CtacteValorId { get { return row.CTACTE_VALOR_ID; } set { row.CTACTE_VALOR_ID = value; } }
        public string Descripcion { get { return ClaseCBABase.GetStringHelper(row.DESCRIPCION); } set { row.DESCRIPCION = value; } }
        public string EsCompra { get { return ClaseCBABase.GetStringHelper(row.ES_COMPRA); } set { row.ES_COMPRA = value; } }
        public string EsVenta { get { return ClaseCBABase.GetStringHelper(row.ES_VENTA); } set { row.ES_VENTA = value; } }
        public string Estado { get { return ClaseCBABase.GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public string TipoCalculo { get { return ClaseCBABase.GetStringHelper(row.TIPO_CALCULO); } set { row.TIPO_CALCULO = value; } }
        public string TipoCondicionPago { get { return ClaseCBABase.GetStringHelper(row.TIPO_CONDICION_PAGO); } set { row.TIPO_CONDICION_PAGO = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CONDICIONES_PAGOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CONDICIONES_PAGORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public CondicionesPagoService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CondicionesPagoService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CondicionesPagoService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CondicionesPagoService(EdiCBA.CondicionPago edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CondicionesPagoService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.CantidadPagos = edi.cantidad_pagos;
            this.Descripcion = edi.nombre;
            this.EsCompra = edi.es_compra ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.EsVenta = edi.es_venta ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            this.Nombre = edi.nombre;
            this.TipoCalculo = edi.tipo_calculo;
            this.TipoCondicionPago = edi.tipo_condicion;
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            var e = new EdiCBA.CondicionPago()
            {
                cantidad_pagos = this.CantidadPagos,
                nombre = this.Nombre,
                tipo_calculo = this.TipoCalculo,
                tipo_condicion = this.TipoCondicionPago
            };

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = this.GetOrCreateUUID(sesion);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
