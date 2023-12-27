// <fileinfo name="HORARIOS_TURNOSRow.cs">
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
	/// Represents a record in the <c>HORARIOS_TURNOS</c> table.
	/// </summary>
	public class HORARIOS_TURNOSRow : HORARIOS_TURNOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_TURNOSRow"/> class.
		/// </summary>
		public HORARIOS_TURNOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public HORARIOS_TURNOSRow Clonar()
		{
			return (HORARIOS_TURNOSRow)this.MemberwiseClone();
		}
	} // End of HORARIOS_TURNOSRow class
} // End of namespace
