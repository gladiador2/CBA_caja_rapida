// <fileinfo name="TIPOS_IMPUESTOSRow.cs">
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
	/// Represents a record in the <c>TIPOS_IMPUESTOS</c> table.
	/// </summary>
	public class TIPOS_IMPUESTOSRow : TIPOS_IMPUESTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_IMPUESTOSRow"/> class.
		/// </summary>
		public TIPOS_IMPUESTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_IMPUESTOSRow Clonar()
		{
			return (TIPOS_IMPUESTOSRow)this.MemberwiseClone();
		}
	} // End of TIPOS_IMPUESTOSRow class
} // End of namespace
