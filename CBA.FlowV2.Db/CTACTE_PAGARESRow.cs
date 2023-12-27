// <fileinfo name="CTACTE_PAGARESRow.cs">
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
	/// Represents a record in the <c>CTACTE_PAGARES</c> table.
	/// </summary>
	public class CTACTE_PAGARESRow : CTACTE_PAGARESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGARESRow"/> class.
		/// </summary>
		public CTACTE_PAGARESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_PAGARESRow Clonar()
		{
			return (CTACTE_PAGARESRow)this.MemberwiseClone();
		}
	} // End of CTACTE_PAGARESRow class
} // End of namespace
