// <fileinfo name="HORARIOS_DIASRow.cs">
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
	/// Represents a record in the <c>HORARIOS_DIAS</c> table.
	/// </summary>
	public class HORARIOS_DIASRow : HORARIOS_DIASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_DIASRow"/> class.
		/// </summary>
		public HORARIOS_DIASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public HORARIOS_DIASRow Clonar()
		{
			return (HORARIOS_DIASRow)this.MemberwiseClone();
		}
	} // End of HORARIOS_DIASRow class
} // End of namespace
