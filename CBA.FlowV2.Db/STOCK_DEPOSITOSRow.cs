// <fileinfo name="STOCK_DEPOSITOSRow.cs">
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
	/// Represents a record in the <c>STOCK_DEPOSITOS</c> table.
	/// </summary>
	public class STOCK_DEPOSITOSRow : STOCK_DEPOSITOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_DEPOSITOSRow"/> class.
		/// </summary>
		public STOCK_DEPOSITOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_DEPOSITOSRow Clonar()
		{
			return (STOCK_DEPOSITOSRow)this.MemberwiseClone();
		}
	} // End of STOCK_DEPOSITOSRow class
} // End of namespace
