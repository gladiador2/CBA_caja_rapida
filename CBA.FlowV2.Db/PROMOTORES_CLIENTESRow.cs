// <fileinfo name="PROMOTORES_CLIENTESRow.cs">
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
	/// Represents a record in the <c>PROMOTORES_CLIENTES</c> table.
	/// </summary>
	public class PROMOTORES_CLIENTESRow : PROMOTORES_CLIENTESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PROMOTORES_CLIENTESRow"/> class.
		/// </summary>
		public PROMOTORES_CLIENTESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PROMOTORES_CLIENTESRow Clonar()
		{
			return (PROMOTORES_CLIENTESRow)this.MemberwiseClone();
		}
	} // End of PROMOTORES_CLIENTESRow class
} // End of namespace
