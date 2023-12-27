// <fileinfo name="STOCK_INVENTARIORow.cs">
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
	/// Represents a record in the <c>STOCK_INVENTARIO</c> table.
	/// </summary>
	public class STOCK_INVENTARIORow : STOCK_INVENTARIORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_INVENTARIORow"/> class.
		/// </summary>
		public STOCK_INVENTARIORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_INVENTARIORow Clonar()
		{
			return (STOCK_INVENTARIORow)this.MemberwiseClone();
		}
	} // End of STOCK_INVENTARIORow class
} // End of namespace
