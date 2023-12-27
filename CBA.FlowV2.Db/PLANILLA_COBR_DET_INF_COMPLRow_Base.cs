// <fileinfo name="PLANILLA_COBR_DET_INF_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> that 
	/// represents a record in the <c>PLANILLA_COBR_DET_INF_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBR_DET_INF_COMPLRow_Base
	{
		private decimal _id;
		private decimal _planilla_cobranza_id;
		private decimal _persona_id;
		private string _persona_nombre;
		private string _persona_codigo;
		private string _direccion_cobro;
		private decimal _monto_cuota;
		private decimal _monto_mora;
		private decimal _moneda_id;
		private string _moneda_monto_nombre;
		private string _moneda_monto_simbolo;
		private decimal _moneda_monto_decimales;
		private bool _moneda_monto_decimalesNull = true;
		private string _moneda_monto_cadena_decimales;
		private decimal _monto_cobrado;
		private bool _monto_cobradoNull = true;
		private decimal _moneda_cobrado_id;
		private bool _moneda_cobrado_idNull = true;
		private string _moneda_cobrado_nombre;
		private string _moneda_cobrado_simbolo;
		private decimal _moneda_cobrado_decimales;
		private bool _moneda_cobrado_decimalesNull = true;
		private string _moneda_cobrad_cadena_decimales;
		private decimal _ctacte_recibo_impreso_id;
		private bool _ctacte_recibo_impreso_idNull = true;
		private decimal _recibo_impreso_talonario_id;
		private bool _recibo_impreso_talonario_idNull = true;
		private string _rec_impreso_talonario_tipo;
		private string _nro_recibo_impreso;
		private string _recibo_impreso_estado;
		private decimal _ctacte_recibo_entregado_id;
		private bool _ctacte_recibo_entregado_idNull = true;
		private decimal _recibo_entregado_talonario_id;
		private bool _recibo_entregado_talonario_idNull = true;
		private string _rec_entregado_talonario_tipo;
		private string _nro_recibo_entregado;
		private string _recibo_entregado_estado;
		private decimal _caso_pago_id;
		private bool _caso_pago_idNull = true;
		private string _caso_pago_estado;
		private string _caso_pago_comprobante;
		private string _observacion;
		private decimal _cotizacion_cobrada;
		private bool _cotizacion_cobradaNull = true;
		private string _pago_confirmado;
		private decimal _funcionario_cajero_id;
		private bool _funcionario_cajero_idNull = true;
		private string _funcionario_cajero_nombre;
		private System.DateTime _fecha_postergacion;
		private bool _fecha_postergacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBR_DET_INF_COMPLRow_Base"/> class.
		/// </summary>
		public PLANILLA_COBR_DET_INF_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_COBR_DET_INF_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANILLA_COBRANZA_ID != original.PLANILLA_COBRANZA_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.DIRECCION_COBRO != original.DIRECCION_COBRO) return true;
			if (this.MONTO_CUOTA != original.MONTO_CUOTA) return true;
			if (this.MONTO_MORA != original.MONTO_MORA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_MONTO_NOMBRE != original.MONEDA_MONTO_NOMBRE) return true;
			if (this.MONEDA_MONTO_SIMBOLO != original.MONEDA_MONTO_SIMBOLO) return true;
			if (this.IsMONEDA_MONTO_DECIMALESNull != original.IsMONEDA_MONTO_DECIMALESNull) return true;
			if (!this.IsMONEDA_MONTO_DECIMALESNull && !original.IsMONEDA_MONTO_DECIMALESNull)
				if (this.MONEDA_MONTO_DECIMALES != original.MONEDA_MONTO_DECIMALES) return true;
			if (this.MONEDA_MONTO_CADENA_DECIMALES != original.MONEDA_MONTO_CADENA_DECIMALES) return true;
			if (this.IsMONTO_COBRADONull != original.IsMONTO_COBRADONull) return true;
			if (!this.IsMONTO_COBRADONull && !original.IsMONTO_COBRADONull)
				if (this.MONTO_COBRADO != original.MONTO_COBRADO) return true;
			if (this.IsMONEDA_COBRADO_IDNull != original.IsMONEDA_COBRADO_IDNull) return true;
			if (!this.IsMONEDA_COBRADO_IDNull && !original.IsMONEDA_COBRADO_IDNull)
				if (this.MONEDA_COBRADO_ID != original.MONEDA_COBRADO_ID) return true;
			if (this.MONEDA_COBRADO_NOMBRE != original.MONEDA_COBRADO_NOMBRE) return true;
			if (this.MONEDA_COBRADO_SIMBOLO != original.MONEDA_COBRADO_SIMBOLO) return true;
			if (this.IsMONEDA_COBRADO_DECIMALESNull != original.IsMONEDA_COBRADO_DECIMALESNull) return true;
			if (!this.IsMONEDA_COBRADO_DECIMALESNull && !original.IsMONEDA_COBRADO_DECIMALESNull)
				if (this.MONEDA_COBRADO_DECIMALES != original.MONEDA_COBRADO_DECIMALES) return true;
			if (this.MONEDA_COBRAD_CADENA_DECIMALES != original.MONEDA_COBRAD_CADENA_DECIMALES) return true;
			if (this.IsCTACTE_RECIBO_IMPRESO_IDNull != original.IsCTACTE_RECIBO_IMPRESO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_IMPRESO_IDNull && !original.IsCTACTE_RECIBO_IMPRESO_IDNull)
				if (this.CTACTE_RECIBO_IMPRESO_ID != original.CTACTE_RECIBO_IMPRESO_ID) return true;
			if (this.IsRECIBO_IMPRESO_TALONARIO_IDNull != original.IsRECIBO_IMPRESO_TALONARIO_IDNull) return true;
			if (!this.IsRECIBO_IMPRESO_TALONARIO_IDNull && !original.IsRECIBO_IMPRESO_TALONARIO_IDNull)
				if (this.RECIBO_IMPRESO_TALONARIO_ID != original.RECIBO_IMPRESO_TALONARIO_ID) return true;
			if (this.REC_IMPRESO_TALONARIO_TIPO != original.REC_IMPRESO_TALONARIO_TIPO) return true;
			if (this.NRO_RECIBO_IMPRESO != original.NRO_RECIBO_IMPRESO) return true;
			if (this.RECIBO_IMPRESO_ESTADO != original.RECIBO_IMPRESO_ESTADO) return true;
			if (this.IsCTACTE_RECIBO_ENTREGADO_IDNull != original.IsCTACTE_RECIBO_ENTREGADO_IDNull) return true;
			if (!this.IsCTACTE_RECIBO_ENTREGADO_IDNull && !original.IsCTACTE_RECIBO_ENTREGADO_IDNull)
				if (this.CTACTE_RECIBO_ENTREGADO_ID != original.CTACTE_RECIBO_ENTREGADO_ID) return true;
			if (this.IsRECIBO_ENTREGADO_TALONARIO_IDNull != original.IsRECIBO_ENTREGADO_TALONARIO_IDNull) return true;
			if (!this.IsRECIBO_ENTREGADO_TALONARIO_IDNull && !original.IsRECIBO_ENTREGADO_TALONARIO_IDNull)
				if (this.RECIBO_ENTREGADO_TALONARIO_ID != original.RECIBO_ENTREGADO_TALONARIO_ID) return true;
			if (this.REC_ENTREGADO_TALONARIO_TIPO != original.REC_ENTREGADO_TALONARIO_TIPO) return true;
			if (this.NRO_RECIBO_ENTREGADO != original.NRO_RECIBO_ENTREGADO) return true;
			if (this.RECIBO_ENTREGADO_ESTADO != original.RECIBO_ENTREGADO_ESTADO) return true;
			if (this.IsCASO_PAGO_IDNull != original.IsCASO_PAGO_IDNull) return true;
			if (!this.IsCASO_PAGO_IDNull && !original.IsCASO_PAGO_IDNull)
				if (this.CASO_PAGO_ID != original.CASO_PAGO_ID) return true;
			if (this.CASO_PAGO_ESTADO != original.CASO_PAGO_ESTADO) return true;
			if (this.CASO_PAGO_COMPROBANTE != original.CASO_PAGO_COMPROBANTE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCOTIZACION_COBRADANull != original.IsCOTIZACION_COBRADANull) return true;
			if (!this.IsCOTIZACION_COBRADANull && !original.IsCOTIZACION_COBRADANull)
				if (this.COTIZACION_COBRADA != original.COTIZACION_COBRADA) return true;
			if (this.PAGO_CONFIRMADO != original.PAGO_CONFIRMADO) return true;
			if (this.IsFUNCIONARIO_CAJERO_IDNull != original.IsFUNCIONARIO_CAJERO_IDNull) return true;
			if (!this.IsFUNCIONARIO_CAJERO_IDNull && !original.IsFUNCIONARIO_CAJERO_IDNull)
				if (this.FUNCIONARIO_CAJERO_ID != original.FUNCIONARIO_CAJERO_ID) return true;
			if (this.FUNCIONARIO_CAJERO_NOMBRE != original.FUNCIONARIO_CAJERO_NOMBRE) return true;
			if (this.IsFECHA_POSTERGACIONNull != original.IsFECHA_POSTERGACIONNull) return true;
			if (!this.IsFECHA_POSTERGACIONNull && !original.IsFECHA_POSTERGACIONNull)
				if (this.FECHA_POSTERGACION != original.FECHA_POSTERGACION) return true;
			
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
		/// Gets or sets the <c>PLANILLA_COBRANZA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_COBRANZA_ID</c> column value.</value>
		public decimal PLANILLA_COBRANZA_ID
		{
			get { return _planilla_cobranza_id; }
			set { _planilla_cobranza_id = value; }
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
		/// Gets or sets the <c>DIRECCION_COBRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION_COBRO</c> column value.</value>
		public string DIRECCION_COBRO
		{
			get { return _direccion_cobro; }
			set { _direccion_cobro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CUOTA</c> column value.</value>
		public decimal MONTO_CUOTA
		{
			get { return _monto_cuota; }
			set { _monto_cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_MORA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_MORA</c> column value.</value>
		public decimal MONTO_MORA
		{
			get { return _monto_mora; }
			set { _monto_mora = value; }
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
		/// Gets or sets the <c>MONEDA_MONTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_MONTO_NOMBRE</c> column value.</value>
		public string MONEDA_MONTO_NOMBRE
		{
			get { return _moneda_monto_nombre; }
			set { _moneda_monto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_MONTO_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_MONTO_SIMBOLO</c> column value.</value>
		public string MONEDA_MONTO_SIMBOLO
		{
			get { return _moneda_monto_simbolo; }
			set { _moneda_monto_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_MONTO_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_MONTO_DECIMALES</c> column value.</value>
		public decimal MONEDA_MONTO_DECIMALES
		{
			get
			{
				if(IsMONEDA_MONTO_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_monto_decimales;
			}
			set
			{
				_moneda_monto_decimalesNull = false;
				_moneda_monto_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_MONTO_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_MONTO_DECIMALESNull
		{
			get { return _moneda_monto_decimalesNull; }
			set { _moneda_monto_decimalesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_MONTO_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_MONTO_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_MONTO_CADENA_DECIMALES
		{
			get { return _moneda_monto_cadena_decimales; }
			set { _moneda_monto_cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COBRADO</c> column value.</value>
		public decimal MONTO_COBRADO
		{
			get
			{
				if(IsMONTO_COBRADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_cobrado;
			}
			set
			{
				_monto_cobradoNull = false;
				_monto_cobrado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COBRADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COBRADONull
		{
			get { return _monto_cobradoNull; }
			set { _monto_cobradoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COBRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COBRADO_ID</c> column value.</value>
		public decimal MONEDA_COBRADO_ID
		{
			get
			{
				if(IsMONEDA_COBRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cobrado_id;
			}
			set
			{
				_moneda_cobrado_idNull = false;
				_moneda_cobrado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_COBRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_COBRADO_IDNull
		{
			get { return _moneda_cobrado_idNull; }
			set { _moneda_cobrado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COBRADO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COBRADO_NOMBRE</c> column value.</value>
		public string MONEDA_COBRADO_NOMBRE
		{
			get { return _moneda_cobrado_nombre; }
			set { _moneda_cobrado_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COBRADO_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COBRADO_SIMBOLO</c> column value.</value>
		public string MONEDA_COBRADO_SIMBOLO
		{
			get { return _moneda_cobrado_simbolo; }
			set { _moneda_cobrado_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COBRADO_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COBRADO_DECIMALES</c> column value.</value>
		public decimal MONEDA_COBRADO_DECIMALES
		{
			get
			{
				if(IsMONEDA_COBRADO_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cobrado_decimales;
			}
			set
			{
				_moneda_cobrado_decimalesNull = false;
				_moneda_cobrado_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_COBRADO_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_COBRADO_DECIMALESNull
		{
			get { return _moneda_cobrado_decimalesNull; }
			set { _moneda_cobrado_decimalesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COBRAD_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COBRAD_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_COBRAD_CADENA_DECIMALES
		{
			get { return _moneda_cobrad_cadena_decimales; }
			set { _moneda_cobrad_cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</value>
		public decimal CTACTE_RECIBO_IMPRESO_ID
		{
			get
			{
				if(IsCTACTE_RECIBO_IMPRESO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_recibo_impreso_id;
			}
			set
			{
				_ctacte_recibo_impreso_idNull = false;
				_ctacte_recibo_impreso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RECIBO_IMPRESO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RECIBO_IMPRESO_IDNull
		{
			get { return _ctacte_recibo_impreso_idNull; }
			set { _ctacte_recibo_impreso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_IMPRESO_TALONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECIBO_IMPRESO_TALONARIO_ID</c> column value.</value>
		public decimal RECIBO_IMPRESO_TALONARIO_ID
		{
			get
			{
				if(IsRECIBO_IMPRESO_TALONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _recibo_impreso_talonario_id;
			}
			set
			{
				_recibo_impreso_talonario_idNull = false;
				_recibo_impreso_talonario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RECIBO_IMPRESO_TALONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRECIBO_IMPRESO_TALONARIO_IDNull
		{
			get { return _recibo_impreso_talonario_idNull; }
			set { _recibo_impreso_talonario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REC_IMPRESO_TALONARIO_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REC_IMPRESO_TALONARIO_TIPO</c> column value.</value>
		public string REC_IMPRESO_TALONARIO_TIPO
		{
			get { return _rec_impreso_talonario_tipo; }
			set { _rec_impreso_talonario_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_RECIBO_IMPRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_RECIBO_IMPRESO</c> column value.</value>
		public string NRO_RECIBO_IMPRESO
		{
			get { return _nro_recibo_impreso; }
			set { _nro_recibo_impreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_IMPRESO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECIBO_IMPRESO_ESTADO</c> column value.</value>
		public string RECIBO_IMPRESO_ESTADO
		{
			get { return _recibo_impreso_estado; }
			set { _recibo_impreso_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</value>
		public decimal CTACTE_RECIBO_ENTREGADO_ID
		{
			get
			{
				if(IsCTACTE_RECIBO_ENTREGADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_recibo_entregado_id;
			}
			set
			{
				_ctacte_recibo_entregado_idNull = false;
				_ctacte_recibo_entregado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RECIBO_ENTREGADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RECIBO_ENTREGADO_IDNull
		{
			get { return _ctacte_recibo_entregado_idNull; }
			set { _ctacte_recibo_entregado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_ENTREGADO_TALONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECIBO_ENTREGADO_TALONARIO_ID</c> column value.</value>
		public decimal RECIBO_ENTREGADO_TALONARIO_ID
		{
			get
			{
				if(IsRECIBO_ENTREGADO_TALONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _recibo_entregado_talonario_id;
			}
			set
			{
				_recibo_entregado_talonario_idNull = false;
				_recibo_entregado_talonario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RECIBO_ENTREGADO_TALONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRECIBO_ENTREGADO_TALONARIO_IDNull
		{
			get { return _recibo_entregado_talonario_idNull; }
			set { _recibo_entregado_talonario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REC_ENTREGADO_TALONARIO_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REC_ENTREGADO_TALONARIO_TIPO</c> column value.</value>
		public string REC_ENTREGADO_TALONARIO_TIPO
		{
			get { return _rec_entregado_talonario_tipo; }
			set { _rec_entregado_talonario_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_RECIBO_ENTREGADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_RECIBO_ENTREGADO</c> column value.</value>
		public string NRO_RECIBO_ENTREGADO
		{
			get { return _nro_recibo_entregado; }
			set { _nro_recibo_entregado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_ENTREGADO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RECIBO_ENTREGADO_ESTADO</c> column value.</value>
		public string RECIBO_ENTREGADO_ESTADO
		{
			get { return _recibo_entregado_estado; }
			set { _recibo_entregado_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_PAGO_ID</c> column value.</value>
		public decimal CASO_PAGO_ID
		{
			get
			{
				if(IsCASO_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_pago_id;
			}
			set
			{
				_caso_pago_idNull = false;
				_caso_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_PAGO_IDNull
		{
			get { return _caso_pago_idNull; }
			set { _caso_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_PAGO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_PAGO_ESTADO</c> column value.</value>
		public string CASO_PAGO_ESTADO
		{
			get { return _caso_pago_estado; }
			set { _caso_pago_estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_PAGO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_PAGO_COMPROBANTE</c> column value.</value>
		public string CASO_PAGO_COMPROBANTE
		{
			get { return _caso_pago_comprobante; }
			set { _caso_pago_comprobante = value; }
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
		/// Gets or sets the <c>COTIZACION_COBRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_COBRADA</c> column value.</value>
		public decimal COTIZACION_COBRADA
		{
			get
			{
				if(IsCOTIZACION_COBRADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_cobrada;
			}
			set
			{
				_cotizacion_cobradaNull = false;
				_cotizacion_cobrada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_COBRADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_COBRADANull
		{
			get { return _cotizacion_cobradaNull; }
			set { _cotizacion_cobradaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAGO_CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAGO_CONFIRMADO</c> column value.</value>
		public string PAGO_CONFIRMADO
		{
			get { return _pago_confirmado; }
			set { _pago_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CAJERO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CAJERO_ID</c> column value.</value>
		public decimal FUNCIONARIO_CAJERO_ID
		{
			get
			{
				if(IsFUNCIONARIO_CAJERO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_cajero_id;
			}
			set
			{
				_funcionario_cajero_idNull = false;
				_funcionario_cajero_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_CAJERO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_CAJERO_IDNull
		{
			get { return _funcionario_cajero_idNull; }
			set { _funcionario_cajero_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CAJERO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CAJERO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_CAJERO_NOMBRE
		{
			get { return _funcionario_cajero_nombre; }
			set { _funcionario_cajero_nombre = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PLANILLA_COBRANZA_ID=");
			dynStr.Append(PLANILLA_COBRANZA_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@DIRECCION_COBRO=");
			dynStr.Append(DIRECCION_COBRO);
			dynStr.Append("@CBA@MONTO_CUOTA=");
			dynStr.Append(MONTO_CUOTA);
			dynStr.Append("@CBA@MONTO_MORA=");
			dynStr.Append(MONTO_MORA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_MONTO_NOMBRE=");
			dynStr.Append(MONEDA_MONTO_NOMBRE);
			dynStr.Append("@CBA@MONEDA_MONTO_SIMBOLO=");
			dynStr.Append(MONEDA_MONTO_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_MONTO_DECIMALES=");
			dynStr.Append(IsMONEDA_MONTO_DECIMALESNull ? (object)"<NULL>" : MONEDA_MONTO_DECIMALES);
			dynStr.Append("@CBA@MONEDA_MONTO_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_MONTO_CADENA_DECIMALES);
			dynStr.Append("@CBA@MONTO_COBRADO=");
			dynStr.Append(IsMONTO_COBRADONull ? (object)"<NULL>" : MONTO_COBRADO);
			dynStr.Append("@CBA@MONEDA_COBRADO_ID=");
			dynStr.Append(IsMONEDA_COBRADO_IDNull ? (object)"<NULL>" : MONEDA_COBRADO_ID);
			dynStr.Append("@CBA@MONEDA_COBRADO_NOMBRE=");
			dynStr.Append(MONEDA_COBRADO_NOMBRE);
			dynStr.Append("@CBA@MONEDA_COBRADO_SIMBOLO=");
			dynStr.Append(MONEDA_COBRADO_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_COBRADO_DECIMALES=");
			dynStr.Append(IsMONEDA_COBRADO_DECIMALESNull ? (object)"<NULL>" : MONEDA_COBRADO_DECIMALES);
			dynStr.Append("@CBA@MONEDA_COBRAD_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_COBRAD_CADENA_DECIMALES);
			dynStr.Append("@CBA@CTACTE_RECIBO_IMPRESO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_IMPRESO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_IMPRESO_ID);
			dynStr.Append("@CBA@RECIBO_IMPRESO_TALONARIO_ID=");
			dynStr.Append(IsRECIBO_IMPRESO_TALONARIO_IDNull ? (object)"<NULL>" : RECIBO_IMPRESO_TALONARIO_ID);
			dynStr.Append("@CBA@REC_IMPRESO_TALONARIO_TIPO=");
			dynStr.Append(REC_IMPRESO_TALONARIO_TIPO);
			dynStr.Append("@CBA@NRO_RECIBO_IMPRESO=");
			dynStr.Append(NRO_RECIBO_IMPRESO);
			dynStr.Append("@CBA@RECIBO_IMPRESO_ESTADO=");
			dynStr.Append(RECIBO_IMPRESO_ESTADO);
			dynStr.Append("@CBA@CTACTE_RECIBO_ENTREGADO_ID=");
			dynStr.Append(IsCTACTE_RECIBO_ENTREGADO_IDNull ? (object)"<NULL>" : CTACTE_RECIBO_ENTREGADO_ID);
			dynStr.Append("@CBA@RECIBO_ENTREGADO_TALONARIO_ID=");
			dynStr.Append(IsRECIBO_ENTREGADO_TALONARIO_IDNull ? (object)"<NULL>" : RECIBO_ENTREGADO_TALONARIO_ID);
			dynStr.Append("@CBA@REC_ENTREGADO_TALONARIO_TIPO=");
			dynStr.Append(REC_ENTREGADO_TALONARIO_TIPO);
			dynStr.Append("@CBA@NRO_RECIBO_ENTREGADO=");
			dynStr.Append(NRO_RECIBO_ENTREGADO);
			dynStr.Append("@CBA@RECIBO_ENTREGADO_ESTADO=");
			dynStr.Append(RECIBO_ENTREGADO_ESTADO);
			dynStr.Append("@CBA@CASO_PAGO_ID=");
			dynStr.Append(IsCASO_PAGO_IDNull ? (object)"<NULL>" : CASO_PAGO_ID);
			dynStr.Append("@CBA@CASO_PAGO_ESTADO=");
			dynStr.Append(CASO_PAGO_ESTADO);
			dynStr.Append("@CBA@CASO_PAGO_COMPROBANTE=");
			dynStr.Append(CASO_PAGO_COMPROBANTE);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@COTIZACION_COBRADA=");
			dynStr.Append(IsCOTIZACION_COBRADANull ? (object)"<NULL>" : COTIZACION_COBRADA);
			dynStr.Append("@CBA@PAGO_CONFIRMADO=");
			dynStr.Append(PAGO_CONFIRMADO);
			dynStr.Append("@CBA@FUNCIONARIO_CAJERO_ID=");
			dynStr.Append(IsFUNCIONARIO_CAJERO_IDNull ? (object)"<NULL>" : FUNCIONARIO_CAJERO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_CAJERO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_CAJERO_NOMBRE);
			dynStr.Append("@CBA@FECHA_POSTERGACION=");
			dynStr.Append(IsFECHA_POSTERGACIONNull ? (object)"<NULL>" : FECHA_POSTERGACION);
			return dynStr.ToString();
		}
	} // End of PLANILLA_COBR_DET_INF_COMPLRow_Base class
} // End of namespace
