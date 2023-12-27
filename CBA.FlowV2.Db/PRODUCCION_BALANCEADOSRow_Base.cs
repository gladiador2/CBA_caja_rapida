// <fileinfo name="PRODUCCION_BALANCEADOSRow_Base.cs">
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
	/// The base class for <see cref="PRODUCCION_BALANCEADOSRow"/> that 
	/// represents a record in the <c>PRODUCCION_BALANCEADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PRODUCCION_BALANCEADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRODUCCION_BALANCEADOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _sucursal_id;
		private decimal _deposito_id;
		private System.DateTime _fecha_solicitud;
		private bool _fecha_solicitudNull = true;
		private decimal _autonumeracion_id;
		private bool _autonumeracion_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _unidad_medida_id;
		private decimal _presentacion_id;
		private bool _presentacion_idNull = true;
		private decimal _cantidad_presentacion;
		private bool _cantidad_presentacionNull = true;
		private decimal _precio;
		private bool _precioNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private string _nro_comprobante;
		private decimal _lote_id;
		private bool _lote_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRODUCCION_BALANCEADOSRow_Base"/> class.
		/// </summary>
		public PRODUCCION_BALANCEADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PRODUCCION_BALANCEADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsFECHA_SOLICITUDNull != original.IsFECHA_SOLICITUDNull) return true;
			if (!this.IsFECHA_SOLICITUDNull && !original.IsFECHA_SOLICITUDNull)
				if (this.FECHA_SOLICITUD != original.FECHA_SOLICITUD) return true;
			if (this.IsAUTONUMERACION_IDNull != original.IsAUTONUMERACION_IDNull) return true;
			if (!this.IsAUTONUMERACION_IDNull && !original.IsAUTONUMERACION_IDNull)
				if (this.AUTONUMERACION_ID != original.AUTONUMERACION_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.IsPRESENTACION_IDNull != original.IsPRESENTACION_IDNull) return true;
			if (!this.IsPRESENTACION_IDNull && !original.IsPRESENTACION_IDNull)
				if (this.PRESENTACION_ID != original.PRESENTACION_ID) return true;
			if (this.IsCANTIDAD_PRESENTACIONNull != original.IsCANTIDAD_PRESENTACIONNull) return true;
			if (!this.IsCANTIDAD_PRESENTACIONNull && !original.IsCANTIDAD_PRESENTACIONNull)
				if (this.CANTIDAD_PRESENTACION != original.CANTIDAD_PRESENTACION) return true;
			if (this.IsPRECIONull != original.IsPRECIONull) return true;
			if (!this.IsPRECIONull && !original.IsPRECIONull)
				if (this.PRECIO != original.PRECIO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			
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
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SOLICITUD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SOLICITUD</c> column value.</value>
		public System.DateTime FECHA_SOLICITUD
		{
			get
			{
				if(IsFECHA_SOLICITUDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_solicitud;
			}
			set
			{
				_fecha_solicitudNull = false;
				_fecha_solicitud = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SOLICITUD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SOLICITUDNull
		{
			get { return _fecha_solicitudNull; }
			set { _fecha_solicitudNull = value; }
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
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRESENTACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRESENTACION_ID</c> column value.</value>
		public decimal PRESENTACION_ID
		{
			get
			{
				if(IsPRESENTACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _presentacion_id;
			}
			set
			{
				_presentacion_idNull = false;
				_presentacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRESENTACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRESENTACION_IDNull
		{
			get { return _presentacion_idNull; }
			set { _presentacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_PRESENTACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_PRESENTACION</c> column value.</value>
		public decimal CANTIDAD_PRESENTACION
		{
			get
			{
				if(IsCANTIDAD_PRESENTACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_presentacion;
			}
			set
			{
				_cantidad_presentacionNull = false;
				_cantidad_presentacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_PRESENTACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_PRESENTACIONNull
		{
			get { return _cantidad_presentacionNull; }
			set { _cantidad_presentacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO</c> column value.</value>
		public decimal PRECIO
		{
			get
			{
				if(IsPRECIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio;
			}
			set
			{
				_precioNull = false;
				_precio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIONull
		{
			get { return _precioNull; }
			set { _precioNull = value; }
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
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
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get
			{
				if(IsLOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lote_id;
			}
			set
			{
				_lote_idNull = false;
				_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOTE_IDNull
		{
			get { return _lote_idNull; }
			set { _lote_idNull = value; }
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
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@FECHA_SOLICITUD=");
			dynStr.Append(IsFECHA_SOLICITUDNull ? (object)"<NULL>" : FECHA_SOLICITUD);
			dynStr.Append("@CBA@AUTONUMERACION_ID=");
			dynStr.Append(IsAUTONUMERACION_IDNull ? (object)"<NULL>" : AUTONUMERACION_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@PRESENTACION_ID=");
			dynStr.Append(IsPRESENTACION_IDNull ? (object)"<NULL>" : PRESENTACION_ID);
			dynStr.Append("@CBA@CANTIDAD_PRESENTACION=");
			dynStr.Append(IsCANTIDAD_PRESENTACIONNull ? (object)"<NULL>" : CANTIDAD_PRESENTACION);
			dynStr.Append("@CBA@PRECIO=");
			dynStr.Append(IsPRECIONull ? (object)"<NULL>" : PRECIO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			return dynStr.ToString();
		}
	} // End of PRODUCCION_BALANCEADOSRow_Base class
} // End of namespace
