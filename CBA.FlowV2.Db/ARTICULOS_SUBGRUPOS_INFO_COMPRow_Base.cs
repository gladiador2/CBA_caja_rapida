// <fileinfo name="ARTICULOS_SUBGRUPOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_SUBGRUPOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>ARTICULOS_SUBGRUPOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_SUBGRUPOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_SUBGRUPOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _familia_id;
		private string _familia_codigo;
		private string _familia_nombre;
		private decimal _grupo_id;
		private string _grupo_codigo;
		private string _grupo_nombre;
		private string _codigo;
		private string _nombre;
		private string _descripcion;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_SUBGRUPOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public ARTICULOS_SUBGRUPOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_SUBGRUPOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_CODIGO != original.FAMILIA_CODIGO) return true;
			if (this.FAMILIA_NOMBRE != original.FAMILIA_NOMBRE) return true;
			if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_CODIGO != original.GRUPO_CODIGO) return true;
			if (this.GRUPO_NOMBRE != original.GRUPO_NOMBRE) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
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
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get { return _familia_id; }
			set { _familia_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_CODIGO</c> column value.</value>
		public string FAMILIA_CODIGO
		{
			get { return _familia_codigo; }
			set { _familia_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>FAMILIA_NOMBRE</c> column value.</value>
		public string FAMILIA_NOMBRE
		{
			get { return _familia_nombre; }
			set { _familia_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get { return _grupo_id; }
			set { _grupo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_CODIGO</c> column value.</value>
		public string GRUPO_CODIGO
		{
			get { return _grupo_codigo; }
			set { _grupo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>GRUPO_NOMBRE</c> column value.</value>
		public string GRUPO_NOMBRE
		{
			get { return _grupo_nombre; }
			set { _grupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
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
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_CODIGO=");
			dynStr.Append(FAMILIA_CODIGO);
			dynStr.Append("@CBA@FAMILIA_NOMBRE=");
			dynStr.Append(FAMILIA_NOMBRE);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_CODIGO=");
			dynStr.Append(GRUPO_CODIGO);
			dynStr.Append("@CBA@GRUPO_NOMBRE=");
			dynStr.Append(GRUPO_NOMBRE);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_SUBGRUPOS_INFO_COMPRow_Base class
} // End of namespace
