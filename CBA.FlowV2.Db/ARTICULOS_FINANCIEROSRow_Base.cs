// <fileinfo name="ARTICULOS_FINANCIEROSRow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_FINANCIEROSRow"/> that 
	/// represents a record in the <c>ARTICULOS_FINANCIEROS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_FINANCIEROSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_FINANCIEROSRow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private decimal _moneda_id;
		private string _tipo_frecuencia;
		private decimal _cantidad_cuotas;
		private decimal _frecuencia;
		private string _estado;
		private decimal _tipo_credito_id;
		private string _anho_comercial;
		private string _desembolsar_para_cliente;
		private string _facturar_conceptos_en_pagos;
		private string _interes_incluye_impuesto;
		private string _aumentar_capital_por_descuent;
		private string _con_recurso;
		private decimal _monto_redondeo;
		private string _tipo_interes_anual;
		private string _concepto_incluye_impuesto;
		private string _facturar_bonificacion_en_pagos;
		private string _bonificacion_incluye_impuesto;
		private System.DateTime _fecha_desde;
		private bool _fecha_desdeNull = true;
		private System.DateTime _fecha_hasta;
		private bool _fecha_hastaNull = true;
		private decimal _tipo_articulo_financiero_id;
		private decimal _facturar_intereses;
		private decimal _cuota_monto_base;
		private bool _cuota_monto_baseNull = true;
		private decimal _canal_venta_id;
		private bool _canal_venta_idNull = true;
		private decimal _facturar_capital;
		private decimal _politica_busqueda_rango_dias;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _reglas_primer_vencimiento;
		private decimal _articulo_refinanciacion_id;
		private bool _articulo_refinanciacion_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FINANCIEROSRow_Base"/> class.
		/// </summary>
		public ARTICULOS_FINANCIEROSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_FINANCIEROSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.TIPO_FRECUENCIA != original.TIPO_FRECUENCIA) return true;
			if (this.CANTIDAD_CUOTAS != original.CANTIDAD_CUOTAS) return true;
			if (this.FRECUENCIA != original.FRECUENCIA) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO_CREDITO_ID != original.TIPO_CREDITO_ID) return true;
			if (this.ANHO_COMERCIAL != original.ANHO_COMERCIAL) return true;
			if (this.DESEMBOLSAR_PARA_CLIENTE != original.DESEMBOLSAR_PARA_CLIENTE) return true;
			if (this.FACTURAR_CONCEPTOS_EN_PAGOS != original.FACTURAR_CONCEPTOS_EN_PAGOS) return true;
			if (this.INTERES_INCLUYE_IMPUESTO != original.INTERES_INCLUYE_IMPUESTO) return true;
			if (this.AUMENTAR_CAPITAL_POR_DESCUENT != original.AUMENTAR_CAPITAL_POR_DESCUENT) return true;
			if (this.CON_RECURSO != original.CON_RECURSO) return true;
			if (this.MONTO_REDONDEO != original.MONTO_REDONDEO) return true;
			if (this.TIPO_INTERES_ANUAL != original.TIPO_INTERES_ANUAL) return true;
			if (this.CONCEPTO_INCLUYE_IMPUESTO != original.CONCEPTO_INCLUYE_IMPUESTO) return true;
			if (this.FACTURAR_BONIFICACION_EN_PAGOS != original.FACTURAR_BONIFICACION_EN_PAGOS) return true;
			if (this.BONIFICACION_INCLUYE_IMPUESTO != original.BONIFICACION_INCLUYE_IMPUESTO) return true;
			if (this.IsFECHA_DESDENull != original.IsFECHA_DESDENull) return true;
			if (!this.IsFECHA_DESDENull && !original.IsFECHA_DESDENull)
				if (this.FECHA_DESDE != original.FECHA_DESDE) return true;
			if (this.IsFECHA_HASTANull != original.IsFECHA_HASTANull) return true;
			if (!this.IsFECHA_HASTANull && !original.IsFECHA_HASTANull)
				if (this.FECHA_HASTA != original.FECHA_HASTA) return true;
			if (this.TIPO_ARTICULO_FINANCIERO_ID != original.TIPO_ARTICULO_FINANCIERO_ID) return true;
			if (this.FACTURAR_INTERESES != original.FACTURAR_INTERESES) return true;
			if (this.IsCUOTA_MONTO_BASENull != original.IsCUOTA_MONTO_BASENull) return true;
			if (!this.IsCUOTA_MONTO_BASENull && !original.IsCUOTA_MONTO_BASENull)
				if (this.CUOTA_MONTO_BASE != original.CUOTA_MONTO_BASE) return true;
			if (this.IsCANAL_VENTA_IDNull != original.IsCANAL_VENTA_IDNull) return true;
			if (!this.IsCANAL_VENTA_IDNull && !original.IsCANAL_VENTA_IDNull)
				if (this.CANAL_VENTA_ID != original.CANAL_VENTA_ID) return true;
			if (this.FACTURAR_CAPITAL != original.FACTURAR_CAPITAL) return true;
			if (this.POLITICA_BUSQUEDA_RANGO_DIAS != original.POLITICA_BUSQUEDA_RANGO_DIAS) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.REGLAS_PRIMER_VENCIMIENTO != original.REGLAS_PRIMER_VENCIMIENTO) return true;
			if (this.IsARTICULO_REFINANCIACION_IDNull != original.IsARTICULO_REFINANCIACION_IDNull) return true;
			if (!this.IsARTICULO_REFINANCIACION_IDNull && !original.IsARTICULO_REFINANCIACION_IDNull)
				if (this.ARTICULO_REFINANCIACION_ID != original.ARTICULO_REFINANCIACION_ID) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
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
		/// Gets or sets the <c>TIPO_FRECUENCIA</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_FRECUENCIA</c> column value.</value>
		public string TIPO_FRECUENCIA
		{
			get { return _tipo_frecuencia; }
			set { _tipo_frecuencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CUOTAS</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CUOTAS</c> column value.</value>
		public decimal CANTIDAD_CUOTAS
		{
			get { return _cantidad_cuotas; }
			set { _cantidad_cuotas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FRECUENCIA</c> column value.
		/// </summary>
		/// <value>The <c>FRECUENCIA</c> column value.</value>
		public decimal FRECUENCIA
		{
			get { return _frecuencia; }
			set { _frecuencia = value; }
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
		/// Gets or sets the <c>TIPO_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CREDITO_ID</c> column value.</value>
		public decimal TIPO_CREDITO_ID
		{
			get { return _tipo_credito_id; }
			set { _tipo_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO_COMERCIAL</c> column value.
		/// </summary>
		/// <value>The <c>ANHO_COMERCIAL</c> column value.</value>
		public string ANHO_COMERCIAL
		{
			get { return _anho_comercial; }
			set { _anho_comercial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESEMBOLSAR_PARA_CLIENTE</c> column value.
		/// </summary>
		/// <value>The <c>DESEMBOLSAR_PARA_CLIENTE</c> column value.</value>
		public string DESEMBOLSAR_PARA_CLIENTE
		{
			get { return _desembolsar_para_cliente; }
			set { _desembolsar_para_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_CONCEPTOS_EN_PAGOS</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_CONCEPTOS_EN_PAGOS</c> column value.</value>
		public string FACTURAR_CONCEPTOS_EN_PAGOS
		{
			get { return _facturar_conceptos_en_pagos; }
			set { _facturar_conceptos_en_pagos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERES_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>INTERES_INCLUYE_IMPUESTO</c> column value.</value>
		public string INTERES_INCLUYE_IMPUESTO
		{
			get { return _interes_incluye_impuesto; }
			set { _interes_incluye_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUMENTAR_CAPITAL_POR_DESCUENT</c> column value.
		/// </summary>
		/// <value>The <c>AUMENTAR_CAPITAL_POR_DESCUENT</c> column value.</value>
		public string AUMENTAR_CAPITAL_POR_DESCUENT
		{
			get { return _aumentar_capital_por_descuent; }
			set { _aumentar_capital_por_descuent = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CON_RECURSO</c> column value.
		/// </summary>
		/// <value>The <c>CON_RECURSO</c> column value.</value>
		public string CON_RECURSO
		{
			get { return _con_recurso; }
			set { _con_recurso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_REDONDEO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_REDONDEO</c> column value.</value>
		public decimal MONTO_REDONDEO
		{
			get { return _monto_redondeo; }
			set { _monto_redondeo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_INTERES_ANUAL</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_INTERES_ANUAL</c> column value.</value>
		public string TIPO_INTERES_ANUAL
		{
			get { return _tipo_interes_anual; }
			set { _tipo_interes_anual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONCEPTO_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>CONCEPTO_INCLUYE_IMPUESTO</c> column value.</value>
		public string CONCEPTO_INCLUYE_IMPUESTO
		{
			get { return _concepto_incluye_impuesto; }
			set { _concepto_incluye_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_BONIFICACION_EN_PAGOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURAR_BONIFICACION_EN_PAGOS</c> column value.</value>
		public string FACTURAR_BONIFICACION_EN_PAGOS
		{
			get { return _facturar_bonificacion_en_pagos; }
			set { _facturar_bonificacion_en_pagos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BONIFICACION_INCLUYE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>BONIFICACION_INCLUYE_IMPUESTO</c> column value.</value>
		public string BONIFICACION_INCLUYE_IMPUESTO
		{
			get { return _bonificacion_incluye_impuesto; }
			set { _bonificacion_incluye_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESDE</c> column value.</value>
		public System.DateTime FECHA_DESDE
		{
			get
			{
				if(IsFECHA_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desde;
			}
			set
			{
				_fecha_desdeNull = false;
				_fecha_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESDENull
		{
			get { return _fecha_desdeNull; }
			set { _fecha_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_HASTA</c> column value.</value>
		public System.DateTime FECHA_HASTA
		{
			get
			{
				if(IsFECHA_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_hasta;
			}
			set
			{
				_fecha_hastaNull = false;
				_fecha_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_HASTANull
		{
			get { return _fecha_hastaNull; }
			set { _fecha_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ARTICULO_FINANCIERO_ID</c> column value.</value>
		public decimal TIPO_ARTICULO_FINANCIERO_ID
		{
			get { return _tipo_articulo_financiero_id; }
			set { _tipo_articulo_financiero_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_INTERESES</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_INTERESES</c> column value.</value>
		public decimal FACTURAR_INTERESES
		{
			get { return _facturar_intereses; }
			set { _facturar_intereses = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_MONTO_BASE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_MONTO_BASE</c> column value.</value>
		public decimal CUOTA_MONTO_BASE
		{
			get
			{
				if(IsCUOTA_MONTO_BASENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_monto_base;
			}
			set
			{
				_cuota_monto_baseNull = false;
				_cuota_monto_base = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_MONTO_BASE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_MONTO_BASENull
		{
			get { return _cuota_monto_baseNull; }
			set { _cuota_monto_baseNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANAL_VENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANAL_VENTA_ID</c> column value.</value>
		public decimal CANAL_VENTA_ID
		{
			get
			{
				if(IsCANAL_VENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _canal_venta_id;
			}
			set
			{
				_canal_venta_idNull = false;
				_canal_venta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANAL_VENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANAL_VENTA_IDNull
		{
			get { return _canal_venta_idNull; }
			set { _canal_venta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURAR_CAPITAL</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAR_CAPITAL</c> column value.</value>
		public decimal FACTURAR_CAPITAL
		{
			get { return _facturar_capital; }
			set { _facturar_capital = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>POLITICA_BUSQUEDA_RANGO_DIAS</c> column value.
		/// </summary>
		/// <value>The <c>POLITICA_BUSQUEDA_RANGO_DIAS</c> column value.</value>
		public decimal POLITICA_BUSQUEDA_RANGO_DIAS
		{
			get { return _politica_busqueda_rango_dias; }
			set { _politica_busqueda_rango_dias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGLAS_PRIMER_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGLAS_PRIMER_VENCIMIENTO</c> column value.</value>
		public string REGLAS_PRIMER_VENCIMIENTO
		{
			get { return _reglas_primer_vencimiento; }
			set { _reglas_primer_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_REFINANCIACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_REFINANCIACION_ID</c> column value.</value>
		public decimal ARTICULO_REFINANCIACION_ID
		{
			get
			{
				if(IsARTICULO_REFINANCIACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_refinanciacion_id;
			}
			set
			{
				_articulo_refinanciacion_idNull = false;
				_articulo_refinanciacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_REFINANCIACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_REFINANCIACION_IDNull
		{
			get { return _articulo_refinanciacion_idNull; }
			set { _articulo_refinanciacion_idNull = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@TIPO_FRECUENCIA=");
			dynStr.Append(TIPO_FRECUENCIA);
			dynStr.Append("@CBA@CANTIDAD_CUOTAS=");
			dynStr.Append(CANTIDAD_CUOTAS);
			dynStr.Append("@CBA@FRECUENCIA=");
			dynStr.Append(FRECUENCIA);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_CREDITO_ID=");
			dynStr.Append(TIPO_CREDITO_ID);
			dynStr.Append("@CBA@ANHO_COMERCIAL=");
			dynStr.Append(ANHO_COMERCIAL);
			dynStr.Append("@CBA@DESEMBOLSAR_PARA_CLIENTE=");
			dynStr.Append(DESEMBOLSAR_PARA_CLIENTE);
			dynStr.Append("@CBA@FACTURAR_CONCEPTOS_EN_PAGOS=");
			dynStr.Append(FACTURAR_CONCEPTOS_EN_PAGOS);
			dynStr.Append("@CBA@INTERES_INCLUYE_IMPUESTO=");
			dynStr.Append(INTERES_INCLUYE_IMPUESTO);
			dynStr.Append("@CBA@AUMENTAR_CAPITAL_POR_DESCUENT=");
			dynStr.Append(AUMENTAR_CAPITAL_POR_DESCUENT);
			dynStr.Append("@CBA@CON_RECURSO=");
			dynStr.Append(CON_RECURSO);
			dynStr.Append("@CBA@MONTO_REDONDEO=");
			dynStr.Append(MONTO_REDONDEO);
			dynStr.Append("@CBA@TIPO_INTERES_ANUAL=");
			dynStr.Append(TIPO_INTERES_ANUAL);
			dynStr.Append("@CBA@CONCEPTO_INCLUYE_IMPUESTO=");
			dynStr.Append(CONCEPTO_INCLUYE_IMPUESTO);
			dynStr.Append("@CBA@FACTURAR_BONIFICACION_EN_PAGOS=");
			dynStr.Append(FACTURAR_BONIFICACION_EN_PAGOS);
			dynStr.Append("@CBA@BONIFICACION_INCLUYE_IMPUESTO=");
			dynStr.Append(BONIFICACION_INCLUYE_IMPUESTO);
			dynStr.Append("@CBA@FECHA_DESDE=");
			dynStr.Append(IsFECHA_DESDENull ? (object)"<NULL>" : FECHA_DESDE);
			dynStr.Append("@CBA@FECHA_HASTA=");
			dynStr.Append(IsFECHA_HASTANull ? (object)"<NULL>" : FECHA_HASTA);
			dynStr.Append("@CBA@TIPO_ARTICULO_FINANCIERO_ID=");
			dynStr.Append(TIPO_ARTICULO_FINANCIERO_ID);
			dynStr.Append("@CBA@FACTURAR_INTERESES=");
			dynStr.Append(FACTURAR_INTERESES);
			dynStr.Append("@CBA@CUOTA_MONTO_BASE=");
			dynStr.Append(IsCUOTA_MONTO_BASENull ? (object)"<NULL>" : CUOTA_MONTO_BASE);
			dynStr.Append("@CBA@CANAL_VENTA_ID=");
			dynStr.Append(IsCANAL_VENTA_IDNull ? (object)"<NULL>" : CANAL_VENTA_ID);
			dynStr.Append("@CBA@FACTURAR_CAPITAL=");
			dynStr.Append(FACTURAR_CAPITAL);
			dynStr.Append("@CBA@POLITICA_BUSQUEDA_RANGO_DIAS=");
			dynStr.Append(POLITICA_BUSQUEDA_RANGO_DIAS);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@REGLAS_PRIMER_VENCIMIENTO=");
			dynStr.Append(REGLAS_PRIMER_VENCIMIENTO);
			dynStr.Append("@CBA@ARTICULO_REFINANCIACION_ID=");
			dynStr.Append(IsARTICULO_REFINANCIACION_IDNull ? (object)"<NULL>" : ARTICULO_REFINANCIACION_ID);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_FINANCIEROSRow_Base class
} // End of namespace
