// <fileinfo name="FUNCIONARIOS_HIJOSRow.cs">
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
	/// Represents a record in the <c>FUNCIONARIOS_HIJOS</c> table.
	/// </summary>
	public class FUNCIONARIOS_HIJOSRow : FUNCIONARIOS_HIJOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_HIJOSRow"/> class.
		/// </summary>
		public FUNCIONARIOS_HIJOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FUNCIONARIOS_HIJOSRow Clonar()
		{
			return (FUNCIONARIOS_HIJOSRow)this.MemberwiseClone();
		}
	} // End of FUNCIONARIOS_HIJOSRow class
} // End of namespace
