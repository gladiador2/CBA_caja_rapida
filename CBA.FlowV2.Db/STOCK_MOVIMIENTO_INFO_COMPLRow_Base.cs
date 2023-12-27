// <fileinfo name="STOCK_MOVIMIENTO_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/> that 
	/// represents a record in the <c>STOCK_MOVIMIENTO_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_MOVIMIENTO_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _flujo_descripcion;
		private string _estado_id;
		private string _estado_anterior_id;
		private decimal _deposito_id;
		private string _deposito_nombre;
		private string _deposito_abreviatura;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _sucursal_abreviatura;
		private decimal _entidad_id;
		private bool _entidad_idNull = true;
		private string _nro_comprobante;
		private string _tipo_movimiento;
		private decimal _articulo_id;
		private string _articulo_codigo;
		private string _articulo_descripcion;
		private decimal _articulo_familia_id;
		private bool _articulo_familia_idNull = true;
		private string _articulo_familia_descripcion;
		private decimal _articulo_grupo_id;
		private bool _articulo_grupo_idNull = true;
		private string _articulo_grupo_descripcion;
		private decimal _articulo_subgrupo_id;
		private bool _articulo_subgrupo_idNull = true;
		private string _articulo_subgrupo_descripcion;
		private decimal _lote_id;
		private string _lote;
		private decimal _cantidad;
		private decimal _usuario_id;
		private string _usuario;
		private string _usuario_nombre;
		private System.DateTime _fecha_movimiento;
		private System.DateTime _fecha_formulario;
		private decimal _existencia;
		private bool _existenciaNull = true;
		private decimal _costo;
		private decimal _costo_moneda_id;
		private decimal _costo_cotizacion_moneda;
		private decimal _costo_origen;
		private decimal _costo_moneda_origen_id;
		private decimal _costo_cotizacion_moneda_origen;
		private string _costo_moneda_nombre;
		private string _moneda_costo_sombolo;
		private string _mon_costo_cade_decimales;
		private decimal _mon_costo_cant_decimales;
		private bool _mon_costo_cant_decimalesNull = true;
		private decimal _costo_ppp;
		private bool _costo_pppNull = true;
		private string _destino;
		private string _estado;
		private decimal _impuesto_id;
		private decimal _registro_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_MOVIMIENTO_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public STOCK_MOVIMIENTO_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_MOVIMIENTO_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.FLUJO_DESCRIPCION != original.FLUJO_DESCRIPCION) return true;
			if (this.ESTADO_ID != original.ESTADO_ID) return true;
			if (this.ESTADO_ANTERIOR_ID != original.ESTADO_ANTERIOR_ID) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_NOMBRE != original.DEPOSITO_NOMBRE) return true;
			if (this.DEPOSITO_ABREVIATURA != original.DEPOSITO_ABREVIATURA) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.SUCURSAL_ABREVIATURA != original.SUCURSAL_ABREVIATURA) return true;
			if (this.IsENTIDAD_IDNull != original.IsENTIDAD_IDNull) return true;
			if (!this.IsENTIDAD_IDNull && !original.IsENTIDAD_IDNull)
				if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			if (this.TIPO_MOVIMIENTO != original.TIPO_MOVIMIENTO) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_DESCRIPCION != original.ARTICULO_DESCRIPCION) return true;
			if (this.IsARTICULO_FAMILIA_IDNull != original.IsARTICULO_FAMILIA_IDNull) return true;
			if (!this.IsARTICULO_FAMILIA_IDNull && !original.IsARTICULO_FAMILIA_IDNull)
				if (this.ARTICULO_FAMILIA_ID != original.ARTICULO_FAMILIA_ID) return true;
			if (this.ARTICULO_FAMILIA_DESCRIPCION != original.ARTICULO_FAMILIA_DESCRIPCION) return true;
			if (this.IsARTICULO_GRUPO_IDNull != original.IsARTICULO_GRUPO_IDNull) return true;
			if (!this.IsARTICULO_GRUPO_IDNull && !original.IsARTICULO_GRUPO_IDNull)
				if (this.ARTICULO_GRUPO_ID != original.ARTICULO_GRUPO_ID) return true;
			if (this.ARTICULO_GRUPO_DESCRIPCION != original.ARTICULO_GRUPO_DESCRIPCION) return true;
			if (this.IsARTICULO_SUBGRUPO_IDNull != original.IsARTICULO_SUBGRUPO_IDNull) return true;
			if (!this.IsARTICULO_SUBGRUPO_IDNull && !original.IsARTICULO_SUBGRUPO_IDNull)
				if (this.ARTICULO_SUBGRUPO_ID != original.ARTICULO_SUBGRUPO_ID) return true;
			if (this.ARTICULO_SUBGRUPO_DESCRIPCION != original.ARTICULO_SUBGRUPO_DESCRIPCION) return true;
			if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.LOTE != original.LOTE) return true;
			if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.USUARIO_NOMBRE != original.USUARIO_NOMBRE) return true;
			if (this.FECHA_MOVIMIENTO != original.FECHA_MOVIMIENTO) return true;
			if (this.FECHA_FORMULARIO != original.FECHA_FORMULARIO) return true;
			if (this.IsEXISTENCIANull != original.IsEXISTENCIANull) return true;
			if (!this.IsEXISTENCIANull && !original.IsEXISTENCIANull)
				if (this.EXISTENCIA != original.EXISTENCIA) return true;
			if (this.COSTO != original.COSTO) return true;
			if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.COSTO_COTIZACION_MONEDA != original.COSTO_COTIZACION_MONEDA) return true;
			if (this.COSTO_ORIGEN != original.COSTO_ORIGEN) return true;
			if (this.COSTO_MONEDA_ORIGEN_ID != original.COSTO_MONEDA_ORIGEN_ID) return true;
			if (this.COSTO_COTIZACION_MONEDA_ORIGEN != original.COSTO_COTIZACION_MONEDA_ORIGEN) return true;
			if (this.COSTO_MONEDA_NOMBRE != original.COSTO_MONEDA_NOMBRE) return true;
			if (this.MONEDA_COSTO_SOMBOLO != original.MONEDA_COSTO_SOMBOLO) return true;
			if (this.MON_COSTO_CADE_DECIMALES != original.MON_COSTO_CADE_DECIMALES) return true;
			if (this.IsMON_COSTO_CANT_DECIMALESNull != original.IsMON_COSTO_CANT_DECIMALESNull) return true;
			if (!this.IsMON_COSTO_CANT_DECIMALESNull && !original.IsMON_COSTO_CANT_DECIMALESNull)
				if (this.MON_COSTO_CANT_DECIMALES != original.MON_COSTO_CANT_DECIMALES) return true;
			if (this.IsCOSTO_PPPNull != original.IsCOSTO_PPPNull) return true;
			if (!this.IsCOSTO_PPPNull && !original.IsCOSTO_PPPNull)
				if (this.COSTO_PPP != original.COSTO_PPP) return true;
			if (this.DESTINO != original.DESTINO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_DESCRIPCION</c> column value.</value>
		public string FLUJO_DESCRIPCION
		{
			get { return _flujo_descripcion; }
			set { _flujo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ID</c> column value.</value>
		public string ESTADO_ID
		{
			get { return _estado_id; }
			set { _estado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ANTERIOR_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO_ANTERIOR_ID</c> column value.</value>
		public string ESTADO_ANTERIOR_ID
		{
			get { return _estado_anterior_id; }
			set { _estado_anterior_id = value; }
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
		/// Gets or sets the <c>DEPOSITO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_NOMBRE</c> column value.</value>
		public string DEPOSITO_NOMBRE
		{
			get { return _deposito_nombre; }
			set { _deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPOSITO_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>DEPOSITO_ABREVIATURA</c> column value.</value>
		public string DEPOSITO_ABREVIATURA
		{
			get { return _deposito_abreviatura; }
			set { _deposito_abreviatura = value; }
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ABREVIATURA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ABREVIATURA</c> column value.</value>
		public string SUCURSAL_ABREVIATURA
		{
			get { return _sucursal_abreviatura; }
			set { _sucursal_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get
			{
				if(IsENTIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _entidad_id;
			}
			set
			{
				_entidad_idNull = false;
				_entidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENTIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENTIDAD_IDNull
		{
			get { return _entidad_idNull; }
			set { _entidad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO</c> column value.</value>
		public string TIPO_MOVIMIENTO
		{
			get { return _tipo_movimiento; }
			set { _tipo_movimiento = value; }
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
		/// Gets or sets the <c>ARTICULO_FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_FAMILIA_DESCRIPCION</c> column value.</value>
		public string ARTICULO_FAMILIA_DESCRIPCION
		{
			get { return _articulo_familia_descripcion; }
			set { _articulo_familia_descripcion = value; }
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
		/// Gets or sets the <c>ARTICULO_GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_GRUPO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_GRUPO_DESCRIPCION
		{
			get { return _articulo_grupo_descripcion; }
			set { _articulo_grupo_descripcion = value; }
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
		/// Gets or sets the <c>ARTICULO_SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_SUBGRUPO_DESCRIPCION</c> column value.</value>
		public string ARTICULO_SUBGRUPO_DESCRIPCION
		{
			get { return _articulo_subgrupo_descripcion; }
			set { _articulo_subgrupo_descripcion = value; }
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
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_NOMBRE</c> column value.</value>
		public string USUARIO_NOMBRE
		{
			get { return _usuario_nombre; }
			set { _usuario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MOVIMIENTO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MOVIMIENTO</c> column value.</value>
		public System.DateTime FECHA_MOVIMIENTO
		{
			get { return _fecha_movimiento; }
			set { _fecha_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FORMULARIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_FORMULARIO</c> column value.</value>
		public System.DateTime FECHA_FORMULARIO
		{
			get { return _fecha_formulario; }
			set { _fecha_formulario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXISTENCIA</c> column value.</value>
		public decimal EXISTENCIA
		{
			get
			{
				if(IsEXISTENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _existencia;
			}
			set
			{
				_existenciaNull = false;
				_existencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EXISTENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEXISTENCIANull
		{
			get { return _existenciaNull; }
			set { _existenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO</c> column value.
		/// </summary>
		/// <value>The <c>COSTO</c> column value.</value>
		public decimal COSTO
		{
			get { return _costo; }
			set { _costo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ID
		{
			get { return _costo_moneda_id; }
			set { _costo_moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_COTIZACION_MONEDA</c> column value.</value>
		public decimal COSTO_COTIZACION_MONEDA
		{
			get { return _costo_cotizacion_moneda; }
			set { _costo_cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_ORIGEN</c> column value.</value>
		public decimal COSTO_ORIGEN
		{
			get { return _costo_origen; }
			set { _costo_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ORIGEN_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ORIGEN_ID
		{
			get { return _costo_moneda_origen_id; }
			set { _costo_moneda_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_COTIZACION_MONEDA_ORIGEN</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_COTIZACION_MONEDA_ORIGEN</c> column value.</value>
		public decimal COSTO_COTIZACION_MONEDA_ORIGEN
		{
			get { return _costo_cotizacion_moneda_origen; }
			set { _costo_cotizacion_moneda_origen = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_NOMBRE</c> column value.</value>
		public string COSTO_MONEDA_NOMBRE
		{
			get { return _costo_moneda_nombre; }
			set { _costo_moneda_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_COSTO_SOMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_COSTO_SOMBOLO</c> column value.</value>
		public string MONEDA_COSTO_SOMBOLO
		{
			get { return _moneda_costo_sombolo; }
			set { _moneda_costo_sombolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MON_COSTO_CADE_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MON_COSTO_CADE_DECIMALES</c> column value.</value>
		public string MON_COSTO_CADE_DECIMALES
		{
			get { return _mon_costo_cade_decimales; }
			set { _mon_costo_cade_decimales = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MON_COSTO_CANT_DECIMALES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MON_COSTO_CANT_DECIMALES</c> column value.</value>
		public decimal MON_COSTO_CANT_DECIMALES
		{
			get
			{
				if(IsMON_COSTO_CANT_DECIMALESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _mon_costo_cant_decimales;
			}
			set
			{
				_mon_costo_cant_decimalesNull = false;
				_mon_costo_cant_decimales = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MON_COSTO_CANT_DECIMALES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMON_COSTO_CANT_DECIMALESNull
		{
			get { return _mon_costo_cant_decimalesNull; }
			set { _mon_costo_cant_decimalesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_PPP</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_PPP</c> column value.</value>
		public decimal COSTO_PPP
		{
			get
			{
				if(IsCOSTO_PPPNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_ppp;
			}
			set
			{
				_costo_pppNull = false;
				_costo_ppp = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_PPP"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_PPPNull
		{
			get { return _costo_pppNull; }
			set { _costo_pppNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESTINO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESTINO</c> column value.</value>
		public string DESTINO
		{
			get { return _destino; }
			set { _destino = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPUESTO_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTO_ID</c> column value.</value>
		public decimal IMPUESTO_ID
		{
			get { return _impuesto_id; }
			set { _impuesto_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public decimal REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@FLUJO_DESCRIPCION=");
			dynStr.Append(FLUJO_DESCRIPCION);
			dynStr.Append("@CBA@ESTADO_ID=");
			dynStr.Append(ESTADO_ID);
			dynStr.Append("@CBA@ESTADO_ANTERIOR_ID=");
			dynStr.Append(ESTADO_ANTERIOR_ID);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_NOMBRE=");
			dynStr.Append(DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@DEPOSITO_ABREVIATURA=");
			dynStr.Append(DEPOSITO_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ABREVIATURA=");
			dynStr.Append(SUCURSAL_ABREVIATURA);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(IsENTIDAD_IDNull ? (object)"<NULL>" : ENTIDAD_ID);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO=");
			dynStr.Append(TIPO_MOVIMIENTO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION=");
			dynStr.Append(ARTICULO_DESCRIPCION);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_ID=");
			dynStr.Append(IsARTICULO_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULO_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULO_FAMILIA_DESCRIPCION=");
			dynStr.Append(ARTICULO_FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@ARTICULO_GRUPO_ID=");
			dynStr.Append(IsARTICULO_GRUPO_IDNull ? (object)"<NULL>" : ARTICULO_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_GRUPO_DESCRIPCION=");
			dynStr.Append(ARTICULO_GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_ID=");
			dynStr.Append(IsARTICULO_SUBGRUPO_IDNull ? (object)"<NULL>" : ARTICULO_SUBGRUPO_ID);
			dynStr.Append("@CBA@ARTICULO_SUBGRUPO_DESCRIPCION=");
			dynStr.Append(ARTICULO_SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(LOTE_ID);
			dynStr.Append("@CBA@LOTE=");
			dynStr.Append(LOTE);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(CANTIDAD);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@USUARIO_NOMBRE=");
			dynStr.Append(USUARIO_NOMBRE);
			dynStr.Append("@CBA@FECHA_MOVIMIENTO=");
			dynStr.Append(FECHA_MOVIMIENTO);
			dynStr.Append("@CBA@FECHA_FORMULARIO=");
			dynStr.Append(FECHA_FORMULARIO);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(IsEXISTENCIANull ? (object)"<NULL>" : EXISTENCIA);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(COSTO);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_COTIZACION_MONEDA=");
			dynStr.Append(COSTO_COTIZACION_MONEDA);
			dynStr.Append("@CBA@COSTO_ORIGEN=");
			dynStr.Append(COSTO_ORIGEN);
			dynStr.Append("@CBA@COSTO_MONEDA_ORIGEN_ID=");
			dynStr.Append(COSTO_MONEDA_ORIGEN_ID);
			dynStr.Append("@CBA@COSTO_COTIZACION_MONEDA_ORIGEN=");
			dynStr.Append(COSTO_COTIZACION_MONEDA_ORIGEN);
			dynStr.Append("@CBA@COSTO_MONEDA_NOMBRE=");
			dynStr.Append(COSTO_MONEDA_NOMBRE);
			dynStr.Append("@CBA@MONEDA_COSTO_SOMBOLO=");
			dynStr.Append(MONEDA_COSTO_SOMBOLO);
			dynStr.Append("@CBA@MON_COSTO_CADE_DECIMALES=");
			dynStr.Append(MON_COSTO_CADE_DECIMALES);
			dynStr.Append("@CBA@MON_COSTO_CANT_DECIMALES=");
			dynStr.Append(IsMON_COSTO_CANT_DECIMALESNull ? (object)"<NULL>" : MON_COSTO_CANT_DECIMALES);
			dynStr.Append("@CBA@COSTO_PPP=");
			dynStr.Append(IsCOSTO_PPPNull ? (object)"<NULL>" : COSTO_PPP);
			dynStr.Append("@CBA@DESTINO=");
			dynStr.Append(DESTINO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			return dynStr.ToString();
		}
	} // End of STOCK_MOVIMIENTO_INFO_COMPLRow_Base class
} // End of namespace
