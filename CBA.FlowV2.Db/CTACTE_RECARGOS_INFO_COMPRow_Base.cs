// <fileinfo name="CTACTE_RECARGOS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_RECARGOS_INFO_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_RECARGOS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_RECARGOS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RECARGOS_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _tipo_recargo;
		private decimal _caso_origen_id;
		private decimal _ctacte_pago_persona_doc_id;
		private bool _ctacte_pago_persona_doc_idNull = true;
		private decimal _ctacte_pago_persona_recargo_id;
		private bool _ctacte_pago_persona_recargo_idNull = true;
		private decimal _aplicacion_documento_doc_id;
		private bool _aplicacion_documento_doc_idNull = true;
		private decimal _aplicacion_documento_doc_re_id;
		private bool _aplicacion_documento_doc_re_idNull = true;
		private decimal _sucursal_id;
		private string _sucursal_nombre;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;
		private decimal _persona_id;
		private string _persona_nombre;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private decimal _moneda_cantidad_decimales;
		private decimal _cotizacion;
		private decimal _monto;
		private decimal _impuesto_id;
		private string _impuesto_nombre;
		private decimal _impuesto_porcentaje;
		private System.DateTime _fecha;
		private decimal _caso_factura_id;
		private bool _caso_factura_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RECARGOS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_RECARGOS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_RECARGOS_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_RECARGO != original.TIPO_RECARGO) return true;
			if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DOC_IDNull != original.IsCTACTE_PAGO_PERSONA_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DOC_IDNull && !original.IsCTACTE_PAGO_PERSONA_DOC_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DOC_ID != original.CTACTE_PAGO_PERSONA_DOC_ID) return true;
			if (this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull != original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull && !original.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull)
				if (this.CTACTE_PAGO_PERSONA_RECARGO_ID != original.CTACTE_PAGO_PERSONA_RECARGO_ID) return true;
			if (this.IsAPLICACION_DOCUMENTO_DOC_IDNull != original.IsAPLICACION_DOCUMENTO_DOC_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTO_DOC_IDNull && !original.IsAPLICACION_DOCUMENTO_DOC_IDNull)
				if (this.APLICACION_DOCUMENTO_DOC_ID != original.APLICACION_DOCUMENTO_DOC_ID) return true;
			if (this.IsAPLICACION_DOCUMENTO_DOC_RE_IDNull != original.IsAPLICACION_DOCUMENTO_DOC_RE_IDNull) return true;
			if (!this.IsAPLICACION_DOCUMENTO_DOC_RE_IDNull && !original.IsAPLICACION_DOCUMENTO_DOC_RE_IDNull)
				if (this.APLICACION_DOCUMENTO_DOC_RE_ID != original.APLICACION_DOCUMENTO_DOC_RE_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IMPUESTO_NOMBRE != original.IMPUESTO_NOMBRE) return true;
			if (this.IMPUESTO_PORCENTAJE != original.IMPUESTO_PORCENTAJE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsCASO_FACTURA_IDNull != original.IsCASO_FACTURA_IDNull) return true;
			if (!this.IsCASO_FACTURA_IDNull && !original.IsCASO_FACTURA_IDNull)
				if (this.CASO_FACTURA_ID != original.CASO_FACTURA_ID) return true;
			
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
		/// Gets or sets the <c>TIPO_RECARGO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_RECARGO</c> column value.</value>
		public decimal TIPO_RECARGO
		{
			get { return _tipo_recargo; }
			set { _tipo_recargo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get { return _caso_origen_id; }
			set { _caso_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_doc_id;
			}
			set
			{
				_ctacte_pago_persona_doc_idNull = false;
				_ctacte_pago_persona_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_DOC_IDNull
		{
			get { return _ctacte_pago_persona_doc_idNull; }
			set { _ctacte_pago_persona_doc_idNull = value; }
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
		/// Gets or sets the <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTO_DOC_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTO_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documento_doc_id;
			}
			set
			{
				_aplicacion_documento_doc_idNull = false;
				_aplicacion_documento_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTO_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTO_DOC_IDNull
		{
			get { return _aplicacion_documento_doc_idNull; }
			set { _aplicacion_documento_doc_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</value>
		public decimal APLICACION_DOCUMENTO_DOC_RE_ID
		{
			get
			{
				if(IsAPLICACION_DOCUMENTO_DOC_RE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _aplicacion_documento_doc_re_id;
			}
			set
			{
				_aplicacion_documento_doc_re_idNull = false;
				_aplicacion_documento_doc_re_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="APLICACION_DOCUMENTO_DOC_RE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAPLICACION_DOCUMENTO_DOC_RE_IDNull
		{
			get { return _aplicacion_documento_doc_re_idNull; }
			set { _aplicacion_documento_doc_re_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
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
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_NOMBRE</c> column value.</value>
		public string IMPUESTO_NOMBRE
		{
			get { return _impuesto_nombre; }
			set { _impuesto_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_PORCENTAJE</c> column value.</value>
		public decimal IMPUESTO_PORCENTAJE
		{
			get { return _impuesto_porcentaje; }
			set { _impuesto_porcentaje = value; }
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
		/// Gets or sets the <c>CASO_FACTURA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FACTURA_ID</c> column value.</value>
		public decimal CASO_FACTURA_ID
		{
			get
			{
				if(IsCASO_FACTURA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_factura_id;
			}
			set
			{
				_caso_factura_idNull = false;
				_caso_factura_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_FACTURA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_FACTURA_IDNull
		{
			get { return _caso_factura_idNull; }
			set { _caso_factura_idNull = value; }
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
			dynStr.Append("@CBA@TIPO_RECARGO=");
			dynStr.Append(TIPO_RECARGO);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(CASO_ORIGEN_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DOC_ID);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_RECARGO_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_RECARGO_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_RECARGO_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTO_DOC_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTO_DOC_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTO_DOC_ID);
			dynStr.Append("@CBA@APLICACION_DOCUMENTO_DOC_RE_ID=");
			dynStr.Append(IsAPLICACION_DOCUMENTO_DOC_RE_IDNull ? (object)"<NULL>" : APLICACION_DOCUMENTO_DOC_RE_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTO_NOMBRE=");
			dynStr.Append(IMPUESTO_NOMBRE);
			dynStr.Append("@CBA@IMPUESTO_PORCENTAJE=");
			dynStr.Append(IMPUESTO_PORCENTAJE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CASO_FACTURA_ID=");
			dynStr.Append(IsCASO_FACTURA_IDNull ? (object)"<NULL>" : CASO_FACTURA_ID);
			return dynStr.ToString();
		}
	} // End of CTACTE_RECARGOS_INFO_COMPRow_Base class
} // End of namespace
