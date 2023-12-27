// <fileinfo name="ENCUESTAS_RESPUESTASRow.cs">
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
	/// Represents a record in the <c>ENCUESTAS_RESPUESTAS</c> table.
	/// </summary>
	public class ENCUESTAS_RESPUESTASRow : ENCUESTAS_RESPUESTASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTAS_RESPUESTASRow"/> class.
		/// </summary>
		public ENCUESTAS_RESPUESTASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ENCUESTAS_RESPUESTASRow Clonar()
		{
			return (ENCUESTAS_RESPUESTASRow)this.MemberwiseClone();
		}
	} // End of ENCUESTAS_RESPUESTASRow class
} // End of namespace
