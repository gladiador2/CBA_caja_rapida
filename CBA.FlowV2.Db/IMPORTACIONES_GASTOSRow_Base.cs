// <fileinfo name="IMPORTACIONES_GASTOSRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_GASTOSRow"/> that 
	/// represents a record in the <c>IMPORTACIONES_GASTOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACIONES_GASTOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_GASTOSRow_Base
	{
		private decimal _id;
		private decimal _importacion_id;
		private bool _importacion_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private string _observacion;
		private decimal _monto_aplicable;
		private bool _monto_aplicableNull = true;
		private decimal _impuesto_monto;
		private bool _impuesto_montoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_GASTOSRow_Base"/> class.
		/// </summary>
		public IMPORTACIONES_GASTOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACIONES_GASTOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsIMPORTACION_IDNull != original.IsIMPORTACION_IDNull) return true;
			if (!this.IsIMPORTACION_IDNull && !original.IsIMPORTACION_IDNull)
				if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsMONTO_APLICABLENull != original.IsMONTO_APLICABLENull) return true;
			if (!this.IsMONTO_APLICABLENull && !original.IsMONTO_APLICABLENull)
				if (this.MONTO_APLICABLE != original.MONTO_APLICABLE) return true;
			if (this.IsIMPUESTO_MONTONull != original.IsIMPUESTO_MONTONull) return true;
			if (!this.IsIMPUESTO_MONTONull && !original.IsIMPUESTO_MONTONull)
				if (this.IMPUESTO_MONTO != original.IMPUESTO_MONTO) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
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
		/// Gets or sets the <c>MONTO_APLICABLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_APLICABLE</c> column value.</value>
		public decimal MONTO_APLICABLE
		{
			get
			{
				if(IsMONTO_APLICABLENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_aplicable;
			}
			set
			{
				_monto_aplicableNull = false;
				_monto_aplicable = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_APLICABLE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_APLICABLENull
		{
			get { return _monto_aplicableNull; }
			set { _monto_aplicableNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_MONTO</c> column value.</value>
		public decimal IMPUESTO_MONTO
		{
			get
			{
				if(IsIMPUESTO_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_monto;
			}
			set
			{
				_impuesto_montoNull = false;
				_impuesto_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_MONTONull
		{
			get { return _impuesto_montoNull; }
			set { _impuesto_montoNull = value; }
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
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IsIMPORTACION_IDNull ? (object)"<NULL>" : IMPORTACION_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@MONTO_APLICABLE=");
			dynStr.Append(IsMONTO_APLICABLENull ? (object)"<NULL>" : MONTO_APLICABLE);
			dynStr.Append("@CBA@IMPUESTO_MONTO=");
			dynStr.Append(IsIMPUESTO_MONTONull ? (object)"<NULL>" : IMPUESTO_MONTO);
			return dynStr.ToString();
		}
	} // End of IMPORTACIONES_GASTOSRow_Base class
} // End of namespace
