// <fileinfo name="TRANSF_CAJ_SUC_DET_INF_CRow_Base.cs">
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
	/// The base class for <see cref="TRANSF_CAJ_SUC_DET_INF_CRow"/> that 
	/// represents a record in the <c>TRANSF_CAJ_SUC_DET_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSF_CAJ_SUC_DET_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSF_CAJ_SUC_DET_INF_CRow_Base
	{
		private decimal _id;
		private decimal _trans_cajas_suc_id;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private decimal _cantidades_decimales;
		private bool _cantidades_decimalesNull = true;
		private string _simbolo;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private string _nombre;
		private string _numero_cheque;
		private string _nombre_emisor;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSF_CAJ_SUC_DET_INF_CRow_Base"/> class.
		/// </summary>
		public TRANSF_CAJ_SUC_DET_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSF_CAJ_SUC_DET_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRANS_CAJAS_SUC_ID != original.TRANS_CAJAS_SUC_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsCANTIDADES_DECIMALESNull != original.IsCANTIDADES_DECIMALESNull) return true;
			if (!this.IsCANTIDADES_DECIMALESNull && !original.IsCANTIDADES_DECIMALESNull)
				if (this.CANTIDADES_DECIMALES != original.CANTIDADES_DECIMALES) return true;
			if (this.SIMBOLO != original.SIMBOLO) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.NUMERO_CHEQUE != original.NUMERO_CHEQUE) return true;
			if (this.NOMBRE_EMISOR != original.NOMBRE_EMISOR) return true;
			
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
		/// Gets or sets the <c>TRANS_CAJAS_SUC_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANS_CAJAS_SUC_ID</c> column value.</value>
		public decimal TRANS_CAJAS_SUC_ID
		{
			get { return _trans_cajas_suc_id; }
			set { _trans_cajas_suc_id = value; }
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
		/// This column is nullable.
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
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDADES_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDADES_DECIMALES</c> column value.</value>
		public decimal CANTIDADES_DECIMALES
		{
			get
			{
				if(IsCANTIDADES_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidades_decimales;
			}
			set
			{
				_cantidades_decimalesNull = false;
				_cantidades_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDADES_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADES_DECIMALESNull
		{
			get { return _cantidades_decimalesNull; }
			set { _cantidades_decimalesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SIMBOLO</c> column value.</value>
		public string SIMBOLO
		{
			get { return _simbolo; }
			set { _simbolo = value; }
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_CHEQUE</c> column value.
		/// This column is nullable.
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TRANS_CAJAS_SUC_ID=");
			dynStr.Append(TRANS_CAJAS_SUC_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@CANTIDADES_DECIMALES=");
			dynStr.Append(IsCANTIDADES_DECIMALESNull ? (object)"<NULL>" : CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@SIMBOLO=");
			dynStr.Append(SIMBOLO);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@NUMERO_CHEQUE=");
			dynStr.Append(NUMERO_CHEQUE);
			dynStr.Append("@CBA@NOMBRE_EMISOR=");
			dynStr.Append(NOMBRE_EMISOR);
			return dynStr.ToString();
		}
	} // End of TRANSF_CAJ_SUC_DET_INF_CRow_Base class
} // End of namespace
