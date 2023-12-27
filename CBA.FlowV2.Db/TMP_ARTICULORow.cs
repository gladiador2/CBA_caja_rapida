// <fileinfo name="TMP_ARTICULORow.cs">
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
	/// Represents a record in the <c>TMP_ARTICULO</c> table.
	/// </summary>
	public class TMP_ARTICULORow : TMP_ARTICULORow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_ARTICULORow"/> class.
		/// </summary>
		public TMP_ARTICULORow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public TMP_ARTICULORow Clonar()
		{
			return (TMP_ARTICULORow)this.MemberwiseClone();
		}
	} // End of TMP_ARTICULORow class
} // End of namespace
