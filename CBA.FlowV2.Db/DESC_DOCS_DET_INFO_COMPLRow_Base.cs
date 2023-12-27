// <fileinfo name="DESC_DOCS_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="DESC_DOCS_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>DESC_DOCS_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESC_DOCS_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESC_DOCS_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _descuento_documento_id;
		private decimal _ctacte_valor_id;
		private string _ctacte_valor_nombre;
		private decimal _monto;
		private decimal _ctacte_cheque_recibido_id;
		private bool _ctacte_cheque_recibido_idNull = true;
		private string _cheque_banco_nombre;
		private string _cheque_banco_abreviatura;
		private string _cheque_numero;
		private string _cheque_banco_codigo;
		private decimal _ctacte_pagare_det_id;
		private bool _ctacte_pagare_det_idNull = true;
		private System.DateTime _fecha_vencimiento;
		private decimal _porcentaje_comision;
		private decimal _monto_comision;
		private string _observacion;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private string _observacion_valor;
		private decimal _monto_impuesto;
		private decimal _cheque_estado_id;
		private bool _cheque_estado_idNull = true;
		private string _cheque_estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESC_DOCS_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public DESC_DOCS_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESC_DOCS_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCUENTO_DOCUMENTO_ID != original.DESCUENTO_DOCUMENTO_ID) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CTACTE_VALOR_NOMBRE != original.CTACTE_VALOR_NOMBRE) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsCTACTE_CHEQUE_RECIBIDO_IDNull != original.IsCTACTE_CHEQUE_RECIBIDO_IDNull) return true;
			if (!this.IsCTACTE_CHEQUE_RECIBIDO_IDNull && !original.IsCTACTE_CHEQUE_RECIBIDO_IDNull)
				if (this.CTACTE_CHEQUE_RECIBIDO_ID != original.CTACTE_CHEQUE_RECIBIDO_ID) return true;
			if (this.CHEQUE_BANCO_NOMBRE != original.CHEQUE_BANCO_NOMBRE) return true;
			if (this.CHEQUE_BANCO_ABREVIATURA != original.CHEQUE_BANCO_ABREVIATURA) return true;
			if (this.CHEQUE_NUMERO != original.CHEQUE_NUMERO) return true;
			if (this.CHEQUE_BANCO_CODIGO != original.CHEQUE_BANCO_CODIGO) return true;
			if (this.IsCTACTE_PAGARE_DET_IDNull != original.IsCTACTE_PAGARE_DET_IDNull) return true;
			if (!this.IsCTACTE_PAGARE_DET_IDNull && !original.IsCTACTE_PAGARE_DET_IDNull)
				if (this.CTACTE_PAGARE_DET_ID != original.CTACTE_PAGARE_DET_ID) return true;
			if (this.FECHA_VENCIMIENTO != original.FECHA_VENCIMIENTO) return true;
			if (this.PORCENTAJE_COMISION != original.PORCENTAJE_COMISION) return true;
			if (this.MONTO_COMISION != original.MONTO_COMISION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.OBSERVACION_VALOR != original.OBSERVACION_VALOR) return true;
			if (this.MONTO_IMPUESTO != original.MONTO_IMPUESTO) return true;
			if (this.IsCHEQUE_ESTADO_IDNull != original.IsCHEQUE_ESTADO_IDNull) return true;
			if (!this.IsCHEQUE_ESTADO_IDNull && !original.IsCHEQUE_ESTADO_IDNull)
				if (this.CHEQUE_ESTADO_ID != original.CHEQUE_ESTADO_ID) return true;
			if (this.CHEQUE_ESTADO != original.CHEQUE_ESTADO) return true;
			
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
		/// Gets or sets the <c>DESCUENTO_DOCUMENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</value>
		public decimal DESCUENTO_DOCUMENTO_ID
		{
			get { return _descuento_documento_id; }
			set { _descuento_documento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_ID</c> column value.</value>
		public decimal CTACTE_VALOR_ID
		{
			get { return _ctacte_valor_id; }
			set { _ctacte_valor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_VALOR_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_VALOR_NOMBRE</c> column value.</value>
		public string CTACTE_VALOR_NOMBRE
		{
			get { return _ctacte_valor_nombre; }
			set { _ctacte_valor_nombre = value; }
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
		/// Gets or sets the <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</value>
		public decimal CTACTE_CHEQUE_RECIBIDO_ID
		{
			get
			{
				if(IsCTACTE_CHEQUE_RECIBIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_cheque_recibido_id;
			}
			set
			{
				_ctacte_cheque_recibido_idNull = false;
				_ctacte_cheque_recibido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CHEQUE_RECIBIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CHEQUE_RECIBIDO_IDNull
		{
			get { return _ctacte_cheque_recibido_idNull; }
			set { _ctacte_cheque_recibido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_BANCO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_BANCO_NOMBRE</c> column value.</value>
		public string CHEQUE_BANCO_NOMBRE
		{
			get { return _cheque_banco_nombre; }
			set { _cheque_banco_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_BANCO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_BANCO_ABREVIATURA</c> column value.</value>
		public string CHEQUE_BANCO_ABREVIATURA
		{
			get { return _cheque_banco_abreviatura; }
			set { _cheque_banco_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_NUMERO</c> column value.</value>
		public string CHEQUE_NUMERO
		{
			get { return _cheque_numero; }
			set { _cheque_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_BANCO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_BANCO_CODIGO</c> column value.</value>
		public string CHEQUE_BANCO_CODIGO
		{
			get { return _cheque_banco_codigo; }
			set { _cheque_banco_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGARE_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGARE_DET_ID</c> column value.</value>
		public decimal CTACTE_PAGARE_DET_ID
		{
			get
			{
				if(IsCTACTE_PAGARE_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pagare_det_id;
			}
			set
			{
				_ctacte_pagare_det_idNull = false;
				_ctacte_pagare_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGARE_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGARE_DET_IDNull
		{
			get { return _ctacte_pagare_det_idNull; }
			set { _ctacte_pagare_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO
		{
			get { return _fecha_vencimiento; }
			set { _fecha_vencimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION</c> column value.</value>
		public decimal PORCENTAJE_COMISION
		{
			get { return _porcentaje_comision; }
			set { _porcentaje_comision = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_COMISION</c> column value.</value>
		public decimal MONTO_COMISION
		{
			get { return _monto_comision; }
			set { _monto_comision = value; }
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
		/// Gets or sets the <c>OBSERVACION_VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_VALOR</c> column value.</value>
		public string OBSERVACION_VALOR
		{
			get { return _observacion_valor; }
			set { _observacion_valor = value; }
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
		/// Gets or sets the <c>CHEQUE_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_ESTADO_ID</c> column value.</value>
		public decimal CHEQUE_ESTADO_ID
		{
			get
			{
				if(IsCHEQUE_ESTADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cheque_estado_id;
			}
			set
			{
				_cheque_estado_idNull = false;
				_cheque_estado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHEQUE_ESTADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHEQUE_ESTADO_IDNull
		{
			get { return _cheque_estado_idNull; }
			set { _cheque_estado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHEQUE_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHEQUE_ESTADO</c> column value.</value>
		public string CHEQUE_ESTADO
		{
			get { return _cheque_estado; }
			set { _cheque_estado = value; }
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
			dynStr.Append("@CBA@DESCUENTO_DOCUMENTO_ID=");
			dynStr.Append(DESCUENTO_DOCUMENTO_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CTACTE_VALOR_NOMBRE=");
			dynStr.Append(CTACTE_VALOR_NOMBRE);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@CTACTE_CHEQUE_RECIBIDO_ID=");
			dynStr.Append(IsCTACTE_CHEQUE_RECIBIDO_IDNull ? (object)"<NULL>" : CTACTE_CHEQUE_RECIBIDO_ID);
			dynStr.Append("@CBA@CHEQUE_BANCO_NOMBRE=");
			dynStr.Append(CHEQUE_BANCO_NOMBRE);
			dynStr.Append("@CBA@CHEQUE_BANCO_ABREVIATURA=");
			dynStr.Append(CHEQUE_BANCO_ABREVIATURA);
			dynStr.Append("@CBA@CHEQUE_NUMERO=");
			dynStr.Append(CHEQUE_NUMERO);
			dynStr.Append("@CBA@CHEQUE_BANCO_CODIGO=");
			dynStr.Append(CHEQUE_BANCO_CODIGO);
			dynStr.Append("@CBA@CTACTE_PAGARE_DET_ID=");
			dynStr.Append(IsCTACTE_PAGARE_DET_IDNull ? (object)"<NULL>" : CTACTE_PAGARE_DET_ID);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO=");
			dynStr.Append(FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@PORCENTAJE_COMISION=");
			dynStr.Append(PORCENTAJE_COMISION);
			dynStr.Append("@CBA@MONTO_COMISION=");
			dynStr.Append(MONTO_COMISION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@OBSERVACION_VALOR=");
			dynStr.Append(OBSERVACION_VALOR);
			dynStr.Append("@CBA@MONTO_IMPUESTO=");
			dynStr.Append(MONTO_IMPUESTO);
			dynStr.Append("@CBA@CHEQUE_ESTADO_ID=");
			dynStr.Append(IsCHEQUE_ESTADO_IDNull ? (object)"<NULL>" : CHEQUE_ESTADO_ID);
			dynStr.Append("@CBA@CHEQUE_ESTADO=");
			dynStr.Append(CHEQUE_ESTADO);
			return dynStr.ToString();
		}
	} // End of DESC_DOCS_DET_INFO_COMPLRow_Base class
} // End of namespace
