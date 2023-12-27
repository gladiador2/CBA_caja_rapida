// <fileinfo name="TEXTOS_PREDEFINIDOSRow.cs">
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
	/// Represents a record in the <c>TEXTOS_PREDEFINIDOS</c> table.
	/// </summary>
	public class TEXTOS_PREDEFINIDOSRow : TEXTOS_PREDEFINIDOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TEXTOS_PREDEFINIDOSRow"/> class.
		/// </summary>
		public TEXTOS_PREDEFINIDOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TEXTOS_PREDEFINIDOSRow Clonar()
		{
			return (TEXTOS_PREDEFINIDOSRow)this.MemberwiseClone();
		}
	} // End of TEXTOS_PREDEFINIDOSRow class
} // End of namespace
