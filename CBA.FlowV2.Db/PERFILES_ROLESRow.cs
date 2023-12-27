// <fileinfo name="PERFILES_ROLESRow.cs">
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
	/// Represents a record in the <c>PERFILES_ROLES</c> table.
	/// </summary>
	public class PERFILES_ROLESRow : PERFILES_ROLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PERFILES_ROLESRow"/> class.
		/// </summary>
		public PERFILES_ROLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PERFILES_ROLESRow Clonar()
		{
			return (PERFILES_ROLESRow)this.MemberwiseClone();
		}
	} // End of PERFILES_ROLESRow class
} // End of namespace
