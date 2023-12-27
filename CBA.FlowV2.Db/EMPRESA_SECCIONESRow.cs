// <fileinfo name="EMPRESA_SECCIONESRow.cs">
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
	/// Represents a record in the <c>EMPRESA_SECCIONES</c> table.
	/// </summary>
	public class EMPRESA_SECCIONESRow : EMPRESA_SECCIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_SECCIONESRow"/> class.
		/// </summary>
		public EMPRESA_SECCIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public EMPRESA_SECCIONESRow Clonar()
		{
			return (EMPRESA_SECCIONESRow)this.MemberwiseClone();
		}
	} // End of EMPRESA_SECCIONESRow class
} // End of namespace
