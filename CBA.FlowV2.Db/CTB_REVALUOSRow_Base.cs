// <fileinfo name="CTB_REVALUOSRow_Base.cs">
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
	/// The base class for <see cref="CTB_REVALUOSRow"/> that 
	/// represents a record in the <c>CTB_REVALUOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_REVALUOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_REVALUOSRow_Base
	{
		private decimal _id;
		private decimal _activo_id;
		private System.DateTime _fecha_revaluo;
		private decimal _coeficiente;
		private decimal _ctb_revaluo_anterior_id;
		private bool _ctb_revaluo_anterior_idNull = true;
		private string _estado;
		private decimal _vida_util;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _monto;
		private decimal _valor_fiscal_rev;
		private decimal _valor_fiscal_net_cierre;
		private decimal _cuota_fiscal_depr_anual;
		private decimal _deprec_fiscal_acum;
		private decimal _vida_util_restante;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_REVALUOSRow_Base"/> class.
		/// </summary>
		public CTB_REVALUOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_REVALUOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.FECHA_REVALUO != original.FECHA_REVALUO) return true;
			if (this.COEFICIENTE != original.COEFICIENTE) return true;
			if (this.IsCTB_REVALUO_ANTERIOR_IDNull != original.IsCTB_REVALUO_ANTERIOR_IDNull) return true;
			if (!this.IsCTB_REVALUO_ANTERIOR_IDNull && !original.IsCTB_REVALUO_ANTERIOR_IDNull)
				if (this.CTB_REVALUO_ANTERIOR_ID != original.CTB_REVALUO_ANTERIOR_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.VIDA_UTIL != original.VIDA_UTIL) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.VALOR_FISCAL_REV != original.VALOR_FISCAL_REV) return true;
			if (this.VALOR_FISCAL_NET_CIERRE != original.VALOR_FISCAL_NET_CIERRE) return true;
			if (this.CUOTA_FISCAL_DEPR_ANUAL != original.CUOTA_FISCAL_DEPR_ANUAL) return true;
			if (this.DEPREC_FISCAL_ACUM != original.DEPREC_FISCAL_ACUM) return true;
			if (this.VIDA_UTIL_RESTANTE != original.VIDA_UTIL_RESTANTE) return true;
			
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
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
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
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
			return dynStr.ToString();
		}
	} // End of CTB_REVALUOSRow_Base class
} // End of namespace
