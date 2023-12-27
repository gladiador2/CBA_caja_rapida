// <fileinfo name="CALENDARIO_PAGOS_FC_PROVEEDORRow_Base.cs">
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
	/// The base class for <see cref="CALENDARIO_PAGOS_FC_PROVEEDORRow"/> that 
	/// represents a record in the <c>CALENDARIO_PAGOS_FC_PROVEEDOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CALENDARIO_PAGOS_FC_PROVEEDORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CALENDARIO_PAGOS_FC_PROVEEDORRow_Base
	{
		private decimal _id;
		private decimal _factura_proveedor_id;
		private decimal _monto;
		private System.DateTime _fecha_vencimiento;

		/// <summary>
		/// Initializes a new instance of the <see cref="CALENDARIO_PAGOS_FC_PROVEEDORRow_Base"/> class.
		/// </summary>
		public CALENDARIO_PAGOS_FC_PROVEEDORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CALENDARIO_PAGOS_FC_PROVEEDORRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FACTURA_PROVEEDOR_ID != original.FACTURA_PROVEEDOR_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			
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
		/// Gets or sets the <c>FACTURA_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_ID
		{
			get { return _factura_proveedor_id; }
			set { _factura_proveedor_id = value; }
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
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
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
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_ID=");
			dynStr.Append(FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			return dynStr.ToString();
		}
	} // End of CALENDARIO_PAGOS_FC_PROVEEDORRow_Base class
} // End of namespace
