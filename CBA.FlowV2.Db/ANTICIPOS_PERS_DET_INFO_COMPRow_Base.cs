// <fileinfo name="ANTICIPOS_PERS_DET_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_PERS_DET_INFO_COMPRow"/> that 
	/// represents a record in the <c>ANTICIPOS_PERS_DET_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ANTICIPOS_PERS_DET_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_PERS_DET_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _anticipo_persona_id;
		private decimal _ctacte_valor_id;
		private string _ctacte_valor_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private bool _montoNull = true;
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
		private decimal _transferencia_bancaria_id;
		private bool _transferencia_bancaria_idNull = true;
		private decimal _deposito_bancario_id;
		private bool _deposito_bancario_idNull = true;
		private string _cheque_es_diferido;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_PERS_DET_INFO_COMPRow_Base"/> class.
		/// </summary>
		public ANTICIPOS_PERS_DET_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ANTICIPOS_PERS_DET_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ANTICIPO_PERSONA_ID != original.ANTICIPO_PERSONA_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
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
			if (this.IsTRANSFERENCIA_BANCARIA_IDNull != original.IsTRANSFERENCIA_BANCARIA_IDNull) return true;
			if (!this.IsTRANSFERENCIA_BANCARIA_IDNull && !original.IsTRANSFERENCIA_BANCARIA_IDNull)
				if (this.TRANSFERENCIA_BANCARIA_ID != original.TRANSFERENCIA_BANCARIA_ID) return true;
			if (this.IsDEPOSITO_BANCARIO_IDNull != original.IsDEPOSITO_BANCARIO_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_IDNull && !original.IsDEPOSITO_BANCARIO_IDNull)
				if (this.DEPOSITO_BANCARIO_ID != original.DEPOSITO_BANCARIO_ID) return true;
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
		/// Gets or sets the <c>ANTICIPO_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ANTICIPO_PERSONA_ID</c> column value.</value>
		public decimal ANTICIPO_PERSONA_ID
		{
			get { return _anticipo_persona_id; }
			set { _anticipo_persona_id = value; }
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
			dynStr.Append("@CBA@ANTICIPO_PERSONA_ID=");
			dynStr.Append(ANTICIPO_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
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
			dynStr.Append("@CBA@TRANSFERENCIA_BANCARIA_ID=");
			dynStr.Append(IsTRANSFERENCIA_BANCARIA_IDNull ? (object)"<NULL>" : TRANSFERENCIA_BANCARIA_ID);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_ID);
			dynStr.Append("@CBA@CHEQUE_ES_DIFERIDO=");
			dynStr.Append(CHEQUE_ES_DIFERIDO);
			return dynStr.ToString();
		}
	} // End of ANTICIPOS_PERS_DET_INFO_COMPRow_Base class
} // End of namespace
