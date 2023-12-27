// <fileinfo name="DIAS_SEMANARow.cs">
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
	/// Represents a record in the <c>DIAS_SEMANA</c> table.
	/// </summary>
	public class DIAS_SEMANARow : DIAS_SEMANARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DIAS_SEMANARow"/> class.
		/// </summary>
		public DIAS_SEMANARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public DIAS_SEMANARow Clonar()
		{
			return (DIAS_SEMANARow)this.MemberwiseClone();
		}
	} // End of DIAS_SEMANARow class
} // End of namespace
