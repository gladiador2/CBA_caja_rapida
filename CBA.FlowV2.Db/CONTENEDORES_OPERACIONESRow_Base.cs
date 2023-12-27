// <fileinfo name="CONTENEDORES_OPERACIONESRow_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_OPERACIONESRow"/> that 
	/// represents a record in the <c>CONTENEDORES_OPERACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTENEDORES_OPERACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_OPERACIONESRow_Base
	{
		private decimal _id;
		private string _operacion;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private System.DateTime _hora_inicio;
		private bool _hora_inicioNull = true;
		private System.DateTime _hora_fin;
		private bool _hora_finNull = true;
		private string _nro_formulario;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private decimal _linea_id;
		private bool _linea_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _bl_nro;
		private string _booking;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _clasificacion_id;
		private decimal _item;
		private bool _itemNull = true;
		private string _mercaderia_interna;
		private string _precinto_1;
		private string _precinto_2;
		private string _precinto_3;
		private string _precinto_4;
		private string _precinto_5;
		private string _edi;
		private string _estado;
		private string _procesado;
		private string _observacion;
		private string _ventilete;
		private decimal _peso_bruto;
		private bool _peso_brutoNull = true;
		private decimal _tara_camion;
		private bool _tara_camionNull = true;
		private decimal _peso_neto;
		private bool _peso_netoNull = true;
		private decimal _tara_contenedor;
		private bool _tara_contenedorNull = true;
		private string _piso;
		private string _fondo;
		private string _techo;
		private string _panel_derecho;
		private string _panel_izquierdo;
		private string _puerta;
		private string _refrigerado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_OPERACIONESRow_Base"/> class.
		/// </summary>
		public CONTENEDORES_OPERACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTENEDORES_OPERACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.OPERACION != original.OPERACION) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsHORA_INICIONull != original.IsHORA_INICIONull) return true;
			if (!this.IsHORA_INICIONull && !original.IsHORA_INICIONull)
				if (this.HORA_INICIO != original.HORA_INICIO) return true;
			if (this.IsHORA_FINNull != original.IsHORA_FINNull) return true;
			if (!this.IsHORA_FINNull && !original.IsHORA_FINNull)
				if (this.HORA_FIN != original.HORA_FIN) return true;
			if (this.NRO_FORMULARIO != original.NRO_FORMULARIO) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.IsLINEA_IDNull != original.IsLINEA_IDNull) return true;
			if (!this.IsLINEA_IDNull && !original.IsLINEA_IDNull)
				if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.BL_NRO != original.BL_NRO) return true;
			if (this.BOOKING != original.BOOKING) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.CLASIFICACION_ID != original.CLASIFICACION_ID) return true;
			if (this.IsITEMNull != original.IsITEMNull) return true;
			if (!this.IsITEMNull && !original.IsITEMNull)
				if (this.ITEM != original.ITEM) return true;
			if (this.MERCADERIA_INTERNA != original.MERCADERIA_INTERNA) return true;
			if (this.PRECINTO_1 != original.PRECINTO_1) return true;
			if (this.PRECINTO_2 != original.PRECINTO_2) return true;
			if (this.PRECINTO_3 != original.PRECINTO_3) return true;
			if (this.PRECINTO_4 != original.PRECINTO_4) return true;
			if (this.PRECINTO_5 != original.PRECINTO_5) return true;
			if (this.EDI != original.EDI) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.PROCESADO != original.PROCESADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.VENTILETE != original.VENTILETE) return true;
			if (this.IsPESO_BRUTONull != original.IsPESO_BRUTONull) return true;
			if (!this.IsPESO_BRUTONull && !original.IsPESO_BRUTONull)
				if (this.PESO_BRUTO != original.PESO_BRUTO) return true;
			if (this.IsTARA_CAMIONNull != original.IsTARA_CAMIONNull) return true;
			if (!this.IsTARA_CAMIONNull && !original.IsTARA_CAMIONNull)
				if (this.TARA_CAMION != original.TARA_CAMION) return true;
			if (this.IsPESO_NETONull != original.IsPESO_NETONull) return true;
			if (!this.IsPESO_NETONull && !original.IsPESO_NETONull)
				if (this.PESO_NETO != original.PESO_NETO) return true;
			if (this.IsTARA_CONTENEDORNull != original.IsTARA_CONTENEDORNull) return true;
			if (!this.IsTARA_CONTENEDORNull && !original.IsTARA_CONTENEDORNull)
				if (this.TARA_CONTENEDOR != original.TARA_CONTENEDOR) return true;
			if (this.PISO != original.PISO) return true;
			if (this.FONDO != original.FONDO) return true;
			if (this.TECHO != original.TECHO) return true;
			if (this.PANEL_DERECHO != original.PANEL_DERECHO) return true;
			if (this.PANEL_IZQUIERDO != original.PANEL_IZQUIERDO) return true;
			if (this.PUERTA != original.PUERTA) return true;
			if (this.REFRIGERADO != original.REFRIGERADO) return true;
			
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
		/// Gets or sets the <c>OPERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERACION</c> column value.</value>
		public string OPERACION
		{
			get { return _operacion; }
			set { _operacion = value; }
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
		/// Gets or sets the <c>HORA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HORA_INICIO</c> column value.</value>
		public System.DateTime HORA_INICIO
		{
			get
			{
				if(IsHORA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _hora_inicio;
			}
			set
			{
				_hora_inicioNull = false;
				_hora_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HORA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHORA_INICIONull
		{
			get { return _hora_inicioNull; }
			set { _hora_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HORA_FIN</c> column value.</value>
		public System.DateTime HORA_FIN
		{
			get
			{
				if(IsHORA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _hora_fin;
			}
			set
			{
				_hora_finNull = false;
				_hora_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HORA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHORA_FINNull
		{
			get { return _hora_finNull; }
			set { _hora_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_FORMULARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_FORMULARIO</c> column value.</value>
		public string NRO_FORMULARIO
		{
			get { return _nro_formulario; }
			set { _nro_formulario = value; }
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
		/// Gets or sets the <c>BL_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BL_NRO</c> column value.</value>
		public string BL_NRO
		{
			get { return _bl_nro; }
			set { _bl_nro = value; }
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
		/// Gets or sets the <c>CLASIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLASIFICACION_ID</c> column value.</value>
		public string CLASIFICACION_ID
		{
			get { return _clasificacion_id; }
			set { _clasificacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ITEM</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEM</c> column value.</value>
		public decimal ITEM
		{
			get
			{
				if(IsITEMNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _item;
			}
			set
			{
				_itemNull = false;
				_item = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEM"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMNull
		{
			get { return _itemNull; }
			set { _itemNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIA_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIA_INTERNA</c> column value.</value>
		public string MERCADERIA_INTERNA
		{
			get { return _mercaderia_interna; }
			set { _mercaderia_interna = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCESADO</c> column value.</value>
		public string PROCESADO
		{
			get { return _procesado; }
			set { _procesado = value; }
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
		/// Gets or sets the <c>VENTILETE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENTILETE</c> column value.</value>
		public string VENTILETE
		{
			get { return _ventilete; }
			set { _ventilete = value; }
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
		/// Gets or sets the <c>PISO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PISO</c> column value.</value>
		public string PISO
		{
			get { return _piso; }
			set { _piso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FONDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FONDO</c> column value.</value>
		public string FONDO
		{
			get { return _fondo; }
			set { _fondo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TECHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TECHO</c> column value.</value>
		public string TECHO
		{
			get { return _techo; }
			set { _techo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PANEL_DERECHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PANEL_DERECHO</c> column value.</value>
		public string PANEL_DERECHO
		{
			get { return _panel_derecho; }
			set { _panel_derecho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PANEL_IZQUIERDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PANEL_IZQUIERDO</c> column value.</value>
		public string PANEL_IZQUIERDO
		{
			get { return _panel_izquierdo; }
			set { _panel_izquierdo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTA</c> column value.</value>
		public string PUERTA
		{
			get { return _puerta; }
			set { _puerta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REFRIGERADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REFRIGERADO</c> column value.</value>
		public string REFRIGERADO
		{
			get { return _refrigerado; }
			set { _refrigerado = value; }
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
			dynStr.Append("@CBA@OPERACION=");
			dynStr.Append(OPERACION);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@HORA_INICIO=");
			dynStr.Append(IsHORA_INICIONull ? (object)"<NULL>" : HORA_INICIO);
			dynStr.Append("@CBA@HORA_FIN=");
			dynStr.Append(IsHORA_FINNull ? (object)"<NULL>" : HORA_FIN);
			dynStr.Append("@CBA@NRO_FORMULARIO=");
			dynStr.Append(NRO_FORMULARIO);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(IsLINEA_IDNull ? (object)"<NULL>" : LINEA_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@BL_NRO=");
			dynStr.Append(BL_NRO);
			dynStr.Append("@CBA@BOOKING=");
			dynStr.Append(BOOKING);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@CLASIFICACION_ID=");
			dynStr.Append(CLASIFICACION_ID);
			dynStr.Append("@CBA@ITEM=");
			dynStr.Append(IsITEMNull ? (object)"<NULL>" : ITEM);
			dynStr.Append("@CBA@MERCADERIA_INTERNA=");
			dynStr.Append(MERCADERIA_INTERNA);
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
			dynStr.Append("@CBA@EDI=");
			dynStr.Append(EDI);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@PROCESADO=");
			dynStr.Append(PROCESADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@VENTILETE=");
			dynStr.Append(VENTILETE);
			dynStr.Append("@CBA@PESO_BRUTO=");
			dynStr.Append(IsPESO_BRUTONull ? (object)"<NULL>" : PESO_BRUTO);
			dynStr.Append("@CBA@TARA_CAMION=");
			dynStr.Append(IsTARA_CAMIONNull ? (object)"<NULL>" : TARA_CAMION);
			dynStr.Append("@CBA@PESO_NETO=");
			dynStr.Append(IsPESO_NETONull ? (object)"<NULL>" : PESO_NETO);
			dynStr.Append("@CBA@TARA_CONTENEDOR=");
			dynStr.Append(IsTARA_CONTENEDORNull ? (object)"<NULL>" : TARA_CONTENEDOR);
			dynStr.Append("@CBA@PISO=");
			dynStr.Append(PISO);
			dynStr.Append("@CBA@FONDO=");
			dynStr.Append(FONDO);
			dynStr.Append("@CBA@TECHO=");
			dynStr.Append(TECHO);
			dynStr.Append("@CBA@PANEL_DERECHO=");
			dynStr.Append(PANEL_DERECHO);
			dynStr.Append("@CBA@PANEL_IZQUIERDO=");
			dynStr.Append(PANEL_IZQUIERDO);
			dynStr.Append("@CBA@PUERTA=");
			dynStr.Append(PUERTA);
			dynStr.Append("@CBA@REFRIGERADO=");
			dynStr.Append(REFRIGERADO);
			return dynStr.ToString();
		}
	} // End of CONTENEDORES_OPERACIONESRow_Base class
} // End of namespace
