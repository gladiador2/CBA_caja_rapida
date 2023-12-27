// <fileinfo name="ORDENES_PAGO_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ORDENES_PAGO_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_PAGO_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _orden_pago_tipo_id;
		private string _orden_pago_tipo_nombre;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _autonumeracion_timbrado;
		private decimal _retencion_autonumeracion_id;
		private bool _retencion_autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _numero_solicitud;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _sucursal_origen_id;
		private string _sucursal_origen_nombre;
		private string _sucursal_origen_abreviatura;
		private decimal _ctacte_caja_teso_origen_id;
		private bool _ctacte_caja_teso_origen_idNull = true;
		private string _ctacte_caja_teso_origen_nomb;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _proveedor_razon_social;
		private string _proveedor_nombre_fantasia;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto_total;
		private string _nro_recibo_beneficiario;
		private System.DateTime _fecha_recibo_beneficiario;
		private bool _fecha_recibo_beneficiarioNull = true;
		private string _nombre_beneficiario;
		private string _observacion;
		private string _observacion_interna;
		private string _retencion_unificada;
		private string _nombre_texto_predefinido;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _proveedor_ruc;
		private string _proveedor_codigo;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ORDENES_PAGO_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_PAGO_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.ORDEN_PAGO_TIPO_ID != original.ORDEN_PAGO_TIPO_ID) return true;
			if (this.ORDEN_PAGO_TIPO_NOMBRE != original.ORDEN_PAGO_TIPO_NOMBRE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION_TIMBRADO != original.AUTONUMERACION_TIMBRADO) return true;
			if (this.IsRETENCION_AUTONUMERACION_IDNull != original.IsRETENCION_AUTONUMERACION_IDNull) return true;
			if (!this.IsRETENCION_AUTONUMERACION_IDNull && !original.IsRETENCION_AUTONUMERACION_IDNull)
				if (this.RETENCION_AUTONUMERACION_ID != original.RETENCION_AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.NUMERO_SOLICITUD != original.NUMERO_SOLICITUD) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.SUCURSAL_ORIGEN_NOMBRE != original.SUCURSAL_ORIGEN_NOMBRE) return true;
			if (this.SUCURSAL_ORIGEN_ABREVIATURA != original.SUCURSAL_ORIGEN_ABREVIATURA) return true;
			if (this.IsCTACTE_CAJA_TESO_ORIGEN_IDNull != original.IsCTACTE_CAJA_TESO_ORIGEN_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESO_ORIGEN_IDNull && !original.IsCTACTE_CAJA_TESO_ORIGEN_IDNull)
				if (this.CTACTE_CAJA_TESO_ORIGEN_ID != original.CTACTE_CAJA_TESO_ORIGEN_ID) return true;
			if (this.CTACTE_CAJA_TESO_ORIGEN_NOMB != original.CTACTE_CAJA_TESO_ORIGEN_NOMB) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.PROVEEDOR_NOMBRE_FANTASIA != original.PROVEEDOR_NOMBRE_FANTASIA) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.NRO_RECIBO_BENEFICIARIO != original.NRO_RECIBO_BENEFICIARIO) return true;
			if (this.IsFECHA_RECIBO_BENEFICIARIONull != original.IsFECHA_RECIBO_BENEFICIARIONull) return true;
			if (!this.IsFECHA_RECIBO_BENEFICIARIONull && !original.IsFECHA_RECIBO_BENEFICIARIONull)
				if (this.FECHA_RECIBO_BENEFICIARIO != original.FECHA_RECIBO_BENEFICIARIO) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.OBSERVACION_INTERNA != original.OBSERVACION_INTERNA) return true;
			if (this.RETENCION_UNIFICADA != original.RETENCION_UNIFICADA) return true;
			if (this.NOMBRE_TEXTO_PREDEFINIDO != original.NOMBRE_TEXTO_PREDEFINIDO) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.PROVEEDOR_RUC != original.PROVEEDOR_RUC) return true;
			if (this.PROVEEDOR_CODIGO != original.PROVEEDOR_CODIGO) return true;
			
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
		/// Gets or sets the <c>ORDEN_PAGO_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_TIPO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_TIPO_ID
		{
			get { return _orden_pago_tipo_id; }
			set { _orden_pago_tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_TIPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_TIPO_NOMBRE</c> column value.</value>
		public string ORDEN_PAGO_TIPO_NOMBRE
		{
			get { return _orden_pago_tipo_nombre; }
			set { _orden_pago_tipo_nombre = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_TIMBRADO</c> column value.</value>
		public string AUTONUMERACION_TIMBRADO
		{
			get { return _autonumeracion_timbrado; }
			set { _autonumeracion_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_AUTONUMERACION_ID</c> column value.</value>
		public decimal RETENCION_AUTONUMERACION_ID
		{
			get
			{
				if(IsRETENCION_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_autonumeracion_id;
			}
			set
			{
				_retencion_autonumeracion_idNull = false;
				_retencion_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_AUTONUMERACION_IDNull
		{
			get { return _retencion_autonumeracion_idNull; }
			set { _retencion_autonumeracion_idNull = value; }
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
		/// Gets or sets the <c>NUMERO_SOLICITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_SOLICITUD</c> column value.</value>
		public string NUMERO_SOLICITUD
		{
			get { return _numero_solicitud; }
			set { _numero_solicitud = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get { return _sucursal_origen_id; }
			set { _sucursal_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.</value>
		public string SUCURSAL_ORIGEN_NOMBRE
		{
			get { return _sucursal_origen_nombre; }
			set { _sucursal_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ORIGEN_ABREVIATURA
		{
			get { return _sucursal_origen_abreviatura; }
			set { _sucursal_origen_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_ORIGEN_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESO_ORIGEN_ID
		{
			get
			{
				if(IsCTACTE_CAJA_TESO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_teso_origen_id;
			}
			set
			{
				_ctacte_caja_teso_origen_idNull = false;
				_ctacte_caja_teso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_TESO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_TESO_ORIGEN_IDNull
		{
			get { return _ctacte_caja_teso_origen_idNull; }
			set { _ctacte_caja_teso_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_ORIGEN_NOMB</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_ORIGEN_NOMB</c> column value.</value>
		public string CTACTE_CAJA_TESO_ORIGEN_NOMB
		{
			get { return _ctacte_caja_teso_origen_nomb; }
			set { _ctacte_caja_teso_origen_nomb = value; }
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RAZON_SOCIAL</c> column value.</value>
		public string PROVEEDOR_RAZON_SOCIAL
		{
			get { return _proveedor_razon_social; }
			set { _proveedor_razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_NOMBRE_FANTASIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_NOMBRE_FANTASIA</c> column value.</value>
		public string PROVEEDOR_NOMBRE_FANTASIA
		{
			get { return _proveedor_nombre_fantasia; }
			set { _proveedor_nombre_fantasia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_RECIBO_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_RECIBO_BENEFICIARIO</c> column value.</value>
		public string NRO_RECIBO_BENEFICIARIO
		{
			get { return _nro_recibo_beneficiario; }
			set { _nro_recibo_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECIBO_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RECIBO_BENEFICIARIO</c> column value.</value>
		public System.DateTime FECHA_RECIBO_BENEFICIARIO
		{
			get
			{
				if(IsFECHA_RECIBO_BENEFICIARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_recibo_beneficiario;
			}
			set
			{
				_fecha_recibo_beneficiarioNull = false;
				_fecha_recibo_beneficiario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RECIBO_BENEFICIARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RECIBO_BENEFICIARIONull
		{
			get { return _fecha_recibo_beneficiarioNull; }
			set { _fecha_recibo_beneficiarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_BENEFICIARIO</c> column value.</value>
		public string NOMBRE_BENEFICIARIO
		{
			get { return _nombre_beneficiario; }
			set { _nombre_beneficiario = value; }
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
		/// Gets or sets the <c>OBSERVACION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_INTERNA</c> column value.</value>
		public string OBSERVACION_INTERNA
		{
			get { return _observacion_interna; }
			set { _observacion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_UNIFICADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_UNIFICADA</c> column value.</value>
		public string RETENCION_UNIFICADA
		{
			get { return _retencion_unificada; }
			set { _retencion_unificada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_TEXTO_PREDEFINIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_TEXTO_PREDEFINIDO</c> column value.</value>
		public string NOMBRE_TEXTO_PREDEFINIDO
		{
			get { return _nombre_texto_predefinido; }
			set { _nombre_texto_predefinido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_RUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_RUC</c> column value.</value>
		public string PROVEEDOR_RUC
		{
			get { return _proveedor_ruc; }
			set { _proveedor_ruc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_CODIGO</c> column value.</value>
		public string PROVEEDOR_CODIGO
		{
			get { return _proveedor_codigo; }
			set { _proveedor_codigo = value; }
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
			dynStr.Append("@CBA@ORDEN_PAGO_TIPO_ID=");
			dynStr.Append(ORDEN_PAGO_TIPO_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_TIPO_NOMBRE=");
			dynStr.Append(ORDEN_PAGO_TIPO_NOMBRE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION_TIMBRADO=");
			dynStr.Append(AUTONUMERACION_TIMBRADO);
			dynStr.Append("@CBA@RETENCION_AUTONUMERACION_ID=");
			dynStr.Append(IsRETENCION_AUTONUMERACION_IDNull ? (object)"<NULL>" : RETENCION_AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NUMERO_SOLICITUD=");
			dynStr.Append(NUMERO_SOLICITUD);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_NOMBRE=");
			dynStr.Append(SUCURSAL_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ORIGEN_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_ORIGEN_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESO_ORIGEN_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESO_ORIGEN_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_ORIGEN_NOMB=");
			dynStr.Append(CTACTE_CAJA_TESO_ORIGEN_NOMB);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE_FANTASIA=");
			dynStr.Append(PROVEEDOR_NOMBRE_FANTASIA);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@NRO_RECIBO_BENEFICIARIO=");
			dynStr.Append(NRO_RECIBO_BENEFICIARIO);
			dynStr.Append("@CBA@FECHA_RECIBO_BENEFICIARIO=");
			dynStr.Append(IsFECHA_RECIBO_BENEFICIARIONull ? (object)"<NULL>" : FECHA_RECIBO_BENEFICIARIO);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@OBSERVACION_INTERNA=");
			dynStr.Append(OBSERVACION_INTERNA);
			dynStr.Append("@CBA@RETENCION_UNIFICADA=");
			dynStr.Append(RETENCION_UNIFICADA);
			dynStr.Append("@CBA@NOMBRE_TEXTO_PREDEFINIDO=");
			dynStr.Append(NOMBRE_TEXTO_PREDEFINIDO);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@PROVEEDOR_RUC=");
			dynStr.Append(PROVEEDOR_RUC);
			dynStr.Append("@CBA@PROVEEDOR_CODIGO=");
			dynStr.Append(PROVEEDOR_CODIGO);
			return dynStr.ToString();
		}
	} // End of ORDENES_PAGO_INFO_COMPLETARow_Base class
} // End of namespace
