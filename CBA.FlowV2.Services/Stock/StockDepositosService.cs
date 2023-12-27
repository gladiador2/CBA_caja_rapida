#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockDepositosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal stock_deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaActivo(stock_deposito_id, sesion);
            }
        }

        public static bool EstaActivo(decimal stock_deposito_id, SessionService sesion)
        {
            STOCK_DEPOSITOSRow row = sesion.Db.STOCK_DEPOSITOSCollection.GetByPrimaryKey(stock_deposito_id);
            return row.ESTADO == Definiciones.Estado.Activo;
        }
        #endregion EstaActivo

        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal stock_deposito_id, SessionService sesion)
        {
            STOCK_DEPOSITOSRow row = sesion.Db.STOCK_DEPOSITOSCollection.GetByPrimaryKey(stock_deposito_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region GetStockDeposito
        /// <summary>
        /// Gets the stock deposito.
        /// </summary>
        /// <param name="deposito_id">The deposito_id.</param>
        /// <returns></returns>
        public static STOCK_DEPOSITOSRow GetStockDeposito(Decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.STOCK_DEPOSITOSCollection.GetByPrimaryKey(deposito_id);
            }
        }
        #endregion

        #region GetStockDepositosDataTable
        /// <summary>
        /// Gets the stock depositos data table.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static DataTable GetStockDepositosDataTable(decimal sucursal_id, bool solo_para_facturar, bool solo_activos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Realizar la busqueda sin importar tildes ni mayusculas
                sesion.Db.IniciarBusquedaFlexible();
                string clausula = SucursalId_NombreCol + " = " + sucursal_id;
                
                if (solo_para_facturar)
                    clausula += " and " + ParaFacturar_NombreCol + " = '" + CBA.FlowV2.Services.Base.Definiciones.SiNo.Si + "' ";

                if (solo_activos)
                    clausula += " and " + Estado_NombreCol + " = '" + CBA.FlowV2.Services.Base.Definiciones.Estado.Activo + "' ";

                dt = sesion.Db.STOCK_DEPOSITOSCollection.GetAsDataTable(clausula, Orden_NombreCol);

                //Finalizar el uso de busqueda sin importar tildes ni mayusculas
                sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }

        public static DataTable GetStockDepositosDataTable(decimal sucursal_id, decimal proveedor_id, bool solo_para_facturar, bool solo_activos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Realizar la busqueda sin importar tildes ni mayusculas
                sesion.Db.IniciarBusquedaFlexible();
                string clausula = SucursalId_NombreCol + " = " + sucursal_id;

                clausula += " and " + ProveedorId_NombreCol + " = " + proveedor_id;

                if (solo_para_facturar)
                    clausula += " and " + ParaFacturar_NombreCol + " = '" + CBA.FlowV2.Services.Base.Definiciones.SiNo.Si + "' ";

                if (solo_activos)
                    clausula += " and " + Estado_NombreCol + " = '" + CBA.FlowV2.Services.Base.Definiciones.Estado.Activo + "' ";

                dt = sesion.Db.STOCK_DEPOSITOSCollection.GetAsDataTable(clausula, Orden_NombreCol);

                //Finalizar el uso de busqueda sin importar tildes ni mayusculas
                sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }


        [Obsolete("Utilizar métodos estáticos")]
        /// <summary>
        /// Gets the stock depositos data table.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public DataTable GetStockDepositosDataTable(decimal sucursal_id)
        {
            return StockDepositosService.GetStockDepositosDataTable(sucursal_id, false, true);
        }

        /// <summary>
        /// Gets the stock depositos data table.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static DataTable GetStockDepositosDataTable2(decimal sucursal_id)
        {
            return StockDepositosService.GetStockDepositosDataTable(sucursal_id, false, true);
        }
        #endregion GetStockDepositosDataTable

        #region GetStockDepositosInfoCompleta
        /// <summary>
        /// Gets the stock depositos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetStockDepositosInfoCompleta(string clausulas, string orden, bool solo_activos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                string where = clausulas;

                //Realizar la busqueda sin importar tildes ni mayusculas
                sesion.Db.IniciarBusquedaFlexible();

                if (solo_activos)
                {
                    if (clausulas.Length > 0) where += " and ";
                    where += Estado_NombreCol + " = '" + CBA.FlowV2.Services.Base.Definiciones.Estado.Activo + "' ";
                }

                dt = sesion.Db.STOCK_DEPOSITOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);

                //Finalizar el uso de busqueda sin importar tildes ni mayusculas
                sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }
        #endregion GetStockDepositosInfoCompleta

        #region GetStockDepositosPorEntidad
        /// <summary>
        /// Gets the stock depositos por entidad.
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <returns></returns>
        public STOCK_DEPOSITOSRow[] GetStockDepositosPorEntidad(decimal entidad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                System.Collections.ArrayList recordList = new System.Collections.ArrayList();
                SUCURSALESRow[] sucursales = sesion.Db.SUCURSALESCollection.GetByENTIDAD_ID(entidad_id);
                STOCK_DEPOSITOSRow[] depositos;

                foreach (SUCURSALESRow sucursal in sucursales)
                {
                    //Se agregan todos los depositos de la sucursal actual
                    recordList.AddRange(sesion.Db.STOCK_DEPOSITOSCollection.GetBySUCURSAL_ID(sucursal.ID));
                }
                
                //Se convierte el ArrayList a un Array y se realiza un casting a STOCK_DEPOSITOSRow
                depositos = new STOCK_DEPOSITOSRow[recordList.Count];
                for (int i = 0 ; i < recordList.Count; i++ )
                {
                    depositos[i] = (STOCK_DEPOSITOSRow)recordList[i];
                }

                return depositos;
            }
        }
        #endregion GetStockDepositosPorEntidad

        #region GetStockDepositosDataTableStatic
        
        public static DataTable GetStockDepositosDataTableStatic(string clausulas, string orden, SessionService sesion)
        {

            return sesion.Db.STOCK_DEPOSITOSCollection.GetAsDataTable(clausulas, orden);

        }

        public static DataTable GetStockDepositosDataTableStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetStockDepositosDataTableStatic(clausulas, orden, sesion);
            }
        }
        
        #endregion GetStockDepositosDataTableStatic

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <returns></returns>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    STOCK_DEPOSITOSRow row = new STOCK_DEPOSITOSRow();
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("stock_depositos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.STOCK_DEPOSITOSCollection.GetRow(StockDepositosService.Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = (string)campos[StockDepositosService.Nombre_NombreCol];
                    row.ABREVIATURA = (string)campos[StockDepositosService.Abreviatura_NombreCol];
                    row.ESTADO = (string)campos[StockDepositosService.Estado_NombreCol];
                    row.PARA_FACTURAR = (string)campos[StockDepositosService.ParaFacturar_NombreCol];

                    if (campos.Contains(StockDepositosService.CentroCostoId_NombreCol))
                        row.CENTRO_COSTO_ID = (decimal)campos[StockDepositosService.CentroCostoId_NombreCol];
                    else
                        row.IsCENTRO_COSTO_IDNull = true;

                    //Si se modifico sucursal
                    if (row.SUCURSAL_ID != (decimal)campos[StockDepositosService.SucursalId_NombreCol])
                    {
                        //Se verifica que la sucursal este activo
                        if (SucursalesService.EstaActivo((decimal)campos[StockDepositosService.SucursalId_NombreCol]))
                            row.SUCURSAL_ID = (decimal)campos[StockDepositosService.SucursalId_NombreCol];
                        else
                            throw new Exception("La sucursal no se encuentra activa.");
                    }

                    //Carga la sucursal id si contiene el campo
                    if (campos.Contains(StockDepositosService.SectorId_NombreCol))
                        row.SUCURSAL_SECTOR_ID = (decimal)campos[StockDepositosService.SectorId_NombreCol];
                    else
                        row.IsSUCURSAL_SECTOR_IDNull = true;

                    if (campos.Contains(StockDepositosService.Orden_NombreCol))
                        row.ORDEN = (decimal)campos[StockDepositosService.Orden_NombreCol];
                    else
                        row.IsORDENNull = true;

                    if (campos.Contains(StockDepositosService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = (decimal)campos[StockDepositosService.ProveedorId_NombreCol];                                           

                    if (insertarNuevo) sesion.Db.STOCK_DEPOSITOSCollection.Insert(row);
                    else sesion.Db.STOCK_DEPOSITOSCollection.Update(row);

                    //Se Cargan incluyen todos los articulos con sus respectivos lotes en el nuevo deposito
                    if (insertarNuevo)
                    {
                       // (new ArticulosLotesService()).InsertarLotesExistentesEnSucursal(row.ID, row.SUCURSAL_ID, sesion);
                    }
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
        }
        #endregion Guardar

        #region GetSucursalId
        public static decimal GetSucursalId(decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSucursalId(deposito_id, sesion);
            }
        }

        public static decimal GetSucursalId(decimal deposito_id, SessionService sesion)
        {
            return sesion.db.STOCK_DEPOSITOSCollection.GetByPrimaryKey(deposito_id).SUCURSAL_ID;
        }
        #endregion GetSucursalId

        #region GetSectorId
        public static decimal GetSectorId(decimal deposito_id)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    return sesion.db.STOCK_DEPOSITOSCollection.GetByPrimaryKey(deposito_id).SUCURSAL_SECTOR_ID;
                }
            }
            catch (Exception exp)
            {
                return Definiciones.Error.Valor.EnteroPositivo;
            }
        }
        #endregion GetSectorId

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "STOCK_DEPOSITOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "STOCK_DEPOSITOS_INFO_COMPLETA"; }
        }
        public static string Id_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.IDColumnName; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.ABREVIATURAColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.ORDENColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string SectorId_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.SUCURSAL_SECTOR_IDColumnName; }
        }
        public static string ParaFacturar_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.PARA_FACTURARColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaParaFacturar_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.PARA_FACTURARColumnName; }
        }
        public static string VistaSectorId_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.SUCURSAL_SECTOR_IDColumnName; }
        }
        public static string VistaSectorNombre_NombreCol
        {
            get {return STOCK_DEPOSITOS_INFO_COMPLETACollection.SECTOR_NOMBREColumnName;}
        }
        public static string VistaSectorAbreviatura_NombreCol
        {
            get { return STOCK_DEPOSITOS_INFO_COMPLETACollection.SECTOR_ABREVIATURAColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return STOCK_DEPOSITOSCollection.PROVEEDOR_IDColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static StockDepositosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid},
            });

            if (e == null)
                return null;
            else
                return new StockDepositosService(e.RegistroId, sesion);
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
        protected STOCK_DEPOSITOSRow row;
        protected STOCK_DEPOSITOSRow rowSinModificar;
        public class Modelo : STOCK_DEPOSITOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return ClaseCBABase.GetStringHelper(row.NOMBRE); } set { row.NOMBRE = value; } }
        public decimal? Orden { get { if (row.IsORDENNull) return null; else return row.ORDEN; } set { if (value.HasValue) row.ORDEN = value.Value; else row.IsORDENNull = true; } }
        public string ParaFacturar { get { return ClaseCBABase.GetStringHelper(row.PARA_FACTURAR); } set { row.PARA_FACTURAR = value; } }
        public decimal? SucursalSectorId { get { if (row.IsSUCURSAL_SECTOR_IDNull) return null; else return row.SUCURSAL_SECTOR_ID; } set { if (value.HasValue) row.SUCURSAL_SECTOR_ID = value.Value; else row.IsSUCURSAL_SECTOR_IDNull = true; } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { row.SUCURSAL_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId);
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
                this.row = sesion.db.STOCK_DEPOSITOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_DEPOSITOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(STOCK_DEPOSITOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public StockDepositosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockDepositosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockDepositosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public StockDepositosService(EdiCBA.Deposito edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = StockDepositosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.Abreviatura = edi.nombre;
            this.Nombre = edi.nombre;

            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal
        }
        private StockDepositosService(STOCK_DEPOSITOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Buscar
        public static StockDepositosService[] Buscar(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return Buscar(clausulas, orden, sesion);
            }
        }
        public static StockDepositosService[] Buscar(string clausulas, string orden, SessionService sesion)
        {
            string where = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            if (clausulas.Length > 0)
                where += " and (" + clausulas + ")";
            STOCK_DEPOSITOSRow[] rows = sesion.db.STOCK_DEPOSITOSCollection.GetAsArray(where, orden);
            StockDepositosService[] sd = new StockDepositosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                sd[i] = new StockDepositosService(rows[i]);
            return sd;
        }
        #endregion Buscar

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Deposito()
            {
                nombre = this.Nombre,
                sucursal_uuid = this.Sucursal.GetOrCreateUUID(sesion),
            };

            if (profundidad_resolucion != EdiCBA.ProfundidadResolucion.NoProfundizar)
            {
                e.sucursal = (EdiCBA.Sucursal)this.Sucursal.ToEDI(nueva_profundidad, sesion);
            }

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




