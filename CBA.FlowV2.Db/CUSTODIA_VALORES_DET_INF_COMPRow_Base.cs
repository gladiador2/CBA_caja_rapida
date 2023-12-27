// <fileinfo name="CUSTODIA_VALORES_DET_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="CUSTODIA_VALORES_DET_INF_COMPRow"/> that 
	/// represents a record in the <c>CUSTODIA_VALORES_DET_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CUSTODIA_VALORES_DET_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CUSTODIA_VALORES_DET_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _custodia_valor_id;
		private decimal _ctacte_valor_id;
		private string _ctacte_valor_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private decimal _moneda_cabecera_id;
		private decimal _cotizacion_moneda_cabecera;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private string _observacion_valor;
		private string _valor_retirado;
		private System.DateTime _fecha_retiro;
		private bool _fecha_retiroNull = true;
		private decimal _usuario_retiro_id;
		private bool _usuario_retiro_idNull = true;
		private string _observacion_inicial;
		private string _observacion_retiro;
		private string _deposito_automatico;
		private decimal _costo;
		private bool _costoNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CUSTODIA_VALORES_DET_INF_COMPRow_Base"/> class.
		/// </summary>
		public CUSTODIA_VALORES_DET_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CUSTODIA_VALORES_DET_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CUSTODIA_VALOR_ID != original.CUSTODIA_VALOR_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.MONEDA_CABECERA_ID != original.MONEDA_CABECERA_ID) return true;
			if (this.COTIZACION_MONEDA_CABECERA != original.COTIZACION_MONEDA_CABECERA) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.OBSERVACION_VALOR != original.OBSERVACION_VALOR) return true;
			if (this.VALOR_RETIRADO != original.VALOR_RETIRADO) return true;
			if (this.IsFECHA_RETIRONull != original.IsFECHA_RETIRONull) return true;
			if (!this.IsFECHA_RETIRONull && !original.IsFECHA_RETIRONull)
				if (this.FECHA_RETIRO != original.FECHA_RETIRO) return true;
			if (this.IsUSUARIO_RETIRO_IDNull != original.IsUSUARIO_RETIRO_IDNull) return true;
			if (!this.IsUSUARIO_RETIRO_IDNull && !original.IsUSUARIO_RETIRO_IDNull)
				if (this.USUARIO_RETIRO_ID != original.USUARIO_RETIRO_ID) return true;
			if (this.OBSERVACION_INICIAL != original.OBSERVACION_INICIAL) return true;
			if (this.OBSERVACION_RETIRO != original.OBSERVACION_RETIRO) return true;
			if (this.DEPOSITO_AUTOMATICO != original.DEPOSITO_AUTOMATICO) return true;
			if (this.IsCOSTONull != original.IsCOSTONull) return true;
			if (!this.IsCOSTONull && !original.IsCOSTONull)
				if (this.COSTO != original.COSTO) return true;
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
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_NOMBRE</c> column value.</value>
		public string CTACTE_VALOR_NOMBRE
		{
			get { return _ctacte_valor_nombre; }
			set { _ctacte_valor_nombre = value; }
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
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
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
		/// Gets or sets the <c>MONEDA_CABECERA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CABECERA_ID</c> column value.</value>
		public decimal MONEDA_CABECERA_ID
		{
			get { return _moneda_cabecera_id; }
			set { _moneda_cabecera_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_CABECERA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_CABECERA</c> column value.</value>
		public decimal COTIZACION_MONEDA_CABECERA
		{
			get { return _cotizacion_moneda_cabecera; }
			set { _cotizacion_moneda_cabecera = value; }
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
		/// Gets or sets the <c>OBSERVACION_VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_VALOR</c> column value.</value>
		public string OBSERVACION_VALOR
		{
			get { return _observacion_valor; }
			set { _observacion_valor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_RETIRADO</c> column value.
		/// </summary>
		/// <value>The <c>VALOR_RETIRADO</c> column value.</value>
		public string VALOR_RETIRADO
		{
			get { return _valor_retirado; }
			set { _valor_retirado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RETIRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RETIRO</c> column value.</value>
		public System.DateTime FECHA_RETIRO
		{
			get
			{
				if(IsFECHA_RETIRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_retiro;
			}
			set
			{
				_fecha_retiroNull = false;
				_fecha_retiro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RETIRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RETIRONull
		{
			get { return _fecha_retiroNull; }
			set { _fecha_retiroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_RETIRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_RETIRO_ID</c> column value.</value>
		public decimal USUARIO_RETIRO_ID
		{
			get
			{
				if(IsUSUARIO_RETIRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_retiro_id;
			}
			set
			{
				_usuario_retiro_idNull = false;
				_usuario_retiro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_RETIRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_RETIRO_IDNull
		{
			get { return _usuario_retiro_idNull; }
			set { _usuario_retiro_idNull = value; }
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
		/// Gets or sets the <c>OBSERVACION_RETIRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_RETIRO</c> column value.</value>
		public string OBSERVACION_RETIRO
		{
			get { return _observacion_retiro; }
			set { _observacion_retiro = value; }
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
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@MONEDA_CABECERA_ID=");
			dynStr.Append(MONEDA_CABECERA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_CABECERA=");
			dynStr.Append(COTIZACION_MONEDA_CABECERA);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@OBSERVACION_VALOR=");
			dynStr.Append(OBSERVACION_VALOR);
			dynStr.Append("@CBA@VALOR_RETIRADO=");
			dynStr.Append(VALOR_RETIRADO);
			dynStr.Append("@CBA@FECHA_RETIRO=");
			dynStr.Append(IsFECHA_RETIRONull ? (object)"<NULL>" : FECHA_RETIRO);
			dynStr.Append("@CBA@USUARIO_RETIRO_ID=");
			dynStr.Append(IsUSUARIO_RETIRO_IDNull ? (object)"<NULL>" : USUARIO_RETIRO_ID);
			dynStr.Append("@CBA@OBSERVACION_INICIAL=");
			dynStr.Append(OBSERVACION_INICIAL);
			dynStr.Append("@CBA@OBSERVACION_RETIRO=");
			dynStr.Append(OBSERVACION_RETIRO);
			dynStr.Append("@CBA@DEPOSITO_AUTOMATICO=");
			dynStr.Append(DEPOSITO_AUTOMATICO);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(IsCOSTONull ? (object)"<NULL>" : COSTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CUSTODIA_VALORES_DET_INF_COMPRow_Base class
} // End of namespace
