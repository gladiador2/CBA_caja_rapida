// <fileinfo name="STOCK_UBICACIONRow.cs">
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
	/// Represents a record in the <c>STOCK_UBICACION</c> table.
	/// </summary>
	public class STOCK_UBICACIONRow : STOCK_UBICACIONRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_UBICACIONRow"/> class.
		/// </summary>
		public STOCK_UBICACIONRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_UBICACIONRow Clonar()
		{
			return (STOCK_UBICACIONRow)this.MemberwiseClone();
		}
	} // End of STOCK_UBICACIONRow class
} // End of namespace
