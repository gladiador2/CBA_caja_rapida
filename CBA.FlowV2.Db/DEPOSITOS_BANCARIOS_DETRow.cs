// <fileinfo name="DEPOSITOS_BANCARIOS_DETRow.cs">
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
	/// Represents a record in the <c>DEPOSITOS_BANCARIOS_DET</c> table.
	/// </summary>
	public class DEPOSITOS_BANCARIOS_DETRow : DEPOSITOS_BANCARIOS_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITOS_BANCARIOS_DETRow"/> class.
		/// </summary>
		public DEPOSITOS_BANCARIOS_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DEPOSITOS_BANCARIOS_DETRow Clonar()
		{
			return (DEPOSITOS_BANCARIOS_DETRow)this.MemberwiseClone();
		}
	} // End of DEPOSITOS_BANCARIOS_DETRow class
} // End of namespace
