// <fileinfo name="TRANSFERENCIAS_TESORERIAS_DETRow.cs">
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
	/// Represents a record in the <c>TRANSFERENCIAS_TESORERIAS_DET</c> table.
	/// </summary>
	public class TRANSFERENCIAS_TESORERIAS_DETRow : TRANSFERENCIAS_TESORERIAS_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_TESORERIAS_DETRow"/> class.
		/// </summary>
		public TRANSFERENCIAS_TESORERIAS_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRANSFERENCIAS_TESORERIAS_DETRow Clonar()
		{
			return (TRANSFERENCIAS_TESORERIAS_DETRow)this.MemberwiseClone();
		}
	} // End of TRANSFERENCIAS_TESORERIAS_DETRow class
} // End of namespace
