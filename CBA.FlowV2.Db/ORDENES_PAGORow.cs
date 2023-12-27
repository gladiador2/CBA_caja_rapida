// <fileinfo name="ORDENES_PAGORow.cs">
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
	/// Represents a record in the <c>ORDENES_PAGO</c> table.
	/// </summary>
	public class ORDENES_PAGORow : ORDENES_PAGORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGORow"/> class.
		/// </summary>
		public ORDENES_PAGORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ORDENES_PAGORow Clonar()
		{
			return (ORDENES_PAGORow)this.MemberwiseClone();
		}
	} // End of ORDENES_PAGORow class
} // End of namespace
