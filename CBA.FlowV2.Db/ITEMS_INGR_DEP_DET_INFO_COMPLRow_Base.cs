// <fileinfo name="ITEMS_INGR_DEP_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ITEMS_INGR_DEP_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGR_DEP_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _items_ingreso_deposito_id;
		private bool _items_ingreso_deposito_idNull = true;
		private decimal _items_ingreso_detalle_id;
		private string _ubicacion;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _tipo_bultos;
		private string _mercaderias;
		private decimal _peso;
		private bool _pesoNull = true;
		private decimal _largo;
		private decimal _ancho;
		private decimal _alto;
		private bool _altoNull = true;
		private decimal _total_espacio;
		private decimal _estibadores;
		private decimal _estibadores_facturados;
		private bool _estibadores_facturadosNull = true;
		private decimal _montacargas;
		private decimal _montacargas_facturados;
		private bool _montacargas_facturadosNull = true;
		private string _observaciones;
		private decimal _uso_bascula;
		private bool _uso_basculaNull = true;
		private decimal _uso_bascula_facturado;
		private bool _uso_bascula_facturadoNull = true;
		private decimal _uso_grua;
		private bool _uso_gruaNull = true;
		private decimal _uso_grua_facturado;
		private bool _uso_grua_facturadoNull = true;
		private decimal _consignatario_persona_id;
		private bool _consignatario_persona_idNull = true;
		private string _consignatario_codigo;
		private string _consignatario_nombre;
		private string _conocimiento;
		private decimal _cantidad_manifestada;
		private bool _cantidad_manifestadaNull = true;
		private string _tipo_bulto_manifestado;
		private string _mercaderia_manifestada;
		private decimal _valor_neto;
		private bool _valor_netoNull = true;
		private decimal _valor_moneda_id;
		private bool _valor_moneda_idNull = true;
		private string _moneda_simbolo;
		private string _moneda_cadena_decimales;
		private string _factura_comercial;
		private System.DateTime _fecha_ingreso;
		private bool _fecha_ingresoNull = true;
		private System.DateTime _fecha_emision;
		private bool _fecha_emisionNull = true;
		private string _generacion_confirmada;
		private string _ingreso_confirmado;
		private string _numero_comprobante;
		private string _transportadora_nombre;
		private string _fcl_lcl;
		private string _mic_dta;
		private decimal _semana;
		private bool _semanaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ITEMS_INGR_DEP_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ITEMS_INGR_DEP_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsITEMS_INGRESO_DEPOSITO_IDNull != original.IsITEMS_INGRESO_DEPOSITO_IDNull) return true;
			if (!this.IsITEMS_INGRESO_DEPOSITO_IDNull && !original.IsITEMS_INGRESO_DEPOSITO_IDNull)
				if (this.ITEMS_INGRESO_DEPOSITO_ID != original.ITEMS_INGRESO_DEPOSITO_ID) return true;
			if (this.ITEMS_INGRESO_DETALLE_ID != original.ITEMS_INGRESO_DETALLE_ID) return true;
			if (this.UBICACION != original.UBICACION) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.TIPO_BULTOS != original.TIPO_BULTOS) return true;
			if (this.MERCADERIAS != original.MERCADERIAS) return true;
			if (this.IsPESONull != original.IsPESONull) return true;
			if (!this.IsPESONull && !original.IsPESONull)
				if (this.PESO != original.PESO) return true;
			if (this.LARGO != original.LARGO) return true;
			if (this.ANCHO != original.ANCHO) return true;
			if (this.IsALTONull != original.IsALTONull) return true;
			if (!this.IsALTONull && !original.IsALTONull)
				if (this.ALTO != original.ALTO) return true;
			if (this.TOTAL_ESPACIO != original.TOTAL_ESPACIO) return true;
			if (this.ESTIBADORES != original.ESTIBADORES) return true;
			if (this.IsESTIBADORES_FACTURADOSNull != original.IsESTIBADORES_FACTURADOSNull) return true;
			if (!this.IsESTIBADORES_FACTURADOSNull && !original.IsESTIBADORES_FACTURADOSNull)
				if (this.ESTIBADORES_FACTURADOS != original.ESTIBADORES_FACTURADOS) return true;
			if (this.MONTACARGAS != original.MONTACARGAS) return true;
			if (this.IsMONTACARGAS_FACTURADOSNull != original.IsMONTACARGAS_FACTURADOSNull) return true;
			if (!this.IsMONTACARGAS_FACTURADOSNull && !original.IsMONTACARGAS_FACTURADOSNull)
				if (this.MONTACARGAS_FACTURADOS != original.MONTACARGAS_FACTURADOS) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsUSO_BASCULANull != original.IsUSO_BASCULANull) return true;
			if (!this.IsUSO_BASCULANull && !original.IsUSO_BASCULANull)
				if (this.USO_BASCULA != original.USO_BASCULA) return true;
			if (this.IsUSO_BASCULA_FACTURADONull != original.IsUSO_BASCULA_FACTURADONull) return true;
			if (!this.IsUSO_BASCULA_FACTURADONull && !original.IsUSO_BASCULA_FACTURADONull)
				if (this.USO_BASCULA_FACTURADO != original.USO_BASCULA_FACTURADO) return true;
			if (this.IsUSO_GRUANull != original.IsUSO_GRUANull) return true;
			if (!this.IsUSO_GRUANull && !original.IsUSO_GRUANull)
				if (this.USO_GRUA != original.USO_GRUA) return true;
			if (this.IsUSO_GRUA_FACTURADONull != original.IsUSO_GRUA_FACTURADONull) return true;
			if (!this.IsUSO_GRUA_FACTURADONull && !original.IsUSO_GRUA_FACTURADONull)
				if (this.USO_GRUA_FACTURADO != original.USO_GRUA_FACTURADO) return true;
			if (this.IsCONSIGNATARIO_PERSONA_IDNull != original.IsCONSIGNATARIO_PERSONA_IDNull) return true;
			if (!this.IsCONSIGNATARIO_PERSONA_IDNull && !original.IsCONSIGNATARIO_PERSONA_IDNull)
				if (this.CONSIGNATARIO_PERSONA_ID != original.CONSIGNATARIO_PERSONA_ID) return true;
			if (this.CONSIGNATARIO_CODIGO != original.CONSIGNATARIO_CODIGO) return true;
			if (this.CONSIGNATARIO_NOMBRE != original.CONSIGNATARIO_NOMBRE) return true;
			if (this.CONOCIMIENTO != original.CONOCIMIENTO) return true;
			if (this.IsCANTIDAD_MANIFESTADANull != original.IsCANTIDAD_MANIFESTADANull) return true;
			if (!this.IsCANTIDAD_MANIFESTADANull && !original.IsCANTIDAD_MANIFESTADANull)
				if (this.CANTIDAD_MANIFESTADA != original.CANTIDAD_MANIFESTADA) return true;
			if (this.TIPO_BULTO_MANIFESTADO != original.TIPO_BULTO_MANIFESTADO) return true;
			if (this.MERCADERIA_MANIFESTADA != original.MERCADERIA_MANIFESTADA) return true;
			if (this.IsVALOR_NETONull != original.IsVALOR_NETONull) return true;
			if (!this.IsVALOR_NETONull && !original.IsVALOR_NETONull)
				if (this.VALOR_NETO != original.VALOR_NETO) return true;
			if (this.IsVALOR_MONEDA_IDNull != original.IsVALOR_MONEDA_IDNull) return true;
			if (!this.IsVALOR_MONEDA_IDNull && !original.IsVALOR_MONEDA_IDNull)
				if (this.VALOR_MONEDA_ID != original.VALOR_MONEDA_ID) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.FACTURA_COMERCIAL != original.FACTURA_COMERCIAL) return true;
			if (this.IsFECHA_INGRESONull != original.IsFECHA_INGRESONull) return true;
			if (!this.IsFECHA_INGRESONull && !original.IsFECHA_INGRESONull)
				if (this.FECHA_INGRESO != original.FECHA_INGRESO) return true;
			if (this.IsFECHA_EMISIONNull != original.IsFECHA_EMISIONNull) return true;
			if (!this.IsFECHA_EMISIONNull && !original.IsFECHA_EMISIONNull)
				if (this.FECHA_EMISION != original.FECHA_EMISION) return true;
			if (this.GENERACION_CONFIRMADA != original.GENERACION_CONFIRMADA) return true;
			if (this.INGRESO_CONFIRMADO != original.INGRESO_CONFIRMADO) return true;
			if (this.NUMERO_COMPROBANTE != original.NUMERO_COMPROBANTE) return true;
			if (this.TRANSPORTADORA_NOMBRE != original.TRANSPORTADORA_NOMBRE) return true;
			if (this.FCL_LCL != original.FCL_LCL) return true;
			if (this.MIC_DTA != original.MIC_DTA) return true;
			if (this.IsSEMANANull != original.IsSEMANANull) return true;
			if (!this.IsSEMANANull && !original.IsSEMANANull)
				if (this.SEMANA != original.SEMANA) return true;
			
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
		/// Gets or sets the <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</value>
		public decimal ITEMS_INGRESO_DEPOSITO_ID
		{
			get
			{
				if(IsITEMS_INGRESO_DEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _items_ingreso_deposito_id;
			}
			set
			{
				_items_ingreso_deposito_idNull = false;
				_items_ingreso_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEMS_INGRESO_DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMS_INGRESO_DEPOSITO_IDNull
		{
			get { return _items_ingreso_deposito_idNull; }
			set { _items_ingreso_deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ITEMS_INGRESO_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESO_DETALLE_ID</c> column value.</value>
		public decimal ITEMS_INGRESO_DETALLE_ID
		{
			get { return _items_ingreso_detalle_id; }
			set { _items_ingreso_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UBICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UBICACION</c> column value.</value>
		public string UBICACION
		{
			get { return _ubicacion; }
			set { _ubicacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_BULTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_BULTOS</c> column value.</value>
		public string TIPO_BULTOS
		{
			get { return _tipo_bultos; }
			set { _tipo_bultos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIAS</c> column value.</value>
		public string MERCADERIAS
		{
			get { return _mercaderias; }
			set { _mercaderias = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO</c> column value.</value>
		public decimal PESO
		{
			get
			{
				if(IsPESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso;
			}
			set
			{
				_pesoNull = false;
				_peso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESONull
		{
			get { return _pesoNull; }
			set { _pesoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LARGO</c> column value.
		/// </summary>
		/// <value>The <c>LARGO</c> column value.</value>
		public decimal LARGO
		{
			get { return _largo; }
			set { _largo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANCHO</c> column value.
		/// </summary>
		/// <value>The <c>ANCHO</c> column value.</value>
		public decimal ANCHO
		{
			get { return _ancho; }
			set { _ancho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ALTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ALTO</c> column value.</value>
		public decimal ALTO
		{
			get
			{
				if(IsALTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _alto;
			}
			set
			{
				_altoNull = false;
				_alto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ALTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsALTONull
		{
			get { return _altoNull; }
			set { _altoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_ESPACIO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_ESPACIO</c> column value.</value>
		public decimal TOTAL_ESPACIO
		{
			get { return _total_espacio; }
			set { _total_espacio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTIBADORES</c> column value.
		/// </summary>
		/// <value>The <c>ESTIBADORES</c> column value.</value>
		public decimal ESTIBADORES
		{
			get { return _estibadores; }
			set { _estibadores = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTIBADORES_FACTURADOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTIBADORES_FACTURADOS</c> column value.</value>
		public decimal ESTIBADORES_FACTURADOS
		{
			get
			{
				if(IsESTIBADORES_FACTURADOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _estibadores_facturados;
			}
			set
			{
				_estibadores_facturadosNull = false;
				_estibadores_facturados = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ESTIBADORES_FACTURADOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsESTIBADORES_FACTURADOSNull
		{
			get { return _estibadores_facturadosNull; }
			set { _estibadores_facturadosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTACARGAS</c> column value.
		/// </summary>
		/// <value>The <c>MONTACARGAS</c> column value.</value>
		public decimal MONTACARGAS
		{
			get { return _montacargas; }
			set { _montacargas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTACARGAS_FACTURADOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTACARGAS_FACTURADOS</c> column value.</value>
		public decimal MONTACARGAS_FACTURADOS
		{
			get
			{
				if(IsMONTACARGAS_FACTURADOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _montacargas_facturados;
			}
			set
			{
				_montacargas_facturadosNull = false;
				_montacargas_facturados = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTACARGAS_FACTURADOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTACARGAS_FACTURADOSNull
		{
			get { return _montacargas_facturadosNull; }
			set { _montacargas_facturadosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACIONES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACIONES</c> column value.</value>
		public string OBSERVACIONES
		{
			get { return _observaciones; }
			set { _observaciones = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USO_BASCULA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USO_BASCULA</c> column value.</value>
		public decimal USO_BASCULA
		{
			get
			{
				if(IsUSO_BASCULANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _uso_bascula;
			}
			set
			{
				_uso_basculaNull = false;
				_uso_bascula = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USO_BASCULA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSO_BASCULANull
		{
			get { return _uso_basculaNull; }
			set { _uso_basculaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USO_BASCULA_FACTURADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USO_BASCULA_FACTURADO</c> column value.</value>
		public decimal USO_BASCULA_FACTURADO
		{
			get
			{
				if(IsUSO_BASCULA_FACTURADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _uso_bascula_facturado;
			}
			set
			{
				_uso_bascula_facturadoNull = false;
				_uso_bascula_facturado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USO_BASCULA_FACTURADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSO_BASCULA_FACTURADONull
		{
			get { return _uso_bascula_facturadoNull; }
			set { _uso_bascula_facturadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USO_GRUA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USO_GRUA</c> column value.</value>
		public decimal USO_GRUA
		{
			get
			{
				if(IsUSO_GRUANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _uso_grua;
			}
			set
			{
				_uso_gruaNull = false;
				_uso_grua = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USO_GRUA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSO_GRUANull
		{
			get { return _uso_gruaNull; }
			set { _uso_gruaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USO_GRUA_FACTURADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USO_GRUA_FACTURADO</c> column value.</value>
		public decimal USO_GRUA_FACTURADO
		{
			get
			{
				if(IsUSO_GRUA_FACTURADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _uso_grua_facturado;
			}
			set
			{
				_uso_grua_facturadoNull = false;
				_uso_grua_facturado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USO_GRUA_FACTURADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSO_GRUA_FACTURADONull
		{
			get { return _uso_grua_facturadoNull; }
			set { _uso_grua_facturadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIGNATARIO_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</value>
		public decimal CONSIGNATARIO_PERSONA_ID
		{
			get
			{
				if(IsCONSIGNATARIO_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _consignatario_persona_id;
			}
			set
			{
				_consignatario_persona_idNull = false;
				_consignatario_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONSIGNATARIO_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONSIGNATARIO_PERSONA_IDNull
		{
			get { return _consignatario_persona_idNull; }
			set { _consignatario_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIGNATARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGNATARIO_CODIGO</c> column value.</value>
		public string CONSIGNATARIO_CODIGO
		{
			get { return _consignatario_codigo; }
			set { _consignatario_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIGNATARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGNATARIO_NOMBRE</c> column value.</value>
		public string CONSIGNATARIO_NOMBRE
		{
			get { return _consignatario_nombre; }
			set { _consignatario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONOCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO</c> column value.</value>
		public string CONOCIMIENTO
		{
			get { return _conocimiento; }
			set { _conocimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MANIFESTADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MANIFESTADA</c> column value.</value>
		public decimal CANTIDAD_MANIFESTADA
		{
			get
			{
				if(IsCANTIDAD_MANIFESTADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_manifestada;
			}
			set
			{
				_cantidad_manifestadaNull = false;
				_cantidad_manifestada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MANIFESTADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MANIFESTADANull
		{
			get { return _cantidad_manifestadaNull; }
			set { _cantidad_manifestadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_BULTO_MANIFESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_BULTO_MANIFESTADO</c> column value.</value>
		public string TIPO_BULTO_MANIFESTADO
		{
			get { return _tipo_bulto_manifestado; }
			set { _tipo_bulto_manifestado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERCADERIA_MANIFESTADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIA_MANIFESTADA</c> column value.</value>
		public string MERCADERIA_MANIFESTADA
		{
			get { return _mercaderia_manifestada; }
			set { _mercaderia_manifestada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_NETO</c> column value.</value>
		public decimal VALOR_NETO
		{
			get
			{
				if(IsVALOR_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_neto;
			}
			set
			{
				_valor_netoNull = false;
				_valor_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_NETONull
		{
			get { return _valor_netoNull; }
			set { _valor_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_MONEDA_ID</c> column value.</value>
		public decimal VALOR_MONEDA_ID
		{
			get
			{
				if(IsVALOR_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_moneda_id;
			}
			set
			{
				_valor_moneda_idNull = false;
				_valor_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_MONEDA_IDNull
		{
			get { return _valor_moneda_idNull; }
			set { _valor_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
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
		/// Gets or sets the <c>FACTURA_COMERCIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_COMERCIAL</c> column value.</value>
		public string FACTURA_COMERCIAL
		{
			get { return _factura_comercial; }
			set { _factura_comercial = value; }
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
		/// Gets or sets the <c>FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_EMISION</c> column value.</value>
		public System.DateTime FECHA_EMISION
		{
			get
			{
				if(IsFECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_emision;
			}
			set
			{
				_fecha_emisionNull = false;
				_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_EMISIONNull
		{
			get { return _fecha_emisionNull; }
			set { _fecha_emisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERACION_CONFIRMADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GENERACION_CONFIRMADA</c> column value.</value>
		public string GENERACION_CONFIRMADA
		{
			get { return _generacion_confirmada; }
			set { _generacion_confirmada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_CONFIRMADO</c> column value.</value>
		public string INGRESO_CONFIRMADO
		{
			get { return _ingreso_confirmado; }
			set { _ingreso_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_COMPROBANTE</c> column value.</value>
		public string NUMERO_COMPROBANTE
		{
			get { return _numero_comprobante; }
			set { _numero_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSPORTADORA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSPORTADORA_NOMBRE</c> column value.</value>
		public string TRANSPORTADORA_NOMBRE
		{
			get { return _transportadora_nombre; }
			set { _transportadora_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FCL_LCL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FCL_LCL</c> column value.</value>
		public string FCL_LCL
		{
			get { return _fcl_lcl; }
			set { _fcl_lcl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MIC_DTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MIC_DTA</c> column value.</value>
		public string MIC_DTA
		{
			get { return _mic_dta; }
			set { _mic_dta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SEMANA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SEMANA</c> column value.</value>
		public decimal SEMANA
		{
			get
			{
				if(IsSEMANANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _semana;
			}
			set
			{
				_semanaNull = false;
				_semana = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SEMANA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSEMANANull
		{
			get { return _semanaNull; }
			set { _semanaNull = value; }
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
			dynStr.Append("@CBA@ITEMS_INGRESO_DEPOSITO_ID=");
			dynStr.Append(IsITEMS_INGRESO_DEPOSITO_IDNull ? (object)"<NULL>" : ITEMS_INGRESO_DEPOSITO_ID);
			dynStr.Append("@CBA@ITEMS_INGRESO_DETALLE_ID=");
			dynStr.Append(ITEMS_INGRESO_DETALLE_ID);
			dynStr.Append("@CBA@UBICACION=");
			dynStr.Append(UBICACION);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@TIPO_BULTOS=");
			dynStr.Append(TIPO_BULTOS);
			dynStr.Append("@CBA@MERCADERIAS=");
			dynStr.Append(MERCADERIAS);
			dynStr.Append("@CBA@PESO=");
			dynStr.Append(IsPESONull ? (object)"<NULL>" : PESO);
			dynStr.Append("@CBA@LARGO=");
			dynStr.Append(LARGO);
			dynStr.Append("@CBA@ANCHO=");
			dynStr.Append(ANCHO);
			dynStr.Append("@CBA@ALTO=");
			dynStr.Append(IsALTONull ? (object)"<NULL>" : ALTO);
			dynStr.Append("@CBA@TOTAL_ESPACIO=");
			dynStr.Append(TOTAL_ESPACIO);
			dynStr.Append("@CBA@ESTIBADORES=");
			dynStr.Append(ESTIBADORES);
			dynStr.Append("@CBA@ESTIBADORES_FACTURADOS=");
			dynStr.Append(IsESTIBADORES_FACTURADOSNull ? (object)"<NULL>" : ESTIBADORES_FACTURADOS);
			dynStr.Append("@CBA@MONTACARGAS=");
			dynStr.Append(MONTACARGAS);
			dynStr.Append("@CBA@MONTACARGAS_FACTURADOS=");
			dynStr.Append(IsMONTACARGAS_FACTURADOSNull ? (object)"<NULL>" : MONTACARGAS_FACTURADOS);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@USO_BASCULA=");
			dynStr.Append(IsUSO_BASCULANull ? (object)"<NULL>" : USO_BASCULA);
			dynStr.Append("@CBA@USO_BASCULA_FACTURADO=");
			dynStr.Append(IsUSO_BASCULA_FACTURADONull ? (object)"<NULL>" : USO_BASCULA_FACTURADO);
			dynStr.Append("@CBA@USO_GRUA=");
			dynStr.Append(IsUSO_GRUANull ? (object)"<NULL>" : USO_GRUA);
			dynStr.Append("@CBA@USO_GRUA_FACTURADO=");
			dynStr.Append(IsUSO_GRUA_FACTURADONull ? (object)"<NULL>" : USO_GRUA_FACTURADO);
			dynStr.Append("@CBA@CONSIGNATARIO_PERSONA_ID=");
			dynStr.Append(IsCONSIGNATARIO_PERSONA_IDNull ? (object)"<NULL>" : CONSIGNATARIO_PERSONA_ID);
			dynStr.Append("@CBA@CONSIGNATARIO_CODIGO=");
			dynStr.Append(CONSIGNATARIO_CODIGO);
			dynStr.Append("@CBA@CONSIGNATARIO_NOMBRE=");
			dynStr.Append(CONSIGNATARIO_NOMBRE);
			dynStr.Append("@CBA@CONOCIMIENTO=");
			dynStr.Append(CONOCIMIENTO);
			dynStr.Append("@CBA@CANTIDAD_MANIFESTADA=");
			dynStr.Append(IsCANTIDAD_MANIFESTADANull ? (object)"<NULL>" : CANTIDAD_MANIFESTADA);
			dynStr.Append("@CBA@TIPO_BULTO_MANIFESTADO=");
			dynStr.Append(TIPO_BULTO_MANIFESTADO);
			dynStr.Append("@CBA@MERCADERIA_MANIFESTADA=");
			dynStr.Append(MERCADERIA_MANIFESTADA);
			dynStr.Append("@CBA@VALOR_NETO=");
			dynStr.Append(IsVALOR_NETONull ? (object)"<NULL>" : VALOR_NETO);
			dynStr.Append("@CBA@VALOR_MONEDA_ID=");
			dynStr.Append(IsVALOR_MONEDA_IDNull ? (object)"<NULL>" : VALOR_MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@FACTURA_COMERCIAL=");
			dynStr.Append(FACTURA_COMERCIAL);
			dynStr.Append("@CBA@FECHA_INGRESO=");
			dynStr.Append(IsFECHA_INGRESONull ? (object)"<NULL>" : FECHA_INGRESO);
			dynStr.Append("@CBA@FECHA_EMISION=");
			dynStr.Append(IsFECHA_EMISIONNull ? (object)"<NULL>" : FECHA_EMISION);
			dynStr.Append("@CBA@GENERACION_CONFIRMADA=");
			dynStr.Append(GENERACION_CONFIRMADA);
			dynStr.Append("@CBA@INGRESO_CONFIRMADO=");
			dynStr.Append(INGRESO_CONFIRMADO);
			dynStr.Append("@CBA@NUMERO_COMPROBANTE=");
			dynStr.Append(NUMERO_COMPROBANTE);
			dynStr.Append("@CBA@TRANSPORTADORA_NOMBRE=");
			dynStr.Append(TRANSPORTADORA_NOMBRE);
			dynStr.Append("@CBA@FCL_LCL=");
			dynStr.Append(FCL_LCL);
			dynStr.Append("@CBA@MIC_DTA=");
			dynStr.Append(MIC_DTA);
			dynStr.Append("@CBA@SEMANA=");
			dynStr.Append(IsSEMANANull ? (object)"<NULL>" : SEMANA);
			return dynStr.ToString();
		}
	} // End of ITEMS_INGR_DEP_DET_INFO_COMPLRow_Base class
} // End of namespace
