// <fileinfo name="MOVIMIENTOS_VARIOS_TESORow.cs">
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
	/// Represents a record in the <c>MOVIMIENTOS_VARIOS_TESO</c> table.
	/// </summary>
	public class MOVIMIENTOS_VARIOS_TESORow : MOVIMIENTOS_VARIOS_TESORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MOVIMIENTOS_VARIOS_TESORow"/> class.
		/// </summary>
		public MOVIMIENTOS_VARIOS_TESORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public MOVIMIENTOS_VARIOS_TESORow Clonar()
		{
			return (MOVIMIENTOS_VARIOS_TESORow)this.MemberwiseClone();
		}
	} // End of MOVIMIENTOS_VARIOS_TESORow class
} // End of namespace
