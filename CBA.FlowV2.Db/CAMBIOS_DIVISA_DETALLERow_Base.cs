// <fileinfo name="CAMBIOS_DIVISA_DETALLERow_Base.cs">
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
	/// The base class for <see cref="CAMBIOS_DIVISA_DETALLERow"/> that 
	/// represents a record in the <c>CAMBIOS_DIVISA_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CAMBIOS_DIVISA_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMBIOS_DIVISA_DETALLERow_Base
	{
		private decimal _id;
		private decimal _cambio_divisa_id;
		private decimal _moneda_origen_id;
		private decimal _cotizacion_moneda_origen;
		private decimal _moneda_destino_id;
		private decimal _cotizacion_moneda_destino;
		private decimal _monto_origen;
		private decimal _monto_destino;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMBIOS_DIVISA_DETALLERow_Base"/> class.
		/// </summary>
		public CAMBIOS_DIVISA_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CAMBIOS_DIVISA_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CAMBIO_DIVISA_ID != original.CAMBIO_DIVISA_ID) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.MONEDA_DESTINO_ID != original.MONEDA_DESTINO_ID) return true;
			if (this.COTIZACION_MONEDA_DESTINO != original.COTIZACION_MONEDA_DESTINO) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			
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
		/// Gets or sets the <c>CAMBIO_DIVISA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CAMBIO_DIVISA_ID</c> column value.</value>
		public decimal CAMBIO_DIVISA_ID
		{
			get { return _cambio_divisa_id; }
			set { _cambio_divisa_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get { return _moneda_origen_id; }
			set { _moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get { return _cotizacion_moneda_origen; }
			set { _cotizacion_moneda_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_DESTINO_ID</c> column value.</value>
		public decimal MONEDA_DESTINO_ID
		{
			get { return _moneda_destino_id; }
			set { _moneda_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_DESTINO</c> column value.</value>
		public decimal COTIZACION_MONEDA_DESTINO
		{
			get { return _cotizacion_moneda_destino; }
			set { _cotizacion_moneda_destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get { return _monto_origen; }
			set { _monto_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get { return _monto_destino; }
			set { _monto_destino = value; }
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
			dynStr.Append("@CBA@CAMBIO_DIVISA_ID=");
			dynStr.Append(CAMBIO_DIVISA_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONEDA_DESTINO_ID=");
			dynStr.Append(MONEDA_DESTINO_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_DESTINO=");
			dynStr.Append(COTIZACION_MONEDA_DESTINO);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(MONTO_DESTINO);
			return dynStr.ToString();
		}
	} // End of CAMBIOS_DIVISA_DETALLERow_Base class
} // End of namespace
