// <fileinfo name="INGRESO_INSUMOSRow_Base.cs">
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
	/// The base class for <see cref="INGRESO_INSUMOSRow"/> that 
	/// represents a record in the <c>INGRESO_INSUMOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INGRESO_INSUMOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_INSUMOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _box_id;
		private bool _box_idNull = true;
		private string _tipo_ingreso;
		private string _factura;
		private string _despacho;
		private decimal _buque_id;
		private bool _buque_idNull = true;
		private string _registro;
		private string _autorizacion_dna;
		private string _transportista;
		private decimal _merma;
		private bool _mermaNull = true;
		private string _observaciones;
		private decimal _persona_id;
		private bool _persona_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_INSUMOSRow_Base"/> class.
		/// </summary>
		public INGRESO_INSUMOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INGRESO_INSUMOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsBOX_IDNull != original.IsBOX_IDNull) return true;
			if (!this.IsBOX_IDNull && !original.IsBOX_IDNull)
				if (this.BOX_ID != original.BOX_ID) return true;
			if (this.TIPO_INGRESO != original.TIPO_INGRESO) return true;
			if (this.FACTURA != original.FACTURA) return true;
			if (this.DESPACHO != original.DESPACHO) return true;
			if (this.IsBUQUE_IDNull != original.IsBUQUE_IDNull) return true;
			if (!this.IsBUQUE_IDNull && !original.IsBUQUE_IDNull)
				if (this.BUQUE_ID != original.BUQUE_ID) return true;
			if (this.REGISTRO != original.REGISTRO) return true;
			if (this.AUTORIZACION_DNA != original.AUTORIZACION_DNA) return true;
			if (this.TRANSPORTISTA != original.TRANSPORTISTA) return true;
			if (this.IsMERMANull != original.IsMERMANull) return true;
			if (!this.IsMERMANull && !original.IsMERMANull)
				if (this.MERMA != original.MERMA) return true;
			if (this.OBSERVACIONES != original.OBSERVACIONES) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
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
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BOX_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BOX_ID</c> column value.</value>
		public decimal BOX_ID
		{
			get
			{
				if(IsBOX_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _box_id;
			}
			set
			{
				_box_idNull = false;
				_box_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BOX_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBOX_IDNull
		{
			get { return _box_idNull; }
			set { _box_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_INGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_INGRESO</c> column value.</value>
		public string TIPO_INGRESO
		{
			get { return _tipo_ingreso; }
			set { _tipo_ingreso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA</c> column value.</value>
		public string FACTURA
		{
			get { return _factura; }
			set { _factura = value; }
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
		/// Gets or sets the <c>BUQUE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BUQUE_ID</c> column value.</value>
		public decimal BUQUE_ID
		{
			get
			{
				if(IsBUQUE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _buque_id;
			}
			set
			{
				_buque_idNull = false;
				_buque_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BUQUE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBUQUE_IDNull
		{
			get { return _buque_idNull; }
			set { _buque_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGISTRO</c> column value.</value>
		public string REGISTRO
		{
			get { return _registro; }
			set { _registro = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTORIZACION_DNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTORIZACION_DNA</c> column value.</value>
		public string AUTORIZACION_DNA
		{
			get { return _autorizacion_dna; }
			set { _autorizacion_dna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSPORTISTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSPORTISTA</c> column value.</value>
		public string TRANSPORTISTA
		{
			get { return _transportista; }
			set { _transportista = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MERMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MERMA</c> column value.</value>
		public decimal MERMA
		{
			get
			{
				if(IsMERMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _merma;
			}
			set
			{
				_mermaNull = false;
				_merma = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MERMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMERMANull
		{
			get { return _mermaNull; }
			set { _mermaNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@BOX_ID=");
			dynStr.Append(IsBOX_IDNull ? (object)"<NULL>" : BOX_ID);
			dynStr.Append("@CBA@TIPO_INGRESO=");
			dynStr.Append(TIPO_INGRESO);
			dynStr.Append("@CBA@FACTURA=");
			dynStr.Append(FACTURA);
			dynStr.Append("@CBA@DESPACHO=");
			dynStr.Append(DESPACHO);
			dynStr.Append("@CBA@BUQUE_ID=");
			dynStr.Append(IsBUQUE_IDNull ? (object)"<NULL>" : BUQUE_ID);
			dynStr.Append("@CBA@REGISTRO=");
			dynStr.Append(REGISTRO);
			dynStr.Append("@CBA@AUTORIZACION_DNA=");
			dynStr.Append(AUTORIZACION_DNA);
			dynStr.Append("@CBA@TRANSPORTISTA=");
			dynStr.Append(TRANSPORTISTA);
			dynStr.Append("@CBA@MERMA=");
			dynStr.Append(IsMERMANull ? (object)"<NULL>" : MERMA);
			dynStr.Append("@CBA@OBSERVACIONES=");
			dynStr.Append(OBSERVACIONES);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			return dynStr.ToString();
		}
	} // End of INGRESO_INSUMOSRow_Base class
} // End of namespace
