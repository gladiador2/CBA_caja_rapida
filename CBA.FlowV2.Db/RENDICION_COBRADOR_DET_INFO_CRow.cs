// <fileinfo name="RENDICION_COBRADOR_DET_INFO_CRow.cs">
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
	/// Represents a record in the <c>RENDICION_COBRADOR_DET_INFO_C</c> view.
	/// </summary>
	public class RENDICION_COBRADOR_DET_INFO_CRow : RENDICION_COBRADOR_DET_INFO_CRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADOR_DET_INFO_CRow"/> class.
		/// </summary>
		public RENDICION_COBRADOR_DET_INFO_CRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public RENDICION_COBRADOR_DET_INFO_CRow Clonar()
		{
			return (RENDICION_COBRADOR_DET_INFO_CRow)this.MemberwiseClone();
		}
	} // End of RENDICION_COBRADOR_DET_INFO_CRow class
} // End of namespace
