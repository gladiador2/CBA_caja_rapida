// <fileinfo name="TRANSF_TESO_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="TRANSF_TESO_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>TRANSF_TESO_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSF_TESO_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSF_TESO_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _transferencias_id;
		private decimal _ctacte_valor_id;
		private string _valor_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _cheque_recibido_banco_id;
		private bool _cheque_recibido_banco_idNull = true;
		private string _banco_razon_social;
		private string _banco_abreviatura;
		private string _cheque_recibido_cuenta;
		private string _cheque_recibido_numero;
		private string _cheque_recibido_emisor;
		private string _cheque_recibido_beneficiario;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSF_TESO_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public TRANSF_TESO_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSF_TESO_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRANSFERENCIAS_ID != original.TRANSFERENCIAS_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.VALOR_NOMBRE != original.VALOR_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsCHEQUE_RECIBIDO_BANCO_IDNull != original.IsCHEQUE_RECIBIDO_BANCO_IDNull) return true;
			if (!this.IsCHEQUE_RECIBIDO_BANCO_IDNull && !original.IsCHEQUE_RECIBIDO_BANCO_IDNull)
				if (this.CHEQUE_RECIBIDO_BANCO_ID != original.CHEQUE_RECIBIDO_BANCO_ID) return true;
			if (this.BANCO_RAZON_SOCIAL != original.BANCO_RAZON_SOCIAL) return true;
			if (this.BANCO_ABREVIATURA != original.BANCO_ABREVIATURA) return true;
			if (this.CHEQUE_RECIBIDO_CUENTA != original.CHEQUE_RECIBIDO_CUENTA) return true;
			if (this.CHEQUE_RECIBIDO_NUMERO != original.CHEQUE_RECIBIDO_NUMERO) return true;
			if (this.CHEQUE_RECIBIDO_EMISOR != original.CHEQUE_RECIBIDO_EMISOR) return true;
			if (this.CHEQUE_RECIBIDO_BENEFICIARIO != original.CHEQUE_RECIBIDO_BENEFICIARIO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>TRANSFERENCIAS_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANSFERENCIAS_ID</c> column value.</value>
		public decimal TRANSFERENCIAS_ID
		{
			get { return _transferencias_id; }
			set { _transferencias_id = value; }
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
		/// Gets or sets the <c>VALOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>VALOR_NOMBRE</c> column value.</value>
		public string VALOR_NOMBRE
		{
			get { return _valor_nombre; }
			set { _valor_nombre = value; }
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
		/// Gets or sets the <c>CHEQUE_RECIBIDO_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_BANCO_ID</c> column value.</value>
		public decimal CHEQUE_RECIBIDO_BANCO_ID
		{
			get
			{
				if(IsCHEQUE_RECIBIDO_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_recibido_banco_id;
			}
			set
			{
				_cheque_recibido_banco_idNull = false;
				_cheque_recibido_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_RECIBIDO_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_RECIBIDO_BANCO_IDNull
		{
			get { return _cheque_recibido_banco_idNull; }
			set { _cheque_recibido_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BANCO_RAZON_SOCIAL</c> column value.</value>
		public string BANCO_RAZON_SOCIAL
		{
			get { return _banco_razon_social; }
			set { _banco_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BANCO_ABREVIATURA</c> column value.</value>
		public string BANCO_ABREVIATURA
		{
			get { return _banco_abreviatura; }
			set { _banco_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_CUENTA</c> column value.</value>
		public string CHEQUE_RECIBIDO_CUENTA
		{
			get { return _cheque_recibido_cuenta; }
			set { _cheque_recibido_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_NUMERO</c> column value.</value>
		public string CHEQUE_RECIBIDO_NUMERO
		{
			get { return _cheque_recibido_numero; }
			set { _cheque_recibido_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_EMISOR</c> column value.</value>
		public string CHEQUE_RECIBIDO_EMISOR
		{
			get { return _cheque_recibido_emisor; }
			set { _cheque_recibido_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_RECIBIDO_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_RECIBIDO_BENEFICIARIO</c> column value.</value>
		public string CHEQUE_RECIBIDO_BENEFICIARIO
		{
			get { return _cheque_recibido_beneficiario; }
			set { _cheque_recibido_beneficiario = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TRANSFERENCIAS_ID=");
			dynStr.Append(TRANSFERENCIAS_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@VALOR_NOMBRE=");
			dynStr.Append(VALOR_NOMBRE);
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
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_BANCO_ID=");
			dynStr.Append(IsCHEQUE_RECIBIDO_BANCO_IDNull ? (object)"<NULL>" : CHEQUE_RECIBIDO_BANCO_ID);
			dynStr.Append("@CBA@BANCO_RAZON_SOCIAL=");
			dynStr.Append(BANCO_RAZON_SOCIAL);
			dynStr.Append("@CBA@BANCO_ABREVIATURA=");
			dynStr.Append(BANCO_ABREVIATURA);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_CUENTA=");
			dynStr.Append(CHEQUE_RECIBIDO_CUENTA);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_NUMERO=");
			dynStr.Append(CHEQUE_RECIBIDO_NUMERO);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_EMISOR=");
			dynStr.Append(CHEQUE_RECIBIDO_EMISOR);
			dynStr.Append("@CBA@CHEQUE_RECIBIDO_BENEFICIARIO=");
			dynStr.Append(CHEQUE_RECIBIDO_BENEFICIARIO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of TRANSF_TESO_DET_INFO_COMPLRow_Base class
} // End of namespace
