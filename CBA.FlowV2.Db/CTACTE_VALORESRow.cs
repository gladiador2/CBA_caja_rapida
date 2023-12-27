// <fileinfo name="CTACTE_VALORESRow.cs">
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
	/// Represents a record in the <c>CTACTE_VALORES</c> table.
	/// </summary>
	public class CTACTE_VALORESRow : CTACTE_VALORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_VALORESRow"/> class.
		/// </summary>
		public CTACTE_VALORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_VALORESRow Clonar()
		{
			return (CTACTE_VALORESRow)this.MemberwiseClone();
		}
	} // End of CTACTE_VALORESRow class
} // End of namespace
