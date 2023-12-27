// <fileinfo name="TIPOS_CATALOGOSRow.cs">
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
	/// Represents a record in the <c>TIPOS_CATALOGOS</c> table.
	/// </summary>
	public class TIPOS_CATALOGOSRow : TIPOS_CATALOGOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_CATALOGOSRow"/> class.
		/// </summary>
		public TIPOS_CATALOGOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_CATALOGOSRow Clonar()
		{
			return (TIPOS_CATALOGOSRow)this.MemberwiseClone();
		}
	} // End of TIPOS_CATALOGOSRow class
} // End of namespace
