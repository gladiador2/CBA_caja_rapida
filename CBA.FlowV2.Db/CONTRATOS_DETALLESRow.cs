// <fileinfo name="CONTRATOS_DETALLESRow.cs">
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
	/// Represents a record in the <c>CONTRATOS_DETALLES</c> table.
	/// </summary>
	public class CONTRATOS_DETALLESRow : CONTRATOS_DETALLESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CONTRATOS_DETALLESRow"/> class.
		/// </summary>
		public CONTRATOS_DETALLESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CONTRATOS_DETALLESRow Clonar()
		{
			return (CONTRATOS_DETALLESRow)this.MemberwiseClone();
		}
	} // End of CONTRATOS_DETALLESRow class
} // End of namespace
