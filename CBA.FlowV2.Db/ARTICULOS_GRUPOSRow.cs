// <fileinfo name="ARTICULOS_GRUPOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_GRUPOS</c> table.
	/// </summary>
	public class ARTICULOS_GRUPOSRow : ARTICULOS_GRUPOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_GRUPOSRow"/> class.
		/// </summary>
		public ARTICULOS_GRUPOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_GRUPOSRow Clonar()
		{
			return (ARTICULOS_GRUPOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_GRUPOSRow class
} // End of namespace
