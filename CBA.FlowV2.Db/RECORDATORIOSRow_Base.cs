// <fileinfo name="RECORDATORIOSRow_Base.cs">
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
	/// The base class for <see cref="RECORDATORIOSRow"/> that 
	/// represents a record in the <c>RECORDATORIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RECORDATORIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECORDATORIOSRow_Base
	{
		private decimal _id;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_creacion;
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
		private System.DateTime _fecha_recordatorio;
		private string _usuarios_recordatorio;
		private string _mail_recordatorio;
		private string _estado;
		private string _tipo;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECORDATORIOSRow_Base"/> class.
		/// </summary>
		public RECORDATORIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RECORDATORIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
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
			if (this.REGISTRO != original.REGISTRO) return true;
			if (this.FECHA_RECORDATORIO != original.FECHA_RECORDATORIO) return true;
			if (this.USUARIOS_RECORDATORIO != original.USUARIOS_RECORDATORIO) return true;
			if (this.MAIL_RECORDATORIO != original.MAIL_RECORDATORIO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO != original.TIPO) return true;
			
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
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
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
		/// </summary>
		/// <value>The <c>REGISTRO</c> column value.</value>
		public decimal REGISTRO
		{
			get { return _registro; }
			set { _registro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECORDATORIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_RECORDATORIO</c> column value.</value>
		public System.DateTime FECHA_RECORDATORIO
		{
			get { return _fecha_recordatorio; }
			set { _fecha_recordatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIOS_RECORDATORIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIOS_RECORDATORIO</c> column value.</value>
		public string USUARIOS_RECORDATORIO
		{
			get { return _usuarios_recordatorio; }
			set { _usuarios_recordatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MAIL_RECORDATORIO</c> column value.
		/// </summary>
		/// <value>The <c>MAIL_RECORDATORIO</c> column value.</value>
		public string MAIL_RECORDATORIO
		{
			get { return _mail_recordatorio; }
			set { _mail_recordatorio = value; }
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
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public string TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
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
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
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
			dynStr.Append(REGISTRO);
			dynStr.Append("@CBA@FECHA_RECORDATORIO=");
			dynStr.Append(FECHA_RECORDATORIO);
			dynStr.Append("@CBA@USUARIOS_RECORDATORIO=");
			dynStr.Append(USUARIOS_RECORDATORIO);
			dynStr.Append("@CBA@MAIL_RECORDATORIO=");
			dynStr.Append(MAIL_RECORDATORIO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			return dynStr.ToString();
		}
	} // End of RECORDATORIOSRow_Base class
} // End of namespace
