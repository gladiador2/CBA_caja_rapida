// <fileinfo name="ESCALAS_PREMIOSRow.cs">
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
	/// Represents a record in the <c>ESCALAS_PREMIOS</c> table.
	/// </summary>
	public class ESCALAS_PREMIOSRow : ESCALAS_PREMIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ESCALAS_PREMIOSRow"/> class.
		/// </summary>
		public ESCALAS_PREMIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ESCALAS_PREMIOSRow Clonar()
		{
			return (ESCALAS_PREMIOSRow)this.MemberwiseClone();
		}
	} // End of ESCALAS_PREMIOSRow class
} // End of namespace
