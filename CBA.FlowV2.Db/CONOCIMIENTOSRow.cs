// <fileinfo name="CONOCIMIENTOSRow.cs">
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
	/// Represents a record in the <c>CONOCIMIENTOS</c> table.
	/// </summary>
	public class CONOCIMIENTOSRow : CONOCIMIENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CONOCIMIENTOSRow"/> class.
		/// </summary>
		public CONOCIMIENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CONOCIMIENTOSRow Clonar()
		{
			return (CONOCIMIENTOSRow)this.MemberwiseClone();
		}
	} // End of CONOCIMIENTOSRow class
} // End of namespace
