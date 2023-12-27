// <fileinfo name="DESEMBOLSOS_GIROS_DETRow_Base.cs">
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
	/// The base class for <see cref="DESEMBOLSOS_GIROS_DETRow"/> that 
	/// represents a record in the <c>DESEMBOLSOS_GIROS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DESEMBOLSOS_GIROS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEMBOLSOS_GIROS_DETRow_Base
	{
		private decimal _id;
		private decimal _desembolso_giro_id;
		private decimal _ctacte_giros_movimiento_id;
		private decimal _monto_origen;
		private decimal _moneda_origen_id;
		private decimal _cotizacion_moneda_origen;
		private decimal _monto_destino;
		private bool _monto_destinoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROS_DETRow_Base"/> class.
		/// </summary>
		public DESEMBOLSOS_GIROS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DESEMBOLSOS_GIROS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.DESEMBOLSO_GIRO_ID != original.DESEMBOLSO_GIRO_ID) return true;
			if (this.CTACTE_GIROS_MOVIMIENTO_ID != original.CTACTE_GIROS_MOVIMIENTO_ID) return true;
			if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.IsMONTO_DESTINONull != original.IsMONTO_DESTINONull) return true;
			if (!this.IsMONTO_DESTINONull && !original.IsMONTO_DESTINONull)
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
		/// Gets or sets the <c>DESEMBOLSO_GIRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DESEMBOLSO_GIRO_ID</c> column value.</value>
		public decimal DESEMBOLSO_GIRO_ID
		{
			get { return _desembolso_giro_id; }
			set { _desembolso_giro_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</value>
		public decimal CTACTE_GIROS_MOVIMIENTO_ID
		{
			get { return _ctacte_giros_movimiento_id; }
			set { _ctacte_giros_movimiento_id = value; }
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
		/// Gets or sets the <c>MONTO_DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_DESTINO</c> column value.</value>
		public decimal MONTO_DESTINO
		{
			get
			{
				if(IsMONTO_DESTINONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_destino;
			}
			set
			{
				_monto_destinoNull = false;
				_monto_destino = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_DESTINO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_DESTINONull
		{
			get { return _monto_destinoNull; }
			set { _monto_destinoNull = value; }
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
			dynStr.Append("@CBA@DESEMBOLSO_GIRO_ID=");
			dynStr.Append(DESEMBOLSO_GIRO_ID);
			dynStr.Append("@CBA@CTACTE_GIROS_MOVIMIENTO_ID=");
			dynStr.Append(CTACTE_GIROS_MOVIMIENTO_ID);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(MONTO_ORIGEN);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(IsMONTO_DESTINONull ? (object)"<NULL>" : MONTO_DESTINO);
			return dynStr.ToString();
		}
	} // End of DESEMBOLSOS_GIROS_DETRow_Base class
} // End of namespace
