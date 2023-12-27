// <fileinfo name="INGRESO_STOCKRow_Base.cs">
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
	/// The base class for <see cref="INGRESO_STOCKRow"/> that 
	/// represents a record in the <c>INGRESO_STOCK</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INGRESO_STOCKRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_STOCKRow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _deposito_id;
		private System.DateTime _fecha;
		private decimal _caso_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private decimal _caso_fc_proveedor_id;
		private bool _caso_fc_proveedor_idNull = true;
		private decimal _porcentaje_prorateo;
		private bool _porcentaje_prorateoNull = true;
		private decimal _monto_prorateo;
		private bool _monto_prorateoNull = true;
		private string _aplicar_prorrateo;
		private decimal _tipo_prorrateo;
		private string _observacion;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _nro_documento_externo;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCKRow_Base"/> class.
		/// </summary>
		public INGRESO_STOCKRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INGRESO_STOCKRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsCASO_FC_PROVEEDOR_IDNull != original.IsCASO_FC_PROVEEDOR_IDNull) return true;
			if (!this.IsCASO_FC_PROVEEDOR_IDNull && !original.IsCASO_FC_PROVEEDOR_IDNull)
				if (this.CASO_FC_PROVEEDOR_ID != original.CASO_FC_PROVEEDOR_ID) return true;
			if (this.IsPORCENTAJE_PRORATEONull != original.IsPORCENTAJE_PRORATEONull) return true;
			if (!this.IsPORCENTAJE_PRORATEONull && !original.IsPORCENTAJE_PRORATEONull)
				if (this.PORCENTAJE_PRORATEO != original.PORCENTAJE_PRORATEO) return true;
			if (this.IsMONTO_PRORATEONull != original.IsMONTO_PRORATEONull) return true;
			if (!this.IsMONTO_PRORATEONull && !original.IsMONTO_PRORATEONull)
				if (this.MONTO_PRORATEO != original.MONTO_PRORATEO) return true;
			if (this.APLICAR_PRORRATEO != original.APLICAR_PRORRATEO) return true;
			if (this.TIPO_PRORRATEO != original.TIPO_PRORRATEO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.NRO_DOCUMENTO_EXTERNO != original.NRO_DOCUMENTO_EXTERNO) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>CASO_FC_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_FC_PROVEEDOR_ID</c> column value.</value>
		public decimal CASO_FC_PROVEEDOR_ID
		{
			get
			{
				if(IsCASO_FC_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_fc_proveedor_id;
			}
			set
			{
				_caso_fc_proveedor_idNull = false;
				_caso_fc_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_FC_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_FC_PROVEEDOR_IDNull
		{
			get { return _caso_fc_proveedor_idNull; }
			set { _caso_fc_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_PRORATEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_PRORATEO</c> column value.</value>
		public decimal PORCENTAJE_PRORATEO
		{
			get
			{
				if(IsPORCENTAJE_PRORATEONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_prorateo;
			}
			set
			{
				_porcentaje_prorateoNull = false;
				_porcentaje_prorateo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_PRORATEO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_PRORATEONull
		{
			get { return _porcentaje_prorateoNull; }
			set { _porcentaje_prorateoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_PRORATEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_PRORATEO</c> column value.</value>
		public decimal MONTO_PRORATEO
		{
			get
			{
				if(IsMONTO_PRORATEONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_prorateo;
			}
			set
			{
				_monto_prorateoNull = false;
				_monto_prorateo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_PRORATEO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_PRORATEONull
		{
			get { return _monto_prorateoNull; }
			set { _monto_prorateoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>APLICAR_PRORRATEO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APLICAR_PRORRATEO</c> column value.</value>
		public string APLICAR_PRORRATEO
		{
			get { return _aplicar_prorrateo; }
			set { _aplicar_prorrateo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_PRORRATEO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_PRORRATEO</c> column value.</value>
		public decimal TIPO_PRORRATEO
		{
			get { return _tipo_prorrateo; }
			set { _tipo_prorrateo = value; }
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
		/// Gets or sets the <c>NRO_DOCUMENTO_EXTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_DOCUMENTO_EXTERNO</c> column value.</value>
		public string NRO_DOCUMENTO_EXTERNO
		{
			get { return _nro_documento_externo; }
			set { _nro_documento_externo = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@CASO_FC_PROVEEDOR_ID=");
			dynStr.Append(IsCASO_FC_PROVEEDOR_IDNull ? (object)"<NULL>" : CASO_FC_PROVEEDOR_ID);
			dynStr.Append("@CBA@PORCENTAJE_PRORATEO=");
			dynStr.Append(IsPORCENTAJE_PRORATEONull ? (object)"<NULL>" : PORCENTAJE_PRORATEO);
			dynStr.Append("@CBA@MONTO_PRORATEO=");
			dynStr.Append(IsMONTO_PRORATEONull ? (object)"<NULL>" : MONTO_PRORATEO);
			dynStr.Append("@CBA@APLICAR_PRORRATEO=");
			dynStr.Append(APLICAR_PRORRATEO);
			dynStr.Append("@CBA@TIPO_PRORRATEO=");
			dynStr.Append(TIPO_PRORRATEO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@NRO_DOCUMENTO_EXTERNO=");
			dynStr.Append(NRO_DOCUMENTO_EXTERNO);
			return dynStr.ToString();
		}
	} // End of INGRESO_STOCKRow_Base class
} // End of namespace
