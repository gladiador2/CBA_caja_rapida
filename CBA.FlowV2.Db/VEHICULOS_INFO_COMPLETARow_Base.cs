// <fileinfo name="VEHICULOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="VEHICULOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>VEHICULOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="VEHICULOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VEHICULOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _tipo_vehiculo_id;
		private string _tipo_vehiculo_nombre;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _chofer_habitual_id;
		private bool _chofer_habitual_idNull = true;
		private string _nombre;
		private string _abreviatura;
		private string _matricula;
		private string _marca;
		private string _modelo;
		private decimal _anho;
		private bool _anhoNull = true;
		private string _color;
		private decimal _consumo_estimado;
		private bool _consumo_estimadoNull = true;
		private decimal _kilometraje_inicial;
		private decimal _kilometraje_actual;
		private string _tipo_combustible;
		private decimal _cantidad_km_entre_mantenim;
		private bool _cantidad_km_entre_mantenimNull = true;
		private decimal _cantidad_dias_entre_mantenim;
		private bool _cantidad_dias_entre_mantenimNull = true;
		private decimal _kilometraje_ultimo_mantenimien;
		private bool _kilometraje_ultimo_mantenimienNull = true;
		private System.DateTime _fecha_ultimo_mantenimiento;
		private bool _fecha_ultimo_mantenimientoNull = true;
		private System.DateTime _fecha_vencimiento_poliza;
		private bool _fecha_vencimiento_polizaNull = true;
		private System.DateTime _fecha_vencimiento_patente;
		private bool _fecha_vencimiento_patenteNull = true;
		private System.DateTime _fecha_ingreso;
		private bool _fecha_ingresoNull = true;
		private System.DateTime _fecha_inactivado;
		private bool _fecha_inactivadoNull = true;
		private string _estado;
		private string _chasis_nro;
		private decimal _proveedor_id;
		private bool _proveedor_idNull = true;
		private string _razon_social;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _nombre_completo;
		private decimal _nro_celdas;
		private bool _nro_celdasNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="VEHICULOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public VEHICULOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(VEHICULOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_VEHICULO_ID != original.TIPO_VEHICULO_ID) return true;
			if (this.TIPO_VEHICULO_NOMBRE != original.TIPO_VEHICULO_NOMBRE) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.IsCHOFER_HABITUAL_IDNull != original.IsCHOFER_HABITUAL_IDNull) return true;
			if (!this.IsCHOFER_HABITUAL_IDNull && !original.IsCHOFER_HABITUAL_IDNull)
				if (this.CHOFER_HABITUAL_ID != original.CHOFER_HABITUAL_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ABREVIATURA != original.ABREVIATURA) return true;
			if (this.MATRICULA != original.MATRICULA) return true;
			if (this.MARCA != original.MARCA) return true;
			if (this.MODELO != original.MODELO) return true;
			if (this.IsANHONull != original.IsANHONull) return true;
			if (!this.IsANHONull && !original.IsANHONull)
				if (this.ANHO != original.ANHO) return true;
			if (this.COLOR != original.COLOR) return true;
			if (this.IsCONSUMO_ESTIMADONull != original.IsCONSUMO_ESTIMADONull) return true;
			if (!this.IsCONSUMO_ESTIMADONull && !original.IsCONSUMO_ESTIMADONull)
				if (this.CONSUMO_ESTIMADO != original.CONSUMO_ESTIMADO) return true;
			if (this.KILOMETRAJE_INICIAL != original.KILOMETRAJE_INICIAL) return true;
			if (this.KILOMETRAJE_ACTUAL != original.KILOMETRAJE_ACTUAL) return true;
			if (this.TIPO_COMBUSTIBLE != original.TIPO_COMBUSTIBLE) return true;
			if (this.IsCANTIDAD_KM_ENTRE_MANTENIMNull != original.IsCANTIDAD_KM_ENTRE_MANTENIMNull) return true;
			if (!this.IsCANTIDAD_KM_ENTRE_MANTENIMNull && !original.IsCANTIDAD_KM_ENTRE_MANTENIMNull)
				if (this.CANTIDAD_KM_ENTRE_MANTENIM != original.CANTIDAD_KM_ENTRE_MANTENIM) return true;
			if (this.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull != original.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull) return true;
			if (!this.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull && !original.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull)
				if (this.CANTIDAD_DIAS_ENTRE_MANTENIM != original.CANTIDAD_DIAS_ENTRE_MANTENIM) return true;
			if (this.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull != original.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull) return true;
			if (!this.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull && !original.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull)
				if (this.KILOMETRAJE_ULTIMO_MANTENIMIEN != original.KILOMETRAJE_ULTIMO_MANTENIMIEN) return true;
			if (this.IsFECHA_ULTIMO_MANTENIMIENTONull != original.IsFECHA_ULTIMO_MANTENIMIENTONull) return true;
			if (!this.IsFECHA_ULTIMO_MANTENIMIENTONull && !original.IsFECHA_ULTIMO_MANTENIMIENTONull)
				if (this.FECHA_ULTIMO_MANTENIMIENTO != original.FECHA_ULTIMO_MANTENIMIENTO) return true;
			if (this.IsFECHA_VENCIMIENTO_POLIZANull != original.IsFECHA_VENCIMIENTO_POLIZANull) return true;
			if (!this.IsFECHA_VENCIMIENTO_POLIZANull && !original.IsFECHA_VENCIMIENTO_POLIZANull)
				if (this.FECHA_VENCIMIENTO_POLIZA != original.FECHA_VENCIMIENTO_POLIZA) return true;
			if (this.IsFECHA_VENCIMIENTO_PATENTENull != original.IsFECHA_VENCIMIENTO_PATENTENull) return true;
			if (!this.IsFECHA_VENCIMIENTO_PATENTENull && !original.IsFECHA_VENCIMIENTO_PATENTENull)
				if (this.FECHA_VENCIMIENTO_PATENTE != original.FECHA_VENCIMIENTO_PATENTE) return true;
			if (this.IsFECHA_INGRESONull != original.IsFECHA_INGRESONull) return true;
			if (!this.IsFECHA_INGRESONull && !original.IsFECHA_INGRESONull)
				if (this.FECHA_INGRESO != original.FECHA_INGRESO) return true;
			if (this.IsFECHA_INACTIVADONull != original.IsFECHA_INACTIVADONull) return true;
			if (!this.IsFECHA_INACTIVADONull && !original.IsFECHA_INACTIVADONull)
				if (this.FECHA_INACTIVADO != original.FECHA_INACTIVADO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.CHASIS_NRO != original.CHASIS_NRO) return true;
			if (this.IsPROVEEDOR_IDNull != original.IsPROVEEDOR_IDNull) return true;
			if (!this.IsPROVEEDOR_IDNull && !original.IsPROVEEDOR_IDNull)
				if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.IsNRO_CELDASNull != original.IsNRO_CELDASNull) return true;
			if (!this.IsNRO_CELDASNull && !original.IsNRO_CELDASNull)
				if (this.NRO_CELDAS != original.NRO_CELDAS) return true;
			
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
		/// Gets or sets the <c>TIPO_VEHICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_VEHICULO_ID</c> column value.</value>
		public decimal TIPO_VEHICULO_ID
		{
			get { return _tipo_vehiculo_id; }
			set { _tipo_vehiculo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_VEHICULO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_VEHICULO_NOMBRE</c> column value.</value>
		public string TIPO_VEHICULO_NOMBRE
		{
			get { return _tipo_vehiculo_nombre; }
			set { _tipo_vehiculo_nombre = value; }
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
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_HABITUAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_HABITUAL_ID</c> column value.</value>
		public decimal CHOFER_HABITUAL_ID
		{
			get
			{
				if(IsCHOFER_HABITUAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _chofer_habitual_id;
			}
			set
			{
				_chofer_habitual_idNull = false;
				_chofer_habitual_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CHOFER_HABITUAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCHOFER_HABITUAL_IDNull
		{
			get { return _chofer_habitual_idNull; }
			set { _chofer_habitual_idNull = value; }
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
		/// Gets or sets the <c>MATRICULA</c> column value.
		/// </summary>
		/// <value>The <c>MATRICULA</c> column value.</value>
		public string MATRICULA
		{
			get { return _matricula; }
			set { _matricula = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCA</c> column value.</value>
		public string MARCA
		{
			get { return _marca; }
			set { _marca = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MODELO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MODELO</c> column value.</value>
		public string MODELO
		{
			get { return _modelo; }
			set { _modelo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public decimal ANHO
		{
			get
			{
				if(IsANHONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anho;
			}
			set
			{
				_anhoNull = false;
				_anho = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANHO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANHONull
		{
			get { return _anhoNull; }
			set { _anhoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLOR</c> column value.</value>
		public string COLOR
		{
			get { return _color; }
			set { _color = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSUMO_ESTIMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSUMO_ESTIMADO</c> column value.</value>
		public decimal CONSUMO_ESTIMADO
		{
			get
			{
				if(IsCONSUMO_ESTIMADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _consumo_estimado;
			}
			set
			{
				_consumo_estimadoNull = false;
				_consumo_estimado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONSUMO_ESTIMADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONSUMO_ESTIMADONull
		{
			get { return _consumo_estimadoNull; }
			set { _consumo_estimadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>KILOMETRAJE_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>KILOMETRAJE_INICIAL</c> column value.</value>
		public decimal KILOMETRAJE_INICIAL
		{
			get { return _kilometraje_inicial; }
			set { _kilometraje_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>KILOMETRAJE_ACTUAL</c> column value.
		/// </summary>
		/// <value>The <c>KILOMETRAJE_ACTUAL</c> column value.</value>
		public decimal KILOMETRAJE_ACTUAL
		{
			get { return _kilometraje_actual; }
			set { _kilometraje_actual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_COMBUSTIBLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_COMBUSTIBLE</c> column value.</value>
		public string TIPO_COMBUSTIBLE
		{
			get { return _tipo_combustible; }
			set { _tipo_combustible = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_KM_ENTRE_MANTENIM</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_KM_ENTRE_MANTENIM</c> column value.</value>
		public decimal CANTIDAD_KM_ENTRE_MANTENIM
		{
			get
			{
				if(IsCANTIDAD_KM_ENTRE_MANTENIMNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_km_entre_mantenim;
			}
			set
			{
				_cantidad_km_entre_mantenimNull = false;
				_cantidad_km_entre_mantenim = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_KM_ENTRE_MANTENIM"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_KM_ENTRE_MANTENIMNull
		{
			get { return _cantidad_km_entre_mantenimNull; }
			set { _cantidad_km_entre_mantenimNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DIAS_ENTRE_MANTENIM</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DIAS_ENTRE_MANTENIM</c> column value.</value>
		public decimal CANTIDAD_DIAS_ENTRE_MANTENIM
		{
			get
			{
				if(IsCANTIDAD_DIAS_ENTRE_MANTENIMNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_dias_entre_mantenim;
			}
			set
			{
				_cantidad_dias_entre_mantenimNull = false;
				_cantidad_dias_entre_mantenim = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DIAS_ENTRE_MANTENIM"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DIAS_ENTRE_MANTENIMNull
		{
			get { return _cantidad_dias_entre_mantenimNull; }
			set { _cantidad_dias_entre_mantenimNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>KILOMETRAJE_ULTIMO_MANTENIMIEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>KILOMETRAJE_ULTIMO_MANTENIMIEN</c> column value.</value>
		public decimal KILOMETRAJE_ULTIMO_MANTENIMIEN
		{
			get
			{
				if(IsKILOMETRAJE_ULTIMO_MANTENIMIENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _kilometraje_ultimo_mantenimien;
			}
			set
			{
				_kilometraje_ultimo_mantenimienNull = false;
				_kilometraje_ultimo_mantenimien = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="KILOMETRAJE_ULTIMO_MANTENIMIEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsKILOMETRAJE_ULTIMO_MANTENIMIENNull
		{
			get { return _kilometraje_ultimo_mantenimienNull; }
			set { _kilometraje_ultimo_mantenimienNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMO_MANTENIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMO_MANTENIMIENTO</c> column value.</value>
		public System.DateTime FECHA_ULTIMO_MANTENIMIENTO
		{
			get
			{
				if(IsFECHA_ULTIMO_MANTENIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultimo_mantenimiento;
			}
			set
			{
				_fecha_ultimo_mantenimientoNull = false;
				_fecha_ultimo_mantenimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMO_MANTENIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMO_MANTENIMIENTONull
		{
			get { return _fecha_ultimo_mantenimientoNull; }
			set { _fecha_ultimo_mantenimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO_POLIZA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO_POLIZA</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO_POLIZA
		{
			get
			{
				if(IsFECHA_VENCIMIENTO_POLIZANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento_poliza;
			}
			set
			{
				_fecha_vencimiento_polizaNull = false;
				_fecha_vencimiento_poliza = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO_POLIZA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTO_POLIZANull
		{
			get { return _fecha_vencimiento_polizaNull; }
			set { _fecha_vencimiento_polizaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_VENCIMIENTO_PATENTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO_PATENTE</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO_PATENTE
		{
			get
			{
				if(IsFECHA_VENCIMIENTO_PATENTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento_patente;
			}
			set
			{
				_fecha_vencimiento_patenteNull = false;
				_fecha_vencimiento_patente = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO_PATENTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTO_PATENTENull
		{
			get { return _fecha_vencimiento_patenteNull; }
			set { _fecha_vencimiento_patenteNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INGRESO</c> column value.</value>
		public System.DateTime FECHA_INGRESO
		{
			get
			{
				if(IsFECHA_INGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ingreso;
			}
			set
			{
				_fecha_ingresoNull = false;
				_fecha_ingreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INGRESONull
		{
			get { return _fecha_ingresoNull; }
			set { _fecha_ingresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INACTIVADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INACTIVADO</c> column value.</value>
		public System.DateTime FECHA_INACTIVADO
		{
			get
			{
				if(IsFECHA_INACTIVADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inactivado;
			}
			set
			{
				_fecha_inactivadoNull = false;
				_fecha_inactivado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INACTIVADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INACTIVADONull
		{
			get { return _fecha_inactivadoNull; }
			set { _fecha_inactivadoNull = value; }
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
		/// Gets or sets the <c>CHASIS_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHASIS_NRO</c> column value.</value>
		public string CHASIS_NRO
		{
			get { return _chasis_nro; }
			set { _chasis_nro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get
			{
				if(IsPROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_id;
			}
			set
			{
				_proveedor_idNull = false;
				_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_IDNull
		{
			get { return _proveedor_idNull; }
			set { _proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_SOCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RAZON_SOCIAL</c> column value.</value>
		public string RAZON_SOCIAL
		{
			get { return _razon_social; }
			set { _razon_social = value; }
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
		/// Gets or sets the <c>NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_COMPLETO</c> column value.</value>
		public string NOMBRE_COMPLETO
		{
			get { return _nombre_completo; }
			set { _nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_CELDAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_CELDAS</c> column value.</value>
		public decimal NRO_CELDAS
		{
			get
			{
				if(IsNRO_CELDASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_celdas;
			}
			set
			{
				_nro_celdasNull = false;
				_nro_celdas = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_CELDAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_CELDASNull
		{
			get { return _nro_celdasNull; }
			set { _nro_celdasNull = value; }
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
			dynStr.Append("@CBA@TIPO_VEHICULO_ID=");
			dynStr.Append(TIPO_VEHICULO_ID);
			dynStr.Append("@CBA@TIPO_VEHICULO_NOMBRE=");
			dynStr.Append(TIPO_VEHICULO_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@CHOFER_HABITUAL_ID=");
			dynStr.Append(IsCHOFER_HABITUAL_IDNull ? (object)"<NULL>" : CHOFER_HABITUAL_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ABREVIATURA=");
			dynStr.Append(ABREVIATURA);
			dynStr.Append("@CBA@MATRICULA=");
			dynStr.Append(MATRICULA);
			dynStr.Append("@CBA@MARCA=");
			dynStr.Append(MARCA);
			dynStr.Append("@CBA@MODELO=");
			dynStr.Append(MODELO);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(IsANHONull ? (object)"<NULL>" : ANHO);
			dynStr.Append("@CBA@COLOR=");
			dynStr.Append(COLOR);
			dynStr.Append("@CBA@CONSUMO_ESTIMADO=");
			dynStr.Append(IsCONSUMO_ESTIMADONull ? (object)"<NULL>" : CONSUMO_ESTIMADO);
			dynStr.Append("@CBA@KILOMETRAJE_INICIAL=");
			dynStr.Append(KILOMETRAJE_INICIAL);
			dynStr.Append("@CBA@KILOMETRAJE_ACTUAL=");
			dynStr.Append(KILOMETRAJE_ACTUAL);
			dynStr.Append("@CBA@TIPO_COMBUSTIBLE=");
			dynStr.Append(TIPO_COMBUSTIBLE);
			dynStr.Append("@CBA@CANTIDAD_KM_ENTRE_MANTENIM=");
			dynStr.Append(IsCANTIDAD_KM_ENTRE_MANTENIMNull ? (object)"<NULL>" : CANTIDAD_KM_ENTRE_MANTENIM);
			dynStr.Append("@CBA@CANTIDAD_DIAS_ENTRE_MANTENIM=");
			dynStr.Append(IsCANTIDAD_DIAS_ENTRE_MANTENIMNull ? (object)"<NULL>" : CANTIDAD_DIAS_ENTRE_MANTENIM);
			dynStr.Append("@CBA@KILOMETRAJE_ULTIMO_MANTENIMIEN=");
			dynStr.Append(IsKILOMETRAJE_ULTIMO_MANTENIMIENNull ? (object)"<NULL>" : KILOMETRAJE_ULTIMO_MANTENIMIEN);
			dynStr.Append("@CBA@FECHA_ULTIMO_MANTENIMIENTO=");
			dynStr.Append(IsFECHA_ULTIMO_MANTENIMIENTONull ? (object)"<NULL>" : FECHA_ULTIMO_MANTENIMIENTO);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_POLIZA=");
			dynStr.Append(IsFECHA_VENCIMIENTO_POLIZANull ? (object)"<NULL>" : FECHA_VENCIMIENTO_POLIZA);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_PATENTE=");
			dynStr.Append(IsFECHA_VENCIMIENTO_PATENTENull ? (object)"<NULL>" : FECHA_VENCIMIENTO_PATENTE);
			dynStr.Append("@CBA@FECHA_INGRESO=");
			dynStr.Append(IsFECHA_INGRESONull ? (object)"<NULL>" : FECHA_INGRESO);
			dynStr.Append("@CBA@FECHA_INACTIVADO=");
			dynStr.Append(IsFECHA_INACTIVADONull ? (object)"<NULL>" : FECHA_INACTIVADO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@CHASIS_NRO=");
			dynStr.Append(CHASIS_NRO);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(IsPROVEEDOR_IDNull ? (object)"<NULL>" : PROVEEDOR_ID);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@NRO_CELDAS=");
			dynStr.Append(IsNRO_CELDASNull ? (object)"<NULL>" : NRO_CELDAS);
			return dynStr.ToString();
		}
	} // End of VEHICULOS_INFO_COMPLETARow_Base class
} // End of namespace
