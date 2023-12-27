// <fileinfo name="USUARIOS_PERFILESRow.cs">
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
	/// Represents a record in the <c>USUARIOS_PERFILES</c> table.
	/// </summary>
	public class USUARIOS_PERFILESRow : USUARIOS_PERFILESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_PERFILESRow"/> class.
		/// </summary>
		public USUARIOS_PERFILESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USUARIOS_PERFILESRow Clonar()
		{
			return (USUARIOS_PERFILESRow)this.MemberwiseClone();
		}
	} // End of USUARIOS_PERFILESRow class
} // End of namespace
