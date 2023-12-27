// <fileinfo name="ARTICULOS_LOTESRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_LOTES</c> table.
	/// </summary>
	public class ARTICULOS_LOTESRow : ARTICULOS_LOTESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_LOTESRow"/> class.
		/// </summary>
		public ARTICULOS_LOTESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_LOTESRow Clonar()
		{
			return (ARTICULOS_LOTESRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_LOTESRow class
} // End of namespace
