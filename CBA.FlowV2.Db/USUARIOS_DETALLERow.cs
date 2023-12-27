// <fileinfo name="USUARIOS_DETALLERow.cs">
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
	/// Represents a record in the <c>USUARIOS_DETALLE</c> table.
	/// </summary>
	public class USUARIOS_DETALLERow : USUARIOS_DETALLERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_DETALLERow"/> class.
		/// </summary>
		public USUARIOS_DETALLERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public USUARIOS_DETALLERow Clonar()
		{
			return (USUARIOS_DETALLERow)this.MemberwiseClone();
		}
	} // End of USUARIOS_DETALLERow class
} // End of namespace
