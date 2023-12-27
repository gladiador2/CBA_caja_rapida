// <fileinfo name="IMPORTACIONESRow.cs">
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
	/// Represents a record in the <c>IMPORTACIONES</c> table.
	/// </summary>
	public class IMPORTACIONESRow : IMPORTACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONESRow"/> class.
		/// </summary>
		public IMPORTACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public IMPORTACIONESRow Clonar()
		{
			return (IMPORTACIONESRow)this.MemberwiseClone();
		}
	} // End of IMPORTACIONESRow class
} // End of namespace
