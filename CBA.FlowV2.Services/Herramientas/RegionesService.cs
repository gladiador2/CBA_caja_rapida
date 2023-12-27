#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class RegionesService
    {
        #region Booleans
        public static bool EstaActivo(decimal region_id)
        {
            using (SessionService sesion = new SessionService())
            {
                REGIONESRow region= sesion.Db.REGIONESCollection.GetByPrimaryKey(region_id);
                return region.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion Booleans

        #region Getters
        public static decimal GetCentroCosto(decimal region_id, SessionService sesion)
        {
            REGIONESRow row = sesion.Db.REGIONESCollection.GetByPrimaryKey(region_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        
        private static REGIONESRow GetRegionPorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REGIONESCollection.GetByPrimaryKey(id);
            }
        }
        public static DataTable GetRegionesEnDataTable()
        {
            using (SessionService sesion = new SessionService()) 
            {
                return GetRegionesEnDataTable(RegionesService.EntidadId_NombreCol + " = " + sesion.Entidad.ID, RegionesService.Nombre_NombreCol, sesion);
            }
        }

        public static DataTable GetRegionesEnDataTable(string where, string order_by) 
        {
            using (SessionService sesion = new SessionService()) 
            {
                return GetRegionesEnDataTable(where, order_by, sesion);
            }
        }

        public static DataTable GetRegionesEnDataTable(string where, string order_by, SessionService sesion)
        {
            return sesion.Db.REGIONESCollection.GetAsDataTable(where, order_by);
        }
        
        public static DataTable GetRegionesHabilitadasPorUsuarioDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = RegionesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                                   " exists(select * from " + UsuariosSucursalesService.Nombre_Tabla + " us " +
                                   "         where us." + UsuariosSucursalesService.RegionId_NombreCol + " = " + RegionesService.Nombre_Tabla + "." + RegionesService.Id_NombreCol + " and " +
                                   "               us." + UsuariosSucursalesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")";

                DataTable dt = RegionesService.GetRegionesEnDataTable(clausulas, RegionesService.Nombre_NombreCol, sesion);
                return dt;
            }
        }
        #endregion Getters

        #region RefrescarCombobox
        public static void RefrescarCombobox(ref System.Windows.Forms.ComboBox cbo)
        {
            using (SessionService sesion = new SessionService())
            {
                var dt = UsuariosSucursalesService.GetRegionesPorUsuario(sesion.Usuario.ID, sesion);
                if(dt.Rows.Count <= 0)
                    dt = RegionesService.GetRegionesEnDataTable(RegionesService.Id_NombreCol + " = " + sesion.SucursalActiva.REGION_ID, string.Empty);
                cbo.DataSource = dt;
                cbo.DisplayMember = RegionesService.Nombre_NombreCol;
                cbo.ValueMember = RegionesService.Id_NombreCol;

                if (sesion.SucursalActiva.IsREGION_IDNull)
                    cbo.SelectedItem = null;
                else
                    cbo.SelectedValue = sesion.SucursalActiva.REGION_ID;
            }
        }
        #endregion RefrescarCombobox

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            return Guardar(campos, true);
        }
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo) 
        {
            REGIONESRow region = new REGIONESRow();
            string valorAnterior = "";
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (insertarNuevo)
                    {
                        region.ID = sesion.Db.GetSiguienteSecuencia(RegionesService.Nombre_Secuencia);
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        region = GetRegionPorId(decimal.Parse(campos[RegionesService.Id_NombreCol].ToString()));
                        valorAnterior = region.ToString();
                    }
                    region.NOMBRE = (string)campos[RegionesService.Nombre_NombreCol];
                    region.ABREVIATURA= (string)campos[RegionesService.Abreviatura_NombreCol];
                    region.ESTADO = (string)campos[RegionesService.Estado_NombreCol];
                    region.ENTIDAD_ID = sesion.Entidad.ID;

                    if (campos.Contains(RegionesService.CentroCostoId_NombreCol))
                        region.CENTRO_COSTO_ID = (decimal)campos[RegionesService.CentroCostoId_NombreCol];
                    else
                        region.IsCENTRO_COSTO_IDNull = true;
                    
                    if (insertarNuevo) sesion.Db.REGIONESCollection.Insert(region);
                    else sesion.Db.REGIONESCollection.Update(region);
                    LogCambiosService.LogDeRegistro(RegionesService.Nombre_Tabla, region.ID, valorAnterior, region.ToString(), sesion);
                    return region.ID;
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion Guardar

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "REGIONES"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "REGIONES_SQC"; }
        }
        public static string Abreviatura_NombreCol 
        {
            get { return REGIONESCollection.ABREVIATURAColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return REGIONESCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return REGIONESCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return REGIONESCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol 
        { 
            get { return REGIONESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return REGIONESCollection.NOMBREColumnName; }
        }
        #endregion Accesors

        #region CODIGO NUEVO orientacion a objetos
        #region Propiedades
        protected REGIONESRow row;
        protected REGIONESRow rowSinModificar;
        
        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return ClaseCBABase.GetStringHelper(row.ABREVIATURA); } set { row.ABREVIATURA = value; } }
        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } private set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region PropiedadesExtendidas
        private SucursalesService _sucursal_casa_matriz;
        public SucursalesService SucursalCasaMatriz
        {
            get
            {
                if (this._sucursal_casa_matriz == null)
                {
                    DataTable dt;

                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionRepresentaEmpresa) == Definiciones.SiNo.Si)
                        dt = SucursalesService.GetSucursalesDataTable2(SucursalesService.RegionId_NombreCol + " = " + this.Id + " and " + SucursalesService.EsCasaMatriz_NombreCol + " = '" + Definiciones.SiNo.Si + "'", SucursalesService.Id_NombreCol, true);
                    else
                        dt = SucursalesService.GetSucursalesDataTable2(SucursalesService.EsCasaMatriz_NombreCol + " = '" + Definiciones.SiNo.Si + "'", SucursalesService.Id_NombreCol, true);

                    this._sucursal_casa_matriz = new SucursalesService((decimal)dt.Rows[0][SucursalesService.Id_NombreCol]);
                }
                return this._sucursal_casa_matriz;
            }
        }
        #endregion PropiedadesExtendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.REGIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new REGIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public RegionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public RegionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public RegionesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores
        #endregion CODIGO NUEVO orientacion a objetos
    }
}
