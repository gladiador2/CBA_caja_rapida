// <fileinfo name="FUNCIONARIOS_LIQ_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_LIQ_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_LIQ_INFO_COMPRow_Base
	{
		private decimal _id;
		private bool _idNull = true;
		private System.DateTime _fecha_creacion;
		private bool _fecha_creacionNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _funcionario_nombre_completo;
		private decimal _tipo;
		private bool _tipoNull = true;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _dias_trabajados;
		private bool _dias_trabajadosNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private string _usuarios_usuario;
		private decimal _total_salario;
		private bool _total_salarioNull = true;
		private decimal _total_descuento;
		private bool _total_descuentoNull = true;
		private decimal _total_bonificaciones;
		private bool _total_bonificacionesNull = true;
		private decimal _total_cobrar;
		private bool _total_cobrarNull = true;
		private decimal _total_aportes_empresa;
		private bool _total_aportes_empresaNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _monedas_nombre;
		private string _monedas_simbolo;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private string _observacion;
		private decimal _planilla_salario_id;
		private bool _planilla_salario_idNull = true;
		private decimal _planilla_salario_det_id;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private string _caso_asociado_nro_comprobante;
		private decimal _orden_pago_id;
		private bool _orden_pago_idNull = true;
		private decimal _orden_pago_caso_id;
		private bool _orden_pago_caso_idNull = true;
		private string _orden_pago_caso_estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_LIQ_INFO_COMPRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_LIQ_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_LIQ_INFO_COMPRow_Base original)
		{
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.IsFECHA_CREACIONNull != original.IsFECHA_CREACIONNull) return true;
			if (!this.IsFECHA_CREACIONNull && !original.IsFECHA_CREACIONNull)
				if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE_COMPLETO != original.FUNCIONARIO_NOMBRE_COMPLETO) return true;
			if (this.IsTIPONull != original.IsTIPONull) return true;
			if (!this.IsTIPONull && !original.IsTIPONull)
				if (this.TIPO != original.TIPO) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsDIAS_TRABAJADOSNull != original.IsDIAS_TRABAJADOSNull) return true;
			if (!this.IsDIAS_TRABAJADOSNull && !original.IsDIAS_TRABAJADOSNull)
				if (this.DIAS_TRABAJADOS != original.DIAS_TRABAJADOS) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIOS_USUARIO != original.USUARIOS_USUARIO) return true;
			if (this.IsTOTAL_SALARIONull != original.IsTOTAL_SALARIONull) return true;
			if (!this.IsTOTAL_SALARIONull && !original.IsTOTAL_SALARIONull)
				if (this.TOTAL_SALARIO != original.TOTAL_SALARIO) return true;
			if (this.IsTOTAL_DESCUENTONull != original.IsTOTAL_DESCUENTONull) return true;
			if (!this.IsTOTAL_DESCUENTONull && !original.IsTOTAL_DESCUENTONull)
				if (this.TOTAL_DESCUENTO != original.TOTAL_DESCUENTO) return true;
			if (this.IsTOTAL_BONIFICACIONESNull != original.IsTOTAL_BONIFICACIONESNull) return true;
			if (!this.IsTOTAL_BONIFICACIONESNull && !original.IsTOTAL_BONIFICACIONESNull)
				if (this.TOTAL_BONIFICACIONES != original.TOTAL_BONIFICACIONES) return true;
			if (this.IsTOTAL_COBRARNull != original.IsTOTAL_COBRARNull) return true;
			if (!this.IsTOTAL_COBRARNull && !original.IsTOTAL_COBRARNull)
				if (this.TOTAL_COBRAR != original.TOTAL_COBRAR) return true;
			if (this.IsTOTAL_APORTES_EMPRESANull != original.IsTOTAL_APORTES_EMPRESANull) return true;
			if (!this.IsTOTAL_APORTES_EMPRESANull && !original.IsTOTAL_APORTES_EMPRESANull)
				if (this.TOTAL_APORTES_EMPRESA != original.TOTAL_APORTES_EMPRESA) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDAS_NOMBRE != original.MONEDAS_NOMBRE) return true;
			if (this.MONEDAS_SIMBOLO != original.MONEDAS_SIMBOLO) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsPLANILLA_SALARIO_IDNull != original.IsPLANILLA_SALARIO_IDNull) return true;
			if (!this.IsPLANILLA_SALARIO_IDNull && !original.IsPLANILLA_SALARIO_IDNull)
				if (this.PLANILLA_SALARIO_ID != original.PLANILLA_SALARIO_ID) return true;
			if (this.PLANILLA_SALARIO_DET_ID != original.PLANILLA_SALARIO_DET_ID) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.CASO_ASOCIADO_NRO_COMPROBANTE != original.CASO_ASOCIADO_NRO_COMPROBANTE) return true;
			if (this.IsORDEN_PAGO_IDNull != original.IsORDEN_PAGO_IDNull) return true;
			if (!this.IsORDEN_PAGO_IDNull && !original.IsORDEN_PAGO_IDNull)
				if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsORDEN_PAGO_CASO_IDNull != original.IsORDEN_PAGO_CASO_IDNull) return true;
			if (!this.IsORDEN_PAGO_CASO_IDNull && !original.IsORDEN_PAGO_CASO_IDNull)
				if (this.ORDEN_PAGO_CASO_ID != original.ORDEN_PAGO_CASO_ID) return true;
			if (this.ORDEN_PAGO_CASO_ESTADO != original.ORDEN_PAGO_CASO_ESTADO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get
			{
				if(IsFECHA_CREACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_creacion;
			}
			set
			{
				_fecha_creacionNull = false;
				_fecha_creacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CREACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CREACIONNull
		{
			get { return _fecha_creacionNull; }
			set { _fecha_creacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE_COMPLETO</c> column value.</value>
		public string FUNCIONARIO_NOMBRE_COMPLETO
		{
			get { return _funcionario_nombre_completo; }
			set { _funcionario_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public decimal TIPO
		{
			get
			{
				if(IsTIPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo;
			}
			set
			{
				_tipoNull = false;
				_tipo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPONull
		{
			get { return _tipoNull; }
			set { _tipoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIOS_USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIOS_USUARIO</c> column value.</value>
		public string USUARIOS_USUARIO
		{
			get { return _usuarios_usuario; }
			set { _usuarios_usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_SALARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_SALARIO</c> column value.</value>
		public decimal TOTAL_SALARIO
		{
			get
			{
				if(IsTOTAL_SALARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_salario;
			}
			set
			{
				_total_salarioNull = false;
				_total_salario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_SALARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_SALARIONull
		{
			get { return _total_salarioNull; }
			set { _total_salarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DESCUENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DESCUENTO</c> column value.</value>
		public decimal TOTAL_DESCUENTO
		{
			get
			{
				if(IsTOTAL_DESCUENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_descuento;
			}
			set
			{
				_total_descuentoNull = false;
				_total_descuento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DESCUENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DESCUENTONull
		{
			get { return _total_descuentoNull; }
			set { _total_descuentoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BONIFICACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_BONIFICACIONES</c> column value.</value>
		public decimal TOTAL_BONIFICACIONES
		{
			get
			{
				if(IsTOTAL_BONIFICACIONESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_bonificaciones;
			}
			set
			{
				_total_bonificacionesNull = false;
				_total_bonificaciones = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_BONIFICACIONES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_BONIFICACIONESNull
		{
			get { return _total_bonificacionesNull; }
			set { _total_bonificacionesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COBRAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_COBRAR</c> column value.</value>
		public decimal TOTAL_COBRAR
		{
			get
			{
				if(IsTOTAL_COBRARNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_cobrar;
			}
			set
			{
				_total_cobrarNull = false;
				_total_cobrar = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_COBRAR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_COBRARNull
		{
			get { return _total_cobrarNull; }
			set { _total_cobrarNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_APORTES_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_APORTES_EMPRESA</c> column value.</value>
		public decimal TOTAL_APORTES_EMPRESA
		{
			get
			{
				if(IsTOTAL_APORTES_EMPRESANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_aportes_empresa;
			}
			set
			{
				_total_aportes_empresaNull = false;
				_total_aportes_empresa = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_APORTES_EMPRESA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_APORTES_EMPRESANull
		{
			get { return _total_aportes_empresaNull; }
			set { _total_aportes_empresaNull = value; }
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
		/// Gets or sets the <c>MONEDAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_NOMBRE</c> column value.</value>
		public string MONEDAS_NOMBRE
		{
			get { return _monedas_nombre; }
			set { _monedas_nombre = value; }
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
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
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
		/// Gets or sets the <c>PLANILLA_SALARIO_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>PLANILLA_SALARIO_DET_ID</c> column value.</value>
		public decimal PLANILLA_SALARIO_DET_ID
		{
			get { return _planilla_salario_det_id; }
			set { _planilla_salario_det_id = value; }
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
		/// Gets or sets the <c>CASO_ASOCIADO_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_NRO_COMPROBANTE</c> column value.</value>
		public string CASO_ASOCIADO_NRO_COMPROBANTE
		{
			get { return _caso_asociado_nro_comprobante; }
			set { _caso_asociado_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_ID
		{
			get
			{
				if(IsORDEN_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_id;
			}
			set
			{
				_orden_pago_idNull = false;
				_orden_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_IDNull
		{
			get { return _orden_pago_idNull; }
			set { _orden_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_CASO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_CASO_ID
		{
			get
			{
				if(IsORDEN_PAGO_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden_pago_caso_id;
			}
			set
			{
				_orden_pago_caso_idNull = false;
				_orden_pago_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN_PAGO_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDEN_PAGO_CASO_IDNull
		{
			get { return _orden_pago_caso_idNull; }
			set { _orden_pago_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN_PAGO_CASO_ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_CASO_ESTADO</c> column value.</value>
		public string ORDEN_PAGO_CASO_ESTADO
		{
			get { return _orden_pago_caso_estado; }
			set { _orden_pago_caso_estado = value; }
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
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(IsFECHA_CREACIONNull ? (object)"<NULL>" : FECHA_CREACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE_COMPLETO=");
			dynStr.Append(FUNCIONARIO_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(IsTIPONull ? (object)"<NULL>" : TIPO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@DIAS_TRABAJADOS=");
			dynStr.Append(IsDIAS_TRABAJADOSNull ? (object)"<NULL>" : DIAS_TRABAJADOS);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@USUARIOS_USUARIO=");
			dynStr.Append(USUARIOS_USUARIO);
			dynStr.Append("@CBA@TOTAL_SALARIO=");
			dynStr.Append(IsTOTAL_SALARIONull ? (object)"<NULL>" : TOTAL_SALARIO);
			dynStr.Append("@CBA@TOTAL_DESCUENTO=");
			dynStr.Append(IsTOTAL_DESCUENTONull ? (object)"<NULL>" : TOTAL_DESCUENTO);
			dynStr.Append("@CBA@TOTAL_BONIFICACIONES=");
			dynStr.Append(IsTOTAL_BONIFICACIONESNull ? (object)"<NULL>" : TOTAL_BONIFICACIONES);
			dynStr.Append("@CBA@TOTAL_COBRAR=");
			dynStr.Append(IsTOTAL_COBRARNull ? (object)"<NULL>" : TOTAL_COBRAR);
			dynStr.Append("@CBA@TOTAL_APORTES_EMPRESA=");
			dynStr.Append(IsTOTAL_APORTES_EMPRESANull ? (object)"<NULL>" : TOTAL_APORTES_EMPRESA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDAS_NOMBRE=");
			dynStr.Append(MONEDAS_NOMBRE);
			dynStr.Append("@CBA@MONEDAS_SIMBOLO=");
			dynStr.Append(MONEDAS_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@PLANILLA_SALARIO_ID=");
			dynStr.Append(IsPLANILLA_SALARIO_IDNull ? (object)"<NULL>" : PLANILLA_SALARIO_ID);
			dynStr.Append("@CBA@PLANILLA_SALARIO_DET_ID=");
			dynStr.Append(PLANILLA_SALARIO_DET_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@CASO_ASOCIADO_NRO_COMPROBANTE=");
			dynStr.Append(CASO_ASOCIADO_NRO_COMPROBANTE);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(IsORDEN_PAGO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_CASO_ID=");
			dynStr.Append(IsORDEN_PAGO_CASO_IDNull ? (object)"<NULL>" : ORDEN_PAGO_CASO_ID);
			dynStr.Append("@CBA@ORDEN_PAGO_CASO_ESTADO=");
			dynStr.Append(ORDEN_PAGO_CASO_ESTADO);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_LIQ_INFO_COMPRow_Base class
} // End of namespace
