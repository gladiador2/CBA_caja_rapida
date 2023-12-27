// <fileinfo name="NOTAS_CREDITO_PERSONA_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="NOTAS_CREDITO_PERSONA_INF_COMPRow"/> that 
	/// represents a record in the <c>NOTAS_CREDITO_PERSONA_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOTAS_CREDITO_PERSONA_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTAS_CREDITO_PERSONA_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private string _caso_estado;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito_nombre;
		private decimal _persona_id;
		private string _persona_nombre;
		private System.DateTime _fecha;
		private decimal _funcionario_cobrador_id;
		private string _funcionario_nombre;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _autonumeracion_timbrado;
		private string _autonumeracion_codigo;
		private string _nro_comprobante;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private string _moneda_cadena_decimales;
		private decimal _cotizacion_moneda;
		private decimal _monto_total;
		private decimal _saldo_por_aplicar;
		private string _observacion;
		private decimal _nro_comprobante_secuencia;
		private bool _nro_comprobante_secuenciaNull = true;
		private decimal _total_impuesto;
		private bool _total_impuestoNull = true;
		private decimal _tipo_nota_credito_id;
		private bool _tipo_nota_credito_idNull = true;
		private string _tipo_nc_nombre;
		private string _tipo_nc_prefijo;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _tipo_cliente_id;
		private bool _tipo_cliente_idNull = true;
		private string _tipo_clientes_nombre;
		private string _caso_usuario_creacion_nombre;
		private string _caso_ultimo_usuario_nombre;
		private System.DateTime _caso_fecha_creacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTAS_CREDITO_PERSONA_INF_COMPRow_Base"/> class.
		/// </summary>
		public NOTAS_CREDITO_PERSONA_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOTAS_CREDITO_PERSONA_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.CASO_ESTADO != original.CASO_ESTADO) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_NOMBRE != original.DEPOSITO_NOMBRE) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.FUNCIONARIO_COBRADOR_ID != original.FUNCIONARIO_COBRADOR_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION_TIMBRADO != original.AUTONUMERACION_TIMBRADO) return true;
			if (this.AUTONUMERACION_CODIGO != original.AUTONUMERACION_CODIGO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.SALDO_POR_APLICAR != original.SALDO_POR_APLICAR) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsNRO_COMPROBANTE_SECUENCIANull != original.IsNRO_COMPROBANTE_SECUENCIANull) return true;
			if (!this.IsNRO_COMPROBANTE_SECUENCIANull && !original.IsNRO_COMPROBANTE_SECUENCIANull)
				if (this.NRO_COMPROBANTE_SECUENCIA != original.NRO_COMPROBANTE_SECUENCIA) return true;
			if (this.IsTOTAL_IMPUESTONull != original.IsTOTAL_IMPUESTONull) return true;
			if (!this.IsTOTAL_IMPUESTONull && !original.IsTOTAL_IMPUESTONull)
				if (this.TOTAL_IMPUESTO != original.TOTAL_IMPUESTO) return true;
			if (this.IsTIPO_NOTA_CREDITO_IDNull != original.IsTIPO_NOTA_CREDITO_IDNull) return true;
			if (!this.IsTIPO_NOTA_CREDITO_IDNull && !original.IsTIPO_NOTA_CREDITO_IDNull)
				if (this.TIPO_NOTA_CREDITO_ID != original.TIPO_NOTA_CREDITO_ID) return true;
			if (this.TIPO_NC_NOMBRE != original.TIPO_NC_NOMBRE) return true;
			if (this.TIPO_NC_PREFIJO != original.TIPO_NC_PREFIJO) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.IsTIPO_CLIENTE_IDNull != original.IsTIPO_CLIENTE_IDNull) return true;
			if (!this.IsTIPO_CLIENTE_IDNull && !original.IsTIPO_CLIENTE_IDNull)
				if (this.TIPO_CLIENTE_ID != original.TIPO_CLIENTE_ID) return true;
			if (this.TIPO_CLIENTES_NOMBRE != original.TIPO_CLIENTES_NOMBRE) return true;
			if (this.CASO_USUARIO_CREACION_NOMBRE != original.CASO_USUARIO_CREACION_NOMBRE) return true;
			if (this.CASO_ULTIMO_USUARIO_NOMBRE != original.CASO_ULTIMO_USUARIO_NOMBRE) return true;
			if (this.CASO_FECHA_CREACION != original.CASO_FECHA_CREACION) return true;
			
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
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO</c> column value.</value>
		public string CASO_ESTADO
		{
			get { return _caso_estado; }
			set { _caso_estado = value; }
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_NOMBRE</c> column value.</value>
		public string DEPOSITO_NOMBRE
		{
			get { return _deposito_nombre; }
			set { _deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_COBRADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</value>
		public decimal FUNCIONARIO_COBRADOR_ID
		{
			get { return _funcionario_cobrador_id; }
			set { _funcionario_cobrador_id = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_TIMBRADO</c> column value.</value>
		public string AUTONUMERACION_TIMBRADO
		{
			get { return _autonumeracion_timbrado; }
			set { _autonumeracion_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_CODIGO</c> column value.</value>
		public string AUTONUMERACION_CODIGO
		{
			get { return _autonumeracion_codigo; }
			set { _autonumeracion_codigo = value; }
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
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_CADENA_DECIMALES
		{
			get { return _moneda_cadena_decimales; }
			set { _moneda_cadena_decimales = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_POR_APLICAR</c> column value.
		/// </summary>
		/// <value>The <c>SALDO_POR_APLICAR</c> column value.</value>
		public decimal SALDO_POR_APLICAR
		{
			get { return _saldo_por_aplicar; }
			set { _saldo_por_aplicar = value; }
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
		/// Gets or sets the <c>NRO_COMPROBANTE_SECUENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE_SECUENCIA</c> column value.</value>
		public decimal NRO_COMPROBANTE_SECUENCIA
		{
			get
			{
				if(IsNRO_COMPROBANTE_SECUENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_comprobante_secuencia;
			}
			set
			{
				_nro_comprobante_secuenciaNull = false;
				_nro_comprobante_secuencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_COMPROBANTE_SECUENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_COMPROBANTE_SECUENCIANull
		{
			get { return _nro_comprobante_secuenciaNull; }
			set { _nro_comprobante_secuenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO</c> column value.</value>
		public decimal TOTAL_IMPUESTO
		{
			get
			{
				if(IsTOTAL_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto;
			}
			set
			{
				_total_impuestoNull = false;
				_total_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTONull
		{
			get { return _total_impuestoNull; }
			set { _total_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NOTA_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NOTA_CREDITO_ID</c> column value.</value>
		public decimal TIPO_NOTA_CREDITO_ID
		{
			get
			{
				if(IsTIPO_NOTA_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_nota_credito_id;
			}
			set
			{
				_tipo_nota_credito_idNull = false;
				_tipo_nota_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_NOTA_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_NOTA_CREDITO_IDNull
		{
			get { return _tipo_nota_credito_idNull; }
			set { _tipo_nota_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NC_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NC_NOMBRE</c> column value.</value>
		public string TIPO_NC_NOMBRE
		{
			get { return _tipo_nc_nombre; }
			set { _tipo_nc_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_NC_PREFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_NC_PREFIJO</c> column value.</value>
		public string TIPO_NC_PREFIJO
		{
			get { return _tipo_nc_prefijo; }
			set { _tipo_nc_prefijo = value; }
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
		/// Gets or sets the <c>TIPO_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CLIENTE_ID</c> column value.</value>
		public decimal TIPO_CLIENTE_ID
		{
			get
			{
				if(IsTIPO_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_cliente_id;
			}
			set
			{
				_tipo_cliente_idNull = false;
				_tipo_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CLIENTE_IDNull
		{
			get { return _tipo_cliente_idNull; }
			set { _tipo_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CLIENTES_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CLIENTES_NOMBRE</c> column value.</value>
		public string TIPO_CLIENTES_NOMBRE
		{
			get { return _tipo_clientes_nombre; }
			set { _tipo_clientes_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_USUARIO_CREACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_USUARIO_CREACION_NOMBRE</c> column value.</value>
		public string CASO_USUARIO_CREACION_NOMBRE
		{
			get { return _caso_usuario_creacion_nombre; }
			set { _caso_usuario_creacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ULTIMO_USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ULTIMO_USUARIO_NOMBRE</c> column value.</value>
		public string CASO_ULTIMO_USUARIO_NOMBRE
		{
			get { return _caso_ultimo_usuario_nombre; }
			set { _caso_ultimo_usuario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>CASO_FECHA_CREACION</c> column value.</value>
		public System.DateTime CASO_FECHA_CREACION
		{
			get { return _caso_fecha_creacion; }
			set { _caso_fecha_creacion = value; }
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
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@CASO_ESTADO=");
			dynStr.Append(CASO_ESTADO);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_NOMBRE=");
			dynStr.Append(DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FUNCIONARIO_COBRADOR_ID=");
			dynStr.Append(FUNCIONARIO_COBRADOR_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION_TIMBRADO=");
			dynStr.Append(AUTONUMERACION_TIMBRADO);
			dynStr.Append("@CBA@AUTONUMERACION_CODIGO=");
			dynStr.Append(AUTONUMERACION_CODIGO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@SALDO_POR_APLICAR=");
			dynStr.Append(SALDO_POR_APLICAR);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE_SECUENCIA=");
			dynStr.Append(IsNRO_COMPROBANTE_SECUENCIANull ? (object)"<NULL>" : NRO_COMPROBANTE_SECUENCIA);
			dynStr.Append("@CBA@TOTAL_IMPUESTO=");
			dynStr.Append(IsTOTAL_IMPUESTONull ? (object)"<NULL>" : TOTAL_IMPUESTO);
			dynStr.Append("@CBA@TIPO_NOTA_CREDITO_ID=");
			dynStr.Append(IsTIPO_NOTA_CREDITO_IDNull ? (object)"<NULL>" : TIPO_NOTA_CREDITO_ID);
			dynStr.Append("@CBA@TIPO_NC_NOMBRE=");
			dynStr.Append(TIPO_NC_NOMBRE);
			dynStr.Append("@CBA@TIPO_NC_PREFIJO=");
			dynStr.Append(TIPO_NC_PREFIJO);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@TIPO_CLIENTE_ID=");
			dynStr.Append(IsTIPO_CLIENTE_IDNull ? (object)"<NULL>" : TIPO_CLIENTE_ID);
			dynStr.Append("@CBA@TIPO_CLIENTES_NOMBRE=");
			dynStr.Append(TIPO_CLIENTES_NOMBRE);
			dynStr.Append("@CBA@CASO_USUARIO_CREACION_NOMBRE=");
			dynStr.Append(CASO_USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@CASO_ULTIMO_USUARIO_NOMBRE=");
			dynStr.Append(CASO_ULTIMO_USUARIO_NOMBRE);
			dynStr.Append("@CBA@CASO_FECHA_CREACION=");
			dynStr.Append(CASO_FECHA_CREACION);
			return dynStr.ToString();
		}
	} // End of NOTAS_CREDITO_PERSONA_INF_COMPRow_Base class
} // End of namespace
