// <fileinfo name="TIPOS_ARTICULO_FINANC_RANGORow_Base.cs">
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
	/// The base class for <see cref="TIPOS_ARTICULO_FINANC_RANGORow"/> that 
	/// represents a record in the <c>TIPOS_ARTICULO_FINANC_RANGO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPOS_ARTICULO_FINANC_RANGORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_ARTICULO_FINANC_RANGORow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _articulo_id;
		private decimal _moneda_tope_id;
		private decimal _monto_tope;
		private decimal _porcentaje_tope;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ARTICULO_FINANC_RANGORow_Base"/> class.
		/// </summary>
		public TIPOS_ARTICULO_FINANC_RANGORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPOS_ARTICULO_FINANC_RANGORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.MONEDA_TOPE_ID != original.MONEDA_TOPE_ID) return true;
			if (this.MONTO_TOPE != original.MONTO_TOPE) return true;
			if (this.PORCENTAJE_TOPE != original.PORCENTAJE_TOPE) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>MONEDA_TOPE_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_TOPE_ID</c> column value.</value>
		public decimal MONEDA_TOPE_ID
		{
			get { return _moneda_tope_id; }
			set { _moneda_tope_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOPE</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOPE</c> column value.</value>
		public decimal MONTO_TOPE
		{
			get { return _monto_tope; }
			set { _monto_tope = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_TOPE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_TOPE</c> column value.</value>
		public decimal PORCENTAJE_TOPE
		{
			get { return _porcentaje_tope; }
			set { _porcentaje_tope = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@MONEDA_TOPE_ID=");
			dynStr.Append(MONEDA_TOPE_ID);
			dynStr.Append("@CBA@MONTO_TOPE=");
			dynStr.Append(MONTO_TOPE);
			dynStr.Append("@CBA@PORCENTAJE_TOPE=");
			dynStr.Append(PORCENTAJE_TOPE);
			return dynStr.ToString();
		}
	} // End of TIPOS_ARTICULO_FINANC_RANGORow_Base class
} // End of namespace
