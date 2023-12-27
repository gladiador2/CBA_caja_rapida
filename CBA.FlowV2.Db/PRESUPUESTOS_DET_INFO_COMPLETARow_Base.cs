// <fileinfo name="PRESUPUESTOS_DET_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>PRESUPUESTOS_DET_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_DET_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _presupuesto_etapa_id;
		private string _presupuesto_etapa_nombre;
		private decimal _presupuesto_id;
		private string _presupuesto_objeto;
		private decimal _monto_bruto_unitario;
		private bool _monto_bruto_unitarioNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _articulo_desc_interna;
		private string _articulo_cod_empresa;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private string _articulo_familia_desc;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private string _articulo_grupo_desc;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _articulo_subgrupo_desc;
		private string _articulo_unidad_med_id;
		private string _articulo_unidad_med_desc;
		private decimal _articulo_cantidad_por_caja;
		private bool _articulo_cantidad_por_cajaNull = true;
		private string _unidad_medida;
		private string _unidad_medida_descripcion;
		private decimal _cantidad_cajas;
		private bool _cantidad_cajasNull = true;
		private decimal _cantidad_unidades;
		private bool _cantidad_unidadesNull = true;
		private decimal _cantidad_por_caja;
		private bool _cantidad_por_cajaNull = true;
		private decimal _cantidad_unitaria_total;
		private bool _cantidad_unitaria_totalNull = true;
		private decimal _monto_descuento;
		private bool _monto_descuentoNull = true;
		private decimal _porcentaje_desc;
		private bool _porcentaje_descNull = true;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private string _impuesto_nombre;
		private decimal _impuesto_porcentaje;
		private bool _impuesto_porcentajeNull = true;
		private decimal _porcentaje_impuesto;
		private bool _porcentaje_impuestoNull = true;
		private string _observacion;
		private decimal _cantidad_unitaria_facturada;
		private bool _cantidad_unitaria_facturadaNull = true;
		private decimal _monto_neto_unitario;
		private bool _monto_neto_unitarioNull = true;
		private decimal _monto_impuesto;
		private bool _monto_impuestoNull = true;
		private decimal _monto_bruto_descontado_total;
		private bool _monto_bruto_descontado_totalNull = true;
		private string _activo_codigo;
		private decimal _activo_id;
		private bool _activo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DET_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public PRESUPUESTOS_DET_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRESUPUESTOS_DET_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PRESUPUESTO_ETAPA_ID != original.PRESUPUESTO_ETAPA_ID) return true;
			if (this.PRESUPUESTO_ETAPA_NOMBRE != original.PRESUPUESTO_ETAPA_NOMBRE) return true;
			if (this.PRESUPUESTO_ID != original.PRESUPUESTO_ID) return true;
			if (this.PRESUPUESTO_OBJETO != original.PRESUPUESTO_OBJETO) return true;
			if (this.IsMONTO_BRUTO_UNITARIONull != original.IsMONTO_BRUTO_UNITARIONull) return true;
			if (!this.IsMONTO_BRUTO_UNITARIONull && !original.IsMONTO_BRUTO_UNITARIONull)
				if (this.MONTO_BRUTO_UNITARIO != original.MONTO_BRUTO_UNITARIO) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_DESC_INTERNA != original.ARTICULO_DESC_INTERNA) return true;
			if (this.ARTICULO_COD_EMPRESA != original.ARTICULO_COD_EMPRESA) return true;
			if (this.IsARTICULO_FAMILIA_IDNull != original.IsARTICULO_FAMILIA_IDNull) return true;
			if (!this.IsARTICULO_FAMILIA_IDNull && !original.IsARTICULO_FAMILIA_IDNull)
				if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.ARTICULO_FAMILIA_DESC != original.ARTICULO_FAMILIA_DESC) return true;
			if (this.IsARTICULO_GRUPO_IDNull != original.IsARTICULO_GRUPO_IDNull) return true;
			if (!this.IsARTICULO_GRUPO_IDNull && !original.IsARTICULO_GRUPO_IDNull)
				if (this.ARTICULO_GRUPO_ID != original.ARTICULO_GRUPO_ID) return true;
			if (this.ARTICULO_GRUPO_DESC != original.ARTICULO_GRUPO_DESC) return true;
			if (this.IsARTICULO_SUBGRUPO_IDNull != original.IsARTICULO_SUBGRUPO_IDNull) return true;
			if (!this.IsARTICULO_SUBGRUPO_IDNull && !original.IsARTICULO_SUBGRUPO_IDNull)
				if (this.ARTICULO_SUBGRUPO_ID != original.ARTICULO_SUBGRUPO_ID) return true;
			if (this.ARTICULO_SUBGRUPO_DESC != original.ARTICULO_SUBGRUPO_DESC) return true;
			if (this.ARTICULO_UNIDAD_MED_ID != original.ARTICULO_UNIDAD_MED_ID) return true;
			if (this.ARTICULO_UNIDAD_MED_DESC != original.ARTICULO_UNIDAD_MED_DESC) return true;
			if (this.IsARTICULO_CANTIDAD_POR_CAJANull != original.IsARTICULO_CANTIDAD_POR_CAJANull) return true;
			if (!this.IsARTICULO_CANTIDAD_POR_CAJANull && !original.IsARTICULO_CANTIDAD_POR_CAJANull)
				if (this.ARTICULO_CANTIDAD_POR_CAJA != original.ARTICULO_CANTIDAD_POR_CAJA) return true;
			if (this.UNIDAD_MEDIDA != original.UNIDAD_MEDIDA) return true;
			if (this.UNIDAD_MEDIDA_DESCRIPCION != original.UNIDAD_MEDIDA_DESCRIPCION) return true;
			if (this.IsCANTIDAD_CAJASNull != original.IsCANTIDAD_CAJASNull) return true;
			if (!this.IsCANTIDAD_CAJASNull && !original.IsCANTIDAD_CAJASNull)
				if (this.CANTIDAD_CAJAS != original.CANTIDAD_CAJAS) return true;
			if (this.IsCANTIDAD_UNIDADESNull != original.IsCANTIDAD_UNIDADESNull) return true;
			if (!this.IsCANTIDAD_UNIDADESNull && !original.IsCANTIDAD_UNIDADESNull)
				if (this.CANTIDAD_UNIDADES != original.CANTIDAD_UNIDADES) return true;
			if (this.IsCANTIDAD_POR_CAJANull != original.IsCANTIDAD_POR_CAJANull) return true;
			if (!this.IsCANTIDAD_POR_CAJANull && !original.IsCANTIDAD_POR_CAJANull)
				if (this.CANTIDAD_POR_CAJA != original.CANTIDAD_POR_CAJA) return true;
			if (this.IsCANTIDAD_UNITARIA_TOTALNull != original.IsCANTIDAD_UNITARIA_TOTALNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_TOTALNull && !original.IsCANTIDAD_UNITARIA_TOTALNull)
				if (this.CANTIDAD_UNITARIA_TOTAL != original.CANTIDAD_UNITARIA_TOTAL) return true;
			if (this.IsMONTO_DESCUENTONull != original.IsMONTO_DESCUENTONull) return true;
			if (!this.IsMONTO_DESCUENTONull && !original.IsMONTO_DESCUENTONull)
				if (this.MONTO_DESCUENTO != original.MONTO_DESCUENTO) return true;
			if (this.IsPORCENTAJE_DESCNull != original.IsPORCENTAJE_DESCNull) return true;
			if (!this.IsPORCENTAJE_DESCNull && !original.IsPORCENTAJE_DESCNull)
				if (this.PORCENTAJE_DESC != original.PORCENTAJE_DESC) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IMPUESTO_NOMBRE != original.IMPUESTO_NOMBRE) return true;
			if (this.IsIMPUESTO_PORCENTAJENull != original.IsIMPUESTO_PORCENTAJENull) return true;
			if (!this.IsIMPUESTO_PORCENTAJENull && !original.IsIMPUESTO_PORCENTAJENull)
				if (this.IMPUESTO_PORCENTAJE != original.IMPUESTO_PORCENTAJE) return true;
			if (this.IsPORCENTAJE_IMPUESTONull != original.IsPORCENTAJE_IMPUESTONull) return true;
			if (!this.IsPORCENTAJE_IMPUESTONull && !original.IsPORCENTAJE_IMPUESTONull)
				if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCANTIDAD_UNITARIA_FACTURADANull != original.IsCANTIDAD_UNITARIA_FACTURADANull) return true;
			if (!this.IsCANTIDAD_UNITARIA_FACTURADANull && !original.IsCANTIDAD_UNITARIA_FACTURADANull)
				if (this.CANTIDAD_UNITARIA_FACTURADA != original.CANTIDAD_UNITARIA_FACTURADA) return true;
			if (this.IsMONTO_NETO_UNITARIONull != original.IsMONTO_NETO_UNITARIONull) return true;
			if (!this.IsMONTO_NETO_UNITARIONull && !original.IsMONTO_NETO_UNITARIONull)
				if (this.MONTO_NETO_UNITARIO != original.MONTO_NETO_UNITARIO) return true;
			if (this.IsMONTO_IMPUESTONull != original.IsMONTO_IMPUESTONull) return true;
			if (!this.IsMONTO_IMPUESTONull && !original.IsMONTO_IMPUESTONull)
				if (this.MONTO_IMPUESTO != original.MONTO_IMPUESTO) return true;
			if (this.IsMONTO_BRUTO_DESCONTADO_TOTALNull != original.IsMONTO_BRUTO_DESCONTADO_TOTALNull) return true;
			if (!this.IsMONTO_BRUTO_DESCONTADO_TOTALNull && !original.IsMONTO_BRUTO_DESCONTADO_TOTALNull)
				if (this.MONTO_BRUTO_DESCONTADO_TOTAL != original.MONTO_BRUTO_DESCONTADO_TOTAL) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			
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
		/// Gets or sets the <c>PRESUPUESTO_ETAPA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ETAPA_ID</c> column value.</value>
		public decimal PRESUPUESTO_ETAPA_ID
		{
			get { return _presupuesto_etapa_id; }
			set { _presupuesto_etapa_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_ETAPA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ETAPA_NOMBRE</c> column value.</value>
		public string PRESUPUESTO_ETAPA_NOMBRE
		{
			get { return _presupuesto_etapa_nombre; }
			set { _presupuesto_etapa_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_ID</c> column value.</value>
		public decimal PRESUPUESTO_ID
		{
			get { return _presupuesto_id; }
			set { _presupuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESUPUESTO_OBJETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESUPUESTO_OBJETO</c> column value.</value>
		public string PRESUPUESTO_OBJETO
		{
			get { return _presupuesto_objeto; }
			set { _presupuesto_objeto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BRUTO_UNITARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BRUTO_UNITARIO</c> column value.</value>
		public decimal MONTO_BRUTO_UNITARIO
		{
			get
			{
				if(IsMONTO_BRUTO_UNITARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bruto_unitario;
			}
			set
			{
				_monto_bruto_unitarioNull = false;
				_monto_bruto_unitario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BRUTO_UNITARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BRUTO_UNITARIONull
		{
			get { return _monto_bruto_unitarioNull; }
			set { _monto_bruto_unitarioNull = value; }
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
		/// Gets or sets the <c>ARTICULO_DESC_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESC_INTERNA</c> column value.</value>
		public string ARTICULO_DESC_INTERNA
		{
			get { return _articulo_desc_interna; }
			set { _articulo_desc_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_COD_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_COD_EMPRESA</c> column value.</value>
		public string ARTICULO_COD_EMPRESA
		{
			get { return _articulo_cod_empresa; }
			set { _articulo_cod_empresa = value; }
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
		/// Gets or sets the <c>ARTICULO_FAMILIA_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_DESC</c> column value.</value>
		public string ARTICULO_FAMILIA_DESC
		{
			get { return _articulo_familia_desc; }
			set { _articulo_familia_desc = value; }
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
		/// Gets or sets the <c>ARTICULO_GRUPO_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_DESC</c> column value.</value>
		public string ARTICULO_GRUPO_DESC
		{
			get { return _articulo_grupo_desc; }
			set { _articulo_grupo_desc = value; }
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
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_DESC</c> column value.</value>
		public string ARTICULO_SUBGRUPO_DESC
		{
			get { return _articulo_subgrupo_desc; }
			set { _articulo_subgrupo_desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_UNIDAD_MED_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_UNIDAD_MED_ID</c> column value.</value>
		public string ARTICULO_UNIDAD_MED_ID
		{
			get { return _articulo_unidad_med_id; }
			set { _articulo_unidad_med_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_UNIDAD_MED_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_UNIDAD_MED_DESC</c> column value.</value>
		public string ARTICULO_UNIDAD_MED_DESC
		{
			get { return _articulo_unidad_med_desc; }
			set { _articulo_unidad_med_desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_CANTIDAD_POR_CAJA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CANTIDAD_POR_CAJA</c> column value.</value>
		public decimal ARTICULO_CANTIDAD_POR_CAJA
		{
			get
			{
				if(IsARTICULO_CANTIDAD_POR_CAJANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_cantidad_por_caja;
			}
			set
			{
				_articulo_cantidad_por_cajaNull = false;
				_articulo_cantidad_por_caja = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_CANTIDAD_POR_CAJA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_CANTIDAD_POR_CAJANull
		{
			get { return _articulo_cantidad_por_cajaNull; }
			set { _articulo_cantidad_por_cajaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA</c> column value.</value>
		public string UNIDAD_MEDIDA
		{
			get { return _unidad_medida; }
			set { _unidad_medida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_DESCRIPCION</c> column value.</value>
		public string UNIDAD_MEDIDA_DESCRIPCION
		{
			get { return _unidad_medida_descripcion; }
			set { _unidad_medida_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CAJAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_CAJAS</c> column value.</value>
		public decimal CANTIDAD_CAJAS
		{
			get
			{
				if(IsCANTIDAD_CAJASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_cajas;
			}
			set
			{
				_cantidad_cajasNull = false;
				_cantidad_cajas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_CAJAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_CAJASNull
		{
			get { return _cantidad_cajasNull; }
			set { _cantidad_cajasNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_POR_CAJA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA
		{
			get
			{
				if(IsCANTIDAD_POR_CAJANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_por_caja;
			}
			set
			{
				_cantidad_por_cajaNull = false;
				_cantidad_por_caja = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_POR_CAJA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_POR_CAJANull
		{
			get { return _cantidad_por_cajaNull; }
			set { _cantidad_por_cajaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_total;
			}
			set
			{
				_cantidad_unitaria_totalNull = false;
				_cantidad_unitaria_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_TOTALNull
		{
			get { return _cantidad_unitaria_totalNull; }
			set { _cantidad_unitaria_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESCUENTO</c> column value.</value>
		public decimal MONTO_DESCUENTO
		{
			get
			{
				if(IsMONTO_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_descuento;
			}
			set
			{
				_monto_descuentoNull = false;
				_monto_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESCUENTONull
		{
			get { return _monto_descuentoNull; }
			set { _monto_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DESC</c> column value.</value>
		public decimal PORCENTAJE_DESC
		{
			get
			{
				if(IsPORCENTAJE_DESCNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_desc;
			}
			set
			{
				_porcentaje_descNull = false;
				_porcentaje_desc = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_DESC"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_DESCNull
		{
			get { return _porcentaje_descNull; }
			set { _porcentaje_descNull = value; }
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
		/// Gets or sets the <c>IMPUESTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_NOMBRE</c> column value.</value>
		public string IMPUESTO_NOMBRE
		{
			get { return _impuesto_nombre; }
			set { _impuesto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_PORCENTAJE</c> column value.</value>
		public decimal IMPUESTO_PORCENTAJE
		{
			get
			{
				if(IsIMPUESTO_PORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_porcentaje;
			}
			set
			{
				_impuesto_porcentajeNull = false;
				_impuesto_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_PORCENTAJENull
		{
			get { return _impuesto_porcentajeNull; }
			set { _impuesto_porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get
			{
				if(IsPORCENTAJE_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_impuesto;
			}
			set
			{
				_porcentaje_impuestoNull = false;
				_porcentaje_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_IMPUESTONull
		{
			get { return _porcentaje_impuestoNull; }
			set { _porcentaje_impuestoNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_UNITARIA_FACTURADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_FACTURADA</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_FACTURADA
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_FACTURADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_facturada;
			}
			set
			{
				_cantidad_unitaria_facturadaNull = false;
				_cantidad_unitaria_facturada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_FACTURADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_FACTURADANull
		{
			get { return _cantidad_unitaria_facturadaNull; }
			set { _cantidad_unitaria_facturadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_NETO_UNITARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_NETO_UNITARIO</c> column value.</value>
		public decimal MONTO_NETO_UNITARIO
		{
			get
			{
				if(IsMONTO_NETO_UNITARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_neto_unitario;
			}
			set
			{
				_monto_neto_unitarioNull = false;
				_monto_neto_unitario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_NETO_UNITARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_NETO_UNITARIONull
		{
			get { return _monto_neto_unitarioNull; }
			set { _monto_neto_unitarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_IMPUESTO</c> column value.</value>
		public decimal MONTO_IMPUESTO
		{
			get
			{
				if(IsMONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_impuesto;
			}
			set
			{
				_monto_impuestoNull = false;
				_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_IMPUESTONull
		{
			get { return _monto_impuestoNull; }
			set { _monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BRUTO_DESCONTADO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BRUTO_DESCONTADO_TOTAL</c> column value.</value>
		public decimal MONTO_BRUTO_DESCONTADO_TOTAL
		{
			get
			{
				if(IsMONTO_BRUTO_DESCONTADO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bruto_descontado_total;
			}
			set
			{
				_monto_bruto_descontado_totalNull = false;
				_monto_bruto_descontado_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BRUTO_DESCONTADO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BRUTO_DESCONTADO_TOTALNull
		{
			get { return _monto_bruto_descontado_totalNull; }
			set { _monto_bruto_descontado_totalNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PRESUPUESTO_ETAPA_ID=");
			dynStr.Append(PRESUPUESTO_ETAPA_ID);
			dynStr.Append("@CBA@PRESUPUESTO_ETAPA_NOMBRE=");
			dynStr.Append(PRESUPUESTO_ETAPA_NOMBRE);
			dynStr.Append("@CBA@PRESUPUESTO_ID=");
			dynStr.Append(PRESUPUESTO_ID);
			dynStr.Append("@CBA@PRESUPUESTO_OBJETO=");
			dynStr.Append(PRESUPUESTO_OBJETO);
			dynStr.Append("@CBA@MONTO_BRUTO_UNITARIO=");
			dynStr.Append(IsMONTO_BRUTO_UNITARIONull ? (object)"<NULL>" : MONTO_BRUTO_UNITARIO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_DESC_INTERNA=");
			dynStr.Append(ARTICULO_DESC_INTERNA);
			dynStr.Append("@CBA@ARTICULO_COD_EMPRESA=");
			dynStr.Append(ARTICULO_COD_EMPRESA);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_DESC=");
			dynStr.Append(ARTICULO_FAMILIA_DESC);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_DESC=");
			dynStr.Append(ARTICULO_GRUPO_DESC);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_DESC=");
			dynStr.Append(ARTICULO_SUBGRUPO_DESC);
			dynStr.Append("@CBA@ARTICULO_UNIDAD_MED_ID=");
			dynStr.Append(ARTICULO_UNIDAD_MED_ID);
			dynStr.Append("@CBA@ARTICULO_UNIDAD_MED_DESC=");
			dynStr.Append(ARTICULO_UNIDAD_MED_DESC);
			dynStr.Append("@CBA@ARTICULO_CANTIDAD_POR_CAJA=");
			dynStr.Append(IsARTICULO_CANTIDAD_POR_CAJANull ? (object)"<NULL>" : ARTICULO_CANTIDAD_POR_CAJA);
			dynStr.Append("@CBA@UNIDAD_MEDIDA=");
			dynStr.Append(UNIDAD_MEDIDA);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_DESCRIPCION=");
			dynStr.Append(UNIDAD_MEDIDA_DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD_CAJAS=");
			dynStr.Append(IsCANTIDAD_CAJASNull ? (object)"<NULL>" : CANTIDAD_CAJAS);
			dynStr.Append("@CBA@CANTIDAD_UNIDADES=");
			dynStr.Append(IsCANTIDAD_UNIDADESNull ? (object)"<NULL>" : CANTIDAD_UNIDADES);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA=");
			dynStr.Append(IsCANTIDAD_POR_CAJANull ? (object)"<NULL>" : CANTIDAD_POR_CAJA);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL=");
			dynStr.Append(IsCANTIDAD_UNITARIA_TOTALNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_TOTAL);
			dynStr.Append("@CBA@MONTO_DESCUENTO=");
			dynStr.Append(IsMONTO_DESCUENTONull ? (object)"<NULL>" : MONTO_DESCUENTO);
			dynStr.Append("@CBA@PORCENTAJE_DESC=");
			dynStr.Append(IsPORCENTAJE_DESCNull ? (object)"<NULL>" : PORCENTAJE_DESC);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTO_NOMBRE=");
			dynStr.Append(IMPUESTO_NOMBRE);
			dynStr.Append("@CBA@IMPUESTO_PORCENTAJE=");
			dynStr.Append(IsIMPUESTO_PORCENTAJENull ? (object)"<NULL>" : IMPUESTO_PORCENTAJE);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(IsPORCENTAJE_IMPUESTONull ? (object)"<NULL>" : PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_FACTURADA=");
			dynStr.Append(IsCANTIDAD_UNITARIA_FACTURADANull ? (object)"<NULL>" : CANTIDAD_UNITARIA_FACTURADA);
			dynStr.Append("@CBA@MONTO_NETO_UNITARIO=");
			dynStr.Append(IsMONTO_NETO_UNITARIONull ? (object)"<NULL>" : MONTO_NETO_UNITARIO);
			dynStr.Append("@CBA@MONTO_IMPUESTO=");
			dynStr.Append(IsMONTO_IMPUESTONull ? (object)"<NULL>" : MONTO_IMPUESTO);
			dynStr.Append("@CBA@MONTO_BRUTO_DESCONTADO_TOTAL=");
			dynStr.Append(IsMONTO_BRUTO_DESCONTADO_TOTALNull ? (object)"<NULL>" : MONTO_BRUTO_DESCONTADO_TOTAL);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			return dynStr.ToString();
		}
	} // End of PRESUPUESTOS_DET_INFO_COMPLETARow_Base class
} // End of namespace
