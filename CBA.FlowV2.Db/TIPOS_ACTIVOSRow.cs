// <fileinfo name="TIPOS_ACTIVOSRow.cs">
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
	/// Represents a record in the <c>TIPOS_ACTIVOS</c> table.
	/// </summary>
	public class TIPOS_ACTIVOSRow : TIPOS_ACTIVOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ACTIVOSRow"/> class.
		/// </summary>
		public TIPOS_ACTIVOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_ACTIVOSRow Clonar()
		{
			return (TIPOS_ACTIVOSRow)this.MemberwiseClone();
		}
	} // End of TIPOS_ACTIVOSRow class
} // End of namespace
