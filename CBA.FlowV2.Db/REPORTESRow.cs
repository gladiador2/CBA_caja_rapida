// <fileinfo name="REPORTESRow.cs">
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
	/// Represents a record in the <c>REPORTES</c> table.
	/// </summary>
	public class REPORTESRow : REPORTESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REPORTESRow"/> class.
		/// </summary>
		public REPORTESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REPORTESRow Clonar()
		{
			return (REPORTESRow)this.MemberwiseClone();
		}
	} // End of REPORTESRow class
} // End of namespace
