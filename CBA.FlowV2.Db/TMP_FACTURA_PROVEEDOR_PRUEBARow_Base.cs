// <fileinfo name="TMP_FACTURA_PROVEEDOR_PRUEBARow_Base.cs">
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
	/// The base class for <see cref="TMP_FACTURA_PROVEEDOR_PRUEBARow"/> that 
	/// represents a record in the <c>TMP_FACTURA_PROVEEDOR_PRUEBA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TMP_FACTURA_PROVEEDOR_PRUEBARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TMP_FACTURA_PROVEEDOR_PRUEBARow_Base
	{
		private string _ruc;
		private string _razon_social;
		private System.DateTime _fecha_factura;
		private bool _fecha_facturaNull = true;
		private string _nro_comprobante;
		private string _nro_timbrado;
		private System.DateTime _fecha_vto_timbrado;
		private bool _fecha_vto_timbradoNull = true;
		private string _moneda;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private string _condicion_pago;
		private string _es_ticket;
		private string _observacion_cabecera;
		private string _observacion_detalle;
		private string _texto_predefinido;
		private string _codigo_articulo;
		private decimal _cantidad_total;
		private bool _cantidad_totalNull = true;
		private decimal _monto_bruto;
		private bool _monto_brutoNull = true;
		private decimal _monto_neto;
		private bool _monto_netoNull = true;
		private decimal _monto_impuesto;
		private bool _monto_impuestoNull = true;
		private decimal _monto_descuento;
		private bool _monto_descuentoNull = true;
		private decimal _porcentaje_impuesto;
		private bool _porcentaje_impuestoNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private decimal _condicion_pago_id;
		private bool _condicion_pago_idNull = true;
		private decimal _tipo_factura_id;
		private bool _tipo_factura_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _rubro_id;
		private bool _rubro_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_FACTURA_PROVEEDOR_PRUEBARow_Base"/> class.
		/// </summary>
		public TMP_FACTURA_PROVEEDOR_PRUEBARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TMP_FACTURA_PROVEEDOR_PRUEBARow_Base original)
		{
			if (this.RUC != original.RUC) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			if (this.IsFECHA_FACTURANull != original.IsFECHA_FACTURANull) return true;
			if (!this.IsFECHA_FACTURANull && !original.IsFECHA_FACTURANull)
				if (this.FECHA_FACTURA != original.FECHA_FACTURA) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.NRO_TIMBRADO != original.NRO_TIMBRADO) return true;
			if (this.IsFECHA_VTO_TIMBRADONull != original.IsFECHA_VTO_TIMBRADONull) return true;
			if (!this.IsFECHA_VTO_TIMBRADONull && !original.IsFECHA_VTO_TIMBRADONull)
				if (this.FECHA_VTO_TIMBRADO != original.FECHA_VTO_TIMBRADO) return true;
			if (this.MONEDA != original.MONEDA) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.CONDICION_PAGO != original.CONDICION_PAGO) return true;
			if (this.ES_TICKET != original.ES_TICKET) return true;
			if (this.OBSERVACION_CABECERA != original.OBSERVACION_CABECERA) return true;
			if (this.OBSERVACION_DETALLE != original.OBSERVACION_DETALLE) return true;
			if (this.TEXTO_PREDEFINIDO != original.TEXTO_PREDEFINIDO) return true;
			if (this.CODIGO_ARTICULO != original.CODIGO_ARTICULO) return true;
			if (this.IsCANTIDAD_TOTALNull != original.IsCANTIDAD_TOTALNull) return true;
			if (!this.IsCANTIDAD_TOTALNull && !original.IsCANTIDAD_TOTALNull)
				if (this.CANTIDAD_TOTAL != original.CANTIDAD_TOTAL) return true;
			if (this.IsMONTO_BRUTONull != original.IsMONTO_BRUTONull) return true;
			if (!this.IsMONTO_BRUTONull && !original.IsMONTO_BRUTONull)
				if (this.MONTO_BRUTO != original.MONTO_BRUTO) return true;
			if (this.IsMONTO_NETONull != original.IsMONTO_NETONull) return true;
			if (!this.IsMONTO_NETONull && !original.IsMONTO_NETONull)
				if (this.MONTO_NETO != original.MONTO_NETO) return true;
			if (this.IsMONTO_IMPUESTONull != original.IsMONTO_IMPUESTONull) return true;
			if (!this.IsMONTO_IMPUESTONull && !original.IsMONTO_IMPUESTONull)
				if (this.MONTO_IMPUESTO != original.MONTO_IMPUESTO) return true;
			if (this.IsMONTO_DESCUENTONull != original.IsMONTO_DESCUENTONull) return true;
			if (!this.IsMONTO_DESCUENTONull && !original.IsMONTO_DESCUENTONull)
				if (this.MONTO_DESCUENTO != original.MONTO_DESCUENTO) return true;
			if (this.IsPORCENTAJE_IMPUESTONull != original.IsPORCENTAJE_IMPUESTONull) return true;
			if (!this.IsPORCENTAJE_IMPUESTONull && !original.IsPORCENTAJE_IMPUESTONull)
				if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsCONDICION_PAGO_IDNull != original.IsCONDICION_PAGO_IDNull) return true;
			if (!this.IsCONDICION_PAGO_IDNull && !original.IsCONDICION_PAGO_IDNull)
				if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.IsTIPO_FACTURA_IDNull != original.IsTIPO_FACTURA_IDNull) return true;
			if (!this.IsTIPO_FACTURA_IDNull && !original.IsTIPO_FACTURA_IDNull)
				if (this.TIPO_FACTURA_ID != original.TIPO_FACTURA_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsRUBRO_IDNull != original.IsRUBRO_IDNull) return true;
			if (!this.IsRUBRO_IDNull && !original.IsRUBRO_IDNull)
				if (this.RUBRO_ID != original.RUBRO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>RUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUC</c> column value.</value>
		public string RUC
		{
			get { return _ruc; }
			set { _ruc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RAZON_SOCIAL</c> column value.</value>
		public string RAZON_SOCIAL
		{
			get { return _razon_social; }
			set { _razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FACTURA</c> column value.</value>
		public System.DateTime FECHA_FACTURA
		{
			get
			{
				if(IsFECHA_FACTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_factura;
			}
			set
			{
				_fecha_facturaNull = false;
				_fecha_factura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FACTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FACTURANull
		{
			get { return _fecha_facturaNull; }
			set { _fecha_facturaNull = value; }
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
		/// Gets or sets the <c>NRO_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_TIMBRADO</c> column value.</value>
		public string NRO_TIMBRADO
		{
			get { return _nro_timbrado; }
			set { _nro_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VTO_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VTO_TIMBRADO</c> column value.</value>
		public System.DateTime FECHA_VTO_TIMBRADO
		{
			get
			{
				if(IsFECHA_VTO_TIMBRADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vto_timbrado;
			}
			set
			{
				_fecha_vto_timbradoNull = false;
				_fecha_vto_timbrado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VTO_TIMBRADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VTO_TIMBRADONull
		{
			get { return _fecha_vto_timbradoNull; }
			set { _fecha_vto_timbradoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA</c> column value.</value>
		public string MONEDA
		{
			get { return _moneda; }
			set { _moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO</c> column value.</value>
		public string CONDICION_PAGO
		{
			get { return _condicion_pago; }
			set { _condicion_pago = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_TICKET</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_TICKET</c> column value.</value>
		public string ES_TICKET
		{
			get { return _es_ticket; }
			set { _es_ticket = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_CABECERA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_CABECERA</c> column value.</value>
		public string OBSERVACION_CABECERA
		{
			get { return _observacion_cabecera; }
			set { _observacion_cabecera = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_DETALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_DETALLE</c> column value.</value>
		public string OBSERVACION_DETALLE
		{
			get { return _observacion_detalle; }
			set { _observacion_detalle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO</c> column value.</value>
		public string TEXTO_PREDEFINIDO
		{
			get { return _texto_predefinido; }
			set { _texto_predefinido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_ARTICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_ARTICULO</c> column value.</value>
		public string CODIGO_ARTICULO
		{
			get { return _codigo_articulo; }
			set { _codigo_articulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_TOTAL</c> column value.</value>
		public decimal CANTIDAD_TOTAL
		{
			get
			{
				if(IsCANTIDAD_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_total;
			}
			set
			{
				_cantidad_totalNull = false;
				_cantidad_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_TOTALNull
		{
			get { return _cantidad_totalNull; }
			set { _cantidad_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BRUTO</c> column value.</value>
		public decimal MONTO_BRUTO
		{
			get
			{
				if(IsMONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bruto;
			}
			set
			{
				_monto_brutoNull = false;
				_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BRUTONull
		{
			get { return _monto_brutoNull; }
			set { _monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_NETO</c> column value.</value>
		public decimal MONTO_NETO
		{
			get
			{
				if(IsMONTO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_neto;
			}
			set
			{
				_monto_netoNull = false;
				_monto_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_NETONull
		{
			get { return _monto_netoNull; }
			set { _monto_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_IMPUESTO</c> column value.</value>
		public decimal MONTO_IMPUESTO
		{
			get
			{
				if(IsMONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_impuesto;
			}
			set
			{
				_monto_impuestoNull = false;
				_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_IMPUESTONull
		{
			get { return _monto_impuestoNull; }
			set { _monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESCUENTO</c> column value.</value>
		public decimal MONTO_DESCUENTO
		{
			get
			{
				if(IsMONTO_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_descuento;
			}
			set
			{
				_monto_descuentoNull = false;
				_monto_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESCUENTONull
		{
			get { return _monto_descuentoNull; }
			set { _monto_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get
			{
				if(IsPORCENTAJE_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_impuesto;
			}
			set
			{
				_porcentaje_impuestoNull = false;
				_porcentaje_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_IMPUESTONull
		{
			get { return _porcentaje_impuestoNull; }
			set { _porcentaje_impuestoNull = value; }
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
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
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get
			{
				if(IsIMPUESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_id;
			}
			set
			{
				_impuesto_idNull = false;
				_impuesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_IDNull
		{
			get { return _impuesto_idNull; }
			set { _impuesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get
			{
				if(IsCONDICION_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_pago_id;
			}
			set
			{
				_condicion_pago_idNull = false;
				_condicion_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_PAGO_IDNull
		{
			get { return _condicion_pago_idNull; }
			set { _condicion_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_FACTURA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_FACTURA_ID</c> column value.</value>
		public decimal TIPO_FACTURA_ID
		{
			get
			{
				if(IsTIPO_FACTURA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_factura_id;
			}
			set
			{
				_tipo_factura_idNull = false;
				_tipo_factura_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_FACTURA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_FACTURA_IDNull
		{
			get { return _tipo_factura_idNull; }
			set { _tipo_factura_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUBRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUBRO_ID</c> column value.</value>
		public decimal RUBRO_ID
		{
			get
			{
				if(IsRUBRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rubro_id;
			}
			set
			{
				_rubro_idNull = false;
				_rubro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RUBRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRUBRO_IDNull
		{
			get { return _rubro_idNull; }
			set { _rubro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get
			{
				if(IsLOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lote_id;
			}
			set
			{
				_lote_idNull = false;
				_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOTE_IDNull
		{
			get { return _lote_idNull; }
			set { _lote_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@RUC=");
			dynStr.Append(RUC);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			dynStr.Append("@CBA@FECHA_FACTURA=");
			dynStr.Append(IsFECHA_FACTURANull ? (object)"<NULL>" : FECHA_FACTURA);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NRO_TIMBRADO=");
			dynStr.Append(NRO_TIMBRADO);
			dynStr.Append("@CBA@FECHA_VTO_TIMBRADO=");
			dynStr.Append(IsFECHA_VTO_TIMBRADONull ? (object)"<NULL>" : FECHA_VTO_TIMBRADO);
			dynStr.Append("@CBA@MONEDA=");
			dynStr.Append(MONEDA);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@CONDICION_PAGO=");
			dynStr.Append(CONDICION_PAGO);
			dynStr.Append("@CBA@ES_TICKET=");
			dynStr.Append(ES_TICKET);
			dynStr.Append("@CBA@OBSERVACION_CABECERA=");
			dynStr.Append(OBSERVACION_CABECERA);
			dynStr.Append("@CBA@OBSERVACION_DETALLE=");
			dynStr.Append(OBSERVACION_DETALLE);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO=");
			dynStr.Append(TEXTO_PREDEFINIDO);
			dynStr.Append("@CBA@CODIGO_ARTICULO=");
			dynStr.Append(CODIGO_ARTICULO);
			dynStr.Append("@CBA@CANTIDAD_TOTAL=");
			dynStr.Append(IsCANTIDAD_TOTALNull ? (object)"<NULL>" : CANTIDAD_TOTAL);
			dynStr.Append("@CBA@MONTO_BRUTO=");
			dynStr.Append(IsMONTO_BRUTONull ? (object)"<NULL>" : MONTO_BRUTO);
			dynStr.Append("@CBA@MONTO_NETO=");
			dynStr.Append(IsMONTO_NETONull ? (object)"<NULL>" : MONTO_NETO);
			dynStr.Append("@CBA@MONTO_IMPUESTO=");
			dynStr.Append(IsMONTO_IMPUESTONull ? (object)"<NULL>" : MONTO_IMPUESTO);
			dynStr.Append("@CBA@MONTO_DESCUENTO=");
			dynStr.Append(IsMONTO_DESCUENTONull ? (object)"<NULL>" : MONTO_DESCUENTO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(IsPORCENTAJE_IMPUESTONull ? (object)"<NULL>" : PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(IsCONDICION_PAGO_IDNull ? (object)"<NULL>" : CONDICION_PAGO_ID);
			dynStr.Append("@CBA@TIPO_FACTURA_ID=");
			dynStr.Append(IsTIPO_FACTURA_IDNull ? (object)"<NULL>" : TIPO_FACTURA_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@RUBRO_ID=");
			dynStr.Append(IsRUBRO_IDNull ? (object)"<NULL>" : RUBRO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			return dynStr.ToString();
		}
	} // End of TMP_FACTURA_PROVEEDOR_PRUEBARow_Base class
} // End of namespace
