// <fileinfo name="PAGO_CONTRATISTASRow.cs">
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
	/// Represents a record in the <c>PAGO_CONTRATISTAS</c> table.
	/// </summary>
	public class PAGO_CONTRATISTASRow : PAGO_CONTRATISTASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PAGO_CONTRATISTASRow"/> class.
		/// </summary>
		public PAGO_CONTRATISTASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PAGO_CONTRATISTASRow Clonar()
		{
			return (PAGO_CONTRATISTASRow)this.MemberwiseClone();
		}
	} // End of PAGO_CONTRATISTASRow class
} // End of namespace
