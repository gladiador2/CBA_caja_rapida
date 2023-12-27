// <fileinfo name="CTACTE_FONDOS_FIJOS_MOVRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/> that 
	/// represents a record in the <c>CTACTE_FONDOS_FIJOS_MOV</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_FONDOS_FIJOS_MOVRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_FONDOS_FIJOS_MOVRow_Base
	{
		private decimal _id;
		private decimal _ctacte_fondo_fijo_id;
		private System.DateTime _fecha;
		private decimal _usuario_id;
		private decimal _ingreso;
		private bool _ingresoNull = true;
		private decimal _egreso;
		private bool _egresoNull = true;
		private decimal _saldo;
		private bool _saldoNull = true;
		private decimal _cotizacion_moneda;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _egreso_vario_caja_id;
		private bool _egreso_vario_caja_idNull = true;
		private string _observacion;
		private decimal _movimiento_fondo_fijo_id;
		private bool _movimiento_fondo_fijo_idNull = true;
		private decimal _transferencia_caja_suc_id;
		private bool _transferencia_caja_suc_idNull = true;
		private decimal _movimiento_fondo_fijo_det_id;
		private bool _movimiento_fondo_fijo_det_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_FONDOS_FIJOS_MOVRow_Base"/> class.
		/// </summary>
		public CTACTE_FONDOS_FIJOS_MOVRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_FONDOS_FIJOS_MOVRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsINGRESONull != original.IsINGRESONull) return true;
			if (!this.IsINGRESONull && !original.IsINGRESONull)
				if (this.INGRESO != original.INGRESO) return true;
			if (this.IsEGRESONull != original.IsEGRESONull) return true;
			if (!this.IsEGRESONull && !original.IsEGRESONull)
				if (this.EGRESO != original.EGRESO) return true;
			if (this.IsSALDONull != original.IsSALDONull) return true;
			if (!this.IsSALDONull && !original.IsSALDONull)
				if (this.SALDO != original.SALDO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsEGRESO_VARIO_CAJA_IDNull != original.IsEGRESO_VARIO_CAJA_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_IDNull && !original.IsEGRESO_VARIO_CAJA_IDNull)
				if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsMOVIMIENTO_FONDO_FIJO_IDNull != original.IsMOVIMIENTO_FONDO_FIJO_IDNull) return true;
			if (!this.IsMOVIMIENTO_FONDO_FIJO_IDNull && !original.IsMOVIMIENTO_FONDO_FIJO_IDNull)
				if (this.MOVIMIENTO_FONDO_FIJO_ID != original.MOVIMIENTO_FONDO_FIJO_ID) return true;
			if (this.IsTRANSFERENCIA_CAJA_SUC_IDNull != original.IsTRANSFERENCIA_CAJA_SUC_IDNull) return true;
			if (!this.IsTRANSFERENCIA_CAJA_SUC_IDNull && !original.IsTRANSFERENCIA_CAJA_SUC_IDNull)
				if (this.TRANSFERENCIA_CAJA_SUC_ID != original.TRANSFERENCIA_CAJA_SUC_ID) return true;
			if (this.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull != original.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull) return true;
			if (!this.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull && !original.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull)
				if (this.MOVIMIENTO_FONDO_FIJO_DET_ID != original.MOVIMIENTO_FONDO_FIJO_DET_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get { return _ctacte_fondo_fijo_id; }
			set { _ctacte_fondo_fijo_id = value; }
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO</c> column value.</value>
		public decimal INGRESO
		{
			get
			{
				if(IsINGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso;
			}
			set
			{
				_ingresoNull = false;
				_ingreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESONull
		{
			get { return _ingresoNull; }
			set { _ingresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO</c> column value.</value>
		public decimal EGRESO
		{
			get
			{
				if(IsEGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso;
			}
			set
			{
				_egresoNull = false;
				_egreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESONull
		{
			get { return _egresoNull; }
			set { _egresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO</c> column value.</value>
		public decimal SALDO
		{
			get
			{
				if(IsSALDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo;
			}
			set
			{
				_saldoNull = false;
				_saldo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDONull
		{
			get { return _saldoNull; }
			set { _saldoNull = value; }
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
		/// Gets or sets the <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_FONDO_FIJO_ID</c> column value.</value>
		public decimal MOVIMIENTO_FONDO_FIJO_ID
		{
			get
			{
				if(IsMOVIMIENTO_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_fondo_fijo_id;
			}
			set
			{
				_movimiento_fondo_fijo_idNull = false;
				_movimiento_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_FONDO_FIJO_IDNull
		{
			get { return _movimiento_fondo_fijo_idNull; }
			set { _movimiento_fondo_fijo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_CAJA_SUC_ID</c> column value.</value>
		public decimal TRANSFERENCIA_CAJA_SUC_ID
		{
			get
			{
				if(IsTRANSFERENCIA_CAJA_SUC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_caja_suc_id;
			}
			set
			{
				_transferencia_caja_suc_idNull = false;
				_transferencia_caja_suc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_CAJA_SUC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_CAJA_SUC_IDNull
		{
			get { return _transferencia_caja_suc_idNull; }
			set { _transferencia_caja_suc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</value>
		public decimal MOVIMIENTO_FONDO_FIJO_DET_ID
		{
			get
			{
				if(IsMOVIMIENTO_FONDO_FIJO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_fondo_fijo_det_id;
			}
			set
			{
				_movimiento_fondo_fijo_det_idNull = false;
				_movimiento_fondo_fijo_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_FONDO_FIJO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_FONDO_FIJO_DET_IDNull
		{
			get { return _movimiento_fondo_fijo_det_idNull; }
			set { _movimiento_fondo_fijo_det_idNull = value; }
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
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@INGRESO=");
			dynStr.Append(IsINGRESONull ? (object)"<NULL>" : INGRESO);
			dynStr.Append("@CBA@EGRESO=");
			dynStr.Append(IsEGRESONull ? (object)"<NULL>" : EGRESO);
			dynStr.Append("@CBA@SALDO=");
			dynStr.Append(IsSALDONull ? (object)"<NULL>" : SALDO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MOVIMIENTO_FONDO_FIJO_ID=");
			dynStr.Append(IsMOVIMIENTO_FONDO_FIJO_IDNull ? (object)"<NULL>" : MOVIMIENTO_FONDO_FIJO_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_CAJA_SUC_ID=");
			dynStr.Append(IsTRANSFERENCIA_CAJA_SUC_IDNull ? (object)"<NULL>" : TRANSFERENCIA_CAJA_SUC_ID);
			dynStr.Append("@CBA@MOVIMIENTO_FONDO_FIJO_DET_ID=");
			dynStr.Append(IsMOVIMIENTO_FONDO_FIJO_DET_IDNull ? (object)"<NULL>" : MOVIMIENTO_FONDO_FIJO_DET_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_FONDOS_FIJOS_MOVRow_Base class
} // End of namespace
