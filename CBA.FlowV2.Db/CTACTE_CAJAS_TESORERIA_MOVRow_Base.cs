// <fileinfo name="CTACTE_CAJAS_TESORERIA_MOVRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> that 
	/// represents a record in the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJAS_TESORERIA_MOVRow_Base
	{
		private decimal _id;
		private decimal _ctacte_caja_tesoreria_id;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private System.DateTime _fecha_operacion;
		private decimal _usuario_operacion_id;
		private decimal _ctacte_valor_id;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _ingreso;
		private bool _ingresoNull = true;
		private decimal _egreso;
		private bool _egresoNull = true;
		private System.DateTime _fecha_ingreso;
		private bool _fecha_ingresoNull = true;
		private System.DateTime _fecha_egreso;
		private bool _fecha_egresoNull = true;
		private string _observacion;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private decimal _ctacte_procesadora_tarjeta_id;
		private bool _ctacte_procesadora_tarjeta_idNull = true;
		private decimal _deposito_bancario_det_id;
		private bool _deposito_bancario_det_idNull = true;
		private decimal _orden_pago_valor_id;
		private bool _orden_pago_valor_idNull = true;
		private decimal _cambio_divisa_det_id;
		private bool _cambio_divisa_det_idNull = true;
		private decimal _movimiento_vario_det_id;
		private bool _movimiento_vario_det_idNull = true;
		private decimal _transferencia_det_id;
		private bool _transferencia_det_idNull = true;
		private decimal _custodia_valor_det_id;
		private bool _custodia_valor_det_idNull = true;
		private decimal _descuento_documento_pago_id;
		private bool _descuento_documento_pago_idNull = true;
		private decimal _descuento_documento_det_id;
		private bool _descuento_documento_det_idNull = true;
		private decimal _canje_valor_det_id;
		private bool _canje_valor_det_idNull = true;
		private decimal _canje_valor_val_id;
		private bool _canje_valor_val_idNull = true;
		private decimal _desembolso_giro_id;
		private bool _desembolso_giro_idNull = true;
		private decimal _custodia_valor_det_entrada_id;
		private bool _custodia_valor_det_entrada_idNull = true;
		private decimal _descuento_documento_cli_det_id;
		private bool _descuento_documento_cli_det_idNull = true;
		private decimal _transferencia_caja_suc_det_id;
		private bool _transferencia_caja_suc_det_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJAS_TESORERIA_MOVRow_Base"/> class.
		/// </summary>
		public CTACTE_CAJAS_TESORERIA_MOVRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CAJAS_TESORERIA_MOVRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.FECHA_OPERACION != original.FECHA_OPERACION) return true;
			if (this.USUARIO_OPERACION_ID != original.USUARIO_OPERACION_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsINGRESONull != original.IsINGRESONull) return true;
			if (!this.IsINGRESONull && !original.IsINGRESONull)
				if (this.INGRESO != original.INGRESO) return true;
			if (this.IsEGRESONull != original.IsEGRESONull) return true;
			if (!this.IsEGRESONull && !original.IsEGRESONull)
				if (this.EGRESO != original.EGRESO) return true;
			if (this.IsFECHA_INGRESONull != original.IsFECHA_INGRESONull) return true;
			if (!this.IsFECHA_INGRESONull && !original.IsFECHA_INGRESONull)
				if (this.FECHA_INGRESO != original.FECHA_INGRESO) return true;
			if (this.IsFECHA_EGRESONull != original.IsFECHA_EGRESONull) return true;
			if (!this.IsFECHA_EGRESONull && !original.IsFECHA_EGRESONull)
				if (this.FECHA_EGRESO != original.FECHA_EGRESO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.IsCTACTE_PROCESADORA_TARJETA_IDNull != original.IsCTACTE_PROCESADORA_TARJETA_IDNull) return true;
			if (!this.IsCTACTE_PROCESADORA_TARJETA_IDNull && !original.IsCTACTE_PROCESADORA_TARJETA_IDNull)
				if (this.CTACTE_PROCESADORA_TARJETA_ID != original.CTACTE_PROCESADORA_TARJETA_ID) return true;
			if (this.IsDEPOSITO_BANCARIO_DET_IDNull != original.IsDEPOSITO_BANCARIO_DET_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_DET_IDNull && !original.IsDEPOSITO_BANCARIO_DET_IDNull)
				if (this.DEPOSITO_BANCARIO_DET_ID != original.DEPOSITO_BANCARIO_DET_ID) return true;
			if (this.IsORDEN_PAGO_VALOR_IDNull != original.IsORDEN_PAGO_VALOR_IDNull) return true;
			if (!this.IsORDEN_PAGO_VALOR_IDNull && !original.IsORDEN_PAGO_VALOR_IDNull)
				if (this.ORDEN_PAGO_VALOR_ID != original.ORDEN_PAGO_VALOR_ID) return true;
			if (this.IsCAMBIO_DIVISA_DET_IDNull != original.IsCAMBIO_DIVISA_DET_IDNull) return true;
			if (!this.IsCAMBIO_DIVISA_DET_IDNull && !original.IsCAMBIO_DIVISA_DET_IDNull)
				if (this.CAMBIO_DIVISA_DET_ID != original.CAMBIO_DIVISA_DET_ID) return true;
			if (this.IsMOVIMIENTO_VARIO_DET_IDNull != original.IsMOVIMIENTO_VARIO_DET_IDNull) return true;
			if (!this.IsMOVIMIENTO_VARIO_DET_IDNull && !original.IsMOVIMIENTO_VARIO_DET_IDNull)
				if (this.MOVIMIENTO_VARIO_DET_ID != original.MOVIMIENTO_VARIO_DET_ID) return true;
			if (this.IsTRANSFERENCIA_DET_IDNull != original.IsTRANSFERENCIA_DET_IDNull) return true;
			if (!this.IsTRANSFERENCIA_DET_IDNull && !original.IsTRANSFERENCIA_DET_IDNull)
				if (this.TRANSFERENCIA_DET_ID != original.TRANSFERENCIA_DET_ID) return true;
			if (this.IsCUSTODIA_VALOR_DET_IDNull != original.IsCUSTODIA_VALOR_DET_IDNull) return true;
			if (!this.IsCUSTODIA_VALOR_DET_IDNull && !original.IsCUSTODIA_VALOR_DET_IDNull)
				if (this.CUSTODIA_VALOR_DET_ID != original.CUSTODIA_VALOR_DET_ID) return true;
			if (this.IsDESCUENTO_DOCUMENTO_PAGO_IDNull != original.IsDESCUENTO_DOCUMENTO_PAGO_IDNull) return true;
			if (!this.IsDESCUENTO_DOCUMENTO_PAGO_IDNull && !original.IsDESCUENTO_DOCUMENTO_PAGO_IDNull)
				if (this.DESCUENTO_DOCUMENTO_PAGO_ID != original.DESCUENTO_DOCUMENTO_PAGO_ID) return true;
			if (this.IsDESCUENTO_DOCUMENTO_DET_IDNull != original.IsDESCUENTO_DOCUMENTO_DET_IDNull) return true;
			if (!this.IsDESCUENTO_DOCUMENTO_DET_IDNull && !original.IsDESCUENTO_DOCUMENTO_DET_IDNull)
				if (this.DESCUENTO_DOCUMENTO_DET_ID != original.DESCUENTO_DOCUMENTO_DET_ID) return true;
			if (this.IsCANJE_VALOR_DET_IDNull != original.IsCANJE_VALOR_DET_IDNull) return true;
			if (!this.IsCANJE_VALOR_DET_IDNull && !original.IsCANJE_VALOR_DET_IDNull)
				if (this.CANJE_VALOR_DET_ID != original.CANJE_VALOR_DET_ID) return true;
			if (this.IsCANJE_VALOR_VAL_IDNull != original.IsCANJE_VALOR_VAL_IDNull) return true;
			if (!this.IsCANJE_VALOR_VAL_IDNull && !original.IsCANJE_VALOR_VAL_IDNull)
				if (this.CANJE_VALOR_VAL_ID != original.CANJE_VALOR_VAL_ID) return true;
			if (this.IsDESEMBOLSO_GIRO_IDNull != original.IsDESEMBOLSO_GIRO_IDNull) return true;
			if (!this.IsDESEMBOLSO_GIRO_IDNull && !original.IsDESEMBOLSO_GIRO_IDNull)
				if (this.DESEMBOLSO_GIRO_ID != original.DESEMBOLSO_GIRO_ID) return true;
			if (this.IsCUSTODIA_VALOR_DET_ENTRADA_IDNull != original.IsCUSTODIA_VALOR_DET_ENTRADA_IDNull) return true;
			if (!this.IsCUSTODIA_VALOR_DET_ENTRADA_IDNull && !original.IsCUSTODIA_VALOR_DET_ENTRADA_IDNull)
				if (this.CUSTODIA_VALOR_DET_ENTRADA_ID != original.CUSTODIA_VALOR_DET_ENTRADA_ID) return true;
			if (this.IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull != original.IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull) return true;
			if (!this.IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull && !original.IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull)
				if (this.DESCUENTO_DOCUMENTO_CLI_DET_ID != original.DESCUENTO_DOCUMENTO_CLI_DET_ID) return true;
			if (this.IsTRANSFERENCIA_CAJA_SUC_DET_IDNull != original.IsTRANSFERENCIA_CAJA_SUC_DET_IDNull) return true;
			if (!this.IsTRANSFERENCIA_CAJA_SUC_DET_IDNull && !original.IsTRANSFERENCIA_CAJA_SUC_DET_IDNull)
				if (this.TRANSFERENCIA_CAJA_SUC_DET_ID != original.TRANSFERENCIA_CAJA_SUC_DET_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_ID
		{
			get { return _ctacte_caja_tesoreria_id; }
			set { _ctacte_caja_tesoreria_id = value; }
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
		/// Gets or sets the <c>FECHA_OPERACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_OPERACION</c> column value.</value>
		public System.DateTime FECHA_OPERACION
		{
			get { return _fecha_operacion; }
			set { _fecha_operacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_OPERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_OPERACION_ID</c> column value.</value>
		public decimal USUARIO_OPERACION_ID
		{
			get { return _usuario_operacion_id; }
			set { _usuario_operacion_id = value; }
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
		/// Gets or sets the <c>FECHA_INGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INGRESO</c> column value.</value>
		public System.DateTime FECHA_INGRESO
		{
			get
			{
				if(IsFECHA_INGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ingreso;
			}
			set
			{
				_fecha_ingresoNull = false;
				_fecha_ingreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INGRESONull
		{
			get { return _fecha_ingresoNull; }
			set { _fecha_ingresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_EGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_EGRESO</c> column value.</value>
		public System.DateTime FECHA_EGRESO
		{
			get
			{
				if(IsFECHA_EGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_egreso;
			}
			set
			{
				_fecha_egresoNull = false;
				_fecha_egreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_EGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_EGRESONull
		{
			get { return _fecha_egresoNull; }
			set { _fecha_egresoNull = value; }
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
		/// Gets or sets the <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</value>
		public decimal CTACTE_PROCESADORA_TARJETA_ID
		{
			get
			{
				if(IsCTACTE_PROCESADORA_TARJETA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_procesadora_tarjeta_id;
			}
			set
			{
				_ctacte_procesadora_tarjeta_idNull = false;
				_ctacte_procesadora_tarjeta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROCESADORA_TARJETA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROCESADORA_TARJETA_IDNull
		{
			get { return _ctacte_procesadora_tarjeta_idNull; }
			set { _ctacte_procesadora_tarjeta_idNull = value; }
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
		/// Gets or sets the <c>CAMBIO_DIVISA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CAMBIO_DIVISA_DET_ID</c> column value.</value>
		public decimal CAMBIO_DIVISA_DET_ID
		{
			get
			{
				if(IsCAMBIO_DIVISA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cambio_divisa_det_id;
			}
			set
			{
				_cambio_divisa_det_idNull = false;
				_cambio_divisa_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CAMBIO_DIVISA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCAMBIO_DIVISA_DET_IDNull
		{
			get { return _cambio_divisa_det_idNull; }
			set { _cambio_divisa_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOVIMIENTO_VARIO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</value>
		public decimal MOVIMIENTO_VARIO_DET_ID
		{
			get
			{
				if(IsMOVIMIENTO_VARIO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _movimiento_vario_det_id;
			}
			set
			{
				_movimiento_vario_det_idNull = false;
				_movimiento_vario_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOVIMIENTO_VARIO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOVIMIENTO_VARIO_DET_IDNull
		{
			get { return _movimiento_vario_det_idNull; }
			set { _movimiento_vario_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_DET_ID</c> column value.</value>
		public decimal TRANSFERENCIA_DET_ID
		{
			get
			{
				if(IsTRANSFERENCIA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_det_id;
			}
			set
			{
				_transferencia_det_idNull = false;
				_transferencia_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_DET_IDNull
		{
			get { return _transferencia_det_idNull; }
			set { _transferencia_det_idNull = value; }
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
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_PAGO_ID
		{
			get
			{
				if(IsDESCUENTO_DOCUMENTO_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_documento_pago_id;
			}
			set
			{
				_descuento_documento_pago_idNull = false;
				_descuento_documento_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_DOCUMENTO_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_DOCUMENTO_PAGO_IDNull
		{
			get { return _descuento_documento_pago_idNull; }
			set { _descuento_documento_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_DET_ID
		{
			get
			{
				if(IsDESCUENTO_DOCUMENTO_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_documento_det_id;
			}
			set
			{
				_descuento_documento_det_idNull = false;
				_descuento_documento_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_DOCUMENTO_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_DOCUMENTO_DET_IDNull
		{
			get { return _descuento_documento_det_idNull; }
			set { _descuento_documento_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANJE_VALOR_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANJE_VALOR_DET_ID</c> column value.</value>
		public decimal CANJE_VALOR_DET_ID
		{
			get
			{
				if(IsCANJE_VALOR_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _canje_valor_det_id;
			}
			set
			{
				_canje_valor_det_idNull = false;
				_canje_valor_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANJE_VALOR_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANJE_VALOR_DET_IDNull
		{
			get { return _canje_valor_det_idNull; }
			set { _canje_valor_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANJE_VALOR_VAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANJE_VALOR_VAL_ID</c> column value.</value>
		public decimal CANJE_VALOR_VAL_ID
		{
			get
			{
				if(IsCANJE_VALOR_VAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _canje_valor_val_id;
			}
			set
			{
				_canje_valor_val_idNull = false;
				_canje_valor_val_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANJE_VALOR_VAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANJE_VALOR_VAL_IDNull
		{
			get { return _canje_valor_val_idNull; }
			set { _canje_valor_val_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESEMBOLSO_GIRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESEMBOLSO_GIRO_ID</c> column value.</value>
		public decimal DESEMBOLSO_GIRO_ID
		{
			get
			{
				if(IsDESEMBOLSO_GIRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _desembolso_giro_id;
			}
			set
			{
				_desembolso_giro_idNull = false;
				_desembolso_giro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESEMBOLSO_GIRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESEMBOLSO_GIRO_IDNull
		{
			get { return _desembolso_giro_idNull; }
			set { _desembolso_giro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</value>
		public decimal CUSTODIA_VALOR_DET_ENTRADA_ID
		{
			get
			{
				if(IsCUSTODIA_VALOR_DET_ENTRADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _custodia_valor_det_entrada_id;
			}
			set
			{
				_custodia_valor_det_entrada_idNull = false;
				_custodia_valor_det_entrada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUSTODIA_VALOR_DET_ENTRADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUSTODIA_VALOR_DET_ENTRADA_IDNull
		{
			get { return _custodia_valor_det_entrada_idNull; }
			set { _custodia_valor_det_entrada_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_CLI_DET_ID
		{
			get
			{
				if(IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_documento_cli_det_id;
			}
			set
			{
				_descuento_documento_cli_det_idNull = false;
				_descuento_documento_cli_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_DOCUMENTO_CLI_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull
		{
			get { return _descuento_documento_cli_det_idNull; }
			set { _descuento_documento_cli_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</value>
		public decimal TRANSFERENCIA_CAJA_SUC_DET_ID
		{
			get
			{
				if(IsTRANSFERENCIA_CAJA_SUC_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_caja_suc_det_id;
			}
			set
			{
				_transferencia_caja_suc_det_idNull = false;
				_transferencia_caja_suc_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_CAJA_SUC_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_CAJA_SUC_DET_IDNull
		{
			get { return _transferencia_caja_suc_det_idNull; }
			set { _transferencia_caja_suc_det_idNull = value; }
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
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@FECHA_OPERACION=");
			dynStr.Append(FECHA_OPERACION);
			dynStr.Append("@CBA@USUARIO_OPERACION_ID=");
			dynStr.Append(USUARIO_OPERACION_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@INGRESO=");
			dynStr.Append(IsINGRESONull ? (object)"<NULL>" : INGRESO);
			dynStr.Append("@CBA@EGRESO=");
			dynStr.Append(IsEGRESONull ? (object)"<NULL>" : EGRESO);
			dynStr.Append("@CBA@FECHA_INGRESO=");
			dynStr.Append(IsFECHA_INGRESONull ? (object)"<NULL>" : FECHA_INGRESO);
			dynStr.Append("@CBA@FECHA_EGRESO=");
			dynStr.Append(IsFECHA_EGRESONull ? (object)"<NULL>" : FECHA_EGRESO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CTACTE_PROCESADORA_TARJETA_ID=");
			dynStr.Append(IsCTACTE_PROCESADORA_TARJETA_IDNull ? (object)"<NULL>" : CTACTE_PROCESADORA_TARJETA_ID);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_DET_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_DET_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_DET_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_VALOR_ID=");
			dynStr.Append(IsORDEN_PAGO_VALOR_IDNull ? (object)"<NULL>" : ORDEN_PAGO_VALOR_ID);
			dynStr.Append("@CBA@CAMBIO_DIVISA_DET_ID=");
			dynStr.Append(IsCAMBIO_DIVISA_DET_IDNull ? (object)"<NULL>" : CAMBIO_DIVISA_DET_ID);
			dynStr.Append("@CBA@MOVIMIENTO_VARIO_DET_ID=");
			dynStr.Append(IsMOVIMIENTO_VARIO_DET_IDNull ? (object)"<NULL>" : MOVIMIENTO_VARIO_DET_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_DET_ID=");
			dynStr.Append(IsTRANSFERENCIA_DET_IDNull ? (object)"<NULL>" : TRANSFERENCIA_DET_ID);
			dynStr.Append("@CBA@CUSTODIA_VALOR_DET_ID=");
			dynStr.Append(IsCUSTODIA_VALOR_DET_IDNull ? (object)"<NULL>" : CUSTODIA_VALOR_DET_ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_PAGO_ID=");
			dynStr.Append(IsDESCUENTO_DOCUMENTO_PAGO_IDNull ? (object)"<NULL>" : DESCUENTO_DOCUMENTO_PAGO_ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_DET_ID=");
			dynStr.Append(IsDESCUENTO_DOCUMENTO_DET_IDNull ? (object)"<NULL>" : DESCUENTO_DOCUMENTO_DET_ID);
			dynStr.Append("@CBA@CANJE_VALOR_DET_ID=");
			dynStr.Append(IsCANJE_VALOR_DET_IDNull ? (object)"<NULL>" : CANJE_VALOR_DET_ID);
			dynStr.Append("@CBA@CANJE_VALOR_VAL_ID=");
			dynStr.Append(IsCANJE_VALOR_VAL_IDNull ? (object)"<NULL>" : CANJE_VALOR_VAL_ID);
			dynStr.Append("@CBA@DESEMBOLSO_GIRO_ID=");
			dynStr.Append(IsDESEMBOLSO_GIRO_IDNull ? (object)"<NULL>" : DESEMBOLSO_GIRO_ID);
			dynStr.Append("@CBA@CUSTODIA_VALOR_DET_ENTRADA_ID=");
			dynStr.Append(IsCUSTODIA_VALOR_DET_ENTRADA_IDNull ? (object)"<NULL>" : CUSTODIA_VALOR_DET_ENTRADA_ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_CLI_DET_ID=");
			dynStr.Append(IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull ? (object)"<NULL>" : DESCUENTO_DOCUMENTO_CLI_DET_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_CAJA_SUC_DET_ID=");
			dynStr.Append(IsTRANSFERENCIA_CAJA_SUC_DET_IDNull ? (object)"<NULL>" : TRANSFERENCIA_CAJA_SUC_DET_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_CAJAS_TESORERIA_MOVRow_Base class
} // End of namespace
