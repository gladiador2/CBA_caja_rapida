// <fileinfo name="ENTIDADES_CONFIG_MAILRow_Base.cs">
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
	/// The base class for <see cref="ENTIDADES_CONFIG_MAILRow"/> that 
	/// represents a record in the <c>ENTIDADES_CONFIG_MAIL</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENTIDADES_CONFIG_MAILRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENTIDADES_CONFIG_MAILRow_Base
	{
		private decimal _id;
		private string _servidor_smtp;
		private string _nombre_usuario;
		private string _contrasena;
		private string _estado;
		private decimal _entidad_id;
		private decimal _puerto;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENTIDADES_CONFIG_MAILRow_Base"/> class.
		/// </summary>
		public ENTIDADES_CONFIG_MAILRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENTIDADES_CONFIG_MAILRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SERVIDOR_SMTP != original.SERVIDOR_SMTP) return true;
			if (this.NOMBRE_USUARIO != original.NOMBRE_USUARIO) return true;
			if (this.CONTRASENA != original.CONTRASENA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.PUERTO != original.PUERTO) return true;
			
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
		/// Gets or sets the <c>SERVIDOR_SMTP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SERVIDOR_SMTP</c> column value.</value>
		public string SERVIDOR_SMTP
		{
			get { return _servidor_smtp; }
			set { _servidor_smtp = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_USUARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_USUARIO</c> column value.</value>
		public string NOMBRE_USUARIO
		{
			get { return _nombre_usuario; }
			set { _nombre_usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTRASENA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTRASENA</c> column value.</value>
		public string CONTRASENA
		{
			get { return _contrasena; }
			set { _contrasena = value; }
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO</c> column value.
		/// </summary>
		/// <value>The <c>PUERTO</c> column value.</value>
		public decimal PUERTO
		{
			get { return _puerto; }
			set { _puerto = value; }
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
			dynStr.Append("@CBA@SERVIDOR_SMTP=");
			dynStr.Append(SERVIDOR_SMTP);
			dynStr.Append("@CBA@NOMBRE_USUARIO=");
			dynStr.Append(NOMBRE_USUARIO);
			dynStr.Append("@CBA@CONTRASENA=");
			dynStr.Append(CONTRASENA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@PUERTO=");
			dynStr.Append(PUERTO);
			return dynStr.ToString();
		}
	} // End of ENTIDADES_CONFIG_MAILRow_Base class
} // End of namespace
