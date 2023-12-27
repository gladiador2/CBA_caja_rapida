// <fileinfo name="CTB_EJERCICIOSRow.cs">
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
	/// Represents a record in the <c>CTB_EJERCICIOS</c> table.
	/// </summary>
	public class CTB_EJERCICIOSRow : CTB_EJERCICIOSRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_EJERCICIOSRow"/> class.
		/// </summary>
		public CTB_EJERCICIOSRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public CTB_EJERCICIOSRow Clonar()
		{
			return (CTB_EJERCICIOSRow)this.MemberwiseClone();
		}
	} // End of CTB_EJERCICIOSRow class
} // End of namespace
