// <fileinfo name="TAREAS_PERSONASRow.cs">
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
	/// Represents a record in the <c>TAREAS_PERSONAS</c> table.
	/// </summary>
	public class TAREAS_PERSONASRow : TAREAS_PERSONASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TAREAS_PERSONASRow"/> class.
		/// </summary>
		public TAREAS_PERSONASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TAREAS_PERSONASRow Clonar()
		{
			return (TAREAS_PERSONASRow)this.MemberwiseClone();
		}
	} // End of TAREAS_PERSONASRow class
} // End of namespace
