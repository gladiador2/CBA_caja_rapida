// <fileinfo name="HORARIOS_DIASRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="HORARIOS_DIASRow"/> that 
	/// represents a record in the <c>HORARIOS_DIAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="HORARIOS_DIASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_DIASRow_Base
	{
		private decimal _id;
		private decimal _horario_id;
		private decimal _dia_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_DIASRow_Base"/> class.
		/// </summary>
		public HORARIOS_DIASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(HORARIOS_DIASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.HORARIO_ID != original.HORARIO_ID) return true;
			if (this.DIA_ID != original.DIA_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>HORARIO_ID</c> column value.</value>
		public decimal HORARIO_ID
		{
			get { return _horario_id; }
			set { _horario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>DIA_ID</c> column value.</value>
		public decimal DIA_ID
		{
			get { return _dia_id; }
			set { _dia_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@HORARIO_ID=");
			dynStr.Append(HORARIO_ID);
			dynStr.Append("@CBA@DIA_ID=");
			dynStr.Append(DIA_ID);
			return dynStr.ToString();
		}
	} // End of HORARIOS_DIASRow_Base class
} // End of namespace
