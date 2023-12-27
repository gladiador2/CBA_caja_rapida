// <fileinfo name="NOMINA_CONTENEDORESRow.cs">
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
	/// Represents a record in the <c>NOMINA_CONTENEDORES</c> table.
	/// </summary>
	public class NOMINA_CONTENEDORESRow : NOMINA_CONTENEDORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENEDORESRow"/> class.
		/// </summary>
		public NOMINA_CONTENEDORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public NOMINA_CONTENEDORESRow Clonar()
		{
			return (NOMINA_CONTENEDORESRow)this.MemberwiseClone();
		}
	} // End of NOMINA_CONTENEDORESRow class
} // End of namespace
