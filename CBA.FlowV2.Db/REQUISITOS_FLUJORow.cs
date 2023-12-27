// <fileinfo name="REQUISITOS_FLUJORow.cs">
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
	/// Represents a record in the <c>REQUISITOS_FLUJO</c> table.
	/// </summary>
	public class REQUISITOS_FLUJORow : REQUISITOS_FLUJORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REQUISITOS_FLUJORow"/> class.
		/// </summary>
		public REQUISITOS_FLUJORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REQUISITOS_FLUJORow Clonar()
		{
			return (REQUISITOS_FLUJORow)this.MemberwiseClone();
		}
	} // End of REQUISITOS_FLUJORow class
} // End of namespace
