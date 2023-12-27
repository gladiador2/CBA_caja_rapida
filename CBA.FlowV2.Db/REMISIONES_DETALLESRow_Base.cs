// <fileinfo name="REMISIONES_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="REMISIONES_DETALLESRow"/> that 
	/// represents a record in the <c>REMISIONES_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="REMISIONES_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REMISIONES_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _remision_id;
		private string _unidad_medida_id;
		private decimal _cantidad;
		private string _observacion;
		private string _estado;
		private decimal _articulo_id;
		private decimal _lote_id;
		private decimal _caso_origen_id;
		private decimal _pedido_cliente_detalle_id;
		private bool _pedido_cliente_detalle_idNull = true;
		private decimal _factura_cliente_detalle_id;
		private bool _factura_cliente_detalle_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="REMISIONES_DETALLESRow_Base"/> class.
		/// </summary>
		public REMISIONES_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(REMISIONES_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.REMISION_ID != original.REMISION_ID) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.CASO_ORIGEN_ID != original.CASO_ORIGEN_ID) return true;
			if (this.IsPEDIDO_CLIENTE_DETALLE_IDNull != original.IsPEDIDO_CLIENTE_DETALLE_IDNull) return true;
			if (!this.IsPEDIDO_CLIENTE_DETALLE_IDNull && !original.IsPEDIDO_CLIENTE_DETALLE_IDNull)
				if (this.PEDIDO_CLIENTE_DETALLE_ID != original.PEDIDO_CLIENTE_DETALLE_ID) return true;
			if (this.IsFACTURA_CLIENTE_DETALLE_IDNull != original.IsFACTURA_CLIENTE_DETALLE_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_DETALLE_IDNull && !original.IsFACTURA_CLIENTE_DETALLE_IDNull)
				if (this.FACTURA_CLIENTE_DETALLE_ID != original.FACTURA_CLIENTE_DETALLE_ID) return true;
			
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
		/// Gets or sets the <c>REMISION_ID</c> column value.
		/// </summary>
		/// <value>The <c>REMISION_ID</c> column value.</value>
		public decimal REMISION_ID
		{
			get { return _remision_id; }
			set { _remision_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get { return _lote_id; }
			set { _lote_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ORIGEN_ID</c> column value.</value>
		public decimal CASO_ORIGEN_ID
		{
			get { return _caso_origen_id; }
			set { _caso_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PEDIDO_CLIENTE_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PEDIDO_CLIENTE_DETALLE_ID</c> column value.</value>
		public decimal PEDIDO_CLIENTE_DETALLE_ID
		{
			get
			{
				if(IsPEDIDO_CLIENTE_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pedido_cliente_detalle_id;
			}
			set
			{
				_pedido_cliente_detalle_idNull = false;
				_pedido_cliente_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PEDIDO_CLIENTE_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPEDIDO_CLIENTE_DETALLE_IDNull
		{
			get { return _pedido_cliente_detalle_idNull; }
			set { _pedido_cliente_detalle_idNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@REMISION_ID=");
			dynStr.Append(REMISION_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@CASO_ORIGEN_ID=");
			dynStr.Append(CASO_ORIGEN_ID);
			dynStr.Append("@CBA@PEDIDO_CLIENTE_DETALLE_ID=");
			dynStr.Append(IsPEDIDO_CLIENTE_DETALLE_IDNull ? (object)"<NULL>" : PEDIDO_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_DETALLE_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_DETALLE_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_DETALLE_ID);
			return dynStr.ToString();
		}
	} // End of REMISIONES_DETALLESRow_Base class
} // End of namespace
