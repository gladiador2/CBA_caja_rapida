// <fileinfo name="ARTICULOS_FINANCIEROSRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_FINANCIEROS</c> table.
	/// </summary>
	public class ARTICULOS_FINANCIEROSRow : ARTICULOS_FINANCIEROSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FINANCIEROSRow"/> class.
		/// </summary>
		public ARTICULOS_FINANCIEROSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_FINANCIEROSRow Clonar()
		{
			return (ARTICULOS_FINANCIEROSRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_FINANCIEROSRow class
} // End of namespace
