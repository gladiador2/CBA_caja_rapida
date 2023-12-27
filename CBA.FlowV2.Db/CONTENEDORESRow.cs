// <fileinfo name="CONTENEDORESRow.cs">
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
	/// Represents a record in the <c>CONTENEDORES</c> table.
	/// </summary>
	public class CONTENEDORESRow : CONTENEDORESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORESRow"/> class.
		/// </summary>
		public CONTENEDORESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CONTENEDORESRow Clonar()
		{
			return (CONTENEDORESRow)this.MemberwiseClone();
		}
	} // End of CONTENEDORESRow class
} // End of namespace
