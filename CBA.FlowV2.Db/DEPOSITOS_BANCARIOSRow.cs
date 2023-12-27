// <fileinfo name="DEPOSITOS_BANCARIOSRow.cs">
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
	/// Represents a record in the <c>DEPOSITOS_BANCARIOS</c> table.
	/// </summary>
	public class DEPOSITOS_BANCARIOSRow : DEPOSITOS_BANCARIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITOS_BANCARIOSRow"/> class.
		/// </summary>
		public DEPOSITOS_BANCARIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DEPOSITOS_BANCARIOSRow Clonar()
		{
			return (DEPOSITOS_BANCARIOSRow)this.MemberwiseClone();
		}
	} // End of DEPOSITOS_BANCARIOSRow class
} // End of namespace
