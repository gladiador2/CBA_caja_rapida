// <fileinfo name="MENSAJES_SISTEMA_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/> that 
	/// represents a record in the <c>MENSAJES_SISTEMA_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MENSAJES_SISTEMA_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MENSAJES_SISTEMA_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _tipo_mensaje;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _entidad_id;
		private bool _entidad_idNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _rol_id;
		private bool _rol_idNull = true;
		private decimal _usuario_creador_id;
		private string _texto;
		private string _estado;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _usuario_nombre;
		private string _rol_descipcion;
		private string _sucursal_nombre;
		private string _entidad_nombre;
		private decimal _sobre_articulo_id;
		private bool _sobre_articulo_idNull = true;
		private string _sobre_articulo_codigo;
		private decimal _sobre_persona_id;
		private bool _sobre_persona_idNull = true;
		private string _sobre_persona_nombre;
		private decimal _sobre_proveedor_id;
		private bool _sobre_proveedor_idNull = true;
		private string _sobre_proveedor_nombre;
		private decimal _sobre_funcionario_id;
		private bool _sobre_funcionario_idNull = true;
		private string _sobre_funcionario_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="MENSAJES_SISTEMA_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public MENSAJES_SISTEMA_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MENSAJES_SISTEMA_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_MENSAJE != original.TIPO_MENSAJE) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsENTIDAD_IDNull != original.IsENTIDAD_IDNull) return true;
			if (!this.IsENTIDAD_IDNull && !original.IsENTIDAD_IDNull)
				if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsROL_IDNull != original.IsROL_IDNull) return true;
			if (!this.IsROL_IDNull && !original.IsROL_IDNull)
				if (this.ROL_ID != original.ROL_ID) return true;
			if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.ROL_DESCIPCION != original.ROL_DESCIPCION) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.IsSOBRE_ARTICULO_IDNull != original.IsSOBRE_ARTICULO_IDNull) return true;
			if (!this.IsSOBRE_ARTICULO_IDNull && !original.IsSOBRE_ARTICULO_IDNull)
				if (this.SOBRE_ARTICULO_ID != original.SOBRE_ARTICULO_ID) return true;
			if (this.SOBRE_ARTICULO_CODIGO != original.SOBRE_ARTICULO_CODIGO) return true;
			if (this.IsSOBRE_PERSONA_IDNull != original.IsSOBRE_PERSONA_IDNull) return true;
			if (!this.IsSOBRE_PERSONA_IDNull && !original.IsSOBRE_PERSONA_IDNull)
				if (this.SOBRE_PERSONA_ID != original.SOBRE_PERSONA_ID) return true;
			if (this.SOBRE_PERSONA_NOMBRE != original.SOBRE_PERSONA_NOMBRE) return true;
			if (this.IsSOBRE_PROVEEDOR_IDNull != original.IsSOBRE_PROVEEDOR_IDNull) return true;
			if (!this.IsSOBRE_PROVEEDOR_IDNull && !original.IsSOBRE_PROVEEDOR_IDNull)
				if (this.SOBRE_PROVEEDOR_ID != original.SOBRE_PROVEEDOR_ID) return true;
			if (this.SOBRE_PROVEEDOR_NOMBRE != original.SOBRE_PROVEEDOR_NOMBRE) return true;
			if (this.IsSOBRE_FUNCIONARIO_IDNull != original.IsSOBRE_FUNCIONARIO_IDNull) return true;
			if (!this.IsSOBRE_FUNCIONARIO_IDNull && !original.IsSOBRE_FUNCIONARIO_IDNull)
				if (this.SOBRE_FUNCIONARIO_ID != original.SOBRE_FUNCIONARIO_ID) return true;
			if (this.SOBRE_FUNCIONARIO_NOMBRE != original.SOBRE_FUNCIONARIO_NOMBRE) return true;
			
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
		/// Gets or sets the <c>TIPO_MENSAJE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_MENSAJE</c> column value.</value>
		public decimal TIPO_MENSAJE
		{
			get { return _tipo_mensaje; }
			set { _tipo_mensaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get
			{
				if(IsENTIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _entidad_id;
			}
			set
			{
				_entidad_idNull = false;
				_entidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENTIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENTIDAD_IDNull
		{
			get { return _entidad_idNull; }
			set { _entidad_idNull = value; }
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
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get { return _usuario_creador_id; }
			set { _usuario_creador_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
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
		/// Gets or sets the <c>ROL_DESCIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESCIPCION</c> column value.</value>
		public string ROL_DESCIPCION
		{
			get { return _rol_descipcion; }
			set { _rol_descipcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_NOMBRE</c> column value.</value>
		public string ENTIDAD_NOMBRE
		{
			get { return _entidad_nombre; }
			set { _entidad_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_ARTICULO_ID</c> column value.</value>
		public decimal SOBRE_ARTICULO_ID
		{
			get
			{
				if(IsSOBRE_ARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sobre_articulo_id;
			}
			set
			{
				_sobre_articulo_idNull = false;
				_sobre_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SOBRE_ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSOBRE_ARTICULO_IDNull
		{
			get { return _sobre_articulo_idNull; }
			set { _sobre_articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_ARTICULO_CODIGO</c> column value.</value>
		public string SOBRE_ARTICULO_CODIGO
		{
			get { return _sobre_articulo_codigo; }
			set { _sobre_articulo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_PERSONA_ID</c> column value.</value>
		public decimal SOBRE_PERSONA_ID
		{
			get
			{
				if(IsSOBRE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sobre_persona_id;
			}
			set
			{
				_sobre_persona_idNull = false;
				_sobre_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SOBRE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSOBRE_PERSONA_IDNull
		{
			get { return _sobre_persona_idNull; }
			set { _sobre_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_PERSONA_NOMBRE</c> column value.</value>
		public string SOBRE_PERSONA_NOMBRE
		{
			get { return _sobre_persona_nombre; }
			set { _sobre_persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_PROVEEDOR_ID</c> column value.</value>
		public decimal SOBRE_PROVEEDOR_ID
		{
			get
			{
				if(IsSOBRE_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sobre_proveedor_id;
			}
			set
			{
				_sobre_proveedor_idNull = false;
				_sobre_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SOBRE_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSOBRE_PROVEEDOR_IDNull
		{
			get { return _sobre_proveedor_idNull; }
			set { _sobre_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_PROVEEDOR_NOMBRE</c> column value.</value>
		public string SOBRE_PROVEEDOR_NOMBRE
		{
			get { return _sobre_proveedor_nombre; }
			set { _sobre_proveedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_FUNCIONARIO_ID</c> column value.</value>
		public decimal SOBRE_FUNCIONARIO_ID
		{
			get
			{
				if(IsSOBRE_FUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sobre_funcionario_id;
			}
			set
			{
				_sobre_funcionario_idNull = false;
				_sobre_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SOBRE_FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSOBRE_FUNCIONARIO_IDNull
		{
			get { return _sobre_funcionario_idNull; }
			set { _sobre_funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOBRE_FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SOBRE_FUNCIONARIO_NOMBRE</c> column value.</value>
		public string SOBRE_FUNCIONARIO_NOMBRE
		{
			get { return _sobre_funcionario_nombre; }
			set { _sobre_funcionario_nombre = value; }
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
			dynStr.Append("@CBA@TIPO_MENSAJE=");
			dynStr.Append(TIPO_MENSAJE);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(IsENTIDAD_IDNull ? (object)"<NULL>" : ENTIDAD_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(IsROL_IDNull ? (object)"<NULL>" : ROL_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@ROL_DESCIPCION=");
			dynStr.Append(ROL_DESCIPCION);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@SOBRE_ARTICULO_ID=");
			dynStr.Append(IsSOBRE_ARTICULO_IDNull ? (object)"<NULL>" : SOBRE_ARTICULO_ID);
			dynStr.Append("@CBA@SOBRE_ARTICULO_CODIGO=");
			dynStr.Append(SOBRE_ARTICULO_CODIGO);
			dynStr.Append("@CBA@SOBRE_PERSONA_ID=");
			dynStr.Append(IsSOBRE_PERSONA_IDNull ? (object)"<NULL>" : SOBRE_PERSONA_ID);
			dynStr.Append("@CBA@SOBRE_PERSONA_NOMBRE=");
			dynStr.Append(SOBRE_PERSONA_NOMBRE);
			dynStr.Append("@CBA@SOBRE_PROVEEDOR_ID=");
			dynStr.Append(IsSOBRE_PROVEEDOR_IDNull ? (object)"<NULL>" : SOBRE_PROVEEDOR_ID);
			dynStr.Append("@CBA@SOBRE_PROVEEDOR_NOMBRE=");
			dynStr.Append(SOBRE_PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@SOBRE_FUNCIONARIO_ID=");
			dynStr.Append(IsSOBRE_FUNCIONARIO_IDNull ? (object)"<NULL>" : SOBRE_FUNCIONARIO_ID);
			dynStr.Append("@CBA@SOBRE_FUNCIONARIO_NOMBRE=");
			dynStr.Append(SOBRE_FUNCIONARIO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of MENSAJES_SISTEMA_INFO_COMPLRow_Base class
} // End of namespace
