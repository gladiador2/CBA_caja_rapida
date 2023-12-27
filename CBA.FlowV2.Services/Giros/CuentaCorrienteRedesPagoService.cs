using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;

namespace CBA.FlowV2.Services.Giros
{
    public class CuentaCorrienteRedesPagosService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal red_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_REDES_PAGORow red = sesion.Db.CTACTE_REDES_PAGOCollection.GetRow(Id_NombreCol + " = " + red_id);
                return red.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetProveedorId
        public static decimal GetProveedorId(decimal red_id, SessionService sesion)
        {
            CTACTE_REDES_PAGORow row = sesion.Db.CTACTE_REDES_PAGOCollection.GetByPrimaryKey(red_id);
            return row.PROVEEDOR_ID;
        }
        #endregion GetProveedorId

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

                    CTACTE_REDES_PAGORow row = new CTACTE_REDES_PAGORow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_REDES_PAGO_SQC");
                    }
                    else
                    {
                        row = sesion.Db.CTACTE_REDES_PAGOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.ABREVIATURA = campos[Abreviatura_NombreCol].ToString();
                    row.TELEFONO1 = campos[Telefono1_NombreCol].ToString();
                    row.TELEFONO2 = campos[Telefono2_NombreCol].ToString();
                    row.EMAIL1 = campos[Email1_NombreCol].ToString();
                    row.EMAIL2 = campos[Email2_NombreCol].ToString();

                    if(campos.Contains(ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = (decimal)campos[ProveedorId_NombreCol];
                    else
                        row.IsPROVEEDOR_IDNull = true;

                    if (insertarNuevo) sesion.Db.CTACTE_REDES_PAGOCollection.Insert(row);
                    else sesion.Db.CTACTE_REDES_PAGOCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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

        #region GetRedesPagoDataTable
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetRedesPagoDataTable(string orden, bool soloActivos)
        {
            string where = string.Empty;
            if (soloActivos) where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            return GetRedesPagoDataTable(where, orden);
        }

        public static DataTable GetRedesPagoDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_REDES_PAGOCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetRedesPagoDataTable

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_REDES_PAGO"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.IDColumnName; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.ABREVIATURAColumnName; }
        }
        public static string Email1_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.EMAIL1ColumnName; }
        }
        public static string Email2_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.EMAIL2ColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.NOMBREColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.PROVEEDOR_IDColumnName; }
        }
        public static string Telefono1_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.TELEFONO1ColumnName; }
        }
        public static string Telefono2_NombreCol
        {
            get { return CTACTE_REDES_PAGOCollection.TELEFONO2ColumnName; }
        }
        #endregion Tabla

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected CTACTE_REDES_PAGORow row;
        protected CTACTE_REDES_PAGORow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Abreviatura { get { return row.ABREVIATURA; } set { row.ABREVIATURA = value; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }

        #region Propiedades Extendidas
        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                    this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                return this._proveedor;
            }
        }
        #endregion Propiedades Extendidas
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_REDES_PAGOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_REDES_PAGORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public CuentaCorrienteRedesPagosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CuentaCorrienteRedesPagosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CuentaCorrienteRedesPagosService(decimal id) 
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
