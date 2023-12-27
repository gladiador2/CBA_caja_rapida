// <fileinfo name="FUNCIONARIOSRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOSRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOSRow_Base
	{
		private decimal _id;
		private string _codigo;
		private decimal _entidad_id;
		private string _tratamiento_id;
		private string _nombre;
		private string _apellido;
		private string _apodo;
		private string _genero;
		private string _ruc;
		private System.DateTime _nacimiento;
		private bool _nacimientoNull = true;
		private string _tipo_documento_identidad_id;
		private string _numero_documento;
		private decimal _pais_nacionalidad_id;
		private bool _pais_nacionalidad_idNull = true;
		private decimal _pais_residencia_id;
		private bool _pais_residencia_idNull = true;
		private string _profesion_id;
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
		private string _es_vendedor;
		private string _es_cobrador;
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
		private System.DateTime _fecha_contratacion;
		private bool _fecha_contratacionNull = true;
		private System.DateTime _fecha_salida;
		private bool _fecha_salidaNull = true;
		private string _motivo_salida;
		private string _estado_civil_id;
		private decimal _estado_documentacion_id;
		private bool _estado_documentacion_idNull = true;
		private string _nombre_familiar_contacto;
		private string _relacion_familiar_contacto;
		private string _telefono_familiar_contacto;
		private decimal _departamento_familiar_cont_id;
		private bool _departamento_familiar_cont_idNull = true;
		private decimal _ciudad_familiar_contacto_id;
		private bool _ciudad_familiar_contacto_idNull = true;
		private decimal _barrio_familiar_contacto_id;
		private bool _barrio_familiar_contacto_idNull = true;
		private string _calle_familiar_contacto;
		private string _cod_post_familiar_contacto;
		private decimal _latitud_familiar_contacto;
		private bool _latitud_familiar_contactoNull = true;
		private decimal _longitud_familiar_contacto;
		private bool _longitud_familiar_contactoNull = true;
		private string _estado;
		private string _ingreso_aprobado;
		private decimal _usuario_aprobacion_id;
		private bool _usuario_aprobacion_idNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private decimal _persona_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private System.DateTime _ingreso_seguro;
		private bool _ingreso_seguroNull = true;
		private decimal _salario_tipo;
		private bool _salario_tipoNull = true;
		private string _cobra_salario_minimo;
		private decimal _salario;
		private bool _salarioNull = true;
		private decimal _salario_complementario;
		private bool _salario_complementarioNull = true;
		private decimal _salario_extra;
		private bool _salario_extraNull = true;
		private string _cobra_anticipo;
		private decimal _monto_anticipo;
		private bool _monto_anticipoNull = true;
		private string _cobra_bonificacion;
		private decimal _monto_bonificacion;
		private bool _monto_bonificacionNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _ctacte;
		private string _grupo_sanguineo;
		private string _es_promotor;
		private decimal _marcaciones_id;
		private bool _marcaciones_idNull = true;
		private string _es_chofer;
		private string _depositero;
		private string _es_cobrador_externo;
		private string _codigo_talonario;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private string _descuentos_basico;
		private string _descuentos_complementario;
		private string _descuentos_extra;
		private decimal _canal_venta_id;
		private bool _canal_venta_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOSRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.TRATAMIENTO_ID != original.TRATAMIENTO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.APELLIDO != original.APELLIDO) return true;
			if (this.APODO != original.APODO) return true;
			if (this.GENERO != original.GENERO) return true;
			if (this.RUC != original.RUC) return true;
			if (this.IsNACIMIENTONull != original.IsNACIMIENTONull) return true;
			if (!this.IsNACIMIENTONull && !original.IsNACIMIENTONull)
				if (this.NACIMIENTO != original.NACIMIENTO) return true;
			if (this.TIPO_DOCUMENTO_IDENTIDAD_ID != original.TIPO_DOCUMENTO_IDENTIDAD_ID) return true;
			if (this.NUMERO_DOCUMENTO != original.NUMERO_DOCUMENTO) return true;
			if (this.IsPAIS_NACIONALIDAD_IDNull != original.IsPAIS_NACIONALIDAD_IDNull) return true;
			if (!this.IsPAIS_NACIONALIDAD_IDNull && !original.IsPAIS_NACIONALIDAD_IDNull)
				if (this.PAIS_NACIONALIDAD_ID != original.PAIS_NACIONALIDAD_ID) return true;
			if (this.IsPAIS_RESIDENCIA_IDNull != original.IsPAIS_RESIDENCIA_IDNull) return true;
			if (!this.IsPAIS_RESIDENCIA_IDNull && !original.IsPAIS_RESIDENCIA_IDNull)
				if (this.PAIS_RESIDENCIA_ID != original.PAIS_RESIDENCIA_ID) return true;
			if (this.PROFESION_ID != original.PROFESION_ID) return true;
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
			if (this.ES_VENDEDOR != original.ES_VENDEDOR) return true;
			if (this.ES_COBRADOR != original.ES_COBRADOR) return true;
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
			if (this.IsFECHA_CONTRATACIONNull != original.IsFECHA_CONTRATACIONNull) return true;
			if (!this.IsFECHA_CONTRATACIONNull && !original.IsFECHA_CONTRATACIONNull)
				if (this.FECHA_CONTRATACION != original.FECHA_CONTRATACION) return true;
			if (this.IsFECHA_SALIDANull != original.IsFECHA_SALIDANull) return true;
			if (!this.IsFECHA_SALIDANull && !original.IsFECHA_SALIDANull)
				if (this.FECHA_SALIDA != original.FECHA_SALIDA) return true;
			if (this.MOTIVO_SALIDA != original.MOTIVO_SALIDA) return true;
			if (this.ESTADO_CIVIL_ID != original.ESTADO_CIVIL_ID) return true;
			if (this.IsESTADO_DOCUMENTACION_IDNull != original.IsESTADO_DOCUMENTACION_IDNull) return true;
			if (!this.IsESTADO_DOCUMENTACION_IDNull && !original.IsESTADO_DOCUMENTACION_IDNull)
				if (this.ESTADO_DOCUMENTACION_ID != original.ESTADO_DOCUMENTACION_ID) return true;
			if (this.NOMBRE_FAMILIAR_CONTACTO != original.NOMBRE_FAMILIAR_CONTACTO) return true;
			if (this.RELACION_FAMILIAR_CONTACTO != original.RELACION_FAMILIAR_CONTACTO) return true;
			if (this.TELEFONO_FAMILIAR_CONTACTO != original.TELEFONO_FAMILIAR_CONTACTO) return true;
			if (this.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull != original.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull) return true;
			if (!this.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull && !original.IsDEPARTAMENTO_FAMILIAR_CONT_IDNull)
				if (this.DEPARTAMENTO_FAMILIAR_CONT_ID != original.DEPARTAMENTO_FAMILIAR_CONT_ID) return true;
			if (this.IsCIUDAD_FAMILIAR_CONTACTO_IDNull != original.IsCIUDAD_FAMILIAR_CONTACTO_IDNull) return true;
			if (!this.IsCIUDAD_FAMILIAR_CONTACTO_IDNull && !original.IsCIUDAD_FAMILIAR_CONTACTO_IDNull)
				if (this.CIUDAD_FAMILIAR_CONTACTO_ID != original.CIUDAD_FAMILIAR_CONTACTO_ID) return true;
			if (this.IsBARRIO_FAMILIAR_CONTACTO_IDNull != original.IsBARRIO_FAMILIAR_CONTACTO_IDNull) return true;
			if (!this.IsBARRIO_FAMILIAR_CONTACTO_IDNull && !original.IsBARRIO_FAMILIAR_CONTACTO_IDNull)
				if (this.BARRIO_FAMILIAR_CONTACTO_ID != original.BARRIO_FAMILIAR_CONTACTO_ID) return true;
			if (this.CALLE_FAMILIAR_CONTACTO != original.CALLE_FAMILIAR_CONTACTO) return true;
			if (this.COD_POST_FAMILIAR_CONTACTO != original.COD_POST_FAMILIAR_CONTACTO) return true;
			if (this.IsLATITUD_FAMILIAR_CONTACTONull != original.IsLATITUD_FAMILIAR_CONTACTONull) return true;
			if (!this.IsLATITUD_FAMILIAR_CONTACTONull && !original.IsLATITUD_FAMILIAR_CONTACTONull)
				if (this.LATITUD_FAMILIAR_CONTACTO != original.LATITUD_FAMILIAR_CONTACTO) return true;
			if (this.IsLONGITUD_FAMILIAR_CONTACTONull != original.IsLONGITUD_FAMILIAR_CONTACTONull) return true;
			if (!this.IsLONGITUD_FAMILIAR_CONTACTONull && !original.IsLONGITUD_FAMILIAR_CONTACTONull)
				if (this.LONGITUD_FAMILIAR_CONTACTO != original.LONGITUD_FAMILIAR_CONTACTO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.INGRESO_APROBADO != original.INGRESO_APROBADO) return true;
			if (this.IsUSUARIO_APROBACION_IDNull != original.IsUSUARIO_APROBACION_IDNull) return true;
			if (!this.IsUSUARIO_APROBACION_IDNull && !original.IsUSUARIO_APROBACION_IDNull)
				if (this.USUARIO_APROBACION_ID != original.USUARIO_APROBACION_ID) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsINGRESO_SEGURONull != original.IsINGRESO_SEGURONull) return true;
			if (!this.IsINGRESO_SEGURONull && !original.IsINGRESO_SEGURONull)
				if (this.INGRESO_SEGURO != original.INGRESO_SEGURO) return true;
			if (this.IsSALARIO_TIPONull != original.IsSALARIO_TIPONull) return true;
			if (!this.IsSALARIO_TIPONull && !original.IsSALARIO_TIPONull)
				if (this.SALARIO_TIPO != original.SALARIO_TIPO) return true;
			if (this.COBRA_SALARIO_MINIMO != original.COBRA_SALARIO_MINIMO) return true;
			if (this.IsSALARIONull != original.IsSALARIONull) return true;
			if (!this.IsSALARIONull && !original.IsSALARIONull)
				if (this.SALARIO != original.SALARIO) return true;
			if (this.IsSALARIO_COMPLEMENTARIONull != original.IsSALARIO_COMPLEMENTARIONull) return true;
			if (!this.IsSALARIO_COMPLEMENTARIONull && !original.IsSALARIO_COMPLEMENTARIONull)
				if (this.SALARIO_COMPLEMENTARIO != original.SALARIO_COMPLEMENTARIO) return true;
			if (this.IsSALARIO_EXTRANull != original.IsSALARIO_EXTRANull) return true;
			if (!this.IsSALARIO_EXTRANull && !original.IsSALARIO_EXTRANull)
				if (this.SALARIO_EXTRA != original.SALARIO_EXTRA) return true;
			if (this.COBRA_ANTICIPO != original.COBRA_ANTICIPO) return true;
			if (this.IsMONTO_ANTICIPONull != original.IsMONTO_ANTICIPONull) return true;
			if (!this.IsMONTO_ANTICIPONull && !original.IsMONTO_ANTICIPONull)
				if (this.MONTO_ANTICIPO != original.MONTO_ANTICIPO) return true;
			if (this.COBRA_BONIFICACION != original.COBRA_BONIFICACION) return true;
			if (this.IsMONTO_BONIFICACIONNull != original.IsMONTO_BONIFICACIONNull) return true;
			if (!this.IsMONTO_BONIFICACIONNull && !original.IsMONTO_BONIFICACIONNull)
				if (this.MONTO_BONIFICACION != original.MONTO_BONIFICACION) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.CTACTE != original.CTACTE) return true;
			if (this.GRUPO_SANGUINEO != original.GRUPO_SANGUINEO) return true;
			if (this.ES_PROMOTOR != original.ES_PROMOTOR) return true;
			if (this.IsMARCACIONES_IDNull != original.IsMARCACIONES_IDNull) return true;
			if (!this.IsMARCACIONES_IDNull && !original.IsMARCACIONES_IDNull)
				if (this.MARCACIONES_ID != original.MARCACIONES_ID) return true;
			if (this.ES_CHOFER != original.ES_CHOFER) return true;
			if (this.DEPOSITERO != original.DEPOSITERO) return true;
			if (this.ES_COBRADOR_EXTERNO != original.ES_COBRADOR_EXTERNO) return true;
			if (this.CODIGO_TALONARIO != original.CODIGO_TALONARIO) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.DESCUENTOS_BASICO != original.DESCUENTOS_BASICO) return true;
			if (this.DESCUENTOS_COMPLEMENTARIO != original.DESCUENTOS_COMPLEMENTARIO) return true;
			if (this.DESCUENTOS_EXTRA != original.DESCUENTOS_EXTRA) return true;
			if (this.IsCANAL_VENTA_IDNull != original.IsCANAL_VENTA_IDNull) return true;
			if (!this.IsCANAL_VENTA_IDNull && !original.IsCANAL_VENTA_IDNull)
				if (this.CANAL_VENTA_ID != original.CANAL_VENTA_ID) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRATAMIENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRATAMIENTO_ID</c> column value.</value>
		public string TRATAMIENTO_ID
		{
			get { return _tratamiento_id; }
			set { _tratamiento_id = value; }
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
		/// Gets or sets the <c>APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APELLIDO</c> column value.</value>
		public string APELLIDO
		{
			get { return _apellido; }
			set { _apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APODO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APODO</c> column value.</value>
		public string APODO
		{
			get { return _apodo; }
			set { _apodo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GENERO</c> column value.</value>
		public string GENERO
		{
			get { return _genero; }
			set { _genero = value; }
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
		/// Gets or sets the <c>NACIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NACIMIENTO</c> column value.</value>
		public System.DateTime NACIMIENTO
		{
			get
			{
				if(IsNACIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nacimiento;
			}
			set
			{
				_nacimientoNull = false;
				_nacimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NACIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNACIMIENTONull
		{
			get { return _nacimientoNull; }
			set { _nacimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</value>
		public string TIPO_DOCUMENTO_IDENTIDAD_ID
		{
			get { return _tipo_documento_identidad_id; }
			set { _tipo_documento_identidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_DOCUMENTO</c> column value.</value>
		public string NUMERO_DOCUMENTO
		{
			get { return _numero_documento; }
			set { _numero_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_NACIONALIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAIS_NACIONALIDAD_ID</c> column value.</value>
		public decimal PAIS_NACIONALIDAD_ID
		{
			get
			{
				if(IsPAIS_NACIONALIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pais_nacionalidad_id;
			}
			set
			{
				_pais_nacionalidad_idNull = false;
				_pais_nacionalidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAIS_NACIONALIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAIS_NACIONALIDAD_IDNull
		{
			get { return _pais_nacionalidad_idNull; }
			set { _pais_nacionalidad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_RESIDENCIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAIS_RESIDENCIA_ID</c> column value.</value>
		public decimal PAIS_RESIDENCIA_ID
		{
			get
			{
				if(IsPAIS_RESIDENCIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pais_residencia_id;
			}
			set
			{
				_pais_residencia_idNull = false;
				_pais_residencia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAIS_RESIDENCIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAIS_RESIDENCIA_IDNull
		{
			get { return _pais_residencia_idNull; }
			set { _pais_residencia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROFESION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROFESION_ID</c> column value.</value>
		public string PROFESION_ID
		{
			get { return _profesion_id; }
			set { _profesion_id = value; }
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
		/// Gets or sets the <c>ES_VENDEDOR</c> column value.
		/// </summary>
		/// <value>The <c>ES_VENDEDOR</c> column value.</value>
		public string ES_VENDEDOR
		{
			get { return _es_vendedor; }
			set { _es_vendedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COBRADOR</c> column value.
		/// </summary>
		/// <value>The <c>ES_COBRADOR</c> column value.</value>
		public string ES_COBRADOR
		{
			get { return _es_cobrador; }
			set { _es_cobrador = value; }
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
		/// Gets or sets the <c>FECHA_CONTRATACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CONTRATACION</c> column value.</value>
		public System.DateTime FECHA_CONTRATACION
		{
			get
			{
				if(IsFECHA_CONTRATACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_contratacion;
			}
			set
			{
				_fecha_contratacionNull = false;
				_fecha_contratacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CONTRATACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CONTRATACIONNull
		{
			get { return _fecha_contratacionNull; }
			set { _fecha_contratacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA</c> column value.</value>
		public System.DateTime FECHA_SALIDA
		{
			get
			{
				if(IsFECHA_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida;
			}
			set
			{
				_fecha_salidaNull = false;
				_fecha_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDANull
		{
			get { return _fecha_salidaNull; }
			set { _fecha_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_SALIDA</c> column value.</value>
		public string MOTIVO_SALIDA
		{
			get { return _motivo_salida; }
			set { _motivo_salida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_CIVIL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_CIVIL_ID</c> column value.</value>
		public string ESTADO_CIVIL_ID
		{
			get { return _estado_civil_id; }
			set { _estado_civil_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DOCUMENTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_DOCUMENTACION_ID</c> column value.</value>
		public decimal ESTADO_DOCUMENTACION_ID
		{
			get
			{
				if(IsESTADO_DOCUMENTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estado_documentacion_id;
			}
			set
			{
				_estado_documentacion_idNull = false;
				_estado_documentacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTADO_DOCUMENTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTADO_DOCUMENTACION_IDNull
		{
			get { return _estado_documentacion_idNull; }
			set { _estado_documentacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_FAMILIAR_CONTACTO</c> column value.</value>
		public string NOMBRE_FAMILIAR_CONTACTO
		{
			get { return _nombre_familiar_contacto; }
			set { _nombre_familiar_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RELACION_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RELACION_FAMILIAR_CONTACTO</c> column value.</value>
		public string RELACION_FAMILIAR_CONTACTO
		{
			get { return _relacion_familiar_contacto; }
			set { _relacion_familiar_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO_FAMILIAR_CONTACTO</c> column value.</value>
		public string TELEFONO_FAMILIAR_CONTACTO
		{
			get { return _telefono_familiar_contacto; }
			set { _telefono_familiar_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_FAMILIAR_CONT_ID</c> column value.</value>
		public decimal DEPARTAMENTO_FAMILIAR_CONT_ID
		{
			get
			{
				if(IsDEPARTAMENTO_FAMILIAR_CONT_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_familiar_cont_id;
			}
			set
			{
				_departamento_familiar_cont_idNull = false;
				_departamento_familiar_cont_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_FAMILIAR_CONT_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_FAMILIAR_CONT_IDNull
		{
			get { return _departamento_familiar_cont_idNull; }
			set { _departamento_familiar_cont_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_FAMILIAR_CONTACTO_ID</c> column value.</value>
		public decimal CIUDAD_FAMILIAR_CONTACTO_ID
		{
			get
			{
				if(IsCIUDAD_FAMILIAR_CONTACTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_familiar_contacto_id;
			}
			set
			{
				_ciudad_familiar_contacto_idNull = false;
				_ciudad_familiar_contacto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_FAMILIAR_CONTACTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_FAMILIAR_CONTACTO_IDNull
		{
			get { return _ciudad_familiar_contacto_idNull; }
			set { _ciudad_familiar_contacto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_FAMILIAR_CONTACTO_ID</c> column value.</value>
		public decimal BARRIO_FAMILIAR_CONTACTO_ID
		{
			get
			{
				if(IsBARRIO_FAMILIAR_CONTACTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio_familiar_contacto_id;
			}
			set
			{
				_barrio_familiar_contacto_idNull = false;
				_barrio_familiar_contacto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO_FAMILIAR_CONTACTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO_FAMILIAR_CONTACTO_IDNull
		{
			get { return _barrio_familiar_contacto_idNull; }
			set { _barrio_familiar_contacto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE_FAMILIAR_CONTACTO</c> column value.</value>
		public string CALLE_FAMILIAR_CONTACTO
		{
			get { return _calle_familiar_contacto; }
			set { _calle_familiar_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COD_POST_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COD_POST_FAMILIAR_CONTACTO</c> column value.</value>
		public string COD_POST_FAMILIAR_CONTACTO
		{
			get { return _cod_post_familiar_contacto; }
			set { _cod_post_familiar_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD_FAMILIAR_CONTACTO</c> column value.</value>
		public decimal LATITUD_FAMILIAR_CONTACTO
		{
			get
			{
				if(IsLATITUD_FAMILIAR_CONTACTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud_familiar_contacto;
			}
			set
			{
				_latitud_familiar_contactoNull = false;
				_latitud_familiar_contacto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD_FAMILIAR_CONTACTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUD_FAMILIAR_CONTACTONull
		{
			get { return _latitud_familiar_contactoNull; }
			set { _latitud_familiar_contactoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD_FAMILIAR_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD_FAMILIAR_CONTACTO</c> column value.</value>
		public decimal LONGITUD_FAMILIAR_CONTACTO
		{
			get
			{
				if(IsLONGITUD_FAMILIAR_CONTACTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud_familiar_contacto;
			}
			set
			{
				_longitud_familiar_contactoNull = false;
				_longitud_familiar_contacto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD_FAMILIAR_CONTACTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD_FAMILIAR_CONTACTONull
		{
			get { return _longitud_familiar_contactoNull; }
			set { _longitud_familiar_contactoNull = value; }
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
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
		/// Gets or sets the <c>INGRESO_SEGURO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_SEGURO</c> column value.</value>
		public System.DateTime INGRESO_SEGURO
		{
			get
			{
				if(IsINGRESO_SEGURONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_seguro;
			}
			set
			{
				_ingreso_seguroNull = false;
				_ingreso_seguro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_SEGURO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_SEGURONull
		{
			get { return _ingreso_seguroNull; }
			set { _ingreso_seguroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALARIO_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALARIO_TIPO</c> column value.</value>
		public decimal SALARIO_TIPO
		{
			get
			{
				if(IsSALARIO_TIPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _salario_tipo;
			}
			set
			{
				_salario_tipoNull = false;
				_salario_tipo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALARIO_TIPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALARIO_TIPONull
		{
			get { return _salario_tipoNull; }
			set { _salario_tipoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRA_SALARIO_MINIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COBRA_SALARIO_MINIMO</c> column value.</value>
		public string COBRA_SALARIO_MINIMO
		{
			get { return _cobra_salario_minimo; }
			set { _cobra_salario_minimo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALARIO</c> column value.</value>
		public decimal SALARIO
		{
			get
			{
				if(IsSALARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _salario;
			}
			set
			{
				_salarioNull = false;
				_salario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALARIONull
		{
			get { return _salarioNull; }
			set { _salarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALARIO_COMPLEMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALARIO_COMPLEMENTARIO</c> column value.</value>
		public decimal SALARIO_COMPLEMENTARIO
		{
			get
			{
				if(IsSALARIO_COMPLEMENTARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _salario_complementario;
			}
			set
			{
				_salario_complementarioNull = false;
				_salario_complementario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALARIO_COMPLEMENTARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALARIO_COMPLEMENTARIONull
		{
			get { return _salario_complementarioNull; }
			set { _salario_complementarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SALARIO_EXTRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALARIO_EXTRA</c> column value.</value>
		public decimal SALARIO_EXTRA
		{
			get
			{
				if(IsSALARIO_EXTRANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _salario_extra;
			}
			set
			{
				_salario_extraNull = false;
				_salario_extra = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SALARIO_EXTRA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSALARIO_EXTRANull
		{
			get { return _salario_extraNull; }
			set { _salario_extraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRA_ANTICIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COBRA_ANTICIPO</c> column value.</value>
		public string COBRA_ANTICIPO
		{
			get { return _cobra_anticipo; }
			set { _cobra_anticipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ANTICIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_ANTICIPO</c> column value.</value>
		public decimal MONTO_ANTICIPO
		{
			get
			{
				if(IsMONTO_ANTICIPONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_anticipo;
			}
			set
			{
				_monto_anticipoNull = false;
				_monto_anticipo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_ANTICIPO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_ANTICIPONull
		{
			get { return _monto_anticipoNull; }
			set { _monto_anticipoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRA_BONIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COBRA_BONIFICACION</c> column value.</value>
		public string COBRA_BONIFICACION
		{
			get { return _cobra_bonificacion; }
			set { _cobra_bonificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_BONIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_BONIFICACION</c> column value.</value>
		public decimal MONTO_BONIFICACION
		{
			get
			{
				if(IsMONTO_BONIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_bonificacion;
			}
			set
			{
				_monto_bonificacionNull = false;
				_monto_bonificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_BONIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_BONIFICACIONNull
		{
			get { return _monto_bonificacionNull; }
			set { _monto_bonificacionNull = value; }
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
		/// Gets or sets the <c>CTACTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE</c> column value.</value>
		public string CTACTE
		{
			get { return _ctacte; }
			set { _ctacte = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_SANGUINEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_SANGUINEO</c> column value.</value>
		public string GRUPO_SANGUINEO
		{
			get { return _grupo_sanguineo; }
			set { _grupo_sanguineo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_PROMOTOR</c> column value.
		/// </summary>
		/// <value>The <c>ES_PROMOTOR</c> column value.</value>
		public string ES_PROMOTOR
		{
			get { return _es_promotor; }
			set { _es_promotor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCACIONES_ID</c> column value.</value>
		public decimal MARCACIONES_ID
		{
			get
			{
				if(IsMARCACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _marcaciones_id;
			}
			set
			{
				_marcaciones_idNull = false;
				_marcaciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MARCACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMARCACIONES_IDNull
		{
			get { return _marcaciones_idNull; }
			set { _marcaciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CHOFER</c> column value.
		/// </summary>
		/// <value>The <c>ES_CHOFER</c> column value.</value>
		public string ES_CHOFER
		{
			get { return _es_chofer; }
			set { _es_chofer = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITERO</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITERO</c> column value.</value>
		public string DEPOSITERO
		{
			get { return _depositero; }
			set { _depositero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COBRADOR_EXTERNO</c> column value.
		/// </summary>
		/// <value>The <c>ES_COBRADOR_EXTERNO</c> column value.</value>
		public string ES_COBRADOR_EXTERNO
		{
			get { return _es_cobrador_externo; }
			set { _es_cobrador_externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_TALONARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_TALONARIO</c> column value.</value>
		public string CODIGO_TALONARIO
		{
			get { return _codigo_talonario; }
			set { _codigo_talonario = value; }
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
		/// Gets or sets the <c>DESCUENTOS_BASICO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTOS_BASICO</c> column value.</value>
		public string DESCUENTOS_BASICO
		{
			get { return _descuentos_basico; }
			set { _descuentos_basico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTOS_COMPLEMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTOS_COMPLEMENTARIO</c> column value.</value>
		public string DESCUENTOS_COMPLEMENTARIO
		{
			get { return _descuentos_complementario; }
			set { _descuentos_complementario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTOS_EXTRA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTOS_EXTRA</c> column value.</value>
		public string DESCUENTOS_EXTRA
		{
			get { return _descuentos_extra; }
			set { _descuentos_extra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANAL_VENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANAL_VENTA_ID</c> column value.</value>
		public decimal CANAL_VENTA_ID
		{
			get
			{
				if(IsCANAL_VENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _canal_venta_id;
			}
			set
			{
				_canal_venta_idNull = false;
				_canal_venta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANAL_VENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANAL_VENTA_IDNull
		{
			get { return _canal_venta_idNull; }
			set { _canal_venta_idNull = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@TRATAMIENTO_ID=");
			dynStr.Append(TRATAMIENTO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@APELLIDO=");
			dynStr.Append(APELLIDO);
			dynStr.Append("@CBA@APODO=");
			dynStr.Append(APODO);
			dynStr.Append("@CBA@GENERO=");
			dynStr.Append(GENERO);
			dynStr.Append("@CBA@RUC=");
			dynStr.Append(RUC);
			dynStr.Append("@CBA@NACIMIENTO=");
			dynStr.Append(IsNACIMIENTONull ? (object)"<NULL>" : NACIMIENTO);
			dynStr.Append("@CBA@TIPO_DOCUMENTO_IDENTIDAD_ID=");
			dynStr.Append(TIPO_DOCUMENTO_IDENTIDAD_ID);
			dynStr.Append("@CBA@NUMERO_DOCUMENTO=");
			dynStr.Append(NUMERO_DOCUMENTO);
			dynStr.Append("@CBA@PAIS_NACIONALIDAD_ID=");
			dynStr.Append(IsPAIS_NACIONALIDAD_IDNull ? (object)"<NULL>" : PAIS_NACIONALIDAD_ID);
			dynStr.Append("@CBA@PAIS_RESIDENCIA_ID=");
			dynStr.Append(IsPAIS_RESIDENCIA_IDNull ? (object)"<NULL>" : PAIS_RESIDENCIA_ID);
			dynStr.Append("@CBA@PROFESION_ID=");
			dynStr.Append(PROFESION_ID);
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
			dynStr.Append("@CBA@ES_VENDEDOR=");
			dynStr.Append(ES_VENDEDOR);
			dynStr.Append("@CBA@ES_COBRADOR=");
			dynStr.Append(ES_COBRADOR);
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
			dynStr.Append("@CBA@FECHA_CONTRATACION=");
			dynStr.Append(IsFECHA_CONTRATACIONNull ? (object)"<NULL>" : FECHA_CONTRATACION);
			dynStr.Append("@CBA@FECHA_SALIDA=");
			dynStr.Append(IsFECHA_SALIDANull ? (object)"<NULL>" : FECHA_SALIDA);
			dynStr.Append("@CBA@MOTIVO_SALIDA=");
			dynStr.Append(MOTIVO_SALIDA);
			dynStr.Append("@CBA@ESTADO_CIVIL_ID=");
			dynStr.Append(ESTADO_CIVIL_ID);
			dynStr.Append("@CBA@ESTADO_DOCUMENTACION_ID=");
			dynStr.Append(IsESTADO_DOCUMENTACION_IDNull ? (object)"<NULL>" : ESTADO_DOCUMENTACION_ID);
			dynStr.Append("@CBA@NOMBRE_FAMILIAR_CONTACTO=");
			dynStr.Append(NOMBRE_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@RELACION_FAMILIAR_CONTACTO=");
			dynStr.Append(RELACION_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@TELEFONO_FAMILIAR_CONTACTO=");
			dynStr.Append(TELEFONO_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@DEPARTAMENTO_FAMILIAR_CONT_ID=");
			dynStr.Append(IsDEPARTAMENTO_FAMILIAR_CONT_IDNull ? (object)"<NULL>" : DEPARTAMENTO_FAMILIAR_CONT_ID);
			dynStr.Append("@CBA@CIUDAD_FAMILIAR_CONTACTO_ID=");
			dynStr.Append(IsCIUDAD_FAMILIAR_CONTACTO_IDNull ? (object)"<NULL>" : CIUDAD_FAMILIAR_CONTACTO_ID);
			dynStr.Append("@CBA@BARRIO_FAMILIAR_CONTACTO_ID=");
			dynStr.Append(IsBARRIO_FAMILIAR_CONTACTO_IDNull ? (object)"<NULL>" : BARRIO_FAMILIAR_CONTACTO_ID);
			dynStr.Append("@CBA@CALLE_FAMILIAR_CONTACTO=");
			dynStr.Append(CALLE_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@COD_POST_FAMILIAR_CONTACTO=");
			dynStr.Append(COD_POST_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@LATITUD_FAMILIAR_CONTACTO=");
			dynStr.Append(IsLATITUD_FAMILIAR_CONTACTONull ? (object)"<NULL>" : LATITUD_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@LONGITUD_FAMILIAR_CONTACTO=");
			dynStr.Append(IsLONGITUD_FAMILIAR_CONTACTONull ? (object)"<NULL>" : LONGITUD_FAMILIAR_CONTACTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@INGRESO_APROBADO=");
			dynStr.Append(INGRESO_APROBADO);
			dynStr.Append("@CBA@USUARIO_APROBACION_ID=");
			dynStr.Append(IsUSUARIO_APROBACION_IDNull ? (object)"<NULL>" : USUARIO_APROBACION_ID);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@INGRESO_SEGURO=");
			dynStr.Append(IsINGRESO_SEGURONull ? (object)"<NULL>" : INGRESO_SEGURO);
			dynStr.Append("@CBA@SALARIO_TIPO=");
			dynStr.Append(IsSALARIO_TIPONull ? (object)"<NULL>" : SALARIO_TIPO);
			dynStr.Append("@CBA@COBRA_SALARIO_MINIMO=");
			dynStr.Append(COBRA_SALARIO_MINIMO);
			dynStr.Append("@CBA@SALARIO=");
			dynStr.Append(IsSALARIONull ? (object)"<NULL>" : SALARIO);
			dynStr.Append("@CBA@SALARIO_COMPLEMENTARIO=");
			dynStr.Append(IsSALARIO_COMPLEMENTARIONull ? (object)"<NULL>" : SALARIO_COMPLEMENTARIO);
			dynStr.Append("@CBA@SALARIO_EXTRA=");
			dynStr.Append(IsSALARIO_EXTRANull ? (object)"<NULL>" : SALARIO_EXTRA);
			dynStr.Append("@CBA@COBRA_ANTICIPO=");
			dynStr.Append(COBRA_ANTICIPO);
			dynStr.Append("@CBA@MONTO_ANTICIPO=");
			dynStr.Append(IsMONTO_ANTICIPONull ? (object)"<NULL>" : MONTO_ANTICIPO);
			dynStr.Append("@CBA@COBRA_BONIFICACION=");
			dynStr.Append(COBRA_BONIFICACION);
			dynStr.Append("@CBA@MONTO_BONIFICACION=");
			dynStr.Append(IsMONTO_BONIFICACIONNull ? (object)"<NULL>" : MONTO_BONIFICACION);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@CTACTE=");
			dynStr.Append(CTACTE);
			dynStr.Append("@CBA@GRUPO_SANGUINEO=");
			dynStr.Append(GRUPO_SANGUINEO);
			dynStr.Append("@CBA@ES_PROMOTOR=");
			dynStr.Append(ES_PROMOTOR);
			dynStr.Append("@CBA@MARCACIONES_ID=");
			dynStr.Append(IsMARCACIONES_IDNull ? (object)"<NULL>" : MARCACIONES_ID);
			dynStr.Append("@CBA@ES_CHOFER=");
			dynStr.Append(ES_CHOFER);
			dynStr.Append("@CBA@DEPOSITERO=");
			dynStr.Append(DEPOSITERO);
			dynStr.Append("@CBA@ES_COBRADOR_EXTERNO=");
			dynStr.Append(ES_COBRADOR_EXTERNO);
			dynStr.Append("@CBA@CODIGO_TALONARIO=");
			dynStr.Append(CODIGO_TALONARIO);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@DESCUENTOS_BASICO=");
			dynStr.Append(DESCUENTOS_BASICO);
			dynStr.Append("@CBA@DESCUENTOS_COMPLEMENTARIO=");
			dynStr.Append(DESCUENTOS_COMPLEMENTARIO);
			dynStr.Append("@CBA@DESCUENTOS_EXTRA=");
			dynStr.Append(DESCUENTOS_EXTRA);
			dynStr.Append("@CBA@CANAL_VENTA_ID=");
			dynStr.Append(IsCANAL_VENTA_IDNull ? (object)"<NULL>" : CANAL_VENTA_ID);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOSRow_Base class
} // End of namespace
