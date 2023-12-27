// <fileinfo name="TRANSACCIONESRow_Base.cs">
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
	/// The base class for <see cref="TRANSACCIONESRow"/> that 
	/// represents a record in the <c>TRANSACCIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSACCIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSACCIONESRow_Base
	{
		private decimal _id;
		private decimal _id_externo;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _ctacte_red_pago_id;
		private bool _ctacte_red_pago_idNull = true;
		private string _nro_transaccion;
		private string _nro_comprobante;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_id;
		private System.DateTime _fecha_transaccion;
		private bool _fecha_transaccionNull = true;
		private System.DateTime _fecha_acreditacion;
		private bool _fecha_acreditacionNull = true;
		private System.DateTime _fecha_anulacion;
		private bool _fecha_anulacionNull = true;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _monto_total;
		private bool _monto_totalNull = true;
		private decimal _monto_capital;
		private bool _monto_capitalNull = true;
		private decimal _monto_intereses;
		private bool _monto_interesesNull = true;
		private decimal _monto_gasto_administrativo;
		private bool _monto_gasto_administrativoNull = true;
		private decimal _comision_total;
		private bool _comision_totalNull = true;
		private decimal _comision_recaudador;
		private bool _comision_recaudadorNull = true;
		private decimal _comision_procesador;
		private bool _comision_procesadorNull = true;
		private decimal _comision_clearing;
		private bool _comision_clearingNull = true;
		private decimal _comision_otro;
		private bool _comision_otroNull = true;
		private string _procesado;
		private string _anulado;
		private string _estado;
		private string _json;
		private decimal _transaccion_cierre_id;
		private bool _transaccion_cierre_idNull = true;
		private decimal _comision_red;
		private bool _comision_redNull = true;
		private System.DateTime _fecha_corte;
		private bool _fecha_corteNull = true;
		private decimal _ctacte_banco_clearing_id;
		private bool _ctacte_banco_clearing_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONESRow_Base"/> class.
		/// </summary>
		public TRANSACCIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSACCIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ID_EXTERNO != original.ID_EXTERNO) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsCTACTE_RED_PAGO_IDNull != original.IsCTACTE_RED_PAGO_IDNull) return true;
			if (!this.IsCTACTE_RED_PAGO_IDNull && !original.IsCTACTE_RED_PAGO_IDNull)
				if (this.CTACTE_RED_PAGO_ID != original.CTACTE_RED_PAGO_ID) return true;
			if (this.NRO_TRANSACCION != original.NRO_TRANSACCION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsFECHA_TRANSACCIONNull != original.IsFECHA_TRANSACCIONNull) return true;
			if (!this.IsFECHA_TRANSACCIONNull && !original.IsFECHA_TRANSACCIONNull)
				if (this.FECHA_TRANSACCION != original.FECHA_TRANSACCION) return true;
			if (this.IsFECHA_ACREDITACIONNull != original.IsFECHA_ACREDITACIONNull) return true;
			if (!this.IsFECHA_ACREDITACIONNull && !original.IsFECHA_ACREDITACIONNull)
				if (this.FECHA_ACREDITACION != original.FECHA_ACREDITACION) return true;
			if (this.IsFECHA_ANULACIONNull != original.IsFECHA_ANULACIONNull) return true;
			if (!this.IsFECHA_ANULACIONNull && !original.IsFECHA_ANULACIONNull)
				if (this.FECHA_ANULACION != original.FECHA_ANULACION) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsMONTO_TOTALNull != original.IsMONTO_TOTALNull) return true;
			if (!this.IsMONTO_TOTALNull && !original.IsMONTO_TOTALNull)
				if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.IsMONTO_CAPITALNull != original.IsMONTO_CAPITALNull) return true;
			if (!this.IsMONTO_CAPITALNull && !original.IsMONTO_CAPITALNull)
				if (this.MONTO_CAPITAL != original.MONTO_CAPITAL) return true;
			if (this.IsMONTO_INTERESESNull != original.IsMONTO_INTERESESNull) return true;
			if (!this.IsMONTO_INTERESESNull && !original.IsMONTO_INTERESESNull)
				if (this.MONTO_INTERESES != original.MONTO_INTERESES) return true;
			if (this.IsMONTO_GASTO_ADMINISTRATIVONull != original.IsMONTO_GASTO_ADMINISTRATIVONull) return true;
			if (!this.IsMONTO_GASTO_ADMINISTRATIVONull && !original.IsMONTO_GASTO_ADMINISTRATIVONull)
				if (this.MONTO_GASTO_ADMINISTRATIVO != original.MONTO_GASTO_ADMINISTRATIVO) return true;
			if (this.IsCOMISION_TOTALNull != original.IsCOMISION_TOTALNull) return true;
			if (!this.IsCOMISION_TOTALNull && !original.IsCOMISION_TOTALNull)
				if (this.COMISION_TOTAL != original.COMISION_TOTAL) return true;
			if (this.IsCOMISION_RECAUDADORNull != original.IsCOMISION_RECAUDADORNull) return true;
			if (!this.IsCOMISION_RECAUDADORNull && !original.IsCOMISION_RECAUDADORNull)
				if (this.COMISION_RECAUDADOR != original.COMISION_RECAUDADOR) return true;
			if (this.IsCOMISION_PROCESADORNull != original.IsCOMISION_PROCESADORNull) return true;
			if (!this.IsCOMISION_PROCESADORNull && !original.IsCOMISION_PROCESADORNull)
				if (this.COMISION_PROCESADOR != original.COMISION_PROCESADOR) return true;
			if (this.IsCOMISION_CLEARINGNull != original.IsCOMISION_CLEARINGNull) return true;
			if (!this.IsCOMISION_CLEARINGNull && !original.IsCOMISION_CLEARINGNull)
				if (this.COMISION_CLEARING != original.COMISION_CLEARING) return true;
			if (this.IsCOMISION_OTRONull != original.IsCOMISION_OTRONull) return true;
			if (!this.IsCOMISION_OTRONull && !original.IsCOMISION_OTRONull)
				if (this.COMISION_OTRO != original.COMISION_OTRO) return true;
			if (this.PROCESADO != original.PROCESADO) return true;
			if (this.ANULADO != original.ANULADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.JSON != original.JSON) return true;
			if (this.IsTRANSACCION_CIERRE_IDNull != original.IsTRANSACCION_CIERRE_IDNull) return true;
			if (!this.IsTRANSACCION_CIERRE_IDNull && !original.IsTRANSACCION_CIERRE_IDNull)
				if (this.TRANSACCION_CIERRE_ID != original.TRANSACCION_CIERRE_ID) return true;
			if (this.IsCOMISION_REDNull != original.IsCOMISION_REDNull) return true;
			if (!this.IsCOMISION_REDNull && !original.IsCOMISION_REDNull)
				if (this.COMISION_RED != original.COMISION_RED) return true;
			if (this.IsFECHA_CORTENull != original.IsFECHA_CORTENull) return true;
			if (!this.IsFECHA_CORTENull && !original.IsFECHA_CORTENull)
				if (this.FECHA_CORTE != original.FECHA_CORTE) return true;
			if (this.IsCTACTE_BANCO_CLEARING_IDNull != original.IsCTACTE_BANCO_CLEARING_IDNull) return true;
			if (!this.IsCTACTE_BANCO_CLEARING_IDNull && !original.IsCTACTE_BANCO_CLEARING_IDNull)
				if (this.CTACTE_BANCO_CLEARING_ID != original.CTACTE_BANCO_CLEARING_ID) return true;
			
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
		/// Gets or sets the <c>ID_EXTERNO</c> column value.
		/// </summary>
		/// <value>The <c>ID_EXTERNO</c> column value.</value>
		public decimal ID_EXTERNO
		{
			get { return _id_externo; }
			set { _id_externo = value; }
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
		/// Gets or sets the <c>CTACTE_RED_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RED_PAGO_ID</c> column value.</value>
		public decimal CTACTE_RED_PAGO_ID
		{
			get
			{
				if(IsCTACTE_RED_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_red_pago_id;
			}
			set
			{
				_ctacte_red_pago_idNull = false;
				_ctacte_red_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RED_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RED_PAGO_IDNull
		{
			get { return _ctacte_red_pago_idNull; }
			set { _ctacte_red_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_TRANSACCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_TRANSACCION</c> column value.</value>
		public string NRO_TRANSACCION
		{
			get { return _nro_transaccion; }
			set { _nro_transaccion = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_TRANSACCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_TRANSACCION</c> column value.</value>
		public System.DateTime FECHA_TRANSACCION
		{
			get
			{
				if(IsFECHA_TRANSACCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_transaccion;
			}
			set
			{
				_fecha_transaccionNull = false;
				_fecha_transaccion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_TRANSACCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_TRANSACCIONNull
		{
			get { return _fecha_transaccionNull; }
			set { _fecha_transaccionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ACREDITACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ACREDITACION</c> column value.</value>
		public System.DateTime FECHA_ACREDITACION
		{
			get
			{
				if(IsFECHA_ACREDITACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_acreditacion;
			}
			set
			{
				_fecha_acreditacionNull = false;
				_fecha_acreditacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ACREDITACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ACREDITACIONNull
		{
			get { return _fecha_acreditacionNull; }
			set { _fecha_acreditacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ANULACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ANULACION</c> column value.</value>
		public System.DateTime FECHA_ANULACION
		{
			get
			{
				if(IsFECHA_ANULACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_anulacion;
			}
			set
			{
				_fecha_anulacionNull = false;
				_fecha_anulacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ANULACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ANULACIONNull
		{
			get { return _fecha_anulacionNull; }
			set { _fecha_anulacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get
			{
				if(IsCTACTE_VALOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_valor_id;
			}
			set
			{
				_ctacte_valor_idNull = false;
				_ctacte_valor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_VALOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_VALOR_IDNull
		{
			get { return _ctacte_valor_idNull; }
			set { _ctacte_valor_idNull = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get
			{
				if(IsMONTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total;
			}
			set
			{
				_monto_totalNull = false;
				_monto_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTALNull
		{
			get { return _monto_totalNull; }
			set { _monto_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CAPITAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL</c> column value.</value>
		public decimal MONTO_CAPITAL
		{
			get
			{
				if(IsMONTO_CAPITALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_capital;
			}
			set
			{
				_monto_capitalNull = false;
				_monto_capital = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CAPITAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CAPITALNull
		{
			get { return _monto_capitalNull; }
			set { _monto_capitalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INTERESES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_INTERESES</c> column value.</value>
		public decimal MONTO_INTERESES
		{
			get
			{
				if(IsMONTO_INTERESESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_intereses;
			}
			set
			{
				_monto_interesesNull = false;
				_monto_intereses = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_INTERESES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_INTERESESNull
		{
			get { return _monto_interesesNull; }
			set { _monto_interesesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_GASTO_ADMINISTRATIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_GASTO_ADMINISTRATIVO</c> column value.</value>
		public decimal MONTO_GASTO_ADMINISTRATIVO
		{
			get
			{
				if(IsMONTO_GASTO_ADMINISTRATIVONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_gasto_administrativo;
			}
			set
			{
				_monto_gasto_administrativoNull = false;
				_monto_gasto_administrativo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_GASTO_ADMINISTRATIVO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_GASTO_ADMINISTRATIVONull
		{
			get { return _monto_gasto_administrativoNull; }
			set { _monto_gasto_administrativoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_TOTAL</c> column value.</value>
		public decimal COMISION_TOTAL
		{
			get
			{
				if(IsCOMISION_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_total;
			}
			set
			{
				_comision_totalNull = false;
				_comision_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_TOTALNull
		{
			get { return _comision_totalNull; }
			set { _comision_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_RECAUDADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_RECAUDADOR</c> column value.</value>
		public decimal COMISION_RECAUDADOR
		{
			get
			{
				if(IsCOMISION_RECAUDADORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_recaudador;
			}
			set
			{
				_comision_recaudadorNull = false;
				_comision_recaudador = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_RECAUDADOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_RECAUDADORNull
		{
			get { return _comision_recaudadorNull; }
			set { _comision_recaudadorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_PROCESADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_PROCESADOR</c> column value.</value>
		public decimal COMISION_PROCESADOR
		{
			get
			{
				if(IsCOMISION_PROCESADORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_procesador;
			}
			set
			{
				_comision_procesadorNull = false;
				_comision_procesador = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_PROCESADOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_PROCESADORNull
		{
			get { return _comision_procesadorNull; }
			set { _comision_procesadorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_CLEARING</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_CLEARING</c> column value.</value>
		public decimal COMISION_CLEARING
		{
			get
			{
				if(IsCOMISION_CLEARINGNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_clearing;
			}
			set
			{
				_comision_clearingNull = false;
				_comision_clearing = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_CLEARING"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_CLEARINGNull
		{
			get { return _comision_clearingNull; }
			set { _comision_clearingNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_OTRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_OTRO</c> column value.</value>
		public decimal COMISION_OTRO
		{
			get
			{
				if(IsCOMISION_OTRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_otro;
			}
			set
			{
				_comision_otroNull = false;
				_comision_otro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_OTRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_OTRONull
		{
			get { return _comision_otroNull; }
			set { _comision_otroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADO</c> column value.
		/// </summary>
		/// <value>The <c>PROCESADO</c> column value.</value>
		public string PROCESADO
		{
			get { return _procesado; }
			set { _procesado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANULADO</c> column value.
		/// </summary>
		/// <value>The <c>ANULADO</c> column value.</value>
		public string ANULADO
		{
			get { return _anulado; }
			set { _anulado = value; }
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
		/// Gets or sets the <c>JSON</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>JSON</c> column value.</value>
		public string JSON
		{
			get { return _json; }
			set { _json = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSACCION_CIERRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSACCION_CIERRE_ID</c> column value.</value>
		public decimal TRANSACCION_CIERRE_ID
		{
			get
			{
				if(IsTRANSACCION_CIERRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transaccion_cierre_id;
			}
			set
			{
				_transaccion_cierre_idNull = false;
				_transaccion_cierre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSACCION_CIERRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSACCION_CIERRE_IDNull
		{
			get { return _transaccion_cierre_idNull; }
			set { _transaccion_cierre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_RED</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_RED</c> column value.</value>
		public decimal COMISION_RED
		{
			get
			{
				if(IsCOMISION_REDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_red;
			}
			set
			{
				_comision_redNull = false;
				_comision_red = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_RED"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_REDNull
		{
			get { return _comision_redNull; }
			set { _comision_redNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CORTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CORTE</c> column value.</value>
		public System.DateTime FECHA_CORTE
		{
			get
			{
				if(IsFECHA_CORTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_corte;
			}
			set
			{
				_fecha_corteNull = false;
				_fecha_corte = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CORTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CORTENull
		{
			get { return _fecha_corteNull; }
			set { _fecha_corteNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_CLEARING_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</value>
		public decimal CTACTE_BANCO_CLEARING_ID
		{
			get
			{
				if(IsCTACTE_BANCO_CLEARING_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banco_clearing_id;
			}
			set
			{
				_ctacte_banco_clearing_idNull = false;
				_ctacte_banco_clearing_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCO_CLEARING_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCO_CLEARING_IDNull
		{
			get { return _ctacte_banco_clearing_idNull; }
			set { _ctacte_banco_clearing_idNull = value; }
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
			dynStr.Append("@CBA@ID_EXTERNO=");
			dynStr.Append(ID_EXTERNO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@CTACTE_RED_PAGO_ID=");
			dynStr.Append(IsCTACTE_RED_PAGO_IDNull ? (object)"<NULL>" : CTACTE_RED_PAGO_ID);
			dynStr.Append("@CBA@NRO_TRANSACCION=");
			dynStr.Append(NRO_TRANSACCION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@FECHA_TRANSACCION=");
			dynStr.Append(IsFECHA_TRANSACCIONNull ? (object)"<NULL>" : FECHA_TRANSACCION);
			dynStr.Append("@CBA@FECHA_ACREDITACION=");
			dynStr.Append(IsFECHA_ACREDITACIONNull ? (object)"<NULL>" : FECHA_ACREDITACION);
			dynStr.Append("@CBA@FECHA_ANULACION=");
			dynStr.Append(IsFECHA_ANULACIONNull ? (object)"<NULL>" : FECHA_ANULACION);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(IsMONTO_TOTALNull ? (object)"<NULL>" : MONTO_TOTAL);
			dynStr.Append("@CBA@MONTO_CAPITAL=");
			dynStr.Append(IsMONTO_CAPITALNull ? (object)"<NULL>" : MONTO_CAPITAL);
			dynStr.Append("@CBA@MONTO_INTERESES=");
			dynStr.Append(IsMONTO_INTERESESNull ? (object)"<NULL>" : MONTO_INTERESES);
			dynStr.Append("@CBA@MONTO_GASTO_ADMINISTRATIVO=");
			dynStr.Append(IsMONTO_GASTO_ADMINISTRATIVONull ? (object)"<NULL>" : MONTO_GASTO_ADMINISTRATIVO);
			dynStr.Append("@CBA@COMISION_TOTAL=");
			dynStr.Append(IsCOMISION_TOTALNull ? (object)"<NULL>" : COMISION_TOTAL);
			dynStr.Append("@CBA@COMISION_RECAUDADOR=");
			dynStr.Append(IsCOMISION_RECAUDADORNull ? (object)"<NULL>" : COMISION_RECAUDADOR);
			dynStr.Append("@CBA@COMISION_PROCESADOR=");
			dynStr.Append(IsCOMISION_PROCESADORNull ? (object)"<NULL>" : COMISION_PROCESADOR);
			dynStr.Append("@CBA@COMISION_CLEARING=");
			dynStr.Append(IsCOMISION_CLEARINGNull ? (object)"<NULL>" : COMISION_CLEARING);
			dynStr.Append("@CBA@COMISION_OTRO=");
			dynStr.Append(IsCOMISION_OTRONull ? (object)"<NULL>" : COMISION_OTRO);
			dynStr.Append("@CBA@PROCESADO=");
			dynStr.Append(PROCESADO);
			dynStr.Append("@CBA@ANULADO=");
			dynStr.Append(ANULADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@JSON=");
			dynStr.Append(JSON);
			dynStr.Append("@CBA@TRANSACCION_CIERRE_ID=");
			dynStr.Append(IsTRANSACCION_CIERRE_IDNull ? (object)"<NULL>" : TRANSACCION_CIERRE_ID);
			dynStr.Append("@CBA@COMISION_RED=");
			dynStr.Append(IsCOMISION_REDNull ? (object)"<NULL>" : COMISION_RED);
			dynStr.Append("@CBA@FECHA_CORTE=");
			dynStr.Append(IsFECHA_CORTENull ? (object)"<NULL>" : FECHA_CORTE);
			dynStr.Append("@CBA@CTACTE_BANCO_CLEARING_ID=");
			dynStr.Append(IsCTACTE_BANCO_CLEARING_IDNull ? (object)"<NULL>" : CTACTE_BANCO_CLEARING_ID);
			return dynStr.ToString();
		}
	} // End of TRANSACCIONESRow_Base class
} // End of namespace
