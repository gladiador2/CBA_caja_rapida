// <fileinfo name="CTACTE_BANCARIASRow.cs">
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
	/// Represents a record in the <c>CTACTE_BANCARIAS</c> table.
	/// </summary>
	public class CTACTE_BANCARIASRow : CTACTE_BANCARIASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIASRow"/> class.
		/// </summary>
		public CTACTE_BANCARIASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_BANCARIASRow Clonar()
		{
			return (CTACTE_BANCARIASRow)this.MemberwiseClone();
		}
	} // End of CTACTE_BANCARIASRow class
} // End of namespace
