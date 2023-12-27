using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;


namespace CBA.FlowV2.Services.Herramientas
{
    public static class ZonasService
    {
        #region Booleans
        public static bool EstaActivo(decimal zona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ZONASRow zona= sesion.Db.ZONASCollection.GetByPrimaryKey(zona_id);
                return zona.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion Booleans

        #region Getters
        public static ZONASRow GetZonaPorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ZONASCollection.GetByPrimaryKey(id);
            }
        }
        public static DataTable GetZonasEnDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ZONAS_INFO_COMPLETACollection.GetAllAsDataTable();
            }
        }
        public static DataTable GetZonasEnDataTable(string clausula, string order_by)
        {
            using (SessionService sesion = new SessionService()) {
                return sesion.Db.ZONAS_INFO_COMPLETACollection.GetAsDataTable(clausula, order_by);
            }
        }
        public static DataTable GetZonasSinFuncionario(string[] tipos_funcionario, string clausula) { 
            string clausulaFuncionarios = string.Empty;
            if (tipos_funcionario.Length >= 1) {
                clausulaFuncionarios = "select " + ZonasFuncionariosService.Id_NombreCol +
                    " from " + ZonasFuncionariosService.NombreTabla +
                    " where " + ZonasFuncionariosService.Funcion_NombreCol + " in ( '" + string.Join("','", tipos_funcionario) + "')";
            } else {
                clausulaFuncionarios = Definiciones.Error.Valor.EnteroPositivo.ToString();
            }
            if (!clausula.Equals(string.Empty))
                clausula += " and ";
            clausula +=  ZonasService.Id_NombreCol + " not in (" + clausulaFuncionarios + ")";

            return GetZonasEnDataTable(clausula, ZonasService.Nombre_NombreCol);
        }

        public static DataTable GetZonasSinFuncionario(string[] tipos_funcionario)
        {
            Func<string, string> or = (cadena) => string.IsNullOrEmpty(cadena)? string.Empty : "OR";
            using (SessionService sesion = new SessionService())
            {
                string subSelect = string.Empty;
                string where=String.Empty;
                foreach (string funcion in tipos_funcionario)
                {
                    subSelect = String.Format("select zf.{0} from {1} zf where zf.{2} = '{3}'",
                        ZonasFuncionariosService.ZonasId_NombreCol,
                        ZonasFuncionariosService.NombreTabla,
                        ZonasFuncionariosService.Funcion_NombreCol,
                        funcion);
                    where += String.Format(" {0} ID not in ({1})", or(where),subSelect);
                }
                return sesion.Db.ZONAS_INFO_COMPLETACollection.GetAsDataTable(where, Id_NombreCol);
            }
        }
        public static DataTable GetZonasPorSucursal(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = String.Format("{0} = {1}",SucursalId_NombreCol,sucursal_id);
                return sesion.Db.ZONAS_INFO_COMPLETACollection.GetAsDataTable(where, Id_NombreCol);
            }
        }
        #endregion Getters

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertar_nuevo) 
        {
            ZONASRow zona = new ZONASRow();
            String valorAnterior = "";
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    if (insertar_nuevo)
                    {
                        zona.ID = sesion.Db.GetSiguienteSecuencia(ZonasService.Secuencia);
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        zona = GetZonaPorId(decimal.Parse(campos[ZonasService.Id_NombreCol].ToString()));
                        valorAnterior = zona.ToString();
                    }
                    zona.NOMBRE = (string)campos[ZonasService.Nombre_NombreCol];
                    zona.ABREVIATURA= (string)campos[ZonasService.Abreviatura_NombreCol];
                    zona.ESTADO = (string)campos[ZonasService.Estado_NombreCol];
                    zona.SUCURSAL_ID = (decimal)campos[ZonasService.SucursalId_NombreCol];


                    if (campos.Contains(ZonasService.CiudadId_NombreCol))
                    {
                        zona.CIUDAD_ID = (decimal)campos[ZonasService.CiudadId_NombreCol];
                    }
                    else
                    {
                        zona.IsCIUDAD_IDNull = true;
                    }

                    sesion.Db.BeginTransaction();
                    if (insertar_nuevo) sesion.Db.ZONASCollection.Insert(zona);
                    else sesion.Db.ZONASCollection.Update(zona);
                    LogCambiosService.LogDeRegistro(ZonasService.Nombre_Tabla, zona.ID, valorAnterior, zona.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                    return zona.ID;
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }

            }

        }
        #endregion Guardar

        #region Accesors
        public static string Nombre_Tabla 
        {
            get { return  "ZONAS"; }
        }
        public static string Nombre_Vista
        {
            get { return "ZONAS_INFO_COMPLETA"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return  ZONASCollection.ABREVIATURAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ZONASCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ZONASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return ZONASCollection.NOMBREColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return ZONASCollection.SUCURSAL_IDColumnName; }
        }

        public static string CiudadId_NombreCol
        {
            get { return ZONASCollection.CIUDAD_IDColumnName; }
        }

        #region Vista
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return ZONAS_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return ZONAS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaCiudadNombre_NombreCol
        {
            get { return ZONAS_INFO_COMPLETACollection.NOMBRE_CIUDADColumnName; }
        }

        #endregion Vista
        #endregion Accesors

        #region Miembros Privados
        private static string Secuencia = "zonas_sqc";
        #endregion Miembros Privados
    }
}
