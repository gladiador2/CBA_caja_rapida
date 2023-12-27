// <fileinfo name="USUARIOS_DETALLERow_Base.cs">
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
	/// The base class for <see cref="USUARIOS_DETALLERow"/> that 
	/// represents a record in the <c>USUARIOS_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOS_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_DETALLERow_Base
	{
		private decimal _id;
		private decimal _usuario_id;
		private string _codigo_verificacion;
		private System.DateTime _fecha_envio;
		private System.DateTime _fecha_caducidad;
		private System.DateTime _fecha_uso;
		private bool _fecha_usoNull = true;
		private string _validacion_correcta;
		private string _ip_solicitud_contrasena;
		private string _ip_validacion_usuario;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_DETALLERow_Base"/> class.
		/// </summary>
		public USUARIOS_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOS_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.CODIGO_VERIFICACION != original.CODIGO_VERIFICACION) return true;
			if (this.FECHA_ENVIO != original.FECHA_ENVIO) return true;
			if (this.FECHA_CADUCIDAD != original.FECHA_CADUCIDAD) return true;
			if (this.IsFECHA_USONull != original.IsFECHA_USONull) return true;
			if (!this.IsFECHA_USONull && !original.IsFECHA_USONull)
				if (this.FECHA_USO != original.FECHA_USO) return true;
			if (this.VALIDACION_CORRECTA != original.VALIDACION_CORRECTA) return true;
			if (this.IP_SOLICITUD_CONTRASENA != original.IP_SOLICITUD_CONTRASENA) return true;
			if (this.IP_VALIDACION_USUARIO != original.IP_VALIDACION_USUARIO) return true;
			
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_VERIFICACION</c> column value.
		/// </summary>
		/// <value>The <c>CODIGO_VERIFICACION</c> column value.</value>
		public string CODIGO_VERIFICACION
		{
			get { return _codigo_verificacion; }
			set { _codigo_verificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENVIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ENVIO</c> column value.</value>
		public System.DateTime FECHA_ENVIO
		{
			get { return _fecha_envio; }
			set { _fecha_envio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CADUCIDAD</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CADUCIDAD</c> column value.</value>
		public System.DateTime FECHA_CADUCIDAD
		{
			get { return _fecha_caducidad; }
			set { _fecha_caducidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_USO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_USO</c> column value.</value>
		public System.DateTime FECHA_USO
		{
			get
			{
				if(IsFECHA_USONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_uso;
			}
			set
			{
				_fecha_usoNull = false;
				_fecha_uso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_USO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_USONull
		{
			get { return _fecha_usoNull; }
			set { _fecha_usoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALIDACION_CORRECTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALIDACION_CORRECTA</c> column value.</value>
		public string VALIDACION_CORRECTA
		{
			get { return _validacion_correcta; }
			set { _validacion_correcta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IP_SOLICITUD_CONTRASENA</c> column value.
		/// </summary>
		/// <value>The <c>IP_SOLICITUD_CONTRASENA</c> column value.</value>
		public string IP_SOLICITUD_CONTRASENA
		{
			get { return _ip_solicitud_contrasena; }
			set { _ip_solicitud_contrasena = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IP_VALIDACION_USUARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IP_VALIDACION_USUARIO</c> column value.</value>
		public string IP_VALIDACION_USUARIO
		{
			get { return _ip_validacion_usuario; }
			set { _ip_validacion_usuario = value; }
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
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@CODIGO_VERIFICACION=");
			dynStr.Append(CODIGO_VERIFICACION);
			dynStr.Append("@CBA@FECHA_ENVIO=");
			dynStr.Append(FECHA_ENVIO);
			dynStr.Append("@CBA@FECHA_CADUCIDAD=");
			dynStr.Append(FECHA_CADUCIDAD);
			dynStr.Append("@CBA@FECHA_USO=");
			dynStr.Append(IsFECHA_USONull ? (object)"<NULL>" : FECHA_USO);
			dynStr.Append("@CBA@VALIDACION_CORRECTA=");
			dynStr.Append(VALIDACION_CORRECTA);
			dynStr.Append("@CBA@IP_SOLICITUD_CONTRASENA=");
			dynStr.Append(IP_SOLICITUD_CONTRASENA);
			dynStr.Append("@CBA@IP_VALIDACION_USUARIO=");
			dynStr.Append(IP_VALIDACION_USUARIO);
			return dynStr.ToString();
		}
	} // End of USUARIOS_DETALLERow_Base class
} // End of namespace
