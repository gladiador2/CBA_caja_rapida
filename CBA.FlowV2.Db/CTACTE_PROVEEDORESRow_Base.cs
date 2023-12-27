// <fileinfo name="CTACTE_PROVEEDORESRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROVEEDORESRow"/> that 
	/// represents a record in the <c>CTACTE_PROVEEDORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PROVEEDORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROVEEDORESRow_Base
	{
		private decimal _id;
		private decimal _proveedor_id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private System.DateTime _fecha_insercion;
		private System.DateTime _fecha_vencimiento;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _ctacte_concepto_id;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _movimiento_vario_tesoreria_id;
		private bool _movimiento_vario_tesoreria_idNull = true;
		private decimal _egreso_vario_caja_id;
		private bool _egreso_vario_caja_idNull = true;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private decimal _calendario_pagos_fc_prov_id;
		private bool _calendario_pagos_fc_prov_idNull = true;
		private decimal _credito_proveedor_det_id;
		private bool _credito_proveedor_det_idNull = true;
		private decimal _credito;
		private decimal _debito;
		private string _concepto;
		private decimal _ctacte_proveedor_relac_id;
		private bool _ctacte_proveedor_relac_idNull = true;
		private decimal _nc_aplicacion_id;
		private bool _nc_aplicacion_idNull = true;
		private decimal _nc_aplicacion_det_id;
		private bool _nc_aplicacion_det_idNull = true;
		private decimal _orden_pago_valor_id;
		private bool _orden_pago_valor_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROVEEDORESRow_Base"/> class.
		/// </summary>
		public CTACTE_PROVEEDORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PROVEEDORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CTACTE_CONCEPTO_ID != original.CTACTE_CONCEPTO_ID) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsMOVIMIENTO_VARIO_TESORERIA_IDNull != original.IsMOVIMIENTO_VARIO_TESORERIA_IDNull) return true;
			if (!this.IsMOVIMIENTO_VARIO_TESORERIA_IDNull && !original.IsMOVIMIENTO_VARIO_TESORERIA_IDNull)
				if (this.MOVIMIENTO_VARIO_TESORERIA_ID != original.MOVIMIENTO_VARIO_TESORERIA_ID) return true;
			if (this.IsEGRESO_VARIO_CAJA_IDNull != original.IsEGRESO_VARIO_CAJA_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_IDNull && !original.IsEGRESO_VARIO_CAJA_IDNull)
				if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.IsCALENDARIO_PAGOS_FC_PROV_IDNull != original.IsCALENDARIO_PAGOS_FC_PROV_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_FC_PROV_IDNull && !original.IsCALENDARIO_PAGOS_FC_PROV_IDNull)
				if (this.CALENDARIO_PAGOS_FC_PROV_ID != original.CALENDARIO_PAGOS_FC_PROV_ID) return true;
			if (this.IsCREDITO_PROVEEDOR_DET_IDNull != original.IsCREDITO_PROVEEDOR_DET_IDNull) return true;
			if (!this.IsCREDITO_PROVEEDOR_DET_IDNull && !original.IsCREDITO_PROVEEDOR_DET_IDNull)
				if (this.CREDITO_PROVEEDOR_DET_ID != original.CREDITO_PROVEEDOR_DET_ID) return true;
			if (this.CREDITO != original.CREDITO) return true;
			if (this.DEBITO != original.DEBITO) return true;
			if (this.CONCEPTO != original.CONCEPTO) return true;
			if (this.IsCTACTE_PROVEEDOR_RELAC_IDNull != original.IsCTACTE_PROVEEDOR_RELAC_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_RELAC_IDNull && !original.IsCTACTE_PROVEEDOR_RELAC_IDNull)
				if (this.CTACTE_PROVEEDOR_RELAC_ID != original.CTACTE_PROVEEDOR_RELAC_ID) return true;
			if (this.IsNC_APLICACION_IDNull != original.IsNC_APLICACION_IDNull) return true;
			if (!this.IsNC_APLICACION_IDNull && !original.IsNC_APLICACION_IDNull)
				if (this.NC_APLICACION_ID != original.NC_APLICACION_ID) return true;
			if (this.IsNC_APLICACION_DET_IDNull != original.IsNC_APLICACION_DET_IDNull) return true;
			if (!this.IsNC_APLICACION_DET_IDNull && !original.IsNC_APLICACION_DET_IDNull)
				if (this.NC_APLICACION_DET_ID != original.NC_APLICACION_DET_ID) return true;
			if (this.IsORDEN_PAGO_VALOR_IDNull != original.IsORDEN_PAGO_VALOR_IDNull) return true;
			if (!this.IsORDEN_PAGO_VALOR_IDNull && !original.IsORDEN_PAGO_VALOR_IDNull)
				if (this.ORDEN_PAGO_VALOR_ID != original.ORDEN_PAGO_VALOR_ID) return true;
			
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
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
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
		/// Gets or sets the <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</value>
		public decimal MOVIMIENTO_VARIO_TESORERIA_ID
		{
			get
			{
				if(IsMOVIMIENTO_VARIO_TESORERIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_vario_tesoreria_id;
			}
			set
			{
				_movimiento_vario_tesoreria_idNull = false;
				_movimiento_vario_tesoreria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_VARIO_TESORERIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_VARIO_TESORERIA_IDNull
		{
			get { return _movimiento_vario_tesoreria_idNull; }
			set { _movimiento_vario_tesoreria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_VARIO_CAJA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_CAJA_ID</c> column value.</value>
		public decimal EGRESO_VARIO_CAJA_ID
		{
			get
			{
				if(IsEGRESO_VARIO_CAJA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_vario_caja_id;
			}
			set
			{
				_egreso_vario_caja_idNull = false;
				_egreso_vario_caja_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_VARIO_CAJA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_VARIO_CAJA_IDNull
		{
			get { return _egreso_vario_caja_idNull; }
			set { _egreso_vario_caja_idNull = value; }
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
		/// Gets or sets the <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_FC_PROV_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_FC_PROV_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_fc_prov_id;
			}
			set
			{
				_calendario_pagos_fc_prov_idNull = false;
				_calendario_pagos_fc_prov_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_FC_PROV_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_FC_PROV_IDNull
		{
			get { return _calendario_pagos_fc_prov_idNull; }
			set { _calendario_pagos_fc_prov_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO_PROVEEDOR_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</value>
		public decimal CREDITO_PROVEEDOR_DET_ID
		{
			get
			{
				if(IsCREDITO_PROVEEDOR_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito_proveedor_det_id;
			}
			set
			{
				_credito_proveedor_det_idNull = false;
				_credito_proveedor_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO_PROVEEDOR_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITO_PROVEEDOR_DET_IDNull
		{
			get { return _credito_proveedor_det_idNull; }
			set { _credito_proveedor_det_idNull = value; }
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
		/// Gets or sets the <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_RELAC_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_RELAC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_relac_id;
			}
			set
			{
				_ctacte_proveedor_relac_idNull = false;
				_ctacte_proveedor_relac_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_RELAC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_RELAC_IDNull
		{
			get { return _ctacte_proveedor_relac_idNull; }
			set { _ctacte_proveedor_relac_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_APLICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_APLICACION_ID</c> column value.</value>
		public decimal NC_APLICACION_ID
		{
			get
			{
				if(IsNC_APLICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_aplicacion_id;
			}
			set
			{
				_nc_aplicacion_idNull = false;
				_nc_aplicacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_APLICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_APLICACION_IDNull
		{
			get { return _nc_aplicacion_idNull; }
			set { _nc_aplicacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NC_APLICACION_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NC_APLICACION_DET_ID</c> column value.</value>
		public decimal NC_APLICACION_DET_ID
		{
			get
			{
				if(IsNC_APLICACION_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nc_aplicacion_det_id;
			}
			set
			{
				_nc_aplicacion_det_idNull = false;
				_nc_aplicacion_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NC_APLICACION_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNC_APLICACION_DET_IDNull
		{
			get { return _nc_aplicacion_det_idNull; }
			set { _nc_aplicacion_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_VALOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_VALOR_ID</c> column value.</value>
		public decimal ORDEN_PAGO_VALOR_ID
		{
			get
			{
				if(IsORDEN_PAGO_VALOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_valor_id;
			}
			set
			{
				_orden_pago_valor_idNull = false;
				_orden_pago_valor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_VALOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_VALOR_IDNull
		{
			get { return _orden_pago_valor_idNull; }
			set { _orden_pago_valor_idNull = value; }
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
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_ID=");
			dynStr.Append(CTACTE_CONCEPTO_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@MOVIMIENTO_VARIO_TESORERIA_ID=");
			dynStr.Append(IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? (object)"<NULL>" : MOVIMIENTO_VARIO_TESORERIA_ID);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_FC_PROV_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_FC_PROV_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_FC_PROV_ID);
			dynStr.Append("@CBA@CREDITO_PROVEEDOR_DET_ID=");
			dynStr.Append(IsCREDITO_PROVEEDOR_DET_IDNull ? (object)"<NULL>" : CREDITO_PROVEEDOR_DET_ID);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(DEBITO);
			dynStr.Append("@CBA@CONCEPTO=");
			dynStr.Append(CONCEPTO);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_RELAC_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_RELAC_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_RELAC_ID);
			dynStr.Append("@CBA@NC_APLICACION_ID=");
			dynStr.Append(IsNC_APLICACION_IDNull ? (object)"<NULL>" : NC_APLICACION_ID);
			dynStr.Append("@CBA@NC_APLICACION_DET_ID=");
			dynStr.Append(IsNC_APLICACION_DET_IDNull ? (object)"<NULL>" : NC_APLICACION_DET_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_VALOR_ID=");
			dynStr.Append(IsORDEN_PAGO_VALOR_IDNull ? (object)"<NULL>" : ORDEN_PAGO_VALOR_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_PROVEEDORESRow_Base class
} // End of namespace
