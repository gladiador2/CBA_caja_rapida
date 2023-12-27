// <fileinfo name="TIPOS_RELACIONES_PERSONASRow.cs">
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
	/// Represents a record in the <c>TIPOS_RELACIONES_PERSONAS</c> table.
	/// </summary>
	public class TIPOS_RELACIONES_PERSONASRow : TIPOS_RELACIONES_PERSONASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_RELACIONES_PERSONASRow"/> class.
		/// </summary>
		public TIPOS_RELACIONES_PERSONASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_RELACIONES_PERSONASRow Clonar()
		{
			return (TIPOS_RELACIONES_PERSONASRow)this.MemberwiseClone();
		}
	} // End of TIPOS_RELACIONES_PERSONASRow class
} // End of namespace
