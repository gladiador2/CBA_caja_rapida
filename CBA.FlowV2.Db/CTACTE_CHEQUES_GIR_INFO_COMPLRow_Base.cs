// <fileinfo name="CTACTE_CHEQUES_GIR_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_GIR_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTACTE_CHEQUES_GIR_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CHEQUES_GIR_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_GIR_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ctacte_banco_id;
		private string _banco_nombre;
		private string _banco_abreviatura;
		private decimal _banco_entidad;
		private string _entidad_nombre;
		private decimal _ctacte_bancaria_id;
		private string _ctacte_bancarias_numero;
		private string _numero_cheque;
		private string _nombre_emisor;
		private string _nombre_beneficiario;
		private string _numero_cta_beneficiario;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_posdatado;
		private System.DateTime _fecha_vencimiento;
		private System.DateTime _fecha_cobro;
		private bool _fecha_cobroNull = true;
		private System.DateTime _fecha_entrega;
		private bool _fecha_entregaNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _monedas_nombre;
		private string _monedas_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private string _saldo_afectado;
		private decimal _cheque_estado_id;
		private bool _cheque_estado_idNull = true;
		private string _cheque_estado;
		private string _motivo_anulacion;
		private decimal _caso_creador_id;
		private bool _caso_creador_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _timbrado;
		private decimal _impresion_delta_altura;
		private bool _impresion_delta_alturaNull = true;
		private decimal _impresion_delta_ancho;
		private bool _impresion_delta_anchoNull = true;
		private string _es_diferido;
		private string _observacion;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_GIR_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTACTE_CHEQUES_GIR_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CHEQUES_GIR_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.BANCO_NOMBRE != original.BANCO_NOMBRE) return true;
			if (this.BANCO_ABREVIATURA != original.BANCO_ABREVIATURA) return true;
			if (this.BANCO_ENTIDAD != original.BANCO_ENTIDAD) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.CTACTE_BANCARIAS_NUMERO != original.CTACTE_BANCARIAS_NUMERO) return true;
			if (this.NUMERO_CHEQUE != original.NUMERO_CHEQUE) return true;
			if (this.NOMBRE_EMISOR != original.NOMBRE_EMISOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.NUMERO_CTA_BENEFICIARIO != original.NUMERO_CTA_BENEFICIARIO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.FECHA_POSDATADO != original.FECHA_POSDATADO) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_COBRONull != original.IsFECHA_COBRONull) return true;
			if (!this.IsFECHA_COBRONull && !original.IsFECHA_COBRONull)
				if (this.FECHA_COBRO != original.FECHA_COBRO) return true;
			if (this.IsFECHA_ENTREGANull != original.IsFECHA_ENTREGANull) return true;
			if (!this.IsFECHA_ENTREGANull && !original.IsFECHA_ENTREGANull)
				if (this.FECHA_ENTREGA != original.FECHA_ENTREGA) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDAS_NOMBRE != original.MONEDAS_NOMBRE) return true;
			if (this.MONEDAS_SIMBOLO != original.MONEDAS_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.SALDO_AFECTADO != original.SALDO_AFECTADO) return true;
			if (this.IsCHEQUE_ESTADO_IDNull != original.IsCHEQUE_ESTADO_IDNull) return true;
			if (!this.IsCHEQUE_ESTADO_IDNull && !original.IsCHEQUE_ESTADO_IDNull)
				if (this.CHEQUE_ESTADO_ID != original.CHEQUE_ESTADO_ID) return true;
			if (this.CHEQUE_ESTADO != original.CHEQUE_ESTADO) return true;
			if (this.MOTIVO_ANULACION != original.MOTIVO_ANULACION) return true;
			if (this.IsCASO_CREADOR_IDNull != original.IsCASO_CREADOR_IDNull) return true;
			if (!this.IsCASO_CREADOR_IDNull && !original.IsCASO_CREADOR_IDNull)
				if (this.CASO_CREADOR_ID != original.CASO_CREADOR_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.TIMBRADO != original.TIMBRADO) return true;
			if (this.IsIMPRESION_DELTA_ALTURANull != original.IsIMPRESION_DELTA_ALTURANull) return true;
			if (!this.IsIMPRESION_DELTA_ALTURANull && !original.IsIMPRESION_DELTA_ALTURANull)
				if (this.IMPRESION_DELTA_ALTURA != original.IMPRESION_DELTA_ALTURA) return true;
			if (this.IsIMPRESION_DELTA_ANCHONull != original.IsIMPRESION_DELTA_ANCHONull) return true;
			if (!this.IsIMPRESION_DELTA_ANCHONull && !original.IsIMPRESION_DELTA_ANCHONull)
				if (this.IMPRESION_DELTA_ANCHO != original.IMPRESION_DELTA_ANCHO) return true;
			if (this.ES_DIFERIDO != original.ES_DIFERIDO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get { return _ctacte_bancaria_id; }
			set { _ctacte_bancaria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIAS_NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIAS_NUMERO</c> column value.</value>
		public string CTACTE_BANCARIAS_NUMERO
		{
			get { return _ctacte_bancarias_numero; }
			set { _ctacte_bancarias_numero = value; }
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
		/// Gets or sets the <c>NUMERO_CTA_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_CTA_BENEFICIARIO</c> column value.</value>
		public string NUMERO_CTA_BENEFICIARIO
		{
			get { return _numero_cta_beneficiario; }
			set { _numero_cta_beneficiario = value; }
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
		/// Gets or sets the <c>SALDO_AFECTADO</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_AFECTADO</c> column value.</value>
		public string SALDO_AFECTADO
		{
			get { return _saldo_afectado; }
			set { _saldo_afectado = value; }
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
		/// Gets or sets the <c>CHEQUE_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CHEQUE_ESTADO</c> column value.</value>
		public string CHEQUE_ESTADO
		{
			get { return _cheque_estado; }
			set { _cheque_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_ANULACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_ANULACION</c> column value.</value>
		public string MOTIVO_ANULACION
		{
			get { return _motivo_anulacion; }
			set { _motivo_anulacion = value; }
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
		/// Gets or sets the <c>TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIMBRADO</c> column value.</value>
		public string TIMBRADO
		{
			get { return _timbrado; }
			set { _timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESION_DELTA_ALTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPRESION_DELTA_ALTURA</c> column value.</value>
		public decimal IMPRESION_DELTA_ALTURA
		{
			get
			{
				if(IsIMPRESION_DELTA_ALTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impresion_delta_altura;
			}
			set
			{
				_impresion_delta_alturaNull = false;
				_impresion_delta_altura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPRESION_DELTA_ALTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPRESION_DELTA_ALTURANull
		{
			get { return _impresion_delta_alturaNull; }
			set { _impresion_delta_alturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESION_DELTA_ANCHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPRESION_DELTA_ANCHO</c> column value.</value>
		public decimal IMPRESION_DELTA_ANCHO
		{
			get
			{
				if(IsIMPRESION_DELTA_ANCHONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impresion_delta_ancho;
			}
			set
			{
				_impresion_delta_anchoNull = false;
				_impresion_delta_ancho = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPRESION_DELTA_ANCHO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPRESION_DELTA_ANCHONull
		{
			get { return _impresion_delta_anchoNull; }
			set { _impresion_delta_anchoNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append("@CBA@BANCO_ENTIDAD=");
			dynStr.Append(BANCO_ENTIDAD);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@CTACTE_BANCARIAS_NUMERO=");
			dynStr.Append(CTACTE_BANCARIAS_NUMERO);
			dynStr.Append("@CBA@NUMERO_CHEQUE=");
			dynStr.Append(NUMERO_CHEQUE);
			dynStr.Append("@CBA@NOMBRE_EMISOR=");
			dynStr.Append(NOMBRE_EMISOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@NUMERO_CTA_BENEFICIARIO=");
			dynStr.Append(NUMERO_CTA_BENEFICIARIO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_POSDATADO=");
			dynStr.Append(FECHA_POSDATADO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_COBRO=");
			dynStr.Append(IsFECHA_COBRONull ? (object)"<NULL>" : FECHA_COBRO);
			dynStr.Append("@CBA@FECHA_ENTREGA=");
			dynStr.Append(IsFECHA_ENTREGANull ? (object)"<NULL>" : FECHA_ENTREGA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDAS_NOMBRE=");
			dynStr.Append(MONEDAS_NOMBRE);
			dynStr.Append("@CBA@MONEDAS_SIMBOLO=");
			dynStr.Append(MONEDAS_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@SALDO_AFECTADO=");
			dynStr.Append(SALDO_AFECTADO);
			dynStr.Append("@CBA@CHEQUE_ESTADO_ID=");
			dynStr.Append(IsCHEQUE_ESTADO_IDNull ? (object)"<NULL>" : CHEQUE_ESTADO_ID);
			dynStr.Append("@CBA@CHEQUE_ESTADO=");
			dynStr.Append(CHEQUE_ESTADO);
			dynStr.Append("@CBA@MOTIVO_ANULACION=");
			dynStr.Append(MOTIVO_ANULACION);
			dynStr.Append("@CBA@CASO_CREADOR_ID=");
			dynStr.Append(IsCASO_CREADOR_IDNull ? (object)"<NULL>" : CASO_CREADOR_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@TIMBRADO=");
			dynStr.Append(TIMBRADO);
			dynStr.Append("@CBA@IMPRESION_DELTA_ALTURA=");
			dynStr.Append(IsIMPRESION_DELTA_ALTURANull ? (object)"<NULL>" : IMPRESION_DELTA_ALTURA);
			dynStr.Append("@CBA@IMPRESION_DELTA_ANCHO=");
			dynStr.Append(IsIMPRESION_DELTA_ANCHONull ? (object)"<NULL>" : IMPRESION_DELTA_ANCHO);
			dynStr.Append("@CBA@ES_DIFERIDO=");
			dynStr.Append(ES_DIFERIDO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_CHEQUES_GIR_INFO_COMPLRow_Base class
} // End of namespace
