// <fileinfo name="CTACTE_PAGARES_DETALLERow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGARES_DETALLERow"/> that 
	/// represents a record in the <c>CTACTE_PAGARES_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGARES_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGARES_DETALLERow_Base
	{
		private decimal _id;
		private decimal _ctacte_pagare_id;
		private decimal _numero_pagare;
		private System.DateTime _fecha_vencimiento;
		private decimal _monto_total;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARES_DETALLERow_Base"/> class.
		/// </summary>
		public CTACTE_PAGARES_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGARES_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PAGARE_ID != original.CTACTE_PAGARE_ID) return true;
			if (this.NUMERO_PAGARE != original.NUMERO_PAGARE) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			
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
		/// Gets or sets the <c>CTACTE_PAGARE_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_ID
		{
			get { return _ctacte_pagare_id; }
			set { _ctacte_pagare_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_PAGARE</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_PAGARE</c> column value.</value>
		public decimal NUMERO_PAGARE
		{
			get { return _numero_pagare; }
			set { _numero_pagare = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
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
			dynStr.Append("@CBA@CTACTE_PAGARE_ID=");
			dynStr.Append(CTACTE_PAGARE_ID);
			dynStr.Append("@CBA@NUMERO_PAGARE=");
			dynStr.Append(NUMERO_PAGARE);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGARES_DETALLERow_Base class
} // End of namespace
