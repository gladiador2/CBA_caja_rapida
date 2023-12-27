// <fileinfo name="IMPORTACIONES_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>IMPORTACIONES_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACIONES_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private System.DateTime _fecha_salida;
		private bool _fecha_salidaNull = true;
		private string _documentos;
		private string _numero_bl;
		private System.DateTime _fecha_llegada_sitio_intermedio;
		private bool _fecha_llegada_sitio_intermedioNull = true;
		private System.DateTime _fecha_llegada_destino_final;
		private bool _fecha_llegada_destino_finalNull = true;
		private string _embarcador;
		private string _se_puede_modificar;
		private string _finalizado;
		private string _nombre_interno;
		private decimal _moneda_pais_id;
		private bool _moneda_pais_idNull = true;
		private decimal _moneda_pais_cotizacion;
		private bool _moneda_pais_cotizacionNull = true;
		private decimal _total_gasto;
		private bool _total_gastoNull = true;
		private decimal _total_factura;
		private bool _total_facturaNull = true;
		private decimal _total_impuesto_factura;
		private bool _total_impuesto_facturaNull = true;
		private decimal _total_impuesto_gasto;
		private bool _total_impuesto_gastoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public IMPORTACIONES_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACIONES_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFECHA_SALIDANull != original.IsFECHA_SALIDANull) return true;
			if (!this.IsFECHA_SALIDANull && !original.IsFECHA_SALIDANull)
				if (this.FECHA_SALIDA != original.FECHA_SALIDA) return true;
			if (this.DOCUMENTOS != original.DOCUMENTOS) return true;
			if (this.NUMERO_BL != original.NUMERO_BL) return true;
			if (this.IsFECHA_LLEGADA_SITIO_INTERMEDIONull != original.IsFECHA_LLEGADA_SITIO_INTERMEDIONull) return true;
			if (!this.IsFECHA_LLEGADA_SITIO_INTERMEDIONull && !original.IsFECHA_LLEGADA_SITIO_INTERMEDIONull)
				if (this.FECHA_LLEGADA_SITIO_INTERMEDIO != original.FECHA_LLEGADA_SITIO_INTERMEDIO) return true;
			if (this.IsFECHA_LLEGADA_DESTINO_FINALNull != original.IsFECHA_LLEGADA_DESTINO_FINALNull) return true;
			if (!this.IsFECHA_LLEGADA_DESTINO_FINALNull && !original.IsFECHA_LLEGADA_DESTINO_FINALNull)
				if (this.FECHA_LLEGADA_DESTINO_FINAL != original.FECHA_LLEGADA_DESTINO_FINAL) return true;
			if (this.EMBARCADOR != original.EMBARCADOR) return true;
			if (this.SE_PUEDE_MODIFICAR != original.SE_PUEDE_MODIFICAR) return true;
			if (this.FINALIZADO != original.FINALIZADO) return true;
			if (this.NOMBRE_INTERNO != original.NOMBRE_INTERNO) return true;
			if (this.IsMONEDA_PAIS_IDNull != original.IsMONEDA_PAIS_IDNull) return true;
			if (!this.IsMONEDA_PAIS_IDNull && !original.IsMONEDA_PAIS_IDNull)
				if (this.MONEDA_PAIS_ID != original.MONEDA_PAIS_ID) return true;
			if (this.IsMONEDA_PAIS_COTIZACIONNull != original.IsMONEDA_PAIS_COTIZACIONNull) return true;
			if (!this.IsMONEDA_PAIS_COTIZACIONNull && !original.IsMONEDA_PAIS_COTIZACIONNull)
				if (this.MONEDA_PAIS_COTIZACION != original.MONEDA_PAIS_COTIZACION) return true;
			if (this.IsTOTAL_GASTONull != original.IsTOTAL_GASTONull) return true;
			if (!this.IsTOTAL_GASTONull && !original.IsTOTAL_GASTONull)
				if (this.TOTAL_GASTO != original.TOTAL_GASTO) return true;
			if (this.IsTOTAL_FACTURANull != original.IsTOTAL_FACTURANull) return true;
			if (!this.IsTOTAL_FACTURANull && !original.IsTOTAL_FACTURANull)
				if (this.TOTAL_FACTURA != original.TOTAL_FACTURA) return true;
			if (this.IsTOTAL_IMPUESTO_FACTURANull != original.IsTOTAL_IMPUESTO_FACTURANull) return true;
			if (!this.IsTOTAL_IMPUESTO_FACTURANull && !original.IsTOTAL_IMPUESTO_FACTURANull)
				if (this.TOTAL_IMPUESTO_FACTURA != original.TOTAL_IMPUESTO_FACTURA) return true;
			if (this.IsTOTAL_IMPUESTO_GASTONull != original.IsTOTAL_IMPUESTO_GASTONull) return true;
			if (!this.IsTOTAL_IMPUESTO_GASTONull && !original.IsTOTAL_IMPUESTO_GASTONull)
				if (this.TOTAL_IMPUESTO_GASTO != original.TOTAL_IMPUESTO_GASTO) return true;
			
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
		/// Gets or sets the <c>FECHA_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA</c> column value.</value>
		public System.DateTime FECHA_SALIDA
		{
			get
			{
				if(IsFECHA_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida;
			}
			set
			{
				_fecha_salidaNull = false;
				_fecha_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDANull
		{
			get { return _fecha_salidaNull; }
			set { _fecha_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DOCUMENTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DOCUMENTOS</c> column value.</value>
		public string DOCUMENTOS
		{
			get { return _documentos; }
			set { _documentos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_BL</c> column value.</value>
		public string NUMERO_BL
		{
			get { return _numero_bl; }
			set { _numero_bl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_LLEGADA_SITIO_INTERMEDIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_LLEGADA_SITIO_INTERMEDIO</c> column value.</value>
		public System.DateTime FECHA_LLEGADA_SITIO_INTERMEDIO
		{
			get
			{
				if(IsFECHA_LLEGADA_SITIO_INTERMEDIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_llegada_sitio_intermedio;
			}
			set
			{
				_fecha_llegada_sitio_intermedioNull = false;
				_fecha_llegada_sitio_intermedio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_LLEGADA_SITIO_INTERMEDIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_LLEGADA_SITIO_INTERMEDIONull
		{
			get { return _fecha_llegada_sitio_intermedioNull; }
			set { _fecha_llegada_sitio_intermedioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_LLEGADA_DESTINO_FINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_LLEGADA_DESTINO_FINAL</c> column value.</value>
		public System.DateTime FECHA_LLEGADA_DESTINO_FINAL
		{
			get
			{
				if(IsFECHA_LLEGADA_DESTINO_FINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_llegada_destino_final;
			}
			set
			{
				_fecha_llegada_destino_finalNull = false;
				_fecha_llegada_destino_final = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_LLEGADA_DESTINO_FINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_LLEGADA_DESTINO_FINALNull
		{
			get { return _fecha_llegada_destino_finalNull; }
			set { _fecha_llegada_destino_finalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMBARCADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMBARCADOR</c> column value.</value>
		public string EMBARCADOR
		{
			get { return _embarcador; }
			set { _embarcador = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SE_PUEDE_MODIFICAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SE_PUEDE_MODIFICAR</c> column value.</value>
		public string SE_PUEDE_MODIFICAR
		{
			get { return _se_puede_modificar; }
			set { _se_puede_modificar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FINALIZADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FINALIZADO</c> column value.</value>
		public string FINALIZADO
		{
			get { return _finalizado; }
			set { _finalizado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_INTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_INTERNO</c> column value.</value>
		public string NOMBRE_INTERNO
		{
			get { return _nombre_interno; }
			set { _nombre_interno = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PAIS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_PAIS_ID</c> column value.</value>
		public decimal MONEDA_PAIS_ID
		{
			get
			{
				if(IsMONEDA_PAIS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_pais_id;
			}
			set
			{
				_moneda_pais_idNull = false;
				_moneda_pais_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_PAIS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_PAIS_IDNull
		{
			get { return _moneda_pais_idNull; }
			set { _moneda_pais_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PAIS_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_PAIS_COTIZACION</c> column value.</value>
		public decimal MONEDA_PAIS_COTIZACION
		{
			get
			{
				if(IsMONEDA_PAIS_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_pais_cotizacion;
			}
			set
			{
				_moneda_pais_cotizacionNull = false;
				_moneda_pais_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_PAIS_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_PAIS_COTIZACIONNull
		{
			get { return _moneda_pais_cotizacionNull; }
			set { _moneda_pais_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_GASTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_GASTO</c> column value.</value>
		public decimal TOTAL_GASTO
		{
			get
			{
				if(IsTOTAL_GASTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_gasto;
			}
			set
			{
				_total_gastoNull = false;
				_total_gasto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_GASTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_GASTONull
		{
			get { return _total_gastoNull; }
			set { _total_gastoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_FACTURA</c> column value.</value>
		public decimal TOTAL_FACTURA
		{
			get
			{
				if(IsTOTAL_FACTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_factura;
			}
			set
			{
				_total_facturaNull = false;
				_total_factura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_FACTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_FACTURANull
		{
			get { return _total_facturaNull; }
			set { _total_facturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO_FACTURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO_FACTURA</c> column value.</value>
		public decimal TOTAL_IMPUESTO_FACTURA
		{
			get
			{
				if(IsTOTAL_IMPUESTO_FACTURANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto_factura;
			}
			set
			{
				_total_impuesto_facturaNull = false;
				_total_impuesto_factura = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO_FACTURA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTO_FACTURANull
		{
			get { return _total_impuesto_facturaNull; }
			set { _total_impuesto_facturaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_IMPUESTO_GASTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_IMPUESTO_GASTO</c> column value.</value>
		public decimal TOTAL_IMPUESTO_GASTO
		{
			get
			{
				if(IsTOTAL_IMPUESTO_GASTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_impuesto_gasto;
			}
			set
			{
				_total_impuesto_gastoNull = false;
				_total_impuesto_gasto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_IMPUESTO_GASTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_IMPUESTO_GASTONull
		{
			get { return _total_impuesto_gastoNull; }
			set { _total_impuesto_gastoNull = value; }
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
			dynStr.Append("@CBA@FECHA_SALIDA=");
			dynStr.Append(IsFECHA_SALIDANull ? (object)"<NULL>" : FECHA_SALIDA);
			dynStr.Append("@CBA@DOCUMENTOS=");
			dynStr.Append(DOCUMENTOS);
			dynStr.Append("@CBA@NUMERO_BL=");
			dynStr.Append(NUMERO_BL);
			dynStr.Append("@CBA@FECHA_LLEGADA_SITIO_INTERMEDIO=");
			dynStr.Append(IsFECHA_LLEGADA_SITIO_INTERMEDIONull ? (object)"<NULL>" : FECHA_LLEGADA_SITIO_INTERMEDIO);
			dynStr.Append("@CBA@FECHA_LLEGADA_DESTINO_FINAL=");
			dynStr.Append(IsFECHA_LLEGADA_DESTINO_FINALNull ? (object)"<NULL>" : FECHA_LLEGADA_DESTINO_FINAL);
			dynStr.Append("@CBA@EMBARCADOR=");
			dynStr.Append(EMBARCADOR);
			dynStr.Append("@CBA@SE_PUEDE_MODIFICAR=");
			dynStr.Append(SE_PUEDE_MODIFICAR);
			dynStr.Append("@CBA@FINALIZADO=");
			dynStr.Append(FINALIZADO);
			dynStr.Append("@CBA@NOMBRE_INTERNO=");
			dynStr.Append(NOMBRE_INTERNO);
			dynStr.Append("@CBA@MONEDA_PAIS_ID=");
			dynStr.Append(IsMONEDA_PAIS_IDNull ? (object)"<NULL>" : MONEDA_PAIS_ID);
			dynStr.Append("@CBA@MONEDA_PAIS_COTIZACION=");
			dynStr.Append(IsMONEDA_PAIS_COTIZACIONNull ? (object)"<NULL>" : MONEDA_PAIS_COTIZACION);
			dynStr.Append("@CBA@TOTAL_GASTO=");
			dynStr.Append(IsTOTAL_GASTONull ? (object)"<NULL>" : TOTAL_GASTO);
			dynStr.Append("@CBA@TOTAL_FACTURA=");
			dynStr.Append(IsTOTAL_FACTURANull ? (object)"<NULL>" : TOTAL_FACTURA);
			dynStr.Append("@CBA@TOTAL_IMPUESTO_FACTURA=");
			dynStr.Append(IsTOTAL_IMPUESTO_FACTURANull ? (object)"<NULL>" : TOTAL_IMPUESTO_FACTURA);
			dynStr.Append("@CBA@TOTAL_IMPUESTO_GASTO=");
			dynStr.Append(IsTOTAL_IMPUESTO_GASTONull ? (object)"<NULL>" : TOTAL_IMPUESTO_GASTO);
			return dynStr.ToString();
		}
	} // End of IMPORTACIONES_INFO_COMPLETARow_Base class
} // End of namespace
