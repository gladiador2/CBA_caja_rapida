// <fileinfo name="CTACTE_PAGOS_PERS_DET_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PERS_DET_INF_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_PAGOS_PERS_DET_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGOS_PERS_DET_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PERS_DET_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _ctacte_pago_persona_id;
		private decimal _ctacte_valor_id;
		private string _ctacte_valor_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _ctacte_plan_desembolso_id;
		private bool _ctacte_plan_desembolso_idNull = true;
		private string _observacion;
		private string _tarjeta_nro;
		private System.DateTime _tarjeta_vencimiento;
		private bool _tarjeta_vencimientoNull = true;
		private string _tarjeta_titular;
		private decimal _deposito_ctacte_bancarias_id;
		private bool _deposito_ctacte_bancarias_idNull = true;
		private string _deposito_nro_boleta;
		private System.DateTime _deposito_fecha;
		private bool _deposito_fechaNull = true;
		private decimal _cheque_ctacte_banco_id;
		private bool _cheque_ctacte_banco_idNull = true;
		private System.DateTime _cheque_fecha_posdatado;
		private bool _cheque_fecha_posdatadoNull = true;
		private System.DateTime _cheque_fecha_vencimiento;
		private bool _cheque_fecha_vencimientoNull = true;
		private string _cheque_nombre_emisor;
		private string _cheque_nombre_beneficiario;
		private string _cheque_nro_cuenta;
		private string _cheque_nro_cheque;
		private string _cheque_de_terceros;
		private string _cheque_documento_emisor;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _ctacte_procesadora_tarjeta_id;
		private bool _ctacte_procesadora_tarjeta_idNull = true;
		private decimal _anticipo_id;
		private bool _anticipo_idNull = true;
		private decimal _transferencia_ctacte_pers_id;
		private bool _transferencia_ctacte_pers_idNull = true;
		private decimal _transferencia_bancaria_id;
		private bool _transferencia_bancaria_idNull = true;
		private decimal _deposito_bancario_id;
		private bool _deposito_bancario_idNull = true;
		private decimal _nota_credito_id;
		private bool _nota_credito_idNull = true;
		private string _retencion_timbrado;
		private string _retencion_nro_comprobante;
		private string _retencion_observacion;
		private decimal _retencion_caso_id;
		private bool _retencion_caso_idNull = true;
		private System.DateTime _retencion_fecha;
		private bool _retencion_fechaNull = true;
		private decimal _retencion_id;
		private bool _retencion_idNull = true;
		private decimal _retencion_detalle_id;
		private bool _retencion_detalle_idNull = true;
		private decimal _retencion_tipo_id;
		private bool _retencion_tipo_idNull = true;
		private decimal _retencion_porcentaje;
		private bool _retencion_porcentajeNull = true;
		private decimal _ctacte_red_pago_id;
		private bool _ctacte_red_pago_idNull = true;
		private string _giro_comprobante;
		private decimal _ctacte_giro_id;
		private bool _ctacte_giro_idNull = true;
		private string _cheque_es_diferido;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERS_DET_INF_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGOS_PERS_DET_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGOS_PERS_DET_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PAGO_PERSONA_ID != original.CTACTE_PAGO_PERSONA_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsCTACTE_PLAN_DESEMBOLSO_IDNull != original.IsCTACTE_PLAN_DESEMBOLSO_IDNull) return true;
			if (!this.IsCTACTE_PLAN_DESEMBOLSO_IDNull && !original.IsCTACTE_PLAN_DESEMBOLSO_IDNull)
				if (this.CTACTE_PLAN_DESEMBOLSO_ID != original.CTACTE_PLAN_DESEMBOLSO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.TARJETA_NRO != original.TARJETA_NRO) return true;
			if (this.IsTARJETA_VENCIMIENTONull != original.IsTARJETA_VENCIMIENTONull) return true;
			if (!this.IsTARJETA_VENCIMIENTONull && !original.IsTARJETA_VENCIMIENTONull)
				if (this.TARJETA_VENCIMIENTO != original.TARJETA_VENCIMIENTO) return true;
			if (this.TARJETA_TITULAR != original.TARJETA_TITULAR) return true;
			if (this.IsDEPOSITO_CTACTE_BANCARIAS_IDNull != original.IsDEPOSITO_CTACTE_BANCARIAS_IDNull) return true;
			if (!this.IsDEPOSITO_CTACTE_BANCARIAS_IDNull && !original.IsDEPOSITO_CTACTE_BANCARIAS_IDNull)
				if (this.DEPOSITO_CTACTE_BANCARIAS_ID != original.DEPOSITO_CTACTE_BANCARIAS_ID) return true;
			if (this.DEPOSITO_NRO_BOLETA != original.DEPOSITO_NRO_BOLETA) return true;
			if (this.IsDEPOSITO_FECHANull != original.IsDEPOSITO_FECHANull) return true;
			if (!this.IsDEPOSITO_FECHANull && !original.IsDEPOSITO_FECHANull)
				if (this.DEPOSITO_FECHA != original.DEPOSITO_FECHA) return true;
			if (this.IsCHEQUE_CTACTE_BANCO_IDNull != original.IsCHEQUE_CTACTE_BANCO_IDNull) return true;
			if (!this.IsCHEQUE_CTACTE_BANCO_IDNull && !original.IsCHEQUE_CTACTE_BANCO_IDNull)
				if (this.CHEQUE_CTACTE_BANCO_ID != original.CHEQUE_CTACTE_BANCO_ID) return true;
			if (this.IsCHEQUE_FECHA_POSDATADONull != original.IsCHEQUE_FECHA_POSDATADONull) return true;
			if (!this.IsCHEQUE_FECHA_POSDATADONull && !original.IsCHEQUE_FECHA_POSDATADONull)
				if (this.CHEQUE_FECHA_POSDATADO != original.CHEQUE_FECHA_POSDATADO) return true;
			if (this.IsCHEQUE_FECHA_VENCIMIENTONull != original.IsCHEQUE_FECHA_VENCIMIENTONull) return true;
			if (!this.IsCHEQUE_FECHA_VENCIMIENTONull && !original.IsCHEQUE_FECHA_VENCIMIENTONull)
				if (this.CHEQUE_FECHA_VENCIMIENTO != original.CHEQUE_FECHA_VENCIMIENTO) return true;
			if (this.CHEQUE_NOMBRE_EMISOR != original.CHEQUE_NOMBRE_EMISOR) return true;
			if (this.CHEQUE_NOMBRE_BENEFICIARIO != original.CHEQUE_NOMBRE_BENEFICIARIO) return true;
			if (this.CHEQUE_NRO_CUENTA != original.CHEQUE_NRO_CUENTA) return true;
			if (this.CHEQUE_NRO_CHEQUE != original.CHEQUE_NRO_CHEQUE) return true;
			if (this.CHEQUE_DE_TERCEROS != original.CHEQUE_DE_TERCEROS) return true;
			if (this.CHEQUE_DOCUMENTO_EMISOR != original.CHEQUE_DOCUMENTO_EMISOR) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsCTACTE_PROCESADORA_TARJETA_IDNull != original.IsCTACTE_PROCESADORA_TARJETA_IDNull) return true;
			if (!this.IsCTACTE_PROCESADORA_TARJETA_IDNull && !original.IsCTACTE_PROCESADORA_TARJETA_IDNull)
				if (this.CTACTE_PROCESADORA_TARJETA_ID != original.CTACTE_PROCESADORA_TARJETA_ID) return true;
			if (this.IsANTICIPO_IDNull != original.IsANTICIPO_IDNull) return true;
			if (!this.IsANTICIPO_IDNull && !original.IsANTICIPO_IDNull)
				if (this.ANTICIPO_ID != original.ANTICIPO_ID) return true;
			if (this.IsTRANSFERENCIA_CTACTE_PERS_IDNull != original.IsTRANSFERENCIA_CTACTE_PERS_IDNull) return true;
			if (!this.IsTRANSFERENCIA_CTACTE_PERS_IDNull && !original.IsTRANSFERENCIA_CTACTE_PERS_IDNull)
				if (this.TRANSFERENCIA_CTACTE_PERS_ID != original.TRANSFERENCIA_CTACTE_PERS_ID) return true;
			if (this.IsTRANSFERENCIA_BANCARIA_IDNull != original.IsTRANSFERENCIA_BANCARIA_IDNull) return true;
			if (!this.IsTRANSFERENCIA_BANCARIA_IDNull && !original.IsTRANSFERENCIA_BANCARIA_IDNull)
				if (this.TRANSFERENCIA_BANCARIA_ID != original.TRANSFERENCIA_BANCARIA_ID) return true;
			if (this.IsDEPOSITO_BANCARIO_IDNull != original.IsDEPOSITO_BANCARIO_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_IDNull && !original.IsDEPOSITO_BANCARIO_IDNull)
				if (this.DEPOSITO_BANCARIO_ID != original.DEPOSITO_BANCARIO_ID) return true;
			if (this.IsNOTA_CREDITO_IDNull != original.IsNOTA_CREDITO_IDNull) return true;
			if (!this.IsNOTA_CREDITO_IDNull && !original.IsNOTA_CREDITO_IDNull)
				if (this.NOTA_CREDITO_ID != original.NOTA_CREDITO_ID) return true;
			if (this.RETENCION_TIMBRADO != original.RETENCION_TIMBRADO) return true;
			if (this.RETENCION_NRO_COMPROBANTE != original.RETENCION_NRO_COMPROBANTE) return true;
			if (this.RETENCION_OBSERVACION != original.RETENCION_OBSERVACION) return true;
			if (this.IsRETENCION_CASO_IDNull != original.IsRETENCION_CASO_IDNull) return true;
			if (!this.IsRETENCION_CASO_IDNull && !original.IsRETENCION_CASO_IDNull)
				if (this.RETENCION_CASO_ID != original.RETENCION_CASO_ID) return true;
			if (this.IsRETENCION_FECHANull != original.IsRETENCION_FECHANull) return true;
			if (!this.IsRETENCION_FECHANull && !original.IsRETENCION_FECHANull)
				if (this.RETENCION_FECHA != original.RETENCION_FECHA) return true;
			if (this.IsRETENCION_IDNull != original.IsRETENCION_IDNull) return true;
			if (!this.IsRETENCION_IDNull && !original.IsRETENCION_IDNull)
				if (this.RETENCION_ID != original.RETENCION_ID) return true;
			if (this.IsRETENCION_DETALLE_IDNull != original.IsRETENCION_DETALLE_IDNull) return true;
			if (!this.IsRETENCION_DETALLE_IDNull && !original.IsRETENCION_DETALLE_IDNull)
				if (this.RETENCION_DETALLE_ID != original.RETENCION_DETALLE_ID) return true;
			if (this.IsRETENCION_TIPO_IDNull != original.IsRETENCION_TIPO_IDNull) return true;
			if (!this.IsRETENCION_TIPO_IDNull && !original.IsRETENCION_TIPO_IDNull)
				if (this.RETENCION_TIPO_ID != original.RETENCION_TIPO_ID) return true;
			if (this.IsRETENCION_PORCENTAJENull != original.IsRETENCION_PORCENTAJENull) return true;
			if (!this.IsRETENCION_PORCENTAJENull && !original.IsRETENCION_PORCENTAJENull)
				if (this.RETENCION_PORCENTAJE != original.RETENCION_PORCENTAJE) return true;
			if (this.IsCTACTE_RED_PAGO_IDNull != original.IsCTACTE_RED_PAGO_IDNull) return true;
			if (!this.IsCTACTE_RED_PAGO_IDNull && !original.IsCTACTE_RED_PAGO_IDNull)
				if (this.CTACTE_RED_PAGO_ID != original.CTACTE_RED_PAGO_ID) return true;
			if (this.GIRO_COMPROBANTE != original.GIRO_COMPROBANTE) return true;
			if (this.IsCTACTE_GIRO_IDNull != original.IsCTACTE_GIRO_IDNull) return true;
			if (!this.IsCTACTE_GIRO_IDNull && !original.IsCTACTE_GIRO_IDNull)
				if (this.CTACTE_GIRO_ID != original.CTACTE_GIRO_ID) return true;
			if (this.CHEQUE_ES_DIFERIDO != original.CHEQUE_ES_DIFERIDO) return true;
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
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_ID
		{
			get { return _ctacte_pago_persona_id; }
			set { _ctacte_pago_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_NOMBRE</c> column value.</value>
		public string CTACTE_VALOR_NOMBRE
		{
			get { return _ctacte_valor_nombre; }
			set { _ctacte_valor_nombre = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</value>
		public decimal CTACTE_PLAN_DESEMBOLSO_ID
		{
			get
			{
				if(IsCTACTE_PLAN_DESEMBOLSO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_plan_desembolso_id;
			}
			set
			{
				_ctacte_plan_desembolso_idNull = false;
				_ctacte_plan_desembolso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PLAN_DESEMBOLSO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PLAN_DESEMBOLSO_IDNull
		{
			get { return _ctacte_plan_desembolso_idNull; }
			set { _ctacte_plan_desembolso_idNull = value; }
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
		/// Gets or sets the <c>TARJETA_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARJETA_NRO</c> column value.</value>
		public string TARJETA_NRO
		{
			get { return _tarjeta_nro; }
			set { _tarjeta_nro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARJETA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARJETA_VENCIMIENTO</c> column value.</value>
		public System.DateTime TARJETA_VENCIMIENTO
		{
			get
			{
				if(IsTARJETA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tarjeta_vencimiento;
			}
			set
			{
				_tarjeta_vencimientoNull = false;
				_tarjeta_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARJETA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARJETA_VENCIMIENTONull
		{
			get { return _tarjeta_vencimientoNull; }
			set { _tarjeta_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARJETA_TITULAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARJETA_TITULAR</c> column value.</value>
		public string TARJETA_TITULAR
		{
			get { return _tarjeta_titular; }
			set { _tarjeta_titular = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</value>
		public decimal DEPOSITO_CTACTE_BANCARIAS_ID
		{
			get
			{
				if(IsDEPOSITO_CTACTE_BANCARIAS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_ctacte_bancarias_id;
			}
			set
			{
				_deposito_ctacte_bancarias_idNull = false;
				_deposito_ctacte_bancarias_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_CTACTE_BANCARIAS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_CTACTE_BANCARIAS_IDNull
		{
			get { return _deposito_ctacte_bancarias_idNull; }
			set { _deposito_ctacte_bancarias_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_NRO_BOLETA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_NRO_BOLETA</c> column value.</value>
		public string DEPOSITO_NRO_BOLETA
		{
			get { return _deposito_nro_boleta; }
			set { _deposito_nro_boleta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_FECHA</c> column value.</value>
		public System.DateTime DEPOSITO_FECHA
		{
			get
			{
				if(IsDEPOSITO_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_fecha;
			}
			set
			{
				_deposito_fechaNull = false;
				_deposito_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_FECHANull
		{
			get { return _deposito_fechaNull; }
			set { _deposito_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_CTACTE_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</value>
		public decimal CHEQUE_CTACTE_BANCO_ID
		{
			get
			{
				if(IsCHEQUE_CTACTE_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_ctacte_banco_id;
			}
			set
			{
				_cheque_ctacte_banco_idNull = false;
				_cheque_ctacte_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_CTACTE_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_CTACTE_BANCO_IDNull
		{
			get { return _cheque_ctacte_banco_idNull; }
			set { _cheque_ctacte_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_FECHA_POSDATADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_FECHA_POSDATADO</c> column value.</value>
		public System.DateTime CHEQUE_FECHA_POSDATADO
		{
			get
			{
				if(IsCHEQUE_FECHA_POSDATADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_fecha_posdatado;
			}
			set
			{
				_cheque_fecha_posdatadoNull = false;
				_cheque_fecha_posdatado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_FECHA_POSDATADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_FECHA_POSDATADONull
		{
			get { return _cheque_fecha_posdatadoNull; }
			set { _cheque_fecha_posdatadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime CHEQUE_FECHA_VENCIMIENTO
		{
			get
			{
				if(IsCHEQUE_FECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_fecha_vencimiento;
			}
			set
			{
				_cheque_fecha_vencimientoNull = false;
				_cheque_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_FECHA_VENCIMIENTONull
		{
			get { return _cheque_fecha_vencimientoNull; }
			set { _cheque_fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_NOMBRE_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_NOMBRE_EMISOR</c> column value.</value>
		public string CHEQUE_NOMBRE_EMISOR
		{
			get { return _cheque_nombre_emisor; }
			set { _cheque_nombre_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_NOMBRE_BENEFICIARIO</c> column value.</value>
		public string CHEQUE_NOMBRE_BENEFICIARIO
		{
			get { return _cheque_nombre_beneficiario; }
			set { _cheque_nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_NRO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_NRO_CUENTA</c> column value.</value>
		public string CHEQUE_NRO_CUENTA
		{
			get { return _cheque_nro_cuenta; }
			set { _cheque_nro_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_NRO_CHEQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_NRO_CHEQUE</c> column value.</value>
		public string CHEQUE_NRO_CHEQUE
		{
			get { return _cheque_nro_cheque; }
			set { _cheque_nro_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_DE_TERCEROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_DE_TERCEROS</c> column value.</value>
		public string CHEQUE_DE_TERCEROS
		{
			get { return _cheque_de_terceros; }
			set { _cheque_de_terceros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_DOCUMENTO_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_DOCUMENTO_EMISOR</c> column value.</value>
		public string CHEQUE_DOCUMENTO_EMISOR
		{
			get { return _cheque_documento_emisor; }
			set { _cheque_documento_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_recibido_id;
			}
			set
			{
				_ctacte_cheque_recibido_idNull = false;
				_ctacte_cheque_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_RECIBIDO_IDNull
		{
			get { return _ctacte_cheque_recibido_idNull; }
			set { _ctacte_cheque_recibido_idNull = value; }
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
		/// Gets or sets the <c>ANTICIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_ID</c> column value.</value>
		public decimal ANTICIPO_ID
		{
			get
			{
				if(IsANTICIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_id;
			}
			set
			{
				_anticipo_idNull = false;
				_anticipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_IDNull
		{
			get { return _anticipo_idNull; }
			set { _anticipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</value>
		public decimal TRANSFERENCIA_CTACTE_PERS_ID
		{
			get
			{
				if(IsTRANSFERENCIA_CTACTE_PERS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_ctacte_pers_id;
			}
			set
			{
				_transferencia_ctacte_pers_idNull = false;
				_transferencia_ctacte_pers_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_CTACTE_PERS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_CTACTE_PERS_IDNull
		{
			get { return _transferencia_ctacte_pers_idNull; }
			set { _transferencia_ctacte_pers_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</value>
		public decimal TRANSFERENCIA_BANCARIA_ID
		{
			get
			{
				if(IsTRANSFERENCIA_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_bancaria_id;
			}
			set
			{
				_transferencia_bancaria_idNull = false;
				_transferencia_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_BANCARIA_IDNull
		{
			get { return _transferencia_bancaria_idNull; }
			set { _transferencia_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_BANCARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_BANCARIO_ID</c> column value.</value>
		public decimal DEPOSITO_BANCARIO_ID
		{
			get
			{
				if(IsDEPOSITO_BANCARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_bancario_id;
			}
			set
			{
				_deposito_bancario_idNull = false;
				_deposito_bancario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_BANCARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_BANCARIO_IDNull
		{
			get { return _deposito_bancario_idNull; }
			set { _deposito_bancario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_ID</c> column value.</value>
		public decimal NOTA_CREDITO_ID
		{
			get
			{
				if(IsNOTA_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nota_credito_id;
			}
			set
			{
				_nota_credito_idNull = false;
				_nota_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOTA_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOTA_CREDITO_IDNull
		{
			get { return _nota_credito_idNull; }
			set { _nota_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_TIMBRADO</c> column value.</value>
		public string RETENCION_TIMBRADO
		{
			get { return _retencion_timbrado; }
			set { _retencion_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_NRO_COMPROBANTE</c> column value.</value>
		public string RETENCION_NRO_COMPROBANTE
		{
			get { return _retencion_nro_comprobante; }
			set { _retencion_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_OBSERVACION</c> column value.</value>
		public string RETENCION_OBSERVACION
		{
			get { return _retencion_observacion; }
			set { _retencion_observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_CASO_ID</c> column value.</value>
		public decimal RETENCION_CASO_ID
		{
			get
			{
				if(IsRETENCION_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_caso_id;
			}
			set
			{
				_retencion_caso_idNull = false;
				_retencion_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_CASO_IDNull
		{
			get { return _retencion_caso_idNull; }
			set { _retencion_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_FECHA</c> column value.</value>
		public System.DateTime RETENCION_FECHA
		{
			get
			{
				if(IsRETENCION_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_fecha;
			}
			set
			{
				_retencion_fechaNull = false;
				_retencion_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_FECHANull
		{
			get { return _retencion_fechaNull; }
			set { _retencion_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_ID</c> column value.</value>
		public decimal RETENCION_ID
		{
			get
			{
				if(IsRETENCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_id;
			}
			set
			{
				_retencion_idNull = false;
				_retencion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_IDNull
		{
			get { return _retencion_idNull; }
			set { _retencion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_DETALLE_ID</c> column value.</value>
		public decimal RETENCION_DETALLE_ID
		{
			get
			{
				if(IsRETENCION_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_detalle_id;
			}
			set
			{
				_retencion_detalle_idNull = false;
				_retencion_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_DETALLE_IDNull
		{
			get { return _retencion_detalle_idNull; }
			set { _retencion_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_TIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_TIPO_ID</c> column value.</value>
		public decimal RETENCION_TIPO_ID
		{
			get
			{
				if(IsRETENCION_TIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_tipo_id;
			}
			set
			{
				_retencion_tipo_idNull = false;
				_retencion_tipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_TIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_TIPO_IDNull
		{
			get { return _retencion_tipo_idNull; }
			set { _retencion_tipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_PORCENTAJE</c> column value.</value>
		public decimal RETENCION_PORCENTAJE
		{
			get
			{
				if(IsRETENCION_PORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_porcentaje;
			}
			set
			{
				_retencion_porcentajeNull = false;
				_retencion_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_PORCENTAJENull
		{
			get { return _retencion_porcentajeNull; }
			set { _retencion_porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RED_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RED_PAGO_ID</c> column value.</value>
		public decimal CTACTE_RED_PAGO_ID
		{
			get
			{
				if(IsCTACTE_RED_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_red_pago_id;
			}
			set
			{
				_ctacte_red_pago_idNull = false;
				_ctacte_red_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RED_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RED_PAGO_IDNull
		{
			get { return _ctacte_red_pago_idNull; }
			set { _ctacte_red_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIRO_COMPROBANTE</c> column value.</value>
		public string GIRO_COMPROBANTE
		{
			get { return _giro_comprobante; }
			set { _giro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_GIRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_GIRO_ID</c> column value.</value>
		public decimal CTACTE_GIRO_ID
		{
			get
			{
				if(IsCTACTE_GIRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_giro_id;
			}
			set
			{
				_ctacte_giro_idNull = false;
				_ctacte_giro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_GIRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_GIRO_IDNull
		{
			get { return _ctacte_giro_idNull; }
			set { _ctacte_giro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_ES_DIFERIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_ES_DIFERIDO</c> column value.</value>
		public string CHEQUE_ES_DIFERIDO
		{
			get { return _cheque_es_diferido; }
			set { _cheque_es_diferido = value; }
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
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_ID=");
			dynStr.Append(CTACTE_PAGO_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@CTACTE_PLAN_DESEMBOLSO_ID=");
			dynStr.Append(IsCTACTE_PLAN_DESEMBOLSO_IDNull ? (object)"<NULL>" : CTACTE_PLAN_DESEMBOLSO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TARJETA_NRO=");
			dynStr.Append(TARJETA_NRO);
			dynStr.Append("@CBA@TARJETA_VENCIMIENTO=");
			dynStr.Append(IsTARJETA_VENCIMIENTONull ? (object)"<NULL>" : TARJETA_VENCIMIENTO);
			dynStr.Append("@CBA@TARJETA_TITULAR=");
			dynStr.Append(TARJETA_TITULAR);
			dynStr.Append("@CBA@DEPOSITO_CTACTE_BANCARIAS_ID=");
			dynStr.Append(IsDEPOSITO_CTACTE_BANCARIAS_IDNull ? (object)"<NULL>" : DEPOSITO_CTACTE_BANCARIAS_ID);
			dynStr.Append("@CBA@DEPOSITO_NRO_BOLETA=");
			dynStr.Append(DEPOSITO_NRO_BOLETA);
			dynStr.Append("@CBA@DEPOSITO_FECHA=");
			dynStr.Append(IsDEPOSITO_FECHANull ? (object)"<NULL>" : DEPOSITO_FECHA);
			dynStr.Append("@CBA@CHEQUE_CTACTE_BANCO_ID=");
			dynStr.Append(IsCHEQUE_CTACTE_BANCO_IDNull ? (object)"<NULL>" : CHEQUE_CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CHEQUE_FECHA_POSDATADO=");
			dynStr.Append(IsCHEQUE_FECHA_POSDATADONull ? (object)"<NULL>" : CHEQUE_FECHA_POSDATADO);
			dynStr.Append("@CBA@CHEQUE_FECHA_VENCIMIENTO=");
			dynStr.Append(IsCHEQUE_FECHA_VENCIMIENTONull ? (object)"<NULL>" : CHEQUE_FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@CHEQUE_NOMBRE_EMISOR=");
			dynStr.Append(CHEQUE_NOMBRE_EMISOR);
			dynStr.Append("@CBA@CHEQUE_NOMBRE_BENEFICIARIO=");
			dynStr.Append(CHEQUE_NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@CHEQUE_NRO_CUENTA=");
			dynStr.Append(CHEQUE_NRO_CUENTA);
			dynStr.Append("@CBA@CHEQUE_NRO_CHEQUE=");
			dynStr.Append(CHEQUE_NRO_CHEQUE);
			dynStr.Append("@CBA@CHEQUE_DE_TERCEROS=");
			dynStr.Append(CHEQUE_DE_TERCEROS);
			dynStr.Append("@CBA@CHEQUE_DOCUMENTO_EMISOR=");
			dynStr.Append(CHEQUE_DOCUMENTO_EMISOR);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_PROCESADORA_TARJETA_ID=");
			dynStr.Append(IsCTACTE_PROCESADORA_TARJETA_IDNull ? (object)"<NULL>" : CTACTE_PROCESADORA_TARJETA_ID);
			dynStr.Append("@CBA@ANTICIPO_ID=");
			dynStr.Append(IsANTICIPO_IDNull ? (object)"<NULL>" : ANTICIPO_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_CTACTE_PERS_ID=");
			dynStr.Append(IsTRANSFERENCIA_CTACTE_PERS_IDNull ? (object)"<NULL>" : TRANSFERENCIA_CTACTE_PERS_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_BANCARIA_ID=");
			dynStr.Append(IsTRANSFERENCIA_BANCARIA_IDNull ? (object)"<NULL>" : TRANSFERENCIA_BANCARIA_ID);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_ID);
			dynStr.Append("@CBA@NOTA_CREDITO_ID=");
			dynStr.Append(IsNOTA_CREDITO_IDNull ? (object)"<NULL>" : NOTA_CREDITO_ID);
			dynStr.Append("@CBA@RETENCION_TIMBRADO=");
			dynStr.Append(RETENCION_TIMBRADO);
			dynStr.Append("@CBA@RETENCION_NRO_COMPROBANTE=");
			dynStr.Append(RETENCION_NRO_COMPROBANTE);
			dynStr.Append("@CBA@RETENCION_OBSERVACION=");
			dynStr.Append(RETENCION_OBSERVACION);
			dynStr.Append("@CBA@RETENCION_CASO_ID=");
			dynStr.Append(IsRETENCION_CASO_IDNull ? (object)"<NULL>" : RETENCION_CASO_ID);
			dynStr.Append("@CBA@RETENCION_FECHA=");
			dynStr.Append(IsRETENCION_FECHANull ? (object)"<NULL>" : RETENCION_FECHA);
			dynStr.Append("@CBA@RETENCION_ID=");
			dynStr.Append(IsRETENCION_IDNull ? (object)"<NULL>" : RETENCION_ID);
			dynStr.Append("@CBA@RETENCION_DETALLE_ID=");
			dynStr.Append(IsRETENCION_DETALLE_IDNull ? (object)"<NULL>" : RETENCION_DETALLE_ID);
			dynStr.Append("@CBA@RETENCION_TIPO_ID=");
			dynStr.Append(IsRETENCION_TIPO_IDNull ? (object)"<NULL>" : RETENCION_TIPO_ID);
			dynStr.Append("@CBA@RETENCION_PORCENTAJE=");
			dynStr.Append(IsRETENCION_PORCENTAJENull ? (object)"<NULL>" : RETENCION_PORCENTAJE);
			dynStr.Append("@CBA@CTACTE_RED_PAGO_ID=");
			dynStr.Append(IsCTACTE_RED_PAGO_IDNull ? (object)"<NULL>" : CTACTE_RED_PAGO_ID);
			dynStr.Append("@CBA@GIRO_COMPROBANTE=");
			dynStr.Append(GIRO_COMPROBANTE);
			dynStr.Append("@CBA@CTACTE_GIRO_ID=");
			dynStr.Append(IsCTACTE_GIRO_IDNull ? (object)"<NULL>" : CTACTE_GIRO_ID);
			dynStr.Append("@CBA@CHEQUE_ES_DIFERIDO=");
			dynStr.Append(CHEQUE_ES_DIFERIDO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGOS_PERS_DET_INF_COMPRow_Base class
} // End of namespace
