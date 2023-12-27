// <fileinfo name="TIPOS_CLIENTESRow.cs">
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
	/// Represents a record in the <c>TIPOS_CLIENTES</c> table.
	/// </summary>
	public class TIPOS_CLIENTESRow : TIPOS_CLIENTESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_CLIENTESRow"/> class.
		/// </summary>
		public TIPOS_CLIENTESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_CLIENTESRow Clonar()
		{
			return (TIPOS_CLIENTESRow)this.MemberwiseClone();
		}
	} // End of TIPOS_CLIENTESRow class
} // End of namespace
