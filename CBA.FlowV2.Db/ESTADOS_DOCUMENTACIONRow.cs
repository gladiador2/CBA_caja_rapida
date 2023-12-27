// <fileinfo name="ESTADOS_DOCUMENTACIONRow.cs">
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
	/// Represents a record in the <c>ESTADOS_DOCUMENTACION</c> table.
	/// </summary>
	public class ESTADOS_DOCUMENTACIONRow : ESTADOS_DOCUMENTACIONRow_Base
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ESTADOS_DOCUMENTACIONRow"/> class.
		/// </summary>
		public ESTADOS_DOCUMENTACIONRow()
		{
			// EMPTY
		}
		
		/// <summary>
		/// Clone the object with MemberwiseClone
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public ESTADOS_DOCUMENTACIONRow Clonar()
		{
			return (ESTADOS_DOCUMENTACIONRow)this.MemberwiseClone();
		}
	} // End of ESTADOS_DOCUMENTACIONRow class
} // End of namespace
