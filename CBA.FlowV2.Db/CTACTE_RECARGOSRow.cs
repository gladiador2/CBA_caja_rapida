// <fileinfo name="CTACTE_RECARGOSRow.cs">
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
	/// Represents a record in the <c>CTACTE_RECARGOS</c> table.
	/// </summary>
	public class CTACTE_RECARGOSRow : CTACTE_RECARGOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RECARGOSRow"/> class.
		/// </summary>
		public CTACTE_RECARGOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_RECARGOSRow Clonar()
		{
			return (CTACTE_RECARGOSRow)this.MemberwiseClone();
		}
	} // End of CTACTE_RECARGOSRow class
} // End of namespace
