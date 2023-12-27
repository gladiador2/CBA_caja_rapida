// <fileinfo name="ARTICULOS_COMBOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_COMBOS</c> table.
	/// </summary>
	public class ARTICULOS_COMBOSRow : ARTICULOS_COMBOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COMBOSRow"/> class.
		/// </summary>
		public ARTICULOS_COMBOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_COMBOSRow Clonar()
		{
			return (ARTICULOS_COMBOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_COMBOSRow class
} // End of namespace
