// <fileinfo name="CTACTE_BANCARIAS_MOVRow.cs">
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
	/// Represents a record in the <c>CTACTE_BANCARIAS_MOV</c> table.
	/// </summary>
	public class CTACTE_BANCARIAS_MOVRow : CTACTE_BANCARIAS_MOVRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_MOVRow"/> class.
		/// </summary>
		public CTACTE_BANCARIAS_MOVRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_BANCARIAS_MOVRow Clonar()
		{
			return (CTACTE_BANCARIAS_MOVRow)this.MemberwiseClone();
		}
	} // End of CTACTE_BANCARIAS_MOVRow class
} // End of namespace
