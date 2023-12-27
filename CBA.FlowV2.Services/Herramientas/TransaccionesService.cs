#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Giros;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using Newtonsoft.Json;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TransaccionesService : ClaseCBA<TransaccionesService>
    {
        #region Implementacion de Filtros
        public class FiltroTransacciones : Filtro
        {
            public new static Filtro[] FiltrosDisponibles
            {
                get
                {
                    return new Filtro[] 
                    {
                        new Filtro{ Nombre = "ID Externo", Columna = Modelo.ID_EXTERNOColumnName},
                        new Filtro{ Nombre = "Nro Comprobante", Columna = Modelo.NRO_COMPROBANTEColumnName},
                        new Filtro{ Nombre = "Nro Trnasacción", Columna = Modelo.NRO_TRANSACCIONColumnName},
                        new Filtro{ Nombre = "Persona", Columna = Modelo.PERSONA_IDColumnName},
                        new Filtro{ Nombre = "Proveedor", Columna = Modelo.PROVEEDOR_IDColumnName},
                        new Filtro{ Nombre = "Red de Pago", Columna = Modelo.CTACTE_RED_PAGO_IDColumnName},
                        new Filtro{ Nombre = "Fecha Corte", Columna = Modelo.FECHA_CREACIONColumnName},
                        new Filtro{ Nombre = "Fecha Cración", Columna = Modelo.FECHA_CREACIONColumnName},
                        new Filtro{ Nombre = "Fecha Transacción", Columna = Modelo.FECHA_TRANSACCIONColumnName},
                        new Filtro{ Nombre = "Fecha Acreditación", Columna = Modelo.FECHA_ACREDITACIONColumnName},
                        new Filtro{ Nombre = "Cierre", Columna = Modelo.TRANSACCION_CIERRE_IDColumnName},
                        new Filtro{ Nombre = "Anulado", Columna = Modelo.ANULADOColumnName},
                        new Filtro{ Nombre = "Moneda", Columna = Modelo.MONEDA_IDColumnName},
                    };
                }
            }

            public override string ToString()
            {
                string texto = string.Empty;

                switch (this.Columna)
                {
                    case Modelo.IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + this.Valor;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => i.ToString()));
                        break;
                    case Modelo.MONEDA_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new MonedasService((decimal)this.Valor).Nombre;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new MonedasService((decimal)this.Valor).Nombre));
                        break;
                    case Modelo.PERSONA_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new PersonasService((decimal)this.Valor).NombreCompleto;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new PersonasService((decimal)this.Valor).NombreCompleto));
                        break;
                    case Modelo.PROVEEDOR_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new ProveedoresService((decimal)this.Valor).RazonSocial;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new ProveedoresService((decimal)this.Valor).RazonSocial));
                        break;
                    case Modelo.CTACTE_RED_PAGO_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new CuentaCorrienteRedesPagosService((decimal)this.Valor).Abreviatura;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new CuentaCorrienteRedesPagosService((decimal)this.Valor).Abreviatura));
                        break;
                    case Modelo.TRANSACCION_CIERRE_IDColumnName:
                        if (this.Exacto)
                            texto = this.Nombre + " es " + new TransaccionesCierresService((decimal)this.Valor).Nombre;
                        else
                            texto = this.Nombre + " está en " + string.Join(",", Array.ConvertAll((decimal[])this.Valor, i => new TransaccionesCierresService((decimal)this.Valor).Nombre));
                        break;
                    case Modelo.ANULADOColumnName:
                        texto = this.Columna + " " + (this.Valor.ToString() == Definiciones.SiNo.Si ? "Sí" : "No");
                        break;
                    case Modelo.ID_EXTERNOColumnName:
                    case Modelo.NRO_COMPROBANTEColumnName:
                    case Modelo.NRO_TRANSACCIONColumnName:
                        if (this.Exacto)
                            texto = this.Columna + " es " + this.Valor;
                        else
                            texto = this.Columna + " contiene " + this.Valor;
                        break;
                    case Modelo.FECHA_ACREDITACIONColumnName:
                    case Modelo.FECHA_CORTEColumnName:
                    case Modelo.FECHA_CREACIONColumnName:
                    case Modelo.FECHA_TRANSACCIONColumnName:
                        texto = this.Columna + " " + this.Comparacion + " " + ((DateTime)this.Valor).ToShortDateString();
                        break;
                }

                return texto;
            }
        }
        #endregion Implementacion de Filtros

        #region clase Acciones
        public class Acciones
        {
            #region clases
            public enum Tipo : int
            {
                GestionarCierre = 0,
                CrearTransferenciaIngresoClearing = 1,
                EmitirFCClienteYTransferencia = 2,
                CrearTransferenciaComisiones = 3
            }
            #endregion clases

            #region propiedades
            public static string DataTable_ColumnaNombre = "__NOMBRE__";
            public static string DataTable_ColumnaValor = "__VALOR__";
            #endregion propiedades

            #region GetDataTable
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(DataTable_ColumnaNombre, typeof(string));
                dt.Columns.Add(DataTable_ColumnaValor, typeof(int));

                dt.Rows.Add("Gestionar Cierres", Acciones.Tipo.GestionarCierre);
                dt.Rows.Add("Crear Transferencias de Ingreso a Clearing", Acciones.Tipo.CrearTransferenciaIngresoClearing);
                dt.Rows.Add("Emitir FC Cliente y Transferencia", Acciones.Tipo.EmitirFCClienteYTransferencia);
                dt.Rows.Add("Crear Transferencias de Egreso por Comisiones", Acciones.Tipo.CrearTransferenciaComisiones);
                
                return dt;
            }
            #endregion GetDataTable

            #region clase CrearTransferenciaIngresoClearing
            public class CrearTransferenciaIngresoClearing
            {
                #region propiedades
                public List<TransaccionesCierresService> lTransaccionesCierres;
                public DateTime Fecha{ get; set; }
                public decimal SucursalId { get; set; }
                private decimal _CtacteBancariaDestinoId;
                public decimal CtacteBancariaDestinoId { get { return this._CtacteBancariaDestinoId; } set { this._CtacteBancariaDestinoId = value; this._MonedaId = Definiciones.Error.Valor.EnteroPositivo; } }
                private decimal _MonedaId;
                public decimal MonedaId 
                { 
                    get 
                    {
                        if(this._MonedaId == Definiciones.Error.Valor.EnteroPositivo)
                            this._MonedaId = CuentaCorrienteCuentasBancariasService.GetMoneda(this.CtacteBancariaDestinoId);
                        return this._MonedaId;
                    }
                }
                public bool TextoPredefinidoUsar { get; set; }
                public decimal TextoPredefinidoId { get; set; }

                public bool HabilitarCuentaOrigenDefecto { get; set; }
                public string CtacteBancariaOrigenDefectoNumeroCuenta { get; set; }
                public decimal CtacteBancariaOrigenDefectoBancoId { get; set; }
                public decimal CtacteBancariaOrigenDefectoMonedaId { get; set; }
                #endregion propiedades

                #region constructores
                public CrearTransferenciaIngresoClearing()
                {
                    this.lTransaccionesCierres = new List<TransaccionesCierresService>();
                    this.Fecha = DateTime.MinValue;
                    this.HabilitarCuentaOrigenDefecto = false;
                }
                #endregion constructores

                #region Validar
                private void Validar(SessionService sesion)
                {
                    TransaccionesService transaccionAux = TransaccionesService.Instancia;
                    transaccionAux.IniciarUsingSesion(sesion);

                    if (this.lTransaccionesCierres.Count <= 0)
                        throw new Exception("Debe seleccionar los cierres a ser incluidos.");
                    if (this.CtacteBancariaDestinoId <= 0)
                        throw new Exception("Debe indicar la cuenta bancaria de destino.");
                    if (this.SucursalId <= 0)
                        throw new Exception("Debe indicar la sucursal en que se crearán las transferencias.");

                    if (this.HabilitarCuentaOrigenDefecto)
                    {
                        if (this.CtacteBancariaOrigenDefectoBancoId <= 0)
                            throw new Exception("Si habilita la cuenta origen por defecto debe definir el banco.");
                        if (this.CtacteBancariaOrigenDefectoMonedaId <= 0)
                            throw new Exception("Si habilita la cuenta origen por defecto debe definir la moneda.");
                        else if(this.CtacteBancariaOrigenDefectoMonedaId != this.MonedaId)
                            throw new Exception("La moneda de la cuenta bancaria por defecto debe ser la misma que moneda de la cuenta destino.");
                        if (this.CtacteBancariaOrigenDefectoNumeroCuenta.Length <= 0)
                            throw new Exception("Si habilita la cuenta origen por defecto debe definir el número de cuenta.");
                    }

                    #region Revisar que no existan transferencias ya realizadas para los cierres en la moneda dada
                    TransaccionesCierresCasosService[] tcc;
                    for (int i = 0; i < this.lTransaccionesCierres.Count; i++)
                    {
                        tcc = transaccionAux.GetFiltrado<TransaccionesCierresCasosService>(new Filtro[]
                            {
                                new Filtro { Columna = TransaccionesCierresCasosService.Modelo.FLUJO_IDColumnName, Valor = (decimal)Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA },
                                new Filtro { Columna = TransaccionesCierresCasosService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = this.lTransaccionesCierres[i].Id.Value },
                                new Filtro { Columna = TransaccionesCierresCasosService.Modelo.MONEDA_IDColumnName, Valor = this.MonedaId },
                            }
                        );
                        
                        if (tcc.Length > 0)
                            throw new Exception("Ya existen transferencias bancarias para el cierre " + this.lTransaccionesCierres[i].Nombre + ".");
                    }
                    #endregion Revisar que no existan transferencias ya realizadas para los cierres en la moneda dada

                    transaccionAux.FinalizarUsingSesion();
                }
                #endregion Validar

                #region Ejecutar
                public CBA.FlowV2.Services.Base.Excepciones Ejecutar()
                {
                    using (SessionService sesion = new SessionService())
                    {
                        try
                        {
                            sesion.BeginTransaction();
                            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

                            this.Validar(sesion);

                            bool exito;
                            Hashtable campos;
                            Dictionary<decimal, Dictionary<decimal, decimal>> dCierresCasos = new Dictionary<decimal, Dictionary<decimal, decimal>>(); //Se guarda, por proveedor, el monto correspondiente a cada cierre
                            Dictionary<decimal, Hashtable> dProveedores = new Dictionary<decimal, Hashtable>();
                            DataTable dtCtacteBancariaDestino = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + this.CtacteBancariaDestinoId, string.Empty, false);
                            decimal monedaDestinoId = (decimal)dtCtacteBancariaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol];
                            decimal cotizacionDestino = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(this.SucursalId), monedaDestinoId, this.Fecha, sesion);
                            TransferenciasBancariasService transferenciaBancaria = new TransferenciasBancariasService();

                            decimal proveedorActualId = Definiciones.Error.Valor.EnteroPositivo; 
                            decimal ctacteBancariaTercerosOrigenId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal ctacteBancoOrigenId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal monedaOrigenId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal cotizacionOrigen = Definiciones.Error.Valor.EnteroPositivo;
                            string numeroCuentaOrigen = string.Empty;

                            #region sumar monto por proveedor y por cierre
                            foreach (TransaccionesCierresService tc in this.lTransaccionesCierres)
                            {
                                TransaccionesService[] t = tc.GetFiltrado<TransaccionesService>(new Filtro[]
                                    {
                                        new Filtro { Columna = TransaccionesService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = tc.Id.Value },
                                        new Filtro { Columna = TransaccionesService.Modelo.MONEDA_IDColumnName, Valor = this.MonedaId },
                                        new Filtro { Columna = TransaccionesService.Modelo.ANULADOColumnName, Valor = Definiciones.SiNo.No },
                                    }
                                );
                          
                                decimal monto = 0;
                                for (int i = 0; i < t.Length; i++)
                                {
                                    if (!t[i].ProveedorId.HasValue)
                                    {
                                        excepciones.Agregar("La transacción " + t[i].IdExterno + " no está asociada a un proveedor.", null);
                                        continue;
                                    }

                                    if (!dCierresCasos.ContainsKey(t[i].ProveedorId.Value))
                                        dCierresCasos.Add(t[i].ProveedorId.Value, new Dictionary<decimal, decimal>());

                                    //Si cambia al proveedor recargar los datos de origen
                                    if (proveedorActualId != t[i].ProveedorId.Value)
                                    {
                                        proveedorActualId = t[i].ProveedorId.Value;
                                        string clausulas = CuentaCorrienteCuentasBancariasTercerosService.ProveedorId_NombreCol + " = " + proveedorActualId + " and " +
                                                           CuentaCorrienteCuentasBancariasTercerosService.MonedaId_NombreCol + " = " + this.MonedaId;
                                        DataTable dtCtacteBancariaTerceros = CuentaCorrienteCuentasBancariasTercerosService.GetCuentaCorrienteBancariasTercerosDataTable(clausulas, CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol, sesion);

                                        if (dtCtacteBancariaTerceros.Rows.Count <= 0)
                                        {
                                            ctacteBancariaTercerosOrigenId = Definiciones.Error.Valor.EnteroPositivo;
                                            monedaOrigenId = this.CtacteBancariaOrigenDefectoMonedaId;
                                            ctacteBancoOrigenId = this.CtacteBancariaOrigenDefectoBancoId;
                                            numeroCuentaOrigen = this.CtacteBancariaOrigenDefectoNumeroCuenta;
                                        }
                                        else
                                        {
                                            ctacteBancariaTercerosOrigenId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol];
                                            monedaOrigenId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.MonedaId_NombreCol];
                                            ctacteBancoOrigenId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.CtacteBancoId_NombreCol];
                                            numeroCuentaOrigen = (string)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.NumeroCuenta_NombreCol];
                                        }

                                        cotizacionOrigen = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(this.SucursalId), monedaOrigenId, this.Fecha, sesion);
                                    }

                                    if (!dProveedores.ContainsKey(t[i].ProveedorId.Value))
                                    {
                                        Hashtable ht = new Hashtable();
                                        ht.Add(TransferenciasBancariasService.MontoOrigen_NombreCol, (decimal)0);
                                        ht.Add(TransferenciasBancariasService.MonedaOrigenId_NombreCol, monedaOrigenId);
                                        ht.Add(TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol, cotizacionOrigen);
                                        ht.Add(TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol, ctacteBancoOrigenId);
                                        ht.Add(TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol, numeroCuentaOrigen);
                                        if (ctacteBancariaTercerosOrigenId != Definiciones.Error.Valor.EnteroPositivo)
                                            ht.Add(TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol, ctacteBancariaTercerosOrigenId);
                                        dProveedores.Add(t[i].ProveedorId.Value, ht);
                                    }

                                    Hashtable htAux = dProveedores[t[i].ProveedorId.Value];
                                    if (monedaOrigenId == t[i].MonedaId)
                                        monto = t[i].MontoTotal;
                                    else
                                        monto = t[i].MontoTotal / t[i].Cotizacion * cotizacionOrigen;
                                    htAux[TransferenciasBancariasService.MontoOrigen_NombreCol] = (decimal)htAux[TransferenciasBancariasService.MontoOrigen_NombreCol] + monto;

                                    if (!dCierresCasos[t[i].ProveedorId.Value].ContainsKey(tc.Id.Value))
                                        dCierresCasos[t[i].ProveedorId.Value].Add(tc.Id.Value, 0);
                                    dCierresCasos[t[i].ProveedorId.Value][tc.Id.Value] += monto;
                                }
                            }
                            #endregion sumar monto por proveedor y por cierre

                            foreach (KeyValuePair<decimal, Hashtable> dProveedorItem in dProveedores)
                            {
                                Hashtable ht = dProveedorItem.Value;
                                string casoCreadoEstado = string.Empty;
                                string mensaje = string.Empty;
                                decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;

                                if (!ht.Contains(TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol) && !this.HabilitarCuentaOrigenDefecto)
                                {
                                    ProveedoresService p = new ProveedoresService(dProveedorItem.Key);
                                    excepciones.Agregar("El proveedor " + p.RazonSocial + " no tiene una cuenta en la moneda de las transferencias.", null);
                                    continue;
                                }

                                campos = new Hashtable();

                                #region cargar campos
                                //Campos estaticos defecto
                                campos.Add(TransferenciasBancariasService.NumeroTransaccion_NombreCol, string.Empty);
                                campos.Add(TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol, Definiciones.SiNo.No);
                                campos.Add(TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol, Definiciones.SiNo.Si);
                                campos.Add(TransferenciasBancariasService.CuentaDestinoTerceros_NombreCol, Definiciones.SiNo.No);
                                campos.Add(TransferenciasBancariasService.SucursalDestinoId_NombreCol, this.SucursalId);
                                campos.Add(TransferenciasBancariasService.CostoTransferencia_NombreCol, (decimal)0);
                                campos.Add(TransferenciasBancariasService.Fecha_NombreCol, this.Fecha);
                                campos.Add(TransferenciasBancariasService.MonedaDestinoId_NombreCol, monedaDestinoId);
                                campos.Add(TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol, dtCtacteBancariaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol]);
                                campos.Add(TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol, dtCtacteBancariaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.Id_NombreCol]);
                                campos.Add(TransferenciasBancariasService.NumeroCuentaDestino_NombreCol, dtCtacteBancariaDestino.Rows[0][CuentaCorrienteCuentasBancariasService.NumeroCuenta_NombreCol]);

                                //Campos variables
                                campos.Add(TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol, ht[TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol]);
                                if (ht.Contains(TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol))
                                {
                                    campos.Add(TransferenciasBancariasService.CuentaOrigenTerceros_NombreCol, Definiciones.SiNo.Si);
                                    campos.Add(TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol, ht[TransferenciasBancariasService.CtaCteBancTercerosOrigenId_NombreCol]);
                                }
                                else
                                {
                                    campos.Add(TransferenciasBancariasService.CuentaOrigenTerceros_NombreCol, Definiciones.SiNo.No);
                                }
                                campos.Add(TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol, ht[TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol]);
                                campos.Add(TransferenciasBancariasService.MonedaOrigenId_NombreCol, ht[TransferenciasBancariasService.MonedaOrigenId_NombreCol]);
                                if (this.TextoPredefinidoUsar)
                                    campos.Add(TransferenciasBancariasService.TextoPredefinidoId_NombreCol, this.TextoPredefinidoId);
                                campos.Add(TransferenciasBancariasService.MontoOrigen_NombreCol, ht[TransferenciasBancariasService.MontoOrigen_NombreCol]);

                                if (monedaDestinoId == (decimal)ht[TransferenciasBancariasService.MonedaOrigenId_NombreCol])
                                {
                                    campos.Add(TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol, cotizacionDestino);
                                    campos.Add(TransferenciasBancariasService.MontoDestino_NombreCol, ht[TransferenciasBancariasService.MontoOrigen_NombreCol]);
                                }
                                else
                                {
                                    campos.Add(TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol, ht[TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol]);
                                    campos.Add(TransferenciasBancariasService.MontoDestino_NombreCol, (decimal)ht[TransferenciasBancariasService.MontoOrigen_NombreCol] / (decimal)ht[TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol] * cotizacionDestino);
                                }

                                campos.Add(TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol, cotizacionDestino);
                                campos.Add(TransferenciasBancariasService.NumeroSolicitud_NombreCol, string.Empty);
                                campos.Add(TransferenciasBancariasService.Observacion_NombreCol, string.Empty);
                                #endregion cargar campos

                                TransferenciasBancariasService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                                
                                #region cambiar de estado la transferencia
                                exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                                if (exito)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                                if (exito)
                                    transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                                if (exito)
                                    exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                                if (exito)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                                if (exito)
                                    transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                                if (exito)
                                    exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                if (exito)
                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                                if (exito)
                                    transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                #endregion cambiar de estado la transferencia

                                #region registrar que el caso afecta al cierre
                                foreach (KeyValuePair<decimal, decimal> d in dCierresCasos[dProveedorItem.Key])
                                {
                                    TransaccionesCierresCasosService tcc = new TransaccionesCierresCasosService();
                                    tcc.IniciarUsingSesion(sesion);
                                    tcc.CasoId = casoCreadoId;
                                    tcc.FlujoId = Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA;
                                    tcc.Cotizacion = cotizacionOrigen;
                                    tcc.MonedaId = monedaOrigenId;
                                    tcc.MontoTotal = d.Value;
                                    tcc.TransaccionCierreId = d.Key;
                                    tcc.Guardar();
                                    tcc.FinalizarUsingSesion();
                                }
                                #endregion registrar que el caso afecta al cierre
                            }
                      
                            sesion.CommitTransaction();
                            return excepciones;
                        }
                        catch
                        {
                            sesion.RollbackTransaction();
                            throw; 
                        }
                    }
                }
                #endregion Ejecutar
            }
            #endregion clase CrearTransferenciaIngresoClearing

            #region clase EmitirFCClienteYTransferencia
            public class EmitirFCClienteYTransferencia
            {
                #region propiedades
                public List<TransaccionesCierresService> lTransaccionesCierres;
                public bool TransaccionesCierresFiltrarPersona { get; set; }
                public decimal TransaccionesCierresPersonaId { get; set; }
                public decimal TransaccionesCierresMonedaId { get; set; }

                public DateTime TransferenciaFecha { get; set; }
                public decimal TransferenciaSucursalId { get; set; }
                public decimal TransferenciaCtacteBancariaOrigenId { get; set; }
                public bool TransferenciaTextoPredefinidoUsar { get; set; }
                public decimal TransferenciaTextoPredefinidoId { get; set; }

                public bool FCUsarPersonaRelacionada { get; set; }
                public DateTime FCFecha { get; set; }
                public decimal FCSucursalId { get; set; }
                public decimal FCDepositoId { get; set; }
                public decimal FCCtacteCajaId { get; set; }
                public decimal FCFuncionarioId { get; set; }
                public decimal FCAutonumeracionId { get; set; }
                public decimal FCArticuloId { get; set; }
                public decimal FCLoteId { get; set; }
                public string FCObservacion { get; set; }
                #endregion propiedades

                #region constructores
                public EmitirFCClienteYTransferencia()
                {
                    this.lTransaccionesCierres = new List<TransaccionesCierresService>();
                    this.TransferenciaFecha = DateTime.MinValue;
                    this.FCFecha = DateTime.MinValue;
                }
                #endregion constructores

                #region Validar
                private void Validar(SessionService sesion)
                {
                    TransaccionesService transaccionAux = TransaccionesService.Instancia;
                    transaccionAux.IniciarUsingSesion(sesion);

                    if (this.lTransaccionesCierres.Count <= 0)
                        throw new Exception("Debe seleccionar los cierres a ser incluidos.");
                    if (this.TransaccionesCierresFiltrarPersona && this.TransaccionesCierresPersonaId <= 0)
                        throw new Exception("Debe seleccionar la única persona del cierre a procesar o desmarcar su uso.");
                    if (this.TransaccionesCierresMonedaId <= 0)
                        throw new Exception("Debe seleccionar la moneda a procesar.");

                    if (this.TransferenciaCtacteBancariaOrigenId <= 0)
                        throw new Exception("Debe indicar la cuenta bancaria de origen para las transferencias.");
                    if (this.TransferenciaSucursalId <= 0)
                        throw new Exception("Debe indicar la sucursal en que se crearán las transferencias.");


                    if (this.FCSucursalId <= 0)
                        throw new Exception("Debe indicar la sucursal en que se crearán las facturas.");
                    if (this.FCDepositoId <= 0)
                        throw new Exception("Debe indicar el depósito en que se crearán las facturas.");
                    if (this.FCCtacteCajaId <= 0)
                        throw new Exception("Debe indicar la caja a la que se asociarán las facturas.");
                    if (this.FCFuncionarioId <= 0)
                        throw new Exception("Debe indicar el funcionario que creará las facturas.");
                    if (this.FCAutonumeracionId <= 0)
                        throw new Exception("Debe indicar el talonario de las facturas.");
                    if (this.FCLoteId <= 0)
                        throw new Exception("Debe indicar el artículo y lote a ser facturados.");
                    
                    #region Revisar que no existan facturas ya realizadas para los cierres
                    TransaccionesCierresCasosService[] tcc;
                    for (int i = 0; i < this.lTransaccionesCierres.Count; i++)
                    {
                        tcc = transaccionAux.GetFiltrado<TransaccionesCierresCasosService>(new Filtro[]
                            {
                                new Filtro { Columna = TransaccionesCierresCasosService.Modelo.FLUJO_IDColumnName, Valor = (decimal)Definiciones.FlujosIDs.FACTURACION_CLIENTE },
                                new Filtro { Columna = TransaccionesCierresCasosService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = this.lTransaccionesCierres[i].Id.Value },
                                new Filtro { Columna = TransaccionesCierresCasosService.Modelo.MONEDA_IDColumnName, Valor = this.TransaccionesCierresMonedaId },
                            }
                        );

                        if (tcc.Length > 0)
                        {
                            if (this.TransaccionesCierresFiltrarPersona)
                            {
                                for (int j = 0; j < tcc.Length; j++)
                                {
                                    DataTable dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + tcc[j].CasoId, string.Empty, sesion);
                                    if (this.TransaccionesCierresPersonaId == (decimal)dtCaso.Rows[0][CasosService.PersonaId_NombreCol])
                                        throw new Exception("Ya fue emitida una Factura de Cliente (caso " + tcc[j].CasoId + " para la persona y cierre " + this.lTransaccionesCierres[i].Nombre + ".");
                                }
                            }
                            else
                            {
                                throw new Exception("Ya existen facturas de cliente para el cierre " + this.lTransaccionesCierres[i].Nombre + ".");
                            }
                        }
                    }
                    #endregion Revisar que no existan facturas ya realizadas para los cierres

                    transaccionAux.FinalizarUsingSesion();
                }
                #endregion Validar

                #region Ejecutar
                public CBA.FlowV2.Services.Base.Excepciones Ejecutar()
                {
                    using (SessionService sesion = new SessionService())
                    {
                        try
                        {
                            sesion.BeginTransaction();

                            this.Validar(sesion);

                            TransaccionesService transaccionAux = TransaccionesService.Instancia;
                            transaccionAux.IniciarUsingSesion(sesion);

                            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
                            bool exito;
                            Hashtable campos;
                            Dictionary<decimal, Dictionary<decimal, decimal>> dCierresCasos = new Dictionary<decimal, Dictionary<decimal, decimal>>(); //Se guarda, por persona, el monto correspondiente a cada cierre
                            Dictionary<decimal, Hashtable> dPersonas = new Dictionary<decimal, Hashtable>();
                            DataTable dtCtacteBancariaOrigen = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + this.TransferenciaCtacteBancariaOrigenId, string.Empty, false);
                            DataTable dtFacturaCreada;
                            decimal monedaOrigenId = (decimal)dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol];
                            decimal cotizacionOrigen = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(this.TransferenciaSucursalId), monedaOrigenId, this.TransferenciaFecha, sesion);
                            TransferenciasBancariasService transferenciaBancaria = new TransferenciasBancariasService();
                            FacturasClienteService facturaCliente = new FacturasClienteService();
                            DateTime fechaPrimerVencimiento, fechaSegundoVencimiento;
                            bool usarFechaPrimerVencimiento, usarFechaSegundoVencimiento;

                            decimal personaActualId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal ctacteBancariaTercerosDestinoId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal ctacteBancoDestinoId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal monedaDestinoId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal cotizacionDestino = Definiciones.Error.Valor.EnteroPositivo;
                            string numeroCuentaDestino = string.Empty;

                            #region sumar monto por persona y por cierre
                            foreach (TransaccionesCierresService tc in this.lTransaccionesCierres)
                            {
                                decimal monto = 0;
                                
                                List<Filtro> lFiltros = new List<Filtro>();
                                lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = tc.Id.Value });
                                lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.MONEDA_IDColumnName, Valor = this.TransaccionesCierresMonedaId });
                                lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.ANULADOColumnName, Valor = Definiciones.SiNo.No });
                                
                                if (this.TransaccionesCierresFiltrarPersona)
                                    lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.PERSONA_IDColumnName, Valor = this.TransaccionesCierresPersonaId });

                                TransaccionesService[] t = transaccionAux.GetFiltrado<TransaccionesService>(lFiltros.ToArray());

                                for (int i = 0; i < t.Length; i++)
                                {
                                    if (!t[i].PersonaId.HasValue)
                                    {
                                        excepciones.Agregar("La transacción " + t[i].IdExterno + " no está asociada a una persona.", null);
                                        continue;
                                    }

                                    if (!dCierresCasos.ContainsKey(t[i].PersonaId.Value))
                                    {
                                        dCierresCasos.Add(t[i].PersonaId.Value, new Dictionary<decimal, decimal>());
                                    }

                                    //Si cambia la persona recarcar los datos de origen
                                    if (personaActualId != t[i].PersonaId.Value)
                                    {
                                        personaActualId = t[i].PersonaId.Value;
                                        string clausulas = CuentaCorrienteCuentasBancariasTercerosService.PersonaId_NombreCol + " = " + personaActualId + " and " +
                                                           CuentaCorrienteCuentasBancariasTercerosService.MonedaId_NombreCol + " = " + this.TransaccionesCierresMonedaId;
                                        DataTable dtCtacteBancariaTerceros = CuentaCorrienteCuentasBancariasTercerosService.GetCuentaCorrienteBancariasTercerosDataTable(clausulas, CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol, sesion);

                                        if (dtCtacteBancariaTerceros.Rows.Count <= 0)
                                        {
                                            excepciones.Agregar("La persona " + t[i].Persona.NombreCompleto + " no tiene una cuenta bancaria definida.", null);
                                            personaActualId = Definiciones.Error.Valor.EnteroPositivo;
                                            continue;
                                        }
                                        
                                        ctacteBancariaTercerosDestinoId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol];
                                        monedaDestinoId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.MonedaId_NombreCol];
                                        ctacteBancoDestinoId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.CtacteBancoId_NombreCol];
                                        numeroCuentaDestino = (string)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.NumeroCuenta_NombreCol];
                                        cotizacionDestino = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(this.TransferenciaSucursalId), monedaDestinoId, this.TransferenciaFecha, sesion);
                                    }

                                    if (!dPersonas.ContainsKey(t[i].PersonaId.Value))
                                    {
                                        Hashtable ht = new Hashtable();
                                        ht.Add(TransferenciasBancariasService.MontoDestino_NombreCol, (decimal)0);
                                        ht.Add(FacturasClienteService.TotalNeto_NombreCol, (decimal)0); //Utilizado luego para la FC
                                        ht.Add(TransferenciasBancariasService.MonedaDestinoId_NombreCol, monedaDestinoId);
                                        ht.Add(TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol, cotizacionDestino);
                                        ht.Add(TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol, ctacteBancoDestinoId);
                                        ht.Add(TransferenciasBancariasService.NumeroCuentaDestino_NombreCol, numeroCuentaDestino);
                                        ht.Add(TransferenciasBancariasService.CtaCteBancTercerosDestId_NombreCol, ctacteBancariaTercerosDestinoId);
                                        dPersonas.Add(t[i].PersonaId.Value, ht);
                                    }

                                    Hashtable htAux = dPersonas[t[i].PersonaId.Value];
                                    if (monedaDestinoId == t[i].MonedaId)
                                    {
                                        monto = t[i].MontoCapital;
                                        htAux[TransferenciasBancariasService.MontoDestino_NombreCol] = (decimal)htAux[TransferenciasBancariasService.MontoDestino_NombreCol] + monto;

                                        monto -= t[i].ComisionTotal;
                                        htAux[FacturasClienteService.TotalNeto_NombreCol] = (decimal)htAux[FacturasClienteService.TotalNeto_NombreCol] + monto;
                                    }
                                    else
                                    {
                                        monto = t[i].MontoCapital / t[i].Cotizacion * cotizacionDestino;
                                        htAux[TransferenciasBancariasService.MontoDestino_NombreCol] = (decimal)htAux[TransferenciasBancariasService.MontoDestino_NombreCol] + monto;

                                        monto -= (t[i].ComisionTotal / t[i].Cotizacion * cotizacionDestino);
                                        htAux[FacturasClienteService.TotalNeto_NombreCol] = (decimal)htAux[FacturasClienteService.TotalNeto_NombreCol] + monto;
                                    }
                                    

                                    if (!dCierresCasos[t[i].PersonaId.Value].ContainsKey(tc.Id.Value))
                                        dCierresCasos[t[i].PersonaId.Value].Add(tc.Id.Value, 0);
                                    dCierresCasos[t[i].PersonaId.Value][tc.Id.Value] += monto;
                                }
                            }
                            #endregion sumar monto por persona y por cierre

                            foreach (KeyValuePair<decimal, Hashtable> dPersonaItem in dPersonas)
                            {
                                Hashtable ht = dPersonaItem.Value;
                                string aux = string.Empty;
                                string casoCreadoEstado = string.Empty;
                                string mensaje = string.Empty;
                                decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;

                                campos = new Hashtable();

                                #region Crear Transferencia
                                #region cargar campos
                                //Campos estaticos defecto
                                campos.Add(TransferenciasBancariasService.NumeroTransaccion_NombreCol, string.Empty);
                                campos.Add(TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol, Definiciones.SiNo.Si);
                                campos.Add(TransferenciasBancariasService.CuentaOrigenTerceros_NombreCol, Definiciones.SiNo.No);
                                campos.Add(TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol, Definiciones.SiNo.No);
                                campos.Add(TransferenciasBancariasService.CuentaDestinoTerceros_NombreCol, Definiciones.SiNo.Si);
                                campos.Add(TransferenciasBancariasService.SucursalOrigenId_NombreCol, this.TransferenciaSucursalId);
                                campos.Add(TransferenciasBancariasService.CostoTransferencia_NombreCol, (decimal)0);
                                campos.Add(TransferenciasBancariasService.Fecha_NombreCol, this.TransferenciaFecha);
                                campos.Add(TransferenciasBancariasService.MonedaOrigenId_NombreCol, monedaOrigenId);
                                campos.Add(TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol]);
                                campos.Add(TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.Id_NombreCol]);
                                campos.Add(TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.NumeroCuenta_NombreCol]);

                                //Campos variables
                                campos.Add(TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol, ht[TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol]);
                                campos.Add(TransferenciasBancariasService.CtaCteBancTercerosDestId_NombreCol, ht[TransferenciasBancariasService.CtaCteBancTercerosDestId_NombreCol]);
                                campos.Add(TransferenciasBancariasService.NumeroCuentaDestino_NombreCol, ht[TransferenciasBancariasService.NumeroCuentaDestino_NombreCol]);
                                campos.Add(TransferenciasBancariasService.MonedaDestinoId_NombreCol, ht[TransferenciasBancariasService.MonedaDestinoId_NombreCol]);
                                if (this.TransferenciaTextoPredefinidoUsar)
                                    campos.Add(TransferenciasBancariasService.TextoPredefinidoId_NombreCol, this.TransferenciaTextoPredefinidoId);
                                campos.Add(TransferenciasBancariasService.MontoDestino_NombreCol, ht[TransferenciasBancariasService.MontoDestino_NombreCol]);

                                if (monedaOrigenId == (decimal)ht[TransferenciasBancariasService.MonedaDestinoId_NombreCol])
                                {
                                    campos.Add(TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol, cotizacionOrigen);
                                    campos.Add(TransferenciasBancariasService.MontoOrigen_NombreCol, ht[TransferenciasBancariasService.MontoDestino_NombreCol]);
                                }
                                else
                                {
                                    campos.Add(TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol, ht[TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol]);
                                    campos.Add(TransferenciasBancariasService.MontoOrigen_NombreCol, (decimal)ht[TransferenciasBancariasService.MontoOrigen_NombreCol] / (decimal)ht[TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol] * cotizacionOrigen);
                                }

                                campos.Add(TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol, cotizacionOrigen);
                                campos.Add(TransferenciasBancariasService.NumeroSolicitud_NombreCol, string.Empty);
                                campos.Add(TransferenciasBancariasService.Observacion_NombreCol, string.Empty);
                                #endregion cargar campos

                                TransferenciasBancariasService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                                
                                #region cambiar de estado la transferencia
                                exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                                if (exito)
                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                                if (exito)
                                    transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                                if (exito)
                                    exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                                if (exito)
                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                                if (exito)
                                    transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                                if (exito)
                                    exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                if (exito)
                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                                if (exito)
                                    transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                #endregion cambiar de estado la transferencia
                                #endregion Crear Transferencia

                                #region registrar que el caso de transferencia afecta al cierre
                                foreach (KeyValuePair<decimal, decimal> d in dCierresCasos[dPersonaItem.Key])
                                {
                                    TransaccionesCierresCasosService tcc = new TransaccionesCierresCasosService();
                                    tcc.IniciarUsingSesion(sesion);
                                    tcc.CasoId = casoCreadoId;
                                    tcc.FlujoId = Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA;
                                    tcc.Cotizacion = cotizacionOrigen;
                                    tcc.MonedaId = monedaOrigenId;
                                    tcc.MontoTotal = d.Value;
                                    tcc.TransaccionCierreId = d.Key;
                                    tcc.Guardar();
                                    tcc.FinalizarUsingSesion();
                                }
                                #endregion registrar que el caso de transferencia afecta al cierre

                                #region Crear FC Cliente
                                #region cargar campos
                                campos = new Hashtable();
                                campos.Add(FacturasClienteService.AConsignacion_NombreCol, Definiciones.SiNo.No);
                                campos.Add(FacturasClienteService.AfectaCtacte_NombreCol, Definiciones.SiNo.No);
                                campos.Add(FacturasClienteService.AfectaLineaCredito_NombreCol, Definiciones.SiNo.No);
                                campos.Add(FacturasClienteService.AfectaStock_NombreCol, Definiciones.SiNo.No);
                                campos.Add(FacturasClienteService.AutonumeracionId_NombreCol, this.FCAutonumeracionId);
                                campos.Add(FacturasClienteService.ComisionPorVenta_NombreCol, Definiciones.TiposComision.ComisionPorVenta);
                                campos.Add(FacturasClienteService.CondicionPagoId_NombreCol, Definiciones.CondicionPago.Contado);
                                campos.Add(FacturasClienteService.CotizacionDestino_NombreCol, cotizacionOrigen);
                                campos.Add(FacturasClienteService.Direccion_NombreCol, string.Empty);
                                campos.Add(FacturasClienteService.FechaVencimiento_NombreCol, this.FCFecha);
                                campos.Add(FacturasClienteService.Fecha_NombreCol, this.FCFecha);
                                campos.Add(FacturasClienteService.MonedaDestinoId_NombreCol, monedaOrigenId);
                                campos.Add(FacturasClienteService.ObservacionEntrega_NombreCol, string.Empty);
                                campos.Add(FacturasClienteService.Observacion_NombreCol, string.Empty);
                                if (this.FCUsarPersonaRelacionada)
                                {
                                    DataTable dtPersona = PersonasService.GetPersonasDataTable2(PersonasService.Id_NombreCol + " = " + dPersonaItem.Key, string.Empty, false, sesion);
                                    if(CBA.FlowV2.Services.Common.Interprete.EsNullODBNull(dtPersona.Rows[0][PersonasService.PersonaIdConyuge_NombreCol]))
                                        campos.Add(FacturasClienteService.PersonaId_NombreCol, dPersonaItem.Key);
                                    else
                                        campos.Add(FacturasClienteService.PersonaId_NombreCol, dtPersona.Rows[0][PersonasService.PersonaIdConyuge_NombreCol]);
                                }
                                else 
                                {
                                    campos.Add(FacturasClienteService.PersonaId_NombreCol, dPersonaItem.Key);
                                }
                                campos.Add(FacturasClienteService.PorcentajeDescSobreTotal_NombreCol, (decimal)0);
                                campos.Add(FacturasClienteService.SucursalId_NombreCol, this.FCSucursalId);
                                campos.Add(FacturasClienteService.TipoFacturaId_NombreCol, Definiciones.TipoFactura.Contado);
                                campos.Add(FacturasClienteService.VendedorId_NombreCol, this.FCFuncionarioId);
                                campos.Add(FacturasClienteService.CtaCteCajaSucursalId_NombreCol, this.FCCtacteCajaId);
                                campos.Add(FacturasClienteService.DepositoId_NombreCol, this.FCDepositoId);
                                campos.Add(FacturasClienteService.TotalEntregaInicial_NombreCol, (decimal)0);

                                FacturasClienteService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                                #endregion cargar campos

                                dtFacturaCreada = FacturasClienteService.GetFacturaClienteDataTable(FacturasClienteService.CasoId_NombreCol + " = " + casoCreadoId, string.Empty, sesion);

                                #region Agregar detalle
                                campos = new System.Collections.Hashtable();
                                campos.Add(FacturasClienteDetalleService.FacturaClienteId_NombreCol, dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol]);
                                campos.Add(FacturasClienteDetalleService.ArticuloId_NombreCol, this.FCArticuloId);
                                campos.Add(FacturasClienteDetalleService.LoteId_NombreCol, this.FCLoteId);
                                campos.Add(FacturasClienteDetalleService.UnidadDestinoId_NombreCol, Definiciones.UnidadesMedida.Simbolo.Unidades);
                                campos.Add(FacturasClienteDetalleService.CantidadEmbalada_NombreCol, (decimal)0);
                                campos.Add(FacturasClienteDetalleService.CantidadUnidadDestino_NombreCol, (decimal)1);
                                campos.Add(FacturasClienteDetalleService.ImpuestoId_NombreCol, Definiciones.Impuestos.IVA_10);
                                campos.Add(FacturasClienteDetalleService.PrecioListaDestino_NombreCol, ht[FacturasClienteService.TotalNeto_NombreCol]);
                                campos.Add(FacturasClienteDetalleService.MontoDescuento_NombreCol, (decimal)0);
                                campos.Add(FacturasClienteDetalleService.PorcentajeDescuento_NombreCol, (decimal)0);
                                campos.Add(FacturasClienteDetalleService.Observacion_NombreCol, this.FCObservacion);

                                FacturasClienteDetalleService.Guardar((decimal)dtFacturaCreada.Rows[0][FacturasClienteService.Id_NombreCol], campos, true, true, out fechaPrimerVencimiento, out usarFechaPrimerVencimiento, out fechaSegundoVencimiento, out usarFechaSegundoVencimiento, true, sesion);
                                #endregion Agregar detalle por pago capital
                                #endregion Crear FC Cliente

                                #region Aprobar el caso de FC Cliente
                                //Pasar a Pendiente
                                exito = facturaCliente.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                                if (exito)
                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                                if (exito)
                                    facturaCliente.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                                //Pasar a Caja
                                if (exito)
                                    exito = facturaCliente.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Caja, false, out mensaje, sesion);
                                if (exito)
                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Caja, string.Empty, sesion);
                                if (exito)
                                    facturaCliente.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Caja, sesion);

                                //Pasar a Cerrado
                                if (exito)
                                    exito = facturaCliente.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                                if (exito)
                                    exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                                if (exito)
                                    facturaCliente.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                                #endregion Aprobar el caso de FC Cliente

                                #region registrar que el caso de FC Cliente afecta al cierre
                                foreach (KeyValuePair<decimal, decimal> d in dCierresCasos[dPersonaItem.Key])
                                {
                                    TransaccionesCierresCasosService tcc = new TransaccionesCierresCasosService();
                                    tcc.IniciarUsingSesion(sesion);
                                    tcc.CasoId = casoCreadoId;
                                    tcc.FlujoId = Definiciones.FlujosIDs.FACTURACION_CLIENTE;
                                    tcc.Cotizacion = cotizacionOrigen;
                                    tcc.MonedaId = monedaOrigenId;
                                    tcc.MontoTotal = d.Value;
                                    tcc.TransaccionCierreId = d.Key;
                                    tcc.Guardar();
                                    tcc.FinalizarUsingSesion();
                                }
                                #endregion registrar que el caso de FC Cliente afecta al cierre
                            }

                            transaccionAux.FinalizarUsingSesion();

                            sesion.CommitTransaction();
                            return excepciones;
                        }
                        catch
                        {
                            sesion.RollbackTransaction();
                            throw;
                        }
                    }
                }
                #endregion Ejecutar
            }
            #endregion clase EmitirFCClienteYTransferencia

            #region clase CrearTransferenciaComisiones
            public class CrearTransferenciaComisiones
            {
                #region clases para ordenar
                private class DestinatarioCtaBancaria
                {
                    public decimal BancoId;
                    public decimal BancariaId;
                    public decimal Cotizacion;
                    public decimal MonedaId;
                    public string NroCuenta;
                    public decimal Monto;

                    public DestinatarioCtaBancaria(decimal proveedor_id, decimal sucursal_id, decimal moneda_id, DateTime fecha, CBA.FlowV2.Services.Base.Excepciones excepciones, SessionService sesion)
                    {
                        if (proveedor_id != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            string clausulas = CuentaCorrienteCuentasBancariasTercerosService.ProveedorId_NombreCol + " = " + proveedor_id + " and " +
                                               CuentaCorrienteCuentasBancariasTercerosService.MonedaId_NombreCol + " = " + moneda_id;
                                        
                            DataTable dtCtacteBancariaTerceros = CuentaCorrienteCuentasBancariasTercerosService.GetCuentaCorrienteBancariasTercerosDataTable(clausulas, CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol, sesion);

                            if (dtCtacteBancariaTerceros.Rows.Count <= 0)
                            {
                                ProveedoresService p = new ProveedoresService(proveedor_id);
                                excepciones.Agregar("El proveedor " + p.RazonSocial + " no tiene una cuenta bancaria definida.", null);
                                return;
                            }

                            this.BancariaId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.Id_NombreCol];
                            this.MonedaId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.MonedaId_NombreCol];
                            this.BancoId = (decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.CtacteBancoId_NombreCol];
                            this.NroCuenta = (string)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.NumeroCuenta_NombreCol];
                            this.Cotizacion = CotizacionesService.GetCotizacionMonedaCompra((decimal)dtCtacteBancariaTerceros.Rows[0][CuentaCorrienteCuentasBancariasTercerosService.PaisId_NombreCol], this.MonedaId, fecha, sesion);
                        }
                        else
                        {
                            this.Cotizacion = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(sucursal_id), moneda_id, fecha, sesion);
                        }
                        
                        this.Monto = 0;
                    }
                }

                private class Destinatarios
                {
                    public enum TipoDestinatario { Procesador, Recaudador, Clearing, Red, Otro }

                    public TipoDestinatario Tipo { get; private set; }
                    public Dictionary<decimal, DestinatarioCtaBancaria> Proveedores { get; private set; }
                    public Dictionary<decimal, Dictionary<decimal, decimal>> CierresCasos { get; private set; }
                    public Dictionary<decimal, decimal> TotalPorCierre { get; private set; }
                    
                    public decimal CtacteBancariaPorDefectoId;
                    private CuentaCorrienteCuentasBancariasService _ctacteBancariaPorDefecto;
                    public CuentaCorrienteCuentasBancariasService CtacteBancariaPorDefecto 
                    {
                        get
                        {
                            if (this.CtacteBancariaPorDefectoId <= 0)
                                throw new Exception("No hay una cuenta bancaria definida.");
                            if (this._ctacteBancariaPorDefecto == null)
                                this._ctacteBancariaPorDefecto = new CuentaCorrienteCuentasBancariasService(this.CtacteBancariaPorDefectoId);

                            return this._ctacteBancariaPorDefecto;
                        }
                    }

                    public Destinatarios(TipoDestinatario tipo)
                    {
                        this.Tipo = tipo;
                        this.Proveedores = new Dictionary<decimal,DestinatarioCtaBancaria>();
                        this.CierresCasos = new Dictionary<decimal, Dictionary<decimal, decimal>>();
                        this.TotalPorCierre = new Dictionary<decimal,decimal>();
                        this.CtacteBancariaPorDefectoId = Definiciones.Error.Valor.EnteroPositivo;
                    }

                    public void Agregar(decimal proveedor_id, decimal sucursal_id, DateTime fecha, decimal ctacte_bancaria_defecto_id, decimal moneda_id, CBA.FlowV2.Services.Base.Excepciones excepciones, SessionService sesion)
                    {
                        if (!this.Proveedores.ContainsKey(proveedor_id))
                        {
                            if (proveedor_id == Definiciones.Error.Valor.EnteroPositivo)
                                this.CtacteBancariaPorDefectoId = ctacte_bancaria_defecto_id;
                                
                            this.Proveedores.Add(proveedor_id, new DestinatarioCtaBancaria(proveedor_id, sucursal_id, moneda_id, fecha, excepciones, sesion));
                            this.CierresCasos.Add(proveedor_id, new Dictionary<decimal, decimal>());
                        }
                    }

                    public void Sumar(decimal proveedor_id, decimal transaccion_cierre_id, decimal monto)
                    {
                        if (!this.TotalPorCierre.ContainsKey(transaccion_cierre_id))
                        {
                            this.TotalPorCierre.Add(transaccion_cierre_id, 0);
                            this.CierresCasos[proveedor_id].Add(transaccion_cierre_id, 0);
                        }

                        this.Proveedores[proveedor_id].Monto += monto;
                        this.TotalPorCierre[transaccion_cierre_id] += monto;
                        this.CierresCasos[proveedor_id][transaccion_cierre_id] += monto;
                    }
                }
                #endregion clases para ordenar

                #region propiedades
                public List<TransaccionesCierresService> lTransaccionesCierres;
                public bool TransaccionesCierresFiltrarProveedor { get; set; }
                public decimal TransaccionesCierresProveedorId { get; set; }
                public decimal TransaccionesCierresMonedaId { get; set; }

                public bool GenerarARecaudadorAnticipo { get; set; }
                public bool GenerarARecaudadorTransferencia { get; set; }
                public bool GenerarAProcesadorAnticipo { get; set; }
                public bool GenerarAProcesadorTransferencia { get; set; }
                public decimal GenerarAProcesadorTransferenciaCtaBancariaDestinoId { get; set; }
                public decimal GenerarAProcesadorProveedorId { get; set; }
                public bool GenerarAClearingAnticipo { get; set; }
                public bool GenerarAClearingTransferencia { get; set; }
                public bool GenerarAClearingProveedorUnico { get; set; }
                public decimal GenerarAClearingProveedorId { get; set; }
                public bool GenerarARedAnticipo { get; set; }
                public bool GenerarARedTransferencia { get; set; }
                public bool GenerarARedProveedorUnico { get; set; }
                public decimal GenerarARedProveedorId { get; set; }
                public bool GenerarAOtroAnticipo { get; set; }
                public bool GenerarAOtroTransferencia { get; set; }
                public decimal GenerarAOtroTransferenciaCtaBancariaDestinoId { get; set; }
                public decimal GenerarAOtroProveedorId { get; set; }
                
                public DateTime TransferenciaFecha { get; set; }
                public decimal TransferenciaSucursalId { get; set; }
                public decimal TransferenciaCtacteBancariaOrigenId { get; set; }
                public bool TransferenciaTextoPredefinidoUsar { get; set; }
                public decimal TransferenciaTextoPredefinidoId { get; set; }

                public DateTime AnticipoFecha { get; set; }
                public decimal AnticipoSucursalId { get; set; }
                public decimal AnticipoMonedaId { get; set; }
                public decimal AnticipoAutonumeracionId { get; set; }

                public decimal GenerarARecaudadorOPCajaTesoreriaId { get; set; }
                public decimal GenerarARecaudadorOPAutonumeracionId { get; set; }
                public decimal GenerarAProcesadorOPCajaTesoreriaId { get; set; }
                public decimal GenerarAProcesadorOPAutonumeracionId { get; set; }
                public decimal GenerarAClearingOPCajaTesoreriaId { get; set; }
                public decimal GenerarAClearingOPAutonumeracionId { get; set; }
                public decimal GenerarARedOPCajaTesoreriaId { get; set; }
                public decimal GenerarARedOPAutonumeracionId { get; set; }
                public decimal GenerarAOtroOPCajaTesoreriaId { get; set; }
                public decimal GenerarAOtroOPAutonumeracionId { get; set; }
                #endregion propiedades

                #region constructores
                public CrearTransferenciaComisiones()
                {
                    this.lTransaccionesCierres = new List<TransaccionesCierresService>();
                    this.TransferenciaFecha = DateTime.MinValue;
                    this.AnticipoFecha = DateTime.MinValue;
                }
                #endregion constructores

                #region Validar
                private bool Validar(TransaccionesCierresService transaccion_cierre, Destinatarios destinatarios_recaudadores, Destinatarios destinatarios_procesadores, Destinatarios destinatarios_bancos_clearing, Destinatarios destinatarios_redes, Destinatarios destinatarios_otros, SessionService sesion)
                {
                    decimal montoRecaudador = 0, montoProcesador = 0, montoClearing= 0, montoRed = 0, montoOtro = 0;

                    if (this.TransaccionesCierresMonedaId <= 0)
                        throw new Exception("Debe seleccionar la moneda a procesar.");

                    TransaccionesService transaccionAux = TransaccionesService.Instancia;
                    transaccionAux.IniciarUsingSesion(sesion);

                    if (destinatarios_recaudadores.TotalPorCierre.ContainsKey(transaccion_cierre.Id.Value))
                        montoRecaudador = destinatarios_recaudadores.TotalPorCierre[transaccion_cierre.Id.Value];
                    if (destinatarios_procesadores.TotalPorCierre.ContainsKey(transaccion_cierre.Id.Value))
                        montoProcesador = destinatarios_procesadores.TotalPorCierre[transaccion_cierre.Id.Value];
                    if (destinatarios_bancos_clearing.TotalPorCierre.ContainsKey(transaccion_cierre.Id.Value))
                        montoClearing = destinatarios_bancos_clearing.TotalPorCierre[transaccion_cierre.Id.Value];
                    if (destinatarios_redes.TotalPorCierre.ContainsKey(transaccion_cierre.Id.Value))
                        montoRed = destinatarios_redes.TotalPorCierre[transaccion_cierre.Id.Value];
                    if (destinatarios_otros.TotalPorCierre.ContainsKey(transaccion_cierre.Id.Value))
                        montoOtro = destinatarios_otros.TotalPorCierre[transaccion_cierre.Id.Value];
                    
                    TransaccionesCierresCasosService[] tcc = transaccionAux.GetFiltrado<TransaccionesCierresCasosService>(new Filtro[]
                        {
                            new Filtro { Columna = TransaccionesCierresCasosService.Modelo.FLUJO_IDColumnName, Valor = (decimal)Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR },
                            new Filtro { Columna = TransaccionesCierresCasosService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = transaccion_cierre.Id.Value },
                            new Filtro { Columna = TransaccionesCierresCasosService.Modelo.MONEDA_IDColumnName, Valor = this.TransaccionesCierresMonedaId },
                        }
                    );

                    decimal aplicadoRecaudador = 0;
                    decimal aplicadoProcesador = 0;
                    decimal aplicadoClearing = 0;
                    decimal aplicadoRed = 0;
                    decimal aplicadoOtro = 0;

                    for (int i = 0; i < tcc.Length; i++)
                    {
                        aplicadoRecaudador += tcc[i].ComisionRecaudador.Value;
                        aplicadoProcesador += tcc[i].ComisionProcesador.Value;
                        aplicadoClearing += tcc[i].ComisionClearing.Value;
                        aplicadoRed += tcc[i].ComisionRed.Value;
                        aplicadoOtro += tcc[i].ComisionOtro.Value;
                    }

                    transaccion_cierre.InicializarPropiedadesExtendidas(this.TransaccionesCierresMonedaId);
                    if (aplicadoRecaudador + montoRecaudador > transaccion_cierre.ComisionRecaudador)
                        throw new Exception("Sobre el cierre " + transaccion_cierre.Nombre + " ya se pagaron comisiones al recaudador por " + aplicadoRecaudador + " de " + transaccion_cierre.ComisionRecaudador + ".");
                    if (aplicadoProcesador + montoProcesador > transaccion_cierre.ComisionProcesador)
                        throw new Exception("Sobre el cierre " + transaccion_cierre.Nombre + " ya se pagaron comisiones al procesador por " + aplicadoProcesador + " de " + transaccion_cierre.ComisionProcesador + ".");
                    if (aplicadoClearing + montoClearing > transaccion_cierre.ComisionClearing)
                        throw new Exception("Sobre el cierre " + transaccion_cierre.Nombre + " ya se pagaron comisiones al clearing por " + aplicadoClearing + " de " + transaccion_cierre.ComisionClearing + ".");
                    if (aplicadoRed + montoRed > transaccion_cierre.ComisionRed)
                        throw new Exception("Sobre el cierre " + transaccion_cierre.Nombre + " ya se pagaron comisiones a la red por " + aplicadoRed + " de " + transaccion_cierre.ComisionRed + ".");
                    if (aplicadoOtro + montoOtro > transaccion_cierre.ComisionOtro)
                        throw new Exception("Sobre el cierre " + transaccion_cierre.Nombre + " ya se pagaron comisiones a otros por " + aplicadoOtro + " de " + transaccion_cierre.ComisionOtro + ".");

                    transaccionAux.FinalizarUsingSesion();
                    return true;
                }
                #endregion Validar

                #region Ejecutar
                public CBA.FlowV2.Services.Base.Excepciones Ejecutar()
                {
                    using (SessionService sesion = new SessionService())
                    {
                        TransaccionesService transaccionAux = TransaccionesService.Instancia;
                        transaccionAux.IniciarUsingSesion(sesion);

                        try
                        {
                            sesion.BeginTransaction();
                            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

                            if ((this.GenerarAProcesadorAnticipo || this.GenerarAProcesadorTransferencia) && this.GenerarAProcesadorProveedorId <= 0 && this.GenerarAProcesadorTransferenciaCtaBancariaDestinoId <= 0)
                                throw new Exception("Debe seleccionar el proveedor para Procesador o una cuenta bancaria");
                            if ((this.GenerarAClearingAnticipo || this.GenerarAClearingTransferencia) && this.GenerarAClearingProveedorUnico && this.GenerarAClearingProveedorId <= 0)
                                throw new Exception("Debe seleccionar el proveedor para Banco Clearing o utilizar el asociado a cada transferencia desmarcando el uso único");
                            if ((this.GenerarARedAnticipo || this.GenerarARedTransferencia) && this.GenerarARedProveedorUnico && this.GenerarARedProveedorId <= 0)
                                throw new Exception("Debe seleccionar el proveedor para Red de Pagos o utilizar el asociado a cada transferencia desmarcando el uso único");
                            if ((this.GenerarAOtroAnticipo || this.GenerarAOtroTransferencia) && this.GenerarAOtroProveedorId <= 0 && this.GenerarAOtroTransferenciaCtaBancariaDestinoId <= 0)
                                throw new Exception("Debe seleccionar el proveedor para Procesador o una cuenta bancaria");
                            
                            DataTable dtCtacteBancariaOrigen = CuentaCorrienteCuentasBancariasService.GetCuentaCorrienteBancariasDataTable(CuentaCorrienteCuentasBancariasService.Id_NombreCol + " = " + this.TransferenciaCtacteBancariaOrigenId, string.Empty, false);
                            decimal monedaOrigenId = (decimal)dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol];
                            decimal cotizacionOrigen = CotizacionesService.GetCotizacionMonedaCompra(SucursalesService.GetPais(this.TransferenciaSucursalId), monedaOrigenId, this.TransferenciaFecha, sesion);
                            decimal casoTransferenciaId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal casoAnticipoId = Definiciones.Error.Valor.EnteroPositivo;
                            decimal proveedorIdAux;

                            Destinatarios destRecaudadores = new Destinatarios(Destinatarios.TipoDestinatario.Recaudador);
                            Destinatarios destProcesadores = new Destinatarios(Destinatarios.TipoDestinatario.Procesador);
                            Destinatarios destBancosClearing = new Destinatarios(Destinatarios.TipoDestinatario.Clearing);
                            Destinatarios destRedes = new Destinatarios(Destinatarios.TipoDestinatario.Red);
                            Destinatarios destOtros = new Destinatarios(Destinatarios.TipoDestinatario.Otro);

                            Dictionary<decimal, decimal> redesPagoVistas = new Dictionary<decimal,decimal>();
                            Dictionary<decimal, decimal> bancosVistos = new Dictionary<decimal,decimal>();

                            #region sumar monto por proveedor y por cierre
                            foreach (TransaccionesCierresService tc in this.lTransaccionesCierres)
                            {
                                List<Filtro> lFiltros = new List<Filtro>();
                                lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = tc.Id.Value });
                                lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.MONEDA_IDColumnName, Valor = this.TransaccionesCierresMonedaId });
                                lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.ANULADOColumnName, Valor = Definiciones.SiNo.No });

                                if (this.TransaccionesCierresFiltrarProveedor)
                                    lFiltros.Add(new Filtro { Columna = TransaccionesService.Modelo.PROVEEDOR_IDColumnName, Valor = this.TransaccionesCierresProveedorId });

                                TransaccionesService[] t = transaccionAux.GetFiltrado<TransaccionesService>(lFiltros.ToArray());

                                for (int i = 0; i < t.Length; i++)
                                {
                                    if (!t[i].ProveedorId.HasValue)
                                    {
                                        excepciones.Agregar("La transacción " + t[i].IdExterno + " no está asociada a un proveedor.", null);
                                        continue;
                                    }

                                    destRecaudadores.Agregar(t[i].ProveedorId.Value, this.TransferenciaSucursalId, this.TransferenciaFecha, Definiciones.Error.Valor.EnteroPositivo, this.TransaccionesCierresMonedaId, excepciones, sesion);
                                    destRecaudadores.Sumar(t[i].ProveedorId.Value, t[i].TransaccionCierreId.Value, t[i].ComisionRecaudador);

                                    if (this.GenerarAProcesadorAnticipo || this.GenerarAProcesadorTransferencia)
                                    {
                                        proveedorIdAux = Definiciones.Error.Valor.EnteroPositivo;
                                        if (this.GenerarAProcesadorProveedorId > 0)
                                        {
                                            proveedorIdAux = this.GenerarAProcesadorProveedorId;
                                        }

                                        destProcesadores.Agregar(proveedorIdAux, this.TransferenciaSucursalId, this.TransferenciaFecha, this.GenerarAProcesadorTransferenciaCtaBancariaDestinoId, this.TransaccionesCierresMonedaId, excepciones, sesion);
                                        destProcesadores.Sumar(proveedorIdAux, t[i].TransaccionCierreId.Value, t[i].ComisionProcesador);
                                    }

                                    if (this.GenerarAClearingAnticipo || this.GenerarAClearingTransferencia)
                                    {
                                        proveedorIdAux = Definiciones.Error.Valor.EnteroPositivo;
                                        if (this.GenerarAClearingProveedorUnico)
                                        {
                                            proveedorIdAux = this.GenerarAClearingProveedorId;
                                        }
                                        else
                                        {
                                            if (!bancosVistos.ContainsKey(t[i].CtacteBancoClearingId.Value))
                                                bancosVistos.Add(t[i].CtacteBancoClearingId.Value, CuentaCorrienteBancosService.GetProveedor(t[i].CtacteBancoClearingId.Value, sesion));

                                            proveedorIdAux = bancosVistos[t[i].CtacteBancoClearingId.Value];
                                        }

                                        if (proveedorIdAux != Definiciones.Error.Valor.EnteroPositivo)
                                        {
                                            destBancosClearing.Agregar(proveedorIdAux, this.TransferenciaSucursalId, this.TransferenciaFecha, Definiciones.Error.Valor.EnteroPositivo, this.TransaccionesCierresMonedaId, excepciones, sesion);
                                            destBancosClearing.Sumar(proveedorIdAux, t[i].TransaccionCierreId.Value, t[i].ComisionClearing);
                                        }
                                        else
                                        {
                                            excepciones.Agregar("El Banco Clearing id " + t[i].CtacteBancoClearingId + " no tiene asociado un proveedor.", null);
                                        }
                                    }

                                    if (this.GenerarARedAnticipo || this.GenerarARedTransferencia)
                                    {
                                        proveedorIdAux = Definiciones.Error.Valor.EnteroPositivo;
                                        if (this.GenerarARedProveedorUnico)
                                        {
                                            proveedorIdAux = this.GenerarARedProveedorId;
                                        }
                                        else
                                        {
                                            if (!redesPagoVistas.ContainsKey(t[i].CtacteRedPagoId.Value))
                                                redesPagoVistas.Add(t[i].CtacteRedPagoId.Value, CuentaCorrienteRedesPagosService.GetProveedorId(t[i].CtacteRedPagoId.Value, sesion));

                                            proveedorIdAux = redesPagoVistas[t[i].CtacteRedPagoId.Value];
                                        }

                                        if (proveedorIdAux != Definiciones.Error.Valor.EnteroPositivo)
                                        {
                                            destRedes.Agregar(proveedorIdAux, this.TransferenciaSucursalId, this.TransferenciaFecha, Definiciones.Error.Valor.EnteroPositivo, this.TransaccionesCierresMonedaId, excepciones, sesion);
                                            destRedes.Sumar(proveedorIdAux, t[i].TransaccionCierreId.Value, t[i].ComisionRed);
                                        }
                                        else
                                        {
                                            excepciones.Agregar("La Red de Pagos id " + t[i].CtacteRedPagoId + " no tiene asociada un proveedor.", null);
                                        }
                                    }

                                    if (this.GenerarAOtroAnticipo || this.GenerarAOtroTransferencia)
                                    {
                                        proveedorIdAux = Definiciones.Error.Valor.EnteroPositivo;
                                        if (this.GenerarAOtroProveedorId > 0)
                                        {
                                            proveedorIdAux = this.GenerarAOtroProveedorId;
                                        }

                                        destOtros.Agregar(proveedorIdAux, this.TransferenciaSucursalId, this.TransferenciaFecha, this.GenerarAOtroTransferenciaCtaBancariaDestinoId, this.TransaccionesCierresMonedaId, excepciones, sesion);
                                        destOtros.Sumar(proveedorIdAux, t[i].TransaccionCierreId.Value, t[i].ComisionOtro);
                                    }
                                }

                                Validar(tc, destRecaudadores, destProcesadores, destBancosClearing, destRedes, destOtros, sesion);
                            }
                            #endregion sumar monto por proveedor y por cierre

                            if (this.GenerarARecaudadorTransferencia || this.GenerarARecaudadorAnticipo)
                            {
                                foreach (KeyValuePair<decimal, DestinatarioCtaBancaria> dProveedorItem in destRecaudadores.Proveedores)
                                {
                                    if (this.GenerarARecaudadorTransferencia)
                                        casoTransferenciaId = this.CrearTransferencia(dtCtacteBancariaOrigen, destRecaudadores, dProveedorItem.Key, sesion);
    
                                    if (this.GenerarARecaudadorAnticipo)
                                        casoAnticipoId = this.CrearAnticipo(destRecaudadores, dProveedorItem.Key, sesion);
                                    
                                    if (this.GenerarARecaudadorTransferencia && this.GenerarARecaudadorAnticipo)
                                    {
                                        this.CrearOrdenPago(casoAnticipoId, casoTransferenciaId, this.GenerarARecaudadorOPCajaTesoreriaId, this.GenerarARecaudadorOPAutonumeracionId, sesion);
                                    }
                                }
                            }

                            if (this.GenerarAProcesadorTransferencia || this.GenerarAProcesadorAnticipo)
                            {
                                foreach (KeyValuePair<decimal, DestinatarioCtaBancaria> dProveedorItem in destProcesadores.Proveedores)
                                {
                                    if (this.GenerarAProcesadorTransferencia)
                                        casoTransferenciaId = this.CrearTransferencia(dtCtacteBancariaOrigen, destProcesadores, dProveedorItem.Key, sesion);

                                    if (this.GenerarAProcesadorAnticipo)
                                        casoAnticipoId = this.CrearAnticipo(destProcesadores, dProveedorItem.Key, sesion);

                                    if (this.GenerarAProcesadorTransferencia && this.GenerarAProcesadorAnticipo)
                                    {
                                        this.CrearOrdenPago(casoAnticipoId, casoTransferenciaId, this.GenerarAProcesadorOPCajaTesoreriaId, this.GenerarAProcesadorOPAutonumeracionId, sesion);
                                    }
                                }
                            }

                            if (this.GenerarAClearingTransferencia || this.GenerarAClearingAnticipo)
                            {
                                foreach (KeyValuePair<decimal, DestinatarioCtaBancaria> dProveedorItem in destBancosClearing.Proveedores)
                                {
                                    if (this.GenerarAClearingTransferencia)
                                        casoTransferenciaId = this.CrearTransferencia(dtCtacteBancariaOrigen, destBancosClearing, dProveedorItem.Key, sesion);

                                    if (this.GenerarAClearingAnticipo)
                                        casoAnticipoId = this.CrearAnticipo(destBancosClearing, dProveedorItem.Key, sesion);

                                    if (this.GenerarAClearingTransferencia && this.GenerarAClearingAnticipo)
                                    {
                                        this.CrearOrdenPago(casoAnticipoId, casoTransferenciaId, this.GenerarAClearingOPCajaTesoreriaId, this.GenerarAClearingOPAutonumeracionId, sesion);
                                    }
                                }
                            }

                            if (this.GenerarARedTransferencia || this.GenerarARedAnticipo)
                            {
                                foreach (KeyValuePair<decimal, DestinatarioCtaBancaria> dProveedorItem in destRedes.Proveedores)
                                {
                                    if (this.GenerarARedTransferencia)
                                        casoTransferenciaId = this.CrearTransferencia(dtCtacteBancariaOrigen, destRedes, dProveedorItem.Key, sesion);

                                    if (this.GenerarARedAnticipo)
                                        casoAnticipoId = this.CrearAnticipo(destRedes, dProveedorItem.Key, sesion);

                                    if (this.GenerarARedTransferencia && this.GenerarARedAnticipo)
                                    {
                                        this.CrearOrdenPago(casoAnticipoId, casoTransferenciaId, this.GenerarARedOPCajaTesoreriaId, this.GenerarARedOPAutonumeracionId, sesion);
                                    }
                                }
                            }

                            if (this.GenerarAOtroTransferencia || this.GenerarAOtroAnticipo)
                            {
                                foreach (KeyValuePair<decimal, DestinatarioCtaBancaria> dProveedorItem in destOtros.Proveedores)
                                {
                                    if (this.GenerarAOtroTransferencia)
                                        casoTransferenciaId = this.CrearTransferencia(dtCtacteBancariaOrigen, destOtros, dProveedorItem.Key, sesion);

                                    if (this.GenerarAOtroAnticipo)
                                        casoAnticipoId = this.CrearAnticipo(destOtros, dProveedorItem.Key, sesion);

                                    if (this.GenerarAOtroTransferencia && this.GenerarAOtroAnticipo)
                                    {
                                        this.CrearOrdenPago(casoAnticipoId, casoTransferenciaId, this.GenerarAOtroOPCajaTesoreriaId, this.GenerarAOtroOPAutonumeracionId, sesion);
                                    }
                                }
                            }

                            transaccionAux.FinalizarUsingSesion();
                            sesion.CommitTransaction();
                            return excepciones;
                        }
                        catch
                        {
                            transaccionAux.FinalizarUsingSesion();
                            sesion.RollbackTransaction();
                            throw;
                        }
                    }
                }
                #endregion Ejecutar

                #region CrearTransferencia
                private decimal CrearTransferencia(DataTable dtCtacteBancariaOrigen, Destinatarios destinatarios, decimal proveedor_id, SessionService sesion)
                {
                    DestinatarioCtaBancaria destinatarioCtaBancaria = destinatarios.Proveedores[proveedor_id];

                    TransferenciasBancariasService transferenciaBancaria = new TransferenciasBancariasService();
                    string casoCreadoEstado = string.Empty;
                    string mensaje = string.Empty;
                    decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                    bool exito;

                    Hashtable campos = new Hashtable();

                    #region cargar campos
                    //Campos estaticos defecto
                    campos.Add(TransferenciasBancariasService.NumeroTransaccion_NombreCol, string.Empty);
                    campos.Add(TransferenciasBancariasService.NumeroSolicitud_NombreCol, string.Empty);
                    campos.Add(TransferenciasBancariasService.Observacion_NombreCol, string.Empty);
                    campos.Add(TransferenciasBancariasService.CuentaOrigenAdministrada_NombreCol, Definiciones.SiNo.Si);
                    campos.Add(TransferenciasBancariasService.CuentaOrigenTerceros_NombreCol, Definiciones.SiNo.No);
                    campos.Add(TransferenciasBancariasService.SucursalOrigenId_NombreCol, this.TransferenciaSucursalId);
                    campos.Add(TransferenciasBancariasService.CostoTransferencia_NombreCol, (decimal)0);
                    campos.Add(TransferenciasBancariasService.Fecha_NombreCol, this.TransferenciaFecha);
                    campos.Add(TransferenciasBancariasService.CtacteBancoOrigenId_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.CtacteBancoId_NombreCol]);
                    campos.Add(TransferenciasBancariasService.CtacteBancariaOrigenId_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.Id_NombreCol]);
                    campos.Add(TransferenciasBancariasService.NumeroCuentaOrigen_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.NumeroCuenta_NombreCol]);
                    campos.Add(TransferenciasBancariasService.MonedaOrigenId_NombreCol, dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol]);

                    //Campos variables
                    if (this.TransferenciaTextoPredefinidoUsar)
                        campos.Add(TransferenciasBancariasService.TextoPredefinidoId_NombreCol, this.TransferenciaTextoPredefinidoId);
                    campos.Add(TransferenciasBancariasService.MontoDestino_NombreCol, destinatarioCtaBancaria.Monto);
                    campos.Add(TransferenciasBancariasService.CotizacionMonedaDestino_NombreCol, destinatarioCtaBancaria.Cotizacion);
                    campos.Add(TransferenciasBancariasService.MontoOrigen_NombreCol, destinatarioCtaBancaria.Monto);
                    campos.Add(TransferenciasBancariasService.CotizacionMonedaOrigen_NombreCol, destinatarioCtaBancaria.Cotizacion);

                    if (destinatarios.CtacteBancariaPorDefectoId == Definiciones.Error.Valor.EnteroPositivo)
                    {
                        if (destinatarioCtaBancaria.BancariaId <= 0)
                            throw new Exception("No hay una cuenta bancaria asociada.");

                        campos.Add(TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol, Definiciones.SiNo.No);
                        campos.Add(TransferenciasBancariasService.CuentaDestinoTerceros_NombreCol, Definiciones.SiNo.Si);

                        campos.Add(TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol, destinatarioCtaBancaria.BancoId);
                        campos.Add(TransferenciasBancariasService.CtaCteBancTercerosDestId_NombreCol, destinatarioCtaBancaria.BancariaId);
                        campos.Add(TransferenciasBancariasService.NumeroCuentaDestino_NombreCol, destinatarioCtaBancaria.NroCuenta);
                        campos.Add(TransferenciasBancariasService.MonedaDestinoId_NombreCol, destinatarioCtaBancaria.MonedaId);
                        
                    }
                    else
                    {
                        campos.Add(TransferenciasBancariasService.CuentaDestinoAdministrada_NombreCol, Definiciones.SiNo.Si);
                        campos.Add(TransferenciasBancariasService.CuentaDestinoTerceros_NombreCol, Definiciones.SiNo.No);

                        campos.Add(TransferenciasBancariasService.CtacteBancoDestinoId_NombreCol, destinatarios.CtacteBancariaPorDefecto.CtacteBancoId);
                        campos.Add(TransferenciasBancariasService.CtacteBancariaDestinoId_NombreCol, destinatarios.CtacteBancariaPorDefecto.Id);
                        campos.Add(TransferenciasBancariasService.NumeroCuentaDestino_NombreCol, destinatarios.CtacteBancariaPorDefecto.NumeroCuenta);
                        campos.Add(TransferenciasBancariasService.MonedaDestinoId_NombreCol, destinatarios.CtacteBancariaPorDefecto.MonedaId);
                    }
                    #endregion cargar campos

                    TransferenciasBancariasService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                    
                    #region cambiar de estado la transferencia
                    exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                    if (exito)
                        transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    if (exito)
                        exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                    if (exito)
                        transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                    if (exito)
                        exito = transferenciaBancaria.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                    if (exito)
                        transferenciaBancaria.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                    #endregion cambiar de estado la transferencia

                    #region registrar que el caso de Anticipo afecta al cierre
                    foreach (KeyValuePair<decimal, decimal> item in destinatarios.CierresCasos[proveedor_id])
                    {
                        TransaccionesCierresCasosService tcc = new TransaccionesCierresCasosService();
                        tcc.IniciarUsingSesion(sesion);
                        tcc.ComisionRecaudador = tcc.ComisionProcesador = tcc.ComisionClearing = tcc.ComisionRed = tcc.ComisionOtro = 0;
                        tcc.CasoId = casoCreadoId;
                        tcc.FlujoId = Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA;
                        tcc.Cotizacion = destinatarioCtaBancaria.Cotizacion;
                        tcc.MonedaId = (decimal)dtCtacteBancariaOrigen.Rows[0][CuentaCorrienteCuentasBancariasService.MonedaId_NombreCol];
                        tcc.MontoTotal = item.Value;
                        tcc.TransaccionCierreId = item.Key;
                        tcc.Guardar();
                        tcc.FinalizarUsingSesion();
                    }
                    #endregion registrar que el caso de Anticipo afecta al cierre

                    return casoCreadoId;
                }
                #endregion Crear Transferencia

                #region Crear Anticipo
                private decimal CrearAnticipo(Destinatarios destinatarios, decimal proveedor_id, SessionService sesion)
                {
                    AnticiposProveedorService anticipoProveedor = new AnticiposProveedorService();
                    string casoCreadoEstado = string.Empty;
                    string mensaje = string.Empty;
                    decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo, monedaId;
                    bool exito;
                    Hashtable campos = new Hashtable();

                    DestinatarioCtaBancaria destinatarioCtaBancaria = destinatarios.Proveedores[proveedor_id];

                    if (destinatarios.CtacteBancariaPorDefectoId == Definiciones.Error.Valor.EnteroPositivo)
                        monedaId = destinatarioCtaBancaria.MonedaId;
                    else
                        monedaId = destinatarios.CtacteBancariaPorDefecto.MonedaId;
                    

                    campos.Add(AnticiposProveedorService.SucursalId_NombreCol, this.AnticipoSucursalId);
                    campos.Add(AnticiposProveedorService.ProveedorId_NombreCol, proveedor_id);
                    campos.Add(AnticiposProveedorService.Fecha_NombreCol, this.AnticipoFecha);
                    campos.Add(AnticiposProveedorService.AutonmeracionId_NombreCol, this.AnticipoAutonumeracionId);
                    campos.Add(AnticiposProveedorService.MontoTotal_NombreCol, destinatarioCtaBancaria.Monto);
                    campos.Add(AnticiposProveedorService.MontoRetencion_NombreCol, (decimal)0);
                    campos.Add(AnticiposProveedorService.CotizacionMoneda_NombreCol, destinatarioCtaBancaria.Cotizacion);
                    campos.Add(AnticiposProveedorService.MonedaId_NombreCol, monedaId);

                    AnticiposProveedorService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);

                    #region Aprobar el caso de Anticipo
                    //Pasar a Pendiente
                    exito = anticipoProveedor.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                    if (exito)
                        anticipoProveedor.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    //Pasar a Aprobado
                    if (exito)
                        exito = anticipoProveedor.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                    if (exito)
                        anticipoProveedor.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, sesion);
                    #endregion Aprobar el caso de FC Cliente

                    #region registrar que el caso de Anticipo afecta al cierre
                    foreach (KeyValuePair<decimal, decimal> item in destinatarios.CierresCasos[proveedor_id])
                    {
                        TransaccionesCierresCasosService tcc = new TransaccionesCierresCasosService();
                        tcc.IniciarUsingSesion(sesion);
                        tcc.ComisionRecaudador = tcc.ComisionProcesador = tcc.ComisionClearing = tcc.ComisionRed = tcc.ComisionOtro = 0;
                        tcc.CasoId = casoCreadoId;
                        tcc.FlujoId = Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR;
                        tcc.Cotizacion = destinatarioCtaBancaria.Cotizacion;
                        tcc.MonedaId = monedaId;
                        switch (destinatarios.Tipo)
                        {
                            case Destinatarios.TipoDestinatario.Recaudador: tcc.ComisionRecaudador = item.Value; break;
                            case Destinatarios.TipoDestinatario.Procesador: tcc.ComisionProcesador = item.Value; break;
                            case Destinatarios.TipoDestinatario.Clearing: tcc.ComisionClearing = item.Value; break;
                            case Destinatarios.TipoDestinatario.Red: tcc.ComisionRed = item.Value; break;
                            case Destinatarios.TipoDestinatario.Otro: tcc.ComisionOtro = item.Value; break;
                        }
                        tcc.MontoTotal = item.Value;
                        tcc.TransaccionCierreId = item.Key;
                        tcc.Guardar();
                        tcc.FinalizarUsingSesion();
                    }
                    #endregion registrar que el caso de Anticipo afecta al cierre

                    return casoCreadoId;
                }
                #endregion Crear Anticipo

                #region Crear Orden Pago
                private void CrearOrdenPago(decimal caso_anticipo_id, decimal caso_transferencia_id, decimal caja_tesoreria_id, decimal autonumeracion_id, SessionService sesion)
                {
                    OrdenesPagoService ordenPago = new OrdenesPagoService();
                    string casoCreadoEstado = string.Empty;
                    string mensaje = string.Empty;
                    decimal casoCreadoId = Definiciones.Error.Valor.EnteroPositivo;
                    bool exito;
                    DataTable dtAnticipo = AnticiposProveedorService.GetAnticipoProveedorDataTable(AnticiposProveedorService.CasoId_NombreCol + " = " + caso_anticipo_id, string.Empty, sesion);
                    DataTable dtTransferencia = TransferenciasBancariasService.GetDataTable(TransferenciasBancariasService.CasoId_NombreCol + " = " + caso_transferencia_id, string.Empty, sesion);
                    DataTable dtOrdenPago;
                    Hashtable campos;

                    campos = new Hashtable();
                    campos.Add(OrdenesPagoService.AutonumeracionId_NombreCol, autonumeracion_id);
                    campos.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, this.AnticipoSucursalId);
                    campos.Add(OrdenesPagoService.Fecha_NombreCol, this.AnticipoFecha);
                    campos.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, Definiciones.TiposOrdenesPago.RespaldoAnticipoProveedor);
                    campos.Add(OrdenesPagoService.MonedaId_NombreCol, this.AnticipoMonedaId);
                    campos.Add(OrdenesPagoService.CotizacionMoneda_NombreCol, dtAnticipo.Rows[0][AnticiposProveedorService.CotizacionMoneda_NombreCol]);
                    campos.Add(OrdenesPagoService.MontoTotal_NombreCol, dtAnticipo.Rows[0][AnticiposProveedorService.MontoTotal_NombreCol]);
                    campos.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, caja_tesoreria_id);
                    campos.Add(OrdenesPagoService.Observacion_NombreCol, string.Empty);
                    OrdenesPagoService.Guardar(campos, true, ref casoCreadoId, ref casoCreadoEstado, sesion);
                    dtOrdenPago = OrdenesPagoService.GetOrdenesPagoDataTable(OrdenesPagoService.CasoId_NombreCol + " = " + casoCreadoId, string.Empty, sesion);

                    campos = new Hashtable();
                    campos.Add(OrdenesPagoDetalleService.OrdenPagoId_NombreCol, dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol]);
                    campos.Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, this.AnticipoMonedaId);
                    campos.Add(OrdenesPagoDetalleService.FlujoReferidoId_NombreCol, Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR);
                    campos.Add(OrdenesPagoDetalleService.Observacion_NombreCol, string.Empty);
                    campos.Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, caso_anticipo_id);
                    campos.Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, dtAnticipo.Rows[0][AnticiposProveedorService.MontoTotal_NombreCol]);
                    OrdenesPagoDetalleService.Guardar(campos, sesion);

                    campos = new Hashtable();
                    campos.Add(OrdenesPagoValoresService.OrdenPagoId_NombreCol, dtOrdenPago.Rows[0][OrdenesPagoService.Id_NombreCol]);
                    campos.Add(OrdenesPagoValoresService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.TransferenciaBancaria);
                    campos.Add(OrdenesPagoValoresService.MonedaOrigenId_NombreCol, this.AnticipoMonedaId);
                    campos.Add(OrdenesPagoValoresService.MontoOrigen_NombreCol, dtAnticipo.Rows[0][AnticiposProveedorService.MontoTotal_NombreCol]);
                    campos.Add(OrdenesPagoValoresService.CotizacionMonedaDestino_NombreCol, dtAnticipo.Rows[0][AnticiposProveedorService.CotizacionMoneda_NombreCol]);
                    campos.Add(OrdenesPagoValoresService.Observacion_NombreCol, string.Empty);
                    campos.Add(OrdenesPagoValoresService.TransferenciaBancariaId_NombreCol, dtTransferencia.Rows[0][TransferenciasBancariasService.Id_NombreCol]);
                    OrdenesPagoValoresService.Guardar(campos, sesion);

                    #region Aprobar el caso de OP
                    exito = ordenPago.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Pendiente, sesion);

                    if (exito)
                        exito = ordenPago.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Aprobado, sesion);

                    if (exito)
                        exito = ordenPago.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Generacion, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Generacion, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Generacion, sesion);

                    if (exito)
                        exito = ordenPago.ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, false, out mensaje, sesion);
                    if (exito)
                        exito = (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, string.Empty, sesion);
                    if (exito)
                        ordenPago.EjecutarAccionesLuegoDeCambioEstado(casoCreadoId, Definiciones.EstadosFlujos.Cerrado, sesion);
                    #endregion Aprobar el caso de OP
                }
                #endregion Crear Orden Pago
            }
            #endregion clase CrearTransferenciaComisiones
        }
        #endregion clase Acciones
    
        #region Propiedades
        protected TRANSACCIONESRow row;
        protected TRANSACCIONESRow rowSinModificar;
        public class Modelo : TRANSACCIONESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Anulado { get { return row.ANULADO; } set { row.ANULADO = value; } }
        public decimal ComisionClearing { get { return row.IsCOMISION_CLEARINGNull ? 0 : row.COMISION_CLEARING; } set { row.COMISION_CLEARING = value; } }
        public decimal ComisionOtro { get { return row.IsCOMISION_OTRONull ? 0 : row.COMISION_OTRO; } set { row.COMISION_OTRO = value; } }
        public decimal ComisionProcesador { get { return row.IsCOMISION_PROCESADORNull ? 0 : row.COMISION_PROCESADOR; } set { row.COMISION_PROCESADOR = value; } }
        public decimal ComisionRecaudador { get { return row.IsCOMISION_RECAUDADORNull ? 0 : row.COMISION_RECAUDADOR; } set { row.COMISION_RECAUDADOR = value; } }
        public decimal ComisionRed { get { return row.IsCOMISION_REDNull ? 0 : row.COMISION_RED; } set { row.COMISION_RED = value; } }
        public decimal ComisionTotal { get { return row.IsCOMISION_TOTALNull ? 0 : row.COMISION_TOTAL; } set { row.COMISION_TOTAL = value; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { if (value == Definiciones.Error.Valor.EnteroPositivo) throw new Exception("Debe actualizar la moneda."); row.COTIZACION = value; } }
        public decimal? CtacteBancoClearingId { get { if (row.IsCTACTE_BANCO_CLEARING_IDNull) return null; else return row.CTACTE_BANCO_CLEARING_ID; } set { if (value.HasValue) row.CTACTE_BANCO_CLEARING_ID = value.Value; else row.IsCTACTE_BANCO_CLEARING_IDNull = true; } }
        public decimal? CtactePersonaId { get { if (row.IsCTACTE_PERSONA_IDNull) return null; else return row.CTACTE_PERSONA_ID; } set { if (value.HasValue) row.CTACTE_PERSONA_ID = value.Value; else row.IsCTACTE_PERSONA_IDNull = true; } }
        public decimal? CtacteRedPagoId { get { if (row.IsCTACTE_RED_PAGO_IDNull) return null; else return row.CTACTE_RED_PAGO_ID; } set { if (value.HasValue) row.CTACTE_RED_PAGO_ID = value.Value; else row.IsCTACTE_RED_PAGO_IDNull = true; } }
        public int? CtacteValorId { get { if (row.IsCTACTE_VALOR_IDNull) return null; else return int.Parse(row.CTACTE_VALOR_ID.ToString()); } set { if (value.HasValue) row.CTACTE_VALOR_ID = value.Value; else row.IsCTACTE_VALOR_IDNull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime? FechaAcreditacion { get { if (row.IsFECHA_ACREDITACIONNull) return null; else return row.FECHA_ACREDITACION; } set { if (value.HasValue) row.FECHA_ACREDITACION = value.Value; else row.IsFECHA_ACREDITACIONNull = true; } }
        public DateTime? FechaAnulacion { get { if (row.IsFECHA_ANULACIONNull) return null; else return row.FECHA_ANULACION; } set { if (value.HasValue) row.FECHA_ANULACION = value.Value; else row.IsFECHA_ANULACIONNull = true; } }
        public DateTime? FechaCorte { get { if (row.IsFECHA_CORTENull) return null; else return row.FECHA_CORTE; } set { if (value.HasValue) row.FECHA_CORTE = value.Value; else row.IsFECHA_CORTENull = true; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } private set { row.FECHA_CREACION = value; } }
        public DateTime? FechaTransaccion { get { if (row.IsFECHA_TRANSACCIONNull) return null; else return row.FECHA_TRANSACCION; } set { if (value.HasValue) row.FECHA_TRANSACCION = value.Value; else row.IsFECHA_TRANSACCIONNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal IdExterno { get { return row.ID_EXTERNO; } set { row.ID_EXTERNO = value; } }
        public string JSON { get { return row.JSON; } set { row.JSON = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal MontoCapital { get { return row.MONTO_CAPITAL; } set { row.MONTO_CAPITAL = value; } }
        public decimal MontoGastoAdministrativo { get { return row.MONTO_GASTO_ADMINISTRATIVO; } set { row.MONTO_GASTO_ADMINISTRATIVO = value; } }
        public decimal MontoIntereses { get { return row.MONTO_INTERESES; } set { row.MONTO_INTERESES = value; } }
        public decimal MontoTotal { get { return row.MONTO_TOTAL; } set { row.MONTO_TOTAL = value; } }
        public string NroComprobante { get { return row.NRO_COMPROBANTE; } set { row.NRO_COMPROBANTE = value; } }
        public string NroTransaccion { get { return row.NRO_TRANSACCION; } set { row.NRO_TRANSACCION = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public string Procesado { get { return row.PROCESADO; } set { row.PROCESADO = value; } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal? SucursalId { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public decimal? TransaccionCierreId { get { if (row.IsTRANSACCION_CIERRE_IDNull) return null; else return row.TRANSACCION_CIERRE_ID; } set { if (value.HasValue) row.TRANSACCION_CIERRE_ID = value.Value; else row.IsTRANSACCION_CIERRE_IDNull = true; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } private set { row.USUARIO_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
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

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (!this.PersonaId.HasValue)
                    throw new Exception("No hay una persona asociada");

                if (this._persona == null)
                    this._persona = new PersonasService(this.PersonaId.Value);

                return this._persona;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (!this.ProveedorId.HasValue)
                    throw new Exception("No hay un proveedor asociado");

                if (this._proveedor == null)
                    this._proveedor = new ProveedoresService(this.ProveedorId.Value);

                return this._proveedor;
            }
        }
        #endregion Propiedades Extendidas
        
        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TRANSACCIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TRANSACCIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TRANSACCIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TransaccionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TransaccionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TransaccionesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TransaccionesService(TRANSACCIONESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        public static CBA.FlowV2.Services.Base.Excepciones Guardar(TransaccionesService[] transacciones)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

                    for (int i = 0; i < transacciones.Length; i++)
                    {
                        try
                        {
                            transacciones[i].IniciarUsingSesion(sesion);
                            transacciones[i].Guardar();
                            transacciones[i].FinalizarUsingSesion();
                        }
                        catch (Exception e)
                        {
                            transacciones[i].FinalizarUsingSesion();
                            excepciones.Agregar(e.Message, e);
                        }
                    }

                    sesion.CommitTransaction();
                    return excepciones;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();
            
            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.FechaCreacion = DateTime.Now;
                this.UsuarioId = sesion.Usuario.ID;
                sesion.db.TRANSACCIONESCollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.TRANSACCIONESCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            //El id externo no puede duplicarse
            string clausulas = TRANSACCIONESCollection.ID_EXTERNOColumnName + " = " + this.IdExterno + " and " +
                               TRANSACCIONESCollection.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            if (this.ExisteEnDB)
                clausulas += " and " + TRANSACCIONESCollection.IDColumnName + " <> " + this.Id;
            
            TRANSACCIONESRow[] t = sesion.db.TRANSACCIONESCollection.GetAsArray(clausulas, string.Empty);
            if(t.Length > 0)
                excepciones.Agregar("La transacción con ID Externo " + this.IdExterno + " ya existe.", null);

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._moneda = null;
            this._persona = null;
            this._proveedor = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override TransaccionesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

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
                        case Modelo.CTACTE_BANCO_CLEARING_IDColumnName:
                        case Modelo.CTACTE_PERSONA_IDColumnName:
                        case Modelo.CTACTE_RED_PAGO_IDColumnName:
                        case Modelo.CTACTE_VALOR_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.PERSONA_IDColumnName:
                        case Modelo.PROVEEDOR_IDColumnName:
                        case Modelo.SUCURSAL_IDColumnName:
                        case Modelo.TRANSACCION_CIERRE_IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.ANULADOColumnName:
                        case Modelo.ID_EXTERNOColumnName:
                        case Modelo.NRO_COMPROBANTEColumnName:
                        case Modelo.NRO_TRANSACCIONColumnName:
                        case Modelo.PROCESADOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.COMISION_CLEARINGColumnName:
                        case Modelo.COMISION_OTROColumnName:
                        case Modelo.COMISION_PROCESADORColumnName:
                        case Modelo.COMISION_RECAUDADORColumnName:
                        case Modelo.COMISION_REDColumnName:
                        case Modelo.COMISION_TOTALColumnName:
                        case Modelo.MONTO_CAPITALColumnName:
                        case Modelo.MONTO_GASTO_ADMINISTRATIVOColumnName:
                        case Modelo.MONTO_INTERESESColumnName:
                        case Modelo.MONTO_TOTALColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.FECHA_ACREDITACIONColumnName:
                        case Modelo.FECHA_ANULACIONColumnName:
                        case Modelo.FECHA_CORTEColumnName:
                        case Modelo.FECHA_CREACIONColumnName:
                        case Modelo.FECHA_TRANSACCIONColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            TRANSACCIONESRow[] rows = sesion.db.TRANSACCIONESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TransaccionesService[] uid = new TransaccionesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                uid[i] = new TransaccionesService(rows[i]);
            return uid;
        }
        #endregion Buscar

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

        #region ImportarWebService
        public static List<TransaccionesService> ImportarWebService(DateTime desde, DateTime hasta, out CBA.FlowV2.Services.Base.Excepciones excepciones)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    List<TransaccionesService> l = new List<TransaccionesService>();
                    switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                    {
                        case Definiciones.Clientes.Electroban:
                            l = ImportarWebService_9(desde, hasta, out excepciones, sesion);
                            break;
                        case Definiciones.Clientes.Documenta:
                            l = ImportarWebService_13(desde, hasta, out excepciones, sesion);
                            break;
                        default: throw new Exception("TransaccionesService.ImportarWebService(). Cliente no implementado.");
                    }

                    return l;
                }
                catch
                {
                    throw;
                }
            }
        }

        private static List<TransaccionesService> ImportarWebService_9(DateTime desde, DateTime hasta, out CBA.FlowV2.Services.Base.Excepciones excepciones, SessionService sesion)
        {
            throw new NotImplementedException("Cliente no implementado");
        }
        private static List<TransaccionesService> ImportarWebService_13(DateTime desde, DateTime hasta, out CBA.FlowV2.Services.Base.Excepciones excepciones, SessionService sesion)
        {
            excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            List<TransaccionesService> l = new List<TransaccionesService>();
            string txtDesde = desde.ToString("ddMMyyyy");
            string txtHasta = hasta.ToString("ddMMyyyy");
            decimal paisId = SucursalesService.GetPais(sesion.Usuario.SUCURSAL_ACTIVA_ID);
            DataTable dtRedesPago = new DataTable(), dtCtacteBanco = new DataTable();
            string ultimoProveedorRedPago = string.Empty, ultimoProveedorBancoClearing = string.Empty;

            //string a = "[{'idRecaudador':2,'recaudador':'Coop. Universitaria','idSucursal':20000002,'sucursal':'Suc. Villa morra','idLocalidad':121,'localidad':'Asuncion','idServicio':3,'servicio':'Ande','idTransaccion':20674460,'idCorte':1467,'fechaCorte':'30092016','fechaIngreso':'29092016','fechaAcreditacion':'04/10/2016','redDescripcion':'RED COOP CU','tipoPago':'EFECTIVO','idFacturador':3,'facturador':'Ande','cantidad':1,'recaudado':220320,'comision':4320,'comisionRec':3920,'procesador':227,'bancoClearing':54,'entidadPolitica':119,'comisionProcTrx':0,'entCabecera':0,'moneda':600,'idRed':2,'idBancoClearing':26},{'idRecaudador':2,'recaudador':'Coop. Universitaria','idSucursal':20000002,'sucursal':'Suc. Villa morra','idLocalidad':121,'localidad':'Asuncion','idServicio':26,'servicio':'Personal Recarga','idTransaccion':20674461,'idCorte':1467,'fechaCorte':'30092016','fechaIngreso':'29092016','fechaAcreditacion':'04/10/2016','redDescripcion':'RED COOP CU','tipoPago':'EFECTIVO','idFacturador':17,'facturador':'Nucleo S.A.','cantidad':1,'recaudado':5000,'comision':385,'comisionRec':250,'procesador':127,'bancoClearing':5,'entidadPolitica':3,'comisionProcTrx':0,'entCabecera':0,'moneda':600,'idRed':2,'idBancoClearing':26},{'idRecaudador':2,'recaudador':'Coop. Universitaria','idSucursal':20000021,'sucursal':'CU24HS','idLocalidad':121,'localidad':'Asuncion','idServicio':5,'servicio':'Tigo Star','idTransaccion':151056177,'idCorte':1467,'fechaCorte':'30092016','fechaIngreso':'29092016','fechaAcreditacion':'04/10/2016','redDescripcion':'RED COOP CU','tipoPago':'EFECTIVO','idFacturador':5,'facturador':'Tigo TV','cantidad':1,'recaudado':316000,'comision':6952,'comisionRec':3789,'procesador':2869,'bancoClearing':120,'entidadPolitica':174,'comisionProcTrx':0,'entCabecera':0,'moneda':600,'idRed':2,'idBancoClearing':26},{'idRecaudador':2,'recaudador':'Coop. Universitaria','idSucursal':20000021,'sucursal':'CU24HS','idLocalidad':121,'localidad':'Asuncion','idServicio':6,'servicio':'Essap','idTransaccion':151053638,'idCorte':1467,'fechaCorte':'30092016','fechaIngreso':'29092016','fechaAcreditacion':'04/10/2016','redDescripcion':'RED COOP CU','tipoPago':'EFECTIVO','idFacturador':6,'facturador':'Essap','cantidad':1,'recaudado':73428,'comision':1428,'comisionRec':1171,'procesador':212,'bancoClearing':9,'entidadPolitica':36,'comisionProcTrx':0,'entCabecera':0,'moneda':600,'idRed':2,'idBancoClearing':26}]";
            //List<Dictionary<string, string>> lImportar = JsonUtil.Deserializar<List<Dictionary<string, string>>>(a);

            WebRequest req = WebRequest.Create("http://ws.documenta.com.py:8099/VistasRest/webresources/vtrx/findtrx/" + txtDesde + "/" + txtHasta);
            req.Method = "GET";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("cbaflow:cbaflow"));

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader readStream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            List<Dictionary<string, string>> lImportar = JsonUtil.Deserializar<List<Dictionary<string, string>>>(readStream.ReadToEnd());
            resp.Close();
            readStream.Close();

            if (lImportar == null)
                throw new Exception("Hubo un error en la respuesta a " + req.RequestUri.ToString());

            for (int i = 0; i < lImportar.Count; i++)
            {
                TransaccionesService t = new TransaccionesService();
                l.Add(t);

                t.JSON = JsonUtil.Serializar(lImportar[i]);
                t.Anulado = Definiciones.SiNo.No;
                t.Procesado = Definiciones.SiNo.No;
                t.Estado = Definiciones.Estado.Activo;
                t.UsuarioId = sesion.Usuario.ID;
                t.SucursalId = sesion.Usuario.SUCURSAL_ACTIVA_ID;
                t.FechaCreacion = DateTime.Now;
                t.MontoGastoAdministrativo = 0;
                t.MontoIntereses = 0;

                switch(lImportar[i]["moneda"])
                {
                    case "600":
                        t.MonedaId = Definiciones.Monedas.Guaranies;
                        break;
                    case "700":
                        t.MonedaId = Definiciones.Monedas.Dolares;
                        break;
                    default:
                        throw new Exception("Id de moneda " + lImportar[i]["moneda"] + " no reconocida.");
                }

                t.IdExterno = decimal.Parse(lImportar[i]["idTransaccion"]);
                t.NroComprobante = lImportar[i]["idTransaccion"];
                t.NroTransaccion = lImportar[i]["idTransaccion"];

                t.PersonaId = PersonasService.GetPersonaIdPorCodigo(lImportar[i]["idFacturador"]);
                if (t.PersonaId == Definiciones.Error.Valor.EnteroPositivo)
                    t.PersonaId = PersonasService.CrearPersona(lImportar[i]["facturador"], string.Empty, "000000", lImportar[i]["idFacturador"], false);

                t.ProveedorId = ProveedoresService.GetProveedorIdPorCodigo(lImportar[i]["idRecaudador"]);
                if (t.ProveedorId == Definiciones.Error.Valor.EnteroPositivo)
                    t.ProveedorId = ProveedoresService.Crear(lImportar[i]["recaudador"], "000000", lImportar[i]["idRecaudador"]);

                if (ultimoProveedorBancoClearing == lImportar[i]["idBancoClearing"] && dtCtacteBanco.Rows.Count > 0)
                {
                    t.CtacteBancoClearingId = (decimal)dtCtacteBanco.Rows[0][CuentaCorrienteBancosService.Id_NombreCol];
                }
                else
                {
                    ultimoProveedorBancoClearing = lImportar[i]["idBancoClearing"];
                    decimal proveedorIdAux = ProveedoresService.GetProveedorIdPorCodigo(ultimoProveedorBancoClearing);
                    if (proveedorIdAux != Definiciones.Error.Valor.EnteroPositivo)
                    {
                        dtCtacteBanco = CuentaCorrienteBancosService.GetBancosDataTable(CuentaCorrienteBancosService.ProveedorId_NombreCol + " = " + proveedorIdAux, string.Empty);
                        if (dtCtacteBanco.Rows.Count <= 0)
                            throw new Exception("El próveedor código " + lImportar[i]["idBancoClearing"] + " no está relacionado a ningún banco.");
                        t.CtacteBancoClearingId = (decimal)dtCtacteBanco.Rows[0][CuentaCorrienteBancosService.Id_NombreCol];
                    }
                }

                if (ultimoProveedorRedPago == lImportar[i]["idRed"] && dtRedesPago.Rows.Count > 0)
                {
                    t.CtacteRedPagoId = (decimal)dtRedesPago.Rows[0][CuentaCorrienteRedesPagosService.Id_NombreCol];
                }
                else
                {
                    ultimoProveedorRedPago = lImportar[i]["idRed"];
                    decimal proveedorIdAux = ProveedoresService.GetProveedorIdPorCodigo(ultimoProveedorRedPago);
                    if (proveedorIdAux != Definiciones.Error.Valor.EnteroPositivo)
                    {
                        dtRedesPago = CuentaCorrienteRedesPagosService.GetRedesPagoDataTable(CuentaCorrienteRedesPagosService.ProveedorId_NombreCol + " = " + proveedorIdAux, string.Empty);
                        if (dtRedesPago.Rows.Count <= 0)
                            throw new Exception("El próveedor código " + lImportar[i]["idRed"] + " no está relacionado a ninguna red de pagos.");
                        t.CtacteRedPagoId = (decimal)dtRedesPago.Rows[0][CuentaCorrienteRedesPagosService.Id_NombreCol];
                    }
                }
                  
                t.FechaAcreditacion = DateTime.ParseExact(lImportar[i]["fechaAcreditacion"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                t.FechaCorte = DateTime.ParseExact(lImportar[i]["fechaCorte"], "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                t.FechaTransaccion = DateTime.ParseExact(lImportar[i]["fechaIngreso"], "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                t.Cotizacion = CotizacionesService.GetCotizacionMonedaCompra(paisId, t.MonedaId, t.FechaTransaccion.Value);

                t.MontoCapital = decimal.Parse(lImportar[i]["recaudado"].Replace('.', ','));
                t.MontoTotal = t.MontoCapital;

                t.ComisionClearing = decimal.Parse(lImportar[i]["bancoClearing"].Replace('.', ','));
                t.ComisionOtro = decimal.Parse(lImportar[i]["entidadPolitica"].Replace('.', ','));
                t.ComisionProcesador = decimal.Parse(lImportar[i]["procesador"].Replace('.', ','));
                t.ComisionRecaudador = decimal.Parse(lImportar[i]["comisionRec"].Replace('.', ','));
                t.ComisionRed = decimal.Parse(lImportar[i]["comisionProcTrx"].Replace('.', ','));
                t.ComisionTotal = decimal.Parse(lImportar[i]["comision"].Replace('.', ','));
            }

            return l;
        }
        #endregion ImportarWebService

        #region Accessors
        public static string Nombre_Tabla = "TRANSACCIONES";
        public static string Nombre_Secuencia = "TRANSACCIONES_SQC";

        #region tabla

        public static string Id_NombreCol
        {
            get { return TRANSACCIONESCollection.IDColumnName; }
        }

        public static string IdExterno_NombreCol
        {
            get { return TRANSACCIONESCollection.ID_EXTERNOColumnName; }
        }

        public static string SucursalId_NombreCol
        {
            get { return TRANSACCIONESCollection.SUCURSAL_IDColumnName; }
        }

        public static string PersonaId_NombreCol
        {
            get { return TRANSACCIONESCollection.PERSONA_IDColumnName; }
        }

        public static string ProveedorId_NombreCol
        {
            get { return TRANSACCIONESCollection.PROVEEDOR_IDColumnName; }
        }

        public static string CtacteRedPagoId_NombreCol
        {
            get { return TRANSACCIONESCollection.CTACTE_RED_PAGO_IDColumnName; }
        }

        public static string NroTransaccion_NombreCol
        {
            get { return TRANSACCIONESCollection.NRO_TRANSACCIONColumnName; }
        }

        public static string FechaCreacion_NombreCol
        {
            get { return TRANSACCIONESCollection.FECHA_CREACIONColumnName; }
        }

        public static string UsuarioId_NombreCol
        {
            get { return TRANSACCIONESCollection.USUARIO_IDColumnName; }
        }

        public static string FechaTransaccion_NombreCol
        {
            get { return TRANSACCIONESCollection.FECHA_TRANSACCIONColumnName; }
        }

        public static string FechaAcreditacion_NombreCol
        {
            get { return TRANSACCIONESCollection.FECHA_ACREDITACIONColumnName; }
        }

        public static string FechaAnulacion_NombreCol
        {
            get { return TRANSACCIONESCollection.FECHA_ANULACIONColumnName; }
        }

        public static string CtaCteValorId_NombreCol
        {
            get { return TRANSACCIONESCollection.CTACTE_VALOR_IDColumnName; }
        }

        public static string CtaCtePersonaId_NombreCol
        {
            get { return TRANSACCIONESCollection.CTACTE_PERSONA_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return TRANSACCIONESCollection.MONEDA_IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return TRANSACCIONESCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return TRANSACCIONESCollection.COTIZACIONColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return TRANSACCIONESCollection.MONTO_TOTALColumnName; }
        }
        public static string MontoCapital_NombreCol
        {
            get { return TRANSACCIONESCollection.MONTO_CAPITALColumnName; }
        }
        public static string MontoIntereses_NombreCol
        {
            get { return TRANSACCIONESCollection.MONTO_INTERESESColumnName; }
        }
        public static string MontoGastoAdministrativo_NombreCol
        {
            get { return TRANSACCIONESCollection.MONTO_GASTO_ADMINISTRATIVOColumnName; }
        }
        public static string ComisionTotal_NombreCol
        {
            get { return TRANSACCIONESCollection.COMISION_TOTALColumnName; }
        }
        public static string ComisionRecaudador_NombreCol
        {
            get { return TRANSACCIONESCollection.COMISION_RECAUDADORColumnName; }
        }
        public static string ComisionProcesador_NombreCol
        {
            get { return TRANSACCIONESCollection.COMISION_PROCESADORColumnName; }
        }
        public static string ComisionClearing_NombreCol
        {
            get { return TRANSACCIONESCollection.COMISION_CLEARINGColumnName; }
        }
        public static string ComisionOtro_NombreCol
        {
            get { return TRANSACCIONESCollection.COMISION_OTROColumnName; }
        }
        public static string Procesado_NombreCol
        {
            get { return TRANSACCIONESCollection.PROCESADOColumnName; }
        }
        public static string Anulado_NombreCol
        {
            get { return TRANSACCIONESCollection.ANULADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TRANSACCIONESCollection.ESTADOColumnName; }
        }
        public static string TransaccionCierreId_NombreCol
        {
            get { return TRANSACCIONESCollection.TRANSACCION_CIERRE_IDColumnName; }
        }
        public static string ComisionRed_NombreCol
        {
            get { return TRANSACCIONESCollection.COMISION_REDColumnName; }
        }
        public static string FechaCorte_NombreCol
        {
            get { return TRANSACCIONESCollection.FECHA_CORTEColumnName; }
        }
        public static string CtaCteBancoClearingId_NombreCol
        {
            get { return TRANSACCIONESCollection.CTACTE_BANCO_CLEARING_IDColumnName; }
        }


        #endregion tabla

        #endregion Accessors
    }
}
