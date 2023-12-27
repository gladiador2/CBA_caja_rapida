// <fileinfo name="USO_DE_INSUMOSRow.cs">
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
	/// Represents a record in the <c>USO_DE_INSUMOS</c> table.
	/// </summary>
	public class USO_DE_INSUMOSRow : USO_DE_INSUMOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USO_DE_INSUMOSRow"/> class.
		/// </summary>
		public USO_DE_INSUMOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USO_DE_INSUMOSRow Clonar()
		{
			return (USO_DE_INSUMOSRow)this.MemberwiseClone();
		}
	} // End of USO_DE_INSUMOSRow class
} // End of namespace
