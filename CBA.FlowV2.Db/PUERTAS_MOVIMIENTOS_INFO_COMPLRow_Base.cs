// <fileinfo name="PUERTAS_MOVIMIENTOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PUERTAS_MOVIMIENTOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PUERTAS_MOVIMIENTOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _bascula_id;
		private bool _bascula_idNull = true;
		private string _bascula_nombre;
		private string _tipo_movimiento;
		private string _chapa_camion;
		private string _chapa_tracto;
		private string _movimiento;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private string _contenedor_numero;
		private decimal _contenedor_tara;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_documento;
		private string _persona_codigo;
		private string _persona_nombre;
		private decimal _puerto_id;
		private bool _puerto_idNull = true;
		private string _puerto_nombre;
		private string _puerto_abreviatura;
		private string _numero_comprobante;
		private string _importacion_terrestre;
		private string _observaciones;
		private string _estado_contenedor;
		private decimal _tara_camion;
		private bool _tara_camionNull = true;
		private string _chofer_documento;
		private string _chofer_nombre;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _peso_bruto;
		private bool _peso_brutoNull = true;
		private decimal _tara_contenedor;
		private bool _tara_contenedorNull = true;
		private decimal _peso_neto;
		private bool _peso_netoNull = true;
		private string _nota_remision;
		private string _confirmado;
		private string _precinto_1;
		private string _precinto_2;
		private string _precinto_3;
		private string _precinto_4;
		private string _precinto_5;
		private string _precinto_ventilete;
		private decimal _intercambio_equipos_id;
		private bool _intercambio_equipos_idNull = true;
		private decimal _usuario_creador_id;
		private bool _usuario_creador_idNull = true;
		private string _usuario_creador_nombre;
		private decimal _usuario_confirmacion_id;
		private bool _usuario_confirmacion_idNull = true;
		private string _usuario_confirmacion_nombre;
		private System.DateTime _fecha_confirmacion;
		private bool _fecha_confirmacionNull = true;
		private string _booking_bl;
		private string _eir_piso;
		private string _eir_fondo;
		private string _eir_techo;
		private string _eir_panel_derecho;
		private string _eir_panel_izquierdo;
		private string _eir_puerta;
		private string _eir_refrigerado;
		private decimal _equipo_autorizado_det_id;
		private bool _equipo_autorizado_det_idNull = true;
		private string _nro_autorizacion;
		private string _codigo_autorizacion;
		private decimal _set_point;
		private bool _set_pointNull = true;
		private string _contendor_clase;
		private string _mercaderias;
		private string _danado;
		private string _dano_informado;
		private string _rechazado;
		private string _conocimiento;
		private decimal _temperatura;
		private bool _temperaturaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PUERTAS_MOVIMIENTOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PUERTAS_MOVIMIENTOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsBASCULA_IDNull != original.IsBASCULA_IDNull) return true;
			if (!this.IsBASCULA_IDNull && !original.IsBASCULA_IDNull)
				if (this.BASCULA_ID != original.BASCULA_ID) return true;
			if (this.BASCULA_NOMBRE != original.BASCULA_NOMBRE) return true;
			if (this.TIPO_MOVIMIENTO != original.TIPO_MOVIMIENTO) return true;
			if (this.CHAPA_CAMION != original.CHAPA_CAMION) return true;
			if (this.CHAPA_TRACTO != original.CHAPA_TRACTO) return true;
			if (this.MOVIMIENTO != original.MOVIMIENTO) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.CONTENEDOR_TARA != original.CONTENEDOR_TARA) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_DOCUMENTO != original.PERSONA_DOCUMENTO) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.IsPUERTO_IDNull != original.IsPUERTO_IDNull) return true;
			if (!this.IsPUERTO_IDNull && !original.IsPUERTO_IDNull)
				if (this.PUERTO_ID != original.PUERTO_ID) return true;
			if (this.PUERTO_NOMBRE != original.PUERTO_NOMBRE) return true;
			if (this.PUERTO_ABREVIATURA != original.PUERTO_ABREVIATURA) return true;
			if (this.NUMERO_COMPROBANTE != original.NUMERO_COMPROBANTE) return true;
			if (this.IMPORTACION_TERRESTRE != original.IMPORTACION_TERRESTRE) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.ESTADO_CONTENEDOR != original.ESTADO_CONTENEDOR) return true;
			if (this.IsTARA_CAMIONNull != original.IsTARA_CAMIONNull) return true;
			if (!this.IsTARA_CAMIONNull && !original.IsTARA_CAMIONNull)
				if (this.TARA_CAMION != original.TARA_CAMION) return true;
			if (this.CHOFER_DOCUMENTO != original.CHOFER_DOCUMENTO) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsPESO_BRUTONull != original.IsPESO_BRUTONull) return true;
			if (!this.IsPESO_BRUTONull && !original.IsPESO_BRUTONull)
				if (this.PESO_BRUTO != original.PESO_BRUTO) return true;
			if (this.IsTARA_CONTENEDORNull != original.IsTARA_CONTENEDORNull) return true;
			if (!this.IsTARA_CONTENEDORNull && !original.IsTARA_CONTENEDORNull)
				if (this.TARA_CONTENEDOR != original.TARA_CONTENEDOR) return true;
			if (this.IsPESO_NETONull != original.IsPESO_NETONull) return true;
			if (!this.IsPESO_NETONull && !original.IsPESO_NETONull)
				if (this.PESO_NETO != original.PESO_NETO) return true;
			if (this.NOTA_REMISION != original.NOTA_REMISION) return true;
			if (this.CONFIRMADO != original.CONFIRMADO) return true;
			if (this.PRECINTO_1 != original.PRECINTO_1) return true;
			if (this.PRECINTO_2 != original.PRECINTO_2) return true;
			if (this.PRECINTO_3 != original.PRECINTO_3) return true;
			if (this.PRECINTO_4 != original.PRECINTO_4) return true;
			if (this.PRECINTO_5 != original.PRECINTO_5) return true;
			if (this.PRECINTO_VENTILETE != original.PRECINTO_VENTILETE) return true;
			if (this.IsINTERCAMBIO_EQUIPOS_IDNull != original.IsINTERCAMBIO_EQUIPOS_IDNull) return true;
			if (!this.IsINTERCAMBIO_EQUIPOS_IDNull && !original.IsINTERCAMBIO_EQUIPOS_IDNull)
				if (this.INTERCAMBIO_EQUIPOS_ID != original.INTERCAMBIO_EQUIPOS_ID) return true;
			if (this.IsUSUARIO_CREADOR_IDNull != original.IsUSUARIO_CREADOR_IDNull) return true;
			if (!this.IsUSUARIO_CREADOR_IDNull && !original.IsUSUARIO_CREADOR_IDNull)
				if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.USUARIO_CREADOR_NOMBRE != original.USUARIO_CREADOR_NOMBRE) return true;
			if (this.IsUSUARIO_CONFIRMACION_IDNull != original.IsUSUARIO_CONFIRMACION_IDNull) return true;
			if (!this.IsUSUARIO_CONFIRMACION_IDNull && !original.IsUSUARIO_CONFIRMACION_IDNull)
				if (this.USUARIO_CONFIRMACION_ID != original.USUARIO_CONFIRMACION_ID) return true;
			if (this.USUARIO_CONFIRMACION_NOMBRE != original.USUARIO_CONFIRMACION_NOMBRE) return true;
			if (this.IsFECHA_CONFIRMACIONNull != original.IsFECHA_CONFIRMACIONNull) return true;
			if (!this.IsFECHA_CONFIRMACIONNull && !original.IsFECHA_CONFIRMACIONNull)
				if (this.FECHA_CONFIRMACION != original.FECHA_CONFIRMACION) return true;
			if (this.BOOKING_BL != original.BOOKING_BL) return true;
			if (this.EIR_PISO != original.EIR_PISO) return true;
			if (this.EIR_FONDO != original.EIR_FONDO) return true;
			if (this.EIR_TECHO != original.EIR_TECHO) return true;
			if (this.EIR_PANEL_DERECHO != original.EIR_PANEL_DERECHO) return true;
			if (this.EIR_PANEL_IZQUIERDO != original.EIR_PANEL_IZQUIERDO) return true;
			if (this.EIR_PUERTA != original.EIR_PUERTA) return true;
			if (this.EIR_REFRIGERADO != original.EIR_REFRIGERADO) return true;
			if (this.IsEQUIPO_AUTORIZADO_DET_IDNull != original.IsEQUIPO_AUTORIZADO_DET_IDNull) return true;
			if (!this.IsEQUIPO_AUTORIZADO_DET_IDNull && !original.IsEQUIPO_AUTORIZADO_DET_IDNull)
				if (this.EQUIPO_AUTORIZADO_DET_ID != original.EQUIPO_AUTORIZADO_DET_ID) return true;
			if (this.NRO_AUTORIZACION != original.NRO_AUTORIZACION) return true;
			if (this.CODIGO_AUTORIZACION != original.CODIGO_AUTORIZACION) return true;
			if (this.IsSET_POINTNull != original.IsSET_POINTNull) return true;
			if (!this.IsSET_POINTNull && !original.IsSET_POINTNull)
				if (this.SET_POINT != original.SET_POINT) return true;
			if (this.CONTENDOR_CLASE != original.CONTENDOR_CLASE) return true;
			if (this.MERCADERIAS != original.MERCADERIAS) return true;
			if (this.DANADO != original.DANADO) return true;
			if (this.DANO_INFORMADO != original.DANO_INFORMADO) return true;
			if (this.RECHAZADO != original.RECHAZADO) return true;
			if (this.CONOCIMIENTO != original.CONOCIMIENTO) return true;
			if (this.IsTEMPERATURANull != original.IsTEMPERATURANull) return true;
			if (!this.IsTEMPERATURANull && !original.IsTEMPERATURANull)
				if (this.TEMPERATURA != original.TEMPERATURA) return true;
			
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
		/// Gets or sets the <c>BASCULA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BASCULA_ID</c> column value.</value>
		public decimal BASCULA_ID
		{
			get
			{
				if(IsBASCULA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _bascula_id;
			}
			set
			{
				_bascula_idNull = false;
				_bascula_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BASCULA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBASCULA_IDNull
		{
			get { return _bascula_idNull; }
			set { _bascula_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BASCULA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BASCULA_NOMBRE</c> column value.</value>
		public string BASCULA_NOMBRE
		{
			get { return _bascula_nombre; }
			set { _bascula_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO</c> column value.</value>
		public string TIPO_MOVIMIENTO
		{
			get { return _tipo_movimiento; }
			set { _tipo_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA_CAMION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA_CAMION</c> column value.</value>
		public string CHAPA_CAMION
		{
			get { return _chapa_camion; }
			set { _chapa_camion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA_TRACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA_TRACTO</c> column value.</value>
		public string CHAPA_TRACTO
		{
			get { return _chapa_tracto; }
			set { _chapa_tracto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO</c> column value.</value>
		public string MOVIMIENTO
		{
			get { return _movimiento; }
			set { _movimiento = value; }
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
		/// Gets or sets the <c>CONTENEDOR_TARA</c> column value.
		/// </summary>
		/// <value>The <c>CONTENEDOR_TARA</c> column value.</value>
		public decimal CONTENEDOR_TARA
		{
			get { return _contenedor_tara; }
			set { _contenedor_tara = value; }
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
		/// Gets or sets the <c>PERSONA_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DOCUMENTO</c> column value.</value>
		public string PERSONA_DOCUMENTO
		{
			get { return _persona_documento; }
			set { _persona_documento = value; }
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
		/// Gets or sets the <c>PUERTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_ID</c> column value.</value>
		public decimal PUERTO_ID
		{
			get
			{
				if(IsPUERTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerto_id;
			}
			set
			{
				_puerto_idNull = false;
				_puerto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTO_IDNull
		{
			get { return _puerto_idNull; }
			set { _puerto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_NOMBRE</c> column value.</value>
		public string PUERTO_NOMBRE
		{
			get { return _puerto_nombre; }
			set { _puerto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_ABREVIATURA</c> column value.</value>
		public string PUERTO_ABREVIATURA
		{
			get { return _puerto_abreviatura; }
			set { _puerto_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_COMPROBANTE</c> column value.</value>
		public string NUMERO_COMPROBANTE
		{
			get { return _numero_comprobante; }
			set { _numero_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_TERRESTRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_TERRESTRE</c> column value.</value>
		public string IMPORTACION_TERRESTRE
		{
			get { return _importacion_terrestre; }
			set { _importacion_terrestre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_CONTENEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_CONTENEDOR</c> column value.</value>
		public string ESTADO_CONTENEDOR
		{
			get { return _estado_contenedor; }
			set { _estado_contenedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA_CAMION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA_CAMION</c> column value.</value>
		public decimal TARA_CAMION
		{
			get
			{
				if(IsTARA_CAMIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara_camion;
			}
			set
			{
				_tara_camionNull = false;
				_tara_camion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA_CAMION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARA_CAMIONNull
		{
			get { return _tara_camionNull; }
			set { _tara_camionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_DOCUMENTO</c> column value.</value>
		public string CHOFER_DOCUMENTO
		{
			get { return _chofer_documento; }
			set { _chofer_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_NOMBRE</c> column value.</value>
		public string CHOFER_NOMBRE
		{
			get { return _chofer_nombre; }
			set { _chofer_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_BRUTO</c> column value.</value>
		public decimal PESO_BRUTO
		{
			get
			{
				if(IsPESO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_bruto;
			}
			set
			{
				_peso_brutoNull = false;
				_peso_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_BRUTONull
		{
			get { return _peso_brutoNull; }
			set { _peso_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA_CONTENEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA_CONTENEDOR</c> column value.</value>
		public decimal TARA_CONTENEDOR
		{
			get
			{
				if(IsTARA_CONTENEDORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara_contenedor;
			}
			set
			{
				_tara_contenedorNull = false;
				_tara_contenedor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA_CONTENEDOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARA_CONTENEDORNull
		{
			get { return _tara_contenedorNull; }
			set { _tara_contenedorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_NETO</c> column value.</value>
		public decimal PESO_NETO
		{
			get
			{
				if(IsPESO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_neto;
			}
			set
			{
				_peso_netoNull = false;
				_peso_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_NETONull
		{
			get { return _peso_netoNull; }
			set { _peso_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_REMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTA_REMISION</c> column value.</value>
		public string NOTA_REMISION
		{
			get { return _nota_remision; }
			set { _nota_remision = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONFIRMADO</c> column value.
		/// </summary>
		/// <value>The <c>CONFIRMADO</c> column value.</value>
		public string CONFIRMADO
		{
			get { return _confirmado; }
			set { _confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_1</c> column value.</value>
		public string PRECINTO_1
		{
			get { return _precinto_1; }
			set { _precinto_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_2</c> column value.</value>
		public string PRECINTO_2
		{
			get { return _precinto_2; }
			set { _precinto_2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_3</c> column value.</value>
		public string PRECINTO_3
		{
			get { return _precinto_3; }
			set { _precinto_3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_4</c> column value.</value>
		public string PRECINTO_4
		{
			get { return _precinto_4; }
			set { _precinto_4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_5</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_5</c> column value.</value>
		public string PRECINTO_5
		{
			get { return _precinto_5; }
			set { _precinto_5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_VENTILETE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_VENTILETE</c> column value.</value>
		public string PRECINTO_VENTILETE
		{
			get { return _precinto_ventilete; }
			set { _precinto_ventilete = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERCAMBIO_EQUIPOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INTERCAMBIO_EQUIPOS_ID</c> column value.</value>
		public decimal INTERCAMBIO_EQUIPOS_ID
		{
			get
			{
				if(IsINTERCAMBIO_EQUIPOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _intercambio_equipos_id;
			}
			set
			{
				_intercambio_equipos_idNull = false;
				_intercambio_equipos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INTERCAMBIO_EQUIPOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINTERCAMBIO_EQUIPOS_IDNull
		{
			get { return _intercambio_equipos_idNull; }
			set { _intercambio_equipos_idNull = value; }
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
		/// Gets or sets the <c>USUARIO_CREADOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_NOMBRE</c> column value.</value>
		public string USUARIO_CREADOR_NOMBRE
		{
			get { return _usuario_creador_nombre; }
			set { _usuario_creador_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CONFIRMACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CONFIRMACION_ID</c> column value.</value>
		public decimal USUARIO_CONFIRMACION_ID
		{
			get
			{
				if(IsUSUARIO_CONFIRMACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_confirmacion_id;
			}
			set
			{
				_usuario_confirmacion_idNull = false;
				_usuario_confirmacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CONFIRMACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CONFIRMACION_IDNull
		{
			get { return _usuario_confirmacion_idNull; }
			set { _usuario_confirmacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CONFIRMACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CONFIRMACION_NOMBRE</c> column value.</value>
		public string USUARIO_CONFIRMACION_NOMBRE
		{
			get { return _usuario_confirmacion_nombre; }
			set { _usuario_confirmacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CONFIRMACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CONFIRMACION</c> column value.</value>
		public System.DateTime FECHA_CONFIRMACION
		{
			get
			{
				if(IsFECHA_CONFIRMACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_confirmacion;
			}
			set
			{
				_fecha_confirmacionNull = false;
				_fecha_confirmacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CONFIRMACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CONFIRMACIONNull
		{
			get { return _fecha_confirmacionNull; }
			set { _fecha_confirmacionNull = value; }
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
		/// Gets or sets the <c>EIR_PISO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_PISO</c> column value.</value>
		public string EIR_PISO
		{
			get { return _eir_piso; }
			set { _eir_piso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EIR_FONDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_FONDO</c> column value.</value>
		public string EIR_FONDO
		{
			get { return _eir_fondo; }
			set { _eir_fondo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EIR_TECHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_TECHO</c> column value.</value>
		public string EIR_TECHO
		{
			get { return _eir_techo; }
			set { _eir_techo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EIR_PANEL_DERECHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_PANEL_DERECHO</c> column value.</value>
		public string EIR_PANEL_DERECHO
		{
			get { return _eir_panel_derecho; }
			set { _eir_panel_derecho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EIR_PANEL_IZQUIERDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_PANEL_IZQUIERDO</c> column value.</value>
		public string EIR_PANEL_IZQUIERDO
		{
			get { return _eir_panel_izquierdo; }
			set { _eir_panel_izquierdo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EIR_PUERTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_PUERTA</c> column value.</value>
		public string EIR_PUERTA
		{
			get { return _eir_puerta; }
			set { _eir_puerta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EIR_REFRIGERADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EIR_REFRIGERADO</c> column value.</value>
		public string EIR_REFRIGERADO
		{
			get { return _eir_refrigerado; }
			set { _eir_refrigerado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EQUIPO_AUTORIZADO_DET_ID</c> column value.</value>
		public decimal EQUIPO_AUTORIZADO_DET_ID
		{
			get
			{
				if(IsEQUIPO_AUTORIZADO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _equipo_autorizado_det_id;
			}
			set
			{
				_equipo_autorizado_det_idNull = false;
				_equipo_autorizado_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EQUIPO_AUTORIZADO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEQUIPO_AUTORIZADO_DET_IDNull
		{
			get { return _equipo_autorizado_det_idNull; }
			set { _equipo_autorizado_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_AUTORIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_AUTORIZACION</c> column value.</value>
		public string NRO_AUTORIZACION
		{
			get { return _nro_autorizacion; }
			set { _nro_autorizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_AUTORIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_AUTORIZACION</c> column value.</value>
		public string CODIGO_AUTORIZACION
		{
			get { return _codigo_autorizacion; }
			set { _codigo_autorizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SET_POINT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SET_POINT</c> column value.</value>
		public decimal SET_POINT
		{
			get
			{
				if(IsSET_POINTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _set_point;
			}
			set
			{
				_set_pointNull = false;
				_set_point = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SET_POINT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSET_POINTNull
		{
			get { return _set_pointNull; }
			set { _set_pointNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENDOR_CLASE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENDOR_CLASE</c> column value.</value>
		public string CONTENDOR_CLASE
		{
			get { return _contendor_clase; }
			set { _contendor_clase = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIAS</c> column value.</value>
		public string MERCADERIAS
		{
			get { return _mercaderias; }
			set { _mercaderias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DANADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DANADO</c> column value.</value>
		public string DANADO
		{
			get { return _danado; }
			set { _danado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DANO_INFORMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DANO_INFORMADO</c> column value.</value>
		public string DANO_INFORMADO
		{
			get { return _dano_informado; }
			set { _dano_informado = value; }
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
		/// Gets or sets the <c>CONOCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO</c> column value.</value>
		public string CONOCIMIENTO
		{
			get { return _conocimiento; }
			set { _conocimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPERATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEMPERATURA</c> column value.</value>
		public decimal TEMPERATURA
		{
			get
			{
				if(IsTEMPERATURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _temperatura;
			}
			set
			{
				_temperaturaNull = false;
				_temperatura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEMPERATURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEMPERATURANull
		{
			get { return _temperaturaNull; }
			set { _temperaturaNull = value; }
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
			dynStr.Append("@CBA@BASCULA_ID=");
			dynStr.Append(IsBASCULA_IDNull ? (object)"<NULL>" : BASCULA_ID);
			dynStr.Append("@CBA@BASCULA_NOMBRE=");
			dynStr.Append(BASCULA_NOMBRE);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO=");
			dynStr.Append(TIPO_MOVIMIENTO);
			dynStr.Append("@CBA@CHAPA_CAMION=");
			dynStr.Append(CHAPA_CAMION);
			dynStr.Append("@CBA@CHAPA_TRACTO=");
			dynStr.Append(CHAPA_TRACTO);
			dynStr.Append("@CBA@MOVIMIENTO=");
			dynStr.Append(MOVIMIENTO);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@CONTENEDOR_TARA=");
			dynStr.Append(CONTENEDOR_TARA);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_DOCUMENTO=");
			dynStr.Append(PERSONA_DOCUMENTO);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PUERTO_ID=");
			dynStr.Append(IsPUERTO_IDNull ? (object)"<NULL>" : PUERTO_ID);
			dynStr.Append("@CBA@PUERTO_NOMBRE=");
			dynStr.Append(PUERTO_NOMBRE);
			dynStr.Append("@CBA@PUERTO_ABREVIATURA=");
			dynStr.Append(PUERTO_ABREVIATURA);
			dynStr.Append("@CBA@NUMERO_COMPROBANTE=");
			dynStr.Append(NUMERO_COMPROBANTE);
			dynStr.Append("@CBA@IMPORTACION_TERRESTRE=");
			dynStr.Append(IMPORTACION_TERRESTRE);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@ESTADO_CONTENEDOR=");
			dynStr.Append(ESTADO_CONTENEDOR);
			dynStr.Append("@CBA@TARA_CAMION=");
			dynStr.Append(IsTARA_CAMIONNull ? (object)"<NULL>" : TARA_CAMION);
			dynStr.Append("@CBA@CHOFER_DOCUMENTO=");
			dynStr.Append(CHOFER_DOCUMENTO);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@PESO_BRUTO=");
			dynStr.Append(IsPESO_BRUTONull ? (object)"<NULL>" : PESO_BRUTO);
			dynStr.Append("@CBA@TARA_CONTENEDOR=");
			dynStr.Append(IsTARA_CONTENEDORNull ? (object)"<NULL>" : TARA_CONTENEDOR);
			dynStr.Append("@CBA@PESO_NETO=");
			dynStr.Append(IsPESO_NETONull ? (object)"<NULL>" : PESO_NETO);
			dynStr.Append("@CBA@NOTA_REMISION=");
			dynStr.Append(NOTA_REMISION);
			dynStr.Append("@CBA@CONFIRMADO=");
			dynStr.Append(CONFIRMADO);
			dynStr.Append("@CBA@PRECINTO_1=");
			dynStr.Append(PRECINTO_1);
			dynStr.Append("@CBA@PRECINTO_2=");
			dynStr.Append(PRECINTO_2);
			dynStr.Append("@CBA@PRECINTO_3=");
			dynStr.Append(PRECINTO_3);
			dynStr.Append("@CBA@PRECINTO_4=");
			dynStr.Append(PRECINTO_4);
			dynStr.Append("@CBA@PRECINTO_5=");
			dynStr.Append(PRECINTO_5);
			dynStr.Append("@CBA@PRECINTO_VENTILETE=");
			dynStr.Append(PRECINTO_VENTILETE);
			dynStr.Append("@CBA@INTERCAMBIO_EQUIPOS_ID=");
			dynStr.Append(IsINTERCAMBIO_EQUIPOS_IDNull ? (object)"<NULL>" : INTERCAMBIO_EQUIPOS_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(IsUSUARIO_CREADOR_IDNull ? (object)"<NULL>" : USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@USUARIO_CREADOR_NOMBRE=");
			dynStr.Append(USUARIO_CREADOR_NOMBRE);
			dynStr.Append("@CBA@USUARIO_CONFIRMACION_ID=");
			dynStr.Append(IsUSUARIO_CONFIRMACION_IDNull ? (object)"<NULL>" : USUARIO_CONFIRMACION_ID);
			dynStr.Append("@CBA@USUARIO_CONFIRMACION_NOMBRE=");
			dynStr.Append(USUARIO_CONFIRMACION_NOMBRE);
			dynStr.Append("@CBA@FECHA_CONFIRMACION=");
			dynStr.Append(IsFECHA_CONFIRMACIONNull ? (object)"<NULL>" : FECHA_CONFIRMACION);
			dynStr.Append("@CBA@BOOKING_BL=");
			dynStr.Append(BOOKING_BL);
			dynStr.Append("@CBA@EIR_PISO=");
			dynStr.Append(EIR_PISO);
			dynStr.Append("@CBA@EIR_FONDO=");
			dynStr.Append(EIR_FONDO);
			dynStr.Append("@CBA@EIR_TECHO=");
			dynStr.Append(EIR_TECHO);
			dynStr.Append("@CBA@EIR_PANEL_DERECHO=");
			dynStr.Append(EIR_PANEL_DERECHO);
			dynStr.Append("@CBA@EIR_PANEL_IZQUIERDO=");
			dynStr.Append(EIR_PANEL_IZQUIERDO);
			dynStr.Append("@CBA@EIR_PUERTA=");
			dynStr.Append(EIR_PUERTA);
			dynStr.Append("@CBA@EIR_REFRIGERADO=");
			dynStr.Append(EIR_REFRIGERADO);
			dynStr.Append("@CBA@EQUIPO_AUTORIZADO_DET_ID=");
			dynStr.Append(IsEQUIPO_AUTORIZADO_DET_IDNull ? (object)"<NULL>" : EQUIPO_AUTORIZADO_DET_ID);
			dynStr.Append("@CBA@NRO_AUTORIZACION=");
			dynStr.Append(NRO_AUTORIZACION);
			dynStr.Append("@CBA@CODIGO_AUTORIZACION=");
			dynStr.Append(CODIGO_AUTORIZACION);
			dynStr.Append("@CBA@SET_POINT=");
			dynStr.Append(IsSET_POINTNull ? (object)"<NULL>" : SET_POINT);
			dynStr.Append("@CBA@CONTENDOR_CLASE=");
			dynStr.Append(CONTENDOR_CLASE);
			dynStr.Append("@CBA@MERCADERIAS=");
			dynStr.Append(MERCADERIAS);
			dynStr.Append("@CBA@DANADO=");
			dynStr.Append(DANADO);
			dynStr.Append("@CBA@DANO_INFORMADO=");
			dynStr.Append(DANO_INFORMADO);
			dynStr.Append("@CBA@RECHAZADO=");
			dynStr.Append(RECHAZADO);
			dynStr.Append("@CBA@CONOCIMIENTO=");
			dynStr.Append(CONOCIMIENTO);
			dynStr.Append("@CBA@TEMPERATURA=");
			dynStr.Append(IsTEMPERATURANull ? (object)"<NULL>" : TEMPERATURA);
			return dynStr.ToString();
		}
	} // End of PUERTAS_MOVIMIENTOS_INFO_COMPLRow_Base class
} // End of namespace
