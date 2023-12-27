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
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;
using System.Net;
using System.IO;

#endregion Using

namespace CBA.FlowV2.Services.Stock
{
    public class StockService
    {
        #region Clase ColumnasStockCompletoAFecha
        public abstract class ColumnasStockCompletoAFecha
        {
            //Agregado por Martin
            public const string NombreTabla = "stock_suc_deposito_art_fecha";
            public const string LoteId = STOCK_SUC_DEPOSITO_ART_FECHACollection.ARTICULO_LOTE_IDColumnName;
            public const string CostoFifo = STOCK_SUC_DEPOSITO_ART_FECHACollection.COSTO_ACTIVOColumnName;
            public const string CostoPonderado = STOCK_SUC_DEPOSITO_ART_FECHACollection.COSTO_PONDERADOColumnName;
            public const string MonedaIdPonderada = STOCK_SUC_DEPOSITO_ART_FECHACollection.MONEDA_PONDERADA_IDColumnName;
            public const string MonedaIdFifo = STOCK_SUC_DEPOSITO_ART_FECHACollection.MONEDA_ACTIVA_IDColumnName;
            public const string CotizacionPonderada = STOCK_SUC_DEPOSITO_ART_FECHACollection.MONEDA_PONDERADA_COTIZACIONColumnName;
            public const string CotizacionFifo = STOCK_SUC_DEPOSITO_ART_FECHACollection.MONEDA_ACTIVA_COTIZACIONColumnName;
            public const string SucursalId = STOCK_SUC_DEPOSITO_ART_FECHACollection.SUCURSAL_IDColumnName;
            public const string ExistenciaFechaFormulario = STOCK_SUC_DEPOSITO_ART_FECHACollection.EXISTENCIA_FORMULARIOColumnName;
            public const string ExistenciaFechaMovimiento = STOCK_SUC_DEPOSITO_ART_FECHACollection.EXISTENCIAColumnName;
            public const string UsuarioCierreId = STOCK_SUC_DEPOSITO_ART_FECHACollection.USUARIO_CIERRE_IDColumnName;
            public const string FechaCierre = STOCK_SUC_DEPOSITO_ART_FECHACollection.FECHA_CIERREColumnName;
            public const string FechaFormatoNumero = STOCK_SUC_DEPOSITO_ART_FECHACollection.FECHA_FORMATO_NUMEROColumnName;
            //Agregado por N.N.
            public const string ExistenciaActual = "existencia_actual";
            public const string CantidadMovimientos = "cantidad_movimientos";
            public const string Costo = "costo";
            public const string ExistenciaFecha = "existencia_fecha";
            public const string CostoTotal = "costo_total";
        }
        #endregion Clase ColumnasStockCompletoAFecha

        #region Clase AfectarStockWebservice
        public static class AfectarStockWebservice
        {
            public static void AfectarStock(decimal caso_id, string estado_destino, SessionService sesion)
            {
                //Permitiria avisar a un sistema externo que cambio el stock
                //switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                //{
                //    case Definiciones.Clientes.ParaguayOnlineShopping:
                //        AfectarStockWebservice.VeinticuatroSeven(caso_id, estado_destino, sesion);
                //        break;
                //}
            }
        }
        #endregion Clase AfectarStockWebservice

        #region Clase Costo
        public class Costo
        {
            public decimal costo, costo_origen;
            public decimal moneda_id = Definiciones.Monedas.Guaranies, moneda_origen_id;
            public decimal cotizacion, cotizacion_origen;
        }
        #endregion Clase Costo

