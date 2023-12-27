// <fileinfo name="RENDICION_COBRADOR_RECIBOSRow.cs">
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
	/// Represents a record in the <c>RENDICION_COBRADOR_RECIBOS</c> view.
	/// </summary>
	public class RENDICION_COBRADOR_RECIBOSRow : RENDICION_COBRADOR_RECIBOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADOR_RECIBOSRow"/> class.
		/// </summary>
		public RENDICION_COBRADOR_RECIBOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public RENDICION_COBRADOR_RECIBOSRow Clonar()
		{
			return (RENDICION_COBRADOR_RECIBOSRow)this.MemberwiseClone();
		}
	} // End of RENDICION_COBRADOR_RECIBOSRow class
} // End of namespace
