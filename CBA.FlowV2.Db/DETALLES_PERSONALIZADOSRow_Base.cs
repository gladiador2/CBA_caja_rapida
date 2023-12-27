// <fileinfo name="DETALLES_PERSONALIZADOSRow_Base.cs">
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
	/// The base class for <see cref="DETALLES_PERSONALIZADOSRow"/> that 
	/// represents a record in the <c>DETALLES_PERSONALIZADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DETALLES_PERSONALIZADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DETALLES_PERSONALIZADOSRow_Base
	{
		private decimal _id;
		private decimal _tipo_detalle_personalizado_id;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_borrado_id;
		private bool _usuario_borrado_idNull = true;
		private System.DateTime _fecha_borrado;
		private bool _fecha_borradoNull = true;
		private string _estado;
		private string _tabla_id;
		private string _columna;
		private string _registro_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOSRow_Base"/> class.
		/// </summary>
		public DETALLES_PERSONALIZADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DETALLES_PERSONALIZADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_DETALLE_PERSONALIZADO_ID != original.TIPO_DETALLE_PERSONALIZADO_ID) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_BORRADO_IDNull != original.IsUSUARIO_BORRADO_IDNull) return true;
			if (!this.IsUSUARIO_BORRADO_IDNull && !original.IsUSUARIO_BORRADO_IDNull)
				if (this.USUARIO_BORRADO_ID != original.USUARIO_BORRADO_ID) return true;
			if (this.IsFECHA_BORRADONull != original.IsFECHA_BORRADONull) return true;
			if (!this.IsFECHA_BORRADONull && !original.IsFECHA_BORRADONull)
				if (this.FECHA_BORRADO != original.FECHA_BORRADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.COLUMNA != original.COLUMNA) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			
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
		/// Gets or sets the <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</value>
		public decimal TIPO_DETALLE_PERSONALIZADO_ID
		{
			get { return _tipo_detalle_personalizado_id; }
			set { _tipo_detalle_personalizado_id = value; }
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
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLUMNA</c> column value.
		/// </summary>
		/// <value>The <c>COLUMNA</c> column value.</value>
		public string COLUMNA
		{
			get { return _columna; }
			set { _columna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public string REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
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
			dynStr.Append("@CBA@TIPO_DETALLE_PERSONALIZADO_ID=");
			dynStr.Append(TIPO_DETALLE_PERSONALIZADO_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_BORRADO_ID=");
			dynStr.Append(IsUSUARIO_BORRADO_IDNull ? (object)"<NULL>" : USUARIO_BORRADO_ID);
			dynStr.Append("@CBA@FECHA_BORRADO=");
			dynStr.Append(IsFECHA_BORRADONull ? (object)"<NULL>" : FECHA_BORRADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@COLUMNA=");
			dynStr.Append(COLUMNA);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			return dynStr.ToString();
		}
	} // End of DETALLES_PERSONALIZADOSRow_Base class
} // End of namespace
