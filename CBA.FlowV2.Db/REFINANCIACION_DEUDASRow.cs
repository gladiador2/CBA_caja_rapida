// <fileinfo name="REFINANCIACION_DEUDASRow.cs">
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
	/// Represents a record in the <c>REFINANCIACION_DEUDAS</c> table.
	/// </summary>
	public class REFINANCIACION_DEUDASRow : REFINANCIACION_DEUDASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REFINANCIACION_DEUDASRow"/> class.
		/// </summary>
		public REFINANCIACION_DEUDASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REFINANCIACION_DEUDASRow Clonar()
		{
			return (REFINANCIACION_DEUDASRow)this.MemberwiseClone();
		}
	} // End of REFINANCIACION_DEUDASRow class
} // End of namespace
