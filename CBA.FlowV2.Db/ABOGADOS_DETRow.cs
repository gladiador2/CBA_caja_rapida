// <fileinfo name="ABOGADOS_DETRow.cs">
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
	/// Represents a record in the <c>ABOGADOS_DET</c> table.
	/// </summary>
	public class ABOGADOS_DETRow : ABOGADOS_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ABOGADOS_DETRow"/> class.
		/// </summary>
		public ABOGADOS_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ABOGADOS_DETRow Clonar()
		{
			return (ABOGADOS_DETRow)this.MemberwiseClone();
		}
	} // End of ABOGADOS_DETRow class
} // End of namespace
