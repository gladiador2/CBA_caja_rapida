// <fileinfo name="FUNCIONARIOS_COMISIONES_INFO_CRow.cs">
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
	/// Represents a record in the <c>FUNCIONARIOS_COMISIONES_INFO_C</c> view.
	/// </summary>
	public class FUNCIONARIOS_COMISIONES_INFO_CRow : FUNCIONARIOS_COMISIONES_INFO_CRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_COMISIONES_INFO_CRow"/> class.
		/// </summary>
		public FUNCIONARIOS_COMISIONES_INFO_CRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FUNCIONARIOS_COMISIONES_INFO_CRow Clonar()
		{
			return (FUNCIONARIOS_COMISIONES_INFO_CRow)this.MemberwiseClone();
		}
	} // End of FUNCIONARIOS_COMISIONES_INFO_CRow class
} // End of namespace
