// <fileinfo name="USUARIOS_PASSWORDRow.cs">
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
	/// Represents a record in the <c>USUARIOS_PASSWORD</c> table.
	/// </summary>
	public class USUARIOS_PASSWORDRow : USUARIOS_PASSWORDRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_PASSWORDRow"/> class.
		/// </summary>
		public USUARIOS_PASSWORDRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USUARIOS_PASSWORDRow Clonar()
		{
			return (USUARIOS_PASSWORDRow)this.MemberwiseClone();
		}
	} // End of USUARIOS_PASSWORDRow class
} // End of namespace
