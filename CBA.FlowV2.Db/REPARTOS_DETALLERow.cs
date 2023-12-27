// <fileinfo name="REPARTOS_DETALLERow.cs">
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
	/// Represents a record in the <c>REPARTOS_DETALLE</c> table.
	/// </summary>
	public class REPARTOS_DETALLERow : REPARTOS_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTOS_DETALLERow"/> class.
		/// </summary>
		public REPARTOS_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REPARTOS_DETALLERow Clonar()
		{
			return (REPARTOS_DETALLERow)this.MemberwiseClone();
		}
	} // End of REPARTOS_DETALLERow class
} // End of namespace
