// <fileinfo name="PLAN_TAREASRow.cs">
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
	/// Represents a record in the <c>PLAN_TAREAS</c> table.
	/// </summary>
	public class PLAN_TAREASRow : PLAN_TAREASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLAN_TAREASRow"/> class.
		/// </summary>
		public PLAN_TAREASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLAN_TAREASRow Clonar()
		{
			return (PLAN_TAREASRow)this.MemberwiseClone();
		}
	} // End of PLAN_TAREASRow class
} // End of namespace
