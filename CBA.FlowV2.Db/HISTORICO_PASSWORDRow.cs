// <fileinfo name="HISTORICO_PASSWORDRow.cs">
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
	/// Represents a record in the <c>HISTORICO_PASSWORD</c> table.
	/// </summary>
	public class HISTORICO_PASSWORDRow : HISTORICO_PASSWORDRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HISTORICO_PASSWORDRow"/> class.
		/// </summary>
		public HISTORICO_PASSWORDRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public HISTORICO_PASSWORDRow Clonar()
		{
			return (HISTORICO_PASSWORDRow)this.MemberwiseClone();
		}
	} // End of HISTORICO_PASSWORDRow class
} // End of namespace
