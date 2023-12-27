// <fileinfo name="STOCK_AJUSTE_DETALLERow_Base.cs">
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
	/// The base class for <see cref="STOCK_AJUSTE_DETALLERow"/> that 
	/// represents a record in the <c>STOCK_AJUSTE_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_AJUSTE_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_AJUSTE_DETALLERow_Base
	{
		private decimal _id;
		private decimal _stock_ajuste_id;
		private bool _stock_ajuste_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _unidad_medida_destino_id;
		private decimal _cantidad_destino;
		private bool _cantidad_destinoNull = true;
		private string _observacion;
		private string _unidad_medida_origen_id;
		private decimal _cantidad_origen;
		private bool _cantidad_origenNull = true;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _costo_total;
		private bool _costo_totalNull = true;
		private decimal _costo_unitario;
		private bool _costo_unitarioNull = true;
		private string _ajustado;
		private decimal _inventario_cant_sistema;
		private bool _inventario_cant_sistemaNull = true;
		private decimal _inventario_cant_encontrada;
		private bool _inventario_cant_encontradaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_AJUSTE_DETALLERow_Base"/> class.
		/// </summary>
		public STOCK_AJUSTE_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_AJUSTE_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsSTOCK_AJUSTE_IDNull != original.IsSTOCK_AJUSTE_IDNull) return true;
			if (!this.IsSTOCK_AJUSTE_IDNull && !original.IsSTOCK_AJUSTE_IDNull)
				if (this.STOCK_AJUSTE_ID != original.STOCK_AJUSTE_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.UNIDAD_MEDIDA_DESTINO_ID != original.UNIDAD_MEDIDA_DESTINO_ID) return true;
			if (this.IsCANTIDAD_DESTINONull != original.IsCANTIDAD_DESTINONull) return true;
			if (!this.IsCANTIDAD_DESTINONull && !original.IsCANTIDAD_DESTINONull)
				if (this.CANTIDAD_DESTINO != original.CANTIDAD_DESTINO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.UNIDAD_MEDIDA_ORIGEN_ID != original.UNIDAD_MEDIDA_ORIGEN_ID) return true;
			if (this.IsCANTIDAD_ORIGENNull != original.IsCANTIDAD_ORIGENNull) return true;
			if (!this.IsCANTIDAD_ORIGENNull && !original.IsCANTIDAD_ORIGENNull)
				if (this.CANTIDAD_ORIGEN != original.CANTIDAD_ORIGEN) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsCOSTO_TOTALNull != original.IsCOSTO_TOTALNull) return true;
			if (!this.IsCOSTO_TOTALNull && !original.IsCOSTO_TOTALNull)
				if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			if (this.IsCOSTO_UNITARIONull != original.IsCOSTO_UNITARIONull) return true;
			if (!this.IsCOSTO_UNITARIONull && !original.IsCOSTO_UNITARIONull)
				if (this.COSTO_UNITARIO != original.COSTO_UNITARIO) return true;
			if (this.AJUSTADO != original.AJUSTADO) return true;
			if (this.IsINVENTARIO_CANT_SISTEMANull != original.IsINVENTARIO_CANT_SISTEMANull) return true;
			if (!this.IsINVENTARIO_CANT_SISTEMANull && !original.IsINVENTARIO_CANT_SISTEMANull)
				if (this.INVENTARIO_CANT_SISTEMA != original.INVENTARIO_CANT_SISTEMA) return true;
			if (this.IsINVENTARIO_CANT_ENCONTRADANull != original.IsINVENTARIO_CANT_ENCONTRADANull) return true;
			if (!this.IsINVENTARIO_CANT_ENCONTRADANull && !original.IsINVENTARIO_CANT_ENCONTRADANull)
				if (this.INVENTARIO_CANT_ENCONTRADA != original.INVENTARIO_CANT_ENCONTRADA) return true;
			
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
		/// Gets or sets the <c>STOCK_AJUSTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>STOCK_AJUSTE_ID</c> column value.</value>
		public decimal STOCK_AJUSTE_ID
		{
			get
			{
				if(IsSTOCK_AJUSTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _stock_ajuste_id;
			}
			set
			{
				_stock_ajuste_idNull = false;
				_stock_ajuste_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="STOCK_AJUSTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSTOCK_AJUSTE_IDNull
		{
			get { return _stock_ajuste_idNull; }
			set { _stock_ajuste_idNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DESTINO</c> column value.</value>
		public decimal CANTIDAD_DESTINO
		{
			get
			{
				if(IsCANTIDAD_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_destino;
			}
			set
			{
				_cantidad_destinoNull = false;
				_cantidad_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DESTINONull
		{
			get { return _cantidad_destinoNull; }
			set { _cantidad_destinoNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_ORIGEN
		{
			get
			{
				if(IsCANTIDAD_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_origen;
			}
			set
			{
				_cantidad_origenNull = false;
				_cantidad_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_ORIGENNull
		{
			get { return _cantidad_origenNull; }
			set { _cantidad_origenNull = value; }
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
		/// Gets or sets the <c>COSTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_TOTAL</c> column value.</value>
		public decimal COSTO_TOTAL
		{
			get
			{
				if(IsCOSTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_total;
			}
			set
			{
				_costo_totalNull = false;
				_costo_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_TOTALNull
		{
			get { return _costo_totalNull; }
			set { _costo_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_UNITARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_UNITARIO</c> column value.</value>
		public decimal COSTO_UNITARIO
		{
			get
			{
				if(IsCOSTO_UNITARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_unitario;
			}
			set
			{
				_costo_unitarioNull = false;
				_costo_unitario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_UNITARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_UNITARIONull
		{
			get { return _costo_unitarioNull; }
			set { _costo_unitarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AJUSTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AJUSTADO</c> column value.</value>
		public string AJUSTADO
		{
			get { return _ajustado; }
			set { _ajustado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INVENTARIO_CANT_SISTEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INVENTARIO_CANT_SISTEMA</c> column value.</value>
		public decimal INVENTARIO_CANT_SISTEMA
		{
			get
			{
				if(IsINVENTARIO_CANT_SISTEMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inventario_cant_sistema;
			}
			set
			{
				_inventario_cant_sistemaNull = false;
				_inventario_cant_sistema = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INVENTARIO_CANT_SISTEMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINVENTARIO_CANT_SISTEMANull
		{
			get { return _inventario_cant_sistemaNull; }
			set { _inventario_cant_sistemaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INVENTARIO_CANT_ENCONTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INVENTARIO_CANT_ENCONTRADA</c> column value.</value>
		public decimal INVENTARIO_CANT_ENCONTRADA
		{
			get
			{
				if(IsINVENTARIO_CANT_ENCONTRADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inventario_cant_encontrada;
			}
			set
			{
				_inventario_cant_encontradaNull = false;
				_inventario_cant_encontrada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INVENTARIO_CANT_ENCONTRADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINVENTARIO_CANT_ENCONTRADANull
		{
			get { return _inventario_cant_encontradaNull; }
			set { _inventario_cant_encontradaNull = value; }
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
			dynStr.Append("@CBA@STOCK_AJUSTE_ID=");
			dynStr.Append(IsSTOCK_AJUSTE_IDNull ? (object)"<NULL>" : STOCK_AJUSTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESTINO_ID=");
			dynStr.Append(UNIDAD_MEDIDA_DESTINO_ID);
			dynStr.Append("@CBA@CANTIDAD_DESTINO=");
			dynStr.Append(IsCANTIDAD_DESTINONull ? (object)"<NULL>" : CANTIDAD_DESTINO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ORIGEN_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ORIGEN_ID);
			dynStr.Append("@CBA@CANTIDAD_ORIGEN=");
			dynStr.Append(IsCANTIDAD_ORIGENNull ? (object)"<NULL>" : CANTIDAD_ORIGEN);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@COSTO_TOTAL=");
			dynStr.Append(IsCOSTO_TOTALNull ? (object)"<NULL>" : COSTO_TOTAL);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(IsCOSTO_UNITARIONull ? (object)"<NULL>" : COSTO_UNITARIO);
			dynStr.Append("@CBA@AJUSTADO=");
			dynStr.Append(AJUSTADO);
			dynStr.Append("@CBA@INVENTARIO_CANT_SISTEMA=");
			dynStr.Append(IsINVENTARIO_CANT_SISTEMANull ? (object)"<NULL>" : INVENTARIO_CANT_SISTEMA);
			dynStr.Append("@CBA@INVENTARIO_CANT_ENCONTRADA=");
			dynStr.Append(IsINVENTARIO_CANT_ENCONTRADANull ? (object)"<NULL>" : INVENTARIO_CANT_ENCONTRADA);
			return dynStr.ToString();
		}
	} // End of STOCK_AJUSTE_DETALLERow_Base class
} // End of namespace
