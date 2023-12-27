// <fileinfo name="ORDENES_COMPRA_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ORDENES_COMPRA_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ORDENES_COMPRA_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ORDENES_COMPRA_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_COMPRA_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _orden_compra_id;
		private decimal _articulo_id;
		private string _articulo_codigo_empresa;
		private string _articulo_descripcion;
		private decimal _cantidad;
		private string _unidad_medida_id;
		private string _unidad_descripcion;
		private decimal _costo_unitario;
		private decimal _costo_total;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_COMPRA_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ORDENES_COMPRA_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ORDENES_COMPRA_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ORDEN_COMPRA_ID != original.ORDEN_COMPRA_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_CODIGO_EMPRESA != original.ARTICULO_CODIGO_EMPRESA) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.UNIDAD_DESCRIPCION != original.UNIDAD_DESCRIPCION) return true;
			if (this.COSTO_UNITARIO != original.COSTO_UNITARIO) return true;
			if (this.COSTO_TOTAL != original.COSTO_TOTAL) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			
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
		/// Gets or sets the <c>ORDEN_COMPRA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN_COMPRA_ID</c> column value.</value>
		public decimal ORDEN_COMPRA_ID
		{
			get { return _orden_compra_id; }
			set { _orden_compra_id = value; }
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
		/// Gets or sets the <c>ARTICULO_CODIGO_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO_EMPRESA</c> column value.</value>
		public string ARTICULO_CODIGO_EMPRESA
		{
			get { return _articulo_codigo_empresa; }
			set { _articulo_codigo_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_DESCRIPCION
		{
			get { return _articulo_descripcion; }
			set { _articulo_descripcion = value; }
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
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_DESCRIPCION</c> column value.</value>
		public string UNIDAD_DESCRIPCION
		{
			get { return _unidad_descripcion; }
			set { _unidad_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_UNITARIO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_UNITARIO</c> column value.</value>
		public decimal COSTO_UNITARIO
		{
			get { return _costo_unitario; }
			set { _costo_unitario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_TOTAL</c> column value.</value>
		public decimal COSTO_TOTAL
		{
			get { return _costo_total; }
			set { _costo_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ASOCIADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_ID</c> column value.</value>
		public decimal CASO_ASOCIADO_ID
		{
			get
			{
				if(IsCASO_ASOCIADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_asociado_id;
			}
			set
			{
				_caso_asociado_idNull = false;
				_caso_asociado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ASOCIADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ASOCIADO_IDNull
		{
			get { return _caso_asociado_idNull; }
			set { _caso_asociado_idNull = value; }
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
			dynStr.Append("@CBA@ORDEN_COMPRA_ID=");
			dynStr.Append(ORDEN_COMPRA_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO_EMPRESA=");
			dynStr.Append(ARTICULO_CODIGO_EMPRESA);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@UNIDAD_DESCRIPCION=");
			dynStr.Append(UNIDAD_DESCRIPCION);
			dynStr.Append("@CBA@COSTO_UNITARIO=");
			dynStr.Append(COSTO_UNITARIO);
			dynStr.Append("@CBA@COSTO_TOTAL=");
			dynStr.Append(COSTO_TOTAL);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			return dynStr.ToString();
		}
	} // End of ORDENES_COMPRA_DET_INFO_COMPLRow_Base class
} // End of namespace
