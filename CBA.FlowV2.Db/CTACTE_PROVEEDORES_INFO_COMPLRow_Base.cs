// <fileinfo name="CTACTE_PROVEEDORES_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTACTE_PROVEEDORES_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROVEEDORES_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _proveedor_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _proveedor_persona_codigo;
		private string _proveedor_persona_nombre;
		private string _proveedor_nombre;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _caso_entidad_id;
		private bool _caso_entidad_idNull = true;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _caso_nro_comprobante;
		private string _flujo_descripcion;
		private string _caso_estado_id;
		private string _nro_comprobante;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private System.DateTime _fecha_insercion;
		private System.DateTime _fecha_vencimiento;
		private string _fecha_vencimiento_texto;
		private System.DateTime _caso_fecha_formulario;
		private bool _caso_fecha_formularioNull = true;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private string _moneda_cadena_decimales;
		private decimal _moneda_cantidad_decimales;
		private decimal _cotizacion_moneda;
		private decimal _ctacte_concepto_id;
		private string _ctacte_concepto_descripcion;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private string _ctacte_valor_nombre;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _movimiento_vario_tesoreria_id;
		private bool _movimiento_vario_tesoreria_idNull = true;
		private decimal _egreso_vario_caja_id;
		private bool _egreso_vario_caja_idNull = true;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private decimal _nc_aplicacion_id;
		private bool _nc_aplicacion_idNull = true;
		private decimal _nc_aplicacion_det_id;
		private bool _nc_aplicacion_det_idNull = true;
		private decimal _orden_pago_valor_id;
		private bool _orden_pago_valor_idNull = true;
		private decimal _calendario_pagos_fc_prov_id;
		private bool _calendario_pagos_fc_prov_idNull = true;
		private decimal _credito_proveedor_det_id;
		private bool _credito_proveedor_det_idNull = true;
		private decimal _credito;
		private decimal _debito;
		private decimal _saldo_credito;
		private bool _saldo_creditoNull = true;
		private string _concepto;
		private decimal _ctacte_proveedor_relac_id;
		private bool _ctacte_proveedor_relac_idNull = true;
		private decimal _retencion_aplicada;
		private bool _retencion_aplicadaNull = true;
		private string _observacion;
		private string _fc_prov_pagar_por_fondo_fijo;
		private decimal _fc_prov_ctacte_fondo_fijo_id;
		private bool _fc_prov_ctacte_fondo_fijo_idNull = true;
		private System.DateTime _fc_prov_fecha_emision;
		private bool _fc_prov_fecha_emisionNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTACTE_PROVEEDORES_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PROVEEDORES_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PROVEEDOR_PERSONA_CODIGO != original.PROVEEDOR_PERSONA_CODIGO) return true;
			if (this.PROVEEDOR_PERSONA_NOMBRE != original.PROVEEDOR_PERSONA_NOMBRE) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsCASO_ENTIDAD_IDNull != original.IsCASO_ENTIDAD_IDNull) return true;
			if (!this.IsCASO_ENTIDAD_IDNull && !original.IsCASO_ENTIDAD_IDNull)
				if (this.CASO_ENTIDAD_ID != original.CASO_ENTIDAD_ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.FECHA_VENCIMIENTO_TEXTO != original.FECHA_VENCIMIENTO_TEXTO) return true;
			if (this.IsCASO_FECHA_FORMULARIONull != original.IsCASO_FECHA_FORMULARIONull) return true;
			if (!this.IsCASO_FECHA_FORMULARIONull && !original.IsCASO_FECHA_FORMULARIONull)
				if (this.CASO_FECHA_FORMULARIO != original.CASO_FECHA_FORMULARIO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CTACTE_CONCEPTO_ID != original.CTACTE_CONCEPTO_ID) return true;
			if (this.CTACTE_CONCEPTO_DESCRIPCION != original.CTACTE_CONCEPTO_DESCRIPCION) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsMOVIMIENTO_VARIO_TESORERIA_IDNull != original.IsMOVIMIENTO_VARIO_TESORERIA_IDNull) return true;
			if (!this.IsMOVIMIENTO_VARIO_TESORERIA_IDNull && !original.IsMOVIMIENTO_VARIO_TESORERIA_IDNull)
				if (this.MOVIMIENTO_VARIO_TESORERIA_ID != original.MOVIMIENTO_VARIO_TESORERIA_ID) return true;
			if (this.IsEGRESO_VARIO_CAJA_IDNull != original.IsEGRESO_VARIO_CAJA_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_IDNull && !original.IsEGRESO_VARIO_CAJA_IDNull)
				if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.IsNC_APLICACION_IDNull != original.IsNC_APLICACION_IDNull) return true;
			if (!this.IsNC_APLICACION_IDNull && !original.IsNC_APLICACION_IDNull)
				if (this.NC_APLICACION_ID != original.NC_APLICACION_ID) return true;
			if (this.IsNC_APLICACION_DET_IDNull != original.IsNC_APLICACION_DET_IDNull) return true;
			if (!this.IsNC_APLICACION_DET_IDNull && !original.IsNC_APLICACION_DET_IDNull)
				if (this.NC_APLICACION_DET_ID != original.NC_APLICACION_DET_ID) return true;
			if (this.IsORDEN_PAGO_VALOR_IDNull != original.IsORDEN_PAGO_VALOR_IDNull) return true;
			if (!this.IsORDEN_PAGO_VALOR_IDNull && !original.IsORDEN_PAGO_VALOR_IDNull)
				if (this.ORDEN_PAGO_VALOR_ID != original.ORDEN_PAGO_VALOR_ID) return true;
			if (this.IsCALENDARIO_PAGOS_FC_PROV_IDNull != original.IsCALENDARIO_PAGOS_FC_PROV_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_FC_PROV_IDNull && !original.IsCALENDARIO_PAGOS_FC_PROV_IDNull)
				if (this.CALENDARIO_PAGOS_FC_PROV_ID != original.CALENDARIO_PAGOS_FC_PROV_ID) return true;
			if (this.IsCREDITO_PROVEEDOR_DET_IDNull != original.IsCREDITO_PROVEEDOR_DET_IDNull) return true;
			if (!this.IsCREDITO_PROVEEDOR_DET_IDNull && !original.IsCREDITO_PROVEEDOR_DET_IDNull)
				if (this.CREDITO_PROVEEDOR_DET_ID != original.CREDITO_PROVEEDOR_DET_ID) return true;
			if (this.CREDITO != original.CREDITO) return true;
			if (this.DEBITO != original.DEBITO) return true;
			if (this.IsSALDO_CREDITONull != original.IsSALDO_CREDITONull) return true;
			if (!this.IsSALDO_CREDITONull && !original.IsSALDO_CREDITONull)
				if (this.SALDO_CREDITO != original.SALDO_CREDITO) return true;
			if (this.CONCEPTO != original.CONCEPTO) return true;
			if (this.IsCTACTE_PROVEEDOR_RELAC_IDNull != original.IsCTACTE_PROVEEDOR_RELAC_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_RELAC_IDNull && !original.IsCTACTE_PROVEEDOR_RELAC_IDNull)
				if (this.CTACTE_PROVEEDOR_RELAC_ID != original.CTACTE_PROVEEDOR_RELAC_ID) return true;
			if (this.IsRETENCION_APLICADANull != original.IsRETENCION_APLICADANull) return true;
			if (!this.IsRETENCION_APLICADANull && !original.IsRETENCION_APLICADANull)
				if (this.RETENCION_APLICADA != original.RETENCION_APLICADA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FC_PROV_PAGAR_POR_FONDO_FIJO != original.FC_PROV_PAGAR_POR_FONDO_FIJO) return true;
			if (this.IsFC_PROV_CTACTE_FONDO_FIJO_IDNull != original.IsFC_PROV_CTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsFC_PROV_CTACTE_FONDO_FIJO_IDNull && !original.IsFC_PROV_CTACTE_FONDO_FIJO_IDNull)
				if (this.FC_PROV_CTACTE_FONDO_FIJO_ID != original.FC_PROV_CTACTE_FONDO_FIJO_ID) return true;
			if (this.IsFC_PROV_FECHA_EMISIONNull != original.IsFC_PROV_FECHA_EMISIONNull) return true;
			if (!this.IsFC_PROV_FECHA_EMISIONNull && !original.IsFC_PROV_FECHA_EMISIONNull)
				if (this.FC_PROV_FECHA_EMISION != original.FC_PROV_FECHA_EMISION) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
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
		/// Gets or sets the <c>PROVEEDOR_PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_PERSONA_CODIGO</c> column value.</value>
		public string PROVEEDOR_PERSONA_CODIGO
		{
			get { return _proveedor_persona_codigo; }
			set { _proveedor_persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_PERSONA_NOMBRE</c> column value.</value>
		public string PROVEEDOR_PERSONA_NOMBRE
		{
			get { return _proveedor_persona_nombre; }
			set { _proveedor_persona_nombre = value; }
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
		/// Gets or sets the <c>CASO_ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ENTIDAD_ID</c> column value.</value>
		public decimal CASO_ENTIDAD_ID
		{
			get
			{
				if(IsCASO_ENTIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_entidad_id;
			}
			set
			{
				_caso_entidad_idNull = false;
				_caso_entidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ENTIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ENTIDAD_IDNull
		{
			get { return _caso_entidad_idNull; }
			set { _caso_entidad_idNull = value; }
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
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
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
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
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
		/// Gets or sets the <c>CASO_FECHA_FORMULARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FECHA_FORMULARIO</c> column value.</value>
		public System.DateTime CASO_FECHA_FORMULARIO
		{
			get
			{
				if(IsCASO_FECHA_FORMULARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_fecha_formulario;
			}
			set
			{
				_caso_fecha_formularioNull = false;
				_caso_fecha_formulario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_FECHA_FORMULARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_FECHA_FORMULARIONull
		{
			get { return _caso_fecha_formularioNull; }
			set { _caso_fecha_formularioNull = value; }
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
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
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
		/// Gets or sets the <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</value>
		public decimal MOVIMIENTO_VARIO_TESORERIA_ID
		{
			get
			{
				if(IsMOVIMIENTO_VARIO_TESORERIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_vario_tesoreria_id;
			}
			set
			{
				_movimiento_vario_tesoreria_idNull = false;
				_movimiento_vario_tesoreria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_VARIO_TESORERIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_VARIO_TESORERIA_IDNull
		{
			get { return _movimiento_vario_tesoreria_idNull; }
			set { _movimiento_vario_tesoreria_idNull = value; }
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
		/// Gets or sets the <c>NC_APLICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_APLICACION_ID</c> column value.</value>
		public decimal NC_APLICACION_ID
		{
			get
			{
				if(IsNC_APLICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_aplicacion_id;
			}
			set
			{
				_nc_aplicacion_idNull = false;
				_nc_aplicacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_APLICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_APLICACION_IDNull
		{
			get { return _nc_aplicacion_idNull; }
			set { _nc_aplicacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_APLICACION_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_APLICACION_DET_ID</c> column value.</value>
		public decimal NC_APLICACION_DET_ID
		{
			get
			{
				if(IsNC_APLICACION_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_aplicacion_det_id;
			}
			set
			{
				_nc_aplicacion_det_idNull = false;
				_nc_aplicacion_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_APLICACION_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_APLICACION_DET_IDNull
		{
			get { return _nc_aplicacion_det_idNull; }
			set { _nc_aplicacion_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_VALOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_VALOR_ID</c> column value.</value>
		public decimal ORDEN_PAGO_VALOR_ID
		{
			get
			{
				if(IsORDEN_PAGO_VALOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_valor_id;
			}
			set
			{
				_orden_pago_valor_idNull = false;
				_orden_pago_valor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_VALOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_VALOR_IDNull
		{
			get { return _orden_pago_valor_idNull; }
			set { _orden_pago_valor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_FC_PROV_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_FC_PROV_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_fc_prov_id;
			}
			set
			{
				_calendario_pagos_fc_prov_idNull = false;
				_calendario_pagos_fc_prov_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_FC_PROV_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_FC_PROV_IDNull
		{
			get { return _calendario_pagos_fc_prov_idNull; }
			set { _calendario_pagos_fc_prov_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO_PROVEEDOR_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</value>
		public decimal CREDITO_PROVEEDOR_DET_ID
		{
			get
			{
				if(IsCREDITO_PROVEEDOR_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito_proveedor_det_id;
			}
			set
			{
				_credito_proveedor_det_idNull = false;
				_credito_proveedor_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO_PROVEEDOR_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITO_PROVEEDOR_DET_IDNull
		{
			get { return _credito_proveedor_det_idNull; }
			set { _credito_proveedor_det_idNull = value; }
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
		/// Gets or sets the <c>SALDO_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_CREDITO</c> column value.</value>
		public decimal SALDO_CREDITO
		{
			get
			{
				if(IsSALDO_CREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_credito;
			}
			set
			{
				_saldo_creditoNull = false;
				_saldo_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_CREDITONull
		{
			get { return _saldo_creditoNull; }
			set { _saldo_creditoNull = value; }
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
		/// Gets or sets the <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_RELAC_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_RELAC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_relac_id;
			}
			set
			{
				_ctacte_proveedor_relac_idNull = false;
				_ctacte_proveedor_relac_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_RELAC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_RELAC_IDNull
		{
			get { return _ctacte_proveedor_relac_idNull; }
			set { _ctacte_proveedor_relac_idNull = value; }
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
		/// Gets or sets the <c>FC_PROV_PAGAR_POR_FONDO_FIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_PROV_PAGAR_POR_FONDO_FIJO</c> column value.</value>
		public string FC_PROV_PAGAR_POR_FONDO_FIJO
		{
			get { return _fc_prov_pagar_por_fondo_fijo; }
			set { _fc_prov_pagar_por_fondo_fijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_PROV_CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_PROV_CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal FC_PROV_CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsFC_PROV_CTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_prov_ctacte_fondo_fijo_id;
			}
			set
			{
				_fc_prov_ctacte_fondo_fijo_idNull = false;
				_fc_prov_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_PROV_CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_PROV_CTACTE_FONDO_FIJO_IDNull
		{
			get { return _fc_prov_ctacte_fondo_fijo_idNull; }
			set { _fc_prov_ctacte_fondo_fijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_PROV_FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_PROV_FECHA_EMISION</c> column value.</value>
		public System.DateTime FC_PROV_FECHA_EMISION
		{
			get
			{
				if(IsFC_PROV_FECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_prov_fecha_emision;
			}
			set
			{
				_fc_prov_fecha_emisionNull = false;
				_fc_prov_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_PROV_FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_PROV_FECHA_EMISIONNull
		{
			get { return _fc_prov_fecha_emisionNull; }
			set { _fc_prov_fecha_emisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_id;
			}
			set
			{
				_centro_costo_idNull = false;
				_centro_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_IDNull
		{
			get { return _centro_costo_idNull; }
			set { _centro_costo_idNull = value; }
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
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_PERSONA_CODIGO=");
			dynStr.Append(PROVEEDOR_PERSONA_CODIGO);
			dynStr.Append("@CBA@PROVEEDOR_PERSONA_NOMBRE=");
			dynStr.Append(PROVEEDOR_PERSONA_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CASO_ENTIDAD_ID=");
			dynStr.Append(IsCASO_ENTIDAD_IDNull ? (object)"<NULL>" : CASO_ENTIDAD_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_TEXTO=");
			dynStr.Append(FECHA_VENCIMIENTO_TEXTO);
			dynStr.Append("@CBA@CASO_FECHA_FORMULARIO=");
			dynStr.Append(IsCASO_FECHA_FORMULARIONull ? (object)"<NULL>" : CASO_FECHA_FORMULARIO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
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
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@MOVIMIENTO_VARIO_TESORERIA_ID=");
			dynStr.Append(IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? (object)"<NULL>" : MOVIMIENTO_VARIO_TESORERIA_ID);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@NC_APLICACION_ID=");
			dynStr.Append(IsNC_APLICACION_IDNull ? (object)"<NULL>" : NC_APLICACION_ID);
			dynStr.Append("@CBA@NC_APLICACION_DET_ID=");
			dynStr.Append(IsNC_APLICACION_DET_IDNull ? (object)"<NULL>" : NC_APLICACION_DET_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_VALOR_ID=");
			dynStr.Append(IsORDEN_PAGO_VALOR_IDNull ? (object)"<NULL>" : ORDEN_PAGO_VALOR_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_FC_PROV_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_FC_PROV_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_FC_PROV_ID);
			dynStr.Append("@CBA@CREDITO_PROVEEDOR_DET_ID=");
			dynStr.Append(IsCREDITO_PROVEEDOR_DET_IDNull ? (object)"<NULL>" : CREDITO_PROVEEDOR_DET_ID);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(DEBITO);
			dynStr.Append("@CBA@SALDO_CREDITO=");
			dynStr.Append(IsSALDO_CREDITONull ? (object)"<NULL>" : SALDO_CREDITO);
			dynStr.Append("@CBA@CONCEPTO=");
			dynStr.Append(CONCEPTO);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_RELAC_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_RELAC_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_RELAC_ID);
			dynStr.Append("@CBA@RETENCION_APLICADA=");
			dynStr.Append(IsRETENCION_APLICADANull ? (object)"<NULL>" : RETENCION_APLICADA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FC_PROV_PAGAR_POR_FONDO_FIJO=");
			dynStr.Append(FC_PROV_PAGAR_POR_FONDO_FIJO);
			dynStr.Append("@CBA@FC_PROV_CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsFC_PROV_CTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : FC_PROV_CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@FC_PROV_FECHA_EMISION=");
			dynStr.Append(IsFC_PROV_FECHA_EMISIONNull ? (object)"<NULL>" : FC_PROV_FECHA_EMISION);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_PROVEEDORES_INFO_COMPLRow_Base class
} // End of namespace
