// <fileinfo name="TIPOS_ALARMARow.cs">
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
	/// Represents a record in the <c>TIPOS_ALARMA</c> table.
	/// </summary>
	public class TIPOS_ALARMARow : TIPOS_ALARMARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_ALARMARow"/> class.
		/// </summary>
		public TIPOS_ALARMARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_ALARMARow Clonar()
		{
			return (TIPOS_ALARMARow)this.MemberwiseClone();
		}
	} // End of TIPOS_ALARMARow class
} // End of namespace
