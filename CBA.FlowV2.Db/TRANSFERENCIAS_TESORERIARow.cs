// <fileinfo name="TRANSFERENCIAS_TESORERIARow.cs">
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
	/// Represents a record in the <c>TRANSFERENCIAS_TESORERIA</c> table.
	/// </summary>
	public class TRANSFERENCIAS_TESORERIARow : TRANSFERENCIAS_TESORERIARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_TESORERIARow"/> class.
		/// </summary>
		public TRANSFERENCIAS_TESORERIARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRANSFERENCIAS_TESORERIARow Clonar()
		{
			return (TRANSFERENCIAS_TESORERIARow)this.MemberwiseClone();
		}
	} // End of TRANSFERENCIAS_TESORERIARow class
} // End of namespace
