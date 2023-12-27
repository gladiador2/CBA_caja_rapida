// <fileinfo name="TIPOS_REPORTERow.cs">
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
	/// Represents a record in the <c>TIPOS_REPORTE</c> table.
	/// </summary>
	public class TIPOS_REPORTERow : TIPOS_REPORTERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_REPORTERow"/> class.
		/// </summary>
		public TIPOS_REPORTERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_REPORTERow Clonar()
		{
			return (TIPOS_REPORTERow)this.MemberwiseClone();
		}
	} // End of TIPOS_REPORTERow class
} // End of namespace
