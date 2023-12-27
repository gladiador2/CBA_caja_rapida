// <fileinfo name="FORMATOS_REPORTERow.cs">
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
	/// Represents a record in the <c>FORMATOS_REPORTE</c> table.
	/// </summary>
	public class FORMATOS_REPORTERow : FORMATOS_REPORTERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FORMATOS_REPORTERow"/> class.
		/// </summary>
		public FORMATOS_REPORTERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FORMATOS_REPORTERow Clonar()
		{
			return (FORMATOS_REPORTERow)this.MemberwiseClone();
		}
	} // End of FORMATOS_REPORTERow class
} // End of namespace
