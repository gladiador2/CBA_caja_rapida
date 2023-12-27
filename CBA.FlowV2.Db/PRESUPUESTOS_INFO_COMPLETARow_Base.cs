// <fileinfo name="PRESUPUESTOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>PRESUPUESTOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRESUPUESTOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private System.DateTime _caso_fecha_creacion;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _sucursal_pais_id;
		private string _sucursal_pais_nombre;
		private decimal _entidad_id;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_entrega;
		private bool _fecha_entregaNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private System.DateTime _fecha_validez;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion;
		private decimal _persona_id;
		private string _persona_nombre_completo;
		private decimal _persona_garante_1_id;
		private bool _persona_garante_1_idNull = true;
		private decimal _persona_garante_2_id;
		private bool _persona_garante_2_idNull = true;
		private decimal _persona_garante_3_id;
		private bool _persona_garante_3_idNull = true;
		private string _observacion;
		private decimal _funcionario_id;
		private string _funcionario_nombre_completo;
		private string _objeto;
		private decimal _caso_origen_id;
		private bool _caso_origen_idNull = true;
		private decimal _texto_predefinido_tipo_id;
		private bool _texto_predefinido_tipo_idNull = true;
		private decimal _texto_predef_id_tipo;
		private bool _texto_predef_id_tipoNull = true;
		private string _texto_predef_tipo_nombre;
		private string _texto_predef_tipo_texto;
		private decimal _texto_predefinido_fuero_id;
		private bool _texto_predefinido_fuero_idNull = true;
		private decimal _texto_predef_id_fuero;
		private bool _texto_predef_id_fueroNull = true;
		private string _texto_predef_fuero_nombre;
		private string _texto_predef_fuero_texto;
		private decimal _total_monto_bruto;
		private bool _total_monto_brutoNull = true;
		private decimal _total_monto_descuento;
		private bool _total_monto_descuentoNull = true;
		private decimal _total_monto_neto;
		private bool _total_monto_netoNull = true;
		private decimal _total_monto_impuesto;
		private bool _total_monto_impuestoNull = true;
		private decimal _tramites_tipos_id;
		private bool _tramites_tipos_idNull = true;
		private string _tramites_tipos_nombre;
		private decimal _tipo_unificado_id;
		private bool _tipo_unificado_idNull = true;
		private string _tipo_unificado;
		private decimal _vehiculo_id;
		private bool _vehiculo_idNull = true;
		private string _vehiculo_nombre;
		private string _chasis_nro;
		private string _nro_comprobante_externo;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _articulo_monto;
		private bool _articulo_montoNull = true;
		private string _articulo_descripcion;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public PRESUPUESTOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRESUPUESTOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_FECHA_CREACION != original.CASO_FECHA_CREACION) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_PAIS_ID != original.SUCURSAL_PAIS_ID) return true;
			if (this.SUCURSAL_PAIS_NOMBRE != original.SUCURSAL_PAIS_NOMBRE) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsFECHA_ENTREGANull != original.IsFECHA_ENTREGANull) return true;
			if (!this.IsFECHA_ENTREGANull && !original.IsFECHA_ENTREGANull)
				if (this.FECHA_ENTREGA != original.FECHA_ENTREGA) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.FECHA_VALIDEZ != original.FECHA_VALIDEZ) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.IsPERSONA_GARANTE_1_IDNull != original.IsPERSONA_GARANTE_1_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_1_IDNull && !original.IsPERSONA_GARANTE_1_IDNull)
				if (this.PERSONA_GARANTE_1_ID != original.PERSONA_GARANTE_1_ID) return true;
			if (this.IsPERSONA_GARANTE_2_IDNull != original.IsPERSONA_GARANTE_2_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_2_IDNull && !original.IsPERSONA_GARANTE_2_IDNull)
				if (this.PERSONA_GARANTE_2_ID != original.PERSONA_GARANTE_2_ID) return true;
			if (this.IsPERSONA_GARANTE_3_IDNull != original.IsPERSONA_GARANTE_3_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_3_IDNull && !original.IsPERSONA_GARANTE_3_IDNull)
				if (this.PERSONA_GARANTE_3_ID != original.PERSONA_GARANTE_3_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.OBJETO != original.OBJETO) return true;
			if (this.IsCASO_ORIGEN_IDNull != original.IsCASO_ORIGEN_IDNull) return true;
			if (!this.IsCASO_ORIGEN_IDNull && !original.IsCASO_ORIGEN_IDNull)
				if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_TIPO_IDNull != original.IsTEXTO_PREDEFINIDO_TIPO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_TIPO_IDNull && !original.IsTEXTO_PREDEFINIDO_TIPO_IDNull)
				if (this.TEXTO_PREDEFINIDO_TIPO_ID != original.TEXTO_PREDEFINIDO_TIPO_ID) return true;
			if (this.IsTEXTO_PREDEF_ID_TIPONull != original.IsTEXTO_PREDEF_ID_TIPONull) return true;
			if (!this.IsTEXTO_PREDEF_ID_TIPONull && !original.IsTEXTO_PREDEF_ID_TIPONull)
				if (this.TEXTO_PREDEF_ID_TIPO != original.TEXTO_PREDEF_ID_TIPO) return true;
			if (this.TEXTO_PREDEF_TIPO_NOMBRE != original.TEXTO_PREDEF_TIPO_NOMBRE) return true;
			if (this.TEXTO_PREDEF_TIPO_TEXTO != original.TEXTO_PREDEF_TIPO_TEXTO) return true;
			if (this.IsTEXTO_PREDEFINIDO_FUERO_IDNull != original.IsTEXTO_PREDEFINIDO_FUERO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_FUERO_IDNull && !original.IsTEXTO_PREDEFINIDO_FUERO_IDNull)
				if (this.TEXTO_PREDEFINIDO_FUERO_ID != original.TEXTO_PREDEFINIDO_FUERO_ID) return true;
			if (this.IsTEXTO_PREDEF_ID_FUERONull != original.IsTEXTO_PREDEF_ID_FUERONull) return true;
			if (!this.IsTEXTO_PREDEF_ID_FUERONull && !original.IsTEXTO_PREDEF_ID_FUERONull)
				if (this.TEXTO_PREDEF_ID_FUERO != original.TEXTO_PREDEF_ID_FUERO) return true;
			if (this.TEXTO_PREDEF_FUERO_NOMBRE != original.TEXTO_PREDEF_FUERO_NOMBRE) return true;
			if (this.TEXTO_PREDEF_FUERO_TEXTO != original.TEXTO_PREDEF_FUERO_TEXTO) return true;
			if (this.IsTOTAL_MONTO_BRUTONull != original.IsTOTAL_MONTO_BRUTONull) return true;
			if (!this.IsTOTAL_MONTO_BRUTONull && !original.IsTOTAL_MONTO_BRUTONull)
				if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			if (this.IsTOTAL_MONTO_DESCUENTONull != original.IsTOTAL_MONTO_DESCUENTONull) return true;
			if (!this.IsTOTAL_MONTO_DESCUENTONull && !original.IsTOTAL_MONTO_DESCUENTONull)
				if (this.TOTAL_MONTO_DESCUENTO != original.TOTAL_MONTO_DESCUENTO) return true;
			if (this.IsTOTAL_MONTO_NETONull != original.IsTOTAL_MONTO_NETONull) return true;
			if (!this.IsTOTAL_MONTO_NETONull && !original.IsTOTAL_MONTO_NETONull)
				if (this.TOTAL_MONTO_NETO != original.TOTAL_MONTO_NETO) return true;
			if (this.IsTOTAL_MONTO_IMPUESTONull != original.IsTOTAL_MONTO_IMPUESTONull) return true;
			if (!this.IsTOTAL_MONTO_IMPUESTONull && !original.IsTOTAL_MONTO_IMPUESTONull)
				if (this.TOTAL_MONTO_IMPUESTO != original.TOTAL_MONTO_IMPUESTO) return true;
			if (this.IsTRAMITES_TIPOS_IDNull != original.IsTRAMITES_TIPOS_IDNull) return true;
			if (!this.IsTRAMITES_TIPOS_IDNull && !original.IsTRAMITES_TIPOS_IDNull)
				if (this.TRAMITES_TIPOS_ID != original.TRAMITES_TIPOS_ID) return true;
			if (this.TRAMITES_TIPOS_NOMBRE != original.TRAMITES_TIPOS_NOMBRE) return true;
			if (this.IsTIPO_UNIFICADO_IDNull != original.IsTIPO_UNIFICADO_IDNull) return true;
			if (!this.IsTIPO_UNIFICADO_IDNull && !original.IsTIPO_UNIFICADO_IDNull)
				if (this.TIPO_UNIFICADO_ID != original.TIPO_UNIFICADO_ID) return true;
			if (this.TIPO_UNIFICADO != original.TIPO_UNIFICADO) return true;
			if (this.IsVEHICULO_IDNull != original.IsVEHICULO_IDNull) return true;
			if (!this.IsVEHICULO_IDNull && !original.IsVEHICULO_IDNull)
				if (this.VEHICULO_ID != original.VEHICULO_ID) return true;
			if (this.VEHICULO_NOMBRE != original.VEHICULO_NOMBRE) return true;
			if (this.CHASIS_NRO != original.CHASIS_NRO) return true;
			if (this.NRO_COMPROBANTE_EXTERNO != original.NRO_COMPROBANTE_EXTERNO) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsARTICULO_MONTONull != original.IsARTICULO_MONTONull) return true;
			if (!this.IsARTICULO_MONTONull && !original.IsARTICULO_MONTONull)
				if (this.ARTICULO_MONTO != original.ARTICULO_MONTO) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			
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
		/// Gets or sets the <c>CASO_FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FECHA_CREACION</c> column value.</value>
		public System.DateTime CASO_FECHA_CREACION
		{
			get { return _caso_fecha_creacion; }
			set { _caso_fecha_creacion = value; }
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
		/// Gets or sets the <c>SUCURSAL_PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_PAIS_ID</c> column value.</value>
		public decimal SUCURSAL_PAIS_ID
		{
			get { return _sucursal_pais_id; }
			set { _sucursal_pais_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_PAIS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_PAIS_NOMBRE</c> column value.</value>
		public string SUCURSAL_PAIS_NOMBRE
		{
			get { return _sucursal_pais_nombre; }
			set { _sucursal_pais_nombre = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENTREGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ENTREGA</c> column value.</value>
		public System.DateTime FECHA_ENTREGA
		{
			get
			{
				if(IsFECHA_ENTREGANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_entrega;
			}
			set
			{
				_fecha_entregaNull = false;
				_fecha_entrega = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ENTREGA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ENTREGANull
		{
			get { return _fecha_entregaNull; }
			set { _fecha_entregaNull = value; }
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
		/// Gets or sets the <c>FECHA_VALIDEZ</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VALIDEZ</c> column value.</value>
		public System.DateTime FECHA_VALIDEZ
		{
			get { return _fecha_validez; }
			set { _fecha_validez = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_1_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_1_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_1_id;
			}
			set
			{
				_persona_garante_1_idNull = false;
				_persona_garante_1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_1_IDNull
		{
			get { return _persona_garante_1_idNull; }
			set { _persona_garante_1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_2_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_2_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_2_id;
			}
			set
			{
				_persona_garante_2_idNull = false;
				_persona_garante_2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_2_IDNull
		{
			get { return _persona_garante_2_idNull; }
			set { _persona_garante_2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_GARANTE_3_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_3_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_3_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_3_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_3_id;
			}
			set
			{
				_persona_garante_3_idNull = false;
				_persona_garante_3_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_3_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_3_IDNull
		{
			get { return _persona_garante_3_idNull; }
			set { _persona_garante_3_idNull = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE_COMPLETO</c> column value.</value>
		public string FUNCIONARIO_NOMBRE_COMPLETO
		{
			get { return _funcionario_nombre_completo; }
			set { _funcionario_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBJETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBJETO</c> column value.</value>
		public string OBJETO
		{
			get { return _objeto; }
			set { _objeto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get
			{
				if(IsCASO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_origen_id;
			}
			set
			{
				_caso_origen_idNull = false;
				_caso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGEN_IDNull
		{
			get { return _caso_origen_idNull; }
			set { _caso_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_TIPO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_TIPO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_TIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_tipo_id;
			}
			set
			{
				_texto_predefinido_tipo_idNull = false;
				_texto_predefinido_tipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_TIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_TIPO_IDNull
		{
			get { return _texto_predefinido_tipo_idNull; }
			set { _texto_predefinido_tipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_ID_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_ID_TIPO</c> column value.</value>
		public decimal TEXTO_PREDEF_ID_TIPO
		{
			get
			{
				if(IsTEXTO_PREDEF_ID_TIPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predef_id_tipo;
			}
			set
			{
				_texto_predef_id_tipoNull = false;
				_texto_predef_id_tipo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEF_ID_TIPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEF_ID_TIPONull
		{
			get { return _texto_predef_id_tipoNull; }
			set { _texto_predef_id_tipoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_TIPO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_TIPO_NOMBRE</c> column value.</value>
		public string TEXTO_PREDEF_TIPO_NOMBRE
		{
			get { return _texto_predef_tipo_nombre; }
			set { _texto_predef_tipo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_TIPO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_TIPO_TEXTO</c> column value.</value>
		public string TEXTO_PREDEF_TIPO_TEXTO
		{
			get { return _texto_predef_tipo_texto; }
			set { _texto_predef_tipo_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_FUERO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_FUERO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_FUERO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_fuero_id;
			}
			set
			{
				_texto_predefinido_fuero_idNull = false;
				_texto_predefinido_fuero_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_FUERO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_FUERO_IDNull
		{
			get { return _texto_predefinido_fuero_idNull; }
			set { _texto_predefinido_fuero_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_ID_FUERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_ID_FUERO</c> column value.</value>
		public decimal TEXTO_PREDEF_ID_FUERO
		{
			get
			{
				if(IsTEXTO_PREDEF_ID_FUERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predef_id_fuero;
			}
			set
			{
				_texto_predef_id_fueroNull = false;
				_texto_predef_id_fuero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEF_ID_FUERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEF_ID_FUERONull
		{
			get { return _texto_predef_id_fueroNull; }
			set { _texto_predef_id_fueroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_FUERO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_FUERO_NOMBRE</c> column value.</value>
		public string TEXTO_PREDEF_FUERO_NOMBRE
		{
			get { return _texto_predef_fuero_nombre; }
			set { _texto_predef_fuero_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_FUERO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_FUERO_TEXTO</c> column value.</value>
		public string TEXTO_PREDEF_FUERO_TEXTO
		{
			get { return _texto_predef_fuero_texto; }
			set { _texto_predef_fuero_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto;
			}
			set
			{
				_total_monto_brutoNull = false;
				_total_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTONull
		{
			get { return _total_monto_brutoNull; }
			set { _total_monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_DESCUENTO</c> column value.</value>
		public decimal TOTAL_MONTO_DESCUENTO
		{
			get
			{
				if(IsTOTAL_MONTO_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_descuento;
			}
			set
			{
				_total_monto_descuentoNull = false;
				_total_monto_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_DESCUENTONull
		{
			get { return _total_monto_descuentoNull; }
			set { _total_monto_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_NETO</c> column value.</value>
		public decimal TOTAL_MONTO_NETO
		{
			get
			{
				if(IsTOTAL_MONTO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_neto;
			}
			set
			{
				_total_monto_netoNull = false;
				_total_monto_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_NETONull
		{
			get { return _total_monto_netoNull; }
			set { _total_monto_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO
		{
			get
			{
				if(IsTOTAL_MONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_impuesto;
			}
			set
			{
				_total_monto_impuestoNull = false;
				_total_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_IMPUESTONull
		{
			get { return _total_monto_impuestoNull; }
			set { _total_monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITES_TIPOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITES_TIPOS_ID</c> column value.</value>
		public decimal TRAMITES_TIPOS_ID
		{
			get
			{
				if(IsTRAMITES_TIPOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramites_tipos_id;
			}
			set
			{
				_tramites_tipos_idNull = false;
				_tramites_tipos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITES_TIPOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITES_TIPOS_IDNull
		{
			get { return _tramites_tipos_idNull; }
			set { _tramites_tipos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITES_TIPOS_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITES_TIPOS_NOMBRE</c> column value.</value>
		public string TRAMITES_TIPOS_NOMBRE
		{
			get { return _tramites_tipos_nombre; }
			set { _tramites_tipos_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_UNIFICADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_UNIFICADO_ID</c> column value.</value>
		public decimal TIPO_UNIFICADO_ID
		{
			get
			{
				if(IsTIPO_UNIFICADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_unificado_id;
			}
			set
			{
				_tipo_unificado_idNull = false;
				_tipo_unificado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_UNIFICADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_UNIFICADO_IDNull
		{
			get { return _tipo_unificado_idNull; }
			set { _tipo_unificado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_UNIFICADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_UNIFICADO</c> column value.</value>
		public string TIPO_UNIFICADO
		{
			get { return _tipo_unificado; }
			set { _tipo_unificado = value; }
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
		/// Gets or sets the <c>VEHICULO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO_NOMBRE</c> column value.</value>
		public string VEHICULO_NOMBRE
		{
			get { return _vehiculo_nombre; }
			set { _vehiculo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHASIS_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHASIS_NRO</c> column value.</value>
		public string CHASIS_NRO
		{
			get { return _chasis_nro; }
			set { _chasis_nro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_EXTERNO</c> column value.</value>
		public string NRO_COMPROBANTE_EXTERNO
		{
			get { return _nro_comprobante_externo; }
			set { _nro_comprobante_externo = value; }
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
		/// Gets or sets the <c>ARTICULO_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_MONTO</c> column value.</value>
		public decimal ARTICULO_MONTO
		{
			get
			{
				if(IsARTICULO_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_monto;
			}
			set
			{
				_articulo_montoNull = false;
				_articulo_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_MONTONull
		{
			get { return _articulo_montoNull; }
			set { _articulo_montoNull = value; }
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
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CASO_FECHA_CREACION=");
			dynStr.Append(CASO_FECHA_CREACION);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_PAIS_ID=");
			dynStr.Append(SUCURSAL_PAIS_ID);
			dynStr.Append("@CBA@SUCURSAL_PAIS_NOMBRE=");
			dynStr.Append(SUCURSAL_PAIS_NOMBRE);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_ENTREGA=");
			dynStr.Append(IsFECHA_ENTREGANull ? (object)"<NULL>" : FECHA_ENTREGA);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@FECHA_VALIDEZ=");
			dynStr.Append(FECHA_VALIDEZ);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_GARANTE_1_ID=");
			dynStr.Append(IsPERSONA_GARANTE_1_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_1_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_2_ID=");
			dynStr.Append(IsPERSONA_GARANTE_2_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_2_ID);
			dynStr.Append("@CBA@PERSONA_GARANTE_3_ID=");
			dynStr.Append(IsPERSONA_GARANTE_3_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_3_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@OBJETO=");
			dynStr.Append(OBJETO);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(IsCASO_ORIGEN_IDNull ? (object)"<NULL>" : CASO_ORIGEN_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_TIPO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_TIPO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_TIPO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEF_ID_TIPO=");
			dynStr.Append(IsTEXTO_PREDEF_ID_TIPONull ? (object)"<NULL>" : TEXTO_PREDEF_ID_TIPO);
			dynStr.Append("@CBA@TEXTO_PREDEF_TIPO_NOMBRE=");
			dynStr.Append(TEXTO_PREDEF_TIPO_NOMBRE);
			dynStr.Append("@CBA@TEXTO_PREDEF_TIPO_TEXTO=");
			dynStr.Append(TEXTO_PREDEF_TIPO_TEXTO);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_FUERO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_FUERO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_FUERO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEF_ID_FUERO=");
			dynStr.Append(IsTEXTO_PREDEF_ID_FUERONull ? (object)"<NULL>" : TEXTO_PREDEF_ID_FUERO);
			dynStr.Append("@CBA@TEXTO_PREDEF_FUERO_NOMBRE=");
			dynStr.Append(TEXTO_PREDEF_FUERO_NOMBRE);
			dynStr.Append("@CBA@TEXTO_PREDEF_FUERO_TEXTO=");
			dynStr.Append(TEXTO_PREDEF_FUERO_TEXTO);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(IsTOTAL_MONTO_BRUTONull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO);
			dynStr.Append("@CBA@TOTAL_MONTO_DESCUENTO=");
			dynStr.Append(IsTOTAL_MONTO_DESCUENTONull ? (object)"<NULL>" : TOTAL_MONTO_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_MONTO_NETO=");
			dynStr.Append(IsTOTAL_MONTO_NETONull ? (object)"<NULL>" : TOTAL_MONTO_NETO);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO=");
			dynStr.Append(IsTOTAL_MONTO_IMPUESTONull ? (object)"<NULL>" : TOTAL_MONTO_IMPUESTO);
			dynStr.Append("@CBA@TRAMITES_TIPOS_ID=");
			dynStr.Append(IsTRAMITES_TIPOS_IDNull ? (object)"<NULL>" : TRAMITES_TIPOS_ID);
			dynStr.Append("@CBA@TRAMITES_TIPOS_NOMBRE=");
			dynStr.Append(TRAMITES_TIPOS_NOMBRE);
			dynStr.Append("@CBA@TIPO_UNIFICADO_ID=");
			dynStr.Append(IsTIPO_UNIFICADO_IDNull ? (object)"<NULL>" : TIPO_UNIFICADO_ID);
			dynStr.Append("@CBA@TIPO_UNIFICADO=");
			dynStr.Append(TIPO_UNIFICADO);
			dynStr.Append("@CBA@VEHICULO_ID=");
			dynStr.Append(IsVEHICULO_IDNull ? (object)"<NULL>" : VEHICULO_ID);
			dynStr.Append("@CBA@VEHICULO_NOMBRE=");
			dynStr.Append(VEHICULO_NOMBRE);
			dynStr.Append("@CBA@CHASIS_NRO=");
			dynStr.Append(CHASIS_NRO);
			dynStr.Append("@CBA@NRO_COMPROBANTE_EXTERNO=");
			dynStr.Append(NRO_COMPROBANTE_EXTERNO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_MONTO=");
			dynStr.Append(IsARTICULO_MONTONull ? (object)"<NULL>" : ARTICULO_MONTO);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			return dynStr.ToString();
		}
	} // End of PRESUPUESTOS_INFO_COMPLETARow_Base class
} // End of namespace
