// <fileinfo name="COMENTARIOS_TRANSICIONESRow.cs">
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
	/// Represents a record in the <c>COMENTARIOS_TRANSICIONES</c> table.
	/// </summary>
	public class COMENTARIOS_TRANSICIONESRow : COMENTARIOS_TRANSICIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="COMENTARIOS_TRANSICIONESRow"/> class.
		/// </summary>
		public COMENTARIOS_TRANSICIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public COMENTARIOS_TRANSICIONESRow Clonar()
		{
			return (COMENTARIOS_TRANSICIONESRow)this.MemberwiseClone();
		}
	} // End of COMENTARIOS_TRANSICIONESRow class
} // End of namespace
