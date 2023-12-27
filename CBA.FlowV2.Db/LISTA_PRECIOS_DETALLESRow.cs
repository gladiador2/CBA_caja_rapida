// <fileinfo name="LISTA_PRECIOS_DETALLESRow.cs">
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
	/// Represents a record in the <c>LISTA_PRECIOS_DETALLES</c> table.
	/// </summary>
	public class LISTA_PRECIOS_DETALLESRow : LISTA_PRECIOS_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOS_DETALLESRow"/> class.
		/// </summary>
		public LISTA_PRECIOS_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LISTA_PRECIOS_DETALLESRow Clonar()
		{
			return (LISTA_PRECIOS_DETALLESRow)this.MemberwiseClone();
		}
	} // End of LISTA_PRECIOS_DETALLESRow class
} // End of namespace
