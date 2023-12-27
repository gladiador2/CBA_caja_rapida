// <fileinfo name="CTACTE_BANCOSRow.cs">
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
	/// Represents a record in the <c>CTACTE_BANCOS</c> table.
	/// </summary>
	public class CTACTE_BANCOSRow : CTACTE_BANCOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCOSRow"/> class.
		/// </summary>
		public CTACTE_BANCOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_BANCOSRow Clonar()
		{
			return (CTACTE_BANCOSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_BANCOSRow class
} // End of namespace
