// <fileinfo name="MARCACIONES_ENTRADAS_SALIDASRow.cs">
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
	/// Represents a record in the <c>MARCACIONES_ENTRADAS_SALIDAS</c> view.
	/// </summary>
	public class MARCACIONES_ENTRADAS_SALIDASRow : MARCACIONES_ENTRADAS_SALIDASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MARCACIONES_ENTRADAS_SALIDASRow"/> class.
		/// </summary>
		public MARCACIONES_ENTRADAS_SALIDASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public MARCACIONES_ENTRADAS_SALIDASRow Clonar()
		{
			return (MARCACIONES_ENTRADAS_SALIDASRow)this.MemberwiseClone();
		}
	} // End of MARCACIONES_ENTRADAS_SALIDASRow class
} // End of namespace
