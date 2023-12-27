// <fileinfo name="USUARIOS_DEPOSITOSRow.cs">
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
	/// Represents a record in the <c>USUARIOS_DEPOSITOS</c> table.
	/// </summary>
	public class USUARIOS_DEPOSITOSRow : USUARIOS_DEPOSITOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_DEPOSITOSRow"/> class.
		/// </summary>
		public USUARIOS_DEPOSITOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USUARIOS_DEPOSITOSRow Clonar()
		{
			return (USUARIOS_DEPOSITOSRow)this.MemberwiseClone();
		}
	} // End of USUARIOS_DEPOSITOSRow class
} // End of namespace
