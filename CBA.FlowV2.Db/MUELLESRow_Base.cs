// <fileinfo name="MUELLESRow_Base.cs">
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
	/// The base class for <see cref="MUELLESRow"/> that 
	/// represents a record in the <c>MUELLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MUELLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MUELLESRow_Base
	{
		private decimal _id;
		private string _nombre_muelle;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="MUELLESRow_Base"/> class.
		/// </summary>
		public MUELLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MUELLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE_MUELLE != original.NOMBRE_MUELLE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>NOMBRE_MUELLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_MUELLE</c> column value.</value>
		public string NOMBRE_MUELLE
		{
			get { return _nombre_muelle; }
			set { _nombre_muelle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append("@CBA@NOMBRE_MUELLE=");
			dynStr.Append(NOMBRE_MUELLE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of MUELLESRow_Base class
} // End of namespace
