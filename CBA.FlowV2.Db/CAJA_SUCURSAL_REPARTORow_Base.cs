// <fileinfo name="CAJA_SUCURSAL_REPARTORow_Base.cs">
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
	/// The base class for <see cref="CAJA_SUCURSAL_REPARTORow"/> that 
	/// represents a record in the <c>CAJA_SUCURSAL_REPARTO</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAJA_SUCURSAL_REPARTORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAJA_SUCURSAL_REPARTORow_Base
	{
		private decimal _caja_id;
		private decimal _reparto_id;
		private decimal _reparto_caso;
		private bool _reparto_casoNull = true;
		private string _fecha_inicio;
		private string _chofer;
		private string _vehiculo;
		private string _nro_comprobante;
		private string _persona_nombre_completo;
		private string _persona_codigo;
		private string _moneda_simbolo;
		private decimal _cotizacion_destino;
		private bool _cotizacion_destinoNull = true;
		private string _moneda_cadena_decimales;
		private decimal _total_monto_bruto;
		private bool _total_monto_brutoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAJA_SUCURSAL_REPARTORow_Base"/> class.
		/// </summary>
		public CAJA_SUCURSAL_REPARTORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAJA_SUCURSAL_REPARTORow_Base original)
		{
			if (this.CAJA_ID != original.CAJA_ID) return true;
			if (this.REPARTO_ID != original.REPARTO_ID) return true;
			if (this.IsREPARTO_CASONull != original.IsREPARTO_CASONull) return true;
			if (!this.IsREPARTO_CASONull && !original.IsREPARTO_CASONull)
				if (this.REPARTO_CASO != original.REPARTO_CASO) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.CHOFER != original.CHOFER) return true;
			if (this.VEHICULO != original.VEHICULO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.MONEDA_SIMBOLO != original.MONEDA_SIMBOLO) return true;
			if (this.IsCOTIZACION_DESTINONull != original.IsCOTIZACION_DESTINONull) return true;
			if (!this.IsCOTIZACION_DESTINONull && !original.IsCOTIZACION_DESTINONull)
				if (this.COTIZACION_DESTINO != original.COTIZACION_DESTINO) return true;
			if (this.MONEDA_CADENA_DECIMALES != original.MONEDA_CADENA_DECIMALES) return true;
			if (this.IsTOTAL_MONTO_BRUTONull != original.IsTOTAL_MONTO_BRUTONull) return true;
			if (!this.IsTOTAL_MONTO_BRUTONull && !original.IsTOTAL_MONTO_BRUTONull)
				if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>CAJA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAJA_ID</c> column value.</value>
		public decimal CAJA_ID
		{
			get { return _caja_id; }
			set { _caja_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPARTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REPARTO_ID</c> column value.</value>
		public decimal REPARTO_ID
		{
			get { return _reparto_id; }
			set { _reparto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REPARTO_CASO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REPARTO_CASO</c> column value.</value>
		public decimal REPARTO_CASO
		{
			get
			{
				if(IsREPARTO_CASONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reparto_caso;
			}
			set
			{
				_reparto_casoNull = false;
				_reparto_caso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REPARTO_CASO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREPARTO_CASONull
		{
			get { return _reparto_casoNull; }
			set { _reparto_casoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public string FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHOFER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHOFER</c> column value.</value>
		public string CHOFER
		{
			get { return _chofer; }
			set { _chofer = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VEHICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VEHICULO</c> column value.</value>
		public string VEHICULO
		{
			get { return _vehiculo; }
			set { _vehiculo = value; }
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
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_SIMBOLO</c> column value.</value>
		public string MONEDA_SIMBOLO
		{
			get { return _moneda_simbolo; }
			set { _moneda_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_DESTINO</c> column value.</value>
		public decimal COTIZACION_DESTINO
		{
			get
			{
				if(IsCOTIZACION_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_destino;
			}
			set
			{
				_cotizacion_destinoNull = false;
				_cotizacion_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_DESTINONull
		{
			get { return _cotizacion_destinoNull; }
			set { _cotizacion_destinoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_CADENA_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_CADENA_DECIMALES</c> column value.</value>
		public string MONEDA_CADENA_DECIMALES
		{
			get { return _moneda_cadena_decimales; }
			set { _moneda_cadena_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get
			{
				if(IsTOTAL_MONTO_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_bruto;
			}
			set
			{
				_total_monto_brutoNull = false;
				_total_monto_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_BRUTONull
		{
			get { return _total_monto_brutoNull; }
			set { _total_monto_brutoNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@CAJA_ID=");
			dynStr.Append(CAJA_ID);
			dynStr.Append("@CBA@REPARTO_ID=");
			dynStr.Append(REPARTO_ID);
			dynStr.Append("@CBA@REPARTO_CASO=");
			dynStr.Append(IsREPARTO_CASONull ? (object)"<NULL>" : REPARTO_CASO);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@CHOFER=");
			dynStr.Append(CHOFER);
			dynStr.Append("@CBA@VEHICULO=");
			dynStr.Append(VEHICULO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@MONEDA_SIMBOLO=");
			dynStr.Append(MONEDA_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_DESTINO=");
			dynStr.Append(IsCOTIZACION_DESTINONull ? (object)"<NULL>" : COTIZACION_DESTINO);
			dynStr.Append("@CBA@MONEDA_CADENA_DECIMALES=");
			dynStr.Append(MONEDA_CADENA_DECIMALES);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(IsTOTAL_MONTO_BRUTONull ? (object)"<NULL>" : TOTAL_MONTO_BRUTO);
			return dynStr.ToString();
		}
	} // End of CAJA_SUCURSAL_REPARTORow_Base class
} // End of namespace
