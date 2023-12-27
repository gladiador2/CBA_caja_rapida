// <fileinfo name="PLANTILLAS_DETALLESRow.cs">
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
	/// Represents a record in the <c>PLANTILLAS_DETALLES</c> table.
	/// </summary>
	public class PLANTILLAS_DETALLESRow : PLANTILLAS_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANTILLAS_DETALLESRow"/> class.
		/// </summary>
		public PLANTILLAS_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANTILLAS_DETALLESRow Clonar()
		{
			return (PLANTILLAS_DETALLESRow)this.MemberwiseClone();
		}
	} // End of PLANTILLAS_DETALLESRow class
} // End of namespace
