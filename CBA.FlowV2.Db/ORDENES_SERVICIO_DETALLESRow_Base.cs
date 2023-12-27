// <fileinfo name="ORDENES_SERVICIO_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_DETALLESRow"/> that 
	/// represents a record in the <c>ORDENES_SERVICIO_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERVICIO_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _orden_servicio_id;
		private string _descripcion;
		private decimal _cantidad_horas;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _costo_unitario;
		private bool _costo_unitarioNull = true;
		private decimal _precio;
		private bool _precioNull = true;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _unidad_id;
		private decimal _porcentaje_descuento;
		private bool _porcentaje_descuentoNull = true;
		private decimal _costo_total;
		private bool _costo_totalNull = true;
		private decimal _costo_unitario_descontado;
		private bool _costo_unitario_descontadoNull = true;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private decimal _total_impuesto_monto;
		private bool _total_impuesto_montoNull = true;
		private string _estado_id;
		private decimal _cantidad_horas_serv;
		private bool _cantidad_horas_servNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_DETALLESRow_Base"/> class.
		/// </summary>
		public ORDENES_SERVICIO_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERVICIO_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_SERVICIO_ID != original.ORDEN_SERVICIO_ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CANTIDAD_HORAS != original.CANTIDAD_HORAS) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsCOSTO_UNITARIONull != original.IsCOSTO_UNITARIONull) return true;
			if (!this.IsCOSTO_UNITARIONull && !original.IsCOSTO_UNITARIONull)
				if (this.COSTO_UNITARIO != original.COSTO_UNITARIO) return true;
			if (this.IsPRECIONull != original.IsPRECIONull) return true;
			if (!this.IsPRECIONull && !original.IsPRECIONull)
				if (this.PRECIO != original.PRECIO) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.IsPORCENTAJE_DESCUENTONull != original.IsPORCENTAJE_DESCUENTONull) return true;
			if (!this.IsPORCENTAJE_DESCUENTONull && !original.IsPORCENTAJE_DESCUENTONull)
				if (this.PORCENTAJE_DESCUENTO != original.PORCENTAJE_DESCUENTO) return true;
			if (this.IsCOSTO_TOTALNull != original.IsCOSTO_TOTALNull) return true;
			if (!this.IsCOSTO_TOTALNull && !original.IsCOSTO_TOTALNull)
				if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			if (this.IsCOSTO_UNITARIO_DESCONTADONull != original.IsCOSTO_UNITARIO_DESCONTADONull) return true;
			if (!this.IsCOSTO_UNITARIO_DESCONTADONull && !original.IsCOSTO_UNITARIO_DESCONTADONull)
				if (this.COSTO_UNITARIO_DESCONTADO != original.COSTO_UNITARIO_DESCONTADO) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IsTOTAL_IMPUESTO_MONTONull != original.IsTOTAL_IMPUESTO_MONTONull) return true;
			if (!this.IsTOTAL_IMPUESTO_MONTONull && !original.IsTOTAL_IMPUESTO_MONTONull)
				if (this.TOTAL_IMPUESTO_MONTO != original.TOTAL_IMPUESTO_MONTO) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			if (this.IsCANTIDAD_HORAS_SERVNull != original.IsCANTIDAD_HORAS_SERVNull) return true;
			if (!this.IsCANTIDAD_HORAS_SERVNull && !original.IsCANTIDAD_HORAS_SERVNull)
				if (this.CANTIDAD_HORAS_SERV != original.CANTIDAD_HORAS_SERV) return true;
			
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
		/// Gets or sets the <c>ORDEN_SERVICIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_SERVICIO_ID</c> column value.</value>
		public decimal ORDEN_SERVICIO_ID
		{
			get { return _orden_servicio_id; }
			set { _orden_servicio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_HORAS</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_HORAS</c> column value.</value>
		public decimal CANTIDAD_HORAS
		{
			get { return _cantidad_horas; }
			set { _cantidad_horas = value; }
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
		/// Gets or sets the <c>PRECIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO</c> column value.</value>
		public decimal PRECIO
		{
			get
			{
				if(IsPRECIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio;
			}
			set
			{
				_precioNull = false;
				_precio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIONull
		{
			get { return _precioNull; }
			set { _precioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
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
		/// Gets or sets the <c>PORCENTAJE_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DESCUENTO</c> column value.</value>
		public decimal PORCENTAJE_DESCUENTO
		{
			get
			{
				if(IsPORCENTAJE_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_descuento;
			}
			set
			{
				_porcentaje_descuentoNull = false;
				_porcentaje_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_DESCUENTONull
		{
			get { return _porcentaje_descuentoNull; }
			set { _porcentaje_descuentoNull = value; }
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
		/// Gets or sets the <c>COSTO_UNITARIO_DESCONTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_UNITARIO_DESCONTADO</c> column value.</value>
		public decimal COSTO_UNITARIO_DESCONTADO
		{
			get
			{
				if(IsCOSTO_UNITARIO_DESCONTADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_unitario_descontado;
			}
			set
			{
				_costo_unitario_descontadoNull = false;
				_costo_unitario_descontado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_UNITARIO_DESCONTADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_UNITARIO_DESCONTADONull
		{
			get { return _costo_unitario_descontadoNull; }
			set { _costo_unitario_descontadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get
			{
				if(IsIMPUESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_id;
			}
			set
			{
				_impuesto_idNull = false;
				_impuesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_IDNull
		{
			get { return _impuesto_idNull; }
			set { _impuesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO_MONTO</c> column value.</value>
		public decimal TOTAL_IMPUESTO_MONTO
		{
			get
			{
				if(IsTOTAL_IMPUESTO_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto_monto;
			}
			set
			{
				_total_impuesto_montoNull = false;
				_total_impuesto_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTO_MONTONull
		{
			get { return _total_impuesto_montoNull; }
			set { _total_impuesto_montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ID</c> column value.</value>
		public string ESTADO_ID
		{
			get { return _estado_id; }
			set { _estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_HORAS_SERV</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_HORAS_SERV</c> column value.</value>
		public decimal CANTIDAD_HORAS_SERV
		{
			get
			{
				if(IsCANTIDAD_HORAS_SERVNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_horas_serv;
			}
			set
			{
				_cantidad_horas_servNull = false;
				_cantidad_horas_serv = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_HORAS_SERV"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_HORAS_SERVNull
		{
			get { return _cantidad_horas_servNull; }
			set { _cantidad_horas_servNull = value; }
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
			dynStr.Append("@CBA@ORDEN_SERVICIO_ID=");
			dynStr.Append(ORDEN_SERVICIO_ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD_HORAS=");
			dynStr.Append(CANTIDAD_HORAS);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(IsCOSTO_UNITARIONull ? (object)"<NULL>" : COSTO_UNITARIO);
			dynStr.Append("@CBA@PRECIO=");
			dynStr.Append(IsPRECIONull ? (object)"<NULL>" : PRECIO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@PORCENTAJE_DESCUENTO=");
			dynStr.Append(IsPORCENTAJE_DESCUENTONull ? (object)"<NULL>" : PORCENTAJE_DESCUENTO);
			dynStr.Append("@CBA@COSTO_TOTAL=");
			dynStr.Append(IsCOSTO_TOTALNull ? (object)"<NULL>" : COSTO_TOTAL);
			dynStr.Append("@CBA@COSTO_UNITARIO_DESCONTADO=");
			dynStr.Append(IsCOSTO_UNITARIO_DESCONTADONull ? (object)"<NULL>" : COSTO_UNITARIO_DESCONTADO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@TOTAL_IMPUESTO_MONTO=");
			dynStr.Append(IsTOTAL_IMPUESTO_MONTONull ? (object)"<NULL>" : TOTAL_IMPUESTO_MONTO);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			dynStr.Append("@CBA@CANTIDAD_HORAS_SERV=");
			dynStr.Append(IsCANTIDAD_HORAS_SERVNull ? (object)"<NULL>" : CANTIDAD_HORAS_SERV);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERVICIO_DETALLESRow_Base class
} // End of namespace
