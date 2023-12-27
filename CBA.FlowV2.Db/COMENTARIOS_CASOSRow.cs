// <fileinfo name="COMENTARIOS_CASOSRow.cs">
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
	/// Represents a record in the <c>COMENTARIOS_CASOS</c> table.
	/// </summary>
	public class COMENTARIOS_CASOSRow : COMENTARIOS_CASOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="COMENTARIOS_CASOSRow"/> class.
		/// </summary>
		public COMENTARIOS_CASOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public COMENTARIOS_CASOSRow Clonar()
		{
			return (COMENTARIOS_CASOSRow)this.MemberwiseClone();
		}
	} // End of COMENTARIOS_CASOSRow class
} // End of namespace
