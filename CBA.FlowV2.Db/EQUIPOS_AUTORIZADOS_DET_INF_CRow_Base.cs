// <fileinfo name="EQUIPOS_AUTORIZADOS_DET_INF_CRow_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> that 
	/// represents a record in the <c>EQUIPOS_AUTORIZADOS_DET_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOS_DET_INF_CRow_Base
	{
		private decimal _id;
		private decimal _equipos_autorizados_id;
		private decimal _puertas_movimiento_id;
		private bool _puertas_movimiento_idNull = true;
		private string _tipo;
		private decimal _conocimiento_detalle_id;
		private bool _conocimiento_detalle_idNull = true;
		private decimal _conocimiento_contenido_id;
		private bool _conocimiento_contenido_idNull = true;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private string _contenedor_numero;
		private string _booking_bl;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private System.DateTime _fecha_devolucion;
		private bool _fecha_devolucionNull = true;
		private decimal _puerto_devolucion_id;
		private bool _puerto_devolucion_idNull = true;
		private string _retirado;
		private string _nro_comprobante;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _puerto_devolucion_nombre;
		private string _contenedor_linea;
		private string _contenedor_tipo;
		private string _contenedor_clase;
		private string _contenedor_estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow_Base"/> class.
		/// </summary>
		public EQUIPOS_AUTORIZADOS_DET_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EQUIPOS_AUTORIZADOS_DET_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.EQUIPOS_AUTORIZADOS_ID != original.EQUIPOS_AUTORIZADOS_ID) return true;
			if (this.IsPUERTAS_MOVIMIENTO_IDNull != original.IsPUERTAS_MOVIMIENTO_IDNull) return true;
			if (!this.IsPUERTAS_MOVIMIENTO_IDNull && !original.IsPUERTAS_MOVIMIENTO_IDNull)
				if (this.PUERTAS_MOVIMIENTO_ID != original.PUERTAS_MOVIMIENTO_ID) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.IsCONOCIMIENTO_DETALLE_IDNull != original.IsCONOCIMIENTO_DETALLE_IDNull) return true;
			if (!this.IsCONOCIMIENTO_DETALLE_IDNull && !original.IsCONOCIMIENTO_DETALLE_IDNull)
				if (this.CONOCIMIENTO_DETALLE_ID != original.CONOCIMIENTO_DETALLE_ID) return true;
			if (this.IsCONOCIMIENTO_CONTENIDO_IDNull != original.IsCONOCIMIENTO_CONTENIDO_IDNull) return true;
			if (!this.IsCONOCIMIENTO_CONTENIDO_IDNull && !original.IsCONOCIMIENTO_CONTENIDO_IDNull)
				if (this.CONOCIMIENTO_CONTENIDO_ID != original.CONOCIMIENTO_CONTENIDO_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.BOOKING_BL != original.BOOKING_BL) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_DEVOLUCIONNull != original.IsFECHA_DEVOLUCIONNull) return true;
			if (!this.IsFECHA_DEVOLUCIONNull && !original.IsFECHA_DEVOLUCIONNull)
				if (this.FECHA_DEVOLUCION != original.FECHA_DEVOLUCION) return true;
			if (this.IsPUERTO_DEVOLUCION_IDNull != original.IsPUERTO_DEVOLUCION_IDNull) return true;
			if (!this.IsPUERTO_DEVOLUCION_IDNull && !original.IsPUERTO_DEVOLUCION_IDNull)
				if (this.PUERTO_DEVOLUCION_ID != original.PUERTO_DEVOLUCION_ID) return true;
			if (this.RETIRADO != original.RETIRADO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.PUERTO_DEVOLUCION_NOMBRE != original.PUERTO_DEVOLUCION_NOMBRE) return true;
			if (this.CONTENEDOR_LINEA != original.CONTENEDOR_LINEA) return true;
			if (this.CONTENEDOR_TIPO != original.CONTENEDOR_TIPO) return true;
			if (this.CONTENEDOR_CLASE != original.CONTENEDOR_CLASE) return true;
			if (this.CONTENEDOR_ESTADO != original.CONTENEDOR_ESTADO) return true;
			
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
		/// Gets or sets the <c>EQUIPOS_AUTORIZADOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>EQUIPOS_AUTORIZADOS_ID</c> column value.</value>
		public decimal EQUIPOS_AUTORIZADOS_ID
		{
			get { return _equipos_autorizados_id; }
			set { _equipos_autorizados_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTAS_MOVIMIENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTAS_MOVIMIENTO_ID</c> column value.</value>
		public decimal PUERTAS_MOVIMIENTO_ID
		{
			get
			{
				if(IsPUERTAS_MOVIMIENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puertas_movimiento_id;
			}
			set
			{
				_puertas_movimiento_idNull = false;
				_puertas_movimiento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTAS_MOVIMIENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTAS_MOVIMIENTO_IDNull
		{
			get { return _puertas_movimiento_idNull; }
			set { _puertas_movimiento_idNull = value; }
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
		/// Gets or sets the <c>CONOCIMIENTO_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</value>
		public decimal CONOCIMIENTO_DETALLE_ID
		{
			get
			{
				if(IsCONOCIMIENTO_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conocimiento_detalle_id;
			}
			set
			{
				_conocimiento_detalle_idNull = false;
				_conocimiento_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONOCIMIENTO_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONOCIMIENTO_DETALLE_IDNull
		{
			get { return _conocimiento_detalle_idNull; }
			set { _conocimiento_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO_CONTENIDO_ID</c> column value.</value>
		public decimal CONOCIMIENTO_CONTENIDO_ID
		{
			get
			{
				if(IsCONOCIMIENTO_CONTENIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conocimiento_contenido_id;
			}
			set
			{
				_conocimiento_contenido_idNull = false;
				_conocimiento_contenido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONOCIMIENTO_CONTENIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONOCIMIENTO_CONTENIDO_IDNull
		{
			get { return _conocimiento_contenido_idNull; }
			set { _conocimiento_contenido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ID</c> column value.</value>
		public decimal CONTENEDOR_ID
		{
			get
			{
				if(IsCONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _contenedor_id;
			}
			set
			{
				_contenedor_idNull = false;
				_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTENEDOR_IDNull
		{
			get { return _contenedor_idNull; }
			set { _contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_NUMERO</c> column value.</value>
		public string CONTENEDOR_NUMERO
		{
			get { return _contenedor_numero; }
			set { _contenedor_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BOOKING_BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BOOKING_BL</c> column value.</value>
		public string BOOKING_BL
		{
			get { return _booking_bl; }
			set { _booking_bl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DEVOLUCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DEVOLUCION</c> column value.</value>
		public System.DateTime FECHA_DEVOLUCION
		{
			get
			{
				if(IsFECHA_DEVOLUCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_devolucion;
			}
			set
			{
				_fecha_devolucionNull = false;
				_fecha_devolucion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DEVOLUCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DEVOLUCIONNull
		{
			get { return _fecha_devolucionNull; }
			set { _fecha_devolucionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_DEVOLUCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_DEVOLUCION_ID</c> column value.</value>
		public decimal PUERTO_DEVOLUCION_ID
		{
			get
			{
				if(IsPUERTO_DEVOLUCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerto_devolucion_id;
			}
			set
			{
				_puerto_devolucion_idNull = false;
				_puerto_devolucion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTO_DEVOLUCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTO_DEVOLUCION_IDNull
		{
			get { return _puerto_devolucion_idNull; }
			set { _puerto_devolucion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETIRADO</c> column value.
		/// </summary>
		/// <value>The <c>RETIRADO</c> column value.</value>
		public string RETIRADO
		{
			get { return _retirado; }
			set { _retirado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_DEVOLUCION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_DEVOLUCION_NOMBRE</c> column value.</value>
		public string PUERTO_DEVOLUCION_NOMBRE
		{
			get { return _puerto_devolucion_nombre; }
			set { _puerto_devolucion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_LINEA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_LINEA</c> column value.</value>
		public string CONTENEDOR_LINEA
		{
			get { return _contenedor_linea; }
			set { _contenedor_linea = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_TIPO</c> column value.</value>
		public string CONTENEDOR_TIPO
		{
			get { return _contenedor_tipo; }
			set { _contenedor_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_CLASE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_CLASE</c> column value.</value>
		public string CONTENEDOR_CLASE
		{
			get { return _contenedor_clase; }
			set { _contenedor_clase = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ESTADO</c> column value.</value>
		public string CONTENEDOR_ESTADO
		{
			get { return _contenedor_estado; }
			set { _contenedor_estado = value; }
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
			dynStr.Append("@CBA@EQUIPOS_AUTORIZADOS_ID=");
			dynStr.Append(EQUIPOS_AUTORIZADOS_ID);
			dynStr.Append("@CBA@PUERTAS_MOVIMIENTO_ID=");
			dynStr.Append(IsPUERTAS_MOVIMIENTO_IDNull ? (object)"<NULL>" : PUERTAS_MOVIMIENTO_ID);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@CONOCIMIENTO_DETALLE_ID=");
			dynStr.Append(IsCONOCIMIENTO_DETALLE_IDNull ? (object)"<NULL>" : CONOCIMIENTO_DETALLE_ID);
			dynStr.Append("@CBA@CONOCIMIENTO_CONTENIDO_ID=");
			dynStr.Append(IsCONOCIMIENTO_CONTENIDO_IDNull ? (object)"<NULL>" : CONOCIMIENTO_CONTENIDO_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@BOOKING_BL=");
			dynStr.Append(BOOKING_BL);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_DEVOLUCION=");
			dynStr.Append(IsFECHA_DEVOLUCIONNull ? (object)"<NULL>" : FECHA_DEVOLUCION);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_ID=");
			dynStr.Append(IsPUERTO_DEVOLUCION_IDNull ? (object)"<NULL>" : PUERTO_DEVOLUCION_ID);
			dynStr.Append("@CBA@RETIRADO=");
			dynStr.Append(RETIRADO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_NOMBRE=");
			dynStr.Append(PUERTO_DEVOLUCION_NOMBRE);
			dynStr.Append("@CBA@CONTENEDOR_LINEA=");
			dynStr.Append(CONTENEDOR_LINEA);
			dynStr.Append("@CBA@CONTENEDOR_TIPO=");
			dynStr.Append(CONTENEDOR_TIPO);
			dynStr.Append("@CBA@CONTENEDOR_CLASE=");
			dynStr.Append(CONTENEDOR_CLASE);
			dynStr.Append("@CBA@CONTENEDOR_ESTADO=");
			dynStr.Append(CONTENEDOR_ESTADO);
			return dynStr.ToString();
		}
	} // End of EQUIPOS_AUTORIZADOS_DET_INF_CRow_Base class
} // End of namespace
