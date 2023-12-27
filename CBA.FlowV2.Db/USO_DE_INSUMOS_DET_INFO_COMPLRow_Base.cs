// <fileinfo name="USO_DE_INSUMOS_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>USO_DE_INSUMOS_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USO_DE_INSUMOS_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _uso_de_insumo_id;
		private decimal _articulo_lote_id;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _articulo_descripcion;
		private string _articulo_codigo;
		private string _articulo_lote_descripcion;
		private decimal _cantidad_embalada;
		private decimal _cantidad_por_caja_destino;
		private decimal _cantidad_unidad_destino;
		private decimal _cantidad_unitaria_total_dest;
		private decimal _costo_id;
		private bool _costo_idNull = true;
		private decimal _costo_total;
		private decimal _costo_moneda_id;
		private string _costo_moneda_nombre;
		private string _costo_moneda_simbolo;
		private decimal _costo_moneda_cotizacion;
		private string _observacion;
		private string _unidad_destino_id;
		private string _unidad_destino_descripcion;
		private decimal _factor_de_conversion;
		private decimal _cantidad_unitaria_total_origen;
		private decimal _cantidad_por_caja_origen;
		private decimal _cantidad_unidad_origen;
		private decimal _valor_medicion;
		private bool _valor_medicionNull = true;
		private string _unidad_origen_id;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private string _unidad_origen_descripcion;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private string _activo_codigo;
		private decimal _sucursal_destino_id;
		private bool _sucursal_destino_idNull = true;
		private string _sucursa_destino_nombre;
		private decimal _proveedor_asignado_id;
		private bool _proveedor_asignado_idNull = true;
		private string _proveedor_asig_razon_social;
		private string _proveedor_asignado_codigo;

		/// <summary>
		/// Initializes a new instance of the <see cref="USO_DE_INSUMOS_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public USO_DE_INSUMOS_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USO_DE_INSUMOS_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.USO_DE_INSUMO_ID != original.USO_DE_INSUMO_ID) return true;
			if (this.ARTICULO_LOTE_ID != original.ARTICULO_LOTE_ID) return true;
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
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_LOTE_DESCRIPCION != original.ARTICULO_LOTE_DESCRIPCION) return true;
			if (this.CANTIDAD_EMBALADA != original.CANTIDAD_EMBALADA) return true;
			if (this.CANTIDAD_POR_CAJA_DESTINO != original.CANTIDAD_POR_CAJA_DESTINO) return true;
			if (this.CANTIDAD_UNIDAD_DESTINO != original.CANTIDAD_UNIDAD_DESTINO) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL_DEST != original.CANTIDAD_UNITARIA_TOTAL_DEST) return true;
			if (this.IsCOSTO_IDNull != original.IsCOSTO_IDNull) return true;
			if (!this.IsCOSTO_IDNull && !original.IsCOSTO_IDNull)
				if (this.COSTO_ID != original.COSTO_ID) return true;
			if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.COSTO_MONEDA_NOMBRE != original.COSTO_MONEDA_NOMBRE) return true;
			if (this.COSTO_MONEDA_SIMBOLO != original.COSTO_MONEDA_SIMBOLO) return true;
			if (this.COSTO_MONEDA_COTIZACION != original.COSTO_MONEDA_COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.UNIDAD_DESTINO_ID != original.UNIDAD_DESTINO_ID) return true;
			if (this.UNIDAD_DESTINO_DESCRIPCION != original.UNIDAD_DESTINO_DESCRIPCION) return true;
			if (this.FACTOR_DE_CONVERSION != original.FACTOR_DE_CONVERSION) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL_ORIGEN != original.CANTIDAD_UNITARIA_TOTAL_ORIGEN) return true;
			if (this.CANTIDAD_POR_CAJA_ORIGEN != original.CANTIDAD_POR_CAJA_ORIGEN) return true;
			if (this.CANTIDAD_UNIDAD_ORIGEN != original.CANTIDAD_UNIDAD_ORIGEN) return true;
			if (this.IsVALOR_MEDICIONNull != original.IsVALOR_MEDICIONNull) return true;
			if (!this.IsVALOR_MEDICIONNull && !original.IsVALOR_MEDICIONNull)
				if (this.VALOR_MEDICION != original.VALOR_MEDICION) return true;
			if (this.UNIDAD_ORIGEN_ID != original.UNIDAD_ORIGEN_ID) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.UNIDAD_ORIGEN_DESCRIPCION != original.UNIDAD_ORIGEN_DESCRIPCION) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			if (this.IsSUCURSAL_DESTINO_IDNull != original.IsSUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_IDNull && !original.IsSUCURSAL_DESTINO_IDNull)
				if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.SUCURSA_DESTINO_NOMBRE != original.SUCURSA_DESTINO_NOMBRE) return true;
			if (this.IsPROVEEDOR_ASIGNADO_IDNull != original.IsPROVEEDOR_ASIGNADO_IDNull) return true;
			if (!this.IsPROVEEDOR_ASIGNADO_IDNull && !original.IsPROVEEDOR_ASIGNADO_IDNull)
				if (this.PROVEEDOR_ASIGNADO_ID != original.PROVEEDOR_ASIGNADO_ID) return true;
			if (this.PROVEEDOR_ASIG_RAZON_SOCIAL != original.PROVEEDOR_ASIG_RAZON_SOCIAL) return true;
			if (this.PROVEEDOR_ASIGNADO_CODIGO != original.PROVEEDOR_ASIGNADO_CODIGO) return true;
			
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
		/// Gets or sets the <c>USO_DE_INSUMO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USO_DE_INSUMO_ID</c> column value.</value>
		public decimal USO_DE_INSUMO_ID
		{
			get { return _uso_de_insumo_id; }
			set { _uso_de_insumo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_LOTE_ID</c> column value.</value>
		public decimal ARTICULO_LOTE_ID
		{
			get { return _articulo_lote_id; }
			set { _articulo_lote_id = value; }
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
		/// Gets or sets the <c>ARTICULO_LOTE_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_LOTE_DESCRIPCION</c> column value.</value>
		public string ARTICULO_LOTE_DESCRIPCION
		{
			get { return _articulo_lote_descripcion; }
			set { _articulo_lote_descripcion = value; }
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
		/// Gets or sets the <c>CANTIDAD_POR_CAJA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA_DESTINO</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA_DESTINO
		{
			get { return _cantidad_por_caja_destino; }
			set { _cantidad_por_caja_destino = value; }
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
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL_DEST</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL_DEST</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL_DEST
		{
			get { return _cantidad_unitaria_total_dest; }
			set { _cantidad_unitaria_total_dest = value; }
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
		/// Gets or sets the <c>COSTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_TOTAL</c> column value.</value>
		public decimal COSTO_TOTAL
		{
			get { return _costo_total; }
			set { _costo_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ID
		{
			get { return _costo_moneda_id; }
			set { _costo_moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_NOMBRE</c> column value.</value>
		public string COSTO_MONEDA_NOMBRE
		{
			get { return _costo_moneda_nombre; }
			set { _costo_moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_SIMBOLO</c> column value.</value>
		public string COSTO_MONEDA_SIMBOLO
		{
			get { return _costo_moneda_simbolo; }
			set { _costo_moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_COTIZACION</c> column value.</value>
		public decimal COSTO_MONEDA_COTIZACION
		{
			get { return _costo_moneda_cotizacion; }
			set { _costo_moneda_cotizacion = value; }
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
		/// Gets or sets the <c>UNIDAD_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO_ID</c> column value.</value>
		public string UNIDAD_DESTINO_ID
		{
			get { return _unidad_destino_id; }
			set { _unidad_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESTINO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_DESTINO_DESCRIPCION</c> column value.</value>
		public string UNIDAD_DESTINO_DESCRIPCION
		{
			get { return _unidad_destino_descripcion; }
			set { _unidad_destino_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTOR_DE_CONVERSION</c> column value.
		/// </summary>
		/// <value>The <c>FACTOR_DE_CONVERSION</c> column value.</value>
		public decimal FACTOR_DE_CONVERSION
		{
			get { return _factor_de_conversion; }
			set { _factor_de_conversion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL_ORIGEN
		{
			get { return _cantidad_unitaria_total_origen; }
			set { _cantidad_unitaria_total_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_POR_CAJA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA_ORIGEN
		{
			get { return _cantidad_por_caja_origen; }
			set { _cantidad_por_caja_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNIDAD_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNIDAD_ORIGEN</c> column value.</value>
		public decimal CANTIDAD_UNIDAD_ORIGEN
		{
			get { return _cantidad_unidad_origen; }
			set { _cantidad_unidad_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_MEDICION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_MEDICION</c> column value.</value>
		public decimal VALOR_MEDICION
		{
			get
			{
				if(IsVALOR_MEDICIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_medicion;
			}
			set
			{
				_valor_medicionNull = false;
				_valor_medicion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_MEDICION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_MEDICIONNull
		{
			get { return _valor_medicionNull; }
			set { _valor_medicionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_ORIGEN_ID</c> column value.</value>
		public string UNIDAD_ORIGEN_ID
		{
			get { return _unidad_origen_id; }
			set { _unidad_origen_id = value; }
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
		/// Gets or sets the <c>UNIDAD_ORIGEN_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ORIGEN_DESCRIPCION</c> column value.</value>
		public string UNIDAD_ORIGEN_DESCRIPCION
		{
			get { return _unidad_origen_descripcion; }
			set { _unidad_origen_descripcion = value; }
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
		/// Gets or sets the <c>ACTIVO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_CODIGO</c> column value.</value>
		public string ACTIVO_CODIGO
		{
			get { return _activo_codigo; }
			set { _activo_codigo = value; }
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
		/// Gets or sets the <c>SUCURSA_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSA_DESTINO_NOMBRE</c> column value.</value>
		public string SUCURSA_DESTINO_NOMBRE
		{
			get { return _sucursa_destino_nombre; }
			set { _sucursa_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ASIGNADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</value>
		public decimal PROVEEDOR_ASIGNADO_ID
		{
			get
			{
				if(IsPROVEEDOR_ASIGNADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_asignado_id;
			}
			set
			{
				_proveedor_asignado_idNull = false;
				_proveedor_asignado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ASIGNADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_ASIGNADO_IDNull
		{
			get { return _proveedor_asignado_idNull; }
			set { _proveedor_asignado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ASIG_RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ASIG_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_ASIG_RAZON_SOCIAL
		{
			get { return _proveedor_asig_razon_social; }
			set { _proveedor_asig_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ASIGNADO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ASIGNADO_CODIGO</c> column value.</value>
		public string PROVEEDOR_ASIGNADO_CODIGO
		{
			get { return _proveedor_asignado_codigo; }
			set { _proveedor_asignado_codigo = value; }
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
			dynStr.Append("@CBA@USO_DE_INSUMO_ID=");
			dynStr.Append(USO_DE_INSUMO_ID);
			dynStr.Append("@CBA@ARTICULO_LOTE_ID=");
			dynStr.Append(ARTICULO_LOTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_LOTE_DESCRIPCION=");
			dynStr.Append(ARTICULO_LOTE_DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD_EMBALADA=");
			dynStr.Append(CANTIDAD_EMBALADA);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_DESTINO=");
			dynStr.Append(CANTIDAD_POR_CAJA_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_DESTINO=");
			dynStr.Append(CANTIDAD_UNIDAD_DESTINO);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_DEST=");
			dynStr.Append(CANTIDAD_UNITARIA_TOTAL_DEST);
			dynStr.Append("@CBA@COSTO_ID=");
			dynStr.Append(IsCOSTO_IDNull ? (object)"<NULL>" : COSTO_ID);
			dynStr.Append("@CBA@COSTO_TOTAL=");
			dynStr.Append(COSTO_TOTAL);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_MONEDA_NOMBRE=");
			dynStr.Append(COSTO_MONEDA_NOMBRE);
			dynStr.Append("@CBA@COSTO_MONEDA_SIMBOLO=");
			dynStr.Append(COSTO_MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COSTO_MONEDA_COTIZACION=");
			dynStr.Append(COSTO_MONEDA_COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@UNIDAD_DESTINO_ID=");
			dynStr.Append(UNIDAD_DESTINO_ID);
			dynStr.Append("@CBA@UNIDAD_DESTINO_DESCRIPCION=");
			dynStr.Append(UNIDAD_DESTINO_DESCRIPCION);
			dynStr.Append("@CBA@FACTOR_DE_CONVERSION=");
			dynStr.Append(FACTOR_DE_CONVERSION);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_ORIGEN=");
			dynStr.Append(CANTIDAD_UNITARIA_TOTAL_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_ORIGEN=");
			dynStr.Append(CANTIDAD_POR_CAJA_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_ORIGEN=");
			dynStr.Append(CANTIDAD_UNIDAD_ORIGEN);
			dynStr.Append("@CBA@VALOR_MEDICION=");
			dynStr.Append(IsVALOR_MEDICIONNull ? (object)"<NULL>" : VALOR_MEDICION);
			dynStr.Append("@CBA@UNIDAD_ORIGEN_ID=");
			dynStr.Append(UNIDAD_ORIGEN_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@UNIDAD_ORIGEN_DESCRIPCION=");
			dynStr.Append(UNIDAD_ORIGEN_DESCRIPCION);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(IsSUCURSAL_DESTINO_IDNull ? (object)"<NULL>" : SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@SUCURSA_DESTINO_NOMBRE=");
			dynStr.Append(SUCURSA_DESTINO_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_ASIGNADO_ID=");
			dynStr.Append(IsPROVEEDOR_ASIGNADO_IDNull ? (object)"<NULL>" : PROVEEDOR_ASIGNADO_ID);
			dynStr.Append("@CBA@PROVEEDOR_ASIG_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_ASIG_RAZON_SOCIAL);
			dynStr.Append("@CBA@PROVEEDOR_ASIGNADO_CODIGO=");
			dynStr.Append(PROVEEDOR_ASIGNADO_CODIGO);
			return dynStr.ToString();
		}
	} // End of USO_DE_INSUMOS_DET_INFO_COMPLRow_Base class
} // End of namespace
