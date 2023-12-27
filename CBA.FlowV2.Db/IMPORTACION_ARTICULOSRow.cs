// <fileinfo name="IMPORTACION_ARTICULOSRow.cs">
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
	/// Represents a record in the <c>IMPORTACION_ARTICULOS</c> view.
	/// </summary>
	public class IMPORTACION_ARTICULOSRow : IMPORTACION_ARTICULOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACION_ARTICULOSRow"/> class.
		/// </summary>
		public IMPORTACION_ARTICULOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public IMPORTACION_ARTICULOSRow Clonar()
		{
			return (IMPORTACION_ARTICULOSRow)this.MemberwiseClone();
		}
	} // End of IMPORTACION_ARTICULOSRow class
} // End of namespace
