// <fileinfo name="USUARIOS_ROLESRow.cs">
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
	/// Represents a record in the <c>USUARIOS_ROLES</c> table.
	/// </summary>
	public class USUARIOS_ROLESRow : USUARIOS_ROLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_ROLESRow"/> class.
		/// </summary>
		public USUARIOS_ROLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USUARIOS_ROLESRow Clonar()
		{
			return (USUARIOS_ROLESRow)this.MemberwiseClone();
		}
	} // End of USUARIOS_ROLESRow class
} // End of namespace
