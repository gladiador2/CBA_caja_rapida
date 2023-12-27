// <fileinfo name="ORDENES_PAGO_DET_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/> that 
	/// represents a record in the <c>ORDENES_PAGO_DET_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_PAGO_DET_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_DET_INFO_COMPRow_Base
	{
		private decimal _id;
		private decimal _orden_pago_id;
		private decimal _sucursal_destino_id;
		private bool _sucursal_destino_idNull = true;
		private string _sucursal_destino_nombre;
		private string _sucursal_destino_abreviatura;
		private decimal _ctacte_caja_teso_destino_id;
		private bool _ctacte_caja_teso_destino_idNull = true;
		private string _ctacte_caja_teso_dest_nombre;
		private string _ctacte_caja_teso_dest_abrev;
		private decimal _ctacte_fondo_fijo_id;
		private bool _ctacte_fondo_fijo_idNull = true;
		private string _ctacte_fondo_fijo_nombre;
		private string _ctacte_fondo_fijo_abreviatura;
		private decimal _ctacte_proveedor_id;
		private bool _ctacte_proveedor_idNull = true;
		private string _ctacte_concepto_descripcion;
		private decimal _ctacte_proveedor_caso_id;
		private bool _ctacte_proveedor_caso_idNull = true;
		private decimal _ctacte_persona_caso_id;
		private bool _ctacte_persona_caso_idNull = true;
		private System.DateTime _ctacte_fecha_vencimiento;
		private bool _ctacte_fecha_vencimientoNull = true;
		private System.DateTime _factura_fecha_emision;
		private bool _factura_fecha_emisionNull = true;
		private decimal _moneda_origen_id;
		private bool _moneda_origen_idNull = true;
		private string _moneda_origen_nombre;
		private string _moneda_origen_simbolo;
		private decimal _monto_origen;
		private bool _monto_origenNull = true;
		private decimal _cotizacion_moneda_origen;
		private bool _cotizacion_moneda_origenNull = true;
		private decimal _monto_destino;
		private bool _monto_destinoNull = true;
		private decimal _flujo_referido_id;
		private bool _flujo_referido_idNull = true;
		private string _flujo_descripcion;
		private string _flujo_descripcion_impresion;
		private decimal _caso_referido_id;
		private bool _caso_referido_idNull = true;
		private string _caso_referido_estado_id;
		private decimal _liquidacion_id;
		private bool _liquidacion_idNull = true;
		private string _observacion;
		private string _nro_comprobante;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_DET_INFO_COMPRow_Base"/> class.
		/// </summary>
		public ORDENES_PAGO_DET_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_PAGO_DET_INFO_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_PAGO_ID != original.ORDEN_PAGO_ID) return true;
			if (this.IsSUCURSAL_DESTINO_IDNull != original.IsSUCURSAL_DESTINO_IDNull) return true;
			if (!this.IsSUCURSAL_DESTINO_IDNull && !original.IsSUCURSAL_DESTINO_IDNull)
				if (this.SUCURSAL_DESTINO_ID != original.SUCURSAL_DESTINO_ID) return true;
			if (this.SUCURSAL_DESTINO_NOMBRE != original.SUCURSAL_DESTINO_NOMBRE) return true;
			if (this.SUCURSAL_DESTINO_ABREVIATURA != original.SUCURSAL_DESTINO_ABREVIATURA) return true;
			if (this.IsCTACTE_CAJA_TESO_DESTINO_IDNull != original.IsCTACTE_CAJA_TESO_DESTINO_IDNull) return true;
			if (!this.IsCTACTE_CAJA_TESO_DESTINO_IDNull && !original.IsCTACTE_CAJA_TESO_DESTINO_IDNull)
				if (this.CTACTE_CAJA_TESO_DESTINO_ID != original.CTACTE_CAJA_TESO_DESTINO_ID) return true;
			if (this.CTACTE_CAJA_TESO_DEST_NOMBRE != original.CTACTE_CAJA_TESO_DEST_NOMBRE) return true;
			if (this.CTACTE_CAJA_TESO_DEST_ABREV != original.CTACTE_CAJA_TESO_DEST_ABREV) return true;
			if (this.IsCTACTE_FONDO_FIJO_IDNull != original.IsCTACTE_FONDO_FIJO_IDNull) return true;
			if (!this.IsCTACTE_FONDO_FIJO_IDNull && !original.IsCTACTE_FONDO_FIJO_IDNull)
				if (this.CTACTE_FONDO_FIJO_ID != original.CTACTE_FONDO_FIJO_ID) return true;
			if (this.CTACTE_FONDO_FIJO_NOMBRE != original.CTACTE_FONDO_FIJO_NOMBRE) return true;
			if (this.CTACTE_FONDO_FIJO_ABREVIATURA != original.CTACTE_FONDO_FIJO_ABREVIATURA) return true;
			if (this.IsCTACTE_PROVEEDOR_IDNull != original.IsCTACTE_PROVEEDOR_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_IDNull && !original.IsCTACTE_PROVEEDOR_IDNull)
				if (this.CTACTE_PROVEEDOR_ID != original.CTACTE_PROVEEDOR_ID) return true;
			if (this.CTACTE_CONCEPTO_DESCRIPCION != original.CTACTE_CONCEPTO_DESCRIPCION) return true;
			if (this.IsCTACTE_PROVEEDOR_CASO_IDNull != original.IsCTACTE_PROVEEDOR_CASO_IDNull) return true;
			if (!this.IsCTACTE_PROVEEDOR_CASO_IDNull && !original.IsCTACTE_PROVEEDOR_CASO_IDNull)
				if (this.CTACTE_PROVEEDOR_CASO_ID != original.CTACTE_PROVEEDOR_CASO_ID) return true;
			if (this.IsCTACTE_PERSONA_CASO_IDNull != original.IsCTACTE_PERSONA_CASO_IDNull) return true;
			if (!this.IsCTACTE_PERSONA_CASO_IDNull && !original.IsCTACTE_PERSONA_CASO_IDNull)
				if (this.CTACTE_PERSONA_CASO_ID != original.CTACTE_PERSONA_CASO_ID) return true;
			if (this.IsCTACTE_FECHA_VENCIMIENTONull != original.IsCTACTE_FECHA_VENCIMIENTONull) return true;
			if (!this.IsCTACTE_FECHA_VENCIMIENTONull && !original.IsCTACTE_FECHA_VENCIMIENTONull)
				if (this.CTACTE_FECHA_VENCIMIENTO != original.CTACTE_FECHA_VENCIMIENTO) return true;
			if (this.IsFACTURA_FECHA_EMISIONNull != original.IsFACTURA_FECHA_EMISIONNull) return true;
			if (!this.IsFACTURA_FECHA_EMISIONNull && !original.IsFACTURA_FECHA_EMISIONNull)
				if (this.FACTURA_FECHA_EMISION != original.FACTURA_FECHA_EMISION) return true;
			if (this.IsMONEDA_ORIGEN_IDNull != original.IsMONEDA_ORIGEN_IDNull) return true;
			if (!this.IsMONEDA_ORIGEN_IDNull && !original.IsMONEDA_ORIGEN_IDNull)
				if (this.MONEDA_ORIGEN_ID != original.MONEDA_ORIGEN_ID) return true;
			if (this.MONEDA_ORIGEN_NOMBRE != original.MONEDA_ORIGEN_NOMBRE) return true;
			if (this.MONEDA_ORIGEN_SIMBOLO != original.MONEDA_ORIGEN_SIMBOLO) return true;
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
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.FLUJO_DESCRIPCION_IMPRESION != original.FLUJO_DESCRIPCION_IMPRESION) return true;
			if (this.IsCASO_REFERIDO_IDNull != original.IsCASO_REFERIDO_IDNull) return true;
			if (!this.IsCASO_REFERIDO_IDNull && !original.IsCASO_REFERIDO_IDNull)
				if (this.CASO_REFERIDO_ID != original.CASO_REFERIDO_ID) return true;
			if (this.CASO_REFERIDO_ESTADO_ID != original.CASO_REFERIDO_ESTADO_ID) return true;
			if (this.IsLIQUIDACION_IDNull != original.IsLIQUIDACION_IDNull) return true;
			if (!this.IsLIQUIDACION_IDNull && !original.IsLIQUIDACION_IDNull)
				if (this.LIQUIDACION_ID != original.LIQUIDACION_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
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
		/// Gets or sets the <c>SUCURSAL_DESTINO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_NOMBRE</c> column value.</value>
		public string SUCURSAL_DESTINO_NOMBRE
		{
			get { return _sucursal_destino_nombre; }
			set { _sucursal_destino_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_DESTINO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_DESTINO_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_DESTINO_ABREVIATURA
		{
			get { return _sucursal_destino_abreviatura; }
			set { _sucursal_destino_abreviatura = value; }
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
		/// Gets or sets the <c>CTACTE_CAJA_TESO_DEST_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_DEST_NOMBRE</c> column value.</value>
		public string CTACTE_CAJA_TESO_DEST_NOMBRE
		{
			get { return _ctacte_caja_teso_dest_nombre; }
			set { _ctacte_caja_teso_dest_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_CAJA_TESO_DEST_ABREV</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CAJA_TESO_DEST_ABREV</c> column value.</value>
		public string CTACTE_CAJA_TESO_DEST_ABREV
		{
			get { return _ctacte_caja_teso_dest_abrev; }
			set { _ctacte_caja_teso_dest_abrev = value; }
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
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_NOMBRE</c> column value.</value>
		public string CTACTE_FONDO_FIJO_NOMBRE
		{
			get { return _ctacte_fondo_fijo_nombre; }
			set { _ctacte_fondo_fijo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FONDO_FIJO_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FONDO_FIJO_ABREVIATURA</c> column value.</value>
		public string CTACTE_FONDO_FIJO_ABREVIATURA
		{
			get { return _ctacte_fondo_fijo_abreviatura; }
			set { _ctacte_fondo_fijo_abreviatura = value; }
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
		/// Gets or sets the <c>CTACTE_CONCEPTO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_CONCEPTO_DESCRIPCION</c> column value.</value>
		public string CTACTE_CONCEPTO_DESCRIPCION
		{
			get { return _ctacte_concepto_descripcion; }
			set { _ctacte_concepto_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PROVEEDOR_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROVEEDOR_CASO_ID</c> column value.</value>
		public decimal CTACTE_PROVEEDOR_CASO_ID
		{
			get
			{
				if(IsCTACTE_PROVEEDOR_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_proveedor_caso_id;
			}
			set
			{
				_ctacte_proveedor_caso_idNull = false;
				_ctacte_proveedor_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROVEEDOR_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROVEEDOR_CASO_IDNull
		{
			get { return _ctacte_proveedor_caso_idNull; }
			set { _ctacte_proveedor_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PERSONA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PERSONA_CASO_ID</c> column value.</value>
		public decimal CTACTE_PERSONA_CASO_ID
		{
			get
			{
				if(IsCTACTE_PERSONA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_persona_caso_id;
			}
			set
			{
				_ctacte_persona_caso_idNull = false;
				_ctacte_persona_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PERSONA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PERSONA_CASO_IDNull
		{
			get { return _ctacte_persona_caso_idNull; }
			set { _ctacte_persona_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_FECHA_VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_FECHA_VENCIMIENTO</c> column value.</value>
		public System.DateTime CTACTE_FECHA_VENCIMIENTO
		{
			get
			{
				if(IsCTACTE_FECHA_VENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_fecha_vencimiento;
			}
			set
			{
				_ctacte_fecha_vencimientoNull = false;
				_ctacte_fecha_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_FECHA_VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_FECHA_VENCIMIENTONull
		{
			get { return _ctacte_fecha_vencimientoNull; }
			set { _ctacte_fecha_vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_FECHA_EMISION</c> column value.</value>
		public System.DateTime FACTURA_FECHA_EMISION
		{
			get
			{
				if(IsFACTURA_FECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_fecha_emision;
			}
			set
			{
				_factura_fecha_emisionNull = false;
				_factura_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_FECHA_EMISIONNull
		{
			get { return _factura_fecha_emisionNull; }
			set { _factura_fecha_emisionNull = value; }
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
		/// Gets or sets the <c>MONEDA_ORIGEN_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_NOMBRE</c> column value.</value>
		public string MONEDA_ORIGEN_NOMBRE
		{
			get { return _moneda_origen_nombre; }
			set { _moneda_origen_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ORIGEN_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ORIGEN_SIMBOLO</c> column value.</value>
		public string MONEDA_ORIGEN_SIMBOLO
		{
			get { return _moneda_origen_simbolo; }
			set { _moneda_origen_simbolo = value; }
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
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_DESCRIPCION_IMPRESION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION_IMPRESION</c> column value.</value>
		public string FLUJO_DESCRIPCION_IMPRESION
		{
			get { return _flujo_descripcion_impresion; }
			set { _flujo_descripcion_impresion = value; }
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
		/// Gets or sets the <c>CASO_REFERIDO_ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_REFERIDO_ESTADO_ID</c> column value.</value>
		public string CASO_REFERIDO_ESTADO_ID
		{
			get { return _caso_referido_estado_id; }
			set { _caso_referido_estado_id = value; }
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
			dynStr.Append("@CBA@SUCURSAL_DESTINO_NOMBRE=");
			dynStr.Append(SUCURSAL_DESTINO_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_DESTINO_ABREVIATURA=");
			dynStr.Append(SUCURSAL_DESTINO_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_DESTINO_ID=");
			dynStr.Append(IsCTACTE_CAJA_TESO_DESTINO_IDNull ? (object)"<NULL>" : CTACTE_CAJA_TESO_DESTINO_ID);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_DEST_NOMBRE=");
			dynStr.Append(CTACTE_CAJA_TESO_DEST_NOMBRE);
			dynStr.Append("@CBA@CTACTE_CAJA_TESO_DEST_ABREV=");
			dynStr.Append(CTACTE_CAJA_TESO_DEST_ABREV);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ID=");
			dynStr.Append(IsCTACTE_FONDO_FIJO_IDNull ? (object)"<NULL>" : CTACTE_FONDO_FIJO_ID);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_NOMBRE=");
			dynStr.Append(CTACTE_FONDO_FIJO_NOMBRE);
			dynStr.Append("@CBA@CTACTE_FONDO_FIJO_ABREVIATURA=");
			dynStr.Append(CTACTE_FONDO_FIJO_ABREVIATURA);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_ID);
			dynStr.Append("@CBA@CTACTE_CONCEPTO_DESCRIPCION=");
			dynStr.Append(CTACTE_CONCEPTO_DESCRIPCION);
			dynStr.Append("@CBA@CTACTE_PROVEEDOR_CASO_ID=");
			dynStr.Append(IsCTACTE_PROVEEDOR_CASO_IDNull ? (object)"<NULL>" : CTACTE_PROVEEDOR_CASO_ID);
			dynStr.Append("@CBA@CTACTE_PERSONA_CASO_ID=");
			dynStr.Append(IsCTACTE_PERSONA_CASO_IDNull ? (object)"<NULL>" : CTACTE_PERSONA_CASO_ID);
			dynStr.Append("@CBA@CTACTE_FECHA_VENCIMIENTO=");
			dynStr.Append(IsCTACTE_FECHA_VENCIMIENTONull ? (object)"<NULL>" : CTACTE_FECHA_VENCIMIENTO);
			dynStr.Append("@CBA@FACTURA_FECHA_EMISION=");
			dynStr.Append(IsFACTURA_FECHA_EMISIONNull ? (object)"<NULL>" : FACTURA_FECHA_EMISION);
			dynStr.Append("@CBA@MONEDA_ORIGEN_ID=");
			dynStr.Append(IsMONEDA_ORIGEN_IDNull ? (object)"<NULL>" : MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@MONEDA_ORIGEN_NOMBRE=");
			dynStr.Append(MONEDA_ORIGEN_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ORIGEN_SIMBOLO=");
			dynStr.Append(MONEDA_ORIGEN_SIMBOLO);
			dynStr.Append("@CBA@MONTO_ORIGEN=");
			dynStr.Append(IsMONTO_ORIGENNull ? (object)"<NULL>" : MONTO_ORIGEN);
			dynStr.Append("@CBA@COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(IsCOTIZACION_MONEDA_ORIGENNull ? (object)"<NULL>" : COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@MONTO_DESTINO=");
			dynStr.Append(IsMONTO_DESTINONull ? (object)"<NULL>" : MONTO_DESTINO);
			dynStr.Append("@CBA@FLUJO_REFERIDO_ID=");
			dynStr.Append(IsFLUJO_REFERIDO_IDNull ? (object)"<NULL>" : FLUJO_REFERIDO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION_IMPRESION=");
			dynStr.Append(FLUJO_DESCRIPCION_IMPRESION);
			dynStr.Append("@CBA@CASO_REFERIDO_ID=");
			dynStr.Append(IsCASO_REFERIDO_IDNull ? (object)"<NULL>" : CASO_REFERIDO_ID);
			dynStr.Append("@CBA@CASO_REFERIDO_ESTADO_ID=");
			dynStr.Append(CASO_REFERIDO_ESTADO_ID);
			dynStr.Append("@CBA@LIQUIDACION_ID=");
			dynStr.Append(IsLIQUIDACION_IDNull ? (object)"<NULL>" : LIQUIDACION_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			return dynStr.ToString();
		}
	} // End of ORDENES_PAGO_DET_INFO_COMPRow_Base class
} // End of namespace
