// <fileinfo name="INSPECCIONES_OBSERVACIONESRow.cs">
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
	/// Represents a record in the <c>INSPECCIONES_OBSERVACIONES</c> table.
	/// </summary>
	public class INSPECCIONES_OBSERVACIONESRow : INSPECCIONES_OBSERVACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="INSPECCIONES_OBSERVACIONESRow"/> class.
		/// </summary>
		public INSPECCIONES_OBSERVACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public INSPECCIONES_OBSERVACIONESRow Clonar()
		{
			return (INSPECCIONES_OBSERVACIONESRow)this.MemberwiseClone();
		}
	} // End of INSPECCIONES_OBSERVACIONESRow class
} // End of namespace
