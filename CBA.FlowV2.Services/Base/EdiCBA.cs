using System;
using System.Net;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CBA.FlowV2.Db;

namespace CBA.FlowV2.Services.Base
{
    //Implementacion de las definiciones que estan en:
    //http://wiki.cba.com.py/index.php/EDI
    public abstract class EdiCBA
    {
        #region Tipo Valor
        public static class TipoValor
        {
            public static int Efectivo = 1;
            public static int Cheque = 2;
            public static int Tarjeta = 3;
            public static int Pagare = 4;
            public static int Anticipo = 5;
            public static int NotaDeCredito = 6;
            public static int DepositoBacnario = 7;
            public static int TransferenciaBancaria = 8;
            public static int OrdenDePago = 9;
            public static int RetencionIVA = 10;
            public static int AjusteBancario = 11;
            public static int DescuentoDeDocumentos = 12;
            public static int Factura = 13;
            public static int Credito = 14;
            public static int LetraDeCambio = 15;
            public static int TransferenciaCtacte = 16;
            public static int Giro = 17;
            public static int NotaDeDebito = 18;
            public static int Ajuste = 19;
            public static int RetencionRenta = 20;
            public static int RetencionSECP = 21;
            public static int DebitoAutomatico = 22;
            public static int EgresoVarioCaja = 23;
        }
        #endregion Tipo Valor

        #region Tipo Documento
        public static class TipoDocumento
        {
            public static int CedulaIdentidad = 1;
            public static int RUC = 2;
            public static int Pasaporte = 3;
        }
        #endregion Tipo Documento

        #region Tipo Factura
        public static class TipoFactura
        {
            public static int Gastos = 1;
            public static int CompraArticulos = 2;
            public static int GastosRepasoTerceros = 3;
            public static int GastosDespacho = 4;
            public static int Autofactura = 5;
        }
        #endregion Tipo Factura

        #region Tipo Orden de Pago
        public static class TipoOrdenDePago
        {
            public static int PagoProveedor = 1;
            public static int ReposicionFondoFijo = 2;
            public static int PagoFuncionario = 3;
            public static int AnticipoFuncionario = 4;
            public static int PagoPersona = 12;
        }
        #endregion Tipo Orden de Pago

        #region Cheque Estados
        public static class ChequeEstados
        {
            public static int AlDia = 1;
            public static int Adelantado = 2;
            public static int Retenido = 3;
            public static int Rechazado = 4;
            public static int Incobrable = 5;
            public static int Judicial = 6;
            public static int Depositado = 7;
            public static int Negociado = 8;
            public static int Custodiado = 9;
            public static int Canjeado = 10;
            public static int Anulado = 11;
            public static int Utilizado = 12;
            public static int Efectivizado = 13;
            public static int ParaDeposito = 14;
            public static int ParaCanje = 15;
        }
        #endregion Cheque Estados

        #region ProfundidadResolucion
        public class ProfundidadResolucion
        {
            public const int Infinita = -1;
            public const int NoProfundizar = 0;

            public static int DisminuirNivel(int nivel_actual)
            {
                if (nivel_actual > 0)
                    return nivel_actual - 1;
                else
                    return nivel_actual;
            }
        }
        #endregion ProfundidadResolucion

        #region ArrayToString
        public static string ArrayToString(Estructura[] array)
        {
            var txt = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
                txt[i] = array[i].ToString();

            return "[" + string.Join(",", txt) + "]";
        }
        #endregion ArrayToString

        #region Error
        public class Error
        {
            public string mensaje;
            public string error; //quitar eventualmente
            public int codigo;

            public Error()
            {
                error = Definiciones.SiNo.Si;
                codigo = Definiciones.ExcepcionesRestError.ERROR_CLIENTE;
            }
        }
        #endregion Error

        #region Estructura
        public class Estructura
        {
            public string uuid;
            public string objeto_nombre;
            public decimal? id;
            public int orden;

            public Estructura()
            {
                uuid = string.Empty;
            }

            public override string ToString()
            {
                return JsonUtil.Serializar(this);
            }
        }
        #endregion Estructura

        #region Resultado
        public class Resultado
        {
            public List<Estructura> datos;
            public Dictionary<string, string> resumen;
            public string mensaje;

            public Resultado()
            {
                this.datos = new List<Estructura>();
                this.resumen = new Dictionary<string, string>();
                this.mensaje = string.Empty;
            }
        }
        #endregion Resultado

        #region Moneda
        public class Moneda : Estructura
        {
            public string nombre;
            public string simbolo;
            public string iso_4217;
            public decimal cantidad_decimales;
            public string cadena_decimales; //utilizado al convertir a texto con formato, obligando al menos un caracter
        }
        #endregion Moneda

        #region Cotizacion
        public class Cotizacion : Estructura
        {
            public string moneda_uuid;
            public Moneda moneda;
            public DateTime fecha;
            public decimal compra;
            public decimal venta;
        }
        #endregion Cotizacion

        #region Persona
        public class Persona : Estructura
        {
            public string codigo;
            public string nombre;
            public string apellido;
            public List<Documento> documentos;
            public List<Direccion> direcciones;
            public List<Telefono> telefonos;
            public List<Imagen> imagenes;

