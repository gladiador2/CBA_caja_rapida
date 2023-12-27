// <fileinfo name="REGLAS_LOGIN_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="REGLAS_LOGIN_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>REGLAS_LOGIN_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REGLAS_LOGIN_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REGLAS_LOGIN_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _usuario_nombre;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _rol_id;
		private bool _rol_idNull = true;
		private string _ip;
		private string _mascara;
		private string _estado;
		private System.DateTime _fecha_caducidad;
		private bool _fecha_caducidadNull = true;
		private string _aplica_horario_laborable;
		private string _aplica_horario_no_laborable;
		private string _aplica_web;
		private string _aplica_mobile;

		/// <summary>
		/// Initializes a new instance of the <see cref="REGLAS_LOGIN_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public REGLAS_LOGIN_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REGLAS_LOGIN_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsROL_IDNull != original.IsROL_IDNull) return true;
			if (!this.IsROL_IDNull && !original.IsROL_IDNull)
				if (this.ROL_ID != original.ROL_ID) return true;
			if (this.IP != original.IP) return true;
			if (this.MASCARA != original.MASCARA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsFECHA_CADUCIDADNull != original.IsFECHA_CADUCIDADNull) return true;
			if (!this.IsFECHA_CADUCIDADNull && !original.IsFECHA_CADUCIDADNull)
				if (this.FECHA_CADUCIDAD != original.FECHA_CADUCIDAD) return true;
			if (this.APLICA_HORARIO_LABORABLE != original.APLICA_HORARIO_LABORABLE) return true;
			if (this.APLICA_HORARIO_NO_LABORABLE != original.APLICA_HORARIO_NO_LABORABLE) return true;
			if (this.APLICA_WEB != original.APLICA_WEB) return true;
			if (this.APLICA_MOBILE != original.APLICA_MOBILE) return true;
			
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
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
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get
			{
				if(IsROL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_id;
			}
			set
			{
				_rol_idNull = false;
				_rol_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_IDNull
		{
			get { return _rol_idNull; }
			set { _rol_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IP</c> column value.</value>
		public string IP
		{
			get { return _ip; }
			set { _ip = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MASCARA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MASCARA</c> column value.</value>
		public string MASCARA
		{
			get { return _mascara; }
			set { _mascara = value; }
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
		/// Gets or sets the <c>FECHA_CADUCIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CADUCIDAD</c> column value.</value>
		public System.DateTime FECHA_CADUCIDAD
		{
			get
			{
				if(IsFECHA_CADUCIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_caducidad;
			}
			set
			{
				_fecha_caducidadNull = false;
				_fecha_caducidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CADUCIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CADUCIDADNull
		{
			get { return _fecha_caducidadNull; }
			set { _fecha_caducidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICA_HORARIO_LABORABLE</c> column value.
		/// </summary>
		/// <value>The <c>APLICA_HORARIO_LABORABLE</c> column value.</value>
		public string APLICA_HORARIO_LABORABLE
		{
			get { return _aplica_horario_laborable; }
			set { _aplica_horario_laborable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICA_HORARIO_NO_LABORABLE</c> column value.
		/// </summary>
		/// <value>The <c>APLICA_HORARIO_NO_LABORABLE</c> column value.</value>
		public string APLICA_HORARIO_NO_LABORABLE
		{
			get { return _aplica_horario_no_laborable; }
			set { _aplica_horario_no_laborable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICA_WEB</c> column value.
		/// </summary>
		/// <value>The <c>APLICA_WEB</c> column value.</value>
		public string APLICA_WEB
		{
			get { return _aplica_web; }
			set { _aplica_web = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICA_MOBILE</c> column value.
		/// </summary>
		/// <value>The <c>APLICA_MOBILE</c> column value.</value>
		public string APLICA_MOBILE
		{
			get { return _aplica_mobile; }
			set { _aplica_mobile = value; }
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
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(IsROL_IDNull ? (object)"<NULL>" : ROL_ID);
			dynStr.Append("@CBA@IP=");
			dynStr.Append(IP);
			dynStr.Append("@CBA@MASCARA=");
			dynStr.Append(MASCARA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_CADUCIDAD=");
			dynStr.Append(IsFECHA_CADUCIDADNull ? (object)"<NULL>" : FECHA_CADUCIDAD);
			dynStr.Append("@CBA@APLICA_HORARIO_LABORABLE=");
			dynStr.Append(APLICA_HORARIO_LABORABLE);
			dynStr.Append("@CBA@APLICA_HORARIO_NO_LABORABLE=");
			dynStr.Append(APLICA_HORARIO_NO_LABORABLE);
			dynStr.Append("@CBA@APLICA_WEB=");
			dynStr.Append(APLICA_WEB);
			dynStr.Append("@CBA@APLICA_MOBILE=");
			dynStr.Append(APLICA_MOBILE);
			return dynStr.ToString();
		}
	} // End of REGLAS_LOGIN_INFO_COMPLETARow_Base class
} // End of namespace
