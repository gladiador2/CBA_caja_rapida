// <fileinfo name="ENCUESTAS_PREGUNTASRow.cs">
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
	/// Represents a record in the <c>ENCUESTAS_PREGUNTAS</c> table.
	/// </summary>
	public class ENCUESTAS_PREGUNTASRow : ENCUESTAS_PREGUNTASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTAS_PREGUNTASRow"/> class.
		/// </summary>
		public ENCUESTAS_PREGUNTASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ENCUESTAS_PREGUNTASRow Clonar()
		{
			return (ENCUESTAS_PREGUNTASRow)this.MemberwiseClone();
		}
	} // End of ENCUESTAS_PREGUNTASRow class
} // End of namespace
