// <fileinfo name="STOCK_ARTICULOS_RESERVARow.cs">
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
	/// Represents a record in the <c>STOCK_ARTICULOS_RESERVA</c> view.
	/// </summary>
	public class STOCK_ARTICULOS_RESERVARow : STOCK_ARTICULOS_RESERVARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_ARTICULOS_RESERVARow"/> class.
		/// </summary>
		public STOCK_ARTICULOS_RESERVARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_ARTICULOS_RESERVARow Clonar()
		{
			return (STOCK_ARTICULOS_RESERVARow)this.MemberwiseClone();
		}
	} // End of STOCK_ARTICULOS_RESERVARow class
} // End of namespace
