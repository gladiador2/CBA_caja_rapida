// <fileinfo name="INGRESO_STOCKRow.cs">
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
	/// Represents a record in the <c>INGRESO_STOCK</c> table.
	/// </summary>
	public class INGRESO_STOCKRow : INGRESO_STOCKRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCKRow"/> class.
		/// </summary>
		public INGRESO_STOCKRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public INGRESO_STOCKRow Clonar()
		{
			return (INGRESO_STOCKRow)this.MemberwiseClone();
		}
	} // End of INGRESO_STOCKRow class
} // End of namespace
