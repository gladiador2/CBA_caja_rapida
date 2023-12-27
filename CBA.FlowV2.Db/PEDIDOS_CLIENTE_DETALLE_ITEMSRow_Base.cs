// <fileinfo name="PEDIDOS_CLIENTE_DETALLE_ITEMSRow_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTE_DETALLE_ITEMSRow"/> that 
	/// represents a record in the <c>PEDIDOS_CLIENTE_DETALLE_ITEMS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PEDIDOS_CLIENTE_DETALLE_ITEMSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTE_DETALLE_ITEMSRow_Base
	{
		private decimal _id;
		private decimal _pedidos_cliente_detalle_id;
		private decimal _cantidad;
		private decimal _unidades;
		private string _comentario;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTE_DETALLE_ITEMSRow_Base"/> class.
		/// </summary>
		public PEDIDOS_CLIENTE_DETALLE_ITEMSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PEDIDOS_CLIENTE_DETALLE_ITEMSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PEDIDOS_CLIENTE_DETALLE_ID != original.PEDIDOS_CLIENTE_DETALLE_ID) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.UNIDADES != original.UNIDADES) return true;
			if (this.COMENTARIO != original.COMENTARIO) return true;
			
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
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDADES</c> column value.
		/// </summary>
		/// <value>The <c>UNIDADES</c> column value.</value>
		public decimal UNIDADES
		{
			get { return _unidades; }
			set { _unidades = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO</c> column value.</value>
		public string COMENTARIO
		{
			get { return _comentario; }
			set { _comentario = value; }
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
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@UNIDADES=");
			dynStr.Append(UNIDADES);
			dynStr.Append("@CBA@COMENTARIO=");
			dynStr.Append(COMENTARIO);
			return dynStr.ToString();
		}
	} // End of PEDIDOS_CLIENTE_DETALLE_ITEMSRow_Base class
} // End of namespace
