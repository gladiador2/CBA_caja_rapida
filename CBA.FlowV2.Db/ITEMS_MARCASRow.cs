// <fileinfo name="ITEMS_MARCASRow.cs">
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
	/// Represents a record in the <c>ITEMS_MARCAS</c> table.
	/// </summary>
	public class ITEMS_MARCASRow : ITEMS_MARCASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_MARCASRow"/> class.
		/// </summary>
		public ITEMS_MARCASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ITEMS_MARCASRow Clonar()
		{
			return (ITEMS_MARCASRow)this.MemberwiseClone();
		}
	} // End of ITEMS_MARCASRow class
} // End of namespace
