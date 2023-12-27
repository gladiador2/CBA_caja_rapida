// <fileinfo name="CTB_REVALUOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTB_REVALUOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_REVALUOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_REVALUOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _activo_id;
		private decimal _activo_rubro_id;
		private bool _activo_rubro_idNull = true;
		private string _activo_rubro_nombre;
		private decimal _caso_relacionado_id;
		private bool _caso_relacionado_idNull = true;
		private string _activo_codigo;
		private string _activo_nombre;
		private System.DateTime _fecha_compra;
		private bool _fecha_compraNull = true;
		private string _sucursal_nombre;
		private System.DateTime _fecha_revaluo;
		private decimal _coeficiente;
		private decimal _ctb_revaluo_anterior_id;
		private bool _ctb_revaluo_anterior_idNull = true;
		private string _estado;
		private decimal _vida_util;
		private decimal _valor_fiscal_rev;
		private decimal _valor_fiscal_net_cierre;
		private decimal _cuota_fiscal_depr_anual;
		private decimal _deprec_fiscal_acum;
		private decimal _vida_util_restante;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private decimal _cotizacion;
		private decimal _monto;
		private decimal _revaluo;
		private bool _revaluoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_REVALUOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTB_REVALUOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_REVALUOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsACTIVO_RUBRO_IDNull != original.IsACTIVO_RUBRO_IDNull) return true;
			if (!this.IsACTIVO_RUBRO_IDNull && !original.IsACTIVO_RUBRO_IDNull)
				if (this.ACTIVO_RUBRO_ID != original.ACTIVO_RUBRO_ID) return true;
			if (this.ACTIVO_RUBRO_NOMBRE != original.ACTIVO_RUBRO_NOMBRE) return true;
			if (this.IsCASO_RELACIONADO_IDNull != original.IsCASO_RELACIONADO_IDNull) return true;
			if (!this.IsCASO_RELACIONADO_IDNull && !original.IsCASO_RELACIONADO_IDNull)
				if (this.CASO_RELACIONADO_ID != original.CASO_RELACIONADO_ID) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			if (this.ACTIVO_NOMBRE != original.ACTIVO_NOMBRE) return true;
			if (this.IsFECHA_COMPRANull != original.IsFECHA_COMPRANull) return true;
			if (!this.IsFECHA_COMPRANull && !original.IsFECHA_COMPRANull)
				if (this.FECHA_COMPRA != original.FECHA_COMPRA) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.FECHA_REVALUO != original.FECHA_REVALUO) return true;
			if (this.COEFICIENTE != original.COEFICIENTE) return true;
			if (this.IsCTB_REVALUO_ANTERIOR_IDNull != original.IsCTB_REVALUO_ANTERIOR_IDNull) return true;
			if (!this.IsCTB_REVALUO_ANTERIOR_IDNull && !original.IsCTB_REVALUO_ANTERIOR_IDNull)
				if (this.CTB_REVALUO_ANTERIOR_ID != original.CTB_REVALUO_ANTERIOR_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.VIDA_UTIL != original.VIDA_UTIL) return true;
			if (this.VALOR_FISCAL_REV != original.VALOR_FISCAL_REV) return true;
			if (this.VALOR_FISCAL_NET_CIERRE != original.VALOR_FISCAL_NET_CIERRE) return true;
			if (this.CUOTA_FISCAL_DEPR_ANUAL != original.CUOTA_FISCAL_DEPR_ANUAL) return true;
			if (this.DEPREC_FISCAL_ACUM != original.DEPREC_FISCAL_ACUM) return true;
			if (this.VIDA_UTIL_RESTANTE != original.VIDA_UTIL_RESTANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.IsREVALUONull != original.IsREVALUONull) return true;
			if (!this.IsREVALUONull && !original.IsREVALUONull)
				if (this.REVALUO != original.REVALUO) return true;
			
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
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get { return _activo_id; }
			set { _activo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_RUBRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_RUBRO_ID</c> column value.</value>
		public decimal ACTIVO_RUBRO_ID
		{
			get
			{
				if(IsACTIVO_RUBRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_rubro_id;
			}
			set
			{
				_activo_rubro_idNull = false;
				_activo_rubro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_RUBRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_RUBRO_IDNull
		{
			get { return _activo_rubro_idNull; }
			set { _activo_rubro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_RUBRO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_RUBRO_NOMBRE</c> column value.</value>
		public string ACTIVO_RUBRO_NOMBRE
		{
			get { return _activo_rubro_nombre; }
			set { _activo_rubro_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_RELACIONADO_ID</c> column value.</value>
		public decimal CASO_RELACIONADO_ID
		{
			get
			{
				if(IsCASO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_relacionado_id;
			}
			set
			{
				_caso_relacionado_idNull = false;
				_caso_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_RELACIONADO_IDNull
		{
			get { return _caso_relacionado_idNull; }
			set { _caso_relacionado_idNull = value; }
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
		/// Gets or sets the <c>ACTIVO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_NOMBRE</c> column value.</value>
		public string ACTIVO_NOMBRE
		{
			get { return _activo_nombre; }
			set { _activo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_COMPRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_COMPRA</c> column value.</value>
		public System.DateTime FECHA_COMPRA
		{
			get
			{
				if(IsFECHA_COMPRANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_compra;
			}
			set
			{
				_fecha_compraNull = false;
				_fecha_compra = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_COMPRA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_COMPRANull
		{
			get { return _fecha_compraNull; }
			set { _fecha_compraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_REVALUO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_REVALUO</c> column value.</value>
		public System.DateTime FECHA_REVALUO
		{
			get { return _fecha_revaluo; }
			set { _fecha_revaluo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COEFICIENTE</c> column value.
		/// </summary>
		/// <value>The <c>COEFICIENTE</c> column value.</value>
		public decimal COEFICIENTE
		{
			get { return _coeficiente; }
			set { _coeficiente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_REVALUO_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</value>
		public decimal CTB_REVALUO_ANTERIOR_ID
		{
			get
			{
				if(IsCTB_REVALUO_ANTERIOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_revaluo_anterior_id;
			}
			set
			{
				_ctb_revaluo_anterior_idNull = false;
				_ctb_revaluo_anterior_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_REVALUO_ANTERIOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_REVALUO_ANTERIOR_IDNull
		{
			get { return _ctb_revaluo_anterior_idNull; }
			set { _ctb_revaluo_anterior_idNull = value; }
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
		/// Gets or sets the <c>VIDA_UTIL</c> column value.
		/// </summary>
		/// <value>The <c>VIDA_UTIL</c> column value.</value>
		public decimal VIDA_UTIL
		{
			get { return _vida_util; }
			set { _vida_util = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_FISCAL_REV</c> column value.
		/// </summary>
		/// <value>The <c>VALOR_FISCAL_REV</c> column value.</value>
		public decimal VALOR_FISCAL_REV
		{
			get { return _valor_fiscal_rev; }
			set { _valor_fiscal_rev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_FISCAL_NET_CIERRE</c> column value.
		/// </summary>
		/// <value>The <c>VALOR_FISCAL_NET_CIERRE</c> column value.</value>
		public decimal VALOR_FISCAL_NET_CIERRE
		{
			get { return _valor_fiscal_net_cierre; }
			set { _valor_fiscal_net_cierre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUOTA_FISCAL_DEPR_ANUAL</c> column value.
		/// </summary>
		/// <value>The <c>CUOTA_FISCAL_DEPR_ANUAL</c> column value.</value>
		public decimal CUOTA_FISCAL_DEPR_ANUAL
		{
			get { return _cuota_fiscal_depr_anual; }
			set { _cuota_fiscal_depr_anual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPREC_FISCAL_ACUM</c> column value.
		/// </summary>
		/// <value>The <c>DEPREC_FISCAL_ACUM</c> column value.</value>
		public decimal DEPREC_FISCAL_ACUM
		{
			get { return _deprec_fiscal_acum; }
			set { _deprec_fiscal_acum = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VIDA_UTIL_RESTANTE</c> column value.
		/// </summary>
		/// <value>The <c>VIDA_UTIL_RESTANTE</c> column value.</value>
		public decimal VIDA_UTIL_RESTANTE
		{
			get { return _vida_util_restante; }
			set { _vida_util_restante = value; }
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
		/// Gets or sets the <c>REVALUO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REVALUO</c> column value.</value>
		public decimal REVALUO
		{
			get
			{
				if(IsREVALUONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _revaluo;
			}
			set
			{
				_revaluoNull = false;
				_revaluo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REVALUO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREVALUONull
		{
			get { return _revaluoNull; }
			set { _revaluoNull = value; }
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
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(ACTIVO_ID);
			dynStr.Append("@CBA@ACTIVO_RUBRO_ID=");
			dynStr.Append(IsACTIVO_RUBRO_IDNull ? (object)"<NULL>" : ACTIVO_RUBRO_ID);
			dynStr.Append("@CBA@ACTIVO_RUBRO_NOMBRE=");
			dynStr.Append(ACTIVO_RUBRO_NOMBRE);
			dynStr.Append("@CBA@CASO_RELACIONADO_ID=");
			dynStr.Append(IsCASO_RELACIONADO_IDNull ? (object)"<NULL>" : CASO_RELACIONADO_ID);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			dynStr.Append("@CBA@ACTIVO_NOMBRE=");
			dynStr.Append(ACTIVO_NOMBRE);
			dynStr.Append("@CBA@FECHA_COMPRA=");
			dynStr.Append(IsFECHA_COMPRANull ? (object)"<NULL>" : FECHA_COMPRA);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@FECHA_REVALUO=");
			dynStr.Append(FECHA_REVALUO);
			dynStr.Append("@CBA@COEFICIENTE=");
			dynStr.Append(COEFICIENTE);
			dynStr.Append("@CBA@CTB_REVALUO_ANTERIOR_ID=");
			dynStr.Append(IsCTB_REVALUO_ANTERIOR_IDNull ? (object)"<NULL>" : CTB_REVALUO_ANTERIOR_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@VIDA_UTIL=");
			dynStr.Append(VIDA_UTIL);
			dynStr.Append("@CBA@VALOR_FISCAL_REV=");
			dynStr.Append(VALOR_FISCAL_REV);
			dynStr.Append("@CBA@VALOR_FISCAL_NET_CIERRE=");
			dynStr.Append(VALOR_FISCAL_NET_CIERRE);
			dynStr.Append("@CBA@CUOTA_FISCAL_DEPR_ANUAL=");
			dynStr.Append(CUOTA_FISCAL_DEPR_ANUAL);
			dynStr.Append("@CBA@DEPREC_FISCAL_ACUM=");
			dynStr.Append(DEPREC_FISCAL_ACUM);
			dynStr.Append("@CBA@VIDA_UTIL_RESTANTE=");
			dynStr.Append(VIDA_UTIL_RESTANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@REVALUO=");
			dynStr.Append(IsREVALUONull ? (object)"<NULL>" : REVALUO);
			return dynStr.ToString();
		}
	} // End of CTB_REVALUOS_INFO_COMPLETARow_Base class
} // End of namespace
