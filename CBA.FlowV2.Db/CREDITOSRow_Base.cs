// <fileinfo name="CREDITOSRow_Base.cs">
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
	/// The base class for <see cref="CREDITOSRow"/> that 
	/// represents a record in the <c>CREDITOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CREDITOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _persona_id;
		private decimal _persona_garante1_id;
		private bool _persona_garante1_idNull = true;
		private decimal _persona_garante2_id;
		private bool _persona_garante2_idNull = true;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private System.DateTime _fecha_solicitud;
		private System.DateTime _fecha_retiro;
		private bool _fecha_retiroNull = true;
		private string _separacion_bienes;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _total_ingresos;
		private bool _total_ingresosNull = true;
		private decimal _total_egresos;
		private bool _total_egresosNull = true;
		private string _observacion;
		private decimal _cantidad_cuotas;
		private decimal _porcentaje_interes;
		private bool _porcentaje_interesNull = true;
		private decimal _porcentaje_diario_mora;
		private bool _porcentaje_diario_moraNull = true;
		private decimal _porcentaje_gasto_administ;
		private bool _porcentaje_gasto_administNull = true;
		private decimal _monto_capital_aprobado;
		private decimal _monto_interes;
		private bool _monto_interesNull = true;
		private decimal _monto_gasto_administrativo;
		private bool _monto_gasto_administrativoNull = true;
		private decimal _monto_capital_solicitado;
		private decimal _monto_total;
		private decimal _tipo_credito_id;
		private decimal _factura_cliente_id;
		private bool _factura_cliente_idNull = true;
		private decimal _factura_cliente_auton_id;
		private bool _factura_cliente_auton_idNull = true;
		private decimal _funcionario_id;
		private string _numero_solicitud;
		private decimal _ordenes_pago_id;
		private bool _ordenes_pago_idNull = true;
		private decimal _ctacte_caja_tesoreria_id;
		private bool _ctacte_caja_tesoreria_idNull = true;
		private decimal _entrega_inicial;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private string _con_recurso;
		private string _desembolsar_para_cliente;
		private string _interes_incluye_impuesto;
		private string _tipo_frecuencia;
		private decimal _frecuencia;
		private string _anho_comercial;
		private string _facturar_conceptos_en_pagos;
		private string _aumentar_capital_por_descuent;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _dias_gracia;
		private decimal _porcentaje_seguro;
		private bool _porcentaje_seguroNull = true;
		private decimal _porcentaje_corretaje;
		private bool _porcentaje_corretajeNull = true;
		private decimal _porcentaje_comision_admin;
		private bool _porcentaje_comision_adminNull = true;
		private decimal _porcentaje_bonificacion;
		private bool _porcentaje_bonificacionNull = true;
		private decimal _monto_seguro;
		private bool _monto_seguroNull = true;
		private decimal _monto_corretaje;
		private bool _monto_corretajeNull = true;
		private decimal _monto_comision_admin;
		private bool _monto_comision_adminNull = true;
		private decimal _monto_bonificacion;
		private bool _monto_bonificacionNull = true;
		private decimal _descuento_cancelacion_anticip;
		private string _estado;
		private System.DateTime _fecha_primer_vencimiento;
		private decimal _monto_redondeo;
		private string _tipo_interes_anual;
		private string _concepto_incluye_impuesto;
		private decimal _monto_capital_orden_compra;
		private string _facturar_bonificacion_en_pagos;
		private string _bonificacion_incluye_impuesto;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private decimal _egreso_vario_caja_id;
		private bool _egreso_vario_caja_idNull = true;
		private string _aprobacion_1;
		private decimal _aprobacion_1_usuario_id;
		private bool _aprobacion_1_usuario_idNull = true;
		private System.DateTime _aprobacion_1_fecha;
		private bool _aprobacion_1_fechaNull = true;
		private string _aprobacion_2;
		private decimal _aprobacion_2_usuario_id;
		private bool _aprobacion_2_usuario_idNull = true;
		private System.DateTime _aprobacion_2_fecha;
		private bool _aprobacion_2_fechaNull = true;
		private string _aprobacion_3;
		private decimal _aprobacion_3_usuario_id;
		private bool _aprobacion_3_usuario_idNull = true;
		private System.DateTime _aprobacion_3_fecha;
		private bool _aprobacion_3_fechaNull = true;
		private decimal _canal_venta_id;
		private bool _canal_venta_idNull = true;
		private decimal _facturar_intereses;
		private decimal _porcentaje_otros;
		private bool _porcentaje_otrosNull = true;
		private decimal _monto_otros;
		private bool _monto_otrosNull = true;
		private string _interes_compuesto;
		private string _afecta_linea_credito;
		private decimal _facturar_capital;
		private decimal _monto_diario_mora;
		private bool _monto_diario_moraNull = true;
		private System.DateTime _fecha_cancelacion_anticipada;
		private bool _fecha_cancelacion_anticipadaNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _descuento_canc_ant_aplicado;
		private decimal _descuento_canc_ant_cant_no_ven;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOSRow_Base"/> class.
		/// </summary>
		public CREDITOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CREDITOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPERSONA_GARANTE1_IDNull != original.IsPERSONA_GARANTE1_IDNull) return true;
			if (!this.IsPERSONA_GARANTE1_IDNull && !original.IsPERSONA_GARANTE1_IDNull)
				if (this.PERSONA_GARANTE1_ID != original.PERSONA_GARANTE1_ID) return true;
			if (this.IsPERSONA_GARANTE2_IDNull != original.IsPERSONA_GARANTE2_IDNull) return true;
			if (!this.IsPERSONA_GARANTE2_IDNull && !original.IsPERSONA_GARANTE2_IDNull)
				if (this.PERSONA_GARANTE2_ID != original.PERSONA_GARANTE2_ID) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA_SOLICITUD != original.FECHA_SOLICITUD) return true;
			if (this.IsFECHA_RETIRONull != original.IsFECHA_RETIRONull) return true;
			if (!this.IsFECHA_RETIRONull && !original.IsFECHA_RETIRONull)
				if (this.FECHA_RETIRO != original.FECHA_RETIRO) return true;
			if (this.SEPARACION_BIENES != original.SEPARACION_BIENES) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsTOTAL_INGRESOSNull != original.IsTOTAL_INGRESOSNull) return true;
			if (!this.IsTOTAL_INGRESOSNull && !original.IsTOTAL_INGRESOSNull)
				if (this.TOTAL_INGRESOS != original.TOTAL_INGRESOS) return true;
			if (this.IsTOTAL_EGRESOSNull != original.IsTOTAL_EGRESOSNull) return true;
			if (!this.IsTOTAL_EGRESOSNull && !original.IsTOTAL_EGRESOSNull)
				if (this.TOTAL_EGRESOS != original.TOTAL_EGRESOS) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.CANTIDAD_CUOTAS != original.CANTIDAD_CUOTAS) return true;
			if (this.IsPORCENTAJE_INTERESNull != original.IsPORCENTAJE_INTERESNull) return true;
			if (!this.IsPORCENTAJE_INTERESNull && !original.IsPORCENTAJE_INTERESNull)
				if (this.PORCENTAJE_INTERES != original.PORCENTAJE_INTERES) return true;
			if (this.IsPORCENTAJE_DIARIO_MORANull != original.IsPORCENTAJE_DIARIO_MORANull) return true;
			if (!this.IsPORCENTAJE_DIARIO_MORANull && !original.IsPORCENTAJE_DIARIO_MORANull)
				if (this.PORCENTAJE_DIARIO_MORA != original.PORCENTAJE_DIARIO_MORA) return true;
			if (this.IsPORCENTAJE_GASTO_ADMINISTNull != original.IsPORCENTAJE_GASTO_ADMINISTNull) return true;
			if (!this.IsPORCENTAJE_GASTO_ADMINISTNull && !original.IsPORCENTAJE_GASTO_ADMINISTNull)
				if (this.PORCENTAJE_GASTO_ADMINIST != original.PORCENTAJE_GASTO_ADMINIST) return true;
			if (this.MONTO_CAPITAL_APROBADO != original.MONTO_CAPITAL_APROBADO) return true;
			if (this.IsMONTO_INTERESNull != original.IsMONTO_INTERESNull) return true;
			if (!this.IsMONTO_INTERESNull && !original.IsMONTO_INTERESNull)
				if (this.MONTO_INTERES != original.MONTO_INTERES) return true;
			if (this.IsMONTO_GASTO_ADMINISTRATIVONull != original.IsMONTO_GASTO_ADMINISTRATIVONull) return true;
			if (!this.IsMONTO_GASTO_ADMINISTRATIVONull && !original.IsMONTO_GASTO_ADMINISTRATIVONull)
				if (this.MONTO_GASTO_ADMINISTRATIVO != original.MONTO_GASTO_ADMINISTRATIVO) return true;
			if (this.MONTO_CAPITAL_SOLICITADO != original.MONTO_CAPITAL_SOLICITADO) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.TIPO_CREDITO_ID != original.TIPO_CREDITO_ID) return true;
			if (this.IsFACTURA_CLIENTE_IDNull != original.IsFACTURA_CLIENTE_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_IDNull && !original.IsFACTURA_CLIENTE_IDNull)
				if (this.FACTURA_CLIENTE_ID != original.FACTURA_CLIENTE_ID) return true;
			if (this.IsFACTURA_CLIENTE_AUTON_IDNull != original.IsFACTURA_CLIENTE_AUTON_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_AUTON_IDNull && !original.IsFACTURA_CLIENTE_AUTON_IDNull)
				if (this.FACTURA_CLIENTE_AUTON_ID != original.FACTURA_CLIENTE_AUTON_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.NUMERO_SOLICITUD != original.NUMERO_SOLICITUD) return true;
			if (this.IsORDENES_PAGO_IDNull != original.IsORDENES_PAGO_IDNull) return true;
			if (!this.IsORDENES_PAGO_IDNull && !original.IsORDENES_PAGO_IDNull)
				if (this.ORDENES_PAGO_ID != original.ORDENES_PAGO_ID) return true;
			if (this.IsCTACTE_CAJA_TESORERIA_IDNull != original.IsCTACTE_CAJA_TESORERIA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESORERIA_IDNull && !original.IsCTACTE_CAJA_TESORERIA_IDNull)
				if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.ENTREGA_INICIAL != original.ENTREGA_INICIAL) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.CON_RECURSO != original.CON_RECURSO) return true;
			if (this.DESEMBOLSAR_PARA_CLIENTE != original.DESEMBOLSAR_PARA_CLIENTE) return true;
			if (this.INTERES_INCLUYE_IMPUESTO != original.INTERES_INCLUYE_IMPUESTO) return true;
			if (this.TIPO_FRECUENCIA != original.TIPO_FRECUENCIA) return true;
			if (this.FRECUENCIA != original.FRECUENCIA) return true;
			if (this.ANHO_COMERCIAL != original.ANHO_COMERCIAL) return true;
			if (this.FACTURAR_CONCEPTOS_EN_PAGOS != original.FACTURAR_CONCEPTOS_EN_PAGOS) return true;
			if (this.AUMENTAR_CAPITAL_POR_DESCUENT != original.AUMENTAR_CAPITAL_POR_DESCUENT) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.DIAS_GRACIA != original.DIAS_GRACIA) return true;
			if (this.IsPORCENTAJE_SEGURONull != original.IsPORCENTAJE_SEGURONull) return true;
			if (!this.IsPORCENTAJE_SEGURONull && !original.IsPORCENTAJE_SEGURONull)
				if (this.PORCENTAJE_SEGURO != original.PORCENTAJE_SEGURO) return true;
			if (this.IsPORCENTAJE_CORRETAJENull != original.IsPORCENTAJE_CORRETAJENull) return true;
			if (!this.IsPORCENTAJE_CORRETAJENull && !original.IsPORCENTAJE_CORRETAJENull)
				if (this.PORCENTAJE_CORRETAJE != original.PORCENTAJE_CORRETAJE) return true;
			if (this.IsPORCENTAJE_COMISION_ADMINNull != original.IsPORCENTAJE_COMISION_ADMINNull) return true;
			if (!this.IsPORCENTAJE_COMISION_ADMINNull && !original.IsPORCENTAJE_COMISION_ADMINNull)
				if (this.PORCENTAJE_COMISION_ADMIN != original.PORCENTAJE_COMISION_ADMIN) return true;
			if (this.IsPORCENTAJE_BONIFICACIONNull != original.IsPORCENTAJE_BONIFICACIONNull) return true;
			if (!this.IsPORCENTAJE_BONIFICACIONNull && !original.IsPORCENTAJE_BONIFICACIONNull)
				if (this.PORCENTAJE_BONIFICACION != original.PORCENTAJE_BONIFICACION) return true;
			if (this.IsMONTO_SEGURONull != original.IsMONTO_SEGURONull) return true;
			if (!this.IsMONTO_SEGURONull && !original.IsMONTO_SEGURONull)
				if (this.MONTO_SEGURO != original.MONTO_SEGURO) return true;
			if (this.IsMONTO_CORRETAJENull != original.IsMONTO_CORRETAJENull) return true;
			if (!this.IsMONTO_CORRETAJENull && !original.IsMONTO_CORRETAJENull)
				if (this.MONTO_CORRETAJE != original.MONTO_CORRETAJE) return true;
			if (this.IsMONTO_COMISION_ADMINNull != original.IsMONTO_COMISION_ADMINNull) return true;
			if (!this.IsMONTO_COMISION_ADMINNull && !original.IsMONTO_COMISION_ADMINNull)
				if (this.MONTO_COMISION_ADMIN != original.MONTO_COMISION_ADMIN) return true;
			if (this.IsMONTO_BONIFICACIONNull != original.IsMONTO_BONIFICACIONNull) return true;
			if (!this.IsMONTO_BONIFICACIONNull && !original.IsMONTO_BONIFICACIONNull)
				if (this.MONTO_BONIFICACION != original.MONTO_BONIFICACION) return true;
			if (this.DESCUENTO_CANCELACION_ANTICIP != original.DESCUENTO_CANCELACION_ANTICIP) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.FECHA_PRIMER_VENCIMIENTO != original.FECHA_PRIMER_VENCIMIENTO) return true;
			if (this.MONTO_REDONDEO != original.MONTO_REDONDEO) return true;
			if (this.TIPO_INTERES_ANUAL != original.TIPO_INTERES_ANUAL) return true;
			if (this.CONCEPTO_INCLUYE_IMPUESTO != original.CONCEPTO_INCLUYE_IMPUESTO) return true;
			if (this.MONTO_CAPITAL_ORDEN_COMPRA != original.MONTO_CAPITAL_ORDEN_COMPRA) return true;
			if (this.FACTURAR_BONIFICACION_EN_PAGOS != original.FACTURAR_BONIFICACION_EN_PAGOS) return true;
			if (this.BONIFICACION_INCLUYE_IMPUESTO != original.BONIFICACION_INCLUYE_IMPUESTO) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.IsEGRESO_VARIO_CAJA_IDNull != original.IsEGRESO_VARIO_CAJA_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_IDNull && !original.IsEGRESO_VARIO_CAJA_IDNull)
				if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.APROBACION_1 != original.APROBACION_1) return true;
			if (this.IsAPROBACION_1_USUARIO_IDNull != original.IsAPROBACION_1_USUARIO_IDNull) return true;
			if (!this.IsAPROBACION_1_USUARIO_IDNull && !original.IsAPROBACION_1_USUARIO_IDNull)
				if (this.APROBACION_1_USUARIO_ID != original.APROBACION_1_USUARIO_ID) return true;
			if (this.IsAPROBACION_1_FECHANull != original.IsAPROBACION_1_FECHANull) return true;
			if (!this.IsAPROBACION_1_FECHANull && !original.IsAPROBACION_1_FECHANull)
				if (this.APROBACION_1_FECHA != original.APROBACION_1_FECHA) return true;
			if (this.APROBACION_2 != original.APROBACION_2) return true;
			if (this.IsAPROBACION_2_USUARIO_IDNull != original.IsAPROBACION_2_USUARIO_IDNull) return true;
			if (!this.IsAPROBACION_2_USUARIO_IDNull && !original.IsAPROBACION_2_USUARIO_IDNull)
				if (this.APROBACION_2_USUARIO_ID != original.APROBACION_2_USUARIO_ID) return true;
			if (this.IsAPROBACION_2_FECHANull != original.IsAPROBACION_2_FECHANull) return true;
			if (!this.IsAPROBACION_2_FECHANull && !original.IsAPROBACION_2_FECHANull)
				if (this.APROBACION_2_FECHA != original.APROBACION_2_FECHA) return true;
			if (this.APROBACION_3 != original.APROBACION_3) return true;
			if (this.IsAPROBACION_3_USUARIO_IDNull != original.IsAPROBACION_3_USUARIO_IDNull) return true;
			if (!this.IsAPROBACION_3_USUARIO_IDNull && !original.IsAPROBACION_3_USUARIO_IDNull)
				if (this.APROBACION_3_USUARIO_ID != original.APROBACION_3_USUARIO_ID) return true;
			if (this.IsAPROBACION_3_FECHANull != original.IsAPROBACION_3_FECHANull) return true;
			if (!this.IsAPROBACION_3_FECHANull && !original.IsAPROBACION_3_FECHANull)
				if (this.APROBACION_3_FECHA != original.APROBACION_3_FECHA) return true;
			if (this.IsCANAL_VENTA_IDNull != original.IsCANAL_VENTA_IDNull) return true;
			if (!this.IsCANAL_VENTA_IDNull && !original.IsCANAL_VENTA_IDNull)
				if (this.CANAL_VENTA_ID != original.CANAL_VENTA_ID) return true;
			if (this.FACTURAR_INTERESES != original.FACTURAR_INTERESES) return true;
			if (this.IsPORCENTAJE_OTROSNull != original.IsPORCENTAJE_OTROSNull) return true;
			if (!this.IsPORCENTAJE_OTROSNull && !original.IsPORCENTAJE_OTROSNull)
				if (this.PORCENTAJE_OTROS != original.PORCENTAJE_OTROS) return true;
			if (this.IsMONTO_OTROSNull != original.IsMONTO_OTROSNull) return true;
			if (!this.IsMONTO_OTROSNull && !original.IsMONTO_OTROSNull)
				if (this.MONTO_OTROS != original.MONTO_OTROS) return true;
			if (this.INTERES_COMPUESTO != original.INTERES_COMPUESTO) return true;
			if (this.AFECTA_LINEA_CREDITO != original.AFECTA_LINEA_CREDITO) return true;
			if (this.FACTURAR_CAPITAL != original.FACTURAR_CAPITAL) return true;
			if (this.IsMONTO_DIARIO_MORANull != original.IsMONTO_DIARIO_MORANull) return true;
			if (!this.IsMONTO_DIARIO_MORANull && !original.IsMONTO_DIARIO_MORANull)
				if (this.MONTO_DIARIO_MORA != original.MONTO_DIARIO_MORA) return true;
			if (this.IsFECHA_CANCELACION_ANTICIPADANull != original.IsFECHA_CANCELACION_ANTICIPADANull) return true;
			if (!this.IsFECHA_CANCELACION_ANTICIPADANull && !original.IsFECHA_CANCELACION_ANTICIPADANull)
				if (this.FECHA_CANCELACION_ANTICIPADA != original.FECHA_CANCELACION_ANTICIPADA) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.DESCUENTO_CANC_ANT_APLICADO != original.DESCUENTO_CANC_ANT_APLICADO) return true;
			if (this.DESCUENTO_CANC_ANT_CANT_NO_VEN != original.DESCUENTO_CANC_ANT_CANT_NO_VEN) return true;
			
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
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>PERSONA_GARANTE1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE1_ID</c> column value.</value>
		public decimal PERSONA_GARANTE1_ID
		{
			get
			{
				if(IsPERSONA_GARANTE1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante1_id;
			}
			set
			{
				_persona_garante1_idNull = false;
				_persona_garante1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE1_IDNull
		{
			get { return _persona_garante1_idNull; }
			set { _persona_garante1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE2_ID</c> column value.</value>
		public decimal PERSONA_GARANTE2_ID
		{
			get
			{
				if(IsPERSONA_GARANTE2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante2_id;
			}
			set
			{
				_persona_garante2_idNull = false;
				_persona_garante2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE2_IDNull
		{
			get { return _persona_garante2_idNull; }
			set { _persona_garante2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>FECHA_SOLICITUD</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_SOLICITUD</c> column value.</value>
		public System.DateTime FECHA_SOLICITUD
		{
			get { return _fecha_solicitud; }
			set { _fecha_solicitud = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RETIRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RETIRO</c> column value.</value>
		public System.DateTime FECHA_RETIRO
		{
			get
			{
				if(IsFECHA_RETIRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_retiro;
			}
			set
			{
				_fecha_retiroNull = false;
				_fecha_retiro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RETIRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RETIRONull
		{
			get { return _fecha_retiroNull; }
			set { _fecha_retiroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SEPARACION_BIENES</c> column value.
		/// </summary>
		/// <value>The <c>SEPARACION_BIENES</c> column value.</value>
		public string SEPARACION_BIENES
		{
			get { return _separacion_bienes; }
			set { _separacion_bienes = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_INGRESOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_INGRESOS</c> column value.</value>
		public decimal TOTAL_INGRESOS
		{
			get
			{
				if(IsTOTAL_INGRESOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_ingresos;
			}
			set
			{
				_total_ingresosNull = false;
				_total_ingresos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_INGRESOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_INGRESOSNull
		{
			get { return _total_ingresosNull; }
			set { _total_ingresosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_EGRESOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_EGRESOS</c> column value.</value>
		public decimal TOTAL_EGRESOS
		{
			get
			{
				if(IsTOTAL_EGRESOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_egresos;
			}
			set
			{
				_total_egresosNull = false;
				_total_egresos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_EGRESOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_EGRESOSNull
		{
			get { return _total_egresosNull; }
			set { _total_egresosNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_CUOTAS</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CUOTAS</c> column value.</value>
		public decimal CANTIDAD_CUOTAS
		{
			get { return _cantidad_cuotas; }
			set { _cantidad_cuotas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_INTERES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_INTERES</c> column value.</value>
		public decimal PORCENTAJE_INTERES
		{
			get
			{
				if(IsPORCENTAJE_INTERESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_interes;
			}
			set
			{
				_porcentaje_interesNull = false;
				_porcentaje_interes = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_INTERES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_INTERESNull
		{
			get { return _porcentaje_interesNull; }
			set { _porcentaje_interesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DIARIO_MORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DIARIO_MORA</c> column value.</value>
		public decimal PORCENTAJE_DIARIO_MORA
		{
			get
			{
				if(IsPORCENTAJE_DIARIO_MORANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_diario_mora;
			}
			set
			{
				_porcentaje_diario_moraNull = false;
				_porcentaje_diario_mora = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_DIARIO_MORA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_DIARIO_MORANull
		{
			get { return _porcentaje_diario_moraNull; }
			set { _porcentaje_diario_moraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_GASTO_ADMINIST</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_GASTO_ADMINIST</c> column value.</value>
		public decimal PORCENTAJE_GASTO_ADMINIST
		{
			get
			{
				if(IsPORCENTAJE_GASTO_ADMINISTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_gasto_administ;
			}
			set
			{
				_porcentaje_gasto_administNull = false;
				_porcentaje_gasto_administ = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_GASTO_ADMINIST"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_GASTO_ADMINISTNull
		{
			get { return _porcentaje_gasto_administNull; }
			set { _porcentaje_gasto_administNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CAPITAL_APROBADO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL_APROBADO</c> column value.</value>
		public decimal MONTO_CAPITAL_APROBADO
		{
			get { return _monto_capital_aprobado; }
			set { _monto_capital_aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INTERES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_INTERES</c> column value.</value>
		public decimal MONTO_INTERES
		{
			get
			{
				if(IsMONTO_INTERESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_interes;
			}
			set
			{
				_monto_interesNull = false;
				_monto_interes = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_INTERES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_INTERESNull
		{
			get { return _monto_interesNull; }
			set { _monto_interesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_GASTO_ADMINISTRATIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_GASTO_ADMINISTRATIVO</c> column value.</value>
		public decimal MONTO_GASTO_ADMINISTRATIVO
		{
			get
			{
				if(IsMONTO_GASTO_ADMINISTRATIVONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_gasto_administrativo;
			}
			set
			{
				_monto_gasto_administrativoNull = false;
				_monto_gasto_administrativo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_GASTO_ADMINISTRATIVO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_GASTO_ADMINISTRATIVONull
		{
			get { return _monto_gasto_administrativoNull; }
			set { _monto_gasto_administrativoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CAPITAL_SOLICITADO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL_SOLICITADO</c> column value.</value>
		public decimal MONTO_CAPITAL_SOLICITADO
		{
			get { return _monto_capital_solicitado; }
			set { _monto_capital_solicitado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CREDITO_ID</c> column value.</value>
		public decimal TIPO_CREDITO_ID
		{
			get { return _tipo_credito_id; }
			set { _tipo_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_ID
		{
			get
			{
				if(IsFACTURA_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_cliente_id;
			}
			set
			{
				_factura_cliente_idNull = false;
				_factura_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CLIENTE_IDNull
		{
			get { return _factura_cliente_idNull; }
			set { _factura_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_AUTON_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_AUTON_ID
		{
			get
			{
				if(IsFACTURA_CLIENTE_AUTON_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_cliente_auton_id;
			}
			set
			{
				_factura_cliente_auton_idNull = false;
				_factura_cliente_auton_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CLIENTE_AUTON_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CLIENTE_AUTON_IDNull
		{
			get { return _factura_cliente_auton_idNull; }
			set { _factura_cliente_auton_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_SOLICITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_SOLICITUD</c> column value.</value>
		public string NUMERO_SOLICITUD
		{
			get { return _numero_solicitud; }
			set { _numero_solicitud = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDENES_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDENES_PAGO_ID</c> column value.</value>
		public decimal ORDENES_PAGO_ID
		{
			get
			{
				if(IsORDENES_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ordenes_pago_id;
			}
			set
			{
				_ordenes_pago_idNull = false;
				_ordenes_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDENES_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENES_PAGO_IDNull
		{
			get { return _ordenes_pago_idNull; }
			set { _ordenes_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_ID
		{
			get
			{
				if(IsCTACTE_CAJA_TESORERIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_tesoreria_id;
			}
			set
			{
				_ctacte_caja_tesoreria_idNull = false;
				_ctacte_caja_tesoreria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_TESORERIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_TESORERIA_IDNull
		{
			get { return _ctacte_caja_tesoreria_idNull; }
			set { _ctacte_caja_tesoreria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTREGA_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>ENTREGA_INICIAL</c> column value.</value>
		public decimal ENTREGA_INICIAL
		{
			get { return _entrega_inicial; }
			set { _entrega_inicial = value; }
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
		/// Gets or sets the <c>CON_RECURSO</c> column value.
		/// </summary>
		/// <value>The <c>CON_RECURSO</c> column value.</value>
		public string CON_RECURSO
		{
			get { return _con_recurso; }
			set { _con_recurso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESEMBOLSAR_PARA_CLIENTE</c> column value.
		/// </summary>
		/// <value>The <c>DESEMBOLSAR_PARA_CLIENTE</c> column value.</value>
		public string DESEMBOLSAR_PARA_CLIENTE
		{
			get { return _desembolsar_para_cliente; }
			set { _desembolsar_para_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_INCLUYE_IMPUESTO</c> column value.</value>
		public string INTERES_INCLUYE_IMPUESTO
		{
			get { return _interes_incluye_impuesto; }
			set { _interes_incluye_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_FRECUENCIA</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_FRECUENCIA</c> column value.</value>
		public string TIPO_FRECUENCIA
		{
			get { return _tipo_frecuencia; }
			set { _tipo_frecuencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FRECUENCIA</c> column value.
		/// </summary>
		/// <value>The <c>FRECUENCIA</c> column value.</value>
		public decimal FRECUENCIA
		{
			get { return _frecuencia; }
			set { _frecuencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO_COMERCIAL</c> column value.
		/// </summary>
		/// <value>The <c>ANHO_COMERCIAL</c> column value.</value>
		public string ANHO_COMERCIAL
		{
			get { return _anho_comercial; }
			set { _anho_comercial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_CONCEPTOS_EN_PAGOS</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_CONCEPTOS_EN_PAGOS</c> column value.</value>
		public string FACTURAR_CONCEPTOS_EN_PAGOS
		{
			get { return _facturar_conceptos_en_pagos; }
			set { _facturar_conceptos_en_pagos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUMENTAR_CAPITAL_POR_DESCUENT</c> column value.
		/// </summary>
		/// <value>The <c>AUMENTAR_CAPITAL_POR_DESCUENT</c> column value.</value>
		public string AUMENTAR_CAPITAL_POR_DESCUENT
		{
			get { return _aumentar_capital_por_descuent; }
			set { _aumentar_capital_por_descuent = value; }
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
		/// Gets or sets the <c>DIAS_GRACIA</c> column value.
		/// </summary>
		/// <value>The <c>DIAS_GRACIA</c> column value.</value>
		public decimal DIAS_GRACIA
		{
			get { return _dias_gracia; }
			set { _dias_gracia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_SEGURO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_SEGURO</c> column value.</value>
		public decimal PORCENTAJE_SEGURO
		{
			get
			{
				if(IsPORCENTAJE_SEGURONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_seguro;
			}
			set
			{
				_porcentaje_seguroNull = false;
				_porcentaje_seguro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_SEGURO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_SEGURONull
		{
			get { return _porcentaje_seguroNull; }
			set { _porcentaje_seguroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_CORRETAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_CORRETAJE</c> column value.</value>
		public decimal PORCENTAJE_CORRETAJE
		{
			get
			{
				if(IsPORCENTAJE_CORRETAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_corretaje;
			}
			set
			{
				_porcentaje_corretajeNull = false;
				_porcentaje_corretaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_CORRETAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_CORRETAJENull
		{
			get { return _porcentaje_corretajeNull; }
			set { _porcentaje_corretajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION_ADMIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION_ADMIN</c> column value.</value>
		public decimal PORCENTAJE_COMISION_ADMIN
		{
			get
			{
				if(IsPORCENTAJE_COMISION_ADMINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_comision_admin;
			}
			set
			{
				_porcentaje_comision_adminNull = false;
				_porcentaje_comision_admin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_COMISION_ADMIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_COMISION_ADMINNull
		{
			get { return _porcentaje_comision_adminNull; }
			set { _porcentaje_comision_adminNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_BONIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_BONIFICACION</c> column value.</value>
		public decimal PORCENTAJE_BONIFICACION
		{
			get
			{
				if(IsPORCENTAJE_BONIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_bonificacion;
			}
			set
			{
				_porcentaje_bonificacionNull = false;
				_porcentaje_bonificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_BONIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_BONIFICACIONNull
		{
			get { return _porcentaje_bonificacionNull; }
			set { _porcentaje_bonificacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_SEGURO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_SEGURO</c> column value.</value>
		public decimal MONTO_SEGURO
		{
			get
			{
				if(IsMONTO_SEGURONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_seguro;
			}
			set
			{
				_monto_seguroNull = false;
				_monto_seguro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_SEGURO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_SEGURONull
		{
			get { return _monto_seguroNull; }
			set { _monto_seguroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CORRETAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CORRETAJE</c> column value.</value>
		public decimal MONTO_CORRETAJE
		{
			get
			{
				if(IsMONTO_CORRETAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_corretaje;
			}
			set
			{
				_monto_corretajeNull = false;
				_monto_corretaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CORRETAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CORRETAJENull
		{
			get { return _monto_corretajeNull; }
			set { _monto_corretajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMISION_ADMIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COMISION_ADMIN</c> column value.</value>
		public decimal MONTO_COMISION_ADMIN
		{
			get
			{
				if(IsMONTO_COMISION_ADMINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_comision_admin;
			}
			set
			{
				_monto_comision_adminNull = false;
				_monto_comision_admin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COMISION_ADMIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COMISION_ADMINNull
		{
			get { return _monto_comision_adminNull; }
			set { _monto_comision_adminNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BONIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BONIFICACION</c> column value.</value>
		public decimal MONTO_BONIFICACION
		{
			get
			{
				if(IsMONTO_BONIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bonificacion;
			}
			set
			{
				_monto_bonificacionNull = false;
				_monto_bonificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BONIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BONIFICACIONNull
		{
			get { return _monto_bonificacionNull; }
			set { _monto_bonificacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_CANCELACION_ANTICIP</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_CANCELACION_ANTICIP</c> column value.</value>
		public decimal DESCUENTO_CANCELACION_ANTICIP
		{
			get { return _descuento_cancelacion_anticip; }
			set { _descuento_cancelacion_anticip = value; }
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
		/// Gets or sets the <c>FECHA_PRIMER_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_PRIMER_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_PRIMER_VENCIMIENTO
		{
			get { return _fecha_primer_vencimiento; }
			set { _fecha_primer_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_REDONDEO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_REDONDEO</c> column value.</value>
		public decimal MONTO_REDONDEO
		{
			get { return _monto_redondeo; }
			set { _monto_redondeo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_INTERES_ANUAL</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_INTERES_ANUAL</c> column value.</value>
		public string TIPO_INTERES_ANUAL
		{
			get { return _tipo_interes_anual; }
			set { _tipo_interes_anual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCEPTO_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>CONCEPTO_INCLUYE_IMPUESTO</c> column value.</value>
		public string CONCEPTO_INCLUYE_IMPUESTO
		{
			get { return _concepto_incluye_impuesto; }
			set { _concepto_incluye_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CAPITAL_ORDEN_COMPRA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL_ORDEN_COMPRA</c> column value.</value>
		public decimal MONTO_CAPITAL_ORDEN_COMPRA
		{
			get { return _monto_capital_orden_compra; }
			set { _monto_capital_orden_compra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_BONIFICACION_EN_PAGOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURAR_BONIFICACION_EN_PAGOS</c> column value.</value>
		public string FACTURAR_BONIFICACION_EN_PAGOS
		{
			get { return _facturar_bonificacion_en_pagos; }
			set { _facturar_bonificacion_en_pagos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BONIFICACION_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>BONIFICACION_INCLUYE_IMPUESTO</c> column value.</value>
		public string BONIFICACION_INCLUYE_IMPUESTO
		{
			get { return _bonificacion_incluye_impuesto; }
			set { _bonificacion_incluye_impuesto = value; }
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
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_ID</c> column value.</value>
		public decimal EGRESO_VARIO_CAJA_ID
		{
			get
			{
				if(IsEGRESO_VARIO_CAJA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_vario_caja_id;
			}
			set
			{
				_egreso_vario_caja_idNull = false;
				_egreso_vario_caja_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_VARIO_CAJA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_VARIO_CAJA_IDNull
		{
			get { return _egreso_vario_caja_idNull; }
			set { _egreso_vario_caja_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_1</c> column value.
		/// </summary>
		/// <value>The <c>APROBACION_1</c> column value.</value>
		public string APROBACION_1
		{
			get { return _aprobacion_1; }
			set { _aprobacion_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_1_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_1_USUARIO_ID</c> column value.</value>
		public decimal APROBACION_1_USUARIO_ID
		{
			get
			{
				if(IsAPROBACION_1_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aprobacion_1_usuario_id;
			}
			set
			{
				_aprobacion_1_usuario_idNull = false;
				_aprobacion_1_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APROBACION_1_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPROBACION_1_USUARIO_IDNull
		{
			get { return _aprobacion_1_usuario_idNull; }
			set { _aprobacion_1_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_1_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_1_FECHA</c> column value.</value>
		public System.DateTime APROBACION_1_FECHA
		{
			get
			{
				if(IsAPROBACION_1_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aprobacion_1_fecha;
			}
			set
			{
				_aprobacion_1_fechaNull = false;
				_aprobacion_1_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APROBACION_1_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPROBACION_1_FECHANull
		{
			get { return _aprobacion_1_fechaNull; }
			set { _aprobacion_1_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_2</c> column value.
		/// </summary>
		/// <value>The <c>APROBACION_2</c> column value.</value>
		public string APROBACION_2
		{
			get { return _aprobacion_2; }
			set { _aprobacion_2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_2_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_2_USUARIO_ID</c> column value.</value>
		public decimal APROBACION_2_USUARIO_ID
		{
			get
			{
				if(IsAPROBACION_2_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aprobacion_2_usuario_id;
			}
			set
			{
				_aprobacion_2_usuario_idNull = false;
				_aprobacion_2_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APROBACION_2_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPROBACION_2_USUARIO_IDNull
		{
			get { return _aprobacion_2_usuario_idNull; }
			set { _aprobacion_2_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_2_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_2_FECHA</c> column value.</value>
		public System.DateTime APROBACION_2_FECHA
		{
			get
			{
				if(IsAPROBACION_2_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aprobacion_2_fecha;
			}
			set
			{
				_aprobacion_2_fechaNull = false;
				_aprobacion_2_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APROBACION_2_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPROBACION_2_FECHANull
		{
			get { return _aprobacion_2_fechaNull; }
			set { _aprobacion_2_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_3</c> column value.
		/// </summary>
		/// <value>The <c>APROBACION_3</c> column value.</value>
		public string APROBACION_3
		{
			get { return _aprobacion_3; }
			set { _aprobacion_3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_3_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_3_USUARIO_ID</c> column value.</value>
		public decimal APROBACION_3_USUARIO_ID
		{
			get
			{
				if(IsAPROBACION_3_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aprobacion_3_usuario_id;
			}
			set
			{
				_aprobacion_3_usuario_idNull = false;
				_aprobacion_3_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APROBACION_3_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPROBACION_3_USUARIO_IDNull
		{
			get { return _aprobacion_3_usuario_idNull; }
			set { _aprobacion_3_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBACION_3_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APROBACION_3_FECHA</c> column value.</value>
		public System.DateTime APROBACION_3_FECHA
		{
			get
			{
				if(IsAPROBACION_3_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aprobacion_3_fecha;
			}
			set
			{
				_aprobacion_3_fechaNull = false;
				_aprobacion_3_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APROBACION_3_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPROBACION_3_FECHANull
		{
			get { return _aprobacion_3_fechaNull; }
			set { _aprobacion_3_fechaNull = value; }
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
		/// Gets or sets the <c>FACTURAR_INTERESES</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_INTERESES</c> column value.</value>
		public decimal FACTURAR_INTERESES
		{
			get { return _facturar_intereses; }
			set { _facturar_intereses = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_OTROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_OTROS</c> column value.</value>
		public decimal PORCENTAJE_OTROS
		{
			get
			{
				if(IsPORCENTAJE_OTROSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_otros;
			}
			set
			{
				_porcentaje_otrosNull = false;
				_porcentaje_otros = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_OTROS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_OTROSNull
		{
			get { return _porcentaje_otrosNull; }
			set { _porcentaje_otrosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_OTROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_OTROS</c> column value.</value>
		public decimal MONTO_OTROS
		{
			get
			{
				if(IsMONTO_OTROSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_otros;
			}
			set
			{
				_monto_otrosNull = false;
				_monto_otros = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_OTROS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_OTROSNull
		{
			get { return _monto_otrosNull; }
			set { _monto_otrosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_COMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_COMPUESTO</c> column value.</value>
		public string INTERES_COMPUESTO
		{
			get { return _interes_compuesto; }
			set { _interes_compuesto = value; }
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
		/// Gets or sets the <c>FACTURAR_CAPITAL</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_CAPITAL</c> column value.</value>
		public decimal FACTURAR_CAPITAL
		{
			get { return _facturar_capital; }
			set { _facturar_capital = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DIARIO_MORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DIARIO_MORA</c> column value.</value>
		public decimal MONTO_DIARIO_MORA
		{
			get
			{
				if(IsMONTO_DIARIO_MORANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_diario_mora;
			}
			set
			{
				_monto_diario_moraNull = false;
				_monto_diario_mora = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DIARIO_MORA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DIARIO_MORANull
		{
			get { return _monto_diario_moraNull; }
			set { _monto_diario_moraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CANCELACION_ANTICIPADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CANCELACION_ANTICIPADA</c> column value.</value>
		public System.DateTime FECHA_CANCELACION_ANTICIPADA
		{
			get
			{
				if(IsFECHA_CANCELACION_ANTICIPADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cancelacion_anticipada;
			}
			set
			{
				_fecha_cancelacion_anticipadaNull = false;
				_fecha_cancelacion_anticipada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CANCELACION_ANTICIPADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CANCELACION_ANTICIPADANull
		{
			get { return _fecha_cancelacion_anticipadaNull; }
			set { _fecha_cancelacion_anticipadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get
			{
				if(IsACTIVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_id;
			}
			set
			{
				_activo_idNull = false;
				_activo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_IDNull
		{
			get { return _activo_idNull; }
			set { _activo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_CANC_ANT_APLICADO</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_CANC_ANT_APLICADO</c> column value.</value>
		public decimal DESCUENTO_CANC_ANT_APLICADO
		{
			get { return _descuento_canc_ant_aplicado; }
			set { _descuento_canc_ant_aplicado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_CANC_ANT_CANT_NO_VEN</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_CANC_ANT_CANT_NO_VEN</c> column value.</value>
		public decimal DESCUENTO_CANC_ANT_CANT_NO_VEN
		{
			get { return _descuento_canc_ant_cant_no_ven; }
			set { _descuento_canc_ant_cant_no_ven = value; }
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
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE1_ID=");
			dynStr.Append(IsPERSONA_GARANTE1_IDNull ? (object)"<NULL>" : PERSONA_GARANTE1_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE2_ID=");
			dynStr.Append(IsPERSONA_GARANTE2_IDNull ? (object)"<NULL>" : PERSONA_GARANTE2_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_SOLICITUD=");
			dynStr.Append(FECHA_SOLICITUD);
			dynStr.Append("@CBA@FECHA_RETIRO=");
			dynStr.Append(IsFECHA_RETIRONull ? (object)"<NULL>" : FECHA_RETIRO);
			dynStr.Append("@CBA@SEPARACION_BIENES=");
			dynStr.Append(SEPARACION_BIENES);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@TOTAL_INGRESOS=");
			dynStr.Append(IsTOTAL_INGRESOSNull ? (object)"<NULL>" : TOTAL_INGRESOS);
			dynStr.Append("@CBA@TOTAL_EGRESOS=");
			dynStr.Append(IsTOTAL_EGRESOSNull ? (object)"<NULL>" : TOTAL_EGRESOS);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CANTIDAD_CUOTAS=");
			dynStr.Append(CANTIDAD_CUOTAS);
			dynStr.Append("@CBA@PORCENTAJE_INTERES=");
			dynStr.Append(IsPORCENTAJE_INTERESNull ? (object)"<NULL>" : PORCENTAJE_INTERES);
			dynStr.Append("@CBA@PORCENTAJE_DIARIO_MORA=");
			dynStr.Append(IsPORCENTAJE_DIARIO_MORANull ? (object)"<NULL>" : PORCENTAJE_DIARIO_MORA);
			dynStr.Append("@CBA@PORCENTAJE_GASTO_ADMINIST=");
			dynStr.Append(IsPORCENTAJE_GASTO_ADMINISTNull ? (object)"<NULL>" : PORCENTAJE_GASTO_ADMINIST);
			dynStr.Append("@CBA@MONTO_CAPITAL_APROBADO=");
			dynStr.Append(MONTO_CAPITAL_APROBADO);
			dynStr.Append("@CBA@MONTO_INTERES=");
			dynStr.Append(IsMONTO_INTERESNull ? (object)"<NULL>" : MONTO_INTERES);
			dynStr.Append("@CBA@MONTO_GASTO_ADMINISTRATIVO=");
			dynStr.Append(IsMONTO_GASTO_ADMINISTRATIVONull ? (object)"<NULL>" : MONTO_GASTO_ADMINISTRATIVO);
			dynStr.Append("@CBA@MONTO_CAPITAL_SOLICITADO=");
			dynStr.Append(MONTO_CAPITAL_SOLICITADO);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@TIPO_CREDITO_ID=");
			dynStr.Append(TIPO_CREDITO_ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_AUTON_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_AUTON_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_AUTON_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@NUMERO_SOLICITUD=");
			dynStr.Append(NUMERO_SOLICITUD);
			dynStr.Append("@CBA@ORDENES_PAGO_ID=");
			dynStr.Append(IsORDENES_PAGO_IDNull ? (object)"<NULL>" : ORDENES_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESORERIA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@ENTREGA_INICIAL=");
			dynStr.Append(ENTREGA_INICIAL);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@CON_RECURSO=");
			dynStr.Append(CON_RECURSO);
			dynStr.Append("@CBA@DESEMBOLSAR_PARA_CLIENTE=");
			dynStr.Append(DESEMBOLSAR_PARA_CLIENTE);
			dynStr.Append("@CBA@INTERES_INCLUYE_IMPUESTO=");
			dynStr.Append(INTERES_INCLUYE_IMPUESTO);
			dynStr.Append("@CBA@TIPO_FRECUENCIA=");
			dynStr.Append(TIPO_FRECUENCIA);
			dynStr.Append("@CBA@FRECUENCIA=");
			dynStr.Append(FRECUENCIA);
			dynStr.Append("@CBA@ANHO_COMERCIAL=");
			dynStr.Append(ANHO_COMERCIAL);
			dynStr.Append("@CBA@FACTURAR_CONCEPTOS_EN_PAGOS=");
			dynStr.Append(FACTURAR_CONCEPTOS_EN_PAGOS);
			dynStr.Append("@CBA@AUMENTAR_CAPITAL_POR_DESCUENT=");
			dynStr.Append(AUMENTAR_CAPITAL_POR_DESCUENT);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@DIAS_GRACIA=");
			dynStr.Append(DIAS_GRACIA);
			dynStr.Append("@CBA@PORCENTAJE_SEGURO=");
			dynStr.Append(IsPORCENTAJE_SEGURONull ? (object)"<NULL>" : PORCENTAJE_SEGURO);
			dynStr.Append("@CBA@PORCENTAJE_CORRETAJE=");
			dynStr.Append(IsPORCENTAJE_CORRETAJENull ? (object)"<NULL>" : PORCENTAJE_CORRETAJE);
			dynStr.Append("@CBA@PORCENTAJE_COMISION_ADMIN=");
			dynStr.Append(IsPORCENTAJE_COMISION_ADMINNull ? (object)"<NULL>" : PORCENTAJE_COMISION_ADMIN);
			dynStr.Append("@CBA@PORCENTAJE_BONIFICACION=");
			dynStr.Append(IsPORCENTAJE_BONIFICACIONNull ? (object)"<NULL>" : PORCENTAJE_BONIFICACION);
			dynStr.Append("@CBA@MONTO_SEGURO=");
			dynStr.Append(IsMONTO_SEGURONull ? (object)"<NULL>" : MONTO_SEGURO);
			dynStr.Append("@CBA@MONTO_CORRETAJE=");
			dynStr.Append(IsMONTO_CORRETAJENull ? (object)"<NULL>" : MONTO_CORRETAJE);
			dynStr.Append("@CBA@MONTO_COMISION_ADMIN=");
			dynStr.Append(IsMONTO_COMISION_ADMINNull ? (object)"<NULL>" : MONTO_COMISION_ADMIN);
			dynStr.Append("@CBA@MONTO_BONIFICACION=");
			dynStr.Append(IsMONTO_BONIFICACIONNull ? (object)"<NULL>" : MONTO_BONIFICACION);
			dynStr.Append("@CBA@DESCUENTO_CANCELACION_ANTICIP=");
			dynStr.Append(DESCUENTO_CANCELACION_ANTICIP);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_PRIMER_VENCIMIENTO=");
			dynStr.Append(FECHA_PRIMER_VENCIMIENTO);
			dynStr.Append("@CBA@MONTO_REDONDEO=");
			dynStr.Append(MONTO_REDONDEO);
			dynStr.Append("@CBA@TIPO_INTERES_ANUAL=");
			dynStr.Append(TIPO_INTERES_ANUAL);
			dynStr.Append("@CBA@CONCEPTO_INCLUYE_IMPUESTO=");
			dynStr.Append(CONCEPTO_INCLUYE_IMPUESTO);
			dynStr.Append("@CBA@MONTO_CAPITAL_ORDEN_COMPRA=");
			dynStr.Append(MONTO_CAPITAL_ORDEN_COMPRA);
			dynStr.Append("@CBA@FACTURAR_BONIFICACION_EN_PAGOS=");
			dynStr.Append(FACTURAR_BONIFICACION_EN_PAGOS);
			dynStr.Append("@CBA@BONIFICACION_INCLUYE_IMPUESTO=");
			dynStr.Append(BONIFICACION_INCLUYE_IMPUESTO);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@APROBACION_1=");
			dynStr.Append(APROBACION_1);
			dynStr.Append("@CBA@APROBACION_1_USUARIO_ID=");
			dynStr.Append(IsAPROBACION_1_USUARIO_IDNull ? (object)"<NULL>" : APROBACION_1_USUARIO_ID);
			dynStr.Append("@CBA@APROBACION_1_FECHA=");
			dynStr.Append(IsAPROBACION_1_FECHANull ? (object)"<NULL>" : APROBACION_1_FECHA);
			dynStr.Append("@CBA@APROBACION_2=");
			dynStr.Append(APROBACION_2);
			dynStr.Append("@CBA@APROBACION_2_USUARIO_ID=");
			dynStr.Append(IsAPROBACION_2_USUARIO_IDNull ? (object)"<NULL>" : APROBACION_2_USUARIO_ID);
			dynStr.Append("@CBA@APROBACION_2_FECHA=");
			dynStr.Append(IsAPROBACION_2_FECHANull ? (object)"<NULL>" : APROBACION_2_FECHA);
			dynStr.Append("@CBA@APROBACION_3=");
			dynStr.Append(APROBACION_3);
			dynStr.Append("@CBA@APROBACION_3_USUARIO_ID=");
			dynStr.Append(IsAPROBACION_3_USUARIO_IDNull ? (object)"<NULL>" : APROBACION_3_USUARIO_ID);
			dynStr.Append("@CBA@APROBACION_3_FECHA=");
			dynStr.Append(IsAPROBACION_3_FECHANull ? (object)"<NULL>" : APROBACION_3_FECHA);
			dynStr.Append("@CBA@CANAL_VENTA_ID=");
			dynStr.Append(IsCANAL_VENTA_IDNull ? (object)"<NULL>" : CANAL_VENTA_ID);
			dynStr.Append("@CBA@FACTURAR_INTERESES=");
			dynStr.Append(FACTURAR_INTERESES);
			dynStr.Append("@CBA@PORCENTAJE_OTROS=");
			dynStr.Append(IsPORCENTAJE_OTROSNull ? (object)"<NULL>" : PORCENTAJE_OTROS);
			dynStr.Append("@CBA@MONTO_OTROS=");
			dynStr.Append(IsMONTO_OTROSNull ? (object)"<NULL>" : MONTO_OTROS);
			dynStr.Append("@CBA@INTERES_COMPUESTO=");
			dynStr.Append(INTERES_COMPUESTO);
			dynStr.Append("@CBA@AFECTA_LINEA_CREDITO=");
			dynStr.Append(AFECTA_LINEA_CREDITO);
			dynStr.Append("@CBA@FACTURAR_CAPITAL=");
			dynStr.Append(FACTURAR_CAPITAL);
			dynStr.Append("@CBA@MONTO_DIARIO_MORA=");
			dynStr.Append(IsMONTO_DIARIO_MORANull ? (object)"<NULL>" : MONTO_DIARIO_MORA);
			dynStr.Append("@CBA@FECHA_CANCELACION_ANTICIPADA=");
			dynStr.Append(IsFECHA_CANCELACION_ANTICIPADANull ? (object)"<NULL>" : FECHA_CANCELACION_ANTICIPADA);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@DESCUENTO_CANC_ANT_APLICADO=");
			dynStr.Append(DESCUENTO_CANC_ANT_APLICADO);
			dynStr.Append("@CBA@DESCUENTO_CANC_ANT_CANT_NO_VEN=");
			dynStr.Append(DESCUENTO_CANC_ANT_CANT_NO_VEN);
			return dynStr.ToString();
		}
	} // End of CREDITOSRow_Base class
} // End of namespace
