// <fileinfo name="TRANSFERENCIA_CTACTE_PERSONARow_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIA_CTACTE_PERSONARow"/> that 
	/// represents a record in the <c>TRANSFERENCIA_CTACTE_PERSONA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSFERENCIA_CTACTE_PERSONARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIA_CTACTE_PERSONARow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _monto_total_credito;
		private bool _monto_total_creditoNull = true;
		private decimal _persona_origen_id;
		private decimal _persona_destino_id;
		private System.DateTime _fecha;
		private System.DateTime _fecha_vencimiento_destino;
		private bool _fecha_vencimiento_destinoNull = true;
		private decimal _caso_id;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private string _nro_comprobante;
		private string _observacion;
		private decimal _monto_total_debito;
		private bool _monto_total_debitoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIA_CTACTE_PERSONARow_Base"/> class.
		/// </summary>
		public TRANSFERENCIA_CTACTE_PERSONARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSFERENCIA_CTACTE_PERSONARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsMONTO_TOTAL_CREDITONull != original.IsMONTO_TOTAL_CREDITONull) return true;
			if (!this.IsMONTO_TOTAL_CREDITONull && !original.IsMONTO_TOTAL_CREDITONull)
				if (this.MONTO_TOTAL_CREDITO != original.MONTO_TOTAL_CREDITO) return true;
			if (this.PERSONA_ORIGEN_ID != original.PERSONA_ORIGEN_ID) return true;
			if (this.PERSONA_DESTINO_ID != original.PERSONA_DESTINO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsFECHA_VENCIMIENTO_DESTINONull != original.IsFECHA_VENCIMIENTO_DESTINONull) return true;
			if (!this.IsFECHA_VENCIMIENTO_DESTINONull && !original.IsFECHA_VENCIMIENTO_DESTINONull)
				if (this.FECHA_VENCIMIENTO_DESTINO != original.FECHA_VENCIMIENTO_DESTINO) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsMONTO_TOTAL_DEBITONull != original.IsMONTO_TOTAL_DEBITONull) return true;
			if (!this.IsMONTO_TOTAL_DEBITONull && !original.IsMONTO_TOTAL_DEBITONull)
				if (this.MONTO_TOTAL_DEBITO != original.MONTO_TOTAL_DEBITO) return true;
			
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL_CREDITO</c> column value.</value>
		public decimal MONTO_TOTAL_CREDITO
		{
			get
			{
				if(IsMONTO_TOTAL_CREDITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total_credito;
			}
			set
			{
				_monto_total_creditoNull = false;
				_monto_total_credito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL_CREDITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTAL_CREDITONull
		{
			get { return _monto_total_creditoNull; }
			set { _monto_total_creditoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ORIGEN_ID</c> column value.</value>
		public decimal PERSONA_ORIGEN_ID
		{
			get { return _persona_origen_id; }
			set { _persona_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_DESTINO_ID</c> column value.</value>
		public decimal PERSONA_DESTINO_ID
		{
			get { return _persona_destino_id; }
			set { _persona_destino_id = value; }
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
		/// Gets or sets the <c>FECHA_VENCIMIENTO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_VENCIMIENTO_DESTINO</c> column value.</value>
		public System.DateTime FECHA_VENCIMIENTO_DESTINO
		{
			get
			{
				if(IsFECHA_VENCIMIENTO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_vencimiento_destino;
			}
			set
			{
				_fecha_vencimiento_destinoNull = false;
				_fecha_vencimiento_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_VENCIMIENTO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_VENCIMIENTO_DESTINONull
		{
			get { return _fecha_vencimiento_destinoNull; }
			set { _fecha_vencimiento_destinoNull = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL_DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL_DEBITO</c> column value.</value>
		public decimal MONTO_TOTAL_DEBITO
		{
			get
			{
				if(IsMONTO_TOTAL_DEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total_debito;
			}
			set
			{
				_monto_total_debitoNull = false;
				_monto_total_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL_DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTAL_DEBITONull
		{
			get { return _monto_total_debitoNull; }
			set { _monto_total_debitoNull = value; }
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
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@MONTO_TOTAL_CREDITO=");
			dynStr.Append(IsMONTO_TOTAL_CREDITONull ? (object)"<NULL>" : MONTO_TOTAL_CREDITO);
			dynStr.Append("@CBA@PERSONA_ORIGEN_ID=");
			dynStr.Append(PERSONA_ORIGEN_ID);
			dynStr.Append("@CBA@PERSONA_DESTINO_ID=");
			dynStr.Append(PERSONA_DESTINO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@FECHA_VENCIMIENTO_DESTINO=");
			dynStr.Append(IsFECHA_VENCIMIENTO_DESTINONull ? (object)"<NULL>" : FECHA_VENCIMIENTO_DESTINO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONTO_TOTAL_DEBITO=");
			dynStr.Append(IsMONTO_TOTAL_DEBITONull ? (object)"<NULL>" : MONTO_TOTAL_DEBITO);
			return dynStr.ToString();
		}
	} // End of TRANSFERENCIA_CTACTE_PERSONARow_Base class
} // End of namespace
