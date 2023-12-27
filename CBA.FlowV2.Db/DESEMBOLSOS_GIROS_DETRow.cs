// <fileinfo name="DESEMBOLSOS_GIROS_DETRow.cs">
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
	/// Represents a record in the <c>DESEMBOLSOS_GIROS_DET</c> table.
	/// </summary>
	public class DESEMBOLSOS_GIROS_DETRow : DESEMBOLSOS_GIROS_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROS_DETRow"/> class.
		/// </summary>
		public DESEMBOLSOS_GIROS_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DESEMBOLSOS_GIROS_DETRow Clonar()
		{
			return (DESEMBOLSOS_GIROS_DETRow)this.MemberwiseClone();
		}
	} // End of DESEMBOLSOS_GIROS_DETRow class
} // End of namespace
