// <fileinfo name="SUGERENCIASRow.cs">
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
	/// Represents a record in the <c>SUGERENCIAS</c> table.
	/// </summary>
	public class SUGERENCIASRow : SUGERENCIASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SUGERENCIASRow"/> class.
		/// </summary>
		public SUGERENCIASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public SUGERENCIASRow Clonar()
		{
			return (SUGERENCIASRow)this.MemberwiseClone();
		}
	} // End of SUGERENCIASRow class
} // End of namespace
