// <fileinfo name="ESTADOSRow_Base.cs">
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
	/// The base class for <see cref="ESTADOSRow"/> that 
	/// represents a record in the <c>ESTADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ESTADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ESTADOSRow_Base
	{
		private string _id;
		private string _alias;
		private string _descripcion;
		private string _color_hexadecimal;

		/// <summary>
		/// Initializes a new instance of the <see cref="ESTADOSRow_Base"/> class.
		/// </summary>
		public ESTADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ESTADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ALIAS != original.ALIAS) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.COLOR_HEXADECIMAL != original.COLOR_HEXADECIMAL) return true;
			
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
		/// Gets or sets the <c>ALIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ALIAS</c> column value.</value>
		public string ALIAS
		{
			get { return _alias; }
			set { _alias = value; }
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
		/// Gets or sets the <c>COLOR_HEXADECIMAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLOR_HEXADECIMAL</c> column value.</value>
		public string COLOR_HEXADECIMAL
		{
			get { return _color_hexadecimal; }
			set { _color_hexadecimal = value; }
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
			dynStr.Append("@CBA@ALIAS=");
			dynStr.Append(ALIAS);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@COLOR_HEXADECIMAL=");
			dynStr.Append(COLOR_HEXADECIMAL);
			return dynStr.ToString();
		}
	} // End of ESTADOSRow_Base class
} // End of namespace
