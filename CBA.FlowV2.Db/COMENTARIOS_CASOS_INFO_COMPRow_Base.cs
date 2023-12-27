// <fileinfo name="COMENTARIOS_CASOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="COMENTARIOS_CASOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>COMENTARIOS_CASOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="COMENTARIOS_CASOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COMENTARIOS_CASOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _tabla_id;
		private decimal _tabla_registro_id;
		private bool _tabla_registro_idNull = true;
		private decimal _usuario_id;
		private string _usuario_nombre;
		private System.DateTime _fecha;
		private string _es_privado;
		private string _observacion;
		private decimal _usuario_borrado_id;
		private bool _usuario_borrado_idNull = true;
		private System.DateTime _fecha_borrado;
		private bool _fecha_borradoNull = true;
		private string _estado;
		private string _recordatorio;
		private string _adjunto_nombre_archivo;

		/// <summary>
		/// Initializes a new instance of the <see cref="COMENTARIOS_CASOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public COMENTARIOS_CASOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(COMENTARIOS_CASOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.IsTABLA_REGISTRO_IDNull != original.IsTABLA_REGISTRO_IDNull) return true;
			if (!this.IsTABLA_REGISTRO_IDNull && !original.IsTABLA_REGISTRO_IDNull)
				if (this.TABLA_REGISTRO_ID != original.TABLA_REGISTRO_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.ES_PRIVADO != original.ES_PRIVADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsUSUARIO_BORRADO_IDNull != original.IsUSUARIO_BORRADO_IDNull) return true;
			if (!this.IsUSUARIO_BORRADO_IDNull && !original.IsUSUARIO_BORRADO_IDNull)
				if (this.USUARIO_BORRADO_ID != original.USUARIO_BORRADO_ID) return true;
			if (this.IsFECHA_BORRADONull != original.IsFECHA_BORRADONull) return true;
			if (!this.IsFECHA_BORRADONull && !original.IsFECHA_BORRADONull)
				if (this.FECHA_BORRADO != original.FECHA_BORRADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.RECORDATORIO != original.RECORDATORIO) return true;
			if (this.ADJUNTO_NOMBRE_ARCHIVO != original.ADJUNTO_NOMBRE_ARCHIVO) return true;
			
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
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_REGISTRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_REGISTRO_ID</c> column value.</value>
		public decimal TABLA_REGISTRO_ID
		{
			get
			{
				if(IsTABLA_REGISTRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tabla_registro_id;
			}
			set
			{
				_tabla_registro_idNull = false;
				_tabla_registro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TABLA_REGISTRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTABLA_REGISTRO_IDNull
		{
			get { return _tabla_registro_idNull; }
			set { _tabla_registro_idNull = value; }
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
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE</c> column value.</value>
		public string USUARIO_NOMBRE
		{
			get { return _usuario_nombre; }
			set { _usuario_nombre = value; }
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
		/// Gets or sets the <c>ES_PRIVADO</c> column value.
		/// </summary>
		/// <value>The <c>ES_PRIVADO</c> column value.</value>
		public string ES_PRIVADO
		{
			get { return _es_privado; }
			set { _es_privado = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECORDATORIO</c> column value.
		/// </summary>
		/// <value>The <c>RECORDATORIO</c> column value.</value>
		public string RECORDATORIO
		{
			get { return _recordatorio; }
			set { _recordatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ADJUNTO_NOMBRE_ARCHIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ADJUNTO_NOMBRE_ARCHIVO</c> column value.</value>
		public string ADJUNTO_NOMBRE_ARCHIVO
		{
			get { return _adjunto_nombre_archivo; }
			set { _adjunto_nombre_archivo = value; }
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
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@TABLA_REGISTRO_ID=");
			dynStr.Append(IsTABLA_REGISTRO_IDNull ? (object)"<NULL>" : TABLA_REGISTRO_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@ES_PRIVADO=");
			dynStr.Append(ES_PRIVADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@USUARIO_BORRADO_ID=");
			dynStr.Append(IsUSUARIO_BORRADO_IDNull ? (object)"<NULL>" : USUARIO_BORRADO_ID);
			dynStr.Append("@CBA@FECHA_BORRADO=");
			dynStr.Append(IsFECHA_BORRADONull ? (object)"<NULL>" : FECHA_BORRADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@RECORDATORIO=");
			dynStr.Append(RECORDATORIO);
			dynStr.Append("@CBA@ADJUNTO_NOMBRE_ARCHIVO=");
			dynStr.Append(ADJUNTO_NOMBRE_ARCHIVO);
			return dynStr.ToString();
		}
	} // End of COMENTARIOS_CASOS_INFO_COMPRow_Base class
} // End of namespace
