// <fileinfo name="ART_PROV_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ART_PROV_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ART_PROV_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ART_PROV_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ART_PROV_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private string _articulo_nombre;
		private string _articulo_codigo;
		private decimal _proveedor_id;
		private string _proveedor_razon_social;
		private string _proveedor_codigo;
		private string _codigo;
		private string _descripcion;
		private string _catalogo;
		private string _codigo_barra;
		private string _no_reponer;

		/// <summary>
		/// Initializes a new instance of the <see cref="ART_PROV_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ART_PROV_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ART_PROV_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_NOMBRE != original.ARTICULO_NOMBRE) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.PROVEEDOR_CODIGO != original.PROVEEDOR_CODIGO) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CATALOGO != original.CATALOGO) return true;
			if (this.CODIGO_BARRA != original.CODIGO_BARRA) return true;
			if (this.NO_REPONER != original.NO_REPONER) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_NOMBRE</c> column value.</value>
		public string ARTICULO_NOMBRE
		{
			get { return _articulo_nombre; }
			set { _articulo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO</c> column value.</value>
		public string ARTICULO_CODIGO
		{
			get { return _articulo_codigo; }
			set { _articulo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_RAZON_SOCIAL</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_RAZON_SOCIAL
		{
			get { return _proveedor_razon_social; }
			set { _proveedor_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_CODIGO</c> column value.</value>
		public string PROVEEDOR_CODIGO
		{
			get { return _proveedor_codigo; }
			set { _proveedor_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
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
		/// Gets or sets the <c>CATALOGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CATALOGO</c> column value.</value>
		public string CATALOGO
		{
			get { return _catalogo; }
			set { _catalogo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BARRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_BARRA</c> column value.</value>
		public string CODIGO_BARRA
		{
			get { return _codigo_barra; }
			set { _codigo_barra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NO_REPONER</c> column value.
		/// </summary>
		/// <value>The <c>NO_REPONER</c> column value.</value>
		public string NO_REPONER
		{
			get { return _no_reponer; }
			set { _no_reponer = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_NOMBRE=");
			dynStr.Append(ARTICULO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@PROVEEDOR_CODIGO=");
			dynStr.Append(PROVEEDOR_CODIGO);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CATALOGO=");
			dynStr.Append(CATALOGO);
			dynStr.Append("@CBA@CODIGO_BARRA=");
			dynStr.Append(CODIGO_BARRA);
			dynStr.Append("@CBA@NO_REPONER=");
			dynStr.Append(NO_REPONER);
			return dynStr.ToString();
		}
	} // End of ART_PROV_INFO_COMPLETARow_Base class
} // End of namespace
