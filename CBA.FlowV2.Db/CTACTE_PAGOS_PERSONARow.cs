// <fileinfo name="CTACTE_PAGOS_PERSONARow.cs">
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
	/// Represents a record in the <c>CTACTE_PAGOS_PERSONA</c> table.
	/// </summary>
	public class CTACTE_PAGOS_PERSONARow : CTACTE_PAGOS_PERSONARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERSONARow"/> class.
		/// </summary>
		public CTACTE_PAGOS_PERSONARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_PAGOS_PERSONARow Clonar()
		{
			return (CTACTE_PAGOS_PERSONARow)this.MemberwiseClone();
		}
	} // End of CTACTE_PAGOS_PERSONARow class
} // End of namespace
