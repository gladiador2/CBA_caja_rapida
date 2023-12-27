// <fileinfo name="TIPOS_ENTRADA_LEGAJORow.cs">
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
	/// Represents a record in the <c>TIPOS_ENTRADA_LEGAJO</c> table.
	/// </summary>
	public class TIPOS_ENTRADA_LEGAJORow : TIPOS_ENTRADA_LEGAJORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ENTRADA_LEGAJORow"/> class.
		/// </summary>
		public TIPOS_ENTRADA_LEGAJORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_ENTRADA_LEGAJORow Clonar()
		{
			return (TIPOS_ENTRADA_LEGAJORow)this.MemberwiseClone();
		}
	} // End of TIPOS_ENTRADA_LEGAJORow class
} // End of namespace
