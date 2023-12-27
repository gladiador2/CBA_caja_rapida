// <fileinfo name="STOCK_ARTICULOS_RESERVARow_Base.cs">
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
	/// The base class for <see cref="STOCK_ARTICULOS_RESERVARow"/> that 
	/// represents a record in the <c>STOCK_ARTICULOS_RESERVA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_ARTICULOS_RESERVARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_ARTICULOS_RESERVARow_Base
	{
		private decimal _sucursal_id;
		private string _sucursal;
		private decimal _deposito_id;
		private string _deposito;
		private decimal _articulo_lote_id;
		private bool _articulo_lote_idNull = true;
		private string _lote;
		private decimal _articulo_id;
		private string _articulo_codigo;
		private string _articulo;
		private decimal _reservado_facturado;
		private bool _reservado_facturadoNull = true;
		private decimal _reservado_pedido;
		private bool _reservado_pedidoNull = true;
		private decimal _reservado_transferencia;
		private bool _reservado_transferenciaNull = true;
		private decimal _reservado_prod_balan;
		private bool _reservado_prod_balanNull = true;
		private decimal _reservado_prod_balan_material;
		private bool _reservado_prod_balan_materialNull = true;
		private decimal _reservado_egreso_producto;
		private bool _reservado_egreso_productoNull = true;
		private decimal _reservado_egreso_prod_material;
		private bool _reservado_egreso_prod_materialNull = true;
		private decimal _cant_reservada;
		private bool _cant_reservadaNull = true;
		private decimal _disponible;
		private bool _disponibleNull = true;
		private decimal _existencia;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_ARTICULOS_RESERVARow_Base"/> class.
		/// </summary>
		public STOCK_ARTICULOS_RESERVARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_ARTICULOS_RESERVARow_Base original)
		{
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL != original.SUCURSAL) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO != original.DEPOSITO) return true;
			if (this.IsARTICULO_LOTE_IDNull != original.IsARTICULO_LOTE_IDNull) return true;
			if (!this.IsARTICULO_LOTE_IDNull && !original.IsARTICULO_LOTE_IDNull)
				if (this.ARTICULO_LOTE_ID != original.ARTICULO_LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO != original.ARTICULO) return true;
			if (this.IsRESERVADO_FACTURADONull != original.IsRESERVADO_FACTURADONull) return true;
			if (!this.IsRESERVADO_FACTURADONull && !original.IsRESERVADO_FACTURADONull)
				if (this.RESERVADO_FACTURADO != original.RESERVADO_FACTURADO) return true;
			if (this.IsRESERVADO_PEDIDONull != original.IsRESERVADO_PEDIDONull) return true;
			if (!this.IsRESERVADO_PEDIDONull && !original.IsRESERVADO_PEDIDONull)
				if (this.RESERVADO_PEDIDO != original.RESERVADO_PEDIDO) return true;
			if (this.IsRESERVADO_TRANSFERENCIANull != original.IsRESERVADO_TRANSFERENCIANull) return true;
			if (!this.IsRESERVADO_TRANSFERENCIANull && !original.IsRESERVADO_TRANSFERENCIANull)
				if (this.RESERVADO_TRANSFERENCIA != original.RESERVADO_TRANSFERENCIA) return true;
			if (this.IsRESERVADO_PROD_BALANNull != original.IsRESERVADO_PROD_BALANNull) return true;
			if (!this.IsRESERVADO_PROD_BALANNull && !original.IsRESERVADO_PROD_BALANNull)
				if (this.RESERVADO_PROD_BALAN != original.RESERVADO_PROD_BALAN) return true;
			if (this.IsRESERVADO_PROD_BALAN_MATERIALNull != original.IsRESERVADO_PROD_BALAN_MATERIALNull) return true;
			if (!this.IsRESERVADO_PROD_BALAN_MATERIALNull && !original.IsRESERVADO_PROD_BALAN_MATERIALNull)
				if (this.RESERVADO_PROD_BALAN_MATERIAL != original.RESERVADO_PROD_BALAN_MATERIAL) return true;
			if (this.IsRESERVADO_EGRESO_PRODUCTONull != original.IsRESERVADO_EGRESO_PRODUCTONull) return true;
			if (!this.IsRESERVADO_EGRESO_PRODUCTONull && !original.IsRESERVADO_EGRESO_PRODUCTONull)
				if (this.RESERVADO_EGRESO_PRODUCTO != original.RESERVADO_EGRESO_PRODUCTO) return true;
			if (this.IsRESERVADO_EGRESO_PROD_MATERIALNull != original.IsRESERVADO_EGRESO_PROD_MATERIALNull) return true;
			if (!this.IsRESERVADO_EGRESO_PROD_MATERIALNull && !original.IsRESERVADO_EGRESO_PROD_MATERIALNull)
				if (this.RESERVADO_EGRESO_PROD_MATERIAL != original.RESERVADO_EGRESO_PROD_MATERIAL) return true;
			if (this.IsCANT_RESERVADANull != original.IsCANT_RESERVADANull) return true;
			if (!this.IsCANT_RESERVADANull && !original.IsCANT_RESERVADANull)
				if (this.CANT_RESERVADA != original.CANT_RESERVADA) return true;
			if (this.IsDISPONIBLENull != original.IsDISPONIBLENull) return true;
			if (!this.IsDISPONIBLENull && !original.IsDISPONIBLENull)
				if (this.DISPONIBLE != original.DISPONIBLE) return true;
			if (this.EXISTENCIA != original.EXISTENCIA) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL</c> column value.</value>
		public string SUCURSAL
		{
			get { return _sucursal; }
			set { _sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ID</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ID</c> column value.</value>
		public decimal DEPOSITO_ID
		{
			get { return _deposito_id; }
			set { _deposito_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO</c> column value.</value>
		public string DEPOSITO
		{
			get { return _deposito; }
			set { _deposito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_LOTE_ID</c> column value.</value>
		public decimal ARTICULO_LOTE_ID
		{
			get
			{
				if(IsARTICULO_LOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_lote_id;
			}
			set
			{
				_articulo_lote_idNull = false;
				_articulo_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_LOTE_IDNull
		{
			get { return _articulo_lote_idNull; }
			set { _articulo_lote_idNull = value; }
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
		/// Gets or sets the <c>ARTICULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO</c> column value.</value>
		public string ARTICULO
		{
			get { return _articulo; }
			set { _articulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_FACTURADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_FACTURADO</c> column value.</value>
		public decimal RESERVADO_FACTURADO
		{
			get
			{
				if(IsRESERVADO_FACTURADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_facturado;
			}
			set
			{
				_reservado_facturadoNull = false;
				_reservado_facturado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_FACTURADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_FACTURADONull
		{
			get { return _reservado_facturadoNull; }
			set { _reservado_facturadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_PEDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_PEDIDO</c> column value.</value>
		public decimal RESERVADO_PEDIDO
		{
			get
			{
				if(IsRESERVADO_PEDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_pedido;
			}
			set
			{
				_reservado_pedidoNull = false;
				_reservado_pedido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_PEDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_PEDIDONull
		{
			get { return _reservado_pedidoNull; }
			set { _reservado_pedidoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_TRANSFERENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_TRANSFERENCIA</c> column value.</value>
		public decimal RESERVADO_TRANSFERENCIA
		{
			get
			{
				if(IsRESERVADO_TRANSFERENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_transferencia;
			}
			set
			{
				_reservado_transferenciaNull = false;
				_reservado_transferencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_TRANSFERENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_TRANSFERENCIANull
		{
			get { return _reservado_transferenciaNull; }
			set { _reservado_transferenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_PROD_BALAN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_PROD_BALAN</c> column value.</value>
		public decimal RESERVADO_PROD_BALAN
		{
			get
			{
				if(IsRESERVADO_PROD_BALANNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_prod_balan;
			}
			set
			{
				_reservado_prod_balanNull = false;
				_reservado_prod_balan = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_PROD_BALAN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_PROD_BALANNull
		{
			get { return _reservado_prod_balanNull; }
			set { _reservado_prod_balanNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_PROD_BALAN_MATERIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_PROD_BALAN_MATERIAL</c> column value.</value>
		public decimal RESERVADO_PROD_BALAN_MATERIAL
		{
			get
			{
				if(IsRESERVADO_PROD_BALAN_MATERIALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_prod_balan_material;
			}
			set
			{
				_reservado_prod_balan_materialNull = false;
				_reservado_prod_balan_material = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_PROD_BALAN_MATERIAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_PROD_BALAN_MATERIALNull
		{
			get { return _reservado_prod_balan_materialNull; }
			set { _reservado_prod_balan_materialNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_EGRESO_PRODUCTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_EGRESO_PRODUCTO</c> column value.</value>
		public decimal RESERVADO_EGRESO_PRODUCTO
		{
			get
			{
				if(IsRESERVADO_EGRESO_PRODUCTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_egreso_producto;
			}
			set
			{
				_reservado_egreso_productoNull = false;
				_reservado_egreso_producto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_EGRESO_PRODUCTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_EGRESO_PRODUCTONull
		{
			get { return _reservado_egreso_productoNull; }
			set { _reservado_egreso_productoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RESERVADO_EGRESO_PROD_MATERIAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RESERVADO_EGRESO_PROD_MATERIAL</c> column value.</value>
		public decimal RESERVADO_EGRESO_PROD_MATERIAL
		{
			get
			{
				if(IsRESERVADO_EGRESO_PROD_MATERIALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reservado_egreso_prod_material;
			}
			set
			{
				_reservado_egreso_prod_materialNull = false;
				_reservado_egreso_prod_material = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RESERVADO_EGRESO_PROD_MATERIAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRESERVADO_EGRESO_PROD_MATERIALNull
		{
			get { return _reservado_egreso_prod_materialNull; }
			set { _reservado_egreso_prod_materialNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANT_RESERVADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANT_RESERVADA</c> column value.</value>
		public decimal CANT_RESERVADA
		{
			get
			{
				if(IsCANT_RESERVADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cant_reservada;
			}
			set
			{
				_cant_reservadaNull = false;
				_cant_reservada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANT_RESERVADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANT_RESERVADANull
		{
			get { return _cant_reservadaNull; }
			set { _cant_reservadaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DISPONIBLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DISPONIBLE</c> column value.</value>
		public decimal DISPONIBLE
		{
			get
			{
				if(IsDISPONIBLENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _disponible;
			}
			set
			{
				_disponibleNull = false;
				_disponible = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DISPONIBLE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDISPONIBLENull
		{
			get { return _disponibleNull; }
			set { _disponibleNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTENCIA</c> column value.
		/// </summary>
		/// <value>The <c>EXISTENCIA</c> column value.</value>
		public decimal EXISTENCIA
		{
			get { return _existencia; }
			set { _existencia = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL=");
			dynStr.Append(SUCURSAL);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO=");
			dynStr.Append(DEPOSITO);
			dynStr.Append("@CBA@ARTICULO_LOTE_ID=");
			dynStr.Append(IsARTICULO_LOTE_IDNull ? (object)"<NULL>" : ARTICULO_LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO=");
			dynStr.Append(ARTICULO);
			dynStr.Append("@CBA@RESERVADO_FACTURADO=");
			dynStr.Append(IsRESERVADO_FACTURADONull ? (object)"<NULL>" : RESERVADO_FACTURADO);
			dynStr.Append("@CBA@RESERVADO_PEDIDO=");
			dynStr.Append(IsRESERVADO_PEDIDONull ? (object)"<NULL>" : RESERVADO_PEDIDO);
			dynStr.Append("@CBA@RESERVADO_TRANSFERENCIA=");
			dynStr.Append(IsRESERVADO_TRANSFERENCIANull ? (object)"<NULL>" : RESERVADO_TRANSFERENCIA);
			dynStr.Append("@CBA@RESERVADO_PROD_BALAN=");
			dynStr.Append(IsRESERVADO_PROD_BALANNull ? (object)"<NULL>" : RESERVADO_PROD_BALAN);
			dynStr.Append("@CBA@RESERVADO_PROD_BALAN_MATERIAL=");
			dynStr.Append(IsRESERVADO_PROD_BALAN_MATERIALNull ? (object)"<NULL>" : RESERVADO_PROD_BALAN_MATERIAL);
			dynStr.Append("@CBA@RESERVADO_EGRESO_PRODUCTO=");
			dynStr.Append(IsRESERVADO_EGRESO_PRODUCTONull ? (object)"<NULL>" : RESERVADO_EGRESO_PRODUCTO);
			dynStr.Append("@CBA@RESERVADO_EGRESO_PROD_MATERIAL=");
			dynStr.Append(IsRESERVADO_EGRESO_PROD_MATERIALNull ? (object)"<NULL>" : RESERVADO_EGRESO_PROD_MATERIAL);
			dynStr.Append("@CBA@CANT_RESERVADA=");
			dynStr.Append(IsCANT_RESERVADANull ? (object)"<NULL>" : CANT_RESERVADA);
			dynStr.Append("@CBA@DISPONIBLE=");
			dynStr.Append(IsDISPONIBLENull ? (object)"<NULL>" : DISPONIBLE);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(EXISTENCIA);
			return dynStr.ToString();
		}
	} // End of STOCK_ARTICULOS_RESERVARow_Base class
} // End of namespace
