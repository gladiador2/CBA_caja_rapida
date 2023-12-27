// <fileinfo name="ORDENES_COMPRARow.cs">
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
	/// Represents a record in the <c>ORDENES_COMPRA</c> table.
	/// </summary>
	public class ORDENES_COMPRARow : ORDENES_COMPRARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_COMPRARow"/> class.
		/// </summary>
		public ORDENES_COMPRARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ORDENES_COMPRARow Clonar()
		{
			return (ORDENES_COMPRARow)this.MemberwiseClone();
		}
	} // End of ORDENES_COMPRARow class
} // End of namespace
