// <fileinfo name="REGLAS_LOGINRow.cs">
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
	/// Represents a record in the <c>REGLAS_LOGIN</c> table.
	/// </summary>
	public class REGLAS_LOGINRow : REGLAS_LOGINRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REGLAS_LOGINRow"/> class.
		/// </summary>
		public REGLAS_LOGINRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REGLAS_LOGINRow Clonar()
		{
			return (REGLAS_LOGINRow)this.MemberwiseClone();
		}
	} // End of REGLAS_LOGINRow class
} // End of namespace
