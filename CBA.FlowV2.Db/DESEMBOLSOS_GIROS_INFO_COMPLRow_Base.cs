// <fileinfo name="DESEMBOLSOS_GIROS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="DESEMBOLSOS_GIROS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>DESEMBOLSOS_GIROS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESEMBOLSOS_GIROS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEMBOLSOS_GIROS_INFO_COMPLRow_Base
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
		private decimal _monto_comision;
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
		private decimal _trans_bancaria_caso_id;
		private bool _trans_bancaria_caso_idNull = true;
		private decimal _trans_bancaria_moneda_dest_id;
		private bool _trans_bancaria_moneda_dest_idNull = true;
		private decimal _trans_bancaria_moneda_dest_cot;
		private bool _trans_bancaria_moneda_dest_cotNull = true;
		private decimal _trans_bancaria_monto_dest;
		private bool _trans_bancaria_monto_destNull = true;
		private decimal _deposito_bancario_id;
		private bool _deposito_bancario_idNull = true;
		private decimal _dep_bancario_caso_id;
		private bool _dep_bancario_caso_idNull = true;
		private decimal _dep_bancario_moneda_id;
		private bool _dep_bancario_moneda_idNull = true;
		private decimal _dep_bancario_moneda_cot;
		private bool _dep_bancario_moneda_cotNull = true;
		private decimal _dep_bancario_total_importe;
		private bool _dep_bancario_total_importeNull = true;
		private decimal _ctacte_red_pago_id;
		private bool _ctacte_red_pago_idNull = true;
		private decimal _ctacte_procesadora_tarjeta_id;
		private bool _ctacte_procesadora_tarjeta_idNull = true;
		private decimal _ctacte_caja_tesoreria_id;
		private bool _ctacte_caja_tesoreria_idNull = true;
		private string _sucursal_nombre;
		private string _autonumeracion_timbrado;
		private string _moneda_nombre;
		private string _valor_nombre;
		private string _banco_nombre;
		private string _red_pago_nombre;
		private string _proc_tarj_nombre;
		private string _cheque_es_diferido;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public DESEMBOLSOS_GIROS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESEMBOLSOS_GIROS_INFO_COMPLRow_Base original)
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
			if (this.MONTO_COMISION != original.MONTO_COMISION) return true;
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
			if (this.IsTRANS_BANCARIA_CASO_IDNull != original.IsTRANS_BANCARIA_CASO_IDNull) return true;
			if (!this.IsTRANS_BANCARIA_CASO_IDNull && !original.IsTRANS_BANCARIA_CASO_IDNull)
				if (this.TRANS_BANCARIA_CASO_ID != original.TRANS_BANCARIA_CASO_ID) return true;
			if (this.IsTRANS_BANCARIA_MONEDA_DEST_IDNull != original.IsTRANS_BANCARIA_MONEDA_DEST_IDNull) return true;
			if (!this.IsTRANS_BANCARIA_MONEDA_DEST_IDNull && !original.IsTRANS_BANCARIA_MONEDA_DEST_IDNull)
				if (this.TRANS_BANCARIA_MONEDA_DEST_ID != original.TRANS_BANCARIA_MONEDA_DEST_ID) return true;
			if (this.IsTRANS_BANCARIA_MONEDA_DEST_COTNull != original.IsTRANS_BANCARIA_MONEDA_DEST_COTNull) return true;
			if (!this.IsTRANS_BANCARIA_MONEDA_DEST_COTNull && !original.IsTRANS_BANCARIA_MONEDA_DEST_COTNull)
				if (this.TRANS_BANCARIA_MONEDA_DEST_COT != original.TRANS_BANCARIA_MONEDA_DEST_COT) return true;
			if (this.IsTRANS_BANCARIA_MONTO_DESTNull != original.IsTRANS_BANCARIA_MONTO_DESTNull) return true;
			if (!this.IsTRANS_BANCARIA_MONTO_DESTNull && !original.IsTRANS_BANCARIA_MONTO_DESTNull)
				if (this.TRANS_BANCARIA_MONTO_DEST != original.TRANS_BANCARIA_MONTO_DEST) return true;
			if (this.IsDEPOSITO_BANCARIO_IDNull != original.IsDEPOSITO_BANCARIO_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_IDNull && !original.IsDEPOSITO_BANCARIO_IDNull)
				if (this.DEPOSITO_BANCARIO_ID != original.DEPOSITO_BANCARIO_ID) return true;
			if (this.IsDEP_BANCARIO_CASO_IDNull != original.IsDEP_BANCARIO_CASO_IDNull) return true;
			if (!this.IsDEP_BANCARIO_CASO_IDNull && !original.IsDEP_BANCARIO_CASO_IDNull)
				if (this.DEP_BANCARIO_CASO_ID != original.DEP_BANCARIO_CASO_ID) return true;
			if (this.IsDEP_BANCARIO_MONEDA_IDNull != original.IsDEP_BANCARIO_MONEDA_IDNull) return true;
			if (!this.IsDEP_BANCARIO_MONEDA_IDNull && !original.IsDEP_BANCARIO_MONEDA_IDNull)
				if (this.DEP_BANCARIO_MONEDA_ID != original.DEP_BANCARIO_MONEDA_ID) return true;
			if (this.IsDEP_BANCARIO_MONEDA_COTNull != original.IsDEP_BANCARIO_MONEDA_COTNull) return true;
			if (!this.IsDEP_BANCARIO_MONEDA_COTNull && !original.IsDEP_BANCARIO_MONEDA_COTNull)
				if (this.DEP_BANCARIO_MONEDA_COT != original.DEP_BANCARIO_MONEDA_COT) return true;
			if (this.IsDEP_BANCARIO_TOTAL_IMPORTENull != original.IsDEP_BANCARIO_TOTAL_IMPORTENull) return true;
			if (!this.IsDEP_BANCARIO_TOTAL_IMPORTENull && !original.IsDEP_BANCARIO_TOTAL_IMPORTENull)
				if (this.DEP_BANCARIO_TOTAL_IMPORTE != original.DEP_BANCARIO_TOTAL_IMPORTE) return true;
			if (this.IsCTACTE_RED_PAGO_IDNull != original.IsCTACTE_RED_PAGO_IDNull) return true;
			if (!this.IsCTACTE_RED_PAGO_IDNull && !original.IsCTACTE_RED_PAGO_IDNull)
				if (this.CTACTE_RED_PAGO_ID != original.CTACTE_RED_PAGO_ID) return true;
			if (this.IsCTACTE_PROCESADORA_TARJETA_IDNull != original.IsCTACTE_PROCESADORA_TARJETA_IDNull) return true;
			if (!this.IsCTACTE_PROCESADORA_TARJETA_IDNull && !original.IsCTACTE_PROCESADORA_TARJETA_IDNull)
				if (this.CTACTE_PROCESADORA_TARJETA_ID != original.CTACTE_PROCESADORA_TARJETA_ID) return true;
			if (this.IsCTACTE_CAJA_TESORERIA_IDNull != original.IsCTACTE_CAJA_TESORERIA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESORERIA_IDNull && !original.IsCTACTE_CAJA_TESORERIA_IDNull)
				if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.AUTONUMERACION_TIMBRADO != original.AUTONUMERACION_TIMBRADO) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.VALOR_NOMBRE != original.VALOR_NOMBRE) return true;
			if (this.BANCO_NOMBRE != original.BANCO_NOMBRE) return true;
			if (this.RED_PAGO_NOMBRE != original.RED_PAGO_NOMBRE) return true;
			if (this.PROC_TARJ_NOMBRE != original.PROC_TARJ_NOMBRE) return true;
			if (this.CHEQUE_ES_DIFERIDO != original.CHEQUE_ES_DIFERIDO) return true;
			
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
		/// Gets or sets the <c>MONTO_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_COMISION</c> column value.</value>
		public decimal MONTO_COMISION
		{
			get { return _monto_comision; }
			set { _monto_comision = value; }
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
		/// Gets or sets the <c>TRANS_BANCARIA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANS_BANCARIA_CASO_ID</c> column value.</value>
		public decimal TRANS_BANCARIA_CASO_ID
		{
			get
			{
				if(IsTRANS_BANCARIA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _trans_bancaria_caso_id;
			}
			set
			{
				_trans_bancaria_caso_idNull = false;
				_trans_bancaria_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANS_BANCARIA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANS_BANCARIA_CASO_IDNull
		{
			get { return _trans_bancaria_caso_idNull; }
			set { _trans_bancaria_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANS_BANCARIA_MONEDA_DEST_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANS_BANCARIA_MONEDA_DEST_ID</c> column value.</value>
		public decimal TRANS_BANCARIA_MONEDA_DEST_ID
		{
			get
			{
				if(IsTRANS_BANCARIA_MONEDA_DEST_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _trans_bancaria_moneda_dest_id;
			}
			set
			{
				_trans_bancaria_moneda_dest_idNull = false;
				_trans_bancaria_moneda_dest_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANS_BANCARIA_MONEDA_DEST_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANS_BANCARIA_MONEDA_DEST_IDNull
		{
			get { return _trans_bancaria_moneda_dest_idNull; }
			set { _trans_bancaria_moneda_dest_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANS_BANCARIA_MONEDA_DEST_COT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANS_BANCARIA_MONEDA_DEST_COT</c> column value.</value>
		public decimal TRANS_BANCARIA_MONEDA_DEST_COT
		{
			get
			{
				if(IsTRANS_BANCARIA_MONEDA_DEST_COTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _trans_bancaria_moneda_dest_cot;
			}
			set
			{
				_trans_bancaria_moneda_dest_cotNull = false;
				_trans_bancaria_moneda_dest_cot = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANS_BANCARIA_MONEDA_DEST_COT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANS_BANCARIA_MONEDA_DEST_COTNull
		{
			get { return _trans_bancaria_moneda_dest_cotNull; }
			set { _trans_bancaria_moneda_dest_cotNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANS_BANCARIA_MONTO_DEST</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANS_BANCARIA_MONTO_DEST</c> column value.</value>
		public decimal TRANS_BANCARIA_MONTO_DEST
		{
			get
			{
				if(IsTRANS_BANCARIA_MONTO_DESTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _trans_bancaria_monto_dest;
			}
			set
			{
				_trans_bancaria_monto_destNull = false;
				_trans_bancaria_monto_dest = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANS_BANCARIA_MONTO_DEST"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANS_BANCARIA_MONTO_DESTNull
		{
			get { return _trans_bancaria_monto_destNull; }
			set { _trans_bancaria_monto_destNull = value; }
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
		/// Gets or sets the <c>DEP_BANCARIO_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEP_BANCARIO_CASO_ID</c> column value.</value>
		public decimal DEP_BANCARIO_CASO_ID
		{
			get
			{
				if(IsDEP_BANCARIO_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dep_bancario_caso_id;
			}
			set
			{
				_dep_bancario_caso_idNull = false;
				_dep_bancario_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEP_BANCARIO_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEP_BANCARIO_CASO_IDNull
		{
			get { return _dep_bancario_caso_idNull; }
			set { _dep_bancario_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEP_BANCARIO_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEP_BANCARIO_MONEDA_ID</c> column value.</value>
		public decimal DEP_BANCARIO_MONEDA_ID
		{
			get
			{
				if(IsDEP_BANCARIO_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dep_bancario_moneda_id;
			}
			set
			{
				_dep_bancario_moneda_idNull = false;
				_dep_bancario_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEP_BANCARIO_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEP_BANCARIO_MONEDA_IDNull
		{
			get { return _dep_bancario_moneda_idNull; }
			set { _dep_bancario_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEP_BANCARIO_MONEDA_COT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEP_BANCARIO_MONEDA_COT</c> column value.</value>
		public decimal DEP_BANCARIO_MONEDA_COT
		{
			get
			{
				if(IsDEP_BANCARIO_MONEDA_COTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dep_bancario_moneda_cot;
			}
			set
			{
				_dep_bancario_moneda_cotNull = false;
				_dep_bancario_moneda_cot = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEP_BANCARIO_MONEDA_COT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEP_BANCARIO_MONEDA_COTNull
		{
			get { return _dep_bancario_moneda_cotNull; }
			set { _dep_bancario_moneda_cotNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEP_BANCARIO_TOTAL_IMPORTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEP_BANCARIO_TOTAL_IMPORTE</c> column value.</value>
		public decimal DEP_BANCARIO_TOTAL_IMPORTE
		{
			get
			{
				if(IsDEP_BANCARIO_TOTAL_IMPORTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dep_bancario_total_importe;
			}
			set
			{
				_dep_bancario_total_importeNull = false;
				_dep_bancario_total_importe = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEP_BANCARIO_TOTAL_IMPORTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEP_BANCARIO_TOTAL_IMPORTENull
		{
			get { return _dep_bancario_total_importeNull; }
			set { _dep_bancario_total_importeNull = value; }
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_TIMBRADO</c> column value.</value>
		public string AUTONUMERACION_TIMBRADO
		{
			get { return _autonumeracion_timbrado; }
			set { _autonumeracion_timbrado = value; }
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
		/// Gets or sets the <c>VALOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>VALOR_NOMBRE</c> column value.</value>
		public string VALOR_NOMBRE
		{
			get { return _valor_nombre; }
			set { _valor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BANCO_NOMBRE</c> column value.</value>
		public string BANCO_NOMBRE
		{
			get { return _banco_nombre; }
			set { _banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RED_PAGO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RED_PAGO_NOMBRE</c> column value.</value>
		public string RED_PAGO_NOMBRE
		{
			get { return _red_pago_nombre; }
			set { _red_pago_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROC_TARJ_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROC_TARJ_NOMBRE</c> column value.</value>
		public string PROC_TARJ_NOMBRE
		{
			get { return _proc_tarj_nombre; }
			set { _proc_tarj_nombre = value; }
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
			dynStr.Append("@CBA@MONTO_COMISION=");
			dynStr.Append(MONTO_COMISION);
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
			dynStr.Append("@CBA@TRANS_BANCARIA_CASO_ID=");
			dynStr.Append(IsTRANS_BANCARIA_CASO_IDNull ? (object)"<NULL>" : TRANS_BANCARIA_CASO_ID);
			dynStr.Append("@CBA@TRANS_BANCARIA_MONEDA_DEST_ID=");
			dynStr.Append(IsTRANS_BANCARIA_MONEDA_DEST_IDNull ? (object)"<NULL>" : TRANS_BANCARIA_MONEDA_DEST_ID);
			dynStr.Append("@CBA@TRANS_BANCARIA_MONEDA_DEST_COT=");
			dynStr.Append(IsTRANS_BANCARIA_MONEDA_DEST_COTNull ? (object)"<NULL>" : TRANS_BANCARIA_MONEDA_DEST_COT);
			dynStr.Append("@CBA@TRANS_BANCARIA_MONTO_DEST=");
			dynStr.Append(IsTRANS_BANCARIA_MONTO_DESTNull ? (object)"<NULL>" : TRANS_BANCARIA_MONTO_DEST);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_ID);
			dynStr.Append("@CBA@DEP_BANCARIO_CASO_ID=");
			dynStr.Append(IsDEP_BANCARIO_CASO_IDNull ? (object)"<NULL>" : DEP_BANCARIO_CASO_ID);
			dynStr.Append("@CBA@DEP_BANCARIO_MONEDA_ID=");
			dynStr.Append(IsDEP_BANCARIO_MONEDA_IDNull ? (object)"<NULL>" : DEP_BANCARIO_MONEDA_ID);
			dynStr.Append("@CBA@DEP_BANCARIO_MONEDA_COT=");
			dynStr.Append(IsDEP_BANCARIO_MONEDA_COTNull ? (object)"<NULL>" : DEP_BANCARIO_MONEDA_COT);
			dynStr.Append("@CBA@DEP_BANCARIO_TOTAL_IMPORTE=");
			dynStr.Append(IsDEP_BANCARIO_TOTAL_IMPORTENull ? (object)"<NULL>" : DEP_BANCARIO_TOTAL_IMPORTE);
			dynStr.Append("@CBA@CTACTE_RED_PAGO_ID=");
			dynStr.Append(IsCTACTE_RED_PAGO_IDNull ? (object)"<NULL>" : CTACTE_RED_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_PROCESADORA_TARJETA_ID=");
			dynStr.Append(IsCTACTE_PROCESADORA_TARJETA_IDNull ? (object)"<NULL>" : CTACTE_PROCESADORA_TARJETA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESORERIA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@AUTONUMERACION_TIMBRADO=");
			dynStr.Append(AUTONUMERACION_TIMBRADO);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@VALOR_NOMBRE=");
			dynStr.Append(VALOR_NOMBRE);
			dynStr.Append("@CBA@BANCO_NOMBRE=");
			dynStr.Append(BANCO_NOMBRE);
			dynStr.Append("@CBA@RED_PAGO_NOMBRE=");
			dynStr.Append(RED_PAGO_NOMBRE);
			dynStr.Append("@CBA@PROC_TARJ_NOMBRE=");
			dynStr.Append(PROC_TARJ_NOMBRE);
			dynStr.Append("@CBA@CHEQUE_ES_DIFERIDO=");
			dynStr.Append(CHEQUE_ES_DIFERIDO);
			return dynStr.ToString();
		}
	} // End of DESEMBOLSOS_GIROS_INFO_COMPLRow_Base class
} // End of namespace
