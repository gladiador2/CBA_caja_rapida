// <fileinfo name="CTACTE_GIROSRow.cs">
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
	/// Represents a record in the <c>CTACTE_GIROS</c> table.
	/// </summary>
	public class CTACTE_GIROSRow : CTACTE_GIROSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_GIROSRow"/> class.
		/// </summary>
		public CTACTE_GIROSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_GIROSRow Clonar()
		{
			return (CTACTE_GIROSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_GIROSRow class
} // End of namespace
