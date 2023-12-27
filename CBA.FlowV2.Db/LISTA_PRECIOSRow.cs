// <fileinfo name="LISTA_PRECIOSRow.cs">
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
	/// Represents a record in the <c>LISTA_PRECIOS</c> table.
	/// </summary>
	public class LISTA_PRECIOSRow : LISTA_PRECIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOSRow"/> class.
		/// </summary>
		public LISTA_PRECIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LISTA_PRECIOSRow Clonar()
		{
			return (LISTA_PRECIOSRow)this.MemberwiseClone();
		}
	} // End of LISTA_PRECIOSRow class
} // End of namespace
