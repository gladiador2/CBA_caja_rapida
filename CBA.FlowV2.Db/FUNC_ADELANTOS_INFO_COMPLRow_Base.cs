// <fileinfo name="FUNC_ADELANTOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="FUNC_ADELANTOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>FUNC_ADELANTOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNC_ADELANTOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNC_ADELANTOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _caso_estado_id;
		private System.DateTime _caso_fecha;
		private decimal _caso_usuario_id;
		private bool _caso_usuario_idNull = true;
		private decimal _caso_sucursal_id;
		private string _caso_sucursal_nombre;
		private string _caso_sucursal_abreviatura;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _funcionario_codigo;
		private decimal _monto_solicitado;
		private decimal _monto_concedido;
		private bool _monto_concedidoNull = true;
		private decimal _cotizacion;
		private string _observacion;
		private string _nro_comprobante;
		private decimal _autonumeracion_id;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _caso_origen_id;
		private bool _caso_origen_idNull = true;
		private decimal _orden_pago_respalda_caso_id;
		private bool _orden_pago_respalda_caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNC_ADELANTOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public FUNC_ADELANTOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNC_ADELANTOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_FECHA != original.CASO_FECHA) return true;
			if (this.IsCASO_USUARIO_IDNull != original.IsCASO_USUARIO_IDNull) return true;
			if (!this.IsCASO_USUARIO_IDNull && !original.IsCASO_USUARIO_IDNull)
				if (this.CASO_USUARIO_ID != original.CASO_USUARIO_ID) return true;
			if (this.CASO_SUCURSAL_ID != original.CASO_SUCURSAL_ID) return true;
			if (this.CASO_SUCURSAL_NOMBRE != original.CASO_SUCURSAL_NOMBRE) return true;
			if (this.CASO_SUCURSAL_ABREVIATURA != original.CASO_SUCURSAL_ABREVIATURA) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.MONTO_SOLICITADO != original.MONTO_SOLICITADO) return true;
			if (this.IsMONTO_CONCEDIDONull != original.IsMONTO_CONCEDIDONull) return true;
			if (!this.IsMONTO_CONCEDIDONull && !original.IsMONTO_CONCEDIDONull)
				if (this.MONTO_CONCEDIDO != original.MONTO_CONCEDIDO) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsCASO_ORIGEN_IDNull != original.IsCASO_ORIGEN_IDNull) return true;
			if (!this.IsCASO_ORIGEN_IDNull && !original.IsCASO_ORIGEN_IDNull)
				if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
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
		/// Gets or sets the <c>CASO_FECHA</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FECHA</c> column value.</value>
		public System.DateTime CASO_FECHA
		{
			get { return _caso_fecha; }
			set { _caso_fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_USUARIO_ID</c> column value.</value>
		public decimal CASO_USUARIO_ID
		{
			get
			{
				if(IsCASO_USUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_usuario_id;
			}
			set
			{
				_caso_usuario_idNull = false;
				_caso_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_USUARIO_IDNull
		{
			get { return _caso_usuario_idNull; }
			set { _caso_usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_SUCURSAL_ID</c> column value.</value>
		public decimal CASO_SUCURSAL_ID
		{
			get { return _caso_sucursal_id; }
			set { _caso_sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CASO_SUCURSAL_NOMBRE</c> column value.</value>
		public string CASO_SUCURSAL_NOMBRE
		{
			get { return _caso_sucursal_nombre; }
			set { _caso_sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>CASO_SUCURSAL_ABREVIATURA</c> column value.</value>
		public string CASO_SUCURSAL_ABREVIATURA
		{
			get { return _caso_sucursal_abreviatura; }
			set { _caso_sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CODIGO</c> column value.</value>
		public string FUNCIONARIO_CODIGO
		{
			get { return _funcionario_codigo; }
			set { _funcionario_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_SOLICITADO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_SOLICITADO</c> column value.</value>
		public decimal MONTO_SOLICITADO
		{
			get { return _monto_solicitado; }
			set { _monto_solicitado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CONCEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CONCEDIDO</c> column value.</value>
		public decimal MONTO_CONCEDIDO
		{
			get
			{
				if(IsMONTO_CONCEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_concedido;
			}
			set
			{
				_monto_concedidoNull = false;
				_monto_concedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CONCEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CONCEDIDONull
		{
			get { return _monto_concedidoNull; }
			set { _monto_concedidoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get
			{
				if(IsCASO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_origen_id;
			}
			set
			{
				_caso_origen_idNull = false;
				_caso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGEN_IDNull
		{
			get { return _caso_origen_idNull; }
			set { _caso_origen_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CASO_FECHA=");
			dynStr.Append(CASO_FECHA);
			dynStr.Append("@CBA@CASO_USUARIO_ID=");
			dynStr.Append(IsCASO_USUARIO_IDNull ? (object)"<NULL>" : CASO_USUARIO_ID);
			dynStr.Append("@CBA@CASO_SUCURSAL_ID=");
			dynStr.Append(CASO_SUCURSAL_ID);
			dynStr.Append("@CBA@CASO_SUCURSAL_NOMBRE=");
			dynStr.Append(CASO_SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@CASO_SUCURSAL_ABREVIATURA=");
			dynStr.Append(CASO_SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@MONTO_SOLICITADO=");
			dynStr.Append(MONTO_SOLICITADO);
			dynStr.Append("@CBA@MONTO_CONCEDIDO=");
			dynStr.Append(IsMONTO_CONCEDIDONull ? (object)"<NULL>" : MONTO_CONCEDIDO);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(IsCASO_ORIGEN_IDNull ? (object)"<NULL>" : CASO_ORIGEN_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_RESPALDA_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_RESPALDA_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_RESPALDA_CASO_ID);
			return dynStr.ToString();
		}
	} // End of FUNC_ADELANTOS_INFO_COMPLRow_Base class
} // End of namespace
