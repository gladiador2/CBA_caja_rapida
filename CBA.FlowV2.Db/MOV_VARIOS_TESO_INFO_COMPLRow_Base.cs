// <fileinfo name="MOV_VARIOS_TESO_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="MOV_VARIOS_TESO_INFO_COMPLRow"/> that 
	/// represents a record in the <c>MOV_VARIOS_TESO_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MOV_VARIOS_TESO_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOV_VARIOS_TESO_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private string _caso_estado_id;
		private decimal _sucursal_id;
		private string _sucursale_nombre;
		private string _sucursale_abreviatura;
		private decimal _ctacte_caja_tesoreria_id;
		private string _ctacte_caja_tesoreria_nombre;
		private string _ctacte_caja_tesoreria_abrev;
		private string _tipo_operacion;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _observacion;
		private decimal _total_dolarizado;
		private bool _total_dolarizadoNull = true;
		private decimal _anticipo_prov_utiliza_caso_id;
		private bool _anticipo_prov_utiliza_caso_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _texto_predefinido;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOV_VARIOS_TESO_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public MOV_VARIOS_TESO_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MOV_VARIOS_TESO_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.CASO_ESTADO_ID != original.CASO_ESTADO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSALE_NOMBRE != original.SUCURSALE_NOMBRE) return true;
			if (this.SUCURSALE_ABREVIATURA != original.SUCURSALE_ABREVIATURA) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_NOMBRE != original.CTACTE_CAJA_TESORERIA_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESORERIA_ABREV != original.CTACTE_CAJA_TESORERIA_ABREV) return true;
			if (this.TIPO_OPERACION != original.TIPO_OPERACION) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTOTAL_DOLARIZADONull != original.IsTOTAL_DOLARIZADONull) return true;
			if (!this.IsTOTAL_DOLARIZADONull && !original.IsTOTAL_DOLARIZADONull)
				if (this.TOTAL_DOLARIZADO != original.TOTAL_DOLARIZADO) return true;
			if (this.IsANTICIPO_PROV_UTILIZA_CASO_IDNull != original.IsANTICIPO_PROV_UTILIZA_CASO_IDNull) return true;
			if (!this.IsANTICIPO_PROV_UTILIZA_CASO_IDNull && !original.IsANTICIPO_PROV_UTILIZA_CASO_IDNull)
				if (this.ANTICIPO_PROV_UTILIZA_CASO_ID != original.ANTICIPO_PROV_UTILIZA_CASO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.TEXTO_PREDEFINIDO != original.TEXTO_PREDEFINIDO) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ESTADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ESTADO_ID</c> column value.</value>
		public string CASO_ESTADO_ID
		{
			get { return _caso_estado_id; }
			set { _caso_estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSALE_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSALE_NOMBRE</c> column value.</value>
		public string SUCURSALE_NOMBRE
		{
			get { return _sucursale_nombre; }
			set { _sucursale_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSALE_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSALE_ABREVIATURA</c> column value.</value>
		public string SUCURSALE_ABREVIATURA
		{
			get { return _sucursale_abreviatura; }
			set { _sucursale_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESORERIA_ID
		{
			get { return _ctacte_caja_tesoreria_id; }
			set { _ctacte_caja_tesoreria_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_NOMBRE
		{
			get { return _ctacte_caja_tesoreria_nombre; }
			set { _ctacte_caja_tesoreria_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESORERIA_ABREV</c> column value.</value>
		public string CTACTE_CAJA_TESORERIA_ABREV
		{
			get { return _ctacte_caja_tesoreria_abrev; }
			set { _ctacte_caja_tesoreria_abrev = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_OPERACION</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_OPERACION</c> column value.</value>
		public string TIPO_OPERACION
		{
			get { return _tipo_operacion; }
			set { _tipo_operacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get
			{
				if(IsAUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_id;
			}
			set
			{
				_autonumeracion_idNull = false;
				_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_IDNull
		{
			get { return _autonumeracion_idNull; }
			set { _autonumeracion_idNull = value; }
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
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DOLARIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DOLARIZADO</c> column value.</value>
		public decimal TOTAL_DOLARIZADO
		{
			get
			{
				if(IsTOTAL_DOLARIZADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_dolarizado;
			}
			set
			{
				_total_dolarizadoNull = false;
				_total_dolarizado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DOLARIZADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DOLARIZADONull
		{
			get { return _total_dolarizadoNull; }
			set { _total_dolarizadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANTICIPO_PROV_UTILIZA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANTICIPO_PROV_UTILIZA_CASO_ID</c> column value.</value>
		public decimal ANTICIPO_PROV_UTILIZA_CASO_ID
		{
			get
			{
				if(IsANTICIPO_PROV_UTILIZA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anticipo_prov_utiliza_caso_id;
			}
			set
			{
				_anticipo_prov_utiliza_caso_idNull = false;
				_anticipo_prov_utiliza_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANTICIPO_PROV_UTILIZA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANTICIPO_PROV_UTILIZA_CASO_IDNull
		{
			get { return _anticipo_prov_utiliza_caso_idNull; }
			set { _anticipo_prov_utiliza_caso_idNull = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO</c> column value.</value>
		public string TEXTO_PREDEFINIDO
		{
			get { return _texto_predefinido; }
			set { _texto_predefinido = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@CASO_ESTADO_ID=");
			dynStr.Append(CASO_ESTADO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSALE_NOMBRE=");
			dynStr.Append(SUCURSALE_NOMBRE);
			dynStr.Append("@CBA@SUCURSALE_ABREVIATURA=");
			dynStr.Append(SUCURSALE_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ABREV=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ABREV);
			dynStr.Append("@CBA@TIPO_OPERACION=");
			dynStr.Append(TIPO_OPERACION);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TOTAL_DOLARIZADO=");
			dynStr.Append(IsTOTAL_DOLARIZADONull ? (object)"<NULL>" : TOTAL_DOLARIZADO);
			dynStr.Append("@CBA@ANTICIPO_PROV_UTILIZA_CASO_ID=");
			dynStr.Append(IsANTICIPO_PROV_UTILIZA_CASO_IDNull ? (object)"<NULL>" : ANTICIPO_PROV_UTILIZA_CASO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO=");
			dynStr.Append(TEXTO_PREDEFINIDO);
			return dynStr.ToString();
		}
	} // End of MOV_VARIOS_TESO_INFO_COMPLRow_Base class
} // End of namespace
