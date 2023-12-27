// <fileinfo name="STOCK_INVENTARIO_DETALLERow.cs">
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
	/// Represents a record in the <c>STOCK_INVENTARIO_DETALLE</c> table.
	/// </summary>
	public class STOCK_INVENTARIO_DETALLERow : STOCK_INVENTARIO_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_INVENTARIO_DETALLERow"/> class.
		/// </summary>
		public STOCK_INVENTARIO_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_INVENTARIO_DETALLERow Clonar()
		{
			return (STOCK_INVENTARIO_DETALLERow)this.MemberwiseClone();
		}
	} // End of STOCK_INVENTARIO_DETALLERow class
} // End of namespace
