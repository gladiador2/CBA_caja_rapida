// <fileinfo name="OPERACIONES_TIPORow.cs">
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
	/// Represents a record in the <c>OPERACIONES_TIPO</c> table.
	/// </summary>
	public class OPERACIONES_TIPORow : OPERACIONES_TIPORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OPERACIONES_TIPORow"/> class.
		/// </summary>
		public OPERACIONES_TIPORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public OPERACIONES_TIPORow Clonar()
		{
			return (OPERACIONES_TIPORow)this.MemberwiseClone();
		}
	} // End of OPERACIONES_TIPORow class
} // End of namespace
