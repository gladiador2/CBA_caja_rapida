// <fileinfo name="TIPOS_REQUISITO_FLUJORow.cs">
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
	/// Represents a record in the <c>TIPOS_REQUISITO_FLUJO</c> table.
	/// </summary>
	public class TIPOS_REQUISITO_FLUJORow : TIPOS_REQUISITO_FLUJORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_REQUISITO_FLUJORow"/> class.
		/// </summary>
		public TIPOS_REQUISITO_FLUJORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_REQUISITO_FLUJORow Clonar()
		{
			return (TIPOS_REQUISITO_FLUJORow)this.MemberwiseClone();
		}
	} // End of TIPOS_REQUISITO_FLUJORow class
} // End of namespace
