// <fileinfo name="ITEMS_INGRESOSRow_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESOSRow"/> that 
	/// represents a record in the <c>ITEMS_INGRESOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ITEMS_INGRESOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESOSRow_Base
	{
		private decimal _id;
		private System.DateTime _fecha_hora;
		private bool _fecha_horaNull = true;
		private string _mic_dta;
		private string _comprobante;
		private string _origen;
		private string _fcl_lcl;
		private decimal _transportadora_persona_id;
		private bool _transportadora_persona_idNull = true;
		private string _transportadora_nombre;
		private string _chapa_camion;
		private string _chapa_carreta;
		private decimal _tipo_camion_id;
		private bool _tipo_camion_idNull = true;
		private decimal _tara_camion;
		private bool _tara_camionNull = true;
		private decimal _tara_carreta;
		private bool _tara_carretaNull = true;
		private string _chofer_nombre;
		private string _chofer_documento;
		private decimal _peso_manifestado;
		private bool _peso_manifestadoNull = true;
		private decimal _tolerancia;
		private bool _toleranciaNull = true;
		private decimal _peso_bruto;
		private bool _peso_brutoNull = true;
		private decimal _tara_contenedor;
		private bool _tara_contenedorNull = true;
		private decimal _peso_neto;
		private bool _peso_netoNull = true;
		private decimal _diferencia;
		private bool _diferenciaNull = true;
		private decimal _valor_neto;
		private bool _valor_netoNull = true;
		private decimal _valor_moneda_id;
		private bool _valor_moneda_idNull = true;
		private decimal _contenedor_id;
		private bool _contenedor_idNull = true;
		private string _confirmado;
		private string _precinto_1;
		private string _precinto_2;
		private string _precinto_3;
		private string _precinto_4;
		private string _precinto_5;
		private string _precinto_ventilete;
		private string _observaciones;
		private decimal _semana;
		private bool _semanaNull = true;
		private string _notificado;
		private string _observacion_notificacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESOSRow_Base"/> class.
		/// </summary>
		public ITEMS_INGRESOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ITEMS_INGRESOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFECHA_HORANull != original.IsFECHA_HORANull) return true;
			if (!this.IsFECHA_HORANull && !original.IsFECHA_HORANull)
				if (this.FECHA_HORA != original.FECHA_HORA) return true;
			if (this.MIC_DTA != original.MIC_DTA) return true;
			if (this.COMPROBANTE != original.COMPROBANTE) return true;
			if (this.ORIGEN != original.ORIGEN) return true;
			if (this.FCL_LCL != original.FCL_LCL) return true;
			if (this.IsTRANSPORTADORA_PERSONA_IDNull != original.IsTRANSPORTADORA_PERSONA_IDNull) return true;
			if (!this.IsTRANSPORTADORA_PERSONA_IDNull && !original.IsTRANSPORTADORA_PERSONA_IDNull)
				if (this.TRANSPORTADORA_PERSONA_ID != original.TRANSPORTADORA_PERSONA_ID) return true;
			if (this.TRANSPORTADORA_NOMBRE != original.TRANSPORTADORA_NOMBRE) return true;
			if (this.CHAPA_CAMION != original.CHAPA_CAMION) return true;
			if (this.CHAPA_CARRETA != original.CHAPA_CARRETA) return true;
			if (this.IsTIPO_CAMION_IDNull != original.IsTIPO_CAMION_IDNull) return true;
			if (!this.IsTIPO_CAMION_IDNull && !original.IsTIPO_CAMION_IDNull)
				if (this.TIPO_CAMION_ID != original.TIPO_CAMION_ID) return true;
			if (this.IsTARA_CAMIONNull != original.IsTARA_CAMIONNull) return true;
			if (!this.IsTARA_CAMIONNull && !original.IsTARA_CAMIONNull)
				if (this.TARA_CAMION != original.TARA_CAMION) return true;
			if (this.IsTARA_CARRETANull != original.IsTARA_CARRETANull) return true;
			if (!this.IsTARA_CARRETANull && !original.IsTARA_CARRETANull)
				if (this.TARA_CARRETA != original.TARA_CARRETA) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.CHOFER_DOCUMENTO != original.CHOFER_DOCUMENTO) return true;
			if (this.IsPESO_MANIFESTADONull != original.IsPESO_MANIFESTADONull) return true;
			if (!this.IsPESO_MANIFESTADONull && !original.IsPESO_MANIFESTADONull)
				if (this.PESO_MANIFESTADO != original.PESO_MANIFESTADO) return true;
			if (this.IsTOLERANCIANull != original.IsTOLERANCIANull) return true;
			if (!this.IsTOLERANCIANull && !original.IsTOLERANCIANull)
				if (this.TOLERANCIA != original.TOLERANCIA) return true;
			if (this.IsPESO_BRUTONull != original.IsPESO_BRUTONull) return true;
			if (!this.IsPESO_BRUTONull && !original.IsPESO_BRUTONull)
				if (this.PESO_BRUTO != original.PESO_BRUTO) return true;
			if (this.IsTARA_CONTENEDORNull != original.IsTARA_CONTENEDORNull) return true;
			if (!this.IsTARA_CONTENEDORNull && !original.IsTARA_CONTENEDORNull)
				if (this.TARA_CONTENEDOR != original.TARA_CONTENEDOR) return true;
			if (this.IsPESO_NETONull != original.IsPESO_NETONull) return true;
			if (!this.IsPESO_NETONull && !original.IsPESO_NETONull)
				if (this.PESO_NETO != original.PESO_NETO) return true;
			if (this.IsDIFERENCIANull != original.IsDIFERENCIANull) return true;
			if (!this.IsDIFERENCIANull && !original.IsDIFERENCIANull)
				if (this.DIFERENCIA != original.DIFERENCIA) return true;
			if (this.IsVALOR_NETONull != original.IsVALOR_NETONull) return true;
			if (!this.IsVALOR_NETONull && !original.IsVALOR_NETONull)
				if (this.VALOR_NETO != original.VALOR_NETO) return true;
			if (this.IsVALOR_MONEDA_IDNull != original.IsVALOR_MONEDA_IDNull) return true;
			if (!this.IsVALOR_MONEDA_IDNull && !original.IsVALOR_MONEDA_IDNull)
				if (this.VALOR_MONEDA_ID != original.VALOR_MONEDA_ID) return true;
			if (this.IsCONTENEDOR_IDNull != original.IsCONTENEDOR_IDNull) return true;
			if (!this.IsCONTENEDOR_IDNull && !original.IsCONTENEDOR_IDNull)
				if (this.CONTENEDOR_ID != original.CONTENEDOR_ID) return true;
			if (this.CONFIRMADO != original.CONFIRMADO) return true;
			if (this.PRECINTO_1 != original.PRECINTO_1) return true;
			if (this.PRECINTO_2 != original.PRECINTO_2) return true;
			if (this.PRECINTO_3 != original.PRECINTO_3) return true;
			if (this.PRECINTO_4 != original.PRECINTO_4) return true;
			if (this.PRECINTO_5 != original.PRECINTO_5) return true;
			if (this.PRECINTO_VENTILETE != original.PRECINTO_VENTILETE) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsSEMANANull != original.IsSEMANANull) return true;
			if (!this.IsSEMANANull && !original.IsSEMANANull)
				if (this.SEMANA != original.SEMANA) return true;
			if (this.NOTIFICADO != original.NOTIFICADO) return true;
			if (this.OBSERVACION_NOTIFICACION != original.OBSERVACION_NOTIFICACION) return true;
			
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
		/// Gets or sets the <c>FECHA_HORA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_HORA</c> column value.</value>
		public System.DateTime FECHA_HORA
		{
			get
			{
				if(IsFECHA_HORANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_hora;
			}
			set
			{
				_fecha_horaNull = false;
				_fecha_hora = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_HORA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_HORANull
		{
			get { return _fecha_horaNull; }
			set { _fecha_horaNull = value; }
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
		/// Gets or sets the <c>COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMPROBANTE</c> column value.</value>
		public string COMPROBANTE
		{
			get { return _comprobante; }
			set { _comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORIGEN</c> column value.</value>
		public string ORIGEN
		{
			get { return _origen; }
			set { _origen = value; }
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
		/// Gets or sets the <c>TARA_CARRETA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA_CARRETA</c> column value.</value>
		public decimal TARA_CARRETA
		{
			get
			{
				if(IsTARA_CARRETANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara_carreta;
			}
			set
			{
				_tara_carretaNull = false;
				_tara_carreta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA_CARRETA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARA_CARRETANull
		{
			get { return _tara_carretaNull; }
			set { _tara_carretaNull = value; }
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
		/// Gets or sets the <c>PESO_MANIFESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_MANIFESTADO</c> column value.</value>
		public decimal PESO_MANIFESTADO
		{
			get
			{
				if(IsPESO_MANIFESTADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_manifestado;
			}
			set
			{
				_peso_manifestadoNull = false;
				_peso_manifestado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_MANIFESTADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_MANIFESTADONull
		{
			get { return _peso_manifestadoNull; }
			set { _peso_manifestadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOLERANCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOLERANCIA</c> column value.</value>
		public decimal TOLERANCIA
		{
			get
			{
				if(IsTOLERANCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tolerancia;
			}
			set
			{
				_toleranciaNull = false;
				_tolerancia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOLERANCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOLERANCIANull
		{
			get { return _toleranciaNull; }
			set { _toleranciaNull = value; }
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
		/// Gets or sets the <c>DIFERENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIFERENCIA</c> column value.</value>
		public decimal DIFERENCIA
		{
			get
			{
				if(IsDIFERENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _diferencia;
			}
			set
			{
				_diferenciaNull = false;
				_diferencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIFERENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIFERENCIANull
		{
			get { return _diferenciaNull; }
			set { _diferenciaNull = value; }
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
		/// Gets or sets the <c>NOTIFICADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTIFICADO</c> column value.</value>
		public string NOTIFICADO
		{
			get { return _notificado; }
			set { _notificado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_NOTIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_NOTIFICACION</c> column value.</value>
		public string OBSERVACION_NOTIFICACION
		{
			get { return _observacion_notificacion; }
			set { _observacion_notificacion = value; }
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
			dynStr.Append("@CBA@FECHA_HORA=");
			dynStr.Append(IsFECHA_HORANull ? (object)"<NULL>" : FECHA_HORA);
			dynStr.Append("@CBA@MIC_DTA=");
			dynStr.Append(MIC_DTA);
			dynStr.Append("@CBA@COMPROBANTE=");
			dynStr.Append(COMPROBANTE);
			dynStr.Append("@CBA@ORIGEN=");
			dynStr.Append(ORIGEN);
			dynStr.Append("@CBA@FCL_LCL=");
			dynStr.Append(FCL_LCL);
			dynStr.Append("@CBA@TRANSPORTADORA_PERSONA_ID=");
			dynStr.Append(IsTRANSPORTADORA_PERSONA_IDNull ? (object)"<NULL>" : TRANSPORTADORA_PERSONA_ID);
			dynStr.Append("@CBA@TRANSPORTADORA_NOMBRE=");
			dynStr.Append(TRANSPORTADORA_NOMBRE);
			dynStr.Append("@CBA@CHAPA_CAMION=");
			dynStr.Append(CHAPA_CAMION);
			dynStr.Append("@CBA@CHAPA_CARRETA=");
			dynStr.Append(CHAPA_CARRETA);
			dynStr.Append("@CBA@TIPO_CAMION_ID=");
			dynStr.Append(IsTIPO_CAMION_IDNull ? (object)"<NULL>" : TIPO_CAMION_ID);
			dynStr.Append("@CBA@TARA_CAMION=");
			dynStr.Append(IsTARA_CAMIONNull ? (object)"<NULL>" : TARA_CAMION);
			dynStr.Append("@CBA@TARA_CARRETA=");
			dynStr.Append(IsTARA_CARRETANull ? (object)"<NULL>" : TARA_CARRETA);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@CHOFER_DOCUMENTO=");
			dynStr.Append(CHOFER_DOCUMENTO);
			dynStr.Append("@CBA@PESO_MANIFESTADO=");
			dynStr.Append(IsPESO_MANIFESTADONull ? (object)"<NULL>" : PESO_MANIFESTADO);
			dynStr.Append("@CBA@TOLERANCIA=");
			dynStr.Append(IsTOLERANCIANull ? (object)"<NULL>" : TOLERANCIA);
			dynStr.Append("@CBA@PESO_BRUTO=");
			dynStr.Append(IsPESO_BRUTONull ? (object)"<NULL>" : PESO_BRUTO);
			dynStr.Append("@CBA@TARA_CONTENEDOR=");
			dynStr.Append(IsTARA_CONTENEDORNull ? (object)"<NULL>" : TARA_CONTENEDOR);
			dynStr.Append("@CBA@PESO_NETO=");
			dynStr.Append(IsPESO_NETONull ? (object)"<NULL>" : PESO_NETO);
			dynStr.Append("@CBA@DIFERENCIA=");
			dynStr.Append(IsDIFERENCIANull ? (object)"<NULL>" : DIFERENCIA);
			dynStr.Append("@CBA@VALOR_NETO=");
			dynStr.Append(IsVALOR_NETONull ? (object)"<NULL>" : VALOR_NETO);
			dynStr.Append("@CBA@VALOR_MONEDA_ID=");
			dynStr.Append(IsVALOR_MONEDA_IDNull ? (object)"<NULL>" : VALOR_MONEDA_ID);
			dynStr.Append("@CBA@CONTENEDOR_ID=");
			dynStr.Append(IsCONTENEDOR_IDNull ? (object)"<NULL>" : CONTENEDOR_ID);
			dynStr.Append("@CBA@CONFIRMADO=");
			dynStr.Append(CONFIRMADO);
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
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@SEMANA=");
			dynStr.Append(IsSEMANANull ? (object)"<NULL>" : SEMANA);
			dynStr.Append("@CBA@NOTIFICADO=");
			dynStr.Append(NOTIFICADO);
			dynStr.Append("@CBA@OBSERVACION_NOTIFICACION=");
			dynStr.Append(OBSERVACION_NOTIFICACION);
			return dynStr.ToString();
		}
	} // End of ITEMS_INGRESOSRow_Base class
} // End of namespace
