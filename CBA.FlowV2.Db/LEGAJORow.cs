// <fileinfo name="LEGAJORow.cs">
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
	/// Represents a record in the <c>LEGAJO</c> table.
	/// </summary>
	public class LEGAJORow : LEGAJORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LEGAJORow"/> class.
		/// </summary>
		public LEGAJORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LEGAJORow Clonar()
		{
			return (LEGAJORow)this.MemberwiseClone();
		}
	} // End of LEGAJORow class
} // End of namespace
