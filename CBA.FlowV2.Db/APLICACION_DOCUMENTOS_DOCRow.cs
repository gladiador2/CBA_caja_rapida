// <fileinfo name="APLICACION_DOCUMENTOS_DOCRow.cs">
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
	/// Represents a record in the <c>APLICACION_DOCUMENTOS_DOC</c> table.
	/// </summary>
	public class APLICACION_DOCUMENTOS_DOCRow : APLICACION_DOCUMENTOS_DOCRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMENTOS_DOCRow"/> class.
		/// </summary>
		public APLICACION_DOCUMENTOS_DOCRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public APLICACION_DOCUMENTOS_DOCRow Clonar()
		{
			return (APLICACION_DOCUMENTOS_DOCRow)this.MemberwiseClone();
		}
	} // End of APLICACION_DOCUMENTOS_DOCRow class
} // End of namespace
