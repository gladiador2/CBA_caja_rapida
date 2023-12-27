// <fileinfo name="ZONASRow.cs">
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
	/// Represents a record in the <c>ZONAS</c> table.
	/// </summary>
	public class ZONASRow : ZONASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ZONASRow"/> class.
		/// </summary>
		public ZONASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ZONASRow Clonar()
		{
			return (ZONASRow)this.MemberwiseClone();
		}
	} // End of ZONASRow class
} // End of namespace
