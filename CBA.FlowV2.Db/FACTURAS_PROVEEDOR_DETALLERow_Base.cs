// <fileinfo name="FACTURAS_PROVEEDOR_DETALLERow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROVEEDOR_DETALLERow"/> that 
	/// represents a record in the <c>FACTURAS_PROVEEDOR_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_PROVEEDOR_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROVEEDOR_DETALLERow_Base
	{
		private decimal _id;
		private decimal _facturas_proveedor_id;
		private string _observacion;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _unidad_id_destino;
		private decimal _cantidad_embalada_destino;
		private decimal _cantidad_unidad_destino;
		private decimal _cantidad_por_caja_destino;
		private decimal _cantidad_unitaria_total_dest;
		private decimal _precio_bruto_unitario_dest;
		private decimal _porcentaje_descuento;
		private decimal _porcentaje_impuesto;
		private decimal _total_bruto;
		private decimal _total_descuento;
		private decimal _total_impuesto_descontado;
		private decimal _total_pago;
		private decimal _cantidad_devuelta_nota_credito;
		private bool _cantidad_devuelta_nota_creditoNull = true;
		private string _unidad_id_origen;
		private decimal _cantidad_embalada_origen;
		private bool _cantidad_embalada_origenNull = true;
		private decimal _cantidad_por_caja_origen;
		private bool _cantidad_por_caja_origenNull = true;
		private decimal _cantidad_unidad_origen;
		private bool _cantidad_unidad_origenNull = true;
		private decimal _cantidad_unitaria_total_orig;
		private bool _cantidad_unitaria_total_origNull = true;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private decimal _precio_bruto_unitario_orig;
		private bool _precio_bruto_unitario_origNull = true;
		private decimal _rubro_id;
		private bool _rubro_idNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _impuesto_id;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _tipo_detalle;
		private string _afecta_stock;
		private decimal _proveedor_relacionado_id;
		private bool _proveedor_relacionado_idNull = true;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _rubro_iva_id;
		private bool _rubro_iva_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROVEEDOR_DETALLERow_Base"/> class.
		/// </summary>
		public FACTURAS_PROVEEDOR_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_PROVEEDOR_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FACTURAS_PROVEEDOR_ID != original.FACTURAS_PROVEEDOR_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.UNIDAD_ID_DESTINO != original.UNIDAD_ID_DESTINO) return true;
			if (this.CANTIDAD_EMBALADA_DESTINO != original.CANTIDAD_EMBALADA_DESTINO) return true;
			if (this.CANTIDAD_UNIDAD_DESTINO != original.CANTIDAD_UNIDAD_DESTINO) return true;
			if (this.CANTIDAD_POR_CAJA_DESTINO != original.CANTIDAD_POR_CAJA_DESTINO) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL_DEST != original.CANTIDAD_UNITARIA_TOTAL_DEST) return true;
			if (this.PRECIO_BRUTO_UNITARIO_DEST != original.PRECIO_BRUTO_UNITARIO_DEST) return true;
			if (this.PORCENTAJE_DESCUENTO != original.PORCENTAJE_DESCUENTO) return true;
			if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.TOTAL_BRUTO != original.TOTAL_BRUTO) return true;
			if (this.TOTAL_DESCUENTO != original.TOTAL_DESCUENTO) return true;
			if (this.TOTAL_IMPUESTO_DESCONTADO != original.TOTAL_IMPUESTO_DESCONTADO) return true;
			if (this.TOTAL_PAGO != original.TOTAL_PAGO) return true;
			if (this.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull != original.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull) return true;
			if (!this.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull && !original.IsCANTIDAD_DEVUELTA_NOTA_CREDITONull)
				if (this.CANTIDAD_DEVUELTA_NOTA_CREDITO != original.CANTIDAD_DEVUELTA_NOTA_CREDITO) return true;
			if (this.UNIDAD_ID_ORIGEN != original.UNIDAD_ID_ORIGEN) return true;
			if (this.IsCANTIDAD_EMBALADA_ORIGENNull != original.IsCANTIDAD_EMBALADA_ORIGENNull) return true;
			if (!this.IsCANTIDAD_EMBALADA_ORIGENNull && !original.IsCANTIDAD_EMBALADA_ORIGENNull)
				if (this.CANTIDAD_EMBALADA_ORIGEN != original.CANTIDAD_EMBALADA_ORIGEN) return true;
			if (this.IsCANTIDAD_POR_CAJA_ORIGENNull != original.IsCANTIDAD_POR_CAJA_ORIGENNull) return true;
			if (!this.IsCANTIDAD_POR_CAJA_ORIGENNull && !original.IsCANTIDAD_POR_CAJA_ORIGENNull)
				if (this.CANTIDAD_POR_CAJA_ORIGEN != original.CANTIDAD_POR_CAJA_ORIGEN) return true;
			if (this.IsCANTIDAD_UNIDAD_ORIGENNull != original.IsCANTIDAD_UNIDAD_ORIGENNull) return true;
			if (!this.IsCANTIDAD_UNIDAD_ORIGENNull && !original.IsCANTIDAD_UNIDAD_ORIGENNull)
				if (this.CANTIDAD_UNIDAD_ORIGEN != original.CANTIDAD_UNIDAD_ORIGEN) return true;
			if (this.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull != original.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull && !original.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull)
				if (this.CANTIDAD_UNITARIA_TOTAL_ORIG != original.CANTIDAD_UNITARIA_TOTAL_ORIG) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.IsPRECIO_BRUTO_UNITARIO_ORIGNull != original.IsPRECIO_BRUTO_UNITARIO_ORIGNull) return true;
			if (!this.IsPRECIO_BRUTO_UNITARIO_ORIGNull && !original.IsPRECIO_BRUTO_UNITARIO_ORIGNull)
				if (this.PRECIO_BRUTO_UNITARIO_ORIG != original.PRECIO_BRUTO_UNITARIO_ORIG) return true;
			if (this.IsRUBRO_IDNull != original.IsRUBRO_IDNull) return true;
			if (!this.IsRUBRO_IDNull && !original.IsRUBRO_IDNull)
				if (this.RUBRO_ID != original.RUBRO_ID) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TIPO_DETALLE != original.TIPO_DETALLE) return true;
			if (this.AFECTA_STOCK != original.AFECTA_STOCK) return true;
			if (this.IsPROVEEDOR_RELACIONADO_IDNull != original.IsPROVEEDOR_RELACIONADO_IDNull) return true;
			if (!this.IsPROVEEDOR_RELACIONADO_IDNull && !original.IsPROVEEDOR_RELACIONADO_IDNull)
				if (this.PROVEEDOR_RELACIONADO_ID != original.PROVEEDOR_RELACIONADO_ID) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.IsRUBRO_IVA_IDNull != original.IsRUBRO_IVA_IDNull) return true;
			if (!this.IsRUBRO_IVA_IDNull && !original.IsRUBRO_IVA_IDNull)
				if (this.RUBRO_IVA_ID != original.RUBRO_IVA_ID) return true;
			
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
		/// Gets or sets the <c>FACTURAS_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAS_PROVEEDOR_ID</c> column value.</value>
		public decimal FACTURAS_PROVEEDOR_ID
		{
			get { return _facturas_proveedor_id; }
			set { _facturas_proveedor_id = value; }
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
		/// Gets or sets the <c>UNIDAD_ID_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_ID_DESTINO</c> column value.</value>
		public string UNIDAD_ID_DESTINO
		{
			get { return _unidad_id_destino; }
			set { _unidad_id_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_EMBALADA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_EMBALADA_DESTINO</c> column value.</value>
		public decimal CANTIDAD_EMBALADA_DESTINO
		{
			get { return _cantidad_embalada_destino; }
			set { _cantidad_embalada_destino = value; }
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
		/// Gets or sets the <c>PRECIO_BRUTO_UNITARIO_DEST</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_BRUTO_UNITARIO_DEST</c> column value.</value>
		public decimal PRECIO_BRUTO_UNITARIO_DEST
		{
			get { return _precio_bruto_unitario_dest; }
			set { _precio_bruto_unitario_dest = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DESCUENTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DESCUENTO</c> column value.</value>
		public decimal PORCENTAJE_DESCUENTO
		{
			get { return _porcentaje_descuento; }
			set { _porcentaje_descuento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get { return _porcentaje_impuesto; }
			set { _porcentaje_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BRUTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_BRUTO</c> column value.</value>
		public decimal TOTAL_BRUTO
		{
			get { return _total_bruto; }
			set { _total_bruto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DESCUENTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_DESCUENTO</c> column value.</value>
		public decimal TOTAL_DESCUENTO
		{
			get { return _total_descuento; }
			set { _total_descuento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO_DESCONTADO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO_DESCONTADO</c> column value.</value>
		public decimal TOTAL_IMPUESTO_DESCONTADO
		{
			get { return _total_impuesto_descontado; }
			set { _total_impuesto_descontado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_PAGO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_PAGO</c> column value.</value>
		public decimal TOTAL_PAGO
		{
			get { return _total_pago; }
			set { _total_pago = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DEVUELTA_NOTA_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DEVUELTA_NOTA_CREDITO</c> column value.</value>
		public decimal CANTIDAD_DEVUELTA_NOTA_CREDITO
		{
			get
			{
				if(IsCANTIDAD_DEVUELTA_NOTA_CREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_devuelta_nota_credito;
			}
			set
			{
				_cantidad_devuelta_nota_creditoNull = false;
				_cantidad_devuelta_nota_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DEVUELTA_NOTA_CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DEVUELTA_NOTA_CREDITONull
		{
			get { return _cantidad_devuelta_nota_creditoNull; }
			set { _cantidad_devuelta_nota_creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ID_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ID_ORIGEN</c> column value.</value>
		public string UNIDAD_ID_ORIGEN
		{
			get { return _unidad_id_origen; }
			set { _unidad_id_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_EMBALADA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_EMBALADA_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_EMBALADA_ORIGEN
		{
			get
			{
				if(IsCANTIDAD_EMBALADA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_embalada_origen;
			}
			set
			{
				_cantidad_embalada_origenNull = false;
				_cantidad_embalada_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_EMBALADA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_EMBALADA_ORIGENNull
		{
			get { return _cantidad_embalada_origenNull; }
			set { _cantidad_embalada_origenNull = value; }
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
		/// Gets or sets the <c>PRECIO_BRUTO_UNITARIO_ORIG</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO_BRUTO_UNITARIO_ORIG</c> column value.</value>
		public decimal PRECIO_BRUTO_UNITARIO_ORIG
		{
			get
			{
				if(IsPRECIO_BRUTO_UNITARIO_ORIGNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio_bruto_unitario_orig;
			}
			set
			{
				_precio_bruto_unitario_origNull = false;
				_precio_bruto_unitario_orig = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO_BRUTO_UNITARIO_ORIG"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIO_BRUTO_UNITARIO_ORIGNull
		{
			get { return _precio_bruto_unitario_origNull; }
			set { _precio_bruto_unitario_origNull = value; }
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
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
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
		/// Gets or sets the <c>TIPO_DETALLE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DETALLE</c> column value.</value>
		public decimal TIPO_DETALLE
		{
			get { return _tipo_detalle; }
			set { _tipo_detalle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_STOCK</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AFECTA_STOCK</c> column value.</value>
		public string AFECTA_STOCK
		{
			get { return _afecta_stock; }
			set { _afecta_stock = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RELACIONADO_ID</c> column value.</value>
		public decimal PROVEEDOR_RELACIONADO_ID
		{
			get
			{
				if(IsPROVEEDOR_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_relacionado_id;
			}
			set
			{
				_proveedor_relacionado_idNull = false;
				_proveedor_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_RELACIONADO_IDNull
		{
			get { return _proveedor_relacionado_idNull; }
			set { _proveedor_relacionado_idNull = value; }
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
		/// Gets or sets the <c>RUBRO_IVA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUBRO_IVA_ID</c> column value.</value>
		public decimal RUBRO_IVA_ID
		{
			get
			{
				if(IsRUBRO_IVA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rubro_iva_id;
			}
			set
			{
				_rubro_iva_idNull = false;
				_rubro_iva_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RUBRO_IVA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRUBRO_IVA_IDNull
		{
			get { return _rubro_iva_idNull; }
			set { _rubro_iva_idNull = value; }
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
			dynStr.Append("@CBA@FACTURAS_PROVEEDOR_ID=");
			dynStr.Append(FACTURAS_PROVEEDOR_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@UNIDAD_ID_DESTINO=");
			dynStr.Append(UNIDAD_ID_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_EMBALADA_DESTINO=");
			dynStr.Append(CANTIDAD_EMBALADA_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_DESTINO=");
			dynStr.Append(CANTIDAD_UNIDAD_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_DESTINO=");
			dynStr.Append(CANTIDAD_POR_CAJA_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_DEST=");
			dynStr.Append(CANTIDAD_UNITARIA_TOTAL_DEST);
			dynStr.Append("@CBA@PRECIO_BRUTO_UNITARIO_DEST=");
			dynStr.Append(PRECIO_BRUTO_UNITARIO_DEST);
			dynStr.Append("@CBA@PORCENTAJE_DESCUENTO=");
			dynStr.Append(PORCENTAJE_DESCUENTO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@TOTAL_BRUTO=");
			dynStr.Append(TOTAL_BRUTO);
			dynStr.Append("@CBA@TOTAL_DESCUENTO=");
			dynStr.Append(TOTAL_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_IMPUESTO_DESCONTADO=");
			dynStr.Append(TOTAL_IMPUESTO_DESCONTADO);
			dynStr.Append("@CBA@TOTAL_PAGO=");
			dynStr.Append(TOTAL_PAGO);
			dynStr.Append("@CBA@CANTIDAD_DEVUELTA_NOTA_CREDITO=");
			dynStr.Append(IsCANTIDAD_DEVUELTA_NOTA_CREDITONull ? (object)"<NULL>" : CANTIDAD_DEVUELTA_NOTA_CREDITO);
			dynStr.Append("@CBA@UNIDAD_ID_ORIGEN=");
			dynStr.Append(UNIDAD_ID_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_EMBALADA_ORIGEN=");
			dynStr.Append(IsCANTIDAD_EMBALADA_ORIGENNull ? (object)"<NULL>" : CANTIDAD_EMBALADA_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_ORIGEN=");
			dynStr.Append(IsCANTIDAD_POR_CAJA_ORIGENNull ? (object)"<NULL>" : CANTIDAD_POR_CAJA_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_ORIGEN=");
			dynStr.Append(IsCANTIDAD_UNIDAD_ORIGENNull ? (object)"<NULL>" : CANTIDAD_UNIDAD_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_ORIG=");
			dynStr.Append(IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_TOTAL_ORIG);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@PRECIO_BRUTO_UNITARIO_ORIG=");
			dynStr.Append(IsPRECIO_BRUTO_UNITARIO_ORIGNull ? (object)"<NULL>" : PRECIO_BRUTO_UNITARIO_ORIG);
			dynStr.Append("@CBA@RUBRO_ID=");
			dynStr.Append(IsRUBRO_IDNull ? (object)"<NULL>" : RUBRO_ID);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TIPO_DETALLE=");
			dynStr.Append(TIPO_DETALLE);
			dynStr.Append("@CBA@AFECTA_STOCK=");
			dynStr.Append(AFECTA_STOCK);
			dynStr.Append("@CBA@PROVEEDOR_RELACIONADO_ID=");
			dynStr.Append(IsPROVEEDOR_RELACIONADO_IDNull ? (object)"<NULL>" : PROVEEDOR_RELACIONADO_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@RUBRO_IVA_ID=");
			dynStr.Append(IsRUBRO_IVA_IDNull ? (object)"<NULL>" : RUBRO_IVA_ID);
			return dynStr.ToString();
		}
	} // End of FACTURAS_PROVEEDOR_DETALLERow_Base class
} // End of namespace
