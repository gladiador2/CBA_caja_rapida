// <fileinfo name="ANTICIPOS_PROVEED_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_PROVEED_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ANTICIPOS_PROVEED_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ANTICIPOS_PROVEED_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_PROVEED_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _proveedor_razon_social;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _entidad_id;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidades_decimales;
		private decimal _moneda_cotizacion;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private decimal _total_anticipo;
		private decimal _saldo_por_aplicar;
		private bool _saldo_por_aplicarNull = true;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _devolucion_caso_id;
		private bool _devolucion_caso_idNull = true;
		private decimal _devolucion_flujo_id;
		private bool _devolucion_flujo_idNull = true;
		private string _devolucion_caso_observacion;
		private string _devolucion_flujo_descripcion;
		private decimal _orden_pago_respalda_caso_id;
		private bool _orden_pago_respalda_caso_idNull = true;
		private string _orden_pago_utiliza_caso_id;
		private string _observacion;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _monto_retencion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_PROVEED_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ANTICIPOS_PROVEED_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ANTICIPOS_PROVEED_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDADES_DECIMALES != original.MONEDA_CANTIDADES_DECIMALES) return true;
			if (this.MONEDA_COTIZACION != original.MONEDA_COTIZACION) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.TOTAL_ANTICIPO != original.TOTAL_ANTICIPO) return true;
			if (this.IsSALDO_POR_APLICARNull != original.IsSALDO_POR_APLICARNull) return true;
			if (!this.IsSALDO_POR_APLICARNull && !original.IsSALDO_POR_APLICARNull)
				if (this.SALDO_POR_APLICAR != original.SALDO_POR_APLICAR) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.IsDEVOLUCION_CASO_IDNull != original.IsDEVOLUCION_CASO_IDNull) return true;
			if (!this.IsDEVOLUCION_CASO_IDNull && !original.IsDEVOLUCION_CASO_IDNull)
				if (this.DEVOLUCION_CASO_ID != original.DEVOLUCION_CASO_ID) return true;
			if (this.IsDEVOLUCION_FLUJO_IDNull != original.IsDEVOLUCION_FLUJO_IDNull) return true;
			if (!this.IsDEVOLUCION_FLUJO_IDNull && !original.IsDEVOLUCION_FLUJO_IDNull)
				if (this.DEVOLUCION_FLUJO_ID != original.DEVOLUCION_FLUJO_ID) return true;
			if (this.DEVOLUCION_CASO_OBSERVACION != original.DEVOLUCION_CASO_OBSERVACION) return true;
			if (this.DEVOLUCION_FLUJO_DESCRIPCION != original.DEVOLUCION_FLUJO_DESCRIPCION) return true;
			if (this.IsORDEN_PAGO_RESPALDA_CASO_IDNull != original.IsORDEN_PAGO_RESPALDA_CASO_IDNull) return true;
			if (!this.IsORDEN_PAGO_RESPALDA_CASO_IDNull && !original.IsORDEN_PAGO_RESPALDA_CASO_IDNull)
				if (this.ORDEN_PAGO_RESPALDA_CASO_ID != original.ORDEN_PAGO_RESPALDA_CASO_ID) return true;
			if (this.ORDEN_PAGO_UTILIZA_CASO_ID != original.ORDEN_PAGO_UTILIZA_CASO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.MONTO_RETENCION != original.MONTO_RETENCION) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>PROVEEDOR_RAZON_SOCIAL</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_RAZON_SOCIAL
		{
			get { return _proveedor_razon_social; }
			set { _proveedor_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>MONEDA_CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDADES_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDADES_DECIMALES
		{
			get { return _moneda_cantidades_decimales; }
			set { _moneda_cantidades_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_COTIZACION</c> column value.</value>
		public decimal MONEDA_COTIZACION
		{
			get { return _moneda_cotizacion; }
			set { _moneda_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>TOTAL_ANTICIPO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_ANTICIPO</c> column value.</value>
		public decimal TOTAL_ANTICIPO
		{
			get { return _total_anticipo; }
			set { _total_anticipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_POR_APLICAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_POR_APLICAR</c> column value.</value>
		public decimal SALDO_POR_APLICAR
		{
			get
			{
				if(IsSALDO_POR_APLICARNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_por_aplicar;
			}
			set
			{
				_saldo_por_aplicarNull = false;
				_saldo_por_aplicar = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_POR_APLICAR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_POR_APLICARNull
		{
			get { return _saldo_por_aplicarNull; }
			set { _saldo_por_aplicarNull = value; }
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
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVOLUCION_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEVOLUCION_CASO_ID</c> column value.</value>
		public decimal DEVOLUCION_CASO_ID
		{
			get
			{
				if(IsDEVOLUCION_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _devolucion_caso_id;
			}
			set
			{
				_devolucion_caso_idNull = false;
				_devolucion_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEVOLUCION_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEVOLUCION_CASO_IDNull
		{
			get { return _devolucion_caso_idNull; }
			set { _devolucion_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVOLUCION_FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEVOLUCION_FLUJO_ID</c> column value.</value>
		public decimal DEVOLUCION_FLUJO_ID
		{
			get
			{
				if(IsDEVOLUCION_FLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _devolucion_flujo_id;
			}
			set
			{
				_devolucion_flujo_idNull = false;
				_devolucion_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEVOLUCION_FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEVOLUCION_FLUJO_IDNull
		{
			get { return _devolucion_flujo_idNull; }
			set { _devolucion_flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVOLUCION_CASO_OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEVOLUCION_CASO_OBSERVACION</c> column value.</value>
		public string DEVOLUCION_CASO_OBSERVACION
		{
			get { return _devolucion_caso_observacion; }
			set { _devolucion_caso_observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEVOLUCION_FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEVOLUCION_FLUJO_DESCRIPCION</c> column value.</value>
		public string DEVOLUCION_FLUJO_DESCRIPCION
		{
			get { return _devolucion_flujo_descripcion; }
			set { _devolucion_flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_RESPALDA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_RESPALDA_CASO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_RESPALDA_CASO_ID
		{
			get
			{
				if(IsORDEN_PAGO_RESPALDA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_respalda_caso_id;
			}
			set
			{
				_orden_pago_respalda_caso_idNull = false;
				_orden_pago_respalda_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_RESPALDA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_RESPALDA_CASO_IDNull
		{
			get { return _orden_pago_respalda_caso_idNull; }
			set { _orden_pago_respalda_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_UTILIZA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_UTILIZA_CASO_ID</c> column value.</value>
		public string ORDEN_PAGO_UTILIZA_CASO_ID
		{
			get { return _orden_pago_utiliza_caso_id; }
			set { _orden_pago_utiliza_caso_id = value; }
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
		/// Gets or sets the <c>MONTO_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_RETENCION</c> column value.</value>
		public decimal MONTO_RETENCION
		{
			get { return _monto_retencion; }
			set { _monto_retencion = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDADES_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@MONEDA_COTIZACION=");
			dynStr.Append(MONEDA_COTIZACION);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@TOTAL_ANTICIPO=");
			dynStr.Append(TOTAL_ANTICIPO);
			dynStr.Append("@CBA@SALDO_POR_APLICAR=");
			dynStr.Append(IsSALDO_POR_APLICARNull ? (object)"<NULL>" : SALDO_POR_APLICAR);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@DEVOLUCION_CASO_ID=");
			dynStr.Append(IsDEVOLUCION_CASO_IDNull ? (object)"<NULL>" : DEVOLUCION_CASO_ID);
			dynStr.Append("@CBA@DEVOLUCION_FLUJO_ID=");
			dynStr.Append(IsDEVOLUCION_FLUJO_IDNull ? (object)"<NULL>" : DEVOLUCION_FLUJO_ID);
			dynStr.Append("@CBA@DEVOLUCION_CASO_OBSERVACION=");
			dynStr.Append(DEVOLUCION_CASO_OBSERVACION);
			dynStr.Append("@CBA@DEVOLUCION_FLUJO_DESCRIPCION=");
			dynStr.Append(DEVOLUCION_FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@ORDEN_PAGO_RESPALDA_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_RESPALDA_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_RESPALDA_CASO_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_UTILIZA_CASO_ID=");
			dynStr.Append(ORDEN_PAGO_UTILIZA_CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@MONTO_RETENCION=");
			dynStr.Append(MONTO_RETENCION);
			return dynStr.ToString();
		}
	} // End of ANTICIPOS_PROVEED_INFO_COMPLRow_Base class
} // End of namespace
