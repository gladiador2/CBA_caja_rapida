// <fileinfo name="STOCK_UBICACION_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="STOCK_UBICACION_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>STOCK_UBICACION_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="STOCK_UBICACION_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_UBICACION_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _stock_suc_dep_art_id;
		private string _pasillo;
		private string _estante;
		private string _nivel;
		private string _columna;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _articulo_id;
		private string _articulo_codigo;
		private string _articulo_nombre;
		private decimal _articulo_lote_id;
		private bool _articulo_lote_idNull = true;
		private string _lote_descripcion;
		private decimal _deposito_id;
		private string _deposito_abreviatura;
		private decimal _sucursal_id;
		private string _sucursal_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_UBICACION_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public STOCK_UBICACION_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(STOCK_UBICACION_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.STOCK_SUC_DEP_ART_ID != original.STOCK_SUC_DEP_ART_ID) return true;
			if (this.PASILLO != original.PASILLO) return true;
			if (this.ESTANTE != original.ESTANTE) return true;
			if (this.NIVEL != original.NIVEL) return true;
			if (this.COLUMNA != original.COLUMNA) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.ARTICULO_CODIGO != original.ARTICULO_CODIGO) return true;
			if (this.ARTICULO_NOMBRE != original.ARTICULO_NOMBRE) return true;
			if (this.IsARTICULO_LOTE_IDNull != original.IsARTICULO_LOTE_IDNull) return true;
			if (!this.IsARTICULO_LOTE_IDNull && !original.IsARTICULO_LOTE_IDNull)
				if (this.ARTICULO_LOTE_ID != original.ARTICULO_LOTE_ID) return true;
			if (this.LOTE_DESCRIPCION != original.LOTE_DESCRIPCION) return true;
			if (this.DEPOSITO_ID != original.DEPOSITO_ID) return true;
			if (this.DEPOSITO_ABREVIATURA != original.DEPOSITO_ABREVIATURA) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			
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
		/// Gets or sets the <c>STOCK_SUC_DEP_ART_ID</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_SUC_DEP_ART_ID</c> column value.</value>
		public decimal STOCK_SUC_DEP_ART_ID
		{
			get { return _stock_suc_dep_art_id; }
			set { _stock_suc_dep_art_id = value; }
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
		/// Gets or sets the <c>LOTE_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_DESCRIPCION</c> column value.</value>
		public string LOTE_DESCRIPCION
		{
			get { return _lote_descripcion; }
			set { _lote_descripcion = value; }
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
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
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
			dynStr.Append("@CBA@STOCK_SUC_DEP_ART_ID=");
			dynStr.Append(STOCK_SUC_DEP_ART_ID);
			dynStr.Append("@CBA@PASILLO=");
			dynStr.Append(PASILLO);
			dynStr.Append("@CBA@ESTANTE=");
			dynStr.Append(ESTANTE);
			dynStr.Append("@CBA@NIVEL=");
			dynStr.Append(NIVEL);
			dynStr.Append("@CBA@COLUMNA=");
			dynStr.Append(COLUMNA);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@ARTICULO_CODIGO=");
			dynStr.Append(ARTICULO_CODIGO);
			dynStr.Append("@CBA@ARTICULO_NOMBRE=");
			dynStr.Append(ARTICULO_NOMBRE);
			dynStr.Append("@CBA@ARTICULO_LOTE_ID=");
			dynStr.Append(IsARTICULO_LOTE_IDNull ? (object)"<NULL>" : ARTICULO_LOTE_ID);
			dynStr.Append("@CBA@LOTE_DESCRIPCION=");
			dynStr.Append(LOTE_DESCRIPCION);
			dynStr.Append("@CBA@DEPOSITO_ID=");
			dynStr.Append(DEPOSITO_ID);
			dynStr.Append("@CBA@DEPOSITO_ABREVIATURA=");
			dynStr.Append(DEPOSITO_ABREVIATURA);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			return dynStr.ToString();
		}
	} // End of STOCK_UBICACION_INFO_COMPLETARow_Base class
} // End of namespace
