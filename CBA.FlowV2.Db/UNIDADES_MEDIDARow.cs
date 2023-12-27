// <fileinfo name="UNIDADES_MEDIDARow.cs">
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
	/// Represents a record in the <c>UNIDADES_MEDIDA</c> table.
	/// </summary>
	public class UNIDADES_MEDIDARow : UNIDADES_MEDIDARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UNIDADES_MEDIDARow"/> class.
		/// </summary>
		public UNIDADES_MEDIDARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public UNIDADES_MEDIDARow Clonar()
		{
			return (UNIDADES_MEDIDARow)this.MemberwiseClone();
		}
	} // End of UNIDADES_MEDIDARow class
} // End of namespace
