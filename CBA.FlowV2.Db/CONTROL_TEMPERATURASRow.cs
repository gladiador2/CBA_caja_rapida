// <fileinfo name="CONTROL_TEMPERATURASRow.cs">
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
	/// Represents a record in the <c>CONTROL_TEMPERATURAS</c> table.
	/// </summary>
	public class CONTROL_TEMPERATURASRow : CONTROL_TEMPERATURASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CONTROL_TEMPERATURASRow"/> class.
		/// </summary>
		public CONTROL_TEMPERATURASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CONTROL_TEMPERATURASRow Clonar()
		{
			return (CONTROL_TEMPERATURASRow)this.MemberwiseClone();
		}
	} // End of CONTROL_TEMPERATURASRow class
} // End of namespace
