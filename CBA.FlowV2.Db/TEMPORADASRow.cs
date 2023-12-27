// <fileinfo name="TEMPORADASRow.cs">
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
	/// Represents a record in the <c>TEMPORADAS</c> table.
	/// </summary>
	public class TEMPORADASRow : TEMPORADASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TEMPORADASRow"/> class.
		/// </summary>
		public TEMPORADASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TEMPORADASRow Clonar()
		{
			return (TEMPORADASRow)this.MemberwiseClone();
		}
	} // End of TEMPORADASRow class
} // End of namespace
