// <fileinfo name="PROVEEDORESRow.cs">
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
	/// Represents a record in the <c>PROVEEDORES</c> table.
	/// </summary>
	public class PROVEEDORESRow : PROVEEDORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PROVEEDORESRow"/> class.
		/// </summary>
		public PROVEEDORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PROVEEDORESRow Clonar()
		{
			return (PROVEEDORESRow)this.MemberwiseClone();
		}
	} // End of PROVEEDORESRow class
} // End of namespace
