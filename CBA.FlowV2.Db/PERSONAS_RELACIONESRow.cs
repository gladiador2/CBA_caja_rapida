// <fileinfo name="PERSONAS_RELACIONESRow.cs">
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
	/// Represents a record in the <c>PERSONAS_RELACIONES</c> table.
	/// </summary>
	public class PERSONAS_RELACIONESRow : PERSONAS_RELACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_RELACIONESRow"/> class.
		/// </summary>
		public PERSONAS_RELACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PERSONAS_RELACIONESRow Clonar()
		{
			return (PERSONAS_RELACIONESRow)this.MemberwiseClone();
		}
	} // End of PERSONAS_RELACIONESRow class
} // End of namespace
