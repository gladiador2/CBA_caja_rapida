using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public static class LogCambiosService
    {
        public static string Nombre_Tabla = "LOG_CAMBIOS";

        public static string Id_NombreCol
        {
            get { return LOG_CAMBIOSCollection.IDColumnName; }
        }
        public static string CampoId_NombreCol
        {
            get { return LOG_CAMBIOSCollection.LOG_CAMPO_IDColumnName; }
        }
        public static string RegistroId_NombreCol
        {
            get { return LOG_CAMBIOSCollection.REGISTRO_IDColumnName; }
        }
        public static string ValorAnterior_NombreCol
        {
            get { return LOG_CAMBIOSCollection.VALOR_ANTERIORColumnName; }
        }
        public static string ValorNuevo_NombreCol
        {
            get { return LOG_CAMBIOSCollection.VALOR_NUEVOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return LOG_CAMBIOSCollection.FECHAColumnName; }
        }
        public static string Ip_NombreCol
        {
            get { return LOG_CAMBIOSCollection.IPColumnName; }
        }
        public static string FechaFormatoNumero_NombreCol
        {
            get { return LOG_CAMBIOSCollection.FECHA_FORMATO_NUMEROColumnName; }
        }

        public static bool LogDeColumna(String tabla, String columna, Decimal registro_id, String valorAnterior, String valorNuevo, SessionService sesion)
        {
            try{
                LOG_CAMPOSRow campo = sesion.Db.LOG_CAMPOSCollection.GetRow("upper(tabla_id)='"+tabla.ToUpper()+"' and upper(campo_id)='"+columna.ToUpper()+"'");
                LOG_CAMBIOSRow cambio = new LOG_CAMBIOSRow();

                cambio.ID = sesion.Db.GetSiguienteSecuencia("log_cambios_sqc");
                cambio.LOG_CAMPO_ID = Decimal.Parse(campo.ID.ToString());
                cambio.FECHA = System.DateTime.Now;
                cambio.IP = SessionService.GetClienteIP();
                cambio.USUARIO_ID = Decimal.Parse(sesion.Usuario_Id.ToString());
                cambio.VALOR_NUEVO = valorNuevo;
                cambio.VALOR_ANTERIOR = valorAnterior;
                cambio.REGISTRO_ID = registro_id;
                
                sesion.Db.LOG_CAMBIOSCollection.Insert(cambio);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool LogDeRegistroJSON(string tabla, decimal registro_id, object anterior, object actual, SessionService sesion)
        {
            string valorAnterior = Definiciones.Log.RegistroNuevo;
            string valorActual = Definiciones.Log.RegistroBorrado;

            if (anterior != null)
                valorAnterior = JsonUtil.Serializar(anterior);
            if (actual != null)
                valorActual = JsonUtil.Serializar(actual);

            return LogDeRegistro(tabla, registro_id, valorAnterior, valorActual, sesion);
        }

        public static bool LogDeRegistro(string tabla, decimal registro_id, string valorAnterior, string valorNuevo, SessionService sesion)
        {
            try
            {
                LOG_CAMPOSRow campo = sesion.Db.LOG_CAMPOSCollection.GetRow("upper(tabla_id)='" + tabla.ToUpper() + "' and campo_id is null");
                LOG_CAMBIOSRow cambio = new LOG_CAMBIOSRow();

                if(valorAnterior.Equals(Definiciones.Log.RegistroNuevo))
                {
                    decimal casoId = Definiciones.Error.Valor.EnteroPositivo;

                    #region evaluar seguimientos automaticos
                    //Si es un registro nuevo de alguna cabecera de flujo
                    //se evaluan los seguimientos automaticos por flujo y estado destino
                    if (CBA.FlowV2.Services.Stock.StockAjusteService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.STOCK_AJUSTECollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if(CBA.FlowV2.Services.Anticipo.AnticiposProveedorService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.ANTICIPOS_PROVEEDORCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Anticipo.AnticiposPersonaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.ANTICIPOS_PERSONACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.CambiosDivisaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CAMBIOS_DIVISACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.CustodiaValoresService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CUSTODIA_VALORESCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.DepositosBancariosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.DEPOSITOS_BANCARIOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.DescuentoDocumentosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.DESCUENTO_DOCUMENTOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.EgresosVariosCaja.EgresosVariosCajaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.EGRESOS_VARIOS_CAJACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.FacturasClienteService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.FACTURAS_CLIENTECollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.FacturasProveedorService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.FACTURAS_PROVEEDORCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.MovimientoVarioCajaTesoreriaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.MOVIMIENTOS_VARIOS_TESOCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.NotasCreditoPersona.NotasCreditoPersonaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.NOTAS_CREDITO_PERSONASCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.NotaCreditosProveedores.NotasCreditoProveedorService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.NOTAS_CREDITO_PROVEEDORESCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.NotasDebitoProveedor.NotasDebitoProveedorService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.NOTA_DEBITO_PROVEEDORCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.NotasDebitoPersona.NotasDebitoPersonaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.NOTA_DEBITO_PERSONACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.NotasDePedidosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.PEDIDOS_CLIENTECollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.OrdenesPagoService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.ORDENES_PAGOCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.RemisionesService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.REMISIONESCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.RepartosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.REPARTOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.TransferenciasBancariasService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.TRANSFERENCIAS_BANCARIASCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Stock.StockTransferenciasService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.STOCK_TRANSFERENCIACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.RecursosHumanos.AsignacionCargosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.ASIGNACIONES_CARGOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.RecursosHumanos.EncuestasService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.ENCUESTASCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.RecursosHumanos.SugerenciasService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.SUGERENCIASCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Herramientas.UsuariosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.USUARIOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.AjustesBancariosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.AJUSTES_BANCARIOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.TransferenciasCajasTesoreriaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.TRANSFERENCIAS_TESORERIACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Presupuestos.PresupuestosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.PRESUPUESTOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Contratos.ContratosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CONTRATOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.RecursosHumanos.FuncionarioAdelantoService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.FUNCIONARIOS_ADELANTOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.RecursosHumanos.PlanillaLiquidacionesService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.PLANILLA_LIQUIDACIONESCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.PagosDePersonaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CTACTE_PAGOS_PERSONACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Stock.IngresoStockService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.INGRESO_STOCKCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Stock.UsoDeInsumosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.USO_DE_INSUMOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Stock.StockInventarioService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.STOCK_INVENTARIOCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.ListaDePrecio.ListaDePreciosModificarService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.LISTA_PRECIOS_MODIFICARCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.CreditosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CREDITOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.TransferenciasCtaCtePersonasService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.TRANSFERENCIA_CTACTE_PERSONACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.PlanillaCobranzaService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.PLANILLA_COBRANZACollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.CreditosProveedorService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CREDITOS_PROVEEDORCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.CanjesValoresService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.CANJES_VALORESCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.DescuentoDocumentosClienteService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.DESCUENTO_DOCUMENTOS_CLIENTECollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.OrdenesServicioService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.ORDENES_SERVICIOCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tramites.TramitesService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.TRAMITESCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Facturacion.PlanesFacturacionService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.PLANES_FACTURACIONCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Giros.DesembolsosGirosService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.DESEMBOLSOS_GIROSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Tesoreria.TransferenciaCajasSucursalService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.TRANSFERENCIA_CAJAS_SUCURSALCollection.GetByPrimaryKey(registro_id).CASO_ID;
                    else if (CBA.FlowV2.Services.Herramientas.UsuarioDepositoService.Nombre_Tabla.Equals(tabla))
                        casoId = sesion.Db.USUARIOSCollection.GetByPrimaryKey(registro_id).CASO_ID;

                    if(!casoId.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        SeguimientosAutomaticosService.Evaluar(casoId, Definiciones.EstadosFlujos.Borrador, sesion);
                    #endregion evaluar seguimientos automaticos
                }
                else
                {
                    //Si se modificaron datos se evalua el seguimiento
                    if (!valorAnterior.Equals(valorNuevo))
                    {
                        decimal casoId;

                        if(CBA.FlowV2.Services.Facturacion.CreditosService.Nombre_Tabla.Equals(tabla))
                        {
                            casoId = sesion.Db.CREDITOSCollection.GetByPrimaryKey(registro_id).CASO_ID;
                            SeguimientosDestinatariosService.Evaluar(casoId, string.Empty, string.Empty, Definiciones.Error.Valor.EnteroPositivo, sesion);
                        }
                    }
                }

                cambio.ID = sesion.Db.GetSiguienteSecuencia("log_cambios_sqc");
                
                cambio.LOG_CAMPO_ID = campo.ID;
                cambio.FECHA = System.DateTime.Now;
                cambio.IP = SessionService.GetClienteIP();
                cambio.USUARIO_ID = sesion.Usuario_Id;
                cambio.VALOR_NUEVO = valorNuevo;
                cambio.VALOR_ANTERIOR = valorAnterior;
                cambio.REGISTRO_ID = registro_id;

                sesion.Db.LOG_CAMBIOSCollection.Insert(cambio);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static DataTable GetLogCambiosDataTable(string tabla,decimal registro_id,bool usar_desde,DateTime fecha_desde,bool usar_hasta,DateTime fecha_hasta, SessionService sesion)
       {
            LOG_CAMPOSRow campo = sesion.Db.LOG_CAMPOSCollection.GetRow("upper(tabla_id)='" + tabla.ToUpper() + "' and campo_id is null");
            if(campo==null)
                throw new Exception("Tabla no encontrada.");

            string where = "select lg." + LogCambiosService.Id_NombreCol + ", lg." + LogCambiosService.ValorAnterior_NombreCol + ", lg." + LogCambiosService.ValorNuevo_NombreCol + ", u." + UsuariosService.Usuario_NombreCol + ", lg." + LogCambiosService.Fecha_NombreCol + ",lg." + LogCambiosService.Ip_NombreCol;
            where += " from " + LogCambiosService .Nombre_Tabla+ " lg, "+UsuariosService.Nombre_Tabla+" u ";
                   where +="where u.id = lg.usuario_id" ;
                where +=" and lg."+LogCambiosService.CampoId_NombreCol+"="+campo.ID;
             where += " and lg."+LogCambiosService.RegistroId_NombreCol+"="+registro_id;
            if(usar_desde)
                where += " and lg." + LogCambiosService.FechaFormatoNumero_NombreCol + ">=" + fecha_desde.ToString("yyyyMMdd");
            if (usar_hasta)
                where += " and lg." + LogCambiosService.FechaFormatoNumero_NombreCol + "<=" + fecha_hasta.ToString("yyyyMMdd");
            where+=" order by "+LogCambiosService.Fecha_NombreCol;
            DataTable dtLogCambios = sesion.db.EjecutarQuery(where);
             return dtLogCambios;

        }
        public static DataTable GetLogCambiosDataTable(string tabla, decimal registro_id, bool usar_desde, DateTime fecha_desde, bool usar_hasta, DateTime fecha_hasta)
        {
            using(SessionService sesion = new SessionService())
            {
                return GetLogCambiosDataTable(tabla, registro_id, usar_desde, fecha_desde, usar_hasta, fecha_hasta, sesion);
            }
        }

        public static DataTable GetDiferenciasDataTable(string valor_anterior, string valor_nuevo)
        {
            DataTable dtResultado = new DataTable();
            string[] separadorCampos = new string[] {"@CBA@"};
            string separadorDatos = "=";

            string[] valorAnteriorCampos = valor_anterior.Split(separadorCampos, StringSplitOptions.None);
               
            string[] valorNuevoCampos = valor_nuevo.Split(separadorCampos, StringSplitOptions.None);

            Dictionary<string, string> valoresAnteriores = new Dictionary<string, string>();
            Dictionary<string, string> valoresNuevos = new Dictionary<string, string>();
            #region Valores Anteriores
            if (!valor_anterior.Equals(Definiciones.Log.RegistroNuevo))
            {
                for (int i = 0; i < valorAnteriorCampos.Length; i++)
                {
                    string[] datosAnteriores = valorAnteriorCampos[i].Split(separadorDatos.ToCharArray());
                    if (datosAnteriores.Length == 0)
                        continue;
                    if (datosAnteriores.Length == 1)
                        valoresAnteriores.Add(datosAnteriores[0], string.Empty);
                    if (datosAnteriores.Length == 2)
                        valoresAnteriores.Add(datosAnteriores[0], datosAnteriores[1]);
                    if (datosAnteriores.Length > 2)
                    {
                        string dato = string.Empty;
                        for (int j = 1; j < datosAnteriores.Length; j++)
                        {
                            dato += " " + datosAnteriores[j];
                        }
                        valoresAnteriores.Add(datosAnteriores[0], dato);
                    }
                   
                }
            }
            #endregion Valores Anteriores

            #region Valores Nuevos
            if (!valor_nuevo.Equals(Definiciones.Log.RegistroBorrado))
            {
                for (int i = 0; i < valorNuevoCampos.Length; i++)
                {
                    string[] datosNuevos = valorNuevoCampos[i].Split(separadorDatos.ToCharArray());
                    if (datosNuevos.Length == 0)
                        continue;
                    if (datosNuevos.Length == 1)
                        valoresNuevos.Add(datosNuevos[0], string.Empty);
                    if (datosNuevos.Length == 2)
                        valoresNuevos.Add(datosNuevos[0], datosNuevos[1]);
                    if (datosNuevos.Length > 2)
                    {
                        string dato = string.Empty;
                        for (int j = 1; j < datosNuevos.Length; j++)
                        {
                            dato += " " + datosNuevos[j];
                        }
                        valoresNuevos.Add(datosNuevos[0], dato);
                    }
                }
            }
            #endregion Valores Nuevos

            #region Comparaciones
            if (valor_anterior.Equals(Definiciones.Log.RegistroNuevo) && !valor_nuevo.Equals(Definiciones.Log.RegistroBorrado))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(LogCambiosService.CampoId_NombreCol);
                dt.Columns.Add(LogCambiosService.ValorNuevo_NombreCol);
                //for(int i=0; iz)
                foreach (KeyValuePair<string, string> item in valoresNuevos)
                {
                    DataRow dr = dt.NewRow();
                    dr[LogCambiosService.CampoId_NombreCol]=item.Key;
                    dr[LogCambiosService.ValorNuevo_NombreCol] = item.Value;
                    dt.Rows.Add(dr);
                }
                dtResultado = dt;
            }

            if (valor_nuevo.Equals(Definiciones.Log.RegistroBorrado)&& !valor_anterior.Equals(Definiciones.Log.RegistroNuevo))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(LogCambiosService.CampoId_NombreCol);
                dt.Columns.Add(LogCambiosService.ValorAnterior_NombreCol);
                //for(int i=0; iz)
                foreach (KeyValuePair<string, string> item in valoresAnteriores)
                {
                    DataRow dr = dt.NewRow();
                    dr[LogCambiosService.CampoId_NombreCol] = item.Key;
                    dr[LogCambiosService.ValorAnterior_NombreCol] = item.Value;
                    dt.Rows.Add(dr);
                }
                dtResultado = dt;
            }

            if (!valor_nuevo.Equals(Definiciones.Log.RegistroBorrado) && !valor_anterior.Equals(Definiciones.Log.RegistroNuevo))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(LogCambiosService.CampoId_NombreCol);
                dt.Columns.Add(LogCambiosService.ValorAnterior_NombreCol);
                dt.Columns.Add(LogCambiosService.ValorNuevo_NombreCol);
                foreach (KeyValuePair<string, string> item in valoresAnteriores)
                {
                    if (valoresNuevos.ContainsKey(item.Key))
                    {
                        string dato = string.Empty;
                        valoresNuevos.TryGetValue(item.Key, out dato);
                        if (!item.Value.Equals(dato))
                        {
                            DataRow dr = dt.NewRow();
                            dr[LogCambiosService.CampoId_NombreCol] = item.Key;
                            dr[LogCambiosService.ValorAnterior_NombreCol] = item.Value;
                            dr[LogCambiosService.ValorNuevo_NombreCol] = dato;
                            dt.Rows.Add(dr);
                        }
                        
                        valoresNuevos.Remove(item.Key);
                    }
                    else {
                        DataRow dr = dt.NewRow();
                        dr[LogCambiosService.CampoId_NombreCol] = item.Key;
                        dr[LogCambiosService.ValorAnterior_NombreCol] = item.Value;
                        dr[LogCambiosService.ValorNuevo_NombreCol] = string.Empty;
                        dt.Rows.Add(dr);
                    }
                }
                foreach (KeyValuePair<string, string> item in valoresNuevos)
                {
                    DataRow dr = dt.NewRow();
                    dr[LogCambiosService.CampoId_NombreCol] = item.Key;
                    dr[LogCambiosService.ValorAnterior_NombreCol] = string.Empty;
                    dr[LogCambiosService.ValorNuevo_NombreCol] = item.Value;
                    dt.Rows.Add(dr);
                }
                dtResultado = dt;
            }
            #endregion Comparaciones
            return dtResultado;
        }
    }
}
