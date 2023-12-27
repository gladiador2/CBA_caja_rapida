// <fileinfo name="DESCUENTO_DOCUMENTOS_CLI_DETRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> that 
	/// represents a record in the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTO_DOCUMENTOS_CLI_DETRow_Base
	{
		private decimal _id;
		private decimal _descuento_documentos_cli_id;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _total_valor_nominal;
		private decimal _total_valor_efectivo;
		private decimal _total_retencion;
		private decimal _porcentaje_interes_anual;
		private decimal _porcentaje_gasto_admin;
		private decimal _ctacte_valor_id;
		private System.DateTime _fecha_creacion;
		private string _nro_comprobante;
		private string _nombre_deudor;
		private string _nombre_beneficiario;
		private decimal _cheque_ctacte_banco_id;
		private bool _cheque_ctacte_banco_idNull = true;
		private string _cheque_nro_cuenta;
		private string _cheque_de_terceros;
		private string _cheque_documento_emisor;
		private decimal _ctacte_documento_recibido_id;
		private bool _ctacte_documento_recibido_idNull = true;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private string _observacion;
		private string _cheque_es_diferido;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow_Base"/> class.
		/// </summary>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTO_DOCUMENTOS_CLI_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCUENTO_DOCUMENTOS_CLI_ID != original.DESCUENTO_DOCUMENTOS_CLI_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.TOTAL_VALOR_NOMINAL != original.TOTAL_VALOR_NOMINAL) return true;
			if (this.TOTAL_VALOR_EFECTIVO != original.TOTAL_VALOR_EFECTIVO) return true;
			if (this.TOTAL_RETENCION != original.TOTAL_RETENCION) return true;
			if (this.PORCENTAJE_INTERES_ANUAL != original.PORCENTAJE_INTERES_ANUAL) return true;
			if (this.PORCENTAJE_GASTO_ADMIN != original.PORCENTAJE_GASTO_ADMIN) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.NOMBRE_DEUDOR != original.NOMBRE_DEUDOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.IsCHEQUE_CTACTE_BANCO_IDNull != original.IsCHEQUE_CTACTE_BANCO_IDNull) return true;
			if (!this.IsCHEQUE_CTACTE_BANCO_IDNull && !original.IsCHEQUE_CTACTE_BANCO_IDNull)
				if (this.CHEQUE_CTACTE_BANCO_ID != original.CHEQUE_CTACTE_BANCO_ID) return true;
			if (this.CHEQUE_NRO_CUENTA != original.CHEQUE_NRO_CUENTA) return true;
			if (this.CHEQUE_DE_TERCEROS != original.CHEQUE_DE_TERCEROS) return true;
			if (this.CHEQUE_DOCUMENTO_EMISOR != original.CHEQUE_DOCUMENTO_EMISOR) return true;
			if (this.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull != original.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull && !original.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull)
				if (this.CTACTE_DOCUMENTO_RECIBIDO_ID != original.CTACTE_DOCUMENTO_RECIBIDO_ID) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.CHEQUE_ES_DIFERIDO != original.CHEQUE_ES_DIFERIDO) return true;
			
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
		/// Gets or sets the <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTOS_CLI_ID
		{
			get { return _descuento_documentos_cli_id; }
			set { _descuento_documentos_cli_id = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
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
		/// Gets or sets the <c>TOTAL_VALOR_NOMINAL</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_VALOR_NOMINAL</c> column value.</value>
		public decimal TOTAL_VALOR_NOMINAL
		{
			get { return _total_valor_nominal; }
			set { _total_valor_nominal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_VALOR_EFECTIVO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_VALOR_EFECTIVO</c> column value.</value>
		public decimal TOTAL_VALOR_EFECTIVO
		{
			get { return _total_valor_efectivo; }
			set { _total_valor_efectivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_RETENCION</c> column value.</value>
		public decimal TOTAL_RETENCION
		{
			get { return _total_retencion; }
			set { _total_retencion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_INTERES_ANUAL</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_INTERES_ANUAL</c> column value.</value>
		public decimal PORCENTAJE_INTERES_ANUAL
		{
			get { return _porcentaje_interes_anual; }
			set { _porcentaje_interes_anual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_GASTO_ADMIN</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_GASTO_ADMIN</c> column value.</value>
		public decimal PORCENTAJE_GASTO_ADMIN
		{
			get { return _porcentaje_gasto_admin; }
			set { _porcentaje_gasto_admin = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
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
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_DEUDOR</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_DEUDOR</c> column value.</value>
		public string NOMBRE_DEUDOR
		{
			get { return _nombre_deudor; }
			set { _nombre_deudor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_BENEFICIARIO</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_BENEFICIARIO</c> column value.</value>
		public string NOMBRE_BENEFICIARIO
		{
			get { return _nombre_beneficiario; }
			set { _nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_CTACTE_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</value>
		public decimal CHEQUE_CTACTE_BANCO_ID
		{
			get
			{
				if(IsCHEQUE_CTACTE_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_ctacte_banco_id;
			}
			set
			{
				_cheque_ctacte_banco_idNull = false;
				_cheque_ctacte_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_CTACTE_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_CTACTE_BANCO_IDNull
		{
			get { return _cheque_ctacte_banco_idNull; }
			set { _cheque_ctacte_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_NRO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_NRO_CUENTA</c> column value.</value>
		public string CHEQUE_NRO_CUENTA
		{
			get { return _cheque_nro_cuenta; }
			set { _cheque_nro_cuenta = value; }
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
		/// Gets or sets the <c>CHEQUE_DOCUMENTO_EMISOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_DOCUMENTO_EMISOR</c> column value.</value>
		public string CHEQUE_DOCUMENTO_EMISOR
		{
			get { return _cheque_documento_emisor; }
			set { _cheque_documento_emisor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_DOCUMENTO_RECIBIDO_ID
		{
			get
			{
				if(IsCTACTE_DOCUMENTO_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_documento_recibido_id;
			}
			set
			{
				_ctacte_documento_recibido_idNull = false;
				_ctacte_documento_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_DOCUMENTO_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_DOCUMENTO_RECIBIDO_IDNull
		{
			get { return _ctacte_documento_recibido_idNull; }
			set { _ctacte_documento_recibido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_recibido_id;
			}
			set
			{
				_ctacte_cheque_recibido_idNull = false;
				_ctacte_cheque_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_RECIBIDO_IDNull
		{
			get { return _ctacte_cheque_recibido_idNull; }
			set { _ctacte_cheque_recibido_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTOS_CLI_ID=");
			dynStr.Append(DESCUENTO_DOCUMENTOS_CLI_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@TOTAL_VALOR_NOMINAL=");
			dynStr.Append(TOTAL_VALOR_NOMINAL);
			dynStr.Append("@CBA@TOTAL_VALOR_EFECTIVO=");
			dynStr.Append(TOTAL_VALOR_EFECTIVO);
			dynStr.Append("@CBA@TOTAL_RETENCION=");
			dynStr.Append(TOTAL_RETENCION);
			dynStr.Append("@CBA@PORCENTAJE_INTERES_ANUAL=");
			dynStr.Append(PORCENTAJE_INTERES_ANUAL);
			dynStr.Append("@CBA@PORCENTAJE_GASTO_ADMIN=");
			dynStr.Append(PORCENTAJE_GASTO_ADMIN);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NOMBRE_DEUDOR=");
			dynStr.Append(NOMBRE_DEUDOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@CHEQUE_CTACTE_BANCO_ID=");
			dynStr.Append(IsCHEQUE_CTACTE_BANCO_IDNull ? (object)"<NULL>" : CHEQUE_CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CHEQUE_NRO_CUENTA=");
			dynStr.Append(CHEQUE_NRO_CUENTA);
			dynStr.Append("@CBA@CHEQUE_DE_TERCEROS=");
			dynStr.Append(CHEQUE_DE_TERCEROS);
			dynStr.Append("@CBA@CHEQUE_DOCUMENTO_EMISOR=");
			dynStr.Append(CHEQUE_DOCUMENTO_EMISOR);
			dynStr.Append("@CBA@CTACTE_DOCUMENTO_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_DOCUMENTO_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_DOCUMENTO_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CHEQUE_ES_DIFERIDO=");
			dynStr.Append(CHEQUE_ES_DIFERIDO);
			return dynStr.ToString();
		}
	} // End of DESCUENTO_DOCUMENTOS_CLI_DETRow_Base class
} // End of namespace
