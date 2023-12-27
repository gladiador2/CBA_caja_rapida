// <fileinfo name="STOCK_SUC_DEPOSITO_ART_FECHARow_Base.cs">
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
	/// The base class for <see cref="STOCK_SUC_DEPOSITO_ART_FECHARow"/> that 
	/// represents a record in the <c>STOCK_SUC_DEPOSITO_ART_FECHA</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_SUC_DEPOSITO_ART_FECHARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_SUC_DEPOSITO_ART_FECHARow_Base
	{
		private decimal _id;
		private decimal _sucursal_id;
		private decimal _deposito_id;
		private decimal _articulo_id;
		private decimal _articulo_lote_id;
		private bool _articulo_lote_idNull = true;
		private decimal _existencia_inicial;
		private decimal _compra;
		private decimal _ajuste_positivo;
		private decimal _transferencia_entrada;
		private decimal _nota_credito_cliente;
		private decimal _nota_debito_proveedor;
		private decimal _transito;
		private decimal _industrializacion;
		private bool _industrializacionNull = true;
		private decimal _punto_minimo;
		private bool _punto_minimoNull = true;
		private decimal _combos_eliminados;
		private decimal _existencia;
		private decimal _venta;
		private decimal _transferencia_salida;
		private decimal _ajuste_negativo;
		private decimal _nota_debito_cliente;
		private decimal _nota_credito_proveedor;
		private decimal _uso_de_insumo;
		private decimal _combos_creados;
		private decimal _fecha_formato_numero;
		private decimal _moneda_activa_id;
		private decimal _moneda_activa_cotizacion;
		private decimal _moneda_ponderada_id;
		private decimal _moneda_ponderada_cotizacion;
		private decimal _costo_activo;
		private decimal _costo_ponderado;
		private decimal _existencia_formulario;
		private bool _existencia_formularioNull = true;
		private decimal _stock_suc_deposito_art_id;
		private decimal _usuario_cierre_id;
		private bool _usuario_cierre_idNull = true;
		private System.DateTime _fecha_cierre;
		private bool _fecha_cierreNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_SUC_DEPOSITO_ART_FECHARow_Base"/> class.
		/// </summary>
		public STOCK_SUC_DEPOSITO_ART_FECHARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_SUC_DEPOSITO_ART_FECHARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsARTICULO_LOTE_IDNull != original.IsARTICULO_LOTE_IDNull) return true;
			if (!this.IsARTICULO_LOTE_IDNull && !original.IsARTICULO_LOTE_IDNull)
				if (this.ARTICULO_LOTE_ID != original.ARTICULO_LOTE_ID) return true;
			if (this.EXISTENCIA_INICIAL != original.EXISTENCIA_INICIAL) return true;
			if (this.COMPRA != original.COMPRA) return true;
			if (this.AJUSTE_POSITIVO != original.AJUSTE_POSITIVO) return true;
			if (this.TRANSFERENCIA_ENTRADA != original.TRANSFERENCIA_ENTRADA) return true;
			if (this.NOTA_CREDITO_CLIENTE != original.NOTA_CREDITO_CLIENTE) return true;
			if (this.NOTA_DEBITO_PROVEEDOR != original.NOTA_DEBITO_PROVEEDOR) return true;
			if (this.TRANSITO != original.TRANSITO) return true;
			if (this.IsINDUSTRIALIZACIONNull != original.IsINDUSTRIALIZACIONNull) return true;
			if (!this.IsINDUSTRIALIZACIONNull && !original.IsINDUSTRIALIZACIONNull)
				if (this.INDUSTRIALIZACION != original.INDUSTRIALIZACION) return true;
			if (this.IsPUNTO_MINIMONull != original.IsPUNTO_MINIMONull) return true;
			if (!this.IsPUNTO_MINIMONull && !original.IsPUNTO_MINIMONull)
				if (this.PUNTO_MINIMO != original.PUNTO_MINIMO) return true;
			if (this.COMBOS_ELIMINADOS != original.COMBOS_ELIMINADOS) return true;
			if (this.EXISTENCIA != original.EXISTENCIA) return true;
			if (this.VENTA != original.VENTA) return true;
			if (this.TRANSFERENCIA_SALIDA != original.TRANSFERENCIA_SALIDA) return true;
			if (this.AJUSTE_NEGATIVO != original.AJUSTE_NEGATIVO) return true;
			if (this.NOTA_DEBITO_CLIENTE != original.NOTA_DEBITO_CLIENTE) return true;
			if (this.NOTA_CREDITO_PROVEEDOR != original.NOTA_CREDITO_PROVEEDOR) return true;
			if (this.USO_DE_INSUMO != original.USO_DE_INSUMO) return true;
			if (this.COMBOS_CREADOS != original.COMBOS_CREADOS) return true;
			if (this.FECHA_FORMATO_NUMERO != original.FECHA_FORMATO_NUMERO) return true;
			if (this.MONEDA_ACTIVA_ID != original.MONEDA_ACTIVA_ID) return true;
			if (this.MONEDA_ACTIVA_COTIZACION != original.MONEDA_ACTIVA_COTIZACION) return true;
			if (this.MONEDA_PONDERADA_ID != original.MONEDA_PONDERADA_ID) return true;
			if (this.MONEDA_PONDERADA_COTIZACION != original.MONEDA_PONDERADA_COTIZACION) return true;
			if (this.COSTO_ACTIVO != original.COSTO_ACTIVO) return true;
			if (this.COSTO_PONDERADO != original.COSTO_PONDERADO) return true;
			if (this.IsEXISTENCIA_FORMULARIONull != original.IsEXISTENCIA_FORMULARIONull) return true;
			if (!this.IsEXISTENCIA_FORMULARIONull && !original.IsEXISTENCIA_FORMULARIONull)
				if (this.EXISTENCIA_FORMULARIO != original.EXISTENCIA_FORMULARIO) return true;
			if (this.STOCK_SUC_DEPOSITO_ART_ID != original.STOCK_SUC_DEPOSITO_ART_ID) return true;
			if (this.IsUSUARIO_CIERRE_IDNull != original.IsUSUARIO_CIERRE_IDNull) return true;
			if (!this.IsUSUARIO_CIERRE_IDNull && !original.IsUSUARIO_CIERRE_IDNull)
				if (this.USUARIO_CIERRE_ID != original.USUARIO_CIERRE_ID) return true;
			if (this.IsFECHA_CIERRENull != original.IsFECHA_CIERRENull) return true;
			if (!this.IsFECHA_CIERRENull && !original.IsFECHA_CIERRENull)
				if (this.FECHA_CIERRE != original.FECHA_CIERRE) return true;
			
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
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
		/// Gets or sets the <c>EXISTENCIA_INICIAL</c> column value.
		/// </summary>
		/// <value>The <c>EXISTENCIA_INICIAL</c> column value.</value>
		public decimal EXISTENCIA_INICIAL
		{
			get { return _existencia_inicial; }
			set { _existencia_inicial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMPRA</c> column value.
		/// </summary>
		/// <value>The <c>COMPRA</c> column value.</value>
		public decimal COMPRA
		{
			get { return _compra; }
			set { _compra = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AJUSTE_POSITIVO</c> column value.
		/// </summary>
		/// <value>The <c>AJUSTE_POSITIVO</c> column value.</value>
		public decimal AJUSTE_POSITIVO
		{
			get { return _ajuste_positivo; }
			set { _ajuste_positivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_ENTRADA</c> column value.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_ENTRADA</c> column value.</value>
		public decimal TRANSFERENCIA_ENTRADA
		{
			get { return _transferencia_entrada; }
			set { _transferencia_entrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CREDITO_CLIENTE</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_CLIENTE</c> column value.</value>
		public decimal NOTA_CREDITO_CLIENTE
		{
			get { return _nota_credito_cliente; }
			set { _nota_credito_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_DEBITO_PROVEEDOR</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_DEBITO_PROVEEDOR</c> column value.</value>
		public decimal NOTA_DEBITO_PROVEEDOR
		{
			get { return _nota_debito_proveedor; }
			set { _nota_debito_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSITO</c> column value.
		/// </summary>
		/// <value>The <c>TRANSITO</c> column value.</value>
		public decimal TRANSITO
		{
			get { return _transito; }
			set { _transito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INDUSTRIALIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INDUSTRIALIZACION</c> column value.</value>
		public decimal INDUSTRIALIZACION
		{
			get
			{
				if(IsINDUSTRIALIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _industrializacion;
			}
			set
			{
				_industrializacionNull = false;
				_industrializacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INDUSTRIALIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINDUSTRIALIZACIONNull
		{
			get { return _industrializacionNull; }
			set { _industrializacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUNTO_MINIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUNTO_MINIMO</c> column value.</value>
		public decimal PUNTO_MINIMO
		{
			get
			{
				if(IsPUNTO_MINIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _punto_minimo;
			}
			set
			{
				_punto_minimoNull = false;
				_punto_minimo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUNTO_MINIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUNTO_MINIMONull
		{
			get { return _punto_minimoNull; }
			set { _punto_minimoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMBOS_ELIMINADOS</c> column value.
		/// </summary>
		/// <value>The <c>COMBOS_ELIMINADOS</c> column value.</value>
		public decimal COMBOS_ELIMINADOS
		{
			get { return _combos_eliminados; }
			set { _combos_eliminados = value; }
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
		/// Gets or sets the <c>VENTA</c> column value.
		/// </summary>
		/// <value>The <c>VENTA</c> column value.</value>
		public decimal VENTA
		{
			get { return _venta; }
			set { _venta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSFERENCIA_SALIDA</c> column value.
		/// </summary>
		/// <value>The <c>TRANSFERENCIA_SALIDA</c> column value.</value>
		public decimal TRANSFERENCIA_SALIDA
		{
			get { return _transferencia_salida; }
			set { _transferencia_salida = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AJUSTE_NEGATIVO</c> column value.
		/// </summary>
		/// <value>The <c>AJUSTE_NEGATIVO</c> column value.</value>
		public decimal AJUSTE_NEGATIVO
		{
			get { return _ajuste_negativo; }
			set { _ajuste_negativo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_DEBITO_CLIENTE</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_DEBITO_CLIENTE</c> column value.</value>
		public decimal NOTA_DEBITO_CLIENTE
		{
			get { return _nota_debito_cliente; }
			set { _nota_debito_cliente = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOTA_CREDITO_PROVEEDOR</c> column value.
		/// </summary>
		/// <value>The <c>NOTA_CREDITO_PROVEEDOR</c> column value.</value>
		public decimal NOTA_CREDITO_PROVEEDOR
		{
			get { return _nota_credito_proveedor; }
			set { _nota_credito_proveedor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USO_DE_INSUMO</c> column value.
		/// </summary>
		/// <value>The <c>USO_DE_INSUMO</c> column value.</value>
		public decimal USO_DE_INSUMO
		{
			get { return _uso_de_insumo; }
			set { _uso_de_insumo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMBOS_CREADOS</c> column value.
		/// </summary>
		/// <value>The <c>COMBOS_CREADOS</c> column value.</value>
		public decimal COMBOS_CREADOS
		{
			get { return _combos_creados; }
			set { _combos_creados = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FORMATO_NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FORMATO_NUMERO</c> column value.</value>
		public decimal FECHA_FORMATO_NUMERO
		{
			get { return _fecha_formato_numero; }
			set { _fecha_formato_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ACTIVA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ACTIVA_ID</c> column value.</value>
		public decimal MONEDA_ACTIVA_ID
		{
			get { return _moneda_activa_id; }
			set { _moneda_activa_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ACTIVA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ACTIVA_COTIZACION</c> column value.</value>
		public decimal MONEDA_ACTIVA_COTIZACION
		{
			get { return _moneda_activa_cotizacion; }
			set { _moneda_activa_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PONDERADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_PONDERADA_ID</c> column value.</value>
		public decimal MONEDA_PONDERADA_ID
		{
			get { return _moneda_ponderada_id; }
			set { _moneda_ponderada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_PONDERADA_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_PONDERADA_COTIZACION</c> column value.</value>
		public decimal MONEDA_PONDERADA_COTIZACION
		{
			get { return _moneda_ponderada_cotizacion; }
			set { _moneda_ponderada_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ACTIVO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_ACTIVO</c> column value.</value>
		public decimal COSTO_ACTIVO
		{
			get { return _costo_activo; }
			set { _costo_activo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_PONDERADO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_PONDERADO</c> column value.</value>
		public decimal COSTO_PONDERADO
		{
			get { return _costo_ponderado; }
			set { _costo_ponderado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTENCIA_FORMULARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXISTENCIA_FORMULARIO</c> column value.</value>
		public decimal EXISTENCIA_FORMULARIO
		{
			get
			{
				if(IsEXISTENCIA_FORMULARIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _existencia_formulario;
			}
			set
			{
				_existencia_formularioNull = false;
				_existencia_formulario = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EXISTENCIA_FORMULARIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEXISTENCIA_FORMULARIONull
		{
			get { return _existencia_formularioNull; }
			set { _existencia_formularioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_SUC_DEPOSITO_ART_ID</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_SUC_DEPOSITO_ART_ID</c> column value.</value>
		public decimal STOCK_SUC_DEPOSITO_ART_ID
		{
			get { return _stock_suc_deposito_art_id; }
			set { _stock_suc_deposito_art_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CIERRE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_CIERRE_ID</c> column value.</value>
		public decimal USUARIO_CIERRE_ID
		{
			get
			{
				if(IsUSUARIO_CIERRE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_cierre_id;
			}
			set
			{
				_usuario_cierre_idNull = false;
				_usuario_cierre_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_CIERRE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_CIERRE_IDNull
		{
			get { return _usuario_cierre_idNull; }
			set { _usuario_cierre_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CIERRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CIERRE</c> column value.</value>
		public System.DateTime FECHA_CIERRE
		{
			get
			{
				if(IsFECHA_CIERRENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_cierre;
			}
			set
			{
				_fecha_cierreNull = false;
				_fecha_cierre = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CIERRE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CIERRENull
		{
			get { return _fecha_cierreNull; }
			set { _fecha_cierreNull = value; }
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
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_LOTE_ID=");
			dynStr.Append(IsARTICULO_LOTE_IDNull ? (object)"<NULL>" : ARTICULO_LOTE_ID);
			dynStr.Append("@CBA@EXISTENCIA_INICIAL=");
			dynStr.Append(EXISTENCIA_INICIAL);
			dynStr.Append("@CBA@COMPRA=");
			dynStr.Append(COMPRA);
			dynStr.Append("@CBA@AJUSTE_POSITIVO=");
			dynStr.Append(AJUSTE_POSITIVO);
			dynStr.Append("@CBA@TRANSFERENCIA_ENTRADA=");
			dynStr.Append(TRANSFERENCIA_ENTRADA);
			dynStr.Append("@CBA@NOTA_CREDITO_CLIENTE=");
			dynStr.Append(NOTA_CREDITO_CLIENTE);
			dynStr.Append("@CBA@NOTA_DEBITO_PROVEEDOR=");
			dynStr.Append(NOTA_DEBITO_PROVEEDOR);
			dynStr.Append("@CBA@TRANSITO=");
			dynStr.Append(TRANSITO);
			dynStr.Append("@CBA@INDUSTRIALIZACION=");
			dynStr.Append(IsINDUSTRIALIZACIONNull ? (object)"<NULL>" : INDUSTRIALIZACION);
			dynStr.Append("@CBA@PUNTO_MINIMO=");
			dynStr.Append(IsPUNTO_MINIMONull ? (object)"<NULL>" : PUNTO_MINIMO);
			dynStr.Append("@CBA@COMBOS_ELIMINADOS=");
			dynStr.Append(COMBOS_ELIMINADOS);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(EXISTENCIA);
			dynStr.Append("@CBA@VENTA=");
			dynStr.Append(VENTA);
			dynStr.Append("@CBA@TRANSFERENCIA_SALIDA=");
			dynStr.Append(TRANSFERENCIA_SALIDA);
			dynStr.Append("@CBA@AJUSTE_NEGATIVO=");
			dynStr.Append(AJUSTE_NEGATIVO);
			dynStr.Append("@CBA@NOTA_DEBITO_CLIENTE=");
			dynStr.Append(NOTA_DEBITO_CLIENTE);
			dynStr.Append("@CBA@NOTA_CREDITO_PROVEEDOR=");
			dynStr.Append(NOTA_CREDITO_PROVEEDOR);
			dynStr.Append("@CBA@USO_DE_INSUMO=");
			dynStr.Append(USO_DE_INSUMO);
			dynStr.Append("@CBA@COMBOS_CREADOS=");
			dynStr.Append(COMBOS_CREADOS);
			dynStr.Append("@CBA@FECHA_FORMATO_NUMERO=");
			dynStr.Append(FECHA_FORMATO_NUMERO);
			dynStr.Append("@CBA@MONEDA_ACTIVA_ID=");
			dynStr.Append(MONEDA_ACTIVA_ID);
			dynStr.Append("@CBA@MONEDA_ACTIVA_COTIZACION=");
			dynStr.Append(MONEDA_ACTIVA_COTIZACION);
			dynStr.Append("@CBA@MONEDA_PONDERADA_ID=");
			dynStr.Append(MONEDA_PONDERADA_ID);
			dynStr.Append("@CBA@MONEDA_PONDERADA_COTIZACION=");
			dynStr.Append(MONEDA_PONDERADA_COTIZACION);
			dynStr.Append("@CBA@COSTO_ACTIVO=");
			dynStr.Append(COSTO_ACTIVO);
			dynStr.Append("@CBA@COSTO_PONDERADO=");
			dynStr.Append(COSTO_PONDERADO);
			dynStr.Append("@CBA@EXISTENCIA_FORMULARIO=");
			dynStr.Append(IsEXISTENCIA_FORMULARIONull ? (object)"<NULL>" : EXISTENCIA_FORMULARIO);
			dynStr.Append("@CBA@STOCK_SUC_DEPOSITO_ART_ID=");
			dynStr.Append(STOCK_SUC_DEPOSITO_ART_ID);
			dynStr.Append("@CBA@USUARIO_CIERRE_ID=");
			dynStr.Append(IsUSUARIO_CIERRE_IDNull ? (object)"<NULL>" : USUARIO_CIERRE_ID);
			dynStr.Append("@CBA@FECHA_CIERRE=");
			dynStr.Append(IsFECHA_CIERRENull ? (object)"<NULL>" : FECHA_CIERRE);
			return dynStr.ToString();
		}
	} // End of STOCK_SUC_DEPOSITO_ART_FECHARow_Base class
} // End of namespace