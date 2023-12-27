// <fileinfo name="WEBSERVICESRow.cs">
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
	/// Represents a record in the <c>WEBSERVICES</c> table.
	/// </summary>
	public class WEBSERVICESRow : WEBSERVICESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WEBSERVICESRow"/> class.
		/// </summary>
		public WEBSERVICESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public WEBSERVICESRow Clonar()
		{
			return (WEBSERVICESRow)this.MemberwiseClone();
		}
	} // End of WEBSERVICESRow class
} // End of namespace
