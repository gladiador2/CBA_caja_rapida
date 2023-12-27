// <fileinfo name="REFI_DEUDAS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="REFI_DEUDAS_INFO_COMPRow"/> that 
	/// represents a record in the <c>REFI_DEUDAS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REFI_DEUDAS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REFI_DEUDAS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _persona_id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _nro_comprobante_externo;
		private decimal _caso_refinanciado_id;
		private decimal _monto_cuota_propuesto;
		private bool _monto_cuota_propuestoNull = true;
		private decimal _entrega_inicial;
		private bool _entrega_inicialNull = true;
		private string _es_recalendarizacion;
		private decimal _personas_estado_morosidad_id;
		private bool _personas_estado_morosidad_idNull = true;
		private System.DateTime _fecha_primer_vencimiento;
		private bool _fecha_primer_vencimientoNull = true;
		private string _estado_morosidad;
		private string _persona_codigo;
		private string _persona_nombre_completo;
		private string _caso_estado_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private string _moneda_cadena_decimales;

		/// <summary>
		/// Initializes a new instance of the <see cref="REFI_DEUDAS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public REFI_DEUDAS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REFI_DEUDAS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.NRO_COMPROBANTE_EXTERNO != original.NRO_COMPROBANTE_EXTERNO) return true;
			if (this.CASO_REFINANCIADO_ID != original.CASO_REFINANCIADO_ID) return true;
			if (this.IsMONTO_CUOTA_PROPUESTONull != original.IsMONTO_CUOTA_PROPUESTONull) return true;
			if (!this.IsMONTO_CUOTA_PROPUESTONull && !original.IsMONTO_CUOTA_PROPUESTONull)
				if (this.MONTO_CUOTA_PROPUESTO != original.MONTO_CUOTA_PROPUESTO) return true;
			if (this.IsENTREGA_INICIALNull != original.IsENTREGA_INICIALNull) return true;
			if (!this.IsENTREGA_INICIALNull && !original.IsENTREGA_INICIALNull)
				if (this.ENTREGA_INICIAL != original.ENTREGA_INICIAL) return true;
			if (this.ES_RECALENDARIZACION != original.ES_RECALENDARIZACION) return true;
			if (this.IsPERSONAS_ESTADO_MOROSIDAD_IDNull != original.IsPERSONAS_ESTADO_MOROSIDAD_IDNull) return true;
			if (!this.IsPERSONAS_ESTADO_MOROSIDAD_IDNull && !original.IsPERSONAS_ESTADO_MOROSIDAD_IDNull)
				if (this.PERSONAS_ESTADO_MOROSIDAD_ID != original.PERSONAS_ESTADO_MOROSIDAD_ID) return true;
			if (this.IsFECHA_PRIMER_VENCIMIENTONull != original.IsFECHA_PRIMER_VENCIMIENTONull) return true;
			if (!this.IsFECHA_PRIMER_VENCIMIENTONull && !original.IsFECHA_PRIMER_VENCIMIENTONull)
				if (this.FECHA_PRIMER_VENCIMIENTO != original.FECHA_PRIMER_VENCIMIENTO) return true;
			if (this.ESTADO_MOROSIDAD != original.ESTADO_MOROSIDAD) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			
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
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
		/// Gets or sets the <c>NRO_COMPROBANTE_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_EXTERNO</c> column value.</value>
		public string NRO_COMPROBANTE_EXTERNO
		{
			get { return _nro_comprobante_externo; }
			set { _nro_comprobante_externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_REFINANCIADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_REFINANCIADO_ID</c> column value.</value>
		public decimal CASO_REFINANCIADO_ID
		{
			get { return _caso_refinanciado_id; }
			set { _caso_refinanciado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CUOTA_PROPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CUOTA_PROPUESTO</c> column value.</value>
		public decimal MONTO_CUOTA_PROPUESTO
		{
			get
			{
				if(IsMONTO_CUOTA_PROPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_cuota_propuesto;
			}
			set
			{
				_monto_cuota_propuestoNull = false;
				_monto_cuota_propuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CUOTA_PROPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CUOTA_PROPUESTONull
		{
			get { return _monto_cuota_propuestoNull; }
			set { _monto_cuota_propuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTREGA_INICIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTREGA_INICIAL</c> column value.</value>
		public decimal ENTREGA_INICIAL
		{
			get
			{
				if(IsENTREGA_INICIALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _entrega_inicial;
			}
			set
			{
				_entrega_inicialNull = false;
				_entrega_inicial = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENTREGA_INICIAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENTREGA_INICIALNull
		{
			get { return _entrega_inicialNull; }
			set { _entrega_inicialNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_RECALENDARIZACION</c> column value.
		/// </summary>
		/// <value>The <c>ES_RECALENDARIZACION</c> column value.</value>
		public string ES_RECALENDARIZACION
		{
			get { return _es_recalendarizacion; }
			set { _es_recalendarizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONAS_ESTADO_MOROSIDAD_ID</c> column value.</value>
		public decimal PERSONAS_ESTADO_MOROSIDAD_ID
		{
			get
			{
				if(IsPERSONAS_ESTADO_MOROSIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _personas_estado_morosidad_id;
			}
			set
			{
				_personas_estado_morosidad_idNull = false;
				_personas_estado_morosidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONAS_ESTADO_MOROSIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONAS_ESTADO_MOROSIDAD_IDNull
		{
			get { return _personas_estado_morosidad_idNull; }
			set { _personas_estado_morosidad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PRIMER_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_PRIMER_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_PRIMER_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_PRIMER_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_primer_vencimiento;
			}
			set
			{
				_fecha_primer_vencimientoNull = false;
				_fecha_primer_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_PRIMER_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_PRIMER_VENCIMIENTONull
		{
			get { return _fecha_primer_vencimientoNull; }
			set { _fecha_primer_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_MOROSIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_MOROSIDAD</c> column value.</value>
		public string ESTADO_MOROSIDAD
		{
			get { return _estado_morosidad; }
			set { _estado_morosidad = value; }
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
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_CADENA_DECIMALES
		{
			get { return _moneda_cadena_decimales; }
			set { _moneda_cadena_decimales = value; }
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
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NRO_COMPROBANTE_EXTERNO=");
			dynStr.Append(NRO_COMPROBANTE_EXTERNO);
			dynStr.Append("@CBA@CASO_REFINANCIADO_ID=");
			dynStr.Append(CASO_REFINANCIADO_ID);
			dynStr.Append("@CBA@MONTO_CUOTA_PROPUESTO=");
			dynStr.Append(IsMONTO_CUOTA_PROPUESTONull ? (object)"<NULL>" : MONTO_CUOTA_PROPUESTO);
			dynStr.Append("@CBA@ENTREGA_INICIAL=");
			dynStr.Append(IsENTREGA_INICIALNull ? (object)"<NULL>" : ENTREGA_INICIAL);
			dynStr.Append("@CBA@ES_RECALENDARIZACION=");
			dynStr.Append(ES_RECALENDARIZACION);
			dynStr.Append("@CBA@PERSONAS_ESTADO_MOROSIDAD_ID=");
			dynStr.Append(IsPERSONAS_ESTADO_MOROSIDAD_IDNull ? (object)"<NULL>" : PERSONAS_ESTADO_MOROSIDAD_ID);
			dynStr.Append("@CBA@FECHA_PRIMER_VENCIMIENTO=");
			dynStr.Append(IsFECHA_PRIMER_VENCIMIENTONull ? (object)"<NULL>" : FECHA_PRIMER_VENCIMIENTO);
			dynStr.Append("@CBA@ESTADO_MOROSIDAD=");
			dynStr.Append(ESTADO_MOROSIDAD);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			return dynStr.ToString();
		}
	} // End of REFI_DEUDAS_INFO_COMPRow_Base class
} // End of namespace
