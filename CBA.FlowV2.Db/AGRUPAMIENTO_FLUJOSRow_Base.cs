// <fileinfo name="AGRUPAMIENTO_FLUJOSRow_Base.cs">
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
	/// The base class for <see cref="AGRUPAMIENTO_FLUJOSRow"/> that 
	/// represents a record in the <c>AGRUPAMIENTO_FLUJOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="AGRUPAMIENTO_FLUJOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AGRUPAMIENTO_FLUJOSRow_Base
	{
		private decimal _id;
		private decimal _tipo;
		private decimal _flujo_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="AGRUPAMIENTO_FLUJOSRow_Base"/> class.
		/// </summary>
		public AGRUPAMIENTO_FLUJOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(AGRUPAMIENTO_FLUJOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			
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
		/// Gets or sets the <c>TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public decimal TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
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
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			return dynStr.ToString();
		}
	} // End of AGRUPAMIENTO_FLUJOSRow_Base class
} // End of namespace
