// <fileinfo name="FUNCIONARIOS_VACACIONESRow.cs">
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
	/// Represents a record in the <c>FUNCIONARIOS_VACACIONES</c> table.
	/// </summary>
	public class FUNCIONARIOS_VACACIONESRow : FUNCIONARIOS_VACACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_VACACIONESRow"/> class.
		/// </summary>
		public FUNCIONARIOS_VACACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FUNCIONARIOS_VACACIONESRow Clonar()
		{
			return (FUNCIONARIOS_VACACIONESRow)this.MemberwiseClone();
		}
	} // End of FUNCIONARIOS_VACACIONESRow class
} // End of namespace
