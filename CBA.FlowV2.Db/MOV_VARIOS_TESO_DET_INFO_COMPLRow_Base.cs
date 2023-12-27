// <fileinfo name="MOV_VARIOS_TESO_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="MOV_VARIOS_TESO_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>MOV_VARIOS_TESO_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MOV_VARIOS_TESO_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOV_VARIOS_TESO_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _movimiento_vario_id;
		private decimal _ctacte_valor_id;
		private string _ctacte_valor_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private decimal _ctacte_banco_id;
		private bool _ctacte_banco_idNull = true;
		private string _numero_cuenta;
		private string _numero_cheque;
		private string _nombre_emisor;
		private string _nombre_beneficiario;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private System.DateTime _fecha_posdatado;
		private bool _fecha_posdatadoNull = true;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private string _cheque_de_terceros;
		private string _ctacte_banco_nombre;
		private string _ctacte_banco_abreviatura;
		private string _observacion;
		private decimal _ctacte_bancaria_id;
		private bool _ctacte_bancaria_idNull = true;
		private string _usar_chequera;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private decimal _ctacte_cheque_girado_id;
		private bool _ctacte_cheque_girado_idNull = true;
		private string _es_diferido;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOV_VARIOS_TESO_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public MOV_VARIOS_TESO_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MOV_VARIOS_TESO_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.MOVIMIENTO_VARIO_ID != original.MOVIMIENTO_VARIO_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsCTACTE_BANCO_IDNull != original.IsCTACTE_BANCO_IDNull) return true;
			if (!this.IsCTACTE_BANCO_IDNull && !original.IsCTACTE_BANCO_IDNull)
				if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.NUMERO_CUENTA != original.NUMERO_CUENTA) return true;
			if (this.NUMERO_CHEQUE != original.NUMERO_CHEQUE) return true;
			if (this.NOMBRE_EMISOR != original.NOMBRE_EMISOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsFECHA_POSDATADONull != original.IsFECHA_POSDATADONull) return true;
			if (!this.IsFECHA_POSDATADONull && !original.IsFECHA_POSDATADONull)
				if (this.FECHA_POSDATADO != original.FECHA_POSDATADO) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.CHEQUE_DE_TERCEROS != original.CHEQUE_DE_TERCEROS) return true;
			if (this.CTACTE_BANCO_NOMBRE != original.CTACTE_BANCO_NOMBRE) return true;
			if (this.CTACTE_BANCO_ABREVIATURA != original.CTACTE_BANCO_ABREVIATURA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTE_BANCARIA_IDNull != original.IsCTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_IDNull && !original.IsCTACTE_BANCARIA_IDNull)
				if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.USAR_CHEQUERA != original.USAR_CHEQUERA) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.IsCTACTE_CHEQUE_GIRADO_IDNull != original.IsCTACTE_CHEQUE_GIRADO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_GIRADO_IDNull && !original.IsCTACTE_CHEQUE_GIRADO_IDNull)
				if (this.CTACTE_CHEQUE_GIRADO_ID != original.CTACTE_CHEQUE_GIRADO_ID) return true;
			if (this.ES_DIFERIDO != original.ES_DIFERIDO) return true;
			
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
		/// Gets or sets the <c>MOVIMIENTO_VARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_VARIO_ID</c> column value.</value>
		public decimal MOVIMIENTO_VARIO_ID
		{
			get { return _movimiento_vario_id; }
			set { _movimiento_vario_id = value; }
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
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get
			{
				if(IsCTACTE_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banco_id;
			}
			set
			{
				_ctacte_banco_idNull = false;
				_ctacte_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCO_IDNull
		{
			get { return _ctacte_banco_idNull; }
			set { _ctacte_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA</c> column value.</value>
		public string NUMERO_CUENTA
		{
			get { return _numero_cuenta; }
			set { _numero_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CHEQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CHEQUE</c> column value.</value>
		public string NUMERO_CHEQUE
		{
			get { return _numero_cheque; }
			set { _numero_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_EMISOR</c> column value.</value>
		public string NOMBRE_EMISOR
		{
			get { return _nombre_emisor; }
			set { _nombre_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_BENEFICIARIO</c> column value.</value>
		public string NOMBRE_BENEFICIARIO
		{
			get { return _nombre_beneficiario; }
			set { _nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get
			{
				if(IsFECHA_CREACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion;
			}
			set
			{
				_fecha_creacionNull = false;
				_fecha_creacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACIONNull
		{
			get { return _fecha_creacionNull; }
			set { _fecha_creacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_POSDATADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_POSDATADO</c> column value.</value>
		public System.DateTime FECHA_POSDATADO
		{
			get
			{
				if(IsFECHA_POSDATADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_posdatado;
			}
			set
			{
				_fecha_posdatadoNull = false;
				_fecha_posdatado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_POSDATADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_POSDATADONull
		{
			get { return _fecha_posdatadoNull; }
			set { _fecha_posdatadoNull = value; }
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
		/// Gets or sets the <c>CTACTE_BANCO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_NOMBRE</c> column value.</value>
		public string CTACTE_BANCO_NOMBRE
		{
			get { return _ctacte_banco_nombre; }
			set { _ctacte_banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ABREVIATURA</c> column value.</value>
		public string CTACTE_BANCO_ABREVIATURA
		{
			get { return _ctacte_banco_abreviatura; }
			set { _ctacte_banco_abreviatura = value; }
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
		/// Gets or sets the <c>USAR_CHEQUERA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USAR_CHEQUERA</c> column value.</value>
		public string USAR_CHEQUERA
		{
			get { return _usar_chequera; }
			set { _usar_chequera = value; }
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
		/// Gets or sets the <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_GIRADO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_GIRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_girado_id;
			}
			set
			{
				_ctacte_cheque_girado_idNull = false;
				_ctacte_cheque_girado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_GIRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_GIRADO_IDNull
		{
			get { return _ctacte_cheque_girado_idNull; }
			set { _ctacte_cheque_girado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_DIFERIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_DIFERIDO</c> column value.</value>
		public string ES_DIFERIDO
		{
			get { return _es_diferido; }
			set { _es_diferido = value; }
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
			dynStr.Append("@CBA@MOVIMIENTO_VARIO_ID=");
			dynStr.Append(MOVIMIENTO_VARIO_ID);
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
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(IsCTACTE_BANCO_IDNull ? (object)"<NULL>" : CTACTE_BANCO_ID);
			dynStr.Append("@CBA@NUMERO_CUENTA=");
			dynStr.Append(NUMERO_CUENTA);
			dynStr.Append("@CBA@NUMERO_CHEQUE=");
			dynStr.Append(NUMERO_CHEQUE);
			dynStr.Append("@CBA@NOMBRE_EMISOR=");
			dynStr.Append(NOMBRE_EMISOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_POSDATADO=");
			dynStr.Append(IsFECHA_POSDATADONull ? (object)"<NULL>" : FECHA_POSDATADO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CHEQUE_DE_TERCEROS=");
			dynStr.Append(CHEQUE_DE_TERCEROS);
			dynStr.Append("@CBA@CTACTE_BANCO_NOMBRE=");
			dynStr.Append(CTACTE_BANCO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_ABREVIATURA=");
			dynStr.Append(CTACTE_BANCO_ABREVIATURA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@USAR_CHEQUERA=");
			dynStr.Append(USAR_CHEQUERA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_GIRADO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_GIRADO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_GIRADO_ID);
			dynStr.Append("@CBA@ES_DIFERIDO=");
			dynStr.Append(ES_DIFERIDO);
			return dynStr.ToString();
		}
	} // End of MOV_VARIOS_TESO_DET_INFO_COMPLRow_Base class
} // End of namespace
