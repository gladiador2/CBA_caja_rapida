// <fileinfo name="ACTIVOSRow_Base.cs">
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
	/// The base class for <see cref="ACTIVOSRow"/> that 
	/// represents a record in the <c>ACTIVOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ACTIVOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ACTIVOSRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _inmueble_id;
		private bool _inmueble_idNull = true;
		private decimal _vehiculo_id;
		private bool _vehiculo_idNull = true;
		private string _codigo;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _monto_compra;
		private bool _monto_compraNull = true;
		private decimal _moneda_compra_id;
		private bool _moneda_compra_idNull = true;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private string _ingreso_aprobado;
		private string _estado;
		private string _nombre;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private System.DateTime _fecha_compra;
		private bool _fecha_compraNull = true;
		private decimal _tipo_activo_id;
		private decimal _activo_rubro_id;
		private decimal _caso_relacionado_id;
		private bool _caso_relacionado_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOSRow_Base"/> class.
		/// </summary>
		public ACTIVOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ACTIVOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsINMUEBLE_IDNull != original.IsINMUEBLE_IDNull) return true;
			if (!this.IsINMUEBLE_IDNull && !original.IsINMUEBLE_IDNull)
				if (this.INMUEBLE_ID != original.INMUEBLE_ID) return true;
			if (this.IsVEHICULO_IDNull != original.IsVEHICULO_IDNull) return true;
			if (!this.IsVEHICULO_IDNull && !original.IsVEHICULO_IDNull)
				if (this.VEHICULO_ID != original.VEHICULO_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsMONTO_COMPRANull != original.IsMONTO_COMPRANull) return true;
			if (!this.IsMONTO_COMPRANull && !original.IsMONTO_COMPRANull)
				if (this.MONTO_COMPRA != original.MONTO_COMPRA) return true;
			if (this.IsMONEDA_COMPRA_IDNull != original.IsMONEDA_COMPRA_IDNull) return true;
			if (!this.IsMONEDA_COMPRA_IDNull && !original.IsMONEDA_COMPRA_IDNull)
				if (this.MONEDA_COMPRA_ID != original.MONEDA_COMPRA_ID) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.INGRESO_APROBADO != original.INGRESO_APROBADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.IsFECHA_COMPRANull != original.IsFECHA_COMPRANull) return true;
			if (!this.IsFECHA_COMPRANull && !original.IsFECHA_COMPRANull)
				if (this.FECHA_COMPRA != original.FECHA_COMPRA) return true;
			if (this.TIPO_ACTIVO_ID != original.TIPO_ACTIVO_ID) return true;
			if (this.ACTIVO_RUBRO_ID != original.ACTIVO_RUBRO_ID) return true;
			if (this.IsCASO_RELACIONADO_IDNull != original.IsCASO_RELACIONADO_IDNull) return true;
			if (!this.IsCASO_RELACIONADO_IDNull && !original.IsCASO_RELACIONADO_IDNull)
				if (this.CASO_RELACIONADO_ID != original.CASO_RELACIONADO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			
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
		/// Gets or sets the <c>INMUEBLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INMUEBLE_ID</c> column value.</value>
		public decimal INMUEBLE_ID
		{
			get
			{
				if(IsINMUEBLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inmueble_id;
			}
			set
			{
				_inmueble_idNull = false;
				_inmueble_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INMUEBLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINMUEBLE_IDNull
		{
			get { return _inmueble_idNull; }
			set { _inmueble_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VEHICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO_ID</c> column value.</value>
		public decimal VEHICULO_ID
		{
			get
			{
				if(IsVEHICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vehiculo_id;
			}
			set
			{
				_vehiculo_idNull = false;
				_vehiculo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VEHICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVEHICULO_IDNull
		{
			get { return _vehiculo_idNull; }
			set { _vehiculo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMPRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COMPRA</c> column value.</value>
		public decimal MONTO_COMPRA
		{
			get
			{
				if(IsMONTO_COMPRANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_compra;
			}
			set
			{
				_monto_compraNull = false;
				_monto_compra = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COMPRA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COMPRANull
		{
			get { return _monto_compraNull; }
			set { _monto_compraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COMPRA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COMPRA_ID</c> column value.</value>
		public decimal MONEDA_COMPRA_ID
		{
			get
			{
				if(IsMONEDA_COMPRA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_compra_id;
			}
			set
			{
				_moneda_compra_idNull = false;
				_moneda_compra_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_COMPRA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_COMPRA_IDNull
		{
			get { return _moneda_compra_idNull; }
			set { _moneda_compra_idNull = value; }
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
		/// Gets or sets the <c>INGRESO_APROBADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_APROBADO</c> column value.</value>
		public string INGRESO_APROBADO
		{
			get { return _ingreso_aprobado; }
			set { _ingreso_aprobado = value; }
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>FECHA_COMPRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_COMPRA</c> column value.</value>
		public System.DateTime FECHA_COMPRA
		{
			get
			{
				if(IsFECHA_COMPRANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_compra;
			}
			set
			{
				_fecha_compraNull = false;
				_fecha_compra = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_COMPRA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_COMPRANull
		{
			get { return _fecha_compraNull; }
			set { _fecha_compraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ACTIVO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ACTIVO_ID</c> column value.</value>
		public decimal TIPO_ACTIVO_ID
		{
			get { return _tipo_activo_id; }
			set { _tipo_activo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_RUBRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ACTIVO_RUBRO_ID</c> column value.</value>
		public decimal ACTIVO_RUBRO_ID
		{
			get { return _activo_rubro_id; }
			set { _activo_rubro_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_RELACIONADO_ID</c> column value.</value>
		public decimal CASO_RELACIONADO_ID
		{
			get
			{
				if(IsCASO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_relacionado_id;
			}
			set
			{
				_caso_relacionado_idNull = false;
				_caso_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_RELACIONADO_IDNull
		{
			get { return _caso_relacionado_idNull; }
			set { _caso_relacionado_idNull = value; }
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
			dynStr.Append("@CBA@INMUEBLE_ID=");
			dynStr.Append(IsINMUEBLE_IDNull ? (object)"<NULL>" : INMUEBLE_ID);
			dynStr.Append("@CBA@VEHICULO_ID=");
			dynStr.Append(IsVEHICULO_IDNull ? (object)"<NULL>" : VEHICULO_ID);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@MONTO_COMPRA=");
			dynStr.Append(IsMONTO_COMPRANull ? (object)"<NULL>" : MONTO_COMPRA);
			dynStr.Append("@CBA@MONEDA_COMPRA_ID=");
			dynStr.Append(IsMONEDA_COMPRA_IDNull ? (object)"<NULL>" : MONEDA_COMPRA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@INGRESO_APROBADO=");
			dynStr.Append(INGRESO_APROBADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@FECHA_COMPRA=");
			dynStr.Append(IsFECHA_COMPRANull ? (object)"<NULL>" : FECHA_COMPRA);
			dynStr.Append("@CBA@TIPO_ACTIVO_ID=");
			dynStr.Append(TIPO_ACTIVO_ID);
			dynStr.Append("@CBA@ACTIVO_RUBRO_ID=");
			dynStr.Append(ACTIVO_RUBRO_ID);
			dynStr.Append("@CBA@CASO_RELACIONADO_ID=");
			dynStr.Append(IsCASO_RELACIONADO_IDNull ? (object)"<NULL>" : CASO_RELACIONADO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			return dynStr.ToString();
		}
	} // End of ACTIVOSRow_Base class
} // End of namespace