            public int? sucursal_id;
            public string apodo;
        }
        #endregion Persona

        #region Funcionario
        public class Funcionario : Estructura
        {
            public string persona_uuid;
            public Persona persona;
            public string codigo;
            public string apodo;
        }
        #endregion Funcionario

        public class getFacturaCliete : Estructura
        {
            public string CONDICION_PAGO_ID { get; set; }
            public string AUTONUMERACION_TIMBRADO { get; set; }
            public string CASO_ESTADO_ID { get; set; }
            public string ES_RAPIDA { get; set; }
            public string TOTAL_NETO { get; set; }
            public decimal ID { get; set; }
            public string TIPO_FACTURA_ID { get; set; }
            public decimal CASO_ID { get; set; }
            public string NRO_COMPROBANTE { get; set; }
            public string SUCURSAL_NOMBRE { get; set; }
            public DateTime FECHA { get; set; }
            public decimal SUCURSAL_ID { get; set; }
        }

        #region Proveedor
        public class Proveedor : Estructura
        {
            public string codigo;
            public string razon_social;
            public List<Documento> documentos;
            public List<Direccion> direcciones;
            public List<Telefono> telefonos;
            public List<Imagen> imagenes;
        }
        #endregion Proveedor

        #region Telefono
        public class Telefono : Estructura
        {
            public string codigo_pais;
            public string codigo_operadora;
            public string numero;
            public bool linea_fija;
        }
        #endregion Telefono

        #region Documento
        public class Documento : Estructura
        {
            public int tipo; //Enumeracion TipoDocumento
            public string numero;
            public DateTime? emision;
            public DateTime? vencimiento;
        }
        #endregion Documento

        #region Direccion
        public class Direccion : Estructura
        {
            public decimal? pais_id;
            public string pais_nombre;
            public decimal? ciudad_id;
            public string ciudad_nombre;
            public decimal? barrio_id;
            public string barrio_nombre;
            public string calle;
            public string numero;
            public string codigo_postal;
            public string latitud;
            public string longitud;
            public string observacion;
        }
        #endregion Direccion

        #region ArticuloConjunto
        public class ArticuloConjunto : Estructura
        {
            public int tipo_articulo_conjunto;
            public string observacion;
            public Estilo estilo;
            public Articulo[] articulos;
        }
        #endregion ArticuloConjunto

        #region Articulo
        public class Articulo : Estructura
        {
            public string codigo;
            public string descripcion_impresion;
            public string descripcion_interna;
            public ArticuloLote[] lotes; //Esta propiedad deberia borrarse ya que la relacion es inversa
            public Impuesto impuesto;
            public string impuesto_uuid;
        }
        #endregion Articulo

        #region ArticuloLote
        public class ArticuloLote : Estructura
        {
            public string articulo_uuid;
            public Articulo articulo;
            public decimal? articulo_id;
            public string codigo;
            public string descripcion;
            public string observacion;
            public decimal moneda_id;
            public string moneda_nombre;
            public decimal? precio;
            public Imagen[] imagenes;
            public bool disponible;
            public bool principal;
        }
        #endregion ArticuloLote

        #region Estilo
        public class Estilo : Estructura
        {
            public string color_fondo;
            public string color_letra;
            public bool destacado;
            public bool recomendado;
        }
        #endregion Estilo

        #region Rubro
        public class Rubro : Estructura
        {
            public string nombre;
        }
        #endregion Moneda

        #region Imagen
        public class Imagen : Estructura
        {
            public string url;
#pragma warning disable CS0108 // 'EdiCBA.Imagen.uuid' oculta el miembro heredado 'EdiCBA.Estructura.uuid'. Use la palabra clave new si su intención era ocultarlo.
            public string uuid;
#pragma warning restore CS0108 // 'EdiCBA.Imagen.uuid' oculta el miembro heredado 'EdiCBA.Estructura.uuid'. Use la palabra clave new si su intención era ocultarlo.
        }
        #endregion Imagen

        #region CondicionPago
        public class CondicionPago : Estructura
        {
            public string nombre;
            public decimal cantidad_pagos;
            public bool es_compra;
            public bool es_venta;
            public string tipo_condicion; //CREDITO o CONTADO
            public string tipo_calculo; //D=Dias, M=Meses
        }
        #endregion CondicionPago

        #region CondicionPagoDetalle
        public class CondicionPagoDetalle : Estructura
        {
            public string condicion_pago_uuid;
            public CondicionPago condicion_pago;
            public decimal numero_cuota;
            public decimal vencimiento_pago; //Dias o meses a partir del inicio
        }
        #endregion CondicionPagoDetalle

        #region CtactePersona
        public class CtactePersona : Estructura
        {
            public decimal? caso_id;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public decimal cuota_numero;
            public decimal cuota_total;
            public string ctacte_persona_relacionada_uuid;
            public CtactePersona ctacte_persona_relacionada;
            public DateTime fecha_creacion;
            public DateTime fecha_vencimiento;
            public decimal credito;
            public decimal debito;
            public string moneda_uuid;
            public Moneda moneda;
            public string persona_uuid;
            public Persona persona;
            public int tipo_valor;
            public string tipo_documento; // Valores: CREDITO, CONTADO
        }
        #endregion CtactePersona

