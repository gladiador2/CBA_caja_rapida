// <fileinfo name="CTB_ASIENTOS_DET_CENT_C_INFO_CRow_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_DET_CENT_C_INFO_CRow"/> that 
	/// represents a record in the <c>CTB_ASIENTOS_DET_CENT_C_INFO_C</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_ASIENTOS_DET_CENT_C_INFO_CRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_DET_CENT_C_INFO_CRow_Base
	{
		private decimal _id;
		private decimal _ctb_asiento_detalle_id;
		private string _ctb_asiento_detalle_observ;
		private decimal _centro_costo_id;
		private string _centro_costo_nombre;
		private string _centro_costo_abreviatura;
		private decimal _centro_costo_orden;
		private decimal _porcentaje;
		private decimal _factura_prov_det_cent_c_id;
		private bool _factura_prov_det_cent_c_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_DET_CENT_C_INFO_CRow_Base"/> class.
		/// </summary>
		public CTB_ASIENTOS_DET_CENT_C_INFO_CRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_ASIENTOS_DET_CENT_C_INFO_CRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CTB_ASIENTO_DETALLE_ID != original.CTB_ASIENTO_DETALLE_ID) return true;
			if (this.CTB_ASIENTO_DETALLE_OBSERV != original.CTB_ASIENTO_DETALLE_OBSERV) return true;
			if (this.CENTRO_COSTO_ID != original.CENTRO_COSTO_ID) return true;
			if (this.CENTRO_COSTO_NOMBRE != original.CENTRO_COSTO_NOMBRE) return true;
			if (this.CENTRO_COSTO_ABREVIATURA != original.CENTRO_COSTO_ABREVIATURA) return true;
			if (this.CENTRO_COSTO_ORDEN != original.CENTRO_COSTO_ORDEN) return true;
			if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.IsFACTURA_PROV_DET_CENT_C_IDNull != original.IsFACTURA_PROV_DET_CENT_C_IDNull) return true;
			if (!this.IsFACTURA_PROV_DET_CENT_C_IDNull && !original.IsFACTURA_PROV_DET_CENT_C_IDNull)
				if (this.FACTURA_PROV_DET_CENT_C_ID != original.FACTURA_PROV_DET_CENT_C_ID) return true;
			
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
		/// Gets or sets the <c>CTB_ASIENTO_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_DETALLE_ID</c> column value.</value>
		public decimal CTB_ASIENTO_DETALLE_ID
		{
			get { return _ctb_asiento_detalle_id; }
			set { _ctb_asiento_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_ASIENTO_DETALLE_OBSERV</c> column value.
		/// </summary>
		/// <value>The <c>CTB_ASIENTO_DETALLE_OBSERV</c> column value.</value>
		public string CTB_ASIENTO_DETALLE_OBSERV
		{
			get { return _ctb_asiento_detalle_observ; }
			set { _ctb_asiento_detalle_observ = value; }
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
		/// Gets or sets the <c>FACTURA_PROV_DET_CENT_C_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FACTURA_PROV_DET_CENT_C_ID</c> column value.</value>
		public decimal FACTURA_PROV_DET_CENT_C_ID
		{
			get
			{
				if(IsFACTURA_PROV_DET_CENT_C_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _factura_prov_det_cent_c_id;
			}
			set
			{
				_factura_prov_det_cent_c_idNull = false;
				_factura_prov_det_cent_c_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FACTURA_PROV_DET_CENT_C_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFACTURA_PROV_DET_CENT_C_IDNull
		{
			get { return _factura_prov_det_cent_c_idNull; }
			set { _factura_prov_det_cent_c_idNull = value; }
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
			dynStr.Append("@CBA@CTB_ASIENTO_DETALLE_ID=");
			dynStr.Append(CTB_ASIENTO_DETALLE_ID);
			dynStr.Append("@CBA@CTB_ASIENTO_DETALLE_OBSERV=");
			dynStr.Append(CTB_ASIENTO_DETALLE_OBSERV);
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
			dynStr.Append("@CBA@FACTURA_PROV_DET_CENT_C_ID=");
			dynStr.Append(IsFACTURA_PROV_DET_CENT_C_IDNull ? (object)"<NULL>" : FACTURA_PROV_DET_CENT_C_ID);
			return dynStr.ToString();
		}
	} // End of CTB_ASIENTOS_DET_CENT_C_INFO_CRow_Base class
} // End of namespace
