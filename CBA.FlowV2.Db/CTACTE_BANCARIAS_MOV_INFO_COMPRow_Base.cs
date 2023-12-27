// <fileinfo name="CTACTE_BANCARIAS_MOV_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_BANCARIAS_MOV_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCARIAS_MOV_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _ctacte_bancaria_id;
		private System.DateTime _fecha;
		private decimal _usuario_id;
		private decimal _ingreso;
		private bool _ingresoNull = true;
		private decimal _egreso;
		private bool _egresoNull = true;
		private decimal _saldo;
		private bool _saldoNull = true;
		private decimal _cotizacion_moneda;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _caso_nro_comprobante;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _deposito_bancario_id;
		private bool _deposito_bancario_idNull = true;
		private decimal _transferencia_bancaria_id;
		private bool _transferencia_bancaria_idNull = true;
		private decimal _ajuste_bancario_id;
		private bool _ajuste_bancario_idNull = true;
		private decimal _descuento_documento_id;
		private bool _descuento_documento_idNull = true;
		private decimal _custodia_valores_id;
		private bool _custodia_valores_idNull = true;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _movimiento_vario_tesoreria_id;
		private bool _movimiento_vario_tesoreria_idNull = true;
		private System.DateTime _fecha_insercion;
		private decimal _egreso_vario_caja_id;
		private bool _egreso_vario_caja_idNull = true;
		private string _observacion;
		private string _conciliado;
		private decimal _conciliado_usuario_id;
		private bool _conciliado_usuario_idNull = true;
		private string _conciliado_usuario_nombre;
		private System.DateTime _conciliado_fecha;
		private bool _conciliado_fechaNull = true;
		private decimal _desconciliado_usuario_id;
		private bool _desconciliado_usuario_idNull = true;
		private string _desconciliado_usuario_nombre;
		private System.DateTime _desconciliado_fecha;
		private bool _desconciliado_fechaNull = true;
		private decimal _ctacte_cheque_girado_id;
		private bool _ctacte_cheque_girado_idNull = true;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_BANCARIAS_MOV_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_BANCARIAS_MOV_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
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
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsDEPOSITO_BANCARIO_IDNull != original.IsDEPOSITO_BANCARIO_IDNull) return true;
			if (!this.IsDEPOSITO_BANCARIO_IDNull && !original.IsDEPOSITO_BANCARIO_IDNull)
				if (this.DEPOSITO_BANCARIO_ID != original.DEPOSITO_BANCARIO_ID) return true;
			if (this.IsTRANSFERENCIA_BANCARIA_IDNull != original.IsTRANSFERENCIA_BANCARIA_IDNull) return true;
			if (!this.IsTRANSFERENCIA_BANCARIA_IDNull && !original.IsTRANSFERENCIA_BANCARIA_IDNull)
				if (this.TRANSFERENCIA_BANCARIA_ID != original.TRANSFERENCIA_BANCARIA_ID) return true;
			if (this.IsAJUSTE_BANCARIO_IDNull != original.IsAJUSTE_BANCARIO_IDNull) return true;
			if (!this.IsAJUSTE_BANCARIO_IDNull && !original.IsAJUSTE_BANCARIO_IDNull)
				if (this.AJUSTE_BANCARIO_ID != original.AJUSTE_BANCARIO_ID) return true;
			if (this.IsDESCUENTO_DOCUMENTO_IDNull != original.IsDESCUENTO_DOCUMENTO_IDNull) return true;
			if (!this.IsDESCUENTO_DOCUMENTO_IDNull && !original.IsDESCUENTO_DOCUMENTO_IDNull)
				if (this.DESCUENTO_DOCUMENTO_ID != original.DESCUENTO_DOCUMENTO_ID) return true;
			if (this.IsCUSTODIA_VALORES_IDNull != original.IsCUSTODIA_VALORES_IDNull) return true;
			if (!this.IsCUSTODIA_VALORES_IDNull && !original.IsCUSTODIA_VALORES_IDNull)
				if (this.CUSTODIA_VALORES_ID != original.CUSTODIA_VALORES_ID) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsMOVIMIENTO_VARIO_TESORERIA_IDNull != original.IsMOVIMIENTO_VARIO_TESORERIA_IDNull) return true;
			if (!this.IsMOVIMIENTO_VARIO_TESORERIA_IDNull && !original.IsMOVIMIENTO_VARIO_TESORERIA_IDNull)
				if (this.MOVIMIENTO_VARIO_TESORERIA_ID != original.MOVIMIENTO_VARIO_TESORERIA_ID) return true;
			if (this.FECHA_INSERCION != original.FECHA_INSERCION) return true;
			if (this.IsEGRESO_VARIO_CAJA_IDNull != original.IsEGRESO_VARIO_CAJA_IDNull) return true;
			if (!this.IsEGRESO_VARIO_CAJA_IDNull && !original.IsEGRESO_VARIO_CAJA_IDNull)
				if (this.EGRESO_VARIO_CAJA_ID != original.EGRESO_VARIO_CAJA_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.CONCILIADO != original.CONCILIADO) return true;
			if (this.IsCONCILIADO_USUARIO_IDNull != original.IsCONCILIADO_USUARIO_IDNull) return true;
			if (!this.IsCONCILIADO_USUARIO_IDNull && !original.IsCONCILIADO_USUARIO_IDNull)
				if (this.CONCILIADO_USUARIO_ID != original.CONCILIADO_USUARIO_ID) return true;
			if (this.CONCILIADO_USUARIO_NOMBRE != original.CONCILIADO_USUARIO_NOMBRE) return true;
			if (this.IsCONCILIADO_FECHANull != original.IsCONCILIADO_FECHANull) return true;
			if (!this.IsCONCILIADO_FECHANull && !original.IsCONCILIADO_FECHANull)
				if (this.CONCILIADO_FECHA != original.CONCILIADO_FECHA) return true;
			if (this.IsDESCONCILIADO_USUARIO_IDNull != original.IsDESCONCILIADO_USUARIO_IDNull) return true;
			if (!this.IsDESCONCILIADO_USUARIO_IDNull && !original.IsDESCONCILIADO_USUARIO_IDNull)
				if (this.DESCONCILIADO_USUARIO_ID != original.DESCONCILIADO_USUARIO_ID) return true;
			if (this.DESCONCILIADO_USUARIO_NOMBRE != original.DESCONCILIADO_USUARIO_NOMBRE) return true;
			if (this.IsDESCONCILIADO_FECHANull != original.IsDESCONCILIADO_FECHANull) return true;
			if (!this.IsDESCONCILIADO_FECHANull && !original.IsDESCONCILIADO_FECHANull)
				if (this.DESCONCILIADO_FECHA != original.DESCONCILIADO_FECHA) return true;
			if (this.IsCTACTE_CHEQUE_GIRADO_IDNull != original.IsCTACTE_CHEQUE_GIRADO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_GIRADO_IDNull && !original.IsCTACTE_CHEQUE_GIRADO_IDNull)
				if (this.CTACTE_CHEQUE_GIRADO_ID != original.CTACTE_CHEQUE_GIRADO_ID) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get { return _ctacte_bancaria_id; }
			set { _ctacte_bancaria_id = value; }
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
		/// Gets or sets the <c>CASO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_NRO_COMPROBANTE
		{
			get { return _caso_nro_comprobante; }
			set { _caso_nro_comprobante = value; }
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
		/// Gets or sets the <c>DEPOSITO_BANCARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_BANCARIO_ID</c> column value.</value>
		public decimal DEPOSITO_BANCARIO_ID
		{
			get
			{
				if(IsDEPOSITO_BANCARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_bancario_id;
			}
			set
			{
				_deposito_bancario_idNull = false;
				_deposito_bancario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_BANCARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_BANCARIO_IDNull
		{
			get { return _deposito_bancario_idNull; }
			set { _deposito_bancario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</value>
		public decimal TRANSFERENCIA_BANCARIA_ID
		{
			get
			{
				if(IsTRANSFERENCIA_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transferencia_bancaria_id;
			}
			set
			{
				_transferencia_bancaria_idNull = false;
				_transferencia_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSFERENCIA_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSFERENCIA_BANCARIA_IDNull
		{
			get { return _transferencia_bancaria_idNull; }
			set { _transferencia_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AJUSTE_BANCARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AJUSTE_BANCARIO_ID</c> column value.</value>
		public decimal AJUSTE_BANCARIO_ID
		{
			get
			{
				if(IsAJUSTE_BANCARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ajuste_bancario_id;
			}
			set
			{
				_ajuste_bancario_idNull = false;
				_ajuste_bancario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AJUSTE_BANCARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAJUSTE_BANCARIO_IDNull
		{
			get { return _ajuste_bancario_idNull; }
			set { _ajuste_bancario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_ID
		{
			get
			{
				if(IsDESCUENTO_DOCUMENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_documento_id;
			}
			set
			{
				_descuento_documento_idNull = false;
				_descuento_documento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_DOCUMENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_DOCUMENTO_IDNull
		{
			get { return _descuento_documento_idNull; }
			set { _descuento_documento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUSTODIA_VALORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUSTODIA_VALORES_ID</c> column value.</value>
		public decimal CUSTODIA_VALORES_ID
		{
			get
			{
				if(IsCUSTODIA_VALORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _custodia_valores_id;
			}
			set
			{
				_custodia_valores_idNull = false;
				_custodia_valores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUSTODIA_VALORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUSTODIA_VALORES_IDNull
		{
			get { return _custodia_valores_idNull; }
			set { _custodia_valores_idNull = value; }
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
		/// Gets or sets the <c>FECHA_INSERCION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INSERCION</c> column value.</value>
		public System.DateTime FECHA_INSERCION
		{
			get { return _fecha_insercion; }
			set { _fecha_insercion = value; }
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
		/// Gets or sets the <c>CONCILIADO</c> column value.
		/// </summary>
		/// <value>The <c>CONCILIADO</c> column value.</value>
		public string CONCILIADO
		{
			get { return _conciliado; }
			set { _conciliado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCILIADO_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONCILIADO_USUARIO_ID</c> column value.</value>
		public decimal CONCILIADO_USUARIO_ID
		{
			get
			{
				if(IsCONCILIADO_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conciliado_usuario_id;
			}
			set
			{
				_conciliado_usuario_idNull = false;
				_conciliado_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONCILIADO_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONCILIADO_USUARIO_IDNull
		{
			get { return _conciliado_usuario_idNull; }
			set { _conciliado_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCILIADO_USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONCILIADO_USUARIO_NOMBRE</c> column value.</value>
		public string CONCILIADO_USUARIO_NOMBRE
		{
			get { return _conciliado_usuario_nombre; }
			set { _conciliado_usuario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCILIADO_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONCILIADO_FECHA</c> column value.</value>
		public System.DateTime CONCILIADO_FECHA
		{
			get
			{
				if(IsCONCILIADO_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conciliado_fecha;
			}
			set
			{
				_conciliado_fechaNull = false;
				_conciliado_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONCILIADO_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONCILIADO_FECHANull
		{
			get { return _conciliado_fechaNull; }
			set { _conciliado_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCONCILIADO_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCONCILIADO_USUARIO_ID</c> column value.</value>
		public decimal DESCONCILIADO_USUARIO_ID
		{
			get
			{
				if(IsDESCONCILIADO_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _desconciliado_usuario_id;
			}
			set
			{
				_desconciliado_usuario_idNull = false;
				_desconciliado_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCONCILIADO_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCONCILIADO_USUARIO_IDNull
		{
			get { return _desconciliado_usuario_idNull; }
			set { _desconciliado_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCONCILIADO_USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCONCILIADO_USUARIO_NOMBRE</c> column value.</value>
		public string DESCONCILIADO_USUARIO_NOMBRE
		{
			get { return _desconciliado_usuario_nombre; }
			set { _desconciliado_usuario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCONCILIADO_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCONCILIADO_FECHA</c> column value.</value>
		public System.DateTime DESCONCILIADO_FECHA
		{
			get
			{
				if(IsDESCONCILIADO_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _desconciliado_fecha;
			}
			set
			{
				_desconciliado_fechaNull = false;
				_desconciliado_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCONCILIADO_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCONCILIADO_FECHANull
		{
			get { return _desconciliado_fechaNull; }
			set { _desconciliado_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_GIRADO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_GIRADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_girado_id;
			}
			set
			{
				_ctacte_cheque_girado_idNull = false;
				_ctacte_cheque_girado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_GIRADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_GIRADO_IDNull
		{
			get { return _ctacte_cheque_girado_idNull; }
			set { _ctacte_cheque_girado_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(CTACTE_BANCARIA_ID);
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@DEPOSITO_BANCARIO_ID=");
			dynStr.Append(IsDEPOSITO_BANCARIO_IDNull ? (object)"<NULL>" : DEPOSITO_BANCARIO_ID);
			dynStr.Append("@CBA@TRANSFERENCIA_BANCARIA_ID=");
			dynStr.Append(IsTRANSFERENCIA_BANCARIA_IDNull ? (object)"<NULL>" : TRANSFERENCIA_BANCARIA_ID);
			dynStr.Append("@CBA@AJUSTE_BANCARIO_ID=");
			dynStr.Append(IsAJUSTE_BANCARIO_IDNull ? (object)"<NULL>" : AJUSTE_BANCARIO_ID);
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_ID=");
			dynStr.Append(IsDESCUENTO_DOCUMENTO_IDNull ? (object)"<NULL>" : DESCUENTO_DOCUMENTO_ID);
			dynStr.Append("@CBA@CUSTODIA_VALORES_ID=");
			dynStr.Append(IsCUSTODIA_VALORES_IDNull ? (object)"<NULL>" : CUSTODIA_VALORES_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@MOVIMIENTO_VARIO_TESORERIA_ID=");
			dynStr.Append(IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? (object)"<NULL>" : MOVIMIENTO_VARIO_TESORERIA_ID);
			dynStr.Append("@CBA@FECHA_INSERCION=");
			dynStr.Append(FECHA_INSERCION);
			dynStr.Append("@CBA@EGRESO_VARIO_CAJA_ID=");
			dynStr.Append(IsEGRESO_VARIO_CAJA_IDNull ? (object)"<NULL>" : EGRESO_VARIO_CAJA_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@CONCILIADO=");
			dynStr.Append(CONCILIADO);
			dynStr.Append("@CBA@CONCILIADO_USUARIO_ID=");
			dynStr.Append(IsCONCILIADO_USUARIO_IDNull ? (object)"<NULL>" : CONCILIADO_USUARIO_ID);
			dynStr.Append("@CBA@CONCILIADO_USUARIO_NOMBRE=");
			dynStr.Append(CONCILIADO_USUARIO_NOMBRE);
			dynStr.Append("@CBA@CONCILIADO_FECHA=");
			dynStr.Append(IsCONCILIADO_FECHANull ? (object)"<NULL>" : CONCILIADO_FECHA);
			dynStr.Append("@CBA@DESCONCILIADO_USUARIO_ID=");
			dynStr.Append(IsDESCONCILIADO_USUARIO_IDNull ? (object)"<NULL>" : DESCONCILIADO_USUARIO_ID);
			dynStr.Append("@CBA@DESCONCILIADO_USUARIO_NOMBRE=");
			dynStr.Append(DESCONCILIADO_USUARIO_NOMBRE);
			dynStr.Append("@CBA@DESCONCILIADO_FECHA=");
			dynStr.Append(IsDESCONCILIADO_FECHANull ? (object)"<NULL>" : DESCONCILIADO_FECHA);
			dynStr.Append("@CBA@CTACTE_CHEQUE_GIRADO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_GIRADO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_GIRADO_ID);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_BANCARIAS_MOV_INFO_COMPRow_Base class
} // End of namespace
