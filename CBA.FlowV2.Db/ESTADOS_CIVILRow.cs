// <fileinfo name="ESTADOS_CIVILRow.cs">
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
	/// Represents a record in the <c>ESTADOS_CIVIL</c> table.
	/// </summary>
	public class ESTADOS_CIVILRow : ESTADOS_CIVILRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ESTADOS_CIVILRow"/> class.
		/// </summary>
		public ESTADOS_CIVILRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ESTADOS_CIVILRow Clonar()
		{
			return (ESTADOS_CIVILRow)this.MemberwiseClone();
		}
	} // End of ESTADOS_CIVILRow class
} // End of namespace
