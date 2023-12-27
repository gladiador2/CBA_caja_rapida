// <fileinfo name="SUCURSALES_SECTORESRow.cs">
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
	/// Represents a record in the <c>SUCURSALES_SECTORES</c> table.
	/// </summary>
	public class SUCURSALES_SECTORESRow : SUCURSALES_SECTORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SUCURSALES_SECTORESRow"/> class.
		/// </summary>
		public SUCURSALES_SECTORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public SUCURSALES_SECTORESRow Clonar()
		{
			return (SUCURSALES_SECTORESRow)this.MemberwiseClone();
		}
	} // End of SUCURSALES_SECTORESRow class
} // End of namespace
