// <fileinfo name="PEDIDOS_CLIENTE_DETALLERow_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTE_DETALLERow"/> that 
	/// represents a record in the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PEDIDOS_CLIENTE_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTE_DETALLERow_Base
	{
		private decimal _id;
		private decimal _pedidos_cliente_id;
		private decimal _articulo_id;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _vendedor_comisionista_id;
		private bool _vendedor_comisionista_idNull = true;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private decimal _cotizacion_origen;
		private bool _cotizacion_origenNull = true;
		private decimal _cotizacion_moneda_linea_cred;
		private bool _cotizacion_moneda_linea_credNull = true;
		private string _unidad_destino_id;
		private decimal _cantidad_cajas_entregada;
		private decimal _cantidad_unitaria_entregada;
		private decimal _cantidad_por_caja_destino;
		private decimal _cantidad_cajas_pedida;
		private decimal _cantidad_unitaria_pedida;
		private decimal _cantidad_total_pedida;
		private decimal _cantidad_subitems_final;
		private bool _cantidad_subitems_finalNull = true;
		private decimal _precio_lista_destino;
		private decimal _monto_descuento;
		private decimal _porcentaje_dto;
		private decimal _impuesto_id;
		private decimal _porcentaje_comision_ven;
		private bool _porcentaje_comision_venNull = true;
		private decimal _monto_comision_ven;
		private bool _monto_comision_venNull = true;
		private decimal _total_monto_impuesto;
		private decimal _total_monto_dto;
		private decimal _total_monto_bruto;
		private decimal _total_neto;
		private decimal _porcentaje_impuesto;
		private bool _porcentaje_impuestoNull = true;
		private decimal _cantidad_total_entregada;
		private bool _cantidad_total_entregadaNull = true;
		private string _unidad_origen_id;
		private decimal _cantidad_unidad_origen;
		private bool _cantidad_unidad_origenNull = true;
		private decimal _cantidad_por_caja_origen;
		private bool _cantidad_por_caja_origenNull = true;
		private decimal _precio_lista_origen;
		private decimal _cantidad_unitaria_total_orig;
		private bool _cantidad_unitaria_total_origNull = true;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private decimal _costo_monto;
		private decimal _costo_moneda_id;
		private bool _costo_moneda_idNull = true;
		private decimal _costo_moneda_cotizacion;
		private bool _costo_moneda_cotizacionNull = true;
		private decimal _costo_id;
		private bool _costo_idNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _orden_de_presentacion;
		private string _observacion;
		private decimal _total_recargo_financiero;
		private decimal _precio_unitario_aprobado;
		private bool _precio_unitario_aprobadoNull = true;
		private string _con_stock;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTE_DETALLERow_Base"/> class.
		/// </summary>
		public PEDIDOS_CLIENTE_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PEDIDOS_CLIENTE_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PEDIDOS_CLIENTE_ID != original.PEDIDOS_CLIENTE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsVENDEDOR_COMISIONISTA_IDNull != original.IsVENDEDOR_COMISIONISTA_IDNull) return true;
			if (!this.IsVENDEDOR_COMISIONISTA_IDNull && !original.IsVENDEDOR_COMISIONISTA_IDNull)
				if (this.VENDEDOR_COMISIONISTA_ID != original.VENDEDOR_COMISIONISTA_ID) return true;
			if (this.IsMONEDA_ORIGEN_IDNull != original.IsMONEDA_ORIGEN_IDNull) return true;
			if (!this.IsMONEDA_ORIGEN_IDNull && !original.IsMONEDA_ORIGEN_IDNull)
				if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.IsCOTIZACION_ORIGENNull != original.IsCOTIZACION_ORIGENNull) return true;
			if (!this.IsCOTIZACION_ORIGENNull && !original.IsCOTIZACION_ORIGENNull)
				if (this.COTIZACION_ORIGEN != original.COTIZACION_ORIGEN) return true;
			if (this.IsCOTIZACION_MONEDA_LINEA_CREDNull != original.IsCOTIZACION_MONEDA_LINEA_CREDNull) return true;
			if (!this.IsCOTIZACION_MONEDA_LINEA_CREDNull && !original.IsCOTIZACION_MONEDA_LINEA_CREDNull)
				if (this.COTIZACION_MONEDA_LINEA_CRED != original.COTIZACION_MONEDA_LINEA_CRED) return true;
			if (this.UNIDAD_DESTINO_ID != original.UNIDAD_DESTINO_ID) return true;
			if (this.CANTIDAD_CAJAS_ENTREGADA != original.CANTIDAD_CAJAS_ENTREGADA) return true;
			if (this.CANTIDAD_UNITARIA_ENTREGADA != original.CANTIDAD_UNITARIA_ENTREGADA) return true;
			if (this.CANTIDAD_POR_CAJA_DESTINO != original.CANTIDAD_POR_CAJA_DESTINO) return true;
			if (this.CANTIDAD_CAJAS_PEDIDA != original.CANTIDAD_CAJAS_PEDIDA) return true;
			if (this.CANTIDAD_UNITARIA_PEDIDA != original.CANTIDAD_UNITARIA_PEDIDA) return true;
			if (this.CANTIDAD_TOTAL_PEDIDA != original.CANTIDAD_TOTAL_PEDIDA) return true;
			if (this.IsCANTIDAD_SUBITEMS_FINALNull != original.IsCANTIDAD_SUBITEMS_FINALNull) return true;
			if (!this.IsCANTIDAD_SUBITEMS_FINALNull && !original.IsCANTIDAD_SUBITEMS_FINALNull)
				if (this.CANTIDAD_SUBITEMS_FINAL != original.CANTIDAD_SUBITEMS_FINAL) return true;
			if (this.PRECIO_LISTA_DESTINO != original.PRECIO_LISTA_DESTINO) return true;
			if (this.MONTO_DESCUENTO != original.MONTO_DESCUENTO) return true;
			if (this.PORCENTAJE_DTO != original.PORCENTAJE_DTO) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsPORCENTAJE_COMISION_VENNull != original.IsPORCENTAJE_COMISION_VENNull) return true;
			if (!this.IsPORCENTAJE_COMISION_VENNull && !original.IsPORCENTAJE_COMISION_VENNull)
				if (this.PORCENTAJE_COMISION_VEN != original.PORCENTAJE_COMISION_VEN) return true;
			if (this.IsMONTO_COMISION_VENNull != original.IsMONTO_COMISION_VENNull) return true;
			if (!this.IsMONTO_COMISION_VENNull && !original.IsMONTO_COMISION_VENNull)
				if (this.MONTO_COMISION_VEN != original.MONTO_COMISION_VEN) return true;
			if (this.TOTAL_MONTO_IMPUESTO != original.TOTAL_MONTO_IMPUESTO) return true;
			if (this.TOTAL_MONTO_DTO != original.TOTAL_MONTO_DTO) return true;
			if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			if (this.TOTAL_NETO != original.TOTAL_NETO) return true;
			if (this.IsPORCENTAJE_IMPUESTONull != original.IsPORCENTAJE_IMPUESTONull) return true;
			if (!this.IsPORCENTAJE_IMPUESTONull && !original.IsPORCENTAJE_IMPUESTONull)
				if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.IsCANTIDAD_TOTAL_ENTREGADANull != original.IsCANTIDAD_TOTAL_ENTREGADANull) return true;
			if (!this.IsCANTIDAD_TOTAL_ENTREGADANull && !original.IsCANTIDAD_TOTAL_ENTREGADANull)
				if (this.CANTIDAD_TOTAL_ENTREGADA != original.CANTIDAD_TOTAL_ENTREGADA) return true;
			if (this.UNIDAD_ORIGEN_ID != original.UNIDAD_ORIGEN_ID) return true;
			if (this.IsCANTIDAD_UNIDAD_ORIGENNull != original.IsCANTIDAD_UNIDAD_ORIGENNull) return true;
			if (!this.IsCANTIDAD_UNIDAD_ORIGENNull && !original.IsCANTIDAD_UNIDAD_ORIGENNull)
				if (this.CANTIDAD_UNIDAD_ORIGEN != original.CANTIDAD_UNIDAD_ORIGEN) return true;
			if (this.IsCANTIDAD_POR_CAJA_ORIGENNull != original.IsCANTIDAD_POR_CAJA_ORIGENNull) return true;
			if (!this.IsCANTIDAD_POR_CAJA_ORIGENNull && !original.IsCANTIDAD_POR_CAJA_ORIGENNull)
				if (this.CANTIDAD_POR_CAJA_ORIGEN != original.CANTIDAD_POR_CAJA_ORIGEN) return true;
			if (this.PRECIO_LISTA_ORIGEN != original.PRECIO_LISTA_ORIGEN) return true;
			if (this.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull != original.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull && !original.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull)
				if (this.CANTIDAD_UNITARIA_TOTAL_ORIG != original.CANTIDAD_UNITARIA_TOTAL_ORIG) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.COSTO_MONTO != original.COSTO_MONTO) return true;
			if (this.IsCOSTO_MONEDA_IDNull != original.IsCOSTO_MONEDA_IDNull) return true;
			if (!this.IsCOSTO_MONEDA_IDNull && !original.IsCOSTO_MONEDA_IDNull)
				if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.IsCOSTO_MONEDA_COTIZACIONNull != original.IsCOSTO_MONEDA_COTIZACIONNull) return true;
			if (!this.IsCOSTO_MONEDA_COTIZACIONNull && !original.IsCOSTO_MONEDA_COTIZACIONNull)
				if (this.COSTO_MONEDA_COTIZACION != original.COSTO_MONEDA_COTIZACION) return true;
			if (this.IsCOSTO_IDNull != original.IsCOSTO_IDNull) return true;
			if (!this.IsCOSTO_IDNull && !original.IsCOSTO_IDNull)
				if (this.COSTO_ID != original.COSTO_ID) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.ORDEN_DE_PRESENTACION != original.ORDEN_DE_PRESENTACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.TOTAL_RECARGO_FINANCIERO != original.TOTAL_RECARGO_FINANCIERO) return true;
			if (this.IsPRECIO_UNITARIO_APROBADONull != original.IsPRECIO_UNITARIO_APROBADONull) return true;
			if (!this.IsPRECIO_UNITARIO_APROBADONull && !original.IsPRECIO_UNITARIO_APROBADONull)
				if (this.PRECIO_UNITARIO_APROBADO != original.PRECIO_UNITARIO_APROBADO) return true;
			if (this.CON_STOCK != original.CON_STOCK) return true;
			
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
		/// Gets or sets the <c>PEDIDOS_CLIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PEDIDOS_CLIENTE_ID</c> column value.</value>
		public decimal PEDIDOS_CLIENTE_ID
		{
			get { return _pedidos_cliente_id; }
			set { _pedidos_cliente_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
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
		/// Gets or sets the <c>VENDEDOR_COMISIONISTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</value>
		public decimal VENDEDOR_COMISIONISTA_ID
		{
			get
			{
				if(IsVENDEDOR_COMISIONISTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vendedor_comisionista_id;
			}
			set
			{
				_vendedor_comisionista_idNull = false;
				_vendedor_comisionista_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENDEDOR_COMISIONISTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENDEDOR_COMISIONISTA_IDNull
		{
			get { return _vendedor_comisionista_idNull; }
			set { _vendedor_comisionista_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get
			{
				if(IsMONEDA_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_origen_id;
			}
			set
			{
				_moneda_origen_idNull = false;
				_moneda_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_ORIGEN_IDNull
		{
			get { return _moneda_origen_idNull; }
			set { _moneda_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_ORIGEN</c> column value.</value>
		public decimal COTIZACION_ORIGEN
		{
			get
			{
				if(IsCOTIZACION_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_origen;
			}
			set
			{
				_cotizacion_origenNull = false;
				_cotizacion_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_ORIGENNull
		{
			get { return _cotizacion_origenNull; }
			set { _cotizacion_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_LINEA_CRED</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_LINEA_CRED</c> column value.</value>
		public decimal COTIZACION_MONEDA_LINEA_CRED
		{
			get
			{
				if(IsCOTIZACION_MONEDA_LINEA_CREDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda_linea_cred;
			}
			set
			{
				_cotizacion_moneda_linea_credNull = false;
				_cotizacion_moneda_linea_cred = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA_LINEA_CRED"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDA_LINEA_CREDNull
		{
			get { return _cotizacion_moneda_linea_credNull; }
			set { _cotizacion_moneda_linea_credNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO_ID</c> column value.</value>
		public string UNIDAD_DESTINO_ID
		{
			get { return _unidad_destino_id; }
			set { _unidad_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CAJAS_ENTREGADA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CAJAS_ENTREGADA</c> column value.</value>
		public decimal CANTIDAD_CAJAS_ENTREGADA
		{
			get { return _cantidad_cajas_entregada; }
			set { _cantidad_cajas_entregada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_ENTREGADA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_ENTREGADA</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_ENTREGADA
		{
			get { return _cantidad_unitaria_entregada; }
			set { _cantidad_unitaria_entregada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_POR_CAJA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA_DESTINO</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA_DESTINO
		{
			get { return _cantidad_por_caja_destino; }
			set { _cantidad_por_caja_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CAJAS_PEDIDA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CAJAS_PEDIDA</c> column value.</value>
		public decimal CANTIDAD_CAJAS_PEDIDA
		{
			get { return _cantidad_cajas_pedida; }
			set { _cantidad_cajas_pedida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_PEDIDA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_PEDIDA</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_PEDIDA
		{
			get { return _cantidad_unitaria_pedida; }
			set { _cantidad_unitaria_pedida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_TOTAL_PEDIDA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_TOTAL_PEDIDA</c> column value.</value>
		public decimal CANTIDAD_TOTAL_PEDIDA
		{
			get { return _cantidad_total_pedida; }
			set { _cantidad_total_pedida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_SUBITEMS_FINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_SUBITEMS_FINAL</c> column value.</value>
		public decimal CANTIDAD_SUBITEMS_FINAL
		{
			get
			{
				if(IsCANTIDAD_SUBITEMS_FINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_subitems_final;
			}
			set
			{
				_cantidad_subitems_finalNull = false;
				_cantidad_subitems_final = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_SUBITEMS_FINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_SUBITEMS_FINALNull
		{
			get { return _cantidad_subitems_finalNull; }
			set { _cantidad_subitems_finalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO_LISTA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_LISTA_DESTINO</c> column value.</value>
		public decimal PRECIO_LISTA_DESTINO
		{
			get { return _precio_lista_destino; }
			set { _precio_lista_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESCUENTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESCUENTO</c> column value.</value>
		public decimal MONTO_DESCUENTO
		{
			get { return _monto_descuento; }
			set { _monto_descuento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DTO</c> column value.</value>
		public decimal PORCENTAJE_DTO
		{
			get { return _porcentaje_dto; }
			set { _porcentaje_dto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION_VEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION_VEN</c> column value.</value>
		public decimal PORCENTAJE_COMISION_VEN
		{
			get
			{
				if(IsPORCENTAJE_COMISION_VENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_comision_ven;
			}
			set
			{
				_porcentaje_comision_venNull = false;
				_porcentaje_comision_ven = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_COMISION_VEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_COMISION_VENNull
		{
			get { return _porcentaje_comision_venNull; }
			set { _porcentaje_comision_venNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMISION_VEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COMISION_VEN</c> column value.</value>
		public decimal MONTO_COMISION_VEN
		{
			get
			{
				if(IsMONTO_COMISION_VENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_comision_ven;
			}
			set
			{
				_monto_comision_venNull = false;
				_monto_comision_ven = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COMISION_VEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COMISION_VENNull
		{
			get { return _monto_comision_venNull; }
			set { _monto_comision_venNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO
		{
			get { return _total_monto_impuesto; }
			set { _total_monto_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_DTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_DTO</c> column value.</value>
		public decimal TOTAL_MONTO_DTO
		{
			get { return _total_monto_dto; }
			set { _total_monto_dto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get { return _total_monto_bruto; }
			set { _total_monto_bruto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_NETO</c> column value.</value>
		public decimal TOTAL_NETO
		{
			get { return _total_neto; }
			set { _total_neto = value; }
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
		/// Gets or sets the <c>CANTIDAD_TOTAL_ENTREGADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_TOTAL_ENTREGADA</c> column value.</value>
		public decimal CANTIDAD_TOTAL_ENTREGADA
		{
			get
			{
				if(IsCANTIDAD_TOTAL_ENTREGADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_total_entregada;
			}
			set
			{
				_cantidad_total_entregadaNull = false;
				_cantidad_total_entregada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_TOTAL_ENTREGADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_TOTAL_ENTREGADANull
		{
			get { return _cantidad_total_entregadaNull; }
			set { _cantidad_total_entregadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ORIGEN_ID</c> column value.</value>
		public string UNIDAD_ORIGEN_ID
		{
			get { return _unidad_origen_id; }
			set { _unidad_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNIDAD_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNIDAD_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_UNIDAD_ORIGEN
		{
			get
			{
				if(IsCANTIDAD_UNIDAD_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unidad_origen;
			}
			set
			{
				_cantidad_unidad_origenNull = false;
				_cantidad_unidad_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNIDAD_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNIDAD_ORIGENNull
		{
			get { return _cantidad_unidad_origenNull; }
			set { _cantidad_unidad_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_POR_CAJA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA_ORIGEN
		{
			get
			{
				if(IsCANTIDAD_POR_CAJA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_por_caja_origen;
			}
			set
			{
				_cantidad_por_caja_origenNull = false;
				_cantidad_por_caja_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_POR_CAJA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_POR_CAJA_ORIGENNull
		{
			get { return _cantidad_por_caja_origenNull; }
			set { _cantidad_por_caja_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO_LISTA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_LISTA_ORIGEN</c> column value.</value>
		public decimal PRECIO_LISTA_ORIGEN
		{
			get { return _precio_lista_origen; }
			set { _precio_lista_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL_ORIG</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL_ORIG</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL_ORIG
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_TOTAL_ORIGNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_total_orig;
			}
			set
			{
				_cantidad_unitaria_total_origNull = false;
				_cantidad_unitaria_total_orig = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_TOTAL_ORIG"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_TOTAL_ORIGNull
		{
			get { return _cantidad_unitaria_total_origNull; }
			set { _cantidad_unitaria_total_origNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_CONVERSION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTOR_CONVERSION</c> column value.</value>
		public decimal FACTOR_CONVERSION
		{
			get
			{
				if(IsFACTOR_CONVERSIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factor_conversion;
			}
			set
			{
				_factor_conversionNull = false;
				_factor_conversion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTOR_CONVERSION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTOR_CONVERSIONNull
		{
			get { return _factor_conversionNull; }
			set { _factor_conversionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONTO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONTO</c> column value.</value>
		public decimal COSTO_MONTO
		{
			get { return _costo_monto; }
			set { _costo_monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ID
		{
			get
			{
				if(IsCOSTO_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_moneda_id;
			}
			set
			{
				_costo_moneda_idNull = false;
				_costo_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONEDA_IDNull
		{
			get { return _costo_moneda_idNull; }
			set { _costo_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_COTIZACION</c> column value.</value>
		public decimal COSTO_MONEDA_COTIZACION
		{
			get
			{
				if(IsCOSTO_MONEDA_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_moneda_cotizacion;
			}
			set
			{
				_costo_moneda_cotizacionNull = false;
				_costo_moneda_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONEDA_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONEDA_COTIZACIONNull
		{
			get { return _costo_moneda_cotizacionNull; }
			set { _costo_moneda_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_ID</c> column value.</value>
		public decimal COSTO_ID
		{
			get
			{
				if(IsCOSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_id;
			}
			set
			{
				_costo_idNull = false;
				_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_IDNull
		{
			get { return _costo_idNull; }
			set { _costo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get
			{
				if(IsACTIVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_id;
			}
			set
			{
				_activo_idNull = false;
				_activo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_IDNull
		{
			get { return _activo_idNull; }
			set { _activo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_DE_PRESENTACION</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_DE_PRESENTACION</c> column value.</value>
		public decimal ORDEN_DE_PRESENTACION
		{
			get { return _orden_de_presentacion; }
			set { _orden_de_presentacion = value; }
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
		/// Gets or sets the <c>TOTAL_RECARGO_FINANCIERO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_RECARGO_FINANCIERO</c> column value.</value>
		public decimal TOTAL_RECARGO_FINANCIERO
		{
			get { return _total_recargo_financiero; }
			set { _total_recargo_financiero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO_UNITARIO_APROBADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO_UNITARIO_APROBADO</c> column value.</value>
		public decimal PRECIO_UNITARIO_APROBADO
		{
			get
			{
				if(IsPRECIO_UNITARIO_APROBADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio_unitario_aprobado;
			}
			set
			{
				_precio_unitario_aprobadoNull = false;
				_precio_unitario_aprobado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO_UNITARIO_APROBADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIO_UNITARIO_APROBADONull
		{
			get { return _precio_unitario_aprobadoNull; }
			set { _precio_unitario_aprobadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CON_STOCK</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CON_STOCK</c> column value.</value>
		public string CON_STOCK
		{
			get { return _con_stock; }
			set { _con_stock = value; }
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
			dynStr.Append("@CBA@PEDIDOS_CLIENTE_ID=");
			dynStr.Append(PEDIDOS_CLIENTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@VENDEDOR_COMISIONISTA_ID=");
			dynStr.Append(IsVENDEDOR_COMISIONISTA_IDNull ? (object)"<NULL>" : VENDEDOR_COMISIONISTA_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_ORIGEN=");
			dynStr.Append(IsCOTIZACION_ORIGENNull ? (object)"<NULL>" : COTIZACION_ORIGEN);
			dynStr.Append("@CBA@COTIZACION_MONEDA_LINEA_CRED=");
			dynStr.Append(IsCOTIZACION_MONEDA_LINEA_CREDNull ? (object)"<NULL>" : COTIZACION_MONEDA_LINEA_CRED);
			dynStr.Append("@CBA@UNIDAD_DESTINO_ID=");
			dynStr.Append(UNIDAD_DESTINO_ID);
			dynStr.Append("@CBA@CANTIDAD_CAJAS_ENTREGADA=");
			dynStr.Append(CANTIDAD_CAJAS_ENTREGADA);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_ENTREGADA=");
			dynStr.Append(CANTIDAD_UNITARIA_ENTREGADA);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_DESTINO=");
			dynStr.Append(CANTIDAD_POR_CAJA_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_CAJAS_PEDIDA=");
			dynStr.Append(CANTIDAD_CAJAS_PEDIDA);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_PEDIDA=");
			dynStr.Append(CANTIDAD_UNITARIA_PEDIDA);
			dynStr.Append("@CBA@CANTIDAD_TOTAL_PEDIDA=");
			dynStr.Append(CANTIDAD_TOTAL_PEDIDA);
			dynStr.Append("@CBA@CANTIDAD_SUBITEMS_FINAL=");
			dynStr.Append(IsCANTIDAD_SUBITEMS_FINALNull ? (object)"<NULL>" : CANTIDAD_SUBITEMS_FINAL);
			dynStr.Append("@CBA@PRECIO_LISTA_DESTINO=");
			dynStr.Append(PRECIO_LISTA_DESTINO);
			dynStr.Append("@CBA@MONTO_DESCUENTO=");
			dynStr.Append(MONTO_DESCUENTO);
			dynStr.Append("@CBA@PORCENTAJE_DTO=");
			dynStr.Append(PORCENTAJE_DTO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@PORCENTAJE_COMISION_VEN=");
			dynStr.Append(IsPORCENTAJE_COMISION_VENNull ? (object)"<NULL>" : PORCENTAJE_COMISION_VEN);
			dynStr.Append("@CBA@MONTO_COMISION_VEN=");
			dynStr.Append(IsMONTO_COMISION_VENNull ? (object)"<NULL>" : MONTO_COMISION_VEN);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO=");
			dynStr.Append(TOTAL_MONTO_IMPUESTO);
			dynStr.Append("@CBA@TOTAL_MONTO_DTO=");
			dynStr.Append(TOTAL_MONTO_DTO);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(TOTAL_MONTO_BRUTO);
			dynStr.Append("@CBA@TOTAL_NETO=");
			dynStr.Append(TOTAL_NETO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(IsPORCENTAJE_IMPUESTONull ? (object)"<NULL>" : PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@CANTIDAD_TOTAL_ENTREGADA=");
			dynStr.Append(IsCANTIDAD_TOTAL_ENTREGADANull ? (object)"<NULL>" : CANTIDAD_TOTAL_ENTREGADA);
			dynStr.Append("@CBA@UNIDAD_ORIGEN_ID=");
			dynStr.Append(UNIDAD_ORIGEN_ID);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_ORIGEN=");
			dynStr.Append(IsCANTIDAD_UNIDAD_ORIGENNull ? (object)"<NULL>" : CANTIDAD_UNIDAD_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_ORIGEN=");
			dynStr.Append(IsCANTIDAD_POR_CAJA_ORIGENNull ? (object)"<NULL>" : CANTIDAD_POR_CAJA_ORIGEN);
			dynStr.Append("@CBA@PRECIO_LISTA_ORIGEN=");
			dynStr.Append(PRECIO_LISTA_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_ORIG=");
			dynStr.Append(IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_TOTAL_ORIG);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@COSTO_MONTO=");
			dynStr.Append(COSTO_MONTO);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(IsCOSTO_MONEDA_IDNull ? (object)"<NULL>" : COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_MONEDA_COTIZACION=");
			dynStr.Append(IsCOSTO_MONEDA_COTIZACIONNull ? (object)"<NULL>" : COSTO_MONEDA_COTIZACION);
			dynStr.Append("@CBA@COSTO_ID=");
			dynStr.Append(IsCOSTO_IDNull ? (object)"<NULL>" : COSTO_ID);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@ORDEN_DE_PRESENTACION=");
			dynStr.Append(ORDEN_DE_PRESENTACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TOTAL_RECARGO_FINANCIERO=");
			dynStr.Append(TOTAL_RECARGO_FINANCIERO);
			dynStr.Append("@CBA@PRECIO_UNITARIO_APROBADO=");
			dynStr.Append(IsPRECIO_UNITARIO_APROBADONull ? (object)"<NULL>" : PRECIO_UNITARIO_APROBADO);
			dynStr.Append("@CBA@CON_STOCK=");
			dynStr.Append(CON_STOCK);
			return dynStr.ToString();
		}
	} // End of PEDIDOS_CLIENTE_DETALLERow_Base class
} // End of namespace
