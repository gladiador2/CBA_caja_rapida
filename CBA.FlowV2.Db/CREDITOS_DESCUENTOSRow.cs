// <fileinfo name="CREDITOS_DESCUENTOSRow.cs">
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
	/// Represents a record in the <c>CREDITOS_DESCUENTOS</c> table.
	/// </summary>
	public class CREDITOS_DESCUENTOSRow : CREDITOS_DESCUENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_DESCUENTOSRow"/> class.
		/// </summary>
		public CREDITOS_DESCUENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CREDITOS_DESCUENTOSRow Clonar()
		{
			return (CREDITOS_DESCUENTOSRow)this.MemberwiseClone();
		}
	} // End of CREDITOS_DESCUENTOSRow class
} // End of namespace
