// <fileinfo name="CATALOGOSRow.cs">
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
	/// Represents a record in the <c>CATALOGOS</c> table.
	/// </summary>
	public class CATALOGOSRow : CATALOGOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CATALOGOSRow"/> class.
		/// </summary>
		public CATALOGOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CATALOGOSRow Clonar()
		{
			return (CATALOGOSRow)this.MemberwiseClone();
		}
	} // End of CATALOGOSRow class
} // End of namespace
