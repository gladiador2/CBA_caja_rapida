// <fileinfo name="ARTICULOS_PEDIDOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_PEDIDOS</c> view.
	/// </summary>
	public class ARTICULOS_PEDIDOSRow : ARTICULOS_PEDIDOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PEDIDOSRow"/> class.
		/// </summary>
		public ARTICULOS_PEDIDOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_PEDIDOSRow Clonar()
		{
			return (ARTICULOS_PEDIDOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_PEDIDOSRow class
} // End of namespace
