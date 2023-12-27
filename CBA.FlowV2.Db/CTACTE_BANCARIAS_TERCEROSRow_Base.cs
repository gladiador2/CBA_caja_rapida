// <fileinfo name="CTACTE_BANCARIAS_TERCEROSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCARIAS_TERCEROSRow"/> that 
	/// represents a record in the <c>CTACTE_BANCARIAS_TERCEROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_BANCARIAS_TERCEROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCARIAS_TERCEROSRow_Base
	{
		private decimal _id;
		private decimal _ctacte_banco_id;
		private decimal _moneda_id;
		private string _swift;
		private string _direccion;
		private string _numero_cuenta;
		private decimal _pais_id;
		private bool _pais_idNull = true;
		private string _ciudad;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_TERCEROSRow_Base"/> class.
		/// </summary>
		public CTACTE_BANCARIAS_TERCEROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_BANCARIAS_TERCEROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.SWIFT != original.SWIFT) return true;
			if (this.DIRECCION != original.DIRECCION) return true;
			if (this.NUMERO_CUENTA != original.NUMERO_CUENTA) return true;
			if (this.IsPAIS_IDNull != original.IsPAIS_IDNull) return true;
			if (!this.IsPAIS_IDNull && !original.IsPAIS_IDNull)
				if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.CIUDAD != original.CIUDAD) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get { return _ctacte_banco_id; }
			set { _ctacte_banco_id = value; }
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
		/// Gets or sets the <c>SWIFT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SWIFT</c> column value.</value>
		public string SWIFT
		{
			get { return _swift; }
			set { _swift = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION</c> column value.</value>
		public string DIRECCION
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA</c> column value.</value>
		public string NUMERO_CUENTA
		{
			get { return _numero_cuenta; }
			set { _numero_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get
			{
				if(IsPAIS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pais_id;
			}
			set
			{
				_pais_idNull = false;
				_pais_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAIS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAIS_IDNull
		{
			get { return _pais_idNull; }
			set { _pais_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD</c> column value.</value>
		public string CIUDAD
		{
			get { return _ciudad; }
			set { _ciudad = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(CTACTE_BANCO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@SWIFT=");
			dynStr.Append(SWIFT);
			dynStr.Append("@CBA@DIRECCION=");
			dynStr.Append(DIRECCION);
			dynStr.Append("@CBA@NUMERO_CUENTA=");
			dynStr.Append(NUMERO_CUENTA);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(IsPAIS_IDNull ? (object)"<NULL>" : PAIS_ID);
			dynStr.Append("@CBA@CIUDAD=");
			dynStr.Append(CIUDAD);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_BANCARIAS_TERCEROSRow_Base class
} // End of namespace
