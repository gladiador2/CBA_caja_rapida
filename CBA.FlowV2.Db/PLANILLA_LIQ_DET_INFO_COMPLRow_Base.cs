// <fileinfo name="PLANILLA_LIQ_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_LIQ_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PLANILLA_LIQ_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_LIQ_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_LIQ_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _planilla_id;
		private decimal _funcionario_id;
		private string _funcionarios_nombre;
		private decimal _total_salario;
		private decimal _total_bonificacion;
		private decimal _total_descuento;
		private decimal _total_a_cobrar;
		private decimal _total_aportes_empresa;
		private decimal _liquidacion_id;
		private bool _liquidacion_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _monedas_nombres;
		private string _monedas_simbolo;
		private decimal _cotizacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_LIQ_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PLANILLA_LIQ_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_LIQ_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PLANILLA_ID != original.PLANILLA_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIOS_NOMBRE != original.FUNCIONARIOS_NOMBRE) return true;
			if (this.TOTAL_SALARIO != original.TOTAL_SALARIO) return true;
			if (this.TOTAL_BONIFICACION != original.TOTAL_BONIFICACION) return true;
			if (this.TOTAL_DESCUENTO != original.TOTAL_DESCUENTO) return true;
			if (this.TOTAL_A_COBRAR != original.TOTAL_A_COBRAR) return true;
			if (this.TOTAL_APORTES_EMPRESA != original.TOTAL_APORTES_EMPRESA) return true;
			if (this.IsLIQUIDACION_IDNull != original.IsLIQUIDACION_IDNull) return true;
			if (!this.IsLIQUIDACION_IDNull && !original.IsLIQUIDACION_IDNull)
				if (this.LIQUIDACION_ID != original.LIQUIDACION_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDAS_NOMBRES != original.MONEDAS_NOMBRES) return true;
			if (this.MONEDAS_SIMBOLO != original.MONEDAS_SIMBOLO) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			
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
		/// Gets or sets the <c>PLANILLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_ID</c> column value.</value>
		public decimal PLANILLA_ID
		{
			get { return _planilla_id; }
			set { _planilla_id = value; }
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
		/// Gets or sets the <c>FUNCIONARIOS_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIOS_NOMBRE</c> column value.</value>
		public string FUNCIONARIOS_NOMBRE
		{
			get { return _funcionarios_nombre; }
			set { _funcionarios_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_SALARIO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_SALARIO</c> column value.</value>
		public decimal TOTAL_SALARIO
		{
			get { return _total_salario; }
			set { _total_salario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BONIFICACION</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_BONIFICACION</c> column value.</value>
		public decimal TOTAL_BONIFICACION
		{
			get { return _total_bonificacion; }
			set { _total_bonificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DESCUENTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_DESCUENTO</c> column value.</value>
		public decimal TOTAL_DESCUENTO
		{
			get { return _total_descuento; }
			set { _total_descuento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_A_COBRAR</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_A_COBRAR</c> column value.</value>
		public decimal TOTAL_A_COBRAR
		{
			get { return _total_a_cobrar; }
			set { _total_a_cobrar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_APORTES_EMPRESA</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_APORTES_EMPRESA</c> column value.</value>
		public decimal TOTAL_APORTES_EMPRESA
		{
			get { return _total_aportes_empresa; }
			set { _total_aportes_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIQUIDACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIQUIDACION_ID</c> column value.</value>
		public decimal LIQUIDACION_ID
		{
			get
			{
				if(IsLIQUIDACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _liquidacion_id;
			}
			set
			{
				_liquidacion_idNull = false;
				_liquidacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIQUIDACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIQUIDACION_IDNull
		{
			get { return _liquidacion_idNull; }
			set { _liquidacion_idNull = value; }
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
		/// Gets or sets the <c>MONEDAS_NOMBRES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_NOMBRES</c> column value.</value>
		public string MONEDAS_NOMBRES
		{
			get { return _monedas_nombres; }
			set { _monedas_nombres = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDAS_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_SIMBOLO</c> column value.</value>
		public string MONEDAS_SIMBOLO
		{
			get { return _monedas_simbolo; }
			set { _monedas_simbolo = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PLANILLA_ID=");
			dynStr.Append(PLANILLA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIOS_NOMBRE=");
			dynStr.Append(FUNCIONARIOS_NOMBRE);
			dynStr.Append("@CBA@TOTAL_SALARIO=");
			dynStr.Append(TOTAL_SALARIO);
			dynStr.Append("@CBA@TOTAL_BONIFICACION=");
			dynStr.Append(TOTAL_BONIFICACION);
			dynStr.Append("@CBA@TOTAL_DESCUENTO=");
			dynStr.Append(TOTAL_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_A_COBRAR=");
			dynStr.Append(TOTAL_A_COBRAR);
			dynStr.Append("@CBA@TOTAL_APORTES_EMPRESA=");
			dynStr.Append(TOTAL_APORTES_EMPRESA);
			dynStr.Append("@CBA@LIQUIDACION_ID=");
			dynStr.Append(IsLIQUIDACION_IDNull ? (object)"<NULL>" : LIQUIDACION_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDAS_NOMBRES=");
			dynStr.Append(MONEDAS_NOMBRES);
			dynStr.Append("@CBA@MONEDAS_SIMBOLO=");
			dynStr.Append(MONEDAS_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			return dynStr.ToString();
		}
	} // End of PLANILLA_LIQ_DET_INFO_COMPLRow_Base class
} // End of namespace
