// <fileinfo name="STOCK_BOXRow.cs">
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
	/// Represents a record in the <c>STOCK_BOX</c> table.
	/// </summary>
	public class STOCK_BOXRow : STOCK_BOXRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_BOXRow"/> class.
		/// </summary>
		public STOCK_BOXRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_BOXRow Clonar()
		{
			return (STOCK_BOXRow)this.MemberwiseClone();
		}
	} // End of STOCK_BOXRow class
} // End of namespace
