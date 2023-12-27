// <fileinfo name="CTACTE_CONDICIONES_PAGO_DETRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CONDICIONES_PAGO_DETRow"/> that 
	/// represents a record in the <c>CTACTE_CONDICIONES_PAGO_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CONDICIONES_PAGO_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CONDICIONES_PAGO_DETRow_Base
	{
		private decimal _id;
		private decimal _ctacte_condicion_pago_id;
		private decimal _vencimiento_pago;
		private decimal _numero_cuota;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONDICIONES_PAGO_DETRow_Base"/> class.
		/// </summary>
		public CTACTE_CONDICIONES_PAGO_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CONDICIONES_PAGO_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_CONDICION_PAGO_ID != original.CTACTE_CONDICION_PAGO_ID) return true;
			if (this.VENCIMIENTO_PAGO != original.VENCIMIENTO_PAGO) return true;
			if (this.NUMERO_CUOTA != original.NUMERO_CUOTA) return true;
			
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
		/// Gets or sets the <c>CTACTE_CONDICION_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</value>
		public decimal CTACTE_CONDICION_PAGO_ID
		{
			get { return _ctacte_condicion_pago_id; }
			set { _ctacte_condicion_pago_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENCIMIENTO_PAGO</c> column value.
		/// </summary>
		/// <value>The <c>VENCIMIENTO_PAGO</c> column value.</value>
		public decimal VENCIMIENTO_PAGO
		{
			get { return _vencimiento_pago; }
			set { _vencimiento_pago = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUOTA</c> column value.</value>
		public decimal NUMERO_CUOTA
		{
			get { return _numero_cuota; }
			set { _numero_cuota = value; }
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
			dynStr.Append("@CBA@CTACTE_CONDICION_PAGO_ID=");
			dynStr.Append(CTACTE_CONDICION_PAGO_ID);
			dynStr.Append("@CBA@VENCIMIENTO_PAGO=");
			dynStr.Append(VENCIMIENTO_PAGO);
			dynStr.Append("@CBA@NUMERO_CUOTA=");
			dynStr.Append(NUMERO_CUOTA);
			return dynStr.ToString();
		}
	} // End of CTACTE_CONDICIONES_PAGO_DETRow_Base class
} // End of namespace
