// <fileinfo name="CTB_PERIODOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CTB_PERIODOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_PERIODOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PERIODOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _ejercicio_plan_cuenta_id;
		private decimal _ctb_ejercicio_id;
		private string _ejercicio_nombre;
		private decimal _ejercicio_pais_id;
		private decimal _ejercicio_region_id;
		private bool _ejercicio_region_idNull = true;
		private decimal _ejercicio_sucursal_id;
		private bool _ejercicio_sucursal_idNull = true;
		private string _ejercicio_se_abrio;
		private string _ejercicio_se_cerro;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private string _estado;
		private string _nombre;
		private decimal _usuario_creacion_id;
		private string _usuario_creacion_nombre;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_inactivacion_id;
		private bool _usuario_inactivacion_idNull = true;
		private string _usuario_inactivacion_nombre;
		private System.DateTime _fecha_inactivacion;
		private bool _fecha_inactivacionNull = true;
		private string _vigente;
		private string _vigente_por_margen;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PERIODOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CTB_PERIODOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_PERIODOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.EJERCICIO_PLAN_CUENTA_ID != original.EJERCICIO_PLAN_CUENTA_ID) return true;
			if (this.CTB_EJERCICIO_ID != original.CTB_EJERCICIO_ID) return true;
			if (this.EJERCICIO_NOMBRE != original.EJERCICIO_NOMBRE) return true;
			if (this.EJERCICIO_PAIS_ID != original.EJERCICIO_PAIS_ID) return true;
			if (this.IsEJERCICIO_REGION_IDNull != original.IsEJERCICIO_REGION_IDNull) return true;
			if (!this.IsEJERCICIO_REGION_IDNull && !original.IsEJERCICIO_REGION_IDNull)
				if (this.EJERCICIO_REGION_ID != original.EJERCICIO_REGION_ID) return true;
			if (this.IsEJERCICIO_SUCURSAL_IDNull != original.IsEJERCICIO_SUCURSAL_IDNull) return true;
			if (!this.IsEJERCICIO_SUCURSAL_IDNull && !original.IsEJERCICIO_SUCURSAL_IDNull)
				if (this.EJERCICIO_SUCURSAL_ID != original.EJERCICIO_SUCURSAL_ID) return true;
			if (this.EJERCICIO_SE_ABRIO != original.EJERCICIO_SE_ABRIO) return true;
			if (this.EJERCICIO_SE_CERRO != original.EJERCICIO_SE_CERRO) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.USUARIO_CREACION_NOMBRE != original.USUARIO_CREACION_NOMBRE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_INACTIVACION_IDNull != original.IsUSUARIO_INACTIVACION_IDNull) return true;
			if (!this.IsUSUARIO_INACTIVACION_IDNull && !original.IsUSUARIO_INACTIVACION_IDNull)
				if (this.USUARIO_INACTIVACION_ID != original.USUARIO_INACTIVACION_ID) return true;
			if (this.USUARIO_INACTIVACION_NOMBRE != original.USUARIO_INACTIVACION_NOMBRE) return true;
			if (this.IsFECHA_INACTIVACIONNull != original.IsFECHA_INACTIVACIONNull) return true;
			if (!this.IsFECHA_INACTIVACIONNull && !original.IsFECHA_INACTIVACIONNull)
				if (this.FECHA_INACTIVACION != original.FECHA_INACTIVACION) return true;
			if (this.VIGENTE != original.VIGENTE) return true;
			if (this.VIGENTE_POR_MARGEN != original.VIGENTE_POR_MARGEN) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EJERCICIO_PLAN_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>EJERCICIO_PLAN_CUENTA_ID</c> column value.</value>
		public decimal EJERCICIO_PLAN_CUENTA_ID
		{
			get { return _ejercicio_plan_cuenta_id; }
			set { _ejercicio_plan_cuenta_id = value; }
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
		/// Gets or sets the <c>EJERCICIO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>EJERCICIO_NOMBRE</c> column value.</value>
		public string EJERCICIO_NOMBRE
		{
			get { return _ejercicio_nombre; }
			set { _ejercicio_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EJERCICIO_PAIS_ID</c> column value.
		/// </summary>
		/// <value>The <c>EJERCICIO_PAIS_ID</c> column value.</value>
		public decimal EJERCICIO_PAIS_ID
		{
			get { return _ejercicio_pais_id; }
			set { _ejercicio_pais_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EJERCICIO_REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EJERCICIO_REGION_ID</c> column value.</value>
		public decimal EJERCICIO_REGION_ID
		{
			get
			{
				if(IsEJERCICIO_REGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ejercicio_region_id;
			}
			set
			{
				_ejercicio_region_idNull = false;
				_ejercicio_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EJERCICIO_REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEJERCICIO_REGION_IDNull
		{
			get { return _ejercicio_region_idNull; }
			set { _ejercicio_region_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EJERCICIO_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EJERCICIO_SUCURSAL_ID</c> column value.</value>
		public decimal EJERCICIO_SUCURSAL_ID
		{
			get
			{
				if(IsEJERCICIO_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ejercicio_sucursal_id;
			}
			set
			{
				_ejercicio_sucursal_idNull = false;
				_ejercicio_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EJERCICIO_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEJERCICIO_SUCURSAL_IDNull
		{
			get { return _ejercicio_sucursal_idNull; }
			set { _ejercicio_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EJERCICIO_SE_ABRIO</c> column value.
		/// </summary>
		/// <value>The <c>EJERCICIO_SE_ABRIO</c> column value.</value>
		public string EJERCICIO_SE_ABRIO
		{
			get { return _ejercicio_se_abrio; }
			set { _ejercicio_se_abrio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EJERCICIO_SE_CERRO</c> column value.
		/// </summary>
		/// <value>The <c>EJERCICIO_SE_CERRO</c> column value.</value>
		public string EJERCICIO_SE_CERRO
		{
			get { return _ejercicio_se_cerro; }
			set { _ejercicio_se_cerro = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_INACTIVACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_INACTIVACION_ID</c> column value.</value>
		public decimal USUARIO_INACTIVACION_ID
		{
			get
			{
				if(IsUSUARIO_INACTIVACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_inactivacion_id;
			}
			set
			{
				_usuario_inactivacion_idNull = false;
				_usuario_inactivacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_INACTIVACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_INACTIVACION_IDNull
		{
			get { return _usuario_inactivacion_idNull; }
			set { _usuario_inactivacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_INACTIVACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_INACTIVACION_NOMBRE</c> column value.</value>
		public string USUARIO_INACTIVACION_NOMBRE
		{
			get { return _usuario_inactivacion_nombre; }
			set { _usuario_inactivacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INACTIVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INACTIVACION</c> column value.</value>
		public System.DateTime FECHA_INACTIVACION
		{
			get
			{
				if(IsFECHA_INACTIVACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inactivacion;
			}
			set
			{
				_fecha_inactivacionNull = false;
				_fecha_inactivacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INACTIVACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INACTIVACIONNull
		{
			get { return _fecha_inactivacionNull; }
			set { _fecha_inactivacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VIGENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VIGENTE</c> column value.</value>
		public string VIGENTE
		{
			get { return _vigente; }
			set { _vigente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VIGENTE_POR_MARGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VIGENTE_POR_MARGEN</c> column value.</value>
		public string VIGENTE_POR_MARGEN
		{
			get { return _vigente_por_margen; }
			set { _vigente_por_margen = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@EJERCICIO_PLAN_CUENTA_ID=");
			dynStr.Append(EJERCICIO_PLAN_CUENTA_ID);
			dynStr.Append("@CBA@CTB_EJERCICIO_ID=");
			dynStr.Append(CTB_EJERCICIO_ID);
			dynStr.Append("@CBA@EJERCICIO_NOMBRE=");
			dynStr.Append(EJERCICIO_NOMBRE);
			dynStr.Append("@CBA@EJERCICIO_PAIS_ID=");
			dynStr.Append(EJERCICIO_PAIS_ID);
			dynStr.Append("@CBA@EJERCICIO_REGION_ID=");
			dynStr.Append(IsEJERCICIO_REGION_IDNull ? (object)"<NULL>" : EJERCICIO_REGION_ID);
			dynStr.Append("@CBA@EJERCICIO_SUCURSAL_ID=");
			dynStr.Append(IsEJERCICIO_SUCURSAL_IDNull ? (object)"<NULL>" : EJERCICIO_SUCURSAL_ID);
			dynStr.Append("@CBA@EJERCICIO_SE_ABRIO=");
			dynStr.Append(EJERCICIO_SE_ABRIO);
			dynStr.Append("@CBA@EJERCICIO_SE_CERRO=");
			dynStr.Append(EJERCICIO_SE_CERRO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(FECHA_FIN);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_NOMBRE=");
			dynStr.Append(USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_INACTIVACION_ID=");
			dynStr.Append(IsUSUARIO_INACTIVACION_IDNull ? (object)"<NULL>" : USUARIO_INACTIVACION_ID);
			dynStr.Append("@CBA@USUARIO_INACTIVACION_NOMBRE=");
			dynStr.Append(USUARIO_INACTIVACION_NOMBRE);
			dynStr.Append("@CBA@FECHA_INACTIVACION=");
			dynStr.Append(IsFECHA_INACTIVACIONNull ? (object)"<NULL>" : FECHA_INACTIVACION);
			dynStr.Append("@CBA@VIGENTE=");
			dynStr.Append(VIGENTE);
			dynStr.Append("@CBA@VIGENTE_POR_MARGEN=");
			dynStr.Append(VIGENTE_POR_MARGEN);
			return dynStr.ToString();
		}
	} // End of CTB_PERIODOS_INFO_COMPLETARow_Base class
} // End of namespace
