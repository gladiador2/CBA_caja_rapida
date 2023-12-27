// <fileinfo name="ITEMS_SAL_DEP_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ITEMS_SAL_DEP_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_SAL_DEP_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _item_salida_deposito_id;
		private bool _item_salida_deposito_idNull = true;
		private decimal _items_ingresos_detalles_id;
		private bool _items_ingresos_detalles_idNull = true;
		private string _conocimiento;
		private string _consiganatario_nombre;
		private string _numero_salida;
		private System.DateTime _fecha_entrada_puerto;
		private bool _fecha_entrada_puertoNull = true;
		private string _chapa_camion;
		private string _chapa_carreta;
		private string _nombre_encargado;
		private string _status;
		private decimal _transportadora_persona_id;
		private bool _transportadora_persona_idNull = true;
		private string _transportadora_nombre;
		private decimal _tipo_camion_id;
		private bool _tipo_camion_idNull = true;
		private string _tipo_vehiculo_nombre;
		private string _chofer_nombre;
		private string _chofer_documento;
		private decimal _tara_camion;
		private bool _tara_camionNull = true;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private string _contenedor_numero;
		private string _contendor_tipo;
		private decimal _tara_contenedor;
		private bool _tara_contenedorNull = true;
		private decimal _peso_bruto;
		private bool _peso_brutoNull = true;
		private decimal _peso_neto;
		private bool _peso_netoNull = true;
		private string _observaciones;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _tipo_bulto_id;
		private string _mercaderia;
		private System.DateTime _fecha_salida_puerto;
		private bool _fecha_salida_puertoNull = true;
		private string _confirmado;
		private string _nro_comprobante;
		private System.DateTime _fecha_confirmacion;
		private bool _fecha_confirmacionNull = true;
		private string _precinto_1;
		private string _precinto_2;
		private string _precinto_3;
		private string _precinto_4;
		private string _precinto_5;
		private string _precinto_ventilete;
		private string _tipo_retiro;
		private decimal _semana;
		private bool _semanaNull = true;
		private System.DateTime _fecha_entrada_deposito;
		private bool _fecha_entrada_depositoNull = true;
		private System.DateTime _fecha_salida_deposito;
		private bool _fecha_salida_depositoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ITEMS_SAL_DEP_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ITEMS_SAL_DEP_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsITEM_SALIDA_DEPOSITO_IDNull != original.IsITEM_SALIDA_DEPOSITO_IDNull) return true;
			if (!this.IsITEM_SALIDA_DEPOSITO_IDNull && !original.IsITEM_SALIDA_DEPOSITO_IDNull)
				if (this.ITEM_SALIDA_DEPOSITO_ID != original.ITEM_SALIDA_DEPOSITO_ID) return true;
			if (this.IsITEMS_INGRESOS_DETALLES_IDNull != original.IsITEMS_INGRESOS_DETALLES_IDNull) return true;
			if (!this.IsITEMS_INGRESOS_DETALLES_IDNull && !original.IsITEMS_INGRESOS_DETALLES_IDNull)
				if (this.ITEMS_INGRESOS_DETALLES_ID != original.ITEMS_INGRESOS_DETALLES_ID) return true;
			if (this.CONOCIMIENTO != original.CONOCIMIENTO) return true;
			if (this.CONSIGANATARIO_NOMBRE != original.CONSIGANATARIO_NOMBRE) return true;
			if (this.NUMERO_SALIDA != original.NUMERO_SALIDA) return true;
			if (this.IsFECHA_ENTRADA_PUERTONull != original.IsFECHA_ENTRADA_PUERTONull) return true;
			if (!this.IsFECHA_ENTRADA_PUERTONull && !original.IsFECHA_ENTRADA_PUERTONull)
				if (this.FECHA_ENTRADA_PUERTO != original.FECHA_ENTRADA_PUERTO) return true;
			if (this.CHAPA_CAMION != original.CHAPA_CAMION) return true;
			if (this.CHAPA_CARRETA != original.CHAPA_CARRETA) return true;
			if (this.NOMBRE_ENCARGADO != original.NOMBRE_ENCARGADO) return true;
			if (this.STATUS != original.STATUS) return true;
			if (this.IsTRANSPORTADORA_PERSONA_IDNull != original.IsTRANSPORTADORA_PERSONA_IDNull) return true;
			if (!this.IsTRANSPORTADORA_PERSONA_IDNull && !original.IsTRANSPORTADORA_PERSONA_IDNull)
				if (this.TRANSPORTADORA_PERSONA_ID != original.TRANSPORTADORA_PERSONA_ID) return true;
			if (this.TRANSPORTADORA_NOMBRE != original.TRANSPORTADORA_NOMBRE) return true;
			if (this.IsTIPO_CAMION_IDNull != original.IsTIPO_CAMION_IDNull) return true;
			if (!this.IsTIPO_CAMION_IDNull && !original.IsTIPO_CAMION_IDNull)
				if (this.TIPO_CAMION_ID != original.TIPO_CAMION_ID) return true;
			if (this.TIPO_VEHICULO_NOMBRE != original.TIPO_VEHICULO_NOMBRE) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.CHOFER_DOCUMENTO != original.CHOFER_DOCUMENTO) return true;
			if (this.IsTARA_CAMIONNull != original.IsTARA_CAMIONNull) return true;
			if (!this.IsTARA_CAMIONNull && !original.IsTARA_CAMIONNull)
				if (this.TARA_CAMION != original.TARA_CAMION) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.CONTENDOR_TIPO != original.CONTENDOR_TIPO) return true;
			if (this.IsTARA_CONTENEDORNull != original.IsTARA_CONTENEDORNull) return true;
			if (!this.IsTARA_CONTENEDORNull && !original.IsTARA_CONTENEDORNull)
				if (this.TARA_CONTENEDOR != original.TARA_CONTENEDOR) return true;
			if (this.IsPESO_BRUTONull != original.IsPESO_BRUTONull) return true;
			if (!this.IsPESO_BRUTONull && !original.IsPESO_BRUTONull)
				if (this.PESO_BRUTO != original.PESO_BRUTO) return true;
			if (this.IsPESO_NETONull != original.IsPESO_NETONull) return true;
			if (!this.IsPESO_NETONull && !original.IsPESO_NETONull)
				if (this.PESO_NETO != original.PESO_NETO) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.TIPO_BULTO_ID != original.TIPO_BULTO_ID) return true;
			if (this.MERCADERIA != original.MERCADERIA) return true;
			if (this.IsFECHA_SALIDA_PUERTONull != original.IsFECHA_SALIDA_PUERTONull) return true;
			if (!this.IsFECHA_SALIDA_PUERTONull && !original.IsFECHA_SALIDA_PUERTONull)
				if (this.FECHA_SALIDA_PUERTO != original.FECHA_SALIDA_PUERTO) return true;
			if (this.CONFIRMADO != original.CONFIRMADO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHA_CONFIRMACIONNull != original.IsFECHA_CONFIRMACIONNull) return true;
			if (!this.IsFECHA_CONFIRMACIONNull && !original.IsFECHA_CONFIRMACIONNull)
				if (this.FECHA_CONFIRMACION != original.FECHA_CONFIRMACION) return true;
			if (this.PRECINTO_1 != original.PRECINTO_1) return true;
			if (this.PRECINTO_2 != original.PRECINTO_2) return true;
			if (this.PRECINTO_3 != original.PRECINTO_3) return true;
			if (this.PRECINTO_4 != original.PRECINTO_4) return true;
			if (this.PRECINTO_5 != original.PRECINTO_5) return true;
			if (this.PRECINTO_VENTILETE != original.PRECINTO_VENTILETE) return true;
			if (this.TIPO_RETIRO != original.TIPO_RETIRO) return true;
			if (this.IsSEMANANull != original.IsSEMANANull) return true;
			if (!this.IsSEMANANull && !original.IsSEMANANull)
				if (this.SEMANA != original.SEMANA) return true;
			if (this.IsFECHA_ENTRADA_DEPOSITONull != original.IsFECHA_ENTRADA_DEPOSITONull) return true;
			if (!this.IsFECHA_ENTRADA_DEPOSITONull && !original.IsFECHA_ENTRADA_DEPOSITONull)
				if (this.FECHA_ENTRADA_DEPOSITO != original.FECHA_ENTRADA_DEPOSITO) return true;
			if (this.IsFECHA_SALIDA_DEPOSITONull != original.IsFECHA_SALIDA_DEPOSITONull) return true;
			if (!this.IsFECHA_SALIDA_DEPOSITONull && !original.IsFECHA_SALIDA_DEPOSITONull)
				if (this.FECHA_SALIDA_DEPOSITO != original.FECHA_SALIDA_DEPOSITO) return true;
			
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
		/// Gets or sets the <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</value>
		public decimal ITEM_SALIDA_DEPOSITO_ID
		{
			get
			{
				if(IsITEM_SALIDA_DEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _item_salida_deposito_id;
			}
			set
			{
				_item_salida_deposito_idNull = false;
				_item_salida_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEM_SALIDA_DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEM_SALIDA_DEPOSITO_IDNull
		{
			get { return _item_salida_deposito_idNull; }
			set { _item_salida_deposito_idNull = value; }
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
		/// Gets or sets the <c>NUMERO_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_SALIDA</c> column value.</value>
		public string NUMERO_SALIDA
		{
			get { return _numero_salida; }
			set { _numero_salida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENTRADA_PUERTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ENTRADA_PUERTO</c> column value.</value>
		public System.DateTime FECHA_ENTRADA_PUERTO
		{
			get
			{
				if(IsFECHA_ENTRADA_PUERTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_entrada_puerto;
			}
			set
			{
				_fecha_entrada_puertoNull = false;
				_fecha_entrada_puerto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ENTRADA_PUERTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ENTRADA_PUERTONull
		{
			get { return _fecha_entrada_puertoNull; }
			set { _fecha_entrada_puertoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA_CAMION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA_CAMION</c> column value.</value>
		public string CHAPA_CAMION
		{
			get { return _chapa_camion; }
			set { _chapa_camion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA_CARRETA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA_CARRETA</c> column value.</value>
		public string CHAPA_CARRETA
		{
			get { return _chapa_carreta; }
			set { _chapa_carreta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_ENCARGADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_ENCARGADO</c> column value.</value>
		public string NOMBRE_ENCARGADO
		{
			get { return _nombre_encargado; }
			set { _nombre_encargado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STATUS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>STATUS</c> column value.</value>
		public string STATUS
		{
			get { return _status; }
			set { _status = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSPORTADORA_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</value>
		public decimal TRANSPORTADORA_PERSONA_ID
		{
			get
			{
				if(IsTRANSPORTADORA_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transportadora_persona_id;
			}
			set
			{
				_transportadora_persona_idNull = false;
				_transportadora_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSPORTADORA_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSPORTADORA_PERSONA_IDNull
		{
			get { return _transportadora_persona_idNull; }
			set { _transportadora_persona_idNull = value; }
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
		/// Gets or sets the <c>TIPO_CAMION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CAMION_ID</c> column value.</value>
		public decimal TIPO_CAMION_ID
		{
			get
			{
				if(IsTIPO_CAMION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_camion_id;
			}
			set
			{
				_tipo_camion_idNull = false;
				_tipo_camion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CAMION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CAMION_IDNull
		{
			get { return _tipo_camion_idNull; }
			set { _tipo_camion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_VEHICULO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_VEHICULO_NOMBRE</c> column value.</value>
		public string TIPO_VEHICULO_NOMBRE
		{
			get { return _tipo_vehiculo_nombre; }
			set { _tipo_vehiculo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_NOMBRE</c> column value.</value>
		public string CHOFER_NOMBRE
		{
			get { return _chofer_nombre; }
			set { _chofer_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER_DOCUMENTO</c> column value.</value>
		public string CHOFER_DOCUMENTO
		{
			get { return _chofer_documento; }
			set { _chofer_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA_CAMION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA_CAMION</c> column value.</value>
		public decimal TARA_CAMION
		{
			get
			{
				if(IsTARA_CAMIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara_camion;
			}
			set
			{
				_tara_camionNull = false;
				_tara_camion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA_CAMION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARA_CAMIONNull
		{
			get { return _tara_camionNull; }
			set { _tara_camionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_ID</c> column value.</value>
		public decimal CONTENEDOR_ID
		{
			get
			{
				if(IsCONTENEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _contenedor_id;
			}
			set
			{
				_contenedor_idNull = false;
				_contenedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONTENEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONTENEDOR_IDNull
		{
			get { return _contenedor_idNull; }
			set { _contenedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_NUMERO</c> column value.</value>
		public string CONTENEDOR_NUMERO
		{
			get { return _contenedor_numero; }
			set { _contenedor_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENDOR_TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENDOR_TIPO</c> column value.</value>
		public string CONTENDOR_TIPO
		{
			get { return _contendor_tipo; }
			set { _contendor_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA_CONTENEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA_CONTENEDOR</c> column value.</value>
		public decimal TARA_CONTENEDOR
		{
			get
			{
				if(IsTARA_CONTENEDORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara_contenedor;
			}
			set
			{
				_tara_contenedorNull = false;
				_tara_contenedor = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA_CONTENEDOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARA_CONTENEDORNull
		{
			get { return _tara_contenedorNull; }
			set { _tara_contenedorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_BRUTO</c> column value.</value>
		public decimal PESO_BRUTO
		{
			get
			{
				if(IsPESO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_bruto;
			}
			set
			{
				_peso_brutoNull = false;
				_peso_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_BRUTONull
		{
			get { return _peso_brutoNull; }
			set { _peso_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_NETO</c> column value.</value>
		public decimal PESO_NETO
		{
			get
			{
				if(IsPESO_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_neto;
			}
			set
			{
				_peso_netoNull = false;
				_peso_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_NETONull
		{
			get { return _peso_netoNull; }
			set { _peso_netoNull = value; }
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
		/// Gets or sets the <c>TIPO_BULTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_BULTO_ID</c> column value.</value>
		public string TIPO_BULTO_ID
		{
			get { return _tipo_bulto_id; }
			set { _tipo_bulto_id = value; }
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
		/// Gets or sets the <c>FECHA_SALIDA_PUERTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA_PUERTO</c> column value.</value>
		public System.DateTime FECHA_SALIDA_PUERTO
		{
			get
			{
				if(IsFECHA_SALIDA_PUERTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida_puerto;
			}
			set
			{
				_fecha_salida_puertoNull = false;
				_fecha_salida_puerto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA_PUERTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDA_PUERTONull
		{
			get { return _fecha_salida_puertoNull; }
			set { _fecha_salida_puertoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONFIRMADO</c> column value.</value>
		public string CONFIRMADO
		{
			get { return _confirmado; }
			set { _confirmado = value; }
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
		/// Gets or sets the <c>FECHA_CONFIRMACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CONFIRMACION</c> column value.</value>
		public System.DateTime FECHA_CONFIRMACION
		{
			get
			{
				if(IsFECHA_CONFIRMACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_confirmacion;
			}
			set
			{
				_fecha_confirmacionNull = false;
				_fecha_confirmacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CONFIRMACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CONFIRMACIONNull
		{
			get { return _fecha_confirmacionNull; }
			set { _fecha_confirmacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_1</c> column value.</value>
		public string PRECINTO_1
		{
			get { return _precinto_1; }
			set { _precinto_1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_2</c> column value.</value>
		public string PRECINTO_2
		{
			get { return _precinto_2; }
			set { _precinto_2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_3</c> column value.</value>
		public string PRECINTO_3
		{
			get { return _precinto_3; }
			set { _precinto_3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_4</c> column value.</value>
		public string PRECINTO_4
		{
			get { return _precinto_4; }
			set { _precinto_4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_5</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_5</c> column value.</value>
		public string PRECINTO_5
		{
			get { return _precinto_5; }
			set { _precinto_5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTO_VENTILETE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTO_VENTILETE</c> column value.</value>
		public string PRECINTO_VENTILETE
		{
			get { return _precinto_ventilete; }
			set { _precinto_ventilete = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_RETIRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_RETIRO</c> column value.</value>
		public string TIPO_RETIRO
		{
			get { return _tipo_retiro; }
			set { _tipo_retiro = value; }
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
		/// Gets or sets the <c>FECHA_ENTRADA_DEPOSITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ENTRADA_DEPOSITO</c> column value.</value>
		public System.DateTime FECHA_ENTRADA_DEPOSITO
		{
			get
			{
				if(IsFECHA_ENTRADA_DEPOSITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_entrada_deposito;
			}
			set
			{
				_fecha_entrada_depositoNull = false;
				_fecha_entrada_deposito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ENTRADA_DEPOSITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ENTRADA_DEPOSITONull
		{
			get { return _fecha_entrada_depositoNull; }
			set { _fecha_entrada_depositoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SALIDA_DEPOSITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA_DEPOSITO</c> column value.</value>
		public System.DateTime FECHA_SALIDA_DEPOSITO
		{
			get
			{
				if(IsFECHA_SALIDA_DEPOSITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida_deposito;
			}
			set
			{
				_fecha_salida_depositoNull = false;
				_fecha_salida_deposito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA_DEPOSITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDA_DEPOSITONull
		{
			get { return _fecha_salida_depositoNull; }
			set { _fecha_salida_depositoNull = value; }
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
			dynStr.Append("@CBA@ITEM_SALIDA_DEPOSITO_ID=");
			dynStr.Append(IsITEM_SALIDA_DEPOSITO_IDNull ? (object)"<NULL>" : ITEM_SALIDA_DEPOSITO_ID);
			dynStr.Append("@CBA@ITEMS_INGRESOS_DETALLES_ID=");
			dynStr.Append(IsITEMS_INGRESOS_DETALLES_IDNull ? (object)"<NULL>" : ITEMS_INGRESOS_DETALLES_ID);
			dynStr.Append("@CBA@CONOCIMIENTO=");
			dynStr.Append(CONOCIMIENTO);
			dynStr.Append("@CBA@CONSIGANATARIO_NOMBRE=");
			dynStr.Append(CONSIGANATARIO_NOMBRE);
			dynStr.Append("@CBA@NUMERO_SALIDA=");
			dynStr.Append(NUMERO_SALIDA);
			dynStr.Append("@CBA@FECHA_ENTRADA_PUERTO=");
			dynStr.Append(IsFECHA_ENTRADA_PUERTONull ? (object)"<NULL>" : FECHA_ENTRADA_PUERTO);
			dynStr.Append("@CBA@CHAPA_CAMION=");
			dynStr.Append(CHAPA_CAMION);
			dynStr.Append("@CBA@CHAPA_CARRETA=");
			dynStr.Append(CHAPA_CARRETA);
			dynStr.Append("@CBA@NOMBRE_ENCARGADO=");
			dynStr.Append(NOMBRE_ENCARGADO);
			dynStr.Append("@CBA@STATUS=");
			dynStr.Append(STATUS);
			dynStr.Append("@CBA@TRANSPORTADORA_PERSONA_ID=");
			dynStr.Append(IsTRANSPORTADORA_PERSONA_IDNull ? (object)"<NULL>" : TRANSPORTADORA_PERSONA_ID);
			dynStr.Append("@CBA@TRANSPORTADORA_NOMBRE=");
			dynStr.Append(TRANSPORTADORA_NOMBRE);
			dynStr.Append("@CBA@TIPO_CAMION_ID=");
			dynStr.Append(IsTIPO_CAMION_IDNull ? (object)"<NULL>" : TIPO_CAMION_ID);
			dynStr.Append("@CBA@TIPO_VEHICULO_NOMBRE=");
			dynStr.Append(TIPO_VEHICULO_NOMBRE);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@CHOFER_DOCUMENTO=");
			dynStr.Append(CHOFER_DOCUMENTO);
			dynStr.Append("@CBA@TARA_CAMION=");
			dynStr.Append(IsTARA_CAMIONNull ? (object)"<NULL>" : TARA_CAMION);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@CONTENDOR_TIPO=");
			dynStr.Append(CONTENDOR_TIPO);
			dynStr.Append("@CBA@TARA_CONTENEDOR=");
			dynStr.Append(IsTARA_CONTENEDORNull ? (object)"<NULL>" : TARA_CONTENEDOR);
			dynStr.Append("@CBA@PESO_BRUTO=");
			dynStr.Append(IsPESO_BRUTONull ? (object)"<NULL>" : PESO_BRUTO);
			dynStr.Append("@CBA@PESO_NETO=");
			dynStr.Append(IsPESO_NETONull ? (object)"<NULL>" : PESO_NETO);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@TIPO_BULTO_ID=");
			dynStr.Append(TIPO_BULTO_ID);
			dynStr.Append("@CBA@MERCADERIA=");
			dynStr.Append(MERCADERIA);
			dynStr.Append("@CBA@FECHA_SALIDA_PUERTO=");
			dynStr.Append(IsFECHA_SALIDA_PUERTONull ? (object)"<NULL>" : FECHA_SALIDA_PUERTO);
			dynStr.Append("@CBA@CONFIRMADO=");
			dynStr.Append(CONFIRMADO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_CONFIRMACION=");
			dynStr.Append(IsFECHA_CONFIRMACIONNull ? (object)"<NULL>" : FECHA_CONFIRMACION);
			dynStr.Append("@CBA@PRECINTO_1=");
			dynStr.Append(PRECINTO_1);
			dynStr.Append("@CBA@PRECINTO_2=");
			dynStr.Append(PRECINTO_2);
			dynStr.Append("@CBA@PRECINTO_3=");
			dynStr.Append(PRECINTO_3);
			dynStr.Append("@CBA@PRECINTO_4=");
			dynStr.Append(PRECINTO_4);
			dynStr.Append("@CBA@PRECINTO_5=");
			dynStr.Append(PRECINTO_5);
			dynStr.Append("@CBA@PRECINTO_VENTILETE=");
			dynStr.Append(PRECINTO_VENTILETE);
			dynStr.Append("@CBA@TIPO_RETIRO=");
			dynStr.Append(TIPO_RETIRO);
			dynStr.Append("@CBA@SEMANA=");
			dynStr.Append(IsSEMANANull ? (object)"<NULL>" : SEMANA);
			dynStr.Append("@CBA@FECHA_ENTRADA_DEPOSITO=");
			dynStr.Append(IsFECHA_ENTRADA_DEPOSITONull ? (object)"<NULL>" : FECHA_ENTRADA_DEPOSITO);
			dynStr.Append("@CBA@FECHA_SALIDA_DEPOSITO=");
			dynStr.Append(IsFECHA_SALIDA_DEPOSITONull ? (object)"<NULL>" : FECHA_SALIDA_DEPOSITO);
			return dynStr.ToString();
		}
	} // End of ITEMS_SAL_DEP_DET_INFO_COMPLRow_Base class
} // End of namespace
