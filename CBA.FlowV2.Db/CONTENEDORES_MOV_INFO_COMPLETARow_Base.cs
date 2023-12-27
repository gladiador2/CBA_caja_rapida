// <fileinfo name="CONTENEDORES_MOV_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CONTENEDORES_MOV_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_MOV_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private System.DateTime _fecha_movimiento;
		private System.DateTime _fecha_insercion;
		private string _tipo_movimiento;
		private decimal _movimiento_id;
		private bool _movimiento_idNull = true;
		private string _comprobante_movimiento;
		private decimal _ordenacion;
		private bool _ordenacionNull = true;
		private string _estado;
		private string _en_predio;
		private string _estado_final;
		private decimal _usuario_id;
		private string _movimiento_usuario;
		private decimal _contenedor_id;
		private string _contenedor_numero;
		private string _contenedor_linea;
		private string _contenedor_agencia;
		private string _contenedor_tipo;
		private string _bloqueado;
		private string _precinto_1;
		private string _precinto_2;
		private string _precinto_3;
		private string _precinto_4;
		private string _precinto_5;
		private string _precinto_ventilete;
		private string _buque;
		private string _bl;
		private string _booking;
		private string _cliente;
		private string _nro_viaje;
		private string _puerto;
		private decimal _peso;
		private bool _pesoNull = true;
		private decimal _tara;
		private bool _taraNull = true;
		private decimal _setpoint;
		private bool _setpointNull = true;
		private decimal _payload;
		private bool _payloadNull = true;
		private string _eir_piso;
		private string _eir_fondo;
		private string _eir_techo;
		private string _eir_panel_derecho;
		private string _eir_panel_izquierdo;
		private string _eir_puerta;
		private string _eir_refrigerado;
		private string _observaciones;
		private string _clase;
		private string _mercaderias;
		private string _danado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_MOV_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CONTENEDORES_MOV_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTENEDORES_MOV_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.TIPO_MOVIMIENTO != original.TIPO_MOVIMIENTO) return true;
			if (this.IsMOVIMIENTO_IDNull != original.IsMOVIMIENTO_IDNull) return true;
			if (!this.IsMOVIMIENTO_IDNull && !original.IsMOVIMIENTO_IDNull)
				if (this.MOVIMIENTO_ID != original.MOVIMIENTO_ID) return true;
			if (this.COMPROBANTE_MOVIMIENTO != original.COMPROBANTE_MOVIMIENTO) return true;
			if (this.IsORDENACIONNull != original.IsORDENACIONNull) return true;
			if (!this.IsORDENACIONNull && !original.IsORDENACIONNull)
				if (this.ORDENACION != original.ORDENACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.EN_PREDIO != original.EN_PREDIO) return true;
			if (this.ESTADO_FINAL != original.ESTADO_FINAL) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.MOVIMIENTO_USUARIO != original.MOVIMIENTO_USUARIO) return true;
			if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.CONTENEDOR_LINEA != original.CONTENEDOR_LINEA) return true;
			if (this.CONTENEDOR_AGENCIA != original.CONTENEDOR_AGENCIA) return true;
			if (this.CONTENEDOR_TIPO != original.CONTENEDOR_TIPO) return true;
			if (this.BLOQUEADO != original.BLOQUEADO) return true;
			if (this.PRECINTO_1 != original.PRECINTO_1) return true;
			if (this.PRECINTO_2 != original.PRECINTO_2) return true;
			if (this.PRECINTO_3 != original.PRECINTO_3) return true;
			if (this.PRECINTO_4 != original.PRECINTO_4) return true;
			if (this.PRECINTO_5 != original.PRECINTO_5) return true;
			if (this.PRECINTO_VENTILETE != original.PRECINTO_VENTILETE) return true;
			if (this.BUQUE != original.BUQUE) return true;
			if (this.BL != original.BL) return true;
			if (this.BOOKING != original.BOOKING) return true;
			if (this.CLIENTE != original.CLIENTE) return true;
			if (this.NRO_VIAJE != original.NRO_VIAJE) return true;
			if (this.PUERTO != original.PUERTO) return true;
			if (this.IsPESONull != original.IsPESONull) return true;
			if (!this.IsPESONull && !original.IsPESONull)
				if (this.PESO != original.PESO) return true;
			if (this.IsTARANull != original.IsTARANull) return true;
			if (!this.IsTARANull && !original.IsTARANull)
				if (this.TARA != original.TARA) return true;
			if (this.IsSETPOINTNull != original.IsSETPOINTNull) return true;
			if (!this.IsSETPOINTNull && !original.IsSETPOINTNull)
				if (this.SETPOINT != original.SETPOINT) return true;
			if (this.IsPAYLOADNull != original.IsPAYLOADNull) return true;
			if (!this.IsPAYLOADNull && !original.IsPAYLOADNull)
				if (this.PAYLOAD != original.PAYLOAD) return true;
			if (this.EIR_PISO != original.EIR_PISO) return true;
			if (this.EIR_FONDO != original.EIR_FONDO) return true;
			if (this.EIR_TECHO != original.EIR_TECHO) return true;
			if (this.EIR_PANEL_DERECHO != original.EIR_PANEL_DERECHO) return true;
			if (this.EIR_PANEL_IZQUIERDO != original.EIR_PANEL_IZQUIERDO) return true;
			if (this.EIR_PUERTA != original.EIR_PUERTA) return true;
			if (this.EIR_REFRIGERADO != original.EIR_REFRIGERADO) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.CLASE != original.CLASE) return true;
			if (this.MERCADERIAS != original.MERCADERIAS) return true;
			if (this.DANADO != original.DANADO) return true;
			
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
		/// Gets or sets the <c>FECHA_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MOVIMIENTO</c> column value.</value>
		public System.DateTime FECHA_MOVIMIENTO
		{
			get { return _fecha_movimiento; }
			set { _fecha_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get { return _fecha_insercion; }
			set { _fecha_insercion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO</c> column value.</value>
		public string TIPO_MOVIMIENTO
		{
			get { return _tipo_movimiento; }
			set { _tipo_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOVIMIENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_ID</c> column value.</value>
		public decimal MOVIMIENTO_ID
		{
			get
			{
				if(IsMOVIMIENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_id;
			}
			set
			{
				_movimiento_idNull = false;
				_movimiento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_IDNull
		{
			get { return _movimiento_idNull; }
			set { _movimiento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMPROBANTE_MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMPROBANTE_MOVIMIENTO</c> column value.</value>
		public string COMPROBANTE_MOVIMIENTO
		{
			get { return _comprobante_movimiento; }
			set { _comprobante_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDENACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDENACION</c> column value.</value>
		public decimal ORDENACION
		{
			get
			{
				if(IsORDENACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ordenacion;
			}
			set
			{
				_ordenacionNull = false;
				_ordenacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDENACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENACIONNull
		{
			get { return _ordenacionNull; }
			set { _ordenacionNull = value; }
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
		/// Gets or sets the <c>EN_PREDIO</c> column value.
		/// </summary>
		/// <value>The <c>EN_PREDIO</c> column value.</value>
		public string EN_PREDIO
		{
			get { return _en_predio; }
			set { _en_predio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_FINAL</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_FINAL</c> column value.</value>
		public string ESTADO_FINAL
		{
			get { return _estado_final; }
			set { _estado_final = value; }
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
		/// Gets or sets the <c>MOVIMIENTO_USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_USUARIO</c> column value.</value>
		public string MOVIMIENTO_USUARIO
		{
			get { return _movimiento_usuario; }
			set { _movimiento_usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ID</c> column value.</value>
		public decimal CONTENEDOR_ID
		{
			get { return _contenedor_id; }
			set { _contenedor_id = value; }
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
		/// Gets or sets the <c>CONTENEDOR_AGENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_AGENCIA</c> column value.</value>
		public string CONTENEDOR_AGENCIA
		{
			get { return _contenedor_agencia; }
			set { _contenedor_agencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_TIPO</c> column value.
		/// </summary>
		/// <value>The <c>CONTENEDOR_TIPO</c> column value.</value>
		public string CONTENEDOR_TIPO
		{
			get { return _contenedor_tipo; }
			set { _contenedor_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BLOQUEADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BLOQUEADO</c> column value.</value>
		public string BLOQUEADO
		{
			get { return _bloqueado; }
			set { _bloqueado = value; }
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
		/// Gets or sets the <c>BUQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BUQUE</c> column value.</value>
		public string BUQUE
		{
			get { return _buque; }
			set { _buque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BL</c> column value.</value>
		public string BL
		{
			get { return _bl; }
			set { _bl = value; }
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
		/// Gets or sets the <c>CLIENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLIENTE</c> column value.</value>
		public string CLIENTE
		{
			get { return _cliente; }
			set { _cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_VIAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_VIAJE</c> column value.</value>
		public string NRO_VIAJE
		{
			get { return _nro_viaje; }
			set { _nro_viaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO</c> column value.</value>
		public string PUERTO
		{
			get { return _puerto; }
			set { _puerto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO</c> column value.</value>
		public decimal PESO
		{
			get
			{
				if(IsPESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso;
			}
			set
			{
				_pesoNull = false;
				_peso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESONull
		{
			get { return _pesoNull; }
			set { _pesoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA</c> column value.</value>
		public decimal TARA
		{
			get
			{
				if(IsTARANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara;
			}
			set
			{
				_taraNull = false;
				_tara = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARANull
		{
			get { return _taraNull; }
			set { _taraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SETPOINT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SETPOINT</c> column value.</value>
		public decimal SETPOINT
		{
			get
			{
				if(IsSETPOINTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _setpoint;
			}
			set
			{
				_setpointNull = false;
				_setpoint = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SETPOINT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSETPOINTNull
		{
			get { return _setpointNull; }
			set { _setpointNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAYLOAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAYLOAD</c> column value.</value>
		public decimal PAYLOAD
		{
			get
			{
				if(IsPAYLOADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _payload;
			}
			set
			{
				_payloadNull = false;
				_payload = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAYLOAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAYLOADNull
		{
			get { return _payloadNull; }
			set { _payloadNull = value; }
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
		/// Gets or sets the <c>CLASE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CLASE</c> column value.</value>
		public string CLASE
		{
			get { return _clase; }
			set { _clase = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO=");
			dynStr.Append(TIPO_MOVIMIENTO);
			dynStr.Append("@CBA@MOVIMIENTO_ID=");
			dynStr.Append(IsMOVIMIENTO_IDNull ? (object)"<NULL>" : MOVIMIENTO_ID);
			dynStr.Append("@CBA@COMPROBANTE_MOVIMIENTO=");
			dynStr.Append(COMPROBANTE_MOVIMIENTO);
			dynStr.Append("@CBA@ORDENACION=");
			dynStr.Append(IsORDENACIONNull ? (object)"<NULL>" : ORDENACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@EN_PREDIO=");
			dynStr.Append(EN_PREDIO);
			dynStr.Append("@CBA@ESTADO_FINAL=");
			dynStr.Append(ESTADO_FINAL);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@MOVIMIENTO_USUARIO=");
			dynStr.Append(MOVIMIENTO_USUARIO);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(CONTENEDOR_ID);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@CONTENEDOR_LINEA=");
			dynStr.Append(CONTENEDOR_LINEA);
			dynStr.Append("@CBA@CONTENEDOR_AGENCIA=");
			dynStr.Append(CONTENEDOR_AGENCIA);
			dynStr.Append("@CBA@CONTENEDOR_TIPO=");
			dynStr.Append(CONTENEDOR_TIPO);
			dynStr.Append("@CBA@BLOQUEADO=");
			dynStr.Append(BLOQUEADO);
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
			dynStr.Append("@CBA@BUQUE=");
			dynStr.Append(BUQUE);
			dynStr.Append("@CBA@BL=");
			dynStr.Append(BL);
			dynStr.Append("@CBA@BOOKING=");
			dynStr.Append(BOOKING);
			dynStr.Append("@CBA@CLIENTE=");
			dynStr.Append(CLIENTE);
			dynStr.Append("@CBA@NRO_VIAJE=");
			dynStr.Append(NRO_VIAJE);
			dynStr.Append("@CBA@PUERTO=");
			dynStr.Append(PUERTO);
			dynStr.Append("@CBA@PESO=");
			dynStr.Append(IsPESONull ? (object)"<NULL>" : PESO);
			dynStr.Append("@CBA@TARA=");
			dynStr.Append(IsTARANull ? (object)"<NULL>" : TARA);
			dynStr.Append("@CBA@SETPOINT=");
			dynStr.Append(IsSETPOINTNull ? (object)"<NULL>" : SETPOINT);
			dynStr.Append("@CBA@PAYLOAD=");
			dynStr.Append(IsPAYLOADNull ? (object)"<NULL>" : PAYLOAD);
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
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@CLASE=");
			dynStr.Append(CLASE);
			dynStr.Append("@CBA@MERCADERIAS=");
			dynStr.Append(MERCADERIAS);
			dynStr.Append("@CBA@DANADO=");
			dynStr.Append(DANADO);
			return dynStr.ToString();
		}
	} // End of CONTENEDORES_MOV_INFO_COMPLETARow_Base class
} // End of namespace
