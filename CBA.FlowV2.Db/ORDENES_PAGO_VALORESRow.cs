// <fileinfo name="ORDENES_PAGO_VALORESRow.cs">
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
	/// Represents a record in the <c>ORDENES_PAGO_VALORES</c> table.
	/// </summary>
	public class ORDENES_PAGO_VALORESRow : ORDENES_PAGO_VALORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_VALORESRow"/> class.
		/// </summary>
		public ORDENES_PAGO_VALORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ORDENES_PAGO_VALORESRow Clonar()
		{
			return (ORDENES_PAGO_VALORESRow)this.MemberwiseClone();
		}
	} // End of ORDENES_PAGO_VALORESRow class
} // End of namespace
