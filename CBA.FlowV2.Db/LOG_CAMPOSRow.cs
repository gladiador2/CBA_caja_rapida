// <fileinfo name="LOG_CAMPOSRow.cs">
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
	/// Represents a record in the <c>LOG_CAMPOS</c> table.
	/// </summary>
	public class LOG_CAMPOSRow : LOG_CAMPOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_CAMPOSRow"/> class.
		/// </summary>
		public LOG_CAMPOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LOG_CAMPOSRow Clonar()
		{
			return (LOG_CAMPOSRow)this.MemberwiseClone();
		}
	} // End of LOG_CAMPOSRow class
} // End of namespace
