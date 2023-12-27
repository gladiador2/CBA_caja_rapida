// <fileinfo name="CTACTE_CHEQUES_REC_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTACTE_CHEQUES_REC_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_REC_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ctacte_banco_id;
		private string _banco_nombre;
		private string _banco_abreviatura;
		private string _banco_codigo;
		private decimal _banco_entidad;
		private string _entidad_nombre;
		private string _numero_cuenta;
		private string _numero_cheque;
		private string _nombre_emisor;
		private string _nombre_beneficiario;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_posdatado;
		private System.DateTime _fecha_vencimiento;
		private System.DateTime _fecha_cobro;
		private bool _fecha_cobroNull = true;
		private System.DateTime _fecha_rechazo;
		private bool _fecha_rechazoNull = true;
		private decimal _moneda_id;
		private string _numero_documento_emisor;
		private string _monedas_nombre;
		private string _monedas_simbolo;
		private decimal _cantidades_decimales;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private decimal _deposito_bancario_id;
		private bool _deposito_bancario_idNull = true;
		private decimal _custodia_valores_id;
		private bool _custodia_valores_idNull = true;
		private decimal _descuento_documentos_id;
		private bool _descuento_documentos_idNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _motivo_rechazo;
		private decimal _cheque_estado_id;
		private bool _cheque_estado_idNull = true;
		private string _estado_cheque;
		private string _estado_abreviado;
		private string _cheque_de_terceros;
		private decimal _caso_creador_id;
		private bool _caso_creador_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _sucursal_abreviatura;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _persona_nombre;
		private string _persona_codigo;
		private string _proveedor_razon_social;
		private string _es_diferido;
		private string _estado;
		private decimal _ctacte_caja_tesoreria_id;
		private bool _ctacte_caja_tesoreria_idNull = true;
		private string _ctacte_caja_tesoreria_nombre;
		private decimal _funcionario_asignado_id;
		private bool _funcionario_asignado_idNull = true;
		private string _funcionario_asignado_nombre;
		private string _datos_resumidos_sin_monto;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTACTE_CHEQUES_REC_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHEQUES_REC_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.BANCO_NOMBRE != original.BANCO_NOMBRE) return true;
			if (this.BANCO_ABREVIATURA != original.BANCO_ABREVIATURA) return true;
			if (this.BANCO_CODIGO != original.BANCO_CODIGO) return true;
			if (this.BANCO_ENTIDAD != original.BANCO_ENTIDAD) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.NUMERO_CUENTA != original.NUMERO_CUENTA) return true;
			if (this.NUMERO_CHEQUE != original.NUMERO_CHEQUE) return true;
			if (this.NOMBRE_EMISOR != original.NOMBRE_EMISOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.FECHA_POSDATADO != original.FECHA_POSDATADO) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_COBRONull != original.IsFECHA_COBRONull) return true;
			if (!this.IsFECHA_COBRONull && !original.IsFECHA_COBRONull)
				if (this.FECHA_COBRO != original.FECHA_COBRO) return true;
			if (this.IsFECHA_RECHAZONull != original.IsFECHA_RECHAZONull) return true;
			if (!this.IsFECHA_RECHAZONull && !original.IsFECHA_RECHAZONull)
				if (this.FECHA_RECHAZO != original.FECHA_RECHAZO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.NUMERO_DOCUMENTO_EMISOR != original.NUMERO_DOCUMENTO_EMISOR) return true;
			if (this.MONEDAS_NOMBRE != original.MONEDAS_NOMBRE) return true;
			if (this.MONEDAS_SIMBOLO != original.MONEDAS_SIMBOLO) return true;
			if (this.CANTIDADES_DECIMALES != original.CANTIDADES_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsDEPOSITO_BANCARIO_IDNull != original.IsDEPOSITO_BANCARIO_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_IDNull && !original.IsDEPOSITO_BANCARIO_IDNull)
				if (this.DEPOSITO_BANCARIO_ID != original.DEPOSITO_BANCARIO_ID) return true;
			if (this.IsCUSTODIA_VALORES_IDNull != original.IsCUSTODIA_VALORES_IDNull) return true;
			if (!this.IsCUSTODIA_VALORES_IDNull && !original.IsCUSTODIA_VALORES_IDNull)
				if (this.CUSTODIA_VALORES_ID != original.CUSTODIA_VALORES_ID) return true;
			if (this.IsDESCUENTO_DOCUMENTOS_IDNull != original.IsDESCUENTO_DOCUMENTOS_IDNull) return true;
			if (!this.IsDESCUENTO_DOCUMENTOS_IDNull && !original.IsDESCUENTO_DOCUMENTOS_IDNull)
				if (this.DESCUENTO_DOCUMENTOS_ID != original.DESCUENTO_DOCUMENTOS_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.MOTIVO_RECHAZO != original.MOTIVO_RECHAZO) return true;
			if (this.IsCHEQUE_ESTADO_IDNull != original.IsCHEQUE_ESTADO_IDNull) return true;
			if (!this.IsCHEQUE_ESTADO_IDNull && !original.IsCHEQUE_ESTADO_IDNull)
				if (this.CHEQUE_ESTADO_ID != original.CHEQUE_ESTADO_ID) return true;
			if (this.ESTADO_CHEQUE != original.ESTADO_CHEQUE) return true;
			if (this.ESTADO_ABREVIADO != original.ESTADO_ABREVIADO) return true;
			if (this.CHEQUE_DE_TERCEROS != original.CHEQUE_DE_TERCEROS) return true;
			if (this.IsCASO_CREADOR_IDNull != original.IsCASO_CREADOR_IDNull) return true;
			if (!this.IsCASO_CREADOR_IDNull && !original.IsCASO_CREADOR_IDNull)
				if (this.CASO_CREADOR_ID != original.CASO_CREADOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PROVEEDOR_RAZON_SOCIAL != original.PROVEEDOR_RAZON_SOCIAL) return true;
			if (this.ES_DIFERIDO != original.ES_DIFERIDO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsCTACTE_CAJA_TESORERIA_IDNull != original.IsCTACTE_CAJA_TESORERIA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESORERIA_IDNull && !original.IsCTACTE_CAJA_TESORERIA_IDNull)
				if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_NOMBRE != original.CTACTE_CAJA_TESORERIA_NOMBRE) return true;
			if (this.IsFUNCIONARIO_ASIGNADO_IDNull != original.IsFUNCIONARIO_ASIGNADO_IDNull) return true;
			if (!this.IsFUNCIONARIO_ASIGNADO_IDNull && !original.IsFUNCIONARIO_ASIGNADO_IDNull)
				if (this.FUNCIONARIO_ASIGNADO_ID != original.FUNCIONARIO_ASIGNADO_ID) return true;
			if (this.FUNCIONARIO_ASIGNADO_NOMBRE != original.FUNCIONARIO_ASIGNADO_NOMBRE) return true;
			if (this.DATOS_RESUMIDOS_SIN_MONTO != original.DATOS_RESUMIDOS_SIN_MONTO) return true;
			
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
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get { return _ctacte_banco_id; }
			set { _ctacte_banco_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>BANCO_NOMBRE</c> column value.</value>
		public string BANCO_NOMBRE
		{
			get { return _banco_nombre; }
			set { _banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>BANCO_ABREVIATURA</c> column value.</value>
		public string BANCO_ABREVIATURA
		{
			get { return _banco_abreviatura; }
			set { _banco_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BANCO_CODIGO</c> column value.</value>
		public string BANCO_CODIGO
		{
			get { return _banco_codigo; }
			set { _banco_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANCO_ENTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>BANCO_ENTIDAD</c> column value.</value>
		public decimal BANCO_ENTIDAD
		{
			get { return _banco_entidad; }
			set { _banco_entidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_NOMBRE</c> column value.</value>
		public string ENTIDAD_NOMBRE
		{
			get { return _entidad_nombre; }
			set { _entidad_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CUENTA</c> column value.</value>
		public string NUMERO_CUENTA
		{
			get { return _numero_cuenta; }
			set { _numero_cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CHEQUE</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_CHEQUE</c> column value.</value>
		public string NUMERO_CHEQUE
		{
			get { return _numero_cheque; }
			set { _numero_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_EMISOR</c> column value.</value>
		public string NOMBRE_EMISOR
		{
			get { return _nombre_emisor; }
			set { _nombre_emisor = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_POSDATADO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_POSDATADO</c> column value.</value>
		public System.DateTime FECHA_POSDATADO
		{
			get { return _fecha_posdatado; }
			set { _fecha_posdatado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_COBRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_COBRO</c> column value.</value>
		public System.DateTime FECHA_COBRO
		{
			get
			{
				if(IsFECHA_COBRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cobro;
			}
			set
			{
				_fecha_cobroNull = false;
				_fecha_cobro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_COBRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_COBRONull
		{
			get { return _fecha_cobroNull; }
			set { _fecha_cobroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECHAZO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RECHAZO</c> column value.</value>
		public System.DateTime FECHA_RECHAZO
		{
			get
			{
				if(IsFECHA_RECHAZONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_rechazo;
			}
			set
			{
				_fecha_rechazoNull = false;
				_fecha_rechazo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RECHAZO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RECHAZONull
		{
			get { return _fecha_rechazoNull; }
			set { _fecha_rechazoNull = value; }
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
		/// Gets or sets the <c>NUMERO_DOCUMENTO_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_DOCUMENTO_EMISOR</c> column value.</value>
		public string NUMERO_DOCUMENTO_EMISOR
		{
			get { return _numero_documento_emisor; }
			set { _numero_documento_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_NOMBRE</c> column value.</value>
		public string MONEDAS_NOMBRE
		{
			get { return _monedas_nombre; }
			set { _monedas_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDAS_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_SIMBOLO</c> column value.</value>
		public string MONEDAS_SIMBOLO
		{
			get { return _monedas_simbolo; }
			set { _monedas_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDADES_DECIMALES</c> column value.</value>
		public decimal CANTIDADES_DECIMALES
		{
			get { return _cantidades_decimales; }
			set { _cantidades_decimales = value; }
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
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_BANCARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_BANCARIO_ID</c> column value.</value>
		public decimal DEPOSITO_BANCARIO_ID
		{
			get
			{
				if(IsDEPOSITO_BANCARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_bancario_id;
			}
			set
			{
				_deposito_bancario_idNull = false;
				_deposito_bancario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_BANCARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_BANCARIO_IDNull
		{
			get { return _deposito_bancario_idNull; }
			set { _deposito_bancario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUSTODIA_VALORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALORES_ID</c> column value.</value>
		public decimal CUSTODIA_VALORES_ID
		{
			get
			{
				if(IsCUSTODIA_VALORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _custodia_valores_id;
			}
			set
			{
				_custodia_valores_idNull = false;
				_custodia_valores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUSTODIA_VALORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUSTODIA_VALORES_IDNull
		{
			get { return _custodia_valores_idNull; }
			set { _custodia_valores_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_DOCUMENTOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTOS_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTOS_ID
		{
			get
			{
				if(IsDESCUENTO_DOCUMENTOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_documentos_id;
			}
			set
			{
				_descuento_documentos_idNull = false;
				_descuento_documentos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_DOCUMENTOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_DOCUMENTOS_IDNull
		{
			get { return _descuento_documentos_idNull; }
			set { _descuento_documentos_idNull = value; }
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
		/// Gets or sets the <c>MOTIVO_RECHAZO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_RECHAZO</c> column value.</value>
		public string MOTIVO_RECHAZO
		{
			get { return _motivo_rechazo; }
			set { _motivo_rechazo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_ESTADO_ID</c> column value.</value>
		public decimal CHEQUE_ESTADO_ID
		{
			get
			{
				if(IsCHEQUE_ESTADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_estado_id;
			}
			set
			{
				_cheque_estado_idNull = false;
				_cheque_estado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_ESTADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_ESTADO_IDNull
		{
			get { return _cheque_estado_idNull; }
			set { _cheque_estado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_CHEQUE</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_CHEQUE</c> column value.</value>
		public string ESTADO_CHEQUE
		{
			get { return _estado_cheque; }
			set { _estado_cheque = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ABREVIADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ABREVIADO</c> column value.</value>
		public string ESTADO_ABREVIADO
		{
			get { return _estado_abreviado; }
			set { _estado_abreviado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_DE_TERCEROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_DE_TERCEROS</c> column value.</value>
		public string CHEQUE_DE_TERCEROS
		{
			get { return _cheque_de_terceros; }
			set { _cheque_de_terceros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_CREADOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_CREADOR_ID</c> column value.</value>
		public decimal CASO_CREADOR_ID
		{
			get
			{
				if(IsCASO_CREADOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_creador_id;
			}
			set
			{
				_caso_creador_idNull = false;
				_caso_creador_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_CREADOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_CREADOR_IDNull
		{
			get { return _caso_creador_idNull; }
			set { _caso_creador_idNull = value; }
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
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
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
		/// Gets or sets the <c>ES_DIFERIDO</c> column value.
		/// </summary>
		/// <value>The <c>ES_DIFERIDO</c> column value.</value>
		public string ES_DIFERIDO
		{
			get { return _es_diferido; }
			set { _es_diferido = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_ASIGNADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ASIGNADO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ASIGNADO_ID
		{
			get
			{
				if(IsFUNCIONARIO_ASIGNADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_asignado_id;
			}
			set
			{
				_funcionario_asignado_idNull = false;
				_funcionario_asignado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ASIGNADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_ASIGNADO_IDNull
		{
			get { return _funcionario_asignado_idNull; }
			set { _funcionario_asignado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ASIGNADO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ASIGNADO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_ASIGNADO_NOMBRE
		{
			get { return _funcionario_asignado_nombre; }
			set { _funcionario_asignado_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DATOS_RESUMIDOS_SIN_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DATOS_RESUMIDOS_SIN_MONTO</c> column value.</value>
		public string DATOS_RESUMIDOS_SIN_MONTO
		{
			get { return _datos_resumidos_sin_monto; }
			set { _datos_resumidos_sin_monto = value; }
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
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(CTACTE_BANCO_ID);
			dynStr.Append("@CBA@BANCO_NOMBRE=");
			dynStr.Append(BANCO_NOMBRE);
			dynStr.Append("@CBA@BANCO_ABREVIATURA=");
			dynStr.Append(BANCO_ABREVIATURA);
			dynStr.Append("@CBA@BANCO_CODIGO=");
			dynStr.Append(BANCO_CODIGO);
			dynStr.Append("@CBA@BANCO_ENTIDAD=");
			dynStr.Append(BANCO_ENTIDAD);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@NUMERO_CUENTA=");
			dynStr.Append(NUMERO_CUENTA);
			dynStr.Append("@CBA@NUMERO_CHEQUE=");
			dynStr.Append(NUMERO_CHEQUE);
			dynStr.Append("@CBA@NOMBRE_EMISOR=");
			dynStr.Append(NOMBRE_EMISOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_POSDATADO=");
			dynStr.Append(FECHA_POSDATADO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_COBRO=");
			dynStr.Append(IsFECHA_COBRONull ? (object)"<NULL>" : FECHA_COBRO);
			dynStr.Append("@CBA@FECHA_RECHAZO=");
			dynStr.Append(IsFECHA_RECHAZONull ? (object)"<NULL>" : FECHA_RECHAZO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@NUMERO_DOCUMENTO_EMISOR=");
			dynStr.Append(NUMERO_DOCUMENTO_EMISOR);
			dynStr.Append("@CBA@MONEDAS_NOMBRE=");
			dynStr.Append(MONEDAS_NOMBRE);
			dynStr.Append("@CBA@MONEDAS_SIMBOLO=");
			dynStr.Append(MONEDAS_SIMBOLO);
			dynStr.Append("@CBA@CANTIDADES_DECIMALES=");
			dynStr.Append(CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_ID);
			dynStr.Append("@CBA@CUSTODIA_VALORES_ID=");
			dynStr.Append(IsCUSTODIA_VALORES_IDNull ? (object)"<NULL>" : CUSTODIA_VALORES_ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTOS_ID=");
			dynStr.Append(IsDESCUENTO_DOCUMENTOS_IDNull ? (object)"<NULL>" : DESCUENTO_DOCUMENTOS_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@MOTIVO_RECHAZO=");
			dynStr.Append(MOTIVO_RECHAZO);
			dynStr.Append("@CBA@CHEQUE_ESTADO_ID=");
			dynStr.Append(IsCHEQUE_ESTADO_IDNull ? (object)"<NULL>" : CHEQUE_ESTADO_ID);
			dynStr.Append("@CBA@ESTADO_CHEQUE=");
			dynStr.Append(ESTADO_CHEQUE);
			dynStr.Append("@CBA@ESTADO_ABREVIADO=");
			dynStr.Append(ESTADO_ABREVIADO);
			dynStr.Append("@CBA@CHEQUE_DE_TERCEROS=");
			dynStr.Append(CHEQUE_DE_TERCEROS);
			dynStr.Append("@CBA@CASO_CREADOR_ID=");
			dynStr.Append(IsCASO_CREADOR_IDNull ? (object)"<NULL>" : CASO_CREADOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PROVEEDOR_RAZON_SOCIAL=");
			dynStr.Append(PROVEEDOR_RAZON_SOCIAL);
			dynStr.Append("@CBA@ES_DIFERIDO=");
			dynStr.Append(ES_DIFERIDO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESORERIA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ASIGNADO_ID=");
			dynStr.Append(IsFUNCIONARIO_ASIGNADO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ASIGNADO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ASIGNADO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_ASIGNADO_NOMBRE);
			dynStr.Append("@CBA@DATOS_RESUMIDOS_SIN_MONTO=");
			dynStr.Append(DATOS_RESUMIDOS_SIN_MONTO);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHEQUES_REC_INFO_COMPLRow_Base class
} // End of namespace
