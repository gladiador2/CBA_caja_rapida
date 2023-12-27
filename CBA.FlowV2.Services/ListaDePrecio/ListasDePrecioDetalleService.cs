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
using CBA.FlowV2.Services.Common;


namespace CBA.FlowV2.Services.ListaDePrecio
{
    public class ListasDePrecioDetalleService
    {
        #region GetListasDePrecioDetalleInfoCompleta
        public DataTable GetListasDePrecioDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.LISTA_PRECIOS_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        public static DataTable GetListasDePrecioDetalleInfoCompleta2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.LISTA_PRECIOS_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }

        #endregion GetListasDePrecioDetalleInfoCompleta

        #region GetListasDePrecioDetalleDataTable
        /// <summary>
        /// Gets the listas de precio detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetListasDePrecioDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.LISTA_PRECIOS_DETALLESCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetListasDePrecioDetalleDataTable

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool actualizarTodasLasListas, SessionService sesion)
        {
            try
            {
                LISTA_PRECIOS_DETALLESRow[] row_insert;

                string valorAnterior = string.Empty;
                bool insertarNuevo = true;
                

                // paso 2, insertar nuevo registro
                row_insert = new LISTA_PRECIOS_DETALLESRow[1];

                row_insert[0] = new LISTA_PRECIOS_DETALLESRow();
                row_insert[0].ID = sesion.Db.GetSiguienteSecuencia("lista_precios_detalles_sqc");
                row_insert[0].LISTA_PRECIO_ID = decimal.Parse(campos[ListasDePrecioDetalleService.ListaPrecioId_NombreCol].ToString());

                valorAnterior = Definiciones.Log.RegistroNuevo;

                if (row_insert[0].ARTICULO_ID != decimal.Parse(campos[ListasDePrecioDetalleService.ArticuloId_NombreCol].ToString()))
                {
                    row_insert[0].ARTICULO_ID = (decimal)campos[ListasDePrecioDetalleService.ArticuloId_NombreCol];
                    if (!ArticulosService.EstaActivo(row_insert[0].ARTICULO_ID))
                        throw new Exception("El artítulo se encuentra inactivo.");
                }

                row_insert[0].PRECIO = PreciosService_new.RedondarPrecio((decimal)campos[ListasDePrecioDetalleService.Precio_NombreCol], decimal.Parse(campos[ListasDePrecioDetalleService.ListaPrecioId_NombreCol].ToString()));
                row_insert[0].PRECIO_CALCULADO = decimal.Parse(campos[ListasDePrecioDetalleService.Precio_NombreCol].ToString());

                row_insert[0].CANTIDAD_MINIMA = decimal.Parse(campos[ListasDePrecioDetalleService.CantidadMinima_NombreCol].ToString());

                row_insert[0].DESCUENTO_MAXIMO = decimal.Parse(campos[ListasDePrecioDetalleService.DescuentoMaximo_NombreCol].ToString());
                if (row_insert[0].DESCUENTO_MAXIMO < 0 || row_insert[0].DESCUENTO_MAXIMO > 100)
                    throw new Exception("El descuento debe ser entre 0 y 100.");
                if (campos.Contains(ListasDePrecioDetalleService.SucursalId_NombreCol))
                    row_insert[0].SUCURSAL_ID = decimal.Parse(campos[ListasDePrecioDetalleService.SucursalId_NombreCol].ToString());
                else
                    row_insert[0].IsSUCURSAL_IDNull = true;

                row_insert[0].FECHA_INICIO = (DateTime)campos[ListasDePrecioDetalleService.FechaInicio_NombreCol];
                if (campos.Contains(ListasDePrecioDetalleService.FechaFin_NombreCol) && campos[ListasDePrecioDetalleService.FechaFin_NombreCol] != System.DBNull.Value)
                    row_insert[0].FECHA_FIN = (DateTime)campos[ListasDePrecioDetalleService.FechaFin_NombreCol];
                else
                    row_insert[0].IsFECHA_FINNull = true;

                row_insert[0].ESTADO = campos[ListasDePrecioDetalleService.Estado_NombreCol].ToString();
                //insertar registro de precio en la lista de precio Base
                InactivarRegistrosDePrecios(campos, sesion);
                sesion.Db.LISTA_PRECIOS_DETALLESCollection.Insert(row_insert[0]);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row_insert[0].ID, valorAnterior, row_insert[0].ToString(), sesion);

                // insertar registro de precio en las demas listas de precios
                System.Collections.Hashtable camposHijos = new System.Collections.Hashtable();

                if (actualizarTodasLasListas)
                {
                    camposHijos = campos;

                    DataTable dtListas = null;
                    // filtramos las listas de precios que dependen de la lista de precio base indicada para aplicar la actualizacion de precios
                    string clausulas = ListasDePrecioService.Es_Base_NombreCol + " = '" +Definiciones.SiNo.No+ "' " +
                                        " and " + ListasDePrecioService.ListaDePrecioBaseId_NombreCol + " = " + camposHijos[ListasDePrecioDetalleService.ListaPrecioId_NombreCol];
                    dtListas = ListasDePrecioService.GetListasDePrecioDataTable2(clausulas, ListasDePrecioService.Id_NombreCol);

                    #region calcular precio
                    decimal precioRedondeado = 0; // este es el precio final
                    decimal precioCalculado = 0;
                    for (int i = 0; i < dtListas.Rows.Count; i++)
                    {
                        camposHijos.Remove(ListasDePrecioDetalleService.ListaPrecioId_NombreCol);
                        camposHijos.Add(ListasDePrecioDetalleService.ListaPrecioId_NombreCol, decimal.Parse(dtListas.Rows[i][ListasDePrecioService.Id_NombreCol].ToString()));

                        decimal porcentaje = Interprete.EsNullODBNull(dtListas.Rows[i][ListasDePrecioService.Porcentaje_NombreCol]) ? 0 : decimal.Parse(dtListas.Rows[i][ListasDePrecioService.Porcentaje_NombreCol].ToString());
                        decimal monto = decimal.Parse(dtListas.Rows[i][ListasDePrecioService.Monto_NombreCol].ToString());

                        // verificar precios por grupo, si tiene registros usar el porcentaje y monto del mismo.
                        DataTable datos = ArticulosPreciosGruposService.GetMontoPorcentajePorArticuloListaDataTable(decimal.Parse(dtListas.Rows[i][ListasDePrecioService.Id_NombreCol].ToString()), decimal.Parse(camposHijos[ListasDePrecioDetalleService.ArticuloId_NombreCol].ToString()));
                        if (datos.Rows.Count > 0)
                        {
                            porcentaje = decimal.Parse(datos.Rows[0][ArticulosPreciosGruposService.Porcentaje_NombreCol].ToString());
                            monto = decimal.Parse(datos.Rows[0][ArticulosPreciosGruposService.Monto_NombreCol].ToString());
                        }
                        precioCalculado = (decimal)campos[ListasDePrecioDetalleService.Precio_NombreCol] + monto + ((decimal)campos[ListasDePrecioDetalleService.Precio_NombreCol] * porcentaje / 100);

                        precioRedondeado = PreciosService_new.RedondarPrecio(precioCalculado, decimal.Parse(camposHijos[ListasDePrecioDetalleService.ListaPrecioId_NombreCol].ToString()));

                        #region insertar
                        // paso 2, insertar nuevo registro
                        row_insert = new LISTA_PRECIOS_DETALLESRow[1];

                        row_insert[0] = new LISTA_PRECIOS_DETALLESRow();
                        row_insert[0].ID = sesion.Db.GetSiguienteSecuencia("lista_precios_detalles_sqc");
                        row_insert[0].LISTA_PRECIO_ID = decimal.Parse(dtListas.Rows[i][ListasDePrecioService.Id_NombreCol].ToString());

                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        if (row_insert[0].ARTICULO_ID != decimal.Parse(camposHijos[ListasDePrecioDetalleService.ArticuloId_NombreCol].ToString()))
                        {
                            row_insert[0].ARTICULO_ID = decimal.Parse(camposHijos[ListasDePrecioDetalleService.ArticuloId_NombreCol].ToString());
                            if (!ArticulosService.EstaActivo(row_insert[0].ARTICULO_ID))
                                throw new Exception("El artítulo se encuentra inactivo.");
                        }

                        row_insert[0].PRECIO = precioRedondeado;
                        row_insert[0].PRECIO_CALCULADO = precioCalculado;

                        row_insert[0].CANTIDAD_MINIMA = decimal.Parse(camposHijos[ListasDePrecioDetalleService.CantidadMinima_NombreCol].ToString());

                        row_insert[0].DESCUENTO_MAXIMO = decimal.Parse(camposHijos[ListasDePrecioDetalleService.DescuentoMaximo_NombreCol].ToString());
                        if (row_insert[0].DESCUENTO_MAXIMO < 0 || row_insert[0].DESCUENTO_MAXIMO > 100)
                            throw new Exception("El descuento debe ser entre 0 y 100.");
                        if (camposHijos.Contains(ListasDePrecioDetalleService.SucursalId_NombreCol))
                            row_insert[0].SUCURSAL_ID = decimal.Parse(camposHijos[ListasDePrecioDetalleService.SucursalId_NombreCol].ToString());
                        else
                            row_insert[0].IsSUCURSAL_IDNull = true;

                        row_insert[0].FECHA_INICIO = (DateTime)camposHijos[ListasDePrecioDetalleService.FechaInicio_NombreCol];
                        if (camposHijos.Contains(ListasDePrecioDetalleService.FechaFin_NombreCol) && camposHijos[ListasDePrecioDetalleService.FechaFin_NombreCol] != System.DBNull.Value)
                            row_insert[0].FECHA_FIN = (DateTime)camposHijos[ListasDePrecioDetalleService.FechaFin_NombreCol];
                        else
                            row_insert[0].IsFECHA_FINNull = true;
                        row_insert[0].ESTADO = Definiciones.Estado.Activo;

                        InactivarRegistrosDePrecios(camposHijos, sesion);

                        //insertar registro de precio en la lista de precio Base

                        sesion.Db.LISTA_PRECIOS_DETALLESCollection.Insert(row_insert[0]);

                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row_insert[0].ID, valorAnterior, row_insert[0].ToString(), sesion);
                        #endregion insertar
                    }
                    #endregion calcular precio
                }
            }
            catch (Exception exp)
            {
                sesion.RollbackTransaction();
                throw exp;

            }
            catch
            {
                sesion.RollbackTransaction();
                throw;
            }
        }
        #endregion Guardar

        #region InactivarRegistrosDePrecios
        public void InactivarRegistrosDePrecios(System.Collections.Hashtable campos, SessionService sesion)
        {
            #region inactivar registros de precio
            LISTA_PRECIOS_DETALLESRow[] rows_update;
            string clausulas = ListasDePrecioDetalleService.ArticuloId_NombreCol + " = " + campos[ListasDePrecioDetalleService.ArticuloId_NombreCol];
            clausulas += "\n and " + ListasDePrecioDetalleService.ListaPrecioId_NombreCol + " = " + campos[ListasDePrecioDetalleService.ListaPrecioId_NombreCol];
            clausulas += "\n and " + ListasDePrecioDetalleService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            if (campos.Contains(ListasDePrecioDetalleService.SucursalId_NombreCol))
                clausulas += "\n and " + ListasDePrecioDetalleService.SucursalId_NombreCol + " = " + campos[ListasDePrecioDetalleService.SucursalId_NombreCol];
            else // si no se indica sucursal, solamente inactivar los registros sin sucursal asignada
                clausulas += "\n and " + ListasDePrecioDetalleService.SucursalId_NombreCol + " is null ";

            if (campos.Contains(ListasDePrecioDetalleService.FechaFin_NombreCol))
            {
                if (!Interprete.EsNullODBNull(campos[ListasDePrecioDetalleService.FechaFin_NombreCol]))
                {
                    clausulas += "\n and trunc(" + ListasDePrecioDetalleService.FechaInicio_NombreCol + ") = '" + ((DateTime)campos[ListasDePrecioDetalleService.FechaInicio_NombreCol]).ToString("dd-MM-yyyy") + "'";
                    clausulas += "\n and trunc(" + ListasDePrecioDetalleService.FechaFin_NombreCol + ") = '" + ((DateTime)campos[ListasDePrecioDetalleService.FechaFin_NombreCol]).ToString("dd-MM-yyyy") + "'";
                }
                else
                    clausulas += "\n and " + ListasDePrecioDetalleService.FechaFin_NombreCol + " is null ";
            }
            else
                clausulas += "\n and " + ListasDePrecioDetalleService.FechaFin_NombreCol + " is null ";

            rows_update = sesion.Db.LISTA_PRECIOS_DETALLESCollection.GetAsArray(clausulas, string.Empty);

            for (int a = 0; a < rows_update.Length; a++)
            {
                string valorAnterior = rows_update[0].ToString();
                rows_update[a].ESTADO = Definiciones.Estado.Inactivo;

                sesion.Db.LISTA_PRECIOS_DETALLESCollection.Update(rows_update[a]);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, rows_update[0].ID, valorAnterior, rows_update[0].ToString(), sesion);
            }
            #endregion inactivar registros de precio
        }
        #endregion InactivarRegistrosDePrecios

        #region Borrarr
        /// <summary>
        /// Borrars the specified lista_de_precio_id.
        /// </summary>
        /// <param name="lista_de_precio_id">The lista_de_precio_id.</param>
        /// <param name="articulo_id">The articulo_id.</param>
        public void Borrar(decimal lista_de_precio_id, decimal articulo_id, decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string clausulas = ListasDePrecioDetalleService.ListaPrecioId_NombreCol + " = " + lista_de_precio_id + " and " +
                                       ListasDePrecioDetalleService.ArticuloId_NombreCol + " = " + articulo_id + " and " +
                                       ListasDePrecioDetalleService.SucursalId_NombreCol + " = " + sucursal_id;

                    LISTA_PRECIOS_DETALLESRow[] row = sesion.Db.LISTA_PRECIOS_DETALLESCollection.GetAsArray(clausulas, string.Empty);

                    if (row.Length > 0)
                    {
                        sesion.Db.LISTA_PRECIOS_DETALLESCollection.Delete(row[0]);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, row[0].ID, row[0].ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "LISTA_PRECIOS_DETALLES"; }
        }
        public static string Nombre_Vista
        {
            get { return "lista_precios_det_info_compl"; }
        }
        public static string Id_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.ARTICULO_IDColumnName; }
        }
        public static string CantidadMinima_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.CANTIDAD_MINIMAColumnName; }
        }
        public static string DescuentoMaximo_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.DESCUENTO_MAXIMOColumnName; }
        }
        public static string ListaPrecioId_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.LISTA_PRECIO_IDColumnName; }
        }
        public static string Precio_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.PRECIOColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.FECHA_INICIOColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.FECHA_FINColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.SUCURSAL_IDColumnName; }
        }
        public static string PrecioCalculado_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.PRECIO_CALCULADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return LISTA_PRECIOS_DETALLESCollection.ESTADOColumnName; }
        }
        public static string VistaArticuloNombre_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.ARTICULO_NOMBREColumnName; }
        }
        public static string VistaListaPrecioAbreviatura_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.LISTA_PRECIOS_ABREVIATURAColumnName; }
        }
        public static string VistaListaPrecioMonedaId_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.LISTA_PRECIOS_MONEDA_IDColumnName; }
        }
        public static string VistaListaPrecioMonedaNombre_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.LISTA_PRECIOS_MONEDA_NOMBREColumnName; }
        }
        public static string VistaListaPrecioNombre_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.LISTA_PRECIOS_NOMBREColumnName; }
        }
        public static string VistaListaCantidadRestante_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.CANTIDAD_RESTANTEColumnName; }
        }
        public static string VistaArticuloFamiliaDescripcion_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.FAMILIA_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloGrupoDescripcion_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.GRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloSubGrupoDescripcion_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.SUBGRUPO_DESCRIPCIONColumnName; }
        }
        public static string VistaArticuloCodigoEmpresa_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.CODIGO_EMPRESAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return LISTA_PRECIOS_DET_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }

        #endregion Accessors
    }
}
