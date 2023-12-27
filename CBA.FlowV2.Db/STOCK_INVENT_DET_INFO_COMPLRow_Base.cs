// <fileinfo name="STOCK_INVENT_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>STOCK_INVENT_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_INVENT_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _stock_inventanrio_id;
		private decimal _stock_invent_caso_id;
		private decimal _articulo_id;
		private string _articulo_codigo;
		private string _articulo_descripcion;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private string _articulo_familia;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private string _articulo_grupo;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _articulo_subgrupo;
		private string _articulo_codigo_catalogo;
		private decimal _lote_id;
		private string _lote;
		private decimal _cantidad_sistema;
		private bool _cantidad_sistemaNull = true;
		private decimal _cantidad_manual;
		private bool _cantidad_manualNull = true;
		private string _unidad_id;
		private string _unidad_medida;
		private decimal _ajuste_stock_caso_id;
		private bool _ajuste_stock_caso_idNull = true;
		private decimal _costo_moneda;
		private bool _costo_monedaNull = true;
		private decimal _costo_cotizacion;
		private bool _costo_cotizacionNull = true;
		private decimal _costo;
		private bool _costoNull = true;
		private string _pasillo;
		private string _estante;
		private string _nivel;
		private string _columna;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_INVENT_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public STOCK_INVENT_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_INVENT_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.STOCK_INVENTANRIO_ID != original.STOCK_INVENTANRIO_ID) return true;
			if (this.STOCK_INVENT_CASO_ID != original.STOCK_INVENT_CASO_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.ARTICULO_FAMILIA != original.ARTICULO_FAMILIA) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.ARTICULO_GRUPO != original.ARTICULO_GRUPO) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.ARTICULO_SUBGRUPO != original.ARTICULO_SUBGRUPO) return true;
			if (this.ARTICULO_CODIGO_CATALOGO != original.ARTICULO_CODIGO_CATALOGO) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.IsCANTIDAD_SISTEMANull != original.IsCANTIDAD_SISTEMANull) return true;
			if (!this.IsCANTIDAD_SISTEMANull && !original.IsCANTIDAD_SISTEMANull)
				if (this.CANTIDAD_SISTEMA != original.CANTIDAD_SISTEMA) return true;
			if (this.IsCANTIDAD_MANUALNull != original.IsCANTIDAD_MANUALNull) return true;
			if (!this.IsCANTIDAD_MANUALNull && !original.IsCANTIDAD_MANUALNull)
				if (this.CANTIDAD_MANUAL != original.CANTIDAD_MANUAL) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
			if (this.UNIDAD_MEDIDA != original.UNIDAD_MEDIDA) return true;
			if (this.IsAJUSTE_STOCK_CASO_IDNull != original.IsAJUSTE_STOCK_CASO_IDNull) return true;
			if (!this.IsAJUSTE_STOCK_CASO_IDNull && !original.IsAJUSTE_STOCK_CASO_IDNull)
				if (this.AJUSTE_STOCK_CASO_ID != original.AJUSTE_STOCK_CASO_ID) return true;
			if (this.IsCOSTO_MONEDANull != original.IsCOSTO_MONEDANull) return true;
			if (!this.IsCOSTO_MONEDANull && !original.IsCOSTO_MONEDANull)
				if (this.COSTO_MONEDA != original.COSTO_MONEDA) return true;
			if (this.IsCOSTO_COTIZACIONNull != original.IsCOSTO_COTIZACIONNull) return true;
			if (!this.IsCOSTO_COTIZACIONNull && !original.IsCOSTO_COTIZACIONNull)
				if (this.COSTO_COTIZACION != original.COSTO_COTIZACION) return true;
			if (this.IsCOSTONull != original.IsCOSTONull) return true;
			if (!this.IsCOSTONull && !original.IsCOSTONull)
				if (this.COSTO != original.COSTO) return true;
			if (this.PASILLO != original.PASILLO) return true;
			if (this.ESTANTE != original.ESTANTE) return true;
			if (this.NIVEL != original.NIVEL) return true;
			if (this.COLUMNA != original.COLUMNA) return true;
			
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
		/// Gets or sets the <c>STOCK_INVENTANRIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_INVENTANRIO_ID</c> column value.</value>
		public decimal STOCK_INVENTANRIO_ID
		{
			get { return _stock_inventanrio_id; }
			set { _stock_inventanrio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_INVENT_CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_INVENT_CASO_ID</c> column value.</value>
		public decimal STOCK_INVENT_CASO_ID
		{
			get { return _stock_invent_caso_id; }
			set { _stock_invent_caso_id = value; }
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
		/// Gets or sets the <c>ARTICULO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO</c> column value.</value>
		public string ARTICULO_CODIGO
		{
			get { return _articulo_codigo; }
			set { _articulo_codigo = value; }
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
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_FAMILIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA</c> column value.</value>
		public string ARTICULO_FAMILIA
		{
			get { return _articulo_familia; }
			set { _articulo_familia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_GRUPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO</c> column value.</value>
		public string ARTICULO_GRUPO
		{
			get { return _articulo_grupo; }
			set { _articulo_grupo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public decimal SUBGRUPO_ID
		{
			get
			{
				if(IsSUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_id;
			}
			set
			{
				_subgrupo_idNull = false;
				_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_IDNull
		{
			get { return _subgrupo_idNull; }
			set { _subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_SUBGRUPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO</c> column value.</value>
		public string ARTICULO_SUBGRUPO
		{
			get { return _articulo_subgrupo; }
			set { _articulo_subgrupo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_CODIGO_CATALOGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_CODIGO_CATALOGO</c> column value.</value>
		public string ARTICULO_CODIGO_CATALOGO
		{
			get { return _articulo_codigo_catalogo; }
			set { _articulo_codigo_catalogo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get { return _lote_id; }
			set { _lote_id = value; }
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
		/// Gets or sets the <c>CANTIDAD_SISTEMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_SISTEMA</c> column value.</value>
		public decimal CANTIDAD_SISTEMA
		{
			get
			{
				if(IsCANTIDAD_SISTEMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_sistema;
			}
			set
			{
				_cantidad_sistemaNull = false;
				_cantidad_sistema = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_SISTEMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_SISTEMANull
		{
			get { return _cantidad_sistemaNull; }
			set { _cantidad_sistemaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MANUAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MANUAL</c> column value.</value>
		public decimal CANTIDAD_MANUAL
		{
			get
			{
				if(IsCANTIDAD_MANUALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_manual;
			}
			set
			{
				_cantidad_manualNull = false;
				_cantidad_manual = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MANUAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MANUALNull
		{
			get { return _cantidad_manualNull; }
			set { _cantidad_manualNull = value; }
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
		/// Gets or sets the <c>AJUSTE_STOCK_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AJUSTE_STOCK_CASO_ID</c> column value.</value>
		public decimal AJUSTE_STOCK_CASO_ID
		{
			get
			{
				if(IsAJUSTE_STOCK_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ajuste_stock_caso_id;
			}
			set
			{
				_ajuste_stock_caso_idNull = false;
				_ajuste_stock_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AJUSTE_STOCK_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAJUSTE_STOCK_CASO_IDNull
		{
			get { return _ajuste_stock_caso_idNull; }
			set { _ajuste_stock_caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA</c> column value.</value>
		public decimal COSTO_MONEDA
		{
			get
			{
				if(IsCOSTO_MONEDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_moneda;
			}
			set
			{
				_costo_monedaNull = false;
				_costo_moneda = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONEDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONEDANull
		{
			get { return _costo_monedaNull; }
			set { _costo_monedaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_COTIZACION</c> column value.</value>
		public decimal COSTO_COTIZACION
		{
			get
			{
				if(IsCOSTO_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_cotizacion;
			}
			set
			{
				_costo_cotizacionNull = false;
				_costo_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_COTIZACIONNull
		{
			get { return _costo_cotizacionNull; }
			set { _costo_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO</c> column value.</value>
		public decimal COSTO
		{
			get
			{
				if(IsCOSTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo;
			}
			set
			{
				_costoNull = false;
				_costo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTONull
		{
			get { return _costoNull; }
			set { _costoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PASILLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PASILLO</c> column value.</value>
		public string PASILLO
		{
			get { return _pasillo; }
			set { _pasillo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTANTE</c> column value.</value>
		public string ESTANTE
		{
			get { return _estante; }
			set { _estante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NIVEL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NIVEL</c> column value.</value>
		public string NIVEL
		{
			get { return _nivel; }
			set { _nivel = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLUMNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COLUMNA</c> column value.</value>
		public string COLUMNA
		{
			get { return _columna; }
			set { _columna = value; }
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
			dynStr.Append("@CBA@STOCK_INVENTANRIO_ID=");
			dynStr.Append(STOCK_INVENTANRIO_ID);
			dynStr.Append("@CBA@STOCK_INVENT_CASO_ID=");
			dynStr.Append(STOCK_INVENT_CASO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA=");
			dynStr.Append(ARTICULO_FAMILIA);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO=");
			dynStr.Append(ARTICULO_GRUPO);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO=");
			dynStr.Append(ARTICULO_SUBGRUPO);
			dynStr.Append("@CBA@ARTICULO_CODIGO_CATALOGO=");
			dynStr.Append(ARTICULO_CODIGO_CATALOGO);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@CANTIDAD_SISTEMA=");
			dynStr.Append(IsCANTIDAD_SISTEMANull ? (object)"<NULL>" : CANTIDAD_SISTEMA);
			dynStr.Append("@CBA@CANTIDAD_MANUAL=");
			dynStr.Append(IsCANTIDAD_MANUALNull ? (object)"<NULL>" : CANTIDAD_MANUAL);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA=");
			dynStr.Append(UNIDAD_MEDIDA);
			dynStr.Append("@CBA@AJUSTE_STOCK_CASO_ID=");
			dynStr.Append(IsAJUSTE_STOCK_CASO_IDNull ? (object)"<NULL>" : AJUSTE_STOCK_CASO_ID);
			dynStr.Append("@CBA@COSTO_MONEDA=");
			dynStr.Append(IsCOSTO_MONEDANull ? (object)"<NULL>" : COSTO_MONEDA);
			dynStr.Append("@CBA@COSTO_COTIZACION=");
			dynStr.Append(IsCOSTO_COTIZACIONNull ? (object)"<NULL>" : COSTO_COTIZACION);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(IsCOSTONull ? (object)"<NULL>" : COSTO);
			dynStr.Append("@CBA@PASILLO=");
			dynStr.Append(PASILLO);
			dynStr.Append("@CBA@ESTANTE=");
			dynStr.Append(ESTANTE);
			dynStr.Append("@CBA@NIVEL=");
			dynStr.Append(NIVEL);
			dynStr.Append("@CBA@COLUMNA=");
			dynStr.Append(COLUMNA);
			return dynStr.ToString();
		}
	} // End of STOCK_INVENT_DET_INFO_COMPLRow_Base class
} // End of namespace
