// <fileinfo name="TRANSICIONES_TIPORow.cs">
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
	/// Represents a record in the <c>TRANSICIONES_TIPO</c> table.
	/// </summary>
	public class TRANSICIONES_TIPORow : TRANSICIONES_TIPORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSICIONES_TIPORow"/> class.
		/// </summary>
		public TRANSICIONES_TIPORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRANSICIONES_TIPORow Clonar()
		{
			return (TRANSICIONES_TIPORow)this.MemberwiseClone();
		}
	} // End of TRANSICIONES_TIPORow class
} // End of namespace
