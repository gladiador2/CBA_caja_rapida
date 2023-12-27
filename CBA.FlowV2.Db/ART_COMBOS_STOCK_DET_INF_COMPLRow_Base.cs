// <fileinfo name="ART_COMBOS_STOCK_DET_INF_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ART_COMBOS_STOCK_DET_INF_COMPLRow"/> that 
	/// represents a record in the <c>ART_COMBOS_STOCK_DET_INF_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ART_COMBOS_STOCK_DET_INF_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ART_COMBOS_STOCK_DET_INF_COMPLRow_Base
	{
		private decimal _id;
		private decimal _art_combo_stock_id;
		private decimal _articulos_detalle_lote_id;
		private decimal _articulo_combo_lote_id;
		private string _lote;
		private decimal _cantidad;
		private string _unidad;

		/// <summary>
		/// Initializes a new instance of the <see cref="ART_COMBOS_STOCK_DET_INF_COMPLRow_Base"/> class.
		/// </summary>
		public ART_COMBOS_STOCK_DET_INF_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ART_COMBOS_STOCK_DET_INF_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ART_COMBO_STOCK_ID != original.ART_COMBO_STOCK_ID) return true;
			if (this.ARTICULOS_DETALLE_LOTE_ID != original.ARTICULOS_DETALLE_LOTE_ID) return true;
			if (this.ARTICULO_COMBO_LOTE_ID != original.ARTICULO_COMBO_LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
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
		/// Gets or sets the <c>ARTICULO_COMBO_LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_COMBO_LOTE_ID</c> column value.</value>
		public decimal ARTICULO_COMBO_LOTE_ID
		{
			get { return _articulo_combo_lote_id; }
			set { _articulo_combo_lote_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE</c> column value.</value>
		public string LOTE
		{
			get { return _lote; }
			set { _lote = value; }
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
			dynStr.Append("@CBA@ARTICULO_COMBO_LOTE_ID=");
			dynStr.Append(ARTICULO_COMBO_LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@UNIDAD=");
			dynStr.Append(UNIDAD);
			return dynStr.ToString();
		}
	} // End of ART_COMBOS_STOCK_DET_INF_COMPLRow_Base class
} // End of namespace
