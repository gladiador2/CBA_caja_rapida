// <fileinfo name="DETALLES_PERSONALIZADOS_DETRow.cs">
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
	/// Represents a record in the <c>DETALLES_PERSONALIZADOS_DET</c> table.
	/// </summary>
	public class DETALLES_PERSONALIZADOS_DETRow : DETALLES_PERSONALIZADOS_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_DETRow"/> class.
		/// </summary>
		public DETALLES_PERSONALIZADOS_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DETALLES_PERSONALIZADOS_DETRow Clonar()
		{
			return (DETALLES_PERSONALIZADOS_DETRow)this.MemberwiseClone();
		}
	} // End of DETALLES_PERSONALIZADOS_DETRow class
} // End of namespace
