// <fileinfo name="FICHAS_MEDICARow.cs">
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
	/// Represents a record in the <c>FICHAS_MEDICA</c> table.
	/// </summary>
	public class FICHAS_MEDICARow : FICHAS_MEDICARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FICHAS_MEDICARow"/> class.
		/// </summary>
		public FICHAS_MEDICARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public FICHAS_MEDICARow Clonar()
		{
			return (FICHAS_MEDICARow)this.MemberwiseClone();
		}
	} // End of FICHAS_MEDICARow class
} // End of namespace
