// <fileinfo name="PEDIDOS_PROVEEDOR_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PEDIDOS_PROVEEDOR_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_PROVEEDOR_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito;
		private System.DateTime _fecha_pedido;
		private bool _fecha_pedidoNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _nombre_fantasia;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _autonumeracion;
		private string _nro_comprobante;
		private decimal _condicion_pago_id;
		private bool _condicion_pago_idNull = true;
		private string _condicion_pago;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private string _afecta_linea_credito;
		private string _observacion;
		private string _numero_contrato;
		private decimal _caso_factura_proveedor_id;
		private bool _caso_factura_proveedor_idNull = true;
		private string _invoice;
		private System.DateTime _fecha_invoice;
		private bool _fecha_invoiceNull = true;
		private decimal _estado_documentacion_id;
		private bool _estado_documentacion_idNull = true;
		private string _estado_documento;
		private decimal _tipo_embarque_id;
		private bool _tipo_embarque_idNull = true;
		private string _tipo_embarque;
		private decimal _tipo_contenedor_id;
		private bool _tipo_contenedor_idNull = true;
		private string _tipo_contenedor;
		private decimal _cantidad_contenedores;
		private bool _cantidad_contenedoresNull = true;
		private decimal _total_bruto_pedido;
		private bool _total_bruto_pedidoNull = true;
		private decimal _total_dto_pedido;
		private bool _total_dto_pedidoNull = true;
		private decimal _total_imp_pedido;
		private bool _total_imp_pedidoNull = true;
		private decimal _total_neto_pedido;
		private bool _total_neto_pedidoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PEDIDOS_PROVEEDOR_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PEDIDOS_PROVEEDOR_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL != original.SUCURSAL) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO != original.DEPOSITO) return true;
			if (this.IsFECHA_PEDIDONull != original.IsFECHA_PEDIDONull) return true;
			if (!this.IsFECHA_PEDIDONull && !original.IsFECHA_PEDIDONull)
				if (this.FECHA_PEDIDO != original.FECHA_PEDIDO) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.NOMBRE_FANTASIA != original.NOMBRE_FANTASIA) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION != original.AUTONUMERACION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsCONDICION_PAGO_IDNull != original.IsCONDICION_PAGO_IDNull) return true;
			if (!this.IsCONDICION_PAGO_IDNull && !original.IsCONDICION_PAGO_IDNull)
				if (this.CONDICION_PAGO_ID != original.CONDICION_PAGO_ID) return true;
			if (this.CONDICION_PAGO != original.CONDICION_PAGO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA != original.MONEDA) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.AFECTA_LINEA_CREDITO != original.AFECTA_LINEA_CREDITO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.NUMERO_CONTRATO != original.NUMERO_CONTRATO) return true;
			if (this.IsCASO_FACTURA_PROVEEDOR_IDNull != original.IsCASO_FACTURA_PROVEEDOR_IDNull) return true;
			if (!this.IsCASO_FACTURA_PROVEEDOR_IDNull && !original.IsCASO_FACTURA_PROVEEDOR_IDNull)
				if (this.CASO_FACTURA_PROVEEDOR_ID != original.CASO_FACTURA_PROVEEDOR_ID) return true;
			if (this.INVOICE != original.INVOICE) return true;
			if (this.IsFECHA_INVOICENull != original.IsFECHA_INVOICENull) return true;
			if (!this.IsFECHA_INVOICENull && !original.IsFECHA_INVOICENull)
				if (this.FECHA_INVOICE != original.FECHA_INVOICE) return true;
			if (this.IsESTADO_DOCUMENTACION_IDNull != original.IsESTADO_DOCUMENTACION_IDNull) return true;
			if (!this.IsESTADO_DOCUMENTACION_IDNull && !original.IsESTADO_DOCUMENTACION_IDNull)
				if (this.ESTADO_DOCUMENTACION_ID != original.ESTADO_DOCUMENTACION_ID) return true;
			if (this.ESTADO_DOCUMENTO != original.ESTADO_DOCUMENTO) return true;
			if (this.IsTIPO_EMBARQUE_IDNull != original.IsTIPO_EMBARQUE_IDNull) return true;
			if (!this.IsTIPO_EMBARQUE_IDNull && !original.IsTIPO_EMBARQUE_IDNull)
				if (this.TIPO_EMBARQUE_ID != original.TIPO_EMBARQUE_ID) return true;
			if (this.TIPO_EMBARQUE != original.TIPO_EMBARQUE) return true;
			if (this.IsTIPO_CONTENEDOR_IDNull != original.IsTIPO_CONTENEDOR_IDNull) return true;
			if (!this.IsTIPO_CONTENEDOR_IDNull && !original.IsTIPO_CONTENEDOR_IDNull)
				if (this.TIPO_CONTENEDOR_ID != original.TIPO_CONTENEDOR_ID) return true;
			if (this.TIPO_CONTENEDOR != original.TIPO_CONTENEDOR) return true;
			if (this.IsCANTIDAD_CONTENEDORESNull != original.IsCANTIDAD_CONTENEDORESNull) return true;
			if (!this.IsCANTIDAD_CONTENEDORESNull && !original.IsCANTIDAD_CONTENEDORESNull)
				if (this.CANTIDAD_CONTENEDORES != original.CANTIDAD_CONTENEDORES) return true;
			if (this.IsTOTAL_BRUTO_PEDIDONull != original.IsTOTAL_BRUTO_PEDIDONull) return true;
			if (!this.IsTOTAL_BRUTO_PEDIDONull && !original.IsTOTAL_BRUTO_PEDIDONull)
				if (this.TOTAL_BRUTO_PEDIDO != original.TOTAL_BRUTO_PEDIDO) return true;
			if (this.IsTOTAL_DTO_PEDIDONull != original.IsTOTAL_DTO_PEDIDONull) return true;
			if (!this.IsTOTAL_DTO_PEDIDONull && !original.IsTOTAL_DTO_PEDIDONull)
				if (this.TOTAL_DTO_PEDIDO != original.TOTAL_DTO_PEDIDO) return true;
			if (this.IsTOTAL_IMP_PEDIDONull != original.IsTOTAL_IMP_PEDIDONull) return true;
			if (!this.IsTOTAL_IMP_PEDIDONull && !original.IsTOTAL_IMP_PEDIDONull)
				if (this.TOTAL_IMP_PEDIDO != original.TOTAL_IMP_PEDIDO) return true;
			if (this.IsTOTAL_NETO_PEDIDONull != original.IsTOTAL_NETO_PEDIDONull) return true;
			if (!this.IsTOTAL_NETO_PEDIDONull && !original.IsTOTAL_NETO_PEDIDONull)
				if (this.TOTAL_NETO_PEDIDO != original.TOTAL_NETO_PEDIDO) return true;
			
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
		/// Gets or sets the <c>SUCURSAL</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL</c> column value.</value>
		public string SUCURSAL
		{
			get { return _sucursal; }
			set { _sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO</c> column value.</value>
		public string DEPOSITO
		{
			get { return _deposito; }
			set { _deposito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_PEDIDO</c> column value.</value>
		public System.DateTime FECHA_PEDIDO
		{
			get
			{
				if(IsFECHA_PEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_pedido;
			}
			set
			{
				_fecha_pedidoNull = false;
				_fecha_pedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_PEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_PEDIDONull
		{
			get { return _fecha_pedidoNull; }
			set { _fecha_pedidoNull = value; }
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
		/// Gets or sets the <c>NOMBRE_FANTASIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_FANTASIA</c> column value.</value>
		public string NOMBRE_FANTASIA
		{
			get { return _nombre_fantasia; }
			set { _nombre_fantasia = value; }
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
		/// Gets or sets the <c>AUTONUMERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION</c> column value.</value>
		public string AUTONUMERACION
		{
			get { return _autonumeracion; }
			set { _autonumeracion = value; }
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
		/// Gets or sets the <c>CONDICION_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO_ID</c> column value.</value>
		public decimal CONDICION_PAGO_ID
		{
			get
			{
				if(IsCONDICION_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_pago_id;
			}
			set
			{
				_condicion_pago_idNull = false;
				_condicion_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_PAGO_IDNull
		{
			get { return _condicion_pago_idNull; }
			set { _condicion_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_PAGO</c> column value.</value>
		public string CONDICION_PAGO
		{
			get { return _condicion_pago; }
			set { _condicion_pago = value; }
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
		/// Gets or sets the <c>MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA</c> column value.</value>
		public string MONEDA
		{
			get { return _moneda; }
			set { _moneda = value; }
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
		/// Gets or sets the <c>AFECTA_LINEA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>AFECTA_LINEA_CREDITO</c> column value.</value>
		public string AFECTA_LINEA_CREDITO
		{
			get { return _afecta_linea_credito; }
			set { _afecta_linea_credito = value; }
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
		/// Gets or sets the <c>NUMERO_CONTRATO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CONTRATO</c> column value.</value>
		public string NUMERO_CONTRATO
		{
			get { return _numero_contrato; }
			set { _numero_contrato = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal CASO_FACTURA_PROVEEDOR_ID
		{
			get
			{
				if(IsCASO_FACTURA_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_factura_proveedor_id;
			}
			set
			{
				_caso_factura_proveedor_idNull = false;
				_caso_factura_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_FACTURA_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_FACTURA_PROVEEDOR_IDNull
		{
			get { return _caso_factura_proveedor_idNull; }
			set { _caso_factura_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INVOICE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INVOICE</c> column value.</value>
		public string INVOICE
		{
			get { return _invoice; }
			set { _invoice = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INVOICE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INVOICE</c> column value.</value>
		public System.DateTime FECHA_INVOICE
		{
			get
			{
				if(IsFECHA_INVOICENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_invoice;
			}
			set
			{
				_fecha_invoiceNull = false;
				_fecha_invoice = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INVOICE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INVOICENull
		{
			get { return _fecha_invoiceNull; }
			set { _fecha_invoiceNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DOCUMENTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DOCUMENTACION_ID</c> column value.</value>
		public decimal ESTADO_DOCUMENTACION_ID
		{
			get
			{
				if(IsESTADO_DOCUMENTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estado_documentacion_id;
			}
			set
			{
				_estado_documentacion_idNull = false;
				_estado_documentacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTADO_DOCUMENTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTADO_DOCUMENTACION_IDNull
		{
			get { return _estado_documentacion_idNull; }
			set { _estado_documentacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DOCUMENTO</c> column value.</value>
		public string ESTADO_DOCUMENTO
		{
			get { return _estado_documento; }
			set { _estado_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EMBARQUE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EMBARQUE_ID</c> column value.</value>
		public decimal TIPO_EMBARQUE_ID
		{
			get
			{
				if(IsTIPO_EMBARQUE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_embarque_id;
			}
			set
			{
				_tipo_embarque_idNull = false;
				_tipo_embarque_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_EMBARQUE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_EMBARQUE_IDNull
		{
			get { return _tipo_embarque_idNull; }
			set { _tipo_embarque_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EMBARQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EMBARQUE</c> column value.</value>
		public string TIPO_EMBARQUE
		{
			get { return _tipo_embarque; }
			set { _tipo_embarque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR_ID</c> column value.</value>
		public decimal TIPO_CONTENEDOR_ID
		{
			get
			{
				if(IsTIPO_CONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_contenedor_id;
			}
			set
			{
				_tipo_contenedor_idNull = false;
				_tipo_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CONTENEDOR_IDNull
		{
			get { return _tipo_contenedor_idNull; }
			set { _tipo_contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONTENEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CONTENEDOR</c> column value.</value>
		public string TIPO_CONTENEDOR
		{
			get { return _tipo_contenedor; }
			set { _tipo_contenedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CONTENEDORES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_CONTENEDORES</c> column value.</value>
		public decimal CANTIDAD_CONTENEDORES
		{
			get
			{
				if(IsCANTIDAD_CONTENEDORESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_contenedores;
			}
			set
			{
				_cantidad_contenedoresNull = false;
				_cantidad_contenedores = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_CONTENEDORES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_CONTENEDORESNull
		{
			get { return _cantidad_contenedoresNull; }
			set { _cantidad_contenedoresNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BRUTO_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_BRUTO_PEDIDO</c> column value.</value>
		public decimal TOTAL_BRUTO_PEDIDO
		{
			get
			{
				if(IsTOTAL_BRUTO_PEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_bruto_pedido;
			}
			set
			{
				_total_bruto_pedidoNull = false;
				_total_bruto_pedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_BRUTO_PEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_BRUTO_PEDIDONull
		{
			get { return _total_bruto_pedidoNull; }
			set { _total_bruto_pedidoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DTO_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DTO_PEDIDO</c> column value.</value>
		public decimal TOTAL_DTO_PEDIDO
		{
			get
			{
				if(IsTOTAL_DTO_PEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_dto_pedido;
			}
			set
			{
				_total_dto_pedidoNull = false;
				_total_dto_pedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DTO_PEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DTO_PEDIDONull
		{
			get { return _total_dto_pedidoNull; }
			set { _total_dto_pedidoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMP_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMP_PEDIDO</c> column value.</value>
		public decimal TOTAL_IMP_PEDIDO
		{
			get
			{
				if(IsTOTAL_IMP_PEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_imp_pedido;
			}
			set
			{
				_total_imp_pedidoNull = false;
				_total_imp_pedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMP_PEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMP_PEDIDONull
		{
			get { return _total_imp_pedidoNull; }
			set { _total_imp_pedidoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_NETO_PEDIDO</c> column value.</value>
		public decimal TOTAL_NETO_PEDIDO
		{
			get
			{
				if(IsTOTAL_NETO_PEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_neto_pedido;
			}
			set
			{
				_total_neto_pedidoNull = false;
				_total_neto_pedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_NETO_PEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_NETO_PEDIDONull
		{
			get { return _total_neto_pedidoNull; }
			set { _total_neto_pedidoNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL=");
			dynStr.Append(SUCURSAL);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO=");
			dynStr.Append(DEPOSITO);
			dynStr.Append("@CBA@FECHA_PEDIDO=");
			dynStr.Append(IsFECHA_PEDIDONull ? (object)"<NULL>" : FECHA_PEDIDO);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@NOMBRE_FANTASIA=");
			dynStr.Append(NOMBRE_FANTASIA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION=");
			dynStr.Append(AUTONUMERACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@CONDICION_PAGO_ID=");
			dynStr.Append(IsCONDICION_PAGO_IDNull ? (object)"<NULL>" : CONDICION_PAGO_ID);
			dynStr.Append("@CBA@CONDICION_PAGO=");
			dynStr.Append(CONDICION_PAGO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA=");
			dynStr.Append(MONEDA);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@AFECTA_LINEA_CREDITO=");
			dynStr.Append(AFECTA_LINEA_CREDITO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NUMERO_CONTRATO=");
			dynStr.Append(NUMERO_CONTRATO);
			dynStr.Append("@CBA@CASO_FACTURA_PROVEEDOR_ID=");
			dynStr.Append(IsCASO_FACTURA_PROVEEDOR_IDNull ? (object)"<NULL>" : CASO_FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@INVOICE=");
			dynStr.Append(INVOICE);
			dynStr.Append("@CBA@FECHA_INVOICE=");
			dynStr.Append(IsFECHA_INVOICENull ? (object)"<NULL>" : FECHA_INVOICE);
			dynStr.Append("@CBA@ESTADO_DOCUMENTACION_ID=");
			dynStr.Append(IsESTADO_DOCUMENTACION_IDNull ? (object)"<NULL>" : ESTADO_DOCUMENTACION_ID);
			dynStr.Append("@CBA@ESTADO_DOCUMENTO=");
			dynStr.Append(ESTADO_DOCUMENTO);
			dynStr.Append("@CBA@TIPO_EMBARQUE_ID=");
			dynStr.Append(IsTIPO_EMBARQUE_IDNull ? (object)"<NULL>" : TIPO_EMBARQUE_ID);
			dynStr.Append("@CBA@TIPO_EMBARQUE=");
			dynStr.Append(TIPO_EMBARQUE);
			dynStr.Append("@CBA@TIPO_CONTENEDOR_ID=");
			dynStr.Append(IsTIPO_CONTENEDOR_IDNull ? (object)"<NULL>" : TIPO_CONTENEDOR_ID);
			dynStr.Append("@CBA@TIPO_CONTENEDOR=");
			dynStr.Append(TIPO_CONTENEDOR);
			dynStr.Append("@CBA@CANTIDAD_CONTENEDORES=");
			dynStr.Append(IsCANTIDAD_CONTENEDORESNull ? (object)"<NULL>" : CANTIDAD_CONTENEDORES);
			dynStr.Append("@CBA@TOTAL_BRUTO_PEDIDO=");
			dynStr.Append(IsTOTAL_BRUTO_PEDIDONull ? (object)"<NULL>" : TOTAL_BRUTO_PEDIDO);
			dynStr.Append("@CBA@TOTAL_DTO_PEDIDO=");
			dynStr.Append(IsTOTAL_DTO_PEDIDONull ? (object)"<NULL>" : TOTAL_DTO_PEDIDO);
			dynStr.Append("@CBA@TOTAL_IMP_PEDIDO=");
			dynStr.Append(IsTOTAL_IMP_PEDIDONull ? (object)"<NULL>" : TOTAL_IMP_PEDIDO);
			dynStr.Append("@CBA@TOTAL_NETO_PEDIDO=");
			dynStr.Append(IsTOTAL_NETO_PEDIDONull ? (object)"<NULL>" : TOTAL_NETO_PEDIDO);
			return dynStr.ToString();
		}
	} // End of PEDIDOS_PROVEEDOR_INFO_COMPLRow_Base class
} // End of namespace
