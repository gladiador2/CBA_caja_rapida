// <fileinfo name="TRAMITES_TIPOSRow.cs">
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
	/// Represents a record in the <c>TRAMITES_TIPOS</c> table.
	/// </summary>
	public class TRAMITES_TIPOSRow : TRAMITES_TIPOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOSRow"/> class.
		/// </summary>
		public TRAMITES_TIPOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRAMITES_TIPOSRow Clonar()
		{
			return (TRAMITES_TIPOSRow)this.MemberwiseClone();
		}
	} // End of TRAMITES_TIPOSRow class
} // End of namespace
