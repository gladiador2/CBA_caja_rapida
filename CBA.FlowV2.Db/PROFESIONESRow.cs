// <fileinfo name="PROFESIONESRow.cs">
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
	/// Represents a record in the <c>PROFESIONES</c> table.
	/// </summary>
	public class PROFESIONESRow : PROFESIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PROFESIONESRow"/> class.
		/// </summary>
		public PROFESIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PROFESIONESRow Clonar()
		{
			return (PROFESIONESRow)this.MemberwiseClone();
		}
	} // End of PROFESIONESRow class
} // End of namespace
