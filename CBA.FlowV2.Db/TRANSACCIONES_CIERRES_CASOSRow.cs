// <fileinfo name="TRANSACCIONES_CIERRES_CASOSRow.cs">
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
	/// Represents a record in the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
	/// </summary>
	public class TRANSACCIONES_CIERRES_CASOSRow : TRANSACCIONES_CIERRES_CASOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> class.
		/// </summary>
		public TRANSACCIONES_CIERRES_CASOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRANSACCIONES_CIERRES_CASOSRow Clonar()
		{
			return (TRANSACCIONES_CIERRES_CASOSRow)this.MemberwiseClone();
		}
	} // End of TRANSACCIONES_CIERRES_CASOSRow class
} // End of namespace
