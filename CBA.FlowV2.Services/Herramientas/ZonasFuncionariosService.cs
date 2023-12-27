using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;

namespace CBA.FlowV2.Services.Herramientas
{
    using VS = Definiciones.VariablesDeSistema;
    using VSEService = VariablesSistemaEntidadService;
    using TipoFuncionario = Definiciones.TipoFuncionarioComision;
    public static class ZonasFuncionariosService
    {

        public static decimal GetVendedor(decimal zona_id)
        {
            return GetFuncionarioTipado(zona_id, Definiciones.TipoFuncionarioComision.Vendedor);
        }
        public static decimal GetCobrador(decimal zona_id)
        {
            return GetFuncionarioTipado(zona_id, Definiciones.TipoFuncionarioComision.Cobrador);
        }
        public static decimal GetFuncionarioTipado(decimal zona_id, string tipo_funcionario)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = String.Format("{0} = {1} and {2} = '{3}'", ZonasId_NombreCol, zona_id, Funcion_NombreCol, tipo_funcionario);
                ZONAS_FUNCIONARIOSRow row = sesion.Db.ZONAS_FUNCIONARIOSCollection.GetRow(where);

                if (row == null)
                    return Definiciones.Error.Valor.EnteroPositivo;
                else
                    return row.FUNCIONARIO_ID;
            }
        }

        public static DataTable GetZonasPorFuncionario(decimal funcionario_id)
        {
            return GetZonasPorFuncionario(funcionario_id, new string[0]);
        }
        public static DataTable GetZonasPorFuncionario(decimal funcionario_id, string[] funciones)
        {

            using (SessionService sesion = new SessionService())
            {
                string where = String.Format("{0} = {1}", FuncionarioId_NombreCol, funcionario_id);
                foreach (string funcion in funciones)
                    where += string.Format(" and {0} = '{1}'", Funcion_NombreCol, funcion);
                return sesion.Db.ZONAS_FUNCIONARIOS_INFO_COMPCollection.GetAsDataTable(where, Id_NombreCol);
            }
        }


        public static DataTable GetFuncionariosPorZona(decimal zona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = String.Format("{0} = {1}", ZonasId_NombreCol, zona_id);
                return sesion.Db.ZONAS_FUNCIONARIOS_INFO_COMPCollection.GetAsDataTable(where, Id_NombreCol);
            }
        }
        public static void DesrelacionarFuncionario(decimal funcionario_id)
        {
            DesrelacionarFuncionario(funcionario_id, new string[0]);
        }
        public static void DesrelacionarFuncionario(decimal funcionario_id, string funcion)
        {
            DesrelacionarFuncionario(funcionario_id, new string []{funcion});
        }
        public static void DesrelacionarFuncionario(decimal funcionario_id, string []funciones)
        {
            DataTable zonasFuncionarios = GetZonasPorFuncionario(funcionario_id,funciones);
            foreach (DataRow relacion in zonasFuncionarios.Rows)
                Borrar((decimal)relacion[Id_NombreCol]);
        }
        public static decimal Borrar(decimal zona_funcionario_id)
        {
            ZONAS_FUNCIONARIOSRow relacion = new ZONAS_FUNCIONARIOSRow();
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    relacion = sesion.Db.ZONAS_FUNCIONARIOSCollection.GetByPrimaryKey(zona_funcionario_id);
                    string valorAnterior = relacion.ToString();
                    sesion.Db.BeginTransaction();
                    if (sesion.Db.ZONAS_FUNCIONARIOSCollection.Delete(relacion))
                        LogCambiosService.LogDeRegistro(ZonasService.Nombre_Tabla, relacion.ID, relacion.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exception)
                {
                    sesion.RollbackTransaction();
                    throw exception;
                }
            }
            return relacion.ID;
        }
        public static decimal Borrar(Hashtable campos)
        {
            #region Configuracion
            Func<string, string> and = (x) => string.IsNullOrEmpty(x)?string.Empty:"AND";
            #endregion Configuracion
            ZONAS_FUNCIONARIOSRow relacion = new ZONAS_FUNCIONARIOSRow();
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    campos[Funcion_NombreCol] = String.Format("'{0}'", campos[Funcion_NombreCol]);
                    string where = string.Empty;
                    foreach (string llave in campos.Keys)
                        where += String.Format(" {0} {1} = {2}" ,and(where), llave, campos[llave]);
                    relacion = sesion.Db.ZONAS_FUNCIONARIOSCollection.GetRow(where);
                    string valorAnterior = relacion.ToString();
                    sesion.Db.BeginTransaction();
                    if(sesion.Db.ZONAS_FUNCIONARIOSCollection.Delete(relacion))
                        LogCambiosService.LogDeRegistro(ZonasService.Nombre_Tabla, relacion.ID, relacion.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exception)
                {
                    sesion.RollbackTransaction();
                    throw exception;
                }
            }
            return relacion.ID;
        }
        public static decimal Guardar(Hashtable campos, bool insertar_nuevo)
        {
            #region Configuracion
            ZONAS_FUNCIONARIOSRow relacion = new ZONAS_FUNCIONARIOSRow();
            #endregion
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string valorAnterior;
                    if (insertar_nuevo)
                    {
                        relacion.ID = sesion.Db.GetSiguienteSecuencia(Secuencia_Nombre);
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        relacion = sesion.Db.ZONAS_FUNCIONARIOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = relacion.ToString();
                    }
                    relacion.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];
                    relacion.FUNCION = (string)campos[Funcion_NombreCol];
                    relacion.ZONAS_ID = (decimal)campos[ZonasId_NombreCol];
                    
                    sesion.Db.BeginTransaction();
                    
                    //Validar que el funcionario pertenece a la sucursal de la zona
                    DataTable dtFuncionario = FuncionariosService.GetFuncionariosDataTable2(FuncionariosService.Id_NombreCol + " = " + relacion.FUNCIONARIO_ID, string.Empty, false);
                    DataTable dtZonas = ZonasService.GetZonasEnDataTable(ZonasService.Id_NombreCol + " = " + relacion.ZONAS_ID, string.Empty);
                    if ((decimal)dtFuncionario.Rows[0][FuncionariosService.SucursalId_NombreCol] != (decimal)dtZonas.Rows[0][ZonasService.SucursalId_NombreCol])
                        throw new Exception("La sucursal de la zona no corresponde a la sucursal del funcionario.");

                    if (!Controlar(relacion))
                        throw new Exception("La zona ya cuenta con un funcionario en dicha función. ");
                    
                    if (insertar_nuevo) sesion.Db.ZONAS_FUNCIONARIOSCollection.Insert(relacion);
                    else sesion.Db.ZONAS_FUNCIONARIOSCollection.Update(relacion);
                    
                    LogCambiosService.LogDeRegistro(ZonasService.Nombre_Tabla, relacion.ID, valorAnterior, relacion.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exception)
                {
                    sesion.RollbackTransaction();
                    throw exception;
                }
            }
            return relacion.ID;
        }
        private static decimal GetCountFuncionariosPorZona(ZONAS_FUNCIONARIOSRow relacion)
        {
            string count = "COUNT";
            string query = string.Format("select count(*) {5} from {0} zf where zf.{1} = {2} and zf.{3} = '{4}'",
                NombreTabla, ZonasId_NombreCol, relacion.ZONAS_ID, Funcion_NombreCol, relacion.FUNCION, count);
            return (decimal)(new SessionService().Db.EjecutarQuery(query)).Rows[0][count];
        }
        private static bool Controlar(ZONAS_FUNCIONARIOSRow relacion)
        {
            decimal max = Definiciones.Error.Valor.EnteroPositivo; decimal nFuncionario = GetCountFuncionariosPorZona(relacion);
            switch (relacion.FUNCION)
            {
                case TipoFuncionario.Vendedor:
                    max = VSEService.GetValorDecimal(VS.MaxVendedoresPorZona);
                    break;
                case TipoFuncionario.Cobrador:
                    max = VSEService.GetValorDecimal(VS.MaxCobradoresPorZona);
                    break;
                case TipoFuncionario.Promotor:
                    max = VSEService.GetValorDecimal(VS.MaxPromotoresPorZona);
                    break;

                case TipoFuncionario.CobradorExterno:
                    max = VSEService.GetValorDecimal(VS.MaxCobradoresExternoPorZona);
                    break;
            }
            return max > nFuncionario;
        }
        #region Accessors
        public static string Secuencia_Nombre
        {
            get { return "zonas_funcionarios_sqc"; }
        }
        public static string NombreTabla
        {
            get { return "ZONAS_FUNCIONARIOS"; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return ZONAS_FUNCIONARIOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Funcion_NombreCol
        {
            get { return ZONAS_FUNCIONARIOSCollection.FUNCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ZONAS_FUNCIONARIOSCollection.IDColumnName; }
        }
        public static string ZonasId_NombreCol
        {
            get { return ZONAS_FUNCIONARIOSCollection.ZONAS_IDColumnName; }
        }

        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return ZONAS_FUNCIONARIOS_INFO_COMPCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaZonaAbreviatura_NombreCol
        {
            get { return ZONAS_FUNCIONARIOS_INFO_COMPCollection.ZONA_ABREVIATURAColumnName; }
        }
        public static string VistaZonaId_NombreCol
        {
            get { return ZONAS_FUNCIONARIOS_INFO_COMPCollection.ZONAS_IDColumnName; }
        }
        public static string VistaZonaNombre_NombreCol
        {
            get { return ZONAS_FUNCIONARIOS_INFO_COMPCollection.ZONA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
