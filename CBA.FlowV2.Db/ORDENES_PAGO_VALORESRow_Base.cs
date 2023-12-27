// <fileinfo name="ORDENES_PAGO_VALORESRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_VALORESRow"/> that 
	/// represents a record in the <c>ORDENES_PAGO_VALORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_PAGO_VALORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_VALORESRow_Base
	{
		private decimal _id;
		private decimal _orden_pago_id;
		private decimal _ctacte_valor_id;
		private decimal _monto_origen;
		private decimal _cg_ctacte_bancaria_id;
		private bool _cg_ctacte_bancaria_idNull = true;
		private decimal _cg_autonumeracion_id;
		private bool _cg_autonumeracion_idNull = true;
		private string _cg_usar_autonum;
		private string _cg_numero_cheque;
		private string _cg_nombre_emisor;
		private string _cg_nombre_beneficiario;
		private System.DateTime _cg_fecha_emision;
		private bool _cg_fecha_emisionNull = true;
		private System.DateTime _cg_fecha_vencimiento;
		private bool _cg_fecha_vencimientoNull = true;
		private decimal _cg_ctacte_cheque_girado_id;
		private bool _cg_ctacte_cheque_girado_idNull = true;
		private decimal _cr_ctacte_cheque_recibido_id;
		private bool _cr_ctacte_cheque_recibido_idNull = true;
		private decimal _tc_ctacte_tarjeta_credito_id;
		private bool _tc_ctacte_tarjeta_credito_idNull = true;
		private string _tc_cupon;
		private string _observacion;
		private decimal _transferencia_bancaria_id;
		private bool _transferencia_bancaria_idNull = true;
		private decimal _anticipo_proveedor_id;
		private bool _anticipo_proveedor_idNull = true;
		private decimal _nota_credito_proveedor_id;
		private bool _nota_credito_proveedor_idNull = true;
		private decimal _moneda_origen_id;
		private decimal _cotizacion_moneda_origen;
		private decimal _monto_destino;
		private decimal _retencion_emitida_id;
		private bool _retencion_emitida_idNull = true;
		private string _retencion_aux_casos;
		private string _retencion_aux_montos;
		private decimal _ajuste_bancario_id;
		private bool _ajuste_bancario_idNull = true;
		private string _cg_es_diferido;
		private decimal _retencion_tipo_id;
		private bool _retencion_tipo_idNull = true;
		private System.DateTime _retencion_fecha;
		private bool _retencion_fechaNull = true;
		private decimal _cotizacion_moneda_destino;
		private string _nro_comprobante;
		private decimal _debito_autom_ctacte_banc_id;
		private bool _debito_autom_ctacte_banc_idNull = true;
		private string _cg_numero_cta_beneficiario;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_VALORESRow_Base"/> class.
		/// </summary>
		public ORDENES_PAGO_VALORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_PAGO_VALORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.IsCG_CTACTE_BANCARIA_IDNull != original.IsCG_CTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCG_CTACTE_BANCARIA_IDNull && !original.IsCG_CTACTE_BANCARIA_IDNull)
				if (this.CG_CTACTE_BANCARIA_ID != original.CG_CTACTE_BANCARIA_ID) return true;
			if (this.IsCG_AUTONUMERACION_IDNull != original.IsCG_AUTONUMERACION_IDNull) return true;
			if (!this.IsCG_AUTONUMERACION_IDNull && !original.IsCG_AUTONUMERACION_IDNull)
				if (this.CG_AUTONUMERACION_ID != original.CG_AUTONUMERACION_ID) return true;
			if (this.CG_USAR_AUTONUM != original.CG_USAR_AUTONUM) return true;
			if (this.CG_NUMERO_CHEQUE != original.CG_NUMERO_CHEQUE) return true;
			if (this.CG_NOMBRE_EMISOR != original.CG_NOMBRE_EMISOR) return true;
			if (this.CG_NOMBRE_BENEFICIARIO != original.CG_NOMBRE_BENEFICIARIO) return true;
			if (this.IsCG_FECHA_EMISIONNull != original.IsCG_FECHA_EMISIONNull) return true;
			if (!this.IsCG_FECHA_EMISIONNull && !original.IsCG_FECHA_EMISIONNull)
				if (this.CG_FECHA_EMISION != original.CG_FECHA_EMISION) return true;
			if (this.IsCG_FECHA_VENCIMIENTONull != original.IsCG_FECHA_VENCIMIENTONull) return true;
			if (!this.IsCG_FECHA_VENCIMIENTONull && !original.IsCG_FECHA_VENCIMIENTONull)
				if (this.CG_FECHA_VENCIMIENTO != original.CG_FECHA_VENCIMIENTO) return true;
			if (this.IsCG_CTACTE_CHEQUE_GIRADO_IDNull != original.IsCG_CTACTE_CHEQUE_GIRADO_IDNull) return true;
			if (!this.IsCG_CTACTE_CHEQUE_GIRADO_IDNull && !original.IsCG_CTACTE_CHEQUE_GIRADO_IDNull)
				if (this.CG_CTACTE_CHEQUE_GIRADO_ID != original.CG_CTACTE_CHEQUE_GIRADO_ID) return true;
			if (this.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CR_CTACTE_CHEQUE_RECIBIDO_ID != original.CR_CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsTC_CTACTE_TARJETA_CREDITO_IDNull != original.IsTC_CTACTE_TARJETA_CREDITO_IDNull) return true;
			if (!this.IsTC_CTACTE_TARJETA_CREDITO_IDNull && !original.IsTC_CTACTE_TARJETA_CREDITO_IDNull)
				if (this.TC_CTACTE_TARJETA_CREDITO_ID != original.TC_CTACTE_TARJETA_CREDITO_ID) return true;
			if (this.TC_CUPON != original.TC_CUPON) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTRANSFERENCIA_BANCARIA_IDNull != original.IsTRANSFERENCIA_BANCARIA_IDNull) return true;
			if (!this.IsTRANSFERENCIA_BANCARIA_IDNull && !original.IsTRANSFERENCIA_BANCARIA_IDNull)
				if (this.TRANSFERENCIA_BANCARIA_ID != original.TRANSFERENCIA_BANCARIA_ID) return true;
			if (this.IsANTICIPO_PROVEEDOR_IDNull != original.IsANTICIPO_PROVEEDOR_IDNull) return true;
			if (!this.IsANTICIPO_PROVEEDOR_IDNull && !original.IsANTICIPO_PROVEEDOR_IDNull)
				if (this.ANTICIPO_PROVEEDOR_ID != original.ANTICIPO_PROVEEDOR_ID) return true;
			if (this.IsNOTA_CREDITO_PROVEEDOR_IDNull != original.IsNOTA_CREDITO_PROVEEDOR_IDNull) return true;
			if (!this.IsNOTA_CREDITO_PROVEEDOR_IDNull && !original.IsNOTA_CREDITO_PROVEEDOR_IDNull)
				if (this.NOTA_CREDITO_PROVEEDOR_ID != original.NOTA_CREDITO_PROVEEDOR_ID) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.IsRETENCION_EMITIDA_IDNull != original.IsRETENCION_EMITIDA_IDNull) return true;
			if (!this.IsRETENCION_EMITIDA_IDNull && !original.IsRETENCION_EMITIDA_IDNull)
				if (this.RETENCION_EMITIDA_ID != original.RETENCION_EMITIDA_ID) return true;
			if (this.RETENCION_AUX_CASOS != original.RETENCION_AUX_CASOS) return true;
			if (this.RETENCION_AUX_MONTOS != original.RETENCION_AUX_MONTOS) return true;
			if (this.IsAJUSTE_BANCARIO_IDNull != original.IsAJUSTE_BANCARIO_IDNull) return true;
			if (!this.IsAJUSTE_BANCARIO_IDNull && !original.IsAJUSTE_BANCARIO_IDNull)
				if (this.AJUSTE_BANCARIO_ID != original.AJUSTE_BANCARIO_ID) return true;
			if (this.CG_ES_DIFERIDO != original.CG_ES_DIFERIDO) return true;
			if (this.IsRETENCION_TIPO_IDNull != original.IsRETENCION_TIPO_IDNull) return true;
			if (!this.IsRETENCION_TIPO_IDNull && !original.IsRETENCION_TIPO_IDNull)
				if (this.RETENCION_TIPO_ID != original.RETENCION_TIPO_ID) return true;
			if (this.IsRETENCION_FECHANull != original.IsRETENCION_FECHANull) return true;
			if (!this.IsRETENCION_FECHANull && !original.IsRETENCION_FECHANull)
				if (this.RETENCION_FECHA != original.RETENCION_FECHA) return true;
			if (this.COTIZACION_MONEDA_DESTINO != original.COTIZACION_MONEDA_DESTINO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsDEBITO_AUTOM_CTACTE_BANC_IDNull != original.IsDEBITO_AUTOM_CTACTE_BANC_IDNull) return true;
			if (!this.IsDEBITO_AUTOM_CTACTE_BANC_IDNull && !original.IsDEBITO_AUTOM_CTACTE_BANC_IDNull)
				if (this.DEBITO_AUTOM_CTACTE_BANC_ID != original.DEBITO_AUTOM_CTACTE_BANC_ID) return true;
			if (this.CG_NUMERO_CTA_BENEFICIARIO != original.CG_NUMERO_CTA_BENEFICIARIO) return true;
			
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
		/// Gets or sets the <c>ORDEN_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_ID
		{
			get { return _orden_pago_id; }
			set { _orden_pago_id = value; }
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
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get { return _monto_origen; }
			set { _monto_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_CTACTE_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CG_CTACTE_BANCARIA_ID
		{
			get
			{
				if(IsCG_CTACTE_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_ctacte_bancaria_id;
			}
			set
			{
				_cg_ctacte_bancaria_idNull = false;
				_cg_ctacte_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_CTACTE_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_CTACTE_BANCARIA_IDNull
		{
			get { return _cg_ctacte_bancaria_idNull; }
			set { _cg_ctacte_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_AUTONUMERACION_ID</c> column value.</value>
		public decimal CG_AUTONUMERACION_ID
		{
			get
			{
				if(IsCG_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_autonumeracion_id;
			}
			set
			{
				_cg_autonumeracion_idNull = false;
				_cg_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_AUTONUMERACION_IDNull
		{
			get { return _cg_autonumeracion_idNull; }
			set { _cg_autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_USAR_AUTONUM</c> column value.
		/// </summary>
		/// <value>The <c>CG_USAR_AUTONUM</c> column value.</value>
		public string CG_USAR_AUTONUM
		{
			get { return _cg_usar_autonum; }
			set { _cg_usar_autonum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NUMERO_CHEQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NUMERO_CHEQUE</c> column value.</value>
		public string CG_NUMERO_CHEQUE
		{
			get { return _cg_numero_cheque; }
			set { _cg_numero_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NOMBRE_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NOMBRE_EMISOR</c> column value.</value>
		public string CG_NOMBRE_EMISOR
		{
			get { return _cg_nombre_emisor; }
			set { _cg_nombre_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NOMBRE_BENEFICIARIO</c> column value.</value>
		public string CG_NOMBRE_BENEFICIARIO
		{
			get { return _cg_nombre_beneficiario; }
			set { _cg_nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_FECHA_EMISION</c> column value.</value>
		public System.DateTime CG_FECHA_EMISION
		{
			get
			{
				if(IsCG_FECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_fecha_emision;
			}
			set
			{
				_cg_fecha_emisionNull = false;
				_cg_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_FECHA_EMISIONNull
		{
			get { return _cg_fecha_emisionNull; }
			set { _cg_fecha_emisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime CG_FECHA_VENCIMIENTO
		{
			get
			{
				if(IsCG_FECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_fecha_vencimiento;
			}
			set
			{
				_cg_fecha_vencimientoNull = false;
				_cg_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_FECHA_VENCIMIENTONull
		{
			get { return _cg_fecha_vencimientoNull; }
			set { _cg_fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</value>
		public decimal CG_CTACTE_CHEQUE_GIRADO_ID
		{
			get
			{
				if(IsCG_CTACTE_CHEQUE_GIRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_ctacte_cheque_girado_id;
			}
			set
			{
				_cg_ctacte_cheque_girado_idNull = false;
				_cg_ctacte_cheque_girado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_CTACTE_CHEQUE_GIRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_CTACTE_CHEQUE_GIRADO_IDNull
		{
			get { return _cg_ctacte_cheque_girado_idNull; }
			set { _cg_ctacte_cheque_girado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CR_CTACTE_CHEQUE_RECIBIDO_ID
		{
			get
			{
				if(IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cr_ctacte_cheque_recibido_id;
			}
			set
			{
				_cr_ctacte_cheque_recibido_idNull = false;
				_cr_ctacte_cheque_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CR_CTACTE_CHEQUE_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull
		{
			get { return _cr_ctacte_cheque_recibido_idNull; }
			set { _cr_ctacte_cheque_recibido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</value>
		public decimal TC_CTACTE_TARJETA_CREDITO_ID
		{
			get
			{
				if(IsTC_CTACTE_TARJETA_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tc_ctacte_tarjeta_credito_id;
			}
			set
			{
				_tc_ctacte_tarjeta_credito_idNull = false;
				_tc_ctacte_tarjeta_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TC_CTACTE_TARJETA_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTC_CTACTE_TARJETA_CREDITO_IDNull
		{
			get { return _tc_ctacte_tarjeta_credito_idNull; }
			set { _tc_ctacte_tarjeta_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TC_CUPON</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TC_CUPON</c> column value.</value>
		public string TC_CUPON
		{
			get { return _tc_cupon; }
			set { _tc_cupon = value; }
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
		/// Gets or sets the <c>ANTICIPO_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</value>
		public decimal ANTICIPO_PROVEEDOR_ID
		{
			get
			{
				if(IsANTICIPO_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_proveedor_id;
			}
			set
			{
				_anticipo_proveedor_idNull = false;
				_anticipo_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_PROVEEDOR_IDNull
		{
			get { return _anticipo_proveedor_idNull; }
			set { _anticipo_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</value>
		public decimal NOTA_CREDITO_PROVEEDOR_ID
		{
			get
			{
				if(IsNOTA_CREDITO_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nota_credito_proveedor_id;
			}
			set
			{
				_nota_credito_proveedor_idNull = false;
				_nota_credito_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOTA_CREDITO_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOTA_CREDITO_PROVEEDOR_IDNull
		{
			get { return _nota_credito_proveedor_idNull; }
			set { _nota_credito_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get { return _moneda_origen_id; }
			set { _moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get { return _cotizacion_moneda_origen; }
			set { _cotizacion_moneda_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get { return _monto_destino; }
			set { _monto_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_EMITIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_EMITIDA_ID</c> column value.</value>
		public decimal RETENCION_EMITIDA_ID
		{
			get
			{
				if(IsRETENCION_EMITIDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_emitida_id;
			}
			set
			{
				_retencion_emitida_idNull = false;
				_retencion_emitida_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_EMITIDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_EMITIDA_IDNull
		{
			get { return _retencion_emitida_idNull; }
			set { _retencion_emitida_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_AUX_CASOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_AUX_CASOS</c> column value.</value>
		public string RETENCION_AUX_CASOS
		{
			get { return _retencion_aux_casos; }
			set { _retencion_aux_casos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_AUX_MONTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_AUX_MONTOS</c> column value.</value>
		public string RETENCION_AUX_MONTOS
		{
			get { return _retencion_aux_montos; }
			set { _retencion_aux_montos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AJUSTE_BANCARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AJUSTE_BANCARIO_ID</c> column value.</value>
		public decimal AJUSTE_BANCARIO_ID
		{
			get
			{
				if(IsAJUSTE_BANCARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ajuste_bancario_id;
			}
			set
			{
				_ajuste_bancario_idNull = false;
				_ajuste_bancario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AJUSTE_BANCARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAJUSTE_BANCARIO_IDNull
		{
			get { return _ajuste_bancario_idNull; }
			set { _ajuste_bancario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_ES_DIFERIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_ES_DIFERIDO</c> column value.</value>
		public string CG_ES_DIFERIDO
		{
			get { return _cg_es_diferido; }
			set { _cg_es_diferido = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_DESTINO</c> column value.</value>
		public decimal COTIZACION_MONEDA_DESTINO
		{
			get { return _cotizacion_moneda_destino; }
			set { _cotizacion_moneda_destino = value; }
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
		/// Gets or sets the <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</value>
		public decimal DEBITO_AUTOM_CTACTE_BANC_ID
		{
			get
			{
				if(IsDEBITO_AUTOM_CTACTE_BANC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _debito_autom_ctacte_banc_id;
			}
			set
			{
				_debito_autom_ctacte_banc_idNull = false;
				_debito_autom_ctacte_banc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEBITO_AUTOM_CTACTE_BANC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEBITO_AUTOM_CTACTE_BANC_IDNull
		{
			get { return _debito_autom_ctacte_banc_idNull; }
			set { _debito_autom_ctacte_banc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NUMERO_CTA_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NUMERO_CTA_BENEFICIARIO</c> column value.</value>
		public string CG_NUMERO_CTA_BENEFICIARIO
		{
			get { return _cg_numero_cta_beneficiario; }
			set { _cg_numero_cta_beneficiario = value; }
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
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(ORDEN_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@CG_CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCG_CTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CG_CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@CG_AUTONUMERACION_ID=");
			dynStr.Append(IsCG_AUTONUMERACION_IDNull ? (object)"<NULL>" : CG_AUTONUMERACION_ID);
			dynStr.Append("@CBA@CG_USAR_AUTONUM=");
			dynStr.Append(CG_USAR_AUTONUM);
			dynStr.Append("@CBA@CG_NUMERO_CHEQUE=");
			dynStr.Append(CG_NUMERO_CHEQUE);
			dynStr.Append("@CBA@CG_NOMBRE_EMISOR=");
			dynStr.Append(CG_NOMBRE_EMISOR);
			dynStr.Append("@CBA@CG_NOMBRE_BENEFICIARIO=");
			dynStr.Append(CG_NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@CG_FECHA_EMISION=");
			dynStr.Append(IsCG_FECHA_EMISIONNull ? (object)"<NULL>" : CG_FECHA_EMISION);
			dynStr.Append("@CBA@CG_FECHA_VENCIMIENTO=");
			dynStr.Append(IsCG_FECHA_VENCIMIENTONull ? (object)"<NULL>" : CG_FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@CG_CTACTE_CHEQUE_GIRADO_ID=");
			dynStr.Append(IsCG_CTACTE_CHEQUE_GIRADO_IDNull ? (object)"<NULL>" : CG_CTACTE_CHEQUE_GIRADO_ID);
			dynStr.Append("@CBA@CR_CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CR_CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@TC_CTACTE_TARJETA_CREDITO_ID=");
			dynStr.Append(IsTC_CTACTE_TARJETA_CREDITO_IDNull ? (object)"<NULL>" : TC_CTACTE_TARJETA_CREDITO_ID);
			dynStr.Append("@CBA@TC_CUPON=");
			dynStr.Append(TC_CUPON);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TRANSFERENCIA_BANCARIA_ID=");
			dynStr.Append(IsTRANSFERENCIA_BANCARIA_IDNull ? (object)"<NULL>" : TRANSFERENCIA_BANCARIA_ID);
			dynStr.Append("@CBA@ANTICIPO_PROVEEDOR_ID=");
			dynStr.Append(IsANTICIPO_PROVEEDOR_IDNull ? (object)"<NULL>" : ANTICIPO_PROVEEDOR_ID);
			dynStr.Append("@CBA@NOTA_CREDITO_PROVEEDOR_ID=");
			dynStr.Append(IsNOTA_CREDITO_PROVEEDOR_IDNull ? (object)"<NULL>" : NOTA_CREDITO_PROVEEDOR_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			dynStr.Append("@CBA@RETENCION_EMITIDA_ID=");
			dynStr.Append(IsRETENCION_EMITIDA_IDNull ? (object)"<NULL>" : RETENCION_EMITIDA_ID);
			dynStr.Append("@CBA@RETENCION_AUX_CASOS=");
			dynStr.Append(RETENCION_AUX_CASOS);
			dynStr.Append("@CBA@RETENCION_AUX_MONTOS=");
			dynStr.Append(RETENCION_AUX_MONTOS);
			dynStr.Append("@CBA@AJUSTE_BANCARIO_ID=");
			dynStr.Append(IsAJUSTE_BANCARIO_IDNull ? (object)"<NULL>" : AJUSTE_BANCARIO_ID);
			dynStr.Append("@CBA@CG_ES_DIFERIDO=");
			dynStr.Append(CG_ES_DIFERIDO);
			dynStr.Append("@CBA@RETENCION_TIPO_ID=");
			dynStr.Append(IsRETENCION_TIPO_IDNull ? (object)"<NULL>" : RETENCION_TIPO_ID);
			dynStr.Append("@CBA@RETENCION_FECHA=");
			dynStr.Append(IsRETENCION_FECHANull ? (object)"<NULL>" : RETENCION_FECHA);
			dynStr.Append("@CBA@COTIZACION_MONEDA_DESTINO=");
			dynStr.Append(COTIZACION_MONEDA_DESTINO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@DEBITO_AUTOM_CTACTE_BANC_ID=");
			dynStr.Append(IsDEBITO_AUTOM_CTACTE_BANC_IDNull ? (object)"<NULL>" : DEBITO_AUTOM_CTACTE_BANC_ID);
			dynStr.Append("@CBA@CG_NUMERO_CTA_BENEFICIARIO=");
			dynStr.Append(CG_NUMERO_CTA_BENEFICIARIO);
			return dynStr.ToString();
		}
	} // End of ORDENES_PAGO_VALORESRow_Base class
} // End of namespace
