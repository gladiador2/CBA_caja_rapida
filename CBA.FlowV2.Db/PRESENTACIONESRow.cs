// <fileinfo name="PRESENTACIONESRow.cs">
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
	/// Represents a record in the <c>PRESENTACIONES</c> table.
	/// </summary>
	public class PRESENTACIONESRow : PRESENTACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PRESENTACIONESRow"/> class.
		/// </summary>
		public PRESENTACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PRESENTACIONESRow Clonar()
		{
			return (PRESENTACIONESRow)this.MemberwiseClone();
		}
	} // End of PRESENTACIONESRow class
} // End of namespace
