// <fileinfo name="CTACTE_POSRow.cs">
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
	/// Represents a record in the <c>CTACTE_POS</c> table.
	/// </summary>
	public class CTACTE_POSRow : CTACTE_POSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_POSRow"/> class.
		/// </summary>
		public CTACTE_POSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_POSRow Clonar()
		{
			return (CTACTE_POSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_POSRow class
} // End of namespace
