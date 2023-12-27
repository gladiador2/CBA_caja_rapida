// <fileinfo name="APLICACION_DOCUMEN_VAL_INFO_CORow_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMEN_VAL_INFO_CORow"/> that 
	/// represents a record in the <c>APLICACION_DOCUMEN_VAL_INFO_CO</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="APLICACION_DOCUMEN_VAL_INFO_CORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMEN_VAL_INFO_CORow_Base
	{
		private decimal _id;
		private bool _idNull = true;
		private decimal _aplicacion_documento_id;
		private bool _aplicacion_documento_idNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_nombre;
		private decimal _caso_id_nc_aplicacion;
		private bool _caso_id_nc_aplicacionNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _ctacte_proveedor_id;
		private bool _ctacte_proveedor_idNull = true;
		private string _caso_nro_comprobante;
		private decimal _saldo_por_aplicar;
		private bool _saldo_por_aplicarNull = true;
		private decimal _monto_total;
		private bool _monto_totalNull = true;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _proveedor_nombre;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_nombre;
		private string _persona_codigo;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda_nombre;
		private decimal _tipo;
		private bool _tipoNull = true;
		private decimal _moneda_cantidad_decimales;
		private bool _moneda_cantidad_decimalesNull = true;
		private string _moneda_cadena_decimales;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private string _moneda_simbolo;
		private decimal _monto_origen;
		private bool _monto_origenNull = true;
		private decimal _monto_destino;
		private bool _monto_destinoNull = true;
		private decimal _moneda_id_detalle;
		private bool _moneda_id_detalleNull = true;
		private decimal _cotizacion_detalle;
		private bool _cotizacion_detalleNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMEN_VAL_INFO_CORow_Base"/> class.
		/// </summary>
		public APLICACION_DOCUMEN_VAL_INFO_CORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(APLICACION_DOCUMEN_VAL_INFO_CORow_Base original)
		{
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.IsAPLICACION_DOCUMENTO_IDNull != original.IsAPLICACION_DOCUMENTO_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTO_IDNull && !original.IsAPLICACION_DOCUMENTO_IDNull)
				if (this.APLICACION_DOCUMENTO_ID != original.APLICACION_DOCUMENTO_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_NOMBRE != original.FLUJO_NOMBRE) return true;
			if (this.IsCASO_ID_NC_APLICACIONNull != original.IsCASO_ID_NC_APLICACIONNull) return true;
			if (!this.IsCASO_ID_NC_APLICACIONNull && !original.IsCASO_ID_NC_APLICACIONNull)
				if (this.CASO_ID_NC_APLICACION != original.CASO_ID_NC_APLICACION) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsCTACTE_PROVEEDOR_IDNull != original.IsCTACTE_PROVEEDOR_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_IDNull && !original.IsCTACTE_PROVEEDOR_IDNull)
				if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.IsSALDO_POR_APLICARNull != original.IsSALDO_POR_APLICARNull) return true;
			if (!this.IsSALDO_POR_APLICARNull && !original.IsSALDO_POR_APLICARNull)
				if (this.SALDO_POR_APLICAR != original.SALDO_POR_APLICAR) return true;
			if (this.IsMONTO_TOTALNull != original.IsMONTO_TOTALNull) return true;
			if (!this.IsMONTO_TOTALNull && !original.IsMONTO_TOTALNull)
				if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.IsTIPONull != original.IsTIPONull) return true;
			if (!this.IsTIPONull && !original.IsTIPONull)
				if (this.TIPO != original.TIPO) return true;
			if (this.IsMONEDA_CANTIDAD_DECIMALESNull != original.IsMONEDA_CANTIDAD_DECIMALESNull) return true;
			if (!this.IsMONEDA_CANTIDAD_DECIMALESNull && !original.IsMONEDA_CANTIDAD_DECIMALESNull)
				if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsMONTO_ORIGENNull != original.IsMONTO_ORIGENNull) return true;
			if (!this.IsMONTO_ORIGENNull && !original.IsMONTO_ORIGENNull)
				if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.IsMONTO_DESTINONull != original.IsMONTO_DESTINONull) return true;
			if (!this.IsMONTO_DESTINONull && !original.IsMONTO_DESTINONull)
				if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.IsMONEDA_ID_DETALLENull != original.IsMONEDA_ID_DETALLENull) return true;
			if (!this.IsMONEDA_ID_DETALLENull && !original.IsMONEDA_ID_DETALLENull)
				if (this.MONEDA_ID_DETALLE != original.MONEDA_ID_DETALLE) return true;
			if (this.IsCOTIZACION_DETALLENull != original.IsCOTIZACION_DETALLENull) return true;
			if (!this.IsCOTIZACION_DETALLENull && !original.IsCOTIZACION_DETALLENull)
				if (this.COTIZACION_DETALLE != original.COTIZACION_DETALLE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTO_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTO_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documento_id;
			}
			set
			{
				_aplicacion_documento_idNull = false;
				_aplicacion_documento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTO_IDNull
		{
			get { return _aplicacion_documento_idNull; }
			set { _aplicacion_documento_idNull = value; }
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
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_NOMBRE</c> column value.</value>
		public string FLUJO_NOMBRE
		{
			get { return _flujo_nombre; }
			set { _flujo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID_NC_APLICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID_NC_APLICACION</c> column value.</value>
		public decimal CASO_ID_NC_APLICACION
		{
			get
			{
				if(IsCASO_ID_NC_APLICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id_nc_aplicacion;
			}
			set
			{
				_caso_id_nc_aplicacionNull = false;
				_caso_id_nc_aplicacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID_NC_APLICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ID_NC_APLICACIONNull
		{
			get { return _caso_id_nc_aplicacionNull; }
			set { _caso_id_nc_aplicacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_id;
			}
			set
			{
				_ctacte_proveedor_idNull = false;
				_ctacte_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_IDNull
		{
			get { return _ctacte_proveedor_idNull; }
			set { _ctacte_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_NRO_COMPROBANTE
		{
			get { return _caso_nro_comprobante; }
			set { _caso_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_POR_APLICAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_POR_APLICAR</c> column value.</value>
		public decimal SALDO_POR_APLICAR
		{
			get
			{
				if(IsSALDO_POR_APLICARNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_por_aplicar;
			}
			set
			{
				_saldo_por_aplicarNull = false;
				_saldo_por_aplicar = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_POR_APLICAR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_POR_APLICARNull
		{
			get { return _saldo_por_aplicarNull; }
			set { _saldo_por_aplicarNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get
			{
				if(IsMONTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total;
			}
			set
			{
				_monto_totalNull = false;
				_monto_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTALNull
		{
			get { return _monto_totalNull; }
			set { _monto_totalNull = value; }
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_NOMBRE</c> column value.</value>
		public string PROVEEDOR_NOMBRE
		{
			get { return _proveedor_nombre; }
			set { _proveedor_nombre = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public decimal TIPO
		{
			get
			{
				if(IsTIPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo;
			}
			set
			{
				_tipoNull = false;
				_tipo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPONull
		{
			get { return _tipoNull; }
			set { _tipoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get
			{
				if(IsMONEDA_CANTIDAD_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cantidad_decimales;
			}
			set
			{
				_moneda_cantidad_decimalesNull = false;
				_moneda_cantidad_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_CANTIDAD_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_CANTIDAD_DECIMALESNull
		{
			get { return _moneda_cantidad_decimalesNull; }
			set { _moneda_cantidad_decimalesNull = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get
			{
				if(IsCOTIZACION_MONEDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda;
			}
			set
			{
				_cotizacion_monedaNull = false;
				_cotizacion_moneda = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDANull
		{
			get { return _cotizacion_monedaNull; }
			set { _cotizacion_monedaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get
			{
				if(IsMONTO_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_origen;
			}
			set
			{
				_monto_origenNull = false;
				_monto_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_ORIGENNull
		{
			get { return _monto_origenNull; }
			set { _monto_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get
			{
				if(IsMONTO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_destino;
			}
			set
			{
				_monto_destinoNull = false;
				_monto_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESTINONull
		{
			get { return _monto_destinoNull; }
			set { _monto_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID_DETALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID_DETALLE</c> column value.</value>
		public decimal MONEDA_ID_DETALLE
		{
			get
			{
				if(IsMONEDA_ID_DETALLENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id_detalle;
			}
			set
			{
				_moneda_id_detalleNull = false;
				_moneda_id_detalle = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID_DETALLE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_ID_DETALLENull
		{
			get { return _moneda_id_detalleNull; }
			set { _moneda_id_detalleNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_DETALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_DETALLE</c> column value.</value>
		public decimal COTIZACION_DETALLE
		{
			get
			{
				if(IsCOTIZACION_DETALLENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_detalle;
			}
			set
			{
				_cotizacion_detalleNull = false;
				_cotizacion_detalle = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_DETALLE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_DETALLENull
		{
			get { return _cotizacion_detalleNull; }
			set { _cotizacion_detalleNull = value; }
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
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTO_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTO_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_NOMBRE=");
			dynStr.Append(FLUJO_NOMBRE);
			dynStr.Append("@CBA@CASO_ID_NC_APLICACION=");
			dynStr.Append(IsCASO_ID_NC_APLICACIONNull ? (object)"<NULL>" : CASO_ID_NC_APLICACION);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@SALDO_POR_APLICAR=");
			dynStr.Append(IsSALDO_POR_APLICARNull ? (object)"<NULL>" : SALDO_POR_APLICAR);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(IsMONTO_TOTALNull ? (object)"<NULL>" : MONTO_TOTAL);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(IsTIPONull ? (object)"<NULL>" : TIPO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(IsMONEDA_CANTIDAD_DECIMALESNull ? (object)"<NULL>" : MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(IsMONTO_ORIGENNull ? (object)"<NULL>" : MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(IsMONTO_DESTINONull ? (object)"<NULL>" : MONTO_DESTINO);
			dynStr.Append("@CBA@MONEDA_ID_DETALLE=");
			dynStr.Append(IsMONEDA_ID_DETALLENull ? (object)"<NULL>" : MONEDA_ID_DETALLE);
			dynStr.Append("@CBA@COTIZACION_DETALLE=");
			dynStr.Append(IsCOTIZACION_DETALLENull ? (object)"<NULL>" : COTIZACION_DETALLE);
			return dynStr.ToString();
		}
	} // End of APLICACION_DOCUMEN_VAL_INFO_CORow_Base class
} // End of namespace