        #region CtacteProveedor
        public class CtacteProveedor : Estructura
        {
            public decimal? caso_id;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public decimal cuota_numero;
            public decimal cuota_total;
            public string ctacte_proveedor_relacionada_uuid;
            public CtacteProveedor ctacte_proveedor_relacionada;
            public DateTime fecha_creacion;
            public DateTime fecha_vencimiento;
            public decimal credito;
            public decimal debito;
            public string moneda_uuid;
            public Moneda moneda;
            public string proveedor_uuid;
            public Proveedor proveedor;
            public int tipo_valor;
        }
        #endregion CtacteProveedor

        #region Caso
        public class Caso : Estructura
        {
            public decimal caso_id; //Los flujos heredan de Caso por lo que Id es PK de la cabecera y no del caso
            public string estado_id;
            public decimal? funcionario_id;
            public string funcionario_uuid;
            public Funcionario funcionario;
            public decimal? persona_id;
            public string persona_uuid;
            public Persona persona;
            public decimal? proveedor_id;
            public string proveedor_uuid;
            public Proveedor proveedor;
            public string nro_comprobante;
            public decimal sucursal_id;
            public string sucursal_uuid;
            public Sucursal sucursal;

            public static Caso Copiar(Caso caso)
            {
                var c = new Caso();
                c.caso_id = caso.caso_id;
                c.estado_id = caso.estado_id;
                c.funcionario_id = caso.funcionario_id;
                c.funcionario_uuid = caso.funcionario_uuid;
                c.funcionario = caso.funcionario;
                c.persona_id = caso.persona_id;
                c.persona_uuid = caso.persona_uuid;
                c.persona = caso.persona;
                c.proveedor_id = caso.proveedor_id;
                c.proveedor_uuid = caso.proveedor_uuid;
                c.proveedor = caso.proveedor;
                c.sucursal_id = caso.sucursal_id;
                c.sucursal_uuid = caso.sucursal_uuid;
                c.sucursal = caso.sucursal;
                c.uuid = caso.uuid;
                return c;
            }
        }
        #endregion Caso

        #region Credito
        public class Credito : Caso
        {
            public decimal? articulo_id;
            public decimal? canal_venta_id;
            public decimal? persona_garante1_id;
            public decimal? persona_garante2_id;
            public decimal autonumeracion_id;
            public DateTime fecha_solicitud;
            public DateTime? fecha_retiro;
            public decimal moneda_id;
            public decimal cotizacion;
            public string observacion;
            public decimal cantidad_cuotas;
            public decimal monto_capital_solicitado;
            public decimal monto_capital_orden_compra;
            public decimal monto_total;
            public string numero_solicitud;
            public DateTime fecha_primer_vencimiento;
        }
        #endregion Credito

        #region FacturaCliente
        public class FacturaCliente : Caso
        {
            public string[] personas_relacionadas_uuid;
            public Persona[] personas_relacionadas;
            public string deposito_uuid;
            public Deposito deposito;
            public DateTime fecha;
            public DateTime fecha_vencimiento;
            public DateTime fecha_creacion;
            public string moneda_uuid;
            public Moneda moneda;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public string condicion_pago_uuid;
            public CondicionPago condicion_pago;
            public string canal_venta_uuid;
            public CanalVenta canal_venta;
            public decimal porcentaje_descuento_sobre_total;
            public decimal total_costo;
            public decimal total_neto;
            public decimal total_bruto;
            public decimal total_descuento;
            public decimal total_impuesto;
            public string nro_comprobante_externo;
            public decimal? nro_comprobante_numerico;
            public string observacion;
            public string[] factura_cliente_detalles_uuid;
            public FacturaClienteDetalle[] factura_cliente_detalles;
        }

        public class FacturaclienteInfoCompleta : FACTURAS_CLIENTE_INFO_COMPLETACollection_Base { public FacturaclienteInfoCompleta() : base(null) { } }

        #endregion FacturaCliente

        #region FacturaClienteDetalle
        public class FacturaClienteDetalle : Estructura
        {
            public string articulo_uuid;
            public Articulo articulo;
            public decimal cantidad_embalada_origen;
            public decimal cantidad_por_caja_origen;
            public decimal cantidad_unitaria_origen;
            public decimal cantidad_unitaria_total_origen;
            public decimal cantidad_embalada_destino;
            public decimal cantidad_por_caja_destino;
            public decimal cantidad_unitaria_destino;
            public decimal cantidad_unitaria_total_destino;
            public string costo_cotizacion_uuid;
            public Cotizacion costo_cotizacion;
            public decimal costo_unitario_monto;
            public decimal factor_conversion;
            public string factura_cliente_uuid;
            public FacturaCliente factura_cliente;
            public string impuesto_uuid;
            public Impuesto impuesto;
            public string lote_uuid;
            public ArticuloLote lote;
            public string observacion;
            public decimal porcentaje_descuento;
            public decimal precio_unitario;
            public decimal total_bruto;
            public decimal total_descuento;
            public decimal total_impuesto;
            public decimal total_neto;
            public string unidad_origen_uuid;
            public UnidadMedida unidad_origen;
            public string unidad_destino_uuid;
            public UnidadMedida unidad_destino;
        }
        #endregion FacturaClienteDetalle

