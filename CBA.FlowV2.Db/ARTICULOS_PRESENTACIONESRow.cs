// <fileinfo name="ARTICULOS_PRESENTACIONESRow.cs">
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
	/// Represents a record in the <c>ARTICULOS_PRESENTACIONES</c> table.
	/// </summary>
	public class ARTICULOS_PRESENTACIONESRow : ARTICULOS_PRESENTACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PRESENTACIONESRow"/> class.
		/// </summary>
		public ARTICULOS_PRESENTACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_PRESENTACIONESRow Clonar()
		{
			return (ARTICULOS_PRESENTACIONESRow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_PRESENTACIONESRow class
} // End of namespace
