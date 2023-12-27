// <fileinfo name="REGIMEN_COMISIONESRow.cs">
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
	/// Represents a record in the <c>REGIMEN_COMISIONES</c> table.
	/// </summary>
	public class REGIMEN_COMISIONESRow : REGIMEN_COMISIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="REGIMEN_COMISIONESRow"/> class.
		/// </summary>
		public REGIMEN_COMISIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public REGIMEN_COMISIONESRow Clonar()
		{
			return (REGIMEN_COMISIONESRow)this.MemberwiseClone();
		}
	} // End of REGIMEN_COMISIONESRow class
} // End of namespace
