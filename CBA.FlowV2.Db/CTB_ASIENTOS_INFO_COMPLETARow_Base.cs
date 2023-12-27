// <fileinfo name="CTB_ASIENTOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _ctb_periodo_id;
		private string _ctb_periodo_nombre;
		private string _ctb_periodo_vigente;
		private string _ctb_periodo_vigente_por_margen;
		private decimal _ctb_ejercicio_id;
		private string _ctb_ejercicio_nombre;
		private System.DateTime _fecha_creacion;
		private string _observacion;
		private string _estado;
		private decimal _usuario_creacion_id;
		private bool _usuario_creacion_idNull = true;
		private string _usuario_creacion_nombre;
		private string _automatico;
		private decimal _usuario_inactivacion_id;
		private bool _usuario_inactivacion_idNull = true;
		private string _usuario_inactivacion_nombre;
		private System.DateTime _fecha_inactivacion;
		private bool _fecha_inactivacionNull = true;
		private System.DateTime _fecha_asiento;
		private decimal _numero;
		private string _observacion_sistema;
		private string _aprobado;
		private decimal _usuario_aprobacion_id;
		private bool _usuario_aprobacion_idNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private decimal _caso_relacionado_id;
		private bool _caso_relacionado_idNull = true;
		private decimal _caso_relacionado_flujo_id;
		private bool _caso_relacionado_flujo_idNull = true;
		private string _caso_relacionado_flujo_des;
		private decimal _transicion_id;
		private bool _transicion_idNull = true;
		private string _tabla_relacionada_id;
		private decimal _registro_relacionado_id;
		private bool _registro_relacionado_idNull = true;
		private string _revision_posterior;
		private string _es_apertura;
		private string _es_regularizacion;
		private string _es_cierre;
		private string _es_global;
		private decimal _ctb_asiento_global_id;
		private bool _ctb_asiento_global_idNull = true;
		private decimal _total_debe;
		private bool _total_debeNull = true;
		private decimal _total_haber;
		private bool _total_haberNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.CTB_PERIODO_ID != original.CTB_PERIODO_ID) return true;
			if (this.CTB_PERIODO_NOMBRE != original.CTB_PERIODO_NOMBRE) return true;
			if (this.CTB_PERIODO_VIGENTE != original.CTB_PERIODO_VIGENTE) return true;
			if (this.CTB_PERIODO_VIGENTE_POR_MARGEN != original.CTB_PERIODO_VIGENTE_POR_MARGEN) return true;
			if (this.CTB_EJERCICIO_ID != original.CTB_EJERCICIO_ID) return true;
			if (this.CTB_EJERCICIO_NOMBRE != original.CTB_EJERCICIO_NOMBRE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsUSUARIO_CREACION_IDNull != original.IsUSUARIO_CREACION_IDNull) return true;
			if (!this.IsUSUARIO_CREACION_IDNull && !original.IsUSUARIO_CREACION_IDNull)
				if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.USUARIO_CREACION_NOMBRE != original.USUARIO_CREACION_NOMBRE) return true;
			if (this.AUTOMATICO != original.AUTOMATICO) return true;
			if (this.IsUSUARIO_INACTIVACION_IDNull != original.IsUSUARIO_INACTIVACION_IDNull) return true;
			if (!this.IsUSUARIO_INACTIVACION_IDNull && !original.IsUSUARIO_INACTIVACION_IDNull)
				if (this.USUARIO_INACTIVACION_ID != original.USUARIO_INACTIVACION_ID) return true;
			if (this.USUARIO_INACTIVACION_NOMBRE != original.USUARIO_INACTIVACION_NOMBRE) return true;
			if (this.IsFECHA_INACTIVACIONNull != original.IsFECHA_INACTIVACIONNull) return true;
			if (!this.IsFECHA_INACTIVACIONNull && !original.IsFECHA_INACTIVACIONNull)
				if (this.FECHA_INACTIVACION != original.FECHA_INACTIVACION) return true;
			if (this.FECHA_ASIENTO != original.FECHA_ASIENTO) return true;
			if (this.NUMERO != original.NUMERO) return true;
			if (this.OBSERVACION_SISTEMA != original.OBSERVACION_SISTEMA) return true;
			if (this.APROBADO != original.APROBADO) return true;
			if (this.IsUSUARIO_APROBACION_IDNull != original.IsUSUARIO_APROBACION_IDNull) return true;
			if (!this.IsUSUARIO_APROBACION_IDNull && !original.IsUSUARIO_APROBACION_IDNull)
				if (this.USUARIO_APROBACION_ID != original.USUARIO_APROBACION_ID) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.IsCASO_RELACIONADO_IDNull != original.IsCASO_RELACIONADO_IDNull) return true;
			if (!this.IsCASO_RELACIONADO_IDNull && !original.IsCASO_RELACIONADO_IDNull)
				if (this.CASO_RELACIONADO_ID != original.CASO_RELACIONADO_ID) return true;
			if (this.IsCASO_RELACIONADO_FLUJO_IDNull != original.IsCASO_RELACIONADO_FLUJO_IDNull) return true;
			if (!this.IsCASO_RELACIONADO_FLUJO_IDNull && !original.IsCASO_RELACIONADO_FLUJO_IDNull)
				if (this.CASO_RELACIONADO_FLUJO_ID != original.CASO_RELACIONADO_FLUJO_ID) return true;
			if (this.CASO_RELACIONADO_FLUJO_DES != original.CASO_RELACIONADO_FLUJO_DES) return true;
			if (this.IsTRANSICION_IDNull != original.IsTRANSICION_IDNull) return true;
			if (!this.IsTRANSICION_IDNull && !original.IsTRANSICION_IDNull)
				if (this.TRANSICION_ID != original.TRANSICION_ID) return true;
			if (this.TABLA_RELACIONADA_ID != original.TABLA_RELACIONADA_ID) return true;
			if (this.IsREGISTRO_RELACIONADO_IDNull != original.IsREGISTRO_RELACIONADO_IDNull) return true;
			if (!this.IsREGISTRO_RELACIONADO_IDNull && !original.IsREGISTRO_RELACIONADO_IDNull)
				if (this.REGISTRO_RELACIONADO_ID != original.REGISTRO_RELACIONADO_ID) return true;
			if (this.REVISION_POSTERIOR != original.REVISION_POSTERIOR) return true;
			if (this.ES_APERTURA != original.ES_APERTURA) return true;
			if (this.ES_REGULARIZACION != original.ES_REGULARIZACION) return true;
			if (this.ES_CIERRE != original.ES_CIERRE) return true;
			if (this.ES_GLOBAL != original.ES_GLOBAL) return true;
			if (this.IsCTB_ASIENTO_GLOBAL_IDNull != original.IsCTB_ASIENTO_GLOBAL_IDNull) return true;
			if (!this.IsCTB_ASIENTO_GLOBAL_IDNull && !original.IsCTB_ASIENTO_GLOBAL_IDNull)
				if (this.CTB_ASIENTO_GLOBAL_ID != original.CTB_ASIENTO_GLOBAL_ID) return true;
			if (this.IsTOTAL_DEBENull != original.IsTOTAL_DEBENull) return true;
			if (!this.IsTOTAL_DEBENull && !original.IsTOTAL_DEBENull)
				if (this.TOTAL_DEBE != original.TOTAL_DEBE) return true;
			if (this.IsTOTAL_HABERNull != original.IsTOTAL_HABERNull) return true;
			if (!this.IsTOTAL_HABERNull && !original.IsTOTAL_HABERNull)
				if (this.TOTAL_HABER != original.TOTAL_HABER) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>CTB_PERIODO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PERIODO_ID</c> column value.</value>
		public decimal CTB_PERIODO_ID
		{
			get { return _ctb_periodo_id; }
			set { _ctb_periodo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PERIODO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PERIODO_NOMBRE</c> column value.</value>
		public string CTB_PERIODO_NOMBRE
		{
			get { return _ctb_periodo_nombre; }
			set { _ctb_periodo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PERIODO_VIGENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_PERIODO_VIGENTE</c> column value.</value>
		public string CTB_PERIODO_VIGENTE
		{
			get { return _ctb_periodo_vigente; }
			set { _ctb_periodo_vigente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PERIODO_VIGENTE_POR_MARGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_PERIODO_VIGENTE_POR_MARGEN</c> column value.</value>
		public string CTB_PERIODO_VIGENTE_POR_MARGEN
		{
			get { return _ctb_periodo_vigente_por_margen; }
			set { _ctb_periodo_vigente_por_margen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_EJERCICIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_EJERCICIO_ID</c> column value.</value>
		public decimal CTB_EJERCICIO_ID
		{
			get { return _ctb_ejercicio_id; }
			set { _ctb_ejercicio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_EJERCICIO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_EJERCICIO_NOMBRE</c> column value.</value>
		public string CTB_EJERCICIO_NOMBRE
		{
			get { return _ctb_ejercicio_nombre; }
			set { _ctb_ejercicio_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get
			{
				if(IsUSUARIO_CREACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_creacion_id;
			}
			set
			{
				_usuario_creacion_idNull = false;
				_usuario_creacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CREACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CREACION_IDNull
		{
			get { return _usuario_creacion_idNull; }
			set { _usuario_creacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_NOMBRE</c> column value.</value>
		public string USUARIO_CREACION_NOMBRE
		{
			get { return _usuario_creacion_nombre; }
			set { _usuario_creacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTOMATICO</c> column value.
		/// </summary>
		/// <value>The <c>AUTOMATICO</c> column value.</value>
		public string AUTOMATICO
		{
			get { return _automatico; }
			set { _automatico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_INACTIVACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_INACTIVACION_ID</c> column value.</value>
		public decimal USUARIO_INACTIVACION_ID
		{
			get
			{
				if(IsUSUARIO_INACTIVACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_inactivacion_id;
			}
			set
			{
				_usuario_inactivacion_idNull = false;
				_usuario_inactivacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_INACTIVACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_INACTIVACION_IDNull
		{
			get { return _usuario_inactivacion_idNull; }
			set { _usuario_inactivacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_INACTIVACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_INACTIVACION_NOMBRE</c> column value.</value>
		public string USUARIO_INACTIVACION_NOMBRE
		{
			get { return _usuario_inactivacion_nombre; }
			set { _usuario_inactivacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INACTIVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INACTIVACION</c> column value.</value>
		public System.DateTime FECHA_INACTIVACION
		{
			get
			{
				if(IsFECHA_INACTIVACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inactivacion;
			}
			set
			{
				_fecha_inactivacionNull = false;
				_fecha_inactivacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INACTIVACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INACTIVACIONNull
		{
			get { return _fecha_inactivacionNull; }
			set { _fecha_inactivacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ASIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ASIENTO</c> column value.</value>
		public System.DateTime FECHA_ASIENTO
		{
			get { return _fecha_asiento; }
			set { _fecha_asiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO</c> column value.</value>
		public decimal NUMERO
		{
			get { return _numero; }
			set { _numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_SISTEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_SISTEMA</c> column value.</value>
		public string OBSERVACION_SISTEMA
		{
			get { return _observacion_sistema; }
			set { _observacion_sistema = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APROBADO</c> column value.
		/// </summary>
		/// <value>The <c>APROBADO</c> column value.</value>
		public string APROBADO
		{
			get { return _aprobado; }
			set { _aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_APROBACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROBACION_ID</c> column value.</value>
		public decimal USUARIO_APROBACION_ID
		{
			get
			{
				if(IsUSUARIO_APROBACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprobacion_id;
			}
			set
			{
				_usuario_aprobacion_idNull = false;
				_usuario_aprobacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROBACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROBACION_IDNull
		{
			get { return _usuario_aprobacion_idNull; }
			set { _usuario_aprobacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROBACION</c> column value.</value>
		public System.DateTime FECHA_APROBACION
		{
			get
			{
				if(IsFECHA_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprobacion;
			}
			set
			{
				_fecha_aprobacionNull = false;
				_fecha_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROBACIONNull
		{
			get { return _fecha_aprobacionNull; }
			set { _fecha_aprobacionNull = value; }
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
		/// Gets or sets the <c>CASO_RELACIONADO_FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_RELACIONADO_FLUJO_ID</c> column value.</value>
		public decimal CASO_RELACIONADO_FLUJO_ID
		{
			get
			{
				if(IsCASO_RELACIONADO_FLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_relacionado_flujo_id;
			}
			set
			{
				_caso_relacionado_flujo_idNull = false;
				_caso_relacionado_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_RELACIONADO_FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_RELACIONADO_FLUJO_IDNull
		{
			get { return _caso_relacionado_flujo_idNull; }
			set { _caso_relacionado_flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_RELACIONADO_FLUJO_DES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_RELACIONADO_FLUJO_DES</c> column value.</value>
		public string CASO_RELACIONADO_FLUJO_DES
		{
			get { return _caso_relacionado_flujo_des; }
			set { _caso_relacionado_flujo_des = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSICION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_ID</c> column value.</value>
		public decimal TRANSICION_ID
		{
			get
			{
				if(IsTRANSICION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transicion_id;
			}
			set
			{
				_transicion_idNull = false;
				_transicion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSICION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSICION_IDNull
		{
			get { return _transicion_idNull; }
			set { _transicion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_RELACIONADA_ID</c> column value.</value>
		public string TABLA_RELACIONADA_ID
		{
			get { return _tabla_relacionada_id; }
			set { _tabla_relacionada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGISTRO_RELACIONADO_ID</c> column value.</value>
		public decimal REGISTRO_RELACIONADO_ID
		{
			get
			{
				if(IsREGISTRO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _registro_relacionado_id;
			}
			set
			{
				_registro_relacionado_idNull = false;
				_registro_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGISTRO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGISTRO_RELACIONADO_IDNull
		{
			get { return _registro_relacionado_idNull; }
			set { _registro_relacionado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REVISION_POSTERIOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REVISION_POSTERIOR</c> column value.</value>
		public string REVISION_POSTERIOR
		{
			get { return _revision_posterior; }
			set { _revision_posterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_APERTURA</c> column value.
		/// </summary>
		/// <value>The <c>ES_APERTURA</c> column value.</value>
		public string ES_APERTURA
		{
			get { return _es_apertura; }
			set { _es_apertura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_REGULARIZACION</c> column value.
		/// </summary>
		/// <value>The <c>ES_REGULARIZACION</c> column value.</value>
		public string ES_REGULARIZACION
		{
			get { return _es_regularizacion; }
			set { _es_regularizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CIERRE</c> column value.
		/// </summary>
		/// <value>The <c>ES_CIERRE</c> column value.</value>
		public string ES_CIERRE
		{
			get { return _es_cierre; }
			set { _es_cierre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_GLOBAL</c> column value.
		/// </summary>
		/// <value>The <c>ES_GLOBAL</c> column value.</value>
		public string ES_GLOBAL
		{
			get { return _es_global; }
			set { _es_global = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_ASIENTO_GLOBAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</value>
		public decimal CTB_ASIENTO_GLOBAL_ID
		{
			get
			{
				if(IsCTB_ASIENTO_GLOBAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_asiento_global_id;
			}
			set
			{
				_ctb_asiento_global_idNull = false;
				_ctb_asiento_global_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_ASIENTO_GLOBAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_ASIENTO_GLOBAL_IDNull
		{
			get { return _ctb_asiento_global_idNull; }
			set { _ctb_asiento_global_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DEBE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DEBE</c> column value.</value>
		public decimal TOTAL_DEBE
		{
			get
			{
				if(IsTOTAL_DEBENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_debe;
			}
			set
			{
				_total_debeNull = false;
				_total_debe = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DEBE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DEBENull
		{
			get { return _total_debeNull; }
			set { _total_debeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_HABER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_HABER</c> column value.</value>
		public decimal TOTAL_HABER
		{
			get
			{
				if(IsTOTAL_HABERNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_haber;
			}
			set
			{
				_total_haberNull = false;
				_total_haber = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_HABER"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_HABERNull
		{
			get { return _total_haberNull; }
			set { _total_haberNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@CTB_PERIODO_ID=");
			dynStr.Append(CTB_PERIODO_ID);
			dynStr.Append("@CBA@CTB_PERIODO_NOMBRE=");
			dynStr.Append(CTB_PERIODO_NOMBRE);
			dynStr.Append("@CBA@CTB_PERIODO_VIGENTE=");
			dynStr.Append(CTB_PERIODO_VIGENTE);
			dynStr.Append("@CBA@CTB_PERIODO_VIGENTE_POR_MARGEN=");
			dynStr.Append(CTB_PERIODO_VIGENTE_POR_MARGEN);
			dynStr.Append("@CBA@CTB_EJERCICIO_ID=");
			dynStr.Append(CTB_EJERCICIO_ID);
			dynStr.Append("@CBA@CTB_EJERCICIO_NOMBRE=");
			dynStr.Append(CTB_EJERCICIO_NOMBRE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(IsUSUARIO_CREACION_IDNull ? (object)"<NULL>" : USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_NOMBRE=");
			dynStr.Append(USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@AUTOMATICO=");
			dynStr.Append(AUTOMATICO);
			dynStr.Append("@CBA@USUARIO_INACTIVACION_ID=");
			dynStr.Append(IsUSUARIO_INACTIVACION_IDNull ? (object)"<NULL>" : USUARIO_INACTIVACION_ID);
			dynStr.Append("@CBA@USUARIO_INACTIVACION_NOMBRE=");
			dynStr.Append(USUARIO_INACTIVACION_NOMBRE);
			dynStr.Append("@CBA@FECHA_INACTIVACION=");
			dynStr.Append(IsFECHA_INACTIVACIONNull ? (object)"<NULL>" : FECHA_INACTIVACION);
			dynStr.Append("@CBA@FECHA_ASIENTO=");
			dynStr.Append(FECHA_ASIENTO);
			dynStr.Append("@CBA@NUMERO=");
			dynStr.Append(NUMERO);
			dynStr.Append("@CBA@OBSERVACION_SISTEMA=");
			dynStr.Append(OBSERVACION_SISTEMA);
			dynStr.Append("@CBA@APROBADO=");
			dynStr.Append(APROBADO);
			dynStr.Append("@CBA@USUARIO_APROBACION_ID=");
			dynStr.Append(IsUSUARIO_APROBACION_IDNull ? (object)"<NULL>" : USUARIO_APROBACION_ID);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@CASO_RELACIONADO_ID=");
			dynStr.Append(IsCASO_RELACIONADO_IDNull ? (object)"<NULL>" : CASO_RELACIONADO_ID);
			dynStr.Append("@CBA@CASO_RELACIONADO_FLUJO_ID=");
			dynStr.Append(IsCASO_RELACIONADO_FLUJO_IDNull ? (object)"<NULL>" : CASO_RELACIONADO_FLUJO_ID);
			dynStr.Append("@CBA@CASO_RELACIONADO_FLUJO_DES=");
			dynStr.Append(CASO_RELACIONADO_FLUJO_DES);
			dynStr.Append("@CBA@TRANSICION_ID=");
			dynStr.Append(IsTRANSICION_IDNull ? (object)"<NULL>" : TRANSICION_ID);
			dynStr.Append("@CBA@TABLA_RELACIONADA_ID=");
			dynStr.Append(TABLA_RELACIONADA_ID);
			dynStr.Append("@CBA@REGISTRO_RELACIONADO_ID=");
			dynStr.Append(IsREGISTRO_RELACIONADO_IDNull ? (object)"<NULL>" : REGISTRO_RELACIONADO_ID);
			dynStr.Append("@CBA@REVISION_POSTERIOR=");
			dynStr.Append(REVISION_POSTERIOR);
			dynStr.Append("@CBA@ES_APERTURA=");
			dynStr.Append(ES_APERTURA);
			dynStr.Append("@CBA@ES_REGULARIZACION=");
			dynStr.Append(ES_REGULARIZACION);
			dynStr.Append("@CBA@ES_CIERRE=");
			dynStr.Append(ES_CIERRE);
			dynStr.Append("@CBA@ES_GLOBAL=");
			dynStr.Append(ES_GLOBAL);
			dynStr.Append("@CBA@CTB_ASIENTO_GLOBAL_ID=");
			dynStr.Append(IsCTB_ASIENTO_GLOBAL_IDNull ? (object)"<NULL>" : CTB_ASIENTO_GLOBAL_ID);
			dynStr.Append("@CBA@TOTAL_DEBE=");
			dynStr.Append(IsTOTAL_DEBENull ? (object)"<NULL>" : TOTAL_DEBE);
			dynStr.Append("@CBA@TOTAL_HABER=");
			dynStr.Append(IsTOTAL_HABERNull ? (object)"<NULL>" : TOTAL_HABER);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_INFO_COMPLETARow_Base class
} // End of namespace
