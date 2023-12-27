// <fileinfo name="ARTICULOS_COMBOS_DETRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COMBOS_DETRow"/> that 
	/// represents a record in the <c>ARTICULOS_COMBOS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COMBOS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COMBOS_DETRow_Base
	{
		private decimal _id;
		private decimal _combo_id;
		private decimal _articulo_id;
		private decimal _cantidad;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COMBOS_DETRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COMBOS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COMBOS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.COMBO_ID != original.COMBO_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			
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
		/// Gets or sets the <c>COMBO_ID</c> column value.
		/// </summary>
		/// <value>The <c>COMBO_ID</c> column value.</value>
		public decimal COMBO_ID
		{
			get { return _combo_id; }
			set { _combo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
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
			dynStr.Append("@CBA@COMBO_ID=");
			dynStr.Append(COMBO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COMBOS_DETRow_Base class
} // End of namespace
