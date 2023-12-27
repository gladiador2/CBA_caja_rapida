// <fileinfo name="DESCUENTO_DOCUMENTOSRow_Base.cs">
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
	/// The base class for <see cref="DESCUENTO_DOCUMENTOSRow"/> that 
	/// represents a record in the <c>DESCUENTO_DOCUMENTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESCUENTO_DOCUMENTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTO_DOCUMENTOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _ctacte_banco_id;
		private bool _ctacte_banco_idNull = true;
		private decimal _ctacte_caja_tesoreria_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private System.DateTime _fecha;
		private string _observacion;
		private string _nombre_institucion;
		private decimal _ctacte_bancaria_id;
		private bool _ctacte_bancaria_idNull = true;
		private decimal _moneda_id;
		private decimal _moneda_cotizacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTO_DOCUMENTOSRow_Base"/> class.
		/// </summary>
		public DESCUENTO_DOCUMENTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESCUENTO_DOCUMENTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsCTACTE_BANCO_IDNull != original.IsCTACTE_BANCO_IDNull) return true;
			if (!this.IsCTACTE_BANCO_IDNull && !original.IsCTACTE_BANCO_IDNull)
				if (this.CTACTE_BANCO_ID != original.CTACTE_BANCO_ID) return true;
			if (this.CTACTE_CAJA_TESORERIA_ID != original.CTACTE_CAJA_TESORERIA_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.NOMBRE_INSTITUCION != original.NOMBRE_INSTITUCION) return true;
			if (this.IsCTACTE_BANCARIA_IDNull != original.IsCTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_IDNull && !original.IsCTACTE_BANCARIA_IDNull)
				if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDA_COTIZACION != original.MONEDA_COTIZACION) return true;
			
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
		/// Gets or sets the <c>CTACTE_BANCO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCO_ID</c> column value.</value>
		public decimal CTACTE_BANCO_ID
		{
			get
			{
				if(IsCTACTE_BANCO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_banco_id;
			}
			set
			{
				_ctacte_banco_idNull = false;
				_ctacte_banco_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCO_IDNull
		{
			get { return _ctacte_banco_idNull; }
			set { _ctacte_banco_idNull = value; }
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
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
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
		/// Gets or sets the <c>NOMBRE_INSTITUCION</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_INSTITUCION</c> column value.</value>
		public string NOMBRE_INSTITUCION
		{
			get { return _nombre_institucion; }
			set { _nombre_institucion = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_COTIZACION</c> column value.</value>
		public decimal MONEDA_COTIZACION
		{
			get { return _moneda_cotizacion; }
			set { _moneda_cotizacion = value; }
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
			dynStr.Append("@CBA@CTACTE_BANCO_ID=");
			dynStr.Append(IsCTACTE_BANCO_IDNull ? (object)"<NULL>" : CTACTE_BANCO_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESORERIA_ID=");
			dynStr.Append(CTACTE_CAJA_TESORERIA_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NOMBRE_INSTITUCION=");
			dynStr.Append(NOMBRE_INSTITUCION);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_COTIZACION=");
			dynStr.Append(MONEDA_COTIZACION);
			return dynStr.ToString();
		}
	} // End of DESCUENTO_DOCUMENTOSRow_Base class
} // End of namespace
