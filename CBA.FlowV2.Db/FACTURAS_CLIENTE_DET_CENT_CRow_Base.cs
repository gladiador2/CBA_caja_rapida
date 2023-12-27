// <fileinfo name="FACTURAS_CLIENTE_DET_CENT_CRow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DET_CENT_CRow"/> that 
	/// represents a record in the <c>FACTURAS_CLIENTE_DET_CENT_C</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_CLIENTE_DET_CENT_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DET_CENT_CRow_Base
	{
		private decimal _id;
		private decimal _factura_cliente_detalle_id;
		private decimal _centro_costo_id;
		private decimal _porcentaje;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DET_CENT_CRow_Base"/> class.
		/// </summary>
		public FACTURAS_CLIENTE_DET_CENT_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_CLIENTE_DET_CENT_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FACTURA_CLIENTE_DETALLE_ID != original.FACTURA_CLIENTE_DETALLE_ID) return true;
			if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_DETALLE_ID
		{
			get { return _factura_cliente_detalle_id; }
			set { _factura_cliente_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ID</c> column value.</value>
		public decimal CENTRO_COSTO_ID
		{
			get { return _centro_costo_id; }
			set { _centro_costo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get { return _porcentaje; }
			set { _porcentaje = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FACTURA_CLIENTE_DETALLE_ID=");
			dynStr.Append(FACTURA_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(CENTRO_COSTO_ID);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of FACTURAS_CLIENTE_DET_CENT_CRow_Base class
} // End of namespace