        #region FacturaProveedor
        public class FacturaProveedor : Caso
        {
            public int tipo_factura; // Valores de Edi.TipoFactura
            public string deposito_uuid;
            public Deposito deposito;
            public DateTime fecha;
            public DateTime? fecha_vencimiento_timbrado;
            public DateTime fecha_creacion;
            public string moneda_uuid;
            public Moneda moneda;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public string cotizacion_moneda_pais_uuid;
            public Cotizacion cotizacion_moneda_pais;
            public string condicion_pago_uuid;
            public CondicionPago condicion_pago;
            public decimal porcentaje_descuento_sobre_total;
            public bool es_ticket;
            public decimal total_costo;
            public decimal total_neto;
            public decimal total_bruto;
            public decimal total_descuento;
            public decimal total_impuesto;
            public string nro_comprobante_externo;
            public string nro_timbrado;
            public string observacion;
            public string[] factura_proveedor_detalles_uuid;
            public FacturaProveedorDetalle[] factura_proveedor_detalles;
        }
        #endregion FacturaProveedor

        #region FacturaProveedorDetalle
        public class FacturaProveedorDetalle : Estructura
        {
            public string articulo_uuid;
            public Articulo articulo;
            public decimal cantidad_embalada_origen;
            public decimal cantidad_por_caja_origen;
            public decimal cantidad_unitaria_origen;
            public decimal cantidad_unitaria_total_origen;
            public decimal cantidad_embalada_destino;
            public decimal cantidad_por_caja_destino;
            public decimal cantidad_unitaria_destino;
            public decimal cantidad_unitaria_total_destino;
            public decimal factor_conversion;
            public string factura_proveedor_uuid;
            public FacturaProveedor factura_proveedor;
            public string impuesto_uuid;
            public Impuesto impuesto;
            public string lote_uuid;
            public ArticuloLote lote;
            public string observacion;
            public decimal porcentaje_descuento;
            public decimal precio_unitario;
            public string rubro_uuid;
            public Rubro rubro;
            public decimal total_bruto;
            public decimal total_descuento;
            public decimal total_impuesto;
            public decimal total_neto;
            public string unidad_origen_uuid;
            public UnidadMedida unidad_origen;
            public string unidad_destino_uuid;
            public UnidadMedida unidad_destino;
        }
        #endregion FacturaProveedorDetalle

        #region NotaCreditoCliente
        public class NotaCreditoCliente : Caso
        {
            public string deposito_uuid;
            public Deposito deposito;
            public DateTime fecha;
            public string moneda_uuid;
            public Moneda moneda;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public string nro_comprobante_externo;
            public decimal? nro_comprobante_numerico;
            public string observacion;
            public bool tipo_descuento;
            public bool tipo_devolucion;
            public decimal total_neto;
            public decimal total_impuesto;
            public decimal total_saldo;
            public string[] nota_credito_cliente_detalles_uuid;
            public NotaCreditoClienteDetalle[] nota_credito_cliente_detalles;
        }
        #endregion NotaCreditoCliente

        #region NotaCreditoClienteDetalle
        public class NotaCreditoClienteDetalle : Estructura
        {
            public string articulo_uuid;
            public Articulo articulo;
            public decimal cantidad_unitaria_total_destino;
            public decimal costo_unitario_monto;
            public string factura_cliente_uuid;
            public FacturaCliente factura_cliente;
            public string factura_cliente_detalle_uuid;
            public FacturaClienteDetalle factura_cliente_detalle;
            public string impuesto_uuid;
            public Impuesto impuesto;
            public string lote_uuid;
            public ArticuloLote lote;
            public string nota_credito_cliente_uuid;
            public NotaCreditoCliente nota_credito_cliente;
            public string observacion;
            public decimal precio_unitario;
            public decimal total_impuesto;
            public decimal total_neto;
        }
        #endregion NotaCreditoClienteDetalle

        #region NotaCreditoProveedor
        public class NotaCreditoProveedor : Caso
        {
            public string deposito_uuid;
            public Deposito deposito;
            public DateTime fecha;
            public string moneda_uuid;
            public Moneda moneda;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public string nro_timbrado;
            public string observacion;
            public decimal total_neto;
            public decimal total_impuesto;
            public decimal total_saldo;
            public string[] nota_credito_proveedor_detalles_uuid;
            public NotaCreditoProveedorDetalle[] nota_credito_proveedor_detalles;
        }
        #endregion NotaCreditoProveedor

        #region NotaCreditoProveedorDetalle
        public class NotaCreditoProveedorDetalle : Estructura
        {
            public string articulo_uuid;
            public Articulo articulo;
            public decimal cantidad_unitaria_total_destino;
            public decimal costo_unitario_monto;
            public string factura_proveedor_uuid;
            public FacturaProveedor factura_proveedor;
            public string factura_proveedor_detalle_uuid;
            public FacturaProveedorDetalle factura_proveedor_detalle;
            public string impuesto_uuid;
            public Impuesto impuesto;
            public string lote_uuid;
            public ArticuloLote lote;
            public string nota_credito_proveedor_uuid;
            public NotaCreditoProveedor nota_credito_proveedor;
            public string observacion;
            public decimal precio_unitario;
            public decimal total_impuesto;
            public decimal total_neto;
        }
        #endregion NotaCreditoProveedorDetalle

