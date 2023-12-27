// <fileinfo name="CTACTE_DOCUMENTOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_DOCUMENTOSRow"/> that 
	/// represents a record in the <c>CTACTE_DOCUMENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_DOCUMENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_DOCUMENTOSRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _ctacte_valor_id;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _total_bruto;
		private decimal _total_retencion;
		private System.DateTime _fecha_creacion;
		private string _nro_comprobante;
		private string _nombre_deudor;
		private string _nombre_beneficiario;
		private string _observacion;
		private decimal _desc_doc_cli_det_id;
		private bool _desc_doc_cli_det_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_DOCUMENTOSRow_Base"/> class.
		/// </summary>
		public CTACTE_DOCUMENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_DOCUMENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.TOTAL_BRUTO != original.TOTAL_BRUTO) return true;
			if (this.TOTAL_RETENCION != original.TOTAL_RETENCION) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.NOMBRE_DEUDOR != original.NOMBRE_DEUDOR) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsDESC_DOC_CLI_DET_IDNull != original.IsDESC_DOC_CLI_DET_IDNull) return true;
			if (!this.IsDESC_DOC_CLI_DET_IDNull && !original.IsDESC_DOC_CLI_DET_IDNull)
				if (this.DESC_DOC_CLI_DET_ID != original.DESC_DOC_CLI_DET_ID) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
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
		/// Gets or sets the <c>TOTAL_BRUTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_BRUTO</c> column value.</value>
		public decimal TOTAL_BRUTO
		{
			get { return _total_bruto; }
			set { _total_bruto = value; }
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
		/// Gets or sets the <c>DESC_DOC_CLI_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESC_DOC_CLI_DET_ID</c> column value.</value>
		public decimal DESC_DOC_CLI_DET_ID
		{
			get
			{
				if(IsDESC_DOC_CLI_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _desc_doc_cli_det_id;
			}
			set
			{
				_desc_doc_cli_det_idNull = false;
				_desc_doc_cli_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESC_DOC_CLI_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESC_DOC_CLI_DET_IDNull
		{
			get { return _desc_doc_cli_det_idNull; }
			set { _desc_doc_cli_det_idNull = value; }
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
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@TOTAL_BRUTO=");
			dynStr.Append(TOTAL_BRUTO);
			dynStr.Append("@CBA@TOTAL_RETENCION=");
			dynStr.Append(TOTAL_RETENCION);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NOMBRE_DEUDOR=");
			dynStr.Append(NOMBRE_DEUDOR);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@DESC_DOC_CLI_DET_ID=");
			dynStr.Append(IsDESC_DOC_CLI_DET_IDNull ? (object)"<NULL>" : DESC_DOC_CLI_DET_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_DOCUMENTOSRow_Base class
} // End of namespace
