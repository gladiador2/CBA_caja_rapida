// <fileinfo name="PLANTILLAS_INFO_COMPLETARow.cs">
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
	/// Represents a record in the <c>PLANTILLAS_INFO_COMPLETA</c> view.
	/// </summary>
	public class PLANTILLAS_INFO_COMPLETARow : PLANTILLAS_INFO_COMPLETARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANTILLAS_INFO_COMPLETARow"/> class.
		/// </summary>
		public PLANTILLAS_INFO_COMPLETARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANTILLAS_INFO_COMPLETARow Clonar()
		{
			return (PLANTILLAS_INFO_COMPLETARow)this.MemberwiseClone();
		}
	} // End of PLANTILLAS_INFO_COMPLETARow class
} // End of namespace
