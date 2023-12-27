// <fileinfo name="ITEMS_SALIDA_DEP_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>ITEMS_SALIDA_DEP_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_SALIDA_DEP_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _items_ingresos_detalles_id;
		private bool _items_ingresos_detalles_idNull = true;
		private string _conocimiento;
		private string _mic_dta;
		private System.DateTime _fecha_emision;
		private bool _fecha_emisionNull = true;
		private string _nro_comprobante;
		private decimal _factura_persona_id;
		private bool _factura_persona_idNull = true;
		private decimal _factura_caso;
		private bool _factura_casoNull = true;
		private System.DateTime _factura_fecha;
		private bool _factura_fechaNull = true;
		private string _factura_numero;
		private decimal _consignatario_persona_id;
		private bool _consignatario_persona_idNull = true;
		private string _consignatario_codigo;
		private string _consiganatario_nombre;
		private string _consiganatario_documento;
		private string _despachante;
		private string _observaciones;
		private System.DateTime _vencimiento;
		private bool _vencimientoNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _mercaderia;
		private string _tipo_bulto;
		private string _despacho;
		private string _generacion_confirmada;
		private string _salida_confirmada;
		private string _es_extension;
		private decimal _item_salida_deposito_origen_id;
		private bool _item_salida_deposito_origen_idNull = true;
		private string _boleta_salida_origen;
		private decimal _semana;
		private bool _semanaNull = true;
		private decimal _razon_textos_predefinidos_id;
		private bool _razon_textos_predefinidos_idNull = true;
		private string _razon_texto_predefinido_nombre;
		private decimal _despachante_persona_id;
		private bool _despachante_persona_idNull = true;
		private string _impreso;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public ITEMS_SALIDA_DEP_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ITEMS_SALIDA_DEP_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsITEMS_INGRESOS_DETALLES_IDNull != original.IsITEMS_INGRESOS_DETALLES_IDNull) return true;
			if (!this.IsITEMS_INGRESOS_DETALLES_IDNull && !original.IsITEMS_INGRESOS_DETALLES_IDNull)
				if (this.ITEMS_INGRESOS_DETALLES_ID != original.ITEMS_INGRESOS_DETALLES_ID) return true;
			if (this.CONOCIMIENTO != original.CONOCIMIENTO) return true;
			if (this.MIC_DTA != original.MIC_DTA) return true;
			if (this.IsFECHA_EMISIONNull != original.IsFECHA_EMISIONNull) return true;
			if (!this.IsFECHA_EMISIONNull && !original.IsFECHA_EMISIONNull)
				if (this.FECHA_EMISION != original.FECHA_EMISION) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFACTURA_PERSONA_IDNull != original.IsFACTURA_PERSONA_IDNull) return true;
			if (!this.IsFACTURA_PERSONA_IDNull && !original.IsFACTURA_PERSONA_IDNull)
				if (this.FACTURA_PERSONA_ID != original.FACTURA_PERSONA_ID) return true;
			if (this.IsFACTURA_CASONull != original.IsFACTURA_CASONull) return true;
			if (!this.IsFACTURA_CASONull && !original.IsFACTURA_CASONull)
				if (this.FACTURA_CASO != original.FACTURA_CASO) return true;
			if (this.IsFACTURA_FECHANull != original.IsFACTURA_FECHANull) return true;
			if (!this.IsFACTURA_FECHANull && !original.IsFACTURA_FECHANull)
				if (this.FACTURA_FECHA != original.FACTURA_FECHA) return true;
			if (this.FACTURA_NUMERO != original.FACTURA_NUMERO) return true;
			if (this.IsCONSIGNATARIO_PERSONA_IDNull != original.IsCONSIGNATARIO_PERSONA_IDNull) return true;
			if (!this.IsCONSIGNATARIO_PERSONA_IDNull && !original.IsCONSIGNATARIO_PERSONA_IDNull)
				if (this.CONSIGNATARIO_PERSONA_ID != original.CONSIGNATARIO_PERSONA_ID) return true;
			if (this.CONSIGNATARIO_CODIGO != original.CONSIGNATARIO_CODIGO) return true;
			if (this.CONSIGANATARIO_NOMBRE != original.CONSIGANATARIO_NOMBRE) return true;
			if (this.CONSIGANATARIO_DOCUMENTO != original.CONSIGANATARIO_DOCUMENTO) return true;
			if (this.DESPACHANTE != original.DESPACHANTE) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsVENCIMIENTONull != original.IsVENCIMIENTONull) return true;
			if (!this.IsVENCIMIENTONull && !original.IsVENCIMIENTONull)
				if (this.VENCIMIENTO != original.VENCIMIENTO) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.MERCADERIA != original.MERCADERIA) return true;
			if (this.TIPO_BULTO != original.TIPO_BULTO) return true;
			if (this.DESPACHO != original.DESPACHO) return true;
			if (this.GENERACION_CONFIRMADA != original.GENERACION_CONFIRMADA) return true;
			if (this.SALIDA_CONFIRMADA != original.SALIDA_CONFIRMADA) return true;
			if (this.ES_EXTENSION != original.ES_EXTENSION) return true;
			if (this.IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull != original.IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull) return true;
			if (!this.IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull && !original.IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull)
				if (this.ITEM_SALIDA_DEPOSITO_ORIGEN_ID != original.ITEM_SALIDA_DEPOSITO_ORIGEN_ID) return true;
			if (this.BOLETA_SALIDA_ORIGEN != original.BOLETA_SALIDA_ORIGEN) return true;
			if (this.IsSEMANANull != original.IsSEMANANull) return true;
			if (!this.IsSEMANANull && !original.IsSEMANANull)
				if (this.SEMANA != original.SEMANA) return true;
			if (this.IsRAZON_TEXTOS_PREDEFINIDOS_IDNull != original.IsRAZON_TEXTOS_PREDEFINIDOS_IDNull) return true;
			if (!this.IsRAZON_TEXTOS_PREDEFINIDOS_IDNull && !original.IsRAZON_TEXTOS_PREDEFINIDOS_IDNull)
				if (this.RAZON_TEXTOS_PREDEFINIDOS_ID != original.RAZON_TEXTOS_PREDEFINIDOS_ID) return true;
			if (this.RAZON_TEXTO_PREDEFINIDO_NOMBRE != original.RAZON_TEXTO_PREDEFINIDO_NOMBRE) return true;
			if (this.IsDESPACHANTE_PERSONA_IDNull != original.IsDESPACHANTE_PERSONA_IDNull) return true;
			if (!this.IsDESPACHANTE_PERSONA_IDNull && !original.IsDESPACHANTE_PERSONA_IDNull)
				if (this.DESPACHANTE_PERSONA_ID != original.DESPACHANTE_PERSONA_ID) return true;
			if (this.IMPRESO != original.IMPRESO) return true;
			
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
		/// Gets or sets the <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</value>
		public decimal ITEMS_INGRESOS_DETALLES_ID
		{
			get
			{
				if(IsITEMS_INGRESOS_DETALLES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _items_ingresos_detalles_id;
			}
			set
			{
				_items_ingresos_detalles_idNull = false;
				_items_ingresos_detalles_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEMS_INGRESOS_DETALLES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMS_INGRESOS_DETALLES_IDNull
		{
			get { return _items_ingresos_detalles_idNull; }
			set { _items_ingresos_detalles_idNull = value; }
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
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_PERSONA_ID</c> column value.</value>
		public decimal FACTURA_PERSONA_ID
		{
			get
			{
				if(IsFACTURA_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_persona_id;
			}
			set
			{
				_factura_persona_idNull = false;
				_factura_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_PERSONA_IDNull
		{
			get { return _factura_persona_idNull; }
			set { _factura_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CASO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CASO</c> column value.</value>
		public decimal FACTURA_CASO
		{
			get
			{
				if(IsFACTURA_CASONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_caso;
			}
			set
			{
				_factura_casoNull = false;
				_factura_caso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CASO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CASONull
		{
			get { return _factura_casoNull; }
			set { _factura_casoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_FECHA</c> column value.</value>
		public System.DateTime FACTURA_FECHA
		{
			get
			{
				if(IsFACTURA_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_fecha;
			}
			set
			{
				_factura_fechaNull = false;
				_factura_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_FECHANull
		{
			get { return _factura_fechaNull; }
			set { _factura_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_NUMERO</c> column value.</value>
		public string FACTURA_NUMERO
		{
			get { return _factura_numero; }
			set { _factura_numero = value; }
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
		/// Gets or sets the <c>CONSIGANATARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGANATARIO_NOMBRE</c> column value.</value>
		public string CONSIGANATARIO_NOMBRE
		{
			get { return _consiganatario_nombre; }
			set { _consiganatario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONSIGANATARIO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONSIGANATARIO_DOCUMENTO</c> column value.</value>
		public string CONSIGANATARIO_DOCUMENTO
		{
			get { return _consiganatario_documento; }
			set { _consiganatario_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHANTE</c> column value.</value>
		public string DESPACHANTE
		{
			get { return _despachante; }
			set { _despachante = value; }
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
		/// Gets or sets the <c>VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENCIMIENTO</c> column value.</value>
		public System.DateTime VENCIMIENTO
		{
			get
			{
				if(IsVENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vencimiento;
			}
			set
			{
				_vencimientoNull = false;
				_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENCIMIENTONull
		{
			get { return _vencimientoNull; }
			set { _vencimientoNull = value; }
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
		/// Gets or sets the <c>MERCADERIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERCADERIA</c> column value.</value>
		public string MERCADERIA
		{
			get { return _mercaderia; }
			set { _mercaderia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_BULTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_BULTO</c> column value.</value>
		public string TIPO_BULTO
		{
			get { return _tipo_bulto; }
			set { _tipo_bulto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO</c> column value.</value>
		public string DESPACHO
		{
			get { return _despacho; }
			set { _despacho = value; }
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
		/// Gets or sets the <c>SALIDA_CONFIRMADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SALIDA_CONFIRMADA</c> column value.</value>
		public string SALIDA_CONFIRMADA
		{
			get { return _salida_confirmada; }
			set { _salida_confirmada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_EXTENSION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_EXTENSION</c> column value.</value>
		public string ES_EXTENSION
		{
			get { return _es_extension; }
			set { _es_extension = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</value>
		public decimal ITEM_SALIDA_DEPOSITO_ORIGEN_ID
		{
			get
			{
				if(IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _item_salida_deposito_origen_id;
			}
			set
			{
				_item_salida_deposito_origen_idNull = false;
				_item_salida_deposito_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEM_SALIDA_DEPOSITO_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull
		{
			get { return _item_salida_deposito_origen_idNull; }
			set { _item_salida_deposito_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BOLETA_SALIDA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BOLETA_SALIDA_ORIGEN</c> column value.</value>
		public string BOLETA_SALIDA_ORIGEN
		{
			get { return _boleta_salida_origen; }
			set { _boleta_salida_origen = value; }
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
		/// Gets or sets the <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</value>
		public decimal RAZON_TEXTOS_PREDEFINIDOS_ID
		{
			get
			{
				if(IsRAZON_TEXTOS_PREDEFINIDOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _razon_textos_predefinidos_id;
			}
			set
			{
				_razon_textos_predefinidos_idNull = false;
				_razon_textos_predefinidos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RAZON_TEXTOS_PREDEFINIDOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRAZON_TEXTOS_PREDEFINIDOS_IDNull
		{
			get { return _razon_textos_predefinidos_idNull; }
			set { _razon_textos_predefinidos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RAZON_TEXTO_PREDEFINIDO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RAZON_TEXTO_PREDEFINIDO_NOMBRE</c> column value.</value>
		public string RAZON_TEXTO_PREDEFINIDO_NOMBRE
		{
			get { return _razon_texto_predefinido_nombre; }
			set { _razon_texto_predefinido_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHANTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHANTE_PERSONA_ID</c> column value.</value>
		public decimal DESPACHANTE_PERSONA_ID
		{
			get
			{
				if(IsDESPACHANTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _despachante_persona_id;
			}
			set
			{
				_despachante_persona_idNull = false;
				_despachante_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESPACHANTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESPACHANTE_PERSONA_IDNull
		{
			get { return _despachante_persona_idNull; }
			set { _despachante_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPRESO</c> column value.</value>
		public string IMPRESO
		{
			get { return _impreso; }
			set { _impreso = value; }
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
			dynStr.Append("@CBA@ITEMS_INGRESOS_DETALLES_ID=");
			dynStr.Append(IsITEMS_INGRESOS_DETALLES_IDNull ? (object)"<NULL>" : ITEMS_INGRESOS_DETALLES_ID);
			dynStr.Append("@CBA@CONOCIMIENTO=");
			dynStr.Append(CONOCIMIENTO);
			dynStr.Append("@CBA@MIC_DTA=");
			dynStr.Append(MIC_DTA);
			dynStr.Append("@CBA@FECHA_EMISION=");
			dynStr.Append(IsFECHA_EMISIONNull ? (object)"<NULL>" : FECHA_EMISION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FACTURA_PERSONA_ID=");
			dynStr.Append(IsFACTURA_PERSONA_IDNull ? (object)"<NULL>" : FACTURA_PERSONA_ID);
			dynStr.Append("@CBA@FACTURA_CASO=");
			dynStr.Append(IsFACTURA_CASONull ? (object)"<NULL>" : FACTURA_CASO);
			dynStr.Append("@CBA@FACTURA_FECHA=");
			dynStr.Append(IsFACTURA_FECHANull ? (object)"<NULL>" : FACTURA_FECHA);
			dynStr.Append("@CBA@FACTURA_NUMERO=");
			dynStr.Append(FACTURA_NUMERO);
			dynStr.Append("@CBA@CONSIGNATARIO_PERSONA_ID=");
			dynStr.Append(IsCONSIGNATARIO_PERSONA_IDNull ? (object)"<NULL>" : CONSIGNATARIO_PERSONA_ID);
			dynStr.Append("@CBA@CONSIGNATARIO_CODIGO=");
			dynStr.Append(CONSIGNATARIO_CODIGO);
			dynStr.Append("@CBA@CONSIGANATARIO_NOMBRE=");
			dynStr.Append(CONSIGANATARIO_NOMBRE);
			dynStr.Append("@CBA@CONSIGANATARIO_DOCUMENTO=");
			dynStr.Append(CONSIGANATARIO_DOCUMENTO);
			dynStr.Append("@CBA@DESPACHANTE=");
			dynStr.Append(DESPACHANTE);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@VENCIMIENTO=");
			dynStr.Append(IsVENCIMIENTONull ? (object)"<NULL>" : VENCIMIENTO);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@MERCADERIA=");
			dynStr.Append(MERCADERIA);
			dynStr.Append("@CBA@TIPO_BULTO=");
			dynStr.Append(TIPO_BULTO);
			dynStr.Append("@CBA@DESPACHO=");
			dynStr.Append(DESPACHO);
			dynStr.Append("@CBA@GENERACION_CONFIRMADA=");
			dynStr.Append(GENERACION_CONFIRMADA);
			dynStr.Append("@CBA@SALIDA_CONFIRMADA=");
			dynStr.Append(SALIDA_CONFIRMADA);
			dynStr.Append("@CBA@ES_EXTENSION=");
			dynStr.Append(ES_EXTENSION);
			dynStr.Append("@CBA@ITEM_SALIDA_DEPOSITO_ORIGEN_ID=");
			dynStr.Append(IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull ? (object)"<NULL>" : ITEM_SALIDA_DEPOSITO_ORIGEN_ID);
			dynStr.Append("@CBA@BOLETA_SALIDA_ORIGEN=");
			dynStr.Append(BOLETA_SALIDA_ORIGEN);
			dynStr.Append("@CBA@SEMANA=");
			dynStr.Append(IsSEMANANull ? (object)"<NULL>" : SEMANA);
			dynStr.Append("@CBA@RAZON_TEXTOS_PREDEFINIDOS_ID=");
			dynStr.Append(IsRAZON_TEXTOS_PREDEFINIDOS_IDNull ? (object)"<NULL>" : RAZON_TEXTOS_PREDEFINIDOS_ID);
			dynStr.Append("@CBA@RAZON_TEXTO_PREDEFINIDO_NOMBRE=");
			dynStr.Append(RAZON_TEXTO_PREDEFINIDO_NOMBRE);
			dynStr.Append("@CBA@DESPACHANTE_PERSONA_ID=");
			dynStr.Append(IsDESPACHANTE_PERSONA_IDNull ? (object)"<NULL>" : DESPACHANTE_PERSONA_ID);
			dynStr.Append("@CBA@IMPRESO=");
			dynStr.Append(IMPRESO);
			return dynStr.ToString();
		}
	} // End of ITEMS_SALIDA_DEP_INFO_COMPLETARow_Base class
} // End of namespace
