// <fileinfo name="TRANSICIONES_TIPORow_Base.cs">
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
	/// The base class for <see cref="TRANSICIONES_TIPORow"/> that 
	/// represents a record in the <c>TRANSICIONES_TIPO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSICIONES_TIPORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSICIONES_TIPORow_Base
	{
		private string _id;
		private string _descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSICIONES_TIPORow_Base"/> class.
		/// </summary>
		public TRANSICIONES_TIPORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSICIONES_TIPORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of TRANSICIONES_TIPORow_Base class
} // End of namespace
