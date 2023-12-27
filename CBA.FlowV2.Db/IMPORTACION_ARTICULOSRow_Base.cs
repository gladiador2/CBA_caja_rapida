// <fileinfo name="IMPORTACION_ARTICULOSRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACION_ARTICULOSRow"/> that 
	/// represents a record in the <c>IMPORTACION_ARTICULOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACION_ARTICULOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACION_ARTICULOSRow_Base
	{
		private decimal _factura_proveedor_id;
		private string _stock_deposito_nombre;
		private string _proveedor_nombre;
		private decimal _proveedor_id;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _articulo_id;
		private string _descripcion_interna;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private string _familia_descripcion;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private string _grupo_descripcion;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _subgrupo_descripcion;
		private decimal _importacion_id;
		private string _nombre_interno;
		private string _numero_bl;
		private string _embarcador;
		private System.DateTime _fecha_salida;
		private bool _fecha_salidaNull = true;
		private decimal _cantidad_importacion;
		private bool _cantidad_importacionNull = true;
		private decimal _existencia;
		private bool _existenciaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACION_ARTICULOSRow_Base"/> class.
		/// </summary>
		public IMPORTACION_ARTICULOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACION_ARTICULOSRow_Base original)
		{
			if (this.FACTURA_PROVEEDOR_ID != original.FACTURA_PROVEEDOR_ID) return true;
			if (this.STOCK_DEPOSITO_NOMBRE != original.STOCK_DEPOSITO_NOMBRE) return true;
			if (this.PROVEEDOR_NOMBRE != original.PROVEEDOR_NOMBRE) return true;
			if (this.PROVEEDOR_ID != original.PROVEEDOR_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			if (this.IMPORTACION_ID != original.IMPORTACION_ID) return true;
			if (this.NOMBRE_INTERNO != original.NOMBRE_INTERNO) return true;
			if (this.NUMERO_BL != original.NUMERO_BL) return true;
			if (this.EMBARCADOR != original.EMBARCADOR) return true;
			if (this.IsFECHA_SALIDANull != original.IsFECHA_SALIDANull) return true;
			if (!this.IsFECHA_SALIDANull && !original.IsFECHA_SALIDANull)
				if (this.FECHA_SALIDA != original.FECHA_SALIDA) return true;
			if (this.IsCANTIDAD_IMPORTACIONNull != original.IsCANTIDAD_IMPORTACIONNull) return true;
			if (!this.IsCANTIDAD_IMPORTACIONNull && !original.IsCANTIDAD_IMPORTACIONNull)
				if (this.CANTIDAD_IMPORTACION != original.CANTIDAD_IMPORTACION) return true;
			if (this.IsEXISTENCIANull != original.IsEXISTENCIANull) return true;
			if (!this.IsEXISTENCIANull && !original.IsEXISTENCIANull)
				if (this.EXISTENCIA != original.EXISTENCIA) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FACTURA_PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>FACTURA_PROVEEDOR_ID</c> column value.</value>
		public decimal FACTURA_PROVEEDOR_ID
		{
			get { return _factura_proveedor_id; }
			set { _factura_proveedor_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>STOCK_DEPOSITO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>STOCK_DEPOSITO_NOMBRE</c> column value.</value>
		public string STOCK_DEPOSITO_NOMBRE
		{
			get { return _stock_deposito_nombre; }
			set { _stock_deposito_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROVEEDOR_NOMBRE</c> column value.</value>
		public string PROVEEDOR_NOMBRE
		{
			get { return _proveedor_nombre; }
			set { _proveedor_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROVEEDOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>PROVEEDOR_ID</c> column value.</value>
		public decimal PROVEEDOR_ID
		{
			get { return _proveedor_id; }
			set { _proveedor_id = value; }
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
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get { return _articulo_id; }
			set { _articulo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_INTERNA</c> column value.</value>
		public string DESCRIPCION_INTERNA
		{
			get { return _descripcion_interna; }
			set { _descripcion_interna = value; }
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
		/// Gets or sets the <c>IMPORTACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>IMPORTACION_ID</c> column value.</value>
		public decimal IMPORTACION_ID
		{
			get { return _importacion_id; }
			set { _importacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_INTERNO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_INTERNO</c> column value.</value>
		public string NOMBRE_INTERNO
		{
			get { return _nombre_interno; }
			set { _nombre_interno = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_BL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_BL</c> column value.</value>
		public string NUMERO_BL
		{
			get { return _numero_bl; }
			set { _numero_bl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMBARCADOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMBARCADOR</c> column value.</value>
		public string EMBARCADOR
		{
			get { return _embarcador; }
			set { _embarcador = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA</c> column value.</value>
		public System.DateTime FECHA_SALIDA
		{
			get
			{
				if(IsFECHA_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida;
			}
			set
			{
				_fecha_salidaNull = false;
				_fecha_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDANull
		{
			get { return _fecha_salidaNull; }
			set { _fecha_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_IMPORTACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_IMPORTACION</c> column value.</value>
		public decimal CANTIDAD_IMPORTACION
		{
			get
			{
				if(IsCANTIDAD_IMPORTACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_importacion;
			}
			set
			{
				_cantidad_importacionNull = false;
				_cantidad_importacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_IMPORTACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_IMPORTACIONNull
		{
			get { return _cantidad_importacionNull; }
			set { _cantidad_importacionNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FACTURA_PROVEEDOR_ID=");
			dynStr.Append(FACTURA_PROVEEDOR_ID);
			dynStr.Append("@CBA@STOCK_DEPOSITO_NOMBRE=");
			dynStr.Append(STOCK_DEPOSITO_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_NOMBRE=");
			dynStr.Append(PROVEEDOR_NOMBRE);
			dynStr.Append("@CBA@PROVEEDOR_ID=");
			dynStr.Append(PROVEEDOR_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(ARTICULO_ID);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			dynStr.Append("@CBA@IMPORTACION_ID=");
			dynStr.Append(IMPORTACION_ID);
			dynStr.Append("@CBA@NOMBRE_INTERNO=");
			dynStr.Append(NOMBRE_INTERNO);
			dynStr.Append("@CBA@NUMERO_BL=");
			dynStr.Append(NUMERO_BL);
			dynStr.Append("@CBA@EMBARCADOR=");
			dynStr.Append(EMBARCADOR);
			dynStr.Append("@CBA@FECHA_SALIDA=");
			dynStr.Append(IsFECHA_SALIDANull ? (object)"<NULL>" : FECHA_SALIDA);
			dynStr.Append("@CBA@CANTIDAD_IMPORTACION=");
			dynStr.Append(IsCANTIDAD_IMPORTACIONNull ? (object)"<NULL>" : CANTIDAD_IMPORTACION);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(IsEXISTENCIANull ? (object)"<NULL>" : EXISTENCIA);
			return dynStr.ToString();
		}
	} // End of IMPORTACION_ARTICULOSRow_Base class
} // End of namespace
