// <fileinfo name="CONTENEDORES_OPERACIONESRow.cs">
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
	/// Represents a record in the <c>CONTENEDORES_OPERACIONES</c> table.
	/// </summary>
	public class CONTENEDORES_OPERACIONESRow : CONTENEDORES_OPERACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_OPERACIONESRow"/> class.
		/// </summary>
		public CONTENEDORES_OPERACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CONTENEDORES_OPERACIONESRow Clonar()
		{
			return (CONTENEDORES_OPERACIONESRow)this.MemberwiseClone();
		}
	} // End of CONTENEDORES_OPERACIONESRow class
} // End of namespace
