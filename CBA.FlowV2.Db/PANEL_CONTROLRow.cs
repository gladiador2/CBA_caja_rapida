// <fileinfo name="PANEL_CONTROLRow.cs">
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
	/// Represents a record in the <c>PANEL_CONTROL</c> table.
	/// </summary>
	public class PANEL_CONTROLRow : PANEL_CONTROLRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PANEL_CONTROLRow"/> class.
		/// </summary>
		public PANEL_CONTROLRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PANEL_CONTROLRow Clonar()
		{
			return (PANEL_CONTROLRow)this.MemberwiseClone();
		}
	} // End of PANEL_CONTROLRow class
} // End of namespace
