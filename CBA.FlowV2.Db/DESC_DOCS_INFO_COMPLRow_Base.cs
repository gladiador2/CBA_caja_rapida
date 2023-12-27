// <fileinfo name="DESC_DOCS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="DESC_DOCS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>DESC_DOCS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESC_DOCS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESC_DOCS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _ctacte_banco_id;
		private bool _ctacte_banco_idNull = true;
		private string _ctacte_banco_nombre;
		private string _ctacte_banco_abreviatura;
		private decimal _ctacte_bancaria_id;
		private bool _ctacte_bancaria_idNull = true;
		private string _ctacte_bancaria_nro_cuenta;
		private decimal _ctacte_caja_tesoreria_id;
		private string _ctacte_caja_tesoreria_nombre;
		private string _ctacte_caja_tesoreria_abrev;
		private System.DateTime _fecha;
		private string _observacion;
		private string _nro_comprobante;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nombre_institucion;
		private decimal _moneda_id;
		private decimal _moneda_cotizacion;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _monto_total;
		private bool _monto_totalNull = true;
		private decimal _monto_dolarizado;
		private bool _monto_dolarizadoNull = true;
		private decimal _monto_comision_dolarizado;
		private bool _monto_comision_dolarizadoNull = true;
		private decimal _monto_efectivo_dolarizado;
		private bool _monto_efectivo_dolarizadoNull = true;
		private decimal _monto_impuesto_dolarizado;
		private bool _monto_impuesto_dolarizadoNull = true;
		private decimal _orden_pago_respalda_caso_id;
		private bool _orden_pago_respalda_caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESC_DOCS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public DESC_DOCS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESC_DOCS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.IsCTACTE_BANCO_IDNull != original.IsCTACTE_BANCO_IDNull) return true;
			if (!this.IsCTACTE_BANCO_IDNull && !original.IsCTACTE_BANCO_IDNull)
				if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.CTACTE_BANCO_NOMBRE != original.CTACTE_BANCO_NOMBRE) return true;
			if (this.CTACTE_BANCO_ABREVIATURA != original.CTACTE_BANCO_ABREVIATURA) return true;
			if (this.IsCTACTE_BANCARIA_IDNull != original.IsCTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_IDNull && !original.IsCTACTE_BANCARIA_IDNull)
				if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.CTACTE_BANCARIA_NRO_CUENTA != original.CTACTE_BANCARIA_NRO_CUENTA) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_NOMBRE != original.CTACTE_CAJA_TESORERIA_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESORERIA_ABREV != original.CTACTE_CAJA_TESORERIA_ABREV) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NOMBRE_INSTITUCION != original.NOMBRE_INSTITUCION) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_COTIZACION != original.MONEDA_COTIZACION) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsMONTO_TOTALNull != original.IsMONTO_TOTALNull) return true;
			if (!this.IsMONTO_TOTALNull && !original.IsMONTO_TOTALNull)
				if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.IsMONTO_DOLARIZADONull != original.IsMONTO_DOLARIZADONull) return true;
			if (!this.IsMONTO_DOLARIZADONull && !original.IsMONTO_DOLARIZADONull)
				if (this.MONTO_DOLARIZADO != original.MONTO_DOLARIZADO) return true;
			if (this.IsMONTO_COMISION_DOLARIZADONull != original.IsMONTO_COMISION_DOLARIZADONull) return true;
			if (!this.IsMONTO_COMISION_DOLARIZADONull && !original.IsMONTO_COMISION_DOLARIZADONull)
				if (this.MONTO_COMISION_DOLARIZADO != original.MONTO_COMISION_DOLARIZADO) return true;
			if (this.IsMONTO_EFECTIVO_DOLARIZADONull != original.IsMONTO_EFECTIVO_DOLARIZADONull) return true;
			if (!this.IsMONTO_EFECTIVO_DOLARIZADONull && !original.IsMONTO_EFECTIVO_DOLARIZADONull)
				if (this.MONTO_EFECTIVO_DOLARIZADO != original.MONTO_EFECTIVO_DOLARIZADO) return true;
			if (this.IsMONTO_IMPUESTO_DOLARIZADONull != original.IsMONTO_IMPUESTO_DOLARIZADONull) return true;
			if (!this.IsMONTO_IMPUESTO_DOLARIZADONull && !original.IsMONTO_IMPUESTO_DOLARIZADONull)
				if (this.MONTO_IMPUESTO_DOLARIZADO != original.MONTO_IMPUESTO_DOLARIZADO) return true;
			if (this.IsORDEN_PAGO_RESPALDA_CASO_IDNull != original.IsORDEN_PAGO_RESPALDA_CASO_IDNull) return true;
			if (!this.IsORDEN_PAGO_RESPALDA_CASO_IDNull && !original.IsORDEN_PAGO_RESPALDA_CASO_IDNull)
				if (this.ORDEN_PAGO_RESPALDA_CASO_ID != original.ORDEN_PAGO_RESPALDA_CASO_ID) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get
			{
				if(IsCTACTE_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banco_id;
			}
			set
			{
				_ctacte_banco_idNull = false;
				_ctacte_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCO_IDNull
		{
			get { return _ctacte_banco_idNull; }
			set { _ctacte_banco_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_NOMBRE</c> column value.</value>
		public string CTACTE_BANCO_NOMBRE
		{
			get { return _ctacte_banco_nombre; }
			set { _ctacte_banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ABREVIATURA</c> column value.</value>
		public string CTACTE_BANCO_ABREVIATURA
		{
			get { return _ctacte_banco_abreviatura; }
			set { _ctacte_banco_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_id;
			}
			set
			{
				_ctacte_bancaria_idNull = false;
				_ctacte_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_IDNull
		{
			get { return _ctacte_bancaria_idNull; }
			set { _ctacte_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_NRO_CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_NRO_CUENTA</c> column value.</value>
		public string CTACTE_BANCARIA_NRO_CUENTA
		{
			get { return _ctacte_bancaria_nro_cuenta; }
			set { _ctacte_bancaria_nro_cuenta = value; }
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
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_NOMBRE
		{
			get { return _ctacte_caja_tesoreria_nombre; }
			set { _ctacte_caja_tesoreria_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_ABREV
		{
			get { return _ctacte_caja_tesoreria_abrev; }
			set { _ctacte_caja_tesoreria_abrev = value; }
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
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_INSTITUCION</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_INSTITUCION</c> column value.</value>
		public string NOMBRE_INSTITUCION
		{
			get { return _nombre_institucion; }
			set { _nombre_institucion = value; }
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
		/// Gets or sets the <c>MONEDA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_COTIZACION</c> column value.</value>
		public decimal MONEDA_COTIZACION
		{
			get { return _moneda_cotizacion; }
			set { _moneda_cotizacion = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get
			{
				if(IsMONTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total;
			}
			set
			{
				_monto_totalNull = false;
				_monto_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTALNull
		{
			get { return _monto_totalNull; }
			set { _monto_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DOLARIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DOLARIZADO</c> column value.</value>
		public decimal MONTO_DOLARIZADO
		{
			get
			{
				if(IsMONTO_DOLARIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_dolarizado;
			}
			set
			{
				_monto_dolarizadoNull = false;
				_monto_dolarizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DOLARIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DOLARIZADONull
		{
			get { return _monto_dolarizadoNull; }
			set { _monto_dolarizadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMISION_DOLARIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_COMISION_DOLARIZADO</c> column value.</value>
		public decimal MONTO_COMISION_DOLARIZADO
		{
			get
			{
				if(IsMONTO_COMISION_DOLARIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_comision_dolarizado;
			}
			set
			{
				_monto_comision_dolarizadoNull = false;
				_monto_comision_dolarizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_COMISION_DOLARIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_COMISION_DOLARIZADONull
		{
			get { return _monto_comision_dolarizadoNull; }
			set { _monto_comision_dolarizadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_EFECTIVO_DOLARIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_EFECTIVO_DOLARIZADO</c> column value.</value>
		public decimal MONTO_EFECTIVO_DOLARIZADO
		{
			get
			{
				if(IsMONTO_EFECTIVO_DOLARIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_efectivo_dolarizado;
			}
			set
			{
				_monto_efectivo_dolarizadoNull = false;
				_monto_efectivo_dolarizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_EFECTIVO_DOLARIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_EFECTIVO_DOLARIZADONull
		{
			get { return _monto_efectivo_dolarizadoNull; }
			set { _monto_efectivo_dolarizadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_IMPUESTO_DOLARIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_IMPUESTO_DOLARIZADO</c> column value.</value>
		public decimal MONTO_IMPUESTO_DOLARIZADO
		{
			get
			{
				if(IsMONTO_IMPUESTO_DOLARIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_impuesto_dolarizado;
			}
			set
			{
				_monto_impuesto_dolarizadoNull = false;
				_monto_impuesto_dolarizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_IMPUESTO_DOLARIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_IMPUESTO_DOLARIZADONull
		{
			get { return _monto_impuesto_dolarizadoNull; }
			set { _monto_impuesto_dolarizadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_RESPALDA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_RESPALDA_CASO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_RESPALDA_CASO_ID
		{
			get
			{
				if(IsORDEN_PAGO_RESPALDA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_respalda_caso_id;
			}
			set
			{
				_orden_pago_respalda_caso_idNull = false;
				_orden_pago_respalda_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_RESPALDA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_RESPALDA_CASO_IDNull
		{
			get { return _orden_pago_respalda_caso_idNull; }
			set { _orden_pago_respalda_caso_idNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(IsCTACTE_BANCO_IDNull ? (object)"<NULL>" : CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_NOMBRE=");
			dynStr.Append(CTACTE_BANCO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_BANCO_ABREVIATURA=");
			dynStr.Append(CTACTE_BANCO_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@CTACTE_BANCARIA_NRO_CUENTA=");
			dynStr.Append(CTACTE_BANCARIA_NRO_CUENTA);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ABREV=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ABREV);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NOMBRE_INSTITUCION=");
			dynStr.Append(NOMBRE_INSTITUCION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_COTIZACION=");
			dynStr.Append(MONEDA_COTIZACION);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(IsMONTO_TOTALNull ? (object)"<NULL>" : MONTO_TOTAL);
			dynStr.Append("@CBA@MONTO_DOLARIZADO=");
			dynStr.Append(IsMONTO_DOLARIZADONull ? (object)"<NULL>" : MONTO_DOLARIZADO);
			dynStr.Append("@CBA@MONTO_COMISION_DOLARIZADO=");
			dynStr.Append(IsMONTO_COMISION_DOLARIZADONull ? (object)"<NULL>" : MONTO_COMISION_DOLARIZADO);
			dynStr.Append("@CBA@MONTO_EFECTIVO_DOLARIZADO=");
			dynStr.Append(IsMONTO_EFECTIVO_DOLARIZADONull ? (object)"<NULL>" : MONTO_EFECTIVO_DOLARIZADO);
			dynStr.Append("@CBA@MONTO_IMPUESTO_DOLARIZADO=");
			dynStr.Append(IsMONTO_IMPUESTO_DOLARIZADONull ? (object)"<NULL>" : MONTO_IMPUESTO_DOLARIZADO);
			dynStr.Append("@CBA@ORDEN_PAGO_RESPALDA_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_RESPALDA_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_RESPALDA_CASO_ID);
			return dynStr.ToString();
		}
	} // End of DESC_DOCS_INFO_COMPLRow_Base class
} // End of namespace
