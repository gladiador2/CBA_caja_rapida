// <fileinfo name="NOTAS_CREDITO_PERSONAS_DETRow_Base.cs">
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
	/// The base class for <see cref="NOTAS_CREDITO_PERSONAS_DETRow"/> that 
	/// represents a record in the <c>NOTAS_CREDITO_PERSONAS_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOTAS_CREDITO_PERSONAS_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTAS_CREDITO_PERSONAS_DETRow_Base
	{
		private decimal _id;
		private decimal _nota_credito_persona_id;
		private decimal _factura_cliente_id;
		private bool _factura_cliente_idNull = true;
		private decimal _factura_cliente_detalle_id;
		private bool _factura_cliente_detalle_idNull = true;
		private decimal _factura_sucursal_id;
		private bool _factura_sucursal_idNull = true;
		private decimal _factura_deposito_id;
		private bool _factura_deposito_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _costo_unitario;
		private bool _costo_unitarioNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _impuesto_id;
		private decimal _impuesto_monto;
		private decimal _total;
		private decimal _monto_concepto;
		private bool _monto_conceptoNull = true;
		private string _observacion;
		private decimal _texto_predefinido_id;
		private bool _texto_predefinido_idNull = true;
		private string _a_consignacion;
		private decimal _activo_id;
		private bool _activo_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTAS_CREDITO_PERSONAS_DETRow_Base"/> class.
		/// </summary>
		public NOTAS_CREDITO_PERSONAS_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOTAS_CREDITO_PERSONAS_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOTA_CREDITO_PERSONA_ID != original.NOTA_CREDITO_PERSONA_ID) return true;
			if (this.IsFACTURA_CLIENTE_IDNull != original.IsFACTURA_CLIENTE_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_IDNull && !original.IsFACTURA_CLIENTE_IDNull)
				if (this.FACTURA_CLIENTE_ID != original.FACTURA_CLIENTE_ID) return true;
			if (this.IsFACTURA_CLIENTE_DETALLE_IDNull != original.IsFACTURA_CLIENTE_DETALLE_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_DETALLE_IDNull && !original.IsFACTURA_CLIENTE_DETALLE_IDNull)
				if (this.FACTURA_CLIENTE_DETALLE_ID != original.FACTURA_CLIENTE_DETALLE_ID) return true;
			if (this.IsFACTURA_SUCURSAL_IDNull != original.IsFACTURA_SUCURSAL_IDNull) return true;
			if (!this.IsFACTURA_SUCURSAL_IDNull && !original.IsFACTURA_SUCURSAL_IDNull)
				if (this.FACTURA_SUCURSAL_ID != original.FACTURA_SUCURSAL_ID) return true;
			if (this.IsFACTURA_DEPOSITO_IDNull != original.IsFACTURA_DEPOSITO_IDNull) return true;
			if (!this.IsFACTURA_DEPOSITO_IDNull && !original.IsFACTURA_DEPOSITO_IDNull)
				if (this.FACTURA_DEPOSITO_ID != original.FACTURA_DEPOSITO_ID) return true;
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
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IMPUESTO_MONTO != original.IMPUESTO_MONTO) return true;
			if (this.TOTAL != original.TOTAL) return true;
			if (this.IsMONTO_CONCEPTONull != original.IsMONTO_CONCEPTONull) return true;
			if (!this.IsMONTO_CONCEPTONull && !original.IsMONTO_CONCEPTONull)
				if (this.MONTO_CONCEPTO != original.MONTO_CONCEPTO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsTEXTO_PREDEFINIDO_IDNull != original.IsTEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_IDNull && !original.IsTEXTO_PREDEFINIDO_IDNull)
				if (this.TEXTO_PREDEFINIDO_ID != original.TEXTO_PREDEFINIDO_ID) return true;
			if (this.A_CONSIGNACION != original.A_CONSIGNACION) return true;
			if (this.IsACTIVO_IDNull != original.IsACTIVO_IDNull) return true;
			if (!this.IsACTIVO_IDNull && !original.IsACTIVO_IDNull)
				if (this.ACTIVO_ID != original.ACTIVO_ID) return true;
			
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
		/// Gets or sets the <c>NOTA_CREDITO_PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PERSONA_ID</c> column value.</value>
		public decimal NOTA_CREDITO_PERSONA_ID
		{
			get { return _nota_credito_persona_id; }
			set { _nota_credito_persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_ID
		{
			get
			{
				if(IsFACTURA_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_cliente_id;
			}
			set
			{
				_factura_cliente_idNull = false;
				_factura_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CLIENTE_IDNull
		{
			get { return _factura_cliente_idNull; }
			set { _factura_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_DETALLE_ID
		{
			get
			{
				if(IsFACTURA_CLIENTE_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_cliente_detalle_id;
			}
			set
			{
				_factura_cliente_detalle_idNull = false;
				_factura_cliente_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_CLIENTE_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_CLIENTE_DETALLE_IDNull
		{
			get { return _factura_cliente_detalle_idNull; }
			set { _factura_cliente_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_SUCURSAL_ID</c> column value.</value>
		public decimal FACTURA_SUCURSAL_ID
		{
			get
			{
				if(IsFACTURA_SUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_sucursal_id;
			}
			set
			{
				_factura_sucursal_idNull = false;
				_factura_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_SUCURSAL_IDNull
		{
			get { return _factura_sucursal_idNull; }
			set { _factura_sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_DEPOSITO_ID</c> column value.</value>
		public decimal FACTURA_DEPOSITO_ID
		{
			get
			{
				if(IsFACTURA_DEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_deposito_id;
			}
			set
			{
				_factura_deposito_idNull = false;
				_factura_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_DEPOSITO_IDNull
		{
			get { return _factura_deposito_idNull; }
			set { _factura_deposito_idNull = value; }
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
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_MONTO</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_MONTO</c> column value.</value>
		public decimal IMPUESTO_MONTO
		{
			get { return _impuesto_monto; }
			set { _impuesto_monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL</c> column value.</value>
		public decimal TOTAL
		{
			get { return _total; }
			set { _total = value; }
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
		/// Gets or sets the <c>A_CONSIGNACION</c> column value.
		/// </summary>
		/// <value>The <c>A_CONSIGNACION</c> column value.</value>
		public string A_CONSIGNACION
		{
			get { return _a_consignacion; }
			set { _a_consignacion = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@NOTA_CREDITO_PERSONA_ID=");
			dynStr.Append(NOTA_CREDITO_PERSONA_ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_DETALLE_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_DETALLE_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@FACTURA_SUCURSAL_ID=");
			dynStr.Append(IsFACTURA_SUCURSAL_IDNull ? (object)"<NULL>" : FACTURA_SUCURSAL_ID);
			dynStr.Append("@CBA@FACTURA_DEPOSITO_ID=");
			dynStr.Append(IsFACTURA_DEPOSITO_IDNull ? (object)"<NULL>" : FACTURA_DEPOSITO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(IsCOSTO_UNITARIONull ? (object)"<NULL>" : COSTO_UNITARIO);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTO_MONTO=");
			dynStr.Append(IMPUESTO_MONTO);
			dynStr.Append("@CBA@TOTAL=");
			dynStr.Append(TOTAL);
			dynStr.Append("@CBA@MONTO_CONCEPTO=");
			dynStr.Append(IsMONTO_CONCEPTONull ? (object)"<NULL>" : MONTO_CONCEPTO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID);
			dynStr.Append("@CBA@A_CONSIGNACION=");
			dynStr.Append(A_CONSIGNACION);
			dynStr.Append("@CBA@ACTIVO_ID=");
			dynStr.Append(IsACTIVO_IDNull ? (object)"<NULL>" : ACTIVO_ID);
			return dynStr.ToString();
		}
	} // End of NOTAS_CREDITO_PERSONAS_DETRow_Base class
} // End of namespace
