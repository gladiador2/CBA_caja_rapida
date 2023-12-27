// <fileinfo name="IMPORTACIONES_GASTOSRow.cs">
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
	/// Represents a record in the <c>IMPORTACIONES_GASTOS</c> table.
	/// </summary>
	public class IMPORTACIONES_GASTOSRow : IMPORTACIONES_GASTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_GASTOSRow"/> class.
		/// </summary>
		public IMPORTACIONES_GASTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public IMPORTACIONES_GASTOSRow Clonar()
		{
			return (IMPORTACIONES_GASTOSRow)this.MemberwiseClone();
		}
	} // End of IMPORTACIONES_GASTOSRow class
} // End of namespace
