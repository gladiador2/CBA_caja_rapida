// <fileinfo name="FACTURAS_PROVEEDOR_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> that 
	/// represents a record in the <c>FACTURAS_PROVEEDOR_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROVEEDOR_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _pagar_por_fondo_fijo;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private string _caso_estado_id;
		private decimal _proveedor_id;
		private string _proveedor_nombre;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _stock_deposito_id;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private decimal _rubro_id;
		private bool _rubro_idNull = true;
		private string _rubro_nombre;
		private string _stock_deposito_nombre;
		private string _stock_deposito_abreviatura;
		private System.DateTime _fecha;
		private System.DateTime _fecha_factura;
		private bool _fecha_facturaNull = true;
		private System.DateTime _fecha_recepcion;
		private bool _fecha_recepcionNull = true;
		private System.DateTime _fecha_vencimiento_timbrado;
		private string _nro_comprobante;
		private string _numero_contrato;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cotizacion;
		private decimal _moneda_pais_cotizacion;
		private decimal _ctacte_condicion_pago_id;
		private string _ctacte_condicion_pago_nombre;
		private decimal _estado_documentacion_id;
		private bool _estado_documentacion_idNull = true;
		private string _estado_documentacion_nombre;
		private decimal _tipo_contenedor_id;
		private bool _tipo_contenedor_idNull = true;
		private string _tipo_contenedor_nombre;
		private decimal _cantidad_contenedores;
		private bool _cantidad_contenedoresNull = true;
		private decimal _tipo_embarque_id;
		private bool _tipo_embarque_idNull = true;
		private string _tipo_embarque_nombre;
		private decimal _total_bruto;
		private bool _total_brutoNull = true;
		private decimal _total_descuento;
		private bool _total_descuentoNull = true;
		private decimal _total_impuesto;
		private bool _total_impuestoNull = true;
		private decimal _total_pago;
		private bool _total_pagoNull = true;
		private decimal _importacion_id;
		private bool _importacion_idNull = true;
		private string _pasible_retencion;
		private string _observacion;
		private decimal _entidad_id;
		private string _nro_timbrado;
		private decimal _tipo_factura_proveedor_id;
		private string _tipo_factura_proveedor_nombre;
		private string _afecta_ctacte_proveedor;
		private string _afecta_ctacte_persona;
		private string _afecta_cred_fiscal_empresa;
		private string _afecta_cred_fiscal_persona;
		private decimal _porc_pror_import;
		private bool _porc_pror_importNull = true;
		private string _nro_documento_externo;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _porcentaje_desc_sobre_total;
		private string _es_ticket;
		private decimal _proveedor_gasto_id;
		private bool _proveedor_gasto_idNull = true;
		private string _proveedor_gasto_nombre;
		private string _direccion_lugar_transaccion;
		private decimal _egreso_vario_caja_autonum_id;
		private bool _egreso_vario_caja_autonum_idNull = true;
		private string _egreso_vario_caja_nro_compr;
		private string _centro_costo_obligatorio;
		private System.DateTime _egreso_vario_caja_fecha;
		private bool _egreso_vario_caja_fechaNull = true;
		private decimal _orden_pago_ctacte_bancaria_id;
		private bool _orden_pago_ctacte_bancaria_idNull = true;
		private string _aplicar_prorrateo_servicios;
		private decimal _pago_contratista_detalle_id;
		private bool _pago_contratista_detalle_idNull = true;
		private string _es_fact_electronica;
		private string _tipo_movimiento_set;
		private decimal _ctb_tipo_comprobante_set_id;
		private bool _ctb_tipo_comprobante_set_idNull = true;
		private string _imputa_iva;
		private string _imputa_ire;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow_Base"/> class.
		/// </summary>
		public FACTURAS_PROVEEDOR_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_PROVEEDOR_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.PAGAR_POR_FONDO_FIJO != original.PAGAR_POR_FONDO_FIJO) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.STOCK_DEPOSITO_ID != original.STOCK_DEPOSITO_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.IsRUBRO_IDNull != original.IsRUBRO_IDNull) return true;
			if (!this.IsRUBRO_IDNull && !original.IsRUBRO_IDNull)
				if (this.RUBRO_ID != original.RUBRO_ID) return true;
			if (this.RUBRO_NOMBRE != original.RUBRO_NOMBRE) return true;
			if (this.STOCK_DEPOSITO_NOMBRE != original.STOCK_DEPOSITO_NOMBRE) return true;
			if (this.STOCK_DEPOSITO_ABREVIATURA != original.STOCK_DEPOSITO_ABREVIATURA) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsFECHA_FACTURANull != original.IsFECHA_FACTURANull) return true;
			if (!this.IsFECHA_FACTURANull && !original.IsFECHA_FACTURANull)
				if (this.FECHA_FACTURA != original.FECHA_FACTURA) return true;
			if (this.IsFECHA_RECEPCIONNull != original.IsFECHA_RECEPCIONNull) return true;
			if (!this.IsFECHA_RECEPCIONNull && !original.IsFECHA_RECEPCIONNull)
				if (this.FECHA_RECEPCION != original.FECHA_RECEPCION) return true;
			if (this.FECHA_VENCIMIENTO_TIMBRADO != original.FECHA_VENCIMIENTO_TIMBRADO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.NUMERO_CONTRATO != original.NUMERO_CONTRATO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_COTIZACION != original.MONEDA_COTIZACION) return true;
			if (this.MONEDA_PAIS_COTIZACION != original.MONEDA_PAIS_COTIZACION) return true;
			if (this.CTACTE_CONDICION_PAGO_ID != original.CTACTE_CONDICION_PAGO_ID) return true;
			if (this.CTACTE_CONDICION_PAGO_NOMBRE != original.CTACTE_CONDICION_PAGO_NOMBRE) return true;
			if (this.IsESTADO_DOCUMENTACION_IDNull != original.IsESTADO_DOCUMENTACION_IDNull) return true;
			if (!this.IsESTADO_DOCUMENTACION_IDNull && !original.IsESTADO_DOCUMENTACION_IDNull)
				if (this.ESTADO_DOCUMENTACION_ID != original.ESTADO_DOCUMENTACION_ID) return true;
			if (this.ESTADO_DOCUMENTACION_NOMBRE != original.ESTADO_DOCUMENTACION_NOMBRE) return true;
			if (this.IsTIPO_CONTENEDOR_IDNull != original.IsTIPO_CONTENEDOR_IDNull) return true;
			if (!this.IsTIPO_CONTENEDOR_IDNull && !original.IsTIPO_CONTENEDOR_IDNull)
				if (this.TIPO_CONTENEDOR_ID != original.TIPO_CONTENEDOR_ID) return true;
			if (this.TIPO_CONTENEDOR_NOMBRE != original.TIPO_CONTENEDOR_NOMBRE) return true;
			if (this.IsCANTIDAD_CONTENEDORESNull != original.IsCANTIDAD_CONTENEDORESNull) return true;
			if (!this.IsCANTIDAD_CONTENEDORESNull && !original.IsCANTIDAD_CONTENEDORESNull)
				if (this.CANTIDAD_CONTENEDORES != original.CANTIDAD_CONTENEDORES) return true;
			if (this.IsTIPO_EMBARQUE_IDNull != original.IsTIPO_EMBARQUE_IDNull) return true;
			if (!this.IsTIPO_EMBARQUE_IDNull && !original.IsTIPO_EMBARQUE_IDNull)
				if (this.TIPO_EMBARQUE_ID != original.TIPO_EMBARQUE_ID) return true;
			if (this.TIPO_EMBARQUE_NOMBRE != original.TIPO_EMBARQUE_NOMBRE) return true;
			if (this.IsTOTAL_BRUTONull != original.IsTOTAL_BRUTONull) return true;
			if (!this.IsTOTAL_BRUTONull && !original.IsTOTAL_BRUTONull)
				if (this.TOTAL_BRUTO != original.TOTAL_BRUTO) return true;
			if (this.IsTOTAL_DESCUENTONull != original.IsTOTAL_DESCUENTONull) return true;
			if (!this.IsTOTAL_DESCUENTONull && !original.IsTOTAL_DESCUENTONull)
				if (this.TOTAL_DESCUENTO != original.TOTAL_DESCUENTO) return true;
			if (this.IsTOTAL_IMPUESTONull != original.IsTOTAL_IMPUESTONull) return true;
			if (!this.IsTOTAL_IMPUESTONull && !original.IsTOTAL_IMPUESTONull)
				if (this.TOTAL_IMPUESTO != original.TOTAL_IMPUESTO) return true;
			if (this.IsTOTAL_PAGONull != original.IsTOTAL_PAGONull) return true;
			if (!this.IsTOTAL_PAGONull && !original.IsTOTAL_PAGONull)
				if (this.TOTAL_PAGO != original.TOTAL_PAGO) return true;
			if (this.IsIMPORTACION_IDNull != original.IsIMPORTACION_IDNull) return true;
			if (!this.IsIMPORTACION_IDNull && !original.IsIMPORTACION_IDNull)
				if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.PASIBLE_RETENCION != original.PASIBLE_RETENCION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.NRO_TIMBRADO != original.NRO_TIMBRADO) return true;
			if (this.TIPO_FACTURA_PROVEEDOR_ID != original.TIPO_FACTURA_PROVEEDOR_ID) return true;
			if (this.TIPO_FACTURA_PROVEEDOR_NOMBRE != original.TIPO_FACTURA_PROVEEDOR_NOMBRE) return true;
			if (this.AFECTA_CTACTE_PROVEEDOR != original.AFECTA_CTACTE_PROVEEDOR) return true;
			if (this.AFECTA_CTACTE_PERSONA != original.AFECTA_CTACTE_PERSONA) return true;
			if (this.AFECTA_CRED_FISCAL_EMPRESA != original.AFECTA_CRED_FISCAL_EMPRESA) return true;
			if (this.AFECTA_CRED_FISCAL_PERSONA != original.AFECTA_CRED_FISCAL_PERSONA) return true;
			if (this.IsPORC_PROR_IMPORTNull != original.IsPORC_PROR_IMPORTNull) return true;
			if (!this.IsPORC_PROR_IMPORTNull && !original.IsPORC_PROR_IMPORTNull)
				if (this.PORC_PROR_IMPORT != original.PORC_PROR_IMPORT) return true;
			if (this.NRO_DOCUMENTO_EXTERNO != original.NRO_DOCUMENTO_EXTERNO) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.PORCENTAJE_DESC_SOBRE_TOTAL != original.PORCENTAJE_DESC_SOBRE_TOTAL) return true;
			if (this.ES_TICKET != original.ES_TICKET) return true;
			if (this.IsPROVEEDOR_GASTO_IDNull != original.IsPROVEEDOR_GASTO_IDNull) return true;
			if (!this.IsPROVEEDOR_GASTO_IDNull && !original.IsPROVEEDOR_GASTO_IDNull)
				if (this.PROVEEDOR_GASTO_ID != original.PROVEEDOR_GASTO_ID) return true;
			if (this.PROVEEDOR_GASTO_NOMBRE != original.PROVEEDOR_GASTO_NOMBRE) return true;
			if (this.DIRECCION_LUGAR_TRANSACCION != original.DIRECCION_LUGAR_TRANSACCION) return true;
			if (this.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull != original.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull && !original.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull)
				if (this.EGRESO_VARIO_CAJA_AUTONUM_ID != original.EGRESO_VARIO_CAJA_AUTONUM_ID) return true;
			if (this.EGRESO_VARIO_CAJA_NRO_COMPR != original.EGRESO_VARIO_CAJA_NRO_COMPR) return true;
			if (this.CENTRO_COSTO_OBLIGATORIO != original.CENTRO_COSTO_OBLIGATORIO) return true;
			if (this.IsEGRESO_VARIO_CAJA_FECHANull != original.IsEGRESO_VARIO_CAJA_FECHANull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_FECHANull && !original.IsEGRESO_VARIO_CAJA_FECHANull)
				if (this.EGRESO_VARIO_CAJA_FECHA != original.EGRESO_VARIO_CAJA_FECHA) return true;
			if (this.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull != original.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull) return true;
			if (!this.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull && !original.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull)
				if (this.ORDEN_PAGO_CTACTE_BANCARIA_ID != original.ORDEN_PAGO_CTACTE_BANCARIA_ID) return true;
			if (this.APLICAR_PRORRATEO_SERVICIOS != original.APLICAR_PRORRATEO_SERVICIOS) return true;
			if (this.IsPAGO_CONTRATISTA_DETALLE_IDNull != original.IsPAGO_CONTRATISTA_DETALLE_IDNull) return true;
			if (!this.IsPAGO_CONTRATISTA_DETALLE_IDNull && !original.IsPAGO_CONTRATISTA_DETALLE_IDNull)
				if (this.PAGO_CONTRATISTA_DETALLE_ID != original.PAGO_CONTRATISTA_DETALLE_ID) return true;
			if (this.ES_FACT_ELECTRONICA != original.ES_FACT_ELECTRONICA) return true;
			if (this.TIPO_MOVIMIENTO_SET != original.TIPO_MOVIMIENTO_SET) return true;
			if (this.IsCTB_TIPO_COMPROBANTE_SET_IDNull != original.IsCTB_TIPO_COMPROBANTE_SET_IDNull) return true;
			if (!this.IsCTB_TIPO_COMPROBANTE_SET_IDNull && !original.IsCTB_TIPO_COMPROBANTE_SET_IDNull)
				if (this.CTB_TIPO_COMPROBANTE_SET_ID != original.CTB_TIPO_COMPROBANTE_SET_ID) return true;
			if (this.IMPUTA_IVA != original.IMPUTA_IVA) return true;
			if (this.IMPUTA_IRE != original.IMPUTA_IRE) return true;
			
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
		/// Gets or sets the <c>PAGAR_POR_FONDO_FIJO</c> column value.
		/// </summary>
		/// <value>The <c>PAGAR_POR_FONDO_FIJO</c> column value.</value>
		public string PAGAR_POR_FONDO_FIJO
		{
			get { return _pagar_por_fondo_fijo; }
			set { _pagar_por_fondo_fijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_id;
			}
			set
			{
				_ctacte_fondo_fijo_idNull = false;
				_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_IDNull
		{
			get { return _ctacte_fondo_fijo_idNull; }
			set { _ctacte_fondo_fijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_NOMBRE</c> column value.</value>
		public string PROVEEDOR_NOMBRE
		{
			get { return _proveedor_nombre; }
			set { _proveedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_ID</c> column value.</value>
		public decimal STOCK_DEPOSITO_ID
		{
			get { return _stock_deposito_id; }
			set { _stock_deposito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
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
		/// Gets or sets the <c>RUBRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUBRO_ID</c> column value.</value>
		public decimal RUBRO_ID
		{
			get
			{
				if(IsRUBRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rubro_id;
			}
			set
			{
				_rubro_idNull = false;
				_rubro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RUBRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRUBRO_IDNull
		{
			get { return _rubro_idNull; }
			set { _rubro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUBRO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUBRO_NOMBRE</c> column value.</value>
		public string RUBRO_NOMBRE
		{
			get { return _rubro_nombre; }
			set { _rubro_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_NOMBRE</c> column value.</value>
		public string STOCK_DEPOSITO_NOMBRE
		{
			get { return _stock_deposito_nombre; }
			set { _stock_deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_ABREVIATURA</c> column value.</value>
		public string STOCK_DEPOSITO_ABREVIATURA
		{
			get { return _stock_deposito_abreviatura; }
			set { _stock_deposito_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FACTURA</c> column value.</value>
		public System.DateTime FECHA_FACTURA
		{
			get
			{
				if(IsFECHA_FACTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_factura;
			}
			set
			{
				_fecha_facturaNull = false;
				_fecha_factura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FACTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FACTURANull
		{
			get { return _fecha_facturaNull; }
			set { _fecha_facturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECEPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RECEPCION</c> column value.</value>
		public System.DateTime FECHA_RECEPCION
		{
			get
			{
				if(IsFECHA_RECEPCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_recepcion;
			}
			set
			{
				_fecha_recepcionNull = false;
				_fecha_recepcion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RECEPCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RECEPCIONNull
		{
			get { return _fecha_recepcionNull; }
			set { _fecha_recepcionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO_TIMBRADO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO_TIMBRADO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO_TIMBRADO
		{
			get { return _fecha_vencimiento_timbrado; }
			set { _fecha_vencimiento_timbrado = value; }
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
		/// Gets or sets the <c>NUMERO_CONTRATO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CONTRATO</c> column value.</value>
		public string NUMERO_CONTRATO
		{
			get { return _numero_contrato; }
			set { _numero_contrato = value; }
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
		/// Gets or sets the <c>MONEDA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_COTIZACION</c> column value.</value>
		public decimal MONEDA_COTIZACION
		{
			get { return _moneda_cotizacion; }
			set { _moneda_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PAIS_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_PAIS_COTIZACION</c> column value.</value>
		public decimal MONEDA_PAIS_COTIZACION
		{
			get { return _moneda_pais_cotizacion; }
			set { _moneda_pais_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CONDICION_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</value>
		public decimal CTACTE_CONDICION_PAGO_ID
		{
			get { return _ctacte_condicion_pago_id; }
			set { _ctacte_condicion_pago_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CONDICION_PAGO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CONDICION_PAGO_NOMBRE</c> column value.</value>
		public string CTACTE_CONDICION_PAGO_NOMBRE
		{
			get { return _ctacte_condicion_pago_nombre; }
			set { _ctacte_condicion_pago_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DOCUMENTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DOCUMENTACION_ID</c> column value.</value>
		public decimal ESTADO_DOCUMENTACION_ID
		{
			get
			{
				if(IsESTADO_DOCUMENTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estado_documentacion_id;
			}
			set
			{
				_estado_documentacion_idNull = false;
				_estado_documentacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTADO_DOCUMENTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTADO_DOCUMENTACION_IDNull
		{
			get { return _estado_documentacion_idNull; }
			set { _estado_documentacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DOCUMENTACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DOCUMENTACION_NOMBRE</c> column value.</value>
		public string ESTADO_DOCUMENTACION_NOMBRE
		{
			get { return _estado_documentacion_nombre; }
			set { _estado_documentacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_ID</c> column value.</value>
		public decimal TIPO_CONTENEDOR_ID
		{
			get
			{
				if(IsTIPO_CONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_contenedor_id;
			}
			set
			{
				_tipo_contenedor_idNull = false;
				_tipo_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CONTENEDOR_IDNull
		{
			get { return _tipo_contenedor_idNull; }
			set { _tipo_contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_NOMBRE</c> column value.</value>
		public string TIPO_CONTENEDOR_NOMBRE
		{
			get { return _tipo_contenedor_nombre; }
			set { _tipo_contenedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CONTENEDORES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_CONTENEDORES</c> column value.</value>
		public decimal CANTIDAD_CONTENEDORES
		{
			get
			{
				if(IsCANTIDAD_CONTENEDORESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_contenedores;
			}
			set
			{
				_cantidad_contenedoresNull = false;
				_cantidad_contenedores = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_CONTENEDORES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_CONTENEDORESNull
		{
			get { return _cantidad_contenedoresNull; }
			set { _cantidad_contenedoresNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EMBARQUE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EMBARQUE_ID</c> column value.</value>
		public decimal TIPO_EMBARQUE_ID
		{
			get
			{
				if(IsTIPO_EMBARQUE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_embarque_id;
			}
			set
			{
				_tipo_embarque_idNull = false;
				_tipo_embarque_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_EMBARQUE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_EMBARQUE_IDNull
		{
			get { return _tipo_embarque_idNull; }
			set { _tipo_embarque_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EMBARQUE_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EMBARQUE_NOMBRE</c> column value.</value>
		public string TIPO_EMBARQUE_NOMBRE
		{
			get { return _tipo_embarque_nombre; }
			set { _tipo_embarque_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_BRUTO</c> column value.</value>
		public decimal TOTAL_BRUTO
		{
			get
			{
				if(IsTOTAL_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_bruto;
			}
			set
			{
				_total_brutoNull = false;
				_total_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_BRUTONull
		{
			get { return _total_brutoNull; }
			set { _total_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DESCUENTO</c> column value.</value>
		public decimal TOTAL_DESCUENTO
		{
			get
			{
				if(IsTOTAL_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_descuento;
			}
			set
			{
				_total_descuentoNull = false;
				_total_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DESCUENTONull
		{
			get { return _total_descuentoNull; }
			set { _total_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO</c> column value.</value>
		public decimal TOTAL_IMPUESTO
		{
			get
			{
				if(IsTOTAL_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto;
			}
			set
			{
				_total_impuestoNull = false;
				_total_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTONull
		{
			get { return _total_impuestoNull; }
			set { _total_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_PAGO</c> column value.</value>
		public decimal TOTAL_PAGO
		{
			get
			{
				if(IsTOTAL_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_pago;
			}
			set
			{
				_total_pagoNull = false;
				_total_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_PAGONull
		{
			get { return _total_pagoNull; }
			set { _total_pagoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get
			{
				if(IsIMPORTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_id;
			}
			set
			{
				_importacion_idNull = false;
				_importacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_IDNull
		{
			get { return _importacion_idNull; }
			set { _importacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASIBLE_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>PASIBLE_RETENCION</c> column value.</value>
		public string PASIBLE_RETENCION
		{
			get { return _pasible_retencion; }
			set { _pasible_retencion = value; }
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_TIMBRADO</c> column value.</value>
		public string NRO_TIMBRADO
		{
			get { return _nro_timbrado; }
			set { _nro_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal TIPO_FACTURA_PROVEEDOR_ID
		{
			get { return _tipo_factura_proveedor_id; }
			set { _tipo_factura_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_FACTURA_PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_FACTURA_PROVEEDOR_NOMBRE</c> column value.</value>
		public string TIPO_FACTURA_PROVEEDOR_NOMBRE
		{
			get { return _tipo_factura_proveedor_nombre; }
			set { _tipo_factura_proveedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CTACTE_PROVEEDOR</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CTACTE_PROVEEDOR</c> column value.</value>
		public string AFECTA_CTACTE_PROVEEDOR
		{
			get { return _afecta_ctacte_proveedor; }
			set { _afecta_ctacte_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CTACTE_PERSONA</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CTACTE_PERSONA</c> column value.</value>
		public string AFECTA_CTACTE_PERSONA
		{
			get { return _afecta_ctacte_persona; }
			set { _afecta_ctacte_persona = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CRED_FISCAL_EMPRESA</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CRED_FISCAL_EMPRESA</c> column value.</value>
		public string AFECTA_CRED_FISCAL_EMPRESA
		{
			get { return _afecta_cred_fiscal_empresa; }
			set { _afecta_cred_fiscal_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_CRED_FISCAL_PERSONA</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_CRED_FISCAL_PERSONA</c> column value.</value>
		public string AFECTA_CRED_FISCAL_PERSONA
		{
			get { return _afecta_cred_fiscal_persona; }
			set { _afecta_cred_fiscal_persona = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORC_PROR_IMPORT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORC_PROR_IMPORT</c> column value.</value>
		public decimal PORC_PROR_IMPORT
		{
			get
			{
				if(IsPORC_PROR_IMPORTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porc_pror_import;
			}
			set
			{
				_porc_pror_importNull = false;
				_porc_pror_import = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORC_PROR_IMPORT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORC_PROR_IMPORTNull
		{
			get { return _porc_pror_importNull; }
			set { _porc_pror_importNull = value; }
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
		/// Gets or sets the <c>CASO_ASOCIADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_ID</c> column value.</value>
		public decimal CASO_ASOCIADO_ID
		{
			get
			{
				if(IsCASO_ASOCIADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_asociado_id;
			}
			set
			{
				_caso_asociado_idNull = false;
				_caso_asociado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ASOCIADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ASOCIADO_IDNull
		{
			get { return _caso_asociado_idNull; }
			set { _caso_asociado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DESC_SOBRE_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DESC_SOBRE_TOTAL</c> column value.</value>
		public decimal PORCENTAJE_DESC_SOBRE_TOTAL
		{
			get { return _porcentaje_desc_sobre_total; }
			set { _porcentaje_desc_sobre_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_TICKET</c> column value.
		/// </summary>
		/// <value>The <c>ES_TICKET</c> column value.</value>
		public string ES_TICKET
		{
			get { return _es_ticket; }
			set { _es_ticket = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_GASTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_GASTO_ID</c> column value.</value>
		public decimal PROVEEDOR_GASTO_ID
		{
			get
			{
				if(IsPROVEEDOR_GASTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_gasto_id;
			}
			set
			{
				_proveedor_gasto_idNull = false;
				_proveedor_gasto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_GASTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_GASTO_IDNull
		{
			get { return _proveedor_gasto_idNull; }
			set { _proveedor_gasto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_GASTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_GASTO_NOMBRE</c> column value.</value>
		public string PROVEEDOR_GASTO_NOMBRE
		{
			get { return _proveedor_gasto_nombre; }
			set { _proveedor_gasto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION_LUGAR_TRANSACCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION_LUGAR_TRANSACCION</c> column value.</value>
		public string DIRECCION_LUGAR_TRANSACCION
		{
			get { return _direccion_lugar_transaccion; }
			set { _direccion_lugar_transaccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</value>
		public decimal EGRESO_VARIO_CAJA_AUTONUM_ID
		{
			get
			{
				if(IsEGRESO_VARIO_CAJA_AUTONUM_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_vario_caja_autonum_id;
			}
			set
			{
				_egreso_vario_caja_autonum_idNull = false;
				_egreso_vario_caja_autonum_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_VARIO_CAJA_AUTONUM_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_VARIO_CAJA_AUTONUM_IDNull
		{
			get { return _egreso_vario_caja_autonum_idNull; }
			set { _egreso_vario_caja_autonum_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_NRO_COMPR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_NRO_COMPR</c> column value.</value>
		public string EGRESO_VARIO_CAJA_NRO_COMPR
		{
			get { return _egreso_vario_caja_nro_compr; }
			set { _egreso_vario_caja_nro_compr = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_OBLIGATORIO</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_OBLIGATORIO</c> column value.</value>
		public string CENTRO_COSTO_OBLIGATORIO
		{
			get { return _centro_costo_obligatorio; }
			set { _centro_costo_obligatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_FECHA</c> column value.</value>
		public System.DateTime EGRESO_VARIO_CAJA_FECHA
		{
			get
			{
				if(IsEGRESO_VARIO_CAJA_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_vario_caja_fecha;
			}
			set
			{
				_egreso_vario_caja_fechaNull = false;
				_egreso_vario_caja_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_VARIO_CAJA_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_VARIO_CAJA_FECHANull
		{
			get { return _egreso_vario_caja_fechaNull; }
			set { _egreso_vario_caja_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal ORDEN_PAGO_CTACTE_BANCARIA_ID
		{
			get
			{
				if(IsORDEN_PAGO_CTACTE_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_ctacte_bancaria_id;
			}
			set
			{
				_orden_pago_ctacte_bancaria_idNull = false;
				_orden_pago_ctacte_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_CTACTE_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_CTACTE_BANCARIA_IDNull
		{
			get { return _orden_pago_ctacte_bancaria_idNull; }
			set { _orden_pago_ctacte_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICAR_PRORRATEO_SERVICIOS</c> column value.
		/// </summary>
		/// <value>The <c>APLICAR_PRORRATEO_SERVICIOS</c> column value.</value>
		public string APLICAR_PRORRATEO_SERVICIOS
		{
			get { return _aplicar_prorrateo_servicios; }
			set { _aplicar_prorrateo_servicios = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</value>
		public decimal PAGO_CONTRATISTA_DETALLE_ID
		{
			get
			{
				if(IsPAGO_CONTRATISTA_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pago_contratista_detalle_id;
			}
			set
			{
				_pago_contratista_detalle_idNull = false;
				_pago_contratista_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAGO_CONTRATISTA_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAGO_CONTRATISTA_DETALLE_IDNull
		{
			get { return _pago_contratista_detalle_idNull; }
			set { _pago_contratista_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_FACT_ELECTRONICA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_FACT_ELECTRONICA</c> column value.</value>
		public string ES_FACT_ELECTRONICA
		{
			get { return _es_fact_electronica; }
			set { _es_fact_electronica = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MOVIMIENTO_SET</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO_SET</c> column value.</value>
		public string TIPO_MOVIMIENTO_SET
		{
			get { return _tipo_movimiento_set; }
			set { _tipo_movimiento_set = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_TIPO_COMPROBANTE_SET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_TIPO_COMPROBANTE_SET_ID</c> column value.</value>
		public decimal CTB_TIPO_COMPROBANTE_SET_ID
		{
			get
			{
				if(IsCTB_TIPO_COMPROBANTE_SET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_tipo_comprobante_set_id;
			}
			set
			{
				_ctb_tipo_comprobante_set_idNull = false;
				_ctb_tipo_comprobante_set_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_TIPO_COMPROBANTE_SET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_TIPO_COMPROBANTE_SET_IDNull
		{
			get { return _ctb_tipo_comprobante_set_idNull; }
			set { _ctb_tipo_comprobante_set_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUTA_IVA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUTA_IVA</c> column value.</value>
		public string IMPUTA_IVA
		{
			get { return _imputa_iva; }
			set { _imputa_iva = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUTA_IRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUTA_IRE</c> column value.</value>
		public string IMPUTA_IRE
		{
			get { return _imputa_ire; }
			set { _imputa_ire = value; }
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
			dynStr.Append("@CBA@PAGAR_POR_FONDO_FIJO=");
			dynStr.Append(PAGAR_POR_FONDO_FIJO);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@STOCK_DEPOSITO_ID=");
			dynStr.Append(STOCK_DEPOSITO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@RUBRO_ID=");
			dynStr.Append(IsRUBRO_IDNull ? (object)"<NULL>" : RUBRO_ID);
			dynStr.Append("@CBA@RUBRO_NOMBRE=");
			dynStr.Append(RUBRO_NOMBRE);
			dynStr.Append("@CBA@STOCK_DEPOSITO_NOMBRE=");
			dynStr.Append(STOCK_DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@STOCK_DEPOSITO_ABREVIATURA=");
			dynStr.Append(STOCK_DEPOSITO_ABREVIATURA);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FECHA_FACTURA=");
			dynStr.Append(IsFECHA_FACTURANull ? (object)"<NULL>" : FECHA_FACTURA);
			dynStr.Append("@CBA@FECHA_RECEPCION=");
			dynStr.Append(IsFECHA_RECEPCIONNull ? (object)"<NULL>" : FECHA_RECEPCION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_TIMBRADO=");
			dynStr.Append(FECHA_VENCIMIENTO_TIMBRADO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NUMERO_CONTRATO=");
			dynStr.Append(NUMERO_CONTRATO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_COTIZACION=");
			dynStr.Append(MONEDA_COTIZACION);
			dynStr.Append("@CBA@MONEDA_PAIS_COTIZACION=");
			dynStr.Append(MONEDA_PAIS_COTIZACION);
			dynStr.Append("@CBA@CTACTE_CONDICION_PAGO_ID=");
			dynStr.Append(CTACTE_CONDICION_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_CONDICION_PAGO_NOMBRE=");
			dynStr.Append(CTACTE_CONDICION_PAGO_NOMBRE);
			dynStr.Append("@CBA@ESTADO_DOCUMENTACION_ID=");
			dynStr.Append(IsESTADO_DOCUMENTACION_IDNull ? (object)"<NULL>" : ESTADO_DOCUMENTACION_ID);
			dynStr.Append("@CBA@ESTADO_DOCUMENTACION_NOMBRE=");
			dynStr.Append(ESTADO_DOCUMENTACION_NOMBRE);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_ID=");
			dynStr.Append(IsTIPO_CONTENEDOR_IDNull ? (object)"<NULL>" : TIPO_CONTENEDOR_ID);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_NOMBRE=");
			dynStr.Append(TIPO_CONTENEDOR_NOMBRE);
			dynStr.Append("@CBA@CANTIDAD_CONTENEDORES=");
			dynStr.Append(IsCANTIDAD_CONTENEDORESNull ? (object)"<NULL>" : CANTIDAD_CONTENEDORES);
			dynStr.Append("@CBA@TIPO_EMBARQUE_ID=");
			dynStr.Append(IsTIPO_EMBARQUE_IDNull ? (object)"<NULL>" : TIPO_EMBARQUE_ID);
			dynStr.Append("@CBA@TIPO_EMBARQUE_NOMBRE=");
			dynStr.Append(TIPO_EMBARQUE_NOMBRE);
			dynStr.Append("@CBA@TOTAL_BRUTO=");
			dynStr.Append(IsTOTAL_BRUTONull ? (object)"<NULL>" : TOTAL_BRUTO);
			dynStr.Append("@CBA@TOTAL_DESCUENTO=");
			dynStr.Append(IsTOTAL_DESCUENTONull ? (object)"<NULL>" : TOTAL_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_IMPUESTO=");
			dynStr.Append(IsTOTAL_IMPUESTONull ? (object)"<NULL>" : TOTAL_IMPUESTO);
			dynStr.Append("@CBA@TOTAL_PAGO=");
			dynStr.Append(IsTOTAL_PAGONull ? (object)"<NULL>" : TOTAL_PAGO);
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IsIMPORTACION_IDNull ? (object)"<NULL>" : IMPORTACION_ID);
			dynStr.Append("@CBA@PASIBLE_RETENCION=");
			dynStr.Append(PASIBLE_RETENCION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@NRO_TIMBRADO=");
			dynStr.Append(NRO_TIMBRADO);
			dynStr.Append("@CBA@TIPO_FACTURA_PROVEEDOR_ID=");
			dynStr.Append(TIPO_FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@TIPO_FACTURA_PROVEEDOR_NOMBRE=");
			dynStr.Append(TIPO_FACTURA_PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@AFECTA_CTACTE_PROVEEDOR=");
			dynStr.Append(AFECTA_CTACTE_PROVEEDOR);
			dynStr.Append("@CBA@AFECTA_CTACTE_PERSONA=");
			dynStr.Append(AFECTA_CTACTE_PERSONA);
			dynStr.Append("@CBA@AFECTA_CRED_FISCAL_EMPRESA=");
			dynStr.Append(AFECTA_CRED_FISCAL_EMPRESA);
			dynStr.Append("@CBA@AFECTA_CRED_FISCAL_PERSONA=");
			dynStr.Append(AFECTA_CRED_FISCAL_PERSONA);
			dynStr.Append("@CBA@PORC_PROR_IMPORT=");
			dynStr.Append(IsPORC_PROR_IMPORTNull ? (object)"<NULL>" : PORC_PROR_IMPORT);
			dynStr.Append("@CBA@NRO_DOCUMENTO_EXTERNO=");
			dynStr.Append(NRO_DOCUMENTO_EXTERNO);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@PORCENTAJE_DESC_SOBRE_TOTAL=");
			dynStr.Append(PORCENTAJE_DESC_SOBRE_TOTAL);
			dynStr.Append("@CBA@ES_TICKET=");
			dynStr.Append(ES_TICKET);
			dynStr.Append("@CBA@PROVEEDOR_GASTO_ID=");
			dynStr.Append(IsPROVEEDOR_GASTO_IDNull ? (object)"<NULL>" : PROVEEDOR_GASTO_ID);
			dynStr.Append("@CBA@PROVEEDOR_GASTO_NOMBRE=");
			dynStr.Append(PROVEEDOR_GASTO_NOMBRE);
			dynStr.Append("@CBA@DIRECCION_LUGAR_TRANSACCION=");
			dynStr.Append(DIRECCION_LUGAR_TRANSACCION);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_AUTONUM_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_AUTONUM_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_AUTONUM_ID);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_NRO_COMPR=");
			dynStr.Append(EGRESO_VARIO_CAJA_NRO_COMPR);
			dynStr.Append("@CBA@CENTRO_COSTO_OBLIGATORIO=");
			dynStr.Append(CENTRO_COSTO_OBLIGATORIO);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_FECHA=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_FECHANull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_FECHA);
			dynStr.Append("@CBA@ORDEN_PAGO_CTACTE_BANCARIA_ID=");
			dynStr.Append(IsORDEN_PAGO_CTACTE_BANCARIA_IDNull ? (object)"<NULL>" : ORDEN_PAGO_CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@APLICAR_PRORRATEO_SERVICIOS=");
			dynStr.Append(APLICAR_PRORRATEO_SERVICIOS);
			dynStr.Append("@CBA@PAGO_CONTRATISTA_DETALLE_ID=");
			dynStr.Append(IsPAGO_CONTRATISTA_DETALLE_IDNull ? (object)"<NULL>" : PAGO_CONTRATISTA_DETALLE_ID);
			dynStr.Append("@CBA@ES_FACT_ELECTRONICA=");
			dynStr.Append(ES_FACT_ELECTRONICA);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO_SET=");
			dynStr.Append(TIPO_MOVIMIENTO_SET);
			dynStr.Append("@CBA@CTB_TIPO_COMPROBANTE_SET_ID=");
			dynStr.Append(IsCTB_TIPO_COMPROBANTE_SET_IDNull ? (object)"<NULL>" : CTB_TIPO_COMPROBANTE_SET_ID);
			dynStr.Append("@CBA@IMPUTA_IVA=");
			dynStr.Append(IMPUTA_IVA);
			dynStr.Append("@CBA@IMPUTA_IRE=");
			dynStr.Append(IMPUTA_IRE);
			return dynStr.ToString();
		}
	} // End of FACTURAS_PROVEEDOR_INFO_COMPRow_Base class
} // End of namespace
