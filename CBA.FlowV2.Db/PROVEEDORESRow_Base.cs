// <fileinfo name="PROVEEDORESRow_Base.cs">
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
	/// The base class for <see cref="PROVEEDORESRow"/> that 
	/// represents a record in the <c>PROVEEDORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PROVEEDORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PROVEEDORESRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private string _codigo;
		private string _razon_social;
		private string _nombre_fantasia;
		private decimal _rubro_id;
		private bool _rubro_idNull = true;
		private string _ruc;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _opera_credito;
		private decimal _condicion_habitual_pago_id;
		private bool _condicion_habitual_pago_idNull = true;
		private decimal _pais_id;
		private decimal _departamento1_id;
		private bool _departamento1_idNull = true;
		private decimal _ciudad1_id;
		private bool _ciudad1_idNull = true;
		private decimal _barrio1_id;
		private bool _barrio1_idNull = true;
		private string _calle1;
		private string _codigo_postal1;
		private decimal _latitud1;
		private bool _latitud1Null = true;
		private decimal _longitud1;
		private bool _longitud1Null = true;
		private decimal _departamento2_id;
		private bool _departamento2_idNull = true;
		private decimal _ciudad2_id;
		private bool _ciudad2_idNull = true;
		private decimal _barrio2_id;
		private bool _barrio2_idNull = true;
		private string _calle2;
		private string _codigo_postal2;
		private decimal _latitud2;
		private bool _latitud2Null = true;
		private decimal _longitud2;
		private bool _longitud2Null = true;
		private string _telefono1;
		private string _telefono2;
		private string _telefono3;
		private string _telefono4;
		private string _email1;
		private string _email2;
		private string _email3;
		private string _pasible_retencion;
		private string _bandera_retencion;
		private System.DateTime _fecha_fundacion;
		private bool _fecha_fundacionNull = true;
		private string _contacto_persona;
		private string _contacto_telefono;
		private string _estado;
		private string _ingreso_aprobado;
		private decimal _usuario_aprobacion_id;
		private bool _usuario_aprobacion_idNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private string _solicita_referencia;
		private string _es_nacional;
		private string _fc_observacion_detalle;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private string _contacto_email;
		private string _es_contribuyente;
		private System.DateTime _fecha_desde_no_retener;
		private bool _fecha_desde_no_retenerNull = true;
		private System.DateTime _fecha_hasta_no_retener;
		private bool _fecha_hasta_no_retenerNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PROVEEDORESRow_Base"/> class.
		/// </summary>
		public PROVEEDORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PROVEEDORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.RAZON_SOCIAL != original.RAZON_SOCIAL) return true;
			if (this.NOMBRE_FANTASIA != original.NOMBRE_FANTASIA) return true;
			if (this.IsRUBRO_IDNull != original.IsRUBRO_IDNull) return true;
			if (!this.IsRUBRO_IDNull && !original.IsRUBRO_IDNull)
				if (this.RUBRO_ID != original.RUBRO_ID) return true;
			if (this.RUC != original.RUC) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.OPERA_CREDITO != original.OPERA_CREDITO) return true;
			if (this.IsCONDICION_HABITUAL_PAGO_IDNull != original.IsCONDICION_HABITUAL_PAGO_IDNull) return true;
			if (!this.IsCONDICION_HABITUAL_PAGO_IDNull && !original.IsCONDICION_HABITUAL_PAGO_IDNull)
				if (this.CONDICION_HABITUAL_PAGO_ID != original.CONDICION_HABITUAL_PAGO_ID) return true;
			if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.IsDEPARTAMENTO1_IDNull != original.IsDEPARTAMENTO1_IDNull) return true;
			if (!this.IsDEPARTAMENTO1_IDNull && !original.IsDEPARTAMENTO1_IDNull)
				if (this.DEPARTAMENTO1_ID != original.DEPARTAMENTO1_ID) return true;
			if (this.IsCIUDAD1_IDNull != original.IsCIUDAD1_IDNull) return true;
			if (!this.IsCIUDAD1_IDNull && !original.IsCIUDAD1_IDNull)
				if (this.CIUDAD1_ID != original.CIUDAD1_ID) return true;
			if (this.IsBARRIO1_IDNull != original.IsBARRIO1_IDNull) return true;
			if (!this.IsBARRIO1_IDNull && !original.IsBARRIO1_IDNull)
				if (this.BARRIO1_ID != original.BARRIO1_ID) return true;
			if (this.CALLE1 != original.CALLE1) return true;
			if (this.CODIGO_POSTAL1 != original.CODIGO_POSTAL1) return true;
			if (this.IsLATITUD1Null != original.IsLATITUD1Null) return true;
			if (!this.IsLATITUD1Null && !original.IsLATITUD1Null)
				if (this.LATITUD1 != original.LATITUD1) return true;
			if (this.IsLONGITUD1Null != original.IsLONGITUD1Null) return true;
			if (!this.IsLONGITUD1Null && !original.IsLONGITUD1Null)
				if (this.LONGITUD1 != original.LONGITUD1) return true;
			if (this.IsDEPARTAMENTO2_IDNull != original.IsDEPARTAMENTO2_IDNull) return true;
			if (!this.IsDEPARTAMENTO2_IDNull && !original.IsDEPARTAMENTO2_IDNull)
				if (this.DEPARTAMENTO2_ID != original.DEPARTAMENTO2_ID) return true;
			if (this.IsCIUDAD2_IDNull != original.IsCIUDAD2_IDNull) return true;
			if (!this.IsCIUDAD2_IDNull && !original.IsCIUDAD2_IDNull)
				if (this.CIUDAD2_ID != original.CIUDAD2_ID) return true;
			if (this.IsBARRIO2_IDNull != original.IsBARRIO2_IDNull) return true;
			if (!this.IsBARRIO2_IDNull && !original.IsBARRIO2_IDNull)
				if (this.BARRIO2_ID != original.BARRIO2_ID) return true;
			if (this.CALLE2 != original.CALLE2) return true;
			if (this.CODIGO_POSTAL2 != original.CODIGO_POSTAL2) return true;
			if (this.IsLATITUD2Null != original.IsLATITUD2Null) return true;
			if (!this.IsLATITUD2Null && !original.IsLATITUD2Null)
				if (this.LATITUD2 != original.LATITUD2) return true;
			if (this.IsLONGITUD2Null != original.IsLONGITUD2Null) return true;
			if (!this.IsLONGITUD2Null && !original.IsLONGITUD2Null)
				if (this.LONGITUD2 != original.LONGITUD2) return true;
			if (this.TELEFONO1 != original.TELEFONO1) return true;
			if (this.TELEFONO2 != original.TELEFONO2) return true;
			if (this.TELEFONO3 != original.TELEFONO3) return true;
			if (this.TELEFONO4 != original.TELEFONO4) return true;
			if (this.EMAIL1 != original.EMAIL1) return true;
			if (this.EMAIL2 != original.EMAIL2) return true;
			if (this.EMAIL3 != original.EMAIL3) return true;
			if (this.PASIBLE_RETENCION != original.PASIBLE_RETENCION) return true;
			if (this.BANDERA_RETENCION != original.BANDERA_RETENCION) return true;
			if (this.IsFECHA_FUNDACIONNull != original.IsFECHA_FUNDACIONNull) return true;
			if (!this.IsFECHA_FUNDACIONNull && !original.IsFECHA_FUNDACIONNull)
				if (this.FECHA_FUNDACION != original.FECHA_FUNDACION) return true;
			if (this.CONTACTO_PERSONA != original.CONTACTO_PERSONA) return true;
			if (this.CONTACTO_TELEFONO != original.CONTACTO_TELEFONO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.INGRESO_APROBADO != original.INGRESO_APROBADO) return true;
			if (this.IsUSUARIO_APROBACION_IDNull != original.IsUSUARIO_APROBACION_IDNull) return true;
			if (!this.IsUSUARIO_APROBACION_IDNull && !original.IsUSUARIO_APROBACION_IDNull)
				if (this.USUARIO_APROBACION_ID != original.USUARIO_APROBACION_ID) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.SOLICITA_REFERENCIA != original.SOLICITA_REFERENCIA) return true;
			if (this.ES_NACIONAL != original.ES_NACIONAL) return true;
			if (this.FC_OBSERVACION_DETALLE != original.FC_OBSERVACION_DETALLE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.CONTACTO_EMAIL != original.CONTACTO_EMAIL) return true;
			if (this.ES_CONTRIBUYENTE != original.ES_CONTRIBUYENTE) return true;
			if (this.IsFECHA_DESDE_NO_RETENERNull != original.IsFECHA_DESDE_NO_RETENERNull) return true;
			if (!this.IsFECHA_DESDE_NO_RETENERNull && !original.IsFECHA_DESDE_NO_RETENERNull)
				if (this.FECHA_DESDE_NO_RETENER != original.FECHA_DESDE_NO_RETENER) return true;
			if (this.IsFECHA_HASTA_NO_RETENERNull != original.IsFECHA_HASTA_NO_RETENERNull) return true;
			if (!this.IsFECHA_HASTA_NO_RETENERNull && !original.IsFECHA_HASTA_NO_RETENERNull)
				if (this.FECHA_HASTA_NO_RETENER != original.FECHA_HASTA_NO_RETENER) return true;
			
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
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_SOCIAL</c> column value.
		/// </summary>
		/// <value>The <c>RAZON_SOCIAL</c> column value.</value>
		public string RAZON_SOCIAL
		{
			get { return _razon_social; }
			set { _razon_social = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_FANTASIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_FANTASIA</c> column value.</value>
		public string NOMBRE_FANTASIA
		{
			get { return _nombre_fantasia; }
			set { _nombre_fantasia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUBRO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUBRO_ID</c> column value.</value>
		public decimal RUBRO_ID
		{
			get
			{
				if(IsRUBRO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rubro_id;
			}
			set
			{
				_rubro_idNull = false;
				_rubro_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RUBRO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRUBRO_IDNull
		{
			get { return _rubro_idNull; }
			set { _rubro_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUC</c> column value.
		/// </summary>
		/// <value>The <c>RUC</c> column value.</value>
		public string RUC
		{
			get { return _ruc; }
			set { _ruc = value; }
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
		/// Gets or sets the <c>OPERA_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERA_CREDITO</c> column value.</value>
		public string OPERA_CREDITO
		{
			get { return _opera_credito; }
			set { _opera_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_HABITUAL_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</value>
		public decimal CONDICION_HABITUAL_PAGO_ID
		{
			get
			{
				if(IsCONDICION_HABITUAL_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _condicion_habitual_pago_id;
			}
			set
			{
				_condicion_habitual_pago_idNull = false;
				_condicion_habitual_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONDICION_HABITUAL_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONDICION_HABITUAL_PAGO_IDNull
		{
			get { return _condicion_habitual_pago_idNull; }
			set { _condicion_habitual_pago_idNull = value; }
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
		/// Gets or sets the <c>DEPARTAMENTO1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO1_ID</c> column value.</value>
		public decimal DEPARTAMENTO1_ID
		{
			get
			{
				if(IsDEPARTAMENTO1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento1_id;
			}
			set
			{
				_departamento1_idNull = false;
				_departamento1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO1_IDNull
		{
			get { return _departamento1_idNull; }
			set { _departamento1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD1_ID</c> column value.</value>
		public decimal CIUDAD1_ID
		{
			get
			{
				if(IsCIUDAD1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad1_id;
			}
			set
			{
				_ciudad1_idNull = false;
				_ciudad1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD1_IDNull
		{
			get { return _ciudad1_idNull; }
			set { _ciudad1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO1_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO1_ID</c> column value.</value>
		public decimal BARRIO1_ID
		{
			get
			{
				if(IsBARRIO1_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio1_id;
			}
			set
			{
				_barrio1_idNull = false;
				_barrio1_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO1_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO1_IDNull
		{
			get { return _barrio1_idNull; }
			set { _barrio1_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE1</c> column value.</value>
		public string CALLE1
		{
			get { return _calle1; }
			set { _calle1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_POSTAL1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_POSTAL1</c> column value.</value>
		public string CODIGO_POSTAL1
		{
			get { return _codigo_postal1; }
			set { _codigo_postal1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD1</c> column value.</value>
		public decimal LATITUD1
		{
			get
			{
				if(IsLATITUD1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud1;
			}
			set
			{
				_latitud1Null = false;
				_latitud1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUD1Null
		{
			get { return _latitud1Null; }
			set { _latitud1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD1</c> column value.</value>
		public decimal LONGITUD1
		{
			get
			{
				if(IsLONGITUD1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud1;
			}
			set
			{
				_longitud1Null = false;
				_longitud1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD1Null
		{
			get { return _longitud1Null; }
			set { _longitud1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO2_ID</c> column value.</value>
		public decimal DEPARTAMENTO2_ID
		{
			get
			{
				if(IsDEPARTAMENTO2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento2_id;
			}
			set
			{
				_departamento2_idNull = false;
				_departamento2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO2_IDNull
		{
			get { return _departamento2_idNull; }
			set { _departamento2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD2_ID</c> column value.</value>
		public decimal CIUDAD2_ID
		{
			get
			{
				if(IsCIUDAD2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad2_id;
			}
			set
			{
				_ciudad2_idNull = false;
				_ciudad2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD2_IDNull
		{
			get { return _ciudad2_idNull; }
			set { _ciudad2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO2_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO2_ID</c> column value.</value>
		public decimal BARRIO2_ID
		{
			get
			{
				if(IsBARRIO2_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio2_id;
			}
			set
			{
				_barrio2_idNull = false;
				_barrio2_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO2_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO2_IDNull
		{
			get { return _barrio2_idNull; }
			set { _barrio2_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE2</c> column value.</value>
		public string CALLE2
		{
			get { return _calle2; }
			set { _calle2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_POSTAL2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_POSTAL2</c> column value.</value>
		public string CODIGO_POSTAL2
		{
			get { return _codigo_postal2; }
			set { _codigo_postal2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD2</c> column value.</value>
		public decimal LATITUD2
		{
			get
			{
				if(IsLATITUD2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud2;
			}
			set
			{
				_latitud2Null = false;
				_latitud2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUD2Null
		{
			get { return _latitud2Null; }
			set { _latitud2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD2</c> column value.</value>
		public decimal LONGITUD2
		{
			get
			{
				if(IsLONGITUD2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud2;
			}
			set
			{
				_longitud2Null = false;
				_longitud2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD2Null
		{
			get { return _longitud2Null; }
			set { _longitud2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO1</c> column value.</value>
		public string TELEFONO1
		{
			get { return _telefono1; }
			set { _telefono1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO2</c> column value.</value>
		public string TELEFONO2
		{
			get { return _telefono2; }
			set { _telefono2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO3</c> column value.</value>
		public string TELEFONO3
		{
			get { return _telefono3; }
			set { _telefono3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO4</c> column value.</value>
		public string TELEFONO4
		{
			get { return _telefono4; }
			set { _telefono4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL1</c> column value.</value>
		public string EMAIL1
		{
			get { return _email1; }
			set { _email1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL2</c> column value.</value>
		public string EMAIL2
		{
			get { return _email2; }
			set { _email2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL3</c> column value.</value>
		public string EMAIL3
		{
			get { return _email3; }
			set { _email3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASIBLE_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>PASIBLE_RETENCION</c> column value.</value>
		public string PASIBLE_RETENCION
		{
			get { return _pasible_retencion; }
			set { _pasible_retencion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BANDERA_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>BANDERA_RETENCION</c> column value.</value>
		public string BANDERA_RETENCION
		{
			get { return _bandera_retencion; }
			set { _bandera_retencion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FUNDACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FUNDACION</c> column value.</value>
		public System.DateTime FECHA_FUNDACION
		{
			get
			{
				if(IsFECHA_FUNDACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fundacion;
			}
			set
			{
				_fecha_fundacionNull = false;
				_fecha_fundacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FUNDACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FUNDACIONNull
		{
			get { return _fecha_fundacionNull; }
			set { _fecha_fundacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTACTO_PERSONA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTACTO_PERSONA</c> column value.</value>
		public string CONTACTO_PERSONA
		{
			get { return _contacto_persona; }
			set { _contacto_persona = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTACTO_TELEFONO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTACTO_TELEFONO</c> column value.</value>
		public string CONTACTO_TELEFONO
		{
			get { return _contacto_telefono; }
			set { _contacto_telefono = value; }
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
		/// Gets or sets the <c>INGRESO_APROBADO</c> column value.
		/// </summary>
		/// <value>The <c>INGRESO_APROBADO</c> column value.</value>
		public string INGRESO_APROBADO
		{
			get { return _ingreso_aprobado; }
			set { _ingreso_aprobado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_APROBACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_APROBACION_ID</c> column value.</value>
		public decimal USUARIO_APROBACION_ID
		{
			get
			{
				if(IsUSUARIO_APROBACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_aprobacion_id;
			}
			set
			{
				_usuario_aprobacion_idNull = false;
				_usuario_aprobacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_APROBACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_APROBACION_IDNull
		{
			get { return _usuario_aprobacion_idNull; }
			set { _usuario_aprobacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_APROBACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_APROBACION</c> column value.</value>
		public System.DateTime FECHA_APROBACION
		{
			get
			{
				if(IsFECHA_APROBACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_aprobacion;
			}
			set
			{
				_fecha_aprobacionNull = false;
				_fecha_aprobacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_APROBACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_APROBACIONNull
		{
			get { return _fecha_aprobacionNull; }
			set { _fecha_aprobacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SOLICITA_REFERENCIA</c> column value.
		/// </summary>
		/// <value>The <c>SOLICITA_REFERENCIA</c> column value.</value>
		public string SOLICITA_REFERENCIA
		{
			get { return _solicita_referencia; }
			set { _solicita_referencia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_NACIONAL</c> column value.
		/// </summary>
		/// <value>The <c>ES_NACIONAL</c> column value.</value>
		public string ES_NACIONAL
		{
			get { return _es_nacional; }
			set { _es_nacional = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_OBSERVACION_DETALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_OBSERVACION_DETALLE</c> column value.</value>
		public string FC_OBSERVACION_DETALLE
		{
			get { return _fc_observacion_detalle; }
			set { _fc_observacion_detalle = value; }
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
		/// Gets or sets the <c>CONTACTO_EMAIL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTACTO_EMAIL</c> column value.</value>
		public string CONTACTO_EMAIL
		{
			get { return _contacto_email; }
			set { _contacto_email = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CONTRIBUYENTE</c> column value.
		/// </summary>
		/// <value>The <c>ES_CONTRIBUYENTE</c> column value.</value>
		public string ES_CONTRIBUYENTE
		{
			get { return _es_contribuyente; }
			set { _es_contribuyente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_DESDE_NO_RETENER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_DESDE_NO_RETENER</c> column value.</value>
		public System.DateTime FECHA_DESDE_NO_RETENER
		{
			get
			{
				if(IsFECHA_DESDE_NO_RETENERNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_desde_no_retener;
			}
			set
			{
				_fecha_desde_no_retenerNull = false;
				_fecha_desde_no_retener = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_DESDE_NO_RETENER"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_DESDE_NO_RETENERNull
		{
			get { return _fecha_desde_no_retenerNull; }
			set { _fecha_desde_no_retenerNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_HASTA_NO_RETENER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_HASTA_NO_RETENER</c> column value.</value>
		public System.DateTime FECHA_HASTA_NO_RETENER
		{
			get
			{
				if(IsFECHA_HASTA_NO_RETENERNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_hasta_no_retener;
			}
			set
			{
				_fecha_hasta_no_retenerNull = false;
				_fecha_hasta_no_retener = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_HASTA_NO_RETENER"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_HASTA_NO_RETENERNull
		{
			get { return _fecha_hasta_no_retenerNull; }
			set { _fecha_hasta_no_retenerNull = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@RAZON_SOCIAL=");
			dynStr.Append(RAZON_SOCIAL);
			dynStr.Append("@CBA@NOMBRE_FANTASIA=");
			dynStr.Append(NOMBRE_FANTASIA);
			dynStr.Append("@CBA@RUBRO_ID=");
			dynStr.Append(IsRUBRO_IDNull ? (object)"<NULL>" : RUBRO_ID);
			dynStr.Append("@CBA@RUC=");
			dynStr.Append(RUC);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@OPERA_CREDITO=");
			dynStr.Append(OPERA_CREDITO);
			dynStr.Append("@CBA@CONDICION_HABITUAL_PAGO_ID=");
			dynStr.Append(IsCONDICION_HABITUAL_PAGO_IDNull ? (object)"<NULL>" : CONDICION_HABITUAL_PAGO_ID);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(PAIS_ID);
			dynStr.Append("@CBA@DEPARTAMENTO1_ID=");
			dynStr.Append(IsDEPARTAMENTO1_IDNull ? (object)"<NULL>" : DEPARTAMENTO1_ID);
			dynStr.Append("@CBA@CIUDAD1_ID=");
			dynStr.Append(IsCIUDAD1_IDNull ? (object)"<NULL>" : CIUDAD1_ID);
			dynStr.Append("@CBA@BARRIO1_ID=");
			dynStr.Append(IsBARRIO1_IDNull ? (object)"<NULL>" : BARRIO1_ID);
			dynStr.Append("@CBA@CALLE1=");
			dynStr.Append(CALLE1);
			dynStr.Append("@CBA@CODIGO_POSTAL1=");
			dynStr.Append(CODIGO_POSTAL1);
			dynStr.Append("@CBA@LATITUD1=");
			dynStr.Append(IsLATITUD1Null ? (object)"<NULL>" : LATITUD1);
			dynStr.Append("@CBA@LONGITUD1=");
			dynStr.Append(IsLONGITUD1Null ? (object)"<NULL>" : LONGITUD1);
			dynStr.Append("@CBA@DEPARTAMENTO2_ID=");
			dynStr.Append(IsDEPARTAMENTO2_IDNull ? (object)"<NULL>" : DEPARTAMENTO2_ID);
			dynStr.Append("@CBA@CIUDAD2_ID=");
			dynStr.Append(IsCIUDAD2_IDNull ? (object)"<NULL>" : CIUDAD2_ID);
			dynStr.Append("@CBA@BARRIO2_ID=");
			dynStr.Append(IsBARRIO2_IDNull ? (object)"<NULL>" : BARRIO2_ID);
			dynStr.Append("@CBA@CALLE2=");
			dynStr.Append(CALLE2);
			dynStr.Append("@CBA@CODIGO_POSTAL2=");
			dynStr.Append(CODIGO_POSTAL2);
			dynStr.Append("@CBA@LATITUD2=");
			dynStr.Append(IsLATITUD2Null ? (object)"<NULL>" : LATITUD2);
			dynStr.Append("@CBA@LONGITUD2=");
			dynStr.Append(IsLONGITUD2Null ? (object)"<NULL>" : LONGITUD2);
			dynStr.Append("@CBA@TELEFONO1=");
			dynStr.Append(TELEFONO1);
			dynStr.Append("@CBA@TELEFONO2=");
			dynStr.Append(TELEFONO2);
			dynStr.Append("@CBA@TELEFONO3=");
			dynStr.Append(TELEFONO3);
			dynStr.Append("@CBA@TELEFONO4=");
			dynStr.Append(TELEFONO4);
			dynStr.Append("@CBA@EMAIL1=");
			dynStr.Append(EMAIL1);
			dynStr.Append("@CBA@EMAIL2=");
			dynStr.Append(EMAIL2);
			dynStr.Append("@CBA@EMAIL3=");
			dynStr.Append(EMAIL3);
			dynStr.Append("@CBA@PASIBLE_RETENCION=");
			dynStr.Append(PASIBLE_RETENCION);
			dynStr.Append("@CBA@BANDERA_RETENCION=");
			dynStr.Append(BANDERA_RETENCION);
			dynStr.Append("@CBA@FECHA_FUNDACION=");
			dynStr.Append(IsFECHA_FUNDACIONNull ? (object)"<NULL>" : FECHA_FUNDACION);
			dynStr.Append("@CBA@CONTACTO_PERSONA=");
			dynStr.Append(CONTACTO_PERSONA);
			dynStr.Append("@CBA@CONTACTO_TELEFONO=");
			dynStr.Append(CONTACTO_TELEFONO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@INGRESO_APROBADO=");
			dynStr.Append(INGRESO_APROBADO);
			dynStr.Append("@CBA@USUARIO_APROBACION_ID=");
			dynStr.Append(IsUSUARIO_APROBACION_IDNull ? (object)"<NULL>" : USUARIO_APROBACION_ID);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@SOLICITA_REFERENCIA=");
			dynStr.Append(SOLICITA_REFERENCIA);
			dynStr.Append("@CBA@ES_NACIONAL=");
			dynStr.Append(ES_NACIONAL);
			dynStr.Append("@CBA@FC_OBSERVACION_DETALLE=");
			dynStr.Append(FC_OBSERVACION_DETALLE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@CONTACTO_EMAIL=");
			dynStr.Append(CONTACTO_EMAIL);
			dynStr.Append("@CBA@ES_CONTRIBUYENTE=");
			dynStr.Append(ES_CONTRIBUYENTE);
			dynStr.Append("@CBA@FECHA_DESDE_NO_RETENER=");
			dynStr.Append(IsFECHA_DESDE_NO_RETENERNull ? (object)"<NULL>" : FECHA_DESDE_NO_RETENER);
			dynStr.Append("@CBA@FECHA_HASTA_NO_RETENER=");
			dynStr.Append(IsFECHA_HASTA_NO_RETENERNull ? (object)"<NULL>" : FECHA_HASTA_NO_RETENER);
			return dynStr.ToString();
		}
	} // End of PROVEEDORESRow_Base class
} // End of namespace
