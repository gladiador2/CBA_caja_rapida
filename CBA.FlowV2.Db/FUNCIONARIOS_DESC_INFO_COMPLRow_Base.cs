// <fileinfo name="FUNCIONARIOS_DESC_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_DESC_INFO_COMPLRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_DESC_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_DESC_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_DESC_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _descuento_id;
		private string _descuento_nombre;
		private string _descuento_consumo;
		private string _descuento_unico;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private decimal _entidad_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _empresa_seccion_id;
		private bool _empresa_seccion_idNull = true;
		private string _empresa_seccion_nombre;
		private string _empresa_departamento_id;
		private string _observacion;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _moneda_cantidad_decimales;
		private string _moneda_cadena_decimales;
		private decimal _cotizacion_moneda;
		private decimal _monto;
		private bool _montoNull = true;
		private string _utilizar_porcentaje;
		private decimal _porcentaje_sugerido;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creacion_id;
		private string _usuario_creacion_nombre;
		private decimal _liquidacion_asociada_id;
		private bool _liquidacion_asociada_idNull = true;
		private string _estado;
		private string _consumo_visitas;
		private decimal _caso_origen_id;
		private bool _caso_origen_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_DESC_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_DESC_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_DESC_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESCUENTO_ID != original.DESCUENTO_ID) return true;
			if (this.DESCUENTO_NOMBRE != original.DESCUENTO_NOMBRE) return true;
			if (this.DESCUENTO_CONSUMO != original.DESCUENTO_CONSUMO) return true;
			if (this.DESCUENTO_UNICO != original.DESCUENTO_UNICO) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.IsEMPRESA_SECCION_IDNull != original.IsEMPRESA_SECCION_IDNull) return true;
			if (!this.IsEMPRESA_SECCION_IDNull && !original.IsEMPRESA_SECCION_IDNull)
				if (this.EMPRESA_SECCION_ID != original.EMPRESA_SECCION_ID) return true;
			if (this.EMPRESA_SECCION_NOMBRE != original.EMPRESA_SECCION_NOMBRE) return true;
			if (this.EMPRESA_DEPARTAMENTO_ID != original.EMPRESA_DEPARTAMENTO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CANTIDAD_DECIMALES != original.MONEDA_CANTIDAD_DECIMALES) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.UTILIZAR_PORCENTAJE != original.UTILIZAR_PORCENTAJE) return true;
			if (this.PORCENTAJE_SUGERIDO != original.PORCENTAJE_SUGERIDO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.USUARIO_CREACION_NOMBRE != original.USUARIO_CREACION_NOMBRE) return true;
			if (this.IsLIQUIDACION_ASOCIADA_IDNull != original.IsLIQUIDACION_ASOCIADA_IDNull) return true;
			if (!this.IsLIQUIDACION_ASOCIADA_IDNull && !original.IsLIQUIDACION_ASOCIADA_IDNull)
				if (this.LIQUIDACION_ASOCIADA_ID != original.LIQUIDACION_ASOCIADA_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CONSUMO_VISITAS != original.CONSUMO_VISITAS) return true;
			if (this.IsCASO_ORIGEN_IDNull != original.IsCASO_ORIGEN_IDNull) return true;
			if (!this.IsCASO_ORIGEN_IDNull && !original.IsCASO_ORIGEN_IDNull)
				if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			
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
		/// Gets or sets the <c>DESCUENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_ID</c> column value.</value>
		public decimal DESCUENTO_ID
		{
			get { return _descuento_id; }
			set { _descuento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_NOMBRE</c> column value.</value>
		public string DESCUENTO_NOMBRE
		{
			get { return _descuento_nombre; }
			set { _descuento_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_CONSUMO</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_CONSUMO</c> column value.</value>
		public string DESCUENTO_CONSUMO
		{
			get { return _descuento_consumo; }
			set { _descuento_consumo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_UNICO</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_UNICO</c> column value.</value>
		public string DESCUENTO_UNICO
		{
			get { return _descuento_unico; }
			set { _descuento_unico = value; }
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
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
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
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_SECCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCION_ID</c> column value.</value>
		public decimal EMPRESA_SECCION_ID
		{
			get
			{
				if(IsEMPRESA_SECCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _empresa_seccion_id;
			}
			set
			{
				_empresa_seccion_idNull = false;
				_empresa_seccion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EMPRESA_SECCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEMPRESA_SECCION_IDNull
		{
			get { return _empresa_seccion_idNull; }
			set { _empresa_seccion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_SECCION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_SECCION_NOMBRE</c> column value.</value>
		public string EMPRESA_SECCION_NOMBRE
		{
			get { return _empresa_seccion_nombre; }
			set { _empresa_seccion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_DEPARTAMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</value>
		public string EMPRESA_DEPARTAMENTO_ID
		{
			get { return _empresa_departamento_id; }
			set { _empresa_departamento_id = value; }
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
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CANTIDAD_DECIMALES</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_CANTIDAD_DECIMALES</c> column value.</value>
		public decimal MONEDA_CANTIDAD_DECIMALES
		{
			get { return _moneda_cantidad_decimales; }
			set { _moneda_cantidad_decimales = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UTILIZAR_PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>UTILIZAR_PORCENTAJE</c> column value.</value>
		public string UTILIZAR_PORCENTAJE
		{
			get { return _utilizar_porcentaje; }
			set { _utilizar_porcentaje = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_SUGERIDO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_SUGERIDO</c> column value.</value>
		public decimal PORCENTAJE_SUGERIDO
		{
			get { return _porcentaje_sugerido; }
			set { _porcentaje_sugerido = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_NOMBRE</c> column value.</value>
		public string USUARIO_CREACION_NOMBRE
		{
			get { return _usuario_creacion_nombre; }
			set { _usuario_creacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIQUIDACION_ASOCIADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</value>
		public decimal LIQUIDACION_ASOCIADA_ID
		{
			get
			{
				if(IsLIQUIDACION_ASOCIADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _liquidacion_asociada_id;
			}
			set
			{
				_liquidacion_asociada_idNull = false;
				_liquidacion_asociada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIQUIDACION_ASOCIADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIQUIDACION_ASOCIADA_IDNull
		{
			get { return _liquidacion_asociada_idNull; }
			set { _liquidacion_asociada_idNull = value; }
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
		/// Gets or sets the <c>CONSUMO_VISITAS</c> column value.
		/// </summary>
		/// <value>The <c>CONSUMO_VISITAS</c> column value.</value>
		public string CONSUMO_VISITAS
		{
			get { return _consumo_visitas; }
			set { _consumo_visitas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get
			{
				if(IsCASO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_origen_id;
			}
			set
			{
				_caso_origen_idNull = false;
				_caso_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ORIGEN_IDNull
		{
			get { return _caso_origen_idNull; }
			set { _caso_origen_idNull = value; }
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
			dynStr.Append("@CBA@DESCUENTO_ID=");
			dynStr.Append(DESCUENTO_ID);
			dynStr.Append("@CBA@DESCUENTO_NOMBRE=");
			dynStr.Append(DESCUENTO_NOMBRE);
			dynStr.Append("@CBA@DESCUENTO_CONSUMO=");
			dynStr.Append(DESCUENTO_CONSUMO);
			dynStr.Append("@CBA@DESCUENTO_UNICO=");
			dynStr.Append(DESCUENTO_UNICO);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@EMPRESA_SECCION_ID=");
			dynStr.Append(IsEMPRESA_SECCION_IDNull ? (object)"<NULL>" : EMPRESA_SECCION_ID);
			dynStr.Append("@CBA@EMPRESA_SECCION_NOMBRE=");
			dynStr.Append(EMPRESA_SECCION_NOMBRE);
			dynStr.Append("@CBA@EMPRESA_DEPARTAMENTO_ID=");
			dynStr.Append(EMPRESA_DEPARTAMENTO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CANTIDAD_DECIMALES=");
			dynStr.Append(MONEDA_CANTIDAD_DECIMALES);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@UTILIZAR_PORCENTAJE=");
			dynStr.Append(UTILIZAR_PORCENTAJE);
			dynStr.Append("@CBA@PORCENTAJE_SUGERIDO=");
			dynStr.Append(PORCENTAJE_SUGERIDO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_NOMBRE=");
			dynStr.Append(USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@LIQUIDACION_ASOCIADA_ID=");
			dynStr.Append(IsLIQUIDACION_ASOCIADA_IDNull ? (object)"<NULL>" : LIQUIDACION_ASOCIADA_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CONSUMO_VISITAS=");
			dynStr.Append(CONSUMO_VISITAS);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(IsCASO_ORIGEN_IDNull ? (object)"<NULL>" : CASO_ORIGEN_ID);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_DESC_INFO_COMPLRow_Base class
} // End of namespace
