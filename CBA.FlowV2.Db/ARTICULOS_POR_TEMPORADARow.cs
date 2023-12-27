// <fileinfo name="ARTICULOS_POR_TEMPORADARow.cs">
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
	/// Represents a record in the <c>ARTICULOS_POR_TEMPORADA</c> table.
	/// </summary>
	public class ARTICULOS_POR_TEMPORADARow : ARTICULOS_POR_TEMPORADARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_POR_TEMPORADARow"/> class.
		/// </summary>
		public ARTICULOS_POR_TEMPORADARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_POR_TEMPORADARow Clonar()
		{
			return (ARTICULOS_POR_TEMPORADARow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_POR_TEMPORADARow class
} // End of namespace
