// <fileinfo name="EMPRESA_CARGOSRow.cs">
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
	/// Represents a record in the <c>EMPRESA_CARGOS</c> table.
	/// </summary>
	public class EMPRESA_CARGOSRow : EMPRESA_CARGOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_CARGOSRow"/> class.
		/// </summary>
		public EMPRESA_CARGOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public EMPRESA_CARGOSRow Clonar()
		{
			return (EMPRESA_CARGOSRow)this.MemberwiseClone();
		}
	} // End of EMPRESA_CARGOSRow class
} // End of namespace
