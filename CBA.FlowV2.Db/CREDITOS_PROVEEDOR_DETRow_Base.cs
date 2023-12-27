// <fileinfo name="CREDITOS_PROVEEDOR_DETRow_Base.cs">
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
	/// The base class for <see cref="CREDITOS_PROVEEDOR_DETRow"/> that 
	/// represents a record in the <c>CREDITOS_PROVEEDOR_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CREDITOS_PROVEEDOR_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOS_PROVEEDOR_DETRow_Base
	{
		private decimal _id;
		private decimal _credito_proveedor_id;
		private decimal _numero_cuota;
		private decimal _monto_capital;
		private decimal _monto_interes;
		private System.DateTime _fecha_vencimiento;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_PROVEEDOR_DETRow_Base"/> class.
		/// </summary>
		public CREDITOS_PROVEEDOR_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CREDITOS_PROVEEDOR_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CREDITO_PROVEEDOR_ID != original.CREDITO_PROVEEDOR_ID) return true;
			if (this.NUMERO_CUOTA != original.NUMERO_CUOTA) return true;
			if (this.MONTO_CAPITAL != original.MONTO_CAPITAL) return true;
			if (this.MONTO_INTERES != original.MONTO_INTERES) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			
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
		/// Gets or sets the <c>CREDITO_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CREDITO_PROVEEDOR_ID</c> column value.</value>
		public decimal CREDITO_PROVEEDOR_ID
		{
			get { return _credito_proveedor_id; }
			set { _credito_proveedor_id = value; }
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
		/// Gets or sets the <c>MONTO_CAPITAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL</c> column value.</value>
		public decimal MONTO_CAPITAL
		{
			get { return _monto_capital; }
			set { _monto_capital = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INTERES</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INTERES</c> column value.</value>
		public decimal MONTO_INTERES
		{
			get { return _monto_interes; }
			set { _monto_interes = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CREDITO_PROVEEDOR_ID=");
			dynStr.Append(CREDITO_PROVEEDOR_ID);
			dynStr.Append("@CBA@NUMERO_CUOTA=");
			dynStr.Append(NUMERO_CUOTA);
			dynStr.Append("@CBA@MONTO_CAPITAL=");
			dynStr.Append(MONTO_CAPITAL);
			dynStr.Append("@CBA@MONTO_INTERES=");
			dynStr.Append(MONTO_INTERES);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			return dynStr.ToString();
		}
	} // End of CREDITOS_PROVEEDOR_DETRow_Base class
} // End of namespace
