// <fileinfo name="CTB_ASIENTOSRow.cs">
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
	/// Represents a record in the <c>CTB_ASIENTOS</c> table.
	/// </summary>
	public class CTB_ASIENTOSRow : CTB_ASIENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOSRow"/> class.
		/// </summary>
		public CTB_ASIENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTB_ASIENTOSRow Clonar()
		{
			return (CTB_ASIENTOSRow)this.MemberwiseClone();
		}
	} // End of CTB_ASIENTOSRow class
} // End of namespace
