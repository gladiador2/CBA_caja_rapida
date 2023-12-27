// <fileinfo name="CTACTE_DOCUMENTOSRow.cs">
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
	/// Represents a record in the <c>CTACTE_DOCUMENTOS</c> table.
	/// </summary>
	public class CTACTE_DOCUMENTOSRow : CTACTE_DOCUMENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_DOCUMENTOSRow"/> class.
		/// </summary>
		public CTACTE_DOCUMENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_DOCUMENTOSRow Clonar()
		{
			return (CTACTE_DOCUMENTOSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_DOCUMENTOSRow class
} // End of namespace
