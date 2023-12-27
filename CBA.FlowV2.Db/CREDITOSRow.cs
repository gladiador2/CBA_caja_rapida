// <fileinfo name="CREDITOSRow.cs">
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
	/// Represents a record in the <c>CREDITOS</c> table.
	/// </summary>
	public class CREDITOSRow : CREDITOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOSRow"/> class.
		/// </summary>
		public CREDITOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CREDITOSRow Clonar()
		{
			return (CREDITOSRow)this.MemberwiseClone();
		}
	} // End of CREDITOSRow class
} // End of namespace
