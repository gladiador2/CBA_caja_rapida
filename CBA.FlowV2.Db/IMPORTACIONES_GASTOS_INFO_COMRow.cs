// <fileinfo name="IMPORTACIONES_GASTOS_INFO_COMRow.cs">
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
	/// Represents a record in the <c>IMPORTACIONES_GASTOS_INFO_COM</c> view.
	/// </summary>
	public class IMPORTACIONES_GASTOS_INFO_COMRow : IMPORTACIONES_GASTOS_INFO_COMRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_GASTOS_INFO_COMRow"/> class.
		/// </summary>
		public IMPORTACIONES_GASTOS_INFO_COMRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public IMPORTACIONES_GASTOS_INFO_COMRow Clonar()
		{
			return (IMPORTACIONES_GASTOS_INFO_COMRow)this.MemberwiseClone();
		}
	} // End of IMPORTACIONES_GASTOS_INFO_COMRow class
} // End of namespace
