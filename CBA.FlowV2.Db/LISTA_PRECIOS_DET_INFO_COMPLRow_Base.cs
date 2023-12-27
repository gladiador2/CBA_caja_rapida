// <fileinfo name="LISTA_PRECIOS_DET_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> that 
	/// represents a record in the <c>LISTA_PRECIOS_DET_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LISTA_PRECIOS_DET_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _lista_precio_id;
		private string _lista_precios_nombre;
		private string _lista_precios_abreviatura;
		private decimal _lista_precios_moneda_id;
		private string _lista_precios_moneda_nombre;
		private decimal _cantidad_minima;
		private bool _cantidad_minimaNull = true;
		private decimal _descuento_maximo;
		private bool _descuento_maximoNull = true;
		private decimal _precio;
		private bool _precioNull = true;
		private decimal _articulo_id;
		private string _articulo_nombre;
		private decimal _cantidad_restante;
		private bool _cantidad_restanteNull = true;
		private string _familia_descripcion;
		private string _grupo_descripcion;
		private string _subgrupo_descripcion;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _codigo_empresa;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public LISTA_PRECIOS_DET_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LISTA_PRECIOS_DET_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			if (this.LISTA_PRECIOS_NOMBRE != original.LISTA_PRECIOS_NOMBRE) return true;
			if (this.LISTA_PRECIOS_ABREVIATURA != original.LISTA_PRECIOS_ABREVIATURA) return true;
			if (this.LISTA_PRECIOS_MONEDA_ID != original.LISTA_PRECIOS_MONEDA_ID) return true;
			if (this.LISTA_PRECIOS_MONEDA_NOMBRE != original.LISTA_PRECIOS_MONEDA_NOMBRE) return true;
			if (this.IsCANTIDAD_MINIMANull != original.IsCANTIDAD_MINIMANull) return true;
			if (!this.IsCANTIDAD_MINIMANull && !original.IsCANTIDAD_MINIMANull)
				if (this.CANTIDAD_MINIMA != original.CANTIDAD_MINIMA) return true;
			if (this.IsDESCUENTO_MAXIMONull != original.IsDESCUENTO_MAXIMONull) return true;
			if (!this.IsDESCUENTO_MAXIMONull && !original.IsDESCUENTO_MAXIMONull)
				if (this.DESCUENTO_MAXIMO != original.DESCUENTO_MAXIMO) return true;
			if (this.IsPRECIONull != original.IsPRECIONull) return true;
			if (!this.IsPRECIONull && !original.IsPRECIONull)
				if (this.PRECIO != original.PRECIO) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_NOMBRE != original.ARTICULO_NOMBRE) return true;
			if (this.IsCANTIDAD_RESTANTENull != original.IsCANTIDAD_RESTANTENull) return true;
			if (!this.IsCANTIDAD_RESTANTENull && !original.IsCANTIDAD_RESTANTENull)
				if (this.CANTIDAD_RESTANTE != original.CANTIDAD_RESTANTE) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.CODIGO_EMPRESA != original.CODIGO_EMPRESA) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get { return _lista_precio_id; }
			set { _lista_precio_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIOS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_NOMBRE</c> column value.</value>
		public string LISTA_PRECIOS_NOMBRE
		{
			get { return _lista_precios_nombre; }
			set { _lista_precios_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIOS_ABREVIATURA</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_ABREVIATURA</c> column value.</value>
		public string LISTA_PRECIOS_ABREVIATURA
		{
			get { return _lista_precios_abreviatura; }
			set { _lista_precios_abreviatura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIOS_MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_MONEDA_ID</c> column value.</value>
		public decimal LISTA_PRECIOS_MONEDA_ID
		{
			get { return _lista_precios_moneda_id; }
			set { _lista_precios_moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LISTA_PRECIOS_MONEDA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_MONEDA_NOMBRE</c> column value.</value>
		public string LISTA_PRECIOS_MONEDA_NOMBRE
		{
			get { return _lista_precios_moneda_nombre; }
			set { _lista_precios_moneda_nombre = value; }
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
		/// Gets or sets the <c>PRECIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECIO</c> column value.</value>
		public decimal PRECIO
		{
			get
			{
				if(IsPRECIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _precio;
			}
			set
			{
				_precioNull = false;
				_precio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PRECIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPRECIONull
		{
			get { return _precioNull; }
			set { _precioNull = value; }
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
		/// Gets or sets the <c>ARTICULO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_NOMBRE</c> column value.</value>
		public string ARTICULO_NOMBRE
		{
			get { return _articulo_nombre; }
			set { _articulo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_RESTANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_RESTANTE</c> column value.</value>
		public decimal CANTIDAD_RESTANTE
		{
			get
			{
				if(IsCANTIDAD_RESTANTENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_restante;
			}
			set
			{
				_cantidad_restanteNull = false;
				_cantidad_restante = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_RESTANTE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_RESTANTENull
		{
			get { return _cantidad_restanteNull; }
			set { _cantidad_restanteNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_DESCRIPCION</c> column value.</value>
		public string FAMILIA_DESCRIPCION
		{
			get { return _familia_descripcion; }
			set { _familia_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_DESCRIPCION</c> column value.</value>
		public string GRUPO_DESCRIPCION
		{
			get { return _grupo_descripcion; }
			set { _grupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_DESCRIPCION</c> column value.</value>
		public string SUBGRUPO_DESCRIPCION
		{
			get { return _subgrupo_descripcion; }
			set { _subgrupo_descripcion = value; }
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
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get { return _fecha_inicio; }
			set { _fecha_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(LISTA_PRECIO_ID);
			dynStr.Append("@CBA@LISTA_PRECIOS_NOMBRE=");
			dynStr.Append(LISTA_PRECIOS_NOMBRE);
			dynStr.Append("@CBA@LISTA_PRECIOS_ABREVIATURA=");
			dynStr.Append(LISTA_PRECIOS_ABREVIATURA);
			dynStr.Append("@CBA@LISTA_PRECIOS_MONEDA_ID=");
			dynStr.Append(LISTA_PRECIOS_MONEDA_ID);
			dynStr.Append("@CBA@LISTA_PRECIOS_MONEDA_NOMBRE=");
			dynStr.Append(LISTA_PRECIOS_MONEDA_NOMBRE);
			dynStr.Append("@CBA@CANTIDAD_MINIMA=");
			dynStr.Append(IsCANTIDAD_MINIMANull ? (object)"<NULL>" : CANTIDAD_MINIMA);
			dynStr.Append("@CBA@DESCUENTO_MAXIMO=");
			dynStr.Append(IsDESCUENTO_MAXIMONull ? (object)"<NULL>" : DESCUENTO_MAXIMO);
			dynStr.Append("@CBA@PRECIO=");
			dynStr.Append(IsPRECIONull ? (object)"<NULL>" : PRECIO);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_NOMBRE=");
			dynStr.Append(ARTICULO_NOMBRE);
			dynStr.Append("@CBA@CANTIDAD_RESTANTE=");
			dynStr.Append(IsCANTIDAD_RESTANTENull ? (object)"<NULL>" : CANTIDAD_RESTANTE);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@CODIGO_EMPRESA=");
			dynStr.Append(CODIGO_EMPRESA);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of LISTA_PRECIOS_DET_INFO_COMPLRow_Base class
} // End of namespace
