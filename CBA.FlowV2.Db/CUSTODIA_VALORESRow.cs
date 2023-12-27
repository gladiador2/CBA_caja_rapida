// <fileinfo name="CUSTODIA_VALORESRow.cs">
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
	/// Represents a record in the <c>CUSTODIA_VALORES</c> table.
	/// </summary>
	public class CUSTODIA_VALORESRow : CUSTODIA_VALORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CUSTODIA_VALORESRow"/> class.
		/// </summary>
		public CUSTODIA_VALORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CUSTODIA_VALORESRow Clonar()
		{
			return (CUSTODIA_VALORESRow)this.MemberwiseClone();
		}
	} // End of CUSTODIA_VALORESRow class
} // End of namespace
