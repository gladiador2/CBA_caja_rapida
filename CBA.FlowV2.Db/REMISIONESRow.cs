// <fileinfo name="REMISIONESRow.cs">
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
	/// Represents a record in the <c>REMISIONES</c> table.
	/// </summary>
	public class REMISIONESRow : REMISIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REMISIONESRow"/> class.
		/// </summary>
		public REMISIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REMISIONESRow Clonar()
		{
			return (REMISIONESRow)this.MemberwiseClone();
		}
	} // End of REMISIONESRow class
} // End of namespace
