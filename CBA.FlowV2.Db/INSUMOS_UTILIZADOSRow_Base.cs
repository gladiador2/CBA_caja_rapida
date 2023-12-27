// <fileinfo name="INSUMOS_UTILIZADOSRow_Base.cs">
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
	/// The base class for <see cref="INSUMOS_UTILIZADOSRow"/> that 
	/// represents a record in the <c>INSUMOS_UTILIZADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="INSUMOS_UTILIZADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INSUMOS_UTILIZADOSRow_Base
	{
		private decimal _id;
		private decimal _prod_balan_id;
		private bool _prod_balan_idNull = true;
		private decimal _articulo_id;
		private string _unidad_medida_id;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _cantidad_nominal;
		private bool _cantidad_nominalNull = true;
		private decimal _egreso_producto_id;
		private bool _egreso_producto_idNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _deposito_id;
		private bool _deposito_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="INSUMOS_UTILIZADOSRow_Base"/> class.
		/// </summary>
		public INSUMOS_UTILIZADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(INSUMOS_UTILIZADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsPROD_BALAN_IDNull != original.IsPROD_BALAN_IDNull) return true;
			if (!this.IsPROD_BALAN_IDNull && !original.IsPROD_BALAN_IDNull)
				if (this.PROD_BALAN_ID != original.PROD_BALAN_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.UNIDAD_MEDIDA_ID != original.UNIDAD_MEDIDA_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsCANTIDAD_NOMINALNull != original.IsCANTIDAD_NOMINALNull) return true;
			if (!this.IsCANTIDAD_NOMINALNull && !original.IsCANTIDAD_NOMINALNull)
				if (this.CANTIDAD_NOMINAL != original.CANTIDAD_NOMINAL) return true;
			if (this.IsEGRESO_PRODUCTO_IDNull != original.IsEGRESO_PRODUCTO_IDNull) return true;
			if (!this.IsEGRESO_PRODUCTO_IDNull && !original.IsEGRESO_PRODUCTO_IDNull)
				if (this.EGRESO_PRODUCTO_ID != original.EGRESO_PRODUCTO_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsDEPOSITO_IDNull != original.IsDEPOSITO_IDNull) return true;
			if (!this.IsDEPOSITO_IDNull && !original.IsDEPOSITO_IDNull)
				if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			
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
		/// Gets or sets the <c>PROD_BALAN_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROD_BALAN_ID</c> column value.</value>
		public decimal PROD_BALAN_ID
		{
			get
			{
				if(IsPROD_BALAN_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _prod_balan_id;
			}
			set
			{
				_prod_balan_idNull = false;
				_prod_balan_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROD_BALAN_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROD_BALAN_IDNull
		{
			get { return _prod_balan_idNull; }
			set { _prod_balan_idNull = value; }
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
		/// Gets or sets the <c>UNIDAD_MEDIDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>UNIDAD_MEDIDA_ID</c> column value.</value>
		public string UNIDAD_MEDIDA_ID
		{
			get { return _unidad_medida_id; }
			set { _unidad_medida_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
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
		/// Gets or sets the <c>CANTIDAD_NOMINAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_NOMINAL</c> column value.</value>
		public decimal CANTIDAD_NOMINAL
		{
			get
			{
				if(IsCANTIDAD_NOMINALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_nominal;
			}
			set
			{
				_cantidad_nominalNull = false;
				_cantidad_nominal = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_NOMINAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_NOMINALNull
		{
			get { return _cantidad_nominalNull; }
			set { _cantidad_nominalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EGRESO_PRODUCTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EGRESO_PRODUCTO_ID</c> column value.</value>
		public decimal EGRESO_PRODUCTO_ID
		{
			get
			{
				if(IsEGRESO_PRODUCTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _egreso_producto_id;
			}
			set
			{
				_egreso_producto_idNull = false;
				_egreso_producto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EGRESO_PRODUCTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEGRESO_PRODUCTO_IDNull
		{
			get { return _egreso_producto_idNull; }
			set { _egreso_producto_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get
			{
				if(IsDEPOSITO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _deposito_id;
			}
			set
			{
				_deposito_idNull = false;
				_deposito_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPOSITO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPOSITO_IDNull
		{
			get { return _deposito_idNull; }
			set { _deposito_idNull = value; }
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
			dynStr.Append("@CBA@PROD_BALAN_ID=");
			dynStr.Append(IsPROD_BALAN_IDNull ? (object)"<NULL>" : PROD_BALAN_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@UNIDAD_MEDIDA_ID=");
			dynStr.Append(UNIDAD_MEDIDA_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@CANTIDAD_NOMINAL=");
			dynStr.Append(IsCANTIDAD_NOMINALNull ? (object)"<NULL>" : CANTIDAD_NOMINAL);
			dynStr.Append("@CBA@EGRESO_PRODUCTO_ID=");
			dynStr.Append(IsEGRESO_PRODUCTO_IDNull ? (object)"<NULL>" : EGRESO_PRODUCTO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(IsDEPOSITO_IDNull ? (object)"<NULL>" : DEPOSITO_ID);
			return dynStr.ToString();
		}
	} // End of INSUMOS_UTILIZADOSRow_Base class
} // End of namespace
