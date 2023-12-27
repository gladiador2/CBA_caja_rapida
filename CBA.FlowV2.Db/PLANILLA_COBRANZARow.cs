// <fileinfo name="PLANILLA_COBRANZARow.cs">
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
	/// Represents a record in the <c>PLANILLA_COBRANZA</c> table.
	/// </summary>
	public class PLANILLA_COBRANZARow : PLANILLA_COBRANZARow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBRANZARow"/> class.
		/// </summary>
		public PLANILLA_COBRANZARow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANILLA_COBRANZARow Clonar()
		{
			return (PLANILLA_COBRANZARow)this.MemberwiseClone();
		}
	} // End of PLANILLA_COBRANZARow class
} // End of namespace
