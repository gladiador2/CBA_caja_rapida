// <fileinfo name="TIPOS_VEHICULORow.cs">
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
	/// Represents a record in the <c>TIPOS_VEHICULO</c> table.
	/// </summary>
	public class TIPOS_VEHICULORow : TIPOS_VEHICULORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_VEHICULORow"/> class.
		/// </summary>
		public TIPOS_VEHICULORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_VEHICULORow Clonar()
		{
			return (TIPOS_VEHICULORow)this.MemberwiseClone();
		}
	} // End of TIPOS_VEHICULORow class
} // End of namespace
