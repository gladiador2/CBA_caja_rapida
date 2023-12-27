// <fileinfo name="ARTICULOS_COMBOS_STOCKRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COMBOS_STOCKRow"/> that 
	/// represents a record in the <c>ARTICULOS_COMBOS_STOCK</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_COMBOS_STOCKRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COMBOS_STOCKRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _deposito_id;
		private decimal _articulo_combo_lote_id;
		private string _operacion;
		private System.DateTime _fecha_operacion;
		private decimal _usuario_operacion_id;
		private decimal _cantidad;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COMBOS_STOCKRow_Base"/> class.
		/// </summary>
		public ARTICULOS_COMBOS_STOCKRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_COMBOS_STOCKRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.ARTICULO_COMBO_LOTE_ID != original.ARTICULO_COMBO_LOTE_ID) return true;
			if (this.OPERACION != original.OPERACION) return true;
			if (this.FECHA_OPERACION != original.FECHA_OPERACION) return true;
			if (this.USUARIO_OPERACION_ID != original.USUARIO_OPERACION_ID) return true;
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
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
		/// Gets or sets the <c>OPERACION</c> column value.
		/// </summary>
		/// <value>The <c>OPERACION</c> column value.</value>
		public string OPERACION
		{
			get { return _operacion; }
			set { _operacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_OPERACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_OPERACION</c> column value.</value>
		public System.DateTime FECHA_OPERACION
		{
			get { return _fecha_operacion; }
			set { _fecha_operacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_OPERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_OPERACION_ID</c> column value.</value>
		public decimal USUARIO_OPERACION_ID
		{
			get { return _usuario_operacion_id; }
			set { _usuario_operacion_id = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@ARTICULO_COMBO_LOTE_ID=");
			dynStr.Append(ARTICULO_COMBO_LOTE_ID);
			dynStr.Append("@CBA@OPERACION=");
			dynStr.Append(OPERACION);
			dynStr.Append("@CBA@FECHA_OPERACION=");
			dynStr.Append(FECHA_OPERACION);
			dynStr.Append("@CBA@USUARIO_OPERACION_ID=");
			dynStr.Append(USUARIO_OPERACION_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_COMBOS_STOCKRow_Base class
} // End of namespace
