// <fileinfo name="EDICollection.cs">
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
	/// Represents the <c>EDI</c> table.
	/// </summary>
	public class EDICollection : EDICollection_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EDICollection"/> class.
		/// </summary>
		/// <param name="db">The database object.</param>
		internal EDICollection(CBAV2 db)
				: base(db)
		{
			// EMPTY
		}
	} // End of EDICollection class
} // End of namespace
