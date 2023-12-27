// <fileinfo name="CTACTE_RECIBOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTACTE_RECIBOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTACTE_RECIBOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_RECIBOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RECIBOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _persona_id;
		private string _persona_codigo;
		private string _persona_documento;
		private string _persona_nombre_completo;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _autonumeracion_codigo;
		private decimal _autonumeracion_funcioanrio_id;
		private bool _autonumeracion_funcioanrio_idNull = true;
		private string _prefijo;
		private string _sufijo;
		private decimal _autonumeracion_sucursal_id;
		private bool _autonumeracion_sucursal_idNull = true;
		private string _autonumeracion_sucursal_abre;
		private string _autonumeracion_sucursal;
		private string _autonumeracion_func_codigo;
		private string _autonumeracion_func_nombre;
		private string _nro_comprobante;
		private decimal _nro_comprobante_secuencia;
		private bool _nro_comprobante_secuenciaNull = true;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cant_decimales;
		private string _moneda_formato_decimales;
		private decimal _monto;
		private System.DateTime _fecha;
		private System.DateTime _fecha_creacion;
		private string _estado;
		private string _impreso;
		private decimal _tipo_cliente_id;
		private bool _tipo_cliente_idNull = true;
		private string _tipo_clientes_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RECIBOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTACTE_RECIBOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_RECIBOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_DOCUMENTO != original.PERSONA_DOCUMENTO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.AUTONUMERACION_CODIGO != original.AUTONUMERACION_CODIGO) return true;
			if (this.IsAUTONUMERACION_FUNCIOANRIO_IDNull != original.IsAUTONUMERACION_FUNCIOANRIO_IDNull) return true;
			if (!this.IsAUTONUMERACION_FUNCIOANRIO_IDNull && !original.IsAUTONUMERACION_FUNCIOANRIO_IDNull)
				if (this.AUTONUMERACION_FUNCIOANRIO_ID != original.AUTONUMERACION_FUNCIOANRIO_ID) return true;
			if (this.PREFIJO != original.PREFIJO) return true;
			if (this.SUFIJO != original.SUFIJO) return true;
			if (this.IsAUTONUMERACION_SUCURSAL_IDNull != original.IsAUTONUMERACION_SUCURSAL_IDNull) return true;
			if (!this.IsAUTONUMERACION_SUCURSAL_IDNull && !original.IsAUTONUMERACION_SUCURSAL_IDNull)
				if (this.AUTONUMERACION_SUCURSAL_ID != original.AUTONUMERACION_SUCURSAL_ID) return true;
			if (this.AUTONUMERACION_SUCURSAL_ABRE != original.AUTONUMERACION_SUCURSAL_ABRE) return true;
			if (this.AUTONUMERACION_SUCURSAL != original.AUTONUMERACION_SUCURSAL) return true;
			if (this.AUTONUMERACION_FUNC_CODIGO != original.AUTONUMERACION_FUNC_CODIGO) return true;
			if (this.AUTONUMERACION_FUNC_NOMBRE != original.AUTONUMERACION_FUNC_NOMBRE) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsNRO_COMPROBANTE_SECUENCIANull != original.IsNRO_COMPROBANTE_SECUENCIANull) return true;
			if (!this.IsNRO_COMPROBANTE_SECUENCIANull && !original.IsNRO_COMPROBANTE_SECUENCIANull)
				if (this.NRO_COMPROBANTE_SECUENCIA != original.NRO_COMPROBANTE_SECUENCIA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANT_DECIMALES != original.MONEDA_CANT_DECIMALES) return true;
			if (this.MONEDA_FORMATO_DECIMALES != original.MONEDA_FORMATO_DECIMALES) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			if (this.IsTIPO_CLIENTE_IDNull != original.IsTIPO_CLIENTE_IDNull) return true;
			if (!this.IsTIPO_CLIENTE_IDNull && !original.IsTIPO_CLIENTE_IDNull)
				if (this.TIPO_CLIENTE_ID != original.TIPO_CLIENTE_ID) return true;
			if (this.TIPO_CLIENTES_NOMBRE != original.TIPO_CLIENTES_NOMBRE) return true;
			
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DOCUMENTO</c> column value.</value>
		public string PERSONA_DOCUMENTO
		{
			get { return _persona_documento; }
			set { _persona_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_FUNCIOANRIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_FUNCIOANRIO_ID</c> column value.</value>
		public decimal AUTONUMERACION_FUNCIOANRIO_ID
		{
			get
			{
				if(IsAUTONUMERACION_FUNCIOANRIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_funcioanrio_id;
			}
			set
			{
				_autonumeracion_funcioanrio_idNull = false;
				_autonumeracion_funcioanrio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_FUNCIOANRIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_FUNCIOANRIO_IDNull
		{
			get { return _autonumeracion_funcioanrio_idNull; }
			set { _autonumeracion_funcioanrio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREFIJO</c> column value.</value>
		public string PREFIJO
		{
			get { return _prefijo; }
			set { _prefijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUFIJO</c> column value.</value>
		public string SUFIJO
		{
			get { return _sufijo; }
			set { _sufijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_SUCURSAL_ID</c> column value.</value>
		public decimal AUTONUMERACION_SUCURSAL_ID
		{
			get
			{
				if(IsAUTONUMERACION_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_sucursal_id;
			}
			set
			{
				_autonumeracion_sucursal_idNull = false;
				_autonumeracion_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_SUCURSAL_IDNull
		{
			get { return _autonumeracion_sucursal_idNull; }
			set { _autonumeracion_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_SUCURSAL_ABRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_SUCURSAL_ABRE</c> column value.</value>
		public string AUTONUMERACION_SUCURSAL_ABRE
		{
			get { return _autonumeracion_sucursal_abre; }
			set { _autonumeracion_sucursal_abre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_SUCURSAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_SUCURSAL</c> column value.</value>
		public string AUTONUMERACION_SUCURSAL
		{
			get { return _autonumeracion_sucursal; }
			set { _autonumeracion_sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_FUNC_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_FUNC_CODIGO</c> column value.</value>
		public string AUTONUMERACION_FUNC_CODIGO
		{
			get { return _autonumeracion_func_codigo; }
			set { _autonumeracion_func_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_FUNC_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_FUNC_NOMBRE</c> column value.</value>
		public string AUTONUMERACION_FUNC_NOMBRE
		{
			get { return _autonumeracion_func_nombre; }
			set { _autonumeracion_func_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
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
		/// Gets or sets the <c>MONEDA_CANT_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANT_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANT_DECIMALES
		{
			get { return _moneda_cant_decimales; }
			set { _moneda_cant_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_FORMATO_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_FORMATO_DECIMALES</c> column value.</value>
		public string MONEDA_FORMATO_DECIMALES
		{
			get { return _moneda_formato_decimales; }
			set { _moneda_formato_decimales = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
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
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_DOCUMENTO=");
			dynStr.Append(PERSONA_DOCUMENTO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@AUTONUMERACION_CODIGO=");
			dynStr.Append(AUTONUMERACION_CODIGO);
			dynStr.Append("@CBA@AUTONUMERACION_FUNCIOANRIO_ID=");
			dynStr.Append(IsAUTONUMERACION_FUNCIOANRIO_IDNull ? (object)"<NULL>" : AUTONUMERACION_FUNCIOANRIO_ID);
			dynStr.Append("@CBA@PREFIJO=");
			dynStr.Append(PREFIJO);
			dynStr.Append("@CBA@SUFIJO=");
			dynStr.Append(SUFIJO);
			dynStr.Append("@CBA@AUTONUMERACION_SUCURSAL_ID=");
			dynStr.Append(IsAUTONUMERACION_SUCURSAL_IDNull ? (object)"<NULL>" : AUTONUMERACION_SUCURSAL_ID);
			dynStr.Append("@CBA@AUTONUMERACION_SUCURSAL_ABRE=");
			dynStr.Append(AUTONUMERACION_SUCURSAL_ABRE);
			dynStr.Append("@CBA@AUTONUMERACION_SUCURSAL=");
			dynStr.Append(AUTONUMERACION_SUCURSAL);
			dynStr.Append("@CBA@AUTONUMERACION_FUNC_CODIGO=");
			dynStr.Append(AUTONUMERACION_FUNC_CODIGO);
			dynStr.Append("@CBA@AUTONUMERACION_FUNC_NOMBRE=");
			dynStr.Append(AUTONUMERACION_FUNC_NOMBRE);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@NRO_COMPROBANTE_SECUENCIA=");
			dynStr.Append(IsNRO_COMPROBANTE_SECUENCIANull ? (object)"<NULL>" : NRO_COMPROBANTE_SECUENCIA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANT_DECIMALES=");
			dynStr.Append(MONEDA_CANT_DECIMALES);
			dynStr.Append("@CBA@MONEDA_FORMATO_DECIMALES=");
			dynStr.Append(MONEDA_FORMATO_DECIMALES);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			dynStr.Append("@CBA@TIPO_CLIENTE_ID=");
			dynStr.Append(IsTIPO_CLIENTE_IDNull ? (object)"<NULL>" : TIPO_CLIENTE_ID);
			dynStr.Append("@CBA@TIPO_CLIENTES_NOMBRE=");
			dynStr.Append(TIPO_CLIENTES_NOMBRE);
			return dynStr.ToString();
		}
	} // End of CTACTE_RECIBOS_INFO_COMPLETARow_Base class
} // End of namespace
