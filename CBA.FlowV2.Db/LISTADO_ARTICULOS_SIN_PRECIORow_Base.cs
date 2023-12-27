// <fileinfo name="LISTADO_ARTICULOS_SIN_PRECIORow_Base.cs">
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
	/// The base class for <see cref="LISTADO_ARTICULOS_SIN_PRECIORow"/> that 
	/// represents a record in the <c>LISTADO_ARTICULOS_SIN_PRECIO</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LISTADO_ARTICULOS_SIN_PRECIORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LISTADO_ARTICULOS_SIN_PRECIORow_Base
	{
		private object _id;
		private object _entidad_id;
		private object _codigo_empresa;
		private object _familia_id;
		private object _familia_descripcion;
		private object _grupo_id;
		private object _grupo_descripcion;
		private object _subgrupo_id;
		private object _subgrupo_descripcion;
		private object _descripcion_a_utilizar;
		private object _problema;

		/// <summary>
		/// Initializes a new instance of the <see cref="LISTADO_ARTICULOS_SIN_PRECIORow_Base"/> class.
		/// </summary>
		public LISTADO_ARTICULOS_SIN_PRECIORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LISTADO_ARTICULOS_SIN_PRECIORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.CODIGO_EMPRESA != original.CODIGO_EMPRESA) return true;
			if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			if (this.DESCRIPCION_A_UTILIZAR != original.DESCRIPCION_A_UTILIZAR) return true;
			if (this.PROBLEMA != original.PROBLEMA) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public object ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public object ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EMPRESA</c> column value.</value>
		public object CODIGO_EMPRESA
		{
			get { return _codigo_empresa; }
			set { _codigo_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public object FAMILIA_ID
		{
			get { return _familia_id; }
			set { _familia_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_DESCRIPCION</c> column value.</value>
		public object FAMILIA_DESCRIPCION
		{
			get { return _familia_descripcion; }
			set { _familia_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public object GRUPO_ID
		{
			get { return _grupo_id; }
			set { _grupo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_DESCRIPCION</c> column value.</value>
		public object GRUPO_DESCRIPCION
		{
			get { return _grupo_descripcion; }
			set { _grupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public object SUBGRUPO_ID
		{
			get { return _subgrupo_id; }
			set { _subgrupo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_DESCRIPCION</c> column value.</value>
		public object SUBGRUPO_DESCRIPCION
		{
			get { return _subgrupo_descripcion; }
			set { _subgrupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_A_UTILIZAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_A_UTILIZAR</c> column value.</value>
		public object DESCRIPCION_A_UTILIZAR
		{
			get { return _descripcion_a_utilizar; }
			set { _descripcion_a_utilizar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROBLEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROBLEMA</c> column value.</value>
		public object PROBLEMA
		{
			get { return _problema; }
			set { _problema = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@CODIGO_EMPRESA=");
			dynStr.Append(CODIGO_EMPRESA);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(SUBGRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@DESCRIPCION_A_UTILIZAR=");
			dynStr.Append(DESCRIPCION_A_UTILIZAR);
			dynStr.Append("@CBA@PROBLEMA=");
			dynStr.Append(PROBLEMA);
			return dynStr.ToString();
		}
	} // End of LISTADO_ARTICULOS_SIN_PRECIORow_Base class
} // End of namespace
