// <fileinfo name="ALARMASRow.cs">
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
	/// Represents a record in the <c>ALARMAS</c> table.
	/// </summary>
	public class ALARMASRow : ALARMASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ALARMASRow"/> class.
		/// </summary>
		public ALARMASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ALARMASRow Clonar()
		{
			return (ALARMASRow)this.MemberwiseClone();
		}
	} // End of ALARMASRow class
} // End of namespace
