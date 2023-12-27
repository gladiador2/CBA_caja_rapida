// <fileinfo name="TIPOS_EVENTO_CALENDARIORow.cs">
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
	/// Represents a record in the <c>TIPOS_EVENTO_CALENDARIO</c> table.
	/// </summary>
	public class TIPOS_EVENTO_CALENDARIORow : TIPOS_EVENTO_CALENDARIORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_EVENTO_CALENDARIORow"/> class.
		/// </summary>
		public TIPOS_EVENTO_CALENDARIORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_EVENTO_CALENDARIORow Clonar()
		{
			return (TIPOS_EVENTO_CALENDARIORow)this.MemberwiseClone();
		}
	} // End of TIPOS_EVENTO_CALENDARIORow class
} // End of namespace
