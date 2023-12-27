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
    public class UsoDeInsumosDetalleService : ClaseCBA<UsoDeInsumosDetalleService>
    {
        #region GetUsoDeInsumosDetalleDataTable
        /// <summary>
        /// Gets the uso de insumos detalle data table.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetUsoDeInsumosDetalleDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.USO_DE_INSUMOS_DETALLECollection.GetAsDataTable(clausula, orden);
            }
        }
        
        #endregion GetUsoDeInsumosDetalleDataTable

        #region GetUsoDeInsumosDetalleInfoCompleta
        /// <summary>
        /// Gets the uso de insumos detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetUsoDeInsumosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsoDeInsumosDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetUsoDeInsumosDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.USO_DE_INSUMOS_DET_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetUsoDeInsumosDetalleInfoCompleta

        #region Propiedades
        protected USO_DE_INSUMOS_DETALLERow row;
        protected USO_DE_INSUMOS_DETALLERow rowSinModificar;
        public class Modelo : USO_DE_INSUMOS_DETALLECollection_Base { public Modelo() : base(null) { } }
        public class ModeloVista : USO_DE_INSUMOS_DET_INFO_COMPLCollection_Base { public ModeloVista() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.USO_DE_INSUMOS_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new USO_DE_INSUMOS_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        
        private void Inicializar(USO_DE_INSUMOS_DETALLERow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public UsoDeInsumosDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public UsoDeInsumosDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public UsoDeInsumosDetalleService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        
        private UsoDeInsumosDetalleService(USO_DE_INSUMOS_DETALLERow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    //El articulo debe tener ingreso aprobado
                    decimal articuloId = ArticulosLotesService.GetArticuloId2((decimal)campos[UsoDeInsumosDetalleService.Modelo.ARTICULO_LOTE_IDColumnName], sesion);
                    if (!ArticulosService.IngresoAprobado(articuloId))
                        throw new System.ArgumentException("El ingreso del artículo aún no está aprobado.");

                    USO_DE_INSUMOS_DETALLERow row = new USO_DE_INSUMOS_DETALLERow();
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("uso_de_insumos_detalle_sqc");
                        row.USO_DE_INSUMO_ID = (decimal)campos[UsoDeInsumosDetalleService.Modelo.USO_DE_INSUMO_IDColumnName];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.USO_DE_INSUMOS_DETALLECollection.GetRow(UsoDeInsumosDetalleService.Modelo.IDColumnName + " = " + campos[UsoDeInsumosDetalleService.Modelo.IDColumnName]);
                        valorAnterior = row.ToString();
                    }

                    var dtUsoDeInsumos = UsoDeInsumosService.GetUsoDeInsumosDataTable(UsoDeInsumosService.Id_NombreCol + " = " + row.USO_DE_INSUMO_ID, string.Empty);
                    
                    row.ARTICULO_LOTE_ID = (decimal)campos[UsoDeInsumosDetalleService.Modelo.ARTICULO_LOTE_IDColumnName];
                    
                    //Cantidades
                    row.UNIDAD_ORIGEN_ID = ArticulosService.GetArticuloRowPorID(articuloId,sesion).UNIDAD_MEDIDA_ID;
                    row.UNIDAD_DESTINO_ID = (string)campos["unidad_principal_id"];
                    row.FACTOR_DE_CONVERSION = (new ArticulosConversionesService()).GetFactorConversion(articuloId, (string)campos[UsoDeInsumosDetalleService.Modelo.UNIDAD_DESTINO_IDColumnName], (decimal)dtUsoDeInsumos.Rows[0][UsoDeInsumosService.SucursalId_NombreCol]);
                    row.CANTIDAD_POR_CAJA_ORIGEN = ArticulosService.GetArticuloRowPorID(articuloId, sesion).CANTIDAD_POR_CAJA;
                    row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_DE_CONVERSION;
                    row.CANTIDAD_UNIDAD_DESTINO = (decimal)campos[UsoDeInsumosDetalleService.Modelo.CANTIDAD_UNIDAD_DESTINOColumnName];
                    row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNIDAD_DESTINO / row.FACTOR_DE_CONVERSION;
                    row.CANTIDAD_UNITARIA_TOTAL_DEST = (row.CANTIDAD_EMBALADA * row.CANTIDAD_POR_CAJA_DESTINO) + row.CANTIDAD_UNIDAD_DESTINO;
                    row.CANTIDAD_UNITARIA_TOTAL_ORIGEN = row.CANTIDAD_UNITARIA_TOTAL_DEST / row.FACTOR_DE_CONVERSION;
                    row.VALOR_MEDICION = (decimal)campos[UsoDeInsumosDetalleService.Modelo.VALOR_MEDICIONColumnName];
                  

                    //TODO Uri:
                    #region código a borrar cuando se eliminen las columnas de costo
                    var costoPPP = CostosService.GetCosto(articuloId, (decimal)dtUsoDeInsumos.Rows[0][UsoDeInsumosService.DepositoId_NombreCol], (DateTime)dtUsoDeInsumos.Rows[0][UsoDeInsumosService.Fecha_NombreCol], sesion);
                    
                    row.IsCOSTO_IDNull = true;
                    row.COSTO_MONEDA_COTIZACION = costoPPP.cotizacion;
                    row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                    if (row.FACTOR_DE_CONVERSION != 0)
                        row.COSTO_TOTAL = (costoPPP.costo * row.CANTIDAD_UNITARIA_TOTAL_DEST) / row.FACTOR_DE_CONVERSION;
                    else
                        row.COSTO_TOTAL = (costoPPP.costo * row.CANTIDAD_UNITARIA_TOTAL_DEST);
                    #endregion código a borrar cuando se eliminen las columnas de costo
                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.CASO_ASOCIADO_IDColumnName))
                        row.CASO_ASOCIADO_ID = (decimal)campos[UsoDeInsumosDetalleService.Modelo.CASO_ASOCIADO_IDColumnName];
                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.OBSERVACIONColumnName))
                        row.OBSERVACION = (string)campos[UsoDeInsumosDetalleService.Modelo.OBSERVACIONColumnName];

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.ACTIVO_IDColumnName))
                        row.ACTIVO_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.ACTIVO_IDColumnName].ToString());
                    else
                        row.IsACTIVO_IDNull = true;

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.SUCURSAL_DESTINO_IDColumnName))
                        row.SUCURSAL_DESTINO_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.SUCURSAL_DESTINO_IDColumnName].ToString());
                    else
                        row.IsSUCURSAL_DESTINO_IDNull = true;

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.PROVEEDOR_ASIGNADO_IDColumnName))
                        row.PROVEEDOR_ASIGNADO_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.PROVEEDOR_ASIGNADO_IDColumnName].ToString());
                    else
                        row.IsPROVEEDOR_ASIGNADO_IDNull = true;

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.ORDENES_SERVICIO_DETALLES_IDColumnName))
                        row.ORDENES_SERVICIO_DETALLES_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.ORDENES_SERVICIO_DETALLES_IDColumnName].ToString());
                    else
                        row.IsORDENES_SERVICIO_DETALLES_IDNull = true;

                    if (insertarNuevo) sesion.Db.USO_DE_INSUMOS_DETALLECollection.Insert(row);
                    else sesion.Db.USO_DE_INSUMOS_DETALLECollection.Update(row);



                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();
            throw new NotImplementedException("Metodo aun no implementado.");
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region Modificar Detalle
        /// <summary>
        /// Actualizar cantidad
        /// </summary>
        /// <param name="stock_detalle_id">ID del detalle</param>
        /// <param name="cantidad">Cantidad nueva</param>
        public static void ModificarDetalle(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    USO_DE_INSUMOS_DETALLERow row = new USO_DE_INSUMOS_DETALLERow();
                    decimal detalleId = (decimal)campos[UsoDeInsumosDetalleService.Modelo.IDColumnName];
                    row = sesion.Db.USO_DE_INSUMOS_DETALLECollection.GetByPrimaryKey(detalleId);
                    string valorAnterior = row.ToString();
                    decimal articuloId = Definiciones.Error.Valor.EnteroPositivo;
                    var dtUsoDeInsumos = UsoDeInsumosService.GetUsoDeInsumosDataTable(UsoDeInsumosService.Id_NombreCol + " = " + row.USO_DE_INSUMO_ID, string.Empty);

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.CANTIDAD_UNITARIA_TOTAL_DESTColumnName))
                    {
                        row.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)campos[UsoDeInsumosDetalleService.Modelo.CANTIDAD_UNITARIA_TOTAL_DESTColumnName]; ;
                        row.CANTIDAD_UNITARIA_TOTAL_ORIGEN = row.CANTIDAD_UNITARIA_TOTAL_DEST / row.FACTOR_DE_CONVERSION;
                    }

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.CANTIDAD_POR_CAJA_DESTINOColumnName))
                    {
                        articuloId = (new ArticulosLotesService()).GetArticuloId((decimal)campos[UsoDeInsumosDetalleService.Modelo.ARTICULO_LOTE_IDColumnName]);
                        row.CANTIDAD_POR_CAJA_ORIGEN = ArticulosService.GetArticuloRowPorID(articuloId).CANTIDAD_POR_CAJA;
                        row.CANTIDAD_POR_CAJA_DESTINO = row.CANTIDAD_POR_CAJA_ORIGEN * row.FACTOR_DE_CONVERSION;
                    }

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.CANTIDAD_UNIDAD_DESTINOColumnName))
                    {
                        row.CANTIDAD_UNIDAD_DESTINO = (decimal)campos[UsoDeInsumosDetalleService.Modelo.CANTIDAD_UNIDAD_DESTINOColumnName];
                        row.CANTIDAD_UNIDAD_ORIGEN = row.CANTIDAD_UNIDAD_DESTINO / row.FACTOR_DE_CONVERSION;
                    }
                    articuloId = ArticulosLotesService.GetArticuloId2((decimal)campos[UsoDeInsumosDetalleService.Modelo.ARTICULO_LOTE_IDColumnName], sesion);

                    //TODO Uri:
                    #region código a borrar cuando se eliminen las columnas de costo
                    var costoPPP = CostosService.GetCosto(articuloId, (decimal)dtUsoDeInsumos.Rows[0][UsoDeInsumosService.DepositoId_NombreCol], (DateTime)dtUsoDeInsumos.Rows[0][UsoDeInsumosService.Fecha_NombreCol], sesion);

                    row.IsCOSTO_IDNull = true;
                    row.COSTO_MONEDA_COTIZACION = costoPPP.cotizacion;
                    row.COSTO_MONEDA_ID = costoPPP.moneda_id;
                    row.COSTO_TOTAL = costoPPP.costo * row.CANTIDAD_UNITARIA_TOTAL_DEST;
                    #endregion código a borrar cuando se eliminen las columnas de costo

                    if (row.CANTIDAD_UNITARIA_TOTAL_DEST < 0)
                        row.COSTO_TOTAL = costoPPP.costo * row.FACTOR_DE_CONVERSION * (row.CANTIDAD_UNITARIA_TOTAL_DEST * -1);
                    else
                        row.COSTO_TOTAL = costoPPP.costo * row.FACTOR_DE_CONVERSION * row.CANTIDAD_UNITARIA_TOTAL_DEST;
                    
                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.VALOR_MEDICIONColumnName))
                        row.VALOR_MEDICION = (decimal)campos[UsoDeInsumosDetalleService.Modelo.VALOR_MEDICIONColumnName];

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.SUCURSAL_DESTINO_IDColumnName))
                        row.SUCURSAL_DESTINO_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.SUCURSAL_DESTINO_IDColumnName].ToString());

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.ACTIVO_IDColumnName))
                        row.ACTIVO_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.ACTIVO_IDColumnName].ToString());

                    if (campos.Contains(UsoDeInsumosDetalleService.Modelo.PROVEEDOR_ASIGNADO_IDColumnName))
                        row.PROVEEDOR_ASIGNADO_ID = decimal.Parse(campos[UsoDeInsumosDetalleService.Modelo.PROVEEDOR_ASIGNADO_IDColumnName].ToString());

                    sesion.Db.USO_DE_INSUMOS_DETALLECollection.Update(row);
                    string valorNuevo = row.ToString();
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        #endregion Modificar Detalle

        #region Borrar
        /// <summary>
        /// Borrars the specified detalles_id.
        /// </summary>
        /// <param name="detalles_id">The detalles_id.</param>
        public static void Borrar(decimal detalles_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    USO_DE_INSUMOS_DETALLERow row = new USO_DE_INSUMOS_DETALLERow();
                    row = sesion.Db.USO_DE_INSUMOS_DETALLECollection.GetByPrimaryKey(detalles_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.USO_DE_INSUMOS_DETALLECollection.DeleteByPrimaryKey(detalles_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region Buscar
        protected override UsoDeInsumosDetalleService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.ACTIVO_IDColumnName:
                        case Modelo.ARTICULO_LOTE_IDColumnName:
                        case Modelo.COSTO_IDColumnName:
                        case Modelo.COSTO_MONEDA_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.PROVEEDOR_ASIGNADO_IDColumnName:
                        case Modelo.SUCURSAL_DESTINO_IDColumnName:
                        case Modelo.USO_DE_INSUMO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.CANTIDAD_EMBALADAColumnName:
                        case Modelo.CANTIDAD_POR_CAJA_DESTINOColumnName:
                        case Modelo.CANTIDAD_POR_CAJA_ORIGENColumnName:
                        case Modelo.CANTIDAD_UNIDAD_DESTINOColumnName:
                        case Modelo.CANTIDAD_UNIDAD_ORIGENColumnName:
                        case Modelo.CANTIDAD_UNITARIA_TOTAL_DESTColumnName:
                        case Modelo.CANTIDAD_UNITARIA_TOTAL_ORIGENColumnName:
                        case Modelo.COSTO_TOTALColumnName:
                        case Modelo.FACTOR_DE_CONVERSIONColumnName:
                        case Modelo.VALOR_MEDICIONColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.OBSERVACIONColumnName:
                        case Modelo.UNIDAD_DESTINO_IDColumnName:
                        case Modelo.UNIDAD_ORIGEN_IDColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            USO_DE_INSUMOS_DETALLERow[] rows = sesion.db.USO_DE_INSUMOS_DETALLECollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            UsoDeInsumosDetalleService[] uid = new UsoDeInsumosDetalleService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                uid[i] = new UsoDeInsumosDetalleService(rows[i]);
            return uid;
        }
        #endregion Buscar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
        }
        #endregion ResetearPropiedadesExtendidas

        #region Accessors
        public static string Nombre_Tabla = "USO_DE_INSUMOS_DETALLE";
        public static string Nombre_Vista = "USO_DE_INSUMOS_DET_INFO_COMPL";

        public static string Id_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.IDColumnName; }
        }
        public static string UsoInsumoId_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.USO_DE_INSUMO_IDColumnName; }
        }
        public static string ArticuloLoteId_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.ARTICULO_LOTE_IDColumnName; }
        }
        public static string CantidadUnidOrigen_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.CANTIDAD_UNIDAD_ORIGENColumnName; }
        }
        public static string CantidadUnidDestino_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.CANTIDAD_UNIDAD_DESTINOColumnName; }
        }
        public static string CostoTotal_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.COSTO_TOTALColumnName; }
        }
        public static string VistaArticuloId_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_INFO_COMPLCollection.ARTICULO_IDColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_INFO_COMPLCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloNombre_NombreCol
        {
            get { return USO_DE_INSUMOS_DET_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.OBSERVACIONColumnName; }
        }
        public static string Orden_Servicio_Detalles_Id_NombreCol
        {
            get { return USO_DE_INSUMOS_DETALLECollection.ORDENES_SERVICIO_DETALLES_IDColumnName; }
        }

        #endregion Accessors
    }
}




