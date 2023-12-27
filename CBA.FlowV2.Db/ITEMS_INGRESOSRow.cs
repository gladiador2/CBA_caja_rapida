// <fileinfo name="ITEMS_INGRESOSRow.cs">
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
	/// Represents a record in the <c>ITEMS_INGRESOS</c> table.
	/// </summary>
	public class ITEMS_INGRESOSRow : ITEMS_INGRESOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESOSRow"/> class.
		/// </summary>
		public ITEMS_INGRESOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ITEMS_INGRESOSRow Clonar()
		{
			return (ITEMS_INGRESOSRow)this.MemberwiseClone();
		}
	} // End of ITEMS_INGRESOSRow class
} // End of namespace
