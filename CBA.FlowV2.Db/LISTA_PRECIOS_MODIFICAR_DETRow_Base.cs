// <fileinfo name="LISTA_PRECIOS_MODIFICAR_DETRow_Base.cs">
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
	/// The base class for <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> that 
	/// represents a record in the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LISTA_PRECIOS_MODIFICAR_DETRow_Base
	{
		private decimal _id;
		private decimal _lista_precios_modificar_id;
		private decimal _articulo_id;
		private decimal _precio_nuevo;
		private decimal _costo;
		private decimal _margen_rentabilidad;
		private decimal _cantidad_minima;
		private decimal _descuento_maximo;
		private string _quitar_articulo_de_lista;
		private decimal _costo_moneda_id;
		private decimal _costo_cotizacion;
		private System.DateTime _fecha_inicio;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOS_MODIFICAR_DETRow_Base"/> class.
		/// </summary>
		public LISTA_PRECIOS_MODIFICAR_DETRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LISTA_PRECIOS_MODIFICAR_DETRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LISTA_PRECIOS_MODIFICAR_ID != original.LISTA_PRECIOS_MODIFICAR_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.PRECIO_NUEVO != original.PRECIO_NUEVO) return true;
			if (this.COSTO != original.COSTO) return true;
			if (this.MARGEN_RENTABILIDAD != original.MARGEN_RENTABILIDAD) return true;
			if (this.CANTIDAD_MINIMA != original.CANTIDAD_MINIMA) return true;
			if (this.DESCUENTO_MAXIMO != original.DESCUENTO_MAXIMO) return true;
			if (this.QUITAR_ARTICULO_DE_LISTA != original.QUITAR_ARTICULO_DE_LISTA) return true;
			if (this.COSTO_MONEDA_ID != original.COSTO_MONEDA_ID) return true;
			if (this.COSTO_COTIZACION != original.COSTO_COTIZACION) return true;
			if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			
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
		/// Gets or sets the <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.
		/// </summary>
		/// <value>The <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.</value>
		public decimal LISTA_PRECIOS_MODIFICAR_ID
		{
			get { return _lista_precios_modificar_id; }
			set { _lista_precios_modificar_id = value; }
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
		/// Gets or sets the <c>PRECIO_NUEVO</c> column value.
		/// </summary>
		/// <value>The <c>PRECIO_NUEVO</c> column value.</value>
		public decimal PRECIO_NUEVO
		{
			get { return _precio_nuevo; }
			set { _precio_nuevo = value; }
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
		/// Gets or sets the <c>MARGEN_RENTABILIDAD</c> column value.
		/// </summary>
		/// <value>The <c>MARGEN_RENTABILIDAD</c> column value.</value>
		public decimal MARGEN_RENTABILIDAD
		{
			get { return _margen_rentabilidad; }
			set { _margen_rentabilidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_MINIMA</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_MINIMA</c> column value.</value>
		public decimal CANTIDAD_MINIMA
		{
			get { return _cantidad_minima; }
			set { _cantidad_minima = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_MAXIMO</c> column value.
		/// </summary>
		/// <value>The <c>DESCUENTO_MAXIMO</c> column value.</value>
		public decimal DESCUENTO_MAXIMO
		{
			get { return _descuento_maximo; }
			set { _descuento_maximo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>QUITAR_ARTICULO_DE_LISTA</c> column value.
		/// </summary>
		/// <value>The <c>QUITAR_ARTICULO_DE_LISTA</c> column value.</value>
		public string QUITAR_ARTICULO_DE_LISTA
		{
			get { return _quitar_articulo_de_lista; }
			set { _quitar_articulo_de_lista = value; }
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
		/// Gets or sets the <c>COSTO_COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COSTO_COTIZACION</c> column value.</value>
		public decimal COSTO_COTIZACION
		{
			get { return _costo_cotizacion; }
			set { _costo_cotizacion = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@LISTA_PRECIOS_MODIFICAR_ID=");
			dynStr.Append(LISTA_PRECIOS_MODIFICAR_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@PRECIO_NUEVO=");
			dynStr.Append(PRECIO_NUEVO);
			dynStr.Append("@CBA@COSTO=");
			dynStr.Append(COSTO);
			dynStr.Append("@CBA@MARGEN_RENTABILIDAD=");
			dynStr.Append(MARGEN_RENTABILIDAD);
			dynStr.Append("@CBA@CANTIDAD_MINIMA=");
			dynStr.Append(CANTIDAD_MINIMA);
			dynStr.Append("@CBA@DESCUENTO_MAXIMO=");
			dynStr.Append(DESCUENTO_MAXIMO);
			dynStr.Append("@CBA@QUITAR_ARTICULO_DE_LISTA=");
			dynStr.Append(QUITAR_ARTICULO_DE_LISTA);
			dynStr.Append("@CBA@COSTO_MONEDA_ID=");
			dynStr.Append(COSTO_MONEDA_ID);
			dynStr.Append("@CBA@COSTO_COTIZACION=");
			dynStr.Append(COSTO_COTIZACION);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			return dynStr.ToString();
		}
	} // End of LISTA_PRECIOS_MODIFICAR_DETRow_Base class
} // End of namespace
