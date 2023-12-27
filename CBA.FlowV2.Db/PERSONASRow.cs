// <fileinfo name="PERSONASRow.cs">
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
	/// Represents a record in the <c>PERSONAS</c> table.
	/// </summary>
	public class PERSONASRow : PERSONASRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONASRow"/> class.
		/// </summary>
		public PERSONASRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PERSONASRow Clonar()
		{
			return (PERSONASRow)this.MemberwiseClone();
		}
	} // End of PERSONASRow class
} // End of namespace
