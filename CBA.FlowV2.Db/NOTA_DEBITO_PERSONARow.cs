// <fileinfo name="NOTA_DEBITO_PERSONARow.cs">
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
	/// Represents a record in the <c>NOTA_DEBITO_PERSONA</c> table.
	/// </summary>
	public class NOTA_DEBITO_PERSONARow : NOTA_DEBITO_PERSONARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NOTA_DEBITO_PERSONARow"/> class.
		/// </summary>
		public NOTA_DEBITO_PERSONARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public NOTA_DEBITO_PERSONARow Clonar()
		{
			return (NOTA_DEBITO_PERSONARow)this.MemberwiseClone();
		}
	} // End of NOTA_DEBITO_PERSONARow class
} // End of namespace
