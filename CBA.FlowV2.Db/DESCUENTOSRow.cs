// <fileinfo name="DESCUENTOSRow.cs">
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
	/// Represents a record in the <c>DESCUENTOS</c> table.
	/// </summary>
	public class DESCUENTOSRow : DESCUENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTOSRow"/> class.
		/// </summary>
		public DESCUENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DESCUENTOSRow Clonar()
		{
			return (DESCUENTOSRow)this.MemberwiseClone();
		}
	} // End of DESCUENTOSRow class
} // End of namespace
