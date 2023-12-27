// <fileinfo name="STOCK_INVENTARIO_DETALLERow_Base.cs">
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
	/// The base class for <see cref="STOCK_INVENTARIO_DETALLERow"/> that 
	/// represents a record in the <c>STOCK_INVENTARIO_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_INVENTARIO_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_INVENTARIO_DETALLERow_Base
	{
		private decimal _id;
		private decimal _stock_inventanrio_id;
		private decimal _articulo_id;
		private decimal _lote_id;
		private decimal _cantidad_sistema;
		private bool _cantidad_sistemaNull = true;
		private decimal _cantidad_manual;
		private bool _cantidad_manualNull = true;
		private decimal _ajuste_stock_caso_id;
		private bool _ajuste_stock_caso_idNull = true;
		private string _unidad_id;
		private string _pasillo;
		private string _estante;
		private string _nivel;
		private string _columna;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_INVENTARIO_DETALLERow_Base"/> class.
		/// </summary>
		public STOCK_INVENTARIO_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_INVENTARIO_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.STOCK_INVENTANRIO_ID != original.STOCK_INVENTANRIO_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsCANTIDAD_SISTEMANull != original.IsCANTIDAD_SISTEMANull) return true;
			if (!this.IsCANTIDAD_SISTEMANull && !original.IsCANTIDAD_SISTEMANull)
				if (this.CANTIDAD_SISTEMA != original.CANTIDAD_SISTEMA) return true;
			if (this.IsCANTIDAD_MANUALNull != original.IsCANTIDAD_MANUALNull) return true;
			if (!this.IsCANTIDAD_MANUALNull && !original.IsCANTIDAD_MANUALNull)
				if (this.CANTIDAD_MANUAL != original.CANTIDAD_MANUAL) return true;
			if (this.IsAJUSTE_STOCK_CASO_IDNull != original.IsAJUSTE_STOCK_CASO_IDNull) return true;
			if (!this.IsAJUSTE_STOCK_CASO_IDNull && !original.IsAJUSTE_STOCK_CASO_IDNull)
				if (this.AJUSTE_STOCK_CASO_ID != original.AJUSTE_STOCK_CASO_ID) return true;
			if (this.UNIDAD_ID != original.UNIDAD_ID) return true;
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
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get { return _lote_id; }
			set { _lote_id = value; }
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
		/// Gets or sets the <c>UNIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_ID</c> column value.</value>
		public string UNIDAD_ID
		{
			get { return _unidad_id; }
			set { _unidad_id = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@CANTIDAD_SISTEMA=");
			dynStr.Append(IsCANTIDAD_SISTEMANull ? (object)"<NULL>" : CANTIDAD_SISTEMA);
			dynStr.Append("@CBA@CANTIDAD_MANUAL=");
			dynStr.Append(IsCANTIDAD_MANUALNull ? (object)"<NULL>" : CANTIDAD_MANUAL);
			dynStr.Append("@CBA@AJUSTE_STOCK_CASO_ID=");
			dynStr.Append(IsAJUSTE_STOCK_CASO_IDNull ? (object)"<NULL>" : AJUSTE_STOCK_CASO_ID);
			dynStr.Append("@CBA@UNIDAD_ID=");
			dynStr.Append(UNIDAD_ID);
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
	} // End of STOCK_INVENTARIO_DETALLERow_Base class
} // End of namespace
