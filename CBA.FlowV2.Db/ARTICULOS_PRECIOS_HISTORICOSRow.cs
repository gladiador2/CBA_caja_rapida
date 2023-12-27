// <fileinfo name="ARTICULOS_PRECIOS_HISTORICOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_PRECIOS_HISTORICOS</c> table.
	/// </summary>
	public class ARTICULOS_PRECIOS_HISTORICOSRow : ARTICULOS_PRECIOS_HISTORICOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PRECIOS_HISTORICOSRow"/> class.
		/// </summary>
		public ARTICULOS_PRECIOS_HISTORICOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_PRECIOS_HISTORICOSRow Clonar()
		{
			return (ARTICULOS_PRECIOS_HISTORICOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_PRECIOS_HISTORICOSRow class
} // End of namespace
