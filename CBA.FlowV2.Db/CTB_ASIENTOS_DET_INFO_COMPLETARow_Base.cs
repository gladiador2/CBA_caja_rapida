// <fileinfo name="CTB_ASIENTOS_DET_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_DET_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_DET_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _ctb_asiento_id;
		private decimal _ctb_cuenta_id;
		private decimal _ctb_plan_cuenta_id;
		private string _ctb_plan_cuenta_nombre;
		private string _ctb_cuenta_codigo_completo;
		private string _codigo_completo_sin_ceros;
		private string _ctb_cuenta_nombre;
		private decimal _ctb_cuenta_madre_id;
		private bool _ctb_cuenta_madre_idNull = true;
		private decimal _debe;
		private decimal _haber;
		private string _observacion;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private string _moneda_nombre;
		private string _moneda_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _orden;
		private bool _ordenNull = true;
		private decimal _debe_origen;
		private bool _debe_origenNull = true;
		private decimal _haber_origen;
		private bool _haber_origenNull = true;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private string _moneda_origen_nombre;
		private string _moneda_origen_simbolo;
		private decimal _cotizacion_moneda_origen;
		private bool _cotizacion_moneda_origenNull = true;
		private string _observacion_sistema;
		private decimal _usuario_creacion_id;
		private decimal _ctb_ejercicio_id;
		private string _usuario_creacion_nombre;
		private string _estado;
		private string _centros_costos;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_DET_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_DET_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_ASIENTO_ID != original.CTB_ASIENTO_ID) return true;
			if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.CTB_PLAN_CUENTA_ID != original.CTB_PLAN_CUENTA_ID) return true;
			if (this.CTB_PLAN_CUENTA_NOMBRE != original.CTB_PLAN_CUENTA_NOMBRE) return true;
			if (this.CTB_CUENTA_CODIGO_COMPLETO != original.CTB_CUENTA_CODIGO_COMPLETO) return true;
			if (this.CODIGO_COMPLETO_SIN_CEROS != original.CODIGO_COMPLETO_SIN_CEROS) return true;
			if (this.CTB_CUENTA_NOMBRE != original.CTB_CUENTA_NOMBRE) return true;
			if (this.IsCTB_CUENTA_MADRE_IDNull != original.IsCTB_CUENTA_MADRE_IDNull) return true;
			if (!this.IsCTB_CUENTA_MADRE_IDNull && !original.IsCTB_CUENTA_MADRE_IDNull)
				if (this.CTB_CUENTA_MADRE_ID != original.CTB_CUENTA_MADRE_ID) return true;
			if (this.DEBE != original.DEBE) return true;
			if (this.HABER != original.HABER) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_NOMBRE != original.MONEDA_NOMBRE) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.IsDEBE_ORIGENNull != original.IsDEBE_ORIGENNull) return true;
			if (!this.IsDEBE_ORIGENNull && !original.IsDEBE_ORIGENNull)
				if (this.DEBE_ORIGEN != original.DEBE_ORIGEN) return true;
			if (this.IsHABER_ORIGENNull != original.IsHABER_ORIGENNull) return true;
			if (!this.IsHABER_ORIGENNull && !original.IsHABER_ORIGENNull)
				if (this.HABER_ORIGEN != original.HABER_ORIGEN) return true;
			if (this.IsMONEDA_ORIGEN_IDNull != original.IsMONEDA_ORIGEN_IDNull) return true;
			if (!this.IsMONEDA_ORIGEN_IDNull && !original.IsMONEDA_ORIGEN_IDNull)
				if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.MONEDA_ORIGEN_NOMBRE != original.MONEDA_ORIGEN_NOMBRE) return true;
			if (this.MONEDA_ORIGEN_SIMBOLO != original.MONEDA_ORIGEN_SIMBOLO) return true;
			if (this.IsCOTIZACION_MONEDA_ORIGENNull != original.IsCOTIZACION_MONEDA_ORIGENNull) return true;
			if (!this.IsCOTIZACION_MONEDA_ORIGENNull && !original.IsCOTIZACION_MONEDA_ORIGENNull)
				if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.OBSERVACION_SISTEMA != original.OBSERVACION_SISTEMA) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.CTB_EJERCICIO_ID != original.CTB_EJERCICIO_ID) return true;
			if (this.USUARIO_CREACION_NOMBRE != original.USUARIO_CREACION_NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CENTROS_COSTOS != original.CENTROS_COSTOS) return true;
			
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
		/// Gets or sets the <c>CTB_ASIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_ID</c> column value.</value>
		public decimal CTB_ASIENTO_ID
		{
			get { return _ctb_asiento_id; }
			set { _ctb_asiento_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get { return _ctb_cuenta_id; }
			set { _ctb_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_ID</c> column value.</value>
		public decimal CTB_PLAN_CUENTA_ID
		{
			get { return _ctb_plan_cuenta_id; }
			set { _ctb_plan_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_PLAN_CUENTA_NOMBRE
		{
			get { return _ctb_plan_cuenta_nombre; }
			set { _ctb_plan_cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_CODIGO_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_CODIGO_COMPLETO</c> column value.</value>
		public string CTB_CUENTA_CODIGO_COMPLETO
		{
			get { return _ctb_cuenta_codigo_completo; }
			set { _ctb_cuenta_codigo_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_COMPLETO_SIN_CEROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_COMPLETO_SIN_CEROS</c> column value.</value>
		public string CODIGO_COMPLETO_SIN_CEROS
		{
			get { return _codigo_completo_sin_ceros; }
			set { _codigo_completo_sin_ceros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_CUENTA_NOMBRE
		{
			get { return _ctb_cuenta_nombre; }
			set { _ctb_cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_MADRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_MADRE_ID</c> column value.</value>
		public decimal CTB_CUENTA_MADRE_ID
		{
			get
			{
				if(IsCTB_CUENTA_MADRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta_madre_id;
			}
			set
			{
				_ctb_cuenta_madre_idNull = false;
				_ctb_cuenta_madre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA_MADRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTA_MADRE_IDNull
		{
			get { return _ctb_cuenta_madre_idNull; }
			set { _ctb_cuenta_madre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBE</c> column value.
		/// </summary>
		/// <value>The <c>DEBE</c> column value.</value>
		public decimal DEBE
		{
			get { return _debe; }
			set { _debe = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HABER</c> column value.
		/// </summary>
		/// <value>The <c>HABER</c> column value.</value>
		public decimal HABER
		{
			get { return _haber; }
			set { _haber = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEBE_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEBE_ORIGEN</c> column value.</value>
		public decimal DEBE_ORIGEN
		{
			get
			{
				if(IsDEBE_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _debe_origen;
			}
			set
			{
				_debe_origenNull = false;
				_debe_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEBE_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEBE_ORIGENNull
		{
			get { return _debe_origenNull; }
			set { _debe_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HABER_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HABER_ORIGEN</c> column value.</value>
		public decimal HABER_ORIGEN
		{
			get
			{
				if(IsHABER_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _haber_origen;
			}
			set
			{
				_haber_origenNull = false;
				_haber_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HABER_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHABER_ORIGENNull
		{
			get { return _haber_origenNull; }
			set { _haber_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get
			{
				if(IsMONEDA_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_origen_id;
			}
			set
			{
				_moneda_origen_idNull = false;
				_moneda_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_ORIGEN_IDNull
		{
			get { return _moneda_origen_idNull; }
			set { _moneda_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_NOMBRE</c> column value.</value>
		public string MONEDA_ORIGEN_NOMBRE
		{
			get { return _moneda_origen_nombre; }
			set { _moneda_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_SIMBOLO</c> column value.</value>
		public string MONEDA_ORIGEN_SIMBOLO
		{
			get { return _moneda_origen_simbolo; }
			set { _moneda_origen_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get
			{
				if(IsCOTIZACION_MONEDA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda_origen;
			}
			set
			{
				_cotizacion_moneda_origenNull = false;
				_cotizacion_moneda_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDA_ORIGENNull
		{
			get { return _cotizacion_moneda_origenNull; }
			set { _cotizacion_moneda_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_SISTEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_SISTEMA</c> column value.</value>
		public string OBSERVACION_SISTEMA
		{
			get { return _observacion_sistema; }
			set { _observacion_sistema = value; }
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
		/// Gets or sets the <c>CTB_EJERCICIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_EJERCICIO_ID</c> column value.</value>
		public decimal CTB_EJERCICIO_ID
		{
			get { return _ctb_ejercicio_id; }
			set { _ctb_ejercicio_id = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTROS_COSTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CENTROS_COSTOS</c> column value.</value>
		public string CENTROS_COSTOS
		{
			get { return _centros_costos; }
			set { _centros_costos = value; }
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
			dynStr.Append("@CBA@CTB_ASIENTO_ID=");
			dynStr.Append(CTB_ASIENTO_ID);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(CTB_CUENTA_ID);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_ID=");
			dynStr.Append(CTB_PLAN_CUENTA_ID);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_NOMBRE=");
			dynStr.Append(CTB_PLAN_CUENTA_NOMBRE);
			dynStr.Append("@CBA@CTB_CUENTA_CODIGO_COMPLETO=");
			dynStr.Append(CTB_CUENTA_CODIGO_COMPLETO);
			dynStr.Append("@CBA@CODIGO_COMPLETO_SIN_CEROS=");
			dynStr.Append(CODIGO_COMPLETO_SIN_CEROS);
			dynStr.Append("@CBA@CTB_CUENTA_NOMBRE=");
			dynStr.Append(CTB_CUENTA_NOMBRE);
			dynStr.Append("@CBA@CTB_CUENTA_MADRE_ID=");
			dynStr.Append(IsCTB_CUENTA_MADRE_IDNull ? (object)"<NULL>" : CTB_CUENTA_MADRE_ID);
			dynStr.Append("@CBA@DEBE=");
			dynStr.Append(DEBE);
			dynStr.Append("@CBA@HABER=");
			dynStr.Append(HABER);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_NOMBRE=");
			dynStr.Append(MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@DEBE_ORIGEN=");
			dynStr.Append(IsDEBE_ORIGENNull ? (object)"<NULL>" : DEBE_ORIGEN);
			dynStr.Append("@CBA@HABER_ORIGEN=");
			dynStr.Append(IsHABER_ORIGENNull ? (object)"<NULL>" : HABER_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_NOMBRE=");
			dynStr.Append(MONEDA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ORIGEN_SIMBOLO=");
			dynStr.Append(MONEDA_ORIGEN_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(IsCOTIZACION_MONEDA_ORIGENNull ? (object)"<NULL>" : COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@OBSERVACION_SISTEMA=");
			dynStr.Append(OBSERVACION_SISTEMA);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@CTB_EJERCICIO_ID=");
			dynStr.Append(CTB_EJERCICIO_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_NOMBRE=");
			dynStr.Append(USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CENTROS_COSTOS=");
			dynStr.Append(CENTROS_COSTOS);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_DET_INFO_COMPLETARow_Base class
} // End of namespace
