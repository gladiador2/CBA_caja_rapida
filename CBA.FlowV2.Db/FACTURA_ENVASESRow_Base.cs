// <fileinfo name="FACTURA_ENVASESRow_Base.cs">
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
	/// The base class for <see cref="FACTURA_ENVASESRow"/> that 
	/// represents a record in the <c>FACTURA_ENVASES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURA_ENVASESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURA_ENVASESRow_Base
	{
		private decimal _id;
		private decimal _factura_cliente_detalle_id;
		private decimal _envase_id;
		private bool _envase_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _peso;
		private bool _pesoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURA_ENVASESRow_Base"/> class.
		/// </summary>
		public FACTURA_ENVASESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURA_ENVASESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FACTURA_CLIENTE_DETALLE_ID != original.FACTURA_CLIENTE_DETALLE_ID) return true;
			if (this.IsENVASE_IDNull != original.IsENVASE_IDNull) return true;
			if (!this.IsENVASE_IDNull && !original.IsENVASE_IDNull)
				if (this.ENVASE_ID != original.ENVASE_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsPESONull != original.IsPESONull) return true;
			if (!this.IsPESONull && !original.IsPESONull)
				if (this.PESO != original.PESO) return true;
			
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
		/// Gets or sets the <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_DETALLE_ID
		{
			get { return _factura_cliente_detalle_id; }
			set { _factura_cliente_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENVASE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENVASE_ID</c> column value.</value>
		public decimal ENVASE_ID
		{
			get
			{
				if(IsENVASE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _envase_id;
			}
			set
			{
				_envase_idNull = false;
				_envase_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENVASE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENVASE_IDNull
		{
			get { return _envase_idNull; }
			set { _envase_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO</c> column value.</value>
		public decimal PESO
		{
			get
			{
				if(IsPESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso;
			}
			set
			{
				_pesoNull = false;
				_peso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESONull
		{
			get { return _pesoNull; }
			set { _pesoNull = value; }
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
			dynStr.Append("@CBA@FACTURA_CLIENTE_DETALLE_ID=");
			dynStr.Append(FACTURA_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@ENVASE_ID=");
			dynStr.Append(IsENVASE_IDNull ? (object)"<NULL>" : ENVASE_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@PESO=");
			dynStr.Append(IsPESONull ? (object)"<NULL>" : PESO);
			return dynStr.ToString();
		}
	} // End of FACTURA_ENVASESRow_Base class
} // End of namespace
