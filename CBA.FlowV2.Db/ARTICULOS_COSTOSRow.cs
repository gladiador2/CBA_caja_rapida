// <fileinfo name="ARTICULOS_COSTOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_COSTOS</c> table.
	/// </summary>
	public class ARTICULOS_COSTOSRow : ARTICULOS_COSTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTOSRow"/> class.
		/// </summary>
		public ARTICULOS_COSTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_COSTOSRow Clonar()
		{
			return (ARTICULOS_COSTOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_COSTOSRow class
} // End of namespace
