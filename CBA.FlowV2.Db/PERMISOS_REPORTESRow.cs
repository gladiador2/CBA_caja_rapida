// <fileinfo name="PERMISOS_REPORTESRow.cs">
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
	/// Represents a record in the <c>PERMISOS_REPORTES</c> table.
	/// </summary>
	public class PERMISOS_REPORTESRow : PERMISOS_REPORTESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PERMISOS_REPORTESRow"/> class.
		/// </summary>
		public PERMISOS_REPORTESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PERMISOS_REPORTESRow Clonar()
		{
			return (PERMISOS_REPORTESRow)this.MemberwiseClone();
		}
	} // End of PERMISOS_REPORTESRow class
} // End of namespace