        #region Getters
        /// <summary>
        /// Gets the existencia mayor A uno.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        public static bool GetExistenciaMayorAUno(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    string where = StockService.ArticuloId_NombreCol + " = " + articulo_id + " and " +
                                   "(" + StockService.Existencia_NombreCol + " < 0 or " + StockService.Existencia_NombreCol + " > 1) ";
                    DataTable dt = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsDataTable(where, string.Empty);
                    //Si la consulta retorno no retorno datos significa que la existencia 
                    //del articulo (sin importar lote ni deposito) es 0 o 1
                    return dt.Rows.Count <= 0;
                }
                catch (Exception)
                {
                    throw new System.ArgumentException("No existe stock para el artículo en el depósito seleccionado.");
                }
            }
        }

        /// <summary>
        /// Gets the stock articulo deposito.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="deposito_id">The deposito_id.</param>
        /// <returns></returns>
        /// 
        public static decimal getStockArticuloLoteDeposito(decimal lote_id, decimal deposito_id, SessionService sesion)
        {
            String where = StockService.ArticuloLoteId_NombreCol + " = " + lote_id + " and " + StockService.DepositoId_NombreCol + " = " + deposito_id;
            DataTable tabla = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsDataTable(where, "");
            return (decimal)tabla.Rows[0][StockService.Existencia_NombreCol];
        }

        public DataRow getStockArticuloDeposito(decimal articulo_id, decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    String where = "articulo_id = " + articulo_id + " and deposito_id = " + deposito_id;
                    DataTable tabla = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsDataTable(where, "");

                    return tabla.Rows[0];
                }
                catch (Exception)
                {
                    throw new System.ArgumentException("No existe stock para el artículo en el depósito seleccionado.");
                }
            }
        }

        public static DataTable getStockArticuloSucursalDeposito() //Devuelve toda la vista.
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.STOCK_SUC_DEP_ART_CANTIDADCollection.GetAsDataTable(string.Empty, "");

                return tabla;
            }
        }

        public static DataTable getStockSucDepositoArticuloInfoCompleta(string where)
        {
            using (SessionService session = new SessionService())
            {
                DataTable tabla = getStockSucDepositoArticuloInfoCompleta(where, session);
                return tabla;
            }
        }

        public static DataTable getStockSucDepositoArticuloInfoCompleta(string where, SessionService session)
        {
            DataTable tabla = session.Db.STOCK_SUC_DEPO_ART_INF_COMPCollection.GetAsDataTable(where, string.Empty);
            return tabla;
        }

        public static decimal getStockArticulo(decimal articulo_id, SessionService sesion) //Devuelve toda la vista.
        {
            STOCK_SUC_DEPOSITO_ARTICULORow[] rows = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetByARTICULO_ID(articulo_id);
            decimal existencia = 0;
            for (int i = 0; i < rows.Length; i++)
                existencia += rows[i].EXISTENCIA;

            return existencia;
        }

        public static DataTable GetArticulosDistintos(SessionService sesion)
        {
            return sesion.db.EjecutarQuery("select distinct " + ArticuloId_NombreCol + " from " + Nombre_Tabla + " order by " + ArticuloId_NombreCol);
        }

        public static DataTable GetStockCompletoAFecha(string fecha, decimal moneda_id, string sucursales, string incluir_todas_sucursales)
        {
            SessionService sesion = new SessionService();
            /* Este query calcula el Saldo de Inventario a una fecha dada desde el comienzo de la historia, tomando los sucesivos movimientos de 
             * stock desde el primer ingreso de stock hasta la fecha deseada en forma incremental para las sucursales seleccionadas.
             */
            string query = "Select " + ColumnasStockCompletoAFecha.LoteId + ", " +
                 ColumnasStockCompletoAFecha.SucursalId + ", " +
                 ColumnasStockCompletoAFecha.CantidadMovimientos + ", " +
                 " round(" + ColumnasStockCompletoAFecha.Costo + ",2), " +
                 " round(" + ColumnasStockCompletoAFecha.CantidadMovimientos + " * " + ColumnasStockCompletoAFecha.Costo + ", 2) " + ColumnasStockCompletoAFecha.CostoTotal +
                 " from (Select b." + ColumnasStockCompletoAFecha.LoteId + ", " +
                 ColumnasStockCompletoAFecha.SucursalId + ", " +
                 " nvl(b.cantidad, 0) " + ColumnasStockCompletoAFecha.CantidadMovimientos + ", " +
                 " nvl(c.costo, 0) " + ColumnasStockCompletoAFecha.Costo +
                 " from (Select sm." + StockMovimientoService.LoteId_NombreCol + " " + ColumnasStockCompletoAFecha.LoteId + "," +
                 " sd." + ColumnasStockCompletoAFecha.SucursalId + "," +
                 " sum(case sm." + StockMovimientoService.Tipo_Movimiento_NombreCol +
                 " when 'VENTA' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol + " * -1" +
                 " when 'AJUSTE_NEGATIVO' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol + " * -1" +
                 " when 'TRANSFERENCIA_SALIDA' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol + " * -1" +
                 " when 'TRANSFERENICA_ENTRADA' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol +
                 " when 'EXISTENCIA_INICIAL' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol +
                 " when 'COMPRA' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol +
                 " when 'AJUSTE_POSITIVO' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol +
                 " when 'NOTA_CREDITO_CLIENTE' then " +
                 " sm." + StockMovimientoService.Cantidad_NombreCol +
                 " else " +
                 " 0 " +
                 " end) cantidad " +
                 " from " + StockMovimientoService.Nombre_Tabla + " sm, " + StockDepositosService.Nombre_Tabla + " sd" +
                 " where trunc(sm." + StockMovimientoService.Fecha_Movimiento_NombreCol + ") < to_date('" + fecha + "')" +
                 " and sm." + StockMovimientoService.Deposito_Id_NombreCol + " = sd." + StockDepositosService.Id_NombreCol +
                 " group by sm." + StockMovimientoService.LoteId_NombreCol + ", sd." + StockDepositosService.SucursalId_NombreCol + ") b," +
                 " (select ac." + CostosService.LoteId_NombreCol + ", " +
                 " case ac." + CostosService.MonedaId_NombreCol +
                 " when c.id then " +
                 " ac." + CostosService.Costo_NombreCol +
                 " else " +
                 " ac." + CostosService.Costo_NombreCol + " / ac." + CostosService.Cotizacion_NombreCol + " * c.venta " +
                 " end " + ColumnasStockCompletoAFecha.Costo +
                 " from " + CostosService.Nombre_Tabla + " ac, " +
                 " (Select max(" + CostosService.Id_NombreCol + ") costo_id " +
                 " from " + CostosService.Nombre_Tabla +
                 " group by " + CostosService.LoteId_NombreCol + ") ac2, " +
                 " (select cm." + CotizacionesService.Modelo.VENTAColumnName + ", m." + MonedasService.Modelo.IDColumnName +
                 " from " + CotizacionesService.Nombre_Vista + " cm, " + MonedasService.Nombre_Tabla + " m " +
                 " where m." + MonedasService.Modelo.IDColumnName + " = cm." + CotizacionesService.Modelo.MONEDA_IDColumnName +
                 " and m." + MonedasService.Modelo.IDColumnName + " = " + moneda_id + ") c" +
                 " where ac." + CostosService.Id_NombreCol + " = ac2.costo_id) c " +
                 " where b." + ColumnasStockCompletoAFecha.LoteId + " = c." + StockMovimientoService.LoteId_NombreCol + "(+)" +
                 " and (" + incluir_todas_sucursales + " or " + ColumnasStockCompletoAFecha.SucursalId + " in " + "(" + sucursales + ")))";

            return sesion.db.EjecutarQuery(query);
        }

        #region Manejo de Stock segun movimiento

        #region GetStockInicial
        public static decimal GetStockInicial(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                STOCK_SUC_DEPOSITO_ARTICULORow[] rows = sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausula, StockService.Id_NombreCol);
                decimal suma = 0;
                for (int i = 0; i < rows.Length; i++)
                    suma += rows[i].EXISTENCIA_INICIAL;

                return suma;
            }
        }
        #endregion GetStockInicial

        #region GetExistenciaActualPorMovimiento
        public static decimal GetExistenciaActualPorMovimiento(decimal articulo_id)
        {
            return GetExistenciaActualPorMovimiento(articulo_id, Definiciones.Error.Valor.EnteroPositivo);
        }

        public static decimal GetExistenciaActualPorMovimiento(decimal articulo_id, decimal lote_id)
        {
            return GetExistenciaActualPorMovimiento(articulo_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo);
        }

        public static decimal GetExistenciaActualPorMovimiento(decimal articulo_id, decimal lote_id, decimal sucursal_id)
        {
            return GetExistenciaActualPorMovimiento(articulo_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo);
        }

        public static decimal GetExistenciaActualPorMovimiento(decimal articulo_id, decimal lote_id, decimal sucursal_id, decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockService.ArticuloId_NombreCol + "=" + articulo_id;
                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.SucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.DepositoId_NombreCol + "=" + deposito_id;
                if (lote_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.ArticuloLoteId_NombreCol + "=" + lote_id;

                STOCK_SUC_DEPOSITO_ARTICULORow[] rows = sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausula, StockService.Id_NombreCol);
                decimal suma = 0;
                for (int i = 0; i < rows.Length; i++)
                    suma += rows[i].EXISTENCIA;

                return suma;
            }
        }
        #endregion GetExistenciaActualPorMovimiento

        #region GetStockAFechaMovimiento
        public static decimal GetStockAFechaMovimiento(decimal articulo_id, string lote_id, decimal sucursal_id, decimal deposito_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockService.ArticuloId_NombreCol + "=" + articulo_id;
                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.SucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.DepositoId_NombreCol + "=" + deposito_id;
                if (!lote_id.Equals(string.Empty))
                    clausula += " and " + StockService.ArticuloLoteId_NombreCol + " in (" + lote_id + ")";

                STOCK_SUC_DEPOSITO_ARTICULORow[] rows = sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausula, StockService.Id_NombreCol);
                decimal suma = 0;
                for (int i = 0; i < rows.Length; i++)
                    suma += rows[i].EXISTENCIA_INICIAL;

                if (rows.Length > 0)
                    suma += StockMovimientoService.GetDiferenciaStockFechaMovimiento(articulo_id, lote_id, sucursal_id, deposito_id, fecha, false, fecha);

                return suma;
            }
        }
        #endregion GetStockAFechaMovimiento

        #region GetStockAFechaFormulario
        public static decimal GetStockAFechaFormulario(decimal articulo_id, string lote_id, decimal sucursal_id, decimal deposito_id, DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = StockService.ArticuloId_NombreCol + "=" + articulo_id;
                //Datos no obligatorios
                if (sucursal_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.SucursalId_NombreCol + "=" + sucursal_id;
                if (deposito_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula += " and " + StockService.DepositoId_NombreCol + "=" + deposito_id;
                if (!lote_id.Equals(string.Empty))
                    clausula += " and " + StockService.ArticuloLoteId_NombreCol + " in (" + lote_id + ")";

                STOCK_SUC_DEPOSITO_ARTICULORow[] rows = sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausula, StockService.Id_NombreCol);
                decimal suma = 0;
                for (int i = 0; i < rows.Length; i++)
                    suma += rows[i].EXISTENCIA_INICIAL;

                if (rows.Length > 0)
                    suma += StockMovimientoService.GetDiferenciaStockFechaFormulario(articulo_id, lote_id, sucursal_id, deposito_id, fecha, false, fecha);

                return suma;
            }
        }
        #endregion GetStockAFechaFormulario

        #endregion Manejo de Stock segun movimiento

        #endregion Getters

        #region modificarStock
        public static bool modificarStock(decimal deposito_id, decimal articulo_id, decimal cantidad, string tipoMovimiento,
                                          decimal caso_id, decimal lote_id, string estado_destino, SessionService sesion,
                                          Costo costo, decimal? impuesto_id, decimal registro_id)
        {
            //se inicializa la variable que indica si la politica ha sido aceptada
            bool politicaVerificada = true;
            //si la modificación del stock proviene de una accion que no tenga que ver con un caso 
            //como ser un combo no se verifican las politicas
            if (caso_id != Definiciones.Error.Valor.EnteroPositivo)
                politicaVerificada = VerificarPoliticas(caso_id, estado_destino, sesion);

            if (!politicaVerificada)
                return false;

            string clausulas = StockService.ArticuloId_NombreCol + " = " + articulo_id + " and " +
                               StockService.ArticuloLoteId_NombreCol + " = " + lote_id + " and " +
                               StockService.DepositoId_NombreCol + " = " + deposito_id;

            STOCK_SUC_DEPOSITO_ARTICULORow[] stockArray = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausulas, string.Empty);
            STOCK_SUC_DEPOSITO_ARTICULORow stockRow;
                        ArticulosService articulo = new ArticulosService(articulo_id, sesion);
            bool exito = true;
            try
            {
                //Los articulos de tipo servicio no se contabilizan en el stock
                if (articulo.Servicio == Definiciones.SiNo.No)
                {
                    //Controla que exista el registro
                    if (stockArray.Length <= 0)
                        InsertarStockEnDeposito(sesion, StockDepositosService.GetSucursalId(deposito_id), deposito_id, articulo_id, lote_id, out stockRow);
                    else
                        stockRow = stockArray[0];

                    switch (tipoMovimiento)
                    {
                        case Definiciones.Stock.TipoMovimiento.AjusteNegativo:
                            stockRow.AJUSTE_NEGATIVO += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                            stockRow.AJUSTE_POSITIVO += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Compra:
                            stockRow.COMPRA += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Industrializacion:
                            if (stockRow.IsINDUSTRIALIZACIONNull)
                                stockRow.INDUSTRIALIZACION = 0;
                            stockRow.INDUSTRIALIZACION += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                            stockRow.NOTA_CREDITO_CLIENTE += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                            stockRow.NOTA_DEBITO_CLIENTE += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                            stockRow.NOTA_CREDITO_PROVEEDOR += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                            stockRow.NOTA_DEBITO_PROVEEDOR += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                            stockRow.TRANSFERENCIA_ENTRADA += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                            stockRow.TRANSFERENCIA_SALIDA += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Transito:
                            stockRow.TRANSITO += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Venta:
                        case Definiciones.Stock.TipoMovimiento.Remision:
                            stockRow.VENTA += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                            stockRow.USO_DE_INSUMO += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosCreados:
                            if (cantidad < 0)
                            {
                                cantidad = cantidad * -1;
                                stockRow.EXISTENCIA += cantidad;
                                stockRow.COMBOS_ELIMINADOS += cantidad;
                            }
                            else
                            {
                                stockRow.EXISTENCIA -= cantidad;
                                stockRow.COMBOS_CREADOS += cantidad;
                            }
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosEliminado:
                            if (cantidad < 0)
                            {
                                cantidad = cantidad * -1;
                                stockRow.EXISTENCIA -= cantidad;
                                stockRow.COMBOS_CREADOS += cantidad;
                            }
                            else
                            {
                                stockRow.EXISTENCIA += cantidad;
                                stockRow.COMBOS_ELIMINADOS += cantidad;
                            }
                            break;
                        default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                    }

                    //Actualizar el registro
                    sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Update(stockRow);
                    // Ingresar registro en la tabla de movimiento de stock
                    var movimiento = new StockMovimientoService()
                    {
                        DepositoId = deposito_id,
                        ArticuloId = articulo_id,
                        LoteId = lote_id,
                        Cantidad = cantidad,
                        TipoMovimiento = tipoMovimiento,
                        CasoId = caso_id,
                        RegistroId = registro_id
                    };

                    if (impuesto_id.HasValue)
                        movimiento.ImpuestoId = impuesto_id.Value;

                    movimiento.CostoMonedaOrigenId = 1;
                    movimiento.CostoOrigen = 1;
                    movimiento.CostoCotizacionMonedaOrigen = 1;
                    movimiento.CostoMonedaId = 1;
                    movimiento.Costo = 1;
                    movimiento.CostoCotizacionMoneda = 1;                    
                    movimiento.IniciarUsingSesion(sesion);
                    movimiento.Guardar();
                    movimiento.FinalizarUsingSesion();

                    //Invocar al webservice si esta configurado para el cliente
                    AfectarStockWebservice.AfectarStock(caso_id, estado_destino, sesion);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                exito = false;
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.STOCK_EXISTENCIA_INSUFICIENTE:
                        throw new System.ArgumentException("El stock es insuficiente.");
                    case Definiciones.OracleNumeroExcepcion.STOCK_INCONSISTENCIA:
                        throw new System.ArgumentException("Inconsistencia de stock. Favor comuníquese con el soporte técnico.");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }

            return exito;
        }

        /// <summary>
        /// Sobrecarga de método para el borrado lógico
        /// <returns></returns>
        public static bool modificarStock(decimal deposito_id, decimal articulo_id, decimal cantidad, string tipoMovimiento,
                                          decimal caso_id, decimal lote_id, string estado_destino, SessionService sesion,
                                          Costo costo, decimal? impuesto_id, decimal registro_id, bool borrado_logico)
        {
            bool politicaVerificada = true;
            //si la modificación del stock proviene de una accion que no tenga que ver con un caso 
            //como ser un combo no se verifican las politicas

            if (caso_id != Definiciones.Error.Valor.EnteroPositivo)
                politicaVerificada = VerificarPoliticas(caso_id, estado_destino, sesion);

            if (!politicaVerificada)
                return false;

            string clausulas = StockService.ArticuloId_NombreCol + " = " + articulo_id + " and " +
                               StockService.ArticuloLoteId_NombreCol + " = " + lote_id + " and " +
                               StockService.DepositoId_NombreCol + " = " + deposito_id;
            STOCK_SUC_DEPOSITO_ARTICULORow[] stockArray = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausulas, string.Empty);
            STOCK_SUC_DEPOSITO_ARTICULORow stockRow;
            ArticulosService articulo = new ArticulosService(articulo_id, sesion);
            bool exito = true;
            try
            {
                //Los articulos de tipo servicio no se contabilizan en el stock
                if (articulo.Servicio == Definiciones.SiNo.No)
                {
                    //Controla que exista el registro
                    if (stockArray.Length <= 0)
                        InsertarStockEnDeposito(sesion, StockDepositosService.GetSucursalId(deposito_id), deposito_id, articulo_id, lote_id, out stockRow);
                    else
                        stockRow = stockArray[0];

                    switch (tipoMovimiento)
                    {
                        case Definiciones.Stock.TipoMovimiento.AjusteNegativo:
                            stockRow.AJUSTE_NEGATIVO += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.AjustePositivo:
                            stockRow.AJUSTE_POSITIVO += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Compra:
                            stockRow.COMPRA += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Industrializacion:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoCliente:
                            stockRow.NOTA_CREDITO_CLIENTE += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoCliente:
                            stockRow.NOTA_DEBITO_CLIENTE += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor:
                            stockRow.NOTA_CREDITO_PROVEEDOR += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor:
                            stockRow.NOTA_DEBITO_PROVEEDOR += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.PuntoMinimo:
                            throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                        case Definiciones.Stock.TipoMovimiento.TransferenciaEntrada:
                            stockRow.TRANSFERENCIA_ENTRADA += cantidad;
                            stockRow.EXISTENCIA += cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.TransferenciaSalida:
                            stockRow.TRANSFERENCIA_SALIDA += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Transito:
                            stockRow.TRANSITO += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.Venta:
                        case Definiciones.Stock.TipoMovimiento.Remision:
                            stockRow.VENTA += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.UsoDeInsumo:
                            stockRow.USO_DE_INSUMO += cantidad;
                            stockRow.EXISTENCIA -= cantidad;
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosCreados:
                            if (cantidad < 0)
                            {
                                cantidad = cantidad * -1;
                                stockRow.EXISTENCIA += cantidad;
                                stockRow.COMBOS_ELIMINADOS += cantidad;
                            }
                            else
                            {
                                stockRow.EXISTENCIA -= cantidad;
                                stockRow.COMBOS_CREADOS += cantidad;
                            }
                            break;
                        case Definiciones.Stock.TipoMovimiento.CombosEliminado:

                            if (cantidad < 0)
                            {
                                cantidad = cantidad * -1;
                                stockRow.EXISTENCIA -= cantidad;
                                stockRow.COMBOS_CREADOS += cantidad;
                            }
                            else
                            {
                                stockRow.EXISTENCIA += cantidad;
                                stockRow.COMBOS_ELIMINADOS += cantidad;
                            }
                            break;
                        default: throw new System.ArgumentException("Error en modificarStock(). El tipo de movimiento no está implementado");
                    }

                    sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Update(stockRow);
                    if (borrado_logico)
                    {
                        var movimiento = new StockMovimientoService();
                        movimiento.IniciarUsingSesion(sesion);
                        foreach (var m in movimiento.GetFiltrado<StockMovimientoService>(new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = caso_id }))
                        {
                            m.IniciarUsingSesion(sesion);
                            m.Borrar();
                            m.FinalizarUsingSesion();
                        }
                        movimiento.FinalizarUsingSesion();
                    }
                    else
                    {
                        var movimiento = new StockMovimientoService()
                        {
                            DepositoId = deposito_id,
                            ArticuloId = articulo_id,
                            LoteId = lote_id,
                            Cantidad = cantidad,
                            TipoMovimiento = tipoMovimiento,
                            CasoId = caso_id,
                            RegistroId = registro_id
                        };

                        if (impuesto_id.HasValue)
                            movimiento.ImpuestoId = impuesto_id.Value;

                        if (costo != null)
                        {
                            movimiento.CostoMonedaOrigenId = costo.moneda_origen_id;
                            movimiento.CostoOrigen = costo.costo_origen;
                            movimiento.CostoCotizacionMonedaOrigen = costo.cotizacion_origen;
                            movimiento.CostoMonedaId = costo.moneda_id;
                            movimiento.Costo = costo.costo;
                            movimiento.CostoCotizacionMoneda = costo.cotizacion;
                        }

                        movimiento.IniciarUsingSesion(sesion);
                        movimiento.Guardar();
                        movimiento.FinalizarUsingSesion();
                    }
                    AfectarStockWebservice.AfectarStock(caso_id, estado_destino, sesion);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                exito = false;
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.STOCK_EXISTENCIA_INSUFICIENTE:
                        throw new System.ArgumentException("El stock es insuficiente.");
                    case Definiciones.OracleNumeroExcepcion.STOCK_INCONSISTENCIA:
                        throw new System.ArgumentException("Inconsistencia de stock. Favor comuníquese con el soporte técnico.");
                    default: throw exp;
                }
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }

            return exito;
        }

        public static bool modificarStockCombo(decimal deposito_id, decimal articulo_id, decimal cantidad, string tipoMovimiento, decimal caso_id, decimal lote_id, bool combo, SessionService sesion, string estado, decimal? impuesto_id, decimal registro_id)
        {
            if (combo)
                return modificarStock(deposito_id, articulo_id, -cantidad, tipoMovimiento, caso_id, lote_id, estado, sesion, null, impuesto_id, registro_id);
            else
                return modificarStock(deposito_id, articulo_id, cantidad, tipoMovimiento, caso_id, lote_id, estado, sesion, null, impuesto_id, registro_id);
        }
        #endregion modificarStock

        #region CorreccionStock
        public static void CorreccionStock(decimal factura_proveedor_det_id, decimal caso_id, decimal lote_id, decimal articulo_id,
            decimal cantidad, decimal lote_anterior, decimal cantidad_anterior, decimal deposito_id, SessionService sesion,
            DateTime fecha, decimal costo_monto, decimal moneda_id, decimal cotizacion, decimal? impuesto_id, decimal registro_id)
        {
            if (ArticulosService.EsServicio(articulo_id))
                return;
            
            string clausulas = string.Empty;
            if (lote_id != lote_anterior)
            {
                // modificacion del stock del articulo original
                if (!lote_anterior.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    clausulas = StockService.ArticuloLoteId_NombreCol + " = " + lote_anterior + " and " +
                                StockService.DepositoId_NombreCol + " = " + deposito_id;

                    STOCK_SUC_DEPOSITO_ARTICULORow[] stockArrayAnterior = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausulas, string.Empty);
                    STOCK_SUC_DEPOSITO_ARTICULORow stockRowAntrior;

                    if (stockArrayAnterior.Length <= 0)
                        InsertarStockEnDeposito(sesion, StockDepositosService.GetSucursalId(deposito_id), deposito_id, articulo_id, lote_id, out stockRowAntrior);
                    else
                        stockRowAntrior = stockArrayAnterior[0];

                    decimal existenciaAnterior = stockRowAntrior.EXISTENCIA;
                    stockRowAntrior.COMPRA -= cantidad_anterior;
                    stockRowAntrior.EXISTENCIA -= cantidad_anterior;
                    if (stockRowAntrior.EXISTENCIA < 0)
                    {
                        throw new Exception("Inconsistencia de Stock, se deben restar:" + cantidad_anterior + "\n pero sólo existen:" + existenciaAnterior + ". \n Favor Verificar.");
                    }
                    sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Update(stockRowAntrior);
                }
                clausulas = StockService.ArticuloLoteId_NombreCol + " = " + lote_id + " and " +
                            StockService.DepositoId_NombreCol + " = " + deposito_id;
                // modificacion del stock del articulo nuevo
                STOCK_SUC_DEPOSITO_ARTICULORow[] stockArrayNuevo = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausulas, string.Empty);
                STOCK_SUC_DEPOSITO_ARTICULORow stockRowNuevo;
                if (stockArrayNuevo.Length <= 0)
                    InsertarStockEnDeposito(sesion, StockDepositosService.GetSucursalId(deposito_id), deposito_id, articulo_id, lote_id, out stockRowNuevo);
                else
                    stockRowNuevo = stockArrayNuevo[0];
                stockRowNuevo.COMPRA += cantidad;
                stockRowNuevo.EXISTENCIA += cantidad;
                sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Update(stockRowNuevo);
            }
            else
            {
                clausulas = StockService.ArticuloLoteId_NombreCol + " = " + lote_id + " and " +
                           StockService.DepositoId_NombreCol + " = " + deposito_id;
                // modificacion del stock del articulo
                STOCK_SUC_DEPOSITO_ARTICULORow[] stockArray = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAsArray(clausulas, string.Empty);
                STOCK_SUC_DEPOSITO_ARTICULORow stockRow;
                if (stockArray.Length <= 0)
                    InsertarStockEnDeposito(sesion, StockDepositosService.GetSucursalId(deposito_id), deposito_id, articulo_id, lote_id, out stockRow);
                else
                    stockRow = stockArray[0];

                stockRow.COMPRA += (cantidad - cantidad_anterior);
                stockRow.EXISTENCIA += (cantidad - cantidad_anterior);                                
                sesion.db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Update(stockRow);
            }
            //modificacion de costos
            #region Costos
            clausulas = StockMovimientoService.Caso_Id_NombreCol + "=" + caso_id + " and " + StockMovimientoService.LoteId_NombreCol + "=" + lote_anterior;
            ARTICULOS_COSTOSRow[] costoRow = sesion.db.ARTICULOS_COSTOSCollection.GetAsArray(clausulas, string.Empty);
            if (costoRow.Length > 0)
            {
                if (costoRow[0].ARTICULO_ID != articulo_id)
                {
                    costoRow[0].CANTIDAD_REST_FECHA_INSERCION = StockMovimientoService.GetDiferenciaStockFechaHoraMovimiento(articulo_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, costoRow[0].FECHA_INSERCION, false, costoRow[0].FECHA_INSERCION);
                }
                costoRow[0].ARTICULO_ID = articulo_id;
                costoRow[0].LOTE_ID = lote_id;
                costoRow[0].CANTIDAD_INICIAL = cantidad;
                costoRow[0].COSTO = costo_monto;
                //costoRow[0].CANTIDAD_REST_FECHA_INSERCION = StockMovimientoService.GetDiferenciaStockFechaHora(articulo_id, lote_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, DateTime.Now, false, fecha);
                sesion.db.ARTICULOS_COSTOSCollection.Update(costoRow[0]);
            }
            else
            {
                ARTICULOS_COSTOSRow row = new ARTICULOS_COSTOSRow();
                row.ID = sesion.Db.GetSiguienteSecuencia("articulos_costos_sqc");
                row.ESTADO = Definiciones.Estado.Activo;
                row.LOTE_ID = lote_id;
                row.CANTIDAD_INICIAL = cantidad;
                row.MONEDA_ID = moneda_id;
                row.COTIZACION = cotizacion;
                row.IsFECHA_FINNull = true;
                row.CANTIDAD_RESTANTE = row.CANTIDAD_INICIAL;
                row.ARTICULO_ID = articulo_id;
                row.CASO_ID = caso_id;
                row.AJUSTE_MANUAL = Definiciones.SiNo.No;
                row.COSTO = costo_monto;
                row.COSTO_PONDERADO = costo_monto;
                row.FECHA_INSERCION = fecha;
                row.CANTIDAD_REST_FECHA_INSERCION = StockMovimientoService.GetDiferenciaStockFechaHoraMovimiento(articulo_id, lote_id, Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, DateTime.Now, false, fecha);
                sesion.Db.ARTICULOS_COSTOSCollection.Insert(row);
            }

            // recalcular los costos
            CostosService.RecalcularCostos(articulo_id, fecha, sesion, false);
            if (!lote_anterior.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {
                CostosService.RecalcularCostos(ArticulosLotesService.GetArticuloId2(lote_anterior), fecha, sesion, false);
            }
            #endregion Costos
            
            #region Movimientos
            var sm = new StockMovimientoService();
            sm.IniciarUsingSesion(sesion);
            var movimiento = sm.GetPrimero<StockMovimientoService>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro(){ Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = caso_id },
                new ClaseCBABase.Filtro(){ Columna = StockMovimientoService.Modelo.REGISTRO_IDColumnName, Valor = registro_id }
            });

            if (movimiento == null)
                movimiento = new StockMovimientoService();

            var caso = new CasosService(caso_id, sesion);
            var dtDetalles = FacturasProveedorDetalleService.GetFacturaProveedorDetalleDataTable(FacturasProveedorDetalleService.Id_NombreCol + " = " + factura_proveedor_det_id, string.Empty, sesion);
            decimal montoImpuesto = 0;
            if ((decimal)dtDetalles.Rows[0][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol] > 0)
                montoImpuesto = (decimal)dtDetalles.Rows[0][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] / (1 + (100 / (decimal)dtDetalles.Rows[0][FacturasProveedorDetalleService.PorcentajeImpuesto_NombreCol]));

            movimiento.DepositoId = deposito_id;
            movimiento.ArticuloId = articulo_id;
            movimiento.LoteId = lote_id;
            movimiento.Cantidad = cantidad;
            movimiento.TipoMovimiento = Definiciones.Stock.TipoMovimiento.Compra;
            movimiento.CasoId = caso_id;
            movimiento.FechaFormulario = fecha;
            movimiento.RegistroId = registro_id;
            if (impuesto_id.HasValue)
                movimiento.ImpuestoId = impuesto_id.Value;

            movimiento.CostoMonedaOrigenId = moneda_id;
            movimiento.CostoCotizacionMonedaOrigen = cotizacion;
            movimiento.CostoOrigen = (decimal)dtDetalles.Rows[0][FacturasProveedorDetalleService.PrecioBrutoUnitarioOrigen_NombreCol] - montoImpuesto;
            movimiento.CostoMonedaId = caso.Sucursal.Region.SucursalCasaMatriz.Pais.MonedaId;
            if (movimiento.CostoMonedaOrigenId == movimiento.CostoMonedaId)
            {
                movimiento.CostoCotizacionMoneda = movimiento.CostoCotizacionMonedaOrigen;
                movimiento.Costo = movimiento.CostoOrigen;
            }
            else
            {
                movimiento.CostoCotizacionMoneda = CotizacionesService.GetCotizacionMonedaVenta(caso.Sucursal.PaisId, movimiento.CostoMonedaId, caso.FechaFormulario.Value, sesion);
                movimiento.Costo = movimiento.CostoOrigen / movimiento.CostoCotizacionMonedaOrigen * movimiento.CostoCotizacionMoneda;
            }

            movimiento.IniciarUsingSesion(sesion);
            movimiento.Guardar();
            movimiento.FinalizarUsingSesion();
            #endregion Movimientos
        }
        #endregion CorreccionStock

        #region InsertarStockEnDeposito
        public static void InsertarStockEnDeposito(SessionService sesion, decimal sucursal_id, decimal deposito_id, decimal articulo_id, decimal lote_id, out STOCK_SUC_DEPOSITO_ARTICULORow stockRowNew)
        {
            STOCK_SUC_DEPOSITO_ARTICULORow stockRow = new STOCK_SUC_DEPOSITO_ARTICULORow();
            try
            {
                stockRow.ID = sesion.db.GetSiguienteSecuencia("stock_suc_deposito_art_sqc");
                stockRow.SUCURSAL_ID = sucursal_id;
                stockRow.DEPOSITO_ID = deposito_id;
                stockRow.ARTICULO_ID = articulo_id;
                stockRow.ARTICULO_LOTE_ID = lote_id;
                //Actualizar el registro
                sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.Insert(stockRow);
                stockRowNew = stockRow;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion InsertarStockEnDeposito

        #region VerificacionPoliticas
        private static bool VerificarPoliticas(decimal caso_id, string estado_destino)
        {
            using (SessionService sesion = new SessionService())
            {
                return VerificarPoliticas(caso_id, estado_destino, sesion);
            }
        }

        private static bool VerificarPoliticas(decimal caso_id, string estado_destino, SessionService sesion)
        {
            //Se obtienen los datos del caso
            int flujoId = int.Parse(CasosService.GetFlujo(caso_id, sesion).ToString());
            string estadoCaso = CasosService.GetEstadoCaso(caso_id, sesion);
            // se obtiene la politica utilizada por la entidad
            decimal politica = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PoliticaMovimientoStock);

            #region Politica Tarde
            if (Definiciones.Stock.Politicas.Tardia == politica)
            {
                // si el estado destino es una cadena vacia, entonces el movimiento de stock no pertenece a 
                // un cambio de estado y solo se evalua el flujo del cual proviene
                //si el estado destino no es una cadena vacia entonces a más de evaluar el flujo 
                // se debe evaluar el estado destino y el estado actual del caso

                if (estado_destino.Equals(string.Empty))
                {
                    return false;
                }
                else
                {
                    switch (flujoId)
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Caja))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnReparto) && estado_destino.Equals(Definiciones.EstadosFlujos.Caja))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Caja) && estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Caja) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Borrador) && estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                            {
                                return true;
                            }
                           
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.REMISIONES:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;
                            else if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                                return true;
                            else if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                                return true;
                            return false;
                            break;
                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.PreAprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.INGRESO_DE_STOCK:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;
                            else if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                                return true;    
                            
                            return false;
                            break;
                        case Definiciones.FlujosIDs.NOTA_CREDITO_PROVEEDOR:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.AJUSTE_STOCK:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.USO_DE_INSUMOS:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;

                            else if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                                return true;    

                            return false;
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Borrador) && estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Viajando) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Viajando) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Cerrado) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_INSUMOS:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Borrador) && estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Viajando) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Viajando) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Cerrado) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_BALANCEADOS:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Borrador) && estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Viajando) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Viajando))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Viajando) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.EnRevision) && estado_destino.Equals(Definiciones.EstadosFlujos.EnRevision))
                            {
                                return true;
                            }
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Cerrado) && estado_destino.Equals(Definiciones.EstadosFlujos.Cerrado))
                            {
                                return true;
                            }
                            //si no cumple con los requisitos de la politica retorna falso.
                            return false;
                            break;
                        case Definiciones.FlujosIDs.INGRESO_INSUMOS:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;
                            else 
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                                return true;
                            else
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Anulado) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;

                            return false;
                            break;                         
                        case Definiciones.FlujosIDs.PRODUCCION_BALANCEADOS:
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Pendiente) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;
                            else
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Aprobado) && estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                                return true;
                            else
                            if (estadoCaso.Equals(Definiciones.EstadosFlujos.Anulado) && estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                                return true;

                            return false;
                            break;
                        default:
                            return false;
                    }
                    return false;
                }
            }
            #endregion Politica Tarde

            return false;
        }
        #endregion VerificacionPoliticas

        #region Cierres por Fecha de Formulario
        public static bool GenerarCierreFechaFormulario(DateTime fecha, SessionService sesion)
        {
            bool exito = false;
            try
            {
                string procedimientoAlamacenado = "TRC.PROC.generar_existencia_fecha_form";
                OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, sesion.db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parametros ENTRANTES
                cmd.Parameters.Add(new OracleParameter("fecha", OracleDbType.Date));
                cmd.Parameters["fecha"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new OracleParameter("usuarioId", OracleDbType.Int32, 50));
                cmd.Parameters["usuarioId"].Direction = ParameterDirection.Input;
                #endregion

                #region Parametros SALIENTES
                cmd.Parameters.Add(new OracleParameter("resultado", OracleDbType.Int32, 400));
                cmd.Parameters["resultado"].Direction = ParameterDirection.Output;
                #endregion

                #region Parametros VALORES
                cmd.Parameters["fecha"].Value = fecha;
                cmd.Parameters["usuarioId"].Value = (Int32)sesion.Usuario.ID;
                #endregion

                // Ejecutamos el procedimiento almacenado
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception exp)
            {
                exito = false;
                throw new Exception("Error al generar el cierre de Stock. " + exp.Message);
            }
            return exito;
        }

        public static bool GenerarCierreFechaFormulario2(DateTime fecha)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                try
                {
                    // Hace un loop de TODOS los registros de stock suc deposito articulo
                    DataTable dtStockSucDepositoArticulo = sesion.Db.STOCK_SUC_DEPOSITO_ARTICULOCollection.GetAllAsDataTable();
                    decimal loteId, depositoId, existenciaBase;
                    DateTime fechaBase;
                    // Para cada registro de stock suc deposito articulo
                    foreach (DataRow stock in dtStockSucDepositoArticulo.Rows)
                    {
                        existenciaBase = (decimal)stock[StockService.ExistenciaInicial_NombreCol];
                        depositoId = (decimal)stock[StockService.DepositoId_NombreCol];
                        loteId = (decimal)stock[StockService.ArticuloLoteId_NombreCol];
                        fechaBase = Convert.ToDateTime("01/01/2000");
                        // Cuenta los elementos de stock suc dep art fecha que tengan el id del stock suc deposito art actual y que existencia formulario no sea null
                        // y que su fecha formato numero sea menor a la fecha dada en el parametro de entrada de esta funcion
                        string clausulas = StockService.StockSucDepArtIdStockSucDepArtFecha_NombreCol + " = " + stock[StockService.Id_NombreCol].ToString() + " and " +
                                           StockService.ExistenciaFormularioStockSucDepArtFecha_NombreCol + " is not null and " +
                                           "trunc(to_date(to_char(" + StockService.FechaFormatoNumero_NombreCol + "),'YYYYMMDD')) < trunc(" + fecha.ToShortDateString() + ")";
                        DataTable dtStockSucDepArtFecha = sesion.Db.STOCK_SUC_DEPOSITO_ART_FECHACollection.GetAsDataTable(clausulas, StockService.IdStockSucDepArtFecha_NombreCol + " desc");
                        // Si existe mas de un elemento
                        // Toma el max id de los elementos obtenidos con la query anterior
                        // Con esta id, se obtiene existencia formulario, deposito id, articulo lote id, fecha formato numero + 1 (esto suma un dia?)
                        // Esto se guarda en existenciaBase, depositoId, loteId, fechaBase
                        if (dtStockSucDepArtFecha.Rows.Count > 0)
                        {
                            existenciaBase = (decimal)dtStockSucDepArtFecha.Rows[0][StockService.ExistenciaFormularioStockSucDepArtFecha_NombreCol];
                            depositoId = (decimal)dtStockSucDepArtFecha.Rows[0][StockService.DepositoIdStockSucDepositoArtFecha_NombreCol];
                            loteId = (decimal)dtStockSucDepArtFecha.Rows[0][StockService.ArticuloLoteIdStockSucDepositoArtFecha_NombreCol];
                            fechaBase = DateTime.ParseExact(((decimal)dtStockSucDepArtFecha.Rows[0][StockService.FechaFormatoNumero_NombreCol]).ToString(), "yyyyMMdd", null);
                        }
                        // Se hace otro loop movimientos con registros de stock_movimientos donde el deposito es depositoId, el lote es loteId, la fecha formulario es >= a la fechaBase y <= a la fecha parametro 
                        // Order by fecha formulario
                        var sm = new StockMovimientoService();
                        sm.IniciarUsingSesion(sesion);
                        foreach (var m in sm.GetFiltrado<StockMovimientoService>(new ClaseCBABase.Filtro[]
                            {
                                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.DEPOSITO_IDColumnName, Valor = depositoId },
                                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.LOTE_IDColumnName, Valor = loteId },
                                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName, Valor = fechaBase, Comparacion = ">=" },
                                new ClaseCBABase.Filtro() { Columna = StockMovimientoService.Modelo.FECHA_FORMULARIOColumnName, Valor = fecha, Comparacion = "<=" },
                            }))
                        {
                            // Hay un if por cada tipo de movimiento posible
                            if (m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Compra ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.AjustePositivo ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.TransferenciaEntrada ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaCreditoCliente ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaDebitoProveedor ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Industrializacion)
                            {
                                existenciaBase = existenciaBase + m.Cantidad;
                            }
                            else if (m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Venta ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.Remision ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.AjusteNegativo ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.TransferenciaSalida ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaDebitoCliente ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.NotaCreditoProveedor ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.CombosCreados ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.CombosEliminado ||
                                m.TipoMovimiento == Definiciones.Stock.TipoMovimiento.UsoDeInsumo)
                            {
                                existenciaBase = existenciaBase - m.Cantidad;
                            }
                        }
                        sm.FinalizarUsingSesion();
                        // Fuera del loop de movimientos, simplemente actualiza el registro de stock suc dep art fecha where stock suc deposito art = registor actual del loop principal y where fecha dada = fecha formato numero
                        // Hace existencia formulario = existenciaBase, usuarioCierre = usuarioId, fecha cierre es sysdate
                        clausulas = StockService.StockSucDepArtIdStockSucDepArtFecha_NombreCol + " = " + ((decimal)stock[StockService.Id_NombreCol]).ToString() + " and " +
                                    "trunc(to_date(to_char(" + StockService.FechaFormatoNumero_NombreCol + "), 'YYYYMMDD')) = trunc(" + fecha.ToShortDateString() + ")";
                        STOCK_SUC_DEPOSITO_ART_FECHARow stockSucDepArtFechaRow = sesion.Db.STOCK_SUC_DEPOSITO_ART_FECHACollection.GetRow(clausulas);
                        stockSucDepArtFechaRow.EXISTENCIA_FORMULARIO = existenciaBase;
                        stockSucDepArtFechaRow.USUARIO_CIERRE_ID = sesion.Usuario_Id;
                        stockSucDepArtFechaRow.FECHA_CIERRE = DateTime.Now;
                        sesion.Db.STOCK_SUC_DEPOSITO_ART_FECHACollection.Update(stockSucDepArtFechaRow);
                    }
                    exito = true;
                }
                catch (Exception exp)
                {
                    exito = false;
                    throw new Exception("Error al generar el cierre de Stock");
                }
                return exito;
            }
        }

        public static bool EliminarCierre(DateTime fecha, SessionService sesion)
        {
            bool exito = false;
            try
            {
                string comando = "delete " + StockService.ColumnasStockCompletoAFecha.NombreTabla +
                                 " where " + StockService.ColumnasStockCompletoAFecha.FechaFormatoNumero + " >= " + fecha.ToString(CBA.FlowV2.Services.Base.Definiciones.FechaFormatoISO);
                OracleCommand cmd = new OracleCommand(comando, sesion.db.Connection as OracleConnection);
                cmd.CommandType = System.Data.CommandType.Text;
                // Ejecutamos el comando
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception exp)
            {
                exito = false;
                throw new Exception("Error al eliminar el cierre de Stock. " + exp.Message);
            }
            return exito;
        }
        #endregion Cierres por Fecha de Formulario

        #region Accesors
        public static string Nombre_Tabla
        { get { return "STOCK_SUC_DEPOSITO_ARTICULO"; } }
        public static string Nombre_Vista
        { get { return "STOCK_SUC_DEPO_ART_INF_COMP"; } }
        public static string Id_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.IDColumnName; } }
        public static string SucursalId_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.SUCURSAL_IDColumnName; } }
        public static string DepositoId_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.DEPOSITO_IDColumnName; } }
        public static string ArticuloId_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.ARTICULO_IDColumnName; } }
        public static string ArticuloLoteId_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.ARTICULO_LOTE_IDColumnName; } }
        public static string ExistenciaStockSucDetArt_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.EXISTENCIAColumnName; } }
        public static string ExistenciaInicial_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ARTICULOCollection.EXISTENCIA_INICIALColumnName; } }
        public static string ArticuloDescripcion_NombreCol
        { get { return STOCK_SUC_DEP_ART_CANTIDADCollection.ARTICULO_DESCRIPCIONColumnName; } }
        public static string DepositoNombre_NombreCol
        { get { return STOCK_SUC_DEP_ART_CANTIDADCollection.DEPOSITO_NOMBREColumnName; } }
        public static string Existencia_NombreCol
        { get { return STOCK_SUC_DEP_ART_CANTIDADCollection.EXISTENCIAColumnName; } }
        public static string LoteNombre_NombreCol
        { get { return STOCK_SUC_DEP_ART_CANTIDADCollection.LOTEColumnName; } }
        public static string SucursalNombre_NombreCol
        { get { return STOCK_SUC_DEP_ART_CANTIDADCollection.SUCURSAL_NOMBREColumnName; } }
        public static string ArticuloCodigo_NombreCol
        { get { return STOCK_SUC_DEP_ART_CANTIDADCollection.ARTICULO_CODIGOColumnName; } }
        public static string IdStockSucDepArtFecha_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ART_FECHACollection.IDColumnName; } }
        public static string StockSucDepArtIdStockSucDepArtFecha_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ART_FECHACollection.STOCK_SUC_DEPOSITO_ART_IDColumnName; } }
        public static string ExistenciaFormularioStockSucDepArtFecha_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ART_FECHACollection.EXISTENCIA_FORMULARIOColumnName; } }
        public static string FechaFormatoNumero_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ART_FECHACollection.FECHA_FORMATO_NUMEROColumnName; } }
        public static string DepositoIdStockSucDepositoArtFecha_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ART_FECHACollection.DEPOSITO_IDColumnName; } }
        public static string ArticuloLoteIdStockSucDepositoArtFecha_NombreCol
        { get { return STOCK_SUC_DEPOSITO_ART_FECHACollection.ARTICULO_LOTE_IDColumnName; } }
        public static string VistaArticuloNombre_NombreCol
        { get { return STOCK_SUC_DEPO_ART_INF_COMPCollection.ARTICULO_NOMBREColumnName; } }
        public static string VistaLoteNombre_NombreCol
        { get { return STOCK_SUC_DEPO_ART_INF_COMPCollection.LOTE_NOMBREColumnName; } }
        public static string VistaSucursalNombre_NombreCol
        { get { return STOCK_SUC_DEPO_ART_INF_COMPCollection.SUCURSAL_NOMBREColumnName; } }
        public static string VistaDepositoNombre_NombreCol
        { get { return STOCK_SUC_DEPO_ART_INF_COMPCollection.DEPOSITO_NOMBREColumnName; } }
        public static string VistaUnidadMedidaId_NombreCol
        { get { return STOCK_SUC_DEPO_ART_INF_COMPCollection.UNIDAD_MEDIDA_IDColumnName; } }
        public static string VistaUnidadMedidaNombre_NombreCol
        { get { return STOCK_SUC_DEPO_ART_INF_COMPCollection.UNIDAD_MEDIDAColumnName; } }
        #endregion Accesors
    }
}
