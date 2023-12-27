// <fileinfo name="VARIABLES_SISTEMA_ENTIDADRow.cs">
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
	/// Represents a record in the <c>VARIABLES_SISTEMA_ENTIDAD</c> table.
	/// </summary>
	public class VARIABLES_SISTEMA_ENTIDADRow : VARIABLES_SISTEMA_ENTIDADRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VARIABLES_SISTEMA_ENTIDADRow"/> class.
		/// </summary>
		public VARIABLES_SISTEMA_ENTIDADRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public VARIABLES_SISTEMA_ENTIDADRow Clonar()
		{
			return (VARIABLES_SISTEMA_ENTIDADRow)this.MemberwiseClone();
		}
	} // End of VARIABLES_SISTEMA_ENTIDADRow class
} // End of namespace
