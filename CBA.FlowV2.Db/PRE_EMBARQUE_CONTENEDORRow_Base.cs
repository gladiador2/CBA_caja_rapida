// <fileinfo name="PRE_EMBARQUE_CONTENEDORRow_Base.cs">
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
	/// The base class for <see cref="PRE_EMBARQUE_CONTENEDORRow"/> that 
	/// represents a record in the <c>PRE_EMBARQUE_CONTENEDOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRE_EMBARQUE_CONTENEDORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMBARQUE_CONTENEDORRow_Base
	{
		private decimal _id;
		private decimal _pre_embarque_detalle_id;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private decimal _tamano;
		private bool _tamanoNull = true;
		private decimal _capacidad;
		private bool _capacidadNull = true;
		private decimal _peso_maximo;
		private bool _peso_maximoNull = true;
		private string _tipo;
		private decimal _linea_id;
		private bool _linea_idNull = true;
		private decimal _agencia_id;
		private bool _agencia_idNull = true;
		private string _mercaderia;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _booking;
		private string _carta_de_frio;
		private string _set_point;
		private decimal _imo_id;
		private bool _imo_idNull = true;
		private string _precinto1;
		private string _precinto2;
		private string _precinto3;
		private string _precinto4;
		private string _precinto5;
		private string _precinto_ventilete;
		private decimal _intercambio_equipo_id;
		private bool _intercambio_equipo_idNull = true;
		private decimal _payload_eir;
		private bool _payload_eirNull = true;
		private decimal _tara_eir;
		private bool _tara_eirNull = true;
		private decimal _temperatura_eir;
		private bool _temperatura_eirNull = true;
		private System.DateTime _hora_eir;
		private bool _hora_eirNull = true;
		private string _procesado_eir;
		private string _salido;
		private string _edi;
		private string _edi_anulado;
		private string _edi_armador;
		private string _precinto_1_eir;
		private string _precinto_2_eir;
		private string _precinto_3_eir;
		private string _precinto_4_eir;
		private string _precinto_5_eir;
		private string _precinto_ventilete_eir;
		private string _eir_piso;
		private string _eir_fondo;
		private string _eir_techo;
		private string _eir_panel_derecho;
		private string _eir_panel_izquierdo;
		private string _eir_puerta;
		private string _observaciones_eir;
		private string _descartado;
		private string _estado_contenedor;
		private decimal _puerto_id;
		private bool _puerto_idNull = true;
		private string _eir_refrigerado;
		private System.DateTime _despacho_fecha;
		private bool _despacho_fechaNull = true;
		private string _factura_numero;
		private string _despacho_numero;
		private string _danado;
		private string _dano_informado;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMBARQUE_CONTENEDORRow_Base"/> class.
		/// </summary>
		public PRE_EMBARQUE_CONTENEDORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRE_EMBARQUE_CONTENEDORRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PRE_EMBARQUE_DETALLE_ID != original.PRE_EMBARQUE_DETALLE_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.IsTAMANONull != original.IsTAMANONull) return true;
			if (!this.IsTAMANONull && !original.IsTAMANONull)
				if (this.TAMANO != original.TAMANO) return true;
			if (this.IsCAPACIDADNull != original.IsCAPACIDADNull) return true;
			if (!this.IsCAPACIDADNull && !original.IsCAPACIDADNull)
				if (this.CAPACIDAD != original.CAPACIDAD) return true;
			if (this.IsPESO_MAXIMONull != original.IsPESO_MAXIMONull) return true;
			if (!this.IsPESO_MAXIMONull && !original.IsPESO_MAXIMONull)
				if (this.PESO_MAXIMO != original.PESO_MAXIMO) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.IsLINEA_IDNull != original.IsLINEA_IDNull) return true;
			if (!this.IsLINEA_IDNull && !original.IsLINEA_IDNull)
				if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.IsAGENCIA_IDNull != original.IsAGENCIA_IDNull) return true;
			if (!this.IsAGENCIA_IDNull && !original.IsAGENCIA_IDNull)
				if (this.AGENCIA_ID != original.AGENCIA_ID) return true;
			if (this.MERCADERIA != original.MERCADERIA) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.BOOKING != original.BOOKING) return true;
			if (this.CARTA_DE_FRIO != original.CARTA_DE_FRIO) return true;
			if (this.SET_POINT != original.SET_POINT) return true;
			if (this.IsIMO_IDNull != original.IsIMO_IDNull) return true;
			if (!this.IsIMO_IDNull && !original.IsIMO_IDNull)
				if (this.IMO_ID != original.IMO_ID) return true;
			if (this.PRECINTO1 != original.PRECINTO1) return true;
			if (this.PRECINTO2 != original.PRECINTO2) return true;
			if (this.PRECINTO3 != original.PRECINTO3) return true;
			if (this.PRECINTO4 != original.PRECINTO4) return true;
			if (this.PRECINTO5 != original.PRECINTO5) return true;
			if (this.PRECINTO_VENTILETE != original.PRECINTO_VENTILETE) return true;
			if (this.IsINTERCAMBIO_EQUIPO_IDNull != original.IsINTERCAMBIO_EQUIPO_IDNull) return true;
			if (!this.IsINTERCAMBIO_EQUIPO_IDNull && !original.IsINTERCAMBIO_EQUIPO_IDNull)
				if (this.INTERCAMBIO_EQUIPO_ID != original.INTERCAMBIO_EQUIPO_ID) return true;
			if (this.IsPAYLOAD_EIRNull != original.IsPAYLOAD_EIRNull) return true;
			if (!this.IsPAYLOAD_EIRNull && !original.IsPAYLOAD_EIRNull)
				if (this.PAYLOAD_EIR != original.PAYLOAD_EIR) return true;
			if (this.IsTARA_EIRNull != original.IsTARA_EIRNull) return true;
			if (!this.IsTARA_EIRNull && !original.IsTARA_EIRNull)
				if (this.TARA_EIR != original.TARA_EIR) return true;
			if (this.IsTEMPERATURA_EIRNull != original.IsTEMPERATURA_EIRNull) return true;
			if (!this.IsTEMPERATURA_EIRNull && !original.IsTEMPERATURA_EIRNull)
				if (this.TEMPERATURA_EIR != original.TEMPERATURA_EIR) return true;
			if (this.IsHORA_EIRNull != original.IsHORA_EIRNull) return true;
			if (!this.IsHORA_EIRNull && !original.IsHORA_EIRNull)
				if (this.HORA_EIR != original.HORA_EIR) return true;
			if (this.PROCESADO_EIR != original.PROCESADO_EIR) return true;
			if (this.SALIDO != original.SALIDO) return true;
			if (this.EDI != original.EDI) return true;
			if (this.EDI_ANULADO != original.EDI_ANULADO) return true;
			if (this.EDI_ARMADOR != original.EDI_ARMADOR) return true;
			if (this.PRECINTO_1_EIR != original.PRECINTO_1_EIR) return true;
			if (this.PRECINTO_2_EIR != original.PRECINTO_2_EIR) return true;
			if (this.PRECINTO_3_EIR != original.PRECINTO_3_EIR) return true;
			if (this.PRECINTO_4_EIR != original.PRECINTO_4_EIR) return true;
			if (this.PRECINTO_5_EIR != original.PRECINTO_5_EIR) return true;
			if (this.PRECINTO_VENTILETE_EIR != original.PRECINTO_VENTILETE_EIR) return true;
			if (this.EIR_PISO != original.EIR_PISO) return true;
			if (this.EIR_FONDO != original.EIR_FONDO) return true;
			if (this.EIR_TECHO != original.EIR_TECHO) return true;
			if (this.EIR_PANEL_DERECHO != original.EIR_PANEL_DERECHO) return true;
			if (this.EIR_PANEL_IZQUIERDO != original.EIR_PANEL_IZQUIERDO) return true;
			if (this.EIR_PUERTA != original.EIR_PUERTA) return true;
			if (this.OBSERVACIONES_EIR != original.OBSERVACIONES_EIR) return true;
			if (this.DESCARTADO != original.DESCARTADO) return true;
			if (this.ESTADO_CONTENEDOR != original.ESTADO_CONTENEDOR) return true;
			if (this.IsPUERTO_IDNull != original.IsPUERTO_IDNull) return true;
			if (!this.IsPUERTO_IDNull && !original.IsPUERTO_IDNull)
				if (this.PUERTO_ID != original.PUERTO_ID) return true;
			if (this.EIR_REFRIGERADO != original.EIR_REFRIGERADO) return true;
			if (this.IsDESPACHO_FECHANull != original.IsDESPACHO_FECHANull) return true;
			if (!this.IsDESPACHO_FECHANull && !original.IsDESPACHO_FECHANull)
				if (this.DESPACHO_FECHA != original.DESPACHO_FECHA) return true;
			if (this.FACTURA_NUMERO != original.FACTURA_NUMERO) return true;
			if (this.DESPACHO_NUMERO != original.DESPACHO_NUMERO) return true;
			if (this.DANADO != original.DANADO) return true;
			if (this.DANO_INFORMADO != original.DANO_INFORMADO) return true;
			
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
		/// Gets or sets the <c>PRE_EMBARQUE_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRE_EMBARQUE_DETALLE_ID</c> column value.</value>
		public decimal PRE_EMBARQUE_DETALLE_ID
		{
			get { return _pre_embarque_detalle_id; }
			set { _pre_embarque_detalle_id = value; }
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
		/// Gets or sets the <c>TAMANO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TAMANO</c> column value.</value>
		public decimal TAMANO
		{
			get
			{
				if(IsTAMANONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tamano;
			}
			set
			{
				_tamanoNull = false;
				_tamano = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TAMANO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTAMANONull
		{
			get { return _tamanoNull; }
			set { _tamanoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPACIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAPACIDAD</c> column value.</value>
		public decimal CAPACIDAD
		{
			get
			{
				if(IsCAPACIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _capacidad;
			}
			set
			{
				_capacidadNull = false;
				_capacidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAPACIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAPACIDADNull
		{
			get { return _capacidadNull; }
			set { _capacidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_MAXIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_MAXIMO</c> column value.</value>
		public decimal PESO_MAXIMO
		{
			get
			{
				if(IsPESO_MAXIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_maximo;
			}
			set
			{
				_peso_maximoNull = false;
				_peso_maximo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_MAXIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_MAXIMONull
		{
			get { return _peso_maximoNull; }
			set { _peso_maximoNull = value; }
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
		/// Gets or sets the <c>LINEA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LINEA_ID</c> column value.</value>
		public decimal LINEA_ID
		{
			get
			{
				if(IsLINEA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _linea_id;
			}
			set
			{
				_linea_idNull = false;
				_linea_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LINEA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLINEA_IDNull
		{
			get { return _linea_idNull; }
			set { _linea_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENCIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AGENCIA_ID</c> column value.</value>
		public decimal AGENCIA_ID
		{
			get
			{
				if(IsAGENCIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _agencia_id;
			}
			set
			{
				_agencia_idNull = false;
				_agencia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AGENCIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAGENCIA_IDNull
		{
			get { return _agencia_idNull; }
			set { _agencia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIA</c> column value.</value>
		public string MERCADERIA
		{
			get { return _mercaderia; }
			set { _mercaderia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BOOKING</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BOOKING</c> column value.</value>
		public string BOOKING
		{
			get { return _booking; }
			set { _booking = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CARTA_DE_FRIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CARTA_DE_FRIO</c> column value.</value>
		public string CARTA_DE_FRIO
		{
			get { return _carta_de_frio; }
			set { _carta_de_frio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SET_POINT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SET_POINT</c> column value.</value>
		public string SET_POINT
		{
			get { return _set_point; }
			set { _set_point = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMO_ID</c> column value.</value>
		public decimal IMO_ID
		{
			get
			{
				if(IsIMO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _imo_id;
			}
			set
			{
				_imo_idNull = false;
				_imo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMO_IDNull
		{
			get { return _imo_idNull; }
			set { _imo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO1</c> column value.</value>
		public string PRECINTO1
		{
			get { return _precinto1; }
			set { _precinto1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO2</c> column value.</value>
		public string PRECINTO2
		{
			get { return _precinto2; }
			set { _precinto2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO3</c> column value.</value>
		public string PRECINTO3
		{
			get { return _precinto3; }
			set { _precinto3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO4</c> column value.</value>
		public string PRECINTO4
		{
			get { return _precinto4; }
			set { _precinto4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO5</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO5</c> column value.</value>
		public string PRECINTO5
		{
			get { return _precinto5; }
			set { _precinto5 = value; }
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
		/// Gets or sets the <c>PAYLOAD_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAYLOAD_EIR</c> column value.</value>
		public decimal PAYLOAD_EIR
		{
			get
			{
				if(IsPAYLOAD_EIRNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _payload_eir;
			}
			set
			{
				_payload_eirNull = false;
				_payload_eir = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAYLOAD_EIR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAYLOAD_EIRNull
		{
			get { return _payload_eirNull; }
			set { _payload_eirNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA_EIR</c> column value.</value>
		public decimal TARA_EIR
		{
			get
			{
				if(IsTARA_EIRNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara_eir;
			}
			set
			{
				_tara_eirNull = false;
				_tara_eir = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA_EIR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARA_EIRNull
		{
			get { return _tara_eirNull; }
			set { _tara_eirNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPERATURA_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEMPERATURA_EIR</c> column value.</value>
		public decimal TEMPERATURA_EIR
		{
			get
			{
				if(IsTEMPERATURA_EIRNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _temperatura_eir;
			}
			set
			{
				_temperatura_eirNull = false;
				_temperatura_eir = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEMPERATURA_EIR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEMPERATURA_EIRNull
		{
			get { return _temperatura_eirNull; }
			set { _temperatura_eirNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORA_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HORA_EIR</c> column value.</value>
		public System.DateTime HORA_EIR
		{
			get
			{
				if(IsHORA_EIRNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _hora_eir;
			}
			set
			{
				_hora_eirNull = false;
				_hora_eir = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HORA_EIR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHORA_EIRNull
		{
			get { return _hora_eirNull; }
			set { _hora_eirNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADO_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCESADO_EIR</c> column value.</value>
		public string PROCESADO_EIR
		{
			get { return _procesado_eir; }
			set { _procesado_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALIDO</c> column value.</value>
		public string SALIDO
		{
			get { return _salido; }
			set { _salido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI</c> column value.</value>
		public string EDI
		{
			get { return _edi; }
			set { _edi = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI_ANULADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI_ANULADO</c> column value.</value>
		public string EDI_ANULADO
		{
			get { return _edi_anulado; }
			set { _edi_anulado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI_ARMADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI_ARMADOR</c> column value.</value>
		public string EDI_ARMADOR
		{
			get { return _edi_armador; }
			set { _edi_armador = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_1_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_1_EIR</c> column value.</value>
		public string PRECINTO_1_EIR
		{
			get { return _precinto_1_eir; }
			set { _precinto_1_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_2_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_2_EIR</c> column value.</value>
		public string PRECINTO_2_EIR
		{
			get { return _precinto_2_eir; }
			set { _precinto_2_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_3_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_3_EIR</c> column value.</value>
		public string PRECINTO_3_EIR
		{
			get { return _precinto_3_eir; }
			set { _precinto_3_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_4_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_4_EIR</c> column value.</value>
		public string PRECINTO_4_EIR
		{
			get { return _precinto_4_eir; }
			set { _precinto_4_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_5_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_5_EIR</c> column value.</value>
		public string PRECINTO_5_EIR
		{
			get { return _precinto_5_eir; }
			set { _precinto_5_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_VENTILETE_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_VENTILETE_EIR</c> column value.</value>
		public string PRECINTO_VENTILETE_EIR
		{
			get { return _precinto_ventilete_eir; }
			set { _precinto_ventilete_eir = value; }
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
		/// Gets or sets the <c>OBSERVACIONES_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES_EIR</c> column value.</value>
		public string OBSERVACIONES_EIR
		{
			get { return _observaciones_eir; }
			set { _observaciones_eir = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCARTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCARTADO</c> column value.</value>
		public string DESCARTADO
		{
			get { return _descartado; }
			set { _descartado = value; }
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
		/// Gets or sets the <c>DESPACHO_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO_FECHA</c> column value.</value>
		public System.DateTime DESPACHO_FECHA
		{
			get
			{
				if(IsDESPACHO_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _despacho_fecha;
			}
			set
			{
				_despacho_fechaNull = false;
				_despacho_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESPACHO_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESPACHO_FECHANull
		{
			get { return _despacho_fechaNull; }
			set { _despacho_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_NUMERO</c> column value.</value>
		public string FACTURA_NUMERO
		{
			get { return _factura_numero; }
			set { _factura_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHO_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO_NUMERO</c> column value.</value>
		public string DESPACHO_NUMERO
		{
			get { return _despacho_numero; }
			set { _despacho_numero = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PRE_EMBARQUE_DETALLE_ID=");
			dynStr.Append(PRE_EMBARQUE_DETALLE_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@TAMANO=");
			dynStr.Append(IsTAMANONull ? (object)"<NULL>" : TAMANO);
			dynStr.Append("@CBA@CAPACIDAD=");
			dynStr.Append(IsCAPACIDADNull ? (object)"<NULL>" : CAPACIDAD);
			dynStr.Append("@CBA@PESO_MAXIMO=");
			dynStr.Append(IsPESO_MAXIMONull ? (object)"<NULL>" : PESO_MAXIMO);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(IsLINEA_IDNull ? (object)"<NULL>" : LINEA_ID);
			dynStr.Append("@CBA@AGENCIA_ID=");
			dynStr.Append(IsAGENCIA_IDNull ? (object)"<NULL>" : AGENCIA_ID);
			dynStr.Append("@CBA@MERCADERIA=");
			dynStr.Append(MERCADERIA);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@BOOKING=");
			dynStr.Append(BOOKING);
			dynStr.Append("@CBA@CARTA_DE_FRIO=");
			dynStr.Append(CARTA_DE_FRIO);
			dynStr.Append("@CBA@SET_POINT=");
			dynStr.Append(SET_POINT);
			dynStr.Append("@CBA@IMO_ID=");
			dynStr.Append(IsIMO_IDNull ? (object)"<NULL>" : IMO_ID);
			dynStr.Append("@CBA@PRECINTO1=");
			dynStr.Append(PRECINTO1);
			dynStr.Append("@CBA@PRECINTO2=");
			dynStr.Append(PRECINTO2);
			dynStr.Append("@CBA@PRECINTO3=");
			dynStr.Append(PRECINTO3);
			dynStr.Append("@CBA@PRECINTO4=");
			dynStr.Append(PRECINTO4);
			dynStr.Append("@CBA@PRECINTO5=");
			dynStr.Append(PRECINTO5);
			dynStr.Append("@CBA@PRECINTO_VENTILETE=");
			dynStr.Append(PRECINTO_VENTILETE);
			dynStr.Append("@CBA@INTERCAMBIO_EQUIPO_ID=");
			dynStr.Append(IsINTERCAMBIO_EQUIPO_IDNull ? (object)"<NULL>" : INTERCAMBIO_EQUIPO_ID);
			dynStr.Append("@CBA@PAYLOAD_EIR=");
			dynStr.Append(IsPAYLOAD_EIRNull ? (object)"<NULL>" : PAYLOAD_EIR);
			dynStr.Append("@CBA@TARA_EIR=");
			dynStr.Append(IsTARA_EIRNull ? (object)"<NULL>" : TARA_EIR);
			dynStr.Append("@CBA@TEMPERATURA_EIR=");
			dynStr.Append(IsTEMPERATURA_EIRNull ? (object)"<NULL>" : TEMPERATURA_EIR);
			dynStr.Append("@CBA@HORA_EIR=");
			dynStr.Append(IsHORA_EIRNull ? (object)"<NULL>" : HORA_EIR);
			dynStr.Append("@CBA@PROCESADO_EIR=");
			dynStr.Append(PROCESADO_EIR);
			dynStr.Append("@CBA@SALIDO=");
			dynStr.Append(SALIDO);
			dynStr.Append("@CBA@EDI=");
			dynStr.Append(EDI);
			dynStr.Append("@CBA@EDI_ANULADO=");
			dynStr.Append(EDI_ANULADO);
			dynStr.Append("@CBA@EDI_ARMADOR=");
			dynStr.Append(EDI_ARMADOR);
			dynStr.Append("@CBA@PRECINTO_1_EIR=");
			dynStr.Append(PRECINTO_1_EIR);
			dynStr.Append("@CBA@PRECINTO_2_EIR=");
			dynStr.Append(PRECINTO_2_EIR);
			dynStr.Append("@CBA@PRECINTO_3_EIR=");
			dynStr.Append(PRECINTO_3_EIR);
			dynStr.Append("@CBA@PRECINTO_4_EIR=");
			dynStr.Append(PRECINTO_4_EIR);
			dynStr.Append("@CBA@PRECINTO_5_EIR=");
			dynStr.Append(PRECINTO_5_EIR);
			dynStr.Append("@CBA@PRECINTO_VENTILETE_EIR=");
			dynStr.Append(PRECINTO_VENTILETE_EIR);
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
			dynStr.Append("@CBA@OBSERVACIONES_EIR=");
			dynStr.Append(OBSERVACIONES_EIR);
			dynStr.Append("@CBA@DESCARTADO=");
			dynStr.Append(DESCARTADO);
			dynStr.Append("@CBA@ESTADO_CONTENEDOR=");
			dynStr.Append(ESTADO_CONTENEDOR);
			dynStr.Append("@CBA@PUERTO_ID=");
			dynStr.Append(IsPUERTO_IDNull ? (object)"<NULL>" : PUERTO_ID);
			dynStr.Append("@CBA@EIR_REFRIGERADO=");
			dynStr.Append(EIR_REFRIGERADO);
			dynStr.Append("@CBA@DESPACHO_FECHA=");
			dynStr.Append(IsDESPACHO_FECHANull ? (object)"<NULL>" : DESPACHO_FECHA);
			dynStr.Append("@CBA@FACTURA_NUMERO=");
			dynStr.Append(FACTURA_NUMERO);
			dynStr.Append("@CBA@DESPACHO_NUMERO=");
			dynStr.Append(DESPACHO_NUMERO);
			dynStr.Append("@CBA@DANADO=");
			dynStr.Append(DANADO);
			dynStr.Append("@CBA@DANO_INFORMADO=");
			dynStr.Append(DANO_INFORMADO);
			return dynStr.ToString();
		}
	} // End of PRE_EMBARQUE_CONTENEDORRow_Base class
} // End of namespace
