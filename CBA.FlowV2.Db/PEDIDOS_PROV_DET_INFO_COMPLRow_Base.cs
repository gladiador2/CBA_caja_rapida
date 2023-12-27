// <fileinfo name="PEDIDOS_PROV_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_PROV_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>PEDIDOS_PROV_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PEDIDOS_PROV_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_PROV_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _pedidos_proveedor_id;
		private decimal _articulo_id;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private string _lote;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _descripcion_proveedor;
		private string _unidad_id;
		private string _unidad_medida;
		private decimal _cantidad_embalada;
		private decimal _cantidad_unidad;
		private decimal _cantidad_por_caja;
		private decimal _cantidad_unitaria_total;
		private decimal _precio_bruto;
		private decimal _precio_con_dto;
		private decimal _porcentaje_dto;
		private decimal _impuesto_porcentaje;
		private bool _impuesto_porcentajeNull = true;
		private decimal _total_monto_bruto;
		private decimal _total_monto_dto;
		private decimal _total_monto_impuesto_dto;
		private decimal _total_neto;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_PROV_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public PEDIDOS_PROV_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PEDIDOS_PROV_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PEDIDOS_PROVEEDOR_ID != original.PEDIDOS_PROVEEDOR_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.IsARTICULO_FAMILIA_IDNull != original.IsARTICULO_FAMILIA_IDNull) return true;
			if (!this.IsARTICULO_FAMILIA_IDNull && !original.IsARTICULO_FAMILIA_IDNull)
				if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.IsARTICULO_GRUPO_IDNull != original.IsARTICULO_GRUPO_IDNull) return true;
			if (!this.IsARTICULO_GRUPO_IDNull && !original.IsARTICULO_GRUPO_IDNull)
				if (this.ARTICULO_GRUPO_ID != original.ARTICULO_GRUPO_ID) return true;
			if (this.IsARTICULO_SUBGRUPO_IDNull != original.IsARTICULO_SUBGRUPO_IDNull) return true;
			if (!this.IsARTICULO_SUBGRUPO_IDNull && !original.IsARTICULO_SUBGRUPO_IDNull)
				if (this.ARTICULO_SUBGRUPO_ID != original.ARTICULO_SUBGRUPO_ID) return true;
			if (this.DESCRIPCION_PROVEEDOR != original.DESCRIPCION_PROVEEDOR) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.UNIDAD_MEDIDA != original.UNIDAD_MEDIDA) return true;
			if (this.CANTIDAD_EMBALADA != original.CANTIDAD_EMBALADA) return true;
			if (this.CANTIDAD_UNIDAD != original.CANTIDAD_UNIDAD) return true;
			if (this.CANTIDAD_POR_CAJA != original.CANTIDAD_POR_CAJA) return true;
			if (this.CANTIDAD_UNITARIA_TOTAL != original.CANTIDAD_UNITARIA_TOTAL) return true;
			if (this.PRECIO_BRUTO != original.PRECIO_BRUTO) return true;
			if (this.PRECIO_CON_DTO != original.PRECIO_CON_DTO) return true;
			if (this.PORCENTAJE_DTO != original.PORCENTAJE_DTO) return true;
			if (this.IsIMPUESTO_PORCENTAJENull != original.IsIMPUESTO_PORCENTAJENull) return true;
			if (!this.IsIMPUESTO_PORCENTAJENull && !original.IsIMPUESTO_PORCENTAJENull)
				if (this.IMPUESTO_PORCENTAJE != original.IMPUESTO_PORCENTAJE) return true;
			if (this.TOTAL_MONTO_BRUTO != original.TOTAL_MONTO_BRUTO) return true;
			if (this.TOTAL_MONTO_DTO != original.TOTAL_MONTO_DTO) return true;
			if (this.TOTAL_MONTO_IMPUESTO_DTO != original.TOTAL_MONTO_IMPUESTO_DTO) return true;
			if (this.TOTAL_NETO != original.TOTAL_NETO) return true;
			
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
		/// Gets or sets the <c>PEDIDOS_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PEDIDOS_PROVEEDOR_ID</c> column value.</value>
		public decimal PEDIDOS_PROVEEDOR_ID
		{
			get { return _pedidos_proveedor_id; }
			set { _pedidos_proveedor_id = value; }
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
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get
			{
				if(IsLOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lote_id;
			}
			set
			{
				_lote_idNull = false;
				_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOTE_IDNull
		{
			get { return _lote_idNull; }
			set { _lote_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE</c> column value.</value>
		public string LOTE
		{
			get { return _lote; }
			set { _lote = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULO_FAMILIA_ID
		{
			get
			{
				if(IsARTICULO_FAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_familia_id;
			}
			set
			{
				_articulo_familia_idNull = false;
				_articulo_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_FAMILIA_IDNull
		{
			get { return _articulo_familia_idNull; }
			set { _articulo_familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_ID</c> column value.</value>
		public decimal ARTICULO_GRUPO_ID
		{
			get
			{
				if(IsARTICULO_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_grupo_id;
			}
			set
			{
				_articulo_grupo_idNull = false;
				_articulo_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_GRUPO_IDNull
		{
			get { return _articulo_grupo_idNull; }
			set { _articulo_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_ID</c> column value.</value>
		public decimal ARTICULO_SUBGRUPO_ID
		{
			get
			{
				if(IsARTICULO_SUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_subgrupo_id;
			}
			set
			{
				_articulo_subgrupo_idNull = false;
				_articulo_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_SUBGRUPO_IDNull
		{
			get { return _articulo_subgrupo_idNull; }
			set { _articulo_subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_PROVEEDOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_PROVEEDOR</c> column value.</value>
		public string DESCRIPCION_PROVEEDOR
		{
			get { return _descripcion_proveedor; }
			set { _descripcion_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_ID</c> column value.</value>
		public string UNIDAD_ID
		{
			get { return _unidad_id; }
			set { _unidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNIDAD_MEDIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA</c> column value.</value>
		public string UNIDAD_MEDIDA
		{
			get { return _unidad_medida; }
			set { _unidad_medida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_EMBALADA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_EMBALADA</c> column value.</value>
		public decimal CANTIDAD_EMBALADA
		{
			get { return _cantidad_embalada; }
			set { _cantidad_embalada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNIDAD</c> column value.</value>
		public decimal CANTIDAD_UNIDAD
		{
			get { return _cantidad_unidad; }
			set { _cantidad_unidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_POR_CAJA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_POR_CAJA</c> column value.</value>
		public decimal CANTIDAD_POR_CAJA
		{
			get { return _cantidad_por_caja; }
			set { _cantidad_por_caja = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL
		{
			get { return _cantidad_unitaria_total; }
			set { _cantidad_unitaria_total = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO_BRUTO</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_BRUTO</c> column value.</value>
		public decimal PRECIO_BRUTO
		{
			get { return _precio_bruto; }
			set { _precio_bruto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO_CON_DTO</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_CON_DTO</c> column value.</value>
		public decimal PRECIO_CON_DTO
		{
			get { return _precio_con_dto; }
			set { _precio_con_dto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DTO</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DTO</c> column value.</value>
		public decimal PORCENTAJE_DTO
		{
			get { return _porcentaje_dto; }
			set { _porcentaje_dto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IMPUESTO_PORCENTAJE</c> column value.</value>
		public decimal IMPUESTO_PORCENTAJE
		{
			get
			{
				if(IsIMPUESTO_PORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _impuesto_porcentaje;
			}
			set
			{
				_impuesto_porcentajeNull = false;
				_impuesto_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="IMPUESTO_PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIMPUESTO_PORCENTAJENull
		{
			get { return _impuesto_porcentajeNull; }
			set { _impuesto_porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_BRUTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_BRUTO</c> column value.</value>
		public decimal TOTAL_MONTO_BRUTO
		{
			get { return _total_monto_bruto; }
			set { _total_monto_bruto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_DTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_DTO</c> column value.</value>
		public decimal TOTAL_MONTO_DTO
		{
			get { return _total_monto_dto; }
			set { _total_monto_dto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO_DTO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO_DTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO_DTO
		{
			get { return _total_monto_impuesto_dto; }
			set { _total_monto_impuesto_dto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO</c> column value.
		/// </summary>
		/// <value>The <c>TOTAL_NETO</c> column value.</value>
		public decimal TOTAL_NETO
		{
			get { return _total_neto; }
			set { _total_neto = value; }
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
			dynStr.Append("@CBA@PEDIDOS_PROVEEDOR_ID=");
			dynStr.Append(PEDIDOS_PROVEEDOR_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@DESCRIPCION_PROVEEDOR=");
			dynStr.Append(DESCRIPCION_PROVEEDOR);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA=");
			dynStr.Append(UNIDAD_MEDIDA);
			dynStr.Append("@CBA@CANTIDAD_EMBALADA=");
			dynStr.Append(CANTIDAD_EMBALADA);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD=");
			dynStr.Append(CANTIDAD_UNIDAD);
			dynStr.Append("@CBA@CANTIDAD_POR_CAJA=");
			dynStr.Append(CANTIDAD_POR_CAJA);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL=");
			dynStr.Append(CANTIDAD_UNITARIA_TOTAL);
			dynStr.Append("@CBA@PRECIO_BRUTO=");
			dynStr.Append(PRECIO_BRUTO);
			dynStr.Append("@CBA@PRECIO_CON_DTO=");
			dynStr.Append(PRECIO_CON_DTO);
			dynStr.Append("@CBA@PORCENTAJE_DTO=");
			dynStr.Append(PORCENTAJE_DTO);
			dynStr.Append("@CBA@IMPUESTO_PORCENTAJE=");
			dynStr.Append(IsIMPUESTO_PORCENTAJENull ? (object)"<NULL>" : IMPUESTO_PORCENTAJE);
			dynStr.Append("@CBA@TOTAL_MONTO_BRUTO=");
			dynStr.Append(TOTAL_MONTO_BRUTO);
			dynStr.Append("@CBA@TOTAL_MONTO_DTO=");
			dynStr.Append(TOTAL_MONTO_DTO);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO_DTO=");
			dynStr.Append(TOTAL_MONTO_IMPUESTO_DTO);
			dynStr.Append("@CBA@TOTAL_NETO=");
			dynStr.Append(TOTAL_NETO);
			return dynStr.ToString();
		}
	} // End of PEDIDOS_PROV_DET_INFO_COMPLRow_Base class
} // End of namespace
