// <fileinfo name="CENTROS_COSTORow.cs">
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
	/// Represents a record in the <c>CENTROS_COSTO</c> table.
	/// </summary>
	public class CENTROS_COSTORow : CENTROS_COSTORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CENTROS_COSTORow"/> class.
		/// </summary>
		public CENTROS_COSTORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CENTROS_COSTORow Clonar()
		{
			return (CENTROS_COSTORow)this.MemberwiseClone();
		}
	} // End of CENTROS_COSTORow class
} // End of namespace
