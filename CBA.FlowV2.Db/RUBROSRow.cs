// <fileinfo name="RUBROSRow.cs">
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
	/// Represents a record in the <c>RUBROS</c> table.
	/// </summary>
	public class RUBROSRow : RUBROSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RUBROSRow"/> class.
		/// </summary>
		public RUBROSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public RUBROSRow Clonar()
		{
			return (RUBROSRow)this.MemberwiseClone();
		}
	} // End of RUBROSRow class
} // End of namespace
