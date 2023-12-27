// <fileinfo name="APLICACION_DOCUMEN_DOC_INFO_CORow_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMEN_DOC_INFO_CORow"/> that 
	/// represents a record in the <c>APLICACION_DOCUMEN_DOC_INFO_CO</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="APLICACION_DOCUMEN_DOC_INFO_CORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMEN_DOC_INFO_CORow_Base
	{
		private decimal _id;
		private decimal _aplicacion_documento_id;
		private decimal _monto_origen;
		private decimal _monto_destino;
		private decimal _cotizacion_detalle;
		private decimal _moneda_detalle;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _ctacte_id;
		private bool _ctacte_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_codigo;
		private string _persona_nombre_completo;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _aplicacion_doc_caso_id;
		private string _caso_nro_comprobante;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private System.DateTime _fecha_postergacion;
		private bool _fecha_postergacionNull = true;
		private decimal _cuota_numero;
		private bool _cuota_numeroNull = true;
		private decimal _cuota_total;
		private bool _cuota_totalNull = true;
		private decimal _saldo_debito;
		private bool _saldo_debitoNull = true;
		private string _cuota;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda_nombre;
		private decimal _moneda_cantidad_decimales;
		private bool _moneda_cantidad_decimalesNull = true;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private string _cadena_decimales;
		private string _moneda_simbolo;
		private decimal _aplicacion_docu_doc_referid_id;
		private bool _aplicacion_docu_doc_referid_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMEN_DOC_INFO_CORow_Base"/> class.
		/// </summary>
		public APLICACION_DOCUMEN_DOC_INFO_CORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(APLICACION_DOCUMEN_DOC_INFO_CORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.APLICACION_DOCUMENTO_ID != original.APLICACION_DOCUMENTO_ID) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.COTIZACION_DETALLE != original.COTIZACION_DETALLE) return true;
			if (this.MONEDA_DETALLE != original.MONEDA_DETALLE) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsCTACTE_IDNull != original.IsCTACTE_IDNull) return true;
			if (!this.IsCTACTE_IDNull && !original.IsCTACTE_IDNull)
				if (this.CTACTE_ID != original.CTACTE_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.APLICACION_DOC_CASO_ID != original.APLICACION_DOC_CASO_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_POSTERGACIONNull != original.IsFECHA_POSTERGACIONNull) return true;
			if (!this.IsFECHA_POSTERGACIONNull && !original.IsFECHA_POSTERGACIONNull)
				if (this.FECHA_POSTERGACION != original.FECHA_POSTERGACION) return true;
			if (this.IsCUOTA_NUMERONull != original.IsCUOTA_NUMERONull) return true;
			if (!this.IsCUOTA_NUMERONull && !original.IsCUOTA_NUMERONull)
				if (this.CUOTA_NUMERO != original.CUOTA_NUMERO) return true;
			if (this.IsCUOTA_TOTALNull != original.IsCUOTA_TOTALNull) return true;
			if (!this.IsCUOTA_TOTALNull && !original.IsCUOTA_TOTALNull)
				if (this.CUOTA_TOTAL != original.CUOTA_TOTAL) return true;
			if (this.IsSALDO_DEBITONull != original.IsSALDO_DEBITONull) return true;
			if (!this.IsSALDO_DEBITONull && !original.IsSALDO_DEBITONull)
				if (this.SALDO_DEBITO != original.SALDO_DEBITO) return true;
			if (this.CUOTA != original.CUOTA) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.IsMONEDA_CANTIDAD_DECIMALESNull != original.IsMONEDA_CANTIDAD_DECIMALESNull) return true;
			if (!this.IsMONEDA_CANTIDAD_DECIMALESNull && !original.IsMONEDA_CANTIDAD_DECIMALESNull)
				if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CADENA_DECIMALES != original.CADENA_DECIMALES) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsAPLICACION_DOCU_DOC_REFERID_IDNull != original.IsAPLICACION_DOCU_DOC_REFERID_IDNull) return true;
			if (!this.IsAPLICACION_DOCU_DOC_REFERID_IDNull && !original.IsAPLICACION_DOCU_DOC_REFERID_IDNull)
				if (this.APLICACION_DOCU_DOC_REFERID_ID != original.APLICACION_DOCU_DOC_REFERID_ID) return true;
			
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
		/// Gets or sets the <c>APLICACION_DOCUMENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTO_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTO_ID
		{
			get { return _aplicacion_documento_id; }
			set { _aplicacion_documento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get { return _monto_origen; }
			set { _monto_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get { return _monto_destino; }
			set { _monto_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_DETALLE</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_DETALLE</c> column value.</value>
		public decimal COTIZACION_DETALLE
		{
			get { return _cotizacion_detalle; }
			set { _cotizacion_detalle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DETALLE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DETALLE</c> column value.</value>
		public decimal MONEDA_DETALLE
		{
			get { return _moneda_detalle; }
			set { _moneda_detalle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_ID</c> column value.</value>
		public decimal CTACTE_ID
		{
			get
			{
				if(IsCTACTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_id;
			}
			set
			{
				_ctacte_idNull = false;
				_ctacte_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_IDNull
		{
			get { return _ctacte_idNull; }
			set { _ctacte_idNull = value; }
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
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOC_CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>APLICACION_DOC_CASO_ID</c> column value.</value>
		public decimal APLICACION_DOC_CASO_ID
		{
			get { return _aplicacion_doc_caso_id; }
			set { _aplicacion_doc_caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_NRO_COMPROBANTE
		{
			get { return _caso_nro_comprobante; }
			set { _caso_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_POSTERGACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_POSTERGACION</c> column value.</value>
		public System.DateTime FECHA_POSTERGACION
		{
			get
			{
				if(IsFECHA_POSTERGACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_postergacion;
			}
			set
			{
				_fecha_postergacionNull = false;
				_fecha_postergacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_POSTERGACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_POSTERGACIONNull
		{
			get { return _fecha_postergacionNull; }
			set { _fecha_postergacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_NUMERO</c> column value.</value>
		public decimal CUOTA_NUMERO
		{
			get
			{
				if(IsCUOTA_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_numero;
			}
			set
			{
				_cuota_numeroNull = false;
				_cuota_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_NUMERONull
		{
			get { return _cuota_numeroNull; }
			set { _cuota_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_TOTAL</c> column value.</value>
		public decimal CUOTA_TOTAL
		{
			get
			{
				if(IsCUOTA_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_total;
			}
			set
			{
				_cuota_totalNull = false;
				_cuota_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_TOTALNull
		{
			get { return _cuota_totalNull; }
			set { _cuota_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_DEBITO</c> column value.</value>
		public decimal SALDO_DEBITO
		{
			get
			{
				if(IsSALDO_DEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_debito;
			}
			set
			{
				_saldo_debitoNull = false;
				_saldo_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_DEBITONull
		{
			get { return _saldo_debitoNull; }
			set { _saldo_debitoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA</c> column value.</value>
		public string CUOTA
		{
			get { return _cuota; }
			set { _cuota = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get
			{
				if(IsMONEDA_CANTIDAD_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cantidad_decimales;
			}
			set
			{
				_moneda_cantidad_decimalesNull = false;
				_moneda_cantidad_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_CANTIDAD_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_CANTIDAD_DECIMALESNull
		{
			get { return _moneda_cantidad_decimalesNull; }
			set { _moneda_cantidad_decimalesNull = value; }
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
		/// Gets or sets the <c>CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CADENA_DECIMALES</c> column value.</value>
		public string CADENA_DECIMALES
		{
			get { return _cadena_decimales; }
			set { _cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</value>
		public decimal APLICACION_DOCU_DOC_REFERID_ID
		{
			get
			{
				if(IsAPLICACION_DOCU_DOC_REFERID_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_docu_doc_referid_id;
			}
			set
			{
				_aplicacion_docu_doc_referid_idNull = false;
				_aplicacion_docu_doc_referid_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCU_DOC_REFERID_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCU_DOC_REFERID_IDNull
		{
			get { return _aplicacion_docu_doc_referid_idNull; }
			set { _aplicacion_docu_doc_referid_idNull = value; }
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
			dynStr.Append("@CBA@APLICACION_DOCUMENTO_ID=");
			dynStr.Append(APLICACION_DOCUMENTO_ID);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			dynStr.Append("@CBA@COTIZACION_DETALLE=");
			dynStr.Append(COTIZACION_DETALLE);
			dynStr.Append("@CBA@MONEDA_DETALLE=");
			dynStr.Append(MONEDA_DETALLE);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_ID=");
			dynStr.Append(IsCTACTE_IDNull ? (object)"<NULL>" : CTACTE_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@APLICACION_DOC_CASO_ID=");
			dynStr.Append(APLICACION_DOC_CASO_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_POSTERGACION=");
			dynStr.Append(IsFECHA_POSTERGACIONNull ? (object)"<NULL>" : FECHA_POSTERGACION);
			dynStr.Append("@CBA@CUOTA_NUMERO=");
			dynStr.Append(IsCUOTA_NUMERONull ? (object)"<NULL>" : CUOTA_NUMERO);
			dynStr.Append("@CBA@CUOTA_TOTAL=");
			dynStr.Append(IsCUOTA_TOTALNull ? (object)"<NULL>" : CUOTA_TOTAL);
			dynStr.Append("@CBA@SALDO_DEBITO=");
			dynStr.Append(IsSALDO_DEBITONull ? (object)"<NULL>" : SALDO_DEBITO);
			dynStr.Append("@CBA@CUOTA=");
			dynStr.Append(CUOTA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(IsMONEDA_CANTIDAD_DECIMALESNull ? (object)"<NULL>" : MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@CADENA_DECIMALES=");
			dynStr.Append(CADENA_DECIMALES);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@APLICACION_DOCU_DOC_REFERID_ID=");
			dynStr.Append(IsAPLICACION_DOCU_DOC_REFERID_IDNull ? (object)"<NULL>" : APLICACION_DOCU_DOC_REFERID_ID);
			return dynStr.ToString();
		}
	} // End of APLICACION_DOCUMEN_DOC_INFO_CORow_Base class
} // End of namespace
