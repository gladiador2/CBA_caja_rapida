// <fileinfo name="MONEDASRow.cs">
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
	/// Represents a record in the <c>MONEDAS</c> table.
	/// </summary>
	public class MONEDASRow : MONEDASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MONEDASRow"/> class.
		/// </summary>
		public MONEDASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public MONEDASRow Clonar()
		{
			return (MONEDASRow)this.MemberwiseClone();
		}
	} // End of MONEDASRow class
} // End of namespace
