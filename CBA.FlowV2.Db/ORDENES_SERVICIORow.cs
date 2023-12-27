// <fileinfo name="ORDENES_SERVICIORow.cs">
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
	/// Represents a record in the <c>ORDENES_SERVICIO</c> table.
	/// </summary>
	public class ORDENES_SERVICIORow : ORDENES_SERVICIORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIORow"/> class.
		/// </summary>
		public ORDENES_SERVICIORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ORDENES_SERVICIORow Clonar()
		{
			return (ORDENES_SERVICIORow)this.MemberwiseClone();
		}
	} // End of ORDENES_SERVICIORow class
} // End of namespace
