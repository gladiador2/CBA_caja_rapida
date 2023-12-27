// <fileinfo name="CREDITOS_DETALLESRow.cs">
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
	/// Represents a record in the <c>CREDITOS_DETALLES</c> table.
	/// </summary>
	public class CREDITOS_DETALLESRow : CREDITOS_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_DETALLESRow"/> class.
		/// </summary>
		public CREDITOS_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CREDITOS_DETALLESRow Clonar()
		{
			return (CREDITOS_DETALLESRow)this.MemberwiseClone();
		}
	} // End of CREDITOS_DETALLESRow class
} // End of namespace
