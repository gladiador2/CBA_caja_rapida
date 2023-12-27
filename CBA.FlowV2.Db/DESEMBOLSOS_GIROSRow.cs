// <fileinfo name="DESEMBOLSOS_GIROSRow.cs">
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
	/// Represents a record in the <c>DESEMBOLSOS_GIROS</c> table.
	/// </summary>
	public class DESEMBOLSOS_GIROSRow : DESEMBOLSOS_GIROSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROSRow"/> class.
		/// </summary>
		public DESEMBOLSOS_GIROSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DESEMBOLSOS_GIROSRow Clonar()
		{
			return (DESEMBOLSOS_GIROSRow)this.MemberwiseClone();
		}
	} // End of DESEMBOLSOS_GIROSRow class
} // End of namespace
