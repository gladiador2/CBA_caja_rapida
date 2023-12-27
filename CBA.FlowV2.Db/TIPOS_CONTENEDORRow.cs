// <fileinfo name="TIPOS_CONTENEDORRow.cs">
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
	/// Represents a record in the <c>TIPOS_CONTENEDOR</c> table.
	/// </summary>
	public class TIPOS_CONTENEDORRow : TIPOS_CONTENEDORRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_CONTENEDORRow"/> class.
		/// </summary>
		public TIPOS_CONTENEDORRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_CONTENEDORRow Clonar()
		{
			return (TIPOS_CONTENEDORRow)this.MemberwiseClone();
		}
	} // End of TIPOS_CONTENEDORRow class
} // End of namespace
