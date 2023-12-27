// <fileinfo name="NOMINA_CONTENED_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>NOMINA_CONTENED_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENED_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _nomina_contenedores_id;
		private bool _nomina_contenedores_idNull = true;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private string _contenedor_numero;
		private string _contenedor_linea;
		private string _contenedor_tipo;
		private string _contenedor_clase;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_codigo;
		private string _persona_nombre;
		private decimal _puerta_movimiento_entrega_id;
		private bool _puerta_movimiento_entrega_idNull = true;
		private string _gio_entrega_numero;
		private System.DateTime _fecha_entrega;
		private bool _fecha_entregaNull = true;
		private string _gio_entrega_confirmado;
		private decimal _gio_entrega_persona_id;
		private bool _gio_entrega_persona_idNull = true;
		private string _gio_entrega_persona_nombre;
		private decimal _puerta_movimiento_devoluc_id;
		private bool _puerta_movimiento_devoluc_idNull = true;
		private string _gio_devolucion_numero;
		private System.DateTime _fecha_devolucion;
		private bool _fecha_devolucionNull = true;
		private string _gio_devolucion_confirmado;
		private decimal _gio_devolucion_persona_id;
		private bool _gio_devolucion_persona_idNull = true;
		private string _gio_devolucion_persona_nombre;
		private string _gio_devolucion_booking;
		private decimal _usuario_creador_id;
		private bool _usuario_creador_idNull = true;
		private string _usuario_creador;
		private decimal _usuario_modificacion_id;
		private bool _usuario_modificacion_idNull = true;
		private string _usuario_modificacion;
		private string _rechazado;
		private string _observacion;
		private decimal _contenedores_operaciones_id;
		private bool _contenedores_operaciones_idNull = true;
		private System.DateTime _consolidacion_fecha;
		private bool _consolidacion_fechaNull = true;
		private string _consolidacion_nro;
		private string _consolidacion_procesado;
		private string _consolidacion_cliente;
		private decimal _pre_embarque_contenedor_id;
		private bool _pre_embarque_contenedor_idNull = true;
		private string _esta_en_pre_embarque;
		private decimal _intercambio_equipo_id;
		private bool _intercambio_equipo_idNull = true;
		private string _intercambio_buque;
		private string _inercambio_numero;
		private decimal _puerto_devolucion_id;
		private bool _puerto_devolucion_idNull = true;
		private string _puerto_devolucion_nombre;
		private string _puerto_devolucion_abreviatura;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENED_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public NOMINA_CONTENED_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOMINA_CONTENED_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsNOMINA_CONTENEDORES_IDNull != original.IsNOMINA_CONTENEDORES_IDNull) return true;
			if (!this.IsNOMINA_CONTENEDORES_IDNull && !original.IsNOMINA_CONTENEDORES_IDNull)
				if (this.NOMINA_CONTENEDORES_ID != original.NOMINA_CONTENEDORES_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.CONTENEDOR_LINEA != original.CONTENEDOR_LINEA) return true;
			if (this.CONTENEDOR_TIPO != original.CONTENEDOR_TIPO) return true;
			if (this.CONTENEDOR_CLASE != original.CONTENEDOR_CLASE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull != original.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull) return true;
			if (!this.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull && !original.IsPUERTA_MOVIMIENTO_ENTREGA_IDNull)
				if (this.PUERTA_MOVIMIENTO_ENTREGA_ID != original.PUERTA_MOVIMIENTO_ENTREGA_ID) return true;
			if (this.GIO_ENTREGA_NUMERO != original.GIO_ENTREGA_NUMERO) return true;
			if (this.IsFECHA_ENTREGANull != original.IsFECHA_ENTREGANull) return true;
			if (!this.IsFECHA_ENTREGANull && !original.IsFECHA_ENTREGANull)
				if (this.FECHA_ENTREGA != original.FECHA_ENTREGA) return true;
			if (this.GIO_ENTREGA_CONFIRMADO != original.GIO_ENTREGA_CONFIRMADO) return true;
			if (this.IsGIO_ENTREGA_PERSONA_IDNull != original.IsGIO_ENTREGA_PERSONA_IDNull) return true;
			if (!this.IsGIO_ENTREGA_PERSONA_IDNull && !original.IsGIO_ENTREGA_PERSONA_IDNull)
				if (this.GIO_ENTREGA_PERSONA_ID != original.GIO_ENTREGA_PERSONA_ID) return true;
			if (this.GIO_ENTREGA_PERSONA_NOMBRE != original.GIO_ENTREGA_PERSONA_NOMBRE) return true;
			if (this.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull != original.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull) return true;
			if (!this.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull && !original.IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull)
				if (this.PUERTA_MOVIMIENTO_DEVOLUC_ID != original.PUERTA_MOVIMIENTO_DEVOLUC_ID) return true;
			if (this.GIO_DEVOLUCION_NUMERO != original.GIO_DEVOLUCION_NUMERO) return true;
			if (this.IsFECHA_DEVOLUCIONNull != original.IsFECHA_DEVOLUCIONNull) return true;
			if (!this.IsFECHA_DEVOLUCIONNull && !original.IsFECHA_DEVOLUCIONNull)
				if (this.FECHA_DEVOLUCION != original.FECHA_DEVOLUCION) return true;
			if (this.GIO_DEVOLUCION_CONFIRMADO != original.GIO_DEVOLUCION_CONFIRMADO) return true;
			if (this.IsGIO_DEVOLUCION_PERSONA_IDNull != original.IsGIO_DEVOLUCION_PERSONA_IDNull) return true;
			if (!this.IsGIO_DEVOLUCION_PERSONA_IDNull && !original.IsGIO_DEVOLUCION_PERSONA_IDNull)
				if (this.GIO_DEVOLUCION_PERSONA_ID != original.GIO_DEVOLUCION_PERSONA_ID) return true;
			if (this.GIO_DEVOLUCION_PERSONA_NOMBRE != original.GIO_DEVOLUCION_PERSONA_NOMBRE) return true;
			if (this.GIO_DEVOLUCION_BOOKING != original.GIO_DEVOLUCION_BOOKING) return true;
			if (this.IsUSUARIO_CREADOR_IDNull != original.IsUSUARIO_CREADOR_IDNull) return true;
			if (!this.IsUSUARIO_CREADOR_IDNull && !original.IsUSUARIO_CREADOR_IDNull)
				if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.USUARIO_CREADOR != original.USUARIO_CREADOR) return true;
			if (this.IsUSUARIO_MODIFICACION_IDNull != original.IsUSUARIO_MODIFICACION_IDNull) return true;
			if (!this.IsUSUARIO_MODIFICACION_IDNull && !original.IsUSUARIO_MODIFICACION_IDNull)
				if (this.USUARIO_MODIFICACION_ID != original.USUARIO_MODIFICACION_ID) return true;
			if (this.USUARIO_MODIFICACION != original.USUARIO_MODIFICACION) return true;
			if (this.RECHAZADO != original.RECHAZADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCONTENEDORES_OPERACIONES_IDNull != original.IsCONTENEDORES_OPERACIONES_IDNull) return true;
			if (!this.IsCONTENEDORES_OPERACIONES_IDNull && !original.IsCONTENEDORES_OPERACIONES_IDNull)
				if (this.CONTENEDORES_OPERACIONES_ID != original.CONTENEDORES_OPERACIONES_ID) return true;
			if (this.IsCONSOLIDACION_FECHANull != original.IsCONSOLIDACION_FECHANull) return true;
			if (!this.IsCONSOLIDACION_FECHANull && !original.IsCONSOLIDACION_FECHANull)
				if (this.CONSOLIDACION_FECHA != original.CONSOLIDACION_FECHA) return true;
			if (this.CONSOLIDACION_NRO != original.CONSOLIDACION_NRO) return true;
			if (this.CONSOLIDACION_PROCESADO != original.CONSOLIDACION_PROCESADO) return true;
			if (this.CONSOLIDACION_CLIENTE != original.CONSOLIDACION_CLIENTE) return true;
			if (this.IsPRE_EMBARQUE_CONTENEDOR_IDNull != original.IsPRE_EMBARQUE_CONTENEDOR_IDNull) return true;
			if (!this.IsPRE_EMBARQUE_CONTENEDOR_IDNull && !original.IsPRE_EMBARQUE_CONTENEDOR_IDNull)
				if (this.PRE_EMBARQUE_CONTENEDOR_ID != original.PRE_EMBARQUE_CONTENEDOR_ID) return true;
			if (this.ESTA_EN_PRE_EMBARQUE != original.ESTA_EN_PRE_EMBARQUE) return true;
			if (this.IsINTERCAMBIO_EQUIPO_IDNull != original.IsINTERCAMBIO_EQUIPO_IDNull) return true;
			if (!this.IsINTERCAMBIO_EQUIPO_IDNull && !original.IsINTERCAMBIO_EQUIPO_IDNull)
				if (this.INTERCAMBIO_EQUIPO_ID != original.INTERCAMBIO_EQUIPO_ID) return true;
			if (this.INTERCAMBIO_BUQUE != original.INTERCAMBIO_BUQUE) return true;
			if (this.INERCAMBIO_NUMERO != original.INERCAMBIO_NUMERO) return true;
			if (this.IsPUERTO_DEVOLUCION_IDNull != original.IsPUERTO_DEVOLUCION_IDNull) return true;
			if (!this.IsPUERTO_DEVOLUCION_IDNull && !original.IsPUERTO_DEVOLUCION_IDNull)
				if (this.PUERTO_DEVOLUCION_ID != original.PUERTO_DEVOLUCION_ID) return true;
			if (this.PUERTO_DEVOLUCION_NOMBRE != original.PUERTO_DEVOLUCION_NOMBRE) return true;
			if (this.PUERTO_DEVOLUCION_ABREVIATURA != original.PUERTO_DEVOLUCION_ABREVIATURA) return true;
			
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
		/// Gets or sets the <c>NOMINA_CONTENEDORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMINA_CONTENEDORES_ID</c> column value.</value>
		public decimal NOMINA_CONTENEDORES_ID
		{
			get
			{
				if(IsNOMINA_CONTENEDORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nomina_contenedores_id;
			}
			set
			{
				_nomina_contenedores_idNull = false;
				_nomina_contenedores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOMINA_CONTENEDORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOMINA_CONTENEDORES_IDNull
		{
			get { return _nomina_contenedores_idNull; }
			set { _nomina_contenedores_idNull = value; }
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
		/// </summary>
		/// <value>The <c>CONTENEDOR_NUMERO</c> column value.</value>
		public string CONTENEDOR_NUMERO
		{
			get { return _contenedor_numero; }
			set { _contenedor_numero = value; }
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
		/// </summary>
		/// <value>The <c>CONTENEDOR_CLASE</c> column value.</value>
		public string CONTENEDOR_CLASE
		{
			get { return _contenedor_clase; }
			set { _contenedor_clase = value; }
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
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTA_MOVIMIENTO_ENTREGA_ID</c> column value.</value>
		public decimal PUERTA_MOVIMIENTO_ENTREGA_ID
		{
			get
			{
				if(IsPUERTA_MOVIMIENTO_ENTREGA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerta_movimiento_entrega_id;
			}
			set
			{
				_puerta_movimiento_entrega_idNull = false;
				_puerta_movimiento_entrega_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTA_MOVIMIENTO_ENTREGA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTA_MOVIMIENTO_ENTREGA_IDNull
		{
			get { return _puerta_movimiento_entrega_idNull; }
			set { _puerta_movimiento_entrega_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_ENTREGA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_ENTREGA_NUMERO</c> column value.</value>
		public string GIO_ENTREGA_NUMERO
		{
			get { return _gio_entrega_numero; }
			set { _gio_entrega_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ENTREGA</c> column value.</value>
		public System.DateTime FECHA_ENTREGA
		{
			get
			{
				if(IsFECHA_ENTREGANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_entrega;
			}
			set
			{
				_fecha_entregaNull = false;
				_fecha_entrega = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ENTREGA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ENTREGANull
		{
			get { return _fecha_entregaNull; }
			set { _fecha_entregaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_ENTREGA_CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_ENTREGA_CONFIRMADO</c> column value.</value>
		public string GIO_ENTREGA_CONFIRMADO
		{
			get { return _gio_entrega_confirmado; }
			set { _gio_entrega_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_ENTREGA_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_ENTREGA_PERSONA_ID</c> column value.</value>
		public decimal GIO_ENTREGA_PERSONA_ID
		{
			get
			{
				if(IsGIO_ENTREGA_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _gio_entrega_persona_id;
			}
			set
			{
				_gio_entrega_persona_idNull = false;
				_gio_entrega_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GIO_ENTREGA_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGIO_ENTREGA_PERSONA_IDNull
		{
			get { return _gio_entrega_persona_idNull; }
			set { _gio_entrega_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_ENTREGA_PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_ENTREGA_PERSONA_NOMBRE</c> column value.</value>
		public string GIO_ENTREGA_PERSONA_NOMBRE
		{
			get { return _gio_entrega_persona_nombre; }
			set { _gio_entrega_persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTA_MOVIMIENTO_DEVOLUC_ID</c> column value.</value>
		public decimal PUERTA_MOVIMIENTO_DEVOLUC_ID
		{
			get
			{
				if(IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerta_movimiento_devoluc_id;
			}
			set
			{
				_puerta_movimiento_devoluc_idNull = false;
				_puerta_movimiento_devoluc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTA_MOVIMIENTO_DEVOLUC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull
		{
			get { return _puerta_movimiento_devoluc_idNull; }
			set { _puerta_movimiento_devoluc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_DEVOLUCION_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_DEVOLUCION_NUMERO</c> column value.</value>
		public string GIO_DEVOLUCION_NUMERO
		{
			get { return _gio_devolucion_numero; }
			set { _gio_devolucion_numero = value; }
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
		/// Gets or sets the <c>GIO_DEVOLUCION_CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_DEVOLUCION_CONFIRMADO</c> column value.</value>
		public string GIO_DEVOLUCION_CONFIRMADO
		{
			get { return _gio_devolucion_confirmado; }
			set { _gio_devolucion_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_DEVOLUCION_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_DEVOLUCION_PERSONA_ID</c> column value.</value>
		public decimal GIO_DEVOLUCION_PERSONA_ID
		{
			get
			{
				if(IsGIO_DEVOLUCION_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _gio_devolucion_persona_id;
			}
			set
			{
				_gio_devolucion_persona_idNull = false;
				_gio_devolucion_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GIO_DEVOLUCION_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGIO_DEVOLUCION_PERSONA_IDNull
		{
			get { return _gio_devolucion_persona_idNull; }
			set { _gio_devolucion_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_DEVOLUCION_PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_DEVOLUCION_PERSONA_NOMBRE</c> column value.</value>
		public string GIO_DEVOLUCION_PERSONA_NOMBRE
		{
			get { return _gio_devolucion_persona_nombre; }
			set { _gio_devolucion_persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GIO_DEVOLUCION_BOOKING</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GIO_DEVOLUCION_BOOKING</c> column value.</value>
		public string GIO_DEVOLUCION_BOOKING
		{
			get { return _gio_devolucion_booking; }
			set { _gio_devolucion_booking = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get
			{
				if(IsUSUARIO_CREADOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creador_id;
			}
			set
			{
				_usuario_creador_idNull = false;
				_usuario_creador_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREADOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREADOR_IDNull
		{
			get { return _usuario_creador_idNull; }
			set { _usuario_creador_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR</c> column value.</value>
		public string USUARIO_CREADOR
		{
			get { return _usuario_creador; }
			set { _usuario_creador = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MODIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION_ID</c> column value.</value>
		public decimal USUARIO_MODIFICACION_ID
		{
			get
			{
				if(IsUSUARIO_MODIFICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_modificacion_id;
			}
			set
			{
				_usuario_modificacion_idNull = false;
				_usuario_modificacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_MODIFICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_MODIFICACION_IDNull
		{
			get { return _usuario_modificacion_idNull; }
			set { _usuario_modificacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MODIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION</c> column value.</value>
		public string USUARIO_MODIFICACION
		{
			get { return _usuario_modificacion; }
			set { _usuario_modificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECHAZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECHAZADO</c> column value.</value>
		public string RECHAZADO
		{
			get { return _rechazado; }
			set { _rechazado = value; }
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
		/// Gets or sets the <c>CONTENEDORES_OPERACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDORES_OPERACIONES_ID</c> column value.</value>
		public decimal CONTENEDORES_OPERACIONES_ID
		{
			get
			{
				if(IsCONTENEDORES_OPERACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _contenedores_operaciones_id;
			}
			set
			{
				_contenedores_operaciones_idNull = false;
				_contenedores_operaciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTENEDORES_OPERACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTENEDORES_OPERACIONES_IDNull
		{
			get { return _contenedores_operaciones_idNull; }
			set { _contenedores_operaciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSOLIDACION_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSOLIDACION_FECHA</c> column value.</value>
		public System.DateTime CONSOLIDACION_FECHA
		{
			get
			{
				if(IsCONSOLIDACION_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _consolidacion_fecha;
			}
			set
			{
				_consolidacion_fechaNull = false;
				_consolidacion_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONSOLIDACION_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONSOLIDACION_FECHANull
		{
			get { return _consolidacion_fechaNull; }
			set { _consolidacion_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSOLIDACION_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSOLIDACION_NRO</c> column value.</value>
		public string CONSOLIDACION_NRO
		{
			get { return _consolidacion_nro; }
			set { _consolidacion_nro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSOLIDACION_PROCESADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSOLIDACION_PROCESADO</c> column value.</value>
		public string CONSOLIDACION_PROCESADO
		{
			get { return _consolidacion_procesado; }
			set { _consolidacion_procesado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSOLIDACION_CLIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSOLIDACION_CLIENTE</c> column value.</value>
		public string CONSOLIDACION_CLIENTE
		{
			get { return _consolidacion_cliente; }
			set { _consolidacion_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRE_EMBARQUE_CONTENEDOR_ID</c> column value.</value>
		public decimal PRE_EMBARQUE_CONTENEDOR_ID
		{
			get
			{
				if(IsPRE_EMBARQUE_CONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pre_embarque_contenedor_id;
			}
			set
			{
				_pre_embarque_contenedor_idNull = false;
				_pre_embarque_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRE_EMBARQUE_CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRE_EMBARQUE_CONTENEDOR_IDNull
		{
			get { return _pre_embarque_contenedor_idNull; }
			set { _pre_embarque_contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTA_EN_PRE_EMBARQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTA_EN_PRE_EMBARQUE</c> column value.</value>
		public string ESTA_EN_PRE_EMBARQUE
		{
			get { return _esta_en_pre_embarque; }
			set { _esta_en_pre_embarque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERCAMBIO_EQUIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INTERCAMBIO_EQUIPO_ID</c> column value.</value>
		public decimal INTERCAMBIO_EQUIPO_ID
		{
			get
			{
				if(IsINTERCAMBIO_EQUIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _intercambio_equipo_id;
			}
			set
			{
				_intercambio_equipo_idNull = false;
				_intercambio_equipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INTERCAMBIO_EQUIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINTERCAMBIO_EQUIPO_IDNull
		{
			get { return _intercambio_equipo_idNull; }
			set { _intercambio_equipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERCAMBIO_BUQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INTERCAMBIO_BUQUE</c> column value.</value>
		public string INTERCAMBIO_BUQUE
		{
			get { return _intercambio_buque; }
			set { _intercambio_buque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INERCAMBIO_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INERCAMBIO_NUMERO</c> column value.</value>
		public string INERCAMBIO_NUMERO
		{
			get { return _inercambio_numero; }
			set { _inercambio_numero = value; }
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
		/// Gets or sets the <c>PUERTO_DEVOLUCION_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_DEVOLUCION_ABREVIATURA</c> column value.</value>
		public string PUERTO_DEVOLUCION_ABREVIATURA
		{
			get { return _puerto_devolucion_abreviatura; }
			set { _puerto_devolucion_abreviatura = value; }
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
			dynStr.Append("@CBA@NOMINA_CONTENEDORES_ID=");
			dynStr.Append(IsNOMINA_CONTENEDORES_IDNull ? (object)"<NULL>" : NOMINA_CONTENEDORES_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@CONTENEDOR_LINEA=");
			dynStr.Append(CONTENEDOR_LINEA);
			dynStr.Append("@CBA@CONTENEDOR_TIPO=");
			dynStr.Append(CONTENEDOR_TIPO);
			dynStr.Append("@CBA@CONTENEDOR_CLASE=");
			dynStr.Append(CONTENEDOR_CLASE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PUERTA_MOVIMIENTO_ENTREGA_ID=");
			dynStr.Append(IsPUERTA_MOVIMIENTO_ENTREGA_IDNull ? (object)"<NULL>" : PUERTA_MOVIMIENTO_ENTREGA_ID);
			dynStr.Append("@CBA@GIO_ENTREGA_NUMERO=");
			dynStr.Append(GIO_ENTREGA_NUMERO);
			dynStr.Append("@CBA@FECHA_ENTREGA=");
			dynStr.Append(IsFECHA_ENTREGANull ? (object)"<NULL>" : FECHA_ENTREGA);
			dynStr.Append("@CBA@GIO_ENTREGA_CONFIRMADO=");
			dynStr.Append(GIO_ENTREGA_CONFIRMADO);
			dynStr.Append("@CBA@GIO_ENTREGA_PERSONA_ID=");
			dynStr.Append(IsGIO_ENTREGA_PERSONA_IDNull ? (object)"<NULL>" : GIO_ENTREGA_PERSONA_ID);
			dynStr.Append("@CBA@GIO_ENTREGA_PERSONA_NOMBRE=");
			dynStr.Append(GIO_ENTREGA_PERSONA_NOMBRE);
			dynStr.Append("@CBA@PUERTA_MOVIMIENTO_DEVOLUC_ID=");
			dynStr.Append(IsPUERTA_MOVIMIENTO_DEVOLUC_IDNull ? (object)"<NULL>" : PUERTA_MOVIMIENTO_DEVOLUC_ID);
			dynStr.Append("@CBA@GIO_DEVOLUCION_NUMERO=");
			dynStr.Append(GIO_DEVOLUCION_NUMERO);
			dynStr.Append("@CBA@FECHA_DEVOLUCION=");
			dynStr.Append(IsFECHA_DEVOLUCIONNull ? (object)"<NULL>" : FECHA_DEVOLUCION);
			dynStr.Append("@CBA@GIO_DEVOLUCION_CONFIRMADO=");
			dynStr.Append(GIO_DEVOLUCION_CONFIRMADO);
			dynStr.Append("@CBA@GIO_DEVOLUCION_PERSONA_ID=");
			dynStr.Append(IsGIO_DEVOLUCION_PERSONA_IDNull ? (object)"<NULL>" : GIO_DEVOLUCION_PERSONA_ID);
			dynStr.Append("@CBA@GIO_DEVOLUCION_PERSONA_NOMBRE=");
			dynStr.Append(GIO_DEVOLUCION_PERSONA_NOMBRE);
			dynStr.Append("@CBA@GIO_DEVOLUCION_BOOKING=");
			dynStr.Append(GIO_DEVOLUCION_BOOKING);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(IsUSUARIO_CREADOR_IDNull ? (object)"<NULL>" : USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR=");
			dynStr.Append(USUARIO_CREADOR);
			dynStr.Append("@CBA@USUARIO_MODIFICACION_ID=");
			dynStr.Append(IsUSUARIO_MODIFICACION_IDNull ? (object)"<NULL>" : USUARIO_MODIFICACION_ID);
			dynStr.Append("@CBA@USUARIO_MODIFICACION=");
			dynStr.Append(USUARIO_MODIFICACION);
			dynStr.Append("@CBA@RECHAZADO=");
			dynStr.Append(RECHAZADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CONTENEDORES_OPERACIONES_ID=");
			dynStr.Append(IsCONTENEDORES_OPERACIONES_IDNull ? (object)"<NULL>" : CONTENEDORES_OPERACIONES_ID);
			dynStr.Append("@CBA@CONSOLIDACION_FECHA=");
			dynStr.Append(IsCONSOLIDACION_FECHANull ? (object)"<NULL>" : CONSOLIDACION_FECHA);
			dynStr.Append("@CBA@CONSOLIDACION_NRO=");
			dynStr.Append(CONSOLIDACION_NRO);
			dynStr.Append("@CBA@CONSOLIDACION_PROCESADO=");
			dynStr.Append(CONSOLIDACION_PROCESADO);
			dynStr.Append("@CBA@CONSOLIDACION_CLIENTE=");
			dynStr.Append(CONSOLIDACION_CLIENTE);
			dynStr.Append("@CBA@PRE_EMBARQUE_CONTENEDOR_ID=");
			dynStr.Append(IsPRE_EMBARQUE_CONTENEDOR_IDNull ? (object)"<NULL>" : PRE_EMBARQUE_CONTENEDOR_ID);
			dynStr.Append("@CBA@ESTA_EN_PRE_EMBARQUE=");
			dynStr.Append(ESTA_EN_PRE_EMBARQUE);
			dynStr.Append("@CBA@INTERCAMBIO_EQUIPO_ID=");
			dynStr.Append(IsINTERCAMBIO_EQUIPO_IDNull ? (object)"<NULL>" : INTERCAMBIO_EQUIPO_ID);
			dynStr.Append("@CBA@INTERCAMBIO_BUQUE=");
			dynStr.Append(INTERCAMBIO_BUQUE);
			dynStr.Append("@CBA@INERCAMBIO_NUMERO=");
			dynStr.Append(INERCAMBIO_NUMERO);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_ID=");
			dynStr.Append(IsPUERTO_DEVOLUCION_IDNull ? (object)"<NULL>" : PUERTO_DEVOLUCION_ID);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_NOMBRE=");
			dynStr.Append(PUERTO_DEVOLUCION_NOMBRE);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_ABREVIATURA=");
			dynStr.Append(PUERTO_DEVOLUCION_ABREVIATURA);
			return dynStr.ToString();
		}
	} // End of NOMINA_CONTENED_DET_INFO_COMPLRow_Base class
} // End of namespace
