// <fileinfo name="TRATAMIENTOSRow.cs">
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
	/// Represents a record in the <c>TRATAMIENTOS</c> table.
	/// </summary>
	public class TRATAMIENTOSRow : TRATAMIENTOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRATAMIENTOSRow"/> class.
		/// </summary>
		public TRATAMIENTOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRATAMIENTOSRow Clonar()
		{
			return (TRATAMIENTOSRow)this.MemberwiseClone();
		}
	} // End of TRATAMIENTOSRow class
} // End of namespace
