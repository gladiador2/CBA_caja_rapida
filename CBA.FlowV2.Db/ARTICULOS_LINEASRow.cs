// <fileinfo name="ARTICULOS_LINEASRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_LINEAS</c> table.
	/// </summary>
	public class ARTICULOS_LINEASRow : ARTICULOS_LINEASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_LINEASRow"/> class.
		/// </summary>
		public ARTICULOS_LINEASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_LINEASRow Clonar()
		{
			return (ARTICULOS_LINEASRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_LINEASRow class
} // End of namespace
