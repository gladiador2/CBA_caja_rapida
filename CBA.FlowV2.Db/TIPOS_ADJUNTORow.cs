// <fileinfo name="TIPOS_ADJUNTORow.cs">
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
	/// Represents a record in the <c>TIPOS_ADJUNTO</c> table.
	/// </summary>
	public class TIPOS_ADJUNTORow : TIPOS_ADJUNTORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ADJUNTORow"/> class.
		/// </summary>
		public TIPOS_ADJUNTORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_ADJUNTORow Clonar()
		{
			return (TIPOS_ADJUNTORow)this.MemberwiseClone();
		}
	} // End of TIPOS_ADJUNTORow class
} // End of namespace
