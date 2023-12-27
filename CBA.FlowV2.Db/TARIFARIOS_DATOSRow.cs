// <fileinfo name="TARIFARIOS_DATOSRow.cs">
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
	/// Represents a record in the <c>TARIFARIOS_DATOS</c> table.
	/// </summary>
	public class TARIFARIOS_DATOSRow : TARIFARIOS_DATOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_DATOSRow"/> class.
		/// </summary>
		public TARIFARIOS_DATOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TARIFARIOS_DATOSRow Clonar()
		{
			return (TARIFARIOS_DATOSRow)this.MemberwiseClone();
		}
	} // End of TARIFARIOS_DATOSRow class
} // End of namespace
