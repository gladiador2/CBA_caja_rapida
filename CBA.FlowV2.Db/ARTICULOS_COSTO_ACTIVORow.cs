// <fileinfo name="ARTICULOS_COSTO_ACTIVORow.cs">
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
	/// Represents a record in the <c>ARTICULOS_COSTO_ACTIVO</c> view.
	/// </summary>
	public class ARTICULOS_COSTO_ACTIVORow : ARTICULOS_COSTO_ACTIVORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTO_ACTIVORow"/> class.
		/// </summary>
		public ARTICULOS_COSTO_ACTIVORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ARTICULOS_COSTO_ACTIVORow Clonar()
		{
			return (ARTICULOS_COSTO_ACTIVORow)this.MemberwiseClone();
		}
	} // End of ARTICULOS_COSTO_ACTIVORow class
} // End of namespace
