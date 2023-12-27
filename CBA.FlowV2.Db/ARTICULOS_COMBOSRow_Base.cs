// <fileinfo name="ARTICULOS_COMBOSRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COMBOSRow"/> that 
	/// represents a record in the <c>ARTICULOS_COMBOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COMBOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COMBOSRow_Base
	{
		private decimal _id;
		private decimal _articulo_combo_id;
		private decimal _articulo_detalle_id;
		private decimal _cantidad_origen;
		private string _unidad_origen_id;
		private decimal _cantidad_destino;
		private string _unidad_destino_id;
		private decimal _factor_conversion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COMBOSRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COMBOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COMBOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_COMBO_ID != original.ARTICULO_COMBO_ID) return true;
			if (this.ARTICULO_DETALLE_ID != original.ARTICULO_DETALLE_ID) return true;
			if (this.CANTIDAD_ORIGEN != original.CANTIDAD_ORIGEN) return true;
			if (this.UNIDAD_ORIGEN_ID != original.UNIDAD_ORIGEN_ID) return true;
			if (this.CANTIDAD_DESTINO != original.CANTIDAD_DESTINO) return true;
			if (this.UNIDAD_DESTINO_ID != original.UNIDAD_DESTINO_ID) return true;
			if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			
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
		/// Gets or sets the <c>ARTICULO_COMBO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_COMBO_ID</c> column value.</value>
		public decimal ARTICULO_COMBO_ID
		{
			get { return _articulo_combo_id; }
			set { _articulo_combo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_DETALLE_ID</c> column value.</value>
		public decimal ARTICULO_DETALLE_ID
		{
			get { return _articulo_detalle_id; }
			set { _articulo_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_ORIGEN
		{
			get { return _cantidad_origen; }
			set { _cantidad_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_ORIGEN_ID</c> column value.</value>
		public string UNIDAD_ORIGEN_ID
		{
			get { return _unidad_origen_id; }
			set { _unidad_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_DESTINO</c> column value.</value>
		public decimal CANTIDAD_DESTINO
		{
			get { return _cantidad_destino; }
			set { _cantidad_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO_ID</c> column value.</value>
		public string UNIDAD_DESTINO_ID
		{
			get { return _unidad_destino_id; }
			set { _unidad_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_CONVERSION</c> column value.
		/// </summary>
		/// <value>The <c>FACTOR_CONVERSION</c> column value.</value>
		public decimal FACTOR_CONVERSION
		{
			get { return _factor_conversion; }
			set { _factor_conversion = value; }
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
			dynStr.Append("@CBA@ARTICULO_COMBO_ID=");
			dynStr.Append(ARTICULO_COMBO_ID);
			dynStr.Append("@CBA@ARTICULO_DETALLE_ID=");
			dynStr.Append(ARTICULO_DETALLE_ID);
			dynStr.Append("@CBA@CANTIDAD_ORIGEN=");
			dynStr.Append(CANTIDAD_ORIGEN);
			dynStr.Append("@CBA@UNIDAD_ORIGEN_ID=");
			dynStr.Append(UNIDAD_ORIGEN_ID);
			dynStr.Append("@CBA@CANTIDAD_DESTINO=");
			dynStr.Append(CANTIDAD_DESTINO);
			dynStr.Append("@CBA@UNIDAD_DESTINO_ID=");
			dynStr.Append(UNIDAD_DESTINO_ID);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(FACTOR_CONVERSION);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COMBOSRow_Base class
} // End of namespace
