#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using System.Collections;
using CBA.FlowV2.Services.RecursosHumanos;
using System.Collections.Generic;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Anticipo;

#endregion Using

namespace CBA.FlowV2.Services.Tesoreria
{
    public class MovimientoFondoFijoDetalleService
    {
        #region GetMovimientoFondoFijoDetallesInfoCompleta
        public static DataTable GetMovimientoFondoFijoDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetMovimientoFondoFijoDetallesInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetMovimientoFondoFijoDetallesInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            if (clausulas != string.Empty)
                clausulas += " and ";
            clausulas += MovimientoFondoFijoDetalleService.VistaEstado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

            return sesion.Db.MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetMovimientoFondoFijoDetallesInfoCompleta

        #region GenerarCasosAsociados
        public static void GenerarCasosAsociados(decimal movimiento_id, SessionService sesion)
        {
            DataTable dtMovimiento = MovimientoFondoFijoService.GetMovimientoFondoFijoDataTable(MovimientoFondoFijoService.Id_NombreCol + " = " + movimiento_id, string.Empty, sesion);
            DataTable movimientosDetalles = MovimientoFondoFijoDetalleService.GetMovimientoFondoFijoDetallesInfoCompleta(MovimientoFondoFijoDetalleService.MovimientoFondoFijoId_NombreCol + "=" + movimiento_id, MovimientoFondoFijoService.Id_NombreCol);
            
            decimal vCasoId = Definiciones.Error.Valor.EnteroPositivo;
            string vCasoEstado = string.Empty;
            string mensaje;
            bool exito = false;
            string observacion = "Generado por Movimiento de Fondo Fijo caso Nro.: " + dtMovimiento.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol];
            DataTable dtAutonumeraciones = null;
            Hashtable campos = null;

            for (int i = 0; i < movimientosDetalles.Rows.Count; i++)
            {
                vCasoId = Definiciones.Error.Valor.EnteroPositivo;

                //Se genera solo si el detalle es de egreso
                if (!((decimal)movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaMontoEgresoDestino_NombreCol] > 0))
                    continue;

                //Si no tiene funcionario id no se genera el adelanto
                if (!Interprete.EsNullODBNull(movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.FuncionarioId_NombreCol]))
                {
                    if (movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.GenerarAdelantoFuncionario_NombreCol].Equals(Definiciones.SiNo.No))
                        continue;

