// <fileinfo name="EGRESOS_VARIOS_CAJARow.cs">
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
	/// Represents a record in the <c>EGRESOS_VARIOS_CAJA</c> table.
	/// </summary>
	public class EGRESOS_VARIOS_CAJARow : EGRESOS_VARIOS_CAJARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJARow"/> class.
		/// </summary>
		public EGRESOS_VARIOS_CAJARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public EGRESOS_VARIOS_CAJARow Clonar()
		{
			return (EGRESOS_VARIOS_CAJARow)this.MemberwiseClone();
		}
	} // End of EGRESOS_VARIOS_CAJARow class
} // End of namespace
