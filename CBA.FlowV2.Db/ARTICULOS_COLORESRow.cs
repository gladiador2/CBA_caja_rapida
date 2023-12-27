// <fileinfo name="ARTICULOS_COLORESRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_COLORES</c> table.
	/// </summary>
	public class ARTICULOS_COLORESRow : ARTICULOS_COLORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COLORESRow"/> class.
		/// </summary>
		public ARTICULOS_COLORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_COLORESRow Clonar()
		{
			return (ARTICULOS_COLORESRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_COLORESRow class
} // End of namespace
