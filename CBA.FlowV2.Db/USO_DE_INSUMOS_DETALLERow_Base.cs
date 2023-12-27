// <fileinfo name="USO_DE_INSUMOS_DETALLERow_Base.cs">
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
	/// The base class for <see cref="USO_DE_INSUMOS_DETALLERow"/> that 
	/// represents a record in the <c>USO_DE_INSUMOS_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USO_DE_INSUMOS_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USO_DE_INSUMOS_DETALLERow_Base
	{
		private decimal _id;
		private decimal _articulo_lote_id;
		private decimal _cantidad_embalada;
		private decimal _cantidad_por_caja_destino;
		private decimal _cantidad_unidad_destino;
		private decimal _cantidad_unitaria_total_dest;
		private decimal _costo_id;
		private bool _costo_idNull = true;
		private decimal _costo_total;
		private decimal _costo_moneda_id;
		private decimal _costo_moneda_cotizacion;
		private string _observacion;
		private string _unidad_destino_id;
		private decimal _factor_de_conversion;
		private decimal _cantidad_unitaria_total_origen;
		private decimal _uso_de_insumo_id;
		private decimal _cantidad_por_caja_origen;
		private decimal _cantidad_unidad_origen;
		private string _unidad_origen_id;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _valor_medicion;
		private bool _valor_medicionNull = true;
		private decimal _sucursal_destino_id;
		private bool _sucursal_destino_idNull = true;
		private decimal _proveedor_asignado_id;
		private bool _proveedor_asignado_idNull = true;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _ordenes_servicio_detalles_id;
		private bool _ordenes_servicio_detalles_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="USO_DE_INSUMOS_DETALLERow_Base"/> class.
		/// </summary>
		public USO_DE_INSUMOS_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USO_DE_INSUMOS_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_LOTE_ID != original.ARTICULO_LOTE_ID) return true;
			if (this.CANTIDAD_EMBALADA != original.CANTIDAD_EMBALADA) return true;
			if (this.CANTIDAD_POR_CAJA_DESTINO != original.CANTIDAD_POR_CAJA_DESTINO) return true;
			if (this.CANTIDAD_UNIDAD_DESTINO != original.CANTIDAD_UNIDAD_DESTINO) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL_DEST != original.CANTIDAD_UNITARIA_TOTAL_DEST) return true;
			if (this.IsCOSTO_IDNull != original.IsCOSTO_IDNull) return true;
			if (!this.IsCOSTO_IDNull && !original.IsCOSTO_IDNull)
				if (this.COSTO_ID != original.COSTO_ID) return true;
			if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.COSTO_MONEDA_COTIZACION != original.COSTO_MONEDA_COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.UNIDAD_DESTINO_ID != original.UNIDAD_DESTINO_ID) return true;
			if (this.FACTOR_DE_CONVERSION != original.FACTOR_DE_CONVERSION) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL_ORIGEN != original.CANTIDAD_UNITARIA_TOTAL_ORIGEN) return true;
			if (this.USO_DE_INSUMO_ID != original.USO_DE_INSUMO_ID) return true;
			if (this.CANTIDAD_POR_CAJA_ORIGEN != original.CANTIDAD_POR_CAJA_ORIGEN) return true;
			if (this.CANTIDAD_UNIDAD_ORIGEN != original.CANTIDAD_UNIDAD_ORIGEN) return true;
			if (this.UNIDAD_ORIGEN_ID != original.UNIDAD_ORIGEN_ID) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsVALOR_MEDICIONNull != original.IsVALOR_MEDICIONNull) return true;
			if (!this.IsVALOR_MEDICIONNull && !original.IsVALOR_MEDICIONNull)
				if (this.VALOR_MEDICION != original.VALOR_MEDICION) return true;
			if (this.IsSUCURSAL_DESTINO_IDNull != original.IsSUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_IDNull && !original.IsSUCURSAL_DESTINO_IDNull)
				if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.IsPROVEEDOR_ASIGNADO_IDNull != original.IsPROVEEDOR_ASIGNADO_IDNull) return true;
			if (!this.IsPROVEEDOR_ASIGNADO_IDNull && !original.IsPROVEEDOR_ASIGNADO_IDNull)
				if (this.PROVEEDOR_ASIGNADO_ID != original.PROVEEDOR_ASIGNADO_ID) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.IsORDENES_SERVICIO_DETALLES_IDNull != original.IsORDENES_SERVICIO_DETALLES_IDNull) return true;
			if (!this.IsORDENES_SERVICIO_DETALLES_IDNull && !original.IsORDENES_SERVICIO_DETALLES_IDNull)
				if (this.ORDENES_SERVICIO_DETALLES_ID != original.ORDENES_SERVICIO_DETALLES_ID) return true;
			
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
		/// Gets or sets the <c>ARTICULO_LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_LOTE_ID</c> column value.</value>
		public decimal ARTICULO_LOTE_ID
		{
			get { return _articulo_lote_id; }
			set { _articulo_lote_id = value; }
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
		/// Gets or sets the <c>USO_DE_INSUMO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USO_DE_INSUMO_ID</c> column value.</value>
		public decimal USO_DE_INSUMO_ID
		{
			get { return _uso_de_insumo_id; }
			set { _uso_de_insumo_id = value; }
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
		/// Gets or sets the <c>UNIDAD_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_ORIGEN_ID</c> column value.</value>
		public string UNIDAD_ORIGEN_ID
		{
			get { return _unidad_origen_id; }
			set { _unidad_origen_id = value; }
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
		/// Gets or sets the <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</value>
		public decimal ORDENES_SERVICIO_DETALLES_ID
		{
			get
			{
				if(IsORDENES_SERVICIO_DETALLES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ordenes_servicio_detalles_id;
			}
			set
			{
				_ordenes_servicio_detalles_idNull = false;
				_ordenes_servicio_detalles_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDENES_SERVICIO_DETALLES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENES_SERVICIO_DETALLES_IDNull
		{
			get { return _ordenes_servicio_detalles_idNull; }
			set { _ordenes_servicio_detalles_idNull = value; }
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
			dynStr.Append("@CBA@ARTICULO_LOTE_ID=");
			dynStr.Append(ARTICULO_LOTE_ID);
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
			dynStr.Append("@CBA@COSTO_MONEDA_COTIZACION=");
			dynStr.Append(COSTO_MONEDA_COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@UNIDAD_DESTINO_ID=");
			dynStr.Append(UNIDAD_DESTINO_ID);
			dynStr.Append("@CBA@FACTOR_DE_CONVERSION=");
			dynStr.Append(FACTOR_DE_CONVERSION);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_ORIGEN=");
			dynStr.Append(CANTIDAD_UNITARIA_TOTAL_ORIGEN);
			dynStr.Append("@CBA@USO_DE_INSUMO_ID=");
			dynStr.Append(USO_DE_INSUMO_ID);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA_ORIGEN=");
			dynStr.Append(CANTIDAD_POR_CAJA_ORIGEN);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_ORIGEN=");
			dynStr.Append(CANTIDAD_UNIDAD_ORIGEN);
			dynStr.Append("@CBA@UNIDAD_ORIGEN_ID=");
			dynStr.Append(UNIDAD_ORIGEN_ID);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@VALOR_MEDICION=");
			dynStr.Append(IsVALOR_MEDICIONNull ? (object)"<NULL>" : VALOR_MEDICION);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(IsSUCURSAL_DESTINO_IDNull ? (object)"<NULL>" : SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@PROVEEDOR_ASIGNADO_ID=");
			dynStr.Append(IsPROVEEDOR_ASIGNADO_IDNull ? (object)"<NULL>" : PROVEEDOR_ASIGNADO_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@ORDENES_SERVICIO_DETALLES_ID=");
			dynStr.Append(IsORDENES_SERVICIO_DETALLES_IDNull ? (object)"<NULL>" : ORDENES_SERVICIO_DETALLES_ID);
			return dynStr.ToString();
		}
	} // End of USO_DE_INSUMOS_DETALLERow_Base class
} // End of namespace
