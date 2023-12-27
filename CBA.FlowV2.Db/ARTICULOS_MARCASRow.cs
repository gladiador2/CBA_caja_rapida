// <fileinfo name="ARTICULOS_MARCASRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_MARCAS</c> table.
	/// </summary>
	public class ARTICULOS_MARCASRow : ARTICULOS_MARCASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_MARCASRow"/> class.
		/// </summary>
		public ARTICULOS_MARCASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_MARCASRow Clonar()
		{
			return (ARTICULOS_MARCASRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_MARCASRow class
} // End of namespace
