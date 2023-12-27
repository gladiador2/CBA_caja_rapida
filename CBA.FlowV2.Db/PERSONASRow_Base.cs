// <fileinfo name="PERSONASRow_Base.cs">
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
	/// The base class for <see cref="PERSONASRow"/> that 
	/// represents a record in the <c>PERSONAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONASRow_Base
	{
		private decimal _id;
		private string _codigo;
		private decimal _entidad_id;
		private string _fisico;
		private string _mayorista;
		private string _tratamiento_id;
		private string _nombre;
		private string _apellido;
		private string _nombre_completo;
		private string _nombre_fantasia;
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
		private string _en_informconf;
		private System.DateTime _fecha_modificacion_informconf;
		private bool _fecha_modificacion_informconfNull = true;
		private string _en_judicial;
		private string _es_cliente;
		private string _posee_unipersonal;
		private string _empresa_nombre_fantasia;
		private System.DateTime _fecha_modificacion_judicial;
		private bool _fecha_modificacion_judicialNull = true;
		private decimal _abogado_id;
		private bool _abogado_idNull = true;
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
		private decimal _rubro_id;
		private bool _rubro_idNull = true;
		private System.DateTime _empresa_fundacion;
		private bool _empresa_fundacionNull = true;
		private string _empresa_persona_contacto;
		private string _empresa_telefono_contacto;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private string _opera_credito;
		private decimal _condicion_habitual_pago_id;
		private decimal _moneda_limite_credito_id;
		private decimal _contador_credito_actual;
		private decimal _vendedor_habitual_id;
		private bool _vendedor_habitual_idNull = true;
		private decimal _cobrador_habitual_id;
		private bool _cobrador_habitual_idNull = true;
		private decimal _departamento_cobranza_id;
		private bool _departamento_cobranza_idNull = true;
		private decimal _ciudad_cobranza_id;
		private bool _ciudad_cobranza_idNull = true;
		private decimal _barrio_cobranza_id;
		private bool _barrio_cobranza_idNull = true;
		private string _calle_cobranza;
		private string _codigo_postal_cobranza;
		private decimal _latitud_cobranza;
		private bool _latitud_cobranzaNull = true;
		private decimal _longitud_cobranza;
		private bool _longitud_cobranzaNull = true;
		private string _telefono_cobranza1;
		private string _telefono_cobranza2;
		private string _conyuge_nombre;
		private string _conyuge_apellido;
		private decimal _estado_documentacion_id;
		private bool _estado_documentacion_idNull = true;
		private decimal _nivel_credito_id;
		private bool _nivel_credito_idNull = true;
		private string _agente_retencion;
		private string _bandera_retencion;
		private string _estado;
		private string _ingreso_aprobado;
		private decimal _usuario_aprobacion_id;
		private bool _usuario_aprobacion_idNull = true;
		private System.DateTime _fecha_aprobacion;
		private bool _fecha_aprobacionNull = true;
		private string _grupo_sanguineo;
		private string _estado_civil_id;
		private decimal _persona_id_conyuge;
		private bool _persona_id_conyugeNull = true;
		private decimal _numero_hijos;
		private bool _numero_hijosNull = true;
		private string _tipo_empleo;
		private string _separacion_bienes;
		private decimal _porc_descuento_automatico;
		private decimal _persona_calificacion_id;
		private bool _persona_calificacion_idNull = true;
		private decimal _zona_cobranza_id;
		private bool _zona_cobranza_idNull = true;
		private decimal _tipo_cliente_id;
		private bool _tipo_cliente_idNull = true;
		private decimal _estado_morosidad_id;
		private bool _estado_morosidad_idNull = true;
		private string _modificable;
		private string _es_contribuyente;
		private decimal _nro_tarjeta_red_pago;
		private bool _nro_tarjeta_red_pagoNull = true;
		private decimal _centro_costo_id;
		private bool _centro_costo_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _codigo_externo;
		private System.DateTime _fecha_ultima_visita;
		private bool _fecha_ultima_visitaNull = true;
		private System.DateTime _fecha_ultima_actualizac_datos;
		private decimal _persona_padre_id;
		private bool _persona_padre_idNull = true;
		private decimal _lista_precios_id;
		private bool _lista_precios_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONASRow_Base"/> class.
		/// </summary>
		public PERSONASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.FISICO != original.FISICO) return true;
			if (this.MAYORISTA != original.MAYORISTA) return true;
			if (this.TRATAMIENTO_ID != original.TRATAMIENTO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.APELLIDO != original.APELLIDO) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.NOMBRE_FANTASIA != original.NOMBRE_FANTASIA) return true;
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
			if (this.EN_INFORMCONF != original.EN_INFORMCONF) return true;
			if (this.IsFECHA_MODIFICACION_INFORMCONFNull != original.IsFECHA_MODIFICACION_INFORMCONFNull) return true;
			if (!this.IsFECHA_MODIFICACION_INFORMCONFNull && !original.IsFECHA_MODIFICACION_INFORMCONFNull)
				if (this.FECHA_MODIFICACION_INFORMCONF != original.FECHA_MODIFICACION_INFORMCONF) return true;
			if (this.EN_JUDICIAL != original.EN_JUDICIAL) return true;
			if (this.ES_CLIENTE != original.ES_CLIENTE) return true;
			if (this.POSEE_UNIPERSONAL != original.POSEE_UNIPERSONAL) return true;
			if (this.EMPRESA_NOMBRE_FANTASIA != original.EMPRESA_NOMBRE_FANTASIA) return true;
			if (this.IsFECHA_MODIFICACION_JUDICIALNull != original.IsFECHA_MODIFICACION_JUDICIALNull) return true;
			if (!this.IsFECHA_MODIFICACION_JUDICIALNull && !original.IsFECHA_MODIFICACION_JUDICIALNull)
				if (this.FECHA_MODIFICACION_JUDICIAL != original.FECHA_MODIFICACION_JUDICIAL) return true;
			if (this.IsABOGADO_IDNull != original.IsABOGADO_IDNull) return true;
			if (!this.IsABOGADO_IDNull && !original.IsABOGADO_IDNull)
				if (this.ABOGADO_ID != original.ABOGADO_ID) return true;
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
			if (this.IsRUBRO_IDNull != original.IsRUBRO_IDNull) return true;
			if (!this.IsRUBRO_IDNull && !original.IsRUBRO_IDNull)
				if (this.RUBRO_ID != original.RUBRO_ID) return true;
			if (this.IsEMPRESA_FUNDACIONNull != original.IsEMPRESA_FUNDACIONNull) return true;
			if (!this.IsEMPRESA_FUNDACIONNull && !original.IsEMPRESA_FUNDACIONNull)
				if (this.EMPRESA_FUNDACION != original.EMPRESA_FUNDACION) return true;
			if (this.EMPRESA_PERSONA_CONTACTO != original.EMPRESA_PERSONA_CONTACTO) return true;
			if (this.EMPRESA_TELEFONO_CONTACTO != original.EMPRESA_TELEFONO_CONTACTO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.OPERA_CREDITO != original.OPERA_CREDITO) return true;
			if (this.CONDICION_HABITUAL_PAGO_ID != original.CONDICION_HABITUAL_PAGO_ID) return true;
			if (this.MONEDA_LIMITE_CREDITO_ID != original.MONEDA_LIMITE_CREDITO_ID) return true;
			if (this.CONTADOR_CREDITO_ACTUAL != original.CONTADOR_CREDITO_ACTUAL) return true;
			if (this.IsVENDEDOR_HABITUAL_IDNull != original.IsVENDEDOR_HABITUAL_IDNull) return true;
			if (!this.IsVENDEDOR_HABITUAL_IDNull && !original.IsVENDEDOR_HABITUAL_IDNull)
				if (this.VENDEDOR_HABITUAL_ID != original.VENDEDOR_HABITUAL_ID) return true;
			if (this.IsCOBRADOR_HABITUAL_IDNull != original.IsCOBRADOR_HABITUAL_IDNull) return true;
			if (!this.IsCOBRADOR_HABITUAL_IDNull && !original.IsCOBRADOR_HABITUAL_IDNull)
				if (this.COBRADOR_HABITUAL_ID != original.COBRADOR_HABITUAL_ID) return true;
			if (this.IsDEPARTAMENTO_COBRANZA_IDNull != original.IsDEPARTAMENTO_COBRANZA_IDNull) return true;
			if (!this.IsDEPARTAMENTO_COBRANZA_IDNull && !original.IsDEPARTAMENTO_COBRANZA_IDNull)
				if (this.DEPARTAMENTO_COBRANZA_ID != original.DEPARTAMENTO_COBRANZA_ID) return true;
			if (this.IsCIUDAD_COBRANZA_IDNull != original.IsCIUDAD_COBRANZA_IDNull) return true;
			if (!this.IsCIUDAD_COBRANZA_IDNull && !original.IsCIUDAD_COBRANZA_IDNull)
				if (this.CIUDAD_COBRANZA_ID != original.CIUDAD_COBRANZA_ID) return true;
			if (this.IsBARRIO_COBRANZA_IDNull != original.IsBARRIO_COBRANZA_IDNull) return true;
			if (!this.IsBARRIO_COBRANZA_IDNull && !original.IsBARRIO_COBRANZA_IDNull)
				if (this.BARRIO_COBRANZA_ID != original.BARRIO_COBRANZA_ID) return true;
			if (this.CALLE_COBRANZA != original.CALLE_COBRANZA) return true;
			if (this.CODIGO_POSTAL_COBRANZA != original.CODIGO_POSTAL_COBRANZA) return true;
			if (this.IsLATITUD_COBRANZANull != original.IsLATITUD_COBRANZANull) return true;
			if (!this.IsLATITUD_COBRANZANull && !original.IsLATITUD_COBRANZANull)
				if (this.LATITUD_COBRANZA != original.LATITUD_COBRANZA) return true;
			if (this.IsLONGITUD_COBRANZANull != original.IsLONGITUD_COBRANZANull) return true;
			if (!this.IsLONGITUD_COBRANZANull && !original.IsLONGITUD_COBRANZANull)
				if (this.LONGITUD_COBRANZA != original.LONGITUD_COBRANZA) return true;
			if (this.TELEFONO_COBRANZA1 != original.TELEFONO_COBRANZA1) return true;
			if (this.TELEFONO_COBRANZA2 != original.TELEFONO_COBRANZA2) return true;
			if (this.CONYUGE_NOMBRE != original.CONYUGE_NOMBRE) return true;
			if (this.CONYUGE_APELLIDO != original.CONYUGE_APELLIDO) return true;
			if (this.IsESTADO_DOCUMENTACION_IDNull != original.IsESTADO_DOCUMENTACION_IDNull) return true;
			if (!this.IsESTADO_DOCUMENTACION_IDNull && !original.IsESTADO_DOCUMENTACION_IDNull)
				if (this.ESTADO_DOCUMENTACION_ID != original.ESTADO_DOCUMENTACION_ID) return true;
			if (this.IsNIVEL_CREDITO_IDNull != original.IsNIVEL_CREDITO_IDNull) return true;
			if (!this.IsNIVEL_CREDITO_IDNull && !original.IsNIVEL_CREDITO_IDNull)
				if (this.NIVEL_CREDITO_ID != original.NIVEL_CREDITO_ID) return true;
			if (this.AGENTE_RETENCION != original.AGENTE_RETENCION) return true;
			if (this.BANDERA_RETENCION != original.BANDERA_RETENCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.INGRESO_APROBADO != original.INGRESO_APROBADO) return true;
			if (this.IsUSUARIO_APROBACION_IDNull != original.IsUSUARIO_APROBACION_IDNull) return true;
			if (!this.IsUSUARIO_APROBACION_IDNull && !original.IsUSUARIO_APROBACION_IDNull)
				if (this.USUARIO_APROBACION_ID != original.USUARIO_APROBACION_ID) return true;
			if (this.IsFECHA_APROBACIONNull != original.IsFECHA_APROBACIONNull) return true;
			if (!this.IsFECHA_APROBACIONNull && !original.IsFECHA_APROBACIONNull)
				if (this.FECHA_APROBACION != original.FECHA_APROBACION) return true;
			if (this.GRUPO_SANGUINEO != original.GRUPO_SANGUINEO) return true;
			if (this.ESTADO_CIVIL_ID != original.ESTADO_CIVIL_ID) return true;
			if (this.IsPERSONA_ID_CONYUGENull != original.IsPERSONA_ID_CONYUGENull) return true;
			if (!this.IsPERSONA_ID_CONYUGENull && !original.IsPERSONA_ID_CONYUGENull)
				if (this.PERSONA_ID_CONYUGE != original.PERSONA_ID_CONYUGE) return true;
			if (this.IsNUMERO_HIJOSNull != original.IsNUMERO_HIJOSNull) return true;
			if (!this.IsNUMERO_HIJOSNull && !original.IsNUMERO_HIJOSNull)
				if (this.NUMERO_HIJOS != original.NUMERO_HIJOS) return true;
			if (this.TIPO_EMPLEO != original.TIPO_EMPLEO) return true;
			if (this.SEPARACION_BIENES != original.SEPARACION_BIENES) return true;
			if (this.PORC_DESCUENTO_AUTOMATICO != original.PORC_DESCUENTO_AUTOMATICO) return true;
			if (this.IsPERSONA_CALIFICACION_IDNull != original.IsPERSONA_CALIFICACION_IDNull) return true;
			if (!this.IsPERSONA_CALIFICACION_IDNull && !original.IsPERSONA_CALIFICACION_IDNull)
				if (this.PERSONA_CALIFICACION_ID != original.PERSONA_CALIFICACION_ID) return true;
			if (this.IsZONA_COBRANZA_IDNull != original.IsZONA_COBRANZA_IDNull) return true;
			if (!this.IsZONA_COBRANZA_IDNull && !original.IsZONA_COBRANZA_IDNull)
				if (this.ZONA_COBRANZA_ID != original.ZONA_COBRANZA_ID) return true;
			if (this.IsTIPO_CLIENTE_IDNull != original.IsTIPO_CLIENTE_IDNull) return true;
			if (!this.IsTIPO_CLIENTE_IDNull && !original.IsTIPO_CLIENTE_IDNull)
				if (this.TIPO_CLIENTE_ID != original.TIPO_CLIENTE_ID) return true;
			if (this.IsESTADO_MOROSIDAD_IDNull != original.IsESTADO_MOROSIDAD_IDNull) return true;
			if (!this.IsESTADO_MOROSIDAD_IDNull && !original.IsESTADO_MOROSIDAD_IDNull)
				if (this.ESTADO_MOROSIDAD_ID != original.ESTADO_MOROSIDAD_ID) return true;
			if (this.MODIFICABLE != original.MODIFICABLE) return true;
			if (this.ES_CONTRIBUYENTE != original.ES_CONTRIBUYENTE) return true;
			if (this.IsNRO_TARJETA_RED_PAGONull != original.IsNRO_TARJETA_RED_PAGONull) return true;
			if (!this.IsNRO_TARJETA_RED_PAGONull && !original.IsNRO_TARJETA_RED_PAGONull)
				if (this.NRO_TARJETA_RED_PAGO != original.NRO_TARJETA_RED_PAGO) return true;
			if (this.IsCENTRO_COSTO_IDNull != original.IsCENTRO_COSTO_IDNull) return true;
			if (!this.IsCENTRO_COSTO_IDNull && !original.IsCENTRO_COSTO_IDNull)
				if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.CODIGO_EXTERNO != original.CODIGO_EXTERNO) return true;
			if (this.IsFECHA_ULTIMA_VISITANull != original.IsFECHA_ULTIMA_VISITANull) return true;
			if (!this.IsFECHA_ULTIMA_VISITANull && !original.IsFECHA_ULTIMA_VISITANull)
				if (this.FECHA_ULTIMA_VISITA != original.FECHA_ULTIMA_VISITA) return true;
			if (this.FECHA_ULTIMA_ACTUALIZAC_DATOS != original.FECHA_ULTIMA_ACTUALIZAC_DATOS) return true;
			if (this.IsPERSONA_PADRE_IDNull != original.IsPERSONA_PADRE_IDNull) return true;
			if (!this.IsPERSONA_PADRE_IDNull && !original.IsPERSONA_PADRE_IDNull)
				if (this.PERSONA_PADRE_ID != original.PERSONA_PADRE_ID) return true;
			if (this.IsLISTA_PRECIOS_IDNull != original.IsLISTA_PRECIOS_IDNull) return true;
			if (!this.IsLISTA_PRECIOS_IDNull && !original.IsLISTA_PRECIOS_IDNull)
				if (this.LISTA_PRECIOS_ID != original.LISTA_PRECIOS_ID) return true;
			
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
		/// Gets or sets the <c>FISICO</c> column value.
		/// </summary>
		/// <value>The <c>FISICO</c> column value.</value>
		public string FISICO
		{
			get { return _fisico; }
			set { _fisico = value; }
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
		/// Gets or sets the <c>EN_INFORMCONF</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EN_INFORMCONF</c> column value.</value>
		public string EN_INFORMCONF
		{
			get { return _en_informconf; }
			set { _en_informconf = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MODIFICACION_INFORMCONF</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_MODIFICACION_INFORMCONF</c> column value.</value>
		public System.DateTime FECHA_MODIFICACION_INFORMCONF
		{
			get
			{
				if(IsFECHA_MODIFICACION_INFORMCONFNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_modificacion_informconf;
			}
			set
			{
				_fecha_modificacion_informconfNull = false;
				_fecha_modificacion_informconf = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_MODIFICACION_INFORMCONF"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_MODIFICACION_INFORMCONFNull
		{
			get { return _fecha_modificacion_informconfNull; }
			set { _fecha_modificacion_informconfNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EN_JUDICIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EN_JUDICIAL</c> column value.</value>
		public string EN_JUDICIAL
		{
			get { return _en_judicial; }
			set { _en_judicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CLIENTE</c> column value.
		/// </summary>
		/// <value>The <c>ES_CLIENTE</c> column value.</value>
		public string ES_CLIENTE
		{
			get { return _es_cliente; }
			set { _es_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>POSEE_UNIPERSONAL</c> column value.
		/// </summary>
		/// <value>The <c>POSEE_UNIPERSONAL</c> column value.</value>
		public string POSEE_UNIPERSONAL
		{
			get { return _posee_unipersonal; }
			set { _posee_unipersonal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_NOMBRE_FANTASIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_NOMBRE_FANTASIA</c> column value.</value>
		public string EMPRESA_NOMBRE_FANTASIA
		{
			get { return _empresa_nombre_fantasia; }
			set { _empresa_nombre_fantasia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MODIFICACION_JUDICIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_MODIFICACION_JUDICIAL</c> column value.</value>
		public System.DateTime FECHA_MODIFICACION_JUDICIAL
		{
			get
			{
				if(IsFECHA_MODIFICACION_JUDICIALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_modificacion_judicial;
			}
			set
			{
				_fecha_modificacion_judicialNull = false;
				_fecha_modificacion_judicial = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_MODIFICACION_JUDICIAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_MODIFICACION_JUDICIALNull
		{
			get { return _fecha_modificacion_judicialNull; }
			set { _fecha_modificacion_judicialNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABOGADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ABOGADO_ID</c> column value.</value>
		public decimal ABOGADO_ID
		{
			get
			{
				if(IsABOGADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _abogado_id;
			}
			set
			{
				_abogado_idNull = false;
				_abogado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ABOGADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsABOGADO_IDNull
		{
			get { return _abogado_idNull; }
			set { _abogado_idNull = value; }
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
		/// Gets or sets the <c>EMPRESA_FUNDACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_FUNDACION</c> column value.</value>
		public System.DateTime EMPRESA_FUNDACION
		{
			get
			{
				if(IsEMPRESA_FUNDACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _empresa_fundacion;
			}
			set
			{
				_empresa_fundacionNull = false;
				_empresa_fundacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EMPRESA_FUNDACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEMPRESA_FUNDACIONNull
		{
			get { return _empresa_fundacionNull; }
			set { _empresa_fundacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_PERSONA_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_PERSONA_CONTACTO</c> column value.</value>
		public string EMPRESA_PERSONA_CONTACTO
		{
			get { return _empresa_persona_contacto; }
			set { _empresa_persona_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMPRESA_TELEFONO_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMPRESA_TELEFONO_CONTACTO</c> column value.</value>
		public string EMPRESA_TELEFONO_CONTACTO
		{
			get { return _empresa_telefono_contacto; }
			set { _empresa_telefono_contacto = value; }
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
		/// </summary>
		/// <value>The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</value>
		public decimal CONDICION_HABITUAL_PAGO_ID
		{
			get { return _condicion_habitual_pago_id; }
			set { _condicion_habitual_pago_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_LIMITE_CREDITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_LIMITE_CREDITO_ID</c> column value.</value>
		public decimal MONEDA_LIMITE_CREDITO_ID
		{
			get { return _moneda_limite_credito_id; }
			set { _moneda_limite_credito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTADOR_CREDITO_ACTUAL</c> column value.
		/// </summary>
		/// <value>The <c>CONTADOR_CREDITO_ACTUAL</c> column value.</value>
		public decimal CONTADOR_CREDITO_ACTUAL
		{
			get { return _contador_credito_actual; }
			set { _contador_credito_actual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_HABITUAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_HABITUAL_ID</c> column value.</value>
		public decimal VENDEDOR_HABITUAL_ID
		{
			get
			{
				if(IsVENDEDOR_HABITUAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vendedor_habitual_id;
			}
			set
			{
				_vendedor_habitual_idNull = false;
				_vendedor_habitual_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENDEDOR_HABITUAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENDEDOR_HABITUAL_IDNull
		{
			get { return _vendedor_habitual_idNull; }
			set { _vendedor_habitual_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRADOR_HABITUAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COBRADOR_HABITUAL_ID</c> column value.</value>
		public decimal COBRADOR_HABITUAL_ID
		{
			get
			{
				if(IsCOBRADOR_HABITUAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cobrador_habitual_id;
			}
			set
			{
				_cobrador_habitual_idNull = false;
				_cobrador_habitual_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COBRADOR_HABITUAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOBRADOR_HABITUAL_IDNull
		{
			get { return _cobrador_habitual_idNull; }
			set { _cobrador_habitual_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO_COBRANZA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</value>
		public decimal DEPARTAMENTO_COBRANZA_ID
		{
			get
			{
				if(IsDEPARTAMENTO_COBRANZA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_cobranza_id;
			}
			set
			{
				_departamento_cobranza_idNull = false;
				_departamento_cobranza_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_COBRANZA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_COBRANZA_IDNull
		{
			get { return _departamento_cobranza_idNull; }
			set { _departamento_cobranza_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD_COBRANZA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_COBRANZA_ID</c> column value.</value>
		public decimal CIUDAD_COBRANZA_ID
		{
			get
			{
				if(IsCIUDAD_COBRANZA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_cobranza_id;
			}
			set
			{
				_ciudad_cobranza_idNull = false;
				_ciudad_cobranza_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_COBRANZA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_COBRANZA_IDNull
		{
			get { return _ciudad_cobranza_idNull; }
			set { _ciudad_cobranza_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO_COBRANZA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_COBRANZA_ID</c> column value.</value>
		public decimal BARRIO_COBRANZA_ID
		{
			get
			{
				if(IsBARRIO_COBRANZA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio_cobranza_id;
			}
			set
			{
				_barrio_cobranza_idNull = false;
				_barrio_cobranza_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO_COBRANZA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO_COBRANZA_IDNull
		{
			get { return _barrio_cobranza_idNull; }
			set { _barrio_cobranza_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE_COBRANZA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE_COBRANZA</c> column value.</value>
		public string CALLE_COBRANZA
		{
			get { return _calle_cobranza; }
			set { _calle_cobranza = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_POSTAL_COBRANZA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_POSTAL_COBRANZA</c> column value.</value>
		public string CODIGO_POSTAL_COBRANZA
		{
			get { return _codigo_postal_cobranza; }
			set { _codigo_postal_cobranza = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LATITUD_COBRANZA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LATITUD_COBRANZA</c> column value.</value>
		public decimal LATITUD_COBRANZA
		{
			get
			{
				if(IsLATITUD_COBRANZANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _latitud_cobranza;
			}
			set
			{
				_latitud_cobranzaNull = false;
				_latitud_cobranza = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LATITUD_COBRANZA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLATITUD_COBRANZANull
		{
			get { return _latitud_cobranzaNull; }
			set { _latitud_cobranzaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LONGITUD_COBRANZA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LONGITUD_COBRANZA</c> column value.</value>
		public decimal LONGITUD_COBRANZA
		{
			get
			{
				if(IsLONGITUD_COBRANZANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _longitud_cobranza;
			}
			set
			{
				_longitud_cobranzaNull = false;
				_longitud_cobranza = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LONGITUD_COBRANZA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLONGITUD_COBRANZANull
		{
			get { return _longitud_cobranzaNull; }
			set { _longitud_cobranzaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_COBRANZA1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO_COBRANZA1</c> column value.</value>
		public string TELEFONO_COBRANZA1
		{
			get { return _telefono_cobranza1; }
			set { _telefono_cobranza1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_COBRANZA2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO_COBRANZA2</c> column value.</value>
		public string TELEFONO_COBRANZA2
		{
			get { return _telefono_cobranza2; }
			set { _telefono_cobranza2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONYUGE_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONYUGE_NOMBRE</c> column value.</value>
		public string CONYUGE_NOMBRE
		{
			get { return _conyuge_nombre; }
			set { _conyuge_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONYUGE_APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONYUGE_APELLIDO</c> column value.</value>
		public string CONYUGE_APELLIDO
		{
			get { return _conyuge_apellido; }
			set { _conyuge_apellido = value; }
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
		/// Gets or sets the <c>NIVEL_CREDITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NIVEL_CREDITO_ID</c> column value.</value>
		public decimal NIVEL_CREDITO_ID
		{
			get
			{
				if(IsNIVEL_CREDITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nivel_credito_id;
			}
			set
			{
				_nivel_credito_idNull = false;
				_nivel_credito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NIVEL_CREDITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNIVEL_CREDITO_IDNull
		{
			get { return _nivel_credito_idNull; }
			set { _nivel_credito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENTE_RETENCION</c> column value.
		/// </summary>
		/// <value>The <c>AGENTE_RETENCION</c> column value.</value>
		public string AGENTE_RETENCION
		{
			get { return _agente_retencion; }
			set { _agente_retencion = value; }
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
		/// Gets or sets the <c>PERSONA_ID_CONYUGE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID_CONYUGE</c> column value.</value>
		public decimal PERSONA_ID_CONYUGE
		{
			get
			{
				if(IsPERSONA_ID_CONYUGENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id_conyuge;
			}
			set
			{
				_persona_id_conyugeNull = false;
				_persona_id_conyuge = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID_CONYUGE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_ID_CONYUGENull
		{
			get { return _persona_id_conyugeNull; }
			set { _persona_id_conyugeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_HIJOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_HIJOS</c> column value.</value>
		public decimal NUMERO_HIJOS
		{
			get
			{
				if(IsNUMERO_HIJOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _numero_hijos;
			}
			set
			{
				_numero_hijosNull = false;
				_numero_hijos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NUMERO_HIJOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNUMERO_HIJOSNull
		{
			get { return _numero_hijosNull; }
			set { _numero_hijosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EMPLEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_EMPLEO</c> column value.</value>
		public string TIPO_EMPLEO
		{
			get { return _tipo_empleo; }
			set { _tipo_empleo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SEPARACION_BIENES</c> column value.
		/// </summary>
		/// <value>The <c>SEPARACION_BIENES</c> column value.</value>
		public string SEPARACION_BIENES
		{
			get { return _separacion_bienes; }
			set { _separacion_bienes = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORC_DESCUENTO_AUTOMATICO</c> column value.
		/// </summary>
		/// <value>The <c>PORC_DESCUENTO_AUTOMATICO</c> column value.</value>
		public decimal PORC_DESCUENTO_AUTOMATICO
		{
			get { return _porc_descuento_automatico; }
			set { _porc_descuento_automatico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CALIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CALIFICACION_ID</c> column value.</value>
		public decimal PERSONA_CALIFICACION_ID
		{
			get
			{
				if(IsPERSONA_CALIFICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_calificacion_id;
			}
			set
			{
				_persona_calificacion_idNull = false;
				_persona_calificacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_CALIFICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_CALIFICACION_IDNull
		{
			get { return _persona_calificacion_idNull; }
			set { _persona_calificacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ZONA_COBRANZA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ZONA_COBRANZA_ID</c> column value.</value>
		public decimal ZONA_COBRANZA_ID
		{
			get
			{
				if(IsZONA_COBRANZA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _zona_cobranza_id;
			}
			set
			{
				_zona_cobranza_idNull = false;
				_zona_cobranza_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ZONA_COBRANZA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsZONA_COBRANZA_IDNull
		{
			get { return _zona_cobranza_idNull; }
			set { _zona_cobranza_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CLIENTE_ID</c> column value.</value>
		public decimal TIPO_CLIENTE_ID
		{
			get
			{
				if(IsTIPO_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_cliente_id;
			}
			set
			{
				_tipo_cliente_idNull = false;
				_tipo_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CLIENTE_IDNull
		{
			get { return _tipo_cliente_idNull; }
			set { _tipo_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_MOROSIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_MOROSIDAD_ID</c> column value.</value>
		public decimal ESTADO_MOROSIDAD_ID
		{
			get
			{
				if(IsESTADO_MOROSIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estado_morosidad_id;
			}
			set
			{
				_estado_morosidad_idNull = false;
				_estado_morosidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTADO_MOROSIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTADO_MOROSIDAD_IDNull
		{
			get { return _estado_morosidad_idNull; }
			set { _estado_morosidad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MODIFICABLE</c> column value.
		/// </summary>
		/// <value>The <c>MODIFICABLE</c> column value.</value>
		public string MODIFICABLE
		{
			get { return _modificable; }
			set { _modificable = value; }
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
		/// Gets or sets the <c>NRO_TARJETA_RED_PAGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_TARJETA_RED_PAGO</c> column value.</value>
		public decimal NRO_TARJETA_RED_PAGO
		{
			get
			{
				if(IsNRO_TARJETA_RED_PAGONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nro_tarjeta_red_pago;
			}
			set
			{
				_nro_tarjeta_red_pagoNull = false;
				_nro_tarjeta_red_pago = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NRO_TARJETA_RED_PAGO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNRO_TARJETA_RED_PAGONull
		{
			get { return _nro_tarjeta_red_pagoNull; }
			set { _nro_tarjeta_red_pagoNull = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EXTERNO</c> column value.</value>
		public string CODIGO_EXTERNO
		{
			get { return _codigo_externo; }
			set { _codigo_externo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMA_VISITA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMA_VISITA</c> column value.</value>
		public System.DateTime FECHA_ULTIMA_VISITA
		{
			get
			{
				if(IsFECHA_ULTIMA_VISITANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ultima_visita;
			}
			set
			{
				_fecha_ultima_visitaNull = false;
				_fecha_ultima_visita = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ULTIMA_VISITA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ULTIMA_VISITANull
		{
			get { return _fecha_ultima_visitaNull; }
			set { _fecha_ultima_visitaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ULTIMA_ACTUALIZAC_DATOS</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ULTIMA_ACTUALIZAC_DATOS</c> column value.</value>
		public System.DateTime FECHA_ULTIMA_ACTUALIZAC_DATOS
		{
			get { return _fecha_ultima_actualizac_datos; }
			set { _fecha_ultima_actualizac_datos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_PADRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_PADRE_ID</c> column value.</value>
		public decimal PERSONA_PADRE_ID
		{
			get
			{
				if(IsPERSONA_PADRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_padre_id;
			}
			set
			{
				_persona_padre_idNull = false;
				_persona_padre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_PADRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_PADRE_IDNull
		{
			get { return _persona_padre_idNull; }
			set { _persona_padre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_ID</c> column value.</value>
		public decimal LISTA_PRECIOS_ID
		{
			get
			{
				if(IsLISTA_PRECIOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precios_id;
			}
			set
			{
				_lista_precios_idNull = false;
				_lista_precios_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIOS_IDNull
		{
			get { return _lista_precios_idNull; }
			set { _lista_precios_idNull = value; }
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
			dynStr.Append("@CBA@FISICO=");
			dynStr.Append(FISICO);
			dynStr.Append("@CBA@MAYORISTA=");
			dynStr.Append(MAYORISTA);
			dynStr.Append("@CBA@TRATAMIENTO_ID=");
			dynStr.Append(TRATAMIENTO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@APELLIDO=");
			dynStr.Append(APELLIDO);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@NOMBRE_FANTASIA=");
			dynStr.Append(NOMBRE_FANTASIA);
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
			dynStr.Append("@CBA@EN_INFORMCONF=");
			dynStr.Append(EN_INFORMCONF);
			dynStr.Append("@CBA@FECHA_MODIFICACION_INFORMCONF=");
			dynStr.Append(IsFECHA_MODIFICACION_INFORMCONFNull ? (object)"<NULL>" : FECHA_MODIFICACION_INFORMCONF);
			dynStr.Append("@CBA@EN_JUDICIAL=");
			dynStr.Append(EN_JUDICIAL);
			dynStr.Append("@CBA@ES_CLIENTE=");
			dynStr.Append(ES_CLIENTE);
			dynStr.Append("@CBA@POSEE_UNIPERSONAL=");
			dynStr.Append(POSEE_UNIPERSONAL);
			dynStr.Append("@CBA@EMPRESA_NOMBRE_FANTASIA=");
			dynStr.Append(EMPRESA_NOMBRE_FANTASIA);
			dynStr.Append("@CBA@FECHA_MODIFICACION_JUDICIAL=");
			dynStr.Append(IsFECHA_MODIFICACION_JUDICIALNull ? (object)"<NULL>" : FECHA_MODIFICACION_JUDICIAL);
			dynStr.Append("@CBA@ABOGADO_ID=");
			dynStr.Append(IsABOGADO_IDNull ? (object)"<NULL>" : ABOGADO_ID);
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
			dynStr.Append("@CBA@RUBRO_ID=");
			dynStr.Append(IsRUBRO_IDNull ? (object)"<NULL>" : RUBRO_ID);
			dynStr.Append("@CBA@EMPRESA_FUNDACION=");
			dynStr.Append(IsEMPRESA_FUNDACIONNull ? (object)"<NULL>" : EMPRESA_FUNDACION);
			dynStr.Append("@CBA@EMPRESA_PERSONA_CONTACTO=");
			dynStr.Append(EMPRESA_PERSONA_CONTACTO);
			dynStr.Append("@CBA@EMPRESA_TELEFONO_CONTACTO=");
			dynStr.Append(EMPRESA_TELEFONO_CONTACTO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@OPERA_CREDITO=");
			dynStr.Append(OPERA_CREDITO);
			dynStr.Append("@CBA@CONDICION_HABITUAL_PAGO_ID=");
			dynStr.Append(CONDICION_HABITUAL_PAGO_ID);
			dynStr.Append("@CBA@MONEDA_LIMITE_CREDITO_ID=");
			dynStr.Append(MONEDA_LIMITE_CREDITO_ID);
			dynStr.Append("@CBA@CONTADOR_CREDITO_ACTUAL=");
			dynStr.Append(CONTADOR_CREDITO_ACTUAL);
			dynStr.Append("@CBA@VENDEDOR_HABITUAL_ID=");
			dynStr.Append(IsVENDEDOR_HABITUAL_IDNull ? (object)"<NULL>" : VENDEDOR_HABITUAL_ID);
			dynStr.Append("@CBA@COBRADOR_HABITUAL_ID=");
			dynStr.Append(IsCOBRADOR_HABITUAL_IDNull ? (object)"<NULL>" : COBRADOR_HABITUAL_ID);
			dynStr.Append("@CBA@DEPARTAMENTO_COBRANZA_ID=");
			dynStr.Append(IsDEPARTAMENTO_COBRANZA_IDNull ? (object)"<NULL>" : DEPARTAMENTO_COBRANZA_ID);
			dynStr.Append("@CBA@CIUDAD_COBRANZA_ID=");
			dynStr.Append(IsCIUDAD_COBRANZA_IDNull ? (object)"<NULL>" : CIUDAD_COBRANZA_ID);
			dynStr.Append("@CBA@BARRIO_COBRANZA_ID=");
			dynStr.Append(IsBARRIO_COBRANZA_IDNull ? (object)"<NULL>" : BARRIO_COBRANZA_ID);
			dynStr.Append("@CBA@CALLE_COBRANZA=");
			dynStr.Append(CALLE_COBRANZA);
			dynStr.Append("@CBA@CODIGO_POSTAL_COBRANZA=");
			dynStr.Append(CODIGO_POSTAL_COBRANZA);
			dynStr.Append("@CBA@LATITUD_COBRANZA=");
			dynStr.Append(IsLATITUD_COBRANZANull ? (object)"<NULL>" : LATITUD_COBRANZA);
			dynStr.Append("@CBA@LONGITUD_COBRANZA=");
			dynStr.Append(IsLONGITUD_COBRANZANull ? (object)"<NULL>" : LONGITUD_COBRANZA);
			dynStr.Append("@CBA@TELEFONO_COBRANZA1=");
			dynStr.Append(TELEFONO_COBRANZA1);
			dynStr.Append("@CBA@TELEFONO_COBRANZA2=");
			dynStr.Append(TELEFONO_COBRANZA2);
			dynStr.Append("@CBA@CONYUGE_NOMBRE=");
			dynStr.Append(CONYUGE_NOMBRE);
			dynStr.Append("@CBA@CONYUGE_APELLIDO=");
			dynStr.Append(CONYUGE_APELLIDO);
			dynStr.Append("@CBA@ESTADO_DOCUMENTACION_ID=");
			dynStr.Append(IsESTADO_DOCUMENTACION_IDNull ? (object)"<NULL>" : ESTADO_DOCUMENTACION_ID);
			dynStr.Append("@CBA@NIVEL_CREDITO_ID=");
			dynStr.Append(IsNIVEL_CREDITO_IDNull ? (object)"<NULL>" : NIVEL_CREDITO_ID);
			dynStr.Append("@CBA@AGENTE_RETENCION=");
			dynStr.Append(AGENTE_RETENCION);
			dynStr.Append("@CBA@BANDERA_RETENCION=");
			dynStr.Append(BANDERA_RETENCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@INGRESO_APROBADO=");
			dynStr.Append(INGRESO_APROBADO);
			dynStr.Append("@CBA@USUARIO_APROBACION_ID=");
			dynStr.Append(IsUSUARIO_APROBACION_IDNull ? (object)"<NULL>" : USUARIO_APROBACION_ID);
			dynStr.Append("@CBA@FECHA_APROBACION=");
			dynStr.Append(IsFECHA_APROBACIONNull ? (object)"<NULL>" : FECHA_APROBACION);
			dynStr.Append("@CBA@GRUPO_SANGUINEO=");
			dynStr.Append(GRUPO_SANGUINEO);
			dynStr.Append("@CBA@ESTADO_CIVIL_ID=");
			dynStr.Append(ESTADO_CIVIL_ID);
			dynStr.Append("@CBA@PERSONA_ID_CONYUGE=");
			dynStr.Append(IsPERSONA_ID_CONYUGENull ? (object)"<NULL>" : PERSONA_ID_CONYUGE);
			dynStr.Append("@CBA@NUMERO_HIJOS=");
			dynStr.Append(IsNUMERO_HIJOSNull ? (object)"<NULL>" : NUMERO_HIJOS);
			dynStr.Append("@CBA@TIPO_EMPLEO=");
			dynStr.Append(TIPO_EMPLEO);
			dynStr.Append("@CBA@SEPARACION_BIENES=");
			dynStr.Append(SEPARACION_BIENES);
			dynStr.Append("@CBA@PORC_DESCUENTO_AUTOMATICO=");
			dynStr.Append(PORC_DESCUENTO_AUTOMATICO);
			dynStr.Append("@CBA@PERSONA_CALIFICACION_ID=");
			dynStr.Append(IsPERSONA_CALIFICACION_IDNull ? (object)"<NULL>" : PERSONA_CALIFICACION_ID);
			dynStr.Append("@CBA@ZONA_COBRANZA_ID=");
			dynStr.Append(IsZONA_COBRANZA_IDNull ? (object)"<NULL>" : ZONA_COBRANZA_ID);
			dynStr.Append("@CBA@TIPO_CLIENTE_ID=");
			dynStr.Append(IsTIPO_CLIENTE_IDNull ? (object)"<NULL>" : TIPO_CLIENTE_ID);
			dynStr.Append("@CBA@ESTADO_MOROSIDAD_ID=");
			dynStr.Append(IsESTADO_MOROSIDAD_IDNull ? (object)"<NULL>" : ESTADO_MOROSIDAD_ID);
			dynStr.Append("@CBA@MODIFICABLE=");
			dynStr.Append(MODIFICABLE);
			dynStr.Append("@CBA@ES_CONTRIBUYENTE=");
			dynStr.Append(ES_CONTRIBUYENTE);
			dynStr.Append("@CBA@NRO_TARJETA_RED_PAGO=");
			dynStr.Append(IsNRO_TARJETA_RED_PAGONull ? (object)"<NULL>" : NRO_TARJETA_RED_PAGO);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(IsCENTRO_COSTO_IDNull ? (object)"<NULL>" : CENTRO_COSTO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@CODIGO_EXTERNO=");
			dynStr.Append(CODIGO_EXTERNO);
			dynStr.Append("@CBA@FECHA_ULTIMA_VISITA=");
			dynStr.Append(IsFECHA_ULTIMA_VISITANull ? (object)"<NULL>" : FECHA_ULTIMA_VISITA);
			dynStr.Append("@CBA@FECHA_ULTIMA_ACTUALIZAC_DATOS=");
			dynStr.Append(FECHA_ULTIMA_ACTUALIZAC_DATOS);
			dynStr.Append("@CBA@PERSONA_PADRE_ID=");
			dynStr.Append(IsPERSONA_PADRE_IDNull ? (object)"<NULL>" : PERSONA_PADRE_ID);
			dynStr.Append("@CBA@LISTA_PRECIOS_ID=");
			dynStr.Append(IsLISTA_PRECIOS_IDNull ? (object)"<NULL>" : LISTA_PRECIOS_ID);
			return dynStr.ToString();
		}
	} // End of PERSONASRow_Base class
} // End of namespace
