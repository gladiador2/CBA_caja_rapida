// <fileinfo name="COPARN_DETALLESRow.cs">
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
	/// Represents a record in the <c>COPARN_DETALLES</c> table.
	/// </summary>
	public class COPARN_DETALLESRow : COPARN_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="COPARN_DETALLESRow"/> class.
		/// </summary>
		public COPARN_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public COPARN_DETALLESRow Clonar()
		{
			return (COPARN_DETALLESRow)this.MemberwiseClone();
		}
	} // End of COPARN_DETALLESRow class
} // End of namespace
