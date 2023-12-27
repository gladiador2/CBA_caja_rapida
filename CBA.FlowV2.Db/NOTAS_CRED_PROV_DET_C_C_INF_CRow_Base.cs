// <fileinfo name="NOTAS_CRED_PROV_DET_C_C_INF_CRow_Base.cs">
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
	/// The base class for <see cref="NOTAS_CRED_PROV_DET_C_C_INF_CRow"/> that 
	/// represents a record in the <c>NOTAS_CRED_PROV_DET_C_C_INF_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOTAS_CRED_PROV_DET_C_C_INF_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTAS_CRED_PROV_DET_C_C_INF_CRow_Base
	{
		private decimal _id;
		private decimal _nota_credito_proveedor_det_id;
		private decimal _centro_costo_id;
		private string _centro_costo_nombre;
		private string _centro_costo_abreviatura;
		private decimal _centro_costo_orden;
		private decimal _porcentaje;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTAS_CRED_PROV_DET_C_C_INF_CRow_Base"/> class.
		/// </summary>
		public NOTAS_CRED_PROV_DET_C_C_INF_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOTAS_CRED_PROV_DET_C_C_INF_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOTA_CREDITO_PROVEEDOR_DET_ID != original.NOTA_CREDITO_PROVEEDOR_DET_ID) return true;
			if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.CENTRO_COSTO_NOMBRE != original.CENTRO_COSTO_NOMBRE) return true;
			if (this.CENTRO_COSTO_ABREVIATURA != original.CENTRO_COSTO_ABREVIATURA) return true;
			if (this.CENTRO_COSTO_ORDEN != original.CENTRO_COSTO_ORDEN) return true;
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
		/// Gets or sets the <c>NOTA_CREDITO_PROVEEDOR_DET_ID</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PROVEEDOR_DET_ID</c> column value.</value>
		public decimal NOTA_CREDITO_PROVEEDOR_DET_ID
		{
			get { return _nota_credito_proveedor_det_id; }
			set { _nota_credito_proveedor_det_id = value; }
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
		/// Gets or sets the <c>CENTRO_COSTO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_NOMBRE</c> column value.</value>
		public string CENTRO_COSTO_NOMBRE
		{
			get { return _centro_costo_nombre; }
			set { _centro_costo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ABREVIATURA</c> column value.</value>
		public string CENTRO_COSTO_ABREVIATURA
		{
			get { return _centro_costo_abreviatura; }
			set { _centro_costo_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CENTRO_COSTO_ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>CENTRO_COSTO_ORDEN</c> column value.</value>
		public decimal CENTRO_COSTO_ORDEN
		{
			get { return _centro_costo_orden; }
			set { _centro_costo_orden = value; }
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
			dynStr.Append("@CBA@NOTA_CREDITO_PROVEEDOR_DET_ID=");
			dynStr.Append(NOTA_CREDITO_PROVEEDOR_DET_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_ID=");
			dynStr.Append(CENTRO_COSTO_ID);
			dynStr.Append("@CBA@CENTRO_COSTO_NOMBRE=");
			dynStr.Append(CENTRO_COSTO_NOMBRE);
			dynStr.Append("@CBA@CENTRO_COSTO_ABREVIATURA=");
			dynStr.Append(CENTRO_COSTO_ABREVIATURA);
			dynStr.Append("@CBA@CENTRO_COSTO_ORDEN=");
			dynStr.Append(CENTRO_COSTO_ORDEN);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(PORCENTAJE);
			return dynStr.ToString();
		}
	} // End of NOTAS_CRED_PROV_DET_C_C_INF_CRow_Base class
} // End of namespace
