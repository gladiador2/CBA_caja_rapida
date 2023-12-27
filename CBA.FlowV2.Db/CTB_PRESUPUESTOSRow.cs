// <fileinfo name="CTB_PRESUPUESTOSRow.cs">
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
	/// Represents a record in the <c>CTB_PRESUPUESTOS</c> table.
	/// </summary>
	public class CTB_PRESUPUESTOSRow : CTB_PRESUPUESTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PRESUPUESTOSRow"/> class.
		/// </summary>
		public CTB_PRESUPUESTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTB_PRESUPUESTOSRow Clonar()
		{
			return (CTB_PRESUPUESTOSRow)this.MemberwiseClone();
		}
	} // End of CTB_PRESUPUESTOSRow class
} // End of namespace
