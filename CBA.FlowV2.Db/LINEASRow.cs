// <fileinfo name="LINEASRow.cs">
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
	/// Represents a record in the <c>LINEAS</c> table.
	/// </summary>
	public class LINEASRow : LINEASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LINEASRow"/> class.
		/// </summary>
		public LINEASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LINEASRow Clonar()
		{
			return (LINEASRow)this.MemberwiseClone();
		}
	} // End of LINEASRow class
} // End of namespace
