// <fileinfo name="EGRESOS_VARIOS_CAJARow_Base.cs">
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
	/// The base class for <see cref="EGRESOS_VARIOS_CAJARow"/> that 
	/// represents a record in the <c>EGRESOS_VARIOS_CAJA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EGRESOS_VARIOS_CAJARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESOS_VARIOS_CAJARow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private System.DateTime _fecha;
		private decimal _autonumeracion_id;
		private string _nro_comprobante;
		private decimal _moneda_id;
		private decimal _cotizacion_moneda;
		private string _nombre_beneficiario;
		private System.DateTime _fecha_recibo_beneficiario;
		private bool _fecha_recibo_beneficiarioNull = true;
		private string _nro_recibo_beneficiario;
		private decimal _monto_total;
		private string _observacion;
		private string _gasto_directivo;
		private decimal _retencion_autonumeracion_id;
		private bool _retencion_autonumeracion_idNull = true;
		private string _retencion_unificada;
		private decimal _ctacte_caja_sucursal_id;
		private bool _ctacte_caja_sucursal_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJARow_Base"/> class.
		/// </summary>
		public EGRESOS_VARIOS_CAJARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EGRESOS_VARIOS_CAJARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.NOMBRE_BENEFICIARIO != original.NOMBRE_BENEFICIARIO) return true;
			if (this.IsFECHA_RECIBO_BENEFICIARIONull != original.IsFECHA_RECIBO_BENEFICIARIONull) return true;
			if (!this.IsFECHA_RECIBO_BENEFICIARIONull && !original.IsFECHA_RECIBO_BENEFICIARIONull)
				if (this.FECHA_RECIBO_BENEFICIARIO != original.FECHA_RECIBO_BENEFICIARIO) return true;
			if (this.NRO_RECIBO_BENEFICIARIO != original.NRO_RECIBO_BENEFICIARIO) return true;
			if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.GASTO_DIRECTIVO != original.GASTO_DIRECTIVO) return true;
			if (this.IsRETENCION_AUTONUMERACION_IDNull != original.IsRETENCION_AUTONUMERACION_IDNull) return true;
			if (!this.IsRETENCION_AUTONUMERACION_IDNull && !original.IsRETENCION_AUTONUMERACION_IDNull)
				if (this.RETENCION_AUTONUMERACION_ID != original.RETENCION_AUTONUMERACION_ID) return true;
			if (this.RETENCION_UNIFICADA != original.RETENCION_UNIFICADA) return true;
			if (this.IsCTACTE_CAJA_SUCURSAL_IDNull != original.IsCTACTE_CAJA_SUCURSAL_IDNull) return true;
			if (!this.IsCTACTE_CAJA_SUCURSAL_IDNull && !original.IsCTACTE_CAJA_SUCURSAL_IDNull)
				if (this.CTACTE_CAJA_SUCURSAL_ID != original.CTACTE_CAJA_SUCURSAL_ID) return true;
			
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
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ID</c> column value.</value>
		public decimal CTACTE_FONDO_FIJO_ID
		{
			get
			{
				if(IsCTACTE_FONDO_FIJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fondo_fijo_id;
			}
			set
			{
				_ctacte_fondo_fijo_idNull = false;
				_ctacte_fondo_fijo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FONDO_FIJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FONDO_FIJO_IDNull
		{
			get { return _ctacte_fondo_fijo_idNull; }
			set { _ctacte_fondo_fijo_idNull = value; }
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
		/// Gets or sets the <c>AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_ID</c> column value.</value>
		public decimal AUTONUMERACION_ID
		{
			get { return _autonumeracion_id; }
			set { _autonumeracion_id = value; }
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
		/// Gets or sets the <c>NOMBRE_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_BENEFICIARIO</c> column value.</value>
		public string NOMBRE_BENEFICIARIO
		{
			get { return _nombre_beneficiario; }
			set { _nombre_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_RECIBO_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_RECIBO_BENEFICIARIO</c> column value.</value>
		public System.DateTime FECHA_RECIBO_BENEFICIARIO
		{
			get
			{
				if(IsFECHA_RECIBO_BENEFICIARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_recibo_beneficiario;
			}
			set
			{
				_fecha_recibo_beneficiarioNull = false;
				_fecha_recibo_beneficiario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_RECIBO_BENEFICIARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_RECIBO_BENEFICIARIONull
		{
			get { return _fecha_recibo_beneficiarioNull; }
			set { _fecha_recibo_beneficiarioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_RECIBO_BENEFICIARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_RECIBO_BENEFICIARIO</c> column value.</value>
		public string NRO_RECIBO_BENEFICIARIO
		{
			get { return _nro_recibo_beneficiario; }
			set { _nro_recibo_beneficiario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get { return _monto_total; }
			set { _monto_total = value; }
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
		/// Gets or sets the <c>GASTO_DIRECTIVO</c> column value.
		/// </summary>
		/// <value>The <c>GASTO_DIRECTIVO</c> column value.</value>
		public string GASTO_DIRECTIVO
		{
			get { return _gasto_directivo; }
			set { _gasto_directivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_AUTONUMERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_AUTONUMERACION_ID</c> column value.</value>
		public decimal RETENCION_AUTONUMERACION_ID
		{
			get
			{
				if(IsRETENCION_AUTONUMERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _retencion_autonumeracion_id;
			}
			set
			{
				_retencion_autonumeracion_idNull = false;
				_retencion_autonumeracion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RETENCION_AUTONUMERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRETENCION_AUTONUMERACION_IDNull
		{
			get { return _retencion_autonumeracion_idNull; }
			set { _retencion_autonumeracion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RETENCION_UNIFICADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RETENCION_UNIFICADA</c> column value.</value>
		public string RETENCION_UNIFICADA
		{
			get { return _retencion_unificada; }
			set { _retencion_unificada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</value>
		public decimal CTACTE_CAJA_SUCURSAL_ID
		{
			get
			{
				if(IsCTACTE_CAJA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_sucursal_id;
			}
			set
			{
				_ctacte_caja_sucursal_idNull = false;
				_ctacte_caja_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_SUCURSAL_IDNull
		{
			get { return _ctacte_caja_sucursal_idNull; }
			set { _ctacte_caja_sucursal_idNull = value; }
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
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(AUTONUMERACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@NOMBRE_BENEFICIARIO=");
			dynStr.Append(NOMBRE_BENEFICIARIO);
			dynStr.Append("@CBA@FECHA_RECIBO_BENEFICIARIO=");
			dynStr.Append(IsFECHA_RECIBO_BENEFICIARIONull ? (object)"<NULL>" : FECHA_RECIBO_BENEFICIARIO);
			dynStr.Append("@CBA@NRO_RECIBO_BENEFICIARIO=");
			dynStr.Append(NRO_RECIBO_BENEFICIARIO);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(MONTO_TOTAL);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@GASTO_DIRECTIVO=");
			dynStr.Append(GASTO_DIRECTIVO);
			dynStr.Append("@CBA@RETENCION_AUTONUMERACION_ID=");
			dynStr.Append(IsRETENCION_AUTONUMERACION_IDNull ? (object)"<NULL>" : RETENCION_AUTONUMERACION_ID);
			dynStr.Append("@CBA@RETENCION_UNIFICADA=");
			dynStr.Append(RETENCION_UNIFICADA);
			dynStr.Append("@CBA@CTACTE_CAJA_SUCURSAL_ID=");
			dynStr.Append(IsCTACTE_CAJA_SUCURSAL_IDNull ? (object)"<NULL>" : CTACTE_CAJA_SUCURSAL_ID);
			return dynStr.ToString();
		}
	} // End of EGRESOS_VARIOS_CAJARow_Base class
} // End of namespace
