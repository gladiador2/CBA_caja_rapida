// <fileinfo name="PRESUPUESTOS_DET_CASOSRow.cs">
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
	/// Represents a record in the <c>PRESUPUESTOS_DET_CASOS</c> table.
	/// </summary>
	public class PRESUPUESTOS_DET_CASOSRow : PRESUPUESTOS_DET_CASOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DET_CASOSRow"/> class.
		/// </summary>
		public PRESUPUESTOS_DET_CASOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PRESUPUESTOS_DET_CASOSRow Clonar()
		{
			return (PRESUPUESTOS_DET_CASOSRow)this.MemberwiseClone();
		}
	} // End of PRESUPUESTOS_DET_CASOSRow class
} // End of namespace
