// <fileinfo name="LEGAJO_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="LEGAJO_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>LEGAJO_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LEGAJO_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LEGAJO_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private bool _entidad_idNull = true;
		private decimal _entrada_id;
		private string _entrada_nombre;
		private string _entrada_descripcion;
		private decimal _subentrada_id;
		private string _subentrada_nombre;
		private string _subentrada_descripcion;
		private decimal _tipo_detalle_personalizado_id;
		private bool _tipo_detalle_personalizado_idNull = true;
		private System.DateTime _fecha;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_nombre_completo;
		private string _proveedor_desc;
		private string _activo_codigo;
		private string _usuario_desc;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _usuario_creacion_id;
		private bool _usuario_creacion_idNull = true;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private string _observacion;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="LEGAJO_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public LEGAJO_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LEGAJO_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsENTIDAD_IDNull != original.IsENTIDAD_IDNull) return true;
			if (!this.IsENTIDAD_IDNull && !original.IsENTIDAD_IDNull)
				if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ENTRADA_ID != original.ENTRADA_ID) return true;
			if (this.ENTRADA_NOMBRE != original.ENTRADA_NOMBRE) return true;
			if (this.ENTRADA_DESCRIPCION != original.ENTRADA_DESCRIPCION) return true;
			if (this.SUBENTRADA_ID != original.SUBENTRADA_ID) return true;
			if (this.SUBENTRADA_NOMBRE != original.SUBENTRADA_NOMBRE) return true;
			if (this.SUBENTRADA_DESCRIPCION != original.SUBENTRADA_DESCRIPCION) return true;
			if (this.IsTIPO_DETALLE_PERSONALIZADO_IDNull != original.IsTIPO_DETALLE_PERSONALIZADO_IDNull) return true;
			if (!this.IsTIPO_DETALLE_PERSONALIZADO_IDNull && !original.IsTIPO_DETALLE_PERSONALIZADO_IDNull)
				if (this.TIPO_DETALLE_PERSONALIZADO_ID != original.TIPO_DETALLE_PERSONALIZADO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.PROVEEDOR_DESC != original.PROVEEDOR_DESC) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			if (this.USUARIO_DESC != original.USUARIO_DESC) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsUSUARIO_CREACION_IDNull != original.IsUSUARIO_CREACION_IDNull) return true;
			if (!this.IsUSUARIO_CREACION_IDNull && !original.IsUSUARIO_CREACION_IDNull)
				if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
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
		/// Gets or sets the <c>ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTRADA_ID</c> column value.</value>
		public decimal ENTRADA_ID
		{
			get { return _entrada_id; }
			set { _entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTRADA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ENTRADA_NOMBRE</c> column value.</value>
		public string ENTRADA_NOMBRE
		{
			get { return _entrada_nombre; }
			set { _entrada_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTRADA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTRADA_DESCRIPCION</c> column value.</value>
		public string ENTRADA_DESCRIPCION
		{
			get { return _entrada_descripcion; }
			set { _entrada_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUBENTRADA_ID</c> column value.</value>
		public decimal SUBENTRADA_ID
		{
			get { return _subentrada_id; }
			set { _subentrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBENTRADA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUBENTRADA_NOMBRE</c> column value.</value>
		public string SUBENTRADA_NOMBRE
		{
			get { return _subentrada_nombre; }
			set { _subentrada_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBENTRADA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBENTRADA_DESCRIPCION</c> column value.</value>
		public string SUBENTRADA_DESCRIPCION
		{
			get { return _subentrada_descripcion; }
			set { _subentrada_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</value>
		public decimal TIPO_DETALLE_PERSONALIZADO_ID
		{
			get
			{
				if(IsTIPO_DETALLE_PERSONALIZADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_detalle_personalizado_id;
			}
			set
			{
				_tipo_detalle_personalizado_idNull = false;
				_tipo_detalle_personalizado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_DETALLE_PERSONALIZADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_DETALLE_PERSONALIZADO_IDNull
		{
			get { return _tipo_detalle_personalizado_idNull; }
			set { _tipo_detalle_personalizado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_DESC</c> column value.</value>
		public string PROVEEDOR_DESC
		{
			get { return _proveedor_desc; }
			set { _proveedor_desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_CODIGO</c> column value.</value>
		public string ACTIVO_CODIGO
		{
			get { return _activo_codigo; }
			set { _activo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_DESC</c> column value.</value>
		public string USUARIO_DESC
		{
			get { return _usuario_desc; }
			set { _usuario_desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get
			{
				if(IsACTIVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_id;
			}
			set
			{
				_activo_idNull = false;
				_activo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_IDNull
		{
			get { return _activo_idNull; }
			set { _activo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get
			{
				if(IsUSUARIO_CREACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creacion_id;
			}
			set
			{
				_usuario_creacion_idNull = false;
				_usuario_creacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREACION_IDNull
		{
			get { return _usuario_creacion_idNull; }
			set { _usuario_creacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get
			{
				if(IsFECHA_CREACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion;
			}
			set
			{
				_fecha_creacionNull = false;
				_fecha_creacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACIONNull
		{
			get { return _fecha_creacionNull; }
			set { _fecha_creacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(IsENTIDAD_IDNull ? (object)"<NULL>" : ENTIDAD_ID);
			dynStr.Append("@CBA@ENTRADA_ID=");
			dynStr.Append(ENTRADA_ID);
			dynStr.Append("@CBA@ENTRADA_NOMBRE=");
			dynStr.Append(ENTRADA_NOMBRE);
			dynStr.Append("@CBA@ENTRADA_DESCRIPCION=");
			dynStr.Append(ENTRADA_DESCRIPCION);
			dynStr.Append("@CBA@SUBENTRADA_ID=");
			dynStr.Append(SUBENTRADA_ID);
			dynStr.Append("@CBA@SUBENTRADA_NOMBRE=");
			dynStr.Append(SUBENTRADA_NOMBRE);
			dynStr.Append("@CBA@SUBENTRADA_DESCRIPCION=");
			dynStr.Append(SUBENTRADA_DESCRIPCION);
			dynStr.Append("@CBA@TIPO_DETALLE_PERSONALIZADO_ID=");
			dynStr.Append(IsTIPO_DETALLE_PERSONALIZADO_IDNull ? (object)"<NULL>" : TIPO_DETALLE_PERSONALIZADO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PROVEEDOR_DESC=");
			dynStr.Append(PROVEEDOR_DESC);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			dynStr.Append("@CBA@USUARIO_DESC=");
			dynStr.Append(USUARIO_DESC);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(IsUSUARIO_CREACION_IDNull ? (object)"<NULL>" : USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of LEGAJO_INFO_COMPLETARow_Base class
} // End of namespace
