// <fileinfo name="SUCURSALESRow_Base.cs">
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
	/// The base class for <see cref="SUCURSALESRow"/> that 
	/// represents a record in the <c>SUCURSALES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="SUCURSALESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class SUCURSALESRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _abreviatura;
		private decimal _pais_id;
		private decimal _entidad_id;
		private decimal _moneda_id;
		private string _direccion;
		private string _telefono;
		private string _mayorista;
		private string _es_casa_matriz;
		private decimal _suc_casa_matriz_id;
		private bool _suc_casa_matriz_idNull = true;
		private decimal _plan_de_cuentas;
		private bool _plan_de_cuentasNull = true;
		private string _ruc;
		private string _estado;
		private decimal _region_id;
		private bool _region_idNull = true;
		private decimal _departamento_id;
		private bool _departamento_idNull = true;
		private decimal _barrio_id;
		private bool _barrio_idNull = true;
		private decimal _ciudad_id;
		private bool _ciudad_idNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _fc_proveedores_cc_obligatorio;
		private string _para_facturar;

		/// <summary>
		/// Initializes a new instance of the <see cref="SUCURSALESRow_Base"/> class.
		/// </summary>
		public SUCURSALESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(SUCURSALESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.DIRECCION != original.DIRECCION) return true;
			if (this.TELEFONO != original.TELEFONO) return true;
			if (this.MAYORISTA != original.MAYORISTA) return true;
			if (this.ES_CASA_MATRIZ != original.ES_CASA_MATRIZ) return true;
			if (this.IsSUC_CASA_MATRIZ_IDNull != original.IsSUC_CASA_MATRIZ_IDNull) return true;
			if (!this.IsSUC_CASA_MATRIZ_IDNull && !original.IsSUC_CASA_MATRIZ_IDNull)
				if (this.SUC_CASA_MATRIZ_ID != original.SUC_CASA_MATRIZ_ID) return true;
			if (this.IsPLAN_DE_CUENTASNull != original.IsPLAN_DE_CUENTASNull) return true;
			if (!this.IsPLAN_DE_CUENTASNull && !original.IsPLAN_DE_CUENTASNull)
				if (this.PLAN_DE_CUENTAS != original.PLAN_DE_CUENTAS) return true;
			if (this.RUC != original.RUC) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.IsDEPARTAMENTO_IDNull != original.IsDEPARTAMENTO_IDNull) return true;
			if (!this.IsDEPARTAMENTO_IDNull && !original.IsDEPARTAMENTO_IDNull)
				if (this.DEPARTAMENTO_ID != original.DEPARTAMENTO_ID) return true;
			if (this.IsBARRIO_IDNull != original.IsBARRIO_IDNull) return true;
			if (!this.IsBARRIO_IDNull && !original.IsBARRIO_IDNull)
				if (this.BARRIO_ID != original.BARRIO_ID) return true;
			if (this.IsCIUDAD_IDNull != original.IsCIUDAD_IDNull) return true;
			if (!this.IsCIUDAD_IDNull && !original.IsCIUDAD_IDNull)
				if (this.CIUDAD_ID != original.CIUDAD_ID) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FC_PROVEEDORES_CC_OBLIGATORIO != original.FC_PROVEEDORES_CC_OBLIGATORIO) return true;
			if (this.PARA_FACTURAR != original.PARA_FACTURAR) return true;
			
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
		/// Gets or sets the <c>ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA</c> column value.</value>
		public string ABREVIATURA
		{
			get { return _abreviatura; }
			set { _abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get { return _pais_id; }
			set { _pais_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>DIRECCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIRECCION</c> column value.</value>
		public string DIRECCION
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO</c> column value.</value>
		public string TELEFONO
		{
			get { return _telefono; }
			set { _telefono = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MAYORISTA</c> column value.
		/// </summary>
		/// <value>The <c>MAYORISTA</c> column value.</value>
		public string MAYORISTA
		{
			get { return _mayorista; }
			set { _mayorista = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CASA_MATRIZ</c> column value.
		/// </summary>
		/// <value>The <c>ES_CASA_MATRIZ</c> column value.</value>
		public string ES_CASA_MATRIZ
		{
			get { return _es_casa_matriz; }
			set { _es_casa_matriz = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUC_CASA_MATRIZ_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUC_CASA_MATRIZ_ID</c> column value.</value>
		public decimal SUC_CASA_MATRIZ_ID
		{
			get
			{
				if(IsSUC_CASA_MATRIZ_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _suc_casa_matriz_id;
			}
			set
			{
				_suc_casa_matriz_idNull = false;
				_suc_casa_matriz_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUC_CASA_MATRIZ_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUC_CASA_MATRIZ_IDNull
		{
			get { return _suc_casa_matriz_idNull; }
			set { _suc_casa_matriz_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLAN_DE_CUENTAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLAN_DE_CUENTAS</c> column value.</value>
		public decimal PLAN_DE_CUENTAS
		{
			get
			{
				if(IsPLAN_DE_CUENTASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _plan_de_cuentas;
			}
			set
			{
				_plan_de_cuentasNull = false;
				_plan_de_cuentas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PLAN_DE_CUENTAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPLAN_DE_CUENTASNull
		{
			get { return _plan_de_cuentasNull; }
			set { _plan_de_cuentasNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUC</c> column value.</value>
		public string RUC
		{
			get { return _ruc; }
			set { _ruc = value; }
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
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_ID</c> column value.</value>
		public decimal DEPARTAMENTO_ID
		{
			get
			{
				if(IsDEPARTAMENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_id;
			}
			set
			{
				_departamento_idNull = false;
				_departamento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_IDNull
		{
			get { return _departamento_idNull; }
			set { _departamento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_ID</c> column value.</value>
		public decimal BARRIO_ID
		{
			get
			{
				if(IsBARRIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio_id;
			}
			set
			{
				_barrio_idNull = false;
				_barrio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO_IDNull
		{
			get { return _barrio_idNull; }
			set { _barrio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_ID</c> column value.</value>
		public decimal CIUDAD_ID
		{
			get
			{
				if(IsCIUDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_id;
			}
			set
			{
				_ciudad_idNull = false;
				_ciudad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_IDNull
		{
			get { return _ciudad_idNull; }
			set { _ciudad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get
			{
				if(IsCENTRO_COSTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _centro_costo_id;
			}
			set
			{
				_centro_costo_idNull = false;
				_centro_costo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CENTRO_COSTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCENTRO_COSTO_IDNull
		{
			get { return _centro_costo_idNull; }
			set { _centro_costo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_PROVEEDORES_CC_OBLIGATORIO</c> column value.
		/// </summary>
		/// <value>The <c>FC_PROVEEDORES_CC_OBLIGATORIO</c> column value.</value>
		public string FC_PROVEEDORES_CC_OBLIGATORIO
		{
			get { return _fc_proveedores_cc_obligatorio; }
			set { _fc_proveedores_cc_obligatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PARA_FACTURAR</c> column value.
		/// </summary>
		/// <value>The <c>PARA_FACTURAR</c> column value.</value>
		public string PARA_FACTURAR
		{
			get { return _para_facturar; }
			set { _para_facturar = value; }
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
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@DIRECCION=");
			dynStr.Append(DIRECCION);
			dynStr.Append("@CBA@TELEFONO=");
			dynStr.Append(TELEFONO);
			dynStr.Append("@CBA@MAYORISTA=");
			dynStr.Append(MAYORISTA);
			dynStr.Append("@CBA@ES_CASA_MATRIZ=");
			dynStr.Append(ES_CASA_MATRIZ);
			dynStr.Append("@CBA@SUC_CASA_MATRIZ_ID=");
			dynStr.Append(IsSUC_CASA_MATRIZ_IDNull ? (object)"<NULL>" : SUC_CASA_MATRIZ_ID);
			dynStr.Append("@CBA@PLAN_DE_CUENTAS=");
			dynStr.Append(IsPLAN_DE_CUENTASNull ? (object)"<NULL>" : PLAN_DE_CUENTAS);
			dynStr.Append("@CBA@RUC=");
			dynStr.Append(RUC);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@DEPARTAMENTO_ID=");
			dynStr.Append(IsDEPARTAMENTO_IDNull ? (object)"<NULL>" : DEPARTAMENTO_ID);
			dynStr.Append("@CBA@BARRIO_ID=");
			dynStr.Append(IsBARRIO_IDNull ? (object)"<NULL>" : BARRIO_ID);
			dynStr.Append("@CBA@CIUDAD_ID=");
			dynStr.Append(IsCIUDAD_IDNull ? (object)"<NULL>" : CIUDAD_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@FC_PROVEEDORES_CC_OBLIGATORIO=");
			dynStr.Append(FC_PROVEEDORES_CC_OBLIGATORIO);
			dynStr.Append("@CBA@PARA_FACTURAR=");
			dynStr.Append(PARA_FACTURAR);
			return dynStr.ToString();
		}
	} // End of SUCURSALESRow_Base class
} // End of namespace
