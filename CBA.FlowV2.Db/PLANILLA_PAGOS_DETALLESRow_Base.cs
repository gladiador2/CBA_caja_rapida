// <fileinfo name="PLANILLA_PAGOS_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PAGOS_DETALLESRow"/> that 
	/// represents a record in the <c>PLANILLA_PAGOS_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_PAGOS_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PAGOS_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _planilla_pago_id;
		private decimal _ctacte_proveedor_id;
		private decimal _op_caso_id;
		private bool _op_caso_idNull = true;
		private decimal _monto_pagar;
		private bool _monto_pagarNull = true;
		private decimal _ctacte_prov_caso_id;
		private bool _ctacte_prov_caso_idNull = true;
		private decimal _monto_bruto;
		private bool _monto_brutoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGOS_DETALLESRow_Base"/> class.
		/// </summary>
		public PLANILLA_PAGOS_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_PAGOS_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANILLA_PAGO_ID != original.PLANILLA_PAGO_ID) return true;
			if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.IsOP_CASO_IDNull != original.IsOP_CASO_IDNull) return true;
			if (!this.IsOP_CASO_IDNull && !original.IsOP_CASO_IDNull)
				if (this.OP_CASO_ID != original.OP_CASO_ID) return true;
			if (this.IsMONTO_PAGARNull != original.IsMONTO_PAGARNull) return true;
			if (!this.IsMONTO_PAGARNull && !original.IsMONTO_PAGARNull)
				if (this.MONTO_PAGAR != original.MONTO_PAGAR) return true;
			if (this.IsCTACTE_PROV_CASO_IDNull != original.IsCTACTE_PROV_CASO_IDNull) return true;
			if (!this.IsCTACTE_PROV_CASO_IDNull && !original.IsCTACTE_PROV_CASO_IDNull)
				if (this.CTACTE_PROV_CASO_ID != original.CTACTE_PROV_CASO_ID) return true;
			if (this.IsMONTO_BRUTONull != original.IsMONTO_BRUTONull) return true;
			if (!this.IsMONTO_BRUTONull && !original.IsMONTO_BRUTONull)
				if (this.MONTO_BRUTO != original.MONTO_BRUTO) return true;
			
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
			dynStr.Append("@CBA@OP_CASO_ID=");
			dynStr.Append(IsOP_CASO_IDNull ? (object)"<NULL>" : OP_CASO_ID);
			dynStr.Append("@CBA@MONTO_PAGAR=");
			dynStr.Append(IsMONTO_PAGARNull ? (object)"<NULL>" : MONTO_PAGAR);
			dynStr.Append("@CBA@CTACTE_PROV_CASO_ID=");
			dynStr.Append(IsCTACTE_PROV_CASO_IDNull ? (object)"<NULL>" : CTACTE_PROV_CASO_ID);
			dynStr.Append("@CBA@MONTO_BRUTO=");
			dynStr.Append(IsMONTO_BRUTONull ? (object)"<NULL>" : MONTO_BRUTO);
			return dynStr.ToString();
		}
	} // End of PLANILLA_PAGOS_DETALLESRow_Base class
} // End of namespace
