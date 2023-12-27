// <fileinfo name="FLUJOSRow.cs">
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
	/// Represents a record in the <c>FLUJOS</c> table.
	/// </summary>
	public class FLUJOSRow : FLUJOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FLUJOSRow"/> class.
		/// </summary>
		public FLUJOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FLUJOSRow Clonar()
		{
			return (FLUJOSRow)this.MemberwiseClone();
		}
	} // End of FLUJOSRow class
} // End of namespace
