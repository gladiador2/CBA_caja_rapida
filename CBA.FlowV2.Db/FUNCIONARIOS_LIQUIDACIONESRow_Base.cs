// <fileinfo name="FUNCIONARIOS_LIQUIDACIONESRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_LIQUIDACIONESRow_Base
	{
		private decimal _id;
		private System.DateTime _fecha_creacion;
		private decimal _funcionario_id;
		private decimal _tipo;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private decimal _usuario_id;
		private decimal _total_salario;
		private decimal _total_descuento;
		private decimal _total_bonificaciones;
		private decimal _total_cobrar;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private string _observacion;
		private decimal _planilla_salario_id;
		private bool _planilla_salario_idNull = true;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private decimal _dias_trabajados;
		private bool _dias_trabajadosNull = true;
		private decimal _total_aportes_empresa;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_LIQUIDACIONESRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_LIQUIDACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_LIQUIDACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.TOTAL_SALARIO != original.TOTAL_SALARIO) return true;
			if (this.TOTAL_DESCUENTO != original.TOTAL_DESCUENTO) return true;
			if (this.TOTAL_BONIFICACIONES != original.TOTAL_BONIFICACIONES) return true;
			if (this.TOTAL_COBRAR != original.TOTAL_COBRAR) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsPLANILLA_SALARIO_IDNull != original.IsPLANILLA_SALARIO_IDNull) return true;
			if (!this.IsPLANILLA_SALARIO_IDNull && !original.IsPLANILLA_SALARIO_IDNull)
				if (this.PLANILLA_SALARIO_ID != original.PLANILLA_SALARIO_ID) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.IsDIAS_TRABAJADOSNull != original.IsDIAS_TRABAJADOSNull) return true;
			if (!this.IsDIAS_TRABAJADOSNull && !original.IsDIAS_TRABAJADOSNull)
				if (this.DIAS_TRABAJADOS != original.DIAS_TRABAJADOS) return true;
			if (this.TOTAL_APORTES_EMPRESA != original.TOTAL_APORTES_EMPRESA) return true;
			
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
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
		/// Gets or sets the <c>TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public decimal TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get { return _fecha_fin; }
			set { _fecha_fin = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>TOTAL_DESCUENTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_DESCUENTO</c> column value.</value>
		public decimal TOTAL_DESCUENTO
		{
			get { return _total_descuento; }
			set { _total_descuento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BONIFICACIONES</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_BONIFICACIONES</c> column value.</value>
		public decimal TOTAL_BONIFICACIONES
		{
			get { return _total_bonificaciones; }
			set { _total_bonificaciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COBRAR</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_COBRAR</c> column value.</value>
		public decimal TOTAL_COBRAR
		{
			get { return _total_cobrar; }
			set { _total_cobrar = value; }
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
		/// Gets or sets the <c>PLANILLA_SALARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANILLA_SALARIO_ID</c> column value.</value>
		public decimal PLANILLA_SALARIO_ID
		{
			get
			{
				if(IsPLANILLA_SALARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _planilla_salario_id;
			}
			set
			{
				_planilla_salario_idNull = false;
				_planilla_salario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PLANILLA_SALARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPLANILLA_SALARIO_IDNull
		{
			get { return _planilla_salario_idNull; }
			set { _planilla_salario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ASOCIADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_ID</c> column value.</value>
		public decimal CASO_ASOCIADO_ID
		{
			get
			{
				if(IsCASO_ASOCIADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_asociado_id;
			}
			set
			{
				_caso_asociado_idNull = false;
				_caso_asociado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ASOCIADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ASOCIADO_IDNull
		{
			get { return _caso_asociado_idNull; }
			set { _caso_asociado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_TRABAJADOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_TRABAJADOS</c> column value.</value>
		public decimal DIAS_TRABAJADOS
		{
			get
			{
				if(IsDIAS_TRABAJADOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_trabajados;
			}
			set
			{
				_dias_trabajadosNull = false;
				_dias_trabajados = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_TRABAJADOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_TRABAJADOSNull
		{
			get { return _dias_trabajadosNull; }
			set { _dias_trabajadosNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(FECHA_FIN);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@TOTAL_SALARIO=");
			dynStr.Append(TOTAL_SALARIO);
			dynStr.Append("@CBA@TOTAL_DESCUENTO=");
			dynStr.Append(TOTAL_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_BONIFICACIONES=");
			dynStr.Append(TOTAL_BONIFICACIONES);
			dynStr.Append("@CBA@TOTAL_COBRAR=");
			dynStr.Append(TOTAL_COBRAR);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@PLANILLA_SALARIO_ID=");
			dynStr.Append(IsPLANILLA_SALARIO_IDNull ? (object)"<NULL>" : PLANILLA_SALARIO_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@DIAS_TRABAJADOS=");
			dynStr.Append(IsDIAS_TRABAJADOSNull ? (object)"<NULL>" : DIAS_TRABAJADOS);
			dynStr.Append("@CBA@TOTAL_APORTES_EMPRESA=");
			dynStr.Append(TOTAL_APORTES_EMPRESA);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_LIQUIDACIONESRow_Base class
} // End of namespace
