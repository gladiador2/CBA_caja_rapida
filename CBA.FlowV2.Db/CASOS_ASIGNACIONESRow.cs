// <fileinfo name="CASOS_ASIGNACIONESRow.cs">
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
	/// Represents a record in the <c>CASOS_ASIGNACIONES</c> table.
	/// </summary>
	public class CASOS_ASIGNACIONESRow : CASOS_ASIGNACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CASOS_ASIGNACIONESRow"/> class.
		/// </summary>
		public CASOS_ASIGNACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CASOS_ASIGNACIONESRow Clonar()
		{
			return (CASOS_ASIGNACIONESRow)this.MemberwiseClone();
		}
	} // End of CASOS_ASIGNACIONESRow class
} // End of namespace
