// <fileinfo name="LOG_ACTIVIDADESRow.cs">
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
	/// Represents a record in the <c>LOG_ACTIVIDADES</c> table.
	/// </summary>
	public class LOG_ACTIVIDADESRow : LOG_ACTIVIDADESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_ACTIVIDADESRow"/> class.
		/// </summary>
		public LOG_ACTIVIDADESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LOG_ACTIVIDADESRow Clonar()
		{
			return (LOG_ACTIVIDADESRow)this.MemberwiseClone();
		}
	} // End of LOG_ACTIVIDADESRow class
} // End of namespace
