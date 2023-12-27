// <fileinfo name="EMPRESA_FAJASRow.cs">
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
	/// Represents a record in the <c>EMPRESA_FAJAS</c> table.
	/// </summary>
	public class EMPRESA_FAJASRow : EMPRESA_FAJASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_FAJASRow"/> class.
		/// </summary>
		public EMPRESA_FAJASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public EMPRESA_FAJASRow Clonar()
		{
			return (EMPRESA_FAJASRow)this.MemberwiseClone();
		}
	} // End of EMPRESA_FAJASRow class
} // End of namespace
