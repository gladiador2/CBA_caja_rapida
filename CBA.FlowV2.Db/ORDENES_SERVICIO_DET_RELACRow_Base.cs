// <fileinfo name="ORDENES_SERVICIO_DET_RELACRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_DET_RELACRow"/> that 
	/// represents a record in the <c>ORDENES_SERVICIO_DET_RELAC</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_SERVICIO_DET_RELACRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_DET_RELACRow_Base
	{
		private decimal _id;
		private decimal _ordenes_servicio_detalles_id;
		private decimal _uso_de_insumos_detalle_id;
		private decimal _cantidad;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_DET_RELACRow_Base"/> class.
		/// </summary>
		public ORDENES_SERVICIO_DET_RELACRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_SERVICIO_DET_RELACRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDENES_SERVICIO_DETALLES_ID != original.ORDENES_SERVICIO_DETALLES_ID) return true;
			if (this.USO_DE_INSUMOS_DETALLE_ID != original.USO_DE_INSUMOS_DETALLE_ID) return true;
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
		/// Gets or sets the <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</value>
		public decimal ORDENES_SERVICIO_DETALLES_ID
		{
			get { return _ordenes_servicio_detalles_id; }
			set { _ordenes_servicio_detalles_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USO_DE_INSUMOS_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>USO_DE_INSUMOS_DETALLE_ID</c> column value.</value>
		public decimal USO_DE_INSUMOS_DETALLE_ID
		{
			get { return _uso_de_insumos_detalle_id; }
			set { _uso_de_insumos_detalle_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@ORDENES_SERVICIO_DETALLES_ID=");
			dynStr.Append(ORDENES_SERVICIO_DETALLES_ID);
			dynStr.Append("@CBA@USO_DE_INSUMOS_DETALLE_ID=");
			dynStr.Append(USO_DE_INSUMOS_DETALLE_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			return dynStr.ToString();
		}
	} // End of ORDENES_SERVICIO_DET_RELACRow_Base class
} // End of namespace
