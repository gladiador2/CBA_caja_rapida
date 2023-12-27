// <fileinfo name="CTACTE_RECIBOSRow.cs">
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
	/// Represents a record in the <c>CTACTE_RECIBOS</c> table.
	/// </summary>
	public class CTACTE_RECIBOSRow : CTACTE_RECIBOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RECIBOSRow"/> class.
		/// </summary>
		public CTACTE_RECIBOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_RECIBOSRow Clonar()
		{
			return (CTACTE_RECIBOSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_RECIBOSRow class
} // End of namespace
