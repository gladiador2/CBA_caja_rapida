// <fileinfo name="INGRESO_STOCK_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="INGRESO_STOCK_DETALLESRow"/> that 
	/// represents a record in the <c>INGRESO_STOCK_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INGRESO_STOCK_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_STOCK_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _ingreso_stock_id;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _cantidad_total_origen;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _costo;
		private decimal _costo_impuesto_porc;
		private string _unidad_id;
		private decimal _cantidad_total_destino;
		private bool _cantidad_total_destinoNull = true;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private decimal _porcentaje_prorrateo_detalle;
		private bool _porcentaje_prorrateo_detalleNull = true;
		private decimal _monto_prorrateo_detalle;
		private bool _monto_prorrateo_detalleNull = true;
		private decimal _monto_prorrateado;
		private bool _monto_prorrateadoNull = true;
		private decimal _costo_neto_sin_dto_original;
		private bool _costo_neto_sin_dto_originalNull = true;
		private decimal _moneda_original_id;
		private bool _moneda_original_idNull = true;
		private decimal _cantidad_original;
		private bool _cantidad_originalNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _gasto_unitario_aplicado;
		private bool _gasto_unitario_aplicadoNull = true;
		private decimal _gasto_total_aplicado;
		private bool _gasto_total_aplicadoNull = true;
		private decimal _costo_prorrateado;
		private bool _costo_prorrateadoNull = true;
		private decimal _monto_total_prorrateado;
		private bool _monto_total_prorrateadoNull = true;
		private decimal _moneda_pais_cotizacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCK_DETALLESRow_Base"/> class.
		/// </summary>
		public INGRESO_STOCK_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INGRESO_STOCK_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.INGRESO_STOCK_ID != original.INGRESO_STOCK_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.CANTIDAD_TOTAL_ORIGEN != original.CANTIDAD_TOTAL_ORIGEN) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.COSTO != original.COSTO) return true;
			if (this.COSTO_IMPUESTO_PORC != original.COSTO_IMPUESTO_PORC) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.IsCANTIDAD_TOTAL_DESTINONull != original.IsCANTIDAD_TOTAL_DESTINONull) return true;
			if (!this.IsCANTIDAD_TOTAL_DESTINONull && !original.IsCANTIDAD_TOTAL_DESTINONull)
				if (this.CANTIDAD_TOTAL_DESTINO != original.CANTIDAD_TOTAL_DESTINO) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.IsPORCENTAJE_PRORRATEO_DETALLENull != original.IsPORCENTAJE_PRORRATEO_DETALLENull) return true;
			if (!this.IsPORCENTAJE_PRORRATEO_DETALLENull && !original.IsPORCENTAJE_PRORRATEO_DETALLENull)
				if (this.PORCENTAJE_PRORRATEO_DETALLE != original.PORCENTAJE_PRORRATEO_DETALLE) return true;
			if (this.IsMONTO_PRORRATEO_DETALLENull != original.IsMONTO_PRORRATEO_DETALLENull) return true;
			if (!this.IsMONTO_PRORRATEO_DETALLENull && !original.IsMONTO_PRORRATEO_DETALLENull)
				if (this.MONTO_PRORRATEO_DETALLE != original.MONTO_PRORRATEO_DETALLE) return true;
			if (this.IsMONTO_PRORRATEADONull != original.IsMONTO_PRORRATEADONull) return true;
			if (!this.IsMONTO_PRORRATEADONull && !original.IsMONTO_PRORRATEADONull)
				if (this.MONTO_PRORRATEADO != original.MONTO_PRORRATEADO) return true;
			if (this.IsCOSTO_NETO_SIN_DTO_ORIGINALNull != original.IsCOSTO_NETO_SIN_DTO_ORIGINALNull) return true;
			if (!this.IsCOSTO_NETO_SIN_DTO_ORIGINALNull && !original.IsCOSTO_NETO_SIN_DTO_ORIGINALNull)
				if (this.COSTO_NETO_SIN_DTO_ORIGINAL != original.COSTO_NETO_SIN_DTO_ORIGINAL) return true;
			if (this.IsMONEDA_ORIGINAL_IDNull != original.IsMONEDA_ORIGINAL_IDNull) return true;
			if (!this.IsMONEDA_ORIGINAL_IDNull && !original.IsMONEDA_ORIGINAL_IDNull)
				if (this.MONEDA_ORIGINAL_ID != original.MONEDA_ORIGINAL_ID) return true;
			if (this.IsCANTIDAD_ORIGINALNull != original.IsCANTIDAD_ORIGINALNull) return true;
			if (!this.IsCANTIDAD_ORIGINALNull && !original.IsCANTIDAD_ORIGINALNull)
				if (this.CANTIDAD_ORIGINAL != original.CANTIDAD_ORIGINAL) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsGASTO_UNITARIO_APLICADONull != original.IsGASTO_UNITARIO_APLICADONull) return true;
			if (!this.IsGASTO_UNITARIO_APLICADONull && !original.IsGASTO_UNITARIO_APLICADONull)
				if (this.GASTO_UNITARIO_APLICADO != original.GASTO_UNITARIO_APLICADO) return true;
			if (this.IsGASTO_TOTAL_APLICADONull != original.IsGASTO_TOTAL_APLICADONull) return true;
			if (!this.IsGASTO_TOTAL_APLICADONull && !original.IsGASTO_TOTAL_APLICADONull)
				if (this.GASTO_TOTAL_APLICADO != original.GASTO_TOTAL_APLICADO) return true;
			if (this.IsCOSTO_PRORRATEADONull != original.IsCOSTO_PRORRATEADONull) return true;
			if (!this.IsCOSTO_PRORRATEADONull && !original.IsCOSTO_PRORRATEADONull)
				if (this.COSTO_PRORRATEADO != original.COSTO_PRORRATEADO) return true;
			if (this.IsMONTO_TOTAL_PRORRATEADONull != original.IsMONTO_TOTAL_PRORRATEADONull) return true;
			if (!this.IsMONTO_TOTAL_PRORRATEADONull && !original.IsMONTO_TOTAL_PRORRATEADONull)
				if (this.MONTO_TOTAL_PRORRATEADO != original.MONTO_TOTAL_PRORRATEADO) return true;
			if (this.MONEDA_PAIS_COTIZACION != original.MONEDA_PAIS_COTIZACION) return true;
			
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
		/// </summary>
		/// <value>The <c>INGRESO_STOCK_ID</c> column value.</value>
		public decimal INGRESO_STOCK_ID
		{
			get { return _ingreso_stock_id; }
			set { _ingreso_stock_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_TOTAL_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_TOTAL_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_TOTAL_ORIGEN
		{
			get { return _cantidad_total_origen; }
			set { _cantidad_total_origen = value; }
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
		/// Gets or sets the <c>COSTO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO</c> column value.</value>
		public decimal COSTO
		{
			get { return _costo; }
			set { _costo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_IMPUESTO_PORC</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_IMPUESTO_PORC</c> column value.</value>
		public decimal COSTO_IMPUESTO_PORC
		{
			get { return _costo_impuesto_porc; }
			set { _costo_impuesto_porc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ID</c> column value.</value>
		public string UNIDAD_ID
		{
			get { return _unidad_id; }
			set { _unidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_TOTAL_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_TOTAL_DESTINO</c> column value.</value>
		public decimal CANTIDAD_TOTAL_DESTINO
		{
			get
			{
				if(IsCANTIDAD_TOTAL_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_total_destino;
			}
			set
			{
				_cantidad_total_destinoNull = false;
				_cantidad_total_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_TOTAL_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_TOTAL_DESTINONull
		{
			get { return _cantidad_total_destinoNull; }
			set { _cantidad_total_destinoNull = value; }
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
		/// Gets or sets the <c>PORCENTAJE_PRORRATEO_DETALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_PRORRATEO_DETALLE</c> column value.</value>
		public decimal PORCENTAJE_PRORRATEO_DETALLE
		{
			get
			{
				if(IsPORCENTAJE_PRORRATEO_DETALLENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_prorrateo_detalle;
			}
			set
			{
				_porcentaje_prorrateo_detalleNull = false;
				_porcentaje_prorrateo_detalle = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_PRORRATEO_DETALLE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_PRORRATEO_DETALLENull
		{
			get { return _porcentaje_prorrateo_detalleNull; }
			set { _porcentaje_prorrateo_detalleNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PRORRATEO_DETALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PRORRATEO_DETALLE</c> column value.</value>
		public decimal MONTO_PRORRATEO_DETALLE
		{
			get
			{
				if(IsMONTO_PRORRATEO_DETALLENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_prorrateo_detalle;
			}
			set
			{
				_monto_prorrateo_detalleNull = false;
				_monto_prorrateo_detalle = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PRORRATEO_DETALLE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PRORRATEO_DETALLENull
		{
			get { return _monto_prorrateo_detalleNull; }
			set { _monto_prorrateo_detalleNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PRORRATEADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PRORRATEADO</c> column value.</value>
		public decimal MONTO_PRORRATEADO
		{
			get
			{
				if(IsMONTO_PRORRATEADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_prorrateado;
			}
			set
			{
				_monto_prorrateadoNull = false;
				_monto_prorrateado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PRORRATEADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PRORRATEADONull
		{
			get { return _monto_prorrateadoNull; }
			set { _monto_prorrateadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_NETO_SIN_DTO_ORIGINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_NETO_SIN_DTO_ORIGINAL</c> column value.</value>
		public decimal COSTO_NETO_SIN_DTO_ORIGINAL
		{
			get
			{
				if(IsCOSTO_NETO_SIN_DTO_ORIGINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_neto_sin_dto_original;
			}
			set
			{
				_costo_neto_sin_dto_originalNull = false;
				_costo_neto_sin_dto_original = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_NETO_SIN_DTO_ORIGINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_NETO_SIN_DTO_ORIGINALNull
		{
			get { return _costo_neto_sin_dto_originalNull; }
			set { _costo_neto_sin_dto_originalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGINAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGINAL_ID</c> column value.</value>
		public decimal MONEDA_ORIGINAL_ID
		{
			get
			{
				if(IsMONEDA_ORIGINAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_original_id;
			}
			set
			{
				_moneda_original_idNull = false;
				_moneda_original_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ORIGINAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_ORIGINAL_IDNull
		{
			get { return _moneda_original_idNull; }
			set { _moneda_original_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_ORIGINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_ORIGINAL</c> column value.</value>
		public decimal CANTIDAD_ORIGINAL
		{
			get
			{
				if(IsCANTIDAD_ORIGINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_original;
			}
			set
			{
				_cantidad_originalNull = false;
				_cantidad_original = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_ORIGINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_ORIGINALNull
		{
			get { return _cantidad_originalNull; }
			set { _cantidad_originalNull = value; }
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
		/// Gets or sets the <c>GASTO_UNITARIO_APLICADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GASTO_UNITARIO_APLICADO</c> column value.</value>
		public decimal GASTO_UNITARIO_APLICADO
		{
			get
			{
				if(IsGASTO_UNITARIO_APLICADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _gasto_unitario_aplicado;
			}
			set
			{
				_gasto_unitario_aplicadoNull = false;
				_gasto_unitario_aplicado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GASTO_UNITARIO_APLICADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGASTO_UNITARIO_APLICADONull
		{
			get { return _gasto_unitario_aplicadoNull; }
			set { _gasto_unitario_aplicadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GASTO_TOTAL_APLICADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GASTO_TOTAL_APLICADO</c> column value.</value>
		public decimal GASTO_TOTAL_APLICADO
		{
			get
			{
				if(IsGASTO_TOTAL_APLICADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _gasto_total_aplicado;
			}
			set
			{
				_gasto_total_aplicadoNull = false;
				_gasto_total_aplicado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GASTO_TOTAL_APLICADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGASTO_TOTAL_APLICADONull
		{
			get { return _gasto_total_aplicadoNull; }
			set { _gasto_total_aplicadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_PRORRATEADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_PRORRATEADO</c> column value.</value>
		public decimal COSTO_PRORRATEADO
		{
			get
			{
				if(IsCOSTO_PRORRATEADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_prorrateado;
			}
			set
			{
				_costo_prorrateadoNull = false;
				_costo_prorrateado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_PRORRATEADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_PRORRATEADONull
		{
			get { return _costo_prorrateadoNull; }
			set { _costo_prorrateadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL_PRORRATEADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL_PRORRATEADO</c> column value.</value>
		public decimal MONTO_TOTAL_PRORRATEADO
		{
			get
			{
				if(IsMONTO_TOTAL_PRORRATEADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total_prorrateado;
			}
			set
			{
				_monto_total_prorrateadoNull = false;
				_monto_total_prorrateado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL_PRORRATEADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTAL_PRORRATEADONull
		{
			get { return _monto_total_prorrateadoNull; }
			set { _monto_total_prorrateadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PAIS_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_PAIS_COTIZACION</c> column value.</value>
		public decimal MONEDA_PAIS_COTIZACION
		{
			get { return _moneda_pais_cotizacion; }
			set { _moneda_pais_cotizacion = value; }
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
			dynStr.Append(INGRESO_STOCK_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@CANTIDAD_TOTAL_ORIGEN=");
			dynStr.Append(CANTIDAD_TOTAL_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(COSTO);
			dynStr.Append("@CBA@COSTO_IMPUESTO_PORC=");
			dynStr.Append(COSTO_IMPUESTO_PORC);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@CANTIDAD_TOTAL_DESTINO=");
			dynStr.Append(IsCANTIDAD_TOTAL_DESTINONull ? (object)"<NULL>" : CANTIDAD_TOTAL_DESTINO);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@PORCENTAJE_PRORRATEO_DETALLE=");
			dynStr.Append(IsPORCENTAJE_PRORRATEO_DETALLENull ? (object)"<NULL>" : PORCENTAJE_PRORRATEO_DETALLE);
			dynStr.Append("@CBA@MONTO_PRORRATEO_DETALLE=");
			dynStr.Append(IsMONTO_PRORRATEO_DETALLENull ? (object)"<NULL>" : MONTO_PRORRATEO_DETALLE);
			dynStr.Append("@CBA@MONTO_PRORRATEADO=");
			dynStr.Append(IsMONTO_PRORRATEADONull ? (object)"<NULL>" : MONTO_PRORRATEADO);
			dynStr.Append("@CBA@COSTO_NETO_SIN_DTO_ORIGINAL=");
			dynStr.Append(IsCOSTO_NETO_SIN_DTO_ORIGINALNull ? (object)"<NULL>" : COSTO_NETO_SIN_DTO_ORIGINAL);
			dynStr.Append("@CBA@MONEDA_ORIGINAL_ID=");
			dynStr.Append(IsMONEDA_ORIGINAL_IDNull ? (object)"<NULL>" : MONEDA_ORIGINAL_ID);
			dynStr.Append("@CBA@CANTIDAD_ORIGINAL=");
			dynStr.Append(IsCANTIDAD_ORIGINALNull ? (object)"<NULL>" : CANTIDAD_ORIGINAL);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@GASTO_UNITARIO_APLICADO=");
			dynStr.Append(IsGASTO_UNITARIO_APLICADONull ? (object)"<NULL>" : GASTO_UNITARIO_APLICADO);
			dynStr.Append("@CBA@GASTO_TOTAL_APLICADO=");
			dynStr.Append(IsGASTO_TOTAL_APLICADONull ? (object)"<NULL>" : GASTO_TOTAL_APLICADO);
			dynStr.Append("@CBA@COSTO_PRORRATEADO=");
			dynStr.Append(IsCOSTO_PRORRATEADONull ? (object)"<NULL>" : COSTO_PRORRATEADO);
			dynStr.Append("@CBA@MONTO_TOTAL_PRORRATEADO=");
			dynStr.Append(IsMONTO_TOTAL_PRORRATEADONull ? (object)"<NULL>" : MONTO_TOTAL_PRORRATEADO);
			dynStr.Append("@CBA@MONEDA_PAIS_COTIZACION=");
			dynStr.Append(MONEDA_PAIS_COTIZACION);
			return dynStr.ToString();
		}
	} // End of INGRESO_STOCK_DETALLESRow_Base class
} // End of namespace
