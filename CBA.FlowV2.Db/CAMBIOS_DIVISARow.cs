// <fileinfo name="CAMBIOS_DIVISARow.cs">
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
	/// Represents a record in the <c>CAMBIOS_DIVISA</c> table.
	/// </summary>
	public class CAMBIOS_DIVISARow : CAMBIOS_DIVISARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CAMBIOS_DIVISARow"/> class.
		/// </summary>
		public CAMBIOS_DIVISARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CAMBIOS_DIVISARow Clonar()
		{
			return (CAMBIOS_DIVISARow)this.MemberwiseClone();
		}
	} // End of CAMBIOS_DIVISARow class
} // End of namespace
