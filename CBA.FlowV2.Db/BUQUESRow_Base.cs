// <fileinfo name="BUQUESRow_Base.cs">
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
	/// The base class for <see cref="BUQUESRow"/> that 
	/// represents a record in the <c>BUQUES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="BUQUESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class BUQUESRow_Base
	{
		private decimal _id;
		private string _descripcion;
		private string _empresa;
		private string _maritimo;
		private string _fluvial;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="BUQUESRow_Base"/> class.
		/// </summary>
		public BUQUESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(BUQUESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.EMPRESA != original.EMPRESA) return true;
			if (this.MARITIMO != original.MARITIMO) return true;
			if (this.FLUVIAL != original.FLUVIAL) return true;
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
		/// Gets or sets the <c>EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA</c> column value.</value>
		public string EMPRESA
		{
			get { return _empresa; }
			set { _empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARITIMO</c> column value.
		/// </summary>
		/// <value>The <c>MARITIMO</c> column value.</value>
		public string MARITIMO
		{
			get { return _maritimo; }
			set { _maritimo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUVIAL</c> column value.
		/// </summary>
		/// <value>The <c>FLUVIAL</c> column value.</value>
		public string FLUVIAL
		{
			get { return _fluvial; }
			set { _fluvial = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@EMPRESA=");
			dynStr.Append(EMPRESA);
			dynStr.Append("@CBA@MARITIMO=");
			dynStr.Append(MARITIMO);
			dynStr.Append("@CBA@FLUVIAL=");
			dynStr.Append(FLUVIAL);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of BUQUESRow_Base class
} // End of namespace
