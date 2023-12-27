// <fileinfo name="FACTURAS_CLIENTE_DET_INF_CORow.cs">
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
	/// Represents a record in the <c>FACTURAS_CLIENTE_DET_INF_CO</c> view.
	/// </summary>
	public class FACTURAS_CLIENTE_DET_INF_CORow : FACTURAS_CLIENTE_DET_INF_CORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> class.
		/// </summary>
		public FACTURAS_CLIENTE_DET_INF_CORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FACTURAS_CLIENTE_DET_INF_CORow Clonar()
		{
			return (FACTURAS_CLIENTE_DET_INF_CORow)this.MemberwiseClone();
		}
	} // End of FACTURAS_CLIENTE_DET_INF_CORow class
} // End of namespace
