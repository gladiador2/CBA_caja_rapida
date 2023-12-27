// <fileinfo name="ARTICULOS_TALLESRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_TALLES</c> table.
	/// </summary>
	public class ARTICULOS_TALLESRow : ARTICULOS_TALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_TALLESRow"/> class.
		/// </summary>
		public ARTICULOS_TALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_TALLESRow Clonar()
		{
			return (ARTICULOS_TALLESRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_TALLESRow class
} // End of namespace
