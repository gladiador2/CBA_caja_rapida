// <fileinfo name="ARTICULOS_FAMILIASRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_FAMILIAS</c> table.
	/// </summary>
	public class ARTICULOS_FAMILIASRow : ARTICULOS_FAMILIASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FAMILIASRow"/> class.
		/// </summary>
		public ARTICULOS_FAMILIASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_FAMILIASRow Clonar()
		{
			return (ARTICULOS_FAMILIASRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_FAMILIASRow class
} // End of namespace
