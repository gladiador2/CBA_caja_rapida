// <fileinfo name="GASTOS_COBRANZASRow.cs">
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
	/// Represents a record in the <c>GASTOS_COBRANZAS</c> table.
	/// </summary>
	public class GASTOS_COBRANZASRow : GASTOS_COBRANZASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GASTOS_COBRANZASRow"/> class.
		/// </summary>
		public GASTOS_COBRANZASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public GASTOS_COBRANZASRow Clonar()
		{
			return (GASTOS_COBRANZASRow)this.MemberwiseClone();
		}
	} // End of GASTOS_COBRANZASRow class
} // End of namespace
