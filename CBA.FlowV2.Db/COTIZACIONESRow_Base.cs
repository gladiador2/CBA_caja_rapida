// <fileinfo name="COTIZACIONESRow_Base.cs">
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
	/// The base class for <see cref="COTIZACIONESRow"/> that 
	/// represents a record in the <c>COTIZACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="COTIZACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COTIZACIONESRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _pais_id;
		private decimal _moneda_id;
		private System.DateTime _fecha;
		private decimal _compra;
		private decimal _venta;
		private decimal _usuario_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="COTIZACIONESRow_Base"/> class.
		/// </summary>
		public COTIZACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(COTIZACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.COMPRA != original.COMPRA) return true;
			if (this.VENTA != original.VENTA) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get { return _pais_id; }
			set { _pais_id = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMPRA</c> column value.
		/// </summary>
		/// <value>The <c>COMPRA</c> column value.</value>
		public decimal COMPRA
		{
			get { return _compra; }
			set { _compra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENTA</c> column value.
		/// </summary>
		/// <value>The <c>VENTA</c> column value.</value>
		public decimal VENTA
		{
			get { return _venta; }
			set { _venta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@COMPRA=");
			dynStr.Append(COMPRA);
			dynStr.Append("@CBA@VENTA=");
			dynStr.Append(VENTA);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			return dynStr.ToString();
		}
	} // End of COTIZACIONESRow_Base class
} // End of namespace
