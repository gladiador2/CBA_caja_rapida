// <fileinfo name="CAMPOS_CONFIGURABLES_ITEMSRow.cs">
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
	/// Represents a record in the <c>CAMPOS_CONFIGURABLES_ITEMS</c> table.
	/// </summary>
	public class CAMPOS_CONFIGURABLES_ITEMSRow : CAMPOS_CONFIGURABLES_ITEMSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONFIGURABLES_ITEMSRow"/> class.
		/// </summary>
		public CAMPOS_CONFIGURABLES_ITEMSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CAMPOS_CONFIGURABLES_ITEMSRow Clonar()
		{
			return (CAMPOS_CONFIGURABLES_ITEMSRow)this.MemberwiseClone();
		}
	} // End of CAMPOS_CONFIGURABLES_ITEMSRow class
} // End of namespace
