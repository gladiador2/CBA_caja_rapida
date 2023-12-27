// <fileinfo name="MENSAJES_SISTEMARow.cs">
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
	/// Represents a record in the <c>MENSAJES_SISTEMA</c> table.
	/// </summary>
	public class MENSAJES_SISTEMARow : MENSAJES_SISTEMARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MENSAJES_SISTEMARow"/> class.
		/// </summary>
		public MENSAJES_SISTEMARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public MENSAJES_SISTEMARow Clonar()
		{
			return (MENSAJES_SISTEMARow)this.MemberwiseClone();
		}
	} // End of MENSAJES_SISTEMARow class
} // End of namespace
