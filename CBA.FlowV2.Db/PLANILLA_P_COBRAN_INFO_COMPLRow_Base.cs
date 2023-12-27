// <fileinfo name="PLANILLA_P_COBRAN_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_P_COBRAN_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PLANILLA_P_COBRAN_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_P_COBRAN_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_P_COBRAN_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _ctacte_persona_id;
		private decimal _monto_cuota;
		private decimal _monto_mora;
		private decimal _cobrado;
		private decimal _planilla_de_cobranza_id;
		private decimal _planilla_de_cobranza_det_id;
		private bool _planilla_de_cobranza_det_idNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _flujo_nombre;
		private decimal _persona_id;
		private string _persona_codigo;
		private string _persona_codigo_externo;
		private string _persona_nombre_completo;
		private string _persona_numero_documento;
		private string _persona_ruc;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private decimal _cotizacion_moneda;
		private string _moneda_cadena_decimales;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private string _cuota_numero;
		private decimal _saldo_cuota;
		private bool _saldo_cuotaNull = true;
		private string _caso_nro_comprobante;
		private string _ctacte_observacion;
		private string _persona_direccion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_P_COBRAN_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PLANILLA_P_COBRAN_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_P_COBRAN_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.MONTO_CUOTA != original.MONTO_CUOTA) return true;
			if (this.MONTO_MORA != original.MONTO_MORA) return true;
			if (this.COBRADO != original.COBRADO) return true;
			if (this.PLANILLA_DE_COBRANZA_ID != original.PLANILLA_DE_COBRANZA_ID) return true;
			if (this.IsPLANILLA_DE_COBRANZA_DET_IDNull != original.IsPLANILLA_DE_COBRANZA_DET_IDNull) return true;
			if (!this.IsPLANILLA_DE_COBRANZA_DET_IDNull && !original.IsPLANILLA_DE_COBRANZA_DET_IDNull)
				if (this.PLANILLA_DE_COBRANZA_DET_ID != original.PLANILLA_DE_COBRANZA_DET_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FLUJO_NOMBRE != original.FLUJO_NOMBRE) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.PERSONA_CODIGO_EXTERNO != original.PERSONA_CODIGO_EXTERNO) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.PERSONA_NUMERO_DOCUMENTO != original.PERSONA_NUMERO_DOCUMENTO) return true;
			if (this.PERSONA_RUC != original.PERSONA_RUC) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.CUOTA_NUMERO != original.CUOTA_NUMERO) return true;
			if (this.IsSALDO_CUOTANull != original.IsSALDO_CUOTANull) return true;
			if (!this.IsSALDO_CUOTANull && !original.IsSALDO_CUOTANull)
				if (this.SALDO_CUOTA != original.SALDO_CUOTA) return true;
			if (this.CASO_NRO_COMPROBANTE != original.CASO_NRO_COMPROBANTE) return true;
			if (this.CTACTE_OBSERVACION != original.CTACTE_OBSERVACION) return true;
			if (this.PERSONA_DIRECCION != original.PERSONA_DIRECCION) return true;
			
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
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get { return _ctacte_persona_id; }
			set { _ctacte_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CUOTA</c> column value.</value>
		public decimal MONTO_CUOTA
		{
			get { return _monto_cuota; }
			set { _monto_cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_MORA</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_MORA</c> column value.</value>
		public decimal MONTO_MORA
		{
			get { return _monto_mora; }
			set { _monto_mora = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRADO</c> column value.
		/// </summary>
		/// <value>The <c>COBRADO</c> column value.</value>
		public decimal COBRADO
		{
			get { return _cobrado; }
			set { _cobrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANILLA_DE_COBRANZA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</value>
		public decimal PLANILLA_DE_COBRANZA_ID
		{
			get { return _planilla_de_cobranza_id; }
			set { _planilla_de_cobranza_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</value>
		public decimal PLANILLA_DE_COBRANZA_DET_ID
		{
			get
			{
				if(IsPLANILLA_DE_COBRANZA_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _planilla_de_cobranza_det_id;
			}
			set
			{
				_planilla_de_cobranza_det_idNull = false;
				_planilla_de_cobranza_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PLANILLA_DE_COBRANZA_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPLANILLA_DE_COBRANZA_DET_IDNull
		{
			get { return _planilla_de_cobranza_det_idNull; }
			set { _planilla_de_cobranza_det_idNull = value; }
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
		/// Gets or sets the <c>FLUJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_NOMBRE</c> column value.</value>
		public string FLUJO_NOMBRE
		{
			get { return _flujo_nombre; }
			set { _flujo_nombre = value; }
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
		/// Gets or sets the <c>PERSONA_CODIGO_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO_EXTERNO</c> column value.</value>
		public string PERSONA_CODIGO_EXTERNO
		{
			get { return _persona_codigo_externo; }
			set { _persona_codigo_externo = value; }
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
		/// Gets or sets the <c>PERSONA_NUMERO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NUMERO_DOCUMENTO</c> column value.</value>
		public string PERSONA_NUMERO_DOCUMENTO
		{
			get { return _persona_numero_documento; }
			set { _persona_numero_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_RUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_RUC</c> column value.</value>
		public string PERSONA_RUC
		{
			get { return _persona_ruc; }
			set { _persona_ruc = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
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
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get
			{
				if(IsFECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento;
			}
			set
			{
				_fecha_vencimientoNull = false;
				_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTONull
		{
			get { return _fecha_vencimientoNull; }
			set { _fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_NUMERO</c> column value.</value>
		public string CUOTA_NUMERO
		{
			get { return _cuota_numero; }
			set { _cuota_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALDO_CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALDO_CUOTA</c> column value.</value>
		public decimal SALDO_CUOTA
		{
			get
			{
				if(IsSALDO_CUOTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _saldo_cuota;
			}
			set
			{
				_saldo_cuotaNull = false;
				_saldo_cuota = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALDO_CUOTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALDO_CUOTANull
		{
			get { return _saldo_cuotaNull; }
			set { _saldo_cuotaNull = value; }
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
		/// Gets or sets the <c>CTACTE_OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_OBSERVACION</c> column value.</value>
		public string CTACTE_OBSERVACION
		{
			get { return _ctacte_observacion; }
			set { _ctacte_observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_DIRECCION</c> column value.</value>
		public string PERSONA_DIRECCION
		{
			get { return _persona_direccion; }
			set { _persona_direccion = value; }
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
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@MONTO_CUOTA=");
			dynStr.Append(MONTO_CUOTA);
			dynStr.Append("@CBA@MONTO_MORA=");
			dynStr.Append(MONTO_MORA);
			dynStr.Append("@CBA@COBRADO=");
			dynStr.Append(COBRADO);
			dynStr.Append("@CBA@PLANILLA_DE_COBRANZA_ID=");
			dynStr.Append(PLANILLA_DE_COBRANZA_ID);
			dynStr.Append("@CBA@PLANILLA_DE_COBRANZA_DET_ID=");
			dynStr.Append(IsPLANILLA_DE_COBRANZA_DET_IDNull ? (object)"<NULL>" : PLANILLA_DE_COBRANZA_DET_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FLUJO_NOMBRE=");
			dynStr.Append(FLUJO_NOMBRE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@PERSONA_CODIGO_EXTERNO=");
			dynStr.Append(PERSONA_CODIGO_EXTERNO);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_NUMERO_DOCUMENTO=");
			dynStr.Append(PERSONA_NUMERO_DOCUMENTO);
			dynStr.Append("@CBA@PERSONA_RUC=");
			dynStr.Append(PERSONA_RUC);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@CUOTA_NUMERO=");
			dynStr.Append(CUOTA_NUMERO);
			dynStr.Append("@CBA@SALDO_CUOTA=");
			dynStr.Append(IsSALDO_CUOTANull ? (object)"<NULL>" : SALDO_CUOTA);
			dynStr.Append("@CBA@CASO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@CTACTE_OBSERVACION=");
			dynStr.Append(CTACTE_OBSERVACION);
			dynStr.Append("@CBA@PERSONA_DIRECCION=");
			dynStr.Append(PERSONA_DIRECCION);
			return dynStr.ToString();
		}
	} // End of PLANILLA_P_COBRAN_INFO_COMPLRow_Base class
} // End of namespace