        #region Cobranza
        public class Cobranza : Caso
        {
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public string cobrador_externo_uuid;
            public Funcionario cobrador_externo;
            public DateTime fecha;
            public string moneda_uuid;
            public Moneda moneda;
            public string recibo_uuid;
            public Recibo recibo;
            public decimal total_vuelto;
            public bool vuelto_convertido_a_anticipo;
            public string[] cobranza_documentos_uuid;
            public CobranzaDocumento[] cobranza_documentos;
            public string[] cobranza_valores_uuid;
            public CobranzaValor[] cobranza_valores;
        }
        #endregion Cobranza

        #region Cobranza Documento
        public class CobranzaDocumento : Estructura
        {
            public string cobranza_uuid;
            public Cobranza cobranza;
            public Cotizacion cotizacion;
            public string cotizacion_uuid;
            public string ctacte_persona_uuid;
            public CtactePersona ctacte_persona;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal monto;
            public string observacion;
        }
        #endregion Cobranza Documento

        #region Cobranza Valor
        public class CobranzaValor : Estructura
        {
            public string cobranza_uuid;
            public Cobranza cobranza;
            public Cotizacion cotizacion;
            public string cotizacion_uuid;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal monto;
            public int tipo_valor;
            public string nro_comprobante;
            public DateTime? fecha_emision;
            public DateTime? fecha_vencimiento;
            public string procesadora_tarjeta_uuid;
            public ProcesadoraTarjeta procesadora_tarjeta;
            public string observacion;
        }
        #endregion Cobranza Valor

        #region OrdenPago
        public class OrdenPago : Caso
        {
            public int tipo_orden_pago_id; //Valores de Edi.TipoOrdenDePago
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public DateTime fecha;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal total;
            public string[] orden_pago_documentos_uuid;
            public OrdenPagoDocumento[] orden_pago_documentos;
            public string[] orden_pago_valores_uuid;
            public OrdenPagoValor[] orden_pago_valores;
        }
        #endregion OrdenPago

        #region Orden Pago Documento
        public class OrdenPagoDocumento : Estructura
        {
            public string orden_pago_uuid;
            public OrdenPago orden_pago;
            public Cotizacion cotizacion;
            public string cotizacion_uuid;
            public string ctacte_proveedor_uuid;
            public CtacteProveedor ctacte_proveedor;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal monto;
            public string observacion;
        }
        #endregion Orden Pago Documento

        #region Orden Pago Valor
        public class OrdenPagoValor : Estructura
        {
            public string orden_pago_uuid;
            public OrdenPago orden_pago;
            public Cotizacion cotizacion;
            public string cotizacion_uuid;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal monto;
            public int tipo_valor;
            public string nro_comprobante;
            public DateTime? fecha_emision;
            public DateTime? fecha_vencimiento;
        }
        #endregion Orden Pago Valor

        #region Deposito Bancario
        public class DepositoBancario : Caso
        {
            public Cotizacion cotizacion;
            public string cotizacion_uuid;
            public string cuenta_bancaria_uuid;
            public CuentaBancaria cuenta_bancaria;
            public string caja_recaudacion_uuid;
            public CajaRecaudacion caja_recaudacion;
            public string caja_tesoreria_uuid;
            public CajaTesoreria caja_tesoreria;
            public DateTime fecha;
            public string observacion;
            public decimal total_cheques_mismo_banco;
            public decimal total_cheques_otro_banco;
            public decimal total_efectivo;
            public decimal total;
            public string[] deposito_bancario_detalles_uuid;
            public DepositoBancarioDetalle[] deposito_bancario_detalles;
        }
        #endregion Deposito Bancario

        #region Deposito Bancario Detalle
        public class DepositoBancarioDetalle : Estructura
        {
            public string deposito_bancario_uuid;
            public DepositoBancario deposito_bancario;
            public string cheque_recibido_uuid;
            public ChequeRecibido cheque_recibido;
            public decimal monto;
            public int tipo_valor;
        }
        #endregion Deposito Bancario Detalle

        #region Recibo
        public class Recibo : Estructura
        {
            public bool anulado;
            public string persona_uuid;
            public Persona persona;
            public DateTime fecha;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal monto;
            public string nro_comprobante;
            public decimal? nro_comprobante_numerico;
        }
        #endregion Recibo

        #region RefinanciacionDeudas
        public class RefinanciacionDeudas : Caso
        {
            public DateTime fecha;
            public decimal moneda_id;
            public decimal cotizacion;
            public decimal? autonumeracion_id;
            public decimal? persona_estado_morosidad_id;
            public decimal monto_cuota_propuesto;
            public decimal entrega_inicial;
            public decimal caso_refinanciado_id;
            public DateTime fecha_primer_vencimiento;
            public bool es_recalendarizacion;
            public RefinanciacionDeudasDetalles[] detalles;
        }

