// <fileinfo name="CTACTE_PERSONAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTACTE_PERSONAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _sucursal_region_id;
		private bool _sucursal_region_idNull = true;
		private string _sucursal_region_nombre;
		private string _persona_codigo;
		private string _persona_nombre_completo;
		private decimal _persona_cobrador_habitual;
		private bool _persona_cobrador_habitualNull = true;
		private string _persona_telefono1;
		private string _persona_telefono2;
		private string _persona_telefono3;
		private string _persona_telefono4;
		private string _persona_email1;
		private string _persona_email2;
		private string _persona_email3;
		private string _persona_numero_documento;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _caso_estado_id;
		private string _caso_nro_comprobante;
		private string _caso_nro_comprobante2;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_nombre;
		private System.DateTime _fecha_insercion;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private System.DateTime _fecha_postergacion;
		private bool _fecha_postergacionNull = true;
		private string _fecha_vencimiento_texto;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private string _moneda_cadena_decimales;
		private decimal _cotizacion_moneda;
		private decimal _ctacte_concepto_id;
		private string _ctacte_concepto_descripcion;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private string _ctacte_valor_nombre;
		private decimal _ctacte_pagare_doc_id;
		private bool _ctacte_pagare_doc_idNull = true;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private decimal _calendario_pagos_fc_cli_id;
		private bool _calendario_pagos_fc_cli_idNull = true;
		private decimal _calendario_pagos_cr_cli_id;
		private bool _calendario_pagos_cr_cli_idNull = true;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _credito;
		private decimal _debito;
		private decimal _saldo_debito;
		private bool _saldo_debitoNull = true;
		private decimal _monto_en_proceso;
		private bool _monto_en_procesoNull = true;
		private string _concepto;
		private decimal _ctacte_persona_relacionada_id;
		private bool _ctacte_persona_relacionada_idNull = true;
		private decimal _ctacte_pago_persona_det_id;
		private bool _ctacte_pago_persona_det_idNull = true;
		private decimal _ctacte_pago_persona_doc_id;
		private bool _ctacte_pago_persona_doc_idNull = true;
		private decimal _ctacte_pago_persona_rec_id;
		private bool _ctacte_pago_persona_rec_idNull = true;
		private decimal _aplicacion_documentos_id;
		private bool _aplicacion_documentos_idNull = true;
		private decimal _aplicacion_documentos_val_id;
		private bool _aplicacion_documentos_val_idNull = true;
		private decimal _aplicacion_documentos_rec_id;
		private bool _aplicacion_documentos_rec_idNull = true;
		private decimal _ctacte_documento_venc_id;
		private bool _ctacte_documento_venc_idNull = true;
		private string _judicial;
		private string _bloqueado;
		private decimal _cuota_numero;
		private bool _cuota_numeroNull = true;
		private decimal _cuota_total;
		private bool _cuota_totalNull = true;
		private string _cuota;
		private System.DateTime _fecha_ultimo_pago;
		private bool _fecha_ultimo_pagoNull = true;
		private string _observacion;
		private string _factura_cliente_tipo;
		private System.DateTime _factura_cliente_fecha_emision;
		private bool _factura_cliente_fecha_emisionNull = true;
		private string _factura_cliente_vendedor_nombr;
		private string _factura_cliente_vendedor_cod;
		private decimal _factura_cliente_vendedor_id;
		private bool _factura_cliente_vendedor_idNull = true;
		private string _juego_pagares_aprobado;
		private decimal _ctacte_pagare_id;
		private bool _ctacte_pagare_idNull = true;
		private decimal _retencion_aplicada;
		private bool _retencion_aplicadaNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTACTE_PERSONAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PERSONAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsSUCURSAL_REGION_IDNull != original.IsSUCURSAL_REGION_IDNull) return true;
			if (!this.IsSUCURSAL_REGION_IDNull && !original.IsSUCURSAL_REGION_IDNull)
				if (this.SUCURSAL_REGION_ID != original.SUCURSAL_REGION_ID) return true;
			if (this.SUCURSAL_REGION_NOMBRE != original.SUCURSAL_REGION_NOMBRE) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.IsPERSONA_COBRADOR_HABITUALNull != original.IsPERSONA_COBRADOR_HABITUALNull) return true;
			if (!this.IsPERSONA_COBRADOR_HABITUALNull && !original.IsPERSONA_COBRADOR_HABITUALNull)
				if (this.PERSONA_COBRADOR_HABITUAL != original.PERSONA_COBRADOR_HABITUAL) return true;
			if (this.PERSONA_TELEFONO1 != original.PERSONA_TELEFONO1) return true;
			if (this.PERSONA_TELEFONO2 != original.PERSONA_TELEFONO2) return true;
			if (this.PERSONA_TELEFONO3 != original.PERSONA_TELEFONO3) return true;
			if (this.PERSONA_TELEFONO4 != original.PERSONA_TELEFONO4) return true;
			if (this.PERSONA_EMAIL1 != original.PERSONA_EMAIL1) return true;
			if (this.PERSONA_EMAIL2 != original.PERSONA_EMAIL2) return true;
			if (this.PERSONA_EMAIL3 != original.PERSONA_EMAIL3) return true;
			if (this.PERSONA_NUMERO_DOCUMENTO != original.PERSONA_NUMERO_DOCUMENTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.CASO_NRO_COMPROBANTE2 != original.CASO_NRO_COMPROBANTE2) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_NOMBRE != original.FLUJO_NOMBRE) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_POSTERGACIONNull != original.IsFECHA_POSTERGACIONNull) return true;
			if (!this.IsFECHA_POSTERGACIONNull && !original.IsFECHA_POSTERGACIONNull)
				if (this.FECHA_POSTERGACION != original.FECHA_POSTERGACION) return true;
			if (this.FECHA_VENCIMIENTO_TEXTO != original.FECHA_VENCIMIENTO_TEXTO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CTACTE_CONCEPTO_ID != original.CTACTE_CONCEPTO_ID) return true;
			if (this.CTACTE_CONCEPTO_DESCRIPCION != original.CTACTE_CONCEPTO_DESCRIPCION) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.IsCTACTE_PAGARE_DOC_IDNull != original.IsCTACTE_PAGARE_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DOC_IDNull && !original.IsCTACTE_PAGARE_DOC_IDNull)
				if (this.CTACTE_PAGARE_DOC_ID != original.CTACTE_PAGARE_DOC_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.IsCALENDARIO_PAGOS_FC_CLI_IDNull != original.IsCALENDARIO_PAGOS_FC_CLI_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_FC_CLI_IDNull && !original.IsCALENDARIO_PAGOS_FC_CLI_IDNull)
				if (this.CALENDARIO_PAGOS_FC_CLI_ID != original.CALENDARIO_PAGOS_FC_CLI_ID) return true;
			if (this.IsCALENDARIO_PAGOS_CR_CLI_IDNull != original.IsCALENDARIO_PAGOS_CR_CLI_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_CR_CLI_IDNull && !original.IsCALENDARIO_PAGOS_CR_CLI_IDNull)
				if (this.CALENDARIO_PAGOS_CR_CLI_ID != original.CALENDARIO_PAGOS_CR_CLI_ID) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.CREDITO != original.CREDITO) return true;
			if (this.DEBITO != original.DEBITO) return true;
			if (this.IsSALDO_DEBITONull != original.IsSALDO_DEBITONull) return true;
			if (!this.IsSALDO_DEBITONull && !original.IsSALDO_DEBITONull)
				if (this.SALDO_DEBITO != original.SALDO_DEBITO) return true;
			if (this.IsMONTO_EN_PROCESONull != original.IsMONTO_EN_PROCESONull) return true;
			if (!this.IsMONTO_EN_PROCESONull && !original.IsMONTO_EN_PROCESONull)
				if (this.MONTO_EN_PROCESO != original.MONTO_EN_PROCESO) return true;
			if (this.CONCEPTO != original.CONCEPTO) return true;
			if (this.IsCTACTE_PERSONA_RELACIONADA_IDNull != original.IsCTACTE_PERSONA_RELACIONADA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_RELACIONADA_IDNull && !original.IsCTACTE_PERSONA_RELACIONADA_IDNull)
				if (this.CTACTE_PERSONA_RELACIONADA_ID != original.CTACTE_PERSONA_RELACIONADA_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DET_IDNull != original.IsCTACTE_PAGO_PERSONA_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DET_IDNull && !original.IsCTACTE_PAGO_PERSONA_DET_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DET_ID != original.CTACTE_PAGO_PERSONA_DET_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DOC_IDNull != original.IsCTACTE_PAGO_PERSONA_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DOC_IDNull && !original.IsCTACTE_PAGO_PERSONA_DOC_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DOC_ID != original.CTACTE_PAGO_PERSONA_DOC_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_REC_IDNull != original.IsCTACTE_PAGO_PERSONA_REC_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_REC_IDNull && !original.IsCTACTE_PAGO_PERSONA_REC_IDNull)
				if (this.CTACTE_PAGO_PERSONA_REC_ID != original.CTACTE_PAGO_PERSONA_REC_ID) return true;
			if (this.IsAPLICACION_DOCUMENTOS_IDNull != original.IsAPLICACION_DOCUMENTOS_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTOS_IDNull && !original.IsAPLICACION_DOCUMENTOS_IDNull)
				if (this.APLICACION_DOCUMENTOS_ID != original.APLICACION_DOCUMENTOS_ID) return true;
			if (this.IsAPLICACION_DOCUMENTOS_VAL_IDNull != original.IsAPLICACION_DOCUMENTOS_VAL_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTOS_VAL_IDNull && !original.IsAPLICACION_DOCUMENTOS_VAL_IDNull)
				if (this.APLICACION_DOCUMENTOS_VAL_ID != original.APLICACION_DOCUMENTOS_VAL_ID) return true;
			if (this.IsAPLICACION_DOCUMENTOS_REC_IDNull != original.IsAPLICACION_DOCUMENTOS_REC_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTOS_REC_IDNull && !original.IsAPLICACION_DOCUMENTOS_REC_IDNull)
				if (this.APLICACION_DOCUMENTOS_REC_ID != original.APLICACION_DOCUMENTOS_REC_ID) return true;
			if (this.IsCTACTE_DOCUMENTO_VENC_IDNull != original.IsCTACTE_DOCUMENTO_VENC_IDNull) return true;
			if (!this.IsCTACTE_DOCUMENTO_VENC_IDNull && !original.IsCTACTE_DOCUMENTO_VENC_IDNull)
				if (this.CTACTE_DOCUMENTO_VENC_ID != original.CTACTE_DOCUMENTO_VENC_ID) return true;
			if (this.JUDICIAL != original.JUDICIAL) return true;
			if (this.BLOQUEADO != original.BLOQUEADO) return true;
			if (this.IsCUOTA_NUMERONull != original.IsCUOTA_NUMERONull) return true;
			if (!this.IsCUOTA_NUMERONull && !original.IsCUOTA_NUMERONull)
				if (this.CUOTA_NUMERO != original.CUOTA_NUMERO) return true;
			if (this.IsCUOTA_TOTALNull != original.IsCUOTA_TOTALNull) return true;
			if (!this.IsCUOTA_TOTALNull && !original.IsCUOTA_TOTALNull)
				if (this.CUOTA_TOTAL != original.CUOTA_TOTAL) return true;
			if (this.CUOTA != original.CUOTA) return true;
			if (this.IsFECHA_ULTIMO_PAGONull != original.IsFECHA_ULTIMO_PAGONull) return true;
			if (!this.IsFECHA_ULTIMO_PAGONull && !original.IsFECHA_ULTIMO_PAGONull)
				if (this.FECHA_ULTIMO_PAGO != original.FECHA_ULTIMO_PAGO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FACTURA_CLIENTE_TIPO != original.FACTURA_CLIENTE_TIPO) return true;
			if (this.IsFACTURA_CLIENTE_FECHA_EMISIONNull != original.IsFACTURA_CLIENTE_FECHA_EMISIONNull) return true;
			if (!this.IsFACTURA_CLIENTE_FECHA_EMISIONNull && !original.IsFACTURA_CLIENTE_FECHA_EMISIONNull)
				if (this.FACTURA_CLIENTE_FECHA_EMISION != original.FACTURA_CLIENTE_FECHA_EMISION) return true;
			if (this.FACTURA_CLIENTE_VENDEDOR_NOMBR != original.FACTURA_CLIENTE_VENDEDOR_NOMBR) return true;
			if (this.FACTURA_CLIENTE_VENDEDOR_COD != original.FACTURA_CLIENTE_VENDEDOR_COD) return true;
			if (this.IsFACTURA_CLIENTE_VENDEDOR_IDNull != original.IsFACTURA_CLIENTE_VENDEDOR_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_VENDEDOR_IDNull && !original.IsFACTURA_CLIENTE_VENDEDOR_IDNull)
				if (this.FACTURA_CLIENTE_VENDEDOR_ID != original.FACTURA_CLIENTE_VENDEDOR_ID) return true;
			if (this.JUEGO_PAGARES_APROBADO != original.JUEGO_PAGARES_APROBADO) return true;
			if (this.IsCTACTE_PAGARE_IDNull != original.IsCTACTE_PAGARE_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_IDNull && !original.IsCTACTE_PAGARE_IDNull)
				if (this.CTACTE_PAGARE_ID != original.CTACTE_PAGARE_ID) return true;
			if (this.IsRETENCION_APLICADANull != original.IsRETENCION_APLICADANull) return true;
			if (!this.IsRETENCION_APLICADANull && !original.IsRETENCION_APLICADANull)
				if (this.RETENCION_APLICADA != original.RETENCION_APLICADA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
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
		/// Gets or sets the <c>SUCURSAL_REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_REGION_ID</c> column value.</value>
		public decimal SUCURSAL_REGION_ID
		{
			get
			{
				if(IsSUCURSAL_REGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_region_id;
			}
			set
			{
				_sucursal_region_idNull = false;
				_sucursal_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_REGION_IDNull
		{
			get { return _sucursal_region_idNull; }
			set { _sucursal_region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_REGION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_REGION_NOMBRE</c> column value.</value>
		public string SUCURSAL_REGION_NOMBRE
		{
			get { return _sucursal_region_nombre; }
			set { _sucursal_region_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_COBRADOR_HABITUAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_COBRADOR_HABITUAL</c> column value.</value>
		public decimal PERSONA_COBRADOR_HABITUAL
		{
			get
			{
				if(IsPERSONA_COBRADOR_HABITUALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_cobrador_habitual;
			}
			set
			{
				_persona_cobrador_habitualNull = false;
				_persona_cobrador_habitual = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_COBRADOR_HABITUAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_COBRADOR_HABITUALNull
		{
			get { return _persona_cobrador_habitualNull; }
			set { _persona_cobrador_habitualNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_TELEFONO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_TELEFONO1</c> column value.</value>
		public string PERSONA_TELEFONO1
		{
			get { return _persona_telefono1; }
			set { _persona_telefono1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_TELEFONO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_TELEFONO2</c> column value.</value>
		public string PERSONA_TELEFONO2
		{
			get { return _persona_telefono2; }
			set { _persona_telefono2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_TELEFONO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_TELEFONO3</c> column value.</value>
		public string PERSONA_TELEFONO3
		{
			get { return _persona_telefono3; }
			set { _persona_telefono3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_TELEFONO4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_TELEFONO4</c> column value.</value>
		public string PERSONA_TELEFONO4
		{
			get { return _persona_telefono4; }
			set { _persona_telefono4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_EMAIL1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_EMAIL1</c> column value.</value>
		public string PERSONA_EMAIL1
		{
			get { return _persona_email1; }
			set { _persona_email1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_EMAIL2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_EMAIL2</c> column value.</value>
		public string PERSONA_EMAIL2
		{
			get { return _persona_email2; }
			set { _persona_email2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_EMAIL3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_EMAIL3</c> column value.</value>
		public string PERSONA_EMAIL3
		{
			get { return _persona_email3; }
			set { _persona_email3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NUMERO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NUMERO_DOCUMENTO</c> column value.</value>
		public string PERSONA_NUMERO_DOCUMENTO
		{
			get { return _persona_numero_documento; }
			set { _persona_numero_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_NRO_COMPROBANTE
		{
			get { return _caso_nro_comprobante; }
			set { _caso_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE2</c> column value.</value>
		public string CASO_NRO_COMPROBANTE2
		{
			get { return _caso_nro_comprobante2; }
			set { _caso_nro_comprobante2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_NOMBRE</c> column value.</value>
		public string FLUJO_NOMBRE
		{
			get { return _flujo_nombre; }
			set { _flujo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get { return _fecha_insercion; }
			set { _fecha_insercion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_POSTERGACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_POSTERGACION</c> column value.</value>
		public System.DateTime FECHA_POSTERGACION
		{
			get
			{
				if(IsFECHA_POSTERGACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_postergacion;
			}
			set
			{
				_fecha_postergacionNull = false;
				_fecha_postergacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_POSTERGACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_POSTERGACIONNull
		{
			get { return _fecha_postergacionNull; }
			set { _fecha_postergacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO_TEXTO</c> column value.</value>
		public string FECHA_VENCIMIENTO_TEXTO
		{
			get { return _fecha_vencimiento_texto; }
			set { _fecha_vencimiento_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_CADENA_DECIMALES
		{
			get { return _moneda_cadena_decimales; }
			set { _moneda_cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CONCEPTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CONCEPTO_ID</c> column value.</value>
		public decimal CTACTE_CONCEPTO_ID
		{
			get { return _ctacte_concepto_id; }
			set { _ctacte_concepto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CONCEPTO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CONCEPTO_DESCRIPCION</c> column value.</value>
		public string CTACTE_CONCEPTO_DESCRIPCION
		{
			get { return _ctacte_concepto_descripcion; }
			set { _ctacte_concepto_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get
			{
				if(IsCTACTE_VALOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_valor_id;
			}
			set
			{
				_ctacte_valor_idNull = false;
				_ctacte_valor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_VALOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_VALOR_IDNull
		{
			get { return _ctacte_valor_idNull; }
			set { _ctacte_valor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_NOMBRE</c> column value.</value>
		public string CTACTE_VALOR_NOMBRE
		{
			get { return _ctacte_valor_nombre; }
			set { _ctacte_valor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_doc_id;
			}
			set
			{
				_ctacte_pagare_doc_idNull = false;
				_ctacte_pagare_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_DOC_IDNull
		{
			get { return _ctacte_pagare_doc_idNull; }
			set { _ctacte_pagare_doc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_DET_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_DET_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_det_id;
			}
			set
			{
				_ctacte_pagare_det_idNull = false;
				_ctacte_pagare_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_DET_IDNull
		{
			get { return _ctacte_pagare_det_idNull; }
			set { _ctacte_pagare_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_FC_CLI_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_FC_CLI_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_fc_cli_id;
			}
			set
			{
				_calendario_pagos_fc_cli_idNull = false;
				_calendario_pagos_fc_cli_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_FC_CLI_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_FC_CLI_IDNull
		{
			get { return _calendario_pagos_fc_cli_idNull; }
			set { _calendario_pagos_fc_cli_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_CR_CLI_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_CR_CLI_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_cr_cli_id;
			}
			set
			{
				_calendario_pagos_cr_cli_idNull = false;
				_calendario_pagos_cr_cli_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_CR_CLI_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_CR_CLI_IDNull
		{
			get { return _calendario_pagos_cr_cli_idNull; }
			set { _calendario_pagos_cr_cli_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_ID
		{
			get
			{
				if(IsORDEN_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_id;
			}
			set
			{
				_orden_pago_idNull = false;
				_orden_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_IDNull
		{
			get { return _orden_pago_idNull; }
			set { _orden_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>CREDITO</c> column value.</value>
		public decimal CREDITO
		{
			get { return _credito; }
			set { _credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBITO</c> column value.
		/// </summary>
		/// <value>The <c>DEBITO</c> column value.</value>
		public decimal DEBITO
		{
			get { return _debito; }
			set { _debito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_DEBITO</c> column value.</value>
		public decimal SALDO_DEBITO
		{
			get
			{
				if(IsSALDO_DEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_debito;
			}
			set
			{
				_saldo_debitoNull = false;
				_saldo_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_DEBITONull
		{
			get { return _saldo_debitoNull; }
			set { _saldo_debitoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_EN_PROCESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_EN_PROCESO</c> column value.</value>
		public decimal MONTO_EN_PROCESO
		{
			get
			{
				if(IsMONTO_EN_PROCESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_en_proceso;
			}
			set
			{
				_monto_en_procesoNull = false;
				_monto_en_proceso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_EN_PROCESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_EN_PROCESONull
		{
			get { return _monto_en_procesoNull; }
			set { _monto_en_procesoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCEPTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONCEPTO</c> column value.</value>
		public string CONCEPTO
		{
			get { return _concepto; }
			set { _concepto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_RELACIONADA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_RELACIONADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_relacionada_id;
			}
			set
			{
				_ctacte_persona_relacionada_idNull = false;
				_ctacte_persona_relacionada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_RELACIONADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_RELACIONADA_IDNull
		{
			get { return _ctacte_persona_relacionada_idNull; }
			set { _ctacte_persona_relacionada_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_DET_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_det_id;
			}
			set
			{
				_ctacte_pago_persona_det_idNull = false;
				_ctacte_pago_persona_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_DET_IDNull
		{
			get { return _ctacte_pago_persona_det_idNull; }
			set { _ctacte_pago_persona_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_doc_id;
			}
			set
			{
				_ctacte_pago_persona_doc_idNull = false;
				_ctacte_pago_persona_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_DOC_IDNull
		{
			get { return _ctacte_pago_persona_doc_idNull; }
			set { _ctacte_pago_persona_doc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_REC_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_REC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_rec_id;
			}
			set
			{
				_ctacte_pago_persona_rec_idNull = false;
				_ctacte_pago_persona_rec_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_REC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_REC_IDNull
		{
			get { return _ctacte_pago_persona_rec_idNull; }
			set { _ctacte_pago_persona_rec_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTOS_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTOS_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documentos_id;
			}
			set
			{
				_aplicacion_documentos_idNull = false;
				_aplicacion_documentos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTOS_IDNull
		{
			get { return _aplicacion_documentos_idNull; }
			set { _aplicacion_documentos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTOS_VAL_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTOS_VAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documentos_val_id;
			}
			set
			{
				_aplicacion_documentos_val_idNull = false;
				_aplicacion_documentos_val_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTOS_VAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTOS_VAL_IDNull
		{
			get { return _aplicacion_documentos_val_idNull; }
			set { _aplicacion_documentos_val_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTOS_REC_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTOS_REC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documentos_rec_id;
			}
			set
			{
				_aplicacion_documentos_rec_idNull = false;
				_aplicacion_documentos_rec_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTOS_REC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTOS_REC_IDNull
		{
			get { return _aplicacion_documentos_rec_idNull; }
			set { _aplicacion_documentos_rec_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</value>
		public decimal CTACTE_DOCUMENTO_VENC_ID
		{
			get
			{
				if(IsCTACTE_DOCUMENTO_VENC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_documento_venc_id;
			}
			set
			{
				_ctacte_documento_venc_idNull = false;
				_ctacte_documento_venc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_DOCUMENTO_VENC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_DOCUMENTO_VENC_IDNull
		{
			get { return _ctacte_documento_venc_idNull; }
			set { _ctacte_documento_venc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>JUDICIAL</c> column value.
		/// </summary>
		/// <value>The <c>JUDICIAL</c> column value.</value>
		public string JUDICIAL
		{
			get { return _judicial; }
			set { _judicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BLOQUEADO</c> column value.
		/// </summary>
		/// <value>The <c>BLOQUEADO</c> column value.</value>
		public string BLOQUEADO
		{
			get { return _bloqueado; }
			set { _bloqueado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_NUMERO</c> column value.</value>
		public decimal CUOTA_NUMERO
		{
			get
			{
				if(IsCUOTA_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_numero;
			}
			set
			{
				_cuota_numeroNull = false;
				_cuota_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_NUMERONull
		{
			get { return _cuota_numeroNull; }
			set { _cuota_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_TOTAL</c> column value.</value>
		public decimal CUOTA_TOTAL
		{
			get
			{
				if(IsCUOTA_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_total;
			}
			set
			{
				_cuota_totalNull = false;
				_cuota_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_TOTALNull
		{
			get { return _cuota_totalNull; }
			set { _cuota_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA</c> column value.</value>
		public string CUOTA
		{
			get { return _cuota; }
			set { _cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMO_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMO_PAGO</c> column value.</value>
		public System.DateTime FECHA_ULTIMO_PAGO
		{
			get
			{
				if(IsFECHA_ULTIMO_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultimo_pago;
			}
			set
			{
				_fecha_ultimo_pagoNull = false;
				_fecha_ultimo_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMO_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMO_PAGONull
		{
			get { return _fecha_ultimo_pagoNull; }
			set { _fecha_ultimo_pagoNull = value; }
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
		/// Gets or sets the <c>FACTURA_CLIENTE_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_TIPO</c> column value.</value>
		public string FACTURA_CLIENTE_TIPO
		{
			get { return _factura_cliente_tipo; }
			set { _factura_cliente_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_FECHA_EMISION</c> column value.</value>
		public System.DateTime FACTURA_CLIENTE_FECHA_EMISION
		{
			get
			{
				if(IsFACTURA_CLIENTE_FECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_cliente_fecha_emision;
			}
			set
			{
				_factura_cliente_fecha_emisionNull = false;
				_factura_cliente_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CLIENTE_FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CLIENTE_FECHA_EMISIONNull
		{
			get { return _factura_cliente_fecha_emisionNull; }
			set { _factura_cliente_fecha_emisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_VENDEDOR_NOMBR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_VENDEDOR_NOMBR</c> column value.</value>
		public string FACTURA_CLIENTE_VENDEDOR_NOMBR
		{
			get { return _factura_cliente_vendedor_nombr; }
			set { _factura_cliente_vendedor_nombr = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_VENDEDOR_COD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_VENDEDOR_COD</c> column value.</value>
		public string FACTURA_CLIENTE_VENDEDOR_COD
		{
			get { return _factura_cliente_vendedor_cod; }
			set { _factura_cliente_vendedor_cod = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_VENDEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_VENDEDOR_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_VENDEDOR_ID
		{
			get
			{
				if(IsFACTURA_CLIENTE_VENDEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_cliente_vendedor_id;
			}
			set
			{
				_factura_cliente_vendedor_idNull = false;
				_factura_cliente_vendedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CLIENTE_VENDEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CLIENTE_VENDEDOR_IDNull
		{
			get { return _factura_cliente_vendedor_idNull; }
			set { _factura_cliente_vendedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>JUEGO_PAGARES_APROBADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>JUEGO_PAGARES_APROBADO</c> column value.</value>
		public string JUEGO_PAGARES_APROBADO
		{
			get { return _juego_pagares_aprobado; }
			set { _juego_pagares_aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_id;
			}
			set
			{
				_ctacte_pagare_idNull = false;
				_ctacte_pagare_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_IDNull
		{
			get { return _ctacte_pagare_idNull; }
			set { _ctacte_pagare_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_APLICADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_APLICADA</c> column value.</value>
		public decimal RETENCION_APLICADA
		{
			get
			{
				if(IsRETENCION_APLICADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_aplicada;
			}
			set
			{
				_retencion_aplicadaNull = false;
				_retencion_aplicada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_APLICADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_APLICADANull
		{
			get { return _retencion_aplicadaNull; }
			set { _retencion_aplicadaNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_REGION_ID=");
			dynStr.Append(IsSUCURSAL_REGION_IDNull ? (object)"<NULL>" : SUCURSAL_REGION_ID);
			dynStr.Append("@CBA@SUCURSAL_REGION_NOMBRE=");
			dynStr.Append(SUCURSAL_REGION_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_COBRADOR_HABITUAL=");
			dynStr.Append(IsPERSONA_COBRADOR_HABITUALNull ? (object)"<NULL>" : PERSONA_COBRADOR_HABITUAL);
			dynStr.Append("@CBA@PERSONA_TELEFONO1=");
			dynStr.Append(PERSONA_TELEFONO1);
			dynStr.Append("@CBA@PERSONA_TELEFONO2=");
			dynStr.Append(PERSONA_TELEFONO2);
			dynStr.Append("@CBA@PERSONA_TELEFONO3=");
			dynStr.Append(PERSONA_TELEFONO3);
			dynStr.Append("@CBA@PERSONA_TELEFONO4=");
			dynStr.Append(PERSONA_TELEFONO4);
			dynStr.Append("@CBA@PERSONA_EMAIL1=");
			dynStr.Append(PERSONA_EMAIL1);
			dynStr.Append("@CBA@PERSONA_EMAIL2=");
			dynStr.Append(PERSONA_EMAIL2);
			dynStr.Append("@CBA@PERSONA_EMAIL3=");
			dynStr.Append(PERSONA_EMAIL3);
			dynStr.Append("@CBA@PERSONA_NUMERO_DOCUMENTO=");
			dynStr.Append(PERSONA_NUMERO_DOCUMENTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE2=");
			dynStr.Append(CASO_NRO_COMPROBANTE2);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_NOMBRE=");
			dynStr.Append(FLUJO_NOMBRE);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_POSTERGACION=");
			dynStr.Append(IsFECHA_POSTERGACIONNull ? (object)"<NULL>" : FECHA_POSTERGACION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_TEXTO=");
			dynStr.Append(FECHA_VENCIMIENTO_TEXTO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_ID=");
			dynStr.Append(CTACTE_CONCEPTO_ID);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_DESCRIPCION=");
			dynStr.Append(CTACTE_CONCEPTO_DESCRIPCION);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@CTACTE_PAGARE_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_FC_CLI_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_FC_CLI_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_FC_CLI_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_CR_CLI_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_CR_CLI_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_CR_CLI_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(DEBITO);
			dynStr.Append("@CBA@SALDO_DEBITO=");
			dynStr.Append(IsSALDO_DEBITONull ? (object)"<NULL>" : SALDO_DEBITO);
			dynStr.Append("@CBA@MONTO_EN_PROCESO=");
			dynStr.Append(IsMONTO_EN_PROCESONull ? (object)"<NULL>" : MONTO_EN_PROCESO);
			dynStr.Append("@CBA@CONCEPTO=");
			dynStr.Append(CONCEPTO);
			dynStr.Append("@CBA@CTACTE_PERSONA_RELACIONADA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_RELACIONADA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_RELACIONADA_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DET_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DET_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_REC_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_REC_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_REC_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTOS_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTOS_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTOS_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTOS_VAL_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTOS_VAL_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTOS_VAL_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTOS_REC_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTOS_REC_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTOS_REC_ID);
			dynStr.Append("@CBA@CTACTE_DOCUMENTO_VENC_ID=");
			dynStr.Append(IsCTACTE_DOCUMENTO_VENC_IDNull ? (object)"<NULL>" : CTACTE_DOCUMENTO_VENC_ID);
			dynStr.Append("@CBA@JUDICIAL=");
			dynStr.Append(JUDICIAL);
			dynStr.Append("@CBA@BLOQUEADO=");
			dynStr.Append(BLOQUEADO);
			dynStr.Append("@CBA@CUOTA_NUMERO=");
			dynStr.Append(IsCUOTA_NUMERONull ? (object)"<NULL>" : CUOTA_NUMERO);
			dynStr.Append("@CBA@CUOTA_TOTAL=");
			dynStr.Append(IsCUOTA_TOTALNull ? (object)"<NULL>" : CUOTA_TOTAL);
			dynStr.Append("@CBA@CUOTA=");
			dynStr.Append(CUOTA);
			dynStr.Append("@CBA@FECHA_ULTIMO_PAGO=");
			dynStr.Append(IsFECHA_ULTIMO_PAGONull ? (object)"<NULL>" : FECHA_ULTIMO_PAGO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FACTURA_CLIENTE_TIPO=");
			dynStr.Append(FACTURA_CLIENTE_TIPO);
			dynStr.Append("@CBA@FACTURA_CLIENTE_FECHA_EMISION=");
			dynStr.Append(IsFACTURA_CLIENTE_FECHA_EMISIONNull ? (object)"<NULL>" : FACTURA_CLIENTE_FECHA_EMISION);
			dynStr.Append("@CBA@FACTURA_CLIENTE_VENDEDOR_NOMBR=");
			dynStr.Append(FACTURA_CLIENTE_VENDEDOR_NOMBR);
			dynStr.Append("@CBA@FACTURA_CLIENTE_VENDEDOR_COD=");
			dynStr.Append(FACTURA_CLIENTE_VENDEDOR_COD);
			dynStr.Append("@CBA@FACTURA_CLIENTE_VENDEDOR_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_VENDEDOR_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_VENDEDOR_ID);
			dynStr.Append("@CBA@JUEGO_PAGARES_APROBADO=");
			dynStr.Append(JUEGO_PAGARES_APROBADO);
			dynStr.Append("@CBA@CTACTE_PAGARE_ID=");
			dynStr.Append(IsCTACTE_PAGARE_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_ID);
			dynStr.Append("@CBA@RETENCION_APLICADA=");
			dynStr.Append(IsRETENCION_APLICADANull ? (object)"<NULL>" : RETENCION_APLICADA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PERSONAS_INFO_COMPLETARow_Base class
} // End of namespace
