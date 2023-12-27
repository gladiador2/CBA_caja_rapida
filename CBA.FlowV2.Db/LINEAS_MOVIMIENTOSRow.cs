// <fileinfo name="LINEAS_MOVIMIENTOSRow.cs">
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
	/// Represents a record in the <c>LINEAS_MOVIMIENTOS</c> table.
	/// </summary>
	public class LINEAS_MOVIMIENTOSRow : LINEAS_MOVIMIENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LINEAS_MOVIMIENTOSRow"/> class.
		/// </summary>
		public LINEAS_MOVIMIENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LINEAS_MOVIMIENTOSRow Clonar()
		{
			return (LINEAS_MOVIMIENTOSRow)this.MemberwiseClone();
		}
	} // End of LINEAS_MOVIMIENTOSRow class
} // End of namespace
