// <fileinfo name="LEGAJO_ENTRADASRow.cs">
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
	/// Represents a record in the <c>LEGAJO_ENTRADAS</c> table.
	/// </summary>
	public class LEGAJO_ENTRADASRow : LEGAJO_ENTRADASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LEGAJO_ENTRADASRow"/> class.
		/// </summary>
		public LEGAJO_ENTRADASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public LEGAJO_ENTRADASRow Clonar()
		{
			return (LEGAJO_ENTRADASRow)this.MemberwiseClone();
		}
	} // End of LEGAJO_ENTRADASRow class
} // End of namespace
