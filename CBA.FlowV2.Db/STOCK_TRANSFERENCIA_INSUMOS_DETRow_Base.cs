// <fileinfo name="STOCK_TRANSFERENCIA_INSUMOS_DETRow_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSFERENCIA_INSUMOS_DETRow"/> that 
	/// represents a record in the <c>STOCK_TRANSFERENCIA_INSUMOS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_TRANSFERENCIA_INSUMOS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSFERENCIA_INSUMOS_DETRow_Base
	{
		private decimal _id;
		private decimal _transferencia_insumos_id;
		private bool _transferencia_insumos_idNull = true;
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
		private decimal _sucursal_destino_id;
		private bool _sucursal_destino_idNull = true;
		private decimal _deposito_destino_id;
		private bool _deposito_destino_idNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _recibido;
		private decimal _tar_bruto;
		private bool _tar_brutoNull = true;
		private decimal _peso_bruto;
		private bool _peso_brutoNull = true;
		private decimal _tar_peso_neto;
		private bool _tar_peso_netoNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _generar_stock;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSFERENCIA_INSUMOS_DETRow_Base"/> class.
		/// </summary>
		public STOCK_TRANSFERENCIA_INSUMOS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_TRANSFERENCIA_INSUMOS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsTRANSFERENCIA_INSUMOS_IDNull != original.IsTRANSFERENCIA_INSUMOS_IDNull) return true;
			if (!this.IsTRANSFERENCIA_INSUMOS_IDNull && !original.IsTRANSFERENCIA_INSUMOS_IDNull)
				if (this.TRANSFERENCIA_INSUMOS_ID != original.TRANSFERENCIA_INSUMOS_ID) return true;
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
			if (this.IsSUCURSAL_DESTINO_IDNull != original.IsSUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_IDNull && !original.IsSUCURSAL_DESTINO_IDNull)
				if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.IsDEPOSITO_DESTINO_IDNull != original.IsDEPOSITO_DESTINO_IDNull) return true;
			if (!this.IsDEPOSITO_DESTINO_IDNull && !original.IsDEPOSITO_DESTINO_IDNull)
				if (this.DEPOSITO_DESTINO_ID != original.DEPOSITO_DESTINO_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.RECIBIDO != original.RECIBIDO) return true;
			if (this.IsTAR_BRUTONull != original.IsTAR_BRUTONull) return true;
			if (!this.IsTAR_BRUTONull && !original.IsTAR_BRUTONull)
				if (this.TAR_BRUTO != original.TAR_BRUTO) return true;
			if (this.IsPESO_BRUTONull != original.IsPESO_BRUTONull) return true;
			if (!this.IsPESO_BRUTONull && !original.IsPESO_BRUTONull)
				if (this.PESO_BRUTO != original.PESO_BRUTO) return true;
			if (this.IsTAR_PESO_NETONull != original.IsTAR_PESO_NETONull) return true;
			if (!this.IsTAR_PESO_NETONull && !original.IsTAR_PESO_NETONull)
				if (this.TAR_PESO_NETO != original.TAR_PESO_NETO) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.GENERAR_STOCK != original.GENERAR_STOCK) return true;
			
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
		/// Gets or sets the <c>TRANSFERENCIA_INSUMOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_INSUMOS_ID</c> column value.</value>
		public decimal TRANSFERENCIA_INSUMOS_ID
		{
			get
			{
				if(IsTRANSFERENCIA_INSUMOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_insumos_id;
			}
			set
			{
				_transferencia_insumos_idNull = false;
				_transferencia_insumos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_INSUMOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_INSUMOS_IDNull
		{
			get { return _transferencia_insumos_idNull; }
			set { _transferencia_insumos_idNull = value; }
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
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get
			{
				if(IsSUCURSAL_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_destino_id;
			}
			set
			{
				_sucursal_destino_idNull = false;
				_sucursal_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_DESTINO_IDNull
		{
			get { return _sucursal_destino_idNull; }
			set { _sucursal_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_DESTINO_ID</c> column value.</value>
		public decimal DEPOSITO_DESTINO_ID
		{
			get
			{
				if(IsDEPOSITO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_destino_id;
			}
			set
			{
				_deposito_destino_idNull = false;
				_deposito_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_DESTINO_IDNull
		{
			get { return _deposito_destino_idNull; }
			set { _deposito_destino_idNull = value; }
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
		/// Gets or sets the <c>RECIBIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECIBIDO</c> column value.</value>
		public string RECIBIDO
		{
			get { return _recibido; }
			set { _recibido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TAR_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TAR_BRUTO</c> column value.</value>
		public decimal TAR_BRUTO
		{
			get
			{
				if(IsTAR_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tar_bruto;
			}
			set
			{
				_tar_brutoNull = false;
				_tar_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TAR_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTAR_BRUTONull
		{
			get { return _tar_brutoNull; }
			set { _tar_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_BRUTO</c> column value.</value>
		public decimal PESO_BRUTO
		{
			get
			{
				if(IsPESO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_bruto;
			}
			set
			{
				_peso_brutoNull = false;
				_peso_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_BRUTONull
		{
			get { return _peso_brutoNull; }
			set { _peso_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TAR_PESO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TAR_PESO_NETO</c> column value.</value>
		public decimal TAR_PESO_NETO
		{
			get
			{
				if(IsTAR_PESO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tar_peso_neto;
			}
			set
			{
				_tar_peso_netoNull = false;
				_tar_peso_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TAR_PESO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTAR_PESO_NETONull
		{
			get { return _tar_peso_netoNull; }
			set { _tar_peso_netoNull = value; }
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
		/// Gets or sets the <c>GENERAR_STOCK</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GENERAR_STOCK</c> column value.</value>
		public string GENERAR_STOCK
		{
			get { return _generar_stock; }
			set { _generar_stock = value; }
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
			dynStr.Append("@CBA@TRANSFERENCIA_INSUMOS_ID=");
			dynStr.Append(IsTRANSFERENCIA_INSUMOS_IDNull ? (object)"<NULL>" : TRANSFERENCIA_INSUMOS_ID);
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
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(IsSUCURSAL_DESTINO_IDNull ? (object)"<NULL>" : SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@DEPOSITO_DESTINO_ID=");
			dynStr.Append(IsDEPOSITO_DESTINO_IDNull ? (object)"<NULL>" : DEPOSITO_DESTINO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@RECIBIDO=");
			dynStr.Append(RECIBIDO);
			dynStr.Append("@CBA@TAR_BRUTO=");
			dynStr.Append(IsTAR_BRUTONull ? (object)"<NULL>" : TAR_BRUTO);
			dynStr.Append("@CBA@PESO_BRUTO=");
			dynStr.Append(IsPESO_BRUTONull ? (object)"<NULL>" : PESO_BRUTO);
			dynStr.Append("@CBA@TAR_PESO_NETO=");
			dynStr.Append(IsTAR_PESO_NETONull ? (object)"<NULL>" : TAR_PESO_NETO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@GENERAR_STOCK=");
			dynStr.Append(GENERAR_STOCK);
			return dynStr.ToString();
		}
	} // End of STOCK_TRANSFERENCIA_INSUMOS_DETRow_Base class
} // End of namespace
