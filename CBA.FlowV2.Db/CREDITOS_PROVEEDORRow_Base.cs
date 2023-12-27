// <fileinfo name="CREDITOS_PROVEEDORRow_Base.cs">
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
	/// The base class for <see cref="CREDITOS_PROVEEDORRow"/> that 
	/// represents a record in the <c>CREDITOS_PROVEEDOR</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CREDITOS_PROVEEDORRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOS_PROVEEDORRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _caso_id;
		private decimal _caso_relac_ingresa_valores_id;
		private bool _caso_relac_ingresa_valores_idNull = true;
		private decimal _tipo_credito_id;
		private decimal _proveedor_id;
		private string _nro_comprobante;
		private System.DateTime _fecha_solicitud;
		private bool _fecha_solicitudNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private System.DateTime _fecha_desembolso;
		private bool _fecha_desembolsoNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _monto_capital;
		private decimal _monto_interes;
		private decimal _monto_total;
		private decimal _porcentaje_impuesto;
		private decimal _monto_impuesto;
		private decimal _interes_anual;
		private decimal _porcentaje_diario_mora;
		private string _observacion;
		private string _facturar_intereses_en_pagos;
		private string _facturar_capital_en_pagos;
		private string _facturar_solo_intereses;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_PROVEEDORRow_Base"/> class.
		/// </summary>
		public CREDITOS_PROVEEDORRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CREDITOS_PROVEEDORRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsCASO_RELAC_INGRESA_VALORES_IDNull != original.IsCASO_RELAC_INGRESA_VALORES_IDNull) return true;
			if (!this.IsCASO_RELAC_INGRESA_VALORES_IDNull && !original.IsCASO_RELAC_INGRESA_VALORES_IDNull)
				if (this.CASO_RELAC_INGRESA_VALORES_ID != original.CASO_RELAC_INGRESA_VALORES_ID) return true;
			if (this.TIPO_CREDITO_ID != original.TIPO_CREDITO_ID) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHA_SOLICITUDNull != original.IsFECHA_SOLICITUDNull) return true;
			if (!this.IsFECHA_SOLICITUDNull && !original.IsFECHA_SOLICITUDNull)
				if (this.FECHA_SOLICITUD != original.FECHA_SOLICITUD) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.IsFECHA_DESEMBOLSONull != original.IsFECHA_DESEMBOLSONull) return true;
			if (!this.IsFECHA_DESEMBOLSONull && !original.IsFECHA_DESEMBOLSONull)
				if (this.FECHA_DESEMBOLSO != original.FECHA_DESEMBOLSO) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO_CAPITAL != original.MONTO_CAPITAL) return true;
			if (this.MONTO_INTERES != original.MONTO_INTERES) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.MONTO_IMPUESTO != original.MONTO_IMPUESTO) return true;
			if (this.INTERES_ANUAL != original.INTERES_ANUAL) return true;
			if (this.PORCENTAJE_DIARIO_MORA != original.PORCENTAJE_DIARIO_MORA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FACTURAR_INTERESES_EN_PAGOS != original.FACTURAR_INTERESES_EN_PAGOS) return true;
			if (this.FACTURAR_CAPITAL_EN_PAGOS != original.FACTURAR_CAPITAL_EN_PAGOS) return true;
			if (this.FACTURAR_SOLO_INTERESES != original.FACTURAR_SOLO_INTERESES) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_RELAC_INGRESA_VALORES_ID</c> column value.</value>
		public decimal CASO_RELAC_INGRESA_VALORES_ID
		{
			get
			{
				if(IsCASO_RELAC_INGRESA_VALORES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_relac_ingresa_valores_id;
			}
			set
			{
				_caso_relac_ingresa_valores_idNull = false;
				_caso_relac_ingresa_valores_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_RELAC_INGRESA_VALORES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_RELAC_INGRESA_VALORES_IDNull
		{
			get { return _caso_relac_ingresa_valores_idNull; }
			set { _caso_relac_ingresa_valores_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CREDITO_ID</c> column value.</value>
		public decimal TIPO_CREDITO_ID
		{
			get { return _tipo_credito_id; }
			set { _tipo_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
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
		/// Gets or sets the <c>FECHA_SOLICITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SOLICITUD</c> column value.</value>
		public System.DateTime FECHA_SOLICITUD
		{
			get
			{
				if(IsFECHA_SOLICITUDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_solicitud;
			}
			set
			{
				_fecha_solicitudNull = false;
				_fecha_solicitud = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SOLICITUD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SOLICITUDNull
		{
			get { return _fecha_solicitudNull; }
			set { _fecha_solicitudNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROBACION</c> column value.</value>
		public System.DateTime FECHA_APROBACION
		{
			get
			{
				if(IsFECHA_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprobacion;
			}
			set
			{
				_fecha_aprobacionNull = false;
				_fecha_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROBACIONNull
		{
			get { return _fecha_aprobacionNull; }
			set { _fecha_aprobacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESEMBOLSO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESEMBOLSO</c> column value.</value>
		public System.DateTime FECHA_DESEMBOLSO
		{
			get
			{
				if(IsFECHA_DESEMBOLSONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desembolso;
			}
			set
			{
				_fecha_desembolsoNull = false;
				_fecha_desembolso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESEMBOLSO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESEMBOLSONull
		{
			get { return _fecha_desembolsoNull; }
			set { _fecha_desembolsoNull = value; }
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
		/// Gets or sets the <c>MONTO_CAPITAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_CAPITAL</c> column value.</value>
		public decimal MONTO_CAPITAL
		{
			get { return _monto_capital; }
			set { _monto_capital = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_INTERES</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_INTERES</c> column value.</value>
		public decimal MONTO_INTERES
		{
			get { return _monto_interes; }
			set { _monto_interes = value; }
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
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get { return _porcentaje_impuesto; }
			set { _porcentaje_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_IMPUESTO</c> column value.</value>
		public decimal MONTO_IMPUESTO
		{
			get { return _monto_impuesto; }
			set { _monto_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_ANUAL</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_ANUAL</c> column value.</value>
		public decimal INTERES_ANUAL
		{
			get { return _interes_anual; }
			set { _interes_anual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DIARIO_MORA</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DIARIO_MORA</c> column value.</value>
		public decimal PORCENTAJE_DIARIO_MORA
		{
			get { return _porcentaje_diario_mora; }
			set { _porcentaje_diario_mora = value; }
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
		/// Gets or sets the <c>FACTURAR_INTERESES_EN_PAGOS</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_INTERESES_EN_PAGOS</c> column value.</value>
		public string FACTURAR_INTERESES_EN_PAGOS
		{
			get { return _facturar_intereses_en_pagos; }
			set { _facturar_intereses_en_pagos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_CAPITAL_EN_PAGOS</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_CAPITAL_EN_PAGOS</c> column value.</value>
		public string FACTURAR_CAPITAL_EN_PAGOS
		{
			get { return _facturar_capital_en_pagos; }
			set { _facturar_capital_en_pagos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_SOLO_INTERESES</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_SOLO_INTERESES</c> column value.</value>
		public string FACTURAR_SOLO_INTERESES
		{
			get { return _facturar_solo_intereses; }
			set { _facturar_solo_intereses = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_RELAC_INGRESA_VALORES_ID=");
			dynStr.Append(IsCASO_RELAC_INGRESA_VALORES_IDNull ? (object)"<NULL>" : CASO_RELAC_INGRESA_VALORES_ID);
			dynStr.Append("@CBA@TIPO_CREDITO_ID=");
			dynStr.Append(TIPO_CREDITO_ID);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_SOLICITUD=");
			dynStr.Append(IsFECHA_SOLICITUDNull ? (object)"<NULL>" : FECHA_SOLICITUD);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@FECHA_DESEMBOLSO=");
			dynStr.Append(IsFECHA_DESEMBOLSONull ? (object)"<NULL>" : FECHA_DESEMBOLSO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO_CAPITAL=");
			dynStr.Append(MONTO_CAPITAL);
			dynStr.Append("@CBA@MONTO_INTERES=");
			dynStr.Append(MONTO_INTERES);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@MONTO_IMPUESTO=");
			dynStr.Append(MONTO_IMPUESTO);
			dynStr.Append("@CBA@INTERES_ANUAL=");
			dynStr.Append(INTERES_ANUAL);
			dynStr.Append("@CBA@PORCENTAJE_DIARIO_MORA=");
			dynStr.Append(PORCENTAJE_DIARIO_MORA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FACTURAR_INTERESES_EN_PAGOS=");
			dynStr.Append(FACTURAR_INTERESES_EN_PAGOS);
			dynStr.Append("@CBA@FACTURAR_CAPITAL_EN_PAGOS=");
			dynStr.Append(FACTURAR_CAPITAL_EN_PAGOS);
			dynStr.Append("@CBA@FACTURAR_SOLO_INTERESES=");
			dynStr.Append(FACTURAR_SOLO_INTERESES);
			return dynStr.ToString();
		}
	} // End of CREDITOS_PROVEEDORRow_Base class
} // End of namespace
