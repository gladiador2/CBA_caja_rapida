// <fileinfo name="STOCK_TRANSFERENCIA_DETALLERow_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> that 
	/// represents a record in the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_TRANSFERENCIA_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSFERENCIA_DETALLERow_Base
	{
		private decimal _id;
		private decimal _transferencia_stock_id;
		private bool _transferencia_stock_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _unidad_medida_destino_id;
		private decimal _cantidad_dest_unitaria;
		private bool _cantidad_dest_unitariaNull = true;
		private decimal _cantidad_dest_embalada;
		private bool _cantidad_dest_embaladaNull = true;
		private decimal _cantidad_dest_caja;
		private bool _cantidad_dest_cajaNull = true;
		private decimal _costo_moneda_id;
		private bool _costo_moneda_idNull = true;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private decimal _monto_costo;
		private bool _monto_costoNull = true;
		private string _observacion;
		private decimal _cantidad_unitaria_dest_total;
		private bool _cantidad_unitaria_dest_totalNull = true;
		private string _unidad_medida_origen_id;
		private decimal _cantidad_orig_unitaria;
		private bool _cantidad_orig_unitariaNull = true;
		private decimal _cantidad_orig_embalada;
		private bool _cantidad_orig_embaladaNull = true;
		private decimal _cantidad_orig_caja;
		private bool _cantidad_orig_cajaNull = true;
		private decimal _cantidad_unitaria_orig_total;
		private bool _cantidad_unitaria_orig_totalNull = true;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private decimal _costos_id;
		private bool _costos_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSFERENCIA_DETALLERow_Base"/> class.
		/// </summary>
		public STOCK_TRANSFERENCIA_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_TRANSFERENCIA_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsTRANSFERENCIA_STOCK_IDNull != original.IsTRANSFERENCIA_STOCK_IDNull) return true;
			if (!this.IsTRANSFERENCIA_STOCK_IDNull && !original.IsTRANSFERENCIA_STOCK_IDNull)
				if (this.TRANSFERENCIA_STOCK_ID != original.TRANSFERENCIA_STOCK_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.UNIDAD_MEDIDA_DESTINO_ID != original.UNIDAD_MEDIDA_DESTINO_ID) return true;
			if (this.IsCANTIDAD_DEST_UNITARIANull != original.IsCANTIDAD_DEST_UNITARIANull) return true;
			if (!this.IsCANTIDAD_DEST_UNITARIANull && !original.IsCANTIDAD_DEST_UNITARIANull)
				if (this.CANTIDAD_DEST_UNITARIA != original.CANTIDAD_DEST_UNITARIA) return true;
			if (this.IsCANTIDAD_DEST_EMBALADANull != original.IsCANTIDAD_DEST_EMBALADANull) return true;
			if (!this.IsCANTIDAD_DEST_EMBALADANull && !original.IsCANTIDAD_DEST_EMBALADANull)
				if (this.CANTIDAD_DEST_EMBALADA != original.CANTIDAD_DEST_EMBALADA) return true;
			if (this.IsCANTIDAD_DEST_CAJANull != original.IsCANTIDAD_DEST_CAJANull) return true;
			if (!this.IsCANTIDAD_DEST_CAJANull && !original.IsCANTIDAD_DEST_CAJANull)
				if (this.CANTIDAD_DEST_CAJA != original.CANTIDAD_DEST_CAJA) return true;
			if (this.IsCOSTO_MONEDA_IDNull != original.IsCOSTO_MONEDA_IDNull) return true;
			if (!this.IsCOSTO_MONEDA_IDNull && !original.IsCOSTO_MONEDA_IDNull)
				if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsMONTO_COSTONull != original.IsMONTO_COSTONull) return true;
			if (!this.IsMONTO_COSTONull && !original.IsMONTO_COSTONull)
				if (this.MONTO_COSTO != original.MONTO_COSTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCANTIDAD_UNITARIA_DEST_TOTALNull != original.IsCANTIDAD_UNITARIA_DEST_TOTALNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_DEST_TOTALNull && !original.IsCANTIDAD_UNITARIA_DEST_TOTALNull)
				if (this.CANTIDAD_UNITARIA_DEST_TOTAL != original.CANTIDAD_UNITARIA_DEST_TOTAL) return true;
			if (this.UNIDAD_MEDIDA_ORIGEN_ID != original.UNIDAD_MEDIDA_ORIGEN_ID) return true;
			if (this.IsCANTIDAD_ORIG_UNITARIANull != original.IsCANTIDAD_ORIG_UNITARIANull) return true;
			if (!this.IsCANTIDAD_ORIG_UNITARIANull && !original.IsCANTIDAD_ORIG_UNITARIANull)
				if (this.CANTIDAD_ORIG_UNITARIA != original.CANTIDAD_ORIG_UNITARIA) return true;
			if (this.IsCANTIDAD_ORIG_EMBALADANull != original.IsCANTIDAD_ORIG_EMBALADANull) return true;
			if (!this.IsCANTIDAD_ORIG_EMBALADANull && !original.IsCANTIDAD_ORIG_EMBALADANull)
				if (this.CANTIDAD_ORIG_EMBALADA != original.CANTIDAD_ORIG_EMBALADA) return true;
			if (this.IsCANTIDAD_ORIG_CAJANull != original.IsCANTIDAD_ORIG_CAJANull) return true;
			if (!this.IsCANTIDAD_ORIG_CAJANull && !original.IsCANTIDAD_ORIG_CAJANull)
				if (this.CANTIDAD_ORIG_CAJA != original.CANTIDAD_ORIG_CAJA) return true;
			if (this.IsCANTIDAD_UNITARIA_ORIG_TOTALNull != original.IsCANTIDAD_UNITARIA_ORIG_TOTALNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_ORIG_TOTALNull && !original.IsCANTIDAD_UNITARIA_ORIG_TOTALNull)
				if (this.CANTIDAD_UNITARIA_ORIG_TOTAL != original.CANTIDAD_UNITARIA_ORIG_TOTAL) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.IsCOSTOS_IDNull != original.IsCOSTOS_IDNull) return true;
			if (!this.IsCOSTOS_IDNull && !original.IsCOSTOS_IDNull)
				if (this.COSTOS_ID != original.COSTOS_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			
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
		/// Gets or sets the <c>TRANSFERENCIA_STOCK_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_STOCK_ID</c> column value.</value>
		public decimal TRANSFERENCIA_STOCK_ID
		{
			get
			{
				if(IsTRANSFERENCIA_STOCK_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_stock_id;
			}
			set
			{
				_transferencia_stock_idNull = false;
				_transferencia_stock_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_STOCK_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_STOCK_IDNull
		{
			get { return _transferencia_stock_idNull; }
			set { _transferencia_stock_idNull = value; }
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
		/// Gets or sets the <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_DESTINO_ID
		{
			get { return _unidad_medida_destino_id; }
			set { _unidad_medida_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DEST_UNITARIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DEST_UNITARIA</c> column value.</value>
		public decimal CANTIDAD_DEST_UNITARIA
		{
			get
			{
				if(IsCANTIDAD_DEST_UNITARIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_dest_unitaria;
			}
			set
			{
				_cantidad_dest_unitariaNull = false;
				_cantidad_dest_unitaria = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DEST_UNITARIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DEST_UNITARIANull
		{
			get { return _cantidad_dest_unitariaNull; }
			set { _cantidad_dest_unitariaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DEST_EMBALADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DEST_EMBALADA</c> column value.</value>
		public decimal CANTIDAD_DEST_EMBALADA
		{
			get
			{
				if(IsCANTIDAD_DEST_EMBALADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_dest_embalada;
			}
			set
			{
				_cantidad_dest_embaladaNull = false;
				_cantidad_dest_embalada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DEST_EMBALADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DEST_EMBALADANull
		{
			get { return _cantidad_dest_embaladaNull; }
			set { _cantidad_dest_embaladaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DEST_CAJA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DEST_CAJA</c> column value.</value>
		public decimal CANTIDAD_DEST_CAJA
		{
			get
			{
				if(IsCANTIDAD_DEST_CAJANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_dest_caja;
			}
			set
			{
				_cantidad_dest_cajaNull = false;
				_cantidad_dest_caja = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DEST_CAJA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DEST_CAJANull
		{
			get { return _cantidad_dest_cajaNull; }
			set { _cantidad_dest_cajaNull = value; }
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
		/// Gets or sets the <c>MONTO_COSTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COSTO</c> column value.</value>
		public decimal MONTO_COSTO
		{
			get
			{
				if(IsMONTO_COSTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_costo;
			}
			set
			{
				_monto_costoNull = false;
				_monto_costo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COSTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COSTONull
		{
			get { return _monto_costoNull; }
			set { _monto_costoNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_UNITARIA_DEST_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_DEST_TOTAL</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_DEST_TOTAL
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_DEST_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_dest_total;
			}
			set
			{
				_cantidad_unitaria_dest_totalNull = false;
				_cantidad_unitaria_dest_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_DEST_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_DEST_TOTALNull
		{
			get { return _cantidad_unitaria_dest_totalNull; }
			set { _cantidad_unitaria_dest_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ORIGEN_ID
		{
			get { return _unidad_medida_origen_id; }
			set { _unidad_medida_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_ORIG_UNITARIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_ORIG_UNITARIA</c> column value.</value>
		public decimal CANTIDAD_ORIG_UNITARIA
		{
			get
			{
				if(IsCANTIDAD_ORIG_UNITARIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_orig_unitaria;
			}
			set
			{
				_cantidad_orig_unitariaNull = false;
				_cantidad_orig_unitaria = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_ORIG_UNITARIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_ORIG_UNITARIANull
		{
			get { return _cantidad_orig_unitariaNull; }
			set { _cantidad_orig_unitariaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_ORIG_EMBALADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_ORIG_EMBALADA</c> column value.</value>
		public decimal CANTIDAD_ORIG_EMBALADA
		{
			get
			{
				if(IsCANTIDAD_ORIG_EMBALADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_orig_embalada;
			}
			set
			{
				_cantidad_orig_embaladaNull = false;
				_cantidad_orig_embalada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_ORIG_EMBALADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_ORIG_EMBALADANull
		{
			get { return _cantidad_orig_embaladaNull; }
			set { _cantidad_orig_embaladaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_ORIG_CAJA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_ORIG_CAJA</c> column value.</value>
		public decimal CANTIDAD_ORIG_CAJA
		{
			get
			{
				if(IsCANTIDAD_ORIG_CAJANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_orig_caja;
			}
			set
			{
				_cantidad_orig_cajaNull = false;
				_cantidad_orig_caja = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_ORIG_CAJA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_ORIG_CAJANull
		{
			get { return _cantidad_orig_cajaNull; }
			set { _cantidad_orig_cajaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_ORIG_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_ORIG_TOTAL</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_ORIG_TOTAL
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_ORIG_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_orig_total;
			}
			set
			{
				_cantidad_unitaria_orig_totalNull = false;
				_cantidad_unitaria_orig_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_ORIG_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_ORIG_TOTALNull
		{
			get { return _cantidad_unitaria_orig_totalNull; }
			set { _cantidad_unitaria_orig_totalNull = value; }
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
		/// Gets or sets the <c>COSTOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTOS_ID</c> column value.</value>
		public decimal COSTOS_ID
		{
			get
			{
				if(IsCOSTOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costos_id;
			}
			set
			{
				_costos_idNull = false;
				_costos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTOS_IDNull
		{
			get { return _costos_idNull; }
			set { _costos_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TRANSFERENCIA_STOCK_ID=");
			dynStr.Append(IsTRANSFERENCIA_STOCK_IDNull ? (object)"<NULL>" : TRANSFERENCIA_STOCK_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESTINO_ID=");
			dynStr.Append(UNIDAD_MEDIDA_DESTINO_ID);
			dynStr.Append("@CBA@CANTIDAD_DEST_UNITARIA=");
			dynStr.Append(IsCANTIDAD_DEST_UNITARIANull ? (object)"<NULL>" : CANTIDAD_DEST_UNITARIA);
			dynStr.Append("@CBA@CANTIDAD_DEST_EMBALADA=");
			dynStr.Append(IsCANTIDAD_DEST_EMBALADANull ? (object)"<NULL>" : CANTIDAD_DEST_EMBALADA);
			dynStr.Append("@CBA@CANTIDAD_DEST_CAJA=");
			dynStr.Append(IsCANTIDAD_DEST_CAJANull ? (object)"<NULL>" : CANTIDAD_DEST_CAJA);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(IsCOSTO_MONEDA_IDNull ? (object)"<NULL>" : COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_COSTO=");
			dynStr.Append(IsMONTO_COSTONull ? (object)"<NULL>" : MONTO_COSTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_DEST_TOTAL=");
			dynStr.Append(IsCANTIDAD_UNITARIA_DEST_TOTALNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_DEST_TOTAL);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ORIGEN_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ORIGEN_ID);
			dynStr.Append("@CBA@CANTIDAD_ORIG_UNITARIA=");
			dynStr.Append(IsCANTIDAD_ORIG_UNITARIANull ? (object)"<NULL>" : CANTIDAD_ORIG_UNITARIA);
			dynStr.Append("@CBA@CANTIDAD_ORIG_EMBALADA=");
			dynStr.Append(IsCANTIDAD_ORIG_EMBALADANull ? (object)"<NULL>" : CANTIDAD_ORIG_EMBALADA);
			dynStr.Append("@CBA@CANTIDAD_ORIG_CAJA=");
			dynStr.Append(IsCANTIDAD_ORIG_CAJANull ? (object)"<NULL>" : CANTIDAD_ORIG_CAJA);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_ORIG_TOTAL=");
			dynStr.Append(IsCANTIDAD_UNITARIA_ORIG_TOTALNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_ORIG_TOTAL);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@COSTOS_ID=");
			dynStr.Append(IsCOSTOS_IDNull ? (object)"<NULL>" : COSTOS_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			return dynStr.ToString();
		}
	} // End of STOCK_TRANSFERENCIA_DETALLERow_Base class
} // End of namespace
