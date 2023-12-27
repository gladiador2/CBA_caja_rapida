// <fileinfo name="NOTAS_CRED_PRO_DET_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/> that 
	/// represents a record in the <c>NOTAS_CRED_PRO_DET_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTAS_CRED_PRO_DET_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _nota_credito_proveedor_id;
		private decimal _factura_proveedor_id;
		private decimal _nota_credito_proveedor_caso_id;
		private bool _nota_credito_proveedor_caso_idNull = true;
		private string _nota_cred_prov_comprobante;
		private System.DateTime _nota_credito_proveedor_fecha;
		private bool _nota_credito_proveedor_fechaNull = true;
		private string _factura_nro_comprobante;
		private decimal _factura_caso_id;
		private bool _factura_caso_idNull = true;
		private System.DateTime _factura_fecha;
		private bool _factura_fechaNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _moneda_cotizacion;
		private bool _moneda_cotizacionNull = true;
		private decimal _factura_proveedor_detalle_id;
		private bool _factura_proveedor_detalle_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private string _deposito_nombre;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _articulo_descripcion;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _lote;
		private decimal _costo_unitario;
		private bool _costo_unitarioNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _impuesto_porcentaje;
		private bool _impuesto_porcentajeNull = true;
		private decimal _total;
		private bool _totalNull = true;
		private string _observacion;
		private decimal _impuesto_monto;
		private bool _impuesto_montoNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;
		private string _nombre_impuesto;
		private string _texto;
		private decimal _monto_concepto;
		private bool _monto_conceptoNull = true;
		private string _activo_codigo;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTAS_CRED_PRO_DET_INF_COMPRow_Base"/> class.
		/// </summary>
		public NOTAS_CRED_PRO_DET_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOTAS_CRED_PRO_DET_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOTA_CREDITO_PROVEEDOR_ID != original.NOTA_CREDITO_PROVEEDOR_ID) return true;
			if (this.FACTURA_PROVEEDOR_ID != original.FACTURA_PROVEEDOR_ID) return true;
			if (this.IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull != original.IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull) return true;
			if (!this.IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull && !original.IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull)
				if (this.NOTA_CREDITO_PROVEEDOR_CASO_ID != original.NOTA_CREDITO_PROVEEDOR_CASO_ID) return true;
			if (this.NOTA_CRED_PROV_COMPROBANTE != original.NOTA_CRED_PROV_COMPROBANTE) return true;
			if (this.IsNOTA_CREDITO_PROVEEDOR_FECHANull != original.IsNOTA_CREDITO_PROVEEDOR_FECHANull) return true;
			if (!this.IsNOTA_CREDITO_PROVEEDOR_FECHANull && !original.IsNOTA_CREDITO_PROVEEDOR_FECHANull)
				if (this.NOTA_CREDITO_PROVEEDOR_FECHA != original.NOTA_CREDITO_PROVEEDOR_FECHA) return true;
			if (this.FACTURA_NRO_COMPROBANTE != original.FACTURA_NRO_COMPROBANTE) return true;
			if (this.IsFACTURA_CASO_IDNull != original.IsFACTURA_CASO_IDNull) return true;
			if (!this.IsFACTURA_CASO_IDNull && !original.IsFACTURA_CASO_IDNull)
				if (this.FACTURA_CASO_ID != original.FACTURA_CASO_ID) return true;
			if (this.IsFACTURA_FECHANull != original.IsFACTURA_FECHANull) return true;
			if (!this.IsFACTURA_FECHANull && !original.IsFACTURA_FECHANull)
				if (this.FACTURA_FECHA != original.FACTURA_FECHA) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsMONEDA_COTIZACIONNull != original.IsMONEDA_COTIZACIONNull) return true;
			if (!this.IsMONEDA_COTIZACIONNull && !original.IsMONEDA_COTIZACIONNull)
				if (this.MONEDA_COTIZACION != original.MONEDA_COTIZACION) return true;
			if (this.IsFACTURA_PROVEEDOR_DETALLE_IDNull != original.IsFACTURA_PROVEEDOR_DETALLE_IDNull) return true;
			if (!this.IsFACTURA_PROVEEDOR_DETALLE_IDNull && !original.IsFACTURA_PROVEEDOR_DETALLE_IDNull)
				if (this.FACTURA_PROVEEDOR_DETALLE_ID != original.FACTURA_PROVEEDOR_DETALLE_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_NOMBRE != original.DEPOSITO_NOMBRE) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsARTICULO_FAMILIA_IDNull != original.IsARTICULO_FAMILIA_IDNull) return true;
			if (!this.IsARTICULO_FAMILIA_IDNull && !original.IsARTICULO_FAMILIA_IDNull)
				if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.IsARTICULO_GRUPO_IDNull != original.IsARTICULO_GRUPO_IDNull) return true;
			if (!this.IsARTICULO_GRUPO_IDNull && !original.IsARTICULO_GRUPO_IDNull)
				if (this.ARTICULO_GRUPO_ID != original.ARTICULO_GRUPO_ID) return true;
			if (this.IsARTICULO_SUBGRUPO_IDNull != original.IsARTICULO_SUBGRUPO_IDNull) return true;
			if (!this.IsARTICULO_SUBGRUPO_IDNull && !original.IsARTICULO_SUBGRUPO_IDNull)
				if (this.ARTICULO_SUBGRUPO_ID != original.ARTICULO_SUBGRUPO_ID) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.IsCOSTO_UNITARIONull != original.IsCOSTO_UNITARIONull) return true;
			if (!this.IsCOSTO_UNITARIONull && !original.IsCOSTO_UNITARIONull)
				if (this.COSTO_UNITARIO != original.COSTO_UNITARIO) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsIMPUESTO_PORCENTAJENull != original.IsIMPUESTO_PORCENTAJENull) return true;
			if (!this.IsIMPUESTO_PORCENTAJENull && !original.IsIMPUESTO_PORCENTAJENull)
				if (this.IMPUESTO_PORCENTAJE != original.IMPUESTO_PORCENTAJE) return true;
			if (this.IsTOTALNull != original.IsTOTALNull) return true;
			if (!this.IsTOTALNull && !original.IsTOTALNull)
				if (this.TOTAL != original.TOTAL) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsIMPUESTO_MONTONull != original.IsIMPUESTO_MONTONull) return true;
			if (!this.IsIMPUESTO_MONTONull && !original.IsIMPUESTO_MONTONull)
				if (this.IMPUESTO_MONTO != original.IMPUESTO_MONTO) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.NOMBRE_IMPUESTO != original.NOMBRE_IMPUESTO) return true;
			if (this.TEXTO != original.TEXTO) return true;
			if (this.IsMONTO_CONCEPTONull != original.IsMONTO_CONCEPTONull) return true;
			if (!this.IsMONTO_CONCEPTONull && !original.IsMONTO_CONCEPTONull)
				if (this.MONTO_CONCEPTO != original.MONTO_CONCEPTO) return true;
			if (this.ACTIVO_CODIGO != original.ACTIVO_CODIGO) return true;
			
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
		/// Gets or sets the <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</value>
		public decimal NOTA_CREDITO_PROVEEDOR_ID
		{
			get { return _nota_credito_proveedor_id; }
			set { _nota_credito_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_ID
		{
			get { return _factura_proveedor_id; }
			set { _factura_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CREDITO_PROVEEDOR_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PROVEEDOR_CASO_ID</c> column value.</value>
		public decimal NOTA_CREDITO_PROVEEDOR_CASO_ID
		{
			get
			{
				if(IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nota_credito_proveedor_caso_id;
			}
			set
			{
				_nota_credito_proveedor_caso_idNull = false;
				_nota_credito_proveedor_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOTA_CREDITO_PROVEEDOR_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull
		{
			get { return _nota_credito_proveedor_caso_idNull; }
			set { _nota_credito_proveedor_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CRED_PROV_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTA_CRED_PROV_COMPROBANTE</c> column value.</value>
		public string NOTA_CRED_PROV_COMPROBANTE
		{
			get { return _nota_cred_prov_comprobante; }
			set { _nota_cred_prov_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CREDITO_PROVEEDOR_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PROVEEDOR_FECHA</c> column value.</value>
		public System.DateTime NOTA_CREDITO_PROVEEDOR_FECHA
		{
			get
			{
				if(IsNOTA_CREDITO_PROVEEDOR_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nota_credito_proveedor_fecha;
			}
			set
			{
				_nota_credito_proveedor_fechaNull = false;
				_nota_credito_proveedor_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NOTA_CREDITO_PROVEEDOR_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNOTA_CREDITO_PROVEEDOR_FECHANull
		{
			get { return _nota_credito_proveedor_fechaNull; }
			set { _nota_credito_proveedor_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_NRO_COMPROBANTE</c> column value.</value>
		public string FACTURA_NRO_COMPROBANTE
		{
			get { return _factura_nro_comprobante; }
			set { _factura_nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CASO_ID</c> column value.</value>
		public decimal FACTURA_CASO_ID
		{
			get
			{
				if(IsFACTURA_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_caso_id;
			}
			set
			{
				_factura_caso_idNull = false;
				_factura_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CASO_IDNull
		{
			get { return _factura_caso_idNull; }
			set { _factura_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_FECHA</c> column value.</value>
		public System.DateTime FACTURA_FECHA
		{
			get
			{
				if(IsFACTURA_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_fecha;
			}
			set
			{
				_factura_fechaNull = false;
				_factura_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_FECHANull
		{
			get { return _factura_fechaNull; }
			set { _factura_fechaNull = value; }
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
		/// Gets or sets the <c>MONEDA_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COTIZACION</c> column value.</value>
		public decimal MONEDA_COTIZACION
		{
			get
			{
				if(IsMONEDA_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_cotizacion;
			}
			set
			{
				_moneda_cotizacionNull = false;
				_moneda_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_COTIZACIONNull
		{
			get { return _moneda_cotizacionNull; }
			set { _moneda_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PROVEEDOR_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_DETALLE_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_DETALLE_ID
		{
			get
			{
				if(IsFACTURA_PROVEEDOR_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_proveedor_detalle_id;
			}
			set
			{
				_factura_proveedor_detalle_idNull = false;
				_factura_proveedor_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_PROVEEDOR_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_PROVEEDOR_DETALLE_IDNull
		{
			get { return _factura_proveedor_detalle_idNull; }
			set { _factura_proveedor_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_NOMBRE</c> column value.</value>
		public string DEPOSITO_NOMBRE
		{
			get { return _deposito_nombre; }
			set { _deposito_nombre = value; }
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
		/// Gets or sets the <c>ARTICULO_FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULO_FAMILIA_ID
		{
			get
			{
				if(IsARTICULO_FAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_familia_id;
			}
			set
			{
				_articulo_familia_idNull = false;
				_articulo_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_FAMILIA_IDNull
		{
			get { return _articulo_familia_idNull; }
			set { _articulo_familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_ID</c> column value.</value>
		public decimal ARTICULO_GRUPO_ID
		{
			get
			{
				if(IsARTICULO_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_grupo_id;
			}
			set
			{
				_articulo_grupo_idNull = false;
				_articulo_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_GRUPO_IDNull
		{
			get { return _articulo_grupo_idNull; }
			set { _articulo_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_ID</c> column value.</value>
		public decimal ARTICULO_SUBGRUPO_ID
		{
			get
			{
				if(IsARTICULO_SUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_subgrupo_id;
			}
			set
			{
				_articulo_subgrupo_idNull = false;
				_articulo_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_SUBGRUPO_IDNull
		{
			get { return _articulo_subgrupo_idNull; }
			set { _articulo_subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_DESCRIPCION
		{
			get { return _articulo_descripcion; }
			set { _articulo_descripcion = value; }
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
		/// Gets or sets the <c>LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE</c> column value.</value>
		public string LOTE
		{
			get { return _lote; }
			set { _lote = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_UNITARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_UNITARIO</c> column value.</value>
		public decimal COSTO_UNITARIO
		{
			get
			{
				if(IsCOSTO_UNITARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_unitario;
			}
			set
			{
				_costo_unitarioNull = false;
				_costo_unitario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_UNITARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_UNITARIONull
		{
			get { return _costo_unitarioNull; }
			set { _costo_unitarioNull = value; }
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
		/// Gets or sets the <c>IMPUESTO_PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_PORCENTAJE</c> column value.</value>
		public decimal IMPUESTO_PORCENTAJE
		{
			get
			{
				if(IsIMPUESTO_PORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_porcentaje;
			}
			set
			{
				_impuesto_porcentajeNull = false;
				_impuesto_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_PORCENTAJENull
		{
			get { return _impuesto_porcentajeNull; }
			set { _impuesto_porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get
			{
				if(IsTOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total;
			}
			set
			{
				_totalNull = false;
				_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTALNull
		{
			get { return _totalNull; }
			set { _totalNull = value; }
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id;
			}
			set
			{
				_texto_predefinido_idNull = false;
				_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_IDNull
		{
			get { return _texto_predefinido_idNull; }
			set { _texto_predefinido_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get
			{
				if(IsIMPUESTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_id;
			}
			set
			{
				_impuesto_idNull = false;
				_impuesto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_IDNull
		{
			get { return _impuesto_idNull; }
			set { _impuesto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_IMPUESTO</c> column value.</value>
		public string NOMBRE_IMPUESTO
		{
			get { return _nombre_impuesto; }
			set { _nombre_impuesto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO</c> column value.</value>
		public string TEXTO
		{
			get { return _texto; }
			set { _texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_CONCEPTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_CONCEPTO</c> column value.</value>
		public decimal MONTO_CONCEPTO
		{
			get
			{
				if(IsMONTO_CONCEPTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_concepto;
			}
			set
			{
				_monto_conceptoNull = false;
				_monto_concepto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_CONCEPTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_CONCEPTONull
		{
			get { return _monto_conceptoNull; }
			set { _monto_conceptoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACTIVO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_CODIGO</c> column value.</value>
		public string ACTIVO_CODIGO
		{
			get { return _activo_codigo; }
			set { _activo_codigo = value; }
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
			dynStr.Append("@CBA@NOTA_CREDITO_PROVEEDOR_ID=");
			dynStr.Append(NOTA_CREDITO_PROVEEDOR_ID);
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_ID=");
			dynStr.Append(FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@NOTA_CREDITO_PROVEEDOR_CASO_ID=");
			dynStr.Append(IsNOTA_CREDITO_PROVEEDOR_CASO_IDNull ? (object)"<NULL>" : NOTA_CREDITO_PROVEEDOR_CASO_ID);
			dynStr.Append("@CBA@NOTA_CRED_PROV_COMPROBANTE=");
			dynStr.Append(NOTA_CRED_PROV_COMPROBANTE);
			dynStr.Append("@CBA@NOTA_CREDITO_PROVEEDOR_FECHA=");
			dynStr.Append(IsNOTA_CREDITO_PROVEEDOR_FECHANull ? (object)"<NULL>" : NOTA_CREDITO_PROVEEDOR_FECHA);
			dynStr.Append("@CBA@FACTURA_NRO_COMPROBANTE=");
			dynStr.Append(FACTURA_NRO_COMPROBANTE);
			dynStr.Append("@CBA@FACTURA_CASO_ID=");
			dynStr.Append(IsFACTURA_CASO_IDNull ? (object)"<NULL>" : FACTURA_CASO_ID);
			dynStr.Append("@CBA@FACTURA_FECHA=");
			dynStr.Append(IsFACTURA_FECHANull ? (object)"<NULL>" : FACTURA_FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@MONEDA_COTIZACION=");
			dynStr.Append(IsMONEDA_COTIZACIONNull ? (object)"<NULL>" : MONEDA_COTIZACION);
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_DETALLE_ID=");
			dynStr.Append(IsFACTURA_PROVEEDOR_DETALLE_IDNull ? (object)"<NULL>" : FACTURA_PROVEEDOR_DETALLE_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_NOMBRE=");
			dynStr.Append(DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(IsCOSTO_UNITARIONull ? (object)"<NULL>" : COSTO_UNITARIO);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@IMPUESTO_PORCENTAJE=");
			dynStr.Append(IsIMPUESTO_PORCENTAJENull ? (object)"<NULL>" : IMPUESTO_PORCENTAJE);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(IsTOTALNull ? (object)"<NULL>" : TOTAL);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@IMPUESTO_MONTO=");
			dynStr.Append(IsIMPUESTO_MONTONull ? (object)"<NULL>" : IMPUESTO_MONTO);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			dynStr.Append("@CBA@NOMBRE_IMPUESTO=");
			dynStr.Append(NOMBRE_IMPUESTO);
			dynStr.Append("@CBA@TEXTO=");
			dynStr.Append(TEXTO);
			dynStr.Append("@CBA@MONTO_CONCEPTO=");
			dynStr.Append(IsMONTO_CONCEPTONull ? (object)"<NULL>" : MONTO_CONCEPTO);
			dynStr.Append("@CBA@ACTIVO_CODIGO=");
			dynStr.Append(ACTIVO_CODIGO);
			return dynStr.ToString();
		}
	} // End of NOTAS_CRED_PRO_DET_INF_COMPRow_Base class
} // End of namespace
