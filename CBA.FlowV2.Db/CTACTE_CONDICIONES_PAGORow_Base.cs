// <fileinfo name="CTACTE_CONDICIONES_PAGORow_Base.cs">
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
	/// The base class for <see cref="CTACTE_CONDICIONES_PAGORow"/> that 
	/// represents a record in the <c>CTACTE_CONDICIONES_PAGO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_CONDICIONES_PAGORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CONDICIONES_PAGORow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private decimal _ctacte_valor_id;
		private decimal _cantidad_pagos;
		private string _estado;
		private string _tipo_calculo;
		private string _tipo_condicion_pago;
		private string _es_compra;
		private string _es_venta;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONDICIONES_PAGORow_Base"/> class.
		/// </summary>
		public CTACTE_CONDICIONES_PAGORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_CONDICIONES_PAGORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.CTACTE_VALOR_ID != original.CTACTE_VALOR_ID) return true;
			if (this.CANTIDAD_PAGOS != original.CANTIDAD_PAGOS) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO_CALCULO != original.TIPO_CALCULO) return true;
			if (this.TIPO_CONDICION_PAGO != original.TIPO_CONDICION_PAGO) return true;
			if (this.ES_COMPRA != original.ES_COMPRA) return true;
			if (this.ES_VENTA != original.ES_VENTA) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
		/// Gets or sets the <c>CANTIDAD_PAGOS</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_PAGOS</c> column value.</value>
		public decimal CANTIDAD_PAGOS
		{
			get { return _cantidad_pagos; }
			set { _cantidad_pagos = value; }
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
		/// Gets or sets the <c>TIPO_CALCULO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CALCULO</c> column value.</value>
		public string TIPO_CALCULO
		{
			get { return _tipo_calculo; }
			set { _tipo_calculo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CONDICION_PAGO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_CONDICION_PAGO</c> column value.</value>
		public string TIPO_CONDICION_PAGO
		{
			get { return _tipo_condicion_pago; }
			set { _tipo_condicion_pago = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COMPRA</c> column value.
		/// </summary>
		/// <value>The <c>ES_COMPRA</c> column value.</value>
		public string ES_COMPRA
		{
			get { return _es_compra; }
			set { _es_compra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_VENTA</c> column value.
		/// </summary>
		/// <value>The <c>ES_VENTA</c> column value.</value>
		public string ES_VENTA
		{
			get { return _es_venta; }
			set { _es_venta = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@CTACTE_VALOR_ID=");
			dynStr.Append(CTACTE_VALOR_ID);
			dynStr.Append("@CBA@CANTIDAD_PAGOS=");
			dynStr.Append(CANTIDAD_PAGOS);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_CALCULO=");
			dynStr.Append(TIPO_CALCULO);
			dynStr.Append("@CBA@TIPO_CONDICION_PAGO=");
			dynStr.Append(TIPO_CONDICION_PAGO);
			dynStr.Append("@CBA@ES_COMPRA=");
			dynStr.Append(ES_COMPRA);
			dynStr.Append("@CBA@ES_VENTA=");
			dynStr.Append(ES_VENTA);
			return dynStr.ToString();
		}
	} // End of CTACTE_CONDICIONES_PAGORow_Base class
} // End of namespace
