// <fileinfo name="VARIABLES_SISTEMARow.cs">
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
	/// Represents a record in the <c>VARIABLES_SISTEMA</c> table.
	/// </summary>
	public class VARIABLES_SISTEMARow : VARIABLES_SISTEMARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VARIABLES_SISTEMARow"/> class.
		/// </summary>
		public VARIABLES_SISTEMARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public VARIABLES_SISTEMARow Clonar()
		{
			return (VARIABLES_SISTEMARow)this.MemberwiseClone();
		}
	} // End of VARIABLES_SISTEMARow class
} // End of namespace
