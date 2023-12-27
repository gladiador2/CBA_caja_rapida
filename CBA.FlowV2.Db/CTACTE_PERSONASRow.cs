// <fileinfo name="CTACTE_PERSONASRow.cs">
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
	/// Represents a record in the <c>CTACTE_PERSONAS</c> table.
	/// </summary>
	public class CTACTE_PERSONASRow : CTACTE_PERSONASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONASRow"/> class.
		/// </summary>
		public CTACTE_PERSONASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_PERSONASRow Clonar()
		{
			return (CTACTE_PERSONASRow)this.MemberwiseClone();
		}
	} // End of CTACTE_PERSONASRow class
} // End of namespace
