// <fileinfo name="INTERCAMBIO_EQUIPOSRow.cs">
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
	/// Represents a record in the <c>INTERCAMBIO_EQUIPOS</c> table.
	/// </summary>
	public class INTERCAMBIO_EQUIPOSRow : INTERCAMBIO_EQUIPOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="INTERCAMBIO_EQUIPOSRow"/> class.
		/// </summary>
		public INTERCAMBIO_EQUIPOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public INTERCAMBIO_EQUIPOSRow Clonar()
		{
			return (INTERCAMBIO_EQUIPOSRow)this.MemberwiseClone();
		}
	} // End of INTERCAMBIO_EQUIPOSRow class
} // End of namespace
