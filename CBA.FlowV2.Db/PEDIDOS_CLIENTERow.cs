// <fileinfo name="PEDIDOS_CLIENTERow.cs">
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
	/// Represents a record in the <c>PEDIDOS_CLIENTE</c> table.
	/// </summary>
	public class PEDIDOS_CLIENTERow : PEDIDOS_CLIENTERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTERow"/> class.
		/// </summary>
		public PEDIDOS_CLIENTERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PEDIDOS_CLIENTERow Clonar()
		{
			return (PEDIDOS_CLIENTERow)this.MemberwiseClone();
		}
	} // End of PEDIDOS_CLIENTERow class
} // End of namespace
