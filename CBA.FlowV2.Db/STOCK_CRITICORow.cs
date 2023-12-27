// <fileinfo name="STOCK_CRITICORow.cs">
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
	/// Represents a record in the <c>STOCK_CRITICO</c> table.
	/// </summary>
	public class STOCK_CRITICORow : STOCK_CRITICORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_CRITICORow"/> class.
		/// </summary>
		public STOCK_CRITICORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public STOCK_CRITICORow Clonar()
		{
			return (STOCK_CRITICORow)this.MemberwiseClone();
		}
	} // End of STOCK_CRITICORow class
} // End of namespace
