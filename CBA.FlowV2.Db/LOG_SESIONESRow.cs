// <fileinfo name="LOG_SESIONESRow.cs">
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
	/// Represents a record in the <c>LOG_SESIONES</c> table.
	/// </summary>
	public class LOG_SESIONESRow : LOG_SESIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LOG_SESIONESRow"/> class.
		/// </summary>
		public LOG_SESIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LOG_SESIONESRow Clonar()
		{
			return (LOG_SESIONESRow)this.MemberwiseClone();
		}
	} // End of LOG_SESIONESRow class
} // End of namespace
