// <fileinfo name="TIPOS_RETENCIONESRow.cs">
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
	/// Represents a record in the <c>TIPOS_RETENCIONES</c> table.
	/// </summary>
	public class TIPOS_RETENCIONESRow : TIPOS_RETENCIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_RETENCIONESRow"/> class.
		/// </summary>
		public TIPOS_RETENCIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_RETENCIONESRow Clonar()
		{
			return (TIPOS_RETENCIONESRow)this.MemberwiseClone();
		}
	} // End of TIPOS_RETENCIONESRow class
} // End of namespace
