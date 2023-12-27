// <fileinfo name="FACTURAS_CLIENTE_DETALLERow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DETALLERow"/> that 
	/// represents a record in the <c>FACTURAS_CLIENTE_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_CLIENTE_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DETALLERow_Base
	{
		private decimal _id;
		private decimal _facturas_cliente_id;
		private decimal _articulo_id;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private decimal _cotizacion_origen;
		private bool _cotizacion_origenNull = true;
		private decimal _cotizacion_moneda_linea_cred;
		private bool _cotizacion_moneda_linea_credNull = true;
		private string _unidad_destino_id;
		private decimal _cantidad_embalada;
		private decimal _cantidad_unidad_destino;
		private decimal _cantidad_por_caja_destino;
		private decimal _cantidad_unitaria_total_dest;
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
		private string _articulo_codigo;
		private string _articulo_codigo_barras;
		private string _articulo_descripcion;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _cantidad_devuelta_nota_credito;
		private decimal _porcentaje_impuesto;
		private bool _porcentaje_impuestoNull = true;
		private string _unidad_origen_id;
		private decimal _cantidad_unidad_origen;
		private bool _cantidad_unidad_origenNull = true;
		private decimal _cantidad_por_caja_origen;
		private bool _cantidad_por_caja_origenNull = true;
		private decimal _cantidad_unitaria_total_orig;
		private bool _cantidad_unitaria_total_origNull = true;
		private decimal _precio_lista_origen;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private decimal _costo_id;
		private bool _costo_idNull = true;
		private decimal _costo_monto;
		private decimal _costo_moneda_id;
		private bool _costo_moneda_idNull = true;
		private decimal _costo_moneda_cotizacion;
		private bool _costo_moneda_cotizacionNull = true;
		private string _observacion;
		private decimal _vendedor_comisionista_id;
		private bool _vendedor_comisionista_idNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _total_recargo_financiero;
		private decimal _ctacte_recargo_id;
		private bool _ctacte_recargo_idNull = true;
		private decimal _total_neto_luego_de_nc;
		private decimal _total_neto_luego_de_nc_aux;
		private decimal _cantidad_anterior_aux;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DETALLERow_Base"/> class.
		/// </summary>
		public FACTURAS_CLIENTE_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_CLIENTE_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FACTURAS_CLIENTE_ID != original.FACTURAS_CLIENTE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
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
			if (this.CANTIDAD_EMBALADA != original.CANTIDAD_EMBALADA) return true;
			if (this.CANTIDAD_UNIDAD_DESTINO != original.CANTIDAD_UNIDAD_DESTINO) return true;
			if (this.CANTIDAD_POR_CAJA_DESTINO != original.CANTIDAD_POR_CAJA_DESTINO) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL_DEST != original.CANTIDAD_UNITARIA_TOTAL_DEST) return true;
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
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_CODIGO_BARRAS != original.ARTICULO_CODIGO_BARRAS) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.CANTIDAD_DEVUELTA_NOTA_CREDITO != original.CANTIDAD_DEVUELTA_NOTA_CREDITO) return true;
			if (this.IsPORCENTAJE_IMPUESTONull != original.IsPORCENTAJE_IMPUESTONull) return true;
			if (!this.IsPORCENTAJE_IMPUESTONull && !original.IsPORCENTAJE_IMPUESTONull)
				if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.UNIDAD_ORIGEN_ID != original.UNIDAD_ORIGEN_ID) return true;
			if (this.IsCANTIDAD_UNIDAD_ORIGENNull != original.IsCANTIDAD_UNIDAD_ORIGENNull) return true;
			if (!this.IsCANTIDAD_UNIDAD_ORIGENNull && !original.IsCANTIDAD_UNIDAD_ORIGENNull)
				if (this.CANTIDAD_UNIDAD_ORIGEN != original.CANTIDAD_UNIDAD_ORIGEN) return true;
			if (this.IsCANTIDAD_POR_CAJA_ORIGENNull != original.IsCANTIDAD_POR_CAJA_ORIGENNull) return true;
			if (!this.IsCANTIDAD_POR_CAJA_ORIGENNull && !original.IsCANTIDAD_POR_CAJA_ORIGENNull)
				if (this.CANTIDAD_POR_CAJA_ORIGEN != original.CANTIDAD_POR_CAJA_ORIGEN) return true;
			if (this.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull != original.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull && !original.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull)
				if (this.CANTIDAD_UNITARIA_TOTAL_ORIG != original.CANTIDAD_UNITARIA_TOTAL_ORIG) return true;
			if (this.PRECIO_LISTA_ORIGEN != original.PRECIO_LISTA_ORIGEN) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.IsCOSTO_IDNull != original.IsCOSTO_IDNull) return true;
			if (!this.IsCOSTO_IDNull && !original.IsCOSTO_IDNull)
				if (this.COSTO_ID != original.COSTO_ID) return true;
			if (this.COSTO_MONTO != original.COSTO_MONTO) return true;
			if (this.IsCOSTO_MONEDA_IDNull != original.IsCOSTO_MONEDA_IDNull) return true;
			if (!this.IsCOSTO_MONEDA_IDNull && !original.IsCOSTO_MONEDA_IDNull)
				if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.IsCOSTO_MONEDA_COTIZACIONNull != original.IsCOSTO_MONEDA_COTIZACIONNull) return true;
			if (!this.IsCOSTO_MONEDA_COTIZACIONNull && !original.IsCOSTO_MONEDA_COTIZACIONNull)
				if (this.COSTO_MONEDA_COTIZACION != original.COSTO_MONEDA_COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsVENDEDOR_COMISIONISTA_IDNull != original.IsVENDEDOR_COMISIONISTA_IDNull) return true;
			if (!this.IsVENDEDOR_COMISIONISTA_IDNull && !original.IsVENDEDOR_COMISIONISTA_IDNull)
				if (this.VENDEDOR_COMISIONISTA_ID != original.VENDEDOR_COMISIONISTA_ID) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.TOTAL_RECARGO_FINANCIERO != original.TOTAL_RECARGO_FINANCIERO) return true;
			if (this.IsCTACTE_RECARGO_IDNull != original.IsCTACTE_RECARGO_IDNull) return true;
			if (!this.IsCTACTE_RECARGO_IDNull && !original.IsCTACTE_RECARGO_IDNull)
				if (this.CTACTE_RECARGO_ID != original.CTACTE_RECARGO_ID) return true;
			if (this.TOTAL_NETO_LUEGO_DE_NC != original.TOTAL_NETO_LUEGO_DE_NC) return true;
			if (this.TOTAL_NETO_LUEGO_DE_NC_AUX != original.TOTAL_NETO_LUEGO_DE_NC_AUX) return true;
			if (this.CANTIDAD_ANTERIOR_AUX != original.CANTIDAD_ANTERIOR_AUX) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			
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
		/// Gets or sets the <c>FACTURAS_CLIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAS_CLIENTE_ID</c> column value.</value>
		public decimal FACTURAS_CLIENTE_ID
		{
			get { return _facturas_cliente_id; }
			set { _facturas_cliente_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_EMBALADA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_EMBALADA</c> column value.</value>
		public decimal CANTIDAD_EMBALADA
		{
			get { return _cantidad_embalada; }
			set { _cantidad_embalada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNIDAD_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNIDAD_DESTINO</c> column value.</value>
		public decimal CANTIDAD_UNIDAD_DESTINO
		{
			get { return _cantidad_unidad_destino; }
			set { _cantidad_unidad_destino = value; }
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
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL_DEST</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL_DEST</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL_DEST
		{
			get { return _cantidad_unitaria_total_dest; }
			set { _cantidad_unitaria_total_dest = value; }
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
		/// Gets or sets the <c>ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO</c> column value.</value>
		public string ARTICULO_CODIGO
		{
			get { return _articulo_codigo; }
			set { _articulo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_CODIGO_BARRAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO_BARRAS</c> column value.</value>
		public string ARTICULO_CODIGO_BARRAS
		{
			get { return _articulo_codigo_barras; }
			set { _articulo_codigo_barras = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_DESCRIPCION
		{
			get { return _articulo_descripcion; }
			set { _articulo_descripcion = value; }
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
		/// Gets or sets the <c>CANTIDAD_DEVUELTA_NOTA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_DEVUELTA_NOTA_CREDITO</c> column value.</value>
		public decimal CANTIDAD_DEVUELTA_NOTA_CREDITO
		{
			get { return _cantidad_devuelta_nota_credito; }
			set { _cantidad_devuelta_nota_credito = value; }
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
		/// Gets or sets the <c>PRECIO_LISTA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_LISTA_ORIGEN</c> column value.</value>
		public decimal PRECIO_LISTA_ORIGEN
		{
			get { return _precio_lista_origen; }
			set { _precio_lista_origen = value; }
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
		/// Gets or sets the <c>TOTAL_RECARGO_FINANCIERO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_RECARGO_FINANCIERO</c> column value.</value>
		public decimal TOTAL_RECARGO_FINANCIERO
		{
			get { return _total_recargo_financiero; }
			set { _total_recargo_financiero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECARGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECARGO_ID</c> column value.</value>
		public decimal CTACTE_RECARGO_ID
		{
			get
			{
				if(IsCTACTE_RECARGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_recargo_id;
			}
			set
			{
				_ctacte_recargo_idNull = false;
				_ctacte_recargo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RECARGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RECARGO_IDNull
		{
			get { return _ctacte_recargo_idNull; }
			set { _ctacte_recargo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO_LUEGO_DE_NC</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_NETO_LUEGO_DE_NC</c> column value.</value>
		public decimal TOTAL_NETO_LUEGO_DE_NC
		{
			get { return _total_neto_luego_de_nc; }
			set { _total_neto_luego_de_nc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO_LUEGO_DE_NC_AUX</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_NETO_LUEGO_DE_NC_AUX</c> column value.</value>
		public decimal TOTAL_NETO_LUEGO_DE_NC_AUX
		{
			get { return _total_neto_luego_de_nc_aux; }
			set { _total_neto_luego_de_nc_aux = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_ANTERIOR_AUX</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_ANTERIOR_AUX</c> column value.</value>
		public decimal CANTIDAD_ANTERIOR_AUX
		{
			get { return _cantidad_anterior_aux; }
			set { _cantidad_anterior_aux = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ASOCIADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_ID</c> column value.</value>
		public decimal CASO_ASOCIADO_ID
		{
			get
			{
				if(IsCASO_ASOCIADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_asociado_id;
			}
			set
			{
				_caso_asociado_idNull = false;
				_caso_asociado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ASOCIADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ASOCIADO_IDNull
		{
			get { return _caso_asociado_idNull; }
			set { _caso_asociado_idNull = value; }
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
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
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
			dynStr.Append("@CBA@FACTURAS_CLIENTE_ID=");
			dynStr.Append(FACTURAS_CLIENTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_ORIGEN=");
			dynStr.Append(IsCOTIZACION_ORIGENNull ? (object)"<NULL>" : COTIZACION_ORIGEN);
			dynStr.Append("@CBA@COTIZACION_MONEDA_LINEA_CRED=");
			dynStr.Append(IsCOTIZACION_MONEDA_LINEA_CREDNull ? (object)"<NULL>" : COTIZACION_MONEDA_LINEA_CRED);
			dynStr.Append("@CBA@UNIDAD_DESTINO_ID=");
			dynStr.Append(UNIDAD_DESTINO_ID);
			dynStr.Append("@CBA@CANTIDAD_EMBALADA=");
			dynStr.Append(CANTIDAD_EMBALADA);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_DESTINO=");
			dynStr.Append(CANTIDAD_UNIDAD_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_DESTINO=");
			dynStr.Append(CANTIDAD_POR_CAJA_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_DEST=");
			dynStr.Append(CANTIDAD_UNITARIA_TOTAL_DEST);
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
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_CODIGO_BARRAS=");
			dynStr.Append(ARTICULO_CODIGO_BARRAS);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@CANTIDAD_DEVUELTA_NOTA_CREDITO=");
			dynStr.Append(CANTIDAD_DEVUELTA_NOTA_CREDITO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(IsPORCENTAJE_IMPUESTONull ? (object)"<NULL>" : PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@UNIDAD_ORIGEN_ID=");
			dynStr.Append(UNIDAD_ORIGEN_ID);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_ORIGEN=");
			dynStr.Append(IsCANTIDAD_UNIDAD_ORIGENNull ? (object)"<NULL>" : CANTIDAD_UNIDAD_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_ORIGEN=");
			dynStr.Append(IsCANTIDAD_POR_CAJA_ORIGENNull ? (object)"<NULL>" : CANTIDAD_POR_CAJA_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_ORIG=");
			dynStr.Append(IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_TOTAL_ORIG);
			dynStr.Append("@CBA@PRECIO_LISTA_ORIGEN=");
			dynStr.Append(PRECIO_LISTA_ORIGEN);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@COSTO_ID=");
			dynStr.Append(IsCOSTO_IDNull ? (object)"<NULL>" : COSTO_ID);
			dynStr.Append("@CBA@COSTO_MONTO=");
			dynStr.Append(COSTO_MONTO);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(IsCOSTO_MONEDA_IDNull ? (object)"<NULL>" : COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_MONEDA_COTIZACION=");
			dynStr.Append(IsCOSTO_MONEDA_COTIZACIONNull ? (object)"<NULL>" : COSTO_MONEDA_COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@VENDEDOR_COMISIONISTA_ID=");
			dynStr.Append(IsVENDEDOR_COMISIONISTA_IDNull ? (object)"<NULL>" : VENDEDOR_COMISIONISTA_ID);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@TOTAL_RECARGO_FINANCIERO=");
			dynStr.Append(TOTAL_RECARGO_FINANCIERO);
			dynStr.Append("@CBA@CTACTE_RECARGO_ID=");
			dynStr.Append(IsCTACTE_RECARGO_IDNull ? (object)"<NULL>" : CTACTE_RECARGO_ID);
			dynStr.Append("@CBA@TOTAL_NETO_LUEGO_DE_NC=");
			dynStr.Append(TOTAL_NETO_LUEGO_DE_NC);
			dynStr.Append("@CBA@TOTAL_NETO_LUEGO_DE_NC_AUX=");
			dynStr.Append(TOTAL_NETO_LUEGO_DE_NC_AUX);
			dynStr.Append("@CBA@CANTIDAD_ANTERIOR_AUX=");
			dynStr.Append(CANTIDAD_ANTERIOR_AUX);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			return dynStr.ToString();
		}
	} // End of FACTURAS_CLIENTE_DETALLERow_Base class
} // End of namespace
