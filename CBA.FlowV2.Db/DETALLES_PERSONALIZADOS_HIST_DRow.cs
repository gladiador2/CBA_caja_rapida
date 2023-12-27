// <fileinfo name="DETALLES_PERSONALIZADOS_HIST_DRow.cs">
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
	/// Represents a record in the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
	/// </summary>
	public class DETALLES_PERSONALIZADOS_HIST_DRow : DETALLES_PERSONALIZADOS_HIST_DRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> class.
		/// </summary>
		public DETALLES_PERSONALIZADOS_HIST_DRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DETALLES_PERSONALIZADOS_HIST_DRow Clonar()
		{
			return (DETALLES_PERSONALIZADOS_HIST_DRow)this.MemberwiseClone();
		}
	} // End of DETALLES_PERSONALIZADOS_HIST_DRow class
} // End of namespace
