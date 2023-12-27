// <fileinfo name="RETENCION_ARTICULOSRow.cs">
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
	/// Represents a record in the <c>RETENCION_ARTICULOS</c> table.
	/// </summary>
	public class RETENCION_ARTICULOSRow : RETENCION_ARTICULOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RETENCION_ARTICULOSRow"/> class.
		/// </summary>
		public RETENCION_ARTICULOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public RETENCION_ARTICULOSRow Clonar()
		{
			return (RETENCION_ARTICULOSRow)this.MemberwiseClone();
		}
	} // End of RETENCION_ARTICULOSRow class
} // End of namespace
