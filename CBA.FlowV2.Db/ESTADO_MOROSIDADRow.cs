// <fileinfo name="ESTADO_MOROSIDADRow.cs">
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
	/// Represents a record in the <c>ESTADO_MOROSIDAD</c> table.
	/// </summary>
	public class ESTADO_MOROSIDADRow : ESTADO_MOROSIDADRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ESTADO_MOROSIDADRow"/> class.
		/// </summary>
		public ESTADO_MOROSIDADRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ESTADO_MOROSIDADRow Clonar()
		{
			return (ESTADO_MOROSIDADRow)this.MemberwiseClone();
		}
	} // End of ESTADO_MOROSIDADRow class
} // End of namespace
