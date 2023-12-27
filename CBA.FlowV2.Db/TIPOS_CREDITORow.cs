// <fileinfo name="TIPOS_CREDITORow.cs">
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
	/// Represents a record in the <c>TIPOS_CREDITO</c> table.
	/// </summary>
	public class TIPOS_CREDITORow : TIPOS_CREDITORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_CREDITORow"/> class.
		/// </summary>
		public TIPOS_CREDITORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_CREDITORow Clonar()
		{
			return (TIPOS_CREDITORow)this.MemberwiseClone();
		}
	} // End of TIPOS_CREDITORow class
} // End of namespace
