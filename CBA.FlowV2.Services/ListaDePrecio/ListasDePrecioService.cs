using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections;
using CBA.FlowV2.Services.Herramientas;


namespace CBA.FlowV2.Services.ListaDePrecio
{
    public class ListasDePrecioService
    {
        #region GetListasDePrecioInfoCompleta
        /// <summary>
        /// Gets the listas de precio data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetListasDePrecioInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ListasDePrecioService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return GetListasDePrecioInfoCompleta(where, orden, sesion);
            }
        }

        public DataTable GetListasDePrecioInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = ListasDePrecioService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;

            return sesion.Db.LISTA_PRECIOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
        }
        #endregion GetListasDePrecioInfoCompleta

        #region GetListasDePrecioMonedaId
        public static decimal GetListasDePrecioMonedaId(decimal lista_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LISTA_PRECIOSRow row = sesion.Db.LISTA_PRECIOSCollection.GetByPrimaryKey(lista_id);

                return row.MONEDA_ID;
            }
        }
        #endregion GetListasDePrecioMonedaId

        #region GetListasDePrecioNombre
        public static string GetListasDePrecioNombre(decimal lista_id)
        {
            using (SessionService sesion = new SessionService())
            {
                LISTA_PRECIOSRow row = sesion.Db.LISTA_PRECIOSCollection.GetByPrimaryKey(lista_id);

                return row.NOMBRE;
            }
        }
        #endregion GetListasDePrecioNombre

        #region AplicarRedondeo
        public static bool aplicarRedondeo(decimal idListaPrecio)
        {           
            using (SessionService sesion = new SessionService())
            {
                LISTA_PRECIOSRow lista = sesion.Db.LISTA_PRECIOSCollection.GetByPrimaryKey(idListaPrecio);
                return lista.APLICAR_REDONDEO == Definiciones.SiNo.Si;
            }
        }
        #endregion AplicarRedondeo

        #region GetListasDePrecioDataTable
        /// <summary>
        /// Gets the listas de precio data table2.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetListasDePrecioDataTable2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ListasDePrecioService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.LISTA_PRECIOSCollection.GetAsDataTable(where, orden);
            }
        }

        /// <summary>
        /// Gets the listas de precio data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetListasDePrecioDataTable(string clausulas, string orden)
        {
            return ListasDePrecioService.GetListasDePrecioDataTable2(clausulas, orden);
        }

        /// <summary>
        /// Gets the listas de precio data table.
        /// </summary>
        /// <param name="lista_precio_id">The lista_precio_id.</param>
        /// <returns></returns>
        public DataTable GetListasDePrecioDataTable(string lista_precio_id)
        {
            return this.GetListasDePrecioDataTable(ListasDePrecioService.Id_NombreCol + " = " + lista_precio_id, ListasDePrecioService.Nombre_NombreCol);
        }
        #endregion GetListasDePrecioDataTable

        #region GetListasDePrecioBaseDataTable
        public static DataTable GetListasDePrecioBaseDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LISTA_PRECIOSCollection.GetAsDataTable(ListasDePrecioService.Es_Base_NombreCol + " = '" + Definiciones.SiNo.Si + "'", ListasDePrecioService.Nombre_NombreCol);
            }
        }
        #endregion GetListasDePrecioBaseDataTable
        
        #region CumpleConCantMinimaDescMaximo
        /// <summary>
        /// Cumples the con cant minima desc maximo.
        /// </summary>
        /// <param name="listaPrecioId">The lista precio identifier.</param>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="cantidadActual">The cantidad actual.</param>
        /// <param name="descuentoActual">The descuento actual.</param>
        /// <returns></returns>
        public static bool CumpleConCantMinimaDescMaximo(decimal listaPrecioId, decimal articulo_id, decimal cantidadActual, decimal descuentoActual)
        {
            bool exito = false;
            string clausulas = string.Empty;

            using (SessionService sesion = new SessionService())
            {
                clausulas = ListasDePrecioDetalleService.ListaPrecioId_NombreCol + " = " + listaPrecioId.ToString() + " and "
                           + ListasDePrecioDetalleService.ArticuloId_NombreCol + " = " + articulo_id.ToString();

                DataTable dtDetalleListaPrecio = sesion.db.LISTA_PRECIOS_DETALLESCollection.GetAsDataTable(clausulas, string.Empty);

                if (dtDetalleListaPrecio.Rows.Count == 1)
                {
                    if (((decimal)dtDetalleListaPrecio.Rows[0][ListasDePrecioDetalleService.CantidadMinima_NombreCol] <= cantidadActual) &&
                        ((decimal)dtDetalleListaPrecio.Rows[0][ListasDePrecioDetalleService.DescuentoMaximo_NombreCol] >= descuentoActual))
                    {
                        exito = true;
                    }
                }
            }

            return exito;
        }
        #endregion CumpleConCantMinimaDescMaximo

        #region Guardar
        public bool Guardar(bool esNuevo, Hashtable campos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    sesion.Db.BeginTransaction();
                    string valorAnterior = string.Empty;
                    LISTA_PRECIOSRow row = new LISTA_PRECIOSRow();

                    if (esNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("lista_precios_sqc");
                        row.FECHA_CREACION = DateTime.Now;
                    }
                    else
                    {
                        decimal id = decimal.Parse(campos[ListasDePrecioService.Id_NombreCol].ToString());
                        row = sesion.Db.LISTA_PRECIOSCollection.GetByPrimaryKey(id);
                    }


                    if (campos.Contains(FechaInicio_NombreCol))
                        row.FECHA_INICIO = (DateTime)campos[FechaInicio_NombreCol];
                    else
                        row.IsFECHA_INICIONull = true;

                    if (campos.Contains(FechaFin_NombreCol))
                        row.FECHA_FIN = (DateTime)campos[FechaFin_NombreCol];
                    else
                        row.IsFECHA_FINNull = true;

                    if (campos.Contains(RegionId_NombreCol))
                        row.REGION_ID = (decimal)campos[RegionId_NombreCol];
                    else
                        row.IsREGION_IDNull = true;

                    if (campos.Contains(SucursalId_NombreCol))
                    {
                        row.SUCURSAL_ID = (decimal)campos[SucursalId_NombreCol];
                        row.REGION_ID = new SucursalesService(row.SUCURSAL_ID, sesion).RegionId.Value;
                    }
                    else
                    {
                        row.IsSUCURSAL_IDNull = true;
                    }                   

                    row.ES_BASE = campos[ListasDePrecioService.Es_Base_NombreCol].ToString();
                    row.APLICAR_REDONDEO = campos[ListasDePrecioService.AplicarRedondeo_NombreCol].ToString();
                  
                    if (campos[ListasDePrecioService.Es_Base_NombreCol].ToString().Equals(Definiciones.SiNo.Si))
                    {
                        row.MONTO = (decimal)0;
                        row.PORCENTAJE = (decimal)0;
                        row.IsLISTA_PRECIO_BASE_IDNull = true;
                    }
                    else
                    {
                        row.MONTO = (decimal)campos[ListasDePrecioService.Monto_NombreCol];
                        row.PORCENTAJE = (decimal)campos[ListasDePrecioService.Porcentaje_NombreCol];
                        if (campos.Contains(ListaDePrecioBaseId_NombreCol))
                            row.LISTA_PRECIO_BASE_ID = (decimal)campos[ListaDePrecioBaseId_NombreCol];
                        else
                            throw new Exception("Debe indicar la lista de precio base");
                    }
                    //campos obligatorios venidos desde el CRUD
                    row.NOMBRE = campos[ListasDePrecioService.Nombre_NombreCol].ToString();
                    row.ABREVIATURA = campos[ListasDePrecioService.Abreviatura_NombreCol].ToString();
                    row.ESTADO = campos[ListasDePrecioService.Estado_NombreCol].ToString();
                    row.MONEDA_ID = decimal.Parse(campos[ListasDePrecioService.MonedaId_NombreCol].ToString());

                    //campos obligatorios desde el service
                    row.ENTIDAD_ID = sesion.Entidad.ID;
                    row.FECHA_MODIFICACION = DateTime.Now;
                    row.USUARIO_CREACION_ID = sesion.Usuario.ID;

                    //se guardan los rows
                    if (esNuevo) sesion.Db.LISTA_PRECIOSCollection.Insert(row);
                    else sesion.Db.LISTA_PRECIOSCollection.Update(row);

                    //se guardan los cambios de log
                    LogCambiosService.LogDeRegistro(ListasDePrecioService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return true;
                }
            }
            catch (Exception e)
            {
                
                return false;
            }
        }
        #endregion Guardar

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "LISTA_PRECIOS"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return LISTA_PRECIOSCollection.ABREVIATURAColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return LISTA_PRECIOSCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return LISTA_PRECIOSCollection.ESTADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return LISTA_PRECIOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return LISTA_PRECIOSCollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return LISTA_PRECIOSCollection.FECHA_INICIOColumnName; }
        }
        public static string FechaModificacion_NombreCol
        {
            get { return LISTA_PRECIOSCollection.FECHA_MODIFICACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return LISTA_PRECIOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return LISTA_PRECIOSCollection.MONEDA_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return LISTA_PRECIOSCollection.NOMBREColumnName; }
        }
        public static string RegionId_NombreCol
        {
            get { return LISTA_PRECIOSCollection.REGION_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return LISTA_PRECIOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string UsuarioCreadorId_NombreCol
        {
            get { return LISTA_PRECIOSCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return LISTA_PRECIOSCollection.MONTOColumnName; }
        }
        public static string Porcentaje_NombreCol
        {
            get { return LISTA_PRECIOSCollection.PORCENTAJEColumnName; }
        }
        public static string ListaDePrecioBaseId_NombreCol
        {
            get { return LISTA_PRECIOSCollection.LISTA_PRECIO_BASE_IDColumnName; }
        }
        public static string Es_Base_NombreCol
        {
            get { return LISTA_PRECIOSCollection.ES_BASEColumnName; }
        }

        public static string AplicarRedondeo_NombreCol
        {
            get { return LISTA_PRECIOSCollection.APLICAR_REDONDEOColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "LISTA_PRECIOS_INFO_COMPLETA"; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.USUARIO_NOMBREColumnName; }
        }
        public static string VistaRegionNombre_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.REGION_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaUsuario_NombreCol
        {
            get { return LISTA_PRECIOS_INFO_COMPLETACollection.USUARIOColumnName; }
        }
        #endregion Vista

        #endregion Accessors

    }
}
