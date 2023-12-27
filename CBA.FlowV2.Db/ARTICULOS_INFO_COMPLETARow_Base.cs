// <fileinfo name="ARTICULOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ARTICULOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _region_id;
		private bool _region_idNull = true;
		private string _codigo_empresa;
		private string _codigo_proveedor;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _codigo_barras_empresa;
		private string _codigo_barras_proveedor;
		private string _descripcion_interna;
		private string _descripcion_impresion;
		private string _descripcion_catalogo;
		private string _descripcion_proveedor;
		private string _descripcion_a_utilizar;
		private string _descripcion_sin_codigo;
		private decimal _codigo_presentacion_id;
		private bool _codigo_presentacion_idNull = true;
		private decimal _codigo_empaque_id;
		private bool _codigo_empaque_idNull = true;
		private decimal _codigo_color_id;
		private bool _codigo_color_idNull = true;
		private decimal _codigo_talle_id;
		private bool _codigo_talle_idNull = true;
		private string _codigo_balanza;
		private string _codigo_catalogo_proveedor;
		private string _proveedor_razon_social;
		private string _importado;
		private string _produccion_interna;
		private string _no_reponer;
		private string _unidad_medida_id;
		private decimal _factor_conversion_kg;
		private bool _factor_conversion_kgNull = true;
		private decimal _factor_conversion_m;
		private bool _factor_conversion_mNull = true;
		private decimal _cantidad_por_caja;
		private decimal _impuesto_id;
		private decimal _impuesto_compra_id;
		private bool _impuesto_compra_idNull = true;
		private string _servicio;
		private decimal _combo_id;
		private bool _combo_idNull = true;
		private string _estado;
		private string _ingreso_aprobado;
		private decimal _usuario_aprobacion_id;
		private bool _usuario_aprobacion_idNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private decimal _porcentaje_precio_padre;
		private bool _porcentaje_precio_padreNull = true;
		private decimal _monto_precio_padre;
		private bool _monto_precio_padreNull = true;
		private string _impuesto_descripcion;
		private string _impuesto_compra_descripcion;
		private string _familia_descripcion;
		private string _grupo_descripcion;
		private string _subgrupo_descripcion;
		private string _presentacion_descripcion;
		private string _empaque_descripcion;
		private string _color_descripcion;
		private string _talle_descripcion;
		private string _familia_codigo;
		private string _grupo_codigo;
		private string _subgrupo_codigo;
		private decimal _familia_orden;
		private bool _familia_ordenNull = true;
		private decimal _grupo_orden;
		private bool _grupo_ordenNull = true;
		private decimal _subgrupo_orden;
		private bool _subgrupo_ordenNull = true;
		private string _es_trazable;
		private string _es_usado;
		private string _es_danhado;
		private string _para_venta;
		private string _es_combo;
		private string _unidad_medida_descripcion;
		private decimal _articulo_linea_id;
		private bool _articulo_linea_idNull = true;
		private string _articulo_linea_nombre;
		private decimal _procedencia;
		private bool _procedenciaNull = true;
		private string _procedencia_gentilicio;
		private string _genero;
		private decimal _articulo_padre_id;
		private bool _articulo_padre_idNull = true;
		private string _es_combo_abierto;
		private string _articulo_padre_nombre;
		private string _articulo_padre_codigo;
		private decimal _articulo_marca_id;
		private bool _articulo_marca_idNull = true;
		private string _articulo_marca_nombre;
		private System.DateTime _ultimo_ingreso_stock_fecha;
		private bool _ultimo_ingreso_stock_fechaNull = true;
		private decimal _existencia_total;
		private bool _existencia_totalNull = true;
		private string _es_modificable;
		private string _recargo_financiero;
		private string _controlar_precio;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _tipo_nota_credito_id;
		private bool _tipo_nota_credito_idNull = true;
		private decimal _costo_base_monto;
		private bool _costo_base_montoNull = true;
		private decimal _costo_base_moneda_id;
		private bool _costo_base_moneda_idNull = true;
		private decimal _costo_base_cotizacion;
		private bool _costo_base_cotizacionNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private string _es_obsoleto;
		private string _es_combo_representativo;
		private string _imagen_path_tmp;
		private decimal _costo_ppp;
		private bool _costo_pppNull = true;
		private System.DateTime _fecha_cierre;
		private bool _fecha_cierreNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _retencion;
		private bool _retencionNull = true;
		private decimal _cantidad_minima;
		private bool _cantidad_minimaNull = true;
		private decimal _cantidad_maxima;
		private bool _cantidad_maximaNull = true;
		private decimal _cantidad_mayorista;
		private bool _cantidad_mayoristaNull = true;
		private string _unidad_medida_control;
		private string _para_compra;
		private string _es_formula;
		private string _tipo_formula;
		private decimal _autonumeraciones_id;
		private bool _autonumeraciones_idNull = true;
		private decimal _cantidad_minima_produccion;
		private bool _cantidad_minima_produccionNull = true;
		private decimal _cantidad_maxima_produccion;
		private bool _cantidad_maxima_produccionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ARTICULOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.CODIGO_EMPRESA != original.CODIGO_EMPRESA) return true;
			if (this.CODIGO_PROVEEDOR != original.CODIGO_PROVEEDOR) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.CODIGO_BARRAS_EMPRESA != original.CODIGO_BARRAS_EMPRESA) return true;
			if (this.CODIGO_BARRAS_PROVEEDOR != original.CODIGO_BARRAS_PROVEEDOR) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.DESCRIPCION_IMPRESION != original.DESCRIPCION_IMPRESION) return true;
			if (this.DESCRIPCION_CATALOGO != original.DESCRIPCION_CATALOGO) return true;
			if (this.DESCRIPCION_PROVEEDOR != original.DESCRIPCION_PROVEEDOR) return true;
			if (this.DESCRIPCION_A_UTILIZAR != original.DESCRIPCION_A_UTILIZAR) return true;
			if (this.DESCRIPCION_SIN_CODIGO != original.DESCRIPCION_SIN_CODIGO) return true;
			if (this.IsCODIGO_PRESENTACION_IDNull != original.IsCODIGO_PRESENTACION_IDNull) return true;
			if (!this.IsCODIGO_PRESENTACION_IDNull && !original.IsCODIGO_PRESENTACION_IDNull)
				if (this.CODIGO_PRESENTACION_ID != original.CODIGO_PRESENTACION_ID) return true;
			if (this.IsCODIGO_EMPAQUE_IDNull != original.IsCODIGO_EMPAQUE_IDNull) return true;
			if (!this.IsCODIGO_EMPAQUE_IDNull && !original.IsCODIGO_EMPAQUE_IDNull)
				if (this.CODIGO_EMPAQUE_ID != original.CODIGO_EMPAQUE_ID) return true;
			if (this.IsCODIGO_COLOR_IDNull != original.IsCODIGO_COLOR_IDNull) return true;
			if (!this.IsCODIGO_COLOR_IDNull && !original.IsCODIGO_COLOR_IDNull)
				if (this.CODIGO_COLOR_ID != original.CODIGO_COLOR_ID) return true;
			if (this.IsCODIGO_TALLE_IDNull != original.IsCODIGO_TALLE_IDNull) return true;
			if (!this.IsCODIGO_TALLE_IDNull && !original.IsCODIGO_TALLE_IDNull)
				if (this.CODIGO_TALLE_ID != original.CODIGO_TALLE_ID) return true;
			if (this.CODIGO_BALANZA != original.CODIGO_BALANZA) return true;
			if (this.CODIGO_CATALOGO_PROVEEDOR != original.CODIGO_CATALOGO_PROVEEDOR) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.IMPORTADO != original.IMPORTADO) return true;
			if (this.PRODUCCION_INTERNA != original.PRODUCCION_INTERNA) return true;
			if (this.NO_REPONER != original.NO_REPONER) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.IsFACTOR_CONVERSION_KGNull != original.IsFACTOR_CONVERSION_KGNull) return true;
			if (!this.IsFACTOR_CONVERSION_KGNull && !original.IsFACTOR_CONVERSION_KGNull)
				if (this.FACTOR_CONVERSION_KG != original.FACTOR_CONVERSION_KG) return true;
			if (this.IsFACTOR_CONVERSION_MNull != original.IsFACTOR_CONVERSION_MNull) return true;
			if (!this.IsFACTOR_CONVERSION_MNull && !original.IsFACTOR_CONVERSION_MNull)
				if (this.FACTOR_CONVERSION_M != original.FACTOR_CONVERSION_M) return true;
			if (this.CANTIDAD_POR_CAJA != original.CANTIDAD_POR_CAJA) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsIMPUESTO_COMPRA_IDNull != original.IsIMPUESTO_COMPRA_IDNull) return true;
			if (!this.IsIMPUESTO_COMPRA_IDNull && !original.IsIMPUESTO_COMPRA_IDNull)
				if (this.IMPUESTO_COMPRA_ID != original.IMPUESTO_COMPRA_ID) return true;
			if (this.SERVICIO != original.SERVICIO) return true;
			if (this.IsCOMBO_IDNull != original.IsCOMBO_IDNull) return true;
			if (!this.IsCOMBO_IDNull && !original.IsCOMBO_IDNull)
				if (this.COMBO_ID != original.COMBO_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.INGRESO_APROBADO != original.INGRESO_APROBADO) return true;
			if (this.IsUSUARIO_APROBACION_IDNull != original.IsUSUARIO_APROBACION_IDNull) return true;
			if (!this.IsUSUARIO_APROBACION_IDNull && !original.IsUSUARIO_APROBACION_IDNull)
				if (this.USUARIO_APROBACION_ID != original.USUARIO_APROBACION_ID) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.IsPORCENTAJE_PRECIO_PADRENull != original.IsPORCENTAJE_PRECIO_PADRENull) return true;
			if (!this.IsPORCENTAJE_PRECIO_PADRENull && !original.IsPORCENTAJE_PRECIO_PADRENull)
				if (this.PORCENTAJE_PRECIO_PADRE != original.PORCENTAJE_PRECIO_PADRE) return true;
			if (this.IsMONTO_PRECIO_PADRENull != original.IsMONTO_PRECIO_PADRENull) return true;
			if (!this.IsMONTO_PRECIO_PADRENull && !original.IsMONTO_PRECIO_PADRENull)
				if (this.MONTO_PRECIO_PADRE != original.MONTO_PRECIO_PADRE) return true;
			if (this.IMPUESTO_DESCRIPCION != original.IMPUESTO_DESCRIPCION) return true;
			if (this.IMPUESTO_COMPRA_DESCRIPCION != original.IMPUESTO_COMPRA_DESCRIPCION) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			if (this.PRESENTACION_DESCRIPCION != original.PRESENTACION_DESCRIPCION) return true;
			if (this.EMPAQUE_DESCRIPCION != original.EMPAQUE_DESCRIPCION) return true;
			if (this.COLOR_DESCRIPCION != original.COLOR_DESCRIPCION) return true;
			if (this.TALLE_DESCRIPCION != original.TALLE_DESCRIPCION) return true;
			if (this.FAMILIA_CODIGO != original.FAMILIA_CODIGO) return true;
			if (this.GRUPO_CODIGO != original.GRUPO_CODIGO) return true;
			if (this.SUBGRUPO_CODIGO != original.SUBGRUPO_CODIGO) return true;
			if (this.IsFAMILIA_ORDENNull != original.IsFAMILIA_ORDENNull) return true;
			if (!this.IsFAMILIA_ORDENNull && !original.IsFAMILIA_ORDENNull)
				if (this.FAMILIA_ORDEN != original.FAMILIA_ORDEN) return true;
			if (this.IsGRUPO_ORDENNull != original.IsGRUPO_ORDENNull) return true;
			if (!this.IsGRUPO_ORDENNull && !original.IsGRUPO_ORDENNull)
				if (this.GRUPO_ORDEN != original.GRUPO_ORDEN) return true;
			if (this.IsSUBGRUPO_ORDENNull != original.IsSUBGRUPO_ORDENNull) return true;
			if (!this.IsSUBGRUPO_ORDENNull && !original.IsSUBGRUPO_ORDENNull)
				if (this.SUBGRUPO_ORDEN != original.SUBGRUPO_ORDEN) return true;
			if (this.ES_TRAZABLE != original.ES_TRAZABLE) return true;
			if (this.ES_USADO != original.ES_USADO) return true;
			if (this.ES_DANHADO != original.ES_DANHADO) return true;
			if (this.PARA_VENTA != original.PARA_VENTA) return true;
			if (this.ES_COMBO != original.ES_COMBO) return true;
			if (this.UNIDAD_MEDIDA_DESCRIPCION != original.UNIDAD_MEDIDA_DESCRIPCION) return true;
			if (this.IsARTICULO_LINEA_IDNull != original.IsARTICULO_LINEA_IDNull) return true;
			if (!this.IsARTICULO_LINEA_IDNull && !original.IsARTICULO_LINEA_IDNull)
				if (this.ARTICULO_LINEA_ID != original.ARTICULO_LINEA_ID) return true;
			if (this.ARTICULO_LINEA_NOMBRE != original.ARTICULO_LINEA_NOMBRE) return true;
			if (this.IsPROCEDENCIANull != original.IsPROCEDENCIANull) return true;
			if (!this.IsPROCEDENCIANull && !original.IsPROCEDENCIANull)
				if (this.PROCEDENCIA != original.PROCEDENCIA) return true;
			if (this.PROCEDENCIA_GENTILICIO != original.PROCEDENCIA_GENTILICIO) return true;
			if (this.GENERO != original.GENERO) return true;
			if (this.IsARTICULO_PADRE_IDNull != original.IsARTICULO_PADRE_IDNull) return true;
			if (!this.IsARTICULO_PADRE_IDNull && !original.IsARTICULO_PADRE_IDNull)
				if (this.ARTICULO_PADRE_ID != original.ARTICULO_PADRE_ID) return true;
			if (this.ES_COMBO_ABIERTO != original.ES_COMBO_ABIERTO) return true;
			if (this.ARTICULO_PADRE_NOMBRE != original.ARTICULO_PADRE_NOMBRE) return true;
			if (this.ARTICULO_PADRE_CODIGO != original.ARTICULO_PADRE_CODIGO) return true;
			if (this.IsARTICULO_MARCA_IDNull != original.IsARTICULO_MARCA_IDNull) return true;
			if (!this.IsARTICULO_MARCA_IDNull && !original.IsARTICULO_MARCA_IDNull)
				if (this.ARTICULO_MARCA_ID != original.ARTICULO_MARCA_ID) return true;
			if (this.ARTICULO_MARCA_NOMBRE != original.ARTICULO_MARCA_NOMBRE) return true;
			if (this.IsULTIMO_INGRESO_STOCK_FECHANull != original.IsULTIMO_INGRESO_STOCK_FECHANull) return true;
			if (!this.IsULTIMO_INGRESO_STOCK_FECHANull && !original.IsULTIMO_INGRESO_STOCK_FECHANull)
				if (this.ULTIMO_INGRESO_STOCK_FECHA != original.ULTIMO_INGRESO_STOCK_FECHA) return true;
			if (this.IsEXISTENCIA_TOTALNull != original.IsEXISTENCIA_TOTALNull) return true;
			if (!this.IsEXISTENCIA_TOTALNull && !original.IsEXISTENCIA_TOTALNull)
				if (this.EXISTENCIA_TOTAL != original.EXISTENCIA_TOTAL) return true;
			if (this.ES_MODIFICABLE != original.ES_MODIFICABLE) return true;
			if (this.RECARGO_FINANCIERO != original.RECARGO_FINANCIERO) return true;
			if (this.CONTROLAR_PRECIO != original.CONTROLAR_PRECIO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsTIPO_NOTA_CREDITO_IDNull != original.IsTIPO_NOTA_CREDITO_IDNull) return true;
			if (!this.IsTIPO_NOTA_CREDITO_IDNull && !original.IsTIPO_NOTA_CREDITO_IDNull)
				if (this.TIPO_NOTA_CREDITO_ID != original.TIPO_NOTA_CREDITO_ID) return true;
			if (this.IsCOSTO_BASE_MONTONull != original.IsCOSTO_BASE_MONTONull) return true;
			if (!this.IsCOSTO_BASE_MONTONull && !original.IsCOSTO_BASE_MONTONull)
				if (this.COSTO_BASE_MONTO != original.COSTO_BASE_MONTO) return true;
			if (this.IsCOSTO_BASE_MONEDA_IDNull != original.IsCOSTO_BASE_MONEDA_IDNull) return true;
			if (!this.IsCOSTO_BASE_MONEDA_IDNull && !original.IsCOSTO_BASE_MONEDA_IDNull)
				if (this.COSTO_BASE_MONEDA_ID != original.COSTO_BASE_MONEDA_ID) return true;
			if (this.IsCOSTO_BASE_COTIZACIONNull != original.IsCOSTO_BASE_COTIZACIONNull) return true;
			if (!this.IsCOSTO_BASE_COTIZACIONNull && !original.IsCOSTO_BASE_COTIZACIONNull)
				if (this.COSTO_BASE_COTIZACION != original.COSTO_BASE_COTIZACION) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.ES_OBSOLETO != original.ES_OBSOLETO) return true;
			if (this.ES_COMBO_REPRESENTATIVO != original.ES_COMBO_REPRESENTATIVO) return true;
			if (this.IMAGEN_PATH_TMP != original.IMAGEN_PATH_TMP) return true;
			if (this.IsCOSTO_PPPNull != original.IsCOSTO_PPPNull) return true;
			if (!this.IsCOSTO_PPPNull && !original.IsCOSTO_PPPNull)
				if (this.COSTO_PPP != original.COSTO_PPP) return true;
			if (this.IsFECHA_CIERRENull != original.IsFECHA_CIERRENull) return true;
			if (!this.IsFECHA_CIERRENull && !original.IsFECHA_CIERRENull)
				if (this.FECHA_CIERRE != original.FECHA_CIERRE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsRETENCIONNull != original.IsRETENCIONNull) return true;
			if (!this.IsRETENCIONNull && !original.IsRETENCIONNull)
				if (this.RETENCION != original.RETENCION) return true;
			if (this.IsCANTIDAD_MINIMANull != original.IsCANTIDAD_MINIMANull) return true;
			if (!this.IsCANTIDAD_MINIMANull && !original.IsCANTIDAD_MINIMANull)
				if (this.CANTIDAD_MINIMA != original.CANTIDAD_MINIMA) return true;
			if (this.IsCANTIDAD_MAXIMANull != original.IsCANTIDAD_MAXIMANull) return true;
			if (!this.IsCANTIDAD_MAXIMANull && !original.IsCANTIDAD_MAXIMANull)
				if (this.CANTIDAD_MAXIMA != original.CANTIDAD_MAXIMA) return true;
			if (this.IsCANTIDAD_MAYORISTANull != original.IsCANTIDAD_MAYORISTANull) return true;
			if (!this.IsCANTIDAD_MAYORISTANull && !original.IsCANTIDAD_MAYORISTANull)
				if (this.CANTIDAD_MAYORISTA != original.CANTIDAD_MAYORISTA) return true;
			if (this.UNIDAD_MEDIDA_CONTROL != original.UNIDAD_MEDIDA_CONTROL) return true;
			if (this.PARA_COMPRA != original.PARA_COMPRA) return true;
			if (this.ES_FORMULA != original.ES_FORMULA) return true;
			if (this.TIPO_FORMULA != original.TIPO_FORMULA) return true;
			if (this.IsAUTONUMERACIONES_IDNull != original.IsAUTONUMERACIONES_IDNull) return true;
			if (!this.IsAUTONUMERACIONES_IDNull && !original.IsAUTONUMERACIONES_IDNull)
				if (this.AUTONUMERACIONES_ID != original.AUTONUMERACIONES_ID) return true;
			if (this.IsCANTIDAD_MINIMA_PRODUCCIONNull != original.IsCANTIDAD_MINIMA_PRODUCCIONNull) return true;
			if (!this.IsCANTIDAD_MINIMA_PRODUCCIONNull && !original.IsCANTIDAD_MINIMA_PRODUCCIONNull)
				if (this.CANTIDAD_MINIMA_PRODUCCION != original.CANTIDAD_MINIMA_PRODUCCION) return true;
			if (this.IsCANTIDAD_MAXIMA_PRODUCCIONNull != original.IsCANTIDAD_MAXIMA_PRODUCCIONNull) return true;
			if (!this.IsCANTIDAD_MAXIMA_PRODUCCIONNull && !original.IsCANTIDAD_MAXIMA_PRODUCCIONNull)
				if (this.CANTIDAD_MAXIMA_PRODUCCION != original.CANTIDAD_MAXIMA_PRODUCCION) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EMPRESA</c> column value.</value>
		public string CODIGO_EMPRESA
		{
			get { return _codigo_empresa; }
			set { _codigo_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_PROVEEDOR</c> column value.</value>
		public string CODIGO_PROVEEDOR
		{
			get { return _codigo_proveedor; }
			set { _codigo_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public decimal SUBGRUPO_ID
		{
			get
			{
				if(IsSUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_id;
			}
			set
			{
				_subgrupo_idNull = false;
				_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_IDNull
		{
			get { return _subgrupo_idNull; }
			set { _subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BARRAS_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_BARRAS_EMPRESA</c> column value.</value>
		public string CODIGO_BARRAS_EMPRESA
		{
			get { return _codigo_barras_empresa; }
			set { _codigo_barras_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BARRAS_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_BARRAS_PROVEEDOR</c> column value.</value>
		public string CODIGO_BARRAS_PROVEEDOR
		{
			get { return _codigo_barras_proveedor; }
			set { _codigo_barras_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_INTERNA</c> column value.</value>
		public string DESCRIPCION_INTERNA
		{
			get { return _descripcion_interna; }
			set { _descripcion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_IMPRESION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_IMPRESION</c> column value.</value>
		public string DESCRIPCION_IMPRESION
		{
			get { return _descripcion_impresion; }
			set { _descripcion_impresion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_CATALOGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_CATALOGO</c> column value.</value>
		public string DESCRIPCION_CATALOGO
		{
			get { return _descripcion_catalogo; }
			set { _descripcion_catalogo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_PROVEEDOR</c> column value.</value>
		public string DESCRIPCION_PROVEEDOR
		{
			get { return _descripcion_proveedor; }
			set { _descripcion_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_A_UTILIZAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_A_UTILIZAR</c> column value.</value>
		public string DESCRIPCION_A_UTILIZAR
		{
			get { return _descripcion_a_utilizar; }
			set { _descripcion_a_utilizar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_SIN_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_SIN_CODIGO</c> column value.</value>
		public string DESCRIPCION_SIN_CODIGO
		{
			get { return _descripcion_sin_codigo; }
			set { _descripcion_sin_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_PRESENTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_PRESENTACION_ID</c> column value.</value>
		public decimal CODIGO_PRESENTACION_ID
		{
			get
			{
				if(IsCODIGO_PRESENTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _codigo_presentacion_id;
			}
			set
			{
				_codigo_presentacion_idNull = false;
				_codigo_presentacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CODIGO_PRESENTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCODIGO_PRESENTACION_IDNull
		{
			get { return _codigo_presentacion_idNull; }
			set { _codigo_presentacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_EMPAQUE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EMPAQUE_ID</c> column value.</value>
		public decimal CODIGO_EMPAQUE_ID
		{
			get
			{
				if(IsCODIGO_EMPAQUE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _codigo_empaque_id;
			}
			set
			{
				_codigo_empaque_idNull = false;
				_codigo_empaque_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CODIGO_EMPAQUE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCODIGO_EMPAQUE_IDNull
		{
			get { return _codigo_empaque_idNull; }
			set { _codigo_empaque_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_COLOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_COLOR_ID</c> column value.</value>
		public decimal CODIGO_COLOR_ID
		{
			get
			{
				if(IsCODIGO_COLOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _codigo_color_id;
			}
			set
			{
				_codigo_color_idNull = false;
				_codigo_color_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CODIGO_COLOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCODIGO_COLOR_IDNull
		{
			get { return _codigo_color_idNull; }
			set { _codigo_color_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_TALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_TALLE_ID</c> column value.</value>
		public decimal CODIGO_TALLE_ID
		{
			get
			{
				if(IsCODIGO_TALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _codigo_talle_id;
			}
			set
			{
				_codigo_talle_idNull = false;
				_codigo_talle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CODIGO_TALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCODIGO_TALLE_IDNull
		{
			get { return _codigo_talle_idNull; }
			set { _codigo_talle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_BALANZA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_BALANZA</c> column value.</value>
		public string CODIGO_BALANZA
		{
			get { return _codigo_balanza; }
			set { _codigo_balanza = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_CATALOGO_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_CATALOGO_PROVEEDOR</c> column value.</value>
		public string CODIGO_CATALOGO_PROVEEDOR
		{
			get { return _codigo_catalogo_proveedor; }
			set { _codigo_catalogo_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_RAZON_SOCIAL
		{
			get { return _proveedor_razon_social; }
			set { _proveedor_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTADO</c> column value.
		/// </summary>
		/// <value>The <c>IMPORTADO</c> column value.</value>
		public string IMPORTADO
		{
			get { return _importado; }
			set { _importado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRODUCCION_INTERNA</c> column value.
		/// </summary>
		/// <value>The <c>PRODUCCION_INTERNA</c> column value.</value>
		public string PRODUCCION_INTERNA
		{
			get { return _produccion_interna; }
			set { _produccion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NO_REPONER</c> column value.
		/// </summary>
		/// <value>The <c>NO_REPONER</c> column value.</value>
		public string NO_REPONER
		{
			get { return _no_reponer; }
			set { _no_reponer = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_CONVERSION_KG</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTOR_CONVERSION_KG</c> column value.</value>
		public decimal FACTOR_CONVERSION_KG
		{
			get
			{
				if(IsFACTOR_CONVERSION_KGNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factor_conversion_kg;
			}
			set
			{
				_factor_conversion_kgNull = false;
				_factor_conversion_kg = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTOR_CONVERSION_KG"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTOR_CONVERSION_KGNull
		{
			get { return _factor_conversion_kgNull; }
			set { _factor_conversion_kgNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_CONVERSION_M</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTOR_CONVERSION_M</c> column value.</value>
		public decimal FACTOR_CONVERSION_M
		{
			get
			{
				if(IsFACTOR_CONVERSION_MNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factor_conversion_m;
			}
			set
			{
				_factor_conversion_mNull = false;
				_factor_conversion_m = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTOR_CONVERSION_M"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTOR_CONVERSION_MNull
		{
			get { return _factor_conversion_mNull; }
			set { _factor_conversion_mNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_POR_CAJA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA
		{
			get { return _cantidad_por_caja; }
			set { _cantidad_por_caja = value; }
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
		/// Gets or sets the <c>IMPUESTO_COMPRA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_COMPRA_ID</c> column value.</value>
		public decimal IMPUESTO_COMPRA_ID
		{
			get
			{
				if(IsIMPUESTO_COMPRA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_compra_id;
			}
			set
			{
				_impuesto_compra_idNull = false;
				_impuesto_compra_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_COMPRA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_COMPRA_IDNull
		{
			get { return _impuesto_compra_idNull; }
			set { _impuesto_compra_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SERVICIO</c> column value.
		/// </summary>
		/// <value>The <c>SERVICIO</c> column value.</value>
		public string SERVICIO
		{
			get { return _servicio; }
			set { _servicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMBO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMBO_ID</c> column value.</value>
		public decimal COMBO_ID
		{
			get
			{
				if(IsCOMBO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _combo_id;
			}
			set
			{
				_combo_idNull = false;
				_combo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMBO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMBO_IDNull
		{
			get { return _combo_idNull; }
			set { _combo_idNull = value; }
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
		/// Gets or sets the <c>INGRESO_APROBADO</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_APROBADO</c> column value.</value>
		public string INGRESO_APROBADO
		{
			get { return _ingreso_aprobado; }
			set { _ingreso_aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_APROBACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROBACION_ID</c> column value.</value>
		public decimal USUARIO_APROBACION_ID
		{
			get
			{
				if(IsUSUARIO_APROBACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprobacion_id;
			}
			set
			{
				_usuario_aprobacion_idNull = false;
				_usuario_aprobacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROBACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROBACION_IDNull
		{
			get { return _usuario_aprobacion_idNull; }
			set { _usuario_aprobacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROBACION</c> column value.</value>
		public System.DateTime FECHA_APROBACION
		{
			get
			{
				if(IsFECHA_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprobacion;
			}
			set
			{
				_fecha_aprobacionNull = false;
				_fecha_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROBACIONNull
		{
			get { return _fecha_aprobacionNull; }
			set { _fecha_aprobacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_PRECIO_PADRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_PRECIO_PADRE</c> column value.</value>
		public decimal PORCENTAJE_PRECIO_PADRE
		{
			get
			{
				if(IsPORCENTAJE_PRECIO_PADRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_precio_padre;
			}
			set
			{
				_porcentaje_precio_padreNull = false;
				_porcentaje_precio_padre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_PRECIO_PADRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_PRECIO_PADRENull
		{
			get { return _porcentaje_precio_padreNull; }
			set { _porcentaje_precio_padreNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PRECIO_PADRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PRECIO_PADRE</c> column value.</value>
		public decimal MONTO_PRECIO_PADRE
		{
			get
			{
				if(IsMONTO_PRECIO_PADRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_precio_padre;
			}
			set
			{
				_monto_precio_padreNull = false;
				_monto_precio_padre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PRECIO_PADRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PRECIO_PADRENull
		{
			get { return _monto_precio_padreNull; }
			set { _monto_precio_padreNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_DESCRIPCION</c> column value.</value>
		public string IMPUESTO_DESCRIPCION
		{
			get { return _impuesto_descripcion; }
			set { _impuesto_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_COMPRA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_COMPRA_DESCRIPCION</c> column value.</value>
		public string IMPUESTO_COMPRA_DESCRIPCION
		{
			get { return _impuesto_compra_descripcion; }
			set { _impuesto_compra_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_DESCRIPCION</c> column value.</value>
		public string FAMILIA_DESCRIPCION
		{
			get { return _familia_descripcion; }
			set { _familia_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_DESCRIPCION</c> column value.</value>
		public string GRUPO_DESCRIPCION
		{
			get { return _grupo_descripcion; }
			set { _grupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_DESCRIPCION</c> column value.</value>
		public string SUBGRUPO_DESCRIPCION
		{
			get { return _subgrupo_descripcion; }
			set { _subgrupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESENTACION_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESENTACION_DESCRIPCION</c> column value.</value>
		public string PRESENTACION_DESCRIPCION
		{
			get { return _presentacion_descripcion; }
			set { _presentacion_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPAQUE_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPAQUE_DESCRIPCION</c> column value.</value>
		public string EMPAQUE_DESCRIPCION
		{
			get { return _empaque_descripcion; }
			set { _empaque_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLOR_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLOR_DESCRIPCION</c> column value.</value>
		public string COLOR_DESCRIPCION
		{
			get { return _color_descripcion; }
			set { _color_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TALLE_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TALLE_DESCRIPCION</c> column value.</value>
		public string TALLE_DESCRIPCION
		{
			get { return _talle_descripcion; }
			set { _talle_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_CODIGO</c> column value.</value>
		public string FAMILIA_CODIGO
		{
			get { return _familia_codigo; }
			set { _familia_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_CODIGO</c> column value.</value>
		public string GRUPO_CODIGO
		{
			get { return _grupo_codigo; }
			set { _grupo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_CODIGO</c> column value.</value>
		public string SUBGRUPO_CODIGO
		{
			get { return _subgrupo_codigo; }
			set { _subgrupo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ORDEN</c> column value.</value>
		public decimal FAMILIA_ORDEN
		{
			get
			{
				if(IsFAMILIA_ORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_orden;
			}
			set
			{
				_familia_ordenNull = false;
				_familia_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_ORDENNull
		{
			get { return _familia_ordenNull; }
			set { _familia_ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ORDEN</c> column value.</value>
		public decimal GRUPO_ORDEN
		{
			get
			{
				if(IsGRUPO_ORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_orden;
			}
			set
			{
				_grupo_ordenNull = false;
				_grupo_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_ORDENNull
		{
			get { return _grupo_ordenNull; }
			set { _grupo_ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ORDEN</c> column value.</value>
		public decimal SUBGRUPO_ORDEN
		{
			get
			{
				if(IsSUBGRUPO_ORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_orden;
			}
			set
			{
				_subgrupo_ordenNull = false;
				_subgrupo_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_ORDENNull
		{
			get { return _subgrupo_ordenNull; }
			set { _subgrupo_ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_TRAZABLE</c> column value.
		/// </summary>
		/// <value>The <c>ES_TRAZABLE</c> column value.</value>
		public string ES_TRAZABLE
		{
			get { return _es_trazable; }
			set { _es_trazable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_USADO</c> column value.
		/// </summary>
		/// <value>The <c>ES_USADO</c> column value.</value>
		public string ES_USADO
		{
			get { return _es_usado; }
			set { _es_usado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_DANHADO</c> column value.
		/// </summary>
		/// <value>The <c>ES_DANHADO</c> column value.</value>
		public string ES_DANHADO
		{
			get { return _es_danhado; }
			set { _es_danhado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PARA_VENTA</c> column value.
		/// </summary>
		/// <value>The <c>PARA_VENTA</c> column value.</value>
		public string PARA_VENTA
		{
			get { return _para_venta; }
			set { _para_venta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COMBO</c> column value.
		/// </summary>
		/// <value>The <c>ES_COMBO</c> column value.</value>
		public string ES_COMBO
		{
			get { return _es_combo; }
			set { _es_combo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_DESCRIPCION</c> column value.</value>
		public string UNIDAD_MEDIDA_DESCRIPCION
		{
			get { return _unidad_medida_descripcion; }
			set { _unidad_medida_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_LINEA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_LINEA_ID</c> column value.</value>
		public decimal ARTICULO_LINEA_ID
		{
			get
			{
				if(IsARTICULO_LINEA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_linea_id;
			}
			set
			{
				_articulo_linea_idNull = false;
				_articulo_linea_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_LINEA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_LINEA_IDNull
		{
			get { return _articulo_linea_idNull; }
			set { _articulo_linea_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_LINEA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_LINEA_NOMBRE</c> column value.</value>
		public string ARTICULO_LINEA_NOMBRE
		{
			get { return _articulo_linea_nombre; }
			set { _articulo_linea_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCEDENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCEDENCIA</c> column value.</value>
		public decimal PROCEDENCIA
		{
			get
			{
				if(IsPROCEDENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _procedencia;
			}
			set
			{
				_procedenciaNull = false;
				_procedencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROCEDENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROCEDENCIANull
		{
			get { return _procedenciaNull; }
			set { _procedenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCEDENCIA_GENTILICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCEDENCIA_GENTILICIO</c> column value.</value>
		public string PROCEDENCIA_GENTILICIO
		{
			get { return _procedencia_gentilicio; }
			set { _procedencia_gentilicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GENERO</c> column value.</value>
		public string GENERO
		{
			get { return _genero; }
			set { _genero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_PADRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_PADRE_ID</c> column value.</value>
		public decimal ARTICULO_PADRE_ID
		{
			get
			{
				if(IsARTICULO_PADRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_padre_id;
			}
			set
			{
				_articulo_padre_idNull = false;
				_articulo_padre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_PADRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_PADRE_IDNull
		{
			get { return _articulo_padre_idNull; }
			set { _articulo_padre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COMBO_ABIERTO</c> column value.
		/// </summary>
		/// <value>The <c>ES_COMBO_ABIERTO</c> column value.</value>
		public string ES_COMBO_ABIERTO
		{
			get { return _es_combo_abierto; }
			set { _es_combo_abierto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_PADRE_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_PADRE_NOMBRE</c> column value.</value>
		public string ARTICULO_PADRE_NOMBRE
		{
			get { return _articulo_padre_nombre; }
			set { _articulo_padre_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_PADRE_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_PADRE_CODIGO</c> column value.</value>
		public string ARTICULO_PADRE_CODIGO
		{
			get { return _articulo_padre_codigo; }
			set { _articulo_padre_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_MARCA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_MARCA_ID</c> column value.</value>
		public decimal ARTICULO_MARCA_ID
		{
			get
			{
				if(IsARTICULO_MARCA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_marca_id;
			}
			set
			{
				_articulo_marca_idNull = false;
				_articulo_marca_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_MARCA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_MARCA_IDNull
		{
			get { return _articulo_marca_idNull; }
			set { _articulo_marca_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_MARCA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_MARCA_NOMBRE</c> column value.</value>
		public string ARTICULO_MARCA_NOMBRE
		{
			get { return _articulo_marca_nombre; }
			set { _articulo_marca_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ULTIMO_INGRESO_STOCK_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ULTIMO_INGRESO_STOCK_FECHA</c> column value.</value>
		public System.DateTime ULTIMO_INGRESO_STOCK_FECHA
		{
			get
			{
				if(IsULTIMO_INGRESO_STOCK_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ultimo_ingreso_stock_fecha;
			}
			set
			{
				_ultimo_ingreso_stock_fechaNull = false;
				_ultimo_ingreso_stock_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ULTIMO_INGRESO_STOCK_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsULTIMO_INGRESO_STOCK_FECHANull
		{
			get { return _ultimo_ingreso_stock_fechaNull; }
			set { _ultimo_ingreso_stock_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTENCIA_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXISTENCIA_TOTAL</c> column value.</value>
		public decimal EXISTENCIA_TOTAL
		{
			get
			{
				if(IsEXISTENCIA_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _existencia_total;
			}
			set
			{
				_existencia_totalNull = false;
				_existencia_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EXISTENCIA_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEXISTENCIA_TOTALNull
		{
			get { return _existencia_totalNull; }
			set { _existencia_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_MODIFICABLE</c> column value.
		/// </summary>
		/// <value>The <c>ES_MODIFICABLE</c> column value.</value>
		public string ES_MODIFICABLE
		{
			get { return _es_modificable; }
			set { _es_modificable = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECARGO_FINANCIERO</c> column value.
		/// </summary>
		/// <value>The <c>RECARGO_FINANCIERO</c> column value.</value>
		public string RECARGO_FINANCIERO
		{
			get { return _recargo_financiero; }
			set { _recargo_financiero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTROLAR_PRECIO</c> column value.
		/// </summary>
		/// <value>The <c>CONTROLAR_PRECIO</c> column value.</value>
		public string CONTROLAR_PRECIO
		{
			get { return _controlar_precio; }
			set { _controlar_precio = value; }
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
		/// Gets or sets the <c>TIPO_NOTA_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NOTA_CREDITO_ID</c> column value.</value>
		public decimal TIPO_NOTA_CREDITO_ID
		{
			get
			{
				if(IsTIPO_NOTA_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_nota_credito_id;
			}
			set
			{
				_tipo_nota_credito_idNull = false;
				_tipo_nota_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_NOTA_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_NOTA_CREDITO_IDNull
		{
			get { return _tipo_nota_credito_idNull; }
			set { _tipo_nota_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_BASE_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_BASE_MONTO</c> column value.</value>
		public decimal COSTO_BASE_MONTO
		{
			get
			{
				if(IsCOSTO_BASE_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_base_monto;
			}
			set
			{
				_costo_base_montoNull = false;
				_costo_base_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_BASE_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_BASE_MONTONull
		{
			get { return _costo_base_montoNull; }
			set { _costo_base_montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_BASE_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_BASE_MONEDA_ID</c> column value.</value>
		public decimal COSTO_BASE_MONEDA_ID
		{
			get
			{
				if(IsCOSTO_BASE_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_base_moneda_id;
			}
			set
			{
				_costo_base_moneda_idNull = false;
				_costo_base_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_BASE_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_BASE_MONEDA_IDNull
		{
			get { return _costo_base_moneda_idNull; }
			set { _costo_base_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_BASE_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_BASE_COTIZACION</c> column value.</value>
		public decimal COSTO_BASE_COTIZACION
		{
			get
			{
				if(IsCOSTO_BASE_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_base_cotizacion;
			}
			set
			{
				_costo_base_cotizacionNull = false;
				_costo_base_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_BASE_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_BASE_COTIZACIONNull
		{
			get { return _costo_base_cotizacionNull; }
			set { _costo_base_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_id;
			}
			set
			{
				_centro_costo_idNull = false;
				_centro_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_IDNull
		{
			get { return _centro_costo_idNull; }
			set { _centro_costo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_OBSOLETO</c> column value.
		/// </summary>
		/// <value>The <c>ES_OBSOLETO</c> column value.</value>
		public string ES_OBSOLETO
		{
			get { return _es_obsoleto; }
			set { _es_obsoleto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COMBO_REPRESENTATIVO</c> column value.
		/// </summary>
		/// <value>The <c>ES_COMBO_REPRESENTATIVO</c> column value.</value>
		public string ES_COMBO_REPRESENTATIVO
		{
			get { return _es_combo_representativo; }
			set { _es_combo_representativo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMAGEN_PATH_TMP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMAGEN_PATH_TMP</c> column value.</value>
		public string IMAGEN_PATH_TMP
		{
			get { return _imagen_path_tmp; }
			set { _imagen_path_tmp = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_PPP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_PPP</c> column value.</value>
		public decimal COSTO_PPP
		{
			get
			{
				if(IsCOSTO_PPPNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_ppp;
			}
			set
			{
				_costo_pppNull = false;
				_costo_ppp = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_PPP"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_PPPNull
		{
			get { return _costo_pppNull; }
			set { _costo_pppNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CIERRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CIERRE</c> column value.</value>
		public System.DateTime FECHA_CIERRE
		{
			get
			{
				if(IsFECHA_CIERRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cierre;
			}
			set
			{
				_fecha_cierreNull = false;
				_fecha_cierre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CIERRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CIERRENull
		{
			get { return _fecha_cierreNull; }
			set { _fecha_cierreNull = value; }
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
		/// Gets or sets the <c>RETENCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION</c> column value.</value>
		public decimal RETENCION
		{
			get
			{
				if(IsRETENCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion;
			}
			set
			{
				_retencionNull = false;
				_retencion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCIONNull
		{
			get { return _retencionNull; }
			set { _retencionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MINIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MINIMA</c> column value.</value>
		public decimal CANTIDAD_MINIMA
		{
			get
			{
				if(IsCANTIDAD_MINIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_minima;
			}
			set
			{
				_cantidad_minimaNull = false;
				_cantidad_minima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MINIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MINIMANull
		{
			get { return _cantidad_minimaNull; }
			set { _cantidad_minimaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MAXIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MAXIMA</c> column value.</value>
		public decimal CANTIDAD_MAXIMA
		{
			get
			{
				if(IsCANTIDAD_MAXIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_maxima;
			}
			set
			{
				_cantidad_maximaNull = false;
				_cantidad_maxima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MAXIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MAXIMANull
		{
			get { return _cantidad_maximaNull; }
			set { _cantidad_maximaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MAYORISTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MAYORISTA</c> column value.</value>
		public decimal CANTIDAD_MAYORISTA
		{
			get
			{
				if(IsCANTIDAD_MAYORISTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_mayorista;
			}
			set
			{
				_cantidad_mayoristaNull = false;
				_cantidad_mayorista = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MAYORISTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MAYORISTANull
		{
			get { return _cantidad_mayoristaNull; }
			set { _cantidad_mayoristaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_CONTROL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_CONTROL</c> column value.</value>
		public string UNIDAD_MEDIDA_CONTROL
		{
			get { return _unidad_medida_control; }
			set { _unidad_medida_control = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PARA_COMPRA</c> column value.
		/// </summary>
		/// <value>The <c>PARA_COMPRA</c> column value.</value>
		public string PARA_COMPRA
		{
			get { return _para_compra; }
			set { _para_compra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_FORMULA</c> column value.
		/// </summary>
		/// <value>The <c>ES_FORMULA</c> column value.</value>
		public string ES_FORMULA
		{
			get { return _es_formula; }
			set { _es_formula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_FORMULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_FORMULA</c> column value.</value>
		public string TIPO_FORMULA
		{
			get { return _tipo_formula; }
			set { _tipo_formula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACIONES_ID</c> column value.</value>
		public decimal AUTONUMERACIONES_ID
		{
			get
			{
				if(IsAUTONUMERACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeraciones_id;
			}
			set
			{
				_autonumeraciones_idNull = false;
				_autonumeraciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACIONES_IDNull
		{
			get { return _autonumeraciones_idNull; }
			set { _autonumeraciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MINIMA_PRODUCCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MINIMA_PRODUCCION</c> column value.</value>
		public decimal CANTIDAD_MINIMA_PRODUCCION
		{
			get
			{
				if(IsCANTIDAD_MINIMA_PRODUCCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_minima_produccion;
			}
			set
			{
				_cantidad_minima_produccionNull = false;
				_cantidad_minima_produccion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MINIMA_PRODUCCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MINIMA_PRODUCCIONNull
		{
			get { return _cantidad_minima_produccionNull; }
			set { _cantidad_minima_produccionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MAXIMA_PRODUCCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MAXIMA_PRODUCCION</c> column value.</value>
		public decimal CANTIDAD_MAXIMA_PRODUCCION
		{
			get
			{
				if(IsCANTIDAD_MAXIMA_PRODUCCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_maxima_produccion;
			}
			set
			{
				_cantidad_maxima_produccionNull = false;
				_cantidad_maxima_produccion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MAXIMA_PRODUCCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MAXIMA_PRODUCCIONNull
		{
			get { return _cantidad_maxima_produccionNull; }
			set { _cantidad_maxima_produccionNull = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@CODIGO_EMPRESA=");
			dynStr.Append(CODIGO_EMPRESA);
			dynStr.Append("@CBA@CODIGO_PROVEEDOR=");
			dynStr.Append(CODIGO_PROVEEDOR);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@CODIGO_BARRAS_EMPRESA=");
			dynStr.Append(CODIGO_BARRAS_EMPRESA);
			dynStr.Append("@CBA@CODIGO_BARRAS_PROVEEDOR=");
			dynStr.Append(CODIGO_BARRAS_PROVEEDOR);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@DESCRIPCION_IMPRESION=");
			dynStr.Append(DESCRIPCION_IMPRESION);
			dynStr.Append("@CBA@DESCRIPCION_CATALOGO=");
			dynStr.Append(DESCRIPCION_CATALOGO);
			dynStr.Append("@CBA@DESCRIPCION_PROVEEDOR=");
			dynStr.Append(DESCRIPCION_PROVEEDOR);
			dynStr.Append("@CBA@DESCRIPCION_A_UTILIZAR=");
			dynStr.Append(DESCRIPCION_A_UTILIZAR);
			dynStr.Append("@CBA@DESCRIPCION_SIN_CODIGO=");
			dynStr.Append(DESCRIPCION_SIN_CODIGO);
			dynStr.Append("@CBA@CODIGO_PRESENTACION_ID=");
			dynStr.Append(IsCODIGO_PRESENTACION_IDNull ? (object)"<NULL>" : CODIGO_PRESENTACION_ID);
			dynStr.Append("@CBA@CODIGO_EMPAQUE_ID=");
			dynStr.Append(IsCODIGO_EMPAQUE_IDNull ? (object)"<NULL>" : CODIGO_EMPAQUE_ID);
			dynStr.Append("@CBA@CODIGO_COLOR_ID=");
			dynStr.Append(IsCODIGO_COLOR_IDNull ? (object)"<NULL>" : CODIGO_COLOR_ID);
			dynStr.Append("@CBA@CODIGO_TALLE_ID=");
			dynStr.Append(IsCODIGO_TALLE_IDNull ? (object)"<NULL>" : CODIGO_TALLE_ID);
			dynStr.Append("@CBA@CODIGO_BALANZA=");
			dynStr.Append(CODIGO_BALANZA);
			dynStr.Append("@CBA@CODIGO_CATALOGO_PROVEEDOR=");
			dynStr.Append(CODIGO_CATALOGO_PROVEEDOR);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@IMPORTADO=");
			dynStr.Append(IMPORTADO);
			dynStr.Append("@CBA@PRODUCCION_INTERNA=");
			dynStr.Append(PRODUCCION_INTERNA);
			dynStr.Append("@CBA@NO_REPONER=");
			dynStr.Append(NO_REPONER);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@FACTOR_CONVERSION_KG=");
			dynStr.Append(IsFACTOR_CONVERSION_KGNull ? (object)"<NULL>" : FACTOR_CONVERSION_KG);
			dynStr.Append("@CBA@FACTOR_CONVERSION_M=");
			dynStr.Append(IsFACTOR_CONVERSION_MNull ? (object)"<NULL>" : FACTOR_CONVERSION_M);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA=");
			dynStr.Append(CANTIDAD_POR_CAJA);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTO_COMPRA_ID=");
			dynStr.Append(IsIMPUESTO_COMPRA_IDNull ? (object)"<NULL>" : IMPUESTO_COMPRA_ID);
			dynStr.Append("@CBA@SERVICIO=");
			dynStr.Append(SERVICIO);
			dynStr.Append("@CBA@COMBO_ID=");
			dynStr.Append(IsCOMBO_IDNull ? (object)"<NULL>" : COMBO_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@INGRESO_APROBADO=");
			dynStr.Append(INGRESO_APROBADO);
			dynStr.Append("@CBA@USUARIO_APROBACION_ID=");
			dynStr.Append(IsUSUARIO_APROBACION_IDNull ? (object)"<NULL>" : USUARIO_APROBACION_ID);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@PORCENTAJE_PRECIO_PADRE=");
			dynStr.Append(IsPORCENTAJE_PRECIO_PADRENull ? (object)"<NULL>" : PORCENTAJE_PRECIO_PADRE);
			dynStr.Append("@CBA@MONTO_PRECIO_PADRE=");
			dynStr.Append(IsMONTO_PRECIO_PADRENull ? (object)"<NULL>" : MONTO_PRECIO_PADRE);
			dynStr.Append("@CBA@IMPUESTO_DESCRIPCION=");
			dynStr.Append(IMPUESTO_DESCRIPCION);
			dynStr.Append("@CBA@IMPUESTO_COMPRA_DESCRIPCION=");
			dynStr.Append(IMPUESTO_COMPRA_DESCRIPCION);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@PRESENTACION_DESCRIPCION=");
			dynStr.Append(PRESENTACION_DESCRIPCION);
			dynStr.Append("@CBA@EMPAQUE_DESCRIPCION=");
			dynStr.Append(EMPAQUE_DESCRIPCION);
			dynStr.Append("@CBA@COLOR_DESCRIPCION=");
			dynStr.Append(COLOR_DESCRIPCION);
			dynStr.Append("@CBA@TALLE_DESCRIPCION=");
			dynStr.Append(TALLE_DESCRIPCION);
			dynStr.Append("@CBA@FAMILIA_CODIGO=");
			dynStr.Append(FAMILIA_CODIGO);
			dynStr.Append("@CBA@GRUPO_CODIGO=");
			dynStr.Append(GRUPO_CODIGO);
			dynStr.Append("@CBA@SUBGRUPO_CODIGO=");
			dynStr.Append(SUBGRUPO_CODIGO);
			dynStr.Append("@CBA@FAMILIA_ORDEN=");
			dynStr.Append(IsFAMILIA_ORDENNull ? (object)"<NULL>" : FAMILIA_ORDEN);
			dynStr.Append("@CBA@GRUPO_ORDEN=");
			dynStr.Append(IsGRUPO_ORDENNull ? (object)"<NULL>" : GRUPO_ORDEN);
			dynStr.Append("@CBA@SUBGRUPO_ORDEN=");
			dynStr.Append(IsSUBGRUPO_ORDENNull ? (object)"<NULL>" : SUBGRUPO_ORDEN);
			dynStr.Append("@CBA@ES_TRAZABLE=");
			dynStr.Append(ES_TRAZABLE);
			dynStr.Append("@CBA@ES_USADO=");
			dynStr.Append(ES_USADO);
			dynStr.Append("@CBA@ES_DANHADO=");
			dynStr.Append(ES_DANHADO);
			dynStr.Append("@CBA@PARA_VENTA=");
			dynStr.Append(PARA_VENTA);
			dynStr.Append("@CBA@ES_COMBO=");
			dynStr.Append(ES_COMBO);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESCRIPCION=");
			dynStr.Append(UNIDAD_MEDIDA_DESCRIPCION);
			dynStr.Append("@CBA@ARTICULO_LINEA_ID=");
			dynStr.Append(IsARTICULO_LINEA_IDNull ? (object)"<NULL>" : ARTICULO_LINEA_ID);
			dynStr.Append("@CBA@ARTICULO_LINEA_NOMBRE=");
			dynStr.Append(ARTICULO_LINEA_NOMBRE);
			dynStr.Append("@CBA@PROCEDENCIA=");
			dynStr.Append(IsPROCEDENCIANull ? (object)"<NULL>" : PROCEDENCIA);
			dynStr.Append("@CBA@PROCEDENCIA_GENTILICIO=");
			dynStr.Append(PROCEDENCIA_GENTILICIO);
			dynStr.Append("@CBA@GENERO=");
			dynStr.Append(GENERO);
			dynStr.Append("@CBA@ARTICULO_PADRE_ID=");
			dynStr.Append(IsARTICULO_PADRE_IDNull ? (object)"<NULL>" : ARTICULO_PADRE_ID);
			dynStr.Append("@CBA@ES_COMBO_ABIERTO=");
			dynStr.Append(ES_COMBO_ABIERTO);
			dynStr.Append("@CBA@ARTICULO_PADRE_NOMBRE=");
			dynStr.Append(ARTICULO_PADRE_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_PADRE_CODIGO=");
			dynStr.Append(ARTICULO_PADRE_CODIGO);
			dynStr.Append("@CBA@ARTICULO_MARCA_ID=");
			dynStr.Append(IsARTICULO_MARCA_IDNull ? (object)"<NULL>" : ARTICULO_MARCA_ID);
			dynStr.Append("@CBA@ARTICULO_MARCA_NOMBRE=");
			dynStr.Append(ARTICULO_MARCA_NOMBRE);
			dynStr.Append("@CBA@ULTIMO_INGRESO_STOCK_FECHA=");
			dynStr.Append(IsULTIMO_INGRESO_STOCK_FECHANull ? (object)"<NULL>" : ULTIMO_INGRESO_STOCK_FECHA);
			dynStr.Append("@CBA@EXISTENCIA_TOTAL=");
			dynStr.Append(IsEXISTENCIA_TOTALNull ? (object)"<NULL>" : EXISTENCIA_TOTAL);
			dynStr.Append("@CBA@ES_MODIFICABLE=");
			dynStr.Append(ES_MODIFICABLE);
			dynStr.Append("@CBA@RECARGO_FINANCIERO=");
			dynStr.Append(RECARGO_FINANCIERO);
			dynStr.Append("@CBA@CONTROLAR_PRECIO=");
			dynStr.Append(CONTROLAR_PRECIO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@TIPO_NOTA_CREDITO_ID=");
			dynStr.Append(IsTIPO_NOTA_CREDITO_IDNull ? (object)"<NULL>" : TIPO_NOTA_CREDITO_ID);
			dynStr.Append("@CBA@COSTO_BASE_MONTO=");
			dynStr.Append(IsCOSTO_BASE_MONTONull ? (object)"<NULL>" : COSTO_BASE_MONTO);
			dynStr.Append("@CBA@COSTO_BASE_MONEDA_ID=");
			dynStr.Append(IsCOSTO_BASE_MONEDA_IDNull ? (object)"<NULL>" : COSTO_BASE_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_BASE_COTIZACION=");
			dynStr.Append(IsCOSTO_BASE_COTIZACIONNull ? (object)"<NULL>" : COSTO_BASE_COTIZACION);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@ES_OBSOLETO=");
			dynStr.Append(ES_OBSOLETO);
			dynStr.Append("@CBA@ES_COMBO_REPRESENTATIVO=");
			dynStr.Append(ES_COMBO_REPRESENTATIVO);
			dynStr.Append("@CBA@IMAGEN_PATH_TMP=");
			dynStr.Append(IMAGEN_PATH_TMP);
			dynStr.Append("@CBA@COSTO_PPP=");
			dynStr.Append(IsCOSTO_PPPNull ? (object)"<NULL>" : COSTO_PPP);
			dynStr.Append("@CBA@FECHA_CIERRE=");
			dynStr.Append(IsFECHA_CIERRENull ? (object)"<NULL>" : FECHA_CIERRE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@RETENCION=");
			dynStr.Append(IsRETENCIONNull ? (object)"<NULL>" : RETENCION);
			dynStr.Append("@CBA@CANTIDAD_MINIMA=");
			dynStr.Append(IsCANTIDAD_MINIMANull ? (object)"<NULL>" : CANTIDAD_MINIMA);
			dynStr.Append("@CBA@CANTIDAD_MAXIMA=");
			dynStr.Append(IsCANTIDAD_MAXIMANull ? (object)"<NULL>" : CANTIDAD_MAXIMA);
			dynStr.Append("@CBA@CANTIDAD_MAYORISTA=");
			dynStr.Append(IsCANTIDAD_MAYORISTANull ? (object)"<NULL>" : CANTIDAD_MAYORISTA);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_CONTROL=");
			dynStr.Append(UNIDAD_MEDIDA_CONTROL);
			dynStr.Append("@CBA@PARA_COMPRA=");
			dynStr.Append(PARA_COMPRA);
			dynStr.Append("@CBA@ES_FORMULA=");
			dynStr.Append(ES_FORMULA);
			dynStr.Append("@CBA@TIPO_FORMULA=");
			dynStr.Append(TIPO_FORMULA);
			dynStr.Append("@CBA@AUTONUMERACIONES_ID=");
			dynStr.Append(IsAUTONUMERACIONES_IDNull ? (object)"<NULL>" : AUTONUMERACIONES_ID);
			dynStr.Append("@CBA@CANTIDAD_MINIMA_PRODUCCION=");
			dynStr.Append(IsCANTIDAD_MINIMA_PRODUCCIONNull ? (object)"<NULL>" : CANTIDAD_MINIMA_PRODUCCION);
			dynStr.Append("@CBA@CANTIDAD_MAXIMA_PRODUCCION=");
			dynStr.Append(IsCANTIDAD_MAXIMA_PRODUCCIONNull ? (object)"<NULL>" : CANTIDAD_MAXIMA_PRODUCCION);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_INFO_COMPLETARow_Base class
} // End of namespace
