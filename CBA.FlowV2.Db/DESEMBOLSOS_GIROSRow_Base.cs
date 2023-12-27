// <fileinfo name="DESEMBOLSOS_GIROSRow_Base.cs">
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
	/// The base class for <see cref="DESEMBOLSOS_GIROSRow"/> that 
	/// represents a record in the <c>DESEMBOLSOS_GIROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESEMBOLSOS_GIROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEMBOLSOS_GIROSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_origen_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _observacion;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto_total;
		private decimal _ctacte_valor_id;
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
		private string _cheque_documento_emisor;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _transferencia_bancaria_id;
		private bool _transferencia_bancaria_idNull = true;
		private decimal _deposito_bancario_id;
		private bool _deposito_bancario_idNull = true;
		private decimal _ctacte_red_pago_id;
		private bool _ctacte_red_pago_idNull = true;
		private decimal _ctacte_procesadora_tarjeta_id;
		private bool _ctacte_procesadora_tarjeta_idNull = true;
		private decimal _monto_valor;
		private bool _monto_valorNull = true;
		private decimal _ctacte_caja_tesoreria_id;
		private bool _ctacte_caja_tesoreria_idNull = true;
		private string _cheque_es_diferido;
		private decimal _monto_comision;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROSRow_Base"/> class.
		/// </summary>
		public DESEMBOLSOS_GIROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESEMBOLSOS_GIROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
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
			if (this.CHEQUE_DOCUMENTO_EMISOR != original.CHEQUE_DOCUMENTO_EMISOR) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsTRANSFERENCIA_BANCARIA_IDNull != original.IsTRANSFERENCIA_BANCARIA_IDNull) return true;
			if (!this.IsTRANSFERENCIA_BANCARIA_IDNull && !original.IsTRANSFERENCIA_BANCARIA_IDNull)
				if (this.TRANSFERENCIA_BANCARIA_ID != original.TRANSFERENCIA_BANCARIA_ID) return true;
			if (this.IsDEPOSITO_BANCARIO_IDNull != original.IsDEPOSITO_BANCARIO_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_IDNull && !original.IsDEPOSITO_BANCARIO_IDNull)
				if (this.DEPOSITO_BANCARIO_ID != original.DEPOSITO_BANCARIO_ID) return true;
			if (this.IsCTACTE_RED_PAGO_IDNull != original.IsCTACTE_RED_PAGO_IDNull) return true;
			if (!this.IsCTACTE_RED_PAGO_IDNull && !original.IsCTACTE_RED_PAGO_IDNull)
				if (this.CTACTE_RED_PAGO_ID != original.CTACTE_RED_PAGO_ID) return true;
			if (this.IsCTACTE_PROCESADORA_TARJETA_IDNull != original.IsCTACTE_PROCESADORA_TARJETA_IDNull) return true;
			if (!this.IsCTACTE_PROCESADORA_TARJETA_IDNull && !original.IsCTACTE_PROCESADORA_TARJETA_IDNull)
				if (this.CTACTE_PROCESADORA_TARJETA_ID != original.CTACTE_PROCESADORA_TARJETA_ID) return true;
			if (this.IsMONTO_VALORNull != original.IsMONTO_VALORNull) return true;
			if (!this.IsMONTO_VALORNull && !original.IsMONTO_VALORNull)
				if (this.MONTO_VALOR != original.MONTO_VALOR) return true;
			if (this.IsCTACTE_CAJA_TESORERIA_IDNull != original.IsCTACTE_CAJA_TESORERIA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESORERIA_IDNull && !original.IsCTACTE_CAJA_TESORERIA_IDNull)
				if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CHEQUE_ES_DIFERIDO != original.CHEQUE_ES_DIFERIDO) return true;
			if (this.MONTO_COMISION != original.MONTO_COMISION) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
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
		/// Gets or sets the <c>MONTO_VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_VALOR</c> column value.</value>
		public decimal MONTO_VALOR
		{
			get
			{
				if(IsMONTO_VALORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_valor;
			}
			set
			{
				_monto_valorNull = false;
				_monto_valor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_VALOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_VALORNull
		{
			get { return _monto_valorNull; }
			set { _monto_valorNull = value; }
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
		/// Gets or sets the <c>MONTO_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_COMISION</c> column value.</value>
		public decimal MONTO_COMISION
		{
			get { return _monto_comision; }
			set { _monto_comision = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
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
			dynStr.Append("@CBA@CHEQUE_DOCUMENTO_EMISOR=");
			dynStr.Append(CHEQUE_DOCUMENTO_EMISOR);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_BANCARIA_ID=");
			dynStr.Append(IsTRANSFERENCIA_BANCARIA_IDNull ? (object)"<NULL>" : TRANSFERENCIA_BANCARIA_ID);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_ID);
			dynStr.Append("@CBA@CTACTE_RED_PAGO_ID=");
			dynStr.Append(IsCTACTE_RED_PAGO_IDNull ? (object)"<NULL>" : CTACTE_RED_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_PROCESADORA_TARJETA_ID=");
			dynStr.Append(IsCTACTE_PROCESADORA_TARJETA_IDNull ? (object)"<NULL>" : CTACTE_PROCESADORA_TARJETA_ID);
			dynStr.Append("@CBA@MONTO_VALOR=");
			dynStr.Append(IsMONTO_VALORNull ? (object)"<NULL>" : MONTO_VALOR);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESORERIA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CHEQUE_ES_DIFERIDO=");
			dynStr.Append(CHEQUE_ES_DIFERIDO);
			dynStr.Append("@CBA@MONTO_COMISION=");
			dynStr.Append(MONTO_COMISION);
			return dynStr.ToString();
		}
	} // End of DESEMBOLSOS_GIROSRow_Base class
} // End of namespace
