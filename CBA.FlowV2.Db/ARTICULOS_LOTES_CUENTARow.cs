// <fileinfo name="ARTICULOS_LOTES_CUENTARow.cs">
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
	/// Represents a record in the <c>ARTICULOS_LOTES_CUENTA</c> view.
	/// </summary>
	public class ARTICULOS_LOTES_CUENTARow : ARTICULOS_LOTES_CUENTARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_LOTES_CUENTARow"/> class.
		/// </summary>
		public ARTICULOS_LOTES_CUENTARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_LOTES_CUENTARow Clonar()
		{
			return (ARTICULOS_LOTES_CUENTARow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_LOTES_CUENTARow class
} // End of namespace
