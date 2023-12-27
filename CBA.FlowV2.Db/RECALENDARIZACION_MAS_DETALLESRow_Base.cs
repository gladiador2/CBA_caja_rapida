// <fileinfo name="RECALENDARIZACION_MAS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="RECALENDARIZACION_MAS_DETALLESRow"/> that 
	/// represents a record in the <c>RECALENDARIZACION_MAS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RECALENDARIZACION_MAS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECALENDARIZACION_MAS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _recalendarizacion_masiva_id;
		private decimal _caso_factura_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECALENDARIZACION_MAS_DETALLESRow_Base"/> class.
		/// </summary>
		public RECALENDARIZACION_MAS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RECALENDARIZACION_MAS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.RECALENDARIZACION_MASIVA_ID != original.RECALENDARIZACION_MASIVA_ID) return true;
			if (this.CASO_FACTURA_ID != original.CASO_FACTURA_ID) return true;
			
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
		/// Gets or sets the <c>RECALENDARIZACION_MASIVA_ID</c> column value.
		/// </summary>
		/// <value>The <c>RECALENDARIZACION_MASIVA_ID</c> column value.</value>
		public decimal RECALENDARIZACION_MASIVA_ID
		{
			get { return _recalendarizacion_masiva_id; }
			set { _recalendarizacion_masiva_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FACTURA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FACTURA_ID</c> column value.</value>
		public decimal CASO_FACTURA_ID
		{
			get { return _caso_factura_id; }
			set { _caso_factura_id = value; }
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
			dynStr.Append("@CBA@RECALENDARIZACION_MASIVA_ID=");
			dynStr.Append(RECALENDARIZACION_MASIVA_ID);
			dynStr.Append("@CBA@CASO_FACTURA_ID=");
			dynStr.Append(CASO_FACTURA_ID);
			return dynStr.ToString();
		}
	} // End of RECALENDARIZACION_MAS_DETALLESRow_Base class
} // End of namespace