        public class RefinanciacionDeudasDetalles : Estructura
        {
            public decimal? calendario_pago_fc_cliente_id;
            public decimal monto_anterior;
            public decimal importe;
            public decimal moneda_id;
            public decimal cotizacion;
            public DateTime vencimiento;
            public decimal cantidad_cuotas;
            public decimal cuota;
            public bool es_interes;
        }
        #endregion RefinanciacionDeudas

        #region TransferenciaStock
        public class TransferenciaStock : Caso
        {
            public decimal sucursal_origen_id { get { return this.sucursal_id; } set { this.sucursal_id = value; } }
            public decimal sucursal_destino_id;
            public decimal deposito_origen_id;
            public decimal deposito_destino_id;
            public DateTime? fecha;
            public decimal? moneda_id;
            public decimal? cotizacion;
            public decimal? costo_asociado;
            public decimal? costo_transferencia;
            public decimal? autonumeracion_id;
            public string comprobante { get { return this.nro_comprobante; } set { this.nro_comprobante = value; } }
            public decimal? caso_asociado_id;
            public decimal? chofer_id { get { return this.funcionario_id; } set { this.funcionario_id = value; } }
            public string chofer_nombre;
            public decimal? acompanante1_id;
            public decimal? acompanante2_id;
            public decimal? acompanante3_id;
            public decimal? vehiculo_id;
            public string vehiculo_marca;
            public string vehiculo_matricula;
            public string observacion;
            public string remision_externa;
            public decimal? texto_predefinido_id;

            public TransferenciaStockDetalle[] detalles;
        }

        public class TransferenciaStockDetalle : Estructura
        {
            public decimal? articulo_id;
            public decimal? lote_id;
            public decimal? cantidad_destino_embalada;
            public decimal? cantidad_destino_unitaria;
            public string unidad_medida_id;
            public string observacion;
        }
        #endregion TransferenciaStock

        #region Clase Operacion
        public class Operacion : Estructura
        {
            public string OPERACION;
            public DateTime FECHA;
            public DateTime HORA_INICIO;
            public DateTime HORA_FIN;
            public string NRO_FORMULARIO;
            public decimal CONTENEDOR_ID;
            public string CONTENEDOR_NUMERO;
            public decimal LINEA_ID;
            public decimal CANTIDAD;
            public string BL_NRO;
            public string BOOKING;
            public decimal PERSONA_ID;
            public string PERSONA_NOMBRE;
            public string CLASIFICACION_ID;
            public decimal ITEM;
            public string MERCADERIA_INTERNA;
            public string PRECINTO_1;
            public string PRECINTO_2;
            public string PRECINTO_3;
            public string PRECINTO_4;
            public string PRECINTO_5;
            public string EDI;
            public string ESTADO;
            public string PROCESADO;
            public string OBSERVACION;
            public string VENTILETE;
            public decimal? PESO_BRUTO;
            public decimal? TARA_CAMION;
            public decimal? PESO_NETO;
            public decimal? TARA_CONTENEDOR;
            public string PISO;
            public string FONDO;
            public string TECHO;
            public string PANEL_DERECHO;
            public string PANEL_IZQUIERDO;
            public string PUERTA;
            public string REFRIGERADO;
        }

        #endregion Clase Operacion

        #region Ganado
        public class Ganado : Estructura
        {
            public string categoria_nombre;
            public string nombre;
            public string sexo;
            public string pelaje;
            public DateTime fecha_nacimiento;
            public string sigla;
            public int? rebanho;
            public int rp;
            public string hbp;
            public string padre_hbp;
            public string madre_hbp;
            public char muerto;
            public char es_mellizo;
            public char controlado;
            public char registrado;
            public char es_receptora;
            public char adn;
            public string adn_marcadores;
            public char geneticamente_superior;
            public char espera_de;
            public string propietario;
            public string criador;
            public char requiere_adn;
            public string adn_numero;
            public char requiere_gs;
            public char primer_registro;
            public string raza_nombre;
            public string establecimiento_nombre;
            public char refugo;
            public DateTime? fecha_muerte;
            public string codigo_interno;
        }
        #endregion Ganado

        #region Sucursal
        public class Sucursal : Estructura
        {
            public int? entidad;
            public string nombre;
            public string ruc;
            public string[] direcciones_uuid;
            public Direccion[] direcciones;
            public string[] telefonos_uuid;
            public Telefono[] telefonos;
        }
        #endregion Sucursal

        #region Deposito
        public class Deposito : Estructura
        {
            public string sucursal_uuid;
            public Sucursal sucursal;
            public string nombre;
        }
        #endregion Deposito

        #region Vehiculo
        public class Vehiculo : Estructura
        {
            public decimal Id;
            public decimal Tipo_Vehiculo_Id;
            public decimal? Sucursal_Id;
            public string Nombre;
            public string Abreviatura;
            public string Matricula;
            public string Marca;
            public string Modelo;
            public decimal? Anho;
            public string Color;
            public decimal? Consumo_Estimado;
            public decimal Kilometraje_Inicial;
            public decimal Kilometraje_Actual;
            public string Tipo_Combustible;
            public decimal? Cantidad_Km_Entre_Mantenim;
            public decimal? Cantidad_Dias_Entre_Mantenim;
            public decimal? Kilometraje_Ultimo_Mantenimien;
            public DateTime? Fecha_Ultimo_Mantenimiento;
            public DateTime? Fecha_Vencimiento_Poliza;
            public DateTime? Fecha_Vencimiento_Patente;
            public DateTime? Fecha_Ingreso;
            public DateTime? Fecha_Inactivado;
            public string Estado;
            public decimal? Chofer_Habitual_Id;
            public string Chasis_Nro;
            public decimal? Proveedor_Id;
        }
        #endregion Vehiculo

