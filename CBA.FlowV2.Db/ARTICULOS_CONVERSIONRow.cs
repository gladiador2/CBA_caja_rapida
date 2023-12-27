// <fileinfo name="ARTICULOS_CONVERSIONRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_CONVERSION</c> table.
	/// </summary>
	public class ARTICULOS_CONVERSIONRow : ARTICULOS_CONVERSIONRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_CONVERSIONRow"/> class.
		/// </summary>
		public ARTICULOS_CONVERSIONRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_CONVERSIONRow Clonar()
		{
			return (ARTICULOS_CONVERSIONRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_CONVERSIONRow class
} // End of namespace
