// <fileinfo name="ESTADOSRow.cs">
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
	/// Represents a record in the <c>ESTADOS</c> table.
	/// </summary>
	public class ESTADOSRow : ESTADOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ESTADOSRow"/> class.
		/// </summary>
		public ESTADOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ESTADOSRow Clonar()
		{
			return (ESTADOSRow)this.MemberwiseClone();
		}
	} // End of ESTADOSRow class
} // End of namespace
