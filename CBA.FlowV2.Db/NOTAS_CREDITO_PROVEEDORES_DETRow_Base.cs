// <fileinfo name="NOTAS_CREDITO_PROVEEDORES_DETRow_Base.cs">
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
	/// The base class for <see cref="NOTAS_CREDITO_PROVEEDORES_DETRow"/> that 
	/// represents a record in the <c>NOTAS_CREDITO_PROVEEDORES_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOTAS_CREDITO_PROVEEDORES_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTAS_CREDITO_PROVEEDORES_DETRow_Base
	{
		private decimal _id;
		private decimal _nota_credito_proveedor_id;
		private decimal _factura_proveedor_id;
		private decimal _factura_proveedor_detalle_id;
		private bool _factura_proveedor_detalle_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
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
		private decimal _activo_id;
		private bool _activo_idNull = true;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private decimal _monto_concepto;
		private bool _monto_conceptoNull = true;
		private decimal _impuesto_id;
		private bool _impuesto_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTAS_CREDITO_PROVEEDORES_DETRow_Base"/> class.
		/// </summary>
		public NOTAS_CREDITO_PROVEEDORES_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOTAS_CREDITO_PROVEEDORES_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOTA_CREDITO_PROVEEDOR_ID != original.NOTA_CREDITO_PROVEEDOR_ID) return true;
			if (this.FACTURA_PROVEEDOR_ID != original.FACTURA_PROVEEDOR_ID) return true;
			if (this.IsFACTURA_PROVEEDOR_DETALLE_IDNull != original.IsFACTURA_PROVEEDOR_DETALLE_IDNull) return true;
			if (!this.IsFACTURA_PROVEEDOR_DETALLE_IDNull && !original.IsFACTURA_PROVEEDOR_DETALLE_IDNull)
				if (this.FACTURA_PROVEEDOR_DETALLE_ID != original.FACTURA_PROVEEDOR_DETALLE_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
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
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.IsMONTO_CONCEPTONull != original.IsMONTO_CONCEPTONull) return true;
			if (!this.IsMONTO_CONCEPTONull && !original.IsMONTO_CONCEPTONull)
				if (this.MONTO_CONCEPTO != original.MONTO_CONCEPTO) return true;
			if (this.IsIMPUESTO_IDNull != original.IsIMPUESTO_IDNull) return true;
			if (!this.IsIMPUESTO_IDNull && !original.IsIMPUESTO_IDNull)
				if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			
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
		/// Gets or sets the <c>ACTIVO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ACTIVO_ID</c> column value.</value>
		public decimal ACTIVO_ID
		{
			get
			{
				if(IsACTIVO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _activo_id;
			}
			set
			{
				_activo_idNull = false;
				_activo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ACTIVO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsACTIVO_IDNull
		{
			get { return _activo_idNull; }
			set { _activo_idNull = value; }
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
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_DETALLE_ID=");
			dynStr.Append(IsFACTURA_PROVEEDOR_DETALLE_IDNull ? (object)"<NULL>" : FACTURA_PROVEEDOR_DETALLE_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
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
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@MONTO_CONCEPTO=");
			dynStr.Append(IsMONTO_CONCEPTONull ? (object)"<NULL>" : MONTO_CONCEPTO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IsIMPUESTO_IDNull ? (object)"<NULL>" : IMPUESTO_ID);
			return dynStr.ToString();
		}
	} // End of NOTAS_CREDITO_PROVEEDORES_DETRow_Base class
} // End of namespace
