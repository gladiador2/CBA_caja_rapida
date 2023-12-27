// <fileinfo name="ARTICULOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS</c> table.
	/// </summary>
	public class ARTICULOSRow : ARTICULOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOSRow"/> class.
		/// </summary>
		public ARTICULOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOSRow Clonar()
		{
			return (ARTICULOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOSRow class
} // End of namespace
