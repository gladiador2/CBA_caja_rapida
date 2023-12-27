// <fileinfo name="CATALOGOS_DETALLERow.cs">
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
	/// Represents a record in the <c>CATALOGOS_DETALLE</c> table.
	/// </summary>
	public class CATALOGOS_DETALLERow : CATALOGOS_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CATALOGOS_DETALLERow"/> class.
		/// </summary>
		public CATALOGOS_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CATALOGOS_DETALLERow Clonar()
		{
			return (CATALOGOS_DETALLERow)this.MemberwiseClone();
		}
	} // End of CATALOGOS_DETALLERow class
} // End of namespace
