// <fileinfo name="PLANILLA_PAGOSRow.cs">
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
	/// Represents a record in the <c>PLANILLA_PAGOS</c> table.
	/// </summary>
	public class PLANILLA_PAGOSRow : PLANILLA_PAGOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGOSRow"/> class.
		/// </summary>
		public PLANILLA_PAGOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANILLA_PAGOSRow Clonar()
		{
			return (PLANILLA_PAGOSRow)this.MemberwiseClone();
		}
	} // End of PLANILLA_PAGOSRow class
} // End of namespace
