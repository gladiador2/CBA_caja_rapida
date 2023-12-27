// <fileinfo name="INGRESO_INSUMOSRow.cs">
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
	/// Represents a record in the <c>INGRESO_INSUMOS</c> table.
	/// </summary>
	public class INGRESO_INSUMOSRow : INGRESO_INSUMOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_INSUMOSRow"/> class.
		/// </summary>
		public INGRESO_INSUMOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public INGRESO_INSUMOSRow Clonar()
		{
			return (INGRESO_INSUMOSRow)this.MemberwiseClone();
		}
	} // End of INGRESO_INSUMOSRow class
} // End of namespace
