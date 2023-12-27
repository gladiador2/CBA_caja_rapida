// <fileinfo name="ASIGNACIONES_CARGOSRow.cs">
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
	/// Represents a record in the <c>ASIGNACIONES_CARGOS</c> table.
	/// </summary>
	public class ASIGNACIONES_CARGOSRow : ASIGNACIONES_CARGOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ASIGNACIONES_CARGOSRow"/> class.
		/// </summary>
		public ASIGNACIONES_CARGOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ASIGNACIONES_CARGOSRow Clonar()
		{
			return (ASIGNACIONES_CARGOSRow)this.MemberwiseClone();
		}
	} // End of ASIGNACIONES_CARGOSRow class
} // End of namespace
