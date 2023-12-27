// <fileinfo name="CATEGORIAS_IMORow.cs">
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
	/// Represents a record in the <c>CATEGORIAS_IMO</c> table.
	/// </summary>
	public class CATEGORIAS_IMORow : CATEGORIAS_IMORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CATEGORIAS_IMORow"/> class.
		/// </summary>
		public CATEGORIAS_IMORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CATEGORIAS_IMORow Clonar()
		{
			return (CATEGORIAS_IMORow)this.MemberwiseClone();
		}
	} // End of CATEGORIAS_IMORow class
} // End of namespace
