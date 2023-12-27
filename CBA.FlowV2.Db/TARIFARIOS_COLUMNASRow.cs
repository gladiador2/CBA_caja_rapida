// <fileinfo name="TARIFARIOS_COLUMNASRow.cs">
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
	/// Represents a record in the <c>TARIFARIOS_COLUMNAS</c> table.
	/// </summary>
	public class TARIFARIOS_COLUMNASRow : TARIFARIOS_COLUMNASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_COLUMNASRow"/> class.
		/// </summary>
		public TARIFARIOS_COLUMNASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TARIFARIOS_COLUMNASRow Clonar()
		{
			return (TARIFARIOS_COLUMNASRow)this.MemberwiseClone();
		}
	} // End of TARIFARIOS_COLUMNASRow class
} // End of namespace