        #region Activos
        public class Activos : Estructura
        {
            public decimal? CentroCostoId;
            public string Codigo;
            public decimal? CotizacionMonenda;
            public decimal EntidadId;
            public string Estado;
            public DateTime? FechaCompra;
            public decimal? Id;
            public string IngresoAprobado;
            public decimal? InmuebleId;
            public decimal? MonedaCompraId;
            public decimal? MontoCompraId;
            public string Nombre;
            public decimal? SucursalId;
            public decimal? VehiculoId;
        }
        #endregion Activos 

        #region Inmueble
        public class Inmueble : Estructura
        {
            public decimal Id;
            public decimal Texto_Pred_Tipo_Inmueble_Id;
            public string Propietario_Nombre;
            public string Propietario_Apellido;
            public decimal? Persona_Propietario_Id;
            public decimal? Inmueble_Padre_Id;
            public decimal? Pais_Id;
            public decimal? Ciudad_Id;
            public decimal? Barrio_Id;
            public decimal? Departamento_Id;
            public string Lote_Numero;
            public decimal? Superficie;
            public string Finca_Numero;
            public string Cuenta_Catastral;
            public string Padron_Numero;
            public decimal? Latitud;
            public decimal? Longitud;
            public string Escriturado;
            public string Piso;
            public string Telefono;
            public string Numero;
            public string Medidor_Agua_Numero;
            public string Medidor_Electricidad_Numero;
            public string NIS_Electricidad;
            public string Cuenta_Catastral_Agua;
            public string Es_Espacio_Comun;
            public string Matricula_Nro;
            public decimal Texto_Pred_Disponibilidad_Id;
            public string Nombre;
            public string Calle;
        }
        #endregion Inmueble

        #region CanalVenta
        public class CanalVenta : Estructura
        {
            public string nombre;
        }
        #endregion CanalVenta

        #region Devengamiento
        public class Devengamiento : Estructura
        {
            public decimal? regionId;
            public decimal? cantalVentaId;
            public decimal? personaRelacionadaId;
            public string existePersonaRelacionada;
            public DateTime fecha;
            public decimal monedaId;
            public decimal cotizacion;
            public decimal limiteDiasEnSuspenso;
            public decimal aDevengarVigente;
            public decimal aDevengarVencido;
            public decimal devengado;
            public decimal enSuspenso;
            public decimal capitalACobrarVigente;
            public decimal capitalACobrarVencido;
            public decimal interesACobrarVigente;
            public decimal interesACobrarVencido;
            public decimal capitalVencidoCobrado;
            public decimal interesVencidoCobrado;
        }
        #endregion Devengamiento

        #region Impuesto
        public class Impuesto : Estructura
        {
            public string descripcion;
            public string nombre;
            public decimal porcentaje;
        }
        #endregion Impuesto

        #region UnidadMedida
        public class UnidadMedida : Estructura
        {
            public string simbolo;
            public string nombre;
            public decimal cantidad_decimales;
        }
        #endregion UnidadMedida

        #region AsientoBusquedaFiltros
        public class AsientoBusquedaFiltros
        {
            public DateTime? fecha_desde;
            public DateTime? fecha_hasta;
            public int? numero_desde;
            public int? numero_hasta;
            public string observacion_contiene;
            public decimal? monto_desde;
            public decimal? monto_hasta;
            public string sucursal_uuid;
            public bool? automatico;
            public bool? es_global;
            public bool? es_detalle_de_global;
            public bool? es_apertura;
            public bool? es_cierre;
            public bool? es_regularizacion;
            public bool? revisar;
            public bool? equilibrado;
            public bool? aprobado;
        }
        #endregion AsientoBusquedaFiltros

        #region Asiento
        public class Asiento : Estructura
        {
            public bool aprobado;
            public bool automatico;
            public decimal? caso_relacionado_id;
            public DateTime fecha;
            public DateTime fecha_creacion;
            public decimal numero;
            public string observacion;
            public string sucursal_uuid;
            public Sucursal sucursal;
        }
        #endregion Asiento

        #region Pais
        public class Pais : Estructura
        {
            public string nombre;
            public string abreviatura;
            public string codigo_telefonico;
            public string gentilicio;
            public string ISO31661;
            public string moneda_uuid;
            public Moneda moneda;
        }
        #endregion Pais

        #region Banco
        public class Banco : Estructura
        {
            public string razon_social;
            public string abreviatura;
            public string codigo;
            public bool es_extranjero;
            public bool es_nacional;
            public string pais_uuid;
            public Pais pais;
        }
        #endregion Banco

        #region CuentaBancaria
        public class CuentaBancaria : Estructura
        {
            public string banco_uuid;
            public Banco banco;
            public string moneda_uuid;
            public Moneda moneda;
            public string numero_cuenta;
            public string sucursal_uuid;
            public Sucursal sucursal;
            public string titular;
        }
        #endregion CuentaBancaria

