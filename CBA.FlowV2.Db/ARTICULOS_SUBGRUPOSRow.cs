// <fileinfo name="ARTICULOS_SUBGRUPOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_SUBGRUPOS</c> table.
	/// </summary>
	public class ARTICULOS_SUBGRUPOSRow : ARTICULOS_SUBGRUPOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_SUBGRUPOSRow"/> class.
		/// </summary>
		public ARTICULOS_SUBGRUPOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_SUBGRUPOSRow Clonar()
		{
			return (ARTICULOS_SUBGRUPOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_SUBGRUPOSRow class
} // End of namespace
