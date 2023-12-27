// <fileinfo name="ORDENES_SERVICIO_DET_INSUMOSRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_DET_INSUMOSRow"/> that 
	/// represents a record in the <c>ORDENES_SERVICIO_DET_INSUMOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERVICIO_DET_INSUMOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_DET_INSUMOSRow_Base
	{
		private decimal _id;
		private decimal _orden_servicio_detalle_id;
		private decimal _articulo_id;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private string _unidad_id;
		private decimal _costo_unitario;
		private bool _costo_unitarioNull = true;
		private decimal _costo_total;
		private bool _costo_totalNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_DET_INSUMOSRow_Base"/> class.
		/// </summary>
		public ORDENES_SERVICIO_DET_INSUMOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERVICIO_DET_INSUMOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_SERVICIO_DETALLE_ID != original.ORDEN_SERVICIO_DETALLE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.IsCOSTO_UNITARIONull != original.IsCOSTO_UNITARIONull) return true;
			if (!this.IsCOSTO_UNITARIONull && !original.IsCOSTO_UNITARIONull)
				if (this.COSTO_UNITARIO != original.COSTO_UNITARIO) return true;
			if (this.IsCOSTO_TOTALNull != original.IsCOSTO_TOTALNull) return true;
			if (!this.IsCOSTO_TOTALNull && !original.IsCOSTO_TOTALNull)
				if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			
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
		/// Gets or sets the <c>ORDEN_SERVICIO_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_SERVICIO_DETALLE_ID</c> column value.</value>
		public decimal ORDEN_SERVICIO_DETALLE_ID
		{
			get { return _orden_servicio_detalle_id; }
			set { _orden_servicio_detalle_id = value; }
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
		/// Gets or sets the <c>UNIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_ID</c> column value.</value>
		public string UNIDAD_ID
		{
			get { return _unidad_id; }
			set { _unidad_id = value; }
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
		/// Gets or sets the <c>COSTO_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_TOTAL</c> column value.</value>
		public decimal COSTO_TOTAL
		{
			get
			{
				if(IsCOSTO_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_total;
			}
			set
			{
				_costo_totalNull = false;
				_costo_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_TOTALNull
		{
			get { return _costo_totalNull; }
			set { _costo_totalNull = value; }
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
			dynStr.Append("@CBA@ORDEN_SERVICIO_DETALLE_ID=");
			dynStr.Append(ORDEN_SERVICIO_DETALLE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(IsCOSTO_UNITARIONull ? (object)"<NULL>" : COSTO_UNITARIO);
			dynStr.Append("@CBA@COSTO_TOTAL=");
			dynStr.Append(IsCOSTO_TOTALNull ? (object)"<NULL>" : COSTO_TOTAL);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERVICIO_DET_INSUMOSRow_Base class
} // End of namespace
