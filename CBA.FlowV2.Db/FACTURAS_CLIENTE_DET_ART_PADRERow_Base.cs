// <fileinfo name="FACTURAS_CLIENTE_DET_ART_PADRERow_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> that 
	/// represents a record in the <c>FACTURAS_CLIENTE_DET_ART_PADRE</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DET_ART_PADRERow_Base
	{
		private string _articulo_descripcion;
		private decimal _facturas_cliente_id;
		private decimal _total_bruto;
		private bool _total_brutoNull = true;
		private decimal _total_monto_impuesto;
		private bool _total_monto_impuestoNull = true;
		private decimal _total_monto_dto;
		private bool _total_monto_dtoNull = true;
		private decimal _total_neto;
		private bool _total_netoNull = true;
		private decimal _total_recargo_financiero;
		private bool _total_recargo_financieroNull = true;
		private decimal _cantidad_unitaria_total_dest;
		private bool _cantidad_unitaria_total_destNull = true;
		private decimal _costo_monto;
		private bool _costo_montoNull = true;
		private decimal _costo_moneda_cabecera;
		private bool _costo_moneda_cabeceraNull = true;
		private decimal _rentabilidad;
		private bool _rentabilidadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow_Base"/> class.
		/// </summary>
		public FACTURAS_CLIENTE_DET_ART_PADRERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FACTURAS_CLIENTE_DET_ART_PADRERow_Base original)
		{
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.FACTURAS_CLIENTE_ID != original.FACTURAS_CLIENTE_ID) return true;
			if (this.IsTOTAL_BRUTONull != original.IsTOTAL_BRUTONull) return true;
			if (!this.IsTOTAL_BRUTONull && !original.IsTOTAL_BRUTONull)
				if (this.TOTAL_BRUTO != original.TOTAL_BRUTO) return true;
			if (this.IsTOTAL_MONTO_IMPUESTONull != original.IsTOTAL_MONTO_IMPUESTONull) return true;
			if (!this.IsTOTAL_MONTO_IMPUESTONull && !original.IsTOTAL_MONTO_IMPUESTONull)
				if (this.TOTAL_MONTO_IMPUESTO != original.TOTAL_MONTO_IMPUESTO) return true;
			if (this.IsTOTAL_MONTO_DTONull != original.IsTOTAL_MONTO_DTONull) return true;
			if (!this.IsTOTAL_MONTO_DTONull && !original.IsTOTAL_MONTO_DTONull)
				if (this.TOTAL_MONTO_DTO != original.TOTAL_MONTO_DTO) return true;
			if (this.IsTOTAL_NETONull != original.IsTOTAL_NETONull) return true;
			if (!this.IsTOTAL_NETONull && !original.IsTOTAL_NETONull)
				if (this.TOTAL_NETO != original.TOTAL_NETO) return true;
			if (this.IsTOTAL_RECARGO_FINANCIERONull != original.IsTOTAL_RECARGO_FINANCIERONull) return true;
			if (!this.IsTOTAL_RECARGO_FINANCIERONull && !original.IsTOTAL_RECARGO_FINANCIERONull)
				if (this.TOTAL_RECARGO_FINANCIERO != original.TOTAL_RECARGO_FINANCIERO) return true;
			if (this.IsCANTIDAD_UNITARIA_TOTAL_DESTNull != original.IsCANTIDAD_UNITARIA_TOTAL_DESTNull) return true;
			if (!this.IsCANTIDAD_UNITARIA_TOTAL_DESTNull && !original.IsCANTIDAD_UNITARIA_TOTAL_DESTNull)
				if (this.CANTIDAD_UNITARIA_TOTAL_DEST != original.CANTIDAD_UNITARIA_TOTAL_DEST) return true;
			if (this.IsCOSTO_MONTONull != original.IsCOSTO_MONTONull) return true;
			if (!this.IsCOSTO_MONTONull && !original.IsCOSTO_MONTONull)
				if (this.COSTO_MONTO != original.COSTO_MONTO) return true;
			if (this.IsCOSTO_MONEDA_CABECERANull != original.IsCOSTO_MONEDA_CABECERANull) return true;
			if (!this.IsCOSTO_MONEDA_CABECERANull && !original.IsCOSTO_MONEDA_CABECERANull)
				if (this.COSTO_MONEDA_CABECERA != original.COSTO_MONEDA_CABECERA) return true;
			if (this.IsRENTABILIDADNull != original.IsRENTABILIDADNull) return true;
			if (!this.IsRENTABILIDADNull && !original.IsRENTABILIDADNull)
				if (this.RENTABILIDAD != original.RENTABILIDAD) return true;
			
			return false;
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
		/// Gets or sets the <c>FACTURAS_CLIENTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURAS_CLIENTE_ID</c> column value.</value>
		public decimal FACTURAS_CLIENTE_ID
		{
			get { return _facturas_cliente_id; }
			set { _facturas_cliente_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_BRUTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_BRUTO</c> column value.</value>
		public decimal TOTAL_BRUTO
		{
			get
			{
				if(IsTOTAL_BRUTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_bruto;
			}
			set
			{
				_total_brutoNull = false;
				_total_bruto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_BRUTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_BRUTONull
		{
			get { return _total_brutoNull; }
			set { _total_brutoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_IMPUESTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_IMPUESTO</c> column value.</value>
		public decimal TOTAL_MONTO_IMPUESTO
		{
			get
			{
				if(IsTOTAL_MONTO_IMPUESTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_impuesto;
			}
			set
			{
				_total_monto_impuestoNull = false;
				_total_monto_impuesto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_IMPUESTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_IMPUESTONull
		{
			get { return _total_monto_impuestoNull; }
			set { _total_monto_impuestoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_MONTO_DTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_MONTO_DTO</c> column value.</value>
		public decimal TOTAL_MONTO_DTO
		{
			get
			{
				if(IsTOTAL_MONTO_DTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_monto_dto;
			}
			set
			{
				_total_monto_dtoNull = false;
				_total_monto_dto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_MONTO_DTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_MONTO_DTONull
		{
			get { return _total_monto_dtoNull; }
			set { _total_monto_dtoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_NETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_NETO</c> column value.</value>
		public decimal TOTAL_NETO
		{
			get
			{
				if(IsTOTAL_NETONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_neto;
			}
			set
			{
				_total_netoNull = false;
				_total_neto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_NETO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_NETONull
		{
			get { return _total_netoNull; }
			set { _total_netoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOTAL_RECARGO_FINANCIERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOTAL_RECARGO_FINANCIERO</c> column value.</value>
		public decimal TOTAL_RECARGO_FINANCIERO
		{
			get
			{
				if(IsTOTAL_RECARGO_FINANCIERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _total_recargo_financiero;
			}
			set
			{
				_total_recargo_financieroNull = false;
				_total_recargo_financiero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOTAL_RECARGO_FINANCIERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOTAL_RECARGO_FINANCIERONull
		{
			get { return _total_recargo_financieroNull; }
			set { _total_recargo_financieroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNITARIA_TOTAL_DEST</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNITARIA_TOTAL_DEST</c> column value.</value>
		public decimal CANTIDAD_UNITARIA_TOTAL_DEST
		{
			get
			{
				if(IsCANTIDAD_UNITARIA_TOTAL_DESTNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unitaria_total_dest;
			}
			set
			{
				_cantidad_unitaria_total_destNull = false;
				_cantidad_unitaria_total_dest = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNITARIA_TOTAL_DEST"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNITARIA_TOTAL_DESTNull
		{
			get { return _cantidad_unitaria_total_destNull; }
			set { _cantidad_unitaria_total_destNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONTO</c> column value.</value>
		public decimal COSTO_MONTO
		{
			get
			{
				if(IsCOSTO_MONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_monto;
			}
			set
			{
				_costo_montoNull = false;
				_costo_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONTONull
		{
			get { return _costo_montoNull; }
			set { _costo_montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_CABECERA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_CABECERA</c> column value.</value>
		public decimal COSTO_MONEDA_CABECERA
		{
			get
			{
				if(IsCOSTO_MONEDA_CABECERANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_moneda_cabecera;
			}
			set
			{
				_costo_moneda_cabeceraNull = false;
				_costo_moneda_cabecera = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONEDA_CABECERA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONEDA_CABECERANull
		{
			get { return _costo_moneda_cabeceraNull; }
			set { _costo_moneda_cabeceraNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RENTABILIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RENTABILIDAD</c> column value.</value>
		public decimal RENTABILIDAD
		{
			get
			{
				if(IsRENTABILIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rentabilidad;
			}
			set
			{
				_rentabilidadNull = false;
				_rentabilidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RENTABILIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRENTABILIDADNull
		{
			get { return _rentabilidadNull; }
			set { _rentabilidadNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@FACTURAS_CLIENTE_ID=");
			dynStr.Append(FACTURAS_CLIENTE_ID);
			dynStr.Append("@CBA@TOTAL_BRUTO=");
			dynStr.Append(IsTOTAL_BRUTONull ? (object)"<NULL>" : TOTAL_BRUTO);
			dynStr.Append("@CBA@TOTAL_MONTO_IMPUESTO=");
			dynStr.Append(IsTOTAL_MONTO_IMPUESTONull ? (object)"<NULL>" : TOTAL_MONTO_IMPUESTO);
			dynStr.Append("@CBA@TOTAL_MONTO_DTO=");
			dynStr.Append(IsTOTAL_MONTO_DTONull ? (object)"<NULL>" : TOTAL_MONTO_DTO);
			dynStr.Append("@CBA@TOTAL_NETO=");
			dynStr.Append(IsTOTAL_NETONull ? (object)"<NULL>" : TOTAL_NETO);
			dynStr.Append("@CBA@TOTAL_RECARGO_FINANCIERO=");
			dynStr.Append(IsTOTAL_RECARGO_FINANCIERONull ? (object)"<NULL>" : TOTAL_RECARGO_FINANCIERO);
			dynStr.Append("@CBA@CANTIDAD_UNITARIA_TOTAL_DEST=");
			dynStr.Append(IsCANTIDAD_UNITARIA_TOTAL_DESTNull ? (object)"<NULL>" : CANTIDAD_UNITARIA_TOTAL_DEST);
			dynStr.Append("@CBA@COSTO_MONTO=");
			dynStr.Append(IsCOSTO_MONTONull ? (object)"<NULL>" : COSTO_MONTO);
			dynStr.Append("@CBA@COSTO_MONEDA_CABECERA=");
			dynStr.Append(IsCOSTO_MONEDA_CABECERANull ? (object)"<NULL>" : COSTO_MONEDA_CABECERA);
			dynStr.Append("@CBA@RENTABILIDAD=");
			dynStr.Append(IsRENTABILIDADNull ? (object)"<NULL>" : RENTABILIDAD);
			return dynStr.ToString();
		}
	} // End of FACTURAS_CLIENTE_DET_ART_PADRERow_Base class
} // End of namespace
