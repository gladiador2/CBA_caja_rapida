// <fileinfo name="BONIFICACIONESRow.cs">
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
	/// Represents a record in the <c>BONIFICACIONES</c> table.
	/// </summary>
	public class BONIFICACIONESRow : BONIFICACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BONIFICACIONESRow"/> class.
		/// </summary>
		public BONIFICACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public BONIFICACIONESRow Clonar()
		{
			return (BONIFICACIONESRow)this.MemberwiseClone();
		}
	} // End of BONIFICACIONESRow class
} // End of namespace
