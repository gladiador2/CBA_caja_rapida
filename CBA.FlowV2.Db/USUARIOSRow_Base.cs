// <fileinfo name="USUARIOSRow_Base.cs">
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
	/// The base class for <see cref="USUARIOSRow"/> that 
	/// represents a record in the <c>USUARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _usuario;
		private string _nombre;
		private string _apellido;
		private string _externo;
		private decimal _entidad_id;
		private decimal _sesion;
		private bool _sesionNull = true;
		private System.DateTime _fecha_cambio_pass;
		private bool _fecha_cambio_passNull = true;
		private decimal _vida_pass;
		private System.DateTime _fecha_cadu_pass;
		private System.DateTime _ultimo_login;
		private bool _ultimo_loginNull = true;
		private string _estado;
		private decimal _sucursal_activa_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _supervisor;
		private bool _supervisorNull = true;
		private string _email;
		private string _requerir_cambio_contrasenha;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOSRow_Base"/> class.
		/// </summary>
		public USUARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.APELLIDO != original.APELLIDO) return true;
			if (this.EXTERNO != original.EXTERNO) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsSESIONNull != original.IsSESIONNull) return true;
			if (!this.IsSESIONNull && !original.IsSESIONNull)
				if (this.SESION != original.SESION) return true;
			if (this.IsFECHA_CAMBIO_PASSNull != original.IsFECHA_CAMBIO_PASSNull) return true;
			if (!this.IsFECHA_CAMBIO_PASSNull && !original.IsFECHA_CAMBIO_PASSNull)
				if (this.FECHA_CAMBIO_PASS != original.FECHA_CAMBIO_PASS) return true;
			if (this.VIDA_PASS != original.VIDA_PASS) return true;
			if (this.FECHA_CADU_PASS != original.FECHA_CADU_PASS) return true;
			if (this.IsULTIMO_LOGINNull != original.IsULTIMO_LOGINNull) return true;
			if (!this.IsULTIMO_LOGINNull && !original.IsULTIMO_LOGINNull)
				if (this.ULTIMO_LOGIN != original.ULTIMO_LOGIN) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.SUCURSAL_ACTIVA_ID != original.SUCURSAL_ACTIVA_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsSUPERVISORNull != original.IsSUPERVISORNull) return true;
			if (!this.IsSUPERVISORNull && !original.IsSUPERVISORNull)
				if (this.SUPERVISOR != original.SUPERVISOR) return true;
			if (this.EMAIL != original.EMAIL) return true;
			if (this.REQUERIR_CAMBIO_CONTRASENHA != original.REQUERIR_CAMBIO_CONTRASENHA) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APELLIDO</c> column value.
		/// </summary>
		/// <value>The <c>APELLIDO</c> column value.</value>
		public string APELLIDO
		{
			get { return _apellido; }
			set { _apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXTERNO</c> column value.</value>
		public string EXTERNO
		{
			get { return _externo; }
			set { _externo = value; }
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
		/// Gets or sets the <c>SESION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SESION</c> column value.</value>
		public decimal SESION
		{
			get
			{
				if(IsSESIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sesion;
			}
			set
			{
				_sesionNull = false;
				_sesion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SESION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSESIONNull
		{
			get { return _sesionNull; }
			set { _sesionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CAMBIO_PASS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CAMBIO_PASS</c> column value.</value>
		public System.DateTime FECHA_CAMBIO_PASS
		{
			get
			{
				if(IsFECHA_CAMBIO_PASSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cambio_pass;
			}
			set
			{
				_fecha_cambio_passNull = false;
				_fecha_cambio_pass = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CAMBIO_PASS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CAMBIO_PASSNull
		{
			get { return _fecha_cambio_passNull; }
			set { _fecha_cambio_passNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VIDA_PASS</c> column value.
		/// </summary>
		/// <value>The <c>VIDA_PASS</c> column value.</value>
		public decimal VIDA_PASS
		{
			get { return _vida_pass; }
			set { _vida_pass = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CADU_PASS</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CADU_PASS</c> column value.</value>
		public System.DateTime FECHA_CADU_PASS
		{
			get { return _fecha_cadu_pass; }
			set { _fecha_cadu_pass = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMO_LOGIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMO_LOGIN</c> column value.</value>
		public System.DateTime ULTIMO_LOGIN
		{
			get
			{
				if(IsULTIMO_LOGINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultimo_login;
			}
			set
			{
				_ultimo_loginNull = false;
				_ultimo_login = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMO_LOGIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMO_LOGINNull
		{
			get { return _ultimo_loginNull; }
			set { _ultimo_loginNull = value; }
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
		/// Gets or sets the <c>SUCURSAL_ACTIVA_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ACTIVA_ID</c> column value.</value>
		public decimal SUCURSAL_ACTIVA_ID
		{
			get { return _sucursal_activa_id; }
			set { _sucursal_activa_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUPERVISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUPERVISOR</c> column value.</value>
		public decimal SUPERVISOR
		{
			get
			{
				if(IsSUPERVISORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _supervisor;
			}
			set
			{
				_supervisorNull = false;
				_supervisor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUPERVISOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUPERVISORNull
		{
			get { return _supervisorNull; }
			set { _supervisorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL</c> column value.
		/// </summary>
		/// <value>The <c>EMAIL</c> column value.</value>
		public string EMAIL
		{
			get { return _email; }
			set { _email = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REQUERIR_CAMBIO_CONTRASENHA</c> column value.
		/// </summary>
		/// <value>The <c>REQUERIR_CAMBIO_CONTRASENHA</c> column value.</value>
		public string REQUERIR_CAMBIO_CONTRASENHA
		{
			get { return _requerir_cambio_contrasenha; }
			set { _requerir_cambio_contrasenha = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@APELLIDO=");
			dynStr.Append(APELLIDO);
			dynStr.Append("@CBA@EXTERNO=");
			dynStr.Append(EXTERNO);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@SESION=");
			dynStr.Append(IsSESIONNull ? (object)"<NULL>" : SESION);
			dynStr.Append("@CBA@FECHA_CAMBIO_PASS=");
			dynStr.Append(IsFECHA_CAMBIO_PASSNull ? (object)"<NULL>" : FECHA_CAMBIO_PASS);
			dynStr.Append("@CBA@VIDA_PASS=");
			dynStr.Append(VIDA_PASS);
			dynStr.Append("@CBA@FECHA_CADU_PASS=");
			dynStr.Append(FECHA_CADU_PASS);
			dynStr.Append("@CBA@ULTIMO_LOGIN=");
			dynStr.Append(IsULTIMO_LOGINNull ? (object)"<NULL>" : ULTIMO_LOGIN);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@SUCURSAL_ACTIVA_ID=");
			dynStr.Append(SUCURSAL_ACTIVA_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@SUPERVISOR=");
			dynStr.Append(IsSUPERVISORNull ? (object)"<NULL>" : SUPERVISOR);
			dynStr.Append("@CBA@EMAIL=");
			dynStr.Append(EMAIL);
			dynStr.Append("@CBA@REQUERIR_CAMBIO_CONTRASENHA=");
			dynStr.Append(REQUERIR_CAMBIO_CONTRASENHA);
			return dynStr.ToString();
		}
	} // End of USUARIOSRow_Base class
} // End of namespace
