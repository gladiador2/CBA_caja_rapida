// <fileinfo name="CONTENEDORES_MOVIMIENTOSRow.cs">
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
	/// Represents a record in the <c>CONTENEDORES_MOVIMIENTOS</c> table.
	/// </summary>
	public class CONTENEDORES_MOVIMIENTOSRow : CONTENEDORES_MOVIMIENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_MOVIMIENTOSRow"/> class.
		/// </summary>
		public CONTENEDORES_MOVIMIENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CONTENEDORES_MOVIMIENTOSRow Clonar()
		{
			return (CONTENEDORES_MOVIMIENTOSRow)this.MemberwiseClone();
		}
	} // End of CONTENEDORES_MOVIMIENTOSRow class
} // End of namespace
