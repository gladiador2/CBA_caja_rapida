// <fileinfo name="TAREAS_PROGRAMADASRow.cs">
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
	/// Represents a record in the <c>TAREAS_PROGRAMADAS</c> table.
	/// </summary>
	public class TAREAS_PROGRAMADASRow : TAREAS_PROGRAMADASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TAREAS_PROGRAMADASRow"/> class.
		/// </summary>
		public TAREAS_PROGRAMADASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TAREAS_PROGRAMADASRow Clonar()
		{
			return (TAREAS_PROGRAMADASRow)this.MemberwiseClone();
		}
	} // End of TAREAS_PROGRAMADASRow class
} // End of namespace
