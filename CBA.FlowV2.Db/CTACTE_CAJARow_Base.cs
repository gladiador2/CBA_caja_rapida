// <fileinfo name="CTACTE_CAJARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJARow"/> that 
	/// represents a record in the <c>CTACTE_CAJA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJARow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _usuario_id;
		private decimal _funcionario_cobrador_id;
		private decimal _ctacte_concepto_id;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _ctacte_valor_id;
		private decimal _monto;
		private System.DateTime _fecha;
		private decimal _ctacte_pago_persona_id;
		private bool _ctacte_pago_persona_idNull = true;
		private decimal _ctacte_pago_persona_det_id;
		private bool _ctacte_pago_persona_det_idNull = true;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _egreso_vario_id;
		private bool _egreso_vario_idNull = true;
		private decimal _ctacte_fondo_fijo_mov_id;
		private bool _ctacte_fondo_fijo_mov_idNull = true;
		private decimal _anticipo_persona_id;
		private bool _anticipo_persona_idNull = true;
		private decimal _anticipo_persona_det_id;
		private bool _anticipo_persona_det_idNull = true;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _deposito_bancario_det_id;
		private bool _deposito_bancario_det_idNull = true;
		private decimal _transferencia_caja_suc_id;
		private bool _transferencia_caja_suc_idNull = true;
		private string _estado;
		private decimal _ctacte_caja_reserva_det_id;
		private bool _ctacte_caja_reserva_det_idNull = true;
		private decimal _movimiento_fondo_fijo_id;
		private bool _movimiento_fondo_fijo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJARow_Base"/> class.
		/// </summary>
		public CTACTE_CAJARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.FUNCIONARIO_COBRADOR_ID != original.FUNCIONARIO_COBRADOR_ID) return true;
			if (this.CTACTE_CONCEPTO_ID != original.CTACTE_CONCEPTO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsCTACTE_PAGO_PERSONA_IDNull != original.IsCTACTE_PAGO_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_IDNull && !original.IsCTACTE_PAGO_PERSONA_IDNull)
				if (this.CTACTE_PAGO_PERSONA_ID != original.CTACTE_PAGO_PERSONA_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DET_IDNull != original.IsCTACTE_PAGO_PERSONA_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DET_IDNull && !original.IsCTACTE_PAGO_PERSONA_DET_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DET_ID != original.CTACTE_PAGO_PERSONA_DET_ID) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsEGRESO_VARIO_IDNull != original.IsEGRESO_VARIO_IDNull) return true;
			if (!this.IsEGRESO_VARIO_IDNull && !original.IsEGRESO_VARIO_IDNull)
				if (this.EGRESO_VARIO_ID != original.EGRESO_VARIO_ID) return true;
			if (this.IsCTACTE_FONDO_FIJO_MOV_IDNull != original.IsCTACTE_FONDO_FIJO_MOV_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_MOV_IDNull && !original.IsCTACTE_FONDO_FIJO_MOV_IDNull)
				if (this.CTACTE_FONDO_FIJO_MOV_ID != original.CTACTE_FONDO_FIJO_MOV_ID) return true;
			if (this.IsANTICIPO_PERSONA_IDNull != original.IsANTICIPO_PERSONA_IDNull) return true;
			if (!this.IsANTICIPO_PERSONA_IDNull && !original.IsANTICIPO_PERSONA_IDNull)
				if (this.ANTICIPO_PERSONA_ID != original.ANTICIPO_PERSONA_ID) return true;
			if (this.IsANTICIPO_PERSONA_DET_IDNull != original.IsANTICIPO_PERSONA_DET_IDNull) return true;
			if (!this.IsANTICIPO_PERSONA_DET_IDNull && !original.IsANTICIPO_PERSONA_DET_IDNull)
				if (this.ANTICIPO_PERSONA_DET_ID != original.ANTICIPO_PERSONA_DET_ID) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsDEPOSITO_BANCARIO_DET_IDNull != original.IsDEPOSITO_BANCARIO_DET_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_DET_IDNull && !original.IsDEPOSITO_BANCARIO_DET_IDNull)
				if (this.DEPOSITO_BANCARIO_DET_ID != original.DEPOSITO_BANCARIO_DET_ID) return true;
			if (this.IsTRANSFERENCIA_CAJA_SUC_IDNull != original.IsTRANSFERENCIA_CAJA_SUC_IDNull) return true;
			if (!this.IsTRANSFERENCIA_CAJA_SUC_IDNull && !original.IsTRANSFERENCIA_CAJA_SUC_IDNull)
				if (this.TRANSFERENCIA_CAJA_SUC_ID != original.TRANSFERENCIA_CAJA_SUC_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsCTACTE_CAJA_RESERVA_DET_IDNull != original.IsCTACTE_CAJA_RESERVA_DET_IDNull) return true;
			if (!this.IsCTACTE_CAJA_RESERVA_DET_IDNull && !original.IsCTACTE_CAJA_RESERVA_DET_IDNull)
				if (this.CTACTE_CAJA_RESERVA_DET_ID != original.CTACTE_CAJA_RESERVA_DET_ID) return true;
			if (this.IsMOVIMIENTO_FONDO_FIJO_IDNull != original.IsMOVIMIENTO_FONDO_FIJO_IDNull) return true;
			if (!this.IsMOVIMIENTO_FONDO_FIJO_IDNull && !original.IsMOVIMIENTO_FONDO_FIJO_IDNull)
				if (this.MOVIMIENTO_FONDO_FIJO_ID != original.MOVIMIENTO_FONDO_FIJO_ID) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_COBRADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</value>
		public decimal FUNCIONARIO_COBRADOR_ID
		{
			get { return _funcionario_cobrador_id; }
			set { _funcionario_cobrador_id = value; }
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
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_id;
			}
			set
			{
				_ctacte_pago_persona_idNull = false;
				_ctacte_pago_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_IDNull
		{
			get { return _ctacte_pago_persona_idNull; }
			set { _ctacte_pago_persona_idNull = value; }
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
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_VARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_VARIO_ID</c> column value.</value>
		public decimal EGRESO_VARIO_ID
		{
			get
			{
				if(IsEGRESO_VARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_vario_id;
			}
			set
			{
				_egreso_vario_idNull = false;
				_egreso_vario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_VARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_VARIO_IDNull
		{
			get { return _egreso_vario_idNull; }
			set { _egreso_vario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_MOV_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_MOV_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_MOV_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_mov_id;
			}
			set
			{
				_ctacte_fondo_fijo_mov_idNull = false;
				_ctacte_fondo_fijo_mov_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_MOV_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_MOV_IDNull
		{
			get { return _ctacte_fondo_fijo_mov_idNull; }
			set { _ctacte_fondo_fijo_mov_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_PERSONA_ID</c> column value.</value>
		public decimal ANTICIPO_PERSONA_ID
		{
			get
			{
				if(IsANTICIPO_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_persona_id;
			}
			set
			{
				_anticipo_persona_idNull = false;
				_anticipo_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_PERSONA_IDNull
		{
			get { return _anticipo_persona_idNull; }
			set { _anticipo_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_PERSONA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_PERSONA_DET_ID</c> column value.</value>
		public decimal ANTICIPO_PERSONA_DET_ID
		{
			get
			{
				if(IsANTICIPO_PERSONA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_persona_det_id;
			}
			set
			{
				_anticipo_persona_det_idNull = false;
				_anticipo_persona_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_PERSONA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_PERSONA_DET_IDNull
		{
			get { return _anticipo_persona_det_idNull; }
			set { _anticipo_persona_det_idNull = value; }
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
		/// Gets or sets the <c>DEPOSITO_BANCARIO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</value>
		public decimal DEPOSITO_BANCARIO_DET_ID
		{
			get
			{
				if(IsDEPOSITO_BANCARIO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_bancario_det_id;
			}
			set
			{
				_deposito_bancario_det_idNull = false;
				_deposito_bancario_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_BANCARIO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_BANCARIO_DET_IDNull
		{
			get { return _deposito_bancario_det_idNull; }
			set { _deposito_bancario_det_idNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_RESERVA_DET_ID</c> column value.</value>
		public decimal CTACTE_CAJA_RESERVA_DET_ID
		{
			get
			{
				if(IsCTACTE_CAJA_RESERVA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_reserva_det_id;
			}
			set
			{
				_ctacte_caja_reserva_det_idNull = false;
				_ctacte_caja_reserva_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_RESERVA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_RESERVA_DET_IDNull
		{
			get { return _ctacte_caja_reserva_det_idNull; }
			set { _ctacte_caja_reserva_det_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_COBRADOR_ID=");
			dynStr.Append(FUNCIONARIO_COBRADOR_ID);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_ID=");
			dynStr.Append(CTACTE_CONCEPTO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DET_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DET_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@EGRESO_VARIO_ID=");
			dynStr.Append(IsEGRESO_VARIO_IDNull ? (object)"<NULL>" : EGRESO_VARIO_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_MOV_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_MOV_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_MOV_ID);
			dynStr.Append("@CBA@ANTICIPO_PERSONA_ID=");
			dynStr.Append(IsANTICIPO_PERSONA_IDNull ? (object)"<NULL>" : ANTICIPO_PERSONA_ID);
			dynStr.Append("@CBA@ANTICIPO_PERSONA_DET_ID=");
			dynStr.Append(IsANTICIPO_PERSONA_DET_IDNull ? (object)"<NULL>" : ANTICIPO_PERSONA_DET_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_DET_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_DET_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_DET_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_CAJA_SUC_ID=");
			dynStr.Append(IsTRANSFERENCIA_CAJA_SUC_IDNull ? (object)"<NULL>" : TRANSFERENCIA_CAJA_SUC_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CTACTE_CAJA_RESERVA_DET_ID=");
			dynStr.Append(IsCTACTE_CAJA_RESERVA_DET_IDNull ? (object)"<NULL>" : CTACTE_CAJA_RESERVA_DET_ID);
			dynStr.Append("@CBA@MOVIMIENTO_FONDO_FIJO_ID=");
			dynStr.Append(IsMOVIMIENTO_FONDO_FIJO_IDNull ? (object)"<NULL>" : MOVIMIENTO_FONDO_FIJO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJARow_Base class
} // End of namespace
