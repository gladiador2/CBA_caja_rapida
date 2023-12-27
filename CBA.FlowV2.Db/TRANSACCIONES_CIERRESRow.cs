// <fileinfo name="TRANSACCIONES_CIERRESRow.cs">
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
	/// Represents a record in the <c>TRANSACCIONES_CIERRES</c> table.
	/// </summary>
	public class TRANSACCIONES_CIERRESRow : TRANSACCIONES_CIERRESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONES_CIERRESRow"/> class.
		/// </summary>
		public TRANSACCIONES_CIERRESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRANSACCIONES_CIERRESRow Clonar()
		{
			return (TRANSACCIONES_CIERRESRow)this.MemberwiseClone();
		}
	} // End of TRANSACCIONES_CIERRESRow class
} // End of namespace
