// <fileinfo name="STOCK_CRITICO_POL_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="STOCK_CRITICO_POL_INFO_COMPLRow"/> that 
	/// represents a record in the <c>STOCK_CRITICO_POL_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_CRITICO_POL_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_CRITICO_POL_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito_nombre;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _articulo_descripcion_interna;
		private string _articulo_codigo_empresa;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private string _familia_descripcion;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private string _grupo_descripcion;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _subgrupo_descripcion;
		private decimal _marca_id;
		private bool _marca_idNull = true;
		private string _marca_nombre;
		private string _politica_calculo;
		private string _frecuencia_calculo;
		private System.DateTime _fecha_ultima_ejecucion;
		private bool _fecha_ultima_ejecucionNull = true;
		private System.DateTime _fecha_proxima_ejecucion;
		private bool _fecha_proxima_ejecucionNull = true;
		private System.DateTime _fecha_creacion;
		private string _estado;
		private decimal _usuario_creacion_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_CRITICO_POL_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public STOCK_CRITICO_POL_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_CRITICO_POL_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_NOMBRE != original.DEPOSITO_NOMBRE) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_DESCRIPCION_INTERNA != original.ARTICULO_DESCRIPCION_INTERNA) return true;
			if (this.ARTICULO_CODIGO_EMPRESA != original.ARTICULO_CODIGO_EMPRESA) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			if (this.IsMARCA_IDNull != original.IsMARCA_IDNull) return true;
			if (!this.IsMARCA_IDNull && !original.IsMARCA_IDNull)
				if (this.MARCA_ID != original.MARCA_ID) return true;
			if (this.MARCA_NOMBRE != original.MARCA_NOMBRE) return true;
			if (this.POLITICA_CALCULO != original.POLITICA_CALCULO) return true;
			if (this.FRECUENCIA_CALCULO != original.FRECUENCIA_CALCULO) return true;
			if (this.IsFECHA_ULTIMA_EJECUCIONNull != original.IsFECHA_ULTIMA_EJECUCIONNull) return true;
			if (!this.IsFECHA_ULTIMA_EJECUCIONNull && !original.IsFECHA_ULTIMA_EJECUCIONNull)
				if (this.FECHA_ULTIMA_EJECUCION != original.FECHA_ULTIMA_EJECUCION) return true;
			if (this.IsFECHA_PROXIMA_EJECUCIONNull != original.IsFECHA_PROXIMA_EJECUCIONNull) return true;
			if (!this.IsFECHA_PROXIMA_EJECUCIONNull && !original.IsFECHA_PROXIMA_EJECUCIONNull)
				if (this.FECHA_PROXIMA_EJECUCION != original.FECHA_PROXIMA_EJECUCION) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_NOMBRE</c> column value.</value>
		public string DEPOSITO_NOMBRE
		{
			get { return _deposito_nombre; }
			set { _deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION_INTERNA</c> column value.</value>
		public string ARTICULO_DESCRIPCION_INTERNA
		{
			get { return _articulo_descripcion_interna; }
			set { _articulo_descripcion_interna = value; }
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
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_DESCRIPCION</c> column value.</value>
		public string FAMILIA_DESCRIPCION
		{
			get { return _familia_descripcion; }
			set { _familia_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_DESCRIPCION</c> column value.</value>
		public string GRUPO_DESCRIPCION
		{
			get { return _grupo_descripcion; }
			set { _grupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public decimal SUBGRUPO_ID
		{
			get
			{
				if(IsSUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_id;
			}
			set
			{
				_subgrupo_idNull = false;
				_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_IDNull
		{
			get { return _subgrupo_idNull; }
			set { _subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_DESCRIPCION</c> column value.</value>
		public string SUBGRUPO_DESCRIPCION
		{
			get { return _subgrupo_descripcion; }
			set { _subgrupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCA_ID</c> column value.</value>
		public decimal MARCA_ID
		{
			get
			{
				if(IsMARCA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _marca_id;
			}
			set
			{
				_marca_idNull = false;
				_marca_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MARCA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMARCA_IDNull
		{
			get { return _marca_idNull; }
			set { _marca_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCA_NOMBRE</c> column value.</value>
		public string MARCA_NOMBRE
		{
			get { return _marca_nombre; }
			set { _marca_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>POLITICA_CALCULO</c> column value.
		/// </summary>
		/// <value>The <c>POLITICA_CALCULO</c> column value.</value>
		public string POLITICA_CALCULO
		{
			get { return _politica_calculo; }
			set { _politica_calculo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FRECUENCIA_CALCULO</c> column value.
		/// </summary>
		/// <value>The <c>FRECUENCIA_CALCULO</c> column value.</value>
		public string FRECUENCIA_CALCULO
		{
			get { return _frecuencia_calculo; }
			set { _frecuencia_calculo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMA_EJECUCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMA_EJECUCION</c> column value.</value>
		public System.DateTime FECHA_ULTIMA_EJECUCION
		{
			get
			{
				if(IsFECHA_ULTIMA_EJECUCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultima_ejecucion;
			}
			set
			{
				_fecha_ultima_ejecucionNull = false;
				_fecha_ultima_ejecucion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMA_EJECUCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMA_EJECUCIONNull
		{
			get { return _fecha_ultima_ejecucionNull; }
			set { _fecha_ultima_ejecucionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_PROXIMA_EJECUCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_PROXIMA_EJECUCION</c> column value.</value>
		public System.DateTime FECHA_PROXIMA_EJECUCION
		{
			get
			{
				if(IsFECHA_PROXIMA_EJECUCIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_proxima_ejecucion;
			}
			set
			{
				_fecha_proxima_ejecucionNull = false;
				_fecha_proxima_ejecucion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_PROXIMA_EJECUCION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_PROXIMA_EJECUCIONNull
		{
			get { return _fecha_proxima_ejecucionNull; }
			set { _fecha_proxima_ejecucionNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_NOMBRE=");
			dynStr.Append(DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION_INTERNA=");
			dynStr.Append(ARTICULO_DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@ARTICULO_CODIGO_EMPRESA=");
			dynStr.Append(ARTICULO_CODIGO_EMPRESA);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@MARCA_ID=");
			dynStr.Append(IsMARCA_IDNull ? (object)"<NULL>" : MARCA_ID);
			dynStr.Append("@CBA@MARCA_NOMBRE=");
			dynStr.Append(MARCA_NOMBRE);
			dynStr.Append("@CBA@POLITICA_CALCULO=");
			dynStr.Append(POLITICA_CALCULO);
			dynStr.Append("@CBA@FRECUENCIA_CALCULO=");
			dynStr.Append(FRECUENCIA_CALCULO);
			dynStr.Append("@CBA@FECHA_ULTIMA_EJECUCION=");
			dynStr.Append(IsFECHA_ULTIMA_EJECUCIONNull ? (object)"<NULL>" : FECHA_ULTIMA_EJECUCION);
			dynStr.Append("@CBA@FECHA_PROXIMA_EJECUCION=");
			dynStr.Append(IsFECHA_PROXIMA_EJECUCIONNull ? (object)"<NULL>" : FECHA_PROXIMA_EJECUCION);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			return dynStr.ToString();
		}
	} // End of STOCK_CRITICO_POL_INFO_COMPLRow_Base class
} // End of namespace
