// <fileinfo name="REFI_DEUDAS_INFO_COMPRow.cs">
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
	/// Represents a record in the <c>REFI_DEUDAS_INFO_COMP</c> view.
	/// </summary>
	public class REFI_DEUDAS_INFO_COMPRow : REFI_DEUDAS_INFO_COMPRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REFI_DEUDAS_INFO_COMPRow"/> class.
		/// </summary>
		public REFI_DEUDAS_INFO_COMPRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REFI_DEUDAS_INFO_COMPRow Clonar()
		{
			return (REFI_DEUDAS_INFO_COMPRow)this.MemberwiseClone();
		}
	} // End of REFI_DEUDAS_INFO_COMPRow class
} // End of namespace
