// <fileinfo name="REMISIONES_DETALLESRow.cs">
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
	/// Represents a record in the <c>REMISIONES_DETALLES</c> table.
	/// </summary>
	public class REMISIONES_DETALLESRow : REMISIONES_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REMISIONES_DETALLESRow"/> class.
		/// </summary>
		public REMISIONES_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REMISIONES_DETALLESRow Clonar()
		{
			return (REMISIONES_DETALLESRow)this.MemberwiseClone();
		}
	} // End of REMISIONES_DETALLESRow class
} // End of namespace
