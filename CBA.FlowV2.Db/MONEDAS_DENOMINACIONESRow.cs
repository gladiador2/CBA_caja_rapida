// <fileinfo name="MONEDAS_DENOMINACIONESRow.cs">
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
	/// Represents a record in the <c>MONEDAS_DENOMINACIONES</c> table.
	/// </summary>
	public class MONEDAS_DENOMINACIONESRow : MONEDAS_DENOMINACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MONEDAS_DENOMINACIONESRow"/> class.
		/// </summary>
		public MONEDAS_DENOMINACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public MONEDAS_DENOMINACIONESRow Clonar()
		{
			return (MONEDAS_DENOMINACIONESRow)this.MemberwiseClone();
		}
	} // End of MONEDAS_DENOMINACIONESRow class
} // End of namespace
