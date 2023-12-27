// <fileinfo name="CTACTE_CONCEPTOSRow.cs">
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
	/// Represents a record in the <c>CTACTE_CONCEPTOS</c> table.
	/// </summary>
	public class CTACTE_CONCEPTOSRow : CTACTE_CONCEPTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONCEPTOSRow"/> class.
		/// </summary>
		public CTACTE_CONCEPTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_CONCEPTOSRow Clonar()
		{
			return (CTACTE_CONCEPTOSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_CONCEPTOSRow class
} // End of namespace
