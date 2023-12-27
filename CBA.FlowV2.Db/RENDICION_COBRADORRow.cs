// <fileinfo name="RENDICION_COBRADORRow.cs">
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
	/// Represents a record in the <c>RENDICION_COBRADOR</c> table.
	/// </summary>
	public class RENDICION_COBRADORRow : RENDICION_COBRADORRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADORRow"/> class.
		/// </summary>
		public RENDICION_COBRADORRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public RENDICION_COBRADORRow Clonar()
		{
			return (RENDICION_COBRADORRow)this.MemberwiseClone();
		}
	} // End of RENDICION_COBRADORRow class
} // End of namespace
