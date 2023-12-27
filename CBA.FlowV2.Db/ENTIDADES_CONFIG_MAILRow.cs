// <fileinfo name="ENTIDADES_CONFIG_MAILRow.cs">
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
	/// Represents a record in the <c>ENTIDADES_CONFIG_MAIL</c> table.
	/// </summary>
	public class ENTIDADES_CONFIG_MAILRow : ENTIDADES_CONFIG_MAILRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ENTIDADES_CONFIG_MAILRow"/> class.
		/// </summary>
		public ENTIDADES_CONFIG_MAILRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ENTIDADES_CONFIG_MAILRow Clonar()
		{
			return (ENTIDADES_CONFIG_MAILRow)this.MemberwiseClone();
		}
	} // End of ENTIDADES_CONFIG_MAILRow class
} // End of namespace
