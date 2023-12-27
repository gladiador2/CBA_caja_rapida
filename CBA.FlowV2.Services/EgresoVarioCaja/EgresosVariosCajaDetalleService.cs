using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;

using CBA.FlowV2.Services.Base;
using System.Collections.Generic;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.EgresosVariosCaja
{
    public class EgresosVariosCajaDetalleService
    {
        #region Sub clase propiedades detalle
        [Serializable]
        public class PropiedadesDetalle
        {
            public decimal EgresoVarioCajaId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CtacteProveedorId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CtactePersonaId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal MonedaOrigenId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal CotizacionCompraOrigen = Definiciones.Error.Valor.EnteroPositivo;
            public decimal MontoOrigen = Definiciones.Error.Valor.EnteroPositivo;
            public decimal MontoDestino = Definiciones.Error.Valor.EnteroPositivo;
            public string Observacion = string.Empty;
            public decimal ProveedorId = Definiciones.Error.Valor.EnteroPositivo;
            public decimal PersonaId = Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion Sub clase propiedades detalle

        #region GetEgresosVariosCajaDetallesDataTable
        /// <summary>
        /// Gets the egresos varios caja detalles data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEgresosVariosCajaDetallesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEgresosVariosCajaDetallesDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetEgresosVariosCajaDetallesDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetEgresosVariosCajaDetallesDataTable

        #region GetEgresosVariosCajaDetallesInfoCompleta
        /// <summary>
        /// Gets the egresos varios caja detalles info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEgresosVariosCajaDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEgresosVariosCajaDetallesInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetEgresosVariosCajaDetallesInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.EGRESOS_VARIOS_CAJA_DET_INF_CCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetEgresosVariosCajaDetallesInfoCompleta

        #region GetTotal
        public static decimal GetTotal(decimal egreso_vario_caja_id, SessionService sesion)
        {
            decimal total = 0;
            EGRESOS_VARIOS_CAJA_DETRow[] rows = sesion.db.EGRESOS_VARIOS_CAJA_DETCollection.GetByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id);
            for (int i = 0; i < rows.Length; i++)
                total += rows[i].MONTO_DESTINO;
            return total;
        }
        #endregion GetTotal

        #region GetCasosIncluidos
        public static List<decimal> GetCasosIncluidos(decimal caso_id, SessionService sesion)
        {
            List<decimal> lCasos = new List<decimal>();
            DataTable dtCabecera = EgresosVariosCajaService.GetEgresosVariosCajaDataTable(EgresosVariosCajaService.CasoId_NombreCol + " = " + caso_id, string.Empty, sesion);
            DataTable dtDetalles = GetEgresosVariosCajaDetallesInfoCompleta(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol + " = " + dtCabecera.Rows[0][EgresosVariosCajaService.Id_NombreCol], string.Empty, sesion);
            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                if (!Interprete.EsNullODBNull(dtDetalles.Rows[i][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol]))
                    lCasos.Add((decimal)dtDetalles.Rows[i][EgresosVariosCajaDetalleService.VistaCasoReferidoId_NombreCol]);
            }
            return lCasos;
        }
        #endregion GetCasosIncluidos

        #region CrearDetalle
        public static bool CrearDetalleProveedor(decimal egreso_vario_caja_id, decimal ctacte_proveedor_id, decimal moneda_origen_id, decimal cotizacion_compra_origen, decimal monto_origen, decimal monto_destino, string observacion, decimal proveedor_id, SessionService sesion)
        {
            EgresosVariosCajaDetalleService.PropiedadesDetalle egresoVariosCajaDetalleService;
            egresoVariosCajaDetalleService = new EgresosVariosCajaDetalleService.PropiedadesDetalle();

            egresoVariosCajaDetalleService.CotizacionCompraOrigen = cotizacion_compra_origen;
            egresoVariosCajaDetalleService.CtacteProveedorId = ctacte_proveedor_id;
            egresoVariosCajaDetalleService.EgresoVarioCajaId = egreso_vario_caja_id;
            egresoVariosCajaDetalleService.MonedaOrigenId = moneda_origen_id;
            egresoVariosCajaDetalleService.MontoDestino = monto_destino;
            egresoVariosCajaDetalleService.MontoOrigen = monto_origen;
            egresoVariosCajaDetalleService.Observacion = observacion;
            egresoVariosCajaDetalleService.ProveedorId = proveedor_id;

            return EgresosVariosCajaDetalleService.Crear(egresoVariosCajaDetalleService, sesion);
        }

        public static bool CrearDetallePersona(decimal egreso_vario_caja_id, decimal ctacte_persona_id, decimal moneda_origen_id, decimal cotizacion_compra_origen, decimal monto_origen, decimal monto_destino, string observacion, decimal persona_id, SessionService sesion)
        {
            EgresosVariosCajaDetalleService.PropiedadesDetalle egresoVariosCajaDetalleService;
            egresoVariosCajaDetalleService = new EgresosVariosCajaDetalleService.PropiedadesDetalle();

            egresoVariosCajaDetalleService.CotizacionCompraOrigen = cotizacion_compra_origen;
            egresoVariosCajaDetalleService.CtactePersonaId = ctacte_persona_id;
            egresoVariosCajaDetalleService.EgresoVarioCajaId = egreso_vario_caja_id;
            egresoVariosCajaDetalleService.MonedaOrigenId = moneda_origen_id;
            egresoVariosCajaDetalleService.MontoDestino = monto_destino;
            egresoVariosCajaDetalleService.MontoOrigen = monto_origen;
            egresoVariosCajaDetalleService.Observacion = observacion;
            egresoVariosCajaDetalleService.PersonaId = persona_id;

            return EgresosVariosCajaDetalleService.Crear(egresoVariosCajaDetalleService, sesion);
        }
        #endregion CrearDetalle

        #region Crear
        public static bool Crear(PropiedadesDetalle detalle, SessionService sesion)
        {
            try
            {
                string estadoId = Definiciones.Error.Valor.EnteroPositivo.ToString();
                System.Collections.Hashtable campos = new System.Collections.Hashtable();

                #region Detalle
                campos.Add(EgresosVariosCajaDetalleService.CotizacionCompraOrigen_NombreCol, detalle.CotizacionCompraOrigen);
                campos.Add(EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol, detalle.EgresoVarioCajaId);
                campos.Add(EgresosVariosCajaDetalleService.MonedaOrigenId_NombreCol, detalle.MonedaOrigenId);
                campos.Add(EgresosVariosCajaDetalleService.MontoDestino_NombreCol, detalle.MontoDestino);
                campos.Add(EgresosVariosCajaDetalleService.MontoOrigen_NombreCol, detalle.MontoOrigen);
                campos.Add(EgresosVariosCajaDetalleService.Observacion_NombreCol, detalle.Observacion);

                if (detalle.CtacteProveedorId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol, detalle.CtacteProveedorId);
                if (detalle.ProveedorId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(EgresosVariosCajaDetalleService.ProveedorId_NombreCol, detalle.ProveedorId);
                if (detalle.CtactePersonaId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(EgresosVariosCajaDetalleService.CtactePersonaId_NombreCol, detalle.CtactePersonaId);
                if (detalle.PersonaId != Definiciones.Error.Valor.EnteroPositivo)
                    campos.Add(EgresosVariosCajaDetalleService.PersonaId_NombreCol, detalle.PersonaId);

                return EgresosVariosCajaDetalleService.Guardar(campos, sesion);
                #endregion Detalle
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Crear

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        public static void Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                Guardar(campos, sesion);
            }
        }

        public static bool Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            bool exito = false;
            try
            {
                DataTable dtCabecera = EgresosVariosCajaService.GetEgresosVariosCajaDataTable(EgresosVariosCajaService.Id_NombreCol + " = " + campos[EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol], string.Empty, sesion);
                SucursalesService sucursal = new SucursalesService((decimal)dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol], sesion);
                EGRESOS_VARIOS_CAJA_DETRow row = new EGRESOS_VARIOS_CAJA_DETRow();
                string valorAnterior = Definiciones.Log.RegistroNuevo;

                if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.RegionCtacteIndependiente, sesion) == Definiciones.SiNo.Si)
                {
                    if (campos.Contains(EgresosVariosCajaDetalleService.CtactePersonaId_NombreCol))
                    {
                        var ctactePersona = new CuentaCorrientePersonasService((decimal)campos[EgresosVariosCajaDetalleService.CtactePersonaId_NombreCol], sesion);
                        if (!ctactePersona.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");
                        if (ctactePersona.CasoId.HasValue && ctactePersona.Caso.Sucursal.RegionId != sucursal.RegionId)
                            throw new Exception("El documento proviene de una región distinta al caso.");
                    }

                    if (campos.Contains(EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol))
                    {
                        var ctacteProveedor = new CuentaCorrienteProveedoresService((decimal)campos[EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol], sesion);
                        if (!ctacteProveedor.ExisteEnDB)
                            throw new System.Exception("El documento no fue encontrado.");
                        if (ctacteProveedor.CasoId.HasValue && ctacteProveedor.Caso.Sucursal.RegionId != sucursal.RegionId)
                            throw new Exception("El documento proviene de una región distinta al caso.");
                    }
                }

                row.ID = sesion.Db.GetSiguienteSecuencia("egresos_varios_caja_det_sqc");
                row.EGRESO_VARIO_CAJA_ID = (decimal)campos[EgresosVariosCajaDetalleService.EgresoVarioCajaId_NombreCol];

                if(campos.Contains(EgresosVariosCajaDetalleService.ProveedorId_NombreCol))
                {
                    if (!ProveedoresService.EstaActivo((decimal)campos[EgresosVariosCajaDetalleService.ProveedorId_NombreCol]))
                        throw new Exception("El proveedor no está activo.");
                    row.PROVEEDOR_ID = (decimal)campos[EgresosVariosCajaDetalleService.ProveedorId_NombreCol];
                }

                if (campos.Contains(EgresosVariosCajaDetalleService.PersonaId_NombreCol))
                {
                    if (!PersonasService.EstaActivo((decimal)campos[EgresosVariosCajaDetalleService.PersonaId_NombreCol]))
                        throw new Exception(Traducciones.La_persona_esta_inactiva);
                    row.PERSONA_ID = (decimal)campos[EgresosVariosCajaDetalleService.PersonaId_NombreCol];
                }

                if (campos.Contains(EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol))
                    row.CTACTE_PROVEEDOR_ID = (decimal)campos[EgresosVariosCajaDetalleService.CtacteProveedorId_NombreCol];
                if (campos.Contains(EgresosVariosCajaDetalleService.CtactePersonaId_NombreCol))
                    row.CTACTE_PERSONA_ID = (decimal)campos[EgresosVariosCajaDetalleService.CtactePersonaId_NombreCol];

                row.MONEDA_ORIGEN_ID = (decimal)campos[EgresosVariosCajaDetalleService.MonedaOrigenId_NombreCol];

                //Se actualiza la cotizacion de la moneda
                row.COTIZACION_COMPRA_ORIGEN = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais((decimal)dtCabecera.Rows[0][EgresosVariosCajaService.SucursalId_NombreCol]), row.MONEDA_ORIGEN_ID, (DateTime)dtCabecera.Rows[0][EgresosVariosCajaService.Fecha_NombreCol], sesion);
                if (row.COTIZACION_COMPRA_ORIGEN.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    throw new Exception("Debe actualizarse la cotización de la moneda origen.");

                row.MONTO_ORIGEN = (decimal)campos[EgresosVariosCajaDetalleService.MontoOrigen_NombreCol];

                //Solo se realiza la conversión si las monedas son distintas
                if (row.MONEDA_ORIGEN_ID != (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.MonedaId_NombreCol])
                    row.MONTO_DESTINO = row.MONTO_ORIGEN / row.COTIZACION_COMPRA_ORIGEN * (decimal)dtCabecera.Rows[0][EgresosVariosCajaService.CotizacionMoneda_NombreCol];
                else
                    row.MONTO_DESTINO = row.MONTO_ORIGEN;

                row.OBSERVACION = (string)campos[EgresosVariosCajaDetalleService.Observacion_NombreCol];

                sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                if (!row.IsPROVEEDOR_IDNull)
                {
                    //Verificar si debe retenerse e incluir en forma
                    //automatica las retenciones como parte de los valores                   
                    RetenerSiCorresponde(row.EGRESO_VARIO_CAJA_ID, row.PROVEEDOR_ID, sesion);
                }

                EgresosVariosCajaService.CalcularTotales(row.EGRESO_VARIO_CAJA_ID, sesion);

                exito = true;
            }
            catch (Exception)
            {
                exito = false;

                throw;
            }

            return exito;
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified egreso_vario_caja_detalle_id.
        /// </summary>
        /// <param name="egreso_vario_caja_detalle_id">The egreso_vario_caja_detalle_id.</param>
        public static void Borrar(decimal egreso_vario_caja_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(egreso_vario_caja_detalle_id, sesion);
            }
        }

        public static void Borrar(decimal egreso_vario_caja_detalle_id, SessionService sesion)
        {
            EGRESOS_VARIOS_CAJA_DETRow row = sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.GetByPrimaryKey(egreso_vario_caja_detalle_id);

            sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.DeleteByPrimaryKey(egreso_vario_caja_detalle_id);
            EgresosVariosCajaService.CalcularTotales(row.EGRESO_VARIO_CAJA_ID, sesion);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

            if (!row.IsPROVEEDOR_IDNull)
            {
                //Verificar si debe retenerse e incluir en forma
                //automatica las retenciones como parte de los valores
                RetenerSiCorresponde(row.EGRESO_VARIO_CAJA_ID, row.PROVEEDOR_ID, sesion);
            }
        }
        #endregion borrar

        #region RetenerSiCorresponde
        private static void RetenerSiCorresponde(decimal egreso_vario_caja_id, decimal proveedor_id, SessionService sesion)
        {
            string clausulas;
            DataTable dtEgresoVario = EgresosVariosCajaService.GetEgresosVariosCajaDataTable(EgresosVariosCajaService.Id_NombreCol + " = " + egreso_vario_caja_id, string.Empty, sesion);
            DataTable dtEgresoVarioValores;
            string[] strAux;
            decimal decimalAux;

            clausulas = EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol + " = " + egreso_vario_caja_id + " and " + 
                        EgresosVariosCajaValoresService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.RetencionIVA + " and " +
                        EgresosVariosCajaValoresService.RetencionProveedorId_NombreCol + " = " + proveedor_id;
            dtEgresoVarioValores = EgresosVariosCajaValoresService.GetDataTable(clausulas, string.Empty, sesion);

            // Se borran los valores de retencion
            for (int i = 0; i < dtEgresoVarioValores.Rows.Count; i++)
                EgresosVariosCajaValoresService.Borrar((decimal)dtEgresoVarioValores.Rows[i][EgresosVariosCajaValoresService.Id_NombreCol], sesion);             

            List<Hashtable> lRetencionesAEmitir = new List<Hashtable>();

            if (!ProveedoresService.EsPasibleRetencion(proveedor_id, DateTime.Parse(dtEgresoVario.Rows[0][EgresosVariosCajaService.Fecha_NombreCol].ToString())))
            {
                lRetencionesAEmitir = CuentaCorrienteRetencionesEmitidasService.GetRetencionesAEmitir(
                                                        (decimal)dtEgresoVario.Rows[0][EgresosVariosCajaService.CasoId_NombreCol],
                                                        proveedor_id,
                                                        Interprete.EsNullODBNull(dtEgresoVario.Rows[0][EgresosVariosCajaService.FechaReciboBeneficiario_NombreCol]) ? (DateTime)dtEgresoVario.Rows[0][EgresosVariosCajaService.Fecha_NombreCol] : (DateTime)dtEgresoVario.Rows[0][EgresosVariosCajaService.FechaReciboBeneficiario_NombreCol],
                                                        (string)dtEgresoVario.Rows[0][EgresosVariosCajaService.RetencionUnificada_NombreCol] == Definiciones.SiNo.Si,
                                                        sesion);
            }

            foreach (Hashtable ht in lRetencionesAEmitir)
            {
                DataTable dtTiposRetenciones = TiposRetencionesService.GetTiposRetencionesDataTable(TiposRetencionesService.Id_NombreCol + " = " + ht[CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol], string.Empty);

                Hashtable campos = new System.Collections.Hashtable();
                campos.Add(EgresosVariosCajaValoresService.EgresoVarioCajaId_NombreCol, dtEgresoVario.Rows[0][EgresosVariosCajaService.Id_NombreCol]);
                campos.Add(EgresosVariosCajaValoresService.RetencionProveedorId_NombreCol, proveedor_id);
                campos.Add(EgresosVariosCajaValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.RetencionIVA);
                campos.Add(EgresosVariosCajaValoresService.RetencionTipoId_NombreCol, ht[CuentaCorrienteRetencionesEmitidasDetalleService.RetencionTipoId_NombreCol]);

                strAux = ht[CuentaCorrienteRetencionesEmitidasService.MonedaId_NombreCol].ToString().Split('@');
                campos.Add(EgresosVariosCajaValoresService.MonedaOrigenId_NombreCol, decimal.Parse(strAux[0]));

                //Si las monedas son distintas el total es incorrecto. Nadie deberia mezclar monedas en la 
                //misma retencion, por proteccion se sugiere sumar los detalles en vez de tomar el total de la cabecera
                strAux = ht[CuentaCorrienteRetencionesEmitidasService.Total_NombreCol].ToString().Split('@');
                decimalAux = 0;
                for (int i = 0; i < strAux.Length; i++)
                    decimalAux += decimal.Parse(strAux[i]);
                campos.Add(EgresosVariosCajaValoresService.MontoOrigen_NombreCol, decimalAux);

                campos.Add(EgresosVariosCajaValoresService.Observacion_NombreCol, ht[CuentaCorrienteRetencionesEmitidasService.Observacion_NombreCol]);
                campos.Add(EgresosVariosCajaValoresService.RetencionAuxCasos_NombreCol, ht[CuentaCorrienteRetencionesEmitidasDetalleService.CasoId_NombreCol]);
                campos.Add(EgresosVariosCajaValoresService.RetencionAuxMontos_NombreCol, ht[CuentaCorrienteRetencionesEmitidasService.Total_NombreCol]);
                campos.Add(EgresosVariosCajaValoresService.RetencionFecha_NombreCol, ht[CuentaCorrienteRetencionesEmitidasService.Fecha_NombreCol]);
                EgresosVariosCajaValoresService.Guardar(campos, sesion);
            }
        }
        #endregion RetenerSiCorresponde

        #region Actualizar Estado
        public static void ActualizarEstado(decimal egreso_vario_caja_det_id, string estado)
        {
            using (SessionService sesion = new SessionService())
            {
                ActualizarEstado(egreso_vario_caja_det_id, estado, sesion);
            }
        }
        public static void ActualizarEstado(decimal egreso_vario_caja_det_id, string estado, SessionService sesion)
        {
            EGRESOS_VARIOS_CAJA_DETRow row = sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.GetByPrimaryKey(egreso_vario_caja_det_id);
            string valorAnterior = row.ToString(); ;

            //row.ESTADO = estado;

            sesion.Db.EGRESOS_VARIOS_CAJA_DETCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Actualizar Estado

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "EGRESOS_VARIOS_CAJA_DET"; }
        }
        public static string Nombre_Vista
        {
            get { return "EGRESOS_VARIOS_CAJA_DET_INF_C"; }
        }
        public static string CotizacionCompraOrigen_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.COTIZACION_COMPRA_ORIGENColumnName; }
        }
        public static string CtactePersonaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string CtacteProveedorId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.CTACTE_PROVEEDOR_IDColumnName; }
        }
        public static string EgresoVarioCajaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.EGRESO_VARIO_CAJA_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.IDColumnName; }
        }
        public static string MonedaOrigenId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.MONEDA_ORIGEN_IDColumnName; }
        }
        public static string MontoDestino_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.MONTO_DESTINOColumnName; }
        }
        public static string MontoOrigen_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.MONTO_ORIGENColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.PERSONA_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.PROVEEDOR_IDColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DETCollection.OBSERVACIONColumnName; }
        }
        public static string VistaCasoReferidoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DET_INF_CCollection.CASO_REFERIDO_IDColumnName; }
        }
        public static string VistaCtacteObservacion_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DET_INF_CCollection.CTACTE_OBSERVACIONColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DET_INF_CCollection.FLUJO_IDColumnName; }
        }
        public static string VistaMonedaOrigenSimbolo_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DET_INF_CCollection.MONEDA_ORIGEN_SIMBOLOColumnName; }
        }
        public static string VistaInvolucradoNombre_NombreCol
        {
            get { return EGRESOS_VARIOS_CAJA_DET_INF_CCollection.INVOLUCRADO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
