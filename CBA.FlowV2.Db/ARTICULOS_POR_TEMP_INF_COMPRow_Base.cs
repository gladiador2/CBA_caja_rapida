// <fileinfo name="ARTICULOS_POR_TEMP_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_POR_TEMP_INF_COMPRow"/> that 
	/// represents a record in the <c>ARTICULOS_POR_TEMP_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_POR_TEMP_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_POR_TEMP_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _temporada_id;
		private string _temporada;
		private decimal _anho;
		private string _nombre_lista;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private string _usuario;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_POR_TEMP_INF_COMPRow_Base"/> class.
		/// </summary>
		public ARTICULOS_POR_TEMP_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_POR_TEMP_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TEMPORADA_ID != original.TEMPORADA_ID) return true;
			if (this.TEMPORADA != original.TEMPORADA) return true;
			if (this.ANHO != original.ANHO) return true;
			if (this.NOMBRE_LISTA != original.NOMBRE_LISTA) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
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
		/// Gets or sets the <c>TEMPORADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEMPORADA_ID</c> column value.</value>
		public decimal TEMPORADA_ID
		{
			get { return _temporada_id; }
			set { _temporada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPORADA</c> column value.
		/// </summary>
		/// <value>The <c>TEMPORADA</c> column value.</value>
		public string TEMPORADA
		{
			get { return _temporada; }
			set { _temporada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public decimal ANHO
		{
			get { return _anho; }
			set { _anho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_LISTA</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_LISTA</c> column value.</value>
		public string NOMBRE_LISTA
		{
			get { return _nombre_lista; }
			set { _nombre_lista = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
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
			dynStr.Append("@CBA@TEMPORADA_ID=");
			dynStr.Append(TEMPORADA_ID);
			dynStr.Append("@CBA@TEMPORADA=");
			dynStr.Append(TEMPORADA);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(ANHO);
			dynStr.Append("@CBA@NOMBRE_LISTA=");
			dynStr.Append(NOMBRE_LISTA);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_POR_TEMP_INF_COMPRow_Base class
} // End of namespace
