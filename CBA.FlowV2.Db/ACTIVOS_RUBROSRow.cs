// <fileinfo name="ACTIVOS_RUBROSRow.cs">
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
	/// Represents a record in the <c>ACTIVOS_RUBROS</c> table.
	/// </summary>
	public class ACTIVOS_RUBROSRow : ACTIVOS_RUBROSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOS_RUBROSRow"/> class.
		/// </summary>
		public ACTIVOS_RUBROSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ACTIVOS_RUBROSRow Clonar()
		{
			return (ACTIVOS_RUBROSRow)this.MemberwiseClone();
		}
	} // End of ACTIVOS_RUBROSRow class
} // End of namespace
