// <fileinfo name="PEDIDOS_PROVEEDORRow.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			You can update this source code manually. If the file
//			already exists it will not be rewritten by the generator.
//		</remarks>
//		<generator rewritefile="False" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// Represents a record in the <c>PEDIDOS_PROVEEDOR</c> table.
	/// </summary>
	public class PEDIDOS_PROVEEDORRow : PEDIDOS_PROVEEDORRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_PROVEEDORRow"/> class.
		/// </summary>
		public PEDIDOS_PROVEEDORRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PEDIDOS_PROVEEDORRow Clonar()
		{
			return (PEDIDOS_PROVEEDORRow)this.MemberwiseClone();
		}
	} // End of PEDIDOS_PROVEEDORRow class
} // End of namespace
