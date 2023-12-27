// <fileinfo name="ARTICULOS_COMBOS_STOCK_DETRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COMBOS_STOCK_DETRow"/> that 
	/// represents a record in the <c>ARTICULOS_COMBOS_STOCK_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COMBOS_STOCK_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COMBOS_STOCK_DETRow_Base
	{
		private decimal _id;
		private decimal _art_combo_stock_id;
		private decimal _articulos_detalle_lote_id;
		private decimal _cantidad;
		private string _unidad;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COMBOS_STOCK_DETRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COMBOS_STOCK_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COMBOS_STOCK_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ART_COMBO_STOCK_ID != original.ART_COMBO_STOCK_ID) return true;
			if (this.ARTICULOS_DETALLE_LOTE_ID != original.ARTICULOS_DETALLE_LOTE_ID) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.UNIDAD != original.UNIDAD) return true;
			
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
		/// Gets or sets the <c>ART_COMBO_STOCK_ID</c> column value.
		/// </summary>
		/// <value>The <c>ART_COMBO_STOCK_ID</c> column value.</value>
		public decimal ART_COMBO_STOCK_ID
		{
			get { return _art_combo_stock_id; }
			set { _art_combo_stock_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_DETALLE_LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_DETALLE_LOTE_ID</c> column value.</value>
		public decimal ARTICULOS_DETALLE_LOTE_ID
		{
			get { return _articulos_detalle_lote_id; }
			set { _articulos_detalle_lote_id = value; }
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
		/// Gets or sets the <c>UNIDAD</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD</c> column value.</value>
		public string UNIDAD
		{
			get { return _unidad; }
			set { _unidad = value; }
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
			dynStr.Append("@CBA@ART_COMBO_STOCK_ID=");
			dynStr.Append(ART_COMBO_STOCK_ID);
			dynStr.Append("@CBA@ARTICULOS_DETALLE_LOTE_ID=");
			dynStr.Append(ARTICULOS_DETALLE_LOTE_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@UNIDAD=");
			dynStr.Append(UNIDAD);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COMBOS_STOCK_DETRow_Base class
} // End of namespace
