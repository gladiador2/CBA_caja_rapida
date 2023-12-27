// <fileinfo name="FUNCIONARIOS_COMISIONESRow.cs">
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
	/// Represents a record in the <c>FUNCIONARIOS_COMISIONES</c> table.
	/// </summary>
	public class FUNCIONARIOS_COMISIONESRow : FUNCIONARIOS_COMISIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_COMISIONESRow"/> class.
		/// </summary>
		public FUNCIONARIOS_COMISIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FUNCIONARIOS_COMISIONESRow Clonar()
		{
			return (FUNCIONARIOS_COMISIONESRow)this.MemberwiseClone();
		}
	} // End of FUNCIONARIOS_COMISIONESRow class
} // End of namespace
