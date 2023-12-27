// <fileinfo name="COPARNRow.cs">
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
	/// Represents a record in the <c>COPARN</c> table.
	/// </summary>
	public class COPARNRow : COPARNRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="COPARNRow"/> class.
		/// </summary>
		public COPARNRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public COPARNRow Clonar()
		{
			return (COPARNRow)this.MemberwiseClone();
		}
	} // End of COPARNRow class
} // End of namespace
