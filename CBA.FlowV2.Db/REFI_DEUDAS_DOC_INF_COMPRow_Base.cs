// <fileinfo name="REFI_DEUDAS_DOC_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="REFI_DEUDAS_DOC_INF_COMPRow"/> that 
	/// represents a record in the <c>REFI_DEUDAS_DOC_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REFI_DEUDAS_DOC_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REFI_DEUDAS_DOC_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _refinanciacion_deudas_id;
		private decimal _calendario_pagos_fc_cliente_id;
		private bool _calendario_pagos_fc_cliente_idNull = true;
		private decimal _monto_anterior;
		private decimal _importe;
		private decimal _moneda_id;
		private string _moneda_cadena_decimales;
		private decimal _moneda_cantidades_decimales;
		private string _moneda_simbolo;
		private decimal _cotizacion;
		private System.DateTime _vencimiento;
		private decimal _cantidad_cuotas;
		private decimal _cuota;
		private string _es_interes;

		/// <summary>
		/// Initializes a new instance of the <see cref="REFI_DEUDAS_DOC_INF_COMPRow_Base"/> class.
		/// </summary>
		public REFI_DEUDAS_DOC_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REFI_DEUDAS_DOC_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.REFINANCIACION_DEUDAS_ID != original.REFINANCIACION_DEUDAS_ID) return true;
			if (this.IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull != original.IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull) return true;
			if (!this.IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull && !original.IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull)
				if (this.CALENDARIO_PAGOS_FC_CLIENTE_ID != original.CALENDARIO_PAGOS_FC_CLIENTE_ID) return true;
			if (this.MONTO_ANTERIOR != original.MONTO_ANTERIOR) return true;
			if (this.IMPORTE != original.IMPORTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.MONEDA_CANTIDADES_DECIMALES != original.MONEDA_CANTIDADES_DECIMALES) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.VENCIMIENTO != original.VENCIMIENTO) return true;
			if (this.CANTIDAD_CUOTAS != original.CANTIDAD_CUOTAS) return true;
			if (this.CUOTA != original.CUOTA) return true;
			if (this.ES_INTERES != original.ES_INTERES) return true;
			
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
		/// Gets or sets the <c>REFINANCIACION_DEUDAS_ID</c> column value.
		/// </summary>
		/// <value>The <c>REFINANCIACION_DEUDAS_ID</c> column value.</value>
		public decimal REFINANCIACION_DEUDAS_ID
		{
			get { return _refinanciacion_deudas_id; }
			set { _refinanciacion_deudas_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</value>
		public decimal CALENDARIO_PAGOS_FC_CLIENTE_ID
		{
			get
			{
				if(IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calendario_pagos_fc_cliente_id;
			}
			set
			{
				_calendario_pagos_fc_cliente_idNull = false;
				_calendario_pagos_fc_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALENDARIO_PAGOS_FC_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull
		{
			get { return _calendario_pagos_fc_cliente_idNull; }
			set { _calendario_pagos_fc_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ANTERIOR</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ANTERIOR</c> column value.</value>
		public decimal MONTO_ANTERIOR
		{
			get { return _monto_anterior; }
			set { _monto_anterior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTE</c> column value.
		/// </summary>
		/// <value>The <c>IMPORTE</c> column value.</value>
		public decimal IMPORTE
		{
			get { return _importe; }
			set { _importe = value; }
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
		/// Gets or sets the <c>MONEDA_CANTIDADES_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDADES_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDADES_DECIMALES
		{
			get { return _moneda_cantidades_decimales; }
			set { _moneda_cantidades_decimales = value; }
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
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENCIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>VENCIMIENTO</c> column value.</value>
		public System.DateTime VENCIMIENTO
		{
			get { return _vencimiento; }
			set { _vencimiento = value; }
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
		/// Gets or sets the <c>CUOTA</c> column value.
		/// </summary>
		/// <value>The <c>CUOTA</c> column value.</value>
		public decimal CUOTA
		{
			get { return _cuota; }
			set { _cuota = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_INTERES</c> column value.
		/// </summary>
		/// <value>The <c>ES_INTERES</c> column value.</value>
		public string ES_INTERES
		{
			get { return _es_interes; }
			set { _es_interes = value; }
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
			dynStr.Append("@CBA@REFINANCIACION_DEUDAS_ID=");
			dynStr.Append(REFINANCIACION_DEUDAS_ID);
			dynStr.Append("@CBA@CALENDARIO_PAGOS_FC_CLIENTE_ID=");
			dynStr.Append(IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull ? (object)"<NULL>" : CALENDARIO_PAGOS_FC_CLIENTE_ID);
			dynStr.Append("@CBA@MONTO_ANTERIOR=");
			dynStr.Append(MONTO_ANTERIOR);
			dynStr.Append("@CBA@IMPORTE=");
			dynStr.Append(IMPORTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CANTIDADES_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDADES_DECIMALES);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@VENCIMIENTO=");
			dynStr.Append(VENCIMIENTO);
			dynStr.Append("@CBA@CANTIDAD_CUOTAS=");
			dynStr.Append(CANTIDAD_CUOTAS);
			dynStr.Append("@CBA@CUOTA=");
			dynStr.Append(CUOTA);
			dynStr.Append("@CBA@ES_INTERES=");
			dynStr.Append(ES_INTERES);
			return dynStr.ToString();
		}
	} // End of REFI_DEUDAS_DOC_INF_COMPRow_Base class
} // End of namespace