                    dtAutonumeraciones = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO, (decimal)dtMovimiento.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol], sesion);
                    if (dtAutonumeraciones.Rows.Count < 1)
                        throw new Exception("No existe un talonario para la generación de los adelantos.");

                    campos = new Hashtable();
                    campos.Add(FuncionarioAdelantoService.FuncionarioId_NombreCol, movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaFuncionarioId_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.MonedaId_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.MonedaId_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.Cotizacion_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.CotizacionMoneda_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.Fecha_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.Fecha_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.AutonmeracionId_NombreCol, dtAutonumeraciones.Rows[0][AutonumeracionesService.Id_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.MontoSolicitado_NombreCol, movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.MontoConcedido_NombreCol, movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol]);
                    campos.Add(FuncionarioAdelantoService.Observacion_NombreCol, observacion);
                    campos.Add(FuncionarioAdelantoService.CasoOrigenId_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol]);

                    //Guardar los datos
                    exito = FuncionarioAdelantoService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);
                    if (!exito)
                        throw new Exception("Error al generar el adelanto del Funcionario" + movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaFuncionarioCodigo_NombreCol].ToString() + "-" + movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaFuncionarioNombre_NombreCol].ToString());

                    new FuncionarioAdelantoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por paso del  " + dtMovimiento.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " al estado " + Definiciones.EstadosFlujos.Aprobado + ".", sesion);
                    new FuncionarioAdelantoService().EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    new FuncionarioAdelantoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                    new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion); 
                    new FuncionarioAdelantoService().EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                    new FuncionarioAdelantoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                    new FuncionarioAdelantoService().EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                }
                else if (!Interprete.EsNullODBNull(movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.ProveedorId_NombreCol]))
                {
                    if (movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.GenerarAnticipoProveedor_NombreCol].Equals(Definiciones.SiNo.No))
                        continue;
                    
                    dtAutonumeraciones = AutonumeracionesService.GetAutonumeracionesPorFlujo2(Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR, (decimal)dtMovimiento.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol], sesion);
                    if (dtAutonumeraciones.Rows.Count < 1)
                        throw new Exception("No existe un talonario para la generación de anticipo a proveedor.");

                    campos = new Hashtable();
                    campos.Add(AnticiposProveedorService.SucursalId_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol]);
                    campos.Add(AnticiposProveedorService.ProveedorId_NombreCol, movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.ProveedorId_NombreCol]);
                    campos.Add(AnticiposProveedorService.Fecha_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.Fecha_NombreCol]);
                    campos.Add(AnticiposProveedorService.MontoTotal_NombreCol, movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.MontoEgresoDestino_NombreCol]);
                    campos.Add(AnticiposProveedorService.Observacion_NombreCol, observacion);
                    campos.Add(AnticiposProveedorService.CasoAsociadoId_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol]);
                    campos.Add(AnticiposProveedorService.MonedaId_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.MonedaId_NombreCol]);
                    campos.Add(AnticiposProveedorService.CotizacionMoneda_NombreCol, dtMovimiento.Rows[0][MovimientoFondoFijoService.CotizacionMoneda_NombreCol]);
                    campos.Add(AnticiposProveedorService.MontoRetencion_NombreCol, (decimal)0);
                    campos.Add(AnticiposProveedorService.AutonmeracionId_NombreCol, dtAutonumeraciones.Rows[0][AutonumeracionesService.Id_NombreCol]);

                    exito = AnticiposProveedorService.Guardar(campos, true, ref vCasoId, ref vCasoEstado, sesion);
                    if (!exito)
                        throw new Exception("No se pudo crear el anticipo a proveedor.");
                    new AnticiposProveedorService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, "Transición automática por paso del  " + dtMovimiento.Rows[0][MovimientoFondoFijoService.CasoId_NombreCol] + " al estado " + Definiciones.EstadosFlujos.Aprobado + ".", sesion);
                    new AnticiposProveedorService().EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    new AnticiposProveedorService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                    new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                    new AnticiposProveedorService().EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                    new AnticiposProveedorService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aplicacion, false, out mensaje, sesion);
                    new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService().ProcesarCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aplicacion, string.Empty, sesion);
                    new AnticiposProveedorService().EjecutarAccionesLuegoDeCambioEstado(vCasoId, Definiciones.EstadosFlujos.Aplicacion, sesion);
                }

                if (vCasoId != Definiciones.Error.Valor.EnteroPositivo)
                {
                    MOVIMIENTO_FONDO_FIJO_DETRow det = sesion.db.MOVIMIENTO_FONDO_FIJO_DETCollection.GetByPrimaryKey((decimal)movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.Id_NombreCol]);
                    det.COMENTARIO = "Caso creado: " + vCasoId + ". " + movimientosDetalles.Rows[i][MovimientoFondoFijoDetalleService.VistaComentario_NombreCol].ToString();
                    sesion.db.MOVIMIENTO_FONDO_FIJO_DETCollection.Update(det);
                }
            }
        }
        #endregion GenerarCasosAsociados

        #region GetSucursalesDistintas
        public static List<decimal> GetSucursalesDistintas(decimal movimiento_fondo_fijo_id, SessionService sesion)
        {
            DataTable dt = sesion.db.EjecutarQuery("select distinct " + SucursalMoviminetoId_NombreCol + " from " + Nombre_Tabla + " where " + MovimientoFondoFijoId_NombreCol + " = " + movimiento_fondo_fijo_id + " and " + SucursalMoviminetoId_NombreCol + " is not null");
            List<decimal> sucursales = new List<decimal>();
            for (int i = 0; i < dt.Rows.Count; i++)
                sucursales.Add((decimal)dt.Rows[i][SucursalMoviminetoId_NombreCol]);
            return sucursales;
        }
        #endregion GetSucursalesDistintas

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DataTable dtMovimientoFondoFijo;

                    MOVIMIENTO_FONDO_FIJO_DETRow row = new MOVIMIENTO_FONDO_FIJO_DETRow();
                    
                    row.ID = sesion.Db.GetSiguienteSecuencia("MOVIMIENTO_FONDO_FIJO_DET_SQC");
                    row.MOVIMIENTO_FONDO_FIJO_ID = (decimal)campos[MovimientoFondoFijoDetalleService.MovimientoFondoFijoId_NombreCol];
                    dtMovimientoFondoFijo = MovimientoFondoFijoService.GetMovimientoFondoFijoDataTable(MovimientoFondoFijoService.Id_NombreCol + " = " + row.MOVIMIENTO_FONDO_FIJO_ID, string.Empty);

                    row.MONEDA_ORIGEN_ID = (decimal)campos[MovimientoFondoFijoDetalleService.MonedaOrigen_NombreCol];
                    row.MONEDA_DESTINO_ID = (decimal)campos[MovimientoFondoFijoDetalleService.MonedaDestino_NombreCol];

                    row.TEXTO_PREDEFINIDO_ID = (decimal)campos[MovimientoFondoFijoDetalleService.TextoPredefinidoId_NombreCol];
                    row.TIPO_TEXTO_PREDEFINIDO_ID = (decimal)campos[MovimientoFondoFijoDetalleService.TipoTextoPredefinidoId_NombreCol];

                    row.CANTIDAD = (decimal)campos[MovimientoFondoFijoDetalleService.Cantidad_NombreCol];

                    //Se actualiza la cotizacion de la moneda
                    row.COTIZACION_ORIGEN = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol]), row.MONEDA_ORIGEN_ID, (DateTime)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.Fecha_NombreCol], sesion);
                    row.COTIZACION_DESTINO = CotizacionesService.GetCotizacionMonedaVenta(SucursalesService.GetPais((decimal)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.SucursalId_NombreCol]), row.MONEDA_DESTINO_ID, (DateTime)dtMovimientoFondoFijo.Rows[0][MovimientoFondoFijoService.Fecha_NombreCol], sesion);
                    
                    if (campos.Contains(MontoEgresoOrigen_NombreCol))
                    {
                        row.MONTO_EGRESO_ORIGEN = (decimal)campos[MovimientoFondoFijoDetalleService.MontoEgresoOrigen_NombreCol];
                        if (row.MONEDA_DESTINO_ID == row.MONEDA_ORIGEN_ID)
                            row.MONTO_EGRESO_DESTINO = row.MONTO_EGRESO_ORIGEN;
                        else
                            row.MONTO_EGRESO_DESTINO = row.MONTO_EGRESO_ORIGEN / row.COTIZACION_ORIGEN * row.COTIZACION_DESTINO;
                    }
                    else
                    {
                        row.MONTO_EGRESO_ORIGEN = 0;
                        row.MONTO_EGRESO_DESTINO = 0;
                    }

                    if (campos.Contains(MontoIngresoOrigen_NombreCol))
                    {
                        row.MONTO_INGRESO_ORIGEN = (decimal)campos[MovimientoFondoFijoDetalleService.MontoIngresoOrigen_NombreCol];
                        if (row.MONEDA_DESTINO_ID == row.MONEDA_ORIGEN_ID)
                            row.MONTO_INGRESO_DESTINO = row.MONTO_INGRESO_ORIGEN;
                        else
                            row.MONTO_INGRESO_DESTINO = row.MONTO_INGRESO_ORIGEN / row.COTIZACION_ORIGEN * row.COTIZACION_DESTINO;
                    }
                    else
                    {
                        row.MONTO_INGRESO_ORIGEN = 0;
                        row.MONTO_INGRESO_DESTINO = 0;
                    }
                   

                    row.COMENTARIO = ((string)campos[MovimientoFondoFijoDetalleService.Comentario_NombreCol]).Trim();
                    row.GENERAR_ADELANTO_FUNC = (string)campos[MovimientoFondoFijoDetalleService.GenerarAdelantoFuncionario_NombreCol];
                    row.GENERAR_ANTICIPO_PROVEEDOR = (string)campos[MovimientoFondoFijoDetalleService.GenerarAnticipoProveedor_NombreCol];

                    if (campos.Contains(MovimientoFondoFijoDetalleService.SucursalMoviminetoId_NombreCol))
                        row.SUCURSAL_MOVIMIENTO_ID = decimal.Parse(campos[MovimientoFondoFijoDetalleService.SucursalMoviminetoId_NombreCol].ToString());
                    
                    if (campos.Contains(MovimientoFondoFijoDetalleService.FuncionarioId_NombreCol))
                        row.FUNCIONARIO_ID = decimal.Parse(campos[MovimientoFondoFijoDetalleService.FuncionarioId_NombreCol].ToString());
                    
                    if (campos.Contains(MovimientoFondoFijoDetalleService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = decimal.Parse(campos[MovimientoFondoFijoDetalleService.ProveedorId_NombreCol].ToString());
                    else
                        row.IsPROVEEDOR_IDNull = true;

                    if (campos.Contains(MovimientoFondoFijoDetalleService.Estado_NombreCol))
                        row.ESTADO = campos[MovimientoFondoFijoDetalleService.Estado_NombreCol].ToString();

                    sesion.Db.MOVIMIENTO_FONDO_FIJO_DETCollection.Insert(row);
                    
                    MovimientoFondoFijoService.CalcularTotales(row.MOVIMIENTO_FONDO_FIJO_ID, sesion);

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

        #region Borrar
        /// <summary>
        /// Borrars the specified movimiento_fondo_fijo_detalle_id.
        /// </summary>
        /// <param name="egreso_vario_caja_detalle_id">The movimiento_fondo_fijo_detalle_id.</param>
        public static void BorradoLogico(decimal movimiento_fondo_fijo_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    MOVIMIENTO_FONDO_FIJO_DETRow row = sesion.db.MOVIMIENTO_FONDO_FIJO_DETCollection.GetByPrimaryKey(movimiento_fondo_fijo_detalle_id);
                    row.ESTADO = Definiciones.Estado.Inactivo;
                    sesion.Db.MOVIMIENTO_FONDO_FIJO_DETCollection.Update(row);
                    MovimientoFondoFijoService.CalcularTotales(row.MOVIMIENTO_FONDO_FIJO_ID, sesion);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        #endregion Borrar

        #region Accessors
      
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "MOVIMIENTO_FONDO_FIJO_DET"; }
        }
        public static string Id_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.CANTIDADColumnName; }
        }
        public static string MovimientoFondoFijoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MOVIMIENTO_FONDO_FIJO_IDColumnName; }
        }
        public static string Comentario_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.COMENTARIOColumnName; }
        }
        public static string CotizacionDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.COTIZACION_DESTINOColumnName; }
        }
        public static string CotizacionOrigen_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.COTIZACION_ORIGENColumnName; }
        }
        public static string GenerarAdelantoFuncionario_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.GENERAR_ADELANTO_FUNCColumnName; }
        }
        public static string GenerarAnticipoProveedor_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.GENERAR_ANTICIPO_PROVEEDORColumnName; }
        }
        public static string MonedaDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string MonedaOrigen_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoEgresoDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MONTO_EGRESO_DESTINOColumnName; }
        }
        public static string MontoEgresoOrigen_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MONTO_EGRESO_ORIGENColumnName; }
        }
        public static string MontoIngresoDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MONTO_INGRESO_DESTINOColumnName; }
        }
        public static string MontoIngresoOrigen_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MONTO_INGRESO_ORIGENColumnName; }
        }
        public static string FondoFijoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.MOVIMIENTO_FONDO_FIJO_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TipoTextoPredefinidoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.TIPO_TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string SucursalMoviminetoId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.SUCURSAL_MOVIMIENTO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.PROVEEDOR_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DETCollection.ESTADOColumnName ; }
        }
        #endregion Tabla

        #region Vista
        public static string Nombre_Vista
        {
            get { return "movimiento_fondo_fijo_det_i_c"; }
        }
        public static string VistaMonedaDestinoNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.MONEDA_DESTINOColumnName; }
        }
        public static string VistaMonedaOrigenNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.MONEDA_ORIGENColumnName; }
        }
        public static string VistaMonedaSimboloOrigen_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.SIMBOLO_ORIGENColumnName; }
        }
        public static string VistaMonedaSimboloDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.SIMBOLO_DESTINOColumnName; }
        }
        public static string VistaTextoPredefinidoNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.TEXTO_PREDEFINIDOColumnName; }
        }
        public static string VistaTipoTextoPredefinidoNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.TIPO_TEXTO_PREDEFINIDOColumnName; }
        }
        public static string VistaMontoTotalOrigen_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.MONTO_TOTAL_ORIGENColumnName; }
        }
        public static string VistaCantidad_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.CANTIDADColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.SUCURSAL_MOVIMIENTO_NOMBREColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.SUCURSAL_MOVIMIENTO_ABREColumnName; }
        }
        public static string VistaProveedorNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaProveedorCodigo_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.PROVEEDOR_CODIGOColumnName; }
        }
        public static string VistaFuncionarioId_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaEstado_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.ESTADOColumnName; }
        }
        public static string VistaMontoEgresoDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.MONTO_EGRESO_DESTINOColumnName; }
        }
        public static string VistaMontoIngresoDestino_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.MONTO_INGRESO_DESTINOColumnName; }
        }
        public static string VistaComentario_NombreCol
        {
            get { return MOVIMIENTO_FONDO_FIJO_DET_I_CCollection.COMENTARIOColumnName; }
        }

        #endregion Vista

        #endregion Accessors
    }
}




