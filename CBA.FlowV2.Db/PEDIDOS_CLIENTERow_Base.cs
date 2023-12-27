// <fileinfo name="PEDIDOS_CLIENTERow_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTERow"/> that 
	/// represents a record in the <c>PEDIDOS_CLIENTE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PEDIDOS_CLIENTERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTERow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _sucursal_venta_id;
		private bool _sucursal_venta_idNull = true;
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
		private decimal _total_monto_bruto_inicial;
		private bool _total_monto_bruto_inicialNull = true;
		private decimal _total_monto_bruto_final;
		private bool _total_monto_bruto_finalNull = true;
		private decimal _total_neto;
		private bool _total_netoNull = true;
		private decimal _total_final_subitems;
		private bool _total_final_subitemsNull = true;
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
		private decimal _monto_afecta_linea_credito;
		private bool _monto_afecta_linea_creditoNull = true;
		private string _comision_por_venta;
		private string _observacion;
		private string _aprobacion_dpto_credito;
		private System.DateTime _fecha_aprob_dpto_credito;
		private bool _fecha_aprob_dpto_creditoNull = true;
		private decimal _usuario_aprob_dpto_credito;
		private bool _usuario_aprob_dpto_creditoNull = true;
		private string _aprobacion_dpto_precios;
		private System.DateTime _fecha_aprob_dpto_precios;
		private bool _fecha_aprob_dpto_preciosNull = true;
		private decimal _usuario_aprob_dpto_precios;
		private bool _usuario_aprob_dpto_preciosNull = true;
		private decimal _texto_obs_dpto_credito_id;
		private bool _texto_obs_dpto_credito_idNull = true;
		private decimal _texto_obs_dpto_precios_id;
		private bool _texto_obs_dpto_precios_idNull = true;
		private string _preventa;
		private decimal _preventa_orden;
		private bool _preventa_ordenNull = true;
		private System.DateTime _preventa_fecha_entrega;
		private bool _preventa_fecha_entregaNull = true;
		private string _a_consignacion;
		private string _impreso;
		private decimal _monto_credito_aprobado;
		private bool _monto_credito_aprobadoNull = true;
		private decimal _total_recargo_financiero;
		private decimal _total_entrega_inicial;
		private string _controlar_cant_min_desc_max;
		private string _usar_remisiones;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTERow_Base"/> class.
		/// </summary>
		public PEDIDOS_CLIENTERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PEDIDOS_CLIENTERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsSUCURSAL_VENTA_IDNull != original.IsSUCURSAL_VENTA_IDNull) return true;
			if (!this.IsSUCURSAL_VENTA_IDNull && !original.IsSUCURSAL_VENTA_IDNull)
				if (this.SUCURSAL_VENTA_ID != original.SUCURSAL_VENTA_ID) return true;
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
			if (this.IsTOTAL_MONTO_BRUTO_INICIALNull != original.IsTOTAL_MONTO_BRUTO_INICIALNull) return true;
			if (!this.IsTOTAL_MONTO_BRUTO_INICIALNull && !original.IsTOTAL_MONTO_BRUTO_INICIALNull)
				if (this.TOTAL_MONTO_BRUTO_INICIAL != original.TOTAL_MONTO_BRUTO_INICIAL) return true;
			if (this.IsTOTAL_MONTO_BRUTO_FINALNull != original.IsTOTAL_MONTO_BRUTO_FINALNull) return true;
			if (!this.IsTOTAL_MONTO_BRUTO_FINALNull && !original.IsTOTAL_MONTO_BRUTO_FINALNull)
				if (this.TOTAL_MONTO_BRUTO_FINAL != original.TOTAL_MONTO_BRUTO_FINAL) return true;
			if (this.IsTOTAL_NETONull != original.IsTOTAL_NETONull) return true;
			if (!this.IsTOTAL_NETONull && !original.IsTOTAL_NETONull)
				if (this.TOTAL_NETO != original.TOTAL_NETO) return true;
			if (this.IsTOTAL_FINAL_SUBITEMSNull != original.IsTOTAL_FINAL_SUBITEMSNull) return true;
			if (!this.IsTOTAL_FINAL_SUBITEMSNull && !original.IsTOTAL_FINAL_SUBITEMSNull)
				if (this.TOTAL_FINAL_SUBITEMS != original.TOTAL_FINAL_SUBITEMS) return true;
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
			if (this.IsMONTO_AFECTA_LINEA_CREDITONull != original.IsMONTO_AFECTA_LINEA_CREDITONull) return true;
			if (!this.IsMONTO_AFECTA_LINEA_CREDITONull && !original.IsMONTO_AFECTA_LINEA_CREDITONull)
				if (this.MONTO_AFECTA_LINEA_CREDITO != original.MONTO_AFECTA_LINEA_CREDITO) return true;
			if (this.COMISION_POR_VENTA != original.COMISION_POR_VENTA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.APROBACION_DPTO_CREDITO != original.APROBACION_DPTO_CREDITO) return true;
			if (this.IsFECHA_APROB_DPTO_CREDITONull != original.IsFECHA_APROB_DPTO_CREDITONull) return true;
			if (!this.IsFECHA_APROB_DPTO_CREDITONull && !original.IsFECHA_APROB_DPTO_CREDITONull)
				if (this.FECHA_APROB_DPTO_CREDITO != original.FECHA_APROB_DPTO_CREDITO) return true;
			if (this.IsUSUARIO_APROB_DPTO_CREDITONull != original.IsUSUARIO_APROB_DPTO_CREDITONull) return true;
			if (!this.IsUSUARIO_APROB_DPTO_CREDITONull && !original.IsUSUARIO_APROB_DPTO_CREDITONull)
				if (this.USUARIO_APROB_DPTO_CREDITO != original.USUARIO_APROB_DPTO_CREDITO) return true;
			if (this.APROBACION_DPTO_PRECIOS != original.APROBACION_DPTO_PRECIOS) return true;
			if (this.IsFECHA_APROB_DPTO_PRECIOSNull != original.IsFECHA_APROB_DPTO_PRECIOSNull) return true;
			if (!this.IsFECHA_APROB_DPTO_PRECIOSNull && !original.IsFECHA_APROB_DPTO_PRECIOSNull)
				if (this.FECHA_APROB_DPTO_PRECIOS != original.FECHA_APROB_DPTO_PRECIOS) return true;
			if (this.IsUSUARIO_APROB_DPTO_PRECIOSNull != original.IsUSUARIO_APROB_DPTO_PRECIOSNull) return true;
			if (!this.IsUSUARIO_APROB_DPTO_PRECIOSNull && !original.IsUSUARIO_APROB_DPTO_PRECIOSNull)
				if (this.USUARIO_APROB_DPTO_PRECIOS != original.USUARIO_APROB_DPTO_PRECIOS) return true;
			if (this.IsTEXTO_OBS_DPTO_CREDITO_IDNull != original.IsTEXTO_OBS_DPTO_CREDITO_IDNull) return true;
			if (!this.IsTEXTO_OBS_DPTO_CREDITO_IDNull && !original.IsTEXTO_OBS_DPTO_CREDITO_IDNull)
				if (this.TEXTO_OBS_DPTO_CREDITO_ID != original.TEXTO_OBS_DPTO_CREDITO_ID) return true;
			if (this.IsTEXTO_OBS_DPTO_PRECIOS_IDNull != original.IsTEXTO_OBS_DPTO_PRECIOS_IDNull) return true;
			if (!this.IsTEXTO_OBS_DPTO_PRECIOS_IDNull && !original.IsTEXTO_OBS_DPTO_PRECIOS_IDNull)
				if (this.TEXTO_OBS_DPTO_PRECIOS_ID != original.TEXTO_OBS_DPTO_PRECIOS_ID) return true;
			if (this.PREVENTA != original.PREVENTA) return true;
			if (this.IsPREVENTA_ORDENNull != original.IsPREVENTA_ORDENNull) return true;
			if (!this.IsPREVENTA_ORDENNull && !original.IsPREVENTA_ORDENNull)
				if (this.PREVENTA_ORDEN != original.PREVENTA_ORDEN) return true;
			if (this.IsPREVENTA_FECHA_ENTREGANull != original.IsPREVENTA_FECHA_ENTREGANull) return true;
			if (!this.IsPREVENTA_FECHA_ENTREGANull && !original.IsPREVENTA_FECHA_ENTREGANull)
				if (this.PREVENTA_FECHA_ENTREGA != original.PREVENTA_FECHA_ENTREGA) return true;
			if (this.A_CONSIGNACION != original.A_CONSIGNACION) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			if (this.IsMONTO_CREDITO_APROBADONull != original.IsMONTO_CREDITO_APROBADONull) return true;
			if (!this.IsMONTO_CREDITO_APROBADONull && !original.IsMONTO_CREDITO_APROBADONull)
				if (this.MONTO_CREDITO_APROBADO != original.MONTO_CREDITO_APROBADO) return true;
			if (this.TOTAL_RECARGO_FINANCIERO != original.TOTAL_RECARGO_FINANCIERO) return true;
			if (this.TOTAL_ENTREGA_INICIAL != original.TOTAL_ENTREGA_INICIAL) return true;
			if (this.CONTROLAR_CANT_MIN_DESC_MAX != original.CONTROLAR_CANT_MIN_DESC_MAX) return true;
			if (this.USAR_REMISIONES != original.USAR_REMISIONES) return true;
			
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
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO_INICIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO_INICIAL</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO_INICIAL
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTO_INICIALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto_inicial;
			}
			set
			{
				_total_monto_bruto_inicialNull = false;
				_total_monto_bruto_inicial = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO_INICIAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTO_INICIALNull
		{
			get { return _total_monto_bruto_inicialNull; }
			set { _total_monto_bruto_inicialNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO_FINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO_FINAL</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO_FINAL
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTO_FINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto_final;
			}
			set
			{
				_total_monto_bruto_finalNull = false;
				_total_monto_bruto_final = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO_FINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTO_FINALNull
		{
			get { return _total_monto_bruto_finalNull; }
			set { _total_monto_bruto_finalNull = value; }
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
		/// Gets or sets the <c>TOTAL_FINAL_SUBITEMS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_FINAL_SUBITEMS</c> column value.</value>
		public decimal TOTAL_FINAL_SUBITEMS
		{
			get
			{
				if(IsTOTAL_FINAL_SUBITEMSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_final_subitems;
			}
			set
			{
				_total_final_subitemsNull = false;
				_total_final_subitems = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_FINAL_SUBITEMS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_FINAL_SUBITEMSNull
		{
			get { return _total_final_subitemsNull; }
			set { _total_final_subitemsNull = value; }
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
		/// </summary>
		/// <value>The <c>AFECTA_LINEA_CREDITO</c> column value.</value>
		public string AFECTA_LINEA_CREDITO
		{
			get { return _afecta_linea_credito; }
			set { _afecta_linea_credito = value; }
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
		/// Gets or sets the <c>APROBACION_DPTO_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_DPTO_CREDITO</c> column value.</value>
		public string APROBACION_DPTO_CREDITO
		{
			get { return _aprobacion_dpto_credito; }
			set { _aprobacion_dpto_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROB_DPTO_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROB_DPTO_CREDITO</c> column value.</value>
		public System.DateTime FECHA_APROB_DPTO_CREDITO
		{
			get
			{
				if(IsFECHA_APROB_DPTO_CREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprob_dpto_credito;
			}
			set
			{
				_fecha_aprob_dpto_creditoNull = false;
				_fecha_aprob_dpto_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROB_DPTO_CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROB_DPTO_CREDITONull
		{
			get { return _fecha_aprob_dpto_creditoNull; }
			set { _fecha_aprob_dpto_creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_APROB_DPTO_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROB_DPTO_CREDITO</c> column value.</value>
		public decimal USUARIO_APROB_DPTO_CREDITO
		{
			get
			{
				if(IsUSUARIO_APROB_DPTO_CREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprob_dpto_credito;
			}
			set
			{
				_usuario_aprob_dpto_creditoNull = false;
				_usuario_aprob_dpto_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROB_DPTO_CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROB_DPTO_CREDITONull
		{
			get { return _usuario_aprob_dpto_creditoNull; }
			set { _usuario_aprob_dpto_creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_DPTO_PRECIOS</c> column value.
		/// </summary>
		/// <value>The <c>APROBACION_DPTO_PRECIOS</c> column value.</value>
		public string APROBACION_DPTO_PRECIOS
		{
			get { return _aprobacion_dpto_precios; }
			set { _aprobacion_dpto_precios = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROB_DPTO_PRECIOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROB_DPTO_PRECIOS</c> column value.</value>
		public System.DateTime FECHA_APROB_DPTO_PRECIOS
		{
			get
			{
				if(IsFECHA_APROB_DPTO_PRECIOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprob_dpto_precios;
			}
			set
			{
				_fecha_aprob_dpto_preciosNull = false;
				_fecha_aprob_dpto_precios = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROB_DPTO_PRECIOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROB_DPTO_PRECIOSNull
		{
			get { return _fecha_aprob_dpto_preciosNull; }
			set { _fecha_aprob_dpto_preciosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_APROB_DPTO_PRECIOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROB_DPTO_PRECIOS</c> column value.</value>
		public decimal USUARIO_APROB_DPTO_PRECIOS
		{
			get
			{
				if(IsUSUARIO_APROB_DPTO_PRECIOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprob_dpto_precios;
			}
			set
			{
				_usuario_aprob_dpto_preciosNull = false;
				_usuario_aprob_dpto_precios = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROB_DPTO_PRECIOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROB_DPTO_PRECIOSNull
		{
			get { return _usuario_aprob_dpto_preciosNull; }
			set { _usuario_aprob_dpto_preciosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_OBS_DPTO_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_OBS_DPTO_CREDITO_ID</c> column value.</value>
		public decimal TEXTO_OBS_DPTO_CREDITO_ID
		{
			get
			{
				if(IsTEXTO_OBS_DPTO_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_obs_dpto_credito_id;
			}
			set
			{
				_texto_obs_dpto_credito_idNull = false;
				_texto_obs_dpto_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_OBS_DPTO_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_OBS_DPTO_CREDITO_IDNull
		{
			get { return _texto_obs_dpto_credito_idNull; }
			set { _texto_obs_dpto_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_OBS_DPTO_PRECIOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_OBS_DPTO_PRECIOS_ID</c> column value.</value>
		public decimal TEXTO_OBS_DPTO_PRECIOS_ID
		{
			get
			{
				if(IsTEXTO_OBS_DPTO_PRECIOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_obs_dpto_precios_id;
			}
			set
			{
				_texto_obs_dpto_precios_idNull = false;
				_texto_obs_dpto_precios_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_OBS_DPTO_PRECIOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_OBS_DPTO_PRECIOS_IDNull
		{
			get { return _texto_obs_dpto_precios_idNull; }
			set { _texto_obs_dpto_precios_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREVENTA</c> column value.
		/// </summary>
		/// <value>The <c>PREVENTA</c> column value.</value>
		public string PREVENTA
		{
			get { return _preventa; }
			set { _preventa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREVENTA_ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREVENTA_ORDEN</c> column value.</value>
		public decimal PREVENTA_ORDEN
		{
			get
			{
				if(IsPREVENTA_ORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _preventa_orden;
			}
			set
			{
				_preventa_ordenNull = false;
				_preventa_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PREVENTA_ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPREVENTA_ORDENNull
		{
			get { return _preventa_ordenNull; }
			set { _preventa_ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREVENTA_FECHA_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREVENTA_FECHA_ENTREGA</c> column value.</value>
		public System.DateTime PREVENTA_FECHA_ENTREGA
		{
			get
			{
				if(IsPREVENTA_FECHA_ENTREGANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _preventa_fecha_entrega;
			}
			set
			{
				_preventa_fecha_entregaNull = false;
				_preventa_fecha_entrega = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PREVENTA_FECHA_ENTREGA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPREVENTA_FECHA_ENTREGANull
		{
			get { return _preventa_fecha_entregaNull; }
			set { _preventa_fecha_entregaNull = value; }
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
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CREDITO_APROBADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CREDITO_APROBADO</c> column value.</value>
		public decimal MONTO_CREDITO_APROBADO
		{
			get
			{
				if(IsMONTO_CREDITO_APROBADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_credito_aprobado;
			}
			set
			{
				_monto_credito_aprobadoNull = false;
				_monto_credito_aprobado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CREDITO_APROBADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CREDITO_APROBADONull
		{
			get { return _monto_credito_aprobadoNull; }
			set { _monto_credito_aprobadoNull = value; }
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
		/// Gets or sets the <c>CONTROLAR_CANT_MIN_DESC_MAX</c> column value.
		/// </summary>
		/// <value>The <c>CONTROLAR_CANT_MIN_DESC_MAX</c> column value.</value>
		public string CONTROLAR_CANT_MIN_DESC_MAX
		{
			get { return _controlar_cant_min_desc_max; }
			set { _controlar_cant_min_desc_max = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_REMISIONES</c> column value.
		/// </summary>
		/// <value>The <c>USAR_REMISIONES</c> column value.</value>
		public string USAR_REMISIONES
		{
			get { return _usar_remisiones; }
			set { _usar_remisiones = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_VENTA_ID=");
			dynStr.Append(IsSUCURSAL_VENTA_IDNull ? (object)"<NULL>" : SUCURSAL_VENTA_ID);
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
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO_INICIAL=");
			dynStr.Append(IsTOTAL_MONTO_BRUTO_INICIALNull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO_INICIAL);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO_FINAL=");
			dynStr.Append(IsTOTAL_MONTO_BRUTO_FINALNull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO_FINAL);
			dynStr.Append("@CBA@TOTAL_NETO=");
			dynStr.Append(IsTOTAL_NETONull ? (object)"<NULL>" : TOTAL_NETO);
			dynStr.Append("@CBA@TOTAL_FINAL_SUBITEMS=");
			dynStr.Append(IsTOTAL_FINAL_SUBITEMSNull ? (object)"<NULL>" : TOTAL_FINAL_SUBITEMS);
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
			dynStr.Append("@CBA@MONTO_AFECTA_LINEA_CREDITO=");
			dynStr.Append(IsMONTO_AFECTA_LINEA_CREDITONull ? (object)"<NULL>" : MONTO_AFECTA_LINEA_CREDITO);
			dynStr.Append("@CBA@COMISION_POR_VENTA=");
			dynStr.Append(COMISION_POR_VENTA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@APROBACION_DPTO_CREDITO=");
			dynStr.Append(APROBACION_DPTO_CREDITO);
			dynStr.Append("@CBA@FECHA_APROB_DPTO_CREDITO=");
			dynStr.Append(IsFECHA_APROB_DPTO_CREDITONull ? (object)"<NULL>" : FECHA_APROB_DPTO_CREDITO);
			dynStr.Append("@CBA@USUARIO_APROB_DPTO_CREDITO=");
			dynStr.Append(IsUSUARIO_APROB_DPTO_CREDITONull ? (object)"<NULL>" : USUARIO_APROB_DPTO_CREDITO);
			dynStr.Append("@CBA@APROBACION_DPTO_PRECIOS=");
			dynStr.Append(APROBACION_DPTO_PRECIOS);
			dynStr.Append("@CBA@FECHA_APROB_DPTO_PRECIOS=");
			dynStr.Append(IsFECHA_APROB_DPTO_PRECIOSNull ? (object)"<NULL>" : FECHA_APROB_DPTO_PRECIOS);
			dynStr.Append("@CBA@USUARIO_APROB_DPTO_PRECIOS=");
			dynStr.Append(IsUSUARIO_APROB_DPTO_PRECIOSNull ? (object)"<NULL>" : USUARIO_APROB_DPTO_PRECIOS);
			dynStr.Append("@CBA@TEXTO_OBS_DPTO_CREDITO_ID=");
			dynStr.Append(IsTEXTO_OBS_DPTO_CREDITO_IDNull ? (object)"<NULL>" : TEXTO_OBS_DPTO_CREDITO_ID);
			dynStr.Append("@CBA@TEXTO_OBS_DPTO_PRECIOS_ID=");
			dynStr.Append(IsTEXTO_OBS_DPTO_PRECIOS_IDNull ? (object)"<NULL>" : TEXTO_OBS_DPTO_PRECIOS_ID);
			dynStr.Append("@CBA@PREVENTA=");
			dynStr.Append(PREVENTA);
			dynStr.Append("@CBA@PREVENTA_ORDEN=");
			dynStr.Append(IsPREVENTA_ORDENNull ? (object)"<NULL>" : PREVENTA_ORDEN);
			dynStr.Append("@CBA@PREVENTA_FECHA_ENTREGA=");
			dynStr.Append(IsPREVENTA_FECHA_ENTREGANull ? (object)"<NULL>" : PREVENTA_FECHA_ENTREGA);
			dynStr.Append("@CBA@A_CONSIGNACION=");
			dynStr.Append(A_CONSIGNACION);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			dynStr.Append("@CBA@MONTO_CREDITO_APROBADO=");
			dynStr.Append(IsMONTO_CREDITO_APROBADONull ? (object)"<NULL>" : MONTO_CREDITO_APROBADO);
			dynStr.Append("@CBA@TOTAL_RECARGO_FINANCIERO=");
			dynStr.Append(TOTAL_RECARGO_FINANCIERO);
			dynStr.Append("@CBA@TOTAL_ENTREGA_INICIAL=");
			dynStr.Append(TOTAL_ENTREGA_INICIAL);
			dynStr.Append("@CBA@CONTROLAR_CANT_MIN_DESC_MAX=");
			dynStr.Append(CONTROLAR_CANT_MIN_DESC_MAX);
			dynStr.Append("@CBA@USAR_REMISIONES=");
			dynStr.Append(USAR_REMISIONES);
			return dynStr.ToString();
		}
	} // End of PEDIDOS_CLIENTERow_Base class
} // End of namespace
