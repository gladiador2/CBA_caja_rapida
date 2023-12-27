// <fileinfo name="CTACTE_PAGOS_PERS_DOC_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PERS_DOC_INF_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_PAGOS_PERS_DOC_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGOS_PERS_DOC_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PERS_DOC_INF_COMPRow_Base
	{
		private decimal _id;
		private bool _idNull = true;
		private decimal _ctacte_pagos_persona_id;
		private bool _ctacte_pagos_persona_idNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _ctacte_pago_persona_recargo_id;
		private bool _ctacte_pago_persona_recargo_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private bool _cotizacion_monedaNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _cuota;
		private decimal _cuota_numero;
		private bool _cuota_numeroNull = true;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_descripcion;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private System.DateTime _dia_de_gracia;
		private bool _dia_de_graciaNull = true;
		private string _fecha_vencimiento_texto;
		private decimal _credito;
		private bool _creditoNull = true;
		private decimal _debito;
		private bool _debitoNull = true;
		private decimal _ctacte_valor_id;
		private bool _ctacte_valor_idNull = true;
		private string _observacion;
		private string _factura_cliente_tipo;
		private string _pago_confirmado;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERS_DOC_INF_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGOS_PERS_DOC_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGOS_PERS_DOC_INF_COMPRow_Base original)
		{
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.IsCTACTE_PAGOS_PERSONA_IDNull != original.IsCTACTE_PAGOS_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PAGOS_PERSONA_IDNull && !original.IsCTACTE_PAGOS_PERSONA_IDNull)
				if (this.CTACTE_PAGOS_PERSONA_ID != original.CTACTE_PAGOS_PERSONA_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull != original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull && !original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
				if (this.CTACTE_PAGO_PERSONA_RECARGO_ID != original.CTACTE_PAGO_PERSONA_RECARGO_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsCOTIZACION_MONEDANull != original.IsCOTIZACION_MONEDANull) return true;
			if (!this.IsCOTIZACION_MONEDANull && !original.IsCOTIZACION_MONEDANull)
				if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CUOTA != original.CUOTA) return true;
			if (this.IsCUOTA_NUMERONull != original.IsCUOTA_NUMERONull) return true;
			if (!this.IsCUOTA_NUMERONull && !original.IsCUOTA_NUMERONull)
				if (this.CUOTA_NUMERO != original.CUOTA_NUMERO) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.IsDIA_DE_GRACIANull != original.IsDIA_DE_GRACIANull) return true;
			if (!this.IsDIA_DE_GRACIANull && !original.IsDIA_DE_GRACIANull)
				if (this.DIA_DE_GRACIA != original.DIA_DE_GRACIA) return true;
			if (this.FECHA_VENCIMIENTO_TEXTO != original.FECHA_VENCIMIENTO_TEXTO) return true;
			if (this.IsCREDITONull != original.IsCREDITONull) return true;
			if (!this.IsCREDITONull && !original.IsCREDITONull)
				if (this.CREDITO != original.CREDITO) return true;
			if (this.IsDEBITONull != original.IsDEBITONull) return true;
			if (!this.IsDEBITONull && !original.IsDEBITONull)
				if (this.DEBITO != original.DEBITO) return true;
			if (this.IsCTACTE_VALOR_IDNull != original.IsCTACTE_VALOR_IDNull) return true;
			if (!this.IsCTACTE_VALOR_IDNull && !original.IsCTACTE_VALOR_IDNull)
				if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FACTURA_CLIENTE_TIPO != original.FACTURA_CLIENTE_TIPO) return true;
			if (this.PAGO_CONFIRMADO != original.PAGO_CONFIRMADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGOS_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PAGOS_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PAGOS_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagos_persona_id;
			}
			set
			{
				_ctacte_pagos_persona_idNull = false;
				_ctacte_pagos_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGOS_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGOS_PERSONA_IDNull
		{
			get { return _ctacte_pagos_persona_idNull; }
			set { _ctacte_pagos_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_RECARGO_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_recargo_id;
			}
			set
			{
				_ctacte_pago_persona_recargo_idNull = false;
				_ctacte_pago_persona_recargo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_RECARGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_RECARGO_IDNull
		{
			get { return _ctacte_pago_persona_recargo_idNull; }
			set { _ctacte_pago_persona_recargo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_NOMBRE</c> column value.</value>
		public string MONEDA_NOMBRE
		{
			get { return _moneda_nombre; }
			set { _moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get
			{
				if(IsCOTIZACION_MONEDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda;
			}
			set
			{
				_cotizacion_monedaNull = false;
				_cotizacion_moneda = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDANull
		{
			get { return _cotizacion_monedaNull; }
			set { _cotizacion_monedaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
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
		/// Gets or sets the <c>CUOTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA</c> column value.</value>
		public string CUOTA
		{
			get { return _cuota; }
			set { _cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUOTA_NUMERO</c> column value.</value>
		public decimal CUOTA_NUMERO
		{
			get
			{
				if(IsCUOTA_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cuota_numero;
			}
			set
			{
				_cuota_numeroNull = false;
				_cuota_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CUOTA_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCUOTA_NUMERONull
		{
			get { return _cuota_numeroNull; }
			set { _cuota_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
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
		/// Gets or sets the <c>DIA_DE_GRACIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIA_DE_GRACIA</c> column value.</value>
		public System.DateTime DIA_DE_GRACIA
		{
			get
			{
				if(IsDIA_DE_GRACIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dia_de_gracia;
			}
			set
			{
				_dia_de_graciaNull = false;
				_dia_de_gracia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIA_DE_GRACIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIA_DE_GRACIANull
		{
			get { return _dia_de_graciaNull; }
			set { _dia_de_graciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO_TEXTO</c> column value.</value>
		public string FECHA_VENCIMIENTO_TEXTO
		{
			get { return _fecha_vencimiento_texto; }
			set { _fecha_vencimiento_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO</c> column value.</value>
		public decimal CREDITO
		{
			get
			{
				if(IsCREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito;
			}
			set
			{
				_creditoNull = false;
				_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITONull
		{
			get { return _creditoNull; }
			set { _creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEBITO</c> column value.</value>
		public decimal DEBITO
		{
			get
			{
				if(IsDEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _debito;
			}
			set
			{
				_debitoNull = false;
				_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEBITONull
		{
			get { return _debitoNull; }
			set { _debitoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get
			{
				if(IsCTACTE_VALOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_valor_id;
			}
			set
			{
				_ctacte_valor_idNull = false;
				_ctacte_valor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_VALOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_VALOR_IDNull
		{
			get { return _ctacte_valor_idNull; }
			set { _ctacte_valor_idNull = value; }
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
		/// Gets or sets the <c>FACTURA_CLIENTE_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_TIPO</c> column value.</value>
		public string FACTURA_CLIENTE_TIPO
		{
			get { return _factura_cliente_tipo; }
			set { _factura_cliente_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAGO_CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAGO_CONFIRMADO</c> column value.</value>
		public string PAGO_CONFIRMADO
		{
			get { return _pago_confirmado; }
			set { _pago_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@CTACTE_PAGOS_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PAGOS_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PAGOS_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_RECARGO_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_RECARGO_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_RECARGO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(IsCOTIZACION_MONEDANull ? (object)"<NULL>" : COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CUOTA=");
			dynStr.Append(CUOTA);
			dynStr.Append("@CBA@CUOTA_NUMERO=");
			dynStr.Append(IsCUOTA_NUMERONull ? (object)"<NULL>" : CUOTA_NUMERO);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@DIA_DE_GRACIA=");
			dynStr.Append(IsDIA_DE_GRACIANull ? (object)"<NULL>" : DIA_DE_GRACIA);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_TEXTO=");
			dynStr.Append(FECHA_VENCIMIENTO_TEXTO);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(IsCREDITONull ? (object)"<NULL>" : CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(IsDEBITONull ? (object)"<NULL>" : DEBITO);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(IsCTACTE_VALOR_IDNull ? (object)"<NULL>" : CTACTE_VALOR_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FACTURA_CLIENTE_TIPO=");
			dynStr.Append(FACTURA_CLIENTE_TIPO);
			dynStr.Append("@CBA@PAGO_CONFIRMADO=");
			dynStr.Append(PAGO_CONFIRMADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGOS_PERS_DOC_INF_COMPRow_Base class
} // End of namespace
