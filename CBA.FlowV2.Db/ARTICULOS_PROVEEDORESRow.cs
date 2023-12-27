// <fileinfo name="ARTICULOS_PROVEEDORESRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_PROVEEDORES</c> table.
	/// </summary>
	public class ARTICULOS_PROVEEDORESRow : ARTICULOS_PROVEEDORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PROVEEDORESRow"/> class.
		/// </summary>
		public ARTICULOS_PROVEEDORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_PROVEEDORESRow Clonar()
		{
			return (ARTICULOS_PROVEEDORESRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_PROVEEDORESRow class
} // End of namespace
