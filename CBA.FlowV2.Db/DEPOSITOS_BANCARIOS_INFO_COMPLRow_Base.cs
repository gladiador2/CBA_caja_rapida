// <fileinfo name="DEPOSITOS_BANCARIOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>DEPOSITOS_BANCARIOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPOSITOS_BANCARIOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _funcionario_id;
		private string _funcionario_nombre_completo;
		private System.DateTime _fecha;
		private string _deposito_desde_suc;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_cadena_decimales;
		private decimal _moneda_cantidades_decimales;
		private decimal _cotizacion_moneda;
		private decimal _ctacte_banco_id;
		private string _ctacte_banco_nombre;
		private string _ctacte_banco_abreviatura;
		private decimal _ctacte_bancaria_id;
		private string _numero_cuenta;
		private decimal _ctacte_caja_tesoreria_id;
		private bool _ctacte_caja_tesoreria_idNull = true;
		private string _ctacte_caja_tesoreria_nombre;
		private string _ctacte_caja_teso_abreviatura;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private string _ctacte_caja_suc_func_nombre;
		private string _ctacte_caja_suc_nro_comp;
		private System.DateTime _ctacte_caja_suc_fecha_ini;
		private bool _ctacte_caja_suc_fecha_iniNull = true;
		private System.DateTime _ctacte_caja_suc_fecha_fin;
		private bool _ctacte_caja_suc_fecha_finNull = true;
		private string _nro_comprobante;
		private decimal _total_efectivo;
		private decimal _total_cheque_mismo_banco;
		private decimal _total_cheque_otro_banco;
		private decimal _total_importe;
		private string _observacion;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto_predefinido_nombre;
		private string _incluye_persona;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public DEPOSITOS_BANCARIOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DEPOSITOS_BANCARIOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.DEPOSITO_DESDE_SUC != original.DEPOSITO_DESDE_SUC) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.MONEDA_CANTIDADES_DECIMALES != original.MONEDA_CANTIDADES_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.CTACTE_BANCO_NOMBRE != original.CTACTE_BANCO_NOMBRE) return true;
			if (this.CTACTE_BANCO_ABREVIATURA != original.CTACTE_BANCO_ABREVIATURA) return true;
			if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.NUMERO_CUENTA != original.NUMERO_CUENTA) return true;
			if (this.IsCTACTE_CAJA_TESORERIA_IDNull != original.IsCTACTE_CAJA_TESORERIA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESORERIA_IDNull && !original.IsCTACTE_CAJA_TESORERIA_IDNull)
				if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_NOMBRE != original.CTACTE_CAJA_TESORERIA_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESO_ABREVIATURA != original.CTACTE_CAJA_TESO_ABREVIATURA) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.CTACTE_CAJA_SUC_FUNC_NOMBRE != original.CTACTE_CAJA_SUC_FUNC_NOMBRE) return true;
			if (this.CTACTE_CAJA_SUC_NRO_COMP != original.CTACTE_CAJA_SUC_NRO_COMP) return true;
			if (this.IsCTACTE_CAJA_SUC_FECHA_ININull != original.IsCTACTE_CAJA_SUC_FECHA_ININull) return true;
			if (!this.IsCTACTE_CAJA_SUC_FECHA_ININull && !original.IsCTACTE_CAJA_SUC_FECHA_ININull)
				if (this.CTACTE_CAJA_SUC_FECHA_INI != original.CTACTE_CAJA_SUC_FECHA_INI) return true;
			if (this.IsCTACTE_CAJA_SUC_FECHA_FINNull != original.IsCTACTE_CAJA_SUC_FECHA_FINNull) return true;
			if (!this.IsCTACTE_CAJA_SUC_FECHA_FINNull && !original.IsCTACTE_CAJA_SUC_FECHA_FINNull)
				if (this.CTACTE_CAJA_SUC_FECHA_FIN != original.CTACTE_CAJA_SUC_FECHA_FIN) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.TOTAL_EFECTIVO != original.TOTAL_EFECTIVO) return true;
			if (this.TOTAL_CHEQUE_MISMO_BANCO != original.TOTAL_CHEQUE_MISMO_BANCO) return true;
			if (this.TOTAL_CHEQUE_OTRO_BANCO != original.TOTAL_CHEQUE_OTRO_BANCO) return true;
			if (this.TOTAL_IMPORTE != original.TOTAL_IMPORTE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO_NOMBRE != original.TEXTO_PREDEFINIDO_NOMBRE) return true;
			if (this.INCLUYE_PERSONA != original.INCLUYE_PERSONA) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_DESDE_SUC</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_DESDE_SUC</c> column value.</value>
		public string DEPOSITO_DESDE_SUC
		{
			get { return _deposito_desde_suc; }
			set { _deposito_desde_suc = value; }
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
		/// Gets or sets the <c>MONEDA_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_CADENA_DECIMALES
		{
			get { return _moneda_cadena_decimales; }
			set { _moneda_cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDADES_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDADES_DECIMALES
		{
			get { return _moneda_cantidades_decimales; }
			set { _moneda_cantidades_decimales = value; }
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
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get { return _ctacte_banco_id; }
			set { _ctacte_banco_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_NOMBRE</c> column value.</value>
		public string CTACTE_BANCO_NOMBRE
		{
			get { return _ctacte_banco_nombre; }
			set { _ctacte_banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ABREVIATURA</c> column value.</value>
		public string CTACTE_BANCO_ABREVIATURA
		{
			get { return _ctacte_banco_abreviatura; }
			set { _ctacte_banco_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get { return _ctacte_bancaria_id; }
			set { _ctacte_bancaria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA</c> column value.</value>
		public string NUMERO_CUENTA
		{
			get { return _numero_cuenta; }
			set { _numero_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_ID
		{
			get
			{
				if(IsCTACTE_CAJA_TESORERIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_tesoreria_id;
			}
			set
			{
				_ctacte_caja_tesoreria_idNull = false;
				_ctacte_caja_tesoreria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_TESORERIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_TESORERIA_IDNull
		{
			get { return _ctacte_caja_tesoreria_idNull; }
			set { _ctacte_caja_tesoreria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_NOMBRE
		{
			get { return _ctacte_caja_tesoreria_nombre; }
			set { _ctacte_caja_tesoreria_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_ABREVIATURA</c> column value.</value>
		public string CTACTE_CAJA_TESO_ABREVIATURA
		{
			get { return _ctacte_caja_teso_abreviatura; }
			set { _ctacte_caja_teso_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUC_FUNC_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUC_FUNC_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_SUC_FUNC_NOMBRE
		{
			get { return _ctacte_caja_suc_func_nombre; }
			set { _ctacte_caja_suc_func_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUC_NRO_COMP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUC_NRO_COMP</c> column value.</value>
		public string CTACTE_CAJA_SUC_NRO_COMP
		{
			get { return _ctacte_caja_suc_nro_comp; }
			set { _ctacte_caja_suc_nro_comp = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUC_FECHA_INI</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUC_FECHA_INI</c> column value.</value>
		public System.DateTime CTACTE_CAJA_SUC_FECHA_INI
		{
			get
			{
				if(IsCTACTE_CAJA_SUC_FECHA_ININull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_suc_fecha_ini;
			}
			set
			{
				_ctacte_caja_suc_fecha_iniNull = false;
				_ctacte_caja_suc_fecha_ini = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUC_FECHA_INI"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUC_FECHA_ININull
		{
			get { return _ctacte_caja_suc_fecha_iniNull; }
			set { _ctacte_caja_suc_fecha_iniNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUC_FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUC_FECHA_FIN</c> column value.</value>
		public System.DateTime CTACTE_CAJA_SUC_FECHA_FIN
		{
			get
			{
				if(IsCTACTE_CAJA_SUC_FECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_suc_fecha_fin;
			}
			set
			{
				_ctacte_caja_suc_fecha_finNull = false;
				_ctacte_caja_suc_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUC_FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUC_FECHA_FINNull
		{
			get { return _ctacte_caja_suc_fecha_finNull; }
			set { _ctacte_caja_suc_fecha_finNull = value; }
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
		/// Gets or sets the <c>TOTAL_EFECTIVO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_EFECTIVO</c> column value.</value>
		public decimal TOTAL_EFECTIVO
		{
			get { return _total_efectivo; }
			set { _total_efectivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_CHEQUE_MISMO_BANCO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_CHEQUE_MISMO_BANCO</c> column value.</value>
		public decimal TOTAL_CHEQUE_MISMO_BANCO
		{
			get { return _total_cheque_mismo_banco; }
			set { _total_cheque_mismo_banco = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_CHEQUE_OTRO_BANCO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_CHEQUE_OTRO_BANCO</c> column value.</value>
		public decimal TOTAL_CHEQUE_OTRO_BANCO
		{
			get { return _total_cheque_otro_banco; }
			set { _total_cheque_otro_banco = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPORTE</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_IMPORTE</c> column value.</value>
		public decimal TOTAL_IMPORTE
		{
			get { return _total_importe; }
			set { _total_importe = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_NOMBRE</c> column value.</value>
		public string TEXTO_PREDEFINIDO_NOMBRE
		{
			get { return _texto_predefinido_nombre; }
			set { _texto_predefinido_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INCLUYE_PERSONA</c> column value.
		/// </summary>
		/// <value>The <c>INCLUYE_PERSONA</c> column value.</value>
		public string INCLUYE_PERSONA
		{
			get { return _incluye_persona; }
			set { _incluye_persona = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@DEPOSITO_DESDE_SUC=");
			dynStr.Append(DEPOSITO_DESDE_SUC);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CANTIDADES_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_NOMBRE=");
			dynStr.Append(CTACTE_BANCO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_ABREVIATURA=");
			dynStr.Append(CTACTE_BANCO_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@NUMERO_CUENTA=");
			dynStr.Append(NUMERO_CUENTA);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESORERIA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_ABREVIATURA=");
			dynStr.Append(CTACTE_CAJA_TESO_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_SUC_FUNC_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_SUC_FUNC_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_SUC_NRO_COMP=");
			dynStr.Append(CTACTE_CAJA_SUC_NRO_COMP);
			dynStr.Append("@CBA@CTACTE_CAJA_SUC_FECHA_INI=");
			dynStr.Append(IsCTACTE_CAJA_SUC_FECHA_ININull ? (object)"<NULL>" : CTACTE_CAJA_SUC_FECHA_INI);
			dynStr.Append("@CBA@CTACTE_CAJA_SUC_FECHA_FIN=");
			dynStr.Append(IsCTACTE_CAJA_SUC_FECHA_FINNull ? (object)"<NULL>" : CTACTE_CAJA_SUC_FECHA_FIN);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@TOTAL_EFECTIVO=");
			dynStr.Append(TOTAL_EFECTIVO);
			dynStr.Append("@CBA@TOTAL_CHEQUE_MISMO_BANCO=");
			dynStr.Append(TOTAL_CHEQUE_MISMO_BANCO);
			dynStr.Append("@CBA@TOTAL_CHEQUE_OTRO_BANCO=");
			dynStr.Append(TOTAL_CHEQUE_OTRO_BANCO);
			dynStr.Append("@CBA@TOTAL_IMPORTE=");
			dynStr.Append(TOTAL_IMPORTE);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_NOMBRE=");
			dynStr.Append(TEXTO_PREDEFINIDO_NOMBRE);
			dynStr.Append("@CBA@INCLUYE_PERSONA=");
			dynStr.Append(INCLUYE_PERSONA);
			return dynStr.ToString();
		}
	} // End of DEPOSITOS_BANCARIOS_INFO_COMPLRow_Base class
} // End of namespace
