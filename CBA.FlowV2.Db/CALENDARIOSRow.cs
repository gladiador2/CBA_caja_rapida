// <fileinfo name="CALENDARIOSRow.cs">
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
	/// Represents a record in the <c>CALENDARIOS</c> table.
	/// </summary>
	public class CALENDARIOSRow : CALENDARIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CALENDARIOSRow"/> class.
		/// </summary>
		public CALENDARIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CALENDARIOSRow Clonar()
		{
			return (CALENDARIOSRow)this.MemberwiseClone();
		}
	} // End of CALENDARIOSRow class
} // End of namespace
