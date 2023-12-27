// <fileinfo name="REGIONESRow.cs">
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
	/// Represents a record in the <c>REGIONES</c> table.
	/// </summary>
	public class REGIONESRow : REGIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REGIONESRow"/> class.
		/// </summary>
		public REGIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REGIONESRow Clonar()
		{
			return (REGIONESRow)this.MemberwiseClone();
		}
	} // End of REGIONESRow class
} // End of namespace
