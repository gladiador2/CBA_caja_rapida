// <fileinfo name="CAMIONES_CONFIGURACION_TARARow_Base.cs">
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
	/// The base class for <see cref="CAMIONES_CONFIGURACION_TARARow"/> that 
	/// represents a record in the <c>CAMIONES_CONFIGURACION_TARA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMIONES_CONFIGURACION_TARARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMIONES_CONFIGURACION_TARARow_Base
	{
		private decimal _id;
		private System.DateTime _fecha_hora;
		private bool _fecha_horaNull = true;
		private decimal _usuario_id;
		private bool _usuario_idNull = true;
		private decimal _tara;
		private bool _taraNull = true;
		private string _chapa_camion;
		private string _chapa_carreta;
		private string _chofer_documento;
		private string _chofer_nombre;
		private decimal _tara_contenedor;
		private bool _tara_contenedorNull = true;
		private decimal _peso_bruto;
		private bool _peso_brutoNull = true;
		private decimal _peso_neto;
		private bool _peso_netoNull = true;
		private string _sin_carga;
		private string _contenedor;
		private decimal _transportadora_persona_id;
		private bool _transportadora_persona_idNull = true;
		private string _transportadora_nombre;
		private decimal _tipo_vehiculo_id;
		private bool _tipo_vehiculo_idNull = true;
		private decimal _consignatario_persona_id;
		private bool _consignatario_persona_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMIONES_CONFIGURACION_TARARow_Base"/> class.
		/// </summary>
		public CAMIONES_CONFIGURACION_TARARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMIONES_CONFIGURACION_TARARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFECHA_HORANull != original.IsFECHA_HORANull) return true;
			if (!this.IsFECHA_HORANull && !original.IsFECHA_HORANull)
				if (this.FECHA_HORA != original.FECHA_HORA) return true;
			if (this.IsUSUARIO_IDNull != original.IsUSUARIO_IDNull) return true;
			if (!this.IsUSUARIO_IDNull && !original.IsUSUARIO_IDNull)
				if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.IsTARANull != original.IsTARANull) return true;
			if (!this.IsTARANull && !original.IsTARANull)
				if (this.TARA != original.TARA) return true;
			if (this.CHAPA_CAMION != original.CHAPA_CAMION) return true;
			if (this.CHAPA_CARRETA != original.CHAPA_CARRETA) return true;
			if (this.CHOFER_DOCUMENTO != original.CHOFER_DOCUMENTO) return true;
			if (this.CHOFER_NOMBRE != original.CHOFER_NOMBRE) return true;
			if (this.IsTARA_CONTENEDORNull != original.IsTARA_CONTENEDORNull) return true;
			if (!this.IsTARA_CONTENEDORNull && !original.IsTARA_CONTENEDORNull)
				if (this.TARA_CONTENEDOR != original.TARA_CONTENEDOR) return true;
			if (this.IsPESO_BRUTONull != original.IsPESO_BRUTONull) return true;
			if (!this.IsPESO_BRUTONull && !original.IsPESO_BRUTONull)
				if (this.PESO_BRUTO != original.PESO_BRUTO) return true;
			if (this.IsPESO_NETONull != original.IsPESO_NETONull) return true;
			if (!this.IsPESO_NETONull && !original.IsPESO_NETONull)
				if (this.PESO_NETO != original.PESO_NETO) return true;
			if (this.SIN_CARGA != original.SIN_CARGA) return true;
			if (this.CONTENEDOR != original.CONTENEDOR) return true;
			if (this.IsTRANSPORTADORA_PERSONA_IDNull != original.IsTRANSPORTADORA_PERSONA_IDNull) return true;
			if (!this.IsTRANSPORTADORA_PERSONA_IDNull && !original.IsTRANSPORTADORA_PERSONA_IDNull)
				if (this.TRANSPORTADORA_PERSONA_ID != original.TRANSPORTADORA_PERSONA_ID) return true;
			if (this.TRANSPORTADORA_NOMBRE != original.TRANSPORTADORA_NOMBRE) return true;
			if (this.IsTIPO_VEHICULO_IDNull != original.IsTIPO_VEHICULO_IDNull) return true;
			if (!this.IsTIPO_VEHICULO_IDNull && !original.IsTIPO_VEHICULO_IDNull)
				if (this.TIPO_VEHICULO_ID != original.TIPO_VEHICULO_ID) return true;
			if (this.IsCONSIGNATARIO_PERSONA_IDNull != original.IsCONSIGNATARIO_PERSONA_IDNull) return true;
			if (!this.IsCONSIGNATARIO_PERSONA_IDNull && !original.IsCONSIGNATARIO_PERSONA_IDNull)
				if (this.CONSIGNATARIO_PERSONA_ID != original.CONSIGNATARIO_PERSONA_ID) return true;
			
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
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get
			{
				if(IsUSUARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_id;
			}
			set
			{
				_usuario_idNull = false;
				_usuario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_IDNull
		{
			get { return _usuario_idNull; }
			set { _usuario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TARA</c> column value.</value>
		public decimal TARA
		{
			get
			{
				if(IsTARANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tara;
			}
			set
			{
				_taraNull = false;
				_tara = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TARA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTARANull
		{
			get { return _taraNull; }
			set { _taraNull = value; }
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
		/// Gets or sets the <c>SIN_CARGA</c> column value.
		/// </summary>
		/// <value>The <c>SIN_CARGA</c> column value.</value>
		public string SIN_CARGA
		{
			get { return _sin_carga; }
			set { _sin_carga = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR</c> column value.</value>
		public string CONTENEDOR
		{
			get { return _contenedor; }
			set { _contenedor = value; }
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
		/// Gets or sets the <c>TIPO_VEHICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_VEHICULO_ID</c> column value.</value>
		public decimal TIPO_VEHICULO_ID
		{
			get
			{
				if(IsTIPO_VEHICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_vehiculo_id;
			}
			set
			{
				_tipo_vehiculo_idNull = false;
				_tipo_vehiculo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_VEHICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_VEHICULO_IDNull
		{
			get { return _tipo_vehiculo_idNull; }
			set { _tipo_vehiculo_idNull = value; }
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
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(IsUSUARIO_IDNull ? (object)"<NULL>" : USUARIO_ID);
			dynStr.Append("@CBA@TARA=");
			dynStr.Append(IsTARANull ? (object)"<NULL>" : TARA);
			dynStr.Append("@CBA@CHAPA_CAMION=");
			dynStr.Append(CHAPA_CAMION);
			dynStr.Append("@CBA@CHAPA_CARRETA=");
			dynStr.Append(CHAPA_CARRETA);
			dynStr.Append("@CBA@CHOFER_DOCUMENTO=");
			dynStr.Append(CHOFER_DOCUMENTO);
			dynStr.Append("@CBA@CHOFER_NOMBRE=");
			dynStr.Append(CHOFER_NOMBRE);
			dynStr.Append("@CBA@TARA_CONTENEDOR=");
			dynStr.Append(IsTARA_CONTENEDORNull ? (object)"<NULL>" : TARA_CONTENEDOR);
			dynStr.Append("@CBA@PESO_BRUTO=");
			dynStr.Append(IsPESO_BRUTONull ? (object)"<NULL>" : PESO_BRUTO);
			dynStr.Append("@CBA@PESO_NETO=");
			dynStr.Append(IsPESO_NETONull ? (object)"<NULL>" : PESO_NETO);
			dynStr.Append("@CBA@SIN_CARGA=");
			dynStr.Append(SIN_CARGA);
			dynStr.Append("@CBA@CONTENEDOR=");
			dynStr.Append(CONTENEDOR);
			dynStr.Append("@CBA@TRANSPORTADORA_PERSONA_ID=");
			dynStr.Append(IsTRANSPORTADORA_PERSONA_IDNull ? (object)"<NULL>" : TRANSPORTADORA_PERSONA_ID);
			dynStr.Append("@CBA@TRANSPORTADORA_NOMBRE=");
			dynStr.Append(TRANSPORTADORA_NOMBRE);
			dynStr.Append("@CBA@TIPO_VEHICULO_ID=");
			dynStr.Append(IsTIPO_VEHICULO_IDNull ? (object)"<NULL>" : TIPO_VEHICULO_ID);
			dynStr.Append("@CBA@CONSIGNATARIO_PERSONA_ID=");
			dynStr.Append(IsCONSIGNATARIO_PERSONA_IDNull ? (object)"<NULL>" : CONSIGNATARIO_PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of CAMIONES_CONFIGURACION_TARARow_Base class
} // End of namespace
