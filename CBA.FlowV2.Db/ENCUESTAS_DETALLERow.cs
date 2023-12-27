// <fileinfo name="ENCUESTAS_DETALLERow.cs">
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
	/// Represents a record in the <c>ENCUESTAS_DETALLE</c> table.
	/// </summary>
	public class ENCUESTAS_DETALLERow : ENCUESTAS_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTAS_DETALLERow"/> class.
		/// </summary>
		public ENCUESTAS_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ENCUESTAS_DETALLERow Clonar()
		{
			return (ENCUESTAS_DETALLERow)this.MemberwiseClone();
		}
	} // End of ENCUESTAS_DETALLERow class
} // End of namespace
