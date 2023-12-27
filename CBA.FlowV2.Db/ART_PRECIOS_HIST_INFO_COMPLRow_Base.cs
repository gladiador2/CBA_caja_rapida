// <fileinfo name="ART_PRECIOS_HIST_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ART_PRECIOS_HIST_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ART_PRECIOS_HIST_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _articulo_id;
		private string _codigo_empresa;
		private string _articulo_descripcion_interna;
		private decimal _articulos_familia_id;
		private bool _articulos_familia_idNull = true;
		private string _articulos_familia_nombre;
		private decimal _articulos_grupo_id;
		private bool _articulos_grupo_idNull = true;
		private string _articulos_grupo_nombre;
		private decimal _articulos_sub_grupo_id;
		private bool _articulos_sub_grupo_idNull = true;
		private string _articulos_subgrupos_nombre;
		private decimal _sucursal_id;
		private string _sucursales_nombre;
		private string _sucursales_abreviatura;
		private decimal _sucursales_entidad_id;
		private string _sucursales_entidad_nombre;
		private decimal _moneda_id;
		private string _monedas_nombre;
		private string _monedas_simbolo;
		private decimal _cotizacion_moneda;
		private decimal _precio;
		private decimal _impuesto_id;
		private string _impuestos_nombre;
		private decimal _costo;
		private bool _costoNull = true;
		private decimal _costo_moneda_id;
		private bool _costo_moneda_idNull = true;
		private decimal _costo_moneda_cotizacion;
		private bool _costo_moneda_cotizacionNull = true;
		private string _costo_moneda_simbolo;
		private decimal _usuario_id;
		private string _usuarios_usuario;
		private System.DateTime _fecha;
		private string _observacion;
		private decimal _descuento_maximo;
		private bool _descuento_maximoNull = true;
		private decimal _cantidad_minima;
		private bool _cantidad_minimaNull = true;
		private decimal _marca_id;
		private bool _marca_idNull = true;
		private string _nombre_marca;

		/// <summary>
		/// Initializes a new instance of the <see cref="ART_PRECIOS_HIST_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ART_PRECIOS_HIST_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ART_PRECIOS_HIST_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.CODIGO_EMPRESA != original.CODIGO_EMPRESA) return true;
			if (this.ARTICULO_DESCRIPCION_INTERNA != original.ARTICULO_DESCRIPCION_INTERNA) return true;
			if (this.IsARTICULOS_FAMILIA_IDNull != original.IsARTICULOS_FAMILIA_IDNull) return true;
			if (!this.IsARTICULOS_FAMILIA_IDNull && !original.IsARTICULOS_FAMILIA_IDNull)
				if (this.ARTICULOS_FAMILIA_ID != original.ARTICULOS_FAMILIA_ID) return true;
			if (this.ARTICULOS_FAMILIA_NOMBRE != original.ARTICULOS_FAMILIA_NOMBRE) return true;
			if (this.IsARTICULOS_GRUPO_IDNull != original.IsARTICULOS_GRUPO_IDNull) return true;
			if (!this.IsARTICULOS_GRUPO_IDNull && !original.IsARTICULOS_GRUPO_IDNull)
				if (this.ARTICULOS_GRUPO_ID != original.ARTICULOS_GRUPO_ID) return true;
			if (this.ARTICULOS_GRUPO_NOMBRE != original.ARTICULOS_GRUPO_NOMBRE) return true;
			if (this.IsARTICULOS_SUB_GRUPO_IDNull != original.IsARTICULOS_SUB_GRUPO_IDNull) return true;
			if (!this.IsARTICULOS_SUB_GRUPO_IDNull && !original.IsARTICULOS_SUB_GRUPO_IDNull)
				if (this.ARTICULOS_SUB_GRUPO_ID != original.ARTICULOS_SUB_GRUPO_ID) return true;
			if (this.ARTICULOS_SUBGRUPOS_NOMBRE != original.ARTICULOS_SUBGRUPOS_NOMBRE) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSALES_NOMBRE != original.SUCURSALES_NOMBRE) return true;
			if (this.SUCURSALES_ABREVIATURA != original.SUCURSALES_ABREVIATURA) return true;
			if (this.SUCURSALES_ENTIDAD_ID != original.SUCURSALES_ENTIDAD_ID) return true;
			if (this.SUCURSALES_ENTIDAD_NOMBRE != original.SUCURSALES_ENTIDAD_NOMBRE) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.MONEDAS_NOMBRE != original.MONEDAS_NOMBRE) return true;
			if (this.MONEDAS_SIMBOLO != original.MONEDAS_SIMBOLO) return true;
			if (this.COTIZACION_MONEDA != original.COTIZACION_MONEDA) return true;
			if (this.PRECIO != original.PRECIO) return true;
			if (this.IMPUESTO_ID != original.IMPUESTO_ID) return true;
			if (this.IMPUESTOS_NOMBRE != original.IMPUESTOS_NOMBRE) return true;
			if (this.IsCOSTONull != original.IsCOSTONull) return true;
			if (!this.IsCOSTONull && !original.IsCOSTONull)
				if (this.COSTO != original.COSTO) return true;
			if (this.IsCOSTO_MONEDA_IDNull != original.IsCOSTO_MONEDA_IDNull) return true;
			if (!this.IsCOSTO_MONEDA_IDNull && !original.IsCOSTO_MONEDA_IDNull)
				if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.IsCOSTO_MONEDA_COTIZACIONNull != original.IsCOSTO_MONEDA_COTIZACIONNull) return true;
			if (!this.IsCOSTO_MONEDA_COTIZACIONNull && !original.IsCOSTO_MONEDA_COTIZACIONNull)
				if (this.COSTO_MONEDA_COTIZACION != original.COSTO_MONEDA_COTIZACION) return true;
			if (this.COSTO_MONEDA_SIMBOLO != original.COSTO_MONEDA_SIMBOLO) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.USUARIOS_USUARIO != original.USUARIOS_USUARIO) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsDESCUENTO_MAXIMONull != original.IsDESCUENTO_MAXIMONull) return true;
			if (!this.IsDESCUENTO_MAXIMONull && !original.IsDESCUENTO_MAXIMONull)
				if (this.DESCUENTO_MAXIMO != original.DESCUENTO_MAXIMO) return true;
			if (this.IsCANTIDAD_MINIMANull != original.IsCANTIDAD_MINIMANull) return true;
			if (!this.IsCANTIDAD_MINIMANull && !original.IsCANTIDAD_MINIMANull)
				if (this.CANTIDAD_MINIMA != original.CANTIDAD_MINIMA) return true;
			if (this.IsMARCA_IDNull != original.IsMARCA_IDNull) return true;
			if (!this.IsMARCA_IDNull && !original.IsMARCA_IDNull)
				if (this.MARCA_ID != original.MARCA_ID) return true;
			if (this.NOMBRE_MARCA != original.NOMBRE_MARCA) return true;
			
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_EMPRESA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_EMPRESA</c> column value.</value>
		public string CODIGO_EMPRESA
		{
			get { return _codigo_empresa; }
			set { _codigo_empresa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_DESCRIPCION_INTERNA</c> column value.</value>
		public string ARTICULO_DESCRIPCION_INTERNA
		{
			get { return _articulo_descripcion_interna; }
			set { _articulo_descripcion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULOS_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULOS_FAMILIA_ID
		{
			get
			{
				if(IsARTICULOS_FAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulos_familia_id;
			}
			set
			{
				_articulos_familia_idNull = false;
				_articulos_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULOS_FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULOS_FAMILIA_IDNull
		{
			get { return _articulos_familia_idNull; }
			set { _articulos_familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_FAMILIA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_FAMILIA_NOMBRE</c> column value.</value>
		public string ARTICULOS_FAMILIA_NOMBRE
		{
			get { return _articulos_familia_nombre; }
			set { _articulos_familia_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULOS_GRUPO_ID</c> column value.</value>
		public decimal ARTICULOS_GRUPO_ID
		{
			get
			{
				if(IsARTICULOS_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulos_grupo_id;
			}
			set
			{
				_articulos_grupo_idNull = false;
				_articulos_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULOS_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULOS_GRUPO_IDNull
		{
			get { return _articulos_grupo_idNull; }
			set { _articulos_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_GRUPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_GRUPO_NOMBRE</c> column value.</value>
		public string ARTICULOS_GRUPO_NOMBRE
		{
			get { return _articulos_grupo_nombre; }
			set { _articulos_grupo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_SUB_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULOS_SUB_GRUPO_ID</c> column value.</value>
		public decimal ARTICULOS_SUB_GRUPO_ID
		{
			get
			{
				if(IsARTICULOS_SUB_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulos_sub_grupo_id;
			}
			set
			{
				_articulos_sub_grupo_idNull = false;
				_articulos_sub_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULOS_SUB_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULOS_SUB_GRUPO_IDNull
		{
			get { return _articulos_sub_grupo_idNull; }
			set { _articulos_sub_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_SUBGRUPOS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULOS_SUBGRUPOS_NOMBRE</c> column value.</value>
		public string ARTICULOS_SUBGRUPOS_NOMBRE
		{
			get { return _articulos_subgrupos_nombre; }
			set { _articulos_subgrupos_nombre = value; }
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
		/// Gets or sets the <c>SUCURSALES_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSALES_NOMBRE</c> column value.</value>
		public string SUCURSALES_NOMBRE
		{
			get { return _sucursales_nombre; }
			set { _sucursales_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSALES_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSALES_ABREVIATURA</c> column value.</value>
		public string SUCURSALES_ABREVIATURA
		{
			get { return _sucursales_abreviatura; }
			set { _sucursales_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSALES_ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSALES_ENTIDAD_ID</c> column value.</value>
		public decimal SUCURSALES_ENTIDAD_ID
		{
			get { return _sucursales_entidad_id; }
			set { _sucursales_entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSALES_ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSALES_ENTIDAD_NOMBRE</c> column value.</value>
		public string SUCURSALES_ENTIDAD_NOMBRE
		{
			get { return _sucursales_entidad_nombre; }
			set { _sucursales_entidad_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_NOMBRE</c> column value.</value>
		public string MONEDAS_NOMBRE
		{
			get { return _monedas_nombre; }
			set { _monedas_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDAS_SIMBOLO</c> column value.
		/// </summary>
		/// <value>The <c>MONEDAS_SIMBOLO</c> column value.</value>
		public string MONEDAS_SIMBOLO
		{
			get { return _monedas_simbolo; }
			set { _monedas_simbolo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION_MONEDA</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION_MONEDA</c> column value.</value>
		public decimal COTIZACION_MONEDA
		{
			get { return _cotizacion_moneda; }
			set { _cotizacion_moneda = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECIO</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO</c> column value.</value>
		public decimal PRECIO
		{
			get { return _precio; }
			set { _precio = value; }
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
		/// Gets or sets the <c>IMPUESTOS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>IMPUESTOS_NOMBRE</c> column value.</value>
		public string IMPUESTOS_NOMBRE
		{
			get { return _impuestos_nombre; }
			set { _impuestos_nombre = value; }
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
		/// Gets or sets the <c>COSTO_MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_ID</c> column value.</value>
		public decimal COSTO_MONEDA_ID
		{
			get
			{
				if(IsCOSTO_MONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_moneda_id;
			}
			set
			{
				_costo_moneda_idNull = false;
				_costo_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONEDA_IDNull
		{
			get { return _costo_moneda_idNull; }
			set { _costo_moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_COTIZACION</c> column value.</value>
		public decimal COSTO_MONEDA_COTIZACION
		{
			get
			{
				if(IsCOSTO_MONEDA_COTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _costo_moneda_cotizacion;
			}
			set
			{
				_costo_moneda_cotizacionNull = false;
				_costo_moneda_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COSTO_MONEDA_COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOSTO_MONEDA_COTIZACIONNull
		{
			get { return _costo_moneda_cotizacionNull; }
			set { _costo_moneda_cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COSTO_MONEDA_SIMBOLO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COSTO_MONEDA_SIMBOLO</c> column value.</value>
		public string COSTO_MONEDA_SIMBOLO
		{
			get { return _costo_moneda_simbolo; }
			set { _costo_moneda_simbolo = value; }
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
		/// Gets or sets the <c>USUARIOS_USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIOS_USUARIO</c> column value.</value>
		public string USUARIOS_USUARIO
		{
			get { return _usuarios_usuario; }
			set { _usuarios_usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_MAXIMO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_MAXIMO</c> column value.</value>
		public decimal DESCUENTO_MAXIMO
		{
			get
			{
				if(IsDESCUENTO_MAXIMONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_maximo;
			}
			set
			{
				_descuento_maximoNull = false;
				_descuento_maximo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_MAXIMO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_MAXIMONull
		{
			get { return _descuento_maximoNull; }
			set { _descuento_maximoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MINIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_MINIMA</c> column value.</value>
		public decimal CANTIDAD_MINIMA
		{
			get
			{
				if(IsCANTIDAD_MINIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_minima;
			}
			set
			{
				_cantidad_minimaNull = false;
				_cantidad_minima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_MINIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_MINIMANull
		{
			get { return _cantidad_minimaNull; }
			set { _cantidad_minimaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCA_ID</c> column value.</value>
		public decimal MARCA_ID
		{
			get
			{
				if(IsMARCA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _marca_id;
			}
			set
			{
				_marca_idNull = false;
				_marca_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MARCA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMARCA_IDNull
		{
			get { return _marca_idNull; }
			set { _marca_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_MARCA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_MARCA</c> column value.</value>
		public string NOMBRE_MARCA
		{
			get { return _nombre_marca; }
			set { _nombre_marca = value; }
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
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@CODIGO_EMPRESA=");
			dynStr.Append(CODIGO_EMPRESA);
			dynStr.Append("@CBA@ARTICULO_DESCRIPCION_INTERNA=");
			dynStr.Append(ARTICULO_DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@ARTICULOS_FAMILIA_ID=");
			dynStr.Append(IsARTICULOS_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULOS_FAMILIA_ID);
			dynStr.Append("@CBA@ARTICULOS_FAMILIA_NOMBRE=");
			dynStr.Append(ARTICULOS_FAMILIA_NOMBRE);
			dynStr.Append("@CBA@ARTICULOS_GRUPO_ID=");
			dynStr.Append(IsARTICULOS_GRUPO_IDNull ? (object)"<NULL>" : ARTICULOS_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULOS_GRUPO_NOMBRE=");
			dynStr.Append(ARTICULOS_GRUPO_NOMBRE);
			dynStr.Append("@CBA@ARTICULOS_SUB_GRUPO_ID=");
			dynStr.Append(IsARTICULOS_SUB_GRUPO_IDNull ? (object)"<NULL>" : ARTICULOS_SUB_GRUPO_ID);
			dynStr.Append("@CBA@ARTICULOS_SUBGRUPOS_NOMBRE=");
			dynStr.Append(ARTICULOS_SUBGRUPOS_NOMBRE);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSALES_NOMBRE=");
			dynStr.Append(SUCURSALES_NOMBRE);
			dynStr.Append("@CBA@SUCURSALES_ABREVIATURA=");
			dynStr.Append(SUCURSALES_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSALES_ENTIDAD_ID=");
			dynStr.Append(SUCURSALES_ENTIDAD_ID);
			dynStr.Append("@CBA@SUCURSALES_ENTIDAD_NOMBRE=");
			dynStr.Append(SUCURSALES_ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@MONEDAS_NOMBRE=");
			dynStr.Append(MONEDAS_NOMBRE);
			dynStr.Append("@CBA@MONEDAS_SIMBOLO=");
			dynStr.Append(MONEDAS_SIMBOLO);
			dynStr.Append("@CBA@COTIZACION_MONEDA=");
			dynStr.Append(COTIZACION_MONEDA);
			dynStr.Append("@CBA@PRECIO=");
			dynStr.Append(PRECIO);
			dynStr.Append("@CBA@IMPUESTO_ID=");
			dynStr.Append(IMPUESTO_ID);
			dynStr.Append("@CBA@IMPUESTOS_NOMBRE=");
			dynStr.Append(IMPUESTOS_NOMBRE);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(IsCOSTONull ? (object)"<NULL>" : COSTO);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(IsCOSTO_MONEDA_IDNull ? (object)"<NULL>" : COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_MONEDA_COTIZACION=");
			dynStr.Append(IsCOSTO_MONEDA_COTIZACIONNull ? (object)"<NULL>" : COSTO_MONEDA_COTIZACION);
			dynStr.Append("@CBA@COSTO_MONEDA_SIMBOLO=");
			dynStr.Append(COSTO_MONEDA_SIMBOLO);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@USUARIOS_USUARIO=");
			dynStr.Append(USUARIOS_USUARIO);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@DESCUENTO_MAXIMO=");
			dynStr.Append(IsDESCUENTO_MAXIMONull ? (object)"<NULL>" : DESCUENTO_MAXIMO);
			dynStr.Append("@CBA@CANTIDAD_MINIMA=");
			dynStr.Append(IsCANTIDAD_MINIMANull ? (object)"<NULL>" : CANTIDAD_MINIMA);
			dynStr.Append("@CBA@MARCA_ID=");
			dynStr.Append(IsMARCA_IDNull ? (object)"<NULL>" : MARCA_ID);
			dynStr.Append("@CBA@NOMBRE_MARCA=");
			dynStr.Append(NOMBRE_MARCA);
			return dynStr.ToString();
		}
	} // End of ART_PRECIOS_HIST_INFO_COMPLRow_Base class
} // End of namespace
