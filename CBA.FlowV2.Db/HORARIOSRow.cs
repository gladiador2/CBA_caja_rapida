// <fileinfo name="HORARIOSRow.cs">
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
	/// Represents a record in the <c>HORARIOS</c> table.
	/// </summary>
	public class HORARIOSRow : HORARIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOSRow"/> class.
		/// </summary>
		public HORARIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public HORARIOSRow Clonar()
		{
			return (HORARIOSRow)this.MemberwiseClone();
		}
	} // End of HORARIOSRow class
} // End of namespace
