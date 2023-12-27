// <fileinfo name="INMUEBLES_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="INMUEBLES_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>INMUEBLES_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INMUEBLES_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INMUEBLES_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _texto_pred_tipo_inmueble_id;
		private string _tipo_inmueble_texto;
		private string _propietario_nombre;
		private string _propietario_apellido;
		private decimal _persona_propietario_id;
		private bool _persona_propietario_idNull = true;
		private decimal _proveedor_propietario_id;
		private bool _proveedor_propietario_idNull = true;
		private string _persona_nombre;
		private string _persona_apellido;
		private decimal _inmueble_padre_id;
		private bool _inmueble_padre_idNull = true;
		private string _inmueble_padre_nombre;
		private decimal _pais_id;
		private bool _pais_idNull = true;
		private string _pais_nombre;
		private decimal _ciudad_id;
		private bool _ciudad_idNull = true;
		private string _ciudad_nombre;
		private decimal _barrio_id;
		private bool _barrio_idNull = true;
		private string _barrio_nombre;
		private decimal _departamento_id;
		private bool _departamento_idNull = true;
		private string _departamento_nombre;
		private string _lote_numero;
		private decimal _superficie;
		private bool _superficieNull = true;
		private string _cuenta_catastral;
		private string _finca_numero;
		private string _padron_numero;
		private decimal _latitud;
		private bool _latitudNull = true;
		private decimal _longitud;
		private bool _longitudNull = true;
		private string _escriturado;
		private string _piso;
		private string _telefono;
		private string _numero;
		private string _medidor_agua_numero;
		private string _medidor_electricidad_numero;
		private string _nis_electricidad;
		private string _cuenta_catastral_agua;
		private string _es_espacio_comun;
		private string _matricula_nro;
		private decimal _texto_pred_disponibilidad_id;
		private string _disponibilidad_texto;
		private string _nombre;
		private string _calle;
		private string _razon_social;

		/// <summary>
		/// Initializes a new instance of the <see cref="INMUEBLES_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public INMUEBLES_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INMUEBLES_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TEXTO_PRED_TIPO_INMUEBLE_ID != original.TEXTO_PRED_TIPO_INMUEBLE_ID) return true;
			if (this.TIPO_INMUEBLE_TEXTO != original.TIPO_INMUEBLE_TEXTO) return true;
			if (this.PROPIETARIO_NOMBRE != original.PROPIETARIO_NOMBRE) return true;
			if (this.PROPIETARIO_APELLIDO != original.PROPIETARIO_APELLIDO) return true;
			if (this.IsPERSONA_PROPIETARIO_IDNull != original.IsPERSONA_PROPIETARIO_IDNull) return true;
			if (!this.IsPERSONA_PROPIETARIO_IDNull && !original.IsPERSONA_PROPIETARIO_IDNull)
				if (this.PERSONA_PROPIETARIO_ID != original.PERSONA_PROPIETARIO_ID) return true;
			if (this.IsPROVEEDOR_PROPIETARIO_IDNull != original.IsPROVEEDOR_PROPIETARIO_IDNull) return true;
			if (!this.IsPROVEEDOR_PROPIETARIO_IDNull && !original.IsPROVEEDOR_PROPIETARIO_IDNull)
				if (this.PROVEEDOR_PROPIETARIO_ID != original.PROVEEDOR_PROPIETARIO_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_APELLIDO != original.PERSONA_APELLIDO) return true;
			if (this.IsINMUEBLE_PADRE_IDNull != original.IsINMUEBLE_PADRE_IDNull) return true;
			if (!this.IsINMUEBLE_PADRE_IDNull && !original.IsINMUEBLE_PADRE_IDNull)
				if (this.INMUEBLE_PADRE_ID != original.INMUEBLE_PADRE_ID) return true;
			if (this.INMUEBLE_PADRE_NOMBRE != original.INMUEBLE_PADRE_NOMBRE) return true;
			if (this.IsPAIS_IDNull != original.IsPAIS_IDNull) return true;
			if (!this.IsPAIS_IDNull && !original.IsPAIS_IDNull)
				if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.PAIS_NOMBRE != original.PAIS_NOMBRE) return true;
			if (this.IsCIUDAD_IDNull != original.IsCIUDAD_IDNull) return true;
			if (!this.IsCIUDAD_IDNull && !original.IsCIUDAD_IDNull)
				if (this.CIUDAD_ID != original.CIUDAD_ID) return true;
			if (this.CIUDAD_NOMBRE != original.CIUDAD_NOMBRE) return true;
			if (this.IsBARRIO_IDNull != original.IsBARRIO_IDNull) return true;
			if (!this.IsBARRIO_IDNull && !original.IsBARRIO_IDNull)
				if (this.BARRIO_ID != original.BARRIO_ID) return true;
			if (this.BARRIO_NOMBRE != original.BARRIO_NOMBRE) return true;
			if (this.IsDEPARTAMENTO_IDNull != original.IsDEPARTAMENTO_IDNull) return true;
			if (!this.IsDEPARTAMENTO_IDNull && !original.IsDEPARTAMENTO_IDNull)
				if (this.DEPARTAMENTO_ID != original.DEPARTAMENTO_ID) return true;
			if (this.DEPARTAMENTO_NOMBRE != original.DEPARTAMENTO_NOMBRE) return true;
			if (this.LOTE_NUMERO != original.LOTE_NUMERO) return true;
			if (this.IsSUPERFICIENull != original.IsSUPERFICIENull) return true;
			if (!this.IsSUPERFICIENull && !original.IsSUPERFICIENull)
				if (this.SUPERFICIE != original.SUPERFICIE) return true;
			if (this.CUENTA_CATASTRAL != original.CUENTA_CATASTRAL) return true;
			if (this.FINCA_NUMERO != original.FINCA_NUMERO) return true;
			if (this.PADRON_NUMERO != original.PADRON_NUMERO) return true;
			if (this.IsLATITUDNull != original.IsLATITUDNull) return true;
			if (!this.IsLATITUDNull && !original.IsLATITUDNull)
				if (this.LATITUD != original.LATITUD) return true;
			if (this.IsLONGITUDNull != original.IsLONGITUDNull) return true;
			if (!this.IsLONGITUDNull && !original.IsLONGITUDNull)
				if (this.LONGITUD != original.LONGITUD) return true;
			if (this.ESCRITURADO != original.ESCRITURADO) return true;
			if (this.PISO != original.PISO) return true;
			if (this.TELEFONO != original.TELEFONO) return true;
			if (this.NUMERO != original.NUMERO) return true;
			if (this.MEDIDOR_AGUA_NUMERO != original.MEDIDOR_AGUA_NUMERO) return true;
			if (this.MEDIDOR_ELECTRICIDAD_NUMERO != original.MEDIDOR_ELECTRICIDAD_NUMERO) return true;
			if (this.NIS_ELECTRICIDAD != original.NIS_ELECTRICIDAD) return true;
			if (this.CUENTA_CATASTRAL_AGUA != original.CUENTA_CATASTRAL_AGUA) return true;
			if (this.ES_ESPACIO_COMUN != original.ES_ESPACIO_COMUN) return true;
			if (this.MATRICULA_NRO != original.MATRICULA_NRO) return true;
			if (this.TEXTO_PRED_DISPONIBILIDAD_ID != original.TEXTO_PRED_DISPONIBILIDAD_ID) return true;
			if (this.DISPONIBILIDAD_TEXTO != original.DISPONIBILIDAD_TEXTO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.CALLE != original.CALLE) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			
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
		/// Gets or sets the <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.</value>
		public decimal TEXTO_PRED_TIPO_INMUEBLE_ID
		{
			get { return _texto_pred_tipo_inmueble_id; }
			set { _texto_pred_tipo_inmueble_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_INMUEBLE_TEXTO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_INMUEBLE_TEXTO</c> column value.</value>
		public string TIPO_INMUEBLE_TEXTO
		{
			get { return _tipo_inmueble_texto; }
			set { _tipo_inmueble_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROPIETARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROPIETARIO_NOMBRE</c> column value.</value>
		public string PROPIETARIO_NOMBRE
		{
			get { return _propietario_nombre; }
			set { _propietario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROPIETARIO_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROPIETARIO_APELLIDO</c> column value.</value>
		public string PROPIETARIO_APELLIDO
		{
			get { return _propietario_apellido; }
			set { _propietario_apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_PROPIETARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_PROPIETARIO_ID</c> column value.</value>
		public decimal PERSONA_PROPIETARIO_ID
		{
			get
			{
				if(IsPERSONA_PROPIETARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_propietario_id;
			}
			set
			{
				_persona_propietario_idNull = false;
				_persona_propietario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_PROPIETARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_PROPIETARIO_IDNull
		{
			get { return _persona_propietario_idNull; }
			set { _persona_propietario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_PROPIETARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</value>
		public decimal PROVEEDOR_PROPIETARIO_ID
		{
			get
			{
				if(IsPROVEEDOR_PROPIETARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _proveedor_propietario_id;
			}
			set
			{
				_proveedor_propietario_idNull = false;
				_proveedor_propietario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROVEEDOR_PROPIETARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROVEEDOR_PROPIETARIO_IDNull
		{
			get { return _proveedor_propietario_idNull; }
			set { _proveedor_propietario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_APELLIDO</c> column value.</value>
		public string PERSONA_APELLIDO
		{
			get { return _persona_apellido; }
			set { _persona_apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INMUEBLE_PADRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INMUEBLE_PADRE_ID</c> column value.</value>
		public decimal INMUEBLE_PADRE_ID
		{
			get
			{
				if(IsINMUEBLE_PADRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inmueble_padre_id;
			}
			set
			{
				_inmueble_padre_idNull = false;
				_inmueble_padre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INMUEBLE_PADRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINMUEBLE_PADRE_IDNull
		{
			get { return _inmueble_padre_idNull; }
			set { _inmueble_padre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INMUEBLE_PADRE_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INMUEBLE_PADRE_NOMBRE</c> column value.</value>
		public string INMUEBLE_PADRE_NOMBRE
		{
			get { return _inmueble_padre_nombre; }
			set { _inmueble_padre_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get
			{
				if(IsPAIS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pais_id;
			}
			set
			{
				_pais_idNull = false;
				_pais_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAIS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAIS_IDNull
		{
			get { return _pais_idNull; }
			set { _pais_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAIS_NOMBRE</c> column value.</value>
		public string PAIS_NOMBRE
		{
			get { return _pais_nombre; }
			set { _pais_nombre = value; }
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
		/// Gets or sets the <c>CIUDAD_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_NOMBRE</c> column value.</value>
		public string CIUDAD_NOMBRE
		{
			get { return _ciudad_nombre; }
			set { _ciudad_nombre = value; }
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
		/// Gets or sets the <c>BARRIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_NOMBRE</c> column value.</value>
		public string BARRIO_NOMBRE
		{
			get { return _barrio_nombre; }
			set { _barrio_nombre = value; }
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
		/// Gets or sets the <c>DEPARTAMENTO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_NOMBRE</c> column value.</value>
		public string DEPARTAMENTO_NOMBRE
		{
			get { return _departamento_nombre; }
			set { _departamento_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_NUMERO</c> column value.</value>
		public string LOTE_NUMERO
		{
			get { return _lote_numero; }
			set { _lote_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUPERFICIE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUPERFICIE</c> column value.</value>
		public decimal SUPERFICIE
		{
			get
			{
				if(IsSUPERFICIENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _superficie;
			}
			set
			{
				_superficieNull = false;
				_superficie = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUPERFICIE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUPERFICIENull
		{
			get { return _superficieNull; }
			set { _superficieNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_CATASTRAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUENTA_CATASTRAL</c> column value.</value>
		public string CUENTA_CATASTRAL
		{
			get { return _cuenta_catastral; }
			set { _cuenta_catastral = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FINCA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FINCA_NUMERO</c> column value.</value>
		public string FINCA_NUMERO
		{
			get { return _finca_numero; }
			set { _finca_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PADRON_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PADRON_NUMERO</c> column value.</value>
		public string PADRON_NUMERO
		{
			get { return _padron_numero; }
			set { _padron_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD</c> column value.</value>
		public decimal LATITUD
		{
			get
			{
				if(IsLATITUDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud;
			}
			set
			{
				_latitudNull = false;
				_latitud = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUDNull
		{
			get { return _latitudNull; }
			set { _latitudNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD</c> column value.</value>
		public decimal LONGITUD
		{
			get
			{
				if(IsLONGITUDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud;
			}
			set
			{
				_longitudNull = false;
				_longitud = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUDNull
		{
			get { return _longitudNull; }
			set { _longitudNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESCRITURADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESCRITURADO</c> column value.</value>
		public string ESCRITURADO
		{
			get { return _escriturado; }
			set { _escriturado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PISO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PISO</c> column value.</value>
		public string PISO
		{
			get { return _piso; }
			set { _piso = value; }
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
		/// Gets or sets the <c>NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO</c> column value.</value>
		public string NUMERO
		{
			get { return _numero; }
			set { _numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MEDIDOR_AGUA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MEDIDOR_AGUA_NUMERO</c> column value.</value>
		public string MEDIDOR_AGUA_NUMERO
		{
			get { return _medidor_agua_numero; }
			set { _medidor_agua_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MEDIDOR_ELECTRICIDAD_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MEDIDOR_ELECTRICIDAD_NUMERO</c> column value.</value>
		public string MEDIDOR_ELECTRICIDAD_NUMERO
		{
			get { return _medidor_electricidad_numero; }
			set { _medidor_electricidad_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NIS_ELECTRICIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NIS_ELECTRICIDAD</c> column value.</value>
		public string NIS_ELECTRICIDAD
		{
			get { return _nis_electricidad; }
			set { _nis_electricidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA_CATASTRAL_AGUA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUENTA_CATASTRAL_AGUA</c> column value.</value>
		public string CUENTA_CATASTRAL_AGUA
		{
			get { return _cuenta_catastral_agua; }
			set { _cuenta_catastral_agua = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_ESPACIO_COMUN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_ESPACIO_COMUN</c> column value.</value>
		public string ES_ESPACIO_COMUN
		{
			get { return _es_espacio_comun; }
			set { _es_espacio_comun = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MATRICULA_NRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MATRICULA_NRO</c> column value.</value>
		public string MATRICULA_NRO
		{
			get { return _matricula_nro; }
			set { _matricula_nro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.</value>
		public decimal TEXTO_PRED_DISPONIBILIDAD_ID
		{
			get { return _texto_pred_disponibilidad_id; }
			set { _texto_pred_disponibilidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DISPONIBILIDAD_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DISPONIBILIDAD_TEXTO</c> column value.</value>
		public string DISPONIBILIDAD_TEXTO
		{
			get { return _disponibilidad_texto; }
			set { _disponibilidad_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE</c> column value.</value>
		public string CALLE
		{
			get { return _calle; }
			set { _calle = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TEXTO_PRED_TIPO_INMUEBLE_ID=");
			dynStr.Append(TEXTO_PRED_TIPO_INMUEBLE_ID);
			dynStr.Append("@CBA@TIPO_INMUEBLE_TEXTO=");
			dynStr.Append(TIPO_INMUEBLE_TEXTO);
			dynStr.Append("@CBA@PROPIETARIO_NOMBRE=");
			dynStr.Append(PROPIETARIO_NOMBRE);
			dynStr.Append("@CBA@PROPIETARIO_APELLIDO=");
			dynStr.Append(PROPIETARIO_APELLIDO);
			dynStr.Append("@CBA@PERSONA_PROPIETARIO_ID=");
			dynStr.Append(IsPERSONA_PROPIETARIO_IDNull ? (object)"<NULL>" : PERSONA_PROPIETARIO_ID);
			dynStr.Append("@CBA@PROVEEDOR_PROPIETARIO_ID=");
			dynStr.Append(IsPROVEEDOR_PROPIETARIO_IDNull ? (object)"<NULL>" : PROVEEDOR_PROPIETARIO_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_APELLIDO=");
			dynStr.Append(PERSONA_APELLIDO);
			dynStr.Append("@CBA@INMUEBLE_PADRE_ID=");
			dynStr.Append(IsINMUEBLE_PADRE_IDNull ? (object)"<NULL>" : INMUEBLE_PADRE_ID);
			dynStr.Append("@CBA@INMUEBLE_PADRE_NOMBRE=");
			dynStr.Append(INMUEBLE_PADRE_NOMBRE);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(IsPAIS_IDNull ? (object)"<NULL>" : PAIS_ID);
			dynStr.Append("@CBA@PAIS_NOMBRE=");
			dynStr.Append(PAIS_NOMBRE);
			dynStr.Append("@CBA@CIUDAD_ID=");
			dynStr.Append(IsCIUDAD_IDNull ? (object)"<NULL>" : CIUDAD_ID);
			dynStr.Append("@CBA@CIUDAD_NOMBRE=");
			dynStr.Append(CIUDAD_NOMBRE);
			dynStr.Append("@CBA@BARRIO_ID=");
			dynStr.Append(IsBARRIO_IDNull ? (object)"<NULL>" : BARRIO_ID);
			dynStr.Append("@CBA@BARRIO_NOMBRE=");
			dynStr.Append(BARRIO_NOMBRE);
			dynStr.Append("@CBA@DEPARTAMENTO_ID=");
			dynStr.Append(IsDEPARTAMENTO_IDNull ? (object)"<NULL>" : DEPARTAMENTO_ID);
			dynStr.Append("@CBA@DEPARTAMENTO_NOMBRE=");
			dynStr.Append(DEPARTAMENTO_NOMBRE);
			dynStr.Append("@CBA@LOTE_NUMERO=");
			dynStr.Append(LOTE_NUMERO);
			dynStr.Append("@CBA@SUPERFICIE=");
			dynStr.Append(IsSUPERFICIENull ? (object)"<NULL>" : SUPERFICIE);
			dynStr.Append("@CBA@CUENTA_CATASTRAL=");
			dynStr.Append(CUENTA_CATASTRAL);
			dynStr.Append("@CBA@FINCA_NUMERO=");
			dynStr.Append(FINCA_NUMERO);
			dynStr.Append("@CBA@PADRON_NUMERO=");
			dynStr.Append(PADRON_NUMERO);
			dynStr.Append("@CBA@LATITUD=");
			dynStr.Append(IsLATITUDNull ? (object)"<NULL>" : LATITUD);
			dynStr.Append("@CBA@LONGITUD=");
			dynStr.Append(IsLONGITUDNull ? (object)"<NULL>" : LONGITUD);
			dynStr.Append("@CBA@ESCRITURADO=");
			dynStr.Append(ESCRITURADO);
			dynStr.Append("@CBA@PISO=");
			dynStr.Append(PISO);
			dynStr.Append("@CBA@TELEFONO=");
			dynStr.Append(TELEFONO);
			dynStr.Append("@CBA@NUMERO=");
			dynStr.Append(NUMERO);
			dynStr.Append("@CBA@MEDIDOR_AGUA_NUMERO=");
			dynStr.Append(MEDIDOR_AGUA_NUMERO);
			dynStr.Append("@CBA@MEDIDOR_ELECTRICIDAD_NUMERO=");
			dynStr.Append(MEDIDOR_ELECTRICIDAD_NUMERO);
			dynStr.Append("@CBA@NIS_ELECTRICIDAD=");
			dynStr.Append(NIS_ELECTRICIDAD);
			dynStr.Append("@CBA@CUENTA_CATASTRAL_AGUA=");
			dynStr.Append(CUENTA_CATASTRAL_AGUA);
			dynStr.Append("@CBA@ES_ESPACIO_COMUN=");
			dynStr.Append(ES_ESPACIO_COMUN);
			dynStr.Append("@CBA@MATRICULA_NRO=");
			dynStr.Append(MATRICULA_NRO);
			dynStr.Append("@CBA@TEXTO_PRED_DISPONIBILIDAD_ID=");
			dynStr.Append(TEXTO_PRED_DISPONIBILIDAD_ID);
			dynStr.Append("@CBA@DISPONIBILIDAD_TEXTO=");
			dynStr.Append(DISPONIBILIDAD_TEXTO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@CALLE=");
			dynStr.Append(CALLE);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			return dynStr.ToString();
		}
	} // End of INMUEBLES_INFO_COMPLETARow_Base class
} // End of namespace
