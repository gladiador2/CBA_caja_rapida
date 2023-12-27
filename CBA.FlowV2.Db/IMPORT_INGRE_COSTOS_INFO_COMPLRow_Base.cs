// <fileinfo name="IMPORT_INGRE_COSTOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>IMPORT_INGRE_COSTOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORT_INGRE_COSTOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ingreso_stock_id;
		private bool _ingreso_stock_idNull = true;
		private decimal _ingreso_caso_id;
		private decimal _ingreso_caso_fc_proveedor_id;
		private bool _ingreso_caso_fc_proveedor_idNull = true;
		private decimal _ingreso_sucursal_id;
		private string _ingreso_sucursal_nombre;
		private string _ingreso_sucursal_abreviatura;
		private decimal _ingreso_deposito_id;
		private string _ingreso_deposito_nombre;
		private string _ingreso_deposito_abreviatura;
		private decimal _monto_prorateo;
		private bool _monto_prorateoNull = true;
		private decimal _ingreso_stock_detalle_id;
		private bool _ingreso_stock_detalle_idNull = true;
		private decimal _ingreso_det_lote_id;
		private bool _ingreso_det_lote_idNull = true;
		private decimal _ingreso_det_articulo_id;
		private bool _ingreso_det_articulo_idNull = true;
		private string _ingreso_det_articulo_codigo;
		private string _ingreso_det_lote;
		private decimal _ingreso_det_moneda_id;
		private string _ingreso_det_moneda_simbolo;
		private decimal _ingreso_det_cotizacion;
		private decimal _importacion_id;
		private bool _importacion_idNull = true;
		private string _importacion_nombre;
		private decimal _importacion_total_gastos;
		private bool _importacion_total_gastosNull = true;
		private decimal _importacion_facturas;
		private bool _importacion_facturasNull = true;
		private decimal _importacion_gastos_id;
		private bool _importacion_gastos_idNull = true;
		private decimal _importacion_gastos_monto;
		private bool _importacion_gastos_montoNull = true;
		private decimal _import_gastos_moneda_id;
		private bool _import_gastos_moneda_idNull = true;
		private string _import_gastos_moneda_nombre;
		private decimal _import_gastos_cotizacion;
		private bool _import_gastos_cotizacionNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _porcentaje;
		private bool _porcentajeNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private string _moneda_cadena_decimales;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public IMPORT_INGRE_COSTOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORT_INGRE_COSTOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsINGRESO_STOCK_IDNull != original.IsINGRESO_STOCK_IDNull) return true;
			if (!this.IsINGRESO_STOCK_IDNull && !original.IsINGRESO_STOCK_IDNull)
				if (this.INGRESO_STOCK_ID != original.INGRESO_STOCK_ID) return true;
			if (this.INGRESO_CASO_ID != original.INGRESO_CASO_ID) return true;
			if (this.IsINGRESO_CASO_FC_PROVEEDOR_IDNull != original.IsINGRESO_CASO_FC_PROVEEDOR_IDNull) return true;
			if (!this.IsINGRESO_CASO_FC_PROVEEDOR_IDNull && !original.IsINGRESO_CASO_FC_PROVEEDOR_IDNull)
				if (this.INGRESO_CASO_FC_PROVEEDOR_ID != original.INGRESO_CASO_FC_PROVEEDOR_ID) return true;
			if (this.INGRESO_SUCURSAL_ID != original.INGRESO_SUCURSAL_ID) return true;
			if (this.INGRESO_SUCURSAL_NOMBRE != original.INGRESO_SUCURSAL_NOMBRE) return true;
			if (this.INGRESO_SUCURSAL_ABREVIATURA != original.INGRESO_SUCURSAL_ABREVIATURA) return true;
			if (this.INGRESO_DEPOSITO_ID != original.INGRESO_DEPOSITO_ID) return true;
			if (this.INGRESO_DEPOSITO_NOMBRE != original.INGRESO_DEPOSITO_NOMBRE) return true;
			if (this.INGRESO_DEPOSITO_ABREVIATURA != original.INGRESO_DEPOSITO_ABREVIATURA) return true;
			if (this.IsMONTO_PRORATEONull != original.IsMONTO_PRORATEONull) return true;
			if (!this.IsMONTO_PRORATEONull && !original.IsMONTO_PRORATEONull)
				if (this.MONTO_PRORATEO != original.MONTO_PRORATEO) return true;
			if (this.IsINGRESO_STOCK_DETALLE_IDNull != original.IsINGRESO_STOCK_DETALLE_IDNull) return true;
			if (!this.IsINGRESO_STOCK_DETALLE_IDNull && !original.IsINGRESO_STOCK_DETALLE_IDNull)
				if (this.INGRESO_STOCK_DETALLE_ID != original.INGRESO_STOCK_DETALLE_ID) return true;
			if (this.IsINGRESO_DET_LOTE_IDNull != original.IsINGRESO_DET_LOTE_IDNull) return true;
			if (!this.IsINGRESO_DET_LOTE_IDNull && !original.IsINGRESO_DET_LOTE_IDNull)
				if (this.INGRESO_DET_LOTE_ID != original.INGRESO_DET_LOTE_ID) return true;
			if (this.IsINGRESO_DET_ARTICULO_IDNull != original.IsINGRESO_DET_ARTICULO_IDNull) return true;
			if (!this.IsINGRESO_DET_ARTICULO_IDNull && !original.IsINGRESO_DET_ARTICULO_IDNull)
				if (this.INGRESO_DET_ARTICULO_ID != original.INGRESO_DET_ARTICULO_ID) return true;
			if (this.INGRESO_DET_ARTICULO_CODIGO != original.INGRESO_DET_ARTICULO_CODIGO) return true;
			if (this.INGRESO_DET_LOTE != original.INGRESO_DET_LOTE) return true;
			if (this.INGRESO_DET_MONEDA_ID != original.INGRESO_DET_MONEDA_ID) return true;
			if (this.INGRESO_DET_MONEDA_SIMBOLO != original.INGRESO_DET_MONEDA_SIMBOLO) return true;
			if (this.INGRESO_DET_COTIZACION != original.INGRESO_DET_COTIZACION) return true;
			if (this.IsIMPORTACION_IDNull != original.IsIMPORTACION_IDNull) return true;
			if (!this.IsIMPORTACION_IDNull && !original.IsIMPORTACION_IDNull)
				if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.IMPORTACION_NOMBRE != original.IMPORTACION_NOMBRE) return true;
			if (this.IsIMPORTACION_TOTAL_GASTOSNull != original.IsIMPORTACION_TOTAL_GASTOSNull) return true;
			if (!this.IsIMPORTACION_TOTAL_GASTOSNull && !original.IsIMPORTACION_TOTAL_GASTOSNull)
				if (this.IMPORTACION_TOTAL_GASTOS != original.IMPORTACION_TOTAL_GASTOS) return true;
			if (this.IsIMPORTACION_FACTURASNull != original.IsIMPORTACION_FACTURASNull) return true;
			if (!this.IsIMPORTACION_FACTURASNull && !original.IsIMPORTACION_FACTURASNull)
				if (this.IMPORTACION_FACTURAS != original.IMPORTACION_FACTURAS) return true;
			if (this.IsIMPORTACION_GASTOS_IDNull != original.IsIMPORTACION_GASTOS_IDNull) return true;
			if (!this.IsIMPORTACION_GASTOS_IDNull && !original.IsIMPORTACION_GASTOS_IDNull)
				if (this.IMPORTACION_GASTOS_ID != original.IMPORTACION_GASTOS_ID) return true;
			if (this.IsIMPORTACION_GASTOS_MONTONull != original.IsIMPORTACION_GASTOS_MONTONull) return true;
			if (!this.IsIMPORTACION_GASTOS_MONTONull && !original.IsIMPORTACION_GASTOS_MONTONull)
				if (this.IMPORTACION_GASTOS_MONTO != original.IMPORTACION_GASTOS_MONTO) return true;
			if (this.IsIMPORT_GASTOS_MONEDA_IDNull != original.IsIMPORT_GASTOS_MONEDA_IDNull) return true;
			if (!this.IsIMPORT_GASTOS_MONEDA_IDNull && !original.IsIMPORT_GASTOS_MONEDA_IDNull)
				if (this.IMPORT_GASTOS_MONEDA_ID != original.IMPORT_GASTOS_MONEDA_ID) return true;
			if (this.IMPORT_GASTOS_MONEDA_NOMBRE != original.IMPORT_GASTOS_MONEDA_NOMBRE) return true;
			if (this.IsIMPORT_GASTOS_COTIZACIONNull != original.IsIMPORT_GASTOS_COTIZACIONNull) return true;
			if (!this.IsIMPORT_GASTOS_COTIZACIONNull && !original.IsIMPORT_GASTOS_COTIZACIONNull)
				if (this.IMPORT_GASTOS_COTIZACION != original.IMPORT_GASTOS_COTIZACION) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsPORCENTAJENull != original.IsPORCENTAJENull) return true;
			if (!this.IsPORCENTAJENull && !original.IsPORCENTAJENull)
				if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			
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
		/// Gets or sets the <c>INGRESO_STOCK_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_STOCK_ID</c> column value.</value>
		public decimal INGRESO_STOCK_ID
		{
			get
			{
				if(IsINGRESO_STOCK_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_stock_id;
			}
			set
			{
				_ingreso_stock_idNull = false;
				_ingreso_stock_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_STOCK_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_STOCK_IDNull
		{
			get { return _ingreso_stock_idNull; }
			set { _ingreso_stock_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_CASO_ID</c> column value.</value>
		public decimal INGRESO_CASO_ID
		{
			get { return _ingreso_caso_id; }
			set { _ingreso_caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_CASO_FC_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_CASO_FC_PROVEEDOR_ID</c> column value.</value>
		public decimal INGRESO_CASO_FC_PROVEEDOR_ID
		{
			get
			{
				if(IsINGRESO_CASO_FC_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_caso_fc_proveedor_id;
			}
			set
			{
				_ingreso_caso_fc_proveedor_idNull = false;
				_ingreso_caso_fc_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_CASO_FC_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_CASO_FC_PROVEEDOR_IDNull
		{
			get { return _ingreso_caso_fc_proveedor_idNull; }
			set { _ingreso_caso_fc_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_SUCURSAL_ID</c> column value.</value>
		public decimal INGRESO_SUCURSAL_ID
		{
			get { return _ingreso_sucursal_id; }
			set { _ingreso_sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_SUCURSAL_NOMBRE</c> column value.</value>
		public string INGRESO_SUCURSAL_NOMBRE
		{
			get { return _ingreso_sucursal_nombre; }
			set { _ingreso_sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_SUCURSAL_ABREVIATURA</c> column value.</value>
		public string INGRESO_SUCURSAL_ABREVIATURA
		{
			get { return _ingreso_sucursal_abreviatura; }
			set { _ingreso_sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_DEPOSITO_ID</c> column value.</value>
		public decimal INGRESO_DEPOSITO_ID
		{
			get { return _ingreso_deposito_id; }
			set { _ingreso_deposito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DEPOSITO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_DEPOSITO_NOMBRE</c> column value.</value>
		public string INGRESO_DEPOSITO_NOMBRE
		{
			get { return _ingreso_deposito_nombre; }
			set { _ingreso_deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DEPOSITO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_DEPOSITO_ABREVIATURA</c> column value.</value>
		public string INGRESO_DEPOSITO_ABREVIATURA
		{
			get { return _ingreso_deposito_abreviatura; }
			set { _ingreso_deposito_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PRORATEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PRORATEO</c> column value.</value>
		public decimal MONTO_PRORATEO
		{
			get
			{
				if(IsMONTO_PRORATEONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_prorateo;
			}
			set
			{
				_monto_prorateoNull = false;
				_monto_prorateo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PRORATEO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PRORATEONull
		{
			get { return _monto_prorateoNull; }
			set { _monto_prorateoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_STOCK_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</value>
		public decimal INGRESO_STOCK_DETALLE_ID
		{
			get
			{
				if(IsINGRESO_STOCK_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_stock_detalle_id;
			}
			set
			{
				_ingreso_stock_detalle_idNull = false;
				_ingreso_stock_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_STOCK_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_STOCK_DETALLE_IDNull
		{
			get { return _ingreso_stock_detalle_idNull; }
			set { _ingreso_stock_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_DET_LOTE_ID</c> column value.</value>
		public decimal INGRESO_DET_LOTE_ID
		{
			get
			{
				if(IsINGRESO_DET_LOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_det_lote_id;
			}
			set
			{
				_ingreso_det_lote_idNull = false;
				_ingreso_det_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_DET_LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_DET_LOTE_IDNull
		{
			get { return _ingreso_det_lote_idNull; }
			set { _ingreso_det_lote_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_DET_ARTICULO_ID</c> column value.</value>
		public decimal INGRESO_DET_ARTICULO_ID
		{
			get
			{
				if(IsINGRESO_DET_ARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_det_articulo_id;
			}
			set
			{
				_ingreso_det_articulo_idNull = false;
				_ingreso_det_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_DET_ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_DET_ARTICULO_IDNull
		{
			get { return _ingreso_det_articulo_idNull; }
			set { _ingreso_det_articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_DET_ARTICULO_CODIGO</c> column value.</value>
		public string INGRESO_DET_ARTICULO_CODIGO
		{
			get { return _ingreso_det_articulo_codigo; }
			set { _ingreso_det_articulo_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_DET_LOTE</c> column value.</value>
		public string INGRESO_DET_LOTE
		{
			get { return _ingreso_det_lote; }
			set { _ingreso_det_lote = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_DET_MONEDA_ID</c> column value.</value>
		public decimal INGRESO_DET_MONEDA_ID
		{
			get { return _ingreso_det_moneda_id; }
			set { _ingreso_det_moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_DET_MONEDA_SIMBOLO</c> column value.</value>
		public string INGRESO_DET_MONEDA_SIMBOLO
		{
			get { return _ingreso_det_moneda_simbolo; }
			set { _ingreso_det_moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_DET_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_DET_COTIZACION</c> column value.</value>
		public decimal INGRESO_DET_COTIZACION
		{
			get { return _ingreso_det_cotizacion; }
			set { _ingreso_det_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get
			{
				if(IsIMPORTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_id;
			}
			set
			{
				_importacion_idNull = false;
				_importacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_IDNull
		{
			get { return _importacion_idNull; }
			set { _importacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_NOMBRE</c> column value.</value>
		public string IMPORTACION_NOMBRE
		{
			get { return _importacion_nombre; }
			set { _importacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_TOTAL_GASTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_TOTAL_GASTOS</c> column value.</value>
		public decimal IMPORTACION_TOTAL_GASTOS
		{
			get
			{
				if(IsIMPORTACION_TOTAL_GASTOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_total_gastos;
			}
			set
			{
				_importacion_total_gastosNull = false;
				_importacion_total_gastos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_TOTAL_GASTOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_TOTAL_GASTOSNull
		{
			get { return _importacion_total_gastosNull; }
			set { _importacion_total_gastosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_FACTURAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_FACTURAS</c> column value.</value>
		public decimal IMPORTACION_FACTURAS
		{
			get
			{
				if(IsIMPORTACION_FACTURASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_facturas;
			}
			set
			{
				_importacion_facturasNull = false;
				_importacion_facturas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_FACTURAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_FACTURASNull
		{
			get { return _importacion_facturasNull; }
			set { _importacion_facturasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_GASTOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_GASTOS_ID</c> column value.</value>
		public decimal IMPORTACION_GASTOS_ID
		{
			get
			{
				if(IsIMPORTACION_GASTOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_gastos_id;
			}
			set
			{
				_importacion_gastos_idNull = false;
				_importacion_gastos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_GASTOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_GASTOS_IDNull
		{
			get { return _importacion_gastos_idNull; }
			set { _importacion_gastos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_GASTOS_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_GASTOS_MONTO</c> column value.</value>
		public decimal IMPORTACION_GASTOS_MONTO
		{
			get
			{
				if(IsIMPORTACION_GASTOS_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_gastos_monto;
			}
			set
			{
				_importacion_gastos_montoNull = false;
				_importacion_gastos_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_GASTOS_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_GASTOS_MONTONull
		{
			get { return _importacion_gastos_montoNull; }
			set { _importacion_gastos_montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORT_GASTOS_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORT_GASTOS_MONEDA_ID</c> column value.</value>
		public decimal IMPORT_GASTOS_MONEDA_ID
		{
			get
			{
				if(IsIMPORT_GASTOS_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _import_gastos_moneda_id;
			}
			set
			{
				_import_gastos_moneda_idNull = false;
				_import_gastos_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORT_GASTOS_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORT_GASTOS_MONEDA_IDNull
		{
			get { return _import_gastos_moneda_idNull; }
			set { _import_gastos_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORT_GASTOS_MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORT_GASTOS_MONEDA_NOMBRE</c> column value.</value>
		public string IMPORT_GASTOS_MONEDA_NOMBRE
		{
			get { return _import_gastos_moneda_nombre; }
			set { _import_gastos_moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORT_GASTOS_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORT_GASTOS_COTIZACION</c> column value.</value>
		public decimal IMPORT_GASTOS_COTIZACION
		{
			get
			{
				if(IsIMPORT_GASTOS_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _import_gastos_cotizacion;
			}
			set
			{
				_import_gastos_cotizacionNull = false;
				_import_gastos_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORT_GASTOS_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORT_GASTOS_COTIZACIONNull
		{
			get { return _import_gastos_cotizacionNull; }
			set { _import_gastos_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get
			{
				if(IsPORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje;
			}
			set
			{
				_porcentajeNull = false;
				_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJENull
		{
			get { return _porcentajeNull; }
			set { _porcentajeNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@INGRESO_STOCK_ID=");
			dynStr.Append(IsINGRESO_STOCK_IDNull ? (object)"<NULL>" : INGRESO_STOCK_ID);
			dynStr.Append("@CBA@INGRESO_CASO_ID=");
			dynStr.Append(INGRESO_CASO_ID);
			dynStr.Append("@CBA@INGRESO_CASO_FC_PROVEEDOR_ID=");
			dynStr.Append(IsINGRESO_CASO_FC_PROVEEDOR_IDNull ? (object)"<NULL>" : INGRESO_CASO_FC_PROVEEDOR_ID);
			dynStr.Append("@CBA@INGRESO_SUCURSAL_ID=");
			dynStr.Append(INGRESO_SUCURSAL_ID);
			dynStr.Append("@CBA@INGRESO_SUCURSAL_NOMBRE=");
			dynStr.Append(INGRESO_SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@INGRESO_SUCURSAL_ABREVIATURA=");
			dynStr.Append(INGRESO_SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@INGRESO_DEPOSITO_ID=");
			dynStr.Append(INGRESO_DEPOSITO_ID);
			dynStr.Append("@CBA@INGRESO_DEPOSITO_NOMBRE=");
			dynStr.Append(INGRESO_DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@INGRESO_DEPOSITO_ABREVIATURA=");
			dynStr.Append(INGRESO_DEPOSITO_ABREVIATURA);
			dynStr.Append("@CBA@MONTO_PRORATEO=");
			dynStr.Append(IsMONTO_PRORATEONull ? (object)"<NULL>" : MONTO_PRORATEO);
			dynStr.Append("@CBA@INGRESO_STOCK_DETALLE_ID=");
			dynStr.Append(IsINGRESO_STOCK_DETALLE_IDNull ? (object)"<NULL>" : INGRESO_STOCK_DETALLE_ID);
			dynStr.Append("@CBA@INGRESO_DET_LOTE_ID=");
			dynStr.Append(IsINGRESO_DET_LOTE_IDNull ? (object)"<NULL>" : INGRESO_DET_LOTE_ID);
			dynStr.Append("@CBA@INGRESO_DET_ARTICULO_ID=");
			dynStr.Append(IsINGRESO_DET_ARTICULO_IDNull ? (object)"<NULL>" : INGRESO_DET_ARTICULO_ID);
			dynStr.Append("@CBA@INGRESO_DET_ARTICULO_CODIGO=");
			dynStr.Append(INGRESO_DET_ARTICULO_CODIGO);
			dynStr.Append("@CBA@INGRESO_DET_LOTE=");
			dynStr.Append(INGRESO_DET_LOTE);
			dynStr.Append("@CBA@INGRESO_DET_MONEDA_ID=");
			dynStr.Append(INGRESO_DET_MONEDA_ID);
			dynStr.Append("@CBA@INGRESO_DET_MONEDA_SIMBOLO=");
			dynStr.Append(INGRESO_DET_MONEDA_SIMBOLO);
			dynStr.Append("@CBA@INGRESO_DET_COTIZACION=");
			dynStr.Append(INGRESO_DET_COTIZACION);
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IsIMPORTACION_IDNull ? (object)"<NULL>" : IMPORTACION_ID);
			dynStr.Append("@CBA@IMPORTACION_NOMBRE=");
			dynStr.Append(IMPORTACION_NOMBRE);
			dynStr.Append("@CBA@IMPORTACION_TOTAL_GASTOS=");
			dynStr.Append(IsIMPORTACION_TOTAL_GASTOSNull ? (object)"<NULL>" : IMPORTACION_TOTAL_GASTOS);
			dynStr.Append("@CBA@IMPORTACION_FACTURAS=");
			dynStr.Append(IsIMPORTACION_FACTURASNull ? (object)"<NULL>" : IMPORTACION_FACTURAS);
			dynStr.Append("@CBA@IMPORTACION_GASTOS_ID=");
			dynStr.Append(IsIMPORTACION_GASTOS_IDNull ? (object)"<NULL>" : IMPORTACION_GASTOS_ID);
			dynStr.Append("@CBA@IMPORTACION_GASTOS_MONTO=");
			dynStr.Append(IsIMPORTACION_GASTOS_MONTONull ? (object)"<NULL>" : IMPORTACION_GASTOS_MONTO);
			dynStr.Append("@CBA@IMPORT_GASTOS_MONEDA_ID=");
			dynStr.Append(IsIMPORT_GASTOS_MONEDA_IDNull ? (object)"<NULL>" : IMPORT_GASTOS_MONEDA_ID);
			dynStr.Append("@CBA@IMPORT_GASTOS_MONEDA_NOMBRE=");
			dynStr.Append(IMPORT_GASTOS_MONEDA_NOMBRE);
			dynStr.Append("@CBA@IMPORT_GASTOS_COTIZACION=");
			dynStr.Append(IsIMPORT_GASTOS_COTIZACIONNull ? (object)"<NULL>" : IMPORT_GASTOS_COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(IsPORCENTAJENull ? (object)"<NULL>" : PORCENTAJE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			return dynStr.ToString();
		}
	} // End of IMPORT_INGRE_COSTOS_INFO_COMPLRow_Base class
} // End of namespace
