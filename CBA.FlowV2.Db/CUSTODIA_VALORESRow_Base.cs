// <fileinfo name="CUSTODIA_VALORESRow_Base.cs">
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
	/// The base class for <see cref="CUSTODIA_VALORESRow"/> that 
	/// represents a record in the <c>CUSTODIA_VALORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CUSTODIA_VALORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CUSTODIA_VALORESRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _ctacte_caja_tesoreria_id;
		private decimal _ctacte_banco_id;
		private decimal _ctacte_bancaria_id;
		private bool _ctacte_bancaria_idNull = true;
		private decimal _costo_asociado;
		private bool _costo_asociadoNull = true;
		private decimal _total_documentos;
		private bool _total_documentosNull = true;
		private System.DateTime _fecha;
		private string _nro_comprobante;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private decimal _total_costo;
		private decimal _porcentaje_impuesto;
		private decimal _total_impuesto;
		private decimal _porcentaje_interes_acordado;
		private decimal _total_interes_acordado;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CUSTODIA_VALORESRow_Base"/> class.
		/// </summary>
		public CUSTODIA_VALORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CUSTODIA_VALORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.IsCTACTE_BANCARIA_IDNull != original.IsCTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_IDNull && !original.IsCTACTE_BANCARIA_IDNull)
				if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.IsCOSTO_ASOCIADONull != original.IsCOSTO_ASOCIADONull) return true;
			if (!this.IsCOSTO_ASOCIADONull && !original.IsCOSTO_ASOCIADONull)
				if (this.COSTO_ASOCIADO != original.COSTO_ASOCIADO) return true;
			if (this.IsTOTAL_DOCUMENTOSNull != original.IsTOTAL_DOCUMENTOSNull) return true;
			if (!this.IsTOTAL_DOCUMENTOSNull && !original.IsTOTAL_DOCUMENTOSNull)
				if (this.TOTAL_DOCUMENTOS != original.TOTAL_DOCUMENTOS) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.TOTAL_COSTO != original.TOTAL_COSTO) return true;
			if (this.PORCENTAJE_IMPUESTO != original.PORCENTAJE_IMPUESTO) return true;
			if (this.TOTAL_IMPUESTO != original.TOTAL_IMPUESTO) return true;
			if (this.PORCENTAJE_INTERES_ACORDADO != original.PORCENTAJE_INTERES_ACORDADO) return true;
			if (this.TOTAL_INTERES_ACORDADO != original.TOTAL_INTERES_ACORDADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get { return _ctacte_banco_id; }
			set { _ctacte_banco_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_id;
			}
			set
			{
				_ctacte_bancaria_idNull = false;
				_ctacte_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_IDNull
		{
			get { return _ctacte_bancaria_idNull; }
			set { _ctacte_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ASOCIADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_ASOCIADO</c> column value.</value>
		public decimal COSTO_ASOCIADO
		{
			get
			{
				if(IsCOSTO_ASOCIADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_asociado;
			}
			set
			{
				_costo_asociadoNull = false;
				_costo_asociado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_ASOCIADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_ASOCIADONull
		{
			get { return _costo_asociadoNull; }
			set { _costo_asociadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_DOCUMENTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_DOCUMENTOS</c> column value.</value>
		public decimal TOTAL_DOCUMENTOS
		{
			get
			{
				if(IsTOTAL_DOCUMENTOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_documentos;
			}
			set
			{
				_total_documentosNull = false;
				_total_documentos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_DOCUMENTOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_DOCUMENTOSNull
		{
			get { return _total_documentosNull; }
			set { _total_documentosNull = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_COSTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_COSTO</c> column value.</value>
		public decimal TOTAL_COSTO
		{
			get { return _total_costo; }
			set { _total_costo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_IMPUESTO</c> column value.</value>
		public decimal PORCENTAJE_IMPUESTO
		{
			get { return _porcentaje_impuesto; }
			set { _porcentaje_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO</c> column value.</value>
		public decimal TOTAL_IMPUESTO
		{
			get { return _total_impuesto; }
			set { _total_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_INTERES_ACORDADO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_INTERES_ACORDADO</c> column value.</value>
		public decimal PORCENTAJE_INTERES_ACORDADO
		{
			get { return _porcentaje_interes_acordado; }
			set { _porcentaje_interes_acordado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_INTERES_ACORDADO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_INTERES_ACORDADO</c> column value.</value>
		public decimal TOTAL_INTERES_ACORDADO
		{
			get { return _total_interes_acordado; }
			set { _total_interes_acordado = value; }
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
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@COSTO_ASOCIADO=");
			dynStr.Append(IsCOSTO_ASOCIADONull ? (object)"<NULL>" : COSTO_ASOCIADO);
			dynStr.Append("@CBA@TOTAL_DOCUMENTOS=");
			dynStr.Append(IsTOTAL_DOCUMENTOSNull ? (object)"<NULL>" : TOTAL_DOCUMENTOS);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@TOTAL_COSTO=");
			dynStr.Append(TOTAL_COSTO);
			dynStr.Append("@CBA@PORCENTAJE_IMPUESTO=");
			dynStr.Append(PORCENTAJE_IMPUESTO);
			dynStr.Append("@CBA@TOTAL_IMPUESTO=");
			dynStr.Append(TOTAL_IMPUESTO);
			dynStr.Append("@CBA@PORCENTAJE_INTERES_ACORDADO=");
			dynStr.Append(PORCENTAJE_INTERES_ACORDADO);
			dynStr.Append("@CBA@TOTAL_INTERES_ACORDADO=");
			dynStr.Append(TOTAL_INTERES_ACORDADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CUSTODIA_VALORESRow_Base class
} // End of namespace
