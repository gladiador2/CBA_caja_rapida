// <fileinfo name="ORDENES_PAGO_DETRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_DETRow"/> that 
	/// represents a record in the <c>ORDENES_PAGO_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_PAGO_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_DETRow_Base
	{
		private decimal _id;
		private decimal _orden_pago_id;
		private decimal _sucursal_destino_id;
		private bool _sucursal_destino_idNull = true;
		private decimal _ctacte_proveedor_id;
		private bool _ctacte_proveedor_idNull = true;
		private decimal _ctacte_persona_id;
		private bool _ctacte_persona_idNull = true;
		private decimal _ctacte_caja_teso_destino_id;
		private bool _ctacte_caja_teso_destino_idNull = true;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private decimal _monto_origen;
		private bool _monto_origenNull = true;
		private decimal _cotizacion_moneda_origen;
		private bool _cotizacion_moneda_origenNull = true;
		private decimal _monto_destino;
		private bool _monto_destinoNull = true;
		private decimal _flujo_referido_id;
		private bool _flujo_referido_idNull = true;
		private decimal _caso_referido_id;
		private bool _caso_referido_idNull = true;
		private string _observacion;
		private decimal _liquidacion_id;
		private bool _liquidacion_idNull = true;
		private string _nro_comprobante;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_DETRow_Base"/> class.
		/// </summary>
		public ORDENES_PAGO_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_PAGO_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsSUCURSAL_DESTINO_IDNull != original.IsSUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_IDNull && !original.IsSUCURSAL_DESTINO_IDNull)
				if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.IsCTACTE_PROVEEDOR_IDNull != original.IsCTACTE_PROVEEDOR_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_IDNull && !original.IsCTACTE_PROVEEDOR_IDNull)
				if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.IsCTACTE_PERSONA_IDNull != original.IsCTACTE_PERSONA_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_IDNull && !original.IsCTACTE_PERSONA_IDNull)
				if (this.CTACTE_PERSONA_ID != original.CTACTE_PERSONA_ID) return true;
			if (this.IsCTACTE_CAJA_TESO_DESTINO_IDNull != original.IsCTACTE_CAJA_TESO_DESTINO_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESO_DESTINO_IDNull && !original.IsCTACTE_CAJA_TESO_DESTINO_IDNull)
				if (this.CTACTE_CAJA_TESO_DESTINO_ID != original.CTACTE_CAJA_TESO_DESTINO_ID) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.IsMONEDA_ORIGEN_IDNull != original.IsMONEDA_ORIGEN_IDNull) return true;
			if (!this.IsMONEDA_ORIGEN_IDNull && !original.IsMONEDA_ORIGEN_IDNull)
				if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.IsMONTO_ORIGENNull != original.IsMONTO_ORIGENNull) return true;
			if (!this.IsMONTO_ORIGENNull && !original.IsMONTO_ORIGENNull)
				if (this.MONTO_ORIGEN != original.MONTO_ORIGEN) return true;
			if (this.IsCOTIZACION_MONEDA_ORIGENNull != original.IsCOTIZACION_MONEDA_ORIGENNull) return true;
			if (!this.IsCOTIZACION_MONEDA_ORIGENNull && !original.IsCOTIZACION_MONEDA_ORIGENNull)
				if (this.COTIZACION_MONEDA_ORIGEN != original.COTIZACION_MONEDA_ORIGEN) return true;
			if (this.IsMONTO_DESTINONull != original.IsMONTO_DESTINONull) return true;
			if (!this.IsMONTO_DESTINONull && !original.IsMONTO_DESTINONull)
				if (this.MONTO_DESTINO != original.MONTO_DESTINO) return true;
			if (this.IsFLUJO_REFERIDO_IDNull != original.IsFLUJO_REFERIDO_IDNull) return true;
			if (!this.IsFLUJO_REFERIDO_IDNull && !original.IsFLUJO_REFERIDO_IDNull)
				if (this.FLUJO_REFERIDO_ID != original.FLUJO_REFERIDO_ID) return true;
			if (this.IsCASO_REFERIDO_IDNull != original.IsCASO_REFERIDO_IDNull) return true;
			if (!this.IsCASO_REFERIDO_IDNull && !original.IsCASO_REFERIDO_IDNull)
				if (this.CASO_REFERIDO_ID != original.CASO_REFERIDO_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsLIQUIDACION_IDNull != original.IsLIQUIDACION_IDNull) return true;
			if (!this.IsLIQUIDACION_IDNull && !original.IsLIQUIDACION_IDNull)
				if (this.LIQUIDACION_ID != original.LIQUIDACION_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			
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
		/// Gets or sets the <c>ORDEN_PAGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_PAGO_ID</c> column value.</value>
		public decimal ORDEN_PAGO_ID
		{
			get { return _orden_pago_id; }
			set { _orden_pago_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ID</c> column value.</value>
		public decimal SUCURSAL_DESTINO_ID
		{
			get
			{
				if(IsSUCURSAL_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_destino_id;
			}
			set
			{
				_sucursal_destino_idNull = false;
				_sucursal_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_DESTINO_IDNull
		{
			get { return _sucursal_destino_idNull; }
			set { _sucursal_destino_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROVEEDOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_id;
			}
			set
			{
				_ctacte_proveedor_idNull = false;
				_ctacte_proveedor_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_IDNull
		{
			get { return _ctacte_proveedor_idNull; }
			set { _ctacte_proveedor_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_id;
			}
			set
			{
				_ctacte_persona_idNull = false;
				_ctacte_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_IDNull
		{
			get { return _ctacte_persona_idNull; }
			set { _ctacte_persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</value>
		public decimal CTACTE_CAJA_TESO_DESTINO_ID
		{
			get
			{
				if(IsCTACTE_CAJA_TESO_DESTINO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_caja_teso_destino_id;
			}
			set
			{
				_ctacte_caja_teso_destino_idNull = false;
				_ctacte_caja_teso_destino_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_CAJA_TESO_DESTINO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_CAJA_TESO_DESTINO_IDNull
		{
			get { return _ctacte_caja_teso_destino_idNull; }
			set { _ctacte_caja_teso_destino_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_ORIGEN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal MONEDA_ORIGEN_ID
		{
			get
			{
				if(IsMONEDA_ORIGEN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_origen_id;
			}
			set
			{
				_moneda_origen_idNull = false;
				_moneda_origen_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ORIGEN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_ORIGEN_IDNull
		{
			get { return _moneda_origen_idNull; }
			set { _moneda_origen_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_ORIGEN</c> column value.</value>
		public decimal MONTO_ORIGEN
		{
			get
			{
				if(IsMONTO_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_origen;
			}
			set
			{
				_monto_origenNull = false;
				_monto_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_ORIGENNull
		{
			get { return _monto_origenNull; }
			set { _monto_origenNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA_ORIGEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COTIZACION_MONEDA_ORIGEN
		{
			get
			{
				if(IsCOTIZACION_MONEDA_ORIGENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion_moneda_origen;
			}
			set
			{
				_cotizacion_moneda_origenNull = false;
				_cotizacion_moneda_origen = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION_MONEDA_ORIGEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACION_MONEDA_ORIGENNull
		{
			get { return _cotizacion_moneda_origenNull; }
			set { _cotizacion_moneda_origenNull = value; }
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
		/// Gets or sets the <c>FLUJO_REFERIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_REFERIDO_ID</c> column value.</value>
		public decimal FLUJO_REFERIDO_ID
		{
			get
			{
				if(IsFLUJO_REFERIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_referido_id;
			}
			set
			{
				_flujo_referido_idNull = false;
				_flujo_referido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_REFERIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_REFERIDO_IDNull
		{
			get { return _flujo_referido_idNull; }
			set { _flujo_referido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_REFERIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_REFERIDO_ID</c> column value.</value>
		public decimal CASO_REFERIDO_ID
		{
			get
			{
				if(IsCASO_REFERIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_referido_id;
			}
			set
			{
				_caso_referido_idNull = false;
				_caso_referido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_REFERIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_REFERIDO_IDNull
		{
			get { return _caso_referido_idNull; }
			set { _caso_referido_idNull = value; }
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
		/// Gets or sets the <c>LIQUIDACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIQUIDACION_ID</c> column value.</value>
		public decimal LIQUIDACION_ID
		{
			get
			{
				if(IsLIQUIDACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _liquidacion_id;
			}
			set
			{
				_liquidacion_idNull = false;
				_liquidacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIQUIDACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIQUIDACION_IDNull
		{
			get { return _liquidacion_idNull; }
			set { _liquidacion_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@ORDEN_PAGO_ID=");
			dynStr.Append(ORDEN_PAGO_ID);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ID=");
			dynStr.Append(IsSUCURSAL_DESTINO_IDNull ? (object)"<NULL>" : SUCURSAL_DESTINO_ID);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_ID=");
			dynStr.Append(IsCTACTE_PERSONA_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_DESTINO_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESO_DESTINO_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESO_DESTINO_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(IsMONTO_ORIGENNull ? (object)"<NULL>" : MONTO_ORIGEN);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(IsCOTIZACION_MONEDA_ORIGENNull ? (object)"<NULL>" : COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(IsMONTO_DESTINONull ? (object)"<NULL>" : MONTO_DESTINO);
			dynStr.Append("@CBA@FLUJO_REFERIDO_ID=");
			dynStr.Append(IsFLUJO_REFERIDO_IDNull ? (object)"<NULL>" : FLUJO_REFERIDO_ID);
			dynStr.Append("@CBA@CASO_REFERIDO_ID=");
			dynStr.Append(IsCASO_REFERIDO_IDNull ? (object)"<NULL>" : CASO_REFERIDO_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@LIQUIDACION_ID=");
			dynStr.Append(IsLIQUIDACION_IDNull ? (object)"<NULL>" : LIQUIDACION_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			return dynStr.ToString();
		}
	} // End of ORDENES_PAGO_DETRow_Base class
} // End of namespace
