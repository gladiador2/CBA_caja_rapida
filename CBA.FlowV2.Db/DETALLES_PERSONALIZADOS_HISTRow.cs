// <fileinfo name="DETALLES_PERSONALIZADOS_HISTRow.cs">
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
	/// Represents a record in the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
	/// </summary>
	public class DETALLES_PERSONALIZADOS_HISTRow : DETALLES_PERSONALIZADOS_HISTRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> class.
		/// </summary>
		public DETALLES_PERSONALIZADOS_HISTRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DETALLES_PERSONALIZADOS_HISTRow Clonar()
		{
			return (DETALLES_PERSONALIZADOS_HISTRow)this.MemberwiseClone();
		}
	} // End of DETALLES_PERSONALIZADOS_HISTRow class
} // End of namespace
