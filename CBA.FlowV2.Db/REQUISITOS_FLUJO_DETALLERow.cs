// <fileinfo name="REQUISITOS_FLUJO_DETALLERow.cs">
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
	/// Represents a record in the <c>REQUISITOS_FLUJO_DETALLE</c> table.
	/// </summary>
	public class REQUISITOS_FLUJO_DETALLERow : REQUISITOS_FLUJO_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REQUISITOS_FLUJO_DETALLERow"/> class.
		/// </summary>
		public REQUISITOS_FLUJO_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REQUISITOS_FLUJO_DETALLERow Clonar()
		{
			return (REQUISITOS_FLUJO_DETALLERow)this.MemberwiseClone();
		}
	} // End of REQUISITOS_FLUJO_DETALLERow class
} // End of namespace
