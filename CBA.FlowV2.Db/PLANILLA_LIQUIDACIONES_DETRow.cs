// <fileinfo name="PLANILLA_LIQUIDACIONES_DETRow.cs">
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
	/// Represents a record in the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
	/// </summary>
	public class PLANILLA_LIQUIDACIONES_DETRow : PLANILLA_LIQUIDACIONES_DETRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> class.
		/// </summary>
		public PLANILLA_LIQUIDACIONES_DETRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANILLA_LIQUIDACIONES_DETRow Clonar()
		{
			return (PLANILLA_LIQUIDACIONES_DETRow)this.MemberwiseClone();
		}
	} // End of PLANILLA_LIQUIDACIONES_DETRow class
} // End of namespace
