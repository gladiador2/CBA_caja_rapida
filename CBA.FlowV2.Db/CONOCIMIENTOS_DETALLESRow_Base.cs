// <fileinfo name="CONOCIMIENTOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="CONOCIMIENTOS_DETALLESRow"/> that 
	/// represents a record in the <c>CONOCIMIENTOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONOCIMIENTOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONOCIMIENTOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _conocimiento_id;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private string _set_point;
		private decimal _peso_manifiesto;
		private bool _peso_manifiestoNull = true;
		private string _vaciamiento;
		private string _traslado;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _servicio_externo;
		private string _fcl_lcl;
		private string _observaciones_concimiento;
		private string _precinto_1;
		private string _precinto_2;
		private string _precinto_3;
		private string _precinto_4;
		private string _precinto_5;
		private string _ingresado;
		private string _estado_contenedor;
		private decimal _categoria_imo_id;
		private bool _categoria_imo_idNull = true;
		private decimal _lineas_id;
		private bool _lineas_idNull = true;
		private decimal _conocimientos_contenido_id;
		private bool _conocimientos_contenido_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _payload_eir;
		private bool _payload_eirNull = true;
		private decimal _tara_eir;
		private bool _tara_eirNull = true;
		private System.DateTime _hora_eir;
		private bool _hora_eirNull = true;
		private string _precinto_ventilete;
		private string _observaciones_eir;
		private string _temperatura_eir;
		private string _edi;
		private string _edi_anulado;
		private string _edi_armador;
		private string _procesado_eir;
		private decimal _intercambio_equipo_id;
		private bool _intercambio_equipo_idNull = true;
		private string _precinto_1_eir;
		private string _precinto_2_eir;
		private string _precinto_3_eir;
		private string _precinto_4_eir;
		private string _precinto_5_eir;
		private string _precinto_ventilete_eir;
		private string _descartado;
		private string _eir_piso;
		private string _eir_fondo;
		private string _eir_techo;
		private string _eir_panel_derecho;
		private string _eir_panel_izquierdo;
		private string _eir_puerta;
		private decimal _puerto_id;
		private bool _puerto_idNull = true;
		private string _eir_refrigerado;
		private string _danado;
		private string _dano_informado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONOCIMIENTOS_DETALLESRow_Base"/> class.
		/// </summary>
		public CONOCIMIENTOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONOCIMIENTOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CONOCIMIENTO_ID != original.CONOCIMIENTO_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.SET_POINT != original.SET_POINT) return true;
			if (this.IsPESO_MANIFIESTONull != original.IsPESO_MANIFIESTONull) return true;
			if (!this.IsPESO_MANIFIESTONull && !original.IsPESO_MANIFIESTONull)
				if (this.PESO_MANIFIESTO != original.PESO_MANIFIESTO) return true;
			if (this.VACIAMIENTO != original.VACIAMIENTO) return true;
			if (this.TRASLADO != original.TRASLADO) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.SERVICIO_EXTERNO != original.SERVICIO_EXTERNO) return true;
			if (this.FCL_LCL != original.FCL_LCL) return true;
			if (this.OBSERVACIONES_CONCIMIENTO != original.OBSERVACIONES_CONCIMIENTO) return true;
			if (this.PRECINTO_1 != original.PRECINTO_1) return true;
			if (this.PRECINTO_2 != original.PRECINTO_2) return true;
			if (this.PRECINTO_3 != original.PRECINTO_3) return true;
			if (this.PRECINTO_4 != original.PRECINTO_4) return true;
			if (this.PRECINTO_5 != original.PRECINTO_5) return true;
			if (this.INGRESADO != original.INGRESADO) return true;
			if (this.ESTADO_CONTENEDOR != original.ESTADO_CONTENEDOR) return true;
			if (this.IsCATEGORIA_IMO_IDNull != original.IsCATEGORIA_IMO_IDNull) return true;
			if (!this.IsCATEGORIA_IMO_IDNull && !original.IsCATEGORIA_IMO_IDNull)
				if (this.CATEGORIA_IMO_ID != original.CATEGORIA_IMO_ID) return true;
			if (this.IsLINEAS_IDNull != original.IsLINEAS_IDNull) return true;
			if (!this.IsLINEAS_IDNull && !original.IsLINEAS_IDNull)
				if (this.LINEAS_ID != original.LINEAS_ID) return true;
			if (this.IsCONOCIMIENTOS_CONTENIDO_IDNull != original.IsCONOCIMIENTOS_CONTENIDO_IDNull) return true;
			if (!this.IsCONOCIMIENTOS_CONTENIDO_IDNull && !original.IsCONOCIMIENTOS_CONTENIDO_IDNull)
				if (this.CONOCIMIENTOS_CONTENIDO_ID != original.CONOCIMIENTOS_CONTENIDO_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsPAYLOAD_EIRNull != original.IsPAYLOAD_EIRNull) return true;
			if (!this.IsPAYLOAD_EIRNull && !original.IsPAYLOAD_EIRNull)
				if (this.PAYLOAD_EIR != original.PAYLOAD_EIR) return true;
			if (this.IsTARA_EIRNull != original.IsTARA_EIRNull) return true;
			if (!this.IsTARA_EIRNull && !original.IsTARA_EIRNull)
				if (this.TARA_EIR != original.TARA_EIR) return true;
			if (this.IsHORA_EIRNull != original.IsHORA_EIRNull) return true;
			if (!this.IsHORA_EIRNull && !original.IsHORA_EIRNull)
				if (this.HORA_EIR != original.HORA_EIR) return true;
			if (this.PRECINTO_VENTILETE != original.PRECINTO_VENTILETE) return true;
			if (this.OBSERVACIONES_EIR != original.OBSERVACIONES_EIR) return true;
			if (this.TEMPERATURA_EIR != original.TEMPERATURA_EIR) return true;
			if (this.EDI != original.EDI) return true;
			if (this.EDI_ANULADO != original.EDI_ANULADO) return true;
			if (this.EDI_ARMADOR != original.EDI_ARMADOR) return true;
			if (this.PROCESADO_EIR != original.PROCESADO_EIR) return true;
			if (this.IsINTERCAMBIO_EQUIPO_IDNull != original.IsINTERCAMBIO_EQUIPO_IDNull) return true;
			if (!this.IsINTERCAMBIO_EQUIPO_IDNull && !original.IsINTERCAMBIO_EQUIPO_IDNull)
				if (this.INTERCAMBIO_EQUIPO_ID != original.INTERCAMBIO_EQUIPO_ID) return true;
			if (this.PRECINTO_1_EIR != original.PRECINTO_1_EIR) return true;
			if (this.PRECINTO_2_EIR != original.PRECINTO_2_EIR) return true;
			if (this.PRECINTO_3_EIR != original.PRECINTO_3_EIR) return true;
			if (this.PRECINTO_4_EIR != original.PRECINTO_4_EIR) return true;
			if (this.PRECINTO_5_EIR != original.PRECINTO_5_EIR) return true;
			if (this.PRECINTO_VENTILETE_EIR != original.PRECINTO_VENTILETE_EIR) return true;
			if (this.DESCARTADO != original.DESCARTADO) return true;
			if (this.EIR_PISO != original.EIR_PISO) return true;
			if (this.EIR_FONDO != original.EIR_FONDO) return true;
			if (this.EIR_TECHO != original.EIR_TECHO) return true;
			if (this.EIR_PANEL_DERECHO != original.EIR_PANEL_DERECHO) return true;
			if (this.EIR_PANEL_IZQUIERDO != original.EIR_PANEL_IZQUIERDO) return true;
			if (this.EIR_PUERTA != original.EIR_PUERTA) return true;
			if (this.IsPUERTO_IDNull != original.IsPUERTO_IDNull) return true;
			if (!this.IsPUERTO_IDNull && !original.IsPUERTO_IDNull)
				if (this.PUERTO_ID != original.PUERTO_ID) return true;
			if (this.EIR_REFRIGERADO != original.EIR_REFRIGERADO) return true;
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
		/// Gets or sets the <c>CONOCIMIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO_ID</c> column value.</value>
		public decimal CONOCIMIENTO_ID
		{
			get { return _conocimiento_id; }
			set { _conocimiento_id = value; }
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
		/// Gets or sets the <c>PESO_MANIFIESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_MANIFIESTO</c> column value.</value>
		public decimal PESO_MANIFIESTO
		{
			get
			{
				if(IsPESO_MANIFIESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_manifiesto;
			}
			set
			{
				_peso_manifiestoNull = false;
				_peso_manifiesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_MANIFIESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_MANIFIESTONull
		{
			get { return _peso_manifiestoNull; }
			set { _peso_manifiestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VACIAMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VACIAMIENTO</c> column value.</value>
		public string VACIAMIENTO
		{
			get { return _vaciamiento; }
			set { _vaciamiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRASLADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRASLADO</c> column value.</value>
		public string TRASLADO
		{
			get { return _traslado; }
			set { _traslado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SERVICIO_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SERVICIO_EXTERNO</c> column value.</value>
		public string SERVICIO_EXTERNO
		{
			get { return _servicio_externo; }
			set { _servicio_externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FCL_LCL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FCL_LCL</c> column value.</value>
		public string FCL_LCL
		{
			get { return _fcl_lcl; }
			set { _fcl_lcl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES_CONCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES_CONCIMIENTO</c> column value.</value>
		public string OBSERVACIONES_CONCIMIENTO
		{
			get { return _observaciones_concimiento; }
			set { _observaciones_concimiento = value; }
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
		/// Gets or sets the <c>INGRESADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESADO</c> column value.</value>
		public string INGRESADO
		{
			get { return _ingresado; }
			set { _ingresado = value; }
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
		/// Gets or sets the <c>CATEGORIA_IMO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CATEGORIA_IMO_ID</c> column value.</value>
		public decimal CATEGORIA_IMO_ID
		{
			get
			{
				if(IsCATEGORIA_IMO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _categoria_imo_id;
			}
			set
			{
				_categoria_imo_idNull = false;
				_categoria_imo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CATEGORIA_IMO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCATEGORIA_IMO_IDNull
		{
			get { return _categoria_imo_idNull; }
			set { _categoria_imo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEAS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LINEAS_ID</c> column value.</value>
		public decimal LINEAS_ID
		{
			get
			{
				if(IsLINEAS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lineas_id;
			}
			set
			{
				_lineas_idNull = false;
				_lineas_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LINEAS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLINEAS_IDNull
		{
			get { return _lineas_idNull; }
			set { _lineas_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTOS_CONTENIDO_ID</c> column value.</value>
		public decimal CONOCIMIENTOS_CONTENIDO_ID
		{
			get
			{
				if(IsCONOCIMIENTOS_CONTENIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conocimientos_contenido_id;
			}
			set
			{
				_conocimientos_contenido_idNull = false;
				_conocimientos_contenido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONOCIMIENTOS_CONTENIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONOCIMIENTOS_CONTENIDO_IDNull
		{
			get { return _conocimientos_contenido_idNull; }
			set { _conocimientos_contenido_idNull = value; }
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
		/// Gets or sets the <c>TEMPERATURA_EIR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEMPERATURA_EIR</c> column value.</value>
		public string TEMPERATURA_EIR
		{
			get { return _temperatura_eir; }
			set { _temperatura_eir = value; }
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
			dynStr.Append("@CBA@CONOCIMIENTO_ID=");
			dynStr.Append(CONOCIMIENTO_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@SET_POINT=");
			dynStr.Append(SET_POINT);
			dynStr.Append("@CBA@PESO_MANIFIESTO=");
			dynStr.Append(IsPESO_MANIFIESTONull ? (object)"<NULL>" : PESO_MANIFIESTO);
			dynStr.Append("@CBA@VACIAMIENTO=");
			dynStr.Append(VACIAMIENTO);
			dynStr.Append("@CBA@TRASLADO=");
			dynStr.Append(TRASLADO);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@SERVICIO_EXTERNO=");
			dynStr.Append(SERVICIO_EXTERNO);
			dynStr.Append("@CBA@FCL_LCL=");
			dynStr.Append(FCL_LCL);
			dynStr.Append("@CBA@OBSERVACIONES_CONCIMIENTO=");
			dynStr.Append(OBSERVACIONES_CONCIMIENTO);
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
			dynStr.Append("@CBA@INGRESADO=");
			dynStr.Append(INGRESADO);
			dynStr.Append("@CBA@ESTADO_CONTENEDOR=");
			dynStr.Append(ESTADO_CONTENEDOR);
			dynStr.Append("@CBA@CATEGORIA_IMO_ID=");
			dynStr.Append(IsCATEGORIA_IMO_IDNull ? (object)"<NULL>" : CATEGORIA_IMO_ID);
			dynStr.Append("@CBA@LINEAS_ID=");
			dynStr.Append(IsLINEAS_IDNull ? (object)"<NULL>" : LINEAS_ID);
			dynStr.Append("@CBA@CONOCIMIENTOS_CONTENIDO_ID=");
			dynStr.Append(IsCONOCIMIENTOS_CONTENIDO_IDNull ? (object)"<NULL>" : CONOCIMIENTOS_CONTENIDO_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@PAYLOAD_EIR=");
			dynStr.Append(IsPAYLOAD_EIRNull ? (object)"<NULL>" : PAYLOAD_EIR);
			dynStr.Append("@CBA@TARA_EIR=");
			dynStr.Append(IsTARA_EIRNull ? (object)"<NULL>" : TARA_EIR);
			dynStr.Append("@CBA@HORA_EIR=");
			dynStr.Append(IsHORA_EIRNull ? (object)"<NULL>" : HORA_EIR);
			dynStr.Append("@CBA@PRECINTO_VENTILETE=");
			dynStr.Append(PRECINTO_VENTILETE);
			dynStr.Append("@CBA@OBSERVACIONES_EIR=");
			dynStr.Append(OBSERVACIONES_EIR);
			dynStr.Append("@CBA@TEMPERATURA_EIR=");
			dynStr.Append(TEMPERATURA_EIR);
			dynStr.Append("@CBA@EDI=");
			dynStr.Append(EDI);
			dynStr.Append("@CBA@EDI_ANULADO=");
			dynStr.Append(EDI_ANULADO);
			dynStr.Append("@CBA@EDI_ARMADOR=");
			dynStr.Append(EDI_ARMADOR);
			dynStr.Append("@CBA@PROCESADO_EIR=");
			dynStr.Append(PROCESADO_EIR);
			dynStr.Append("@CBA@INTERCAMBIO_EQUIPO_ID=");
			dynStr.Append(IsINTERCAMBIO_EQUIPO_IDNull ? (object)"<NULL>" : INTERCAMBIO_EQUIPO_ID);
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
			dynStr.Append("@CBA@DESCARTADO=");
			dynStr.Append(DESCARTADO);
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
			dynStr.Append("@CBA@PUERTO_ID=");
			dynStr.Append(IsPUERTO_IDNull ? (object)"<NULL>" : PUERTO_ID);
			dynStr.Append("@CBA@EIR_REFRIGERADO=");
			dynStr.Append(EIR_REFRIGERADO);
			dynStr.Append("@CBA@DANADO=");
			dynStr.Append(DANADO);
			dynStr.Append("@CBA@DANO_INFORMADO=");
			dynStr.Append(DANO_INFORMADO);
			return dynStr.ToString();
		}
	} // End of CONOCIMIENTOS_DETALLESRow_Base class
} // End of namespace
