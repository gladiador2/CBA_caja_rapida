// <fileinfo name="RENDICION_COBRADOR_RECIBOSRow_Base.cs">
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
	/// The base class for <see cref="RENDICION_COBRADOR_RECIBOSRow"/> that 
	/// represents a record in the <c>RENDICION_COBRADOR_RECIBOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RENDICION_COBRADOR_RECIBOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RENDICION_COBRADOR_RECIBOSRow_Base
	{
		private decimal _recibo_id;
		private decimal _persona_id;
		private string _nombre_completo;
		private string _nro_comprobante;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private string _estado_recibo_id;
		private string _estado_recibo;
		private string _moneda_simbolo;
		private string _moneda_nombre;
		private decimal _cantidades_decimales;
		private string _cadena_decimales;
		private decimal _monto;
		private decimal _nro_comprobante_secuencia;
		private bool _nro_comprobante_secuenciaNull = true;
		private decimal _autonumeracion_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private decimal _funcionario_id;
		private string _funcionario_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADOR_RECIBOSRow_Base"/> class.
		/// </summary>
		public RENDICION_COBRADOR_RECIBOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RENDICION_COBRADOR_RECIBOSRow_Base original)
		{
			if (this.RECIBO_ID != original.RECIBO_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.ESTADO_RECIBO_ID != original.ESTADO_RECIBO_ID) return true;
			if (this.ESTADO_RECIBO != original.ESTADO_RECIBO) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.CANTIDADES_DECIMALES != original.CANTIDADES_DECIMALES) return true;
			if (this.CADENA_DECIMALES != original.CADENA_DECIMALES) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsNRO_COMPROBANTE_SECUENCIANull != original.IsNRO_COMPROBANTE_SECUENCIANull) return true;
			if (!this.IsNRO_COMPROBANTE_SECUENCIANull && !original.IsNRO_COMPROBANTE_SECUENCIANull)
				if (this.NRO_COMPROBANTE_SECUENCIA != original.NRO_COMPROBANTE_SECUENCIA) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>RECIBO_ID</c> column value.
		/// </summary>
		/// <value>The <c>RECIBO_ID</c> column value.</value>
		public decimal RECIBO_ID
		{
			get { return _recibo_id; }
			set { _recibo_id = value; }
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
		/// Gets or sets the <c>NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_COMPLETO</c> column value.</value>
		public string NOMBRE_COMPLETO
		{
			get { return _nombre_completo; }
			set { _nombre_completo = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>ESTADO_RECIBO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_RECIBO_ID</c> column value.</value>
		public string ESTADO_RECIBO_ID
		{
			get { return _estado_recibo_id; }
			set { _estado_recibo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_RECIBO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_RECIBO</c> column value.</value>
		public string ESTADO_RECIBO
		{
			get { return _estado_recibo; }
			set { _estado_recibo = value; }
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
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDADES_DECIMALES</c> column value.</value>
		public decimal CANTIDADES_DECIMALES
		{
			get { return _cantidades_decimales; }
			set { _cantidades_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CADENA_DECIMALES</c> column value.</value>
		public string CADENA_DECIMALES
		{
			get { return _cadena_decimales; }
			set { _cadena_decimales = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@RECIBO_ID=");
			dynStr.Append(RECIBO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@ESTADO_RECIBO_ID=");
			dynStr.Append(ESTADO_RECIBO_ID);
			dynStr.Append("@CBA@ESTADO_RECIBO=");
			dynStr.Append(ESTADO_RECIBO);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@CANTIDADES_DECIMALES=");
			dynStr.Append(CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@CADENA_DECIMALES=");
			dynStr.Append(CADENA_DECIMALES);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@NRO_COMPROBANTE_SECUENCIA=");
			dynStr.Append(IsNRO_COMPROBANTE_SECUENCIANull ? (object)"<NULL>" : NRO_COMPROBANTE_SECUENCIA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			return dynStr.ToString();
		}
	} // End of RENDICION_COBRADOR_RECIBOSRow_Base class
} // End of namespace
