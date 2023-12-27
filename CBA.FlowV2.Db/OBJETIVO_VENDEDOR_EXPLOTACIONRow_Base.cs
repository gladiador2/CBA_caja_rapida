// <fileinfo name="OBJETIVO_VENDEDOR_EXPLOTACIONRow_Base.cs">
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
	/// The base class for <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> that 
	/// represents a record in the <c>OBJETIVO_VENDEDOR_EXPLOTACION</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJETIVO_VENDEDOR_EXPLOTACIONRow_Base
	{
		private decimal _factura_cliente_detalle_id;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _vendedor_comisionista_id;
		private bool _vendedor_comisionista_idNull = true;
		private string _vendedor_nombre;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _persona_nombre_completo;
		private string _persona_codigo;
		private decimal _articulo_id;
		private string _articulo_descripcion;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private string _familia_nombre;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private string _grupo_nombre;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _subgrupo_nombre;
		private decimal _articulo_marca_id;
		private bool _articulo_marca_idNull = true;
		private decimal _cantidad_vendida;
		private bool _cantidad_vendidaNull = true;
		private decimal _monto_vendido_usd;
		private bool _monto_vendido_usdNull = true;
		private decimal _monto_vendido;
		private bool _monto_vendidoNull = true;
		private decimal _monto_linea_credito;
		private decimal _moneda_linea_credito;
		private decimal _moneda_lc_cotizacion;
		private decimal _credito_menos_debito;
		private bool _credito_menos_debitoNull = true;
		private decimal _tot_cheq_no_deposit_ni_efectiv;
		private bool _tot_cheq_no_deposit_ni_efectivNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cantidad_decimales;
		private bool _cantidad_decimalesNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow_Base"/> class.
		/// </summary>
		public OBJETIVO_VENDEDOR_EXPLOTACIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OBJETIVO_VENDEDOR_EXPLOTACIONRow_Base original)
		{
			if (this.FACTURA_CLIENTE_DETALLE_ID != original.FACTURA_CLIENTE_DETALLE_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsVENDEDOR_COMISIONISTA_IDNull != original.IsVENDEDOR_COMISIONISTA_IDNull) return true;
			if (!this.IsVENDEDOR_COMISIONISTA_IDNull && !original.IsVENDEDOR_COMISIONISTA_IDNull)
				if (this.VENDEDOR_COMISIONISTA_ID != original.VENDEDOR_COMISIONISTA_ID) return true;
			if (this.VENDEDOR_NOMBRE != original.VENDEDOR_NOMBRE) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE_COMPLETO != original.PERSONA_NOMBRE_COMPLETO) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_NOMBRE != original.FAMILIA_NOMBRE) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_NOMBRE != original.GRUPO_NOMBRE) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.SUBGRUPO_NOMBRE != original.SUBGRUPO_NOMBRE) return true;
			if (this.IsARTICULO_MARCA_IDNull != original.IsARTICULO_MARCA_IDNull) return true;
			if (!this.IsARTICULO_MARCA_IDNull && !original.IsARTICULO_MARCA_IDNull)
				if (this.ARTICULO_MARCA_ID != original.ARTICULO_MARCA_ID) return true;
			if (this.IsCANTIDAD_VENDIDANull != original.IsCANTIDAD_VENDIDANull) return true;
			if (!this.IsCANTIDAD_VENDIDANull && !original.IsCANTIDAD_VENDIDANull)
				if (this.CANTIDAD_VENDIDA != original.CANTIDAD_VENDIDA) return true;
			if (this.IsMONTO_VENDIDO_USDNull != original.IsMONTO_VENDIDO_USDNull) return true;
			if (!this.IsMONTO_VENDIDO_USDNull && !original.IsMONTO_VENDIDO_USDNull)
				if (this.MONTO_VENDIDO_USD != original.MONTO_VENDIDO_USD) return true;
			if (this.IsMONTO_VENDIDONull != original.IsMONTO_VENDIDONull) return true;
			if (!this.IsMONTO_VENDIDONull && !original.IsMONTO_VENDIDONull)
				if (this.MONTO_VENDIDO != original.MONTO_VENDIDO) return true;
			if (this.MONTO_LINEA_CREDITO != original.MONTO_LINEA_CREDITO) return true;
			if (this.MONEDA_LINEA_CREDITO != original.MONEDA_LINEA_CREDITO) return true;
			if (this.MONEDA_LC_COTIZACION != original.MONEDA_LC_COTIZACION) return true;
			if (this.IsCREDITO_MENOS_DEBITONull != original.IsCREDITO_MENOS_DEBITONull) return true;
			if (!this.IsCREDITO_MENOS_DEBITONull && !original.IsCREDITO_MENOS_DEBITONull)
				if (this.CREDITO_MENOS_DEBITO != original.CREDITO_MENOS_DEBITO) return true;
			if (this.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull != original.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull) return true;
			if (!this.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull && !original.IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull)
				if (this.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV != original.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCANTIDAD_DECIMALESNull != original.IsCANTIDAD_DECIMALESNull) return true;
			if (!this.IsCANTIDAD_DECIMALESNull && !original.IsCANTIDAD_DECIMALESNull)
				if (this.CANTIDAD_DECIMALES != original.CANTIDAD_DECIMALES) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</value>
		public decimal FACTURA_CLIENTE_DETALLE_ID
		{
			get { return _factura_cliente_detalle_id; }
			set { _factura_cliente_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_COMISIONISTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</value>
		public decimal VENDEDOR_COMISIONISTA_ID
		{
			get
			{
				if(IsVENDEDOR_COMISIONISTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vendedor_comisionista_id;
			}
			set
			{
				_vendedor_comisionista_idNull = false;
				_vendedor_comisionista_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENDEDOR_COMISIONISTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENDEDOR_COMISIONISTA_IDNull
		{
			get { return _vendedor_comisionista_idNull; }
			set { _vendedor_comisionista_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENDEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENDEDOR_NOMBRE</c> column value.</value>
		public string VENDEDOR_NOMBRE
		{
			get { return _vendedor_nombre; }
			set { _vendedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE_COMPLETO</c> column value.</value>
		public string PERSONA_NOMBRE_COMPLETO
		{
			get { return _persona_nombre_completo; }
			set { _persona_nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
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
		/// Gets or sets the <c>FAMILIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>FAMILIA_NOMBRE</c> column value.</value>
		public string FAMILIA_NOMBRE
		{
			get { return _familia_nombre; }
			set { _familia_nombre = value; }
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
		/// Gets or sets the <c>GRUPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>GRUPO_NOMBRE</c> column value.</value>
		public string GRUPO_NOMBRE
		{
			get { return _grupo_nombre; }
			set { _grupo_nombre = value; }
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
		/// Gets or sets the <c>SUBGRUPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUBGRUPO_NOMBRE</c> column value.</value>
		public string SUBGRUPO_NOMBRE
		{
			get { return _subgrupo_nombre; }
			set { _subgrupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_MARCA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_MARCA_ID</c> column value.</value>
		public decimal ARTICULO_MARCA_ID
		{
			get
			{
				if(IsARTICULO_MARCA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_marca_id;
			}
			set
			{
				_articulo_marca_idNull = false;
				_articulo_marca_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_MARCA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_MARCA_IDNull
		{
			get { return _articulo_marca_idNull; }
			set { _articulo_marca_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_VENDIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_VENDIDA</c> column value.</value>
		public decimal CANTIDAD_VENDIDA
		{
			get
			{
				if(IsCANTIDAD_VENDIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_vendida;
			}
			set
			{
				_cantidad_vendidaNull = false;
				_cantidad_vendida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_VENDIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_VENDIDANull
		{
			get { return _cantidad_vendidaNull; }
			set { _cantidad_vendidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_VENDIDO_USD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_VENDIDO_USD</c> column value.</value>
		public decimal MONTO_VENDIDO_USD
		{
			get
			{
				if(IsMONTO_VENDIDO_USDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_vendido_usd;
			}
			set
			{
				_monto_vendido_usdNull = false;
				_monto_vendido_usd = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_VENDIDO_USD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_VENDIDO_USDNull
		{
			get { return _monto_vendido_usdNull; }
			set { _monto_vendido_usdNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_VENDIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_VENDIDO</c> column value.</value>
		public decimal MONTO_VENDIDO
		{
			get
			{
				if(IsMONTO_VENDIDONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_vendido;
			}
			set
			{
				_monto_vendidoNull = false;
				_monto_vendido = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_VENDIDO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_VENDIDONull
		{
			get { return _monto_vendidoNull; }
			set { _monto_vendidoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_LINEA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO_LINEA_CREDITO</c> column value.</value>
		public decimal MONTO_LINEA_CREDITO
		{
			get { return _monto_linea_credito; }
			set { _monto_linea_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_LINEA_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_LINEA_CREDITO</c> column value.</value>
		public decimal MONEDA_LINEA_CREDITO
		{
			get { return _moneda_linea_credito; }
			set { _moneda_linea_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_LC_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_LC_COTIZACION</c> column value.</value>
		public decimal MONEDA_LC_COTIZACION
		{
			get { return _moneda_lc_cotizacion; }
			set { _moneda_lc_cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CREDITO_MENOS_DEBITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CREDITO_MENOS_DEBITO</c> column value.</value>
		public decimal CREDITO_MENOS_DEBITO
		{
			get
			{
				if(IsCREDITO_MENOS_DEBITONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _credito_menos_debito;
			}
			set
			{
				_credito_menos_debitoNull = false;
				_credito_menos_debito = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CREDITO_MENOS_DEBITO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCREDITO_MENOS_DEBITONull
		{
			get { return _credito_menos_debitoNull; }
			set { _credito_menos_debitoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV</c> column value.</value>
		public decimal TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV
		{
			get
			{
				if(IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tot_cheq_no_deposit_ni_efectiv;
			}
			set
			{
				_tot_cheq_no_deposit_ni_efectivNull = false;
				_tot_cheq_no_deposit_ni_efectiv = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull
		{
			get { return _tot_cheq_no_deposit_ni_efectivNull; }
			set { _tot_cheq_no_deposit_ni_efectivNull = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_DECIMALES</c> column value.</value>
		public decimal CANTIDAD_DECIMALES
		{
			get
			{
				if(IsCANTIDAD_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_decimales;
			}
			set
			{
				_cantidad_decimalesNull = false;
				_cantidad_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_DECIMALESNull
		{
			get { return _cantidad_decimalesNull; }
			set { _cantidad_decimalesNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FACTURA_CLIENTE_DETALLE_ID=");
			dynStr.Append(FACTURA_CLIENTE_DETALLE_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@VENDEDOR_COMISIONISTA_ID=");
			dynStr.Append(IsVENDEDOR_COMISIONISTA_IDNull ? (object)"<NULL>" : VENDEDOR_COMISIONISTA_ID);
			dynStr.Append("@CBA@VENDEDOR_NOMBRE=");
			dynStr.Append(VENDEDOR_NOMBRE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE_COMPLETO=");
			dynStr.Append(PERSONA_NOMBRE_COMPLETO);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_NOMBRE=");
			dynStr.Append(FAMILIA_NOMBRE);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_NOMBRE=");
			dynStr.Append(GRUPO_NOMBRE);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_NOMBRE=");
			dynStr.Append(SUBGRUPO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_MARCA_ID=");
			dynStr.Append(IsARTICULO_MARCA_IDNull ? (object)"<NULL>" : ARTICULO_MARCA_ID);
			dynStr.Append("@CBA@CANTIDAD_VENDIDA=");
			dynStr.Append(IsCANTIDAD_VENDIDANull ? (object)"<NULL>" : CANTIDAD_VENDIDA);
			dynStr.Append("@CBA@MONTO_VENDIDO_USD=");
			dynStr.Append(IsMONTO_VENDIDO_USDNull ? (object)"<NULL>" : MONTO_VENDIDO_USD);
			dynStr.Append("@CBA@MONTO_VENDIDO=");
			dynStr.Append(IsMONTO_VENDIDONull ? (object)"<NULL>" : MONTO_VENDIDO);
			dynStr.Append("@CBA@MONTO_LINEA_CREDITO=");
			dynStr.Append(MONTO_LINEA_CREDITO);
			dynStr.Append("@CBA@MONEDA_LINEA_CREDITO=");
			dynStr.Append(MONEDA_LINEA_CREDITO);
			dynStr.Append("@CBA@MONEDA_LC_COTIZACION=");
			dynStr.Append(MONEDA_LC_COTIZACION);
			dynStr.Append("@CBA@CREDITO_MENOS_DEBITO=");
			dynStr.Append(IsCREDITO_MENOS_DEBITONull ? (object)"<NULL>" : CREDITO_MENOS_DEBITO);
			dynStr.Append("@CBA@TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV=");
			dynStr.Append(IsTOT_CHEQ_NO_DEPOSIT_NI_EFECTIVNull ? (object)"<NULL>" : TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@CANTIDAD_DECIMALES=");
			dynStr.Append(IsCANTIDAD_DECIMALESNull ? (object)"<NULL>" : CANTIDAD_DECIMALES);
			return dynStr.ToString();
		}
	} // End of OBJETIVO_VENDEDOR_EXPLOTACIONRow_Base class
} // End of namespace