        #region CajaRecaudacion
        public class CajaTesoreria : Estructura
        {
            public string nombre;
            public string abreviatura;
            public string sucursal_uuid;
            public Sucursal sucursal;
        }
        #endregion CajaRecaudacion

        #region CajaRecaudacion
        public class CajaRecaudacion : Estructura
        {
            public string sucursal_uuid;
            public Sucursal sucursal;
            public string caja_tesoreria_uuid;
            public CajaTesoreria caja_tesoreria;
            public string funcionario_uuid;
            public Funcionario funcionario;
            public DateTime? fecha_apertura;
            public DateTime? fecha_cierre;
            public string caja_recaudacion_anterior_uuid;
            public CajaRecaudacion caja_recaudacion_anterior;
            public string nro_comprobante;
        }
        #endregion CajaRecaudacion

        #region ChequeRecibido
        public class ChequeRecibido : Estructura
        {
            public decimal? caso_creador_id;
            public bool cheque_de_terceros;
            public int cheque_estado; //Valores de Edi.ChequeEstados
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public string banco_uuid;
            public Banco banco;
            public string deposito_bancario_uuid;
            public DepositoBancario deposito_bancario;
            public bool es_diferido;
            public DateTime? fecha_cobro;
            public DateTime fecha_emision;
            public DateTime? fecha_rechazo;
            public DateTime fecha_vencimiento;
            public string moneda_uuid;
            public Moneda moneda;
            public decimal monto;
            public string motivo_rechazo;
            public string nombre_beneficiario;
            public string nombre_emisor;
            public string numero_cheque;
            public string numero_cuenta;
            public string numero_cuenta_emisor;
        }
        #endregion ChequeRecibido

        #region ProcesadoraTarjeta
        public class ProcesadoraTarjeta : Estructura
        {
            public string abreviatura;
            public string nombre;
        }
        #endregion ProcesadoraTarjeta

        #region ArticulosFamilia
        public class ArticuloFamilia : Estructura
        {
            public string nombre;
            public string descripcion;
            public string exclusivo;
        }
        #endregion ArticulosFamilia



        #region ArticulosGrupo
        public class ArticuloGrupo : Estructura
        {
            public string nombre;
            public string descripcion;
            public string familia_uuid;
            public ArticuloFamilia familia;
        }
        #endregion ArticulosGrupo

        #region ArticulosSubgrupo
        public class ArticuloSubgrupo : Estructura
        {
            public string nombre;
            public string descripcion;
            public string familia_uuid;
            public ArticuloFamilia familia;
            public string grupo_uuid;
            public ArticuloGrupo grupo;
        }
        #endregion ArticulosSubgrupo

        #region PlanillaLiquidacion
        public class PlanillaLiquidacion : Caso
        {
#pragma warning disable CS0108 // 'EdiCBA.PlanillaLiquidacion.sucursal_uuid' oculta el miembro heredado 'EdiCBA.Caso.sucursal_uuid'. Use la palabra clave new si su intención era ocultarlo.
            public string sucursal_uuid;
#pragma warning restore CS0108 // 'EdiCBA.PlanillaLiquidacion.sucursal_uuid' oculta el miembro heredado 'EdiCBA.Caso.sucursal_uuid'. Use la palabra clave new si su intención era ocultarlo.
#pragma warning disable CS0108 // 'EdiCBA.PlanillaLiquidacion.sucursal' oculta el miembro heredado 'EdiCBA.Caso.sucursal'. Use la palabra clave new si su intención era ocultarlo.
            public Sucursal sucursal;
#pragma warning restore CS0108 // 'EdiCBA.PlanillaLiquidacion.sucursal' oculta el miembro heredado 'EdiCBA.Caso.sucursal'. Use la palabra clave new si su intención era ocultarlo.
            public decimal tipo;
            public DateTime fecha_creacion;
            public DateTime fecha_desde;
            public DateTime fecha_hasta;
            public string moneda_uuid;
            public Moneda moneda;
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public decimal total;
            public string observacion;
            public string[] planilla_liquidacion_detalles_uuid;
            public PlanillaLiquidacionDetalle[] planilla_liquidacion_detalles;
        }
        #endregion PlanillaLiquidacion

        #region PlanillaLiquidacionDetalle
        public class PlanillaLiquidacionDetalle : Estructura
        {
            public string cotizacion_uuid;
            public Cotizacion cotizacion;
            public decimal? funcionario_id;
            public string funcionario_uuid;
            public Funcionario funcionario;
            public string moneda_uuid;
            public Moneda moneda;
            public string planilla_liquidacion_uuid;
            public PlanillaLiquidacion planilla_liquidacion;
            public decimal total_a_cobrar;
            public decimal total_aporte_empresa;
            public decimal total_bonificacion;
            public decimal total_descuento;
            public decimal total_salario;
        }
        #endregion PlanillaLiquidacionDetalle

        #region DepositosBancariosPOS
        public class DepositosBancariosPOS : Estructura
        {
            public string casosCreados;
            public string mensaje;
        }
        #endregion DepositosBancariosPOS

        #region facturacionRapida

        #endregion FacturacionRapida
    }
}
