// <fileinfo name="CANJES_VALORES_DETRow.cs">
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
	/// Represents a record in the <c>CANJES_VALORES_DET</c> table.
	/// </summary>
	public class CANJES_VALORES_DETRow : CANJES_VALORES_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CANJES_VALORES_DETRow"/> class.
		/// </summary>
		public CANJES_VALORES_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CANJES_VALORES_DETRow Clonar()
		{
			return (CANJES_VALORES_DETRow)this.MemberwiseClone();
		}
	} // End of CANJES_VALORES_DETRow class
} // End of namespace
