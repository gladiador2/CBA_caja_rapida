// <fileinfo name="PLANES_FACT_ETAPAS_DET_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/> that 
	/// represents a record in the <c>PLANES_FACT_ETAPAS_DET_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANES_FACT_ETAPAS_DET_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _plan_facturacion_etapa_id;
		private decimal _articulo_id;
		private decimal _cantidad_embalada;
		private decimal _cantidad_unitaria;
		private decimal _monto_bruto;
		private bool _monto_brutoNull = true;
		private string _calcular_monto;
		private string _observacion;
		private string _unidad_medida_id;
		private string _articulo_codigo_empresa;
		private string _articulo_unidad_medida_id;
		private decimal _cantidad_por_caja;
		private decimal _impuesto_id;
		private string _articulo_para_venta;
		private string _impuesto_nombre;
		private decimal _impuesto_porcentaje;
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private string _activo_codigo;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANES_FACT_ETAPAS_DET_INFO_CRow_Base"/> class.
		/// </summary>
		public PLANES_FACT_ETAPAS_DET_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANES_FACT_ETAPAS_DET_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLAN_FACTURACION_ETAPA_ID != original.PLAN_FACTURACION_ETAPA_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.CANTIDAD_EMBALADA != original.CANTIDAD_EMBALADA) return true;
			if (this.CANTIDAD_UNITARIA != original.CANTIDAD_UNITARIA) return true;
			if (this.IsMONTO_BRUTONull != original.IsMONTO_BRUTONull) return true;
			if (!this.IsMONTO_BRUTONull && !original.IsMONTO_BRUTONull)
				if (this.MONTO_BRUTO != original.MONTO_BRUTO) return true;
			if (this.CALCULAR_MONTO != original.CALCULAR_MONTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.ARTICULO_CODIGO_EMPRESA != original.ARTICULO_CODIGO_EMPRESA) return true;
			if (this.ARTICULO_UNIDAD_MEDIDA_ID != original.ARTICULO_UNIDAD_MEDIDA_ID) return true;
			if (this.CANTIDAD_POR_CAJA != original.CANTIDAD_POR_CAJA) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.ARTICULO_PARA_VENTA != original.ARTICULO_PARA_VENTA) return true;
			if (this.IMPUESTO_NOMBRE != original.IMPUESTO_NOMBRE) return true;
			if (this.IMPUESTO_PORCENTAJE != original.IMPUESTO_PORCENTAJE) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			
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
		/// Gets or sets the <c>PLAN_FACTURACION_ETAPA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLAN_FACTURACION_ETAPA_ID</c> column value.</value>
		public decimal PLAN_FACTURACION_ETAPA_ID
		{
			get { return _plan_facturacion_etapa_id; }
			set { _plan_facturacion_etapa_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_EMBALADA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_EMBALADA</c> column value.</value>
		public decimal CANTIDAD_EMBALADA
		{
			get { return _cantidad_embalada; }
			set { _cantidad_embalada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA</c> column value.</value>
		public decimal CANTIDAD_UNITARIA
		{
			get { return _cantidad_unitaria; }
			set { _cantidad_unitaria = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BRUTO</c> column value.</value>
		public decimal MONTO_BRUTO
		{
			get
			{
				if(IsMONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bruto;
			}
			set
			{
				_monto_brutoNull = false;
				_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BRUTONull
		{
			get { return _monto_brutoNull; }
			set { _monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALCULAR_MONTO</c> column value.
		/// </summary>
		/// <value>The <c>CALCULAR_MONTO</c> column value.</value>
		public string CALCULAR_MONTO
		{
			get { return _calcular_monto; }
			set { _calcular_monto = value; }
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
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_CODIGO_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO_EMPRESA</c> column value.</value>
		public string ARTICULO_CODIGO_EMPRESA
		{
			get { return _articulo_codigo_empresa; }
			set { _articulo_codigo_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_UNIDAD_MEDIDA_ID</c> column value.</value>
		public string ARTICULO_UNIDAD_MEDIDA_ID
		{
			get { return _articulo_unidad_medida_id; }
			set { _articulo_unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_POR_CAJA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA
		{
			get { return _cantidad_por_caja; }
			set { _cantidad_por_caja = value; }
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
		/// Gets or sets the <c>ARTICULO_PARA_VENTA</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_PARA_VENTA</c> column value.</value>
		public string ARTICULO_PARA_VENTA
		{
			get { return _articulo_para_venta; }
			set { _articulo_para_venta = value; }
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
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get
			{
				if(IsACTIVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_id;
			}
			set
			{
				_activo_idNull = false;
				_activo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_IDNull
		{
			get { return _activo_idNull; }
			set { _activo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_CODIGO</c> column value.</value>
		public string ACTIVO_CODIGO
		{
			get { return _activo_codigo; }
			set { _activo_codigo = value; }
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
			dynStr.Append("@CBA@PLAN_FACTURACION_ETAPA_ID=");
			dynStr.Append(PLAN_FACTURACION_ETAPA_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD_EMBALADA=");
			dynStr.Append(CANTIDAD_EMBALADA);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA=");
			dynStr.Append(CANTIDAD_UNITARIA);
			dynStr.Append("@CBA@MONTO_BRUTO=");
			dynStr.Append(IsMONTO_BRUTONull ? (object)"<NULL>" : MONTO_BRUTO);
			dynStr.Append("@CBA@CALCULAR_MONTO=");
			dynStr.Append(CALCULAR_MONTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO_EMPRESA=");
			dynStr.Append(ARTICULO_CODIGO_EMPRESA);
			dynStr.Append("@CBA@ARTICULO_UNIDAD_MEDIDA_ID=");
			dynStr.Append(ARTICULO_UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA=");
			dynStr.Append(CANTIDAD_POR_CAJA);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@ARTICULO_PARA_VENTA=");
			dynStr.Append(ARTICULO_PARA_VENTA);
			dynStr.Append("@CBA@IMPUESTO_NOMBRE=");
			dynStr.Append(IMPUESTO_NOMBRE);
			dynStr.Append("@CBA@IMPUESTO_PORCENTAJE=");
			dynStr.Append(IMPUESTO_PORCENTAJE);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			return dynStr.ToString();
		}
	} // End of PLANES_FACT_ETAPAS_DET_INFO_CRow_Base class
} // End of namespace
