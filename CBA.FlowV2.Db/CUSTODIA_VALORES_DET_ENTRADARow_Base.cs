// <fileinfo name="CUSTODIA_VALORES_DET_ENTRADARow_Base.cs">
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
	/// The base class for <see cref="CUSTODIA_VALORES_DET_ENTRADARow"/> that 
	/// represents a record in the <c>CUSTODIA_VALORES_DET_ENTRADA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CUSTODIA_VALORES_DET_ENTRADARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CUSTODIA_VALORES_DET_ENTRADARow_Base
	{
		private decimal _id;
		private decimal _custodia_valor_id;
		private decimal _custodia_valor_det_id;
		private bool _custodia_valor_det_idNull = true;
		private decimal _ctacte_valor_id;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private decimal _costo;
		private bool _costoNull = true;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private string _observacion_inicial;
		private string _deposito_automatico;
		private System.DateTime _fecha;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CUSTODIA_VALORES_DET_ENTRADARow_Base"/> class.
		/// </summary>
		public CUSTODIA_VALORES_DET_ENTRADARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CUSTODIA_VALORES_DET_ENTRADARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CUSTODIA_VALOR_ID != original.CUSTODIA_VALOR_ID) return true;
			if (this.IsCUSTODIA_VALOR_DET_IDNull != original.IsCUSTODIA_VALOR_DET_IDNull) return true;
			if (!this.IsCUSTODIA_VALOR_DET_IDNull && !original.IsCUSTODIA_VALOR_DET_IDNull)
				if (this.CUSTODIA_VALOR_DET_ID != original.CUSTODIA_VALOR_DET_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsCOSTONull != original.IsCOSTONull) return true;
			if (!this.IsCOSTONull && !original.IsCOSTONull)
				if (this.COSTO != original.COSTO) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.OBSERVACION_INICIAL != original.OBSERVACION_INICIAL) return true;
			if (this.DEPOSITO_AUTOMATICO != original.DEPOSITO_AUTOMATICO) return true;
			if (this.FECHA != original.FECHA) return true;
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
		/// Gets or sets the <c>CUSTODIA_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALOR_ID</c> column value.</value>
		public decimal CUSTODIA_VALOR_ID
		{
			get { return _custodia_valor_id; }
			set { _custodia_valor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUSTODIA_VALOR_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALOR_DET_ID</c> column value.</value>
		public decimal CUSTODIA_VALOR_DET_ID
		{
			get
			{
				if(IsCUSTODIA_VALOR_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _custodia_valor_det_id;
			}
			set
			{
				_custodia_valor_det_idNull = false;
				_custodia_valor_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUSTODIA_VALOR_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUSTODIA_VALOR_DET_IDNull
		{
			get { return _custodia_valor_det_idNull; }
			set { _custodia_valor_det_idNull = value; }
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
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO</c> column value.</value>
		public decimal COSTO
		{
			get
			{
				if(IsCOSTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo;
			}
			set
			{
				_costoNull = false;
				_costo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTONull
		{
			get { return _costoNull; }
			set { _costoNull = value; }
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
		/// Gets or sets the <c>OBSERVACION_INICIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_INICIAL</c> column value.</value>
		public string OBSERVACION_INICIAL
		{
			get { return _observacion_inicial; }
			set { _observacion_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_AUTOMATICO</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_AUTOMATICO</c> column value.</value>
		public string DEPOSITO_AUTOMATICO
		{
			get { return _deposito_automatico; }
			set { _deposito_automatico = value; }
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
			dynStr.Append("@CBA@CUSTODIA_VALOR_ID=");
			dynStr.Append(CUSTODIA_VALOR_ID);
			dynStr.Append("@CBA@CUSTODIA_VALOR_DET_ID=");
			dynStr.Append(IsCUSTODIA_VALOR_DET_IDNull ? (object)"<NULL>" : CUSTODIA_VALOR_DET_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(IsCOSTONull ? (object)"<NULL>" : COSTO);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@OBSERVACION_INICIAL=");
			dynStr.Append(OBSERVACION_INICIAL);
			dynStr.Append("@CBA@DEPOSITO_AUTOMATICO=");
			dynStr.Append(DEPOSITO_AUTOMATICO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CUSTODIA_VALORES_DET_ENTRADARow_Base class
} // End of namespace
