// <fileinfo name="CTB_PRESUPUESTOS_DETRow.cs">
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
	/// Represents a record in the <c>CTB_PRESUPUESTOS_DET</c> table.
	/// </summary>
	public class CTB_PRESUPUESTOS_DETRow : CTB_PRESUPUESTOS_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PRESUPUESTOS_DETRow"/> class.
		/// </summary>
		public CTB_PRESUPUESTOS_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTB_PRESUPUESTOS_DETRow Clonar()
		{
			return (CTB_PRESUPUESTOS_DETRow)this.MemberwiseClone();
		}
	} // End of CTB_PRESUPUESTOS_DETRow class
} // End of namespace
