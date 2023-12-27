// <fileinfo name="INGRESO_STOCK_DETALLESRow.cs">
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
	/// Represents a record in the <c>INGRESO_STOCK_DETALLES</c> table.
	/// </summary>
	public class INGRESO_STOCK_DETALLESRow : INGRESO_STOCK_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCK_DETALLESRow"/> class.
		/// </summary>
		public INGRESO_STOCK_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public INGRESO_STOCK_DETALLESRow Clonar()
		{
			return (INGRESO_STOCK_DETALLESRow)this.MemberwiseClone();
		}
	} // End of INGRESO_STOCK_DETALLESRow class
} // End of namespace
