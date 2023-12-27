// <fileinfo name="TIPOS_PANEL_CONTROLRow.cs">
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
	/// Represents a record in the <c>TIPOS_PANEL_CONTROL</c> table.
	/// </summary>
	public class TIPOS_PANEL_CONTROLRow : TIPOS_PANEL_CONTROLRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_PANEL_CONTROLRow"/> class.
		/// </summary>
		public TIPOS_PANEL_CONTROLRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_PANEL_CONTROLRow Clonar()
		{
			return (TIPOS_PANEL_CONTROLRow)this.MemberwiseClone();
		}
	} // End of TIPOS_PANEL_CONTROLRow class
} // End of namespace
