#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class SucursalesService
    {
        #region GetSucursalID
        public static decimal GetSucursalID(string abreviatura)
        {
            using (SessionService sesion = new SessionService())
            {
                SUCURSALESRow sucursal = sesion.Db.SUCURSALESCollection.GetRow(Abreviatura_NombreCol + " = '" + abreviatura + "'");
                return sucursal.ID;
            }
        }
        #endregion GetSucursalID

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                SUCURSALESRow sucursal = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
                return sucursal.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetPais
        /// <summary>
        /// Gets the pais.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static decimal GetPais(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                SUCURSALESRow sucursal = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
                return sucursal.PAIS_ID;
            }
        }
        #endregion EstaActivo

        public static string GetRUC(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRUC(sucursal_id, sesion);
            }
        }

        public static string GetRUC(decimal sucursal_id, SessionService sesion)
        {
            SUCURSALESRow sucursal = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
            return sucursal.RUC;
        }

        #region GetRegionID
        public static object GetRegionID(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRegionID(sucursal_id, sesion);
            }
        }

        public static object GetRegionID(decimal sucursal_id, SessionService sesion)
        {
            var sucursal = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
            if (sucursal.IsREGION_IDNull)
                return null;
            else
                return sucursal.REGION_ID;
        }
        #endregion GetRegionID

        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCentroCosto(sucursal_id, sesion);
            }
        }

        public static decimal GetCentroCosto(decimal sucursal_id, SessionService sesion)
        {
            SUCURSALESRow row = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region GetFCProveedorCentroCostoObligatorio
        public static bool GetFCProveedorCentroCostoObligatorio(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                SUCURSALESRow row = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
                return row.FC_PROVEEDORES_CC_OBLIGATORIO == Definiciones.SiNo.Si;
            }
        }
        #endregion GetFCProveedorCentroCostoObligatorio

        #region GetCasaMatriz
        /// <summary>
        /// Gets the casa matriz.
        /// </summary>
        /// <param name="sucursal_id">The sucursal_id.</param>
        /// <returns></returns>
        public static decimal GetCasaMatriz(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCasaMatriz(sucursal_id, sesion);
            }
        }

        public static decimal GetCasaMatriz(decimal sucursal_id, SessionService sesion)
        {
            SUCURSALESRow row = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);

            if (row.IsSUC_CASA_MATRIZ_IDNull) return Definiciones.Error.Valor.EnteroPositivo;
            else return row.SUC_CASA_MATRIZ_ID;
        }
        #endregion GetCasaMatriz

        #region GetSucursalesInfoCompleta
        /// <summary>
        /// Gets the sucursales info completa.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesInfoCompleta()
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSucursalesInfoCompleta(sesion.Entidad.ID);
            }
        }
        public static DataTable GetSucursalesInfoCompleta2()
        {
            using (SessionService sesion = new SessionService())
            {
                return SucursalesService.GetSucursalesInfoCompleta2(sesion.Entidad.ID);
            }
        }

        /// <summary>
        /// Gets the sucursales info completa.
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesInfoCompleta(decimal entidad_id)
        {
            return GetSucursalesInfoCompleta(SucursalesService.EntidadId_NombreCol + " = " + entidad_id);
        }
        public static DataTable GetSucursalesInfoCompleta2(decimal entidad_id)
        {
            return SucursalesService.GetSucursalesInfoCompleta2(SucursalesService.EntidadId_NombreCol + " = " + entidad_id);
        }

        /// <summary>
        /// Gets the sucursales info completa.
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return this.GetSucursalesInfoCompleta(clausulas, SUCURSALESCollection.NOMBREColumnName, false);
                //return sesion.Db.SUCURSALES_INFO_COMPLETACollection.GetAsDataTable(clausulas, SUCURSALESCollection.NOMBREColumnName);
            }
        }
        public static DataTable GetSucursalesInfoCompleta2(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return SucursalesService.GetSucursalesInfoCompleta2(clausulas, SUCURSALESCollection.NOMBREColumnName, false);
            }
        }

        /// <summary>
        /// Gets the sucursales info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where;

                //La busqueda debe realizarse solo para la entidad del usuario
                where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas != string.Empty) where += " and " + clausulas;

                return sesion.Db.SUCURSALES_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        public static DataTable GetSucursalesInfoCompleta2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where;

                //La busqueda debe realizarse solo para la entidad del usuario
                where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                if (clausulas != string.Empty) where += " and " + clausulas;

                return sesion.Db.SUCURSALES_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetSucursalesInfoCompleta

        #region GetSucursalesHabilitadasPorUsuarioLista
        public static string[] GetSucursalesHabilitadasPorUsuarioArray()
        {
            List<string> sucursales = new List<string>();
            DataTable dt = GetSucursalesHabilitadasPorUsuarioDataTable(string.Empty, SucursalesService.Nombre_NombreCol);

            for(int i=0;i<dt.Rows.Count;i++)
                sucursales.Add(dt.Rows[i][SucursalesService.Id_NombreCol].ToString());

            return sucursales.ToArray();
        }
        #endregion GetSucursalesHabilitadasPorUsuarioLista

        #region GetSucursalesHabilitadasPorUsuarioDataTable
        public static DataTable GetSucursalesHabilitadasPorUsuarioDataTable()
        {
            return GetSucursalesHabilitadasPorUsuarioDataTable(string.Empty, SucursalesService.Nombre_NombreCol);
        }

        public static DataTable GetSucursalesHabilitadasPorUsuarioDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = SucursalesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                               " exists(select * from " + UsuariosSucursalesService.Nombre_Tabla + " us " + 
                               "         where (us." + UsuariosSucursalesService.SucursalId_NombreCol + " = " + SucursalesService.Nombre_Tabla + "." + SucursalesService.Id_NombreCol + " or " +
                               "                (us." + UsuariosSucursalesService.RegionId_NombreCol + ", us." + UsuariosSucursalesService.SucursalId_NombreCol + ") in ((" + SucursalesService.Nombre_Tabla + "." + SucursalesService.RegionId_NombreCol + ", null))) " +
                               "           and us." + UsuariosSucursalesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                DataTable dt = SucursalesService.GetSucursalesDataTable2(where, orden);
                return dt;
            }
        }
        #endregion GetSucursalesHabilitadasPorUsuarioDataTable

        #region GetSucursalesHabilitadasPorUsuarioInfoCompleta
        public static DataTable GetSucursalesHabilitadasPorUsuarioInfoCompleta()
        {
            return GetSucursalesHabilitadasPorUsuarioInfoCompleta(string.Empty, SucursalesService.Nombre_NombreCol);
        }

        public static DataTable GetSucursalesHabilitadasPorUsuarioInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = SucursalesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' and " +
                               " exists(select * from " + UsuariosSucursalesService.Nombre_Vista + " us " +
                               "         where (us." + UsuariosSucursalesService.SucursalId_NombreCol + " = " + SucursalesService.Nombre_Vista + "." + SucursalesService.Id_NombreCol + " or " +
                               "                (us." + UsuariosSucursalesService.RegionId_NombreCol + ", us." + UsuariosSucursalesService.SucursalId_NombreCol + ") in ((" + SucursalesService.Nombre_Vista + "." + SucursalesService.RegionId_NombreCol + ", null))) " +
                               "           and us." + UsuariosSucursalesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")";
                if (clausulas.Length > 0)
                    where += " and " + clausulas;

                DataTable dt = SucursalesService.GetSucursalesInfoCompleta2(where, orden, true);
                return dt;
            }
        }
        #endregion GetSucursalesHabilitadasPorUsuarioInfoCompleta

        #region GetSucursalesPorRegion
        public static SUCURSALESRow[] GetSucursalesPorRegion(decimal region_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.SUCURSALESCollection.GetAsArray(RegionId_NombreCol + " =  " + region_id, Id_NombreCol);
            }
        }

        public static string GetSucursalesPorRegion(decimal region_id, string order_by)
        {
            string str_sucursales = string.Empty;

            using (SessionService sesion = new SessionService())
            {
                SUCURSALESRow[] sucursales = sesion.Db.SUCURSALESCollection.GetAsArray(RegionId_NombreCol + " =  " + region_id, order_by);

                if (sucursales.Length > 0)
                {
                    foreach (SUCURSALESRow sucursal in SucursalesService.GetSucursalesPorRegion(region_id))
                    {
                        str_sucursales += sucursal.ID + ",";
                    }
                }
                else
                {
                    str_sucursales = Definiciones.Error.Valor.EnteroPositivo.ToString() + ",";
                }
                

                return str_sucursales.Substring(0, str_sucursales.Length - 1);
            }
        }
        #endregion GetSucursalesPorRegion

        #region GetSucursalesDataTable
        /// <summary>
        /// Gets the sucursales data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.SUCURSALESCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetSucursalesDataTable2(string clausulas, string orden)
        {
            return GetSucursalesDataTable2(clausulas, orden, false);
        }

        public static DataTable GetSucursalesDataTable2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetSucursalesDataTable2(clausulas, orden, soloActivos, sesion);
            }
        }

        public static DataTable GetSucursalesDataTable2(string clausulas, string orden, bool soloActivos, SessionService sesion)
        {
            string where;

            //La busqueda debe realizarse solo para la entidad del usuario
            where = EntidadId_NombreCol + " = " + sesion.Entidad.ID;

            if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas != string.Empty) where += " and " + clausulas;

            return sesion.Db.SUCURSALESCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetSucursalesDataTable()
        {
            return SucursalesService.GetSucursalesDataTable2(false);
        }
        
        /// <summary>
        /// Gets the sucursales data table agregando o no un registro inicial "Todas".
        /// </summary>
        /// <param name="incluirRegistroTodas">if set to <c>true</c> [incluir registro todas].</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesDataTable(bool incluirRegistroTodas)
        {
            using (SessionService sesion = new SessionService())
            {
                return this.GetSucursalesDataTable(sesion.Entidad.ID, incluirRegistroTodas);
            }
        }
        public static DataTable GetSucursalesDataTable2(bool incluirRegistroTodas)
        {
            using (SessionService sesion = new SessionService())
            {
                return SucursalesService.GetSucursalesDataTable2(sesion.Entidad.ID, incluirRegistroTodas);
            }
        }

        /// <summary>
        /// Gets the sucursales data table agregando o no un registro inicial "Todas".
        /// </summary>
        /// <param name="entidad_id">The entidad_id.</param>
        /// <param name="incluirRegistroTodas">if set to <c>true</c> [incluir registro todas].</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetSucursalesDataTable(Decimal entidad_id, bool incluirRegistroTodas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.SUCURSALESCollection.GetAsDataTable(EntidadId_NombreCol + " = " + entidad_id, SUCURSALESCollection.NOMBREColumnName);

                if (incluirRegistroTodas)
                {
                    DataRow row = table.NewRow();
                    row[SUCURSALESCollection.IDColumnName] = 0;
                    row[SUCURSALESCollection.ABREVIATURAColumnName] = "Todas";
                    row[SUCURSALESCollection.ESTADOColumnName] = Definiciones.Estado.Activo; //Solo por completar el dato
                    row[SUCURSALESCollection.NOMBREColumnName] = "Todas";
                    row[SUCURSALESCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID; //Solo por completar el dato
                    row[SUCURSALESCollection.PAIS_IDColumnName] = Definiciones.Paises.Paraguay; //Solo por completar el dato
                    row[SUCURSALESCollection.MONEDA_IDColumnName] = Definiciones.Monedas.Guaranies; //Solo por completar el dato
                    row[SUCURSALESCollection.MAYORISTAColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.ES_CASA_MATRIZColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.FC_PROVEEDORES_CC_OBLIGATORIOColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    table.Rows.InsertAt(row, 0);

                    row = table.NewRow();
                    row[SUCURSALESCollection.IDColumnName] = Definiciones.IdNull;
                    row[SUCURSALESCollection.ABREVIATURAColumnName] = "Suc. usuario";
                    row[SUCURSALESCollection.ESTADOColumnName] = Definiciones.Estado.Activo;
                    row[SUCURSALESCollection.NOMBREColumnName] = "Sucursal del usuario";
                    row[SUCURSALESCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID;
                    row[SUCURSALESCollection.PAIS_IDColumnName] = Definiciones.Paises.Paraguay; //Solo por completar el dato
                    row[SUCURSALESCollection.MONEDA_IDColumnName] = Definiciones.Monedas.Guaranies; //Solo por completar el dato
                    row[SUCURSALESCollection.MAYORISTAColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.ES_CASA_MATRIZColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.FC_PROVEEDORES_CC_OBLIGATORIOColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }
        public static DataTable GetSucursalesDataTable2(Decimal entidad_id, bool incluirRegistroTodas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.SUCURSALESCollection.GetAsDataTable(EntidadId_NombreCol + " = " + entidad_id, SUCURSALESCollection.NOMBREColumnName);

                if (incluirRegistroTodas)
                {
                    DataRow row = table.NewRow();
                    row[SUCURSALESCollection.IDColumnName] = 0;
                    row[SUCURSALESCollection.ABREVIATURAColumnName] = "Todas";
                    row[SUCURSALESCollection.ESTADOColumnName] = Definiciones.Estado.Activo; //Solo por completar el dato
                    row[SUCURSALESCollection.NOMBREColumnName] = "Todas";
                    row[SUCURSALESCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID; //Solo por completar el dato
                    row[SUCURSALESCollection.PAIS_IDColumnName] = Definiciones.Paises.Paraguay; //Solo por completar el dato
                    row[SUCURSALESCollection.MONEDA_IDColumnName] = Definiciones.Monedas.Guaranies; //Solo por completar el dato
                    row[SUCURSALESCollection.MAYORISTAColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.ES_CASA_MATRIZColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.FC_PROVEEDORES_CC_OBLIGATORIOColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.PARA_FACTURARColumnName] = Definiciones.SiNo.No; //Solo por completar el dato

                    table.Rows.InsertAt(row, 0);

                    row = table.NewRow();
                    row[SUCURSALESCollection.IDColumnName] = Definiciones.IdNull;
                    row[SUCURSALESCollection.ABREVIATURAColumnName] = "Suc. usuario";
                    row[SUCURSALESCollection.ESTADOColumnName] = Definiciones.Estado.Activo;
                    row[SUCURSALESCollection.NOMBREColumnName] = "Sucursal del usuario";
                    row[SUCURSALESCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID;
                    row[SUCURSALESCollection.PAIS_IDColumnName] = Definiciones.Paises.Paraguay; //Solo por completar el dato
                    row[SUCURSALESCollection.MONEDA_IDColumnName] = Definiciones.Monedas.Guaranies; //Solo por completar el dato
                    row[SUCURSALESCollection.MAYORISTAColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.ES_CASA_MATRIZColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.FC_PROVEEDORES_CC_OBLIGATORIOColumnName] = Definiciones.SiNo.No; //Solo por completar el dato
                    row[SUCURSALESCollection.PARA_FACTURARColumnName] = Definiciones.SiNo.No; //Solo por completar el dato

                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }
        #endregion GetSucursalesDataTable

        #region GetSucursalesPorPais
        /// <summary>
        /// Gets the sucursales por pais.
        /// </summary>
        /// <param name="pais_id">The pais_id.</param>
        /// <returns></returns>
        public static DataTable GetSucursalesPorPais(decimal pais_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.SUCURSALESCollection.GetAsDataTable( SucursalesService.PaisId_NombreCol + " = " + pais_id, SUCURSALESCollection.NOMBREColumnName);
            }
        }
        #endregion GetSucursalesPorPais

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    SUCURSALESRow sucursal = new SUCURSALESRow();
                    String valorAnterior = "";
                    Decimal dAux;

                    if (insertarNuevo)
                    {
                        sucursal.ID = sesion.Db.GetSiguienteSecuencia(Nombre_Secuencia);
                        sucursal.ENTIDAD_ID = sesion.Entidad.ID;
                        sucursal.ES_CASA_MATRIZ = Definiciones.SiNo.No;
                        sucursal.MAYORISTA = Definiciones.SiNo.No;
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        sucursal = sesion.Db.SUCURSALESCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = sucursal.ToString();
                    }

                    sucursal.MONEDA_ID = PaisesService.GetMoneda((decimal)campos[SucursalesService.PaisId_NombreCol]);
                    sucursal.ABREVIATURA = (string)campos[Abreviatura_NombreCol];
                    sucursal.TELEFONO = (string)campos[Telefono_NombreCol];
                    sucursal.DIRECCION = (string)campos[Direccion_NombreCol];
                    sucursal.NOMBRE = (string)campos[Nombre_NombreCol];
                    sucursal.RUC = (string)campos[Ruc_NombreCol];
                    sucursal.ESTADO = (string)campos[Estado_NombreCol];
                    sucursal.FC_PROVEEDORES_CC_OBLIGATORIO = (string)campos[FCProveedoresCCObligatorio_NombreCol];

                    if (campos.Contains(RegionId_NombreCol))
                    {
                        if (!insertarNuevo)
                        {
                            if (!sucursal.IsREGION_IDNull)
                            {
                                if ((decimal)campos[RegionId_NombreCol] != sucursal.REGION_ID)
                                    UsuariosSucursalesService.DesasignarSucursalAUsuariosConRegion(sucursal.ID, sucursal.REGION_ID, sesion);
                            }
                        }

                        sucursal.REGION_ID = (decimal)campos[RegionId_NombreCol];
                    }

                    if (campos.Contains(SucCasaMatriz_NombreCol))
                    {
                        sucursal.SUC_CASA_MATRIZ_ID = (decimal)campos[SucCasaMatriz_NombreCol];
                        sucursal.ES_CASA_MATRIZ = Definiciones.SiNo.No;
                    }
                    else
                    {
                        sucursal.IsSUC_CASA_MATRIZ_IDNull = true;
                        sucursal.ES_CASA_MATRIZ = Definiciones.SiNo.Si;

                        //Validar que no exista otra casa matriz en la misma region
                        string clausulas = SucursalesService.EsCasaMatriz_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
                        if(VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionRepresentaEmpresa) == Definiciones.SiNo.Si)
                            clausulas += " and " + SucursalesService.RegionId_NombreCol + " = " + sucursal.REGION_ID;
                        var rowsCasaMatriz = sesion.db.SUCURSALESCollection.GetAsArray(clausulas, string.Empty);

                        if (rowsCasaMatriz.Length > 0)
                            throw new Exception("Esta sucursal no puede ser casa matriz porque ya lo está siendo " + rowsCasaMatriz[0].NOMBRE + ".");
                    }

                    if (campos.Contains(Mayorista_NombreCol))
                        sucursal.MAYORISTA = (string)campos[Mayorista_NombreCol];

                    if (campos.Contains(CentroCostoId_NombreCol))
                        sucursal.CENTRO_COSTO_ID = (decimal)campos[CentroCostoId_NombreCol];
                    else
                        sucursal.IsCENTRO_COSTO_IDNull = true;

                    if (campos.Contains(MonedaId_NombreCol))
                    {
                        dAux = Interprete.ObtenerDecimal(campos[MonedaId_NombreCol]);
                        if (sucursal.MONEDA_ID != dAux)
                        {
                            if (MonedasService.EstaActivo(dAux)) sucursal.MONEDA_ID = dAux;
                            else throw new System.ArgumentException("La moneda seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }

                    if (sucursal.PAIS_ID != (decimal)campos[PaisId_NombreCol])
                    {
                        if (PaisesService.EstaActivo((decimal)campos[PaisId_NombreCol]))
                            sucursal.PAIS_ID = (decimal)campos[PaisId_NombreCol];
                        else
                            throw new System.ArgumentException("El país seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    if (campos.Contains(SucursalesService.DepartamentoId_NombreCol))
                    {
                        if (sucursal.IsDEPARTAMENTO_IDNull || sucursal.DEPARTAMENTO_ID != (decimal)campos[DepartamentoId_NombreCol])
                        {
                            if (DepartamentosService.EstaActivo((decimal)campos[DepartamentoId_NombreCol]))
                                sucursal.DEPARTAMENTO_ID = (decimal)campos[DepartamentoId_NombreCol];
                            else
                                throw new System.ArgumentException("El departamento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        sucursal.IsDEPARTAMENTO_IDNull = true;
                    }

                    if (campos.Contains(SucursalesService.CiudadId_NombreCol))
                    {
                        if (sucursal.IsCIUDAD_IDNull || sucursal.CIUDAD_ID != (decimal)campos[CiudadId_NombreCol])
                        {
                            if (CiudadesService.EstaActivo((decimal)campos[CiudadId_NombreCol]))
                                sucursal.CIUDAD_ID = (decimal)campos[CiudadId_NombreCol];
                            else
                                throw new System.ArgumentException("La ciudad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        sucursal.IsCIUDAD_IDNull = true;
                    }

                    if (campos.Contains(SucursalesService.BarrioId_NombreCol))
                    {
                        if (sucursal.IsBARRIO_IDNull || sucursal.BARRIO_ID != (decimal)campos[BarrioId_NombreCol])
                        {
                            if (BarriosService.EstaActivo((decimal)campos[BarrioId_NombreCol]))
                                sucursal.BARRIO_ID = (decimal)campos[BarrioId_NombreCol];
                            else
                                throw new System.ArgumentException("El barrio seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        sucursal.IsBARRIO_IDNull = true;
                    }

                    if (campos.Contains(PlanDeCuentas_NombreCol))
                        sucursal.PLAN_DE_CUENTAS = Decimal.Parse((string)campos[PlanDeCuentas_NombreCol]);
                    else
                        sucursal.IsPLAN_DE_CUENTASNull = true;

                    if (campos.Contains(PersonaId_NombreCol))
                        sucursal.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];

                    sucursal.PARA_FACTURAR = campos[ParaFacturar_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.SUCURSALESCollection.Insert(sucursal);
                    else sesion.Db.SUCURSALESCollection.Update(sucursal);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, sucursal.ID, valorAnterior, sucursal.ToString(), sesion);

                    if (campos.Contains(RegionId_NombreCol))
                        UsuariosSucursalesService.AsignarSucursalAUsuariosConRegion(sucursal.ID, sucursal.REGION_ID, sesion);

                    sesion.Db.CommitTransaction();
                    return sucursal.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region GetMonedaSucursal
        public static decimal GetMonedaSucursal(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMonedaSucursal(sucursal_id, sesion);
            }
        }
        public static decimal GetMonedaSucursal(decimal sucursal_id, SessionService sesion)
        {
            SUCURSALESRow row = sesion.Db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
            return row.MONEDA_ID;
        }
        #endregion GetMonedaSucursal

        #region GetNombreSucursal
        public static string GetNombreSucursal(decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                SUCURSALESRow row = sesion.db.SUCURSALESCollection.GetByPrimaryKey(sucursal_id);
                return row.NOMBRE;
            }
        }
        #endregion GetNombreSucursal

        #region GetSucursalCasaMatriz
        public static decimal GetSucursalCasaMatriz(decimal? region_id, decimal? sucursal_id, SessionService sesion)
        {
            string clausulas = SucursalesService.EsCasaMatriz_NombreCol + " = '" + Definiciones.SiNo.Si + "' and " +
                               SucursalesService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (region_id.HasValue)
            {
                clausulas += " and " + SucursalesService.RegionId_NombreCol + " = " + region_id.Value;
            }
            else if (sucursal_id.HasValue)
            {
                clausulas += " and " + SucursalesService.RegionId_NombreCol + " = " +
                             "     (select " + SucursalesService.RegionId_NombreCol +
                             "         from " + SucursalesService.Nombre_Tabla +
                             "        where " + SucursalesService.Id_NombreCol + " = " + sucursal_id.Value +
                             "      )";
            }
            else
            {
                clausulas += " and " + SucursalesService.RegionId_NombreCol + " = " +
                             "     (select " + SucursalesService.RegionId_NombreCol +
                             "         from " + SucursalesService.Nombre_Tabla +
                             "        where " + SucursalesService.Abreviatura_NombreCol + " = '" + VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.AbreviaturaSucursalPrincipal) + "'" +
                             "      )";
            }
            SUCURSALESRow[] rows = sesion.db.SUCURSALESCollection.GetAsArray(clausulas, SucursalesService.Id_NombreCol);
            if (rows.Length > 0)
                return rows[0].ID;
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetSucursalCasaMatriz

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "SUCURSALES"; }
        }
        public static string Nombre_Vista
        {
            get { return "SUCURSALES_INFO_COMPLETA"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "sucursales_sqc"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return SUCURSALESCollection.ABREVIATURAColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return SUCURSALESCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return SUCURSALESCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return SUCURSALESCollection.NOMBREColumnName; }
        }
        public static string Direccion_NombreCol
        {
            get { return SUCURSALESCollection.DIRECCIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return SUCURSALESCollection.ENTIDAD_IDColumnName; }
        }
        public static string FCProveedoresCCObligatorio_NombreCol
        {
            get { return SUCURSALESCollection.FC_PROVEEDORES_CC_OBLIGATORIOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return SUCURSALESCollection.MONEDA_IDColumnName; }
        }
        public static string PaisId_NombreCol
        {
            get { return SUCURSALESCollection.PAIS_IDColumnName; }
        }
        public static string RegionId_NombreCol
        {
            get { return SUCURSALESCollection.REGION_IDColumnName; }
        }
        public static string Ruc_NombreCol
        {
            get { return SUCURSALESCollection.RUCColumnName; }
        }
        public static string Telefono_NombreCol
        {
            get { return SUCURSALESCollection.TELEFONOColumnName; }
        }
        public static string Mayorista_NombreCol
        {
            get { return SUCURSALESCollection.MAYORISTAColumnName; }
        }
        public static string EsCasaMatriz_NombreCol
        {
            get { return SUCURSALESCollection.ES_CASA_MATRIZColumnName; }
        }
        public static string SucCasaMatriz_NombreCol
        {
            get { return SUCURSALESCollection.SUC_CASA_MATRIZ_IDColumnName; }
        }
        public static string PlanDeCuentas_NombreCol
        {
            get { return SUCURSALESCollection.PLAN_DE_CUENTASColumnName; }
        }
        public static string BarrioId_NombreCol
        {
            get { return SUCURSALESCollection.BARRIO_IDColumnName; }
        }
        public static string DepartamentoId_NombreCol
        {
            get { return SUCURSALESCollection.DEPARTAMENTO_IDColumnName; }
        }
        public static string CiudadId_NombreCol
        {
            get { return SUCURSALESCollection.CIUDAD_IDColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return SUCURSALESCollection.ESTADOColumnName; } 
        }
        public static string PersonaId_NombreCol
        { get { return SUCURSALESCollection.PERSONA_IDColumnName; } }

        public static string ParaFacturar_NombreCol
        {
            get { return SUCURSALESCollection.PARA_FACTURARColumnName; }
        }

        public static string VistaPaisNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.PAIS_NOMBREColumnName; }
        }
        public static string VistaRegionAbreviatura_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.REGION_ABREVIATURAColumnName; }
        }
        public static string VistaRegionNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.REGION_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaBarrioNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.BARRIO_NOMBREColumnName; }
        }
        public static string VistaCentroCostoNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.CENTRO_COSTO_NOMBREColumnName; }
        }
        public static string VistaDepartamentoNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.DEPARTAMENTO_NOMBREColumnName; }
        }
        public static string VistaCiudadNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.CIUDAD_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return SUCURSALES_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        
        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static SucursalesService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new SucursalesService(e.RegistroId, sesion);
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
        protected SUCURSALESRow row;
        protected SUCURSALESRow rowSinModificar;
        public class Modelo : SUCURSALESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Abreviatura { get { return row.ABREVIATURA; } set { row.ABREVIATURA = value; } }
        public decimal? BarrioId { get { if (row.IsBARRIO_IDNull) return null; else return row.BARRIO_ID; } set { if (value.HasValue) row.BARRIO_ID = value.Value; else row.IsBARRIO_IDNull = true; } }
        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public decimal? CiudadId { get { if (row.IsCIUDAD_IDNull) return null; else return row.CIUDAD_ID; } set { if (value.HasValue) row.CIUDAD_ID = value.Value; else row.IsCIUDAD_IDNull = true; } }
        public decimal? DepartamentoId { get { if (row.IsDEPARTAMENTO_IDNull) return null; else return row.DEPARTAMENTO_ID; } set { if (value.HasValue) row.DEPARTAMENTO_ID = value.Value; else row.IsDEPARTAMENTO_IDNull = true; } }
        public string Direccion { get { return ClaseCBABase.GetStringHelper(row.DIRECCION); } set { row.DIRECCION = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string EsCasaMatriz { get { return row.ES_CASA_MATRIZ; } set { row.ES_CASA_MATRIZ = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string FCProveedoresCCObligatorio { get { return row.FC_PROVEEDORES_CC_OBLIGATORIO; } set { row.FC_PROVEEDORES_CC_OBLIGATORIO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Mayorista { get { return row.MAYORISTA; } set { row.MAYORISTA = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal PaisId { get { return row.PAIS_ID; } set { row.PAIS_ID = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public decimal? PlanDeCuentasId { get { if (row.IsPLAN_DE_CUENTASNull) return null; else return row.PLAN_DE_CUENTAS; } set { if (value.HasValue) row.PLAN_DE_CUENTAS = value.Value; else row.IsPLAN_DE_CUENTASNull = true; } }
        public decimal? RegionId { get { if (row.IsREGION_IDNull) return null; else return row.REGION_ID; } set { if (value.HasValue) row.REGION_ID = value.Value; else row.IsREGION_IDNull = true; } }
        public string Ruc { get { return ClaseCBABase.GetStringHelper(row.RUC); } set { row.RUC = value; } }
        public decimal? SucursalCasaMatrizId { get { if (row.IsSUC_CASA_MATRIZ_IDNull) return null; else return row.SUC_CASA_MATRIZ_ID; } set { if (value.HasValue) row.SUC_CASA_MATRIZ_ID = value.Value; else row.IsSUC_CASA_MATRIZ_IDNull = true; } }
        public string Telefono { get { return ClaseCBABase.GetStringHelper(row.TELEFONO); } set { row.TELEFONO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private RegionesService _region;
        public RegionesService Region
        {
            get
            {
                if (this._region == null)
                    this._region = new RegionesService(this.RegionId.Value);
                return this._region;
            }
        }

        private CiudadesService _ciudad;
        public CiudadesService Ciudad
        {
            get
            {
                if (this._ciudad == null)
                    this._ciudad = new CiudadesService(this.CiudadId.Value);
                return this._ciudad;
            }
        }

        private MonedasService _moneda;
        public MonedasService Moneda
        {
            get
            {
                if (this._moneda == null)
                    this._moneda = new MonedasService(this.MonedaId);
                return this._moneda;
            }
        }

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
                this.row = sesion.db.SUCURSALESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new SUCURSALESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public SucursalesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public SucursalesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public SucursalesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public SucursalesService(EdiCBA.Sucursal edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = SucursalesService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 
            
            this.Abreviatura = edi.nombre;
            this.Nombre = edi.nombre;
            this.Ruc = edi.ruc;
         
            int contTelefonos = 0;
            if (edi.telefonos != null && edi.telefonos.Length > contTelefonos)
                this.Telefono = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Sucursal()
            {
                entidad = (int)this.EntidadId,
                nombre = this.Nombre,
                ruc = this.Ruc,
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
