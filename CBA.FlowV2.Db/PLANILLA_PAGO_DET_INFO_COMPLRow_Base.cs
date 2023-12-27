// <fileinfo name="PLANILLA_PAGO_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PLANILLA_PAGO_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PAGO_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _planilla_pago_id;
		private decimal _ctacte_proveedor_id;
		private decimal _monto_pagar;
		private bool _monto_pagarNull = true;
		private decimal _ctacte_prov_caso_id;
		private bool _ctacte_prov_caso_idNull = true;
		private decimal _monto_bruto;
		private bool _monto_brutoNull = true;
		private decimal _ctacte_caso_id;
		private bool _ctacte_caso_idNull = true;
		private string _ctacte_nro_comprobante;
		private decimal _proveedor_id;
		private string _proveedor_nombre;
		private decimal _ctacte_moneda_id;
		private string _ctacte_moneda_nombre;
		private string _ctacte_moneda_simbolo;
		private decimal _ctacte_moneda_cotizacion;
		private decimal _saldo_ctacte;
		private bool _saldo_ctacteNull = true;
		private System.DateTime _ctacte_fecha_vencimiento;
		private decimal _op_caso_id;
		private bool _op_caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PLANILLA_PAGO_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_PAGO_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANILLA_PAGO_ID != original.PLANILLA_PAGO_ID) return true;
			if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.IsMONTO_PAGARNull != original.IsMONTO_PAGARNull) return true;
			if (!this.IsMONTO_PAGARNull && !original.IsMONTO_PAGARNull)
				if (this.MONTO_PAGAR != original.MONTO_PAGAR) return true;
			if (this.IsCTACTE_PROV_CASO_IDNull != original.IsCTACTE_PROV_CASO_IDNull) return true;
			if (!this.IsCTACTE_PROV_CASO_IDNull && !original.IsCTACTE_PROV_CASO_IDNull)
				if (this.CTACTE_PROV_CASO_ID != original.CTACTE_PROV_CASO_ID) return true;
			if (this.IsMONTO_BRUTONull != original.IsMONTO_BRUTONull) return true;
			if (!this.IsMONTO_BRUTONull && !original.IsMONTO_BRUTONull)
				if (this.MONTO_BRUTO != original.MONTO_BRUTO) return true;
			if (this.IsCTACTE_CASO_IDNull != original.IsCTACTE_CASO_IDNull) return true;
			if (!this.IsCTACTE_CASO_IDNull && !original.IsCTACTE_CASO_IDNull)
				if (this.CTACTE_CASO_ID != original.CTACTE_CASO_ID) return true;
			if (this.CTACTE_NRO_COMPROBANTE != original.CTACTE_NRO_COMPROBANTE) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.CTACTE_MONEDA_ID != original.CTACTE_MONEDA_ID) return true;
			if (this.CTACTE_MONEDA_NOMBRE != original.CTACTE_MONEDA_NOMBRE) return true;
			if (this.CTACTE_MONEDA_SIMBOLO != original.CTACTE_MONEDA_SIMBOLO) return true;
			if (this.CTACTE_MONEDA_COTIZACION != original.CTACTE_MONEDA_COTIZACION) return true;
			if (this.IsSALDO_CTACTENull != original.IsSALDO_CTACTENull) return true;
			if (!this.IsSALDO_CTACTENull && !original.IsSALDO_CTACTENull)
				if (this.SALDO_CTACTE != original.SALDO_CTACTE) return true;
			if (this.CTACTE_FECHA_VENCIMIENTO != original.CTACTE_FECHA_VENCIMIENTO) return true;
			if (this.IsOP_CASO_IDNull != original.IsOP_CASO_IDNull) return true;
			if (!this.IsOP_CASO_IDNull && !original.IsOP_CASO_IDNull)
				if (this.OP_CASO_ID != original.OP_CASO_ID) return true;
			
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
		/// Gets or sets the <c>PLANILLA_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_PAGO_ID</c> column value.</value>
		public decimal PLANILLA_PAGO_ID
		{
			get { return _planilla_pago_id; }
			set { _planilla_pago_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_ID
		{
			get { return _ctacte_proveedor_id; }
			set { _ctacte_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PAGAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PAGAR</c> column value.</value>
		public decimal MONTO_PAGAR
		{
			get
			{
				if(IsMONTO_PAGARNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_pagar;
			}
			set
			{
				_monto_pagarNull = false;
				_monto_pagar = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PAGAR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PAGARNull
		{
			get { return _monto_pagarNull; }
			set { _monto_pagarNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROV_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROV_CASO_ID</c> column value.</value>
		public decimal CTACTE_PROV_CASO_ID
		{
			get
			{
				if(IsCTACTE_PROV_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_prov_caso_id;
			}
			set
			{
				_ctacte_prov_caso_idNull = false;
				_ctacte_prov_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROV_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROV_CASO_IDNull
		{
			get { return _ctacte_prov_caso_idNull; }
			set { _ctacte_prov_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BRUTO</c> column value.</value>
		public decimal MONTO_BRUTO
		{
			get
			{
				if(IsMONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bruto;
			}
			set
			{
				_monto_brutoNull = false;
				_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BRUTONull
		{
			get { return _monto_brutoNull; }
			set { _monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CASO_ID</c> column value.</value>
		public decimal CTACTE_CASO_ID
		{
			get
			{
				if(IsCTACTE_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caso_id;
			}
			set
			{
				_ctacte_caso_idNull = false;
				_ctacte_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CASO_IDNull
		{
			get { return _ctacte_caso_idNull; }
			set { _ctacte_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_NRO_COMPROBANTE</c> column value.</value>
		public string CTACTE_NRO_COMPROBANTE
		{
			get { return _ctacte_nro_comprobante; }
			set { _ctacte_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_NOMBRE</c> column value.</value>
		public string PROVEEDOR_NOMBRE
		{
			get { return _proveedor_nombre; }
			set { _proveedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_MONEDA_ID</c> column value.</value>
		public decimal CTACTE_MONEDA_ID
		{
			get { return _ctacte_moneda_id; }
			set { _ctacte_moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_MONEDA_NOMBRE</c> column value.</value>
		public string CTACTE_MONEDA_NOMBRE
		{
			get { return _ctacte_moneda_nombre; }
			set { _ctacte_moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_MONEDA_SIMBOLO</c> column value.</value>
		public string CTACTE_MONEDA_SIMBOLO
		{
			get { return _ctacte_moneda_simbolo; }
			set { _ctacte_moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_MONEDA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_MONEDA_COTIZACION</c> column value.</value>
		public decimal CTACTE_MONEDA_COTIZACION
		{
			get { return _ctacte_moneda_cotizacion; }
			set { _ctacte_moneda_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_CTACTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_CTACTE</c> column value.</value>
		public decimal SALDO_CTACTE
		{
			get
			{
				if(IsSALDO_CTACTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_ctacte;
			}
			set
			{
				_saldo_ctacteNull = false;
				_saldo_ctacte = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_CTACTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_CTACTENull
		{
			get { return _saldo_ctacteNull; }
			set { _saldo_ctacteNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime CTACTE_FECHA_VENCIMIENTO
		{
			get { return _ctacte_fecha_vencimiento; }
			set { _ctacte_fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OP_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OP_CASO_ID</c> column value.</value>
		public decimal OP_CASO_ID
		{
			get
			{
				if(IsOP_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _op_caso_id;
			}
			set
			{
				_op_caso_idNull = false;
				_op_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="OP_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsOP_CASO_IDNull
		{
			get { return _op_caso_idNull; }
			set { _op_caso_idNull = value; }
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
			dynStr.Append("@CBA@PLANILLA_PAGO_ID=");
			dynStr.Append(PLANILLA_PAGO_ID);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_ID=");
			dynStr.Append(CTACTE_PROVEEDOR_ID);
			dynStr.Append("@CBA@MONTO_PAGAR=");
			dynStr.Append(IsMONTO_PAGARNull ? (object)"<NULL>" : MONTO_PAGAR);
			dynStr.Append("@CBA@CTACTE_PROV_CASO_ID=");
			dynStr.Append(IsCTACTE_PROV_CASO_IDNull ? (object)"<NULL>" : CTACTE_PROV_CASO_ID);
			dynStr.Append("@CBA@MONTO_BRUTO=");
			dynStr.Append(IsMONTO_BRUTONull ? (object)"<NULL>" : MONTO_BRUTO);
			dynStr.Append("@CBA@CTACTE_CASO_ID=");
			dynStr.Append(IsCTACTE_CASO_IDNull ? (object)"<NULL>" : CTACTE_CASO_ID);
			dynStr.Append("@CBA@CTACTE_NRO_COMPROBANTE=");
			dynStr.Append(CTACTE_NRO_COMPROBANTE);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@CTACTE_MONEDA_ID=");
			dynStr.Append(CTACTE_MONEDA_ID);
			dynStr.Append("@CBA@CTACTE_MONEDA_NOMBRE=");
			dynStr.Append(CTACTE_MONEDA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_MONEDA_SIMBOLO=");
			dynStr.Append(CTACTE_MONEDA_SIMBOLO);
			dynStr.Append("@CBA@CTACTE_MONEDA_COTIZACION=");
			dynStr.Append(CTACTE_MONEDA_COTIZACION);
			dynStr.Append("@CBA@SALDO_CTACTE=");
			dynStr.Append(IsSALDO_CTACTENull ? (object)"<NULL>" : SALDO_CTACTE);
			dynStr.Append("@CBA@CTACTE_FECHA_VENCIMIENTO=");
			dynStr.Append(CTACTE_FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@OP_CASO_ID=");
			dynStr.Append(IsOP_CASO_IDNull ? (object)"<NULL>" : OP_CASO_ID);
			return dynStr.ToString();
		}
	} // End of PLANILLA_PAGO_DET_INFO_COMPLRow_Base class
} // End of namespace
