// <fileinfo name="ARTICULOS_DATOS_PERSONARow.cs">
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
	/// Represents a record in the <c>ARTICULOS_DATOS_PERSONA</c> table.
	/// </summary>
	public class ARTICULOS_DATOS_PERSONARow : ARTICULOS_DATOS_PERSONARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_DATOS_PERSONARow"/> class.
		/// </summary>
		public ARTICULOS_DATOS_PERSONARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_DATOS_PERSONARow Clonar()
		{
			return (ARTICULOS_DATOS_PERSONARow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_DATOS_PERSONARow class
} // End of namespace
