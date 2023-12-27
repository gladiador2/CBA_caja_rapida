// <fileinfo name="CANALES_VENTARow.cs">
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
	/// Represents a record in the <c>CANALES_VENTA</c> table.
	/// </summary>
	public class CANALES_VENTARow : CANALES_VENTARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CANALES_VENTARow"/> class.
		/// </summary>
		public CANALES_VENTARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CANALES_VENTARow Clonar()
		{
			return (CANALES_VENTARow)this.MemberwiseClone();
		}
	} // End of CANALES_VENTARow class
} // End of namespace
