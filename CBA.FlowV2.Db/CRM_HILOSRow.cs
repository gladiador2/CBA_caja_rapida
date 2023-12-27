// <fileinfo name="CRM_HILOSRow.cs">
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
	/// Represents a record in the <c>CRM_HILOS</c> table.
	/// </summary>
	public class CRM_HILOSRow : CRM_HILOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CRM_HILOSRow"/> class.
		/// </summary>
		public CRM_HILOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CRM_HILOSRow Clonar()
		{
			return (CRM_HILOSRow)this.MemberwiseClone();
		}
	} // End of CRM_HILOSRow class
} // End of namespace
