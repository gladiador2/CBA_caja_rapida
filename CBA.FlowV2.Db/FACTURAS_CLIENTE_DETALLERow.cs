// <fileinfo name="FACTURAS_CLIENTE_DETALLERow.cs">
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
	/// Represents a record in the <c>FACTURAS_CLIENTE_DETALLE</c> table.
	/// </summary>
	public class FACTURAS_CLIENTE_DETALLERow : FACTURAS_CLIENTE_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DETALLERow"/> class.
		/// </summary>
		public FACTURAS_CLIENTE_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FACTURAS_CLIENTE_DETALLERow Clonar()
		{
			return (FACTURAS_CLIENTE_DETALLERow)this.MemberwiseClone();
		}
	} // End of FACTURAS_CLIENTE_DETALLERow class
} // End of namespace
