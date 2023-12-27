// <fileinfo name="VEHICULOSRow.cs">
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
	/// Represents a record in the <c>VEHICULOS</c> table.
	/// </summary>
	public class VEHICULOSRow : VEHICULOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VEHICULOSRow"/> class.
		/// </summary>
		public VEHICULOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public VEHICULOSRow Clonar()
		{
			return (VEHICULOSRow)this.MemberwiseClone();
		}
	} // End of VEHICULOSRow class
} // End of namespace
