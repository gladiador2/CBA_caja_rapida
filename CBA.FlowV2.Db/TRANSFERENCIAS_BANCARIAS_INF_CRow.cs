// <fileinfo name="TRANSFERENCIAS_BANCARIAS_INF_CRow.cs">
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
	/// Represents a record in the <c>TRANSFERENCIAS_BANCARIAS_INF_C</c> view.
	/// </summary>
	public class TRANSFERENCIAS_BANCARIAS_INF_CRow : TRANSFERENCIAS_BANCARIAS_INF_CRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> class.
		/// </summary>
		public TRANSFERENCIAS_BANCARIAS_INF_CRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TRANSFERENCIAS_BANCARIAS_INF_CRow Clonar()
		{
			return (TRANSFERENCIAS_BANCARIAS_INF_CRow)this.MemberwiseClone();
		}
	} // End of TRANSFERENCIAS_BANCARIAS_INF_CRow class
} // End of namespace
