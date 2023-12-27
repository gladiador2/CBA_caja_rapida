// <fileinfo name="EGRESO_PRODUCTOSRow.cs">
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
	/// Represents a record in the <c>EGRESO_PRODUCTOS</c> table.
	/// </summary>
	public class EGRESO_PRODUCTOSRow : EGRESO_PRODUCTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESO_PRODUCTOSRow"/> class.
		/// </summary>
		public EGRESO_PRODUCTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public EGRESO_PRODUCTOSRow Clonar()
		{
			return (EGRESO_PRODUCTOSRow)this.MemberwiseClone();
		}
	} // End of EGRESO_PRODUCTOSRow class
} // End of namespace
