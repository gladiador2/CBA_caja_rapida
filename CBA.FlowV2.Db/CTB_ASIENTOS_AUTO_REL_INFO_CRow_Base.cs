// <fileinfo name="CTB_ASIENTOS_AUTO_REL_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_AUTO_REL_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTO_REL_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _ctb_asiento_auto_det_id;
		private string _ctb_asiento_auto_det_nombre;
		private string _ctb_asiento_auto_det_desc;
		private decimal _ctb_asiento_automatico_id;
		private decimal _ctb_plan_cuenta_id;
		private string _ctb_plan_cuenta_nombre;
		private string _ctb_plan_cuenta_estado;
		private string _invertir_debe_y_haber;
		private decimal _region_id;
		private bool _region_idNull = true;
		private string _region_nombre;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private decimal _ctb_cuenta_id;
		private bool _ctb_cuenta_idNull = true;
		private string _ctb_cuenta_codigo;
		private string _ctb_cuenta_nombre;
		private decimal _ctacte_bancaria_id;
		private bool _ctacte_bancaria_idNull = true;
		private string _ctacte_bancaria_numero;
		private decimal _ctacte_bancaria_banco_id;
		private bool _ctacte_bancaria_banco_idNull = true;
		private string _ctacte_bancaria_banco_nombre;
		private decimal _stock_deposito_id;
		private bool _stock_deposito_idNull = true;
		private string _stock_deposito_nombre;
		private decimal _stock_deposito_sucursal_id;
		private bool _stock_deposito_sucursal_idNull = true;
		private string _stock_deposito_sucursal_nombre;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private string _ctacte_valor_nombre;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda_nombre;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _proveedor_nombre;
		private decimal _proveedor_relacionado_id;
		private bool _proveedor_relacionado_idNull = true;
		private string _proveedor_rel_razon_social;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _tipo_cliente_id;
		private bool _tipo_cliente_idNull = true;
		private string _tipo_cliente_nombre;
		private string _persona_nombre;
		private string _persona_relacionada_nombre;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _funcionario_nombre;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private string _articulo_familia_nombre;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private string _articulo_grupo_nombre;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _articulo_subgrupo_nombre;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _articulo_nombre;
		private string _articulo_usado;
		private string _articulo_danhado;
		private decimal _rubro_id;
		private bool _rubro_idNull = true;
		private string _rubro_nombre;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto_predefinido_texto;
		private decimal _ctacte_caja_teso_id;
		private bool _ctacte_caja_teso_idNull = true;
		private string _ctacte_caja_teso_nombre;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private string _ctacte_fondo_fijo_nombre;
		private decimal _ctacte_cheque_estado_id;
		private bool _ctacte_cheque_estado_idNull = true;
		private string _ctacte_cheque_estado_nombre;
		private decimal _tipo_notas_credito_id;
		private bool _tipo_notas_credito_idNull = true;
		private decimal _tipo_orden_pago_id;
		private bool _tipo_orden_pago_idNull = true;
		private string _tipo_orden_pago_descripcion;
		private string _tipo_notas_credito_descripcion;
		private string _invertir_si_es_negativo;
		private decimal _descuento_id;
		private bool _descuento_idNull = true;
		private string _descuento_nombre;
		private decimal _bonificacion_id;
		private bool _bonificacion_idNull = true;
		private string _bonificacion_nombre;
		private string _exclusiones;
		private string _inclusiones;
		private string _crear_asiento;
		private decimal _persona_relacionada_id;
		private bool _persona_relacionada_idNull = true;
		private decimal _canal_venta_id;
		private bool _canal_venta_idNull = true;
		private string _canal_venta_nombre;
		private decimal _activo_rubro_id;
		private bool _activo_rubro_idNull = true;
		private string _activo_rubro_nombre;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private string _impuesto_nombre;
		private decimal _ctacte_procesadora_tarjeta_id;
		private bool _ctacte_procesadora_tarjeta_idNull = true;
		private string _ctacte_proc_tarjeta_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_AUTO_REL_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_AUTO_REL_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_ASIENTO_AUTO_DET_ID != original.CTB_ASIENTO_AUTO_DET_ID) return true;
			if (this.CTB_ASIENTO_AUTO_DET_NOMBRE != original.CTB_ASIENTO_AUTO_DET_NOMBRE) return true;
			if (this.CTB_ASIENTO_AUTO_DET_DESC != original.CTB_ASIENTO_AUTO_DET_DESC) return true;
			if (this.CTB_ASIENTO_AUTOMATICO_ID != original.CTB_ASIENTO_AUTOMATICO_ID) return true;
			if (this.CTB_PLAN_CUENTA_ID != original.CTB_PLAN_CUENTA_ID) return true;
			if (this.CTB_PLAN_CUENTA_NOMBRE != original.CTB_PLAN_CUENTA_NOMBRE) return true;
			if (this.CTB_PLAN_CUENTA_ESTADO != original.CTB_PLAN_CUENTA_ESTADO) return true;
			if (this.INVERTIR_DEBE_Y_HABER != original.INVERTIR_DEBE_Y_HABER) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.REGION_NOMBRE != original.REGION_NOMBRE) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.IsCTB_CUENTA_IDNull != original.IsCTB_CUENTA_IDNull) return true;
			if (!this.IsCTB_CUENTA_IDNull && !original.IsCTB_CUENTA_IDNull)
				if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.CTB_CUENTA_CODIGO != original.CTB_CUENTA_CODIGO) return true;
			if (this.CTB_CUENTA_NOMBRE != original.CTB_CUENTA_NOMBRE) return true;
			if (this.IsCTACTE_BANCARIA_IDNull != original.IsCTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_IDNull && !original.IsCTACTE_BANCARIA_IDNull)
				if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.CTACTE_BANCARIA_NUMERO != original.CTACTE_BANCARIA_NUMERO) return true;
			if (this.IsCTACTE_BANCARIA_BANCO_IDNull != original.IsCTACTE_BANCARIA_BANCO_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_BANCO_IDNull && !original.IsCTACTE_BANCARIA_BANCO_IDNull)
				if (this.CTACTE_BANCARIA_BANCO_ID != original.CTACTE_BANCARIA_BANCO_ID) return true;
			if (this.CTACTE_BANCARIA_BANCO_NOMBRE != original.CTACTE_BANCARIA_BANCO_NOMBRE) return true;
			if (this.IsSTOCK_DEPOSITO_IDNull != original.IsSTOCK_DEPOSITO_IDNull) return true;
			if (!this.IsSTOCK_DEPOSITO_IDNull && !original.IsSTOCK_DEPOSITO_IDNull)
				if (this.STOCK_DEPOSITO_ID != original.STOCK_DEPOSITO_ID) return true;
			if (this.STOCK_DEPOSITO_NOMBRE != original.STOCK_DEPOSITO_NOMBRE) return true;
			if (this.IsSTOCK_DEPOSITO_SUCURSAL_IDNull != original.IsSTOCK_DEPOSITO_SUCURSAL_IDNull) return true;
			if (!this.IsSTOCK_DEPOSITO_SUCURSAL_IDNull && !original.IsSTOCK_DEPOSITO_SUCURSAL_IDNull)
				if (this.STOCK_DEPOSITO_SUCURSAL_ID != original.STOCK_DEPOSITO_SUCURSAL_ID) return true;
			if (this.STOCK_DEPOSITO_SUCURSAL_NOMBRE != original.STOCK_DEPOSITO_SUCURSAL_NOMBRE) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.IsPROVEEDOR_RELACIONADO_IDNull != original.IsPROVEEDOR_RELACIONADO_IDNull) return true;
			if (!this.IsPROVEEDOR_RELACIONADO_IDNull && !original.IsPROVEEDOR_RELACIONADO_IDNull)
				if (this.PROVEEDOR_RELACIONADO_ID != original.PROVEEDOR_RELACIONADO_ID) return true;
			if (this.PROVEEDOR_REL_RAZON_SOCIAL != original.PROVEEDOR_REL_RAZON_SOCIAL) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsTIPO_CLIENTE_IDNull != original.IsTIPO_CLIENTE_IDNull) return true;
			if (!this.IsTIPO_CLIENTE_IDNull && !original.IsTIPO_CLIENTE_IDNull)
				if (this.TIPO_CLIENTE_ID != original.TIPO_CLIENTE_ID) return true;
			if (this.TIPO_CLIENTE_NOMBRE != original.TIPO_CLIENTE_NOMBRE) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_RELACIONADA_NOMBRE != original.PERSONA_RELACIONADA_NOMBRE) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.IsARTICULO_FAMILIA_IDNull != original.IsARTICULO_FAMILIA_IDNull) return true;
			if (!this.IsARTICULO_FAMILIA_IDNull && !original.IsARTICULO_FAMILIA_IDNull)
				if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.ARTICULO_FAMILIA_NOMBRE != original.ARTICULO_FAMILIA_NOMBRE) return true;
			if (this.IsARTICULO_GRUPO_IDNull != original.IsARTICULO_GRUPO_IDNull) return true;
			if (!this.IsARTICULO_GRUPO_IDNull && !original.IsARTICULO_GRUPO_IDNull)
				if (this.ARTICULO_GRUPO_ID != original.ARTICULO_GRUPO_ID) return true;
			if (this.ARTICULO_GRUPO_NOMBRE != original.ARTICULO_GRUPO_NOMBRE) return true;
			if (this.IsARTICULO_SUBGRUPO_IDNull != original.IsARTICULO_SUBGRUPO_IDNull) return true;
			if (!this.IsARTICULO_SUBGRUPO_IDNull && !original.IsARTICULO_SUBGRUPO_IDNull)
				if (this.ARTICULO_SUBGRUPO_ID != original.ARTICULO_SUBGRUPO_ID) return true;
			if (this.ARTICULO_SUBGRUPO_NOMBRE != original.ARTICULO_SUBGRUPO_NOMBRE) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_NOMBRE != original.ARTICULO_NOMBRE) return true;
			if (this.ARTICULO_USADO != original.ARTICULO_USADO) return true;
			if (this.ARTICULO_DANHADO != original.ARTICULO_DANHADO) return true;
			if (this.IsRUBRO_IDNull != original.IsRUBRO_IDNull) return true;
			if (!this.IsRUBRO_IDNull && !original.IsRUBRO_IDNull)
				if (this.RUBRO_ID != original.RUBRO_ID) return true;
			if (this.RUBRO_NOMBRE != original.RUBRO_NOMBRE) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_TEXTO != original.TEXTO_PREDEFINIDO_TEXTO) return true;
			if (this.IsCTACTE_CAJA_TESO_IDNull != original.IsCTACTE_CAJA_TESO_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESO_IDNull && !original.IsCTACTE_CAJA_TESO_IDNull)
				if (this.CTACTE_CAJA_TESO_ID != original.CTACTE_CAJA_TESO_ID) return true;
			if (this.CTACTE_CAJA_TESO_NOMBRE != original.CTACTE_CAJA_TESO_NOMBRE) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.CTACTE_FONDO_FIJO_NOMBRE != original.CTACTE_FONDO_FIJO_NOMBRE) return true;
			if (this.IsCTACTE_CHEQUE_ESTADO_IDNull != original.IsCTACTE_CHEQUE_ESTADO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_ESTADO_IDNull && !original.IsCTACTE_CHEQUE_ESTADO_IDNull)
				if (this.CTACTE_CHEQUE_ESTADO_ID != original.CTACTE_CHEQUE_ESTADO_ID) return true;
			if (this.CTACTE_CHEQUE_ESTADO_NOMBRE != original.CTACTE_CHEQUE_ESTADO_NOMBRE) return true;
			if (this.IsTIPO_NOTAS_CREDITO_IDNull != original.IsTIPO_NOTAS_CREDITO_IDNull) return true;
			if (!this.IsTIPO_NOTAS_CREDITO_IDNull && !original.IsTIPO_NOTAS_CREDITO_IDNull)
				if (this.TIPO_NOTAS_CREDITO_ID != original.TIPO_NOTAS_CREDITO_ID) return true;
			if (this.IsTIPO_ORDEN_PAGO_IDNull != original.IsTIPO_ORDEN_PAGO_IDNull) return true;
			if (!this.IsTIPO_ORDEN_PAGO_IDNull && !original.IsTIPO_ORDEN_PAGO_IDNull)
				if (this.TIPO_ORDEN_PAGO_ID != original.TIPO_ORDEN_PAGO_ID) return true;
			if (this.TIPO_ORDEN_PAGO_DESCRIPCION != original.TIPO_ORDEN_PAGO_DESCRIPCION) return true;
			if (this.TIPO_NOTAS_CREDITO_DESCRIPCION != original.TIPO_NOTAS_CREDITO_DESCRIPCION) return true;
			if (this.INVERTIR_SI_ES_NEGATIVO != original.INVERTIR_SI_ES_NEGATIVO) return true;
			if (this.IsDESCUENTO_IDNull != original.IsDESCUENTO_IDNull) return true;
			if (!this.IsDESCUENTO_IDNull && !original.IsDESCUENTO_IDNull)
				if (this.DESCUENTO_ID != original.DESCUENTO_ID) return true;
			if (this.DESCUENTO_NOMBRE != original.DESCUENTO_NOMBRE) return true;
			if (this.IsBONIFICACION_IDNull != original.IsBONIFICACION_IDNull) return true;
			if (!this.IsBONIFICACION_IDNull && !original.IsBONIFICACION_IDNull)
				if (this.BONIFICACION_ID != original.BONIFICACION_ID) return true;
			if (this.BONIFICACION_NOMBRE != original.BONIFICACION_NOMBRE) return true;
			if (this.EXCLUSIONES != original.EXCLUSIONES) return true;
			if (this.INCLUSIONES != original.INCLUSIONES) return true;
			if (this.CREAR_ASIENTO != original.CREAR_ASIENTO) return true;
			if (this.IsPERSONA_RELACIONADA_IDNull != original.IsPERSONA_RELACIONADA_IDNull) return true;
			if (!this.IsPERSONA_RELACIONADA_IDNull && !original.IsPERSONA_RELACIONADA_IDNull)
				if (this.PERSONA_RELACIONADA_ID != original.PERSONA_RELACIONADA_ID) return true;
			if (this.IsCANAL_VENTA_IDNull != original.IsCANAL_VENTA_IDNull) return true;
			if (!this.IsCANAL_VENTA_IDNull && !original.IsCANAL_VENTA_IDNull)
				if (this.CANAL_VENTA_ID != original.CANAL_VENTA_ID) return true;
			if (this.CANAL_VENTA_NOMBRE != original.CANAL_VENTA_NOMBRE) return true;
			if (this.IsACTIVO_RUBRO_IDNull != original.IsACTIVO_RUBRO_IDNull) return true;
			if (!this.IsACTIVO_RUBRO_IDNull && !original.IsACTIVO_RUBRO_IDNull)
				if (this.ACTIVO_RUBRO_ID != original.ACTIVO_RUBRO_ID) return true;
			if (this.ACTIVO_RUBRO_NOMBRE != original.ACTIVO_RUBRO_NOMBRE) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IMPUESTO_NOMBRE != original.IMPUESTO_NOMBRE) return true;
			if (this.IsCTACTE_PROCESADORA_TARJETA_IDNull != original.IsCTACTE_PROCESADORA_TARJETA_IDNull) return true;
			if (!this.IsCTACTE_PROCESADORA_TARJETA_IDNull && !original.IsCTACTE_PROCESADORA_TARJETA_IDNull)
				if (this.CTACTE_PROCESADORA_TARJETA_ID != original.CTACTE_PROCESADORA_TARJETA_ID) return true;
			if (this.CTACTE_PROC_TARJETA_NOMBRE != original.CTACTE_PROC_TARJETA_NOMBRE) return true;
			
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
		/// Gets or sets the <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_AUTO_DET_ID</c> column value.</value>
		public decimal CTB_ASIENTO_AUTO_DET_ID
		{
			get { return _ctb_asiento_auto_det_id; }
			set { _ctb_asiento_auto_det_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_ASIENTO_AUTO_DET_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_AUTO_DET_NOMBRE</c> column value.</value>
		public string CTB_ASIENTO_AUTO_DET_NOMBRE
		{
			get { return _ctb_asiento_auto_det_nombre; }
			set { _ctb_asiento_auto_det_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_ASIENTO_AUTO_DET_DESC</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_AUTO_DET_DESC</c> column value.</value>
		public string CTB_ASIENTO_AUTO_DET_DESC
		{
			get { return _ctb_asiento_auto_det_desc; }
			set { _ctb_asiento_auto_det_desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</value>
		public decimal CTB_ASIENTO_AUTOMATICO_ID
		{
			get { return _ctb_asiento_automatico_id; }
			set { _ctb_asiento_automatico_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_ID</c> column value.</value>
		public decimal CTB_PLAN_CUENTA_ID
		{
			get { return _ctb_plan_cuenta_id; }
			set { _ctb_plan_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_PLAN_CUENTA_NOMBRE
		{
			get { return _ctb_plan_cuenta_nombre; }
			set { _ctb_plan_cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_ESTADO</c> column value.</value>
		public string CTB_PLAN_CUENTA_ESTADO
		{
			get { return _ctb_plan_cuenta_estado; }
			set { _ctb_plan_cuenta_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INVERTIR_DEBE_Y_HABER</c> column value.
		/// </summary>
		/// <value>The <c>INVERTIR_DEBE_Y_HABER</c> column value.</value>
		public string INVERTIR_DEBE_Y_HABER
		{
			get { return _invertir_debe_y_haber; }
			set { _invertir_debe_y_haber = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_NOMBRE</c> column value.</value>
		public string REGION_NOMBRE
		{
			get { return _region_nombre; }
			set { _region_nombre = value; }
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get
			{
				if(IsCTB_CUENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta_id;
			}
			set
			{
				_ctb_cuenta_idNull = false;
				_ctb_cuenta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTA_IDNull
		{
			get { return _ctb_cuenta_idNull; }
			set { _ctb_cuenta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_CODIGO</c> column value.</value>
		public string CTB_CUENTA_CODIGO
		{
			get { return _ctb_cuenta_codigo; }
			set { _ctb_cuenta_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_CUENTA_NOMBRE
		{
			get { return _ctb_cuenta_nombre; }
			set { _ctb_cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_id;
			}
			set
			{
				_ctacte_bancaria_idNull = false;
				_ctacte_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_IDNull
		{
			get { return _ctacte_bancaria_idNull; }
			set { _ctacte_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_NUMERO</c> column value.</value>
		public string CTACTE_BANCARIA_NUMERO
		{
			get { return _ctacte_bancaria_numero; }
			set { _ctacte_bancaria_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_BANCO_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_banco_id;
			}
			set
			{
				_ctacte_bancaria_banco_idNull = false;
				_ctacte_bancaria_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_BANCO_IDNull
		{
			get { return _ctacte_bancaria_banco_idNull; }
			set { _ctacte_bancaria_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_BANCO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_BANCO_NOMBRE</c> column value.</value>
		public string CTACTE_BANCARIA_BANCO_NOMBRE
		{
			get { return _ctacte_bancaria_banco_nombre; }
			set { _ctacte_bancaria_banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_ID</c> column value.</value>
		public decimal STOCK_DEPOSITO_ID
		{
			get
			{
				if(IsSTOCK_DEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _stock_deposito_id;
			}
			set
			{
				_stock_deposito_idNull = false;
				_stock_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="STOCK_DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSTOCK_DEPOSITO_IDNull
		{
			get { return _stock_deposito_idNull; }
			set { _stock_deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_NOMBRE</c> column value.</value>
		public string STOCK_DEPOSITO_NOMBRE
		{
			get { return _stock_deposito_nombre; }
			set { _stock_deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_SUCURSAL_ID</c> column value.</value>
		public decimal STOCK_DEPOSITO_SUCURSAL_ID
		{
			get
			{
				if(IsSTOCK_DEPOSITO_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _stock_deposito_sucursal_id;
			}
			set
			{
				_stock_deposito_sucursal_idNull = false;
				_stock_deposito_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="STOCK_DEPOSITO_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSTOCK_DEPOSITO_SUCURSAL_IDNull
		{
			get { return _stock_deposito_sucursal_idNull; }
			set { _stock_deposito_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_SUCURSAL_NOMBRE</c> column value.</value>
		public string STOCK_DEPOSITO_SUCURSAL_NOMBRE
		{
			get { return _stock_deposito_sucursal_nombre; }
			set { _stock_deposito_sucursal_nombre = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
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
		/// Gets or sets the <c>PROVEEDOR_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</value>
		public decimal PROVEEDOR_RELACIONADO_ID
		{
			get
			{
				if(IsPROVEEDOR_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_relacionado_id;
			}
			set
			{
				_proveedor_relacionado_idNull = false;
				_proveedor_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_RELACIONADO_IDNull
		{
			get { return _proveedor_relacionado_idNull; }
			set { _proveedor_relacionado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_REL_RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_REL_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_REL_RAZON_SOCIAL
		{
			get { return _proveedor_rel_razon_social; }
			set { _proveedor_rel_razon_social = value; }
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
		/// Gets or sets the <c>TIPO_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CLIENTE_ID</c> column value.</value>
		public decimal TIPO_CLIENTE_ID
		{
			get
			{
				if(IsTIPO_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_cliente_id;
			}
			set
			{
				_tipo_cliente_idNull = false;
				_tipo_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CLIENTE_IDNull
		{
			get { return _tipo_cliente_idNull; }
			set { _tipo_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CLIENTE_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CLIENTE_NOMBRE</c> column value.</value>
		public string TIPO_CLIENTE_NOMBRE
		{
			get { return _tipo_cliente_nombre; }
			set { _tipo_cliente_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_RELACIONADA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_RELACIONADA_NOMBRE</c> column value.</value>
		public string PERSONA_RELACIONADA_NOMBRE
		{
			get { return _persona_relacionada_nombre; }
			set { _persona_relacionada_nombre = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULO_FAMILIA_ID
		{
			get
			{
				if(IsARTICULO_FAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_familia_id;
			}
			set
			{
				_articulo_familia_idNull = false;
				_articulo_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_FAMILIA_IDNull
		{
			get { return _articulo_familia_idNull; }
			set { _articulo_familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_FAMILIA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_NOMBRE</c> column value.</value>
		public string ARTICULO_FAMILIA_NOMBRE
		{
			get { return _articulo_familia_nombre; }
			set { _articulo_familia_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_ID</c> column value.</value>
		public decimal ARTICULO_GRUPO_ID
		{
			get
			{
				if(IsARTICULO_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_grupo_id;
			}
			set
			{
				_articulo_grupo_idNull = false;
				_articulo_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_GRUPO_IDNull
		{
			get { return _articulo_grupo_idNull; }
			set { _articulo_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_GRUPO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_NOMBRE</c> column value.</value>
		public string ARTICULO_GRUPO_NOMBRE
		{
			get { return _articulo_grupo_nombre; }
			set { _articulo_grupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_ID</c> column value.</value>
		public decimal ARTICULO_SUBGRUPO_ID
		{
			get
			{
				if(IsARTICULO_SUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_subgrupo_id;
			}
			set
			{
				_articulo_subgrupo_idNull = false;
				_articulo_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_SUBGRUPO_IDNull
		{
			get { return _articulo_subgrupo_idNull; }
			set { _articulo_subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_NOMBRE</c> column value.</value>
		public string ARTICULO_SUBGRUPO_NOMBRE
		{
			get { return _articulo_subgrupo_nombre; }
			set { _articulo_subgrupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_NOMBRE</c> column value.</value>
		public string ARTICULO_NOMBRE
		{
			get { return _articulo_nombre; }
			set { _articulo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_USADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_USADO</c> column value.</value>
		public string ARTICULO_USADO
		{
			get { return _articulo_usado; }
			set { _articulo_usado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DANHADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DANHADO</c> column value.</value>
		public string ARTICULO_DANHADO
		{
			get { return _articulo_danhado; }
			set { _articulo_danhado = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_TEXTO</c> column value.</value>
		public string TEXTO_PREDEFINIDO_TEXTO
		{
			get { return _texto_predefinido_texto; }
			set { _texto_predefinido_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESO_ID
		{
			get
			{
				if(IsCTACTE_CAJA_TESO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_teso_id;
			}
			set
			{
				_ctacte_caja_teso_idNull = false;
				_ctacte_caja_teso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_TESO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_TESO_IDNull
		{
			get { return _ctacte_caja_teso_idNull; }
			set { _ctacte_caja_teso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESO_NOMBRE
		{
			get { return _ctacte_caja_teso_nombre; }
			set { _ctacte_caja_teso_nombre = value; }
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
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_NOMBRE</c> column value.</value>
		public string CTACTE_FONDO_FIJO_NOMBRE
		{
			get { return _ctacte_fondo_fijo_nombre; }
			set { _ctacte_fondo_fijo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_ESTADO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_ESTADO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_ESTADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_estado_id;
			}
			set
			{
				_ctacte_cheque_estado_idNull = false;
				_ctacte_cheque_estado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_ESTADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_ESTADO_IDNull
		{
			get { return _ctacte_cheque_estado_idNull; }
			set { _ctacte_cheque_estado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_ESTADO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_ESTADO_NOMBRE</c> column value.</value>
		public string CTACTE_CHEQUE_ESTADO_NOMBRE
		{
			get { return _ctacte_cheque_estado_nombre; }
			set { _ctacte_cheque_estado_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NOTAS_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NOTAS_CREDITO_ID</c> column value.</value>
		public decimal TIPO_NOTAS_CREDITO_ID
		{
			get
			{
				if(IsTIPO_NOTAS_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_notas_credito_id;
			}
			set
			{
				_tipo_notas_credito_idNull = false;
				_tipo_notas_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_NOTAS_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_NOTAS_CREDITO_IDNull
		{
			get { return _tipo_notas_credito_idNull; }
			set { _tipo_notas_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ORDEN_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ORDEN_PAGO_ID</c> column value.</value>
		public decimal TIPO_ORDEN_PAGO_ID
		{
			get
			{
				if(IsTIPO_ORDEN_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_orden_pago_id;
			}
			set
			{
				_tipo_orden_pago_idNull = false;
				_tipo_orden_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_ORDEN_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_ORDEN_PAGO_IDNull
		{
			get { return _tipo_orden_pago_idNull; }
			set { _tipo_orden_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ORDEN_PAGO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ORDEN_PAGO_DESCRIPCION</c> column value.</value>
		public string TIPO_ORDEN_PAGO_DESCRIPCION
		{
			get { return _tipo_orden_pago_descripcion; }
			set { _tipo_orden_pago_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NOTAS_CREDITO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NOTAS_CREDITO_DESCRIPCION</c> column value.</value>
		public string TIPO_NOTAS_CREDITO_DESCRIPCION
		{
			get { return _tipo_notas_credito_descripcion; }
			set { _tipo_notas_credito_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INVERTIR_SI_ES_NEGATIVO</c> column value.
		/// </summary>
		/// <value>The <c>INVERTIR_SI_ES_NEGATIVO</c> column value.</value>
		public string INVERTIR_SI_ES_NEGATIVO
		{
			get { return _invertir_si_es_negativo; }
			set { _invertir_si_es_negativo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_ID</c> column value.</value>
		public decimal DESCUENTO_ID
		{
			get
			{
				if(IsDESCUENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_id;
			}
			set
			{
				_descuento_idNull = false;
				_descuento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_IDNull
		{
			get { return _descuento_idNull; }
			set { _descuento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_NOMBRE</c> column value.</value>
		public string DESCUENTO_NOMBRE
		{
			get { return _descuento_nombre; }
			set { _descuento_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BONIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BONIFICACION_ID</c> column value.</value>
		public decimal BONIFICACION_ID
		{
			get
			{
				if(IsBONIFICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _bonificacion_id;
			}
			set
			{
				_bonificacion_idNull = false;
				_bonificacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BONIFICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBONIFICACION_IDNull
		{
			get { return _bonificacion_idNull; }
			set { _bonificacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BONIFICACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BONIFICACION_NOMBRE</c> column value.</value>
		public string BONIFICACION_NOMBRE
		{
			get { return _bonificacion_nombre; }
			set { _bonificacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXCLUSIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXCLUSIONES</c> column value.</value>
		public string EXCLUSIONES
		{
			get { return _exclusiones; }
			set { _exclusiones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INCLUSIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INCLUSIONES</c> column value.</value>
		public string INCLUSIONES
		{
			get { return _inclusiones; }
			set { _inclusiones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREAR_ASIENTO</c> column value.
		/// </summary>
		/// <value>The <c>CREAR_ASIENTO</c> column value.</value>
		public string CREAR_ASIENTO
		{
			get { return _crear_asiento; }
			set { _crear_asiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_RELACIONADA_ID</c> column value.</value>
		public decimal PERSONA_RELACIONADA_ID
		{
			get
			{
				if(IsPERSONA_RELACIONADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_relacionada_id;
			}
			set
			{
				_persona_relacionada_idNull = false;
				_persona_relacionada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_RELACIONADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_RELACIONADA_IDNull
		{
			get { return _persona_relacionada_idNull; }
			set { _persona_relacionada_idNull = value; }
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
		/// Gets or sets the <c>CANAL_VENTA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANAL_VENTA_NOMBRE</c> column value.</value>
		public string CANAL_VENTA_NOMBRE
		{
			get { return _canal_venta_nombre; }
			set { _canal_venta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_RUBRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_RUBRO_ID</c> column value.</value>
		public decimal ACTIVO_RUBRO_ID
		{
			get
			{
				if(IsACTIVO_RUBRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_rubro_id;
			}
			set
			{
				_activo_rubro_idNull = false;
				_activo_rubro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_RUBRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_RUBRO_IDNull
		{
			get { return _activo_rubro_idNull; }
			set { _activo_rubro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_RUBRO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_RUBRO_NOMBRE</c> column value.</value>
		public string ACTIVO_RUBRO_NOMBRE
		{
			get { return _activo_rubro_nombre; }
			set { _activo_rubro_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get
			{
				if(IsIMPUESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_id;
			}
			set
			{
				_impuesto_idNull = false;
				_impuesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_IDNull
		{
			get { return _impuesto_idNull; }
			set { _impuesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_NOMBRE</c> column value.</value>
		public string IMPUESTO_NOMBRE
		{
			get { return _impuesto_nombre; }
			set { _impuesto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</value>
		public decimal CTACTE_PROCESADORA_TARJETA_ID
		{
			get
			{
				if(IsCTACTE_PROCESADORA_TARJETA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_procesadora_tarjeta_id;
			}
			set
			{
				_ctacte_procesadora_tarjeta_idNull = false;
				_ctacte_procesadora_tarjeta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROCESADORA_TARJETA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROCESADORA_TARJETA_IDNull
		{
			get { return _ctacte_procesadora_tarjeta_idNull; }
			set { _ctacte_procesadora_tarjeta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROC_TARJETA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROC_TARJETA_NOMBRE</c> column value.</value>
		public string CTACTE_PROC_TARJETA_NOMBRE
		{
			get { return _ctacte_proc_tarjeta_nombre; }
			set { _ctacte_proc_tarjeta_nombre = value; }
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
			dynStr.Append("@CBA@CTB_ASIENTO_AUTO_DET_ID=");
			dynStr.Append(CTB_ASIENTO_AUTO_DET_ID);
			dynStr.Append("@CBA@CTB_ASIENTO_AUTO_DET_NOMBRE=");
			dynStr.Append(CTB_ASIENTO_AUTO_DET_NOMBRE);
			dynStr.Append("@CBA@CTB_ASIENTO_AUTO_DET_DESC=");
			dynStr.Append(CTB_ASIENTO_AUTO_DET_DESC);
			dynStr.Append("@CBA@CTB_ASIENTO_AUTOMATICO_ID=");
			dynStr.Append(CTB_ASIENTO_AUTOMATICO_ID);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_ID=");
			dynStr.Append(CTB_PLAN_CUENTA_ID);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_NOMBRE=");
			dynStr.Append(CTB_PLAN_CUENTA_NOMBRE);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_ESTADO=");
			dynStr.Append(CTB_PLAN_CUENTA_ESTADO);
			dynStr.Append("@CBA@INVERTIR_DEBE_Y_HABER=");
			dynStr.Append(INVERTIR_DEBE_Y_HABER);
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@REGION_NOMBRE=");
			dynStr.Append(REGION_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(IsCTB_CUENTA_IDNull ? (object)"<NULL>" : CTB_CUENTA_ID);
			dynStr.Append("@CBA@CTB_CUENTA_CODIGO=");
			dynStr.Append(CTB_CUENTA_CODIGO);
			dynStr.Append("@CBA@CTB_CUENTA_NOMBRE=");
			dynStr.Append(CTB_CUENTA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@CTACTE_BANCARIA_NUMERO=");
			dynStr.Append(CTACTE_BANCARIA_NUMERO);
			dynStr.Append("@CBA@CTACTE_BANCARIA_BANCO_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_BANCO_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_BANCO_ID);
			dynStr.Append("@CBA@CTACTE_BANCARIA_BANCO_NOMBRE=");
			dynStr.Append(CTACTE_BANCARIA_BANCO_NOMBRE);
			dynStr.Append("@CBA@STOCK_DEPOSITO_ID=");
			dynStr.Append(IsSTOCK_DEPOSITO_IDNull ? (object)"<NULL>" : STOCK_DEPOSITO_ID);
			dynStr.Append("@CBA@STOCK_DEPOSITO_NOMBRE=");
			dynStr.Append(STOCK_DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@STOCK_DEPOSITO_SUCURSAL_ID=");
			dynStr.Append(IsSTOCK_DEPOSITO_SUCURSAL_IDNull ? (object)"<NULL>" : STOCK_DEPOSITO_SUCURSAL_ID);
			dynStr.Append("@CBA@STOCK_DEPOSITO_SUCURSAL_NOMBRE=");
			dynStr.Append(STOCK_DEPOSITO_SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_RELACIONADO_ID=");
			dynStr.Append(IsPROVEEDOR_RELACIONADO_IDNull ? (object)"<NULL>" : PROVEEDOR_RELACIONADO_ID);
			dynStr.Append("@CBA@PROVEEDOR_REL_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_REL_RAZON_SOCIAL);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@TIPO_CLIENTE_ID=");
			dynStr.Append(IsTIPO_CLIENTE_IDNull ? (object)"<NULL>" : TIPO_CLIENTE_ID);
			dynStr.Append("@CBA@TIPO_CLIENTE_NOMBRE=");
			dynStr.Append(TIPO_CLIENTE_NOMBRE);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_RELACIONADA_NOMBRE=");
			dynStr.Append(PERSONA_RELACIONADA_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_NOMBRE=");
			dynStr.Append(ARTICULO_FAMILIA_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_NOMBRE=");
			dynStr.Append(ARTICULO_GRUPO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_NOMBRE=");
			dynStr.Append(ARTICULO_SUBGRUPO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_NOMBRE=");
			dynStr.Append(ARTICULO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_USADO=");
			dynStr.Append(ARTICULO_USADO);
			dynStr.Append("@CBA@ARTICULO_DANHADO=");
			dynStr.Append(ARTICULO_DANHADO);
			dynStr.Append("@CBA@RUBRO_ID=");
			dynStr.Append(IsRUBRO_IDNull ? (object)"<NULL>" : RUBRO_ID);
			dynStr.Append("@CBA@RUBRO_NOMBRE=");
			dynStr.Append(RUBRO_NOMBRE);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_TEXTO=");
			dynStr.Append(TEXTO_PREDEFINIDO_TEXTO);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESO_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESO_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_NOMBRE=");
			dynStr.Append(CTACTE_FONDO_FIJO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CHEQUE_ESTADO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_ESTADO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_ESTADO_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_ESTADO_NOMBRE=");
			dynStr.Append(CTACTE_CHEQUE_ESTADO_NOMBRE);
			dynStr.Append("@CBA@TIPO_NOTAS_CREDITO_ID=");
			dynStr.Append(IsTIPO_NOTAS_CREDITO_IDNull ? (object)"<NULL>" : TIPO_NOTAS_CREDITO_ID);
			dynStr.Append("@CBA@TIPO_ORDEN_PAGO_ID=");
			dynStr.Append(IsTIPO_ORDEN_PAGO_IDNull ? (object)"<NULL>" : TIPO_ORDEN_PAGO_ID);
			dynStr.Append("@CBA@TIPO_ORDEN_PAGO_DESCRIPCION=");
			dynStr.Append(TIPO_ORDEN_PAGO_DESCRIPCION);
			dynStr.Append("@CBA@TIPO_NOTAS_CREDITO_DESCRIPCION=");
			dynStr.Append(TIPO_NOTAS_CREDITO_DESCRIPCION);
			dynStr.Append("@CBA@INVERTIR_SI_ES_NEGATIVO=");
			dynStr.Append(INVERTIR_SI_ES_NEGATIVO);
			dynStr.Append("@CBA@DESCUENTO_ID=");
			dynStr.Append(IsDESCUENTO_IDNull ? (object)"<NULL>" : DESCUENTO_ID);
			dynStr.Append("@CBA@DESCUENTO_NOMBRE=");
			dynStr.Append(DESCUENTO_NOMBRE);
			dynStr.Append("@CBA@BONIFICACION_ID=");
			dynStr.Append(IsBONIFICACION_IDNull ? (object)"<NULL>" : BONIFICACION_ID);
			dynStr.Append("@CBA@BONIFICACION_NOMBRE=");
			dynStr.Append(BONIFICACION_NOMBRE);
			dynStr.Append("@CBA@EXCLUSIONES=");
			dynStr.Append(EXCLUSIONES);
			dynStr.Append("@CBA@INCLUSIONES=");
			dynStr.Append(INCLUSIONES);
			dynStr.Append("@CBA@CREAR_ASIENTO=");
			dynStr.Append(CREAR_ASIENTO);
			dynStr.Append("@CBA@PERSONA_RELACIONADA_ID=");
			dynStr.Append(IsPERSONA_RELACIONADA_IDNull ? (object)"<NULL>" : PERSONA_RELACIONADA_ID);
			dynStr.Append("@CBA@CANAL_VENTA_ID=");
			dynStr.Append(IsCANAL_VENTA_IDNull ? (object)"<NULL>" : CANAL_VENTA_ID);
			dynStr.Append("@CBA@CANAL_VENTA_NOMBRE=");
			dynStr.Append(CANAL_VENTA_NOMBRE);
			dynStr.Append("@CBA@ACTIVO_RUBRO_ID=");
			dynStr.Append(IsACTIVO_RUBRO_IDNull ? (object)"<NULL>" : ACTIVO_RUBRO_ID);
			dynStr.Append("@CBA@ACTIVO_RUBRO_NOMBRE=");
			dynStr.Append(ACTIVO_RUBRO_NOMBRE);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTO_NOMBRE=");
			dynStr.Append(IMPUESTO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_PROCESADORA_TARJETA_ID=");
			dynStr.Append(IsCTACTE_PROCESADORA_TARJETA_IDNull ? (object)"<NULL>" : CTACTE_PROCESADORA_TARJETA_ID);
			dynStr.Append("@CBA@CTACTE_PROC_TARJETA_NOMBRE=");
			dynStr.Append(CTACTE_PROC_TARJETA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_AUTO_REL_INFO_CRow_Base class
} // End of namespace
