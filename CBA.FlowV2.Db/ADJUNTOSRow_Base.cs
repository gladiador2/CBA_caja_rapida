// <fileinfo name="ADJUNTOSRow_Base.cs">
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
	/// The base class for <see cref="ADJUNTOSRow"/> that 
	/// represents a record in the <c>ADJUNTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ADJUNTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ADJUNTOSRow_Base
	{
		private decimal _id;
		private string _nombre_archivo;
		private string _descripcion;
		private string _extension;
		private string _tipo_mime;
		private decimal _usuario_id;
		private System.DateTime _fecha;
		private decimal _usuario_ultima_edicion_id;
		private bool _usuario_ultima_edicion_idNull = true;
		private System.DateTime _fecha_ultima_edicion;
		private bool _fecha_ultima_edicionNull = true;
		private decimal _usuario_borrado_id;
		private bool _usuario_borrado_idNull = true;
		private System.DateTime _fecha_borrado;
		private bool _fecha_borradoNull = true;
		private string _motivo_borrado;
		private string _tabla_id;
		private decimal _registro;
		private bool _registroNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _tipo_adjunto_id;
		private string _tipo_privacidad;
		private string _estado;
		private string _clio_uuid;
		private string _grupo;
		private string _principal;
		private string _path_temporal;

		/// <summary>
		/// Initializes a new instance of the <see cref="ADJUNTOSRow_Base"/> class.
		/// </summary>
		public ADJUNTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ADJUNTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE_ARCHIVO != original.NOMBRE_ARCHIVO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.EXTENSION != original.EXTENSION) return true;
			if (this.TIPO_MIME != original.TIPO_MIME) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsUSUARIO_ULTIMA_EDICION_IDNull != original.IsUSUARIO_ULTIMA_EDICION_IDNull) return true;
			if (!this.IsUSUARIO_ULTIMA_EDICION_IDNull && !original.IsUSUARIO_ULTIMA_EDICION_IDNull)
				if (this.USUARIO_ULTIMA_EDICION_ID != original.USUARIO_ULTIMA_EDICION_ID) return true;
			if (this.IsFECHA_ULTIMA_EDICIONNull != original.IsFECHA_ULTIMA_EDICIONNull) return true;
			if (!this.IsFECHA_ULTIMA_EDICIONNull && !original.IsFECHA_ULTIMA_EDICIONNull)
				if (this.FECHA_ULTIMA_EDICION != original.FECHA_ULTIMA_EDICION) return true;
			if (this.IsUSUARIO_BORRADO_IDNull != original.IsUSUARIO_BORRADO_IDNull) return true;
			if (!this.IsUSUARIO_BORRADO_IDNull && !original.IsUSUARIO_BORRADO_IDNull)
				if (this.USUARIO_BORRADO_ID != original.USUARIO_BORRADO_ID) return true;
			if (this.IsFECHA_BORRADONull != original.IsFECHA_BORRADONull) return true;
			if (!this.IsFECHA_BORRADONull && !original.IsFECHA_BORRADONull)
				if (this.FECHA_BORRADO != original.FECHA_BORRADO) return true;
			if (this.MOTIVO_BORRADO != original.MOTIVO_BORRADO) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.IsREGISTRONull != original.IsREGISTRONull) return true;
			if (!this.IsREGISTRONull && !original.IsREGISTRONull)
				if (this.REGISTRO != original.REGISTRO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.TIPO_ADJUNTO_ID != original.TIPO_ADJUNTO_ID) return true;
			if (this.TIPO_PRIVACIDAD != original.TIPO_PRIVACIDAD) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CLIO_UUID != original.CLIO_UUID) return true;
			if (this.GRUPO != original.GRUPO) return true;
			if (this.PRINCIPAL != original.PRINCIPAL) return true;
			if (this.PATH_TEMPORAL != original.PATH_TEMPORAL) return true;
			
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
		/// Gets or sets the <c>NOMBRE_ARCHIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_ARCHIVO</c> column value.</value>
		public string NOMBRE_ARCHIVO
		{
			get { return _nombre_archivo; }
			set { _nombre_archivo = value; }
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
		/// Gets or sets the <c>EXTENSION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXTENSION</c> column value.</value>
		public string EXTENSION
		{
			get { return _extension; }
			set { _extension = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MIME</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_MIME</c> column value.</value>
		public string TIPO_MIME
		{
			get { return _tipo_mime; }
			set { _tipo_mime = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ULTIMA_EDICION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</value>
		public decimal USUARIO_ULTIMA_EDICION_ID
		{
			get
			{
				if(IsUSUARIO_ULTIMA_EDICION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_ultima_edicion_id;
			}
			set
			{
				_usuario_ultima_edicion_idNull = false;
				_usuario_ultima_edicion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ULTIMA_EDICION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ULTIMA_EDICION_IDNull
		{
			get { return _usuario_ultima_edicion_idNull; }
			set { _usuario_ultima_edicion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMA_EDICION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMA_EDICION</c> column value.</value>
		public System.DateTime FECHA_ULTIMA_EDICION
		{
			get
			{
				if(IsFECHA_ULTIMA_EDICIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultima_edicion;
			}
			set
			{
				_fecha_ultima_edicionNull = false;
				_fecha_ultima_edicion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMA_EDICION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMA_EDICIONNull
		{
			get { return _fecha_ultima_edicionNull; }
			set { _fecha_ultima_edicionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_BORRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_BORRADO_ID</c> column value.</value>
		public decimal USUARIO_BORRADO_ID
		{
			get
			{
				if(IsUSUARIO_BORRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_borrado_id;
			}
			set
			{
				_usuario_borrado_idNull = false;
				_usuario_borrado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_BORRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_BORRADO_IDNull
		{
			get { return _usuario_borrado_idNull; }
			set { _usuario_borrado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_BORRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_BORRADO</c> column value.</value>
		public System.DateTime FECHA_BORRADO
		{
			get
			{
				if(IsFECHA_BORRADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_borrado;
			}
			set
			{
				_fecha_borradoNull = false;
				_fecha_borrado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_BORRADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_BORRADONull
		{
			get { return _fecha_borradoNull; }
			set { _fecha_borradoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_BORRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_BORRADO</c> column value.</value>
		public string MOTIVO_BORRADO
		{
			get { return _motivo_borrado; }
			set { _motivo_borrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGISTRO</c> column value.</value>
		public decimal REGISTRO
		{
			get
			{
				if(IsREGISTRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _registro;
			}
			set
			{
				_registroNull = false;
				_registro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGISTRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGISTRONull
		{
			get { return _registroNull; }
			set { _registroNull = value; }
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
		/// Gets or sets the <c>TIPO_ADJUNTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ADJUNTO_ID</c> column value.</value>
		public decimal TIPO_ADJUNTO_ID
		{
			get { return _tipo_adjunto_id; }
			set { _tipo_adjunto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_PRIVACIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_PRIVACIDAD</c> column value.</value>
		public string TIPO_PRIVACIDAD
		{
			get { return _tipo_privacidad; }
			set { _tipo_privacidad = value; }
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
		/// Gets or sets the <c>CLIO_UUID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIO_UUID</c> column value.</value>
		public string CLIO_UUID
		{
			get { return _clio_uuid; }
			set { _clio_uuid = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO</c> column value.</value>
		public string GRUPO
		{
			get { return _grupo; }
			set { _grupo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRINCIPAL</c> column value.
		/// </summary>
		/// <value>The <c>PRINCIPAL</c> column value.</value>
		public string PRINCIPAL
		{
			get { return _principal; }
			set { _principal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PATH_TEMPORAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PATH_TEMPORAL</c> column value.</value>
		public string PATH_TEMPORAL
		{
			get { return _path_temporal; }
			set { _path_temporal = value; }
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
			dynStr.Append("@CBA@NOMBRE_ARCHIVO=");
			dynStr.Append(NOMBRE_ARCHIVO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@EXTENSION=");
			dynStr.Append(EXTENSION);
			dynStr.Append("@CBA@TIPO_MIME=");
			dynStr.Append(TIPO_MIME);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@USUARIO_ULTIMA_EDICION_ID=");
			dynStr.Append(IsUSUARIO_ULTIMA_EDICION_IDNull ? (object)"<NULL>" : USUARIO_ULTIMA_EDICION_ID);
			dynStr.Append("@CBA@FECHA_ULTIMA_EDICION=");
			dynStr.Append(IsFECHA_ULTIMA_EDICIONNull ? (object)"<NULL>" : FECHA_ULTIMA_EDICION);
			dynStr.Append("@CBA@USUARIO_BORRADO_ID=");
			dynStr.Append(IsUSUARIO_BORRADO_IDNull ? (object)"<NULL>" : USUARIO_BORRADO_ID);
			dynStr.Append("@CBA@FECHA_BORRADO=");
			dynStr.Append(IsFECHA_BORRADONull ? (object)"<NULL>" : FECHA_BORRADO);
			dynStr.Append("@CBA@MOTIVO_BORRADO=");
			dynStr.Append(MOTIVO_BORRADO);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@REGISTRO=");
			dynStr.Append(IsREGISTRONull ? (object)"<NULL>" : REGISTRO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@TIPO_ADJUNTO_ID=");
			dynStr.Append(TIPO_ADJUNTO_ID);
			dynStr.Append("@CBA@TIPO_PRIVACIDAD=");
			dynStr.Append(TIPO_PRIVACIDAD);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CLIO_UUID=");
			dynStr.Append(CLIO_UUID);
			dynStr.Append("@CBA@GRUPO=");
			dynStr.Append(GRUPO);
			dynStr.Append("@CBA@PRINCIPAL=");
			dynStr.Append(PRINCIPAL);
			dynStr.Append("@CBA@PATH_TEMPORAL=");
			dynStr.Append(PATH_TEMPORAL);
			return dynStr.ToString();
		}
	} // End of ADJUNTOSRow_Base class
} // End of namespace
