// <fileinfo name="CTB_INDICADORESRow.cs">
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
	/// Represents a record in the <c>CTB_INDICADORES</c> table.
	/// </summary>
	public class CTB_INDICADORESRow : CTB_INDICADORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_INDICADORESRow"/> class.
		/// </summary>
		public CTB_INDICADORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTB_INDICADORESRow Clonar()
		{
			return (CTB_INDICADORESRow)this.MemberwiseClone();
		}
	} // End of CTB_INDICADORESRow class
} // End of namespace
