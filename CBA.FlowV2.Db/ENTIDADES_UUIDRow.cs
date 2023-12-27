// <fileinfo name="ENTIDADES_UUIDRow.cs">
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
	/// Represents a record in the <c>ENTIDADES_UUID</c> table.
	/// </summary>
	public class ENTIDADES_UUIDRow : ENTIDADES_UUIDRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ENTIDADES_UUIDRow"/> class.
		/// </summary>
		public ENTIDADES_UUIDRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ENTIDADES_UUIDRow Clonar()
		{
			return (ENTIDADES_UUIDRow)this.MemberwiseClone();
		}
	} // End of ENTIDADES_UUIDRow class
} // End of namespace
