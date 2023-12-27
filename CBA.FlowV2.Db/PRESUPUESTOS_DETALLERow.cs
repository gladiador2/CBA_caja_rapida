// <fileinfo name="PRESUPUESTOS_DETALLERow.cs">
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
	/// Represents a record in the <c>PRESUPUESTOS_DETALLE</c> table.
	/// </summary>
	public class PRESUPUESTOS_DETALLERow : PRESUPUESTOS_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DETALLERow"/> class.
		/// </summary>
		public PRESUPUESTOS_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PRESUPUESTOS_DETALLERow Clonar()
		{
			return (PRESUPUESTOS_DETALLERow)this.MemberwiseClone();
		}
	} // End of PRESUPUESTOS_DETALLERow class
} // End of namespace
