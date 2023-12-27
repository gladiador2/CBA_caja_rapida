// <fileinfo name="TRANSACCIONES_CIERRES_CASOSRow_Base.cs">
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
	/// The base class for <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> that 
	/// represents a record in the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSACCIONES_CIERRES_CASOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSACCIONES_CIERRES_CASOSRow_Base
	{
		private decimal _id;
		private decimal _transaccion_cierre_id;
		private decimal _flujo_id;
		private decimal _caso_id;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _monto_total;
		private bool _monto_totalNull = true;
		private decimal _comision_total;
		private bool _comision_totalNull = true;
		private decimal _comision_recaudador;
		private bool _comision_recaudadorNull = true;
		private decimal _comision_procesador;
		private bool _comision_procesadorNull = true;
		private decimal _comision_clearing;
		private bool _comision_clearingNull = true;
		private decimal _comision_otro;
		private bool _comision_otroNull = true;
		private decimal _comision_red;
		private bool _comision_redNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONES_CIERRES_CASOSRow_Base"/> class.
		/// </summary>
		public TRANSACCIONES_CIERRES_CASOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSACCIONES_CIERRES_CASOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRANSACCION_CIERRE_ID != original.TRANSACCION_CIERRE_ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsMONTO_TOTALNull != original.IsMONTO_TOTALNull) return true;
			if (!this.IsMONTO_TOTALNull && !original.IsMONTO_TOTALNull)
				if (this.MONTO_TOTAL != original.MONTO_TOTAL) return true;
			if (this.IsCOMISION_TOTALNull != original.IsCOMISION_TOTALNull) return true;
			if (!this.IsCOMISION_TOTALNull && !original.IsCOMISION_TOTALNull)
				if (this.COMISION_TOTAL != original.COMISION_TOTAL) return true;
			if (this.IsCOMISION_RECAUDADORNull != original.IsCOMISION_RECAUDADORNull) return true;
			if (!this.IsCOMISION_RECAUDADORNull && !original.IsCOMISION_RECAUDADORNull)
				if (this.COMISION_RECAUDADOR != original.COMISION_RECAUDADOR) return true;
			if (this.IsCOMISION_PROCESADORNull != original.IsCOMISION_PROCESADORNull) return true;
			if (!this.IsCOMISION_PROCESADORNull && !original.IsCOMISION_PROCESADORNull)
				if (this.COMISION_PROCESADOR != original.COMISION_PROCESADOR) return true;
			if (this.IsCOMISION_CLEARINGNull != original.IsCOMISION_CLEARINGNull) return true;
			if (!this.IsCOMISION_CLEARINGNull && !original.IsCOMISION_CLEARINGNull)
				if (this.COMISION_CLEARING != original.COMISION_CLEARING) return true;
			if (this.IsCOMISION_OTRONull != original.IsCOMISION_OTRONull) return true;
			if (!this.IsCOMISION_OTRONull && !original.IsCOMISION_OTRONull)
				if (this.COMISION_OTRO != original.COMISION_OTRO) return true;
			if (this.IsCOMISION_REDNull != original.IsCOMISION_REDNull) return true;
			if (!this.IsCOMISION_REDNull && !original.IsCOMISION_REDNull)
				if (this.COMISION_RED != original.COMISION_RED) return true;
			
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
		/// Gets or sets the <c>TRANSACCION_CIERRE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRANSACCION_CIERRE_ID</c> column value.</value>
		public decimal TRANSACCION_CIERRE_ID
		{
			get { return _transaccion_cierre_id; }
			set { _transaccion_cierre_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
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
		/// Gets or sets the <c>MONTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOTAL</c> column value.</value>
		public decimal MONTO_TOTAL
		{
			get
			{
				if(IsMONTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_total;
			}
			set
			{
				_monto_totalNull = false;
				_monto_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOTALNull
		{
			get { return _monto_totalNull; }
			set { _monto_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_TOTAL</c> column value.</value>
		public decimal COMISION_TOTAL
		{
			get
			{
				if(IsCOMISION_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_total;
			}
			set
			{
				_comision_totalNull = false;
				_comision_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_TOTALNull
		{
			get { return _comision_totalNull; }
			set { _comision_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_RECAUDADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_RECAUDADOR</c> column value.</value>
		public decimal COMISION_RECAUDADOR
		{
			get
			{
				if(IsCOMISION_RECAUDADORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_recaudador;
			}
			set
			{
				_comision_recaudadorNull = false;
				_comision_recaudador = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_RECAUDADOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_RECAUDADORNull
		{
			get { return _comision_recaudadorNull; }
			set { _comision_recaudadorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_PROCESADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_PROCESADOR</c> column value.</value>
		public decimal COMISION_PROCESADOR
		{
			get
			{
				if(IsCOMISION_PROCESADORNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_procesador;
			}
			set
			{
				_comision_procesadorNull = false;
				_comision_procesador = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_PROCESADOR"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_PROCESADORNull
		{
			get { return _comision_procesadorNull; }
			set { _comision_procesadorNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_CLEARING</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_CLEARING</c> column value.</value>
		public decimal COMISION_CLEARING
		{
			get
			{
				if(IsCOMISION_CLEARINGNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_clearing;
			}
			set
			{
				_comision_clearingNull = false;
				_comision_clearing = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_CLEARING"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_CLEARINGNull
		{
			get { return _comision_clearingNull; }
			set { _comision_clearingNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_OTRO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_OTRO</c> column value.</value>
		public decimal COMISION_OTRO
		{
			get
			{
				if(IsCOMISION_OTRONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_otro;
			}
			set
			{
				_comision_otroNull = false;
				_comision_otro = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_OTRO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_OTRONull
		{
			get { return _comision_otroNull; }
			set { _comision_otroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMISION_RED</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMISION_RED</c> column value.</value>
		public decimal COMISION_RED
		{
			get
			{
				if(IsCOMISION_REDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comision_red;
			}
			set
			{
				_comision_redNull = false;
				_comision_red = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMISION_RED"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMISION_REDNull
		{
			get { return _comision_redNull; }
			set { _comision_redNull = value; }
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
			dynStr.Append("@CBA@TRANSACCION_CIERRE_ID=");
			dynStr.Append(TRANSACCION_CIERRE_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@MONTO_TOTAL=");
			dynStr.Append(IsMONTO_TOTALNull ? (object)"<NULL>" : MONTO_TOTAL);
			dynStr.Append("@CBA@COMISION_TOTAL=");
			dynStr.Append(IsCOMISION_TOTALNull ? (object)"<NULL>" : COMISION_TOTAL);
			dynStr.Append("@CBA@COMISION_RECAUDADOR=");
			dynStr.Append(IsCOMISION_RECAUDADORNull ? (object)"<NULL>" : COMISION_RECAUDADOR);
			dynStr.Append("@CBA@COMISION_PROCESADOR=");
			dynStr.Append(IsCOMISION_PROCESADORNull ? (object)"<NULL>" : COMISION_PROCESADOR);
			dynStr.Append("@CBA@COMISION_CLEARING=");
			dynStr.Append(IsCOMISION_CLEARINGNull ? (object)"<NULL>" : COMISION_CLEARING);
			dynStr.Append("@CBA@COMISION_OTRO=");
			dynStr.Append(IsCOMISION_OTRONull ? (object)"<NULL>" : COMISION_OTRO);
			dynStr.Append("@CBA@COMISION_RED=");
			dynStr.Append(IsCOMISION_REDNull ? (object)"<NULL>" : COMISION_RED);
			return dynStr.ToString();
		}
	} // End of TRANSACCIONES_CIERRES_CASOSRow_Base class
} // End of namespace
