// <fileinfo name="USUARIOS_SUCURSALESRow.cs">
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
	/// Represents a record in the <c>USUARIOS_SUCURSALES</c> table.
	/// </summary>
	public class USUARIOS_SUCURSALESRow : USUARIOS_SUCURSALESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_SUCURSALESRow"/> class.
		/// </summary>
		public USUARIOS_SUCURSALESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USUARIOS_SUCURSALESRow Clonar()
		{
			return (USUARIOS_SUCURSALESRow)this.MemberwiseClone();
		}
	} // End of USUARIOS_SUCURSALESRow class
} // End of namespace
