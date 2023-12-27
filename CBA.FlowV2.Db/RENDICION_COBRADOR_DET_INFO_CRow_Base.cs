// <fileinfo name="RENDICION_COBRADOR_DET_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="RENDICION_COBRADOR_DET_INFO_CRow"/> that 
	/// represents a record in the <c>RENDICION_COBRADOR_DET_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="RENDICION_COBRADOR_DET_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RENDICION_COBRADOR_DET_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _rendicion_cobrador_id;
		private decimal _recibo_id;
		private decimal _caso_pago;
		private bool _caso_pagoNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private decimal _persona_id;
		private string _nombre_completo;
		private string _nro_comprobante;
		private string _estado_recibo_id;
		private string _estado_recibo;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cantidades_decimales;
		private string _cadena_decimales;
		private decimal _monto;
		private System.DateTime _fecha;
		private string _estado_id;
		private string _estado_anterior_id;
		private System.DateTime _fecha_creacion_caso;
		private bool _fecha_creacion_casoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADOR_DET_INFO_CRow_Base"/> class.
		/// </summary>
		public RENDICION_COBRADOR_DET_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(RENDICION_COBRADOR_DET_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.RENDICION_COBRADOR_ID != original.RENDICION_COBRADOR_ID) return true;
			if (this.RECIBO_ID != original.RECIBO_ID) return true;
			if (this.IsCASO_PAGONull != original.IsCASO_PAGONull) return true;
			if (!this.IsCASO_PAGONull && !original.IsCASO_PAGONull)
				if (this.CASO_PAGO != original.CASO_PAGO) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.ESTADO_RECIBO_ID != original.ESTADO_RECIBO_ID) return true;
			if (this.ESTADO_RECIBO != original.ESTADO_RECIBO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.CANTIDADES_DECIMALES != original.CANTIDADES_DECIMALES) return true;
			if (this.CADENA_DECIMALES != original.CADENA_DECIMALES) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			if (this.ESTADO_ANTERIOR_ID != original.ESTADO_ANTERIOR_ID) return true;
			if (this.IsFECHA_CREACION_CASONull != original.IsFECHA_CREACION_CASONull) return true;
			if (!this.IsFECHA_CREACION_CASONull && !original.IsFECHA_CREACION_CASONull)
				if (this.FECHA_CREACION_CASO != original.FECHA_CREACION_CASO) return true;
			
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
		/// Gets or sets the <c>RENDICION_COBRADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>RENDICION_COBRADOR_ID</c> column value.</value>
		public decimal RENDICION_COBRADOR_ID
		{
			get { return _rendicion_cobrador_id; }
			set { _rendicion_cobrador_id = value; }
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
		/// Gets or sets the <c>CASO_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_PAGO</c> column value.</value>
		public decimal CASO_PAGO
		{
			get
			{
				if(IsCASO_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_pago;
			}
			set
			{
				_caso_pagoNull = false;
				_caso_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_PAGONull
		{
			get { return _caso_pagoNull; }
			set { _caso_pagoNull = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ID</c> column value.</value>
		public string ESTADO_ID
		{
			get { return _estado_id; }
			set { _estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ANTERIOR_ID</c> column value.</value>
		public string ESTADO_ANTERIOR_ID
		{
			get { return _estado_anterior_id; }
			set { _estado_anterior_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION_CASO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION_CASO</c> column value.</value>
		public System.DateTime FECHA_CREACION_CASO
		{
			get
			{
				if(IsFECHA_CREACION_CASONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion_caso;
			}
			set
			{
				_fecha_creacion_casoNull = false;
				_fecha_creacion_caso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION_CASO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACION_CASONull
		{
			get { return _fecha_creacion_casoNull; }
			set { _fecha_creacion_casoNull = value; }
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
			dynStr.Append("@CBA@RENDICION_COBRADOR_ID=");
			dynStr.Append(RENDICION_COBRADOR_ID);
			dynStr.Append("@CBA@RECIBO_ID=");
			dynStr.Append(RECIBO_ID);
			dynStr.Append("@CBA@CASO_PAGO=");
			dynStr.Append(IsCASO_PAGONull ? (object)"<NULL>" : CASO_PAGO);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@ESTADO_RECIBO_ID=");
			dynStr.Append(ESTADO_RECIBO_ID);
			dynStr.Append("@CBA@ESTADO_RECIBO=");
			dynStr.Append(ESTADO_RECIBO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@CANTIDADES_DECIMALES=");
			dynStr.Append(CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@CADENA_DECIMALES=");
			dynStr.Append(CADENA_DECIMALES);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			dynStr.Append("@CBA@ESTADO_ANTERIOR_ID=");
			dynStr.Append(ESTADO_ANTERIOR_ID);
			dynStr.Append("@CBA@FECHA_CREACION_CASO=");
			dynStr.Append(IsFECHA_CREACION_CASONull ? (object)"<NULL>" : FECHA_CREACION_CASO);
			return dynStr.ToString();
		}
	} // End of RENDICION_COBRADOR_DET_INFO_CRow_Base class
} // End of namespace
