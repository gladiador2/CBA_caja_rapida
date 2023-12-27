// <fileinfo name="TRANSFERENCIAS_BANCARIAS_INF_CRow_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> that 
	/// represents a record in the <c>TRANSFERENCIAS_BANCARIAS_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIAS_BANCARIAS_INF_CRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private System.DateTime _fecha;
		private string _nro_solicitud;
		private string _cuenta_origen_administrada;
		private string _cuenta_destino_administrada;
		private string _cuenta_origen_terceros;
		private string _cuenta_destino_terceros;
		private decimal _sucursal_origen_id;
		private bool _sucursal_origen_idNull = true;
		private decimal _ctacte_banc_terceros_origen_id;
		private bool _ctacte_banc_terceros_origen_idNull = true;
		private decimal _ctacte_banc_terceros_dest_id;
		private bool _ctacte_banc_terceros_dest_idNull = true;
		private string _sucursal_origen_nombre;
		private decimal _ctacte_banco_origen_id;
		private string _ctacte_banco_origen_nombre;
		private string _ctacte_banco_origen_abrev;
		private decimal _ctacte_bancaria_origen_id;
		private bool _ctacte_bancaria_origen_idNull = true;
		private string _numero_cuenta_origen;
		private decimal _moneda_origen_id;
		private string _moneda_origen_nombre;
		private string _moneda_origen_simbolo;
		private decimal _cotizacion_moneda_origen;
		private decimal _monto_origen;
		private decimal _costo_transferencia;
		private decimal _sucursal_destino_id;
		private bool _sucursal_destino_idNull = true;
		private string _sucursal_destino_nombre;
		private decimal _ctacte_banco_destino_id;
		private decimal _ctacte_bancaria_destino_id;
		private bool _ctacte_bancaria_destino_idNull = true;
		private string _ctacte_banco_destino_nombre;
		private string _ctacte_banco_destino_abrev;
		private string _numero_cuenta_destino;
		private decimal _moneda_destino_id;
		private string _moneda_destino_nombre;
		private string _moneda_destino_simbolo;
		private decimal _cotizacion_moneda_destino;
		private decimal _monto_destino;
		private string _numero_transaccion;
		private decimal _persona_origen_id;
		private bool _persona_origen_idNull = true;
		private decimal _proveedor_origen_id;
		private bool _proveedor_origen_idNull = true;
		private decimal _funcionario_origen_id;
		private bool _funcionario_origen_idNull = true;
		private decimal _persona_destino_id;
		private bool _persona_destino_idNull = true;
		private decimal _proveedor_destino_id;
		private bool _proveedor_destino_idNull = true;
		private decimal _funcionario_destino_id;
		private bool _funcionario_destino_idNull = true;
		private decimal _orden_pago_respalda_caso_id;
		private bool _orden_pago_respalda_caso_idNull = true;
		private string _orden_pago_utiliza_caso_id;
		private decimal _anticipo_prov_utiliza_caso_id;
		private bool _anticipo_prov_utiliza_caso_idNull = true;
		private string _observacion;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _cg_autonumeracion_id;
		private bool _cg_autonumeracion_idNull = true;
		private string _cg_numero_cheque;
		private System.DateTime _cg_fecha_emision;
		private bool _cg_fecha_emisionNull = true;
		private System.DateTime _cg_fecha_vencimiento;
		private bool _cg_fecha_vencimientoNull = true;
		private string _cg_nombre_emisor;
		private string _cg_nombre_beneficiario;
		private string _cg_usar_chequera;
		private decimal _cg_cheque_girado_id;
		private bool _cg_cheque_girado_idNull = true;
		private string _cg_es_diferido;
		private string _persona_origen_nombre;
		private string _proveedor_origen_nombre;
		private string _funcionario_origen_nombre;
		private string _persona_destino_nombre;
		private string _proveedor_destino_nombre;
		private string _funcionario_destino_nombre;
		private string _es_cotizacion_directa;
		private decimal _moneda_cot_directa_id;
		private bool _moneda_cot_directa_idNull = true;
		private string _moneda_directa_nombre;
		private string _moneda_directa_simbolo;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow_Base"/> class.
		/// </summary>
		public TRANSFERENCIAS_BANCARIAS_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSFERENCIAS_BANCARIAS_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.NRO_SOLICITUD != original.NRO_SOLICITUD) return true;
			if (this.CUENTA_ORIGEN_ADMINISTRADA != original.CUENTA_ORIGEN_ADMINISTRADA) return true;
			if (this.CUENTA_DESTINO_ADMINISTRADA != original.CUENTA_DESTINO_ADMINISTRADA) return true;
			if (this.CUENTA_ORIGEN_TERCEROS != original.CUENTA_ORIGEN_TERCEROS) return true;
			if (this.CUENTA_DESTINO_TERCEROS != original.CUENTA_DESTINO_TERCEROS) return true;
			if (this.IsSUCURSAL_ORIGEN_IDNull != original.IsSUCURSAL_ORIGEN_IDNull) return true;
			if (!this.IsSUCURSAL_ORIGEN_IDNull && !original.IsSUCURSAL_ORIGEN_IDNull)
				if (this.SUCURSAL_ORIGEN_ID != original.SUCURSAL_ORIGEN_ID) return true;
			if (this.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull != original.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull) return true;
			if (!this.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull && !original.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull)
				if (this.CTACTE_BANC_TERCEROS_ORIGEN_ID != original.CTACTE_BANC_TERCEROS_ORIGEN_ID) return true;
			if (this.IsCTACTE_BANC_TERCEROS_DEST_IDNull != original.IsCTACTE_BANC_TERCEROS_DEST_IDNull) return true;
			if (!this.IsCTACTE_BANC_TERCEROS_DEST_IDNull && !original.IsCTACTE_BANC_TERCEROS_DEST_IDNull)
				if (this.CTACTE_BANC_TERCEROS_DEST_ID != original.CTACTE_BANC_TERCEROS_DEST_ID) return true;
			if (this.SUCURSAL_ORIGEN_NOMBRE != original.SUCURSAL_ORIGEN_NOMBRE) return true;
			if (this.CTACTE_BANCO_ORIGEN_ID != original.CTACTE_BANCO_ORIGEN_ID) return true;
			if (this.CTACTE_BANCO_ORIGEN_NOMBRE != original.CTACTE_BANCO_ORIGEN_NOMBRE) return true;
			if (this.CTACTE_BANCO_ORIGEN_ABREV != original.CTACTE_BANCO_ORIGEN_ABREV) return true;
			if (this.IsCTACTE_BANCARIA_ORIGEN_IDNull != original.IsCTACTE_BANCARIA_ORIGEN_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_ORIGEN_IDNull && !original.IsCTACTE_BANCARIA_ORIGEN_IDNull)
				if (this.CTACTE_BANCARIA_ORIGEN_ID != original.CTACTE_BANCARIA_ORIGEN_ID) return true;
			if (this.NUMERO_CUENTA_ORIGEN != original.NUMERO_CUENTA_ORIGEN) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.MONEDA_ORIGEN_NOMBRE != original.MONEDA_ORIGEN_NOMBRE) return true;
			if (this.MONEDA_ORIGEN_SIMBOLO != original.MONEDA_ORIGEN_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.COSTO_TRANSFERENCIA != original.COSTO_TRANSFERENCIA) return true;
			if (this.IsSUCURSAL_DESTINO_IDNull != original.IsSUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_IDNull && !original.IsSUCURSAL_DESTINO_IDNull)
				if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.SUCURSAL_DESTINO_NOMBRE != original.SUCURSAL_DESTINO_NOMBRE) return true;
			if (this.CTACTE_BANCO_DESTINO_ID != original.CTACTE_BANCO_DESTINO_ID) return true;
			if (this.IsCTACTE_BANCARIA_DESTINO_IDNull != original.IsCTACTE_BANCARIA_DESTINO_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_DESTINO_IDNull && !original.IsCTACTE_BANCARIA_DESTINO_IDNull)
				if (this.CTACTE_BANCARIA_DESTINO_ID != original.CTACTE_BANCARIA_DESTINO_ID) return true;
			if (this.CTACTE_BANCO_DESTINO_NOMBRE != original.CTACTE_BANCO_DESTINO_NOMBRE) return true;
			if (this.CTACTE_BANCO_DESTINO_ABREV != original.CTACTE_BANCO_DESTINO_ABREV) return true;
			if (this.NUMERO_CUENTA_DESTINO != original.NUMERO_CUENTA_DESTINO) return true;
			if (this.MONEDA_DESTINO_ID != original.MONEDA_DESTINO_ID) return true;
			if (this.MONEDA_DESTINO_NOMBRE != original.MONEDA_DESTINO_NOMBRE) return true;
			if (this.MONEDA_DESTINO_SIMBOLO != original.MONEDA_DESTINO_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA_DESTINO != original.COTIZACION_MONEDA_DESTINO) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.NUMERO_TRANSACCION != original.NUMERO_TRANSACCION) return true;
			if (this.IsPERSONA_ORIGEN_IDNull != original.IsPERSONA_ORIGEN_IDNull) return true;
			if (!this.IsPERSONA_ORIGEN_IDNull && !original.IsPERSONA_ORIGEN_IDNull)
				if (this.PERSONA_ORIGEN_ID != original.PERSONA_ORIGEN_ID) return true;
			if (this.IsPROVEEDOR_ORIGEN_IDNull != original.IsPROVEEDOR_ORIGEN_IDNull) return true;
			if (!this.IsPROVEEDOR_ORIGEN_IDNull && !original.IsPROVEEDOR_ORIGEN_IDNull)
				if (this.PROVEEDOR_ORIGEN_ID != original.PROVEEDOR_ORIGEN_ID) return true;
			if (this.IsFUNCIONARIO_ORIGEN_IDNull != original.IsFUNCIONARIO_ORIGEN_IDNull) return true;
			if (!this.IsFUNCIONARIO_ORIGEN_IDNull && !original.IsFUNCIONARIO_ORIGEN_IDNull)
				if (this.FUNCIONARIO_ORIGEN_ID != original.FUNCIONARIO_ORIGEN_ID) return true;
			if (this.IsPERSONA_DESTINO_IDNull != original.IsPERSONA_DESTINO_IDNull) return true;
			if (!this.IsPERSONA_DESTINO_IDNull && !original.IsPERSONA_DESTINO_IDNull)
				if (this.PERSONA_DESTINO_ID != original.PERSONA_DESTINO_ID) return true;
			if (this.IsPROVEEDOR_DESTINO_IDNull != original.IsPROVEEDOR_DESTINO_IDNull) return true;
			if (!this.IsPROVEEDOR_DESTINO_IDNull && !original.IsPROVEEDOR_DESTINO_IDNull)
				if (this.PROVEEDOR_DESTINO_ID != original.PROVEEDOR_DESTINO_ID) return true;
			if (this.IsFUNCIONARIO_DESTINO_IDNull != original.IsFUNCIONARIO_DESTINO_IDNull) return true;
			if (!this.IsFUNCIONARIO_DESTINO_IDNull && !original.IsFUNCIONARIO_DESTINO_IDNull)
				if (this.FUNCIONARIO_DESTINO_ID != original.FUNCIONARIO_DESTINO_ID) return true;
			if (this.IsORDEN_PAGO_RESPALDA_CASO_IDNull != original.IsORDEN_PAGO_RESPALDA_CASO_IDNull) return true;
			if (!this.IsORDEN_PAGO_RESPALDA_CASO_IDNull && !original.IsORDEN_PAGO_RESPALDA_CASO_IDNull)
				if (this.ORDEN_PAGO_RESPALDA_CASO_ID != original.ORDEN_PAGO_RESPALDA_CASO_ID) return true;
			if (this.ORDEN_PAGO_UTILIZA_CASO_ID != original.ORDEN_PAGO_UTILIZA_CASO_ID) return true;
			if (this.IsANTICIPO_PROV_UTILIZA_CASO_IDNull != original.IsANTICIPO_PROV_UTILIZA_CASO_IDNull) return true;
			if (!this.IsANTICIPO_PROV_UTILIZA_CASO_IDNull && !original.IsANTICIPO_PROV_UTILIZA_CASO_IDNull)
				if (this.ANTICIPO_PROV_UTILIZA_CASO_ID != original.ANTICIPO_PROV_UTILIZA_CASO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsCG_AUTONUMERACION_IDNull != original.IsCG_AUTONUMERACION_IDNull) return true;
			if (!this.IsCG_AUTONUMERACION_IDNull && !original.IsCG_AUTONUMERACION_IDNull)
				if (this.CG_AUTONUMERACION_ID != original.CG_AUTONUMERACION_ID) return true;
			if (this.CG_NUMERO_CHEQUE != original.CG_NUMERO_CHEQUE) return true;
			if (this.IsCG_FECHA_EMISIONNull != original.IsCG_FECHA_EMISIONNull) return true;
			if (!this.IsCG_FECHA_EMISIONNull && !original.IsCG_FECHA_EMISIONNull)
				if (this.CG_FECHA_EMISION != original.CG_FECHA_EMISION) return true;
			if (this.IsCG_FECHA_VENCIMIENTONull != original.IsCG_FECHA_VENCIMIENTONull) return true;
			if (!this.IsCG_FECHA_VENCIMIENTONull && !original.IsCG_FECHA_VENCIMIENTONull)
				if (this.CG_FECHA_VENCIMIENTO != original.CG_FECHA_VENCIMIENTO) return true;
			if (this.CG_NOMBRE_EMISOR != original.CG_NOMBRE_EMISOR) return true;
			if (this.CG_NOMBRE_BENEFICIARIO != original.CG_NOMBRE_BENEFICIARIO) return true;
			if (this.CG_USAR_CHEQUERA != original.CG_USAR_CHEQUERA) return true;
			if (this.IsCG_CHEQUE_GIRADO_IDNull != original.IsCG_CHEQUE_GIRADO_IDNull) return true;
			if (!this.IsCG_CHEQUE_GIRADO_IDNull && !original.IsCG_CHEQUE_GIRADO_IDNull)
				if (this.CG_CHEQUE_GIRADO_ID != original.CG_CHEQUE_GIRADO_ID) return true;
			if (this.CG_ES_DIFERIDO != original.CG_ES_DIFERIDO) return true;
			if (this.PERSONA_ORIGEN_NOMBRE != original.PERSONA_ORIGEN_NOMBRE) return true;
			if (this.PROVEEDOR_ORIGEN_NOMBRE != original.PROVEEDOR_ORIGEN_NOMBRE) return true;
			if (this.FUNCIONARIO_ORIGEN_NOMBRE != original.FUNCIONARIO_ORIGEN_NOMBRE) return true;
			if (this.PERSONA_DESTINO_NOMBRE != original.PERSONA_DESTINO_NOMBRE) return true;
			if (this.PROVEEDOR_DESTINO_NOMBRE != original.PROVEEDOR_DESTINO_NOMBRE) return true;
			if (this.FUNCIONARIO_DESTINO_NOMBRE != original.FUNCIONARIO_DESTINO_NOMBRE) return true;
			if (this.ES_COTIZACION_DIRECTA != original.ES_COTIZACION_DIRECTA) return true;
			if (this.IsMONEDA_COT_DIRECTA_IDNull != original.IsMONEDA_COT_DIRECTA_IDNull) return true;
			if (!this.IsMONEDA_COT_DIRECTA_IDNull && !original.IsMONEDA_COT_DIRECTA_IDNull)
				if (this.MONEDA_COT_DIRECTA_ID != original.MONEDA_COT_DIRECTA_ID) return true;
			if (this.MONEDA_DIRECTA_NOMBRE != original.MONEDA_DIRECTA_NOMBRE) return true;
			if (this.MONEDA_DIRECTA_SIMBOLO != original.MONEDA_DIRECTA_SIMBOLO) return true;
			
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_SOLICITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_SOLICITUD</c> column value.</value>
		public string NRO_SOLICITUD
		{
			get { return _nro_solicitud; }
			set { _nro_solicitud = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_ORIGEN_ADMINISTRADA</c> column value.
		/// </summary>
		/// <value>The <c>CUENTA_ORIGEN_ADMINISTRADA</c> column value.</value>
		public string CUENTA_ORIGEN_ADMINISTRADA
		{
			get { return _cuenta_origen_administrada; }
			set { _cuenta_origen_administrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_DESTINO_ADMINISTRADA</c> column value.
		/// </summary>
		/// <value>The <c>CUENTA_DESTINO_ADMINISTRADA</c> column value.</value>
		public string CUENTA_DESTINO_ADMINISTRADA
		{
			get { return _cuenta_destino_administrada; }
			set { _cuenta_destino_administrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_ORIGEN_TERCEROS</c> column value.
		/// </summary>
		/// <value>The <c>CUENTA_ORIGEN_TERCEROS</c> column value.</value>
		public string CUENTA_ORIGEN_TERCEROS
		{
			get { return _cuenta_origen_terceros; }
			set { _cuenta_origen_terceros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_DESTINO_TERCEROS</c> column value.
		/// </summary>
		/// <value>The <c>CUENTA_DESTINO_TERCEROS</c> column value.</value>
		public string CUENTA_DESTINO_TERCEROS
		{
			get { return _cuenta_destino_terceros; }
			set { _cuenta_destino_terceros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_ID</c> column value.</value>
		public decimal SUCURSAL_ORIGEN_ID
		{
			get
			{
				if(IsSUCURSAL_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_origen_id;
			}
			set
			{
				_sucursal_origen_idNull = false;
				_sucursal_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_ORIGEN_IDNull
		{
			get { return _sucursal_origen_idNull; }
			set { _sucursal_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</value>
		public decimal CTACTE_BANC_TERCEROS_ORIGEN_ID
		{
			get
			{
				if(IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banc_terceros_origen_id;
			}
			set
			{
				_ctacte_banc_terceros_origen_idNull = false;
				_ctacte_banc_terceros_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANC_TERCEROS_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull
		{
			get { return _ctacte_banc_terceros_origen_idNull; }
			set { _ctacte_banc_terceros_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</value>
		public decimal CTACTE_BANC_TERCEROS_DEST_ID
		{
			get
			{
				if(IsCTACTE_BANC_TERCEROS_DEST_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banc_terceros_dest_id;
			}
			set
			{
				_ctacte_banc_terceros_dest_idNull = false;
				_ctacte_banc_terceros_dest_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANC_TERCEROS_DEST_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANC_TERCEROS_DEST_IDNull
		{
			get { return _ctacte_banc_terceros_dest_idNull; }
			set { _ctacte_banc_terceros_dest_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ORIGEN_NOMBRE</c> column value.</value>
		public string SUCURSAL_ORIGEN_NOMBRE
		{
			get { return _sucursal_origen_nombre; }
			set { _sucursal_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ORIGEN_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ORIGEN_ID
		{
			get { return _ctacte_banco_origen_id; }
			set { _ctacte_banco_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ORIGEN_NOMBRE</c> column value.</value>
		public string CTACTE_BANCO_ORIGEN_NOMBRE
		{
			get { return _ctacte_banco_origen_nombre; }
			set { _ctacte_banco_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ORIGEN_ABREV</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ORIGEN_ABREV</c> column value.</value>
		public string CTACTE_BANCO_ORIGEN_ABREV
		{
			get { return _ctacte_banco_origen_abrev; }
			set { _ctacte_banco_origen_abrev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ORIGEN_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_origen_id;
			}
			set
			{
				_ctacte_bancaria_origen_idNull = false;
				_ctacte_bancaria_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_ORIGEN_IDNull
		{
			get { return _ctacte_bancaria_origen_idNull; }
			set { _ctacte_bancaria_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA_ORIGEN</c> column value.</value>
		public string NUMERO_CUENTA_ORIGEN
		{
			get { return _numero_cuenta_origen; }
			set { _numero_cuenta_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get { return _moneda_origen_id; }
			set { _moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_NOMBRE</c> column value.</value>
		public string MONEDA_ORIGEN_NOMBRE
		{
			get { return _moneda_origen_nombre; }
			set { _moneda_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_SIMBOLO</c> column value.</value>
		public string MONEDA_ORIGEN_SIMBOLO
		{
			get { return _moneda_origen_simbolo; }
			set { _moneda_origen_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get { return _cotizacion_moneda_origen; }
			set { _cotizacion_moneda_origen = value; }
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
		/// Gets or sets the <c>COSTO_TRANSFERENCIA</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_TRANSFERENCIA</c> column value.</value>
		public decimal COSTO_TRANSFERENCIA
		{
			get { return _costo_transferencia; }
			set { _costo_transferencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get
			{
				if(IsSUCURSAL_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_destino_id;
			}
			set
			{
				_sucursal_destino_idNull = false;
				_sucursal_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_DESTINO_IDNull
		{
			get { return _sucursal_destino_idNull; }
			set { _sucursal_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_NOMBRE</c> column value.</value>
		public string SUCURSAL_DESTINO_NOMBRE
		{
			get { return _sucursal_destino_nombre; }
			set { _sucursal_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_DESTINO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_DESTINO_ID
		{
			get { return _ctacte_banco_destino_id; }
			set { _ctacte_banco_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_DESTINO_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_destino_id;
			}
			set
			{
				_ctacte_bancaria_destino_idNull = false;
				_ctacte_bancaria_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_DESTINO_IDNull
		{
			get { return _ctacte_bancaria_destino_idNull; }
			set { _ctacte_bancaria_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_DESTINO_NOMBRE</c> column value.</value>
		public string CTACTE_BANCO_DESTINO_NOMBRE
		{
			get { return _ctacte_banco_destino_nombre; }
			set { _ctacte_banco_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_DESTINO_ABREV</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_DESTINO_ABREV</c> column value.</value>
		public string CTACTE_BANCO_DESTINO_ABREV
		{
			get { return _ctacte_banco_destino_abrev; }
			set { _ctacte_banco_destino_abrev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA_DESTINO</c> column value.</value>
		public string NUMERO_CUENTA_DESTINO
		{
			get { return _numero_cuenta_destino; }
			set { _numero_cuenta_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_ID</c> column value.</value>
		public decimal MONEDA_DESTINO_ID
		{
			get { return _moneda_destino_id; }
			set { _moneda_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_NOMBRE</c> column value.</value>
		public string MONEDA_DESTINO_NOMBRE
		{
			get { return _moneda_destino_nombre; }
			set { _moneda_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_SIMBOLO</c> column value.</value>
		public string MONEDA_DESTINO_SIMBOLO
		{
			get { return _moneda_destino_simbolo; }
			set { _moneda_destino_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_DESTINO</c> column value.</value>
		public decimal COTIZACION_MONEDA_DESTINO
		{
			get { return _cotizacion_moneda_destino; }
			set { _cotizacion_moneda_destino = value; }
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
		/// Gets or sets the <c>NUMERO_TRANSACCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_TRANSACCION</c> column value.</value>
		public string NUMERO_TRANSACCION
		{
			get { return _numero_transaccion; }
			set { _numero_transaccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ORIGEN_ID</c> column value.</value>
		public decimal PERSONA_ORIGEN_ID
		{
			get
			{
				if(IsPERSONA_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_origen_id;
			}
			set
			{
				_persona_origen_idNull = false;
				_persona_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_ORIGEN_IDNull
		{
			get { return _persona_origen_idNull; }
			set { _persona_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ORIGEN_ID</c> column value.</value>
		public decimal PROVEEDOR_ORIGEN_ID
		{
			get
			{
				if(IsPROVEEDOR_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_origen_id;
			}
			set
			{
				_proveedor_origen_idNull = false;
				_proveedor_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_ORIGEN_IDNull
		{
			get { return _proveedor_origen_idNull; }
			set { _proveedor_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ORIGEN_ID</c> column value.</value>
		public decimal FUNCIONARIO_ORIGEN_ID
		{
			get
			{
				if(IsFUNCIONARIO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_origen_id;
			}
			set
			{
				_funcionario_origen_idNull = false;
				_funcionario_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ORIGEN_IDNull
		{
			get { return _funcionario_origen_idNull; }
			set { _funcionario_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DESTINO_ID</c> column value.</value>
		public decimal PERSONA_DESTINO_ID
		{
			get
			{
				if(IsPERSONA_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_destino_id;
			}
			set
			{
				_persona_destino_idNull = false;
				_persona_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_DESTINO_IDNull
		{
			get { return _persona_destino_idNull; }
			set { _persona_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_DESTINO_ID</c> column value.</value>
		public decimal PROVEEDOR_DESTINO_ID
		{
			get
			{
				if(IsPROVEEDOR_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_destino_id;
			}
			set
			{
				_proveedor_destino_idNull = false;
				_proveedor_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_DESTINO_IDNull
		{
			get { return _proveedor_destino_idNull; }
			set { _proveedor_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_DESTINO_ID</c> column value.</value>
		public decimal FUNCIONARIO_DESTINO_ID
		{
			get
			{
				if(IsFUNCIONARIO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_destino_id;
			}
			set
			{
				_funcionario_destino_idNull = false;
				_funcionario_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_DESTINO_IDNull
		{
			get { return _funcionario_destino_idNull; }
			set { _funcionario_destino_idNull = value; }
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
		/// Gets or sets the <c>ANTICIPO_PROV_UTILIZA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_PROV_UTILIZA_CASO_ID</c> column value.</value>
		public decimal ANTICIPO_PROV_UTILIZA_CASO_ID
		{
			get
			{
				if(IsANTICIPO_PROV_UTILIZA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_prov_utiliza_caso_id;
			}
			set
			{
				_anticipo_prov_utiliza_caso_idNull = false;
				_anticipo_prov_utiliza_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_PROV_UTILIZA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_PROV_UTILIZA_CASO_IDNull
		{
			get { return _anticipo_prov_utiliza_caso_idNull; }
			set { _anticipo_prov_utiliza_caso_idNull = value; }
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
		/// Gets or sets the <c>CG_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_AUTONUMERACION_ID</c> column value.</value>
		public decimal CG_AUTONUMERACION_ID
		{
			get
			{
				if(IsCG_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_autonumeracion_id;
			}
			set
			{
				_cg_autonumeracion_idNull = false;
				_cg_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_AUTONUMERACION_IDNull
		{
			get { return _cg_autonumeracion_idNull; }
			set { _cg_autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NUMERO_CHEQUE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NUMERO_CHEQUE</c> column value.</value>
		public string CG_NUMERO_CHEQUE
		{
			get { return _cg_numero_cheque; }
			set { _cg_numero_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_FECHA_EMISION</c> column value.</value>
		public System.DateTime CG_FECHA_EMISION
		{
			get
			{
				if(IsCG_FECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_fecha_emision;
			}
			set
			{
				_cg_fecha_emisionNull = false;
				_cg_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_FECHA_EMISIONNull
		{
			get { return _cg_fecha_emisionNull; }
			set { _cg_fecha_emisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime CG_FECHA_VENCIMIENTO
		{
			get
			{
				if(IsCG_FECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_fecha_vencimiento;
			}
			set
			{
				_cg_fecha_vencimientoNull = false;
				_cg_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_FECHA_VENCIMIENTONull
		{
			get { return _cg_fecha_vencimientoNull; }
			set { _cg_fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NOMBRE_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NOMBRE_EMISOR</c> column value.</value>
		public string CG_NOMBRE_EMISOR
		{
			get { return _cg_nombre_emisor; }
			set { _cg_nombre_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_NOMBRE_BENEFICIARIO</c> column value.</value>
		public string CG_NOMBRE_BENEFICIARIO
		{
			get { return _cg_nombre_beneficiario; }
			set { _cg_nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_USAR_CHEQUERA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_USAR_CHEQUERA</c> column value.</value>
		public string CG_USAR_CHEQUERA
		{
			get { return _cg_usar_chequera; }
			set { _cg_usar_chequera = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_CHEQUE_GIRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_CHEQUE_GIRADO_ID</c> column value.</value>
		public decimal CG_CHEQUE_GIRADO_ID
		{
			get
			{
				if(IsCG_CHEQUE_GIRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cg_cheque_girado_id;
			}
			set
			{
				_cg_cheque_girado_idNull = false;
				_cg_cheque_girado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CG_CHEQUE_GIRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCG_CHEQUE_GIRADO_IDNull
		{
			get { return _cg_cheque_girado_idNull; }
			set { _cg_cheque_girado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CG_ES_DIFERIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CG_ES_DIFERIDO</c> column value.</value>
		public string CG_ES_DIFERIDO
		{
			get { return _cg_es_diferido; }
			set { _cg_es_diferido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ORIGEN_NOMBRE</c> column value.</value>
		public string PERSONA_ORIGEN_NOMBRE
		{
			get { return _persona_origen_nombre; }
			set { _persona_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ORIGEN_NOMBRE</c> column value.</value>
		public string PROVEEDOR_ORIGEN_NOMBRE
		{
			get { return _proveedor_origen_nombre; }
			set { _proveedor_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ORIGEN_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_ORIGEN_NOMBRE
		{
			get { return _funcionario_origen_nombre; }
			set { _funcionario_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DESTINO_NOMBRE</c> column value.</value>
		public string PERSONA_DESTINO_NOMBRE
		{
			get { return _persona_destino_nombre; }
			set { _persona_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_DESTINO_NOMBRE</c> column value.</value>
		public string PROVEEDOR_DESTINO_NOMBRE
		{
			get { return _proveedor_destino_nombre; }
			set { _proveedor_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_DESTINO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_DESTINO_NOMBRE
		{
			get { return _funcionario_destino_nombre; }
			set { _funcionario_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COTIZACION_DIRECTA</c> column value.
		/// </summary>
		/// <value>The <c>ES_COTIZACION_DIRECTA</c> column value.</value>
		public string ES_COTIZACION_DIRECTA
		{
			get { return _es_cotizacion_directa; }
			set { _es_cotizacion_directa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COT_DIRECTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COT_DIRECTA_ID</c> column value.</value>
		public decimal MONEDA_COT_DIRECTA_ID
		{
			get
			{
				if(IsMONEDA_COT_DIRECTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cot_directa_id;
			}
			set
			{
				_moneda_cot_directa_idNull = false;
				_moneda_cot_directa_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_COT_DIRECTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_COT_DIRECTA_IDNull
		{
			get { return _moneda_cot_directa_idNull; }
			set { _moneda_cot_directa_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DIRECTA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_DIRECTA_NOMBRE</c> column value.</value>
		public string MONEDA_DIRECTA_NOMBRE
		{
			get { return _moneda_directa_nombre; }
			set { _moneda_directa_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DIRECTA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_DIRECTA_SIMBOLO</c> column value.</value>
		public string MONEDA_DIRECTA_SIMBOLO
		{
			get { return _moneda_directa_simbolo; }
			set { _moneda_directa_simbolo = value; }
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
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@NRO_SOLICITUD=");
			dynStr.Append(NRO_SOLICITUD);
			dynStr.Append("@CBA@CUENTA_ORIGEN_ADMINISTRADA=");
			dynStr.Append(CUENTA_ORIGEN_ADMINISTRADA);
			dynStr.Append("@CBA@CUENTA_DESTINO_ADMINISTRADA=");
			dynStr.Append(CUENTA_DESTINO_ADMINISTRADA);
			dynStr.Append("@CBA@CUENTA_ORIGEN_TERCEROS=");
			dynStr.Append(CUENTA_ORIGEN_TERCEROS);
			dynStr.Append("@CBA@CUENTA_DESTINO_TERCEROS=");
			dynStr.Append(CUENTA_DESTINO_TERCEROS);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_ID=");
			dynStr.Append(IsSUCURSAL_ORIGEN_IDNull ? (object)"<NULL>" : SUCURSAL_ORIGEN_ID);
			dynStr.Append("@CBA@CTACTE_BANC_TERCEROS_ORIGEN_ID=");
			dynStr.Append(IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull ? (object)"<NULL>" : CTACTE_BANC_TERCEROS_ORIGEN_ID);
			dynStr.Append("@CBA@CTACTE_BANC_TERCEROS_DEST_ID=");
			dynStr.Append(IsCTACTE_BANC_TERCEROS_DEST_IDNull ? (object)"<NULL>" : CTACTE_BANC_TERCEROS_DEST_ID);
			dynStr.Append("@CBA@SUCURSAL_ORIGEN_NOMBRE=");
			dynStr.Append(SUCURSAL_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_ORIGEN_ID=");
			dynStr.Append(CTACTE_BANCO_ORIGEN_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_ORIGEN_NOMBRE=");
			dynStr.Append(CTACTE_BANCO_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_ORIGEN_ABREV=");
			dynStr.Append(CTACTE_BANCO_ORIGEN_ABREV);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ORIGEN_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_ORIGEN_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ORIGEN_ID);
			dynStr.Append("@CBA@NUMERO_CUENTA_ORIGEN=");
			dynStr.Append(NUMERO_CUENTA_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_NOMBRE=");
			dynStr.Append(MONEDA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ORIGEN_SIMBOLO=");
			dynStr.Append(MONEDA_ORIGEN_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@COSTO_TRANSFERENCIA=");
			dynStr.Append(COSTO_TRANSFERENCIA);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(IsSUCURSAL_DESTINO_IDNull ? (object)"<NULL>" : SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_NOMBRE=");
			dynStr.Append(SUCURSAL_DESTINO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_DESTINO_ID=");
			dynStr.Append(CTACTE_BANCO_DESTINO_ID);
			dynStr.Append("@CBA@CTACTE_BANCARIA_DESTINO_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_DESTINO_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_DESTINO_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_DESTINO_NOMBRE=");
			dynStr.Append(CTACTE_BANCO_DESTINO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_DESTINO_ABREV=");
			dynStr.Append(CTACTE_BANCO_DESTINO_ABREV);
			dynStr.Append("@CBA@NUMERO_CUENTA_DESTINO=");
			dynStr.Append(NUMERO_CUENTA_DESTINO);
			dynStr.Append("@CBA@MONEDA_DESTINO_ID=");
			dynStr.Append(MONEDA_DESTINO_ID);
			dynStr.Append("@CBA@MONEDA_DESTINO_NOMBRE=");
			dynStr.Append(MONEDA_DESTINO_NOMBRE);
			dynStr.Append("@CBA@MONEDA_DESTINO_SIMBOLO=");
			dynStr.Append(MONEDA_DESTINO_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA_DESTINO=");
			dynStr.Append(COTIZACION_MONEDA_DESTINO);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			dynStr.Append("@CBA@NUMERO_TRANSACCION=");
			dynStr.Append(NUMERO_TRANSACCION);
			dynStr.Append("@CBA@PERSONA_ORIGEN_ID=");
			dynStr.Append(IsPERSONA_ORIGEN_IDNull ? (object)"<NULL>" : PERSONA_ORIGEN_ID);
			dynStr.Append("@CBA@PROVEEDOR_ORIGEN_ID=");
			dynStr.Append(IsPROVEEDOR_ORIGEN_IDNull ? (object)"<NULL>" : PROVEEDOR_ORIGEN_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ORIGEN_ID=");
			dynStr.Append(IsFUNCIONARIO_ORIGEN_IDNull ? (object)"<NULL>" : FUNCIONARIO_ORIGEN_ID);
			dynStr.Append("@CBA@PERSONA_DESTINO_ID=");
			dynStr.Append(IsPERSONA_DESTINO_IDNull ? (object)"<NULL>" : PERSONA_DESTINO_ID);
			dynStr.Append("@CBA@PROVEEDOR_DESTINO_ID=");
			dynStr.Append(IsPROVEEDOR_DESTINO_IDNull ? (object)"<NULL>" : PROVEEDOR_DESTINO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_DESTINO_ID=");
			dynStr.Append(IsFUNCIONARIO_DESTINO_IDNull ? (object)"<NULL>" : FUNCIONARIO_DESTINO_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_RESPALDA_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_RESPALDA_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_RESPALDA_CASO_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_UTILIZA_CASO_ID=");
			dynStr.Append(ORDEN_PAGO_UTILIZA_CASO_ID);
			dynStr.Append("@CBA@ANTICIPO_PROV_UTILIZA_CASO_ID=");
			dynStr.Append(IsANTICIPO_PROV_UTILIZA_CASO_IDNull ? (object)"<NULL>" : ANTICIPO_PROV_UTILIZA_CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@CG_AUTONUMERACION_ID=");
			dynStr.Append(IsCG_AUTONUMERACION_IDNull ? (object)"<NULL>" : CG_AUTONUMERACION_ID);
			dynStr.Append("@CBA@CG_NUMERO_CHEQUE=");
			dynStr.Append(CG_NUMERO_CHEQUE);
			dynStr.Append("@CBA@CG_FECHA_EMISION=");
			dynStr.Append(IsCG_FECHA_EMISIONNull ? (object)"<NULL>" : CG_FECHA_EMISION);
			dynStr.Append("@CBA@CG_FECHA_VENCIMIENTO=");
			dynStr.Append(IsCG_FECHA_VENCIMIENTONull ? (object)"<NULL>" : CG_FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@CG_NOMBRE_EMISOR=");
			dynStr.Append(CG_NOMBRE_EMISOR);
			dynStr.Append("@CBA@CG_NOMBRE_BENEFICIARIO=");
			dynStr.Append(CG_NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@CG_USAR_CHEQUERA=");
			dynStr.Append(CG_USAR_CHEQUERA);
			dynStr.Append("@CBA@CG_CHEQUE_GIRADO_ID=");
			dynStr.Append(IsCG_CHEQUE_GIRADO_IDNull ? (object)"<NULL>" : CG_CHEQUE_GIRADO_ID);
			dynStr.Append("@CBA@CG_ES_DIFERIDO=");
			dynStr.Append(CG_ES_DIFERIDO);
			dynStr.Append("@CBA@PERSONA_ORIGEN_NOMBRE=");
			dynStr.Append(PERSONA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_ORIGEN_NOMBRE=");
			dynStr.Append(PROVEEDOR_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ORIGEN_NOMBRE=");
			dynStr.Append(FUNCIONARIO_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@PERSONA_DESTINO_NOMBRE=");
			dynStr.Append(PERSONA_DESTINO_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_DESTINO_NOMBRE=");
			dynStr.Append(PROVEEDOR_DESTINO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_DESTINO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_DESTINO_NOMBRE);
			dynStr.Append("@CBA@ES_COTIZACION_DIRECTA=");
			dynStr.Append(ES_COTIZACION_DIRECTA);
			dynStr.Append("@CBA@MONEDA_COT_DIRECTA_ID=");
			dynStr.Append(IsMONEDA_COT_DIRECTA_IDNull ? (object)"<NULL>" : MONEDA_COT_DIRECTA_ID);
			dynStr.Append("@CBA@MONEDA_DIRECTA_NOMBRE=");
			dynStr.Append(MONEDA_DIRECTA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_DIRECTA_SIMBOLO=");
			dynStr.Append(MONEDA_DIRECTA_SIMBOLO);
			return dynStr.ToString();
		}
	} // End of TRANSFERENCIAS_BANCARIAS_INF_CRow_Base class
} // End of namespace
