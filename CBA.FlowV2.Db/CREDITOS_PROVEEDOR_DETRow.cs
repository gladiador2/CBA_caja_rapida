// <fileinfo name="CREDITOS_PROVEEDOR_DETRow.cs">
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
	/// Represents a record in the <c>CREDITOS_PROVEEDOR_DET</c> table.
	/// </summary>
	public class CREDITOS_PROVEEDOR_DETRow : CREDITOS_PROVEEDOR_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_PROVEEDOR_DETRow"/> class.
		/// </summary>
		public CREDITOS_PROVEEDOR_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CREDITOS_PROVEEDOR_DETRow Clonar()
		{
			return (CREDITOS_PROVEEDOR_DETRow)this.MemberwiseClone();
		}
	} // End of CREDITOS_PROVEEDOR_DETRow class
} // End of namespace
