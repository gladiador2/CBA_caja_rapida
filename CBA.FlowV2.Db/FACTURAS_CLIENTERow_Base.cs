// <fileinfo name="FACTURAS_CLIENTERow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="FACTURAS_CLIENTERow"/> that 
	/// represents a record in the <c>FACTURAS_CLIENTE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_CLIENTERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTERow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _caso_origen_id;
		private bool _caso_origen_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _vendedor_id;
		private bool _vendedor_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _tipo_factura_id;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha_vencimiento;
		private decimal _condicion_pago_id;
		private bool _condicion_pago_idNull = true;
		private decimal _porcentaje_desc_sobre_total;
		private bool _porcentaje_desc_sobre_totalNull = true;
		private decimal _moneda_destino_id;
		private bool _moneda_destino_idNull = true;
		private decimal _cotizacion_destino;
		private bool _cotizacion_destinoNull = true;
		private decimal _total_monto_impuesto;
		private bool _total_monto_impuestoNull = true;
		private decimal _total_monto_dto;
		private bool _total_monto_dtoNull = true;
		private decimal _total_monto_bruto;
		private bool _total_monto_brutoNull = true;
		private decimal _total_neto;
		private bool _total_netoNull = true;
		private decimal _total_costo_bruto;
		private bool _total_costo_brutoNull = true;
		private decimal _total_costo_neto;
		private bool _total_costo_netoNull = true;
		private decimal _total_comision_vendedor;
		private bool _total_comision_vendedorNull = true;
		private decimal _usuario_id_autoriza_descuento;
		private bool _usuario_id_autoriza_descuentoNull = true;
		private System.DateTime _fecha_autorizacion_descuento;
		private bool _fecha_autorizacion_descuentoNull = true;
		private decimal _descuento_max_autorizado;
		private bool _descuento_max_autorizadoNull = true;
		private string _afecta_linea_credito;
		private string _afecta_ctacte;
		private decimal _monto_afecta_linea_credito;
		private bool _monto_afecta_linea_creditoNull = true;
		private string _comision_por_venta;
		private string _observacion;
		private string _a_consignacion;
		private string _direccion;
		private decimal _latitud;
		private bool _latitudNull = true;
		private decimal _longitud;
		private bool _longitudNull = true;
		private string _observacion_entrega;
		private string _condicion_descripcion;
		private string _impreso;
		private decimal _mora_porcentaje;
		private decimal _mora_dias_gracia;
		private string _afecta_stock;
		private decimal _total_recargo_financiero;
		private decimal _total_entrega_inicial;
		private decimal _nro_comprobante_secuencia;
		private bool _nro_comprobante_secuenciaNull = true;
		private decimal _persona_garante_1_id;
		private bool _persona_garante_1_idNull = true;
		private decimal _persona_garante_2_id;
		private bool _persona_garante_2_idNull = true;
		private decimal _persona_garante_3_id;
		private bool _persona_garante_3_idNull = true;
		private string _nro_documento_externo;
		private decimal _sucursal_venta_id;
		private bool _sucursal_venta_idNull = true;
		private string _controlar_cant_min_desc_max;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private string _estado;
		private string _generar_transferencia;
		private decimal _deposito_destino_id;
		private bool _deposito_destino_idNull = true;
		private decimal _autonumeracion_transf_id;
		private bool _autonumeracion_transf_idNull = true;
		private string _nro_timbrado_fact_pro;
		private System.DateTime _fecha_venc_timbrado_fact_pro;
		private bool _fecha_venc_timbrado_fact_proNull = true;
		private string _nro_comprobante_fact_pro;
		private decimal _canal_venta_id;
		private bool _canal_venta_idNull = true;
		private string _es_rapida;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTERow_Base"/> class.
		/// </summary>
		public FACTURAS_CLIENTERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_CLIENTERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsCASO_ORIGEN_IDNull != original.IsCASO_ORIGEN_IDNull) return true;
			if (!this.IsCASO_ORIGEN_IDNull && !original.IsCASO_ORIGEN_IDNull)
				if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsVENDEDOR_IDNull != original.IsVENDEDOR_IDNull) return true;
			if (!this.IsVENDEDOR_IDNull && !original.IsVENDEDOR_IDNull)
				if (this.VENDEDOR_ID != original.VENDEDOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.TIPO_FACTURA_ID != original.TIPO_FACTURA_ID) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsCONDICION_PAGO_IDNull != original.IsCONDICION_PAGO_IDNull) return true;
			if (!this.IsCONDICION_PAGO_IDNull && !original.IsCONDICION_PAGO_IDNull)
				if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.IsPORCENTAJE_DESC_SOBRE_TOTALNull != original.IsPORCENTAJE_DESC_SOBRE_TOTALNull) return true;
			if (!this.IsPORCENTAJE_DESC_SOBRE_TOTALNull && !original.IsPORCENTAJE_DESC_SOBRE_TOTALNull)
				if (this.PORCENTAJE_DESC_SOBRE_TOTAL != original.PORCENTAJE_DESC_SOBRE_TOTAL) return true;
			if (this.IsMONEDA_DESTINO_IDNull != original.IsMONEDA_DESTINO_IDNull) return true;
			if (!this.IsMONEDA_DESTINO_IDNull && !original.IsMONEDA_DESTINO_IDNull)
				if (this.MONEDA_DESTINO_ID != original.MONEDA_DESTINO_ID) return true;
			if (this.IsCOTIZACION_DESTINONull != original.IsCOTIZACION_DESTINONull) return true;
			if (!this.IsCOTIZACION_DESTINONull && !original.IsCOTIZACION_DESTINONull)
				if (this.COTIZACION_DESTINO != original.COTIZACION_DESTINO) return true;
			if (this.IsTOTAL_MONTO_IMPUESTONull != original.IsTOTAL_MONTO_IMPUESTONull) return true;
			if (!this.IsTOTAL_MONTO_IMPUESTONull && !original.IsTOTAL_MONTO_IMPUESTONull)
				if (this.TOTAL_MONTO_IMPUESTO != original.TOTAL_MONTO_IMPUESTO) return true;
			if (this.IsTOTAL_MONTO_DTONull != original.IsTOTAL_MONTO_DTONull) return true;
			if (!this.IsTOTAL_MONTO_DTONull && !original.IsTOTAL_MONTO_DTONull)
				if (this.TOTAL_MONTO_DTO != original.TOTAL_MONTO_DTO) return true;
			if (this.IsTOTAL_MONTO_BRUTONull != original.IsTOTAL_MONTO_BRUTONull) return true;
			if (!this.IsTOTAL_MONTO_BRUTONull && !original.IsTOTAL_MONTO_BRUTONull)
				if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			if (this.IsTOTAL_NETONull != original.IsTOTAL_NETONull) return true;
			if (!this.IsTOTAL_NETONull && !original.IsTOTAL_NETONull)
				if (this.TOTAL_NETO != original.TOTAL_NETO) return true;
			if (this.IsTOTAL_COSTO_BRUTONull != original.IsTOTAL_COSTO_BRUTONull) return true;
			if (!this.IsTOTAL_COSTO_BRUTONull && !original.IsTOTAL_COSTO_BRUTONull)
				if (this.TOTAL_COSTO_BRUTO != original.TOTAL_COSTO_BRUTO) return true;
			if (this.IsTOTAL_COSTO_NETONull != original.IsTOTAL_COSTO_NETONull) return true;
			if (!this.IsTOTAL_COSTO_NETONull && !original.IsTOTAL_COSTO_NETONull)
				if (this.TOTAL_COSTO_NETO != original.TOTAL_COSTO_NETO) return true;
			if (this.IsTOTAL_COMISION_VENDEDORNull != original.IsTOTAL_COMISION_VENDEDORNull) return true;
			if (!this.IsTOTAL_COMISION_VENDEDORNull && !original.IsTOTAL_COMISION_VENDEDORNull)
				if (this.TOTAL_COMISION_VENDEDOR != original.TOTAL_COMISION_VENDEDOR) return true;
			if (this.IsUSUARIO_ID_AUTORIZA_DESCUENTONull != original.IsUSUARIO_ID_AUTORIZA_DESCUENTONull) return true;
			if (!this.IsUSUARIO_ID_AUTORIZA_DESCUENTONull && !original.IsUSUARIO_ID_AUTORIZA_DESCUENTONull)
				if (this.USUARIO_ID_AUTORIZA_DESCUENTO != original.USUARIO_ID_AUTORIZA_DESCUENTO) return true;
			if (this.IsFECHA_AUTORIZACION_DESCUENTONull != original.IsFECHA_AUTORIZACION_DESCUENTONull) return true;
			if (!this.IsFECHA_AUTORIZACION_DESCUENTONull && !original.IsFECHA_AUTORIZACION_DESCUENTONull)
				if (this.FECHA_AUTORIZACION_DESCUENTO != original.FECHA_AUTORIZACION_DESCUENTO) return true;
			if (this.IsDESCUENTO_MAX_AUTORIZADONull != original.IsDESCUENTO_MAX_AUTORIZADONull) return true;
			if (!this.IsDESCUENTO_MAX_AUTORIZADONull && !original.IsDESCUENTO_MAX_AUTORIZADONull)
				if (this.DESCUENTO_MAX_AUTORIZADO != original.DESCUENTO_MAX_AUTORIZADO) return true;
			if (this.AFECTA_LINEA_CREDITO != original.AFECTA_LINEA_CREDITO) return true;
			if (this.AFECTA_CTACTE != original.AFECTA_CTACTE) return true;
			if (this.IsMONTO_AFECTA_LINEA_CREDITONull != original.IsMONTO_AFECTA_LINEA_CREDITONull) return true;
			if (!this.IsMONTO_AFECTA_LINEA_CREDITONull && !original.IsMONTO_AFECTA_LINEA_CREDITONull)
				if (this.MONTO_AFECTA_LINEA_CREDITO != original.MONTO_AFECTA_LINEA_CREDITO) return true;
			if (this.COMISION_POR_VENTA != original.COMISION_POR_VENTA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.A_CONSIGNACION != original.A_CONSIGNACION) return true;
			if (this.DIRECCION != original.DIRECCION) return true;
			if (this.IsLATITUDNull != original.IsLATITUDNull) return true;
			if (!this.IsLATITUDNull && !original.IsLATITUDNull)
				if (this.LATITUD != original.LATITUD) return true;
			if (this.IsLONGITUDNull != original.IsLONGITUDNull) return true;
			if (!this.IsLONGITUDNull && !original.IsLONGITUDNull)
				if (this.LONGITUD != original.LONGITUD) return true;
			if (this.OBSERVACION_ENTREGA != original.OBSERVACION_ENTREGA) return true;
			if (this.CONDICION_DESCRIPCION != original.CONDICION_DESCRIPCION) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			if (this.MORA_PORCENTAJE != original.MORA_PORCENTAJE) return true;
			if (this.MORA_DIAS_GRACIA != original.MORA_DIAS_GRACIA) return true;
			if (this.AFECTA_STOCK != original.AFECTA_STOCK) return true;
			if (this.TOTAL_RECARGO_FINANCIERO != original.TOTAL_RECARGO_FINANCIERO) return true;
			if (this.TOTAL_ENTREGA_INICIAL != original.TOTAL_ENTREGA_INICIAL) return true;
			if (this.IsNRO_COMPROBANTE_SECUENCIANull != original.IsNRO_COMPROBANTE_SECUENCIANull) return true;
			if (!this.IsNRO_COMPROBANTE_SECUENCIANull && !original.IsNRO_COMPROBANTE_SECUENCIANull)
				if (this.NRO_COMPROBANTE_SECUENCIA != original.NRO_COMPROBANTE_SECUENCIA) return true;
			if (this.IsPERSONA_GARANTE_1_IDNull != original.IsPERSONA_GARANTE_1_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_1_IDNull && !original.IsPERSONA_GARANTE_1_IDNull)
				if (this.PERSONA_GARANTE_1_ID != original.PERSONA_GARANTE_1_ID) return true;
			if (this.IsPERSONA_GARANTE_2_IDNull != original.IsPERSONA_GARANTE_2_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_2_IDNull && !original.IsPERSONA_GARANTE_2_IDNull)
				if (this.PERSONA_GARANTE_2_ID != original.PERSONA_GARANTE_2_ID) return true;
			if (this.IsPERSONA_GARANTE_3_IDNull != original.IsPERSONA_GARANTE_3_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_3_IDNull && !original.IsPERSONA_GARANTE_3_IDNull)
				if (this.PERSONA_GARANTE_3_ID != original.PERSONA_GARANTE_3_ID) return true;
			if (this.NRO_DOCUMENTO_EXTERNO != original.NRO_DOCUMENTO_EXTERNO) return true;
			if (this.IsSUCURSAL_VENTA_IDNull != original.IsSUCURSAL_VENTA_IDNull) return true;
			if (!this.IsSUCURSAL_VENTA_IDNull && !original.IsSUCURSAL_VENTA_IDNull)
				if (this.SUCURSAL_VENTA_ID != original.SUCURSAL_VENTA_ID) return true;
			if (this.CONTROLAR_CANT_MIN_DESC_MAX != original.CONTROLAR_CANT_MIN_DESC_MAX) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.GENERAR_TRANSFERENCIA != original.GENERAR_TRANSFERENCIA) return true;
			if (this.IsDEPOSITO_DESTINO_IDNull != original.IsDEPOSITO_DESTINO_IDNull) return true;
			if (!this.IsDEPOSITO_DESTINO_IDNull && !original.IsDEPOSITO_DESTINO_IDNull)
				if (this.DEPOSITO_DESTINO_ID != original.DEPOSITO_DESTINO_ID) return true;
			if (this.IsAUTONUMERACION_TRANSF_IDNull != original.IsAUTONUMERACION_TRANSF_IDNull) return true;
			if (!this.IsAUTONUMERACION_TRANSF_IDNull && !original.IsAUTONUMERACION_TRANSF_IDNull)
				if (this.AUTONUMERACION_TRANSF_ID != original.AUTONUMERACION_TRANSF_ID) return true;
			if (this.NRO_TIMBRADO_FACT_PRO != original.NRO_TIMBRADO_FACT_PRO) return true;
			if (this.IsFECHA_VENC_TIMBRADO_FACT_PRONull != original.IsFECHA_VENC_TIMBRADO_FACT_PRONull) return true;
			if (!this.IsFECHA_VENC_TIMBRADO_FACT_PRONull && !original.IsFECHA_VENC_TIMBRADO_FACT_PRONull)
				if (this.FECHA_VENC_TIMBRADO_FACT_PRO != original.FECHA_VENC_TIMBRADO_FACT_PRO) return true;
			if (this.NRO_COMPROBANTE_FACT_PRO != original.NRO_COMPROBANTE_FACT_PRO) return true;
			if (this.IsCANAL_VENTA_IDNull != original.IsCANAL_VENTA_IDNull) return true;
			if (!this.IsCANAL_VENTA_IDNull && !original.IsCANAL_VENTA_IDNull)
				if (this.CANAL_VENTA_ID != original.CANAL_VENTA_ID) return true;
			if (this.ES_RAPIDA != original.ES_RAPIDA) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get
			{
				if(IsCASO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_origen_id;
			}
			set
			{
				_caso_origen_idNull = false;
				_caso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGEN_IDNull
		{
			get { return _caso_origen_idNull; }
			set { _caso_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_ID</c> column value.</value>
		public decimal VENDEDOR_ID
		{
			get
			{
				if(IsVENDEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vendedor_id;
			}
			set
			{
				_vendedor_idNull = false;
				_vendedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENDEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENDEDOR_IDNull
		{
			get { return _vendedor_idNull; }
			set { _vendedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_FACTURA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_FACTURA_ID</c> column value.</value>
		public string TIPO_FACTURA_ID
		{
			get { return _tipo_factura_id; }
			set { _tipo_factura_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get
			{
				if(IsCONDICION_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_pago_id;
			}
			set
			{
				_condicion_pago_idNull = false;
				_condicion_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_PAGO_IDNull
		{
			get { return _condicion_pago_idNull; }
			set { _condicion_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DESC_SOBRE_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DESC_SOBRE_TOTAL</c> column value.</value>
		public decimal PORCENTAJE_DESC_SOBRE_TOTAL
		{
			get
			{
				if(IsPORCENTAJE_DESC_SOBRE_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_desc_sobre_total;
			}
			set
			{
				_porcentaje_desc_sobre_totalNull = false;
				_porcentaje_desc_sobre_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_DESC_SOBRE_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_DESC_SOBRE_TOTALNull
		{
			get { return _porcentaje_desc_sobre_totalNull; }
			set { _porcentaje_desc_sobre_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_ID</c> column value.</value>
		public decimal MONEDA_DESTINO_ID
		{
			get
			{
				if(IsMONEDA_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_destino_id;
			}
			set
			{
				_moneda_destino_idNull = false;
				_moneda_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_DESTINO_IDNull
		{
			get { return _moneda_destino_idNull; }
			set { _moneda_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_DESTINO</c> column value.</value>
		public decimal COTIZACION_DESTINO
		{
			get
			{
				if(IsCOTIZACION_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_destino;
			}
			set
			{
				_cotizacion_destinoNull = false;
				_cotizacion_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_DESTINONull
		{
			get { return _cotizacion_destinoNull; }
			set { _cotizacion_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO
		{
			get
			{
				if(IsTOTAL_MONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_impuesto;
			}
			set
			{
				_total_monto_impuestoNull = false;
				_total_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_IMPUESTONull
		{
			get { return _total_monto_impuestoNull; }
			set { _total_monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_DTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_DTO</c> column value.</value>
		public decimal TOTAL_MONTO_DTO
		{
			get
			{
				if(IsTOTAL_MONTO_DTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_dto;
			}
			set
			{
				_total_monto_dtoNull = false;
				_total_monto_dto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_DTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_DTONull
		{
			get { return _total_monto_dtoNull; }
			set { _total_monto_dtoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto;
			}
			set
			{
				_total_monto_brutoNull = false;
				_total_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTONull
		{
			get { return _total_monto_brutoNull; }
			set { _total_monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_NETO</c> column value.</value>
		public decimal TOTAL_NETO
		{
			get
			{
				if(IsTOTAL_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_neto;
			}
			set
			{
				_total_netoNull = false;
				_total_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_NETONull
		{
			get { return _total_netoNull; }
			set { _total_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COSTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_COSTO_BRUTO</c> column value.</value>
		public decimal TOTAL_COSTO_BRUTO
		{
			get
			{
				if(IsTOTAL_COSTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_costo_bruto;
			}
			set
			{
				_total_costo_brutoNull = false;
				_total_costo_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_COSTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_COSTO_BRUTONull
		{
			get { return _total_costo_brutoNull; }
			set { _total_costo_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COSTO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_COSTO_NETO</c> column value.</value>
		public decimal TOTAL_COSTO_NETO
		{
			get
			{
				if(IsTOTAL_COSTO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_costo_neto;
			}
			set
			{
				_total_costo_netoNull = false;
				_total_costo_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_COSTO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_COSTO_NETONull
		{
			get { return _total_costo_netoNull; }
			set { _total_costo_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COMISION_VENDEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_COMISION_VENDEDOR</c> column value.</value>
		public decimal TOTAL_COMISION_VENDEDOR
		{
			get
			{
				if(IsTOTAL_COMISION_VENDEDORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_comision_vendedor;
			}
			set
			{
				_total_comision_vendedorNull = false;
				_total_comision_vendedor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_COMISION_VENDEDOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_COMISION_VENDEDORNull
		{
			get { return _total_comision_vendedorNull; }
			set { _total_comision_vendedorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</value>
		public decimal USUARIO_ID_AUTORIZA_DESCUENTO
		{
			get
			{
				if(IsUSUARIO_ID_AUTORIZA_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id_autoriza_descuento;
			}
			set
			{
				_usuario_id_autoriza_descuentoNull = false;
				_usuario_id_autoriza_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID_AUTORIZA_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ID_AUTORIZA_DESCUENTONull
		{
			get { return _usuario_id_autoriza_descuentoNull; }
			set { _usuario_id_autoriza_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_AUTORIZACION_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_AUTORIZACION_DESCUENTO</c> column value.</value>
		public System.DateTime FECHA_AUTORIZACION_DESCUENTO
		{
			get
			{
				if(IsFECHA_AUTORIZACION_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_autorizacion_descuento;
			}
			set
			{
				_fecha_autorizacion_descuentoNull = false;
				_fecha_autorizacion_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_AUTORIZACION_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_AUTORIZACION_DESCUENTONull
		{
			get { return _fecha_autorizacion_descuentoNull; }
			set { _fecha_autorizacion_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_MAX_AUTORIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_MAX_AUTORIZADO</c> column value.</value>
		public decimal DESCUENTO_MAX_AUTORIZADO
		{
			get
			{
				if(IsDESCUENTO_MAX_AUTORIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_max_autorizado;
			}
			set
			{
				_descuento_max_autorizadoNull = false;
				_descuento_max_autorizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_MAX_AUTORIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_MAX_AUTORIZADONull
		{
			get { return _descuento_max_autorizadoNull; }
			set { _descuento_max_autorizadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_LINEA_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AFECTA_LINEA_CREDITO</c> column value.</value>
		public string AFECTA_LINEA_CREDITO
		{
			get { return _afecta_linea_credito; }
			set { _afecta_linea_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CTACTE</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CTACTE</c> column value.</value>
		public string AFECTA_CTACTE
		{
			get { return _afecta_ctacte; }
			set { _afecta_ctacte = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_AFECTA_LINEA_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_AFECTA_LINEA_CREDITO</c> column value.</value>
		public decimal MONTO_AFECTA_LINEA_CREDITO
		{
			get
			{
				if(IsMONTO_AFECTA_LINEA_CREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_afecta_linea_credito;
			}
			set
			{
				_monto_afecta_linea_creditoNull = false;
				_monto_afecta_linea_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_AFECTA_LINEA_CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_AFECTA_LINEA_CREDITONull
		{
			get { return _monto_afecta_linea_creditoNull; }
			set { _monto_afecta_linea_creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_POR_VENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_POR_VENTA</c> column value.</value>
		public string COMISION_POR_VENTA
		{
			get { return _comision_por_venta; }
			set { _comision_por_venta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>A_CONSIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>A_CONSIGNACION</c> column value.</value>
		public string A_CONSIGNACION
		{
			get { return _a_consignacion; }
			set { _a_consignacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION</c> column value.</value>
		public string DIRECCION
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD</c> column value.</value>
		public decimal LATITUD
		{
			get
			{
				if(IsLATITUDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud;
			}
			set
			{
				_latitudNull = false;
				_latitud = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUDNull
		{
			get { return _latitudNull; }
			set { _latitudNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD</c> column value.</value>
		public decimal LONGITUD
		{
			get
			{
				if(IsLONGITUDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud;
			}
			set
			{
				_longitudNull = false;
				_longitud = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUDNull
		{
			get { return _longitudNull; }
			set { _longitudNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_ENTREGA</c> column value.</value>
		public string OBSERVACION_ENTREGA
		{
			get { return _observacion_entrega; }
			set { _observacion_entrega = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_DESCRIPCION</c> column value.</value>
		public string CONDICION_DESCRIPCION
		{
			get { return _condicion_descripcion; }
			set { _condicion_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MORA_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>MORA_PORCENTAJE</c> column value.</value>
		public decimal MORA_PORCENTAJE
		{
			get { return _mora_porcentaje; }
			set { _mora_porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MORA_DIAS_GRACIA</c> column value.
		/// </summary>
		/// <value>The <c>MORA_DIAS_GRACIA</c> column value.</value>
		public decimal MORA_DIAS_GRACIA
		{
			get { return _mora_dias_gracia; }
			set { _mora_dias_gracia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_STOCK</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_STOCK</c> column value.</value>
		public string AFECTA_STOCK
		{
			get { return _afecta_stock; }
			set { _afecta_stock = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_RECARGO_FINANCIERO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_RECARGO_FINANCIERO</c> column value.</value>
		public decimal TOTAL_RECARGO_FINANCIERO
		{
			get { return _total_recargo_financiero; }
			set { _total_recargo_financiero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_ENTREGA_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_ENTREGA_INICIAL</c> column value.</value>
		public decimal TOTAL_ENTREGA_INICIAL
		{
			get { return _total_entrega_inicial; }
			set { _total_entrega_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE_SECUENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_SECUENCIA</c> column value.</value>
		public decimal NRO_COMPROBANTE_SECUENCIA
		{
			get
			{
				if(IsNRO_COMPROBANTE_SECUENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_comprobante_secuencia;
			}
			set
			{
				_nro_comprobante_secuenciaNull = false;
				_nro_comprobante_secuencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_COMPROBANTE_SECUENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_COMPROBANTE_SECUENCIANull
		{
			get { return _nro_comprobante_secuenciaNull; }
			set { _nro_comprobante_secuenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_1_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_1_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_1_id;
			}
			set
			{
				_persona_garante_1_idNull = false;
				_persona_garante_1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_1_IDNull
		{
			get { return _persona_garante_1_idNull; }
			set { _persona_garante_1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_2_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_2_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_2_id;
			}
			set
			{
				_persona_garante_2_idNull = false;
				_persona_garante_2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_2_IDNull
		{
			get { return _persona_garante_2_idNull; }
			set { _persona_garante_2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_3_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_3_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_3_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_3_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_3_id;
			}
			set
			{
				_persona_garante_3_idNull = false;
				_persona_garante_3_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_3_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_3_IDNull
		{
			get { return _persona_garante_3_idNull; }
			set { _persona_garante_3_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_DOCUMENTO_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_DOCUMENTO_EXTERNO</c> column value.</value>
		public string NRO_DOCUMENTO_EXTERNO
		{
			get { return _nro_documento_externo; }
			set { _nro_documento_externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_VENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_VENTA_ID</c> column value.</value>
		public decimal SUCURSAL_VENTA_ID
		{
			get
			{
				if(IsSUCURSAL_VENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_venta_id;
			}
			set
			{
				_sucursal_venta_idNull = false;
				_sucursal_venta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_VENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_VENTA_IDNull
		{
			get { return _sucursal_venta_idNull; }
			set { _sucursal_venta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTROLAR_CANT_MIN_DESC_MAX</c> column value.
		/// </summary>
		/// <value>The <c>CONTROLAR_CANT_MIN_DESC_MAX</c> column value.</value>
		public string CONTROLAR_CANT_MIN_DESC_MAX
		{
			get { return _controlar_cant_min_desc_max; }
			set { _controlar_cant_min_desc_max = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERAR_TRANSFERENCIA</c> column value.
		/// </summary>
		/// <value>The <c>GENERAR_TRANSFERENCIA</c> column value.</value>
		public string GENERAR_TRANSFERENCIA
		{
			get { return _generar_transferencia; }
			set { _generar_transferencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_DESTINO_ID</c> column value.</value>
		public decimal DEPOSITO_DESTINO_ID
		{
			get
			{
				if(IsDEPOSITO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_destino_id;
			}
			set
			{
				_deposito_destino_idNull = false;
				_deposito_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_DESTINO_IDNull
		{
			get { return _deposito_destino_idNull; }
			set { _deposito_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_TRANSF_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_TRANSF_ID</c> column value.</value>
		public decimal AUTONUMERACION_TRANSF_ID
		{
			get
			{
				if(IsAUTONUMERACION_TRANSF_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_transf_id;
			}
			set
			{
				_autonumeracion_transf_idNull = false;
				_autonumeracion_transf_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_TRANSF_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_TRANSF_IDNull
		{
			get { return _autonumeracion_transf_idNull; }
			set { _autonumeracion_transf_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_TIMBRADO_FACT_PRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_TIMBRADO_FACT_PRO</c> column value.</value>
		public string NRO_TIMBRADO_FACT_PRO
		{
			get { return _nro_timbrado_fact_pro; }
			set { _nro_timbrado_fact_pro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENC_TIMBRADO_FACT_PRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENC_TIMBRADO_FACT_PRO</c> column value.</value>
		public System.DateTime FECHA_VENC_TIMBRADO_FACT_PRO
		{
			get
			{
				if(IsFECHA_VENC_TIMBRADO_FACT_PRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_venc_timbrado_fact_pro;
			}
			set
			{
				_fecha_venc_timbrado_fact_proNull = false;
				_fecha_venc_timbrado_fact_pro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENC_TIMBRADO_FACT_PRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENC_TIMBRADO_FACT_PRONull
		{
			get { return _fecha_venc_timbrado_fact_proNull; }
			set { _fecha_venc_timbrado_fact_proNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE_FACT_PRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_FACT_PRO</c> column value.</value>
		public string NRO_COMPROBANTE_FACT_PRO
		{
			get { return _nro_comprobante_fact_pro; }
			set { _nro_comprobante_fact_pro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANAL_VENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANAL_VENTA_ID</c> column value.</value>
		public decimal CANAL_VENTA_ID
		{
			get
			{
				if(IsCANAL_VENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _canal_venta_id;
			}
			set
			{
				_canal_venta_idNull = false;
				_canal_venta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANAL_VENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANAL_VENTA_IDNull
		{
			get { return _canal_venta_idNull; }
			set { _canal_venta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_RAPIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_RAPIDA</c> column value.</value>
		public string ES_RAPIDA
		{
			get { return _es_rapida; }
			set { _es_rapida = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(IsCASO_ORIGEN_IDNull ? (object)"<NULL>" : CASO_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@VENDEDOR_ID=");
			dynStr.Append(IsVENDEDOR_IDNull ? (object)"<NULL>" : VENDEDOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@TIPO_FACTURA_ID=");
			dynStr.Append(TIPO_FACTURA_ID);
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(IsCONDICION_PAGO_IDNull ? (object)"<NULL>" : CONDICION_PAGO_ID);
			dynStr.Append("@CBA@PORCENTAJE_DESC_SOBRE_TOTAL=");
			dynStr.Append(IsPORCENTAJE_DESC_SOBRE_TOTALNull ? (object)"<NULL>" : PORCENTAJE_DESC_SOBRE_TOTAL);
			dynStr.Append("@CBA@MONEDA_DESTINO_ID=");
			dynStr.Append(IsMONEDA_DESTINO_IDNull ? (object)"<NULL>" : MONEDA_DESTINO_ID);
			dynStr.Append("@CBA@COTIZACION_DESTINO=");
			dynStr.Append(IsCOTIZACION_DESTINONull ? (object)"<NULL>" : COTIZACION_DESTINO);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO=");
			dynStr.Append(IsTOTAL_MONTO_IMPUESTONull ? (object)"<NULL>" : TOTAL_MONTO_IMPUESTO);
			dynStr.Append("@CBA@TOTAL_MONTO_DTO=");
			dynStr.Append(IsTOTAL_MONTO_DTONull ? (object)"<NULL>" : TOTAL_MONTO_DTO);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(IsTOTAL_MONTO_BRUTONull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO);
			dynStr.Append("@CBA@TOTAL_NETO=");
			dynStr.Append(IsTOTAL_NETONull ? (object)"<NULL>" : TOTAL_NETO);
			dynStr.Append("@CBA@TOTAL_COSTO_BRUTO=");
			dynStr.Append(IsTOTAL_COSTO_BRUTONull ? (object)"<NULL>" : TOTAL_COSTO_BRUTO);
			dynStr.Append("@CBA@TOTAL_COSTO_NETO=");
			dynStr.Append(IsTOTAL_COSTO_NETONull ? (object)"<NULL>" : TOTAL_COSTO_NETO);
			dynStr.Append("@CBA@TOTAL_COMISION_VENDEDOR=");
			dynStr.Append(IsTOTAL_COMISION_VENDEDORNull ? (object)"<NULL>" : TOTAL_COMISION_VENDEDOR);
			dynStr.Append("@CBA@USUARIO_ID_AUTORIZA_DESCUENTO=");
			dynStr.Append(IsUSUARIO_ID_AUTORIZA_DESCUENTONull ? (object)"<NULL>" : USUARIO_ID_AUTORIZA_DESCUENTO);
			dynStr.Append("@CBA@FECHA_AUTORIZACION_DESCUENTO=");
			dynStr.Append(IsFECHA_AUTORIZACION_DESCUENTONull ? (object)"<NULL>" : FECHA_AUTORIZACION_DESCUENTO);
			dynStr.Append("@CBA@DESCUENTO_MAX_AUTORIZADO=");
			dynStr.Append(IsDESCUENTO_MAX_AUTORIZADONull ? (object)"<NULL>" : DESCUENTO_MAX_AUTORIZADO);
			dynStr.Append("@CBA@AFECTA_LINEA_CREDITO=");
			dynStr.Append(AFECTA_LINEA_CREDITO);
			dynStr.Append("@CBA@AFECTA_CTACTE=");
			dynStr.Append(AFECTA_CTACTE);
			dynStr.Append("@CBA@MONTO_AFECTA_LINEA_CREDITO=");
			dynStr.Append(IsMONTO_AFECTA_LINEA_CREDITONull ? (object)"<NULL>" : MONTO_AFECTA_LINEA_CREDITO);
			dynStr.Append("@CBA@COMISION_POR_VENTA=");
			dynStr.Append(COMISION_POR_VENTA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@A_CONSIGNACION=");
			dynStr.Append(A_CONSIGNACION);
			dynStr.Append("@CBA@DIRECCION=");
			dynStr.Append(DIRECCION);
			dynStr.Append("@CBA@LATITUD=");
			dynStr.Append(IsLATITUDNull ? (object)"<NULL>" : LATITUD);
			dynStr.Append("@CBA@LONGITUD=");
			dynStr.Append(IsLONGITUDNull ? (object)"<NULL>" : LONGITUD);
			dynStr.Append("@CBA@OBSERVACION_ENTREGA=");
			dynStr.Append(OBSERVACION_ENTREGA);
			dynStr.Append("@CBA@CONDICION_DESCRIPCION=");
			dynStr.Append(CONDICION_DESCRIPCION);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			dynStr.Append("@CBA@MORA_PORCENTAJE=");
			dynStr.Append(MORA_PORCENTAJE);
			dynStr.Append("@CBA@MORA_DIAS_GRACIA=");
			dynStr.Append(MORA_DIAS_GRACIA);
			dynStr.Append("@CBA@AFECTA_STOCK=");
			dynStr.Append(AFECTA_STOCK);
			dynStr.Append("@CBA@TOTAL_RECARGO_FINANCIERO=");
			dynStr.Append(TOTAL_RECARGO_FINANCIERO);
			dynStr.Append("@CBA@TOTAL_ENTREGA_INICIAL=");
			dynStr.Append(TOTAL_ENTREGA_INICIAL);
			dynStr.Append("@CBA@NRO_COMPROBANTE_SECUENCIA=");
			dynStr.Append(IsNRO_COMPROBANTE_SECUENCIANull ? (object)"<NULL>" : NRO_COMPROBANTE_SECUENCIA);
			dynStr.Append("@CBA@PERSONA_GARANTE_1_ID=");
			dynStr.Append(IsPERSONA_GARANTE_1_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_1_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_2_ID=");
			dynStr.Append(IsPERSONA_GARANTE_2_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_2_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_3_ID=");
			dynStr.Append(IsPERSONA_GARANTE_3_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_3_ID);
			dynStr.Append("@CBA@NRO_DOCUMENTO_EXTERNO=");
			dynStr.Append(NRO_DOCUMENTO_EXTERNO);
			dynStr.Append("@CBA@SUCURSAL_VENTA_ID=");
			dynStr.Append(IsSUCURSAL_VENTA_IDNull ? (object)"<NULL>" : SUCURSAL_VENTA_ID);
			dynStr.Append("@CBA@CONTROLAR_CANT_MIN_DESC_MAX=");
			dynStr.Append(CONTROLAR_CANT_MIN_DESC_MAX);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@GENERAR_TRANSFERENCIA=");
			dynStr.Append(GENERAR_TRANSFERENCIA);
			dynStr.Append("@CBA@DEPOSITO_DESTINO_ID=");
			dynStr.Append(IsDEPOSITO_DESTINO_IDNull ? (object)"<NULL>" : DEPOSITO_DESTINO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_TRANSF_ID=");
			dynStr.Append(IsAUTONUMERACION_TRANSF_IDNull ? (object)"<NULL>" : AUTONUMERACION_TRANSF_ID);
			dynStr.Append("@CBA@NRO_TIMBRADO_FACT_PRO=");
			dynStr.Append(NRO_TIMBRADO_FACT_PRO);
			dynStr.Append("@CBA@FECHA_VENC_TIMBRADO_FACT_PRO=");
			dynStr.Append(IsFECHA_VENC_TIMBRADO_FACT_PRONull ? (object)"<NULL>" : FECHA_VENC_TIMBRADO_FACT_PRO);
			dynStr.Append("@CBA@NRO_COMPROBANTE_FACT_PRO=");
			dynStr.Append(NRO_COMPROBANTE_FACT_PRO);
			dynStr.Append("@CBA@CANAL_VENTA_ID=");
			dynStr.Append(IsCANAL_VENTA_IDNull ? (object)"<NULL>" : CANAL_VENTA_ID);
			dynStr.Append("@CBA@ES_RAPIDA=");
			dynStr.Append(ES_RAPIDA);
			return dynStr.ToString();
		}
	} // End of FACTURAS_CLIENTERow_Base class
} // End of namespace
