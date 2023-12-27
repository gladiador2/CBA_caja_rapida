// <fileinfo name="AGENCIASRow.cs">
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
	/// Represents a record in the <c>AGENCIAS</c> table.
	/// </summary>
	public class AGENCIASRow : AGENCIASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AGENCIASRow"/> class.
		/// </summary>
		public AGENCIASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public AGENCIASRow Clonar()
		{
			return (AGENCIASRow)this.MemberwiseClone();
		}
	} // End of AGENCIASRow class
} // End of namespace
