// <fileinfo name="DESCUENTO_DOCUMENTOS_CLI_INF_CRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTO_DOCUMENTOS_CLI_INF_CRow"/> that 
	/// represents a record in the <c>DESCUENTO_DOCUMENTOS_CLI_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTO_DOCUMENTOS_CLI_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTO_DOCUMENTOS_CLI_INF_CRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _ctacte_caja_tesoreria_id;
		private bool _ctacte_caja_tesoreria_idNull = true;
		private string _sucursal_abreviatura;
		private decimal _persona_id;
		private string _persona_nombre_completo;
		private decimal _persona_garante_id;
		private bool _persona_garante_idNull = true;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private System.DateTime _fecha;
		private string _observacion;
		private decimal _moneda_id;
		private string _moneda_simbolo;
		private string _moneda_nombre;
		private decimal _cotizacion_moneda;
		private decimal _monto_gasto_extra;
		private decimal _porcentaje_diario_mora;
		private decimal _funcionario_id;
		private string _cheque_es_diferido;
		private string _funcionario_nombre_completo;
		private decimal _total_valor_nominal;
		private bool _total_valor_nominalNull = true;
		private decimal _total_retencion;
		private bool _total_retencionNull = true;
		private decimal _total_valor_efectivo;
		private bool _total_valor_efectivoNull = true;
		private string _afectar_ctacte_persona_debito;
		private string _descuento_doc_con_recurso;
		private string _usar_interes_en_calculo;
		private string _interes_incluye_impuesto;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTO_DOCUMENTOS_CLI_INF_CRow_Base"/> class.
		/// </summary>
		public DESCUENTO_DOCUMENTOS_CLI_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTO_DOCUMENTOS_CLI_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.IsCTACTE_CAJA_TESORERIA_IDNull != original.IsCTACTE_CAJA_TESORERIA_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESORERIA_IDNull && !original.IsCTACTE_CAJA_TESORERIA_IDNull)
				if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.IsPERSONA_GARANTE_IDNull != original.IsPERSONA_GARANTE_IDNull) return true;
			if (!this.IsPERSONA_GARANTE_IDNull && !original.IsPERSONA_GARANTE_IDNull)
				if (this.PERSONA_GARANTE_ID != original.PERSONA_GARANTE_ID) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_GASTO_EXTRA != original.MONTO_GASTO_EXTRA) return true;
			if (this.PORCENTAJE_DIARIO_MORA != original.PORCENTAJE_DIARIO_MORA) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.CHEQUE_ES_DIFERIDO != original.CHEQUE_ES_DIFERIDO) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.IsTOTAL_VALOR_NOMINALNull != original.IsTOTAL_VALOR_NOMINALNull) return true;
			if (!this.IsTOTAL_VALOR_NOMINALNull && !original.IsTOTAL_VALOR_NOMINALNull)
				if (this.TOTAL_VALOR_NOMINAL != original.TOTAL_VALOR_NOMINAL) return true;
			if (this.IsTOTAL_RETENCIONNull != original.IsTOTAL_RETENCIONNull) return true;
			if (!this.IsTOTAL_RETENCIONNull && !original.IsTOTAL_RETENCIONNull)
				if (this.TOTAL_RETENCION != original.TOTAL_RETENCION) return true;
			if (this.IsTOTAL_VALOR_EFECTIVONull != original.IsTOTAL_VALOR_EFECTIVONull) return true;
			if (!this.IsTOTAL_VALOR_EFECTIVONull && !original.IsTOTAL_VALOR_EFECTIVONull)
				if (this.TOTAL_VALOR_EFECTIVO != original.TOTAL_VALOR_EFECTIVO) return true;
			if (this.AFECTAR_CTACTE_PERSONA_DEBITO != original.AFECTAR_CTACTE_PERSONA_DEBITO) return true;
			if (this.DESCUENTO_DOC_CON_RECURSO != original.DESCUENTO_DOC_CON_RECURSO) return true;
			if (this.USAR_INTERES_EN_CALCULO != original.USAR_INTERES_EN_CALCULO) return true;
			if (this.INTERES_INCLUYE_IMPUESTO != original.INTERES_INCLUYE_IMPUESTO) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
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
		/// Gets or sets the <c>PERSONA_GARANTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_GARANTE_ID</c> column value.</value>
		public decimal PERSONA_GARANTE_ID
		{
			get
			{
				if(IsPERSONA_GARANTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_garante_id;
			}
			set
			{
				_persona_garante_idNull = false;
				_persona_garante_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_GARANTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_GARANTE_IDNull
		{
			get { return _persona_garante_idNull; }
			set { _persona_garante_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
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
		/// Gets or sets the <c>MONTO_GASTO_EXTRA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_GASTO_EXTRA</c> column value.</value>
		public decimal MONTO_GASTO_EXTRA
		{
			get { return _monto_gasto_extra; }
			set { _monto_gasto_extra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DIARIO_MORA</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DIARIO_MORA</c> column value.</value>
		public decimal PORCENTAJE_DIARIO_MORA
		{
			get { return _porcentaje_diario_mora; }
			set { _porcentaje_diario_mora = value; }
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
		/// Gets or sets the <c>CHEQUE_ES_DIFERIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_ES_DIFERIDO</c> column value.</value>
		public string CHEQUE_ES_DIFERIDO
		{
			get { return _cheque_es_diferido; }
			set { _cheque_es_diferido = value; }
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
		/// Gets or sets the <c>TOTAL_VALOR_NOMINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_VALOR_NOMINAL</c> column value.</value>
		public decimal TOTAL_VALOR_NOMINAL
		{
			get
			{
				if(IsTOTAL_VALOR_NOMINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_valor_nominal;
			}
			set
			{
				_total_valor_nominalNull = false;
				_total_valor_nominal = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_VALOR_NOMINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_VALOR_NOMINALNull
		{
			get { return _total_valor_nominalNull; }
			set { _total_valor_nominalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_RETENCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_RETENCION</c> column value.</value>
		public decimal TOTAL_RETENCION
		{
			get
			{
				if(IsTOTAL_RETENCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_retencion;
			}
			set
			{
				_total_retencionNull = false;
				_total_retencion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_RETENCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_RETENCIONNull
		{
			get { return _total_retencionNull; }
			set { _total_retencionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_VALOR_EFECTIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_VALOR_EFECTIVO</c> column value.</value>
		public decimal TOTAL_VALOR_EFECTIVO
		{
			get
			{
				if(IsTOTAL_VALOR_EFECTIVONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_valor_efectivo;
			}
			set
			{
				_total_valor_efectivoNull = false;
				_total_valor_efectivo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_VALOR_EFECTIVO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_VALOR_EFECTIVONull
		{
			get { return _total_valor_efectivoNull; }
			set { _total_valor_efectivoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTAR_CTACTE_PERSONA_DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AFECTAR_CTACTE_PERSONA_DEBITO</c> column value.</value>
		public string AFECTAR_CTACTE_PERSONA_DEBITO
		{
			get { return _afectar_ctacte_persona_debito; }
			set { _afectar_ctacte_persona_debito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_DOC_CON_RECURSO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOC_CON_RECURSO</c> column value.</value>
		public string DESCUENTO_DOC_CON_RECURSO
		{
			get { return _descuento_doc_con_recurso; }
			set { _descuento_doc_con_recurso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_INTERES_EN_CALCULO</c> column value.
		/// </summary>
		/// <value>The <c>USAR_INTERES_EN_CALCULO</c> column value.</value>
		public string USAR_INTERES_EN_CALCULO
		{
			get { return _usar_interes_en_calculo; }
			set { _usar_interes_en_calculo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_INCLUYE_IMPUESTO</c> column value.</value>
		public string INTERES_INCLUYE_IMPUESTO
		{
			get { return _interes_incluye_impuesto; }
			set { _interes_incluye_impuesto = value; }
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
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESORERIA_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_GARANTE_ID=");
			dynStr.Append(IsPERSONA_GARANTE_IDNull ? (object)"<NULL>" : PERSONA_GARANTE_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_GASTO_EXTRA=");
			dynStr.Append(MONTO_GASTO_EXTRA);
			dynStr.Append("@CBA@PORCENTAJE_DIARIO_MORA=");
			dynStr.Append(PORCENTAJE_DIARIO_MORA);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@CHEQUE_ES_DIFERIDO=");
			dynStr.Append(CHEQUE_ES_DIFERIDO);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@TOTAL_VALOR_NOMINAL=");
			dynStr.Append(IsTOTAL_VALOR_NOMINALNull ? (object)"<NULL>" : TOTAL_VALOR_NOMINAL);
			dynStr.Append("@CBA@TOTAL_RETENCION=");
			dynStr.Append(IsTOTAL_RETENCIONNull ? (object)"<NULL>" : TOTAL_RETENCION);
			dynStr.Append("@CBA@TOTAL_VALOR_EFECTIVO=");
			dynStr.Append(IsTOTAL_VALOR_EFECTIVONull ? (object)"<NULL>" : TOTAL_VALOR_EFECTIVO);
			dynStr.Append("@CBA@AFECTAR_CTACTE_PERSONA_DEBITO=");
			dynStr.Append(AFECTAR_CTACTE_PERSONA_DEBITO);
			dynStr.Append("@CBA@DESCUENTO_DOC_CON_RECURSO=");
			dynStr.Append(DESCUENTO_DOC_CON_RECURSO);
			dynStr.Append("@CBA@USAR_INTERES_EN_CALCULO=");
			dynStr.Append(USAR_INTERES_EN_CALCULO);
			dynStr.Append("@CBA@INTERES_INCLUYE_IMPUESTO=");
			dynStr.Append(INTERES_INCLUYE_IMPUESTO);
			return dynStr.ToString();
		}
	} // End of DESCUENTO_DOCUMENTOS_CLI_INF_CRow_Base class
} // End of namespace
