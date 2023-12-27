// <fileinfo name="STOCK_AJUSTE_DET_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="STOCK_AJUSTE_DET_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>STOCK_AJUSTE_DET_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_AJUSTE_DET_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_AJUSTE_DET_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _stock_ajuste_id;
		private decimal _caso_id;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _descripcion_interna;
		private string _articulo_codigo;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _lote;
		private string _unidad_medida_destino_id;
		private decimal _cantidad_destino;
		private bool _cantidad_destinoNull = true;
		private string _unidad_medida_destino_nombre;
		private string _unidad_medida_origen_id;
		private decimal _cantidad_origen;
		private bool _cantidad_origenNull = true;
		private string _unidad_medida_origen_nombre;
		private decimal _factor_conversion;
		private bool _factor_conversionNull = true;
		private string _observacion;
		private decimal _costo_total;
		private bool _costo_totalNull = true;
		private decimal _costo_unitario;
		private bool _costo_unitarioNull = true;
		private decimal _inventario_cant_sistema;
		private bool _inventario_cant_sistemaNull = true;
		private decimal _inventario_cant_encontrada;
		private bool _inventario_cant_encontradaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_AJUSTE_DET_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public STOCK_AJUSTE_DET_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_AJUSTE_DET_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.STOCK_AJUSTE_ID != original.STOCK_AJUSTE_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsARTICULO_FAMILIA_IDNull != original.IsARTICULO_FAMILIA_IDNull) return true;
			if (!this.IsARTICULO_FAMILIA_IDNull && !original.IsARTICULO_FAMILIA_IDNull)
				if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.IsARTICULO_GRUPO_IDNull != original.IsARTICULO_GRUPO_IDNull) return true;
			if (!this.IsARTICULO_GRUPO_IDNull && !original.IsARTICULO_GRUPO_IDNull)
				if (this.ARTICULO_GRUPO_ID != original.ARTICULO_GRUPO_ID) return true;
			if (this.IsARTICULO_SUBGRUPO_IDNull != original.IsARTICULO_SUBGRUPO_IDNull) return true;
			if (!this.IsARTICULO_SUBGRUPO_IDNull && !original.IsARTICULO_SUBGRUPO_IDNull)
				if (this.ARTICULO_SUBGRUPO_ID != original.ARTICULO_SUBGRUPO_ID) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.UNIDAD_MEDIDA_DESTINO_ID != original.UNIDAD_MEDIDA_DESTINO_ID) return true;
			if (this.IsCANTIDAD_DESTINONull != original.IsCANTIDAD_DESTINONull) return true;
			if (!this.IsCANTIDAD_DESTINONull && !original.IsCANTIDAD_DESTINONull)
				if (this.CANTIDAD_DESTINO != original.CANTIDAD_DESTINO) return true;
			if (this.UNIDAD_MEDIDA_DESTINO_NOMBRE != original.UNIDAD_MEDIDA_DESTINO_NOMBRE) return true;
			if (this.UNIDAD_MEDIDA_ORIGEN_ID != original.UNIDAD_MEDIDA_ORIGEN_ID) return true;
			if (this.IsCANTIDAD_ORIGENNull != original.IsCANTIDAD_ORIGENNull) return true;
			if (!this.IsCANTIDAD_ORIGENNull && !original.IsCANTIDAD_ORIGENNull)
				if (this.CANTIDAD_ORIGEN != original.CANTIDAD_ORIGEN) return true;
			if (this.UNIDAD_MEDIDA_ORIGEN_NOMBRE != original.UNIDAD_MEDIDA_ORIGEN_NOMBRE) return true;
			if (this.IsFACTOR_CONVERSIONNull != original.IsFACTOR_CONVERSIONNull) return true;
			if (!this.IsFACTOR_CONVERSIONNull && !original.IsFACTOR_CONVERSIONNull)
				if (this.FACTOR_CONVERSION != original.FACTOR_CONVERSION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCOSTO_TOTALNull != original.IsCOSTO_TOTALNull) return true;
			if (!this.IsCOSTO_TOTALNull && !original.IsCOSTO_TOTALNull)
				if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			if (this.IsCOSTO_UNITARIONull != original.IsCOSTO_UNITARIONull) return true;
			if (!this.IsCOSTO_UNITARIONull && !original.IsCOSTO_UNITARIONull)
				if (this.COSTO_UNITARIO != original.COSTO_UNITARIO) return true;
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
		/// </summary>
		/// <value>The <c>STOCK_AJUSTE_ID</c> column value.</value>
		public decimal STOCK_AJUSTE_ID
		{
			get { return _stock_ajuste_id; }
			set { _stock_ajuste_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
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
		/// Gets or sets the <c>ARTICULO_FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULO_FAMILIA_ID
		{
			get
			{
				if(IsARTICULO_FAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_familia_id;
			}
			set
			{
				_articulo_familia_idNull = false;
				_articulo_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_FAMILIA_IDNull
		{
			get { return _articulo_familia_idNull; }
			set { _articulo_familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_ID</c> column value.</value>
		public decimal ARTICULO_GRUPO_ID
		{
			get
			{
				if(IsARTICULO_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_grupo_id;
			}
			set
			{
				_articulo_grupo_idNull = false;
				_articulo_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_GRUPO_IDNull
		{
			get { return _articulo_grupo_idNull; }
			set { _articulo_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_ID</c> column value.</value>
		public decimal ARTICULO_SUBGRUPO_ID
		{
			get
			{
				if(IsARTICULO_SUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_subgrupo_id;
			}
			set
			{
				_articulo_subgrupo_idNull = false;
				_articulo_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_SUBGRUPO_IDNull
		{
			get { return _articulo_subgrupo_idNull; }
			set { _articulo_subgrupo_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
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
		/// Gets or sets the <c>LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE</c> column value.</value>
		public string LOTE
		{
			get { return _lote; }
			set { _lote = value; }
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
		/// Gets or sets the <c>UNIDAD_MEDIDA_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_DESTINO_NOMBRE</c> column value.</value>
		public string UNIDAD_MEDIDA_DESTINO_NOMBRE
		{
			get { return _unidad_medida_destino_nombre; }
			set { _unidad_medida_destino_nombre = value; }
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
		/// Gets or sets the <c>UNIDAD_MEDIDA_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ORIGEN_NOMBRE</c> column value.</value>
		public string UNIDAD_MEDIDA_ORIGEN_NOMBRE
		{
			get { return _unidad_medida_origen_nombre; }
			set { _unidad_medida_origen_nombre = value; }
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
			dynStr.Append(STOCK_AJUSTE_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESTINO_ID=");
			dynStr.Append(UNIDAD_MEDIDA_DESTINO_ID);
			dynStr.Append("@CBA@CANTIDAD_DESTINO=");
			dynStr.Append(IsCANTIDAD_DESTINONull ? (object)"<NULL>" : CANTIDAD_DESTINO);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESTINO_NOMBRE=");
			dynStr.Append(UNIDAD_MEDIDA_DESTINO_NOMBRE);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ORIGEN_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ORIGEN_ID);
			dynStr.Append("@CBA@CANTIDAD_ORIGEN=");
			dynStr.Append(IsCANTIDAD_ORIGENNull ? (object)"<NULL>" : CANTIDAD_ORIGEN);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ORIGEN_NOMBRE=");
			dynStr.Append(UNIDAD_MEDIDA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@FACTOR_CONVERSION=");
			dynStr.Append(IsFACTOR_CONVERSIONNull ? (object)"<NULL>" : FACTOR_CONVERSION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@COSTO_TOTAL=");
			dynStr.Append(IsCOSTO_TOTALNull ? (object)"<NULL>" : COSTO_TOTAL);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(IsCOSTO_UNITARIONull ? (object)"<NULL>" : COSTO_UNITARIO);
			dynStr.Append("@CBA@INVENTARIO_CANT_SISTEMA=");
			dynStr.Append(IsINVENTARIO_CANT_SISTEMANull ? (object)"<NULL>" : INVENTARIO_CANT_SISTEMA);
			dynStr.Append("@CBA@INVENTARIO_CANT_ENCONTRADA=");
			dynStr.Append(IsINVENTARIO_CANT_ENCONTRADANull ? (object)"<NULL>" : INVENTARIO_CANT_ENCONTRADA);
			return dynStr.ToString();
		}
	} // End of STOCK_AJUSTE_DET_INFO_COMPLETARow_Base class
} // End of namespace
