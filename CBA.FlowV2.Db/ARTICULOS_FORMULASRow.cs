// <fileinfo name="ARTICULOS_FORMULASRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_FORMULAS</c> table.
	/// </summary>
	public class ARTICULOS_FORMULASRow : ARTICULOS_FORMULASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FORMULASRow"/> class.
		/// </summary>
		public ARTICULOS_FORMULASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_FORMULASRow Clonar()
		{
			return (ARTICULOS_FORMULASRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_FORMULASRow class
} // End of namespace
