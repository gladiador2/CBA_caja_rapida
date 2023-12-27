// <fileinfo name="PLANES_FACTURACIONRow.cs">
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
	/// Represents a record in the <c>PLANES_FACTURACION</c> table.
	/// </summary>
	public class PLANES_FACTURACIONRow : PLANES_FACTURACIONRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANES_FACTURACIONRow"/> class.
		/// </summary>
		public PLANES_FACTURACIONRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANES_FACTURACIONRow Clonar()
		{
			return (PLANES_FACTURACIONRow)this.MemberwiseClone();
		}
	} // End of PLANES_FACTURACIONRow class
} // End of namespace
