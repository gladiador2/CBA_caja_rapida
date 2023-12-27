// <fileinfo name="REPORTES_CONTADORESRow.cs">
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
	/// Represents a record in the <c>REPORTES_CONTADORES</c> table.
	/// </summary>
	public class REPORTES_CONTADORESRow : REPORTES_CONTADORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REPORTES_CONTADORESRow"/> class.
		/// </summary>
		public REPORTES_CONTADORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REPORTES_CONTADORESRow Clonar()
		{
			return (REPORTES_CONTADORESRow)this.MemberwiseClone();
		}
	} // End of REPORTES_CONTADORESRow class
} // End of namespace
