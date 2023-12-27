// <fileinfo name="FACTURAS_PROV_DET_CTB_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROV_DET_CTB_INFO_CRow"/> that 
	/// represents a record in the <c>FACTURAS_PROV_DET_CTB_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_PROV_DET_CTB_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROV_DET_CTB_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _factura_proveedor_detalle_id;
		private decimal _ctb_cuenta_id;
		private string _ctb_cuenta_nombre;
		private string _ctb_cuenta_codigo_completo;
		private decimal _ctb_plan_cuenta_id;
		private string _ctb_plan_cuenta_nombre;
		private decimal _porcentaje;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROV_DET_CTB_INFO_CRow_Base"/> class.
		/// </summary>
		public FACTURAS_PROV_DET_CTB_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_PROV_DET_CTB_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FACTURA_PROVEEDOR_DETALLE_ID != original.FACTURA_PROVEEDOR_DETALLE_ID) return true;
			if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.CTB_CUENTA_NOMBRE != original.CTB_CUENTA_NOMBRE) return true;
			if (this.CTB_CUENTA_CODIGO_COMPLETO != original.CTB_CUENTA_CODIGO_COMPLETO) return true;
			if (this.CTB_PLAN_CUENTA_ID != original.CTB_PLAN_CUENTA_ID) return true;
			if (this.CTB_PLAN_CUENTA_NOMBRE != original.CTB_PLAN_CUENTA_NOMBRE) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			
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
		/// Gets or sets the <c>FACTURA_PROVEEDOR_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_DETALLE_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_DETALLE_ID
		{
			get { return _factura_proveedor_detalle_id; }
			set { _factura_proveedor_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get { return _ctb_cuenta_id; }
			set { _ctb_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_CUENTA_NOMBRE
		{
			get { return _ctb_cuenta_nombre; }
			set { _ctb_cuenta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_CODIGO_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_CODIGO_COMPLETO</c> column value.</value>
		public string CTB_CUENTA_CODIGO_COMPLETO
		{
			get { return _ctb_cuenta_codigo_completo; }
			set { _ctb_cuenta_codigo_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_ID</c> column value.</value>
		public decimal CTB_PLAN_CUENTA_ID
		{
			get { return _ctb_plan_cuenta_id; }
			set { _ctb_plan_cuenta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTA_NOMBRE</c> column value.</value>
		public string CTB_PLAN_CUENTA_NOMBRE
		{
			get { return _ctb_plan_cuenta_nombre; }
			set { _ctb_plan_cuenta_nombre = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_DETALLE_ID=");
			dynStr.Append(FACTURA_PROVEEDOR_DETALLE_ID);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(CTB_CUENTA_ID);
			dynStr.Append("@CBA@CTB_CUENTA_NOMBRE=");
			dynStr.Append(CTB_CUENTA_NOMBRE);
			dynStr.Append("@CBA@CTB_CUENTA_CODIGO_COMPLETO=");
			dynStr.Append(CTB_CUENTA_CODIGO_COMPLETO);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_ID=");
			dynStr.Append(CTB_PLAN_CUENTA_ID);
			dynStr.Append("@CBA@CTB_PLAN_CUENTA_NOMBRE=");
			dynStr.Append(CTB_PLAN_CUENTA_NOMBRE);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			return dynStr.ToString();
		}
	} // End of FACTURAS_PROV_DET_CTB_INFO_CRow_Base class
} // End of namespace
