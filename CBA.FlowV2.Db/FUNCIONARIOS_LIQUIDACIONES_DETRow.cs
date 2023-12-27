// <fileinfo name="FUNCIONARIOS_LIQUIDACIONES_DETRow.cs">
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
	/// Represents a record in the <c>FUNCIONARIOS_LIQUIDACIONES_DET</c> table.
	/// </summary>
	public class FUNCIONARIOS_LIQUIDACIONES_DETRow : FUNCIONARIOS_LIQUIDACIONES_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_LIQUIDACIONES_DETRow"/> class.
		/// </summary>
		public FUNCIONARIOS_LIQUIDACIONES_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FUNCIONARIOS_LIQUIDACIONES_DETRow Clonar()
		{
			return (FUNCIONARIOS_LIQUIDACIONES_DETRow)this.MemberwiseClone();
		}
	} // End of FUNCIONARIOS_LIQUIDACIONES_DETRow class
} // End of namespace
