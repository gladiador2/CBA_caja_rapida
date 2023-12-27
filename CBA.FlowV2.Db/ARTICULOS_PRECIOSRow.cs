// <fileinfo name="ARTICULOS_PRECIOSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_PRECIOS</c> view.
	/// </summary>
	public class ARTICULOS_PRECIOSRow : ARTICULOS_PRECIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PRECIOSRow"/> class.
		/// </summary>
		public ARTICULOS_PRECIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_PRECIOSRow Clonar()
		{
			return (ARTICULOS_PRECIOSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_PRECIOSRow class
} // End of namespace
