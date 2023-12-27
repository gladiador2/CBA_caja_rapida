// <fileinfo name="BASCULASRow.cs">
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
	/// Represents a record in the <c>BASCULAS</c> table.
	/// </summary>
	public class BASCULASRow : BASCULASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BASCULASRow"/> class.
		/// </summary>
		public BASCULASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public BASCULASRow Clonar()
		{
			return (BASCULASRow)this.MemberwiseClone();
		}
	} // End of BASCULASRow class
} // End of namespace
