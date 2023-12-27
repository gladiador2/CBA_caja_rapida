// <fileinfo name="PLANILLA_PAGOS_DETALLESRow.cs">
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
	/// Represents a record in the <c>PLANILLA_PAGOS_DETALLES</c> table.
	/// </summary>
	public class PLANILLA_PAGOS_DETALLESRow : PLANILLA_PAGOS_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGOS_DETALLESRow"/> class.
		/// </summary>
		public PLANILLA_PAGOS_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANILLA_PAGOS_DETALLESRow Clonar()
		{
			return (PLANILLA_PAGOS_DETALLESRow)this.MemberwiseClone();
		}
	} // End of PLANILLA_PAGOS_DETALLESRow class
} // End of namespace
