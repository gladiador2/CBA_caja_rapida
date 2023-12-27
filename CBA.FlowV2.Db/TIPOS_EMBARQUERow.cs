// <fileinfo name="TIPOS_EMBARQUERow.cs">
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
	/// Represents a record in the <c>TIPOS_EMBARQUE</c> table.
	/// </summary>
	public class TIPOS_EMBARQUERow : TIPOS_EMBARQUERow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_EMBARQUERow"/> class.
		/// </summary>
		public TIPOS_EMBARQUERow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TIPOS_EMBARQUERow Clonar()
		{
			return (TIPOS_EMBARQUERow)this.MemberwiseClone();
		}
	} // End of TIPOS_EMBARQUERow class
} // End of namespace
