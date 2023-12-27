// <fileinfo name="IMPUESTOS_COMPUESTOSRow.cs">
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
	/// Represents a record in the <c>IMPUESTOS_COMPUESTOS</c> table.
	/// </summary>
	public class IMPUESTOS_COMPUESTOSRow : IMPUESTOS_COMPUESTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IMPUESTOS_COMPUESTOSRow"/> class.
		/// </summary>
		public IMPUESTOS_COMPUESTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public IMPUESTOS_COMPUESTOSRow Clonar()
		{
			return (IMPUESTOS_COMPUESTOSRow)this.MemberwiseClone();
		}
	} // End of IMPUESTOS_COMPUESTOSRow class
} // End of namespace
