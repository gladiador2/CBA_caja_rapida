// <fileinfo name="IMPORTACION_INGRESO_COSTOSRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACION_INGRESO_COSTOSRow"/> that 
	/// represents a record in the <c>IMPORTACION_INGRESO_COSTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACION_INGRESO_COSTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACION_INGRESO_COSTOSRow_Base
	{
		private decimal _id;
		private decimal _ingreso_stock_id;
		private bool _ingreso_stock_idNull = true;
		private decimal _ingreso_stock_detalle_id;
		private bool _ingreso_stock_detalle_idNull = true;
		private decimal _importacion_id;
		private bool _importacion_idNull = true;
		private decimal _importacion_gastos_id;
		private bool _importacion_gastos_idNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _porcentaje;
		private bool _porcentajeNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACION_INGRESO_COSTOSRow_Base"/> class.
		/// </summary>
		public IMPORTACION_INGRESO_COSTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACION_INGRESO_COSTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsINGRESO_STOCK_IDNull != original.IsINGRESO_STOCK_IDNull) return true;
			if (!this.IsINGRESO_STOCK_IDNull && !original.IsINGRESO_STOCK_IDNull)
				if (this.INGRESO_STOCK_ID != original.INGRESO_STOCK_ID) return true;
			if (this.IsINGRESO_STOCK_DETALLE_IDNull != original.IsINGRESO_STOCK_DETALLE_IDNull) return true;
			if (!this.IsINGRESO_STOCK_DETALLE_IDNull && !original.IsINGRESO_STOCK_DETALLE_IDNull)
				if (this.INGRESO_STOCK_DETALLE_ID != original.INGRESO_STOCK_DETALLE_ID) return true;
			if (this.IsIMPORTACION_IDNull != original.IsIMPORTACION_IDNull) return true;
			if (!this.IsIMPORTACION_IDNull && !original.IsIMPORTACION_IDNull)
				if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.IsIMPORTACION_GASTOS_IDNull != original.IsIMPORTACION_GASTOS_IDNull) return true;
			if (!this.IsIMPORTACION_GASTOS_IDNull && !original.IsIMPORTACION_GASTOS_IDNull)
				if (this.IMPORTACION_GASTOS_ID != original.IMPORTACION_GASTOS_ID) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsPORCENTAJENull != original.IsPORCENTAJENull) return true;
			if (!this.IsPORCENTAJENull && !original.IsPORCENTAJENull)
				if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			
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
		/// Gets or sets the <c>INGRESO_STOCK_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_STOCK_ID</c> column value.</value>
		public decimal INGRESO_STOCK_ID
		{
			get
			{
				if(IsINGRESO_STOCK_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_stock_id;
			}
			set
			{
				_ingreso_stock_idNull = false;
				_ingreso_stock_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_STOCK_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_STOCK_IDNull
		{
			get { return _ingreso_stock_idNull; }
			set { _ingreso_stock_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_STOCK_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</value>
		public decimal INGRESO_STOCK_DETALLE_ID
		{
			get
			{
				if(IsINGRESO_STOCK_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ingreso_stock_detalle_id;
			}
			set
			{
				_ingreso_stock_detalle_idNull = false;
				_ingreso_stock_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INGRESO_STOCK_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINGRESO_STOCK_DETALLE_IDNull
		{
			get { return _ingreso_stock_detalle_idNull; }
			set { _ingreso_stock_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get
			{
				if(IsIMPORTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_id;
			}
			set
			{
				_importacion_idNull = false;
				_importacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_IDNull
		{
			get { return _importacion_idNull; }
			set { _importacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPORTACION_GASTOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPORTACION_GASTOS_ID</c> column value.</value>
		public decimal IMPORTACION_GASTOS_ID
		{
			get
			{
				if(IsIMPORTACION_GASTOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _importacion_gastos_id;
			}
			set
			{
				_importacion_gastos_idNull = false;
				_importacion_gastos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPORTACION_GASTOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPORTACION_GASTOS_IDNull
		{
			get { return _importacion_gastos_idNull; }
			set { _importacion_gastos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get
			{
				if(IsPORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje;
			}
			set
			{
				_porcentajeNull = false;
				_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJENull
		{
			get { return _porcentajeNull; }
			set { _porcentajeNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@INGRESO_STOCK_ID=");
			dynStr.Append(IsINGRESO_STOCK_IDNull ? (object)"<NULL>" : INGRESO_STOCK_ID);
			dynStr.Append("@CBA@INGRESO_STOCK_DETALLE_ID=");
			dynStr.Append(IsINGRESO_STOCK_DETALLE_IDNull ? (object)"<NULL>" : INGRESO_STOCK_DETALLE_ID);
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IsIMPORTACION_IDNull ? (object)"<NULL>" : IMPORTACION_ID);
			dynStr.Append("@CBA@IMPORTACION_GASTOS_ID=");
			dynStr.Append(IsIMPORTACION_GASTOS_IDNull ? (object)"<NULL>" : IMPORTACION_GASTOS_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(IsPORCENTAJENull ? (object)"<NULL>" : PORCENTAJE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			return dynStr.ToString();
		}
	} // End of IMPORTACION_INGRESO_COSTOSRow_Base class
} // End of namespace
