// <fileinfo name="AGRUPAMIENTO_FLUJOSRow.cs">
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
	/// Represents a record in the <c>AGRUPAMIENTO_FLUJOS</c> table.
	/// </summary>
	public class AGRUPAMIENTO_FLUJOSRow : AGRUPAMIENTO_FLUJOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AGRUPAMIENTO_FLUJOSRow"/> class.
		/// </summary>
		public AGRUPAMIENTO_FLUJOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public AGRUPAMIENTO_FLUJOSRow Clonar()
		{
			return (AGRUPAMIENTO_FLUJOSRow)this.MemberwiseClone();
		}
	} // End of AGRUPAMIENTO_FLUJOSRow class
} // End of namespace
