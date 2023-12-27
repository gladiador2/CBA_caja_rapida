// <fileinfo name="FACTURA_ENVASESRow.cs">
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
	/// Represents a record in the <c>FACTURA_ENVASES</c> table.
	/// </summary>
	public class FACTURA_ENVASESRow : FACTURA_ENVASESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURA_ENVASESRow"/> class.
		/// </summary>
		public FACTURA_ENVASESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FACTURA_ENVASESRow Clonar()
		{
			return (FACTURA_ENVASESRow)this.MemberwiseClone();
		}
	} // End of FACTURA_ENVASESRow class
} // End of namespace
