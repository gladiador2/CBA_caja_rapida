// <fileinfo name="ITEMS_MODELOSRow.cs">
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
	/// Represents a record in the <c>ITEMS_MODELOS</c> table.
	/// </summary>
	public class ITEMS_MODELOSRow : ITEMS_MODELOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_MODELOSRow"/> class.
		/// </summary>
		public ITEMS_MODELOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ITEMS_MODELOSRow Clonar()
		{
			return (ITEMS_MODELOSRow)this.MemberwiseClone();
		}
	} // End of ITEMS_MODELOSRow class
} // End of namespace
