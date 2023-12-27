// <fileinfo name="PAISESRow_Base.cs">
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
	/// The base class for <see cref="PAISESRow"/> that 
	/// represents a record in the <c>PAISES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PAISESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PAISESRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _abreviatura;
		private string _gentilicio;
		private string _iso_3166_1;
		private decimal _moneda_id;
		private string _codigo_tel;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="PAISESRow_Base"/> class.
		/// </summary>
		public PAISESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PAISESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.GENTILICIO != original.GENTILICIO) return true;
			if (this.ISO_3166_1 != original.ISO_3166_1) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.CODIGO_TEL != original.CODIGO_TEL) return true;
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENTILICIO</c> column value.
		/// </summary>
		/// <value>The <c>GENTILICIO</c> column value.</value>
		public string GENTILICIO
		{
			get { return _gentilicio; }
			set { _gentilicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ISO_3166_1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ISO_3166_1</c> column value.</value>
		public string ISO_3166_1
		{
			get { return _iso_3166_1; }
			set { _iso_3166_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_TEL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_TEL</c> column value.</value>
		public string CODIGO_TEL
		{
			get { return _codigo_tel; }
			set { _codigo_tel = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@GENTILICIO=");
			dynStr.Append(GENTILICIO);
			dynStr.Append("@CBA@ISO_3166_1=");
			dynStr.Append(ISO_3166_1);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@CODIGO_TEL=");
			dynStr.Append(CODIGO_TEL);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of PAISESRow_Base class
} // End of namespace
