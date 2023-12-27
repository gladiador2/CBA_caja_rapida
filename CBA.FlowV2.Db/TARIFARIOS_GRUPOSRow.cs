// <fileinfo name="TARIFARIOS_GRUPOSRow.cs">
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
	/// Represents a record in the <c>TARIFARIOS_GRUPOS</c> table.
	/// </summary>
	public class TARIFARIOS_GRUPOSRow : TARIFARIOS_GRUPOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_GRUPOSRow"/> class.
		/// </summary>
		public TARIFARIOS_GRUPOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TARIFARIOS_GRUPOSRow Clonar()
		{
			return (TARIFARIOS_GRUPOSRow)this.MemberwiseClone();
		}
	} // End of TARIFARIOS_GRUPOSRow class
} // End of namespace
