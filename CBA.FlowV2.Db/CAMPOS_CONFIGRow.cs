// <fileinfo name="CAMPOS_CONFIGRow.cs">
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
	/// Represents a record in the <c>CAMPOS_CONFIG</c> table.
	/// </summary>
	public class CAMPOS_CONFIGRow : CAMPOS_CONFIGRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONFIGRow"/> class.
		/// </summary>
		public CAMPOS_CONFIGRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CAMPOS_CONFIGRow Clonar()
		{
			return (CAMPOS_CONFIGRow)this.MemberwiseClone();
		}
	} // End of CAMPOS_CONFIGRow class
} // End of namespace
