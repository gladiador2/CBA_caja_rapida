// <fileinfo name="ARTICULOS_PADRESRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_PADRES</c> table.
	/// </summary>
	public class ARTICULOS_PADRESRow : ARTICULOS_PADRESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PADRESRow"/> class.
		/// </summary>
		public ARTICULOS_PADRESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_PADRESRow Clonar()
		{
			return (ARTICULOS_PADRESRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_PADRESRow class
} // End of namespace
