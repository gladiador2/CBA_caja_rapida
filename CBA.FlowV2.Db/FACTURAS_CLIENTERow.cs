// <fileinfo name="FACTURAS_CLIENTERow.cs">
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
	/// Represents a record in the <c>FACTURAS_CLIENTE</c> table.
	/// </summary>
	public class FACTURAS_CLIENTERow : FACTURAS_CLIENTERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTERow"/> class.
		/// </summary>
		public FACTURAS_CLIENTERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FACTURAS_CLIENTERow Clonar()
		{
			return (FACTURAS_CLIENTERow)this.MemberwiseClone();
		}
	} // End of FACTURAS_CLIENTERow class
} // End of namespace
