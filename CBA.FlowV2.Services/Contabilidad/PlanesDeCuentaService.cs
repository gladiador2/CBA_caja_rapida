#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
   public class PlanesDeCuentaService
   {
        #region GetPlanesDeCuentaDataTable
        /// <summary>
        /// Obtiene los planes de cuenta
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns>DataTable con los planes de cuenta</returns>
        public static DataTable GetPlanesDeCuentaDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (clausulas.Length > 0)
                {
                    where += " and " + clausulas;
                }

                return sesion.Db.CTB_PLANES_CUENTACollection.GetAsDataTable(where, orden);               
            }
        }
        #endregion GetPlanesDeCuentaDataTable

        #region EstaActivo
        public static bool EstaActivo(decimal plan_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_PLANES_CUENTARow planCuenta = sesion.Db.CTB_PLANES_CUENTACollection.GetRow(Id_NombreCol + "=" + plan_cuenta_id);
                return planCuenta.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region TieneCuentas
        static public bool TieneCuentas(decimal ctb_plan_cuenta_id)
        {
           using(SessionService sesion = new SessionService())
           {
               DataTable dt = CuentasService.GetCuentasDataTable(CuentasService.CtbPlanCuentaId_NombreCol + " = " + ctb_plan_cuenta_id, string.Empty);
               return dt.Rows.Count > 0;
           }
        }
        #endregion TieneCuentas

        #region GetNombre

        public static string GetNombre(decimal plan_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_PLANES_CUENTARow row = sesion.Db.CTB_PLANES_CUENTACollection.GetByPrimaryKey(plan_cuenta_id);
                return row.NOMBRE;
            }
        }

        #endregion GetNombre

        #region TieneEjercicioActivoAsociado

        public static bool TieneEjercicioActivoAsociado(decimal ctb_plan_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                EjerciciosService ejercicio = new EjerciciosService();
                DataTable dt;

                dt = EjerciciosService.GetEjerciciosDataTable(EjerciciosService.PlanDeCuentasId_NombreCol + " = " + ctb_plan_cuenta_id + " and " + EjerciciosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", string.Empty);

                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        #endregion TieneEjercicioActivoAsociado

        #region Guardar
        /// <summary>
        /// Guarda los cambios en la base de datos (inserta o actualiza según corresponda)
        /// </summary>
        /// <param name="campos">Los campos del registro</param>
        /// <param name="insertarNuevo">Si es <c>true</c> inserta un nuevo registro</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_PLANES_CUENTARow row = new CTB_PLANES_CUENTARow();
                    
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_planes_cuenta_sqc");
                        row.ENTIDAD_ID = sesion.Entidad.ID;
                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                    }
                    else
                    {
                        row = sesion.Db.CTB_PLANES_CUENTACollection.GetByPrimaryKey((decimal)campos[PlanesDeCuentaService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[PlanesDeCuentaService.Nombre_NombreCol].ToString();
                    row.OBSERVACION = campos[PlanesDeCuentaService.Observacion_NombreCol].ToString();

                    if (row.ESTADO != null)
                    {
                        if (row.ESTADO.Equals(Definiciones.Estado.Activo) && campos[PlanesDeCuentaService.Estado_NombreCol].Equals(Definiciones.Estado.Inactivo))
                        {
                            row.USUARIO_INACTIVADO_ID = sesion.Usuario_Id;
                            row.FECHA_INACTIVADO = DateTime.Now;
                        }
                    }
                    row.ESTADO = (string)campos[Estado_NombreCol];

                    if (insertarNuevo) sesion.Db.CTB_PLANES_CUENTACollection.Insert(row);
                    else sesion.Db.CTB_PLANES_CUENTACollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exc)
                {
                    sesion.Db.RollbackTransaction();
                    throw exc;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CTB_PLANES_CUENTA"; }
        }

        public static string EntidadId_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.ENTIDAD_IDColumnName; }
        }

        public static string Estado_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.ESTADOColumnName; }
        }

        public static string FechaCreacion_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.FECHA_CREACIONColumnName; }
        }

        public static string FechaInactivado_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.FECHA_INACTIVADOColumnName; }
        }
       
        public static string Id_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.IDColumnName; }
        }
        
        public static string Nombre_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.NOMBREColumnName; }
        }
        
        public static string Observacion_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.OBSERVACIONColumnName; }
        }
        
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.USUARIO_CREACION_IDColumnName; }
        }
        
        public static string UsuarioInactivadoId_NombreCol
        {
            get { return CTB_PLANES_CUENTACollection.USUARIO_INACTIVADO_IDColumnName; }
        }

        public static string VistaEntidadNombre_NombreCol
        {
            get { return CTB_PLANES_CUENTA_INFO_COMPLCollection.ENTIDAD_NOMBREColumnName; }
        }

        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return CTB_PLANES_CUENTA_INFO_COMPLCollection.USUARIO_CREACION_NOMBREColumnName; }
        }

        public static string VistaUsuarioInactivadoNombre_NombreCol
        {
            get { return CTB_PLANES_CUENTA_INFO_COMPLCollection.USUARIO_INACTIVADO_NOMBREColumnName; }
        }

        #endregion Accessors

        #region CODIGO NUEVO orientacion a objetos
        #region Propiedades
        protected CTB_PLANES_CUENTARow row;
        protected CTB_PLANES_CUENTARow rowSinModificar;
        
        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal EntidadId { get { return row.ENTIDAD_ID; } private set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } private set { row.FECHA_CREACION = value; } }
        public DateTime? FechaInactivado { get { if (row.IsFECHA_INACTIVADONull) return null; else return row.FECHA_INACTIVADO; } set { if (value.HasValue) row.FECHA_INACTIVADO = value.Value; else row.IsFECHA_INACTIVADONull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal UsuarioCreacionId { get { return row.USUARIO_CREACION_ID; } private set { row.USUARIO_CREACION_ID = value; } }
        public decimal? UsuarioInactivadoId { get { if (row.IsUSUARIO_INACTIVADO_IDNull) return null; else return row.USUARIO_INACTIVADO_ID; } set { if (value.HasValue) row.USUARIO_INACTIVADO_ID = value.Value; else row.IsUSUARIO_INACTIVADO_IDNull = true; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_PLANES_CUENTACollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_PLANES_CUENTARow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public PlanesDeCuentaService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PlanesDeCuentaService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PlanesDeCuentaService(decimal id) 
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
