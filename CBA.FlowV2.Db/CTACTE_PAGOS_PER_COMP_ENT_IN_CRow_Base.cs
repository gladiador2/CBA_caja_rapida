// <fileinfo name="CTACTE_PAGOS_PER_COMP_ENT_IN_CRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PER_COMP_ENT_IN_CRow"/> that 
	/// represents a record in the <c>CTACTE_PAGOS_PER_COMP_ENT_IN_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PAGOS_PER_COMP_ENT_IN_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PER_COMP_ENT_IN_CRow_Base
	{
		private decimal _id;
		private decimal _ctacte_pagos_persona_id;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _ctacte_pago_persona_recargo_id;
		private bool _ctacte_pago_persona_recargo_idNull = true;
		private decimal _ctacte_pagos_persona_doc_id;
		private bool _ctacte_pagos_persona_doc_idNull = true;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private string _observacion;
		private string _estado;
		private System.DateTime _fecha_creacion;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _cuota;
		private System.DateTime _fecha_vencimiento;
		private bool _fecha_vencimientoNull = true;
		private string _fecha_vencimiento_texto;
		private decimal _credito;
		private bool _creditoNull = true;
		private decimal _debito;
		private bool _debitoNull = true;
		private string _factura_cliente_tipo;
		private string _pago_confirmado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PER_COMP_ENT_IN_CRow_Base"/> class.
		/// </summary>
		public CTACTE_PAGOS_PER_COMP_ENT_IN_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PAGOS_PER_COMP_ENT_IN_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTACTE_PAGOS_PERSONA_ID != original.CTACTE_PAGOS_PERSONA_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull != original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull && !original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
				if (this.CTACTE_PAGO_PERSONA_RECARGO_ID != original.CTACTE_PAGO_PERSONA_RECARGO_ID) return true;
			if (this.IsCTACTE_PAGOS_PERSONA_DOC_IDNull != original.IsCTACTE_PAGOS_PERSONA_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGOS_PERSONA_DOC_IDNull && !original.IsCTACTE_PAGOS_PERSONA_DOC_IDNull)
				if (this.CTACTE_PAGOS_PERSONA_DOC_ID != original.CTACTE_PAGOS_PERSONA_DOC_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CUOTA != original.CUOTA) return true;
			if (this.IsFECHA_VENCIMIENTONull != original.IsFECHA_VENCIMIENTONull) return true;
			if (!this.IsFECHA_VENCIMIENTONull && !original.IsFECHA_VENCIMIENTONull)
				if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.FECHA_VENCIMIENTO_TEXTO != original.FECHA_VENCIMIENTO_TEXTO) return true;
			if (this.IsCREDITONull != original.IsCREDITONull) return true;
			if (!this.IsCREDITONull && !original.IsCREDITONull)
				if (this.CREDITO != original.CREDITO) return true;
			if (this.IsDEBITONull != original.IsDEBITONull) return true;
			if (!this.IsDEBITONull && !original.IsDEBITONull)
				if (this.DEBITO != original.DEBITO) return true;
			if (this.FACTURA_CLIENTE_TIPO != original.FACTURA_CLIENTE_TIPO) return true;
			if (this.PAGO_CONFIRMADO != original.PAGO_CONFIRMADO) return true;
			
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
		/// Gets or sets the <c>CTACTE_PAGOS_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PAGOS_PERSONA_ID
		{
			get { return _ctacte_pagos_persona_id; }
			set { _ctacte_pagos_persona_id = value; }
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
		/// Gets or sets the <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGOS_PERSONA_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGOS_PERSONA_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagos_persona_doc_id;
			}
			set
			{
				_ctacte_pagos_persona_doc_idNull = false;
				_ctacte_pagos_persona_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGOS_PERSONA_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGOS_PERSONA_DOC_IDNull
		{
			get { return _ctacte_pagos_persona_doc_idNull; }
			set { _ctacte_pagos_persona_doc_idNull = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// </summary>
		/// <value>The <c>PAGO_CONFIRMADO</c> column value.</value>
		public string PAGO_CONFIRMADO
		{
			get { return _pago_confirmado; }
			set { _pago_confirmado = value; }
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
			dynStr.Append("@CBA@CTACTE_PAGOS_PERSONA_ID=");
			dynStr.Append(CTACTE_PAGOS_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_RECARGO_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_RECARGO_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_RECARGO_ID);
			dynStr.Append("@CBA@CTACTE_PAGOS_PERSONA_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGOS_PERSONA_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGOS_PERSONA_DOC_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@CUOTA=");
			dynStr.Append(CUOTA);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(IsFECHA_VENCIMIENTONull ? (object)"<NULL>" : FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_TEXTO=");
			dynStr.Append(FECHA_VENCIMIENTO_TEXTO);
			dynStr.Append("@CBA@CREDITO=");
			dynStr.Append(IsCREDITONull ? (object)"<NULL>" : CREDITO);
			dynStr.Append("@CBA@DEBITO=");
			dynStr.Append(IsDEBITONull ? (object)"<NULL>" : DEBITO);
			dynStr.Append("@CBA@FACTURA_CLIENTE_TIPO=");
			dynStr.Append(FACTURA_CLIENTE_TIPO);
			dynStr.Append("@CBA@PAGO_CONFIRMADO=");
			dynStr.Append(PAGO_CONFIRMADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PAGOS_PER_COMP_ENT_IN_CRow_Base class
} // End of namespace
