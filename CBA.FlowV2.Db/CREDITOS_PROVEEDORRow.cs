// <fileinfo name="CREDITOS_PROVEEDORRow.cs">
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
	/// Represents a record in the <c>CREDITOS_PROVEEDOR</c> table.
	/// </summary>
	public class CREDITOS_PROVEEDORRow : CREDITOS_PROVEEDORRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_PROVEEDORRow"/> class.
		/// </summary>
		public CREDITOS_PROVEEDORRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CREDITOS_PROVEEDORRow Clonar()
		{
			return (CREDITOS_PROVEEDORRow)this.MemberwiseClone();
		}
	} // End of CREDITOS_PROVEEDORRow class
} // End of namespace
