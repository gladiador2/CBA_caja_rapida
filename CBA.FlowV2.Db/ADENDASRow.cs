// <fileinfo name="ADENDASRow.cs">
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
	/// Represents a record in the <c>ADENDAS</c> table.
	/// </summary>
	public class ADENDASRow : ADENDASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ADENDASRow"/> class.
		/// </summary>
		public ADENDASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ADENDASRow Clonar()
		{
			return (ADENDASRow)this.MemberwiseClone();
		}
	} // End of ADENDASRow class
} // End of namespace
