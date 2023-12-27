// <fileinfo name="CTACTE_CONDICIONES_PAGORow.cs">
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
	/// Represents a record in the <c>CTACTE_CONDICIONES_PAGO</c> table.
	/// </summary>
	public class CTACTE_CONDICIONES_PAGORow : CTACTE_CONDICIONES_PAGORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONDICIONES_PAGORow"/> class.
		/// </summary>
		public CTACTE_CONDICIONES_PAGORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTACTE_CONDICIONES_PAGORow Clonar()
		{
			return (CTACTE_CONDICIONES_PAGORow)this.MemberwiseClone();
		}
	} // End of CTACTE_CONDICIONES_PAGORow class
} // End of namespace
