// <fileinfo name="CANJES_VALORESRow.cs">
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
	/// Represents a record in the <c>CANJES_VALORES</c> table.
	/// </summary>
	public class CANJES_VALORESRow : CANJES_VALORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CANJES_VALORESRow"/> class.
		/// </summary>
		public CANJES_VALORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CANJES_VALORESRow Clonar()
		{
			return (CANJES_VALORESRow)this.MemberwiseClone();
		}
	} // End of CANJES_VALORESRow class
} // End of namespace
