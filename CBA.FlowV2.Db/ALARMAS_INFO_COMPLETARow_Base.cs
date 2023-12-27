// <fileinfo name="ALARMAS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ALARMAS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ALARMAS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ALARMAS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ALARMAS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _tipo_alarma_id;
		private string _nombre;
		private string _descripcion;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _usuario;
		private string _usuario_nombre;
		private string _usuario_apellido;
		private decimal _rol_id;
		private bool _rol_idNull = true;
		private string _rol_descripcion;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_descripcion;
		private string _flujo_estado_id;
		private decimal _log_campo_id;
		private bool _log_campo_idNull = true;
		private string _log_campo_tabla_id;
		private string _log_campo_campo_id;
		private decimal _tipo_dato;
		private bool _tipo_datoNull = true;
		private string _valor_inferior;
		private string _valor_superior;
		private decimal _tipo_rango;
		private bool _tipo_rangoNull = true;
		private string _mail;
		private string _estado;
		private string _existencia_mayor_cero;
		private decimal _tipo_envio_para_usuario;
		private bool _tipo_envio_para_usuarioNull = true;
		private string _resumido;
		private string _sql;

		/// <summary>
		/// Initializes a new instance of the <see cref="ALARMAS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ALARMAS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ALARMAS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.TIPO_ALARMA_ID != original.TIPO_ALARMA_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.USUARIO_APELLIDO != original.USUARIO_APELLIDO) return true;
			if (this.IsROL_IDNull != original.IsROL_IDNull) return true;
			if (!this.IsROL_IDNull && !original.IsROL_IDNull)
				if (this.ROL_ID != original.ROL_ID) return true;
			if (this.ROL_DESCRIPCION != original.ROL_DESCRIPCION) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.FLUJO_ESTADO_ID != original.FLUJO_ESTADO_ID) return true;
			if (this.IsLOG_CAMPO_IDNull != original.IsLOG_CAMPO_IDNull) return true;
			if (!this.IsLOG_CAMPO_IDNull && !original.IsLOG_CAMPO_IDNull)
				if (this.LOG_CAMPO_ID != original.LOG_CAMPO_ID) return true;
			if (this.LOG_CAMPO_TABLA_ID != original.LOG_CAMPO_TABLA_ID) return true;
			if (this.LOG_CAMPO_CAMPO_ID != original.LOG_CAMPO_CAMPO_ID) return true;
			if (this.IsTIPO_DATONull != original.IsTIPO_DATONull) return true;
			if (!this.IsTIPO_DATONull && !original.IsTIPO_DATONull)
				if (this.TIPO_DATO != original.TIPO_DATO) return true;
			if (this.VALOR_INFERIOR != original.VALOR_INFERIOR) return true;
			if (this.VALOR_SUPERIOR != original.VALOR_SUPERIOR) return true;
			if (this.IsTIPO_RANGONull != original.IsTIPO_RANGONull) return true;
			if (!this.IsTIPO_RANGONull && !original.IsTIPO_RANGONull)
				if (this.TIPO_RANGO != original.TIPO_RANGO) return true;
			if (this.MAIL != original.MAIL) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.EXISTENCIA_MAYOR_CERO != original.EXISTENCIA_MAYOR_CERO) return true;
			if (this.IsTIPO_ENVIO_PARA_USUARIONull != original.IsTIPO_ENVIO_PARA_USUARIONull) return true;
			if (!this.IsTIPO_ENVIO_PARA_USUARIONull && !original.IsTIPO_ENVIO_PARA_USUARIONull)
				if (this.TIPO_ENVIO_PARA_USUARIO != original.TIPO_ENVIO_PARA_USUARIO) return true;
			if (this.RESUMIDO != original.RESUMIDO) return true;
			if (this.SQL != original.SQL) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ALARMA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ALARMA_ID</c> column value.</value>
		public decimal TIPO_ALARMA_ID
		{
			get { return _tipo_alarma_id; }
			set { _tipo_alarma_id = value; }
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
		/// Gets or sets the <c>USUARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
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
		/// Gets or sets the <c>USUARIO_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APELLIDO</c> column value.</value>
		public string USUARIO_APELLIDO
		{
			get { return _usuario_apellido; }
			set { _usuario_apellido = value; }
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
		/// Gets or sets the <c>ROL_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESCRIPCION</c> column value.</value>
		public string ROL_DESCRIPCION
		{
			get { return _rol_descripcion; }
			set { _rol_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ESTADO_ID</c> column value.</value>
		public string FLUJO_ESTADO_ID
		{
			get { return _flujo_estado_id; }
			set { _flujo_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOG_CAMPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOG_CAMPO_ID</c> column value.</value>
		public decimal LOG_CAMPO_ID
		{
			get
			{
				if(IsLOG_CAMPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _log_campo_id;
			}
			set
			{
				_log_campo_idNull = false;
				_log_campo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOG_CAMPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOG_CAMPO_IDNull
		{
			get { return _log_campo_idNull; }
			set { _log_campo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOG_CAMPO_TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOG_CAMPO_TABLA_ID</c> column value.</value>
		public string LOG_CAMPO_TABLA_ID
		{
			get { return _log_campo_tabla_id; }
			set { _log_campo_tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOG_CAMPO_CAMPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOG_CAMPO_CAMPO_ID</c> column value.</value>
		public string LOG_CAMPO_CAMPO_ID
		{
			get { return _log_campo_campo_id; }
			set { _log_campo_campo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DATO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DATO</c> column value.</value>
		public decimal TIPO_DATO
		{
			get
			{
				if(IsTIPO_DATONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_dato;
			}
			set
			{
				_tipo_datoNull = false;
				_tipo_dato = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_DATO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_DATONull
		{
			get { return _tipo_datoNull; }
			set { _tipo_datoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_INFERIOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_INFERIOR</c> column value.</value>
		public string VALOR_INFERIOR
		{
			get { return _valor_inferior; }
			set { _valor_inferior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_SUPERIOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_SUPERIOR</c> column value.</value>
		public string VALOR_SUPERIOR
		{
			get { return _valor_superior; }
			set { _valor_superior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_RANGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_RANGO</c> column value.</value>
		public decimal TIPO_RANGO
		{
			get
			{
				if(IsTIPO_RANGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_rango;
			}
			set
			{
				_tipo_rangoNull = false;
				_tipo_rango = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_RANGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_RANGONull
		{
			get { return _tipo_rangoNull; }
			set { _tipo_rangoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MAIL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MAIL</c> column value.</value>
		public string MAIL
		{
			get { return _mail; }
			set { _mail = value; }
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
		/// Gets or sets the <c>EXISTENCIA_MAYOR_CERO</c> column value.
		/// </summary>
		/// <value>The <c>EXISTENCIA_MAYOR_CERO</c> column value.</value>
		public string EXISTENCIA_MAYOR_CERO
		{
			get { return _existencia_mayor_cero; }
			set { _existencia_mayor_cero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ENVIO_PARA_USUARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_ENVIO_PARA_USUARIO</c> column value.</value>
		public decimal TIPO_ENVIO_PARA_USUARIO
		{
			get
			{
				if(IsTIPO_ENVIO_PARA_USUARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_envio_para_usuario;
			}
			set
			{
				_tipo_envio_para_usuarioNull = false;
				_tipo_envio_para_usuario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_ENVIO_PARA_USUARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_ENVIO_PARA_USUARIONull
		{
			get { return _tipo_envio_para_usuarioNull; }
			set { _tipo_envio_para_usuarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESUMIDO</c> column value.
		/// </summary>
		/// <value>The <c>RESUMIDO</c> column value.</value>
		public string RESUMIDO
		{
			get { return _resumido; }
			set { _resumido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SQL</c> column value.</value>
		public string SQL
		{
			get { return _sql; }
			set { _sql = value; }
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
			dynStr.Append("@CBA@TIPO_ALARMA_ID=");
			dynStr.Append(TIPO_ALARMA_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@USUARIO_APELLIDO=");
			dynStr.Append(USUARIO_APELLIDO);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(IsROL_IDNull ? (object)"<NULL>" : ROL_ID);
			dynStr.Append("@CBA@ROL_DESCRIPCION=");
			dynStr.Append(ROL_DESCRIPCION);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@FLUJO_ESTADO_ID=");
			dynStr.Append(FLUJO_ESTADO_ID);
			dynStr.Append("@CBA@LOG_CAMPO_ID=");
			dynStr.Append(IsLOG_CAMPO_IDNull ? (object)"<NULL>" : LOG_CAMPO_ID);
			dynStr.Append("@CBA@LOG_CAMPO_TABLA_ID=");
			dynStr.Append(LOG_CAMPO_TABLA_ID);
			dynStr.Append("@CBA@LOG_CAMPO_CAMPO_ID=");
			dynStr.Append(LOG_CAMPO_CAMPO_ID);
			dynStr.Append("@CBA@TIPO_DATO=");
			dynStr.Append(IsTIPO_DATONull ? (object)"<NULL>" : TIPO_DATO);
			dynStr.Append("@CBA@VALOR_INFERIOR=");
			dynStr.Append(VALOR_INFERIOR);
			dynStr.Append("@CBA@VALOR_SUPERIOR=");
			dynStr.Append(VALOR_SUPERIOR);
			dynStr.Append("@CBA@TIPO_RANGO=");
			dynStr.Append(IsTIPO_RANGONull ? (object)"<NULL>" : TIPO_RANGO);
			dynStr.Append("@CBA@MAIL=");
			dynStr.Append(MAIL);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@EXISTENCIA_MAYOR_CERO=");
			dynStr.Append(EXISTENCIA_MAYOR_CERO);
			dynStr.Append("@CBA@TIPO_ENVIO_PARA_USUARIO=");
			dynStr.Append(IsTIPO_ENVIO_PARA_USUARIONull ? (object)"<NULL>" : TIPO_ENVIO_PARA_USUARIO);
			dynStr.Append("@CBA@RESUMIDO=");
			dynStr.Append(RESUMIDO);
			dynStr.Append("@CBA@SQL=");
			dynStr.Append(SQL);
			return dynStr.ToString();
		}
	} // End of ALARMAS_INFO_COMPLETARow_Base class
} // End of namespace
