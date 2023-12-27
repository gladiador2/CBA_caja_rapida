// <fileinfo name="STOCK_AJUSTERow.cs">
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
	/// Represents a record in the <c>STOCK_AJUSTE</c> table.
	/// </summary>
	public class STOCK_AJUSTERow : STOCK_AJUSTERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_AJUSTERow"/> class.
		/// </summary>
		public STOCK_AJUSTERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_AJUSTERow Clonar()
		{
			return (STOCK_AJUSTERow)this.MemberwiseClone();
		}
	} // End of STOCK_AJUSTERow class
} // End of namespace
