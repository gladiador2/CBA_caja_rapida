// <fileinfo name="TRAMITES_ACTIVIDADESRow_Base.cs">
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
	/// The base class for <see cref="TRAMITES_ACTIVIDADESRow"/> that 
	/// represents a record in the <c>TRAMITES_ACTIVIDADES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_ACTIVIDADESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_ACTIVIDADESRow_Base
	{
		private decimal _id;
		private decimal _tramite_id;
		private string _descripcion;
		private decimal _cantidad_horas;
		private bool _cantidad_horasNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
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
		private decimal _total_impuesto_mont;
		private bool _total_impuesto_montNull = true;
		private string _finalizado;
		private decimal _cantidad_unidades;
		private bool _cantidad_unidadesNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_ACTIVIDADESRow_Base"/> class.
		/// </summary>
		public TRAMITES_ACTIVIDADESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_ACTIVIDADESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_ID != original.TRAMITE_ID) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.IsCANTIDAD_HORASNull != original.IsCANTIDAD_HORASNull) return true;
			if (!this.IsCANTIDAD_HORASNull && !original.IsCANTIDAD_HORASNull)
				if (this.CANTIDAD_HORAS != original.CANTIDAD_HORAS) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
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
			if (this.IsTOTAL_IMPUESTO_MONTNull != original.IsTOTAL_IMPUESTO_MONTNull) return true;
			if (!this.IsTOTAL_IMPUESTO_MONTNull && !original.IsTOTAL_IMPUESTO_MONTNull)
				if (this.TOTAL_IMPUESTO_MONT != original.TOTAL_IMPUESTO_MONT) return true;
			if (this.FINALIZADO != original.FINALIZADO) return true;
			if (this.IsCANTIDAD_UNIDADESNull != original.IsCANTIDAD_UNIDADESNull) return true;
			if (!this.IsCANTIDAD_UNIDADESNull && !original.IsCANTIDAD_UNIDADESNull)
				if (this.CANTIDAD_UNIDADES != original.CANTIDAD_UNIDADES) return true;
			
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
		/// Gets or sets the <c>TRAMITE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_ID</c> column value.</value>
		public decimal TRAMITE_ID
		{
			get { return _tramite_id; }
			set { _tramite_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_HORAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_HORAS</c> column value.</value>
		public decimal CANTIDAD_HORAS
		{
			get
			{
				if(IsCANTIDAD_HORASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_horas;
			}
			set
			{
				_cantidad_horasNull = false;
				_cantidad_horas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_HORAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_HORASNull
		{
			get { return _cantidad_horasNull; }
			set { _cantidad_horasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
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
		/// Gets or sets the <c>TOTAL_IMPUESTO_MONT</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO_MONT</c> column value.</value>
		public decimal TOTAL_IMPUESTO_MONT
		{
			get
			{
				if(IsTOTAL_IMPUESTO_MONTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto_mont;
			}
			set
			{
				_total_impuesto_montNull = false;
				_total_impuesto_mont = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO_MONT"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTO_MONTNull
		{
			get { return _total_impuesto_montNull; }
			set { _total_impuesto_montNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FINALIZADO</c> column value.
		/// </summary>
		/// <value>The <c>FINALIZADO</c> column value.</value>
		public string FINALIZADO
		{
			get { return _finalizado; }
			set { _finalizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNIDADES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNIDADES</c> column value.</value>
		public decimal CANTIDAD_UNIDADES
		{
			get
			{
				if(IsCANTIDAD_UNIDADESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unidades;
			}
			set
			{
				_cantidad_unidadesNull = false;
				_cantidad_unidades = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNIDADES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNIDADESNull
		{
			get { return _cantidad_unidadesNull; }
			set { _cantidad_unidadesNull = value; }
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
			dynStr.Append("@CBA@TRAMITE_ID=");
			dynStr.Append(TRAMITE_ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD_HORAS=");
			dynStr.Append(IsCANTIDAD_HORASNull ? (object)"<NULL>" : CANTIDAD_HORAS);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
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
			dynStr.Append("@CBA@TOTAL_IMPUESTO_MONT=");
			dynStr.Append(IsTOTAL_IMPUESTO_MONTNull ? (object)"<NULL>" : TOTAL_IMPUESTO_MONT);
			dynStr.Append("@CBA@FINALIZADO=");
			dynStr.Append(FINALIZADO);
			dynStr.Append("@CBA@CANTIDAD_UNIDADES=");
			dynStr.Append(IsCANTIDAD_UNIDADESNull ? (object)"<NULL>" : CANTIDAD_UNIDADES);
			return dynStr.ToString();
		}
	} // End of TRAMITES_ACTIVIDADESRow_Base class
} // End of namespace
