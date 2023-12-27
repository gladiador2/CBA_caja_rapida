// <fileinfo name="RUBROS_IVARow.cs">
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
	/// Represents a record in the <c>RUBROS_IVA</c> table.
	/// </summary>
	public class RUBROS_IVARow : RUBROS_IVARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RUBROS_IVARow"/> class.
		/// </summary>
		public RUBROS_IVARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public RUBROS_IVARow Clonar()
		{
			return (RUBROS_IVARow)this.MemberwiseClone();
		}
	} // End of RUBROS_IVARow class
} // End of namespace
