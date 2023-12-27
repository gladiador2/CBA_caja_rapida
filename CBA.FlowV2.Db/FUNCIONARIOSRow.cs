// <fileinfo name="FUNCIONARIOSRow.cs">
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
	/// Represents a record in the <c>FUNCIONARIOS</c> table.
	/// </summary>
	public class FUNCIONARIOSRow : FUNCIONARIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOSRow"/> class.
		/// </summary>
		public FUNCIONARIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FUNCIONARIOSRow Clonar()
		{
			return (FUNCIONARIOSRow)this.MemberwiseClone();
		}
	} // End of FUNCIONARIOSRow class
} // End of namespace
