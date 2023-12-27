// <fileinfo name="TIPOS_TAREARow.cs">
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
	/// Represents a record in the <c>TIPOS_TAREA</c> table.
	/// </summary>
	public class TIPOS_TAREARow : TIPOS_TAREARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_TAREARow"/> class.
		/// </summary>
		public TIPOS_TAREARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_TAREARow Clonar()
		{
			return (TIPOS_TAREARow)this.MemberwiseClone();
		}
	} // End of TIPOS_TAREARow class
} // End of namespace
