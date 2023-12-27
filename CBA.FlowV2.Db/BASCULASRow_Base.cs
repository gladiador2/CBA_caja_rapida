// <fileinfo name="BASCULASRow_Base.cs">
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
	/// The base class for <see cref="BASCULASRow"/> that 
	/// represents a record in the <c>BASCULAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="BASCULASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class BASCULASRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _path_ws;

		/// <summary>
		/// Initializes a new instance of the <see cref="BASCULASRow_Base"/> class.
		/// </summary>
		public BASCULASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(BASCULASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.PATH_WS != original.PATH_WS) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PATH_WS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PATH_WS</c> column value.</value>
		public string PATH_WS
		{
			get { return _path_ws; }
			set { _path_ws = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@PATH_WS=");
			dynStr.Append(PATH_WS);
			return dynStr.ToString();
		}
	} // End of BASCULASRow_Base class
} // End of namespace
