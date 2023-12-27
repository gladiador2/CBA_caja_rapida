// <fileinfo name="CTACTE_PERSONASRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONASRow"/> that 
	/// represents a record in the <c>CTACTE_PERSONAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PERSONASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONASRow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private System.DateTime _fecha_insercion;
		private System.DateTime _fecha_vencimiento;
		private System.DateTime _fecha_postergacion;
		private bool _fecha_postergacionNull = true;
		private decimal _cuota_numero;
		private bool _cuota_numeroNull = true;
		private decimal _cuota_total;
		private bool _cuota_totalNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _ctacte_concepto_id;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private decimal _ctacte_pagare_doc_id;
		private bool _ctacte_pagare_doc_idNull = true;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private decimal _ctacte_pago_persona_det_id;
		private bool _ctacte_pago_persona_det_idNull = true;
		private decimal _ctacte_pago_persona_doc_id;
		private bool _ctacte_pago_persona_doc_idNull = true;
		private decimal _ctacte_pago_persona_rec_id;
		private bool _ctacte_pago_persona_rec_idNull = true;
		private decimal _calendario_pagos_fc_cli_id;
		private bool _calendario_pagos_fc_cli_idNull = true;
		private decimal _calendario_pagos_cr_cli_id;
		private bool _calendario_pagos_cr_cli_idNull = true;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _ctacte_documento_venc_id;
		private bool _ctacte_documento_venc_idNull = true;
		private decimal _credito;
		private decimal _debito;
		private string _concepto;
		private decimal _ctacte_persona_relacionada_id;
		private bool _ctacte_persona_relacionada_idNull = true;
		private string _judicial;
		private string _bloqueado;
		private string _estado;
		private decimal _aplicacion_documentos_id;
		private bool _aplicacion_documentos_idNull = true;
		private decimal _aplicacion_documentos_val_id;
		private bool _aplicacion_documentos_val_idNull = true;
		private decimal _aplicacion_documentos_rec_id;
		private bool _aplicacion_documentos_rec_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONASRow_Base"/> class.
		/// </summary>
		public CTACTE_PERSONASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PERSONASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsFECHA_POSTERGACIONNull != original.IsFECHA_POSTERGACIONNull) return true;
			if (!this.IsFECHA_POSTERGACIONNull && !original.IsFECHA_POSTERGACIONNull)
				if (this.FECHA_POSTERGACION != original.FECHA_POSTERGACION) return true;
			if (this.IsCUOTA_NUMERONull != original.IsCUOTA_NUMERONull) return true;
			if (!this.IsCUOTA_NUMERONull && !original.IsCUOTA_NUMERONull)
				if (this.CUOTA_NUMERO != original.CUOTA_NUMERO) return true;
			if (this.IsCUOTA_TOTALNull != original.IsCUOTA_TOTALNull) return true;
			if (!this.IsCUOTA_TOTALNull && !original.IsCUOTA_TOTALNull)
				if (this.CUOTA_TOTAL != original.CUOTA_TOTAL) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CTACTE_CONCEPTO_ID != original.CTACTE_CONCEPTO_ID) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.IsCTACTE_PAGARE_DOC_IDNull != original.IsCTACTE_PAGARE_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DOC_IDNull && !original.IsCTACTE_PAGARE_DOC_IDNull)
				if (this.CTACTE_PAGARE_DOC_ID != original.CTACTE_PAGARE_DOC_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DET_IDNull != original.IsCTACTE_PAGO_PERSONA_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DET_IDNull && !original.IsCTACTE_PAGO_PERSONA_DET_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DET_ID != original.CTACTE_PAGO_PERSONA_DET_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DOC_IDNull != original.IsCTACTE_PAGO_PERSONA_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DOC_IDNull && !original.IsCTACTE_PAGO_PERSONA_DOC_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DOC_ID != original.CTACTE_PAGO_PERSONA_DOC_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_REC_IDNull != original.IsCTACTE_PAGO_PERSONA_REC_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_REC_IDNull && !original.IsCTACTE_PAGO_PERSONA_REC_IDNull)
				if (this.CTACTE_PAGO_PERSONA_REC_ID != original.CTACTE_PAGO_PERSONA_REC_ID) return true;
			if (this.IsCALENDARIO_PAGOS_FC_CLI_IDNull != original.IsCALENDARIO_PAGOS_FC_CLI_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_FC_CLI_IDNull && !original.IsCALENDARIO_PAGOS_FC_CLI_IDNull)
				if (this.CALENDARIO_PAGOS_FC_CLI_ID != original.CALENDARIO_PAGOS_FC_CLI_ID) return true;
			if (this.IsCALENDARIO_PAGOS_CR_CLI_IDNull != original.IsCALENDARIO_PAGOS_CR_CLI_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_CR_CLI_IDNull && !original.IsCALENDARIO_PAGOS_CR_CLI_IDNull)
				if (this.CALENDARIO_PAGOS_CR_CLI_ID != original.CALENDARIO_PAGOS_CR_CLI_ID) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsCTACTE_DOCUMENTO_VENC_IDNull != original.IsCTACTE_DOCUMENTO_VENC_IDNull) return true;
			if (!this.IsCTACTE_DOCUMENTO_VENC_IDNull && !original.IsCTACTE_DOCUMENTO_VENC_IDNull)
				if (this.CTACTE_DOCUMENTO_VENC_ID != original.CTACTE_DOCUMENTO_VENC_ID) return true;
			if (this.CREDITO != original.CREDITO) return true;
			if (this.DEBITO != original.DEBITO) return true;
			if (this.CONCEPTO != original.CONCEPTO) return true;
			if (this.IsCTACTE_PERSONA_RELACIONADA_IDNull != original.IsCTACTE_PERSONA_RELACIONADA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_RELACIONADA_IDNull && !original.IsCTACTE_PERSONA_RELACIONADA_IDNull)
				if (this.CTACTE_PERSONA_RELACIONADA_ID != original.CTACTE_PERSONA_RELACIONADA_ID) return true;
			if (this.JUDICIAL != original.JUDICIAL) return true;
			if (this.BLOQUEADO != original.BLOQUEADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsAPLICACION_DOCUMENTOS_IDNull != original.IsAPLICACION_DOCUMENTOS_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTOS_IDNull && !original.IsAPLICACION_DOCUMENTOS_IDNull)
				if (this.APLICACION_DOCUMENTOS_ID != original.APLICACION_DOCUMENTOS_ID) return true;
			if (this.IsAPLICACION_DOCUMENTOS_VAL_IDNull != original.IsAPLICACION_DOCUMENTOS_VAL_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTOS_VAL_IDNull && !original.IsAPLICACION_DOCUMENTOS_VAL_IDNull)
				if (this.APLICACION_DOCUMENTOS_VAL_ID != original.APLICACION_DOCUMENTOS_VAL_ID) return true;
			if (this.IsAPLICACION_DOCUMENTOS_REC_IDNull != original.IsAPLICACION_DOCUMENTOS_REC_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTOS_REC_IDNull && !original.IsAPLICACION_DOCUMENTOS_REC_IDNull)
				if (this.APLICACION_DOCUMENTOS_REC_ID != original.APLICACION_DOCUMENTOS_REC_ID) return true;
			
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
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get { return _fecha_insercion; }
			set { _fecha_insercion = value; }
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
		/// Gets or sets the <c>CUOTA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_NUMERO</c> column value.</value>
		public decimal CUOTA_NUMERO
		{
			get
			{
				if(IsCUOTA_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_numero;
			}
			set
			{
				_cuota_numeroNull = false;
				_cuota_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_NUMERONull
		{
			get { return _cuota_numeroNull; }
			set { _cuota_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_TOTAL</c> column value.</value>
		public decimal CUOTA_TOTAL
		{
			get
			{
				if(IsCUOTA_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_total;
			}
			set
			{
				_cuota_totalNull = false;
				_cuota_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_TOTALNull
		{
			get { return _cuota_totalNull; }
			set { _cuota_totalNull = value; }
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
		/// Gets or sets the <c>CTACTE_CONCEPTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CONCEPTO_ID</c> column value.</value>
		public decimal CTACTE_CONCEPTO_ID
		{
			get { return _ctacte_concepto_id; }
			set { _ctacte_concepto_id = value; }
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
		/// Gets or sets the <c>CTACTE_PAGARE_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_doc_id;
			}
			set
			{
				_ctacte_pagare_doc_idNull = false;
				_ctacte_pagare_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_DOC_IDNull
		{
			get { return _ctacte_pagare_doc_idNull; }
			set { _ctacte_pagare_doc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_DET_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_DET_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_det_id;
			}
			set
			{
				_ctacte_pagare_det_idNull = false;
				_ctacte_pagare_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_DET_IDNull
		{
			get { return _ctacte_pagare_det_idNull; }
			set { _ctacte_pagare_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_DET_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_DET_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_det_id;
			}
			set
			{
				_ctacte_pago_persona_det_idNull = false;
				_ctacte_pago_persona_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_DET_IDNull
		{
			get { return _ctacte_pago_persona_det_idNull; }
			set { _ctacte_pago_persona_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_doc_id;
			}
			set
			{
				_ctacte_pago_persona_doc_idNull = false;
				_ctacte_pago_persona_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_DOC_IDNull
		{
			get { return _ctacte_pago_persona_doc_idNull; }
			set { _ctacte_pago_persona_doc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_REC_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_REC_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_REC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_rec_id;
			}
			set
			{
				_ctacte_pago_persona_rec_idNull = false;
				_ctacte_pago_persona_rec_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_REC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_REC_IDNull
		{
			get { return _ctacte_pago_persona_rec_idNull; }
			set { _ctacte_pago_persona_rec_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_FC_CLI_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_FC_CLI_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_FC_CLI_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_fc_cli_id;
			}
			set
			{
				_calendario_pagos_fc_cli_idNull = false;
				_calendario_pagos_fc_cli_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_FC_CLI_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_FC_CLI_IDNull
		{
			get { return _calendario_pagos_fc_cli_idNull; }
			set { _calendario_pagos_fc_cli_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_CR_CLI_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_CR_CLI_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_CR_CLI_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_cr_cli_id;
			}
			set
			{
				_calendario_pagos_cr_cli_idNull = false;
				_calendario_pagos_cr_cli_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_CR_CLI_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_CR_CLI_IDNull
		{
			get { return _calendario_pagos_cr_cli_idNull; }
			set { _calendario_pagos_cr_cli_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_ID
		{
			get
			{
				if(IsORDEN_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_id;
			}
			set
			{
				_orden_pago_idNull = false;
				_orden_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_IDNull
		{
			get { return _orden_pago_idNull; }
			set { _orden_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_DOCUMENTO_VENC_ID</c> column value.</value>
		public decimal CTACTE_DOCUMENTO_VENC_ID
		{
			get
			{
				if(IsCTACTE_DOCUMENTO_VENC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_documento_venc_id;
			}
			set
			{
				_ctacte_documento_venc_idNull = false;
				_ctacte_documento_venc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_DOCUMENTO_VENC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_DOCUMENTO_VENC_IDNull
		{
			get { return _ctacte_documento_venc_idNull; }
			set { _ctacte_documento_venc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>CREDITO</c> column value.</value>
		public decimal CREDITO
		{
			get { return _credito; }
			set { _credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBITO</c> column value.
		/// </summary>
		/// <value>The <c>DEBITO</c> column value.</value>
		public decimal DEBITO
		{
			get { return _debito; }
			set { _debito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCEPTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONCEPTO</c> column value.</value>
		public string CONCEPTO
		{
			get { return _concepto; }
			set { _concepto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_RELACIONADA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_RELACIONADA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_RELACIONADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_relacionada_id;
			}
			set
			{
				_ctacte_persona_relacionada_idNull = false;
				_ctacte_persona_relacionada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_RELACIONADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_RELACIONADA_IDNull
		{
			get { return _ctacte_persona_relacionada_idNull; }
			set { _ctacte_persona_relacionada_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>JUDICIAL</c> column value.
		/// </summary>
		/// <value>The <c>JUDICIAL</c> column value.</value>
		public string JUDICIAL
		{
			get { return _judicial; }
			set { _judicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BLOQUEADO</c> column value.
		/// </summary>
		/// <value>The <c>BLOQUEADO</c> column value.</value>
		public string BLOQUEADO
		{
			get { return _bloqueado; }
			set { _bloqueado = value; }
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
		/// Gets or sets the <c>APLICACION_DOCUMENTOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTOS_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTOS_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documentos_id;
			}
			set
			{
				_aplicacion_documentos_idNull = false;
				_aplicacion_documentos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTOS_IDNull
		{
			get { return _aplicacion_documentos_idNull; }
			set { _aplicacion_documentos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTOS_VAL_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTOS_VAL_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTOS_VAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documentos_val_id;
			}
			set
			{
				_aplicacion_documentos_val_idNull = false;
				_aplicacion_documentos_val_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTOS_VAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTOS_VAL_IDNull
		{
			get { return _aplicacion_documentos_val_idNull; }
			set { _aplicacion_documentos_val_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTOS_REC_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTOS_REC_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTOS_REC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documentos_rec_id;
			}
			set
			{
				_aplicacion_documentos_rec_idNull = false;
				_aplicacion_documentos_rec_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTOS_REC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTOS_REC_IDNull
		{
			get { return _aplicacion_documentos_rec_idNull; }
			set { _aplicacion_documentos_rec_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_POSTERGACION=");
			dynStr.Append(IsFECHA_POSTERGACIONNull ? (object)"<NULL>" : FECHA_POSTERGACION);
			dynStr.Append("@CBA@CUOTA_NUMERO=");
			dynStr.Append(IsCUOTA_NUMERONull ? (object)"<NULL>" : CUOTA_NUMERO);
			dynStr.Append("@CBA@CUOTA_TOTAL=");
			dynStr.Append(IsCUOTA_TOTALNull ? (object)"<NULL>" : CUOTA_TOTAL);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_ID=");
			dynStr.Append(CTACTE_CONCEPTO_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DET_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DET_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_REC_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_REC_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_REC_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_FC_CLI_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_FC_CLI_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_FC_CLI_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_CR_CLI_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_CR_CLI_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_CR_CLI_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_DOCUMENTO_VENC_ID=");
			dynStr.Append(IsCTACTE_DOCUMENTO_VENC_IDNull ? (object)"<NULL>" : CTACTE_DOCUMENTO_VENC_ID);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(DEBITO);
			dynStr.Append("@CBA@CONCEPTO=");
			dynStr.Append(CONCEPTO);
			dynStr.Append("@CBA@CTACTE_PERSONA_RELACIONADA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_RELACIONADA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_RELACIONADA_ID);
			dynStr.Append("@CBA@JUDICIAL=");
			dynStr.Append(JUDICIAL);
			dynStr.Append("@CBA@BLOQUEADO=");
			dynStr.Append(BLOQUEADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@APLICACION_DOCUMENTOS_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTOS_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTOS_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTOS_VAL_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTOS_VAL_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTOS_VAL_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTOS_REC_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTOS_REC_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTOS_REC_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_PERSONASRow_Base class
} // End of namespace
