// <fileinfo name="LOG_CAMBIOSRow.cs">
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
	/// Represents a record in the <c>LOG_CAMBIOS</c> table.
	/// </summary>
	public class LOG_CAMBIOSRow : LOG_CAMBIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_CAMBIOSRow"/> class.
		/// </summary>
		public LOG_CAMBIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LOG_CAMBIOSRow Clonar()
		{
			return (LOG_CAMBIOSRow)this.MemberwiseClone();
		}
	} // End of LOG_CAMBIOSRow class
} // End of namespace
