// <fileinfo name="ENCUESTASRow.cs">
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
	/// Represents a record in the <c>ENCUESTAS</c> table.
	/// </summary>
	public class ENCUESTASRow : ENCUESTASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTASRow"/> class.
		/// </summary>
		public ENCUESTASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ENCUESTASRow Clonar()
		{
			return (ENCUESTASRow)this.MemberwiseClone();
		}
	} // End of ENCUESTASRow class
} // End of namespace
