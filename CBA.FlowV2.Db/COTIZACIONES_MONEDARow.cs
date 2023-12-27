// <fileinfo name="COTIZACIONES_MONEDARow.cs">
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
	/// Represents a record in the <c>COTIZACIONES_MONEDA</c> view.
	/// </summary>
	public class COTIZACIONES_MONEDARow : COTIZACIONES_MONEDARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="COTIZACIONES_MONEDARow"/> class.
		/// </summary>
		public COTIZACIONES_MONEDARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public COTIZACIONES_MONEDARow Clonar()
		{
			return (COTIZACIONES_MONEDARow)this.MemberwiseClone();
		}
	} // End of COTIZACIONES_MONEDARow class
} // End of namespace
