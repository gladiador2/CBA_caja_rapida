// <fileinfo name="ORDENES_SERV_DET_RELACIONESRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERV_DET_RELACIONESRow"/> that 
	/// represents a record in the <c>ORDENES_SERV_DET_RELACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERV_DET_RELACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERV_DET_RELACIONESRow_Base
	{
		private decimal _id;
		private decimal _orden_servicio_det_id;
		private decimal _fc_cliente_det_id;
		private bool _fc_cliente_det_idNull = true;
		private decimal _fc_proveedor_det_id;
		private bool _fc_proveedor_det_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERV_DET_RELACIONESRow_Base"/> class.
		/// </summary>
		public ORDENES_SERV_DET_RELACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERV_DET_RELACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_SERVICIO_DET_ID != original.ORDEN_SERVICIO_DET_ID) return true;
			if (this.IsFC_CLIENTE_DET_IDNull != original.IsFC_CLIENTE_DET_IDNull) return true;
			if (!this.IsFC_CLIENTE_DET_IDNull && !original.IsFC_CLIENTE_DET_IDNull)
				if (this.FC_CLIENTE_DET_ID != original.FC_CLIENTE_DET_ID) return true;
			if (this.IsFC_PROVEEDOR_DET_IDNull != original.IsFC_PROVEEDOR_DET_IDNull) return true;
			if (!this.IsFC_PROVEEDOR_DET_IDNull && !original.IsFC_PROVEEDOR_DET_IDNull)
				if (this.FC_PROVEEDOR_DET_ID != original.FC_PROVEEDOR_DET_ID) return true;
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
		/// Gets or sets the <c>ORDEN_SERVICIO_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_SERVICIO_DET_ID</c> column value.</value>
		public decimal ORDEN_SERVICIO_DET_ID
		{
			get { return _orden_servicio_det_id; }
			set { _orden_servicio_det_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_CLIENTE_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_CLIENTE_DET_ID</c> column value.</value>
		public decimal FC_CLIENTE_DET_ID
		{
			get
			{
				if(IsFC_CLIENTE_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_cliente_det_id;
			}
			set
			{
				_fc_cliente_det_idNull = false;
				_fc_cliente_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_CLIENTE_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_CLIENTE_DET_IDNull
		{
			get { return _fc_cliente_det_idNull; }
			set { _fc_cliente_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FC_PROVEEDOR_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FC_PROVEEDOR_DET_ID</c> column value.</value>
		public decimal FC_PROVEEDOR_DET_ID
		{
			get
			{
				if(IsFC_PROVEEDOR_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fc_proveedor_det_id;
			}
			set
			{
				_fc_proveedor_det_idNull = false;
				_fc_proveedor_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FC_PROVEEDOR_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFC_PROVEEDOR_DET_IDNull
		{
			get { return _fc_proveedor_det_idNull; }
			set { _fc_proveedor_det_idNull = value; }
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
			dynStr.Append("@CBA@ORDEN_SERVICIO_DET_ID=");
			dynStr.Append(ORDEN_SERVICIO_DET_ID);
			dynStr.Append("@CBA@FC_CLIENTE_DET_ID=");
			dynStr.Append(IsFC_CLIENTE_DET_IDNull ? (object)"<NULL>" : FC_CLIENTE_DET_ID);
			dynStr.Append("@CBA@FC_PROVEEDOR_DET_ID=");
			dynStr.Append(IsFC_PROVEEDOR_DET_IDNull ? (object)"<NULL>" : FC_PROVEEDOR_DET_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERV_DET_RELACIONESRow_Base class
} // End of namespace
