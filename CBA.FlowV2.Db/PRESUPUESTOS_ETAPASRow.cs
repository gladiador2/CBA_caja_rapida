// <fileinfo name="PRESUPUESTOS_ETAPASRow.cs">
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
	/// Represents a record in the <c>PRESUPUESTOS_ETAPAS</c> table.
	/// </summary>
	public class PRESUPUESTOS_ETAPASRow : PRESUPUESTOS_ETAPASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_ETAPASRow"/> class.
		/// </summary>
		public PRESUPUESTOS_ETAPASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PRESUPUESTOS_ETAPASRow Clonar()
		{
			return (PRESUPUESTOS_ETAPASRow)this.MemberwiseClone();
		}
	} // End of PRESUPUESTOS_ETAPASRow class
} // End of namespace
