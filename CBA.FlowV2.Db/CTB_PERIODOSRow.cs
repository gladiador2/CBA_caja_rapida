// <fileinfo name="CTB_PERIODOSRow.cs">
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
	/// Represents a record in the <c>CTB_PERIODOS</c> table.
	/// </summary>
	public class CTB_PERIODOSRow : CTB_PERIODOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PERIODOSRow"/> class.
		/// </summary>
		public CTB_PERIODOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTB_PERIODOSRow Clonar()
		{
			return (CTB_PERIODOSRow)this.MemberwiseClone();
		}
	} // End of CTB_PERIODOSRow class
} // End of namespace
