// <fileinfo name="MANUALESRow.cs">
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
	/// Represents a record in the <c>MANUALES</c> table.
	/// </summary>
	public class MANUALESRow : MANUALESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MANUALESRow"/> class.
		/// </summary>
		public MANUALESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public MANUALESRow Clonar()
		{
			return (MANUALESRow)this.MemberwiseClone();
		}
	} // End of MANUALESRow class
} // End of namespace
