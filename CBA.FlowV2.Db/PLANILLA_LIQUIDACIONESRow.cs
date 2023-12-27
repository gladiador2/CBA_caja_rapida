// <fileinfo name="PLANILLA_LIQUIDACIONESRow.cs">
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
	/// Represents a record in the <c>PLANILLA_LIQUIDACIONES</c> table.
	/// </summary>
	public class PLANILLA_LIQUIDACIONESRow : PLANILLA_LIQUIDACIONESRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_LIQUIDACIONESRow"/> class.
		/// </summary>
		public PLANILLA_LIQUIDACIONESRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public PLANILLA_LIQUIDACIONESRow Clonar()
		{
			return (PLANILLA_LIQUIDACIONESRow)this.MemberwiseClone();
		}
	} // End of PLANILLA_LIQUIDACIONESRow class
} // End of namespace
