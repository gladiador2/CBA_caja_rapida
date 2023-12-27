// <fileinfo name="ANTICIPOS_FACTURAS_PROVEEDORRow_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> that 
	/// represents a record in the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_FACTURAS_PROVEEDORRow_Base
	{
		private decimal _anticipo_proveedor_id;
		private decimal _factura_proveedor_id;
		private System.DateTime _fecha;
		private bool _fechaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow_Base"/> class.
		/// </summary>
		public ANTICIPOS_FACTURAS_PROVEEDORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ANTICIPOS_FACTURAS_PROVEEDORRow_Base original)
		{
			if (this.ANTICIPO_PROVEEDOR_ID != original.ANTICIPO_PROVEEDOR_ID) return true;
			if (this.FACTURA_PROVEEDOR_ID != original.FACTURA_PROVEEDOR_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</value>
		public decimal ANTICIPO_PROVEEDOR_ID
		{
			get { return _anticipo_proveedor_id; }
			set { _anticipo_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_ID
		{
			get { return _factura_proveedor_id; }
			set { _factura_proveedor_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ANTICIPO_PROVEEDOR_ID=");
			dynStr.Append(ANTICIPO_PROVEEDOR_ID);
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_ID=");
			dynStr.Append(FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			return dynStr.ToString();
		}
	} // End of ANTICIPOS_FACTURAS_PROVEEDORRow_Base class
} // End of namespace
