// <fileinfo name="CTACTE_CAJARow.cs">
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
	/// Represents a record in the <c>CTACTE_CAJA</c> table.
	/// </summary>
	public class CTACTE_CAJARow : CTACTE_CAJARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJARow"/> class.
		/// </summary>
		public CTACTE_CAJARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_CAJARow Clonar()
		{
			return (CTACTE_CAJARow)this.MemberwiseClone();
		}
	} // End of CTACTE_CAJARow class
} // End of namespace
