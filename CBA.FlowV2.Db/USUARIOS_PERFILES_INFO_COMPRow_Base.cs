// <fileinfo name="USUARIOS_PERFILES_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="USUARIOS_PERFILES_INFO_COMPRow"/> that 
	/// represents a record in the <c>USUARIOS_PERFILES_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOS_PERFILES_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_PERFILES_INFO_COMPRow_Base
	{
		private decimal _usuario_id;
		private string _usuario_nombre;
		private decimal _perfil_id;
		private string _perfil_descripcion;
		private string _perfil_estado;
		private decimal _entidad_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_PERFILES_INFO_COMPRow_Base"/> class.
		/// </summary>
		public USUARIOS_PERFILES_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOS_PERFILES_INFO_COMPRow_Base original)
		{
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.PERFIL_ID != original.PERFIL_ID) return true;
			if (this.PERFIL_DESCRIPCION != original.PERFIL_DESCRIPCION) return true;
			if (this.PERFIL_ESTADO != original.PERFIL_ESTADO) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE</c> column value.</value>
		public string USUARIO_NOMBRE
		{
			get { return _usuario_nombre; }
			set { _usuario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERFIL_ID</c> column value.</value>
		public decimal PERFIL_ID
		{
			get { return _perfil_id; }
			set { _perfil_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERFIL_DESCRIPCION</c> column value.</value>
		public string PERFIL_DESCRIPCION
		{
			get { return _perfil_descripcion; }
			set { _perfil_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERFIL_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERFIL_ESTADO</c> column value.</value>
		public string PERFIL_ESTADO
		{
			get { return _perfil_estado; }
			set { _perfil_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@PERFIL_ID=");
			dynStr.Append(PERFIL_ID);
			dynStr.Append("@CBA@PERFIL_DESCRIPCION=");
			dynStr.Append(PERFIL_DESCRIPCION);
			dynStr.Append("@CBA@PERFIL_ESTADO=");
			dynStr.Append(PERFIL_ESTADO);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			return dynStr.ToString();
		}
	} // End of USUARIOS_PERFILES_INFO_COMPRow_Base class
} // End of namespace
