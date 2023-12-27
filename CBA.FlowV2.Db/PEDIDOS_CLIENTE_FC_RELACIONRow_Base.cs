// <fileinfo name="PEDIDOS_CLIENTE_FC_RELACIONRow_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTE_FC_RELACIONRow"/> that 
	/// represents a record in the <c>PEDIDOS_CLIENTE_FC_RELACION</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PEDIDOS_CLIENTE_FC_RELACIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTE_FC_RELACIONRow_Base
	{
		private decimal _id;
		private decimal _pedidos_cliente_detalle_id;
		private decimal _factura_cliente_detalle_id;
		private bool _factura_cliente_detalle_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTE_FC_RELACIONRow_Base"/> class.
		/// </summary>
		public PEDIDOS_CLIENTE_FC_RELACIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PEDIDOS_CLIENTE_FC_RELACIONRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PEDIDOS_CLIENTE_DETALLE_ID != original.PEDIDOS_CLIENTE_DETALLE_ID) return true;
			if (this.IsFACTURA_CLIENTE_DETALLE_IDNull != original.IsFACTURA_CLIENTE_DETALLE_IDNull) return true;
			if (!this.IsFACTURA_CLIENTE_DETALLE_IDNull && !original.IsFACTURA_CLIENTE_DETALLE_IDNull)
				if (this.FACTURA_CLIENTE_DETALLE_ID != original.FACTURA_CLIENTE_DETALLE_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			
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
		/// Gets or sets the <c>PEDIDOS_CLIENTE_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>PEDIDOS_CLIENTE_DETALLE_ID</c> column value.</value>
		public decimal PEDIDOS_CLIENTE_DETALLE_ID
		{
			get { return _pedidos_cliente_detalle_id; }
			set { _pedidos_cliente_detalle_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@PEDIDOS_CLIENTE_DETALLE_ID=");
			dynStr.Append(PEDIDOS_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_DETALLE_ID=");
			dynStr.Append(IsFACTURA_CLIENTE_DETALLE_IDNull ? (object)"<NULL>" : FACTURA_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			return dynStr.ToString();
		}
	} // End of PEDIDOS_CLIENTE_FC_RELACIONRow_Base class
} // End of namespace
